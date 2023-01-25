using Wad.Models;
using Wad.Repositories.Interfaces;

namespace Wad.Repositories
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        protected AuctioneerContext _auctioneerContext { get; set; }

        public RepositoryWrapper(AuctioneerContext auctioneerContext)
        {
            _auctioneerContext = auctioneerContext;
        }

        public void Save()
        {
            _auctioneerContext.SaveChanges();
        }

        private IItemRepository? _itemRepository;


        public IItemRepository ItemRepository
        {
            get
            {
                if (_itemRepository == null)
                {
                    _itemRepository = new ItemRepository(_auctioneerContext);
                }

                return _itemRepository;
            }
        }

        private IBrandRepository? _brandRepository;
        public IBrandRepository BrandRepository
        {
            get
            {
                if (_brandRepository == null)
                {
                    _brandRepository = new BrandRepository(_auctioneerContext);
                }

                return _brandRepository;
            }
        }

        private IBidRepository? _bidRepository;
        public IBidRepository BidRepository
        {
            get
            {
                if (_bidRepository == null)
                {
                    _bidRepository = new BidRepository(_auctioneerContext);
                }

                return _bidRepository;
            }
        }

        private ICategoryRepository _categoryRepository;
        public ICategoryRepository CategoryRepository
        {
            get
            {
                if (_categoryRepository == null)
                {
                    _categoryRepository = new CategoryRepository(_auctioneerContext);
                }

                return _categoryRepository;
            }
        }

        private IEmployeeRepository? _employeeRepository;
        public IEmployeeRepository EmployeeRepository
        {
            get
            {
                if (_employeeRepository == null)
                {
                    _employeeRepository = new EmployeeRepository(_auctioneerContext);
                }

                return _employeeRepository;
            }
        }
    }
}
