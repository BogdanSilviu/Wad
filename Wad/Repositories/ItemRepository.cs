using Wad.Models;
using Wad.Repositories.Interfaces;

namespace Wad.Repositories
{
    public class ItemRepository : RepositoryBase<Item>, IItemRepository
    {
        public ItemRepository(AuctioneerContext autioneerContext) : base(autioneerContext)
        {
        }

    }
}