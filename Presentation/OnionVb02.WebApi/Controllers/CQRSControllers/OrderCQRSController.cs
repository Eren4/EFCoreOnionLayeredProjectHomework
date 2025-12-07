using Microsoft.AspNetCore.Mvc;
using OnionVb02.Application.CqrsAndMediatr.CQRS.Commands.OrderCommands;
using OnionVb02.Application.CqrsAndMediatr.CQRS.Handlers.Modify.Orders;
using OnionVb02.Application.CqrsAndMediatr.CQRS.Handlers.Read.Orders;
using OnionVb02.Application.CqrsAndMediatr.CQRS.Queries.OrderQueries;
using OnionVb02.Application.CqrsAndMediatr.CQRS.Results.OrderResults;

namespace OnionVb02.WebApi.Controllers.SampleControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderCQRSController : ControllerBase
    {
        private readonly GetOrderQueryHandler _getOrderQueryHandler;
        private readonly GetOrderByIdQueryHandler _getOrderByIdQueryHandler;
        private readonly CreateOrderCommandHandler _createOrderCommandHandler;
        private readonly UpdateOrderCommandHandler _updateOrderCommandHandler;
        private readonly RemoveOrderCommandHandler _removeOrderCommandHandler;

        public OrderCQRSController(GetOrderQueryHandler getOrderQueryHandler, GetOrderByIdQueryHandler getOrderByIdQueryHandler, CreateOrderCommandHandler createOrderCommandHandler, UpdateOrderCommandHandler updateOrderCommandHandler, RemoveOrderCommandHandler removeOrderCommandHandler)
        {
            _getOrderQueryHandler = getOrderQueryHandler;
            _getOrderByIdQueryHandler = getOrderByIdQueryHandler;
            _createOrderCommandHandler = createOrderCommandHandler;
            _updateOrderCommandHandler = updateOrderCommandHandler;
            _removeOrderCommandHandler = removeOrderCommandHandler;
        }

        [HttpGet]
        public async Task<IActionResult> OrderList()
        {
            List<GetOrderQueryResult> values = await _getOrderQueryHandler.Handle();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrder(int id)
        {
            GetOrderByIdQueryResult value = await _getOrderByIdQueryHandler.Handle(new GetOrderByIdQuery(id));
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder(CreateOrderCommand command)
        {
            await _createOrderCommandHandler.Handle(command);
            return Ok("Ekleme işlemi basarılı");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateOrder(UpdateOrderCommand command)
        {
            await _updateOrderCommandHandler.Handle(command);
            return Ok("Güncelleme işlemi basarılı");
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveOrder(int id)
        {
            await _removeOrderCommandHandler.Handle(new RemoveOrderCommand(id));
            return Ok("Silme işlemi basarılı");
        }
    }
}
