


using System.Collections.Generic;
using System.Threading.Tasks;

namespace demotest
{
    public interface ILoanVerificationModelRepository
    {
        Task<int> InsertAsync(LoanVerificationModel model);
        Task<LoanVerificationModel> GetByIdAsync(int id);
        Task<List<LoanVerificationModel>> GetAllAsync();
        Task<int> UpdateAsync(LoanVerificationModel model);
        Task<int> DeleteAsync(int id);
    }
}
