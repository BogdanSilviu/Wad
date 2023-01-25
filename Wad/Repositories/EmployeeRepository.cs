using Wad.Models;
using Wad.Repositories.Interfaces;

namespace Wad.Repositories
{
    public class EmployeeRepository : RepositoryBase<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(AuctioneerContext autioneerContext) : base(autioneerContext)
        {
        }
    }

}
