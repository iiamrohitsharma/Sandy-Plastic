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
    public class CompanyProfileRepository : ICompanyProfileRepository
    {
        private readonly IConfiguration configuration;
        public CompanyProfileRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public async Task<int> AddAsync(CompanyProfile entity)
        {
            var sql = "Insert into CompanyProfiles (Name,Description,IsActive) VALUES (@Name,@Description,@IsActive)";
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.ExecuteAsync(sql, entity);
                return result;
            }
        }

        public async Task<int> DeleteAsync(int id)
        {
            var sql = "DELETE FROM CompanyProfiles WHERE ID = @ID";
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.ExecuteAsync(sql, new { Id = id });
                return result;
            }
        }

        public async Task<IReadOnlyList<CompanyProfile>> GetAllAsync()
        {
            var sql = "SELECT * FROM CompanyProfiles";
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.QueryAsync<CompanyProfile>(sql);
                return result.ToList();
            }
        }

        public async Task<CompanyProfile> GetByIdAsync(int id)
        {
            var sql = "SELECT * FROM CompanyProfiles WHERE ID = @ID";
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.QuerySingleOrDefaultAsync<CompanyProfile>(sql, new { Id = id });
                return result;
            }
        }

        public async Task<int> UpdateAsync(CompanyProfile entity)
        {
            var sql = "UPDATE CompanyProfiles SET Name = @Name, Description = @Description, IsActive = @IsActive  WHERE ID = @ID";
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.ExecuteAsync(sql, entity);
                return result;
            }
        }
    }
}
