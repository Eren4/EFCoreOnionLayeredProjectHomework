using OnionVb02.Domain.Enums;

namespace Project.OnionVb02.Models.ResponseModels.AppUsers
{
    public class AppUserResponseModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public DataStatus Status { get; set; }
    }
}
