using PokemonReviewApp.Data;
using PokemonReviewApp.Interfaces;
using PokemonReviewApp.Models;

namespace PokemonReviewApp.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        DataContext context;
        public CategoryRepository(DataContext context)
        {
            this.context = context;
        }
        public bool CategoryExists(int categoryId)
        {
            return this.context.Categories.Any(c => c.Id == categoryId);
        }

        public ICollection<Category> GetCategories()
        {
            return this.context.Categories.ToList();
        }

        public Category GetCategory(int id)
        {
            return this.context.Categories.Where(c => c.Id == id).FirstOrDefault();
        }

        public ICollection<Pokemon> GetPokemonByCategory(int categoryId)
        {
            return this.context.PokemonCategories.Where(c => c.CategoryId == categoryId).Select(p => p.Pokemon).ToList();
        }
    }
}
