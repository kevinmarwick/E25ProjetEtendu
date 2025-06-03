using E25ProjetEtendu.Data;
using E25ProjetEtendu.Models;
using E25ProjetEtendu.Services.IServices;
using E25ProjetEtendu.ViewModels;

namespace E25ProjetEtendu.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ApplicationDbContext _context;
        public CategoryService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Category> AddCategoryFromVM(AddCategoryVM vm)
        {
            var Category = new Category
            {
                Name = vm.Name
            };
            _context.Categories.Add(Category);
            await _context.SaveChangesAsync();
            return Category;
        }
    }
}
