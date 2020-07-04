using Library.Domains.Books.Entities;
using Microsoft.EntityFrameworkCore;

namespace Library.DataAccessCommands.Context
{
    public class LibraryContext:DbContext
    {
        public LibraryContext(DbContextOptions<LibraryContext> options):base(options)
        {
            
        }

        public DbSet<Book> Books { get; set; }




        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);


        }
    }
}