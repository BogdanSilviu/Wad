using Wad.Models;
using Wad.Repositories.Interfaces;
using Wad.Services.Interfaces;

namespace Wad.Services
{
    public class BrandService:IBrandService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public BrandService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public void CreateBrand(Brand brand)
        {
            _repositoryWrapper.BrandRepository.Create(brand);
            _repositoryWrapper.Save();
        }

        public void DeleteBrand(Brand brand)
        {
            _repositoryWrapper.BrandRepository?.Delete(brand);
            _repositoryWrapper?.Save();
        }

        public Brand GetBrandById(int id)
        {

           return _repositoryWrapper.BrandRepository?.FindByCondition(c => c.Id == id).FirstOrDefault();
        }

        public List<Brand> GetBrands()
        {
            return _repositoryWrapper.BrandRepository?.FindAll().ToList();
        }

        public void UpdateBrand(Brand brand)
        {
           _repositoryWrapper.BrandRepository.Update(brand);
        }
    }
}
