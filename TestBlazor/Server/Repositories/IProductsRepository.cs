using TestBlazor.Shared.Models;

namespace TestBlazor.Server.Repositories
{
    public interface IProductsRepository
    {

        Task<List<ProductModel>> GetAsync();

        Task<ProductModel?> GetAsync(string id);

        Task CreateAsync(ProductModel product);

        Task UpdateAsync(string id, ProductModel product);

        Task RemoveAsync(string id);

    }
}
