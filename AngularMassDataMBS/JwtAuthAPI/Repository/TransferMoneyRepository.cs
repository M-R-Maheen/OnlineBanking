using JwtAuthAPI.Models.BankModel;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace JwtAuthAPI.Repository
{
    public class TransferMoneyRepository
    {
        private readonly string _connectionString;

        public TransferMoneyRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("Dbcon");
        }

        public TransferMoneyRepository()
        {

        }

        public async Task<List<TransferMoney>> GetAll()
        {
            using (SqlConnection sql = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SpGetAllTransferMoneys", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    var response = new List<TransferMoney>();
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

        private TransferMoney MapToValue(SqlDataReader reader)
        {
            return new TransferMoney()
            {
                TransferMoneyID = (int)reader["TransferMoneyID"],
                SenderAccountNo = reader["SenderAccountNo"].ToString(),
                RecipientAccountNo = reader["RecipientAccountNo"].ToString(),
                Amount = (decimal)reader["Amount"],
                DepositDate = (DateTime)reader["DepositDate"],
                AccountID = (int)reader["AccountID"],
            };
        }

        public async Task<TransferMoney> GetByTransferMoneyID(int TransferMoneyID)
        {
            using (SqlConnection sql = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SpGetByTransferMoneyID", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@TransferMoneyID", TransferMoneyID));
                    TransferMoney response = null;
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


        public async Task<string> InsertTransferMoney(TransferMoney transferMoney)
        {
            using (SqlConnection sql = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SpTransferMoneySave", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@SenderAccountNo", transferMoney.SenderAccountNo));
                    cmd.Parameters.Add(new SqlParameter("@RecipientAccountNo", transferMoney.RecipientAccountNo));
                    cmd.Parameters.Add(new SqlParameter("@Amount", transferMoney.Amount));
                    cmd.Parameters.Add(new SqlParameter("@DepositDate", transferMoney.DepositDate));
                    cmd.Parameters.Add(new SqlParameter("@AccountID", transferMoney.AccountID));

                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                    return "Data Save Successfully";
                }
            }
        }


        public async Task DeleteByTransferMoneyID(int TransferMoneyID)
        {
            using (SqlConnection sql = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SpDeleteRecordFromTransferMoneys", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@TransferMoneyID", TransferMoneyID));
                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                    return;
                }
            }
        }
        //////---The End of this TransferMoney Repository
    }

}
