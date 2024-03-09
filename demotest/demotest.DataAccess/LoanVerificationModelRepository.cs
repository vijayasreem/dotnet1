using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace demotest
{
    public class LoanVerificationModelRepository : ILoanVerificationModelRepository
    {
        private readonly string connectionString;

        public LoanVerificationModelRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public async Task<int> InsertAsync(LoanVerificationModel model)
        {
            using MySqlConnection connection = new MySqlConnection(connectionString);
            await connection.OpenAsync();

            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "INSERT INTO LoanVerificationModel (ApplicantId, ProofOfIncome, CreditHistory, EmploymentDetails, BankDatabase, ExternalSources, CreditCheck, CreditScore, FinancialHistory, DocumentVerificationResults, Eligibility, LoanAmount, InterestRateRange) VALUES (@ApplicantId, @ProofOfIncome, @CreditHistory, @EmploymentDetails, @BankDatabase, @ExternalSources, @CreditCheck, @CreditScore, @FinancialHistory, @DocumentVerificationResults, @Eligibility, @LoanAmount, @InterestRateRange)";
            command.Parameters.AddWithValue("@ApplicantId", model.ApplicantId);
            command.Parameters.AddWithValue("@ProofOfIncome", model.ProofOfIncome);
            command.Parameters.AddWithValue("@CreditHistory", model.CreditHistory);
            command.Parameters.AddWithValue("@EmploymentDetails", model.EmploymentDetails);
            command.Parameters.AddWithValue("@BankDatabase", model.BankDatabase);
            command.Parameters.AddWithValue("@ExternalSources", model.ExternalSources);
            command.Parameters.AddWithValue("@CreditCheck", model.CreditCheck);
            command.Parameters.AddWithValue("@CreditScore", model.CreditScore);
            command.Parameters.AddWithValue("@FinancialHistory", model.FinancialHistory);
            command.Parameters.AddWithValue("@DocumentVerificationResults", model.DocumentVerificationResults);
            command.Parameters.AddWithValue("@Eligibility", model.Eligibility);
            command.Parameters.AddWithValue("@LoanAmount", model.LoanAmount);
            command.Parameters.AddWithValue("@InterestRateRange", model.InterestRateRange);

            return await command.ExecuteNonQueryAsync();
        }

        public async Task<LoanVerificationModel> GetByIdAsync(int id)
        {
            using MySqlConnection connection = new MySqlConnection(connectionString);
            await connection.OpenAsync();

            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM LoanVerificationModel WHERE Id = @Id";
            command.Parameters.AddWithValue("@Id", id);

            using MySqlDataReader reader = await command.ExecuteReaderAsync();
            if (await reader.ReadAsync())
            {
                return new LoanVerificationModel
                {
                    Id = reader.GetInt32("Id"),
                    ApplicantId = reader.GetString("ApplicantId"),
                    ProofOfIncome = reader.GetString("ProofOfIncome"),
                    CreditHistory = reader.GetString("CreditHistory"),
                    EmploymentDetails = reader.GetString("EmploymentDetails"),
                    BankDatabase = reader.GetString("BankDatabase"),
                    ExternalSources = reader.GetString("ExternalSources"),
                    CreditCheck = reader.GetString("CreditCheck"),
                    CreditScore = reader.GetString("CreditScore"),
                    FinancialHistory = reader.GetString("FinancialHistory"),
                    DocumentVerificationResults = reader.GetString("DocumentVerificationResults"),
                    Eligibility = reader.GetBoolean("Eligibility"),
                    LoanAmount = reader.GetDecimal("LoanAmount"),
                    InterestRateRange = reader.GetDecimal("InterestRateRange")
                };
            }

            return null;
        }

        public async Task<List<LoanVerificationModel>> GetAllAsync()
        {
            using MySqlConnection connection = new MySqlConnection(connectionString);
            await connection.OpenAsync();

            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM LoanVerificationModel";

            List<LoanVerificationModel> models = new List<LoanVerificationModel>();

            using MySqlDataReader reader = await command.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                models.Add(new LoanVerificationModel
                {
                    Id = reader.GetInt32("Id"),
                    ApplicantId = reader.GetString("ApplicantId"),
                    ProofOfIncome = reader.GetString("ProofOfIncome"),
                    CreditHistory = reader.GetString("CreditHistory"),
                    EmploymentDetails = reader.GetString("EmploymentDetails"),
                    BankDatabase = reader.GetString("BankDatabase"),
                    ExternalSources = reader.GetString("ExternalSources"),
                    CreditCheck = reader.GetString("CreditCheck"),
                    CreditScore = reader.GetString("CreditScore"),
                    FinancialHistory = reader.GetString("FinancialHistory"),
                    DocumentVerificationResults = reader.GetString("DocumentVerificationResults"),
                    Eligibility = reader.GetBoolean("Eligibility"),
                    LoanAmount = reader.GetDecimal("LoanAmount"),
                    InterestRateRange = reader.GetDecimal("InterestRateRange")
                });
            }

            return models;
        }

        public async Task<int> UpdateAsync(LoanVerificationModel model)
        {
            using MySqlConnection connection = new MySqlConnection(connectionString);
            await connection.OpenAsync();

            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "UPDATE LoanVerificationModel SET ApplicantId = @ApplicantId, ProofOfIncome = @ProofOfIncome, CreditHistory = @CreditHistory, EmploymentDetails = @EmploymentDetails, BankDatabase = @BankDatabase, ExternalSources = @ExternalSources, CreditCheck = @CreditCheck, CreditScore = @CreditScore, FinancialHistory = @FinancialHistory, DocumentVerificationResults = @DocumentVerificationResults, Eligibility = @Eligibility, LoanAmount = @LoanAmount, InterestRateRange = @InterestRateRange WHERE Id = @Id";
            command.Parameters.AddWithValue("@ApplicantId", model.ApplicantId);
            command.Parameters.AddWithValue("@ProofOfIncome", model.ProofOfIncome);
            command.Parameters.AddWithValue("@CreditHistory", model.CreditHistory);
            command.Parameters.AddWithValue("@EmploymentDetails", model.EmploymentDetails);
            command.Parameters.AddWithValue("@BankDatabase", model.BankDatabase);
            command.Parameters.AddWithValue("@ExternalSources", model.ExternalSources);
            command.Parameters.AddWithValue("@CreditCheck", model.CreditCheck);
            command.Parameters.AddWithValue("@CreditScore", model.CreditScore);
            command.Parameters.AddWithValue("@FinancialHistory", model.FinancialHistory);
            command.Parameters.AddWithValue("@DocumentVerificationResults", model.DocumentVerificationResults);
            command.Parameters.AddWithValue("@Eligibility", model.Eligibility);
            command.Parameters.AddWithValue("@LoanAmount", model.LoanAmount);
            command.Parameters.AddWithValue("@InterestRateRange", model.InterestRateRange);
            command.Parameters.AddWithValue("@Id", model.Id);

            return await command.ExecuteNonQueryAsync();
        }

        public async Task<int> DeleteAsync(int id)
        {
            using MySqlConnection connection = new MySqlConnection(connectionString);
            await connection.OpenAsync();

            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "DELETE FROM LoanVerificationModel WHERE Id = @Id";
            command.Parameters.AddWithValue("@Id", id);

            return await command.ExecuteNonQueryAsync();
        }
    }
}