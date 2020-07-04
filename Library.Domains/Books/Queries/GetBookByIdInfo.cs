using Library.Domains.Books.Entities;
using MediatR;

namespace Library.Domains.Books.Queries
{
    public class GetBookByIdInfo:IRequest<Book>
    {
        public int BookId { get; set; }

        public GetBookByIdInfo(int bookId)
        {
            BookId = bookId;
        }
    }
}