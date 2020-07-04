using Library.Domains.Books.Commands;
using Library.Domains.Books.Entities;
using Library.Domains.Commons;
using System.Threading.Tasks;
using Library.Domains.Books.Dtos;

namespace Library.Services.Books.Commands
{
    public class AddBookService : IAddBookService
    {
        private readonly IUnitOfWork _unitOfWork;

        public AddBookService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Execute(AddBookInfo book)
        {
            await _unitOfWork.BookRepositoryCommand.AddBook(book);
            await _unitOfWork.Save();
        }
    }
}