using TestBlazor.Shared.Models;
using TestBlazor.Server.Repositories;
using Microsoft.AspNetCore.Mvc;


namespace TestBlazor.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductsRepository _productsRepository;

        public ProductsController(ProductsRepository productsRepository)
        {
            _productsRepository = productsRepository;
        }

        [HttpGet]
        public async Task<List<ProductModel>> GetProducts() =>
            await _productsRepository.GetAsync();


        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<ProductModel>> Get(string id)
        {
            var book = await _productsRepository.GetAsync(id);

            if (book is null)
            {
                return NotFound();
            }

            return book;
        }

        [HttpPost]
        public async Task<IActionResult> Post(ProductModel newBook)
        {
            await _productsRepository.CreateAsync(newBook);

            return CreatedAtAction(nameof(Get), new { id = newBook.Id }, newBook);
        }

        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> Update(string id, ProductModel updateProduct)
        {
            var product = await _productsRepository.GetAsync(id);

            if (product is null)
            {
                return NotFound();
            }

            updateProduct.Id = product.Id;

            await _productsRepository.UpdateAsync(id, product);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var product = await _productsRepository.GetAsync(id);

            if (product is null || product.Id is null)
            {
                return NotFound();
            }

            await _productsRepository.RemoveAsync(product.Id);

            return NoContent();
        }

    }
}
