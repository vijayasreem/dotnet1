
using System.Threading.Tasks;

public interface ILoanVerificationService
{
    Task VerifyApplicantDocuments(Applicant applicant);
}
