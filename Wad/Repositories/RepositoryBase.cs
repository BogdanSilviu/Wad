using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Wad.Models;
using Wad.Repositories.Interfaces;

namespace Wad.Repositories
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected AuctioneerContext _auctioneerContext { get; set; }

        public RepositoryBase(AuctioneerContext auctioneerContext)
        {
            _auctioneerContext = auctioneerContext;
        }

        public IQueryable<T> FindAll()
        {
            return _auctioneerContext.Set<T>().AsNoTracking();
        }

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return _auctioneerContext.Set<T>().Where(expression).AsNoTracking();
        }

        public void Create(T entity)
        {
            _auctioneerContext.Set<T>().Add(entity);
        }

        public void Update(T entity)
        {
            _auctioneerContext.Set<T>().Update(entity);
        }

        public void Delete(T entity)
        {
            _auctioneerContext.Set<T>().Remove(entity);
        }
    }
}
