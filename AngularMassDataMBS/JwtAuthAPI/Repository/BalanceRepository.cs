using JwtAuthAPI.Models.BankModel;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace JwtAuthAPI.Repository
{
    public class BalanceRepository
    {
        private readonly string _connectionString;

        public BalanceRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("Dbcon");
        }

        public BalanceRepository()
        {

        }

        public async Task<List<Balance>> GetAll()
        {
            using (SqlConnection sql = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SpGetAllBalances", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    var response = new List<Balance>();
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

        private Balance MapToValue(SqlDataReader reader)
        {
            return new Balance()
            {
                BalanceID = (int)reader["BalanceID"],
                TotalBalance = (decimal)reader["TotalBalance"],
                AccountID = (int)reader["AccountID"],
            };
        }

        public async Task<Balance> GetByBalanceId(int BalanceID)
        {
            using (SqlConnection sql = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SpGetByBalanceID", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@BalanceID", BalanceID));
                    Balance response = null;
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


        public async Task<string> InsertBalance(Balance balance)
        {
            using (SqlConnection sql = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SpBalanceSave", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@TotalBalance", balance.TotalBalance));
                    cmd.Parameters.Add(new SqlParameter("@AccountID", balance.AccountID));

                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                    return "Data Save Successfully";
                }
            }
        }


        public async Task DeleteByBalanceId(int BalanceID)
        {
            using (SqlConnection sql = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SpDeleteRecordFromBalances", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@BalanceID", BalanceID));
                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                    return;
                }
            }
        }
        //The End of this Application
    }
}
