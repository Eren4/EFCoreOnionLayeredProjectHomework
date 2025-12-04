using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnionVb02.Application.DTOClasses;
using OnionVb02.Application.ManagerInterfaces;
using OnionVb02.Domain.Entities;
using OnionVb02.InnerInfrastructure.ManagerConcretes;
using OnionVb02.ValidatorStructure.Models.RequestModels.AppUserProfiles;
using OnionVb02.ValidatorStructure.Models.ResponseModels.AppUserProfiles;
using OnionVb02.ValidatorStructure.Models.RequestModels.Categories;

namespace OnionVb02.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppUserProfileController : ControllerBase
    {
        private readonly IAppUserProfileManager _appUserProfileManager;
        private readonly IMapper _mapper;
        
        public AppUserProfileController(IAppUserProfileManager appUserProfileManager, IMapper mapper)
        {
            _appUserProfileManager = appUserProfileManager;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> AppUserProfileList()
        {
            List<AppUserProfileDto> values = await _appUserProfileManager.GetAllAsync();
            return Ok(_mapper.Map<List<AppUserProfileResponseModel>>(values));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAppUserProfile(int id)
        {
            AppUserProfileDto value = await _appUserProfileManager.GetByIdAsync(id);
            return Ok(_mapper.Map<AppUserProfileResponseModel>(value));
        }

        [HttpPost]
        public async Task<IActionResult> CreateAppUserProfile(CreateAppUserProfileRequestModel model)
        {
            AppUserProfileDto appUserProfile = _mapper.Map<AppUserProfileDto>(model);
            await _appUserProfileManager.CreateAsync(appUserProfile);
            return Ok("Veri eklendi");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAppUserProfile(UpdateAppUserProfileRequestModel model)
        {
            AppUserProfileDto appUserProfile = _mapper.Map<AppUserProfileDto>(model);
            await _appUserProfileManager.UpdateAsync(appUserProfile);
            return Ok("Veri güncelleme basarılıdır");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PacifyAppUserProfile(int id)
        {
            string mesaj = await _appUserProfileManager.SoftDeleteAsync(id);
            return Ok(mesaj);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAppUserProfile(int id)
        {
            string mesaj = await _appUserProfileManager.HardDeleteAsync(id);
            return Ok(mesaj);
        }
    }
}
