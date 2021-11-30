using System;
using System.Threading.Tasks;
using Unittest.Api.Domains;
using Unittest.Api.Models;
using Unittest.Api.Repositories;

namespace Unittest.Api.Services
{
    public interface ICustomerService
    {
        Task<Customer> CreateCustomer(CustomerCreateDTO createModel);
    }

    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly INotificationSender _notificationSender;

        public CustomerService(ICustomerRepository customerRepository, INotificationSender notificationSender)
        {
            _customerRepository = customerRepository;
            _notificationSender = notificationSender;
        }

        public async Task<Customer> CreateCustomer(CustomerCreateDTO createModel)
        {
            var resultModel = new Customer()
            {
                Id = Guid.NewGuid().ToString(),
                Name = createModel.Name,
                Surname = createModel.Surname,
                Limit = createModel.Limit
            };

            var result = await _customerRepository.AddAsync(resultModel);
            if (result <= 0)
            {
                throw new Exception("Db fail");
            }


            _notificationSender.SendNotification("selam yeni müşteri");
            return resultModel;
        }

        private void BusinessLogin(string vl)
        {
            //rule
        }
    }
}