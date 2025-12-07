using Microsoft.AspNetCore.Mvc;
using OnionVb02.Application.CqrsAndMediatr.CQRS.Commands.AppUserProfileCommands;
using OnionVb02.Application.CqrsAndMediatr.CQRS.Handlers.Modify.AppUserProfiles;
using OnionVb02.Application.CqrsAndMediatr.CQRS.Handlers.Read.AppUserProfiles;
using OnionVb02.Application.CqrsAndMediatr.CQRS.Queries.AppUserProfileQueries;
using OnionVb02.Application.CqrsAndMediatr.CQRS.Results.AppUserProfileResults;

namespace OnionVb02.WebApi.Controllers.SampleControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppUserProfileSampleController : ControllerBase
    {
        private readonly GetAppUserProfileQueryHandler _getAppUserProfileQueryHandler;
        private readonly GetAppUserProfileByIdQueryHandler _getAppUserProfileByIdQueryHandler;
        private readonly CreateAppUserProfileCommandHandler _createAppUserProfileCommandHandler;
        private readonly UpdateAppUserProfileCommandHandler _updateAppUserProfileCommandHandler;
        private readonly RemoveAppUserProfileCommandHandler _removeAppUserProfileCommandHandler;

        public AppUserProfileSampleController(GetAppUserProfileQueryHandler getAppUserProfileQueryHandler, GetAppUserProfileByIdQueryHandler getAppUserProfileByIdQueryHandler, CreateAppUserProfileCommandHandler createAppUserProfileCommandHandler, UpdateAppUserProfileCommandHandler updateAppUserProfileCommandHandler, RemoveAppUserProfileCommandHandler removeAppUserProfileCommandHandler)
        {
            _getAppUserProfileQueryHandler = getAppUserProfileQueryHandler;
            _getAppUserProfileByIdQueryHandler = getAppUserProfileByIdQueryHandler;
            _createAppUserProfileCommandHandler = createAppUserProfileCommandHandler;
            _updateAppUserProfileCommandHandler = updateAppUserProfileCommandHandler;
            _removeAppUserProfileCommandHandler = removeAppUserProfileCommandHandler;
        }

        [HttpGet]
        public async Task<IActionResult> AppUserProfileList()
        {
            List<GetAppUserProfileQueryResult> values = await _getAppUserProfileQueryHandler.Handle();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAppUserProfile(int id)
        {
            GetAppUserProfileByIdQueryResult value = await _getAppUserProfileByIdQueryHandler.Handle(new GetAppUserProfileByIdQuery(id));
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAppUserProfile(CreateAppUserProfileCommand command)
        {
            await _createAppUserProfileCommandHandler.Handle(command);
            return Ok("Ekleme işlemi basarılı");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAppUserProfile(UpdateAppUserProfileCommand command)
        {
            await _updateAppUserProfileCommandHandler.Handle(command);
            return Ok("Güncelleme işlemi basarılı");
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveAppUserProfile(int id)
        {
            await _removeAppUserProfileCommandHandler.Handle(new RemoveAppUserProfileCommand(id));
            return Ok("Silme işlemi basarılı");
        }
    }
}
