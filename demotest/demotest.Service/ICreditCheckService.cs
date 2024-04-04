public interface ICreditCheckService
{
    Task<PreQualificationResult> CheckCreditAsync(Applicant applicant);
}

public class Applicant
{
    public string Name { get; set; }
    public int CreditScore { get; set; }
    public FinancialHistory History { get; set; }
    // other applicant properties
}

public class FinancialHistory
{
    // financial history properties
}

public class PreQualificationResult
{
    public decimal EligibleAmount { get; set; }
    public Range InterestRateRange { get; set; }
    public string Explanation { get; set; }
}

public class Range
{
    public double Min { get; set; }
    public double Max { get; set; }

    public Range(double min, double max)
    {
        Min = min;
        Max = max;
    }
}