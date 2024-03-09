
using System;
using System.Collections.Generic;

namespace demotest
{
    public class LoanVerificationModel
    {
        public int Id { get; set; }
        public string ApplicantId { get; set; }
        public string ProofOfIncome { get; set; }
        public string CreditHistory { get; set; }
        public string EmploymentDetails { get; set; }
        public string BankDatabase { get; set; }
        public string ExternalSources { get; set; }
        public string CreditCheck { get; set; }
        public string CreditScore { get; set; }
        public string FinancialHistory { get; set; }
        public string DocumentVerificationResults { get; set; }
        public bool Eligibility { get; set; }
        public decimal LoanAmount { get; set; }
        public decimal InterestRateRange { get; set; }
    }
}
