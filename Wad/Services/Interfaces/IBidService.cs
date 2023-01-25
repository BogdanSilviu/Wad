using Wad.Models;

namespace Wad.Services.Interfaces
{
    public interface IBidService
    {
        void CreateBid(Bid bid);
        void UpdateBid(Bid bid);

        void DeleteBid(Bid bid);

        Bid GetHighestBid(int itemId);
    }
}
