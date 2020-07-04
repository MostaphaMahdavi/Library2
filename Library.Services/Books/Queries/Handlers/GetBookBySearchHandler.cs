using Library.Domains.Books.Entities;
using Library.Domains.Books.Queries;
using Library.Domains.Books.Repositories;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Library.Services.Books.Queries.Handlers
{

    public class GetBookBySearchHandler : IRequestHandler<GetBookBySearch, List<Book>>
    {
        private readonly IBookRepositoryQuery _bookRepositoryQuery;

        public GetBookBySearchHandler(IBookRepositoryQuery bookRepositoryQuery)
        {
            _bookRepositoryQuery = bookRepositoryQuery;
        }

        public async Task<List<Book>> Handle(GetBookBySearch request, CancellationToken cancellationToken)
        {
            return await _bookRepositoryQuery.GetBookBySearch(request.SearchBook);
        }
    }
}