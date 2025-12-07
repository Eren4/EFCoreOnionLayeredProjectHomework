using Microsoft.AspNetCore.Mvc;
using OnionVb02.Application.CqrsAndMediatr.CQRS.Commands.ProductCommands;
using OnionVb02.Application.CqrsAndMediatr.CQRS.Handlers.Modify.Products;
using OnionVb02.Application.CqrsAndMediatr.CQRS.Handlers.Read.Products;
using OnionVb02.Application.CqrsAndMediatr.CQRS.Queries.ProductQueries;
using OnionVb02.Application.CqrsAndMediatr.CQRS.Results.ProductResults;

namespace OnionVb02.WebApi.Controllers.SampleControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductSampleController : ControllerBase
    {
        private readonly GetProductQueryHandler _getProductQueryHandler;
        private readonly GetProductByIdQueryHandler _getProductByIdQueryHandler;
        private readonly CreateProductCommandHandler _createProductCommandHandler;
        private readonly UpdateProductCommandHandler _updateProductCommandHandler;
        private readonly RemoveProductCommandHandler _removeProductCommandHandler;

        public ProductSampleController(GetProductQueryHandler getProductQueryHandler, GetProductByIdQueryHandler getProductByIdQueryHandler, CreateProductCommandHandler createProductCommandHandler, UpdateProductCommandHandler updateProductCommandHandler, RemoveProductCommandHandler removeProductCommandHandler)
        {
            _getProductQueryHandler = getProductQueryHandler;
            _getProductByIdQueryHandler = getProductByIdQueryHandler;
            _createProductCommandHandler = createProductCommandHandler;
            _updateProductCommandHandler = updateProductCommandHandler;
            _removeProductCommandHandler = removeProductCommandHandler;
        }

        [HttpGet]
        public async Task<IActionResult> ProductList()
        {
            List<GetProductQueryResult> values = await _getProductQueryHandler.Handle();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(int id)
        {
            GetProductByIdQueryResult value = await _getProductByIdQueryHandler.Handle(new GetProductByIdQuery(id));
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductCommand command)
        {
            await _createProductCommandHandler.Handle(command);
            return Ok("Ekleme işlemi basarılı");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProduct(UpdateProductCommand command)
        {
            await _updateProductCommandHandler.Handle(command);
            return Ok("Güncelleme işlemi basarılı");
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveProduct(int id)
        {
            await _removeProductCommandHandler.Handle(new RemoveProductCommand(id));
            return Ok("Silme işlemi basarılı");
        }
    }
}
