using Dapper;
using Library.Domains.Books.Entities;
using Library.Domains.Books.Repositories;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.DataAccessQueries.Books.Repositories
{
    public class BookRepositoryQuery : IBookRepositoryQuery
    {
        private readonly SqlConnection _db;

        public BookRepositoryQuery(IConfiguration configuration)
        {
            _db = new SqlConnection(configuration["ConnectionStrings:QueryConnection"]);
        }

        public async Task<List<Book>> GetAllBook()
        {
            return (await _db.QueryAsync<Book>("select * from books")).ToList();
        }

        public async Task<List<Book>> GetBookBySearch(string search)
        {
            return (await _db.QueryAsync<Book>("exec SpSearchBook @search", new { @search = search })).ToList();
        }

        public async Task<Book> GetBookById(int bookId)
        {
            return await _db.QueryFirstOrDefaultAsync<Book>("select * from books where bookId=@bookId", new { @bookId = bookId });
        }

        public async Task<bool> CheckShabek(string shabekNo)
        {
            int shabek = await _db.QueryFirstOrDefaultAsync<int>("select count(*) from books where ShabekNo=@shabekNo", new { @shabekNo = shabekNo });
            return shabek > 0 ? false : true;
        }
    }
}