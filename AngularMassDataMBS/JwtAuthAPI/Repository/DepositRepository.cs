using JwtAuthAPI.Models.BankModel;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JwtAuthAPI.Repository
{
    public class DepositRepository
    {
        private readonly string _connectionString;

        public DepositRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("Dbcon");
        }

        public DepositRepository()
        {

        }

        public async Task<List<Deposit>> GetAll()
        {
            using (SqlConnection sql = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SpGetAllDeposits", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    var response = new List<Deposit>();
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

        private Deposit MapToValue(SqlDataReader reader)
        {
            return new Deposit()
            {
                DepositID = (int)reader["DepositID"],
                AccountNumber = reader["AccountNumber"].ToString(),
                AccountHolderName = reader["AccountHolderName"].ToString(),
                Amount = (decimal)reader["Amount"],
                DepositDate = (DateTime)reader["DepositDate"],
                AccountID = (int)reader["AccountID"],
            };
        }

        public async Task<Deposit> GetByDeposotId(int DepositID)
        {
            using (SqlConnection sql = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SpGetByDepositID", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@DepositID", DepositID));
                    Deposit response = null;
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


        public async Task<string> InsertDeposit(Deposit deposit)
        {
            using (SqlConnection sql = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SpDepositSave", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@AccountNumber", deposit.AccountNumber));
                    cmd.Parameters.Add(new SqlParameter("@AccountHolderName", deposit.AccountHolderName));
                    cmd.Parameters.Add(new SqlParameter("@Amount", deposit.Amount));
                    cmd.Parameters.Add(new SqlParameter("@DepositDate", deposit.DepositDate));
                    cmd.Parameters.Add(new SqlParameter("@AccountID", deposit.AccountID));

                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                    return "Data Save Successfully";
                }
            }
        }


        public async Task DeleteByDepositId(int DepositID)
        {
            using (SqlConnection sql = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SpDeleteRecordFromDeposit", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@DepositID", DepositID));
                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                    return;
                }
            }
        }
        //The End of this Application

    }
}
