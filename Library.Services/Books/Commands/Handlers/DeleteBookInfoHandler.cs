using Library.Domains.Books.Commands;
using Library.Domains.Books.Repositories;
using Library.Domains.Commons;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Library.Services.Books.Commands.Handlers
{
    public class DeleteBookInfoHandler : IRequestHandler<DeleteBookInfo, bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IBookRepositoryQuery _bookRepositoryQuery;

        public DeleteBookInfoHandler(IUnitOfWork unitOfWork, IBookRepositoryQuery bookRepositoryQuery)
        {
            _unitOfWork = unitOfWork;
            _bookRepositoryQuery = bookRepositoryQuery;
        }

        public async Task<bool> Handle(DeleteBookInfo request, CancellationToken cancellationToken)
        {
            var book = await _bookRepositoryQuery.GetBookById(request.BookId);
            _unitOfWork.BookRepositoryCommand.DeleteBook(book);
            await _unitOfWork.Save();
            return true;

        }
    }
}