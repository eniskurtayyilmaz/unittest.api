using System;
using System.Threading.Tasks;
using AutoFixture;
using FluentAssertions;
using Moq;
using Unittest.Api.Domains;
using Unittest.Api.Models;
using Unittest.Api.Repositories;
using Unittest.Api.Services;
using Xunit;

namespace Unittest.Tests.Services
{
    public class CustomerServiceTests
    {
        public CustomerServiceTests()
        {
        }

        [Fact]
        public async Task Can_Create_New_Customer_When_Customer_Repository_Return_1()
        {
            //Arrange
            var createModel = new Fixture().Create<CustomerCreateDTO>();
            var customerRepository = new Mock<ICustomerRepository>();
            customerRepository.Setup(x => x.AddAsync(It.IsAny<Customer>()))
                .Callback<Customer>((entity) =>
                {
                    Assert.NotEqual(Guid.Empty.ToString(), entity.Id);
                    Assert.NotNull(entity.Id);
                    entity.Should().BeEquivalentTo(createModel);
                })
                .ReturnsAsync(() => 1);

            var mockNotificationSender = new Mock<INotificationSender>();

            var service = new CustomerService(customerRepository.Object, mockNotificationSender.Object);

            //Action
            var result = await service.CreateCustomer(createModel);

            
            //Assert
            Assert.NotEqual(Guid.Empty.ToString(), result.Id);
            Assert.NotNull(result.Id);
            result.Should().BeEquivalentTo(createModel);
            
            mockNotificationSender.Verify(x=> x.SendNotification(It.IsAny<string>()), Times.Once);
        }


        [Fact]
        public async Task Can_Create_New_Customer_When_Customer_Repository_Return_0()
        {
            //Arrange
            var createModel = new Fixture().Create<CustomerCreateDTO>();
            var customerRepository = new Mock<ICustomerRepository>();
            customerRepository
                .Setup(x => x.AddAsync(It.IsAny<Customer>()))
                .Callback<Customer>((entity) =>
                {
                    Assert.NotEqual(Guid.Empty.ToString(), entity.Id);
                    Assert.NotNull(entity.Id);
                    entity.Should().BeEquivalentTo(createModel);
                })
                .ReturnsAsync(() => 0);

            var mockNotificationSender = new Mock<INotificationSender>();

            var service = new CustomerService(customerRepository.Object, mockNotificationSender.Object);
            //Action
            var result = await Record.ExceptionAsync(() => service.CreateCustomer(createModel));

            //Assert
            result.Message.Should().Be("Db fail");
            result.Should().NotBeNull();
            
            mockNotificationSender.Verify(x=> x.SendNotification(It.IsAny<string>()), Times.Never);
            
        }
    }
}