using MediatR;

namespace Library.Domains.Books.Commands
{
    public class DeleteBookInfo:IRequest<bool>
    {
        public int BookId { get; set; }

        public DeleteBookInfo(int bookId)
        {
            BookId = bookId;
        }
    }
}