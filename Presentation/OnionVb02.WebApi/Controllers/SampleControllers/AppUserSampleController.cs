using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnionVb02.Application.CqrsAndMediatr.CQRS.Commands.AppUserCommands;
using OnionVb02.Application.CqrsAndMediatr.CQRS.Handlers.Modify.AppUsers;
using OnionVb02.Application.CqrsAndMediatr.CQRS.Handlers.Read.AppUsers;
using OnionVb02.Application.CqrsAndMediatr.CQRS.Queries.AppUserQueries;
using OnionVb02.Application.CqrsAndMediatr.CQRS.Results.AppUserResults;

namespace OnionVb02.WebApi.Controllers.SampleControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppUserSampleController : ControllerBase
    {
        private readonly GetAppUserQueryHandler _getAppUserQueryHandler;
        private readonly GetAppUserByIdQueryHandler _getAppUserByIdQueryHandler;
        private readonly CreateAppUserCommandHandler _createAppUserCommandHandler;
        private readonly UpdateAppUserCommandHandler _updateAppUserCommandHandler;
        private readonly RemoveAppUserCommandHandler _removeAppUserCommandHandler;

        public AppUserSampleController(GetAppUserQueryHandler getAppUserQueryHandler, GetAppUserByIdQueryHandler getAppUserByIdQueryHandler, CreateAppUserCommandHandler createAppUserCommandHandler, UpdateAppUserCommandHandler updateAppUserCommandHandler, RemoveAppUserCommandHandler removeAppUserCommandHandler)
        {
            _getAppUserQueryHandler = getAppUserQueryHandler;
            _getAppUserByIdQueryHandler = getAppUserByIdQueryHandler;
            _createAppUserCommandHandler = createAppUserCommandHandler;
            _updateAppUserCommandHandler = updateAppUserCommandHandler;
            _removeAppUserCommandHandler = removeAppUserCommandHandler;
        }

        [HttpGet]
        public async Task<IActionResult> AppUserList()
        {
            List<GetAppUserQueryResult> values = await _getAppUserQueryHandler.Handle();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAppUser(int id)
        {
            GetAppUserByIdQueryResult value = await _getAppUserByIdQueryHandler.Handle(new GetAppUserByIdQuery(id));
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAppUser(CreateAppUserCommand command)
        {
            await _createAppUserCommandHandler.Handle(command);
            return Ok("Ekleme işlemi basarılı");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAppUser(UpdateAppUserCommand command)
        {
            await _updateAppUserCommandHandler.Handle(command);
            return Ok("Güncelleme işlemi basarılı");
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveAppUser(int id)
        {
            await _removeAppUserCommandHandler.Handle(new RemoveAppUserCommand(id));
            return Ok("Silme işlemi basarılı");
        }
    }
}
