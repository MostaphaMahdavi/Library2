using System.Collections.Generic;
using System.Threading.Tasks;
using Library.Domains.Books.Entities;

namespace Library.Domains.Books.Repositories
{
    public interface IBookRepositoryQuery
    {
        Task<List<Book>> GetAllBook();
        Task<List<Book>> GetBookBySearch(string search);

        Task<Book> GetBookById(int bookId);
    }
}