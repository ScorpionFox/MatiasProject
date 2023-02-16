using MatiasProject.Models.DTO;

namespace MatiasProject.Repositories.Abstract
{
    public interface IUserAuthenticationService
    {
        Task<Status> LoginAsync(LoginModel model);
        Task<Status> RegistrationAsync(RegistrationModel model);
        Task LogoutAsync();
        Task<Status> ChangePasswordAsync (ChangePasswordModel model, string username);
    }
}
