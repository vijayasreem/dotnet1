
namespace demotest
{
    public class CreditCheckModel
    {
        public int Id { get; set; }
        public int CreditScore { get; set; }
        public string FinancialHistory { get; set; }
        public decimal LoanAmount { get; set; }
        public decimal InterestRateRange { get; set; }
        public bool PreQualificationResult { get; set; }
        public string PreQualificationExplanation { get; set; }
        public bool IsRequestValid { get; set; }
    }

    public class LoanApplicantModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string ContactNumber { get; set; }
        public CreditCheckModel CreditCheck { get; set; }
    }
}
