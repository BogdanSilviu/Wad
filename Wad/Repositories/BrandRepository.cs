using Wad.Models;
using Wad.Repositories.Interfaces;

namespace Wad.Repositories
{
    public class BrandRepository : RepositoryBase<Brand>, IBrandRepository
    {
        public BrandRepository(AuctioneerContext autioneerContext) : base(autioneerContext)
        {
        }
    }

}
