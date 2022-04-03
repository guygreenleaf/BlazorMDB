using TestBlazor.Shared.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using TestBlazor.Server.db;
namespace TestBlazor.Server.Repositories
{
   
    public class ProductsRepository : IProductsRepository
    {
        private readonly IMongoCollection<ProductModel> _productsCollection;

        public ProductsRepository(IOptions<StoreDatabaseSettings> storeDatabaseSettings)
        {
            var mongoClient = new MongoClient(storeDatabaseSettings.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(storeDatabaseSettings.Value.DatabaseName);
            _productsCollection = mongoDatabase.GetCollection<ProductModel>(storeDatabaseSettings.Value.StoreCollectionName);
        }

        public async Task<List<ProductModel>> GetAsync() =>
            await _productsCollection.Find(_ => true).ToListAsync();

        public async Task<ProductModel?> GetAsync(string id) =>
            await _productsCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(ProductModel product) => 
            await _productsCollection.InsertOneAsync(product);

        public async Task UpdateAsync(string id, ProductModel product) =>
            await _productsCollection.ReplaceOneAsync(x => x.Id == id, product);

        public async Task RemoveAsync(string id) =>
            await _productsCollection.DeleteOneAsync(x =>x.Id == id);


    }
}
