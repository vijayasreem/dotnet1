
using System.Collections.Generic;
using System.Threading.Tasks;
using demotest.DTO;

namespace demotest.Service
{
    public interface ICreditCheckService
    {
        Task<int> CreateAsync(CreditCheckModel creditCheck);
        Task<CreditCheckModel> GetByIdAsync(int id);
        Task<List<CreditCheckModel>> GetAllAsync();
        Task UpdateAsync(CreditCheckModel creditCheck);
        Task DeleteAsync(int id);
    }
}
