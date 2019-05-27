using EShopAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using EShopAPI.Contracts;
using EShopAPI.Contracts.Tags;

namespace EShopAPI.Controllers
{
    [Route("api/tag/{tagId}/products")]
    [ApiController]
    public class ProductTagsController : ControllerBase
    {
        private readonly IProductTagsService _productTagsService;

        public ProductTagsController(IProductTagsService productTagsService)
        {
            _productTagsService = productTagsService;
        }

        [HttpGet]
        [Produces(typeof(int[]))]
        public async Task<IActionResult> GetProducts(int tagId)
        {
            var products = await _productTagsService.GetProductIds(tagId);

            return Ok(products);
        }

        [HttpPost]
        [Produces(typeof(TagDto))]
        public async Task<IActionResult> Post(int tagId, [FromBody] NewProductTagDto newProductTag)
        {
            await _productTagsService.AddTag(tagId, newProductTag);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int tagId, int productId)
        {
            await _productTagsService.RemoveTag(tagId, productId);

            return NoContent();
        }
    }
}