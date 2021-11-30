using System;
using System.Threading.Tasks;
using FluentValidation.TestHelper;
using Unittest.Api.Models;
using Unittest.Api.Validators;
using Xunit;

namespace Unittest.Tests.Validators
{
    public class CustomerCreateValidatorTests
    {
        private readonly CustomerCreateValidator _validator;

        public CustomerCreateValidatorTests()
        {
            this._validator = new CustomerCreateValidator();
        }
        //
        // [Fact]
        // public async Task When_Customer_Name_Null_It_Should_Have_Error()
        // {
        //     //Arrange
        //     
        //     var model = new CustomerCreateDTO()
        //     {
        //         Name = null
        //     };
        //
        //     //Action
        //     var result = await _validator.TestValidateAsync(model);
        //
        //     //Assert
        //     result.ShouldHaveValidationErrorFor(x => x.Name)
        //         .WithErrorMessage("İsim null olamaz");
        // }
        //
        // [Fact]
        // public async Task When_Customer_Name_Empty_It_Should_Have_Error()
        // {
        //     //Arrange
        //     
        //     var model = new CustomerCreateDTO()
        //     {
        //         Name = String.Empty
        //     };
        //
        //     //Action
        //     var result = await _validator.TestValidateAsync(model);
        //
        //     //Assert
        //     result.ShouldHaveValidationErrorFor(x => x.Name)
        //         .WithErrorMessage("İsim boş olamaz");
        // }
        //
        // [Fact]
        // public async Task When_Customer_Name_Minimum_Length_2_It_Should_Have_Error()
        // {
        //     //Arrange
        //     
        //     var model = new CustomerCreateDTO()
        //     {
        //         Name = "ab"
        //     };
        //
        //     //Action
        //     var result = await _validator.TestValidateAsync(model);
        //
        //     //Assert
        //     result.ShouldHaveValidationErrorFor(x => x.Name)
        //         .WithErrorMessage("İsim minimum 3 karakter olmalıdır");
        // }

        [Theory]
        [InlineData(null, "İsim null olamaz")]
        [InlineData("", "İsim boş olamaz")]
        [InlineData("ab", "İsim minimum 3 karakter olmalıdır")]
        [InlineData("tr", "İsim minimum 3 karakter olmalıdır")]
        [InlineData("en", "İsim minimum 3 karakter olmalıdır")]
        public async Task When_Customer_Name_Invalid_It_Should_Have_Error(string name, string exceptedMessage)
        {
            
            var model = new CustomerCreateDTO()
            {
                Name = name
            };

            //Action
            var result = await _validator.TestValidateAsync(model);

            //Assert
            result.ShouldHaveValidationErrorFor(x => x.Name)
                .WithErrorMessage(exceptedMessage);
        }
        
        [Theory]
        [InlineData("Kurtay")]
        [InlineData("Appcent")]
        [InlineData("Koray")]
        [InlineData("Sena")]
        [InlineData("Ali")]
        [InlineData("Ata")]
        public async Task When_Customer_Name_Valid_It_Should_Not_Have_Error(string name)
        {
            
            var model = new CustomerCreateDTO()
            {
                Name = name
            };

            //Action
            var result = await _validator.TestValidateAsync(model);

            //Assert
            result.ShouldNotHaveValidationErrorFor(x => x.Name);
        }
        
        [Theory]
        [InlineData(null, "Soyisim null olamaz")]
        [InlineData("", "Soyisim boş olamaz")]
        [InlineData("ab", "Soyisim minimum 3 karakter olmalıdır")]
        [InlineData("tr", "Soyisim minimum 3 karakter olmalıdır")]
        [InlineData("en", "Soyisim minimum 3 karakter olmalıdır")]
        public async Task When_Customer_Surname_Invalid_It_Should_Have_Error(string surname, string exceptedMessage)
        {
            
            var model = new CustomerCreateDTO()
            {
                Surname = surname
            };

            //Action
            var result = await _validator.TestValidateAsync(model);

            //Assert
            result.ShouldHaveValidationErrorFor(x => x.Surname)
                .WithErrorMessage(exceptedMessage);
        }
        
        [Theory]
        [InlineData("Yılmaz")]
        [InlineData("Uysal")]
        [InlineData("Başer")]
        [InlineData("Ata")]
        public async Task When_Customer_Surname_Valid_It_Should_Not_Have_Error(string surname)
        {
            
            var model = new CustomerCreateDTO()
            {
                Surname = surname
            };

            //Action
            var result = await _validator.TestValidateAsync(model);

            //Assert
            result.ShouldNotHaveValidationErrorFor(x => x.Surname);
        }
        
        [Theory]
        [InlineData(0.01, "Limit minimum 1 olmalıdır")]
        [InlineData(-1.00, "Limit minimum 1 olmalıdır")]
        public async Task When_Customer_Limit_Invalid_It_Should_Have_Error(decimal limit, string exceptedMessage)
        {
            
            var model = new CustomerCreateDTO()
            {
                Limit = limit
            };

            //Action
            var result = await _validator.TestValidateAsync(model);

            //Assert
            result.ShouldHaveValidationErrorFor(x => x.Limit.Value)
                .WithErrorMessage(exceptedMessage);
        }
        
        [Theory]
        [InlineData(2)]
        [InlineData(1)]
        public async Task When_Customer_Limit_Valid_It_Should_Have_Error(decimal limit)
        {
            
            var model = new CustomerCreateDTO()
            {
                Limit = limit
            };

            //Action
            var result = await _validator.TestValidateAsync(model);

            //Assert
            result.ShouldNotHaveValidationErrorFor(x => x.Limit.Value);
        }
    }
}