using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BookStoreApp.Data
{
    public class BookDbContext : IdentityDbContext<IdentityUser>
    {
        public BookDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<BookData> BookData { get; set; }
    }
}
