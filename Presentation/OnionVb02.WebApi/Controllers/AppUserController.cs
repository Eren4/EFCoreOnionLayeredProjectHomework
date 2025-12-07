using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnionVb02.Application.CqrsAndMediatr.Mediator.Commands.AppUserCommands;
using OnionVb02.Application.CqrsAndMediatr.Mediator.Queries.AppUserQueries;
using OnionVb02.Application.CqrsAndMediatr.Mediator.Results.AppUserResults;
using OnionVb02.Application.DTOClasses;
using OnionVb02.Application.ManagerInterfaces;
using OnionVb02.Domain.Entities;
using OnionVb02.ValidatorStructure.Models.RequestModels.AppUsers;
using OnionVb02.ValidatorStructure.Models.ResponseModels.AppUsers;

namespace OnionVb02.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppUserController : ControllerBase
    {
        private readonly IAppUserManager _AppUserManager;
        private readonly IMapper _mapper;

        public AppUserController(IAppUserManager AppUserManager, IMapper mapper)
        {
            _AppUserManager = AppUserManager;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> AppUserList()
        {
            List<AppUserDto> values = await _AppUserManager.GetAllAsync();
            return Ok(_mapper.Map<List<AppUserResponseModel>>(values));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAppUser(int id)
        {
            AppUserDto value = await _AppUserManager.GetByIdAsync(id);
            return Ok(_mapper.Map<AppUserResponseModel>(value));
        }

        [HttpPost]
        public async Task<IActionResult> CreateAppUser(CreateAppUserRequestModel model)
        {
            AppUserDto AppUser = _mapper.Map<AppUserDto>(model);
            await _AppUserManager.CreateAsync(AppUser);
            return Ok("Veri eklendi");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAppUser(UpdateAppUserRequestModel model)
        {
            AppUserDto AppUser = _mapper.Map<AppUserDto>(model);
            await _AppUserManager.UpdateAsync(AppUser);
            return Ok("Veri güncelleme basarılıdır");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PacifyAppUser(int id)
        {
            string mesaj = await _AppUserManager.SoftDeleteAsync(id);
            return Ok(mesaj);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAppUser(int id)
        {
            string mesaj = await _AppUserManager.HardDeleteAsync(id);
            return Ok(mesaj);
        }
    }
}
