using E25ProjetEtendu.Models;
using E25ProjetEtendu.ViewModels;

namespace E25ProjetEtendu.Services.IServices
{
    public interface IUserService
    {
        Task<List<UserViewModel>> GetNonPrivilegedUsers();
        Task<ApplicationUser?> GetUserById(string userId);
        Task<bool> GiveDelivererRights(string userId);
        Task<bool> RemoveDelivererRights(string userId);

    }
}
