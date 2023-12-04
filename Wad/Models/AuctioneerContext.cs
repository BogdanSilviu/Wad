using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Wad.Models;


namespace Wad.Models
{
    public class AuctioneerContext : IdentityDbContext<IdentityUser>

    {

        public AuctioneerContext(DbContextOptions<AuctioneerContext> options)

        : base(options)

        { }

        public DbSet<Brand>? Brands { get; set; }
        public DbSet<Category>? Categories { get; set; }
        public DbSet<Employee>? Employees { get; set; }
        public DbSet<Item>? Items { get; set; }
        public DbSet<Order>? Orders { get; set; }
        public DbSet<Wad.Models.Bid>? Bid { get; set; }
        




    }
}
