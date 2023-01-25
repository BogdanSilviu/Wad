namespace Wad.Repositories.Interfaces
{
    public interface IRepositoryWrapper
    {
        IItemRepository ItemRepository { get; }
        IBrandRepository BrandRepository { get; }
        ICategoryRepository CategoryRepository { get; }
        IEmployeeRepository EmployeeRepository { get; } 

        IBidRepository BidRepository { get; }
        void Save();
    }
}
