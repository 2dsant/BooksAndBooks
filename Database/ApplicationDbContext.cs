using BooksAndBooks.Models;
using Microsoft.EntityFrameworkCore;

namespace BooksAndBooks.Database
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
    }
}