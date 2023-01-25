using Wad.Models;
using Wad.Repositories.Interfaces;
using Wad.Services.Interfaces;

namespace Wad.Services
{
    public class CategoryService:ICategoryService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public CategoryService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public void CreateCategory(Category category)
        {
            _repositoryWrapper.CategoryRepository.Create(category);
            _repositoryWrapper.Save();
        }

        public void DeleteCategory(Category category)
        {
            _repositoryWrapper.CategoryRepository.Delete(category);
            _repositoryWrapper.Save();

        }

        public List<Category> GetCategories()
        {
            return _repositoryWrapper.CategoryRepository?.FindAll().ToList();
        }

        public Category GetCategoryById(int id)
        {
            return _repositoryWrapper.CategoryRepository?.FindByCondition(c=>c.Id==id).FirstOrDefault();
        }

        public void UpdateCategory(Category category)
        {
            _repositoryWrapper.CategoryRepository.Update(category);
            _repositoryWrapper.Save();
        }
    }
}
