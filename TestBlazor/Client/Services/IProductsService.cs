using TestBlazor.Shared.Models;


namespace TestBlazor.Client.Services
{
    public interface IProductsService
    {
        Task<List<ProductModel>?> GetProductsAsync();

        Task InsertProductAsync(ProductInsertModel insertModel);
    }
}
