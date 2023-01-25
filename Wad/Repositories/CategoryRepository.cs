using Wad.Models;
using Wad.Repositories.Interfaces;

namespace Wad.Repositories
{
    public class CategoryRepository : RepositoryBase<Category>, ICategoryRepository
    {
        public CategoryRepository(AuctioneerContext autioneerContext) : base(autioneerContext)
        {
        }
    }

}
