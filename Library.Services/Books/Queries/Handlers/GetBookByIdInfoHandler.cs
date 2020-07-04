using Library.Domains.Books.Entities;
using Library.Domains.Books.Queries;
using Library.Domains.Books.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Library.Services.Books.Queries.Handlers
{
    public class GetBookByIdInfoHandler : IRequestHandler<GetBookByIdInfo, Book>
    {
        private readonly IBookRepositoryQuery _bookRepositoryQuery;

        public GetBookByIdInfoHandler(IBookRepositoryQuery bookRepositoryQuery)
        {
            _bookRepositoryQuery = bookRepositoryQuery;
        }
        public async Task<Book> Handle(GetBookByIdInfo request, CancellationToken cancellationToken)
        {
            return await _bookRepositoryQuery.GetBookById(request.BookId);
        }
    }
}