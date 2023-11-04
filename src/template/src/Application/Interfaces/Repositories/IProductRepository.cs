using System.Threading.Tasks;

namespace GenocsBlazor.Application.Interfaces.Repositories
{
    public interface IProductRepository
    {
        Task<bool> IsBrandUsed(int brandId);
    }
}