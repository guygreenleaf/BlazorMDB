using TestBlazor.Shared.Models;
using System.Net.Http.Json;

namespace TestBlazor.Client.Services
{
    public class ProductsService : IProductsService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly HttpClient _httpClient;

        public ProductsService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
            _httpClient = _httpClientFactory.CreateClient("api");
        }


        public async Task<List<ProductModel>?> GetProductsAsync()
        {

            var response = await _httpClient.GetFromJsonAsync<List<ProductModel>>("api/products");

            if(response == null)
            {
                return null;
            }
            return response;
        }

        public async Task InsertProductAsync(ProductInsertModel insertModel)
        {
            try
            {
                await _httpClient.PostAsJsonAsync("api/products", insertModel);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
