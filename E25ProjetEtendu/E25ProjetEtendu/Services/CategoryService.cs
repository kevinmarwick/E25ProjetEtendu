using E25ProjetEtendu.Data;
using E25ProjetEtendu.Services.IServices;

namespace E25ProjetEtendu.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ApplicationDbContext _context;
        public CategoryService(ApplicationDbContext context)
        {
            _context = context;
        }
    }
}
