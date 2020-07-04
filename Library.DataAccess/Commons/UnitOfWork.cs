using Library.DataAccessCommands.Context;
using Library.Domains.Commons;
using System.Threading.Tasks;
using Library.DataAccessCommands.Books.Repositories;
using Library.Domains.Books.Repositories;

namespace Library.DataAccessCommands.Commons
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly LibraryContext _context;

        public UnitOfWork(LibraryContext context)
        {
            _context = context;
            BookRepositoryCommand=new BookRepositoryCommand(_context);
        }


        public IBookRepositoryCommand BookRepositoryCommand { get; }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}