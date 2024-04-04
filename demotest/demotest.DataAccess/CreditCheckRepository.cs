using System.Collections.Generic;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace demotest
{
    public class CreditCheckRepository : ICreditCheckService
    {
        private readonly string connectionString;
        
        public CreditCheckRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }
        
        public async Task<int> CreateAsync(CreditCheckModel creditCheck)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                await connection.OpenAsync();
                
                var query = "INSERT INTO CreditChecks (CreditScore, FinancialHistory, LoanAmount, InterestRateRange, PreQualificationResult, PreQualificationExplanation, IsRequestValid) " +
                            "VALUES (@CreditScore, @FinancialHistory, @LoanAmount, @InterestRateRange, @PreQualificationResult, @PreQualificationExplanation, @IsRequestValid); " +
                            "SELECT LAST_INSERT_ID();";
                
                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@CreditScore", creditCheck.CreditScore);
                    command.Parameters.AddWithValue("@FinancialHistory", creditCheck.FinancialHistory);
                    command.Parameters.AddWithValue("@LoanAmount", creditCheck.LoanAmount);
                    command.Parameters.AddWithValue("@InterestRateRange", creditCheck.InterestRateRange);
                    command.Parameters.AddWithValue("@PreQualificationResult", creditCheck.PreQualificationResult);
                    command.Parameters.AddWithValue("@PreQualificationExplanation", creditCheck.PreQualificationExplanation);
                    command.Parameters.AddWithValue("@IsRequestValid", creditCheck.IsRequestValid);
                    
                    var result = await command.ExecuteScalarAsync();
                    return Convert.ToInt32(result);
                }
            }
        }
        
        public async Task<CreditCheckModel> GetByIdAsync(int id)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                await connection.OpenAsync();
                
                var query = "SELECT * FROM CreditChecks WHERE Id = @Id;";
                
                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            return new CreditCheckModel
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                CreditScore = Convert.ToInt32(reader["CreditScore"]),
                                FinancialHistory = reader["FinancialHistory"].ToString(),
                                LoanAmount = Convert.ToDecimal(reader["LoanAmount"]),
                                InterestRateRange = Convert.ToDecimal(reader["InterestRateRange"]),
                                PreQualificationResult = Convert.ToBoolean(reader["PreQualificationResult"]),
                                PreQualificationExplanation = reader["PreQualificationExplanation"].ToString(),
                                IsRequestValid = Convert.ToBoolean(reader["IsRequestValid"])
                            };
                        }
                        
                        return null;
                    }
                }
            }
        }
        
        public async Task<List<CreditCheckModel>> GetAllAsync()
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                await connection.OpenAsync();
                
                var query = "SELECT * FROM CreditChecks;";
                
                using (var command = new MySqlCommand(query, connection))
                {
                    var creditChecks = new List<CreditCheckModel>();
                    
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            creditChecks.Add(new CreditCheckModel
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                CreditScore = Convert.ToInt32(reader["CreditScore"]),
                                FinancialHistory = reader["FinancialHistory"].ToString(),
                                LoanAmount = Convert.ToDecimal(reader["LoanAmount"]),
                                InterestRateRange = Convert.ToDecimal(reader["InterestRateRange"]),
                                PreQualificationResult = Convert.ToBoolean(reader["PreQualificationResult"]),
                                PreQualificationExplanation = reader["PreQualificationExplanation"].ToString(),
                                IsRequestValid = Convert.ToBoolean(reader["IsRequestValid"])
                            });
                        }
                    }
                    
                    return creditChecks;
                }
            }
        }
        
        public async Task UpdateAsync(CreditCheckModel creditCheck)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                await connection.OpenAsync();
                
                var query = "UPDATE CreditChecks SET CreditScore = @CreditScore, FinancialHistory = @FinancialHistory, " +
                            "LoanAmount = @LoanAmount, InterestRateRange = @InterestRateRange, " +
                            "PreQualificationResult = @PreQualificationResult, PreQualificationExplanation = @PreQualificationExplanation, " +
                            "IsRequestValid = @IsRequestValid WHERE Id = @Id;";
                
                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@CreditScore", creditCheck.CreditScore);
                    command.Parameters.AddWithValue("@FinancialHistory", creditCheck.FinancialHistory);
                    command.Parameters.AddWithValue("@LoanAmount", creditCheck.LoanAmount);
                    command.Parameters.AddWithValue("@InterestRateRange", creditCheck.InterestRateRange);
                    command.Parameters.AddWithValue("@PreQualificationResult", creditCheck.PreQualificationResult);
                    command.Parameters.AddWithValue("@PreQualificationExplanation", creditCheck.PreQualificationExplanation);
                    command.Parameters.AddWithValue("@IsRequestValid", creditCheck.IsRequestValid);
                    command.Parameters.AddWithValue("@Id", creditCheck.Id);
                    
                    await command.ExecuteNonQueryAsync();
                }
            }
        }
        
        public async Task DeleteAsync(int id)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                await connection.OpenAsync();
                
                var query = "DELETE FROM CreditChecks WHERE Id = @Id;";
                
                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    
                    await command.ExecuteNonQueryAsync();
                }
            }
        }
    }
}