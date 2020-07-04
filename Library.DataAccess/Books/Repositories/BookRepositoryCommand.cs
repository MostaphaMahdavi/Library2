using AutoMapper;
using Library.DataAccessCommands.Context;
using Library.Domains.Books.Dtos;
using Library.Domains.Books.Entities;
using Library.Domains.Books.Repositories;
using System.Threading.Tasks;

namespace Library.DataAccessCommands.Books.Repositories
{
    public class BookRepositoryCommand : IBookRepositoryCommand
    {
        private readonly LibraryContext _context;
       

        public BookRepositoryCommand(LibraryContext context)
        {
            _context = context;
            
        }
        public async Task AddBook(AddBookInfo book)
        {
           
            Book bookMap=new Book()
            {
                BookName = book.BookName,
                ShabekNo = book.ShabekNo,
                Subject = book.Subject,
                ImageName = book.ImageName,
                Content = book.Content
            };
            await _context.Books.AddAsync(bookMap);
        }
    }
}