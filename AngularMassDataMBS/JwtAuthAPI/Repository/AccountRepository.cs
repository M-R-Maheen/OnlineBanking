using JwtAuthAPI.Models.BankModel;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace JwtAuthAPI.Repository
{
    public class AccountRepository
    { 
        private readonly string _connectionString;

        public AccountRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("Dbcon");
        }

        public AccountRepository()
        {

        }

        public async Task<List<Account>> GetAll()
        {
            using (SqlConnection sql = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SpGetAllAccounts", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    var response = new List<Account>();
                    await sql.OpenAsync();

                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            response.Add(MapToValue(reader));
                        }
                    }

                    return response;
                }
            }
        }

        private Account MapToValue(SqlDataReader reader)
        {
            return new Account()
            {
                AccountID = (int)reader["AccountID"],
                AccountHolderName = reader["AccountHolderName"].ToString(),
                AccountNumber = reader["AccountNumber"].ToString(),
                AccountType = reader["AccountType"].ToString(),
                Gender = reader["Gender"].ToString(),
                Address = reader["Address"].ToString(),
                Picture = reader["Picture"].ToString(),
                CreatedDate = (DateTime)reader["CreatedDate"],
                Email = reader["Email"].ToString(),
                Password = reader["Password"].ToString(),
            };
        }

        public async Task<Account> GetByDeposotId(int AccountID)
        {
            using (SqlConnection sql = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SpGetByAccountID", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@AccountID", AccountID));
                    Account response = null;
                    await sql.OpenAsync();

                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            response = MapToValue(reader);
                        }
                    }

                    return response;
                }
            }
        }


        public async Task<string> CreateNewAccount(Account account)
        {
            using (SqlConnection sql = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SpCreateAccounts", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@AccountHolderName", account.AccountHolderName));
                    cmd.Parameters.Add(new SqlParameter("@AccountNumber", account.AccountNumber));
                    cmd.Parameters.Add(new SqlParameter("@AccountType", account.AccountType));

                    cmd.Parameters.Add(new SqlParameter("@Gender", account.Gender));
                    cmd.Parameters.Add(new SqlParameter("@Address", account.Address));
                    cmd.Parameters.Add(new SqlParameter("@Picture", account.Picture));

                    cmd.Parameters.Add(new SqlParameter("@CreatedDate", account.CreatedDate));
                    cmd.Parameters.Add(new SqlParameter("@Email", account.Email));
                    cmd.Parameters.Add(new SqlParameter("@Password", account.Password));

                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                    return "Data Save Successfully";
                }
            }
        }


        public async Task DeleteByAccountID(int AccountID)
        {
            using (SqlConnection sql = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SpDeleteRecordFromAccounts", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@AccountID", AccountID));
                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                    return;
                }
            }
        }
        //The End of this Application

    }

}
