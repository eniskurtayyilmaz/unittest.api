using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Dapper;
using Unittest.Api.Common;
using Unittest.Api.Domains;

namespace Unittest.Api.Repositories
{
    public interface ICustomerRepository : IBaseRepository<Customer>
    {
    }

    public class CustomerRepository : ICustomerRepository
    {
        private readonly IDatabaseConnectionFactory _connectionFactory;

        public CustomerRepository(IDatabaseConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }


        public Task<Customer> GetByIdAsync(string id)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<Customer>> GetAllAsync()
        {
            throw new System.NotImplementedException();
        }

        public async Task<int> AddAsync(Customer entity)
        {
            var parameters = new DynamicParameters();
            parameters.Add("Id", entity.Id, DbType.String);
            parameters.Add("Name", entity.Name, DbType.String);
            parameters.Add("Surname", entity.Surname, DbType.String);
            parameters.Add("Limit", entity.Limit, DbType.Decimal);

            var query = $"INSERT INTO {Constant.CustomerTableName} (Id, Name, Surname, Limit)" + Environment.NewLine +
                        "VALUES (@Id, @Name, @Surname, @Limit)";
            var connection = await _connectionFactory.CreateConnectionAsync();
            var result = await connection.ExecuteAsync(query, parameters);
            return result;
        }

        public Task<int> UpdateAsync(Customer entity)
        {
            throw new System.NotImplementedException();
        }

        public Task<int> DeleteAsync(string id)
        {
            throw new System.NotImplementedException();
        }
    }
}