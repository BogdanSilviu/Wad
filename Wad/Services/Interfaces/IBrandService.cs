using Wad.Models;

namespace Wad.Services.Interfaces
{
    public interface IBrandService
    {
        void CreateBrand(Brand brand);
        void UpdateBrand(Brand brand);

        void DeleteBrand(Brand brand);
        
        Brand GetBrandById(int id);

        List<Brand> GetBrands();

    }
}
