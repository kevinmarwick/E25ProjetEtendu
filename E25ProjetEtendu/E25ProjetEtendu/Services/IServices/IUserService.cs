using E25ProjetEtendu.Models;
using E25ProjetEtendu.ViewModels;

namespace E25ProjetEtendu.Services.IServices
{
    public interface IUserService
    {
        Task<List<UserViewModel>> GetNonPrivilegedUsers();
    }
}
