using System.Threading.Tasks;
using Library.Domains.Books.Dtos;
using Library.Domains.Books.Entities;

namespace Library.Domains.Books.Commands
{
    public interface IAddBookService
    {
        Task Execute(AddBookInfo book);

    }
}