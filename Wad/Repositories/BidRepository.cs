using Wad.Models;
using Wad.Repositories.Interfaces;

namespace Wad.Repositories
{
    public class BidRepository : RepositoryBase<Bid>, IBidRepository
    {
        public BidRepository(AuctioneerContext autioneerContext) : base(autioneerContext)
        {
        }

    }
}