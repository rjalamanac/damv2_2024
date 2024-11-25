using RestAPI.Models.Entity;

namespace ApiPelicula.Repository.IRepository
{
    public interface ICategoryRepository
    {
        Task<ICollection<Category>> GetCategoriesAsync();
        Task<Category> GetCategoryAsync(int id);
        Task<bool> CategoryExistsAsync(string name);
        Task<bool> CategoryExistsAsync(int id);
        Task<bool> CreateCategoryAsync(Category category);
        Task<bool> UpdateCategoryAsync(Category category);
        Task<bool> DeleteCategoryAsync(int id);
        Task<bool> Save();
        void ClearCategoryCache();
    }
}
