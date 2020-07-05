using AutoMapper;
using Library.DataAccessCommands.Context;
using Library.Domains.Books.Entities;
using Library.Domains.Books.Repositories;
using System.Threading.Tasks;
using Library.Domains.Books.Commands;

namespace Library.DataAccessCommands.Books.Repositories
{
    public class BookRepositoryCommand : IBookRepositoryCommand
    {
        private readonly LibraryContext _context;
       

        public BookRepositoryCommand(LibraryContext context)
        {
            _context = context;
            
        }
        public async Task AddBook(Book book)
        {
            await _context.Books.AddAsync(book);
        }

        public void DeleteBook(Book book)
        {
            _context.Books.Remove(book);
        }
    }
}