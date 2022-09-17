using Dapper;
using Microsoft.Extensions.Configuration;
using Sandy.Application;
using Sandy.Core.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sandy.Infrastructure.Repositories
{
    public class RecruiterProfileRepository : IRecruiterProfileRepository
    {
        private readonly IConfiguration configuration;
        public RecruiterProfileRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public async Task<int> AddAsync(RecruiterProfile entity)
        {
            var sql = "Insert into RecruiterProfiles (FirstName,LastName,MobileNumber,EmailID,CompanyID) VALUES (@FirstName,@LastName,@MobileNumber,@EmailID,@CompanyID)";
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.ExecuteAsync(sql, entity);
                return result;
            }
        }

        public async Task<int> DeleteAsync(int id)
        {
            var sql = "DELETE FROM RecruiterProfiles WHERE ID = @ID";
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.ExecuteAsync(sql, new { Id = id });
                return result;
            }
        }

        public async Task<IReadOnlyList<RecruiterProfile>> GetAllAsync()
        {
            var sql = "SELECT * FROM RecruiterProfiles";
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.QueryAsync<RecruiterProfile>(sql);
                return result.ToList();
            }
        }

        public async Task<RecruiterProfile> GetByIdAsync(int id)
        {
            var sql = "SELECT * FROM RecruiterProfiles WHERE ID = @ID";
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.QuerySingleOrDefaultAsync<RecruiterProfile>(sql, new { Id = id });
                return result;
            }
        }

        public async Task<int> UpdateAsync(RecruiterProfile entity)
        {
            var sql = "UPDATE RecruiterProfiles SET FirstName = @FirstName, LastName = @LastName, MobileNumber = @MobileNumber, EmailID = @EmailID, CompanyID = @CompanyID  WHERE ID = @ID";
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.ExecuteAsync(sql, entity);
                return result;
            }
        }
    }
}
