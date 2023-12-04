using Wad.Models;
using Wad.Repositories.Interfaces;
using Wad.Services.Interfaces;

namespace Wad.Services
{
    public class BidService : IBidService
    {
        private readonly IRepositoryWrapper _repositoryWrapper;

        public BidService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public void CreateBid(Bid bid)
        {
            _repositoryWrapper.BidRepository.Create(bid);
            _repositoryWrapper.Save();
        }

        public void DeleteBid(Bid bid)
        {
            _repositoryWrapper.BidRepository.Delete(bid);
            _repositoryWrapper.Save();
        }

        public void UpdateBid(Bid bid)
        {
            _repositoryWrapper.BidRepository.Update(bid);
            _repositoryWrapper.Save();
        }

        public Bid GetHighestBid(int itemId)
        {
            var bids = _repositoryWrapper.BidRepository.FindByCondition(c => c.ItemId == itemId).ToList();
            if (bids.Count == 0)
            {
                Bid bid = new Bid();
                bid.Price = 0;
                return bid;
            }
            var maxBid = bids.OrderByDescending(p => p.Price).First();
            return maxBid;
        }
    }
}
