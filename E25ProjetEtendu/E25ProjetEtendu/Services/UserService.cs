using E25ProjetEtendu.Data;
using E25ProjetEtendu.Models;
using E25ProjetEtendu.Services.IServices;
using E25ProjetEtendu.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace E25ProjetEtendu.Services
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        public UserService(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<ApplicationUser?> GetUserById(string userId)
        {
            return await _userManager.FindByIdAsync(userId);
        }


        public async Task<List<UserViewModel>> GetNonPrivilegedUsers()
        {
            List<ApplicationUser> users = await _userManager.Users.ToListAsync();

            List<UserViewModel> result = new List<UserViewModel>();

            foreach (var user in users)
            {
                var roles = await _userManager.GetRolesAsync(user);

                if (!roles.Contains("Admin") && !roles.Contains("DeliveryStation"))
                {
                    result.Add(new UserViewModel
                    {
                        Id = user.Id,
                        Email = user.Email,
                        FirstName = user.FirstName,
                        LastName = user.LastName,
                        Roles = roles.ToList(),
                        Balance = user.Balance
                    });
                }
            }

            return result;
        }

        public async Task<bool> GiveDelivererRights(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
                return false;

            if (!await _userManager.IsInRoleAsync(user, "Deliverer"))
            {
                var result = await _userManager.AddToRoleAsync(user, "Deliverer");
                return result.Succeeded;
            }
            return true;
        }

        public async Task<bool> RemoveDelivererRights(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
                return false;

            if (await _userManager.IsInRoleAsync(user, "Deliverer"))
            {
                var result = await _userManager.RemoveFromRoleAsync(user, "Deliverer");
                return result.Succeeded;
            }

            return true;
        }
    }
}
