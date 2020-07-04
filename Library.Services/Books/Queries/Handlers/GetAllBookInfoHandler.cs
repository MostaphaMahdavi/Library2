using Library.Domains.Books.Dtos;
using Library.Domains.Books.Entities;
using Library.Domains.Books.Repositories;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Library.Services.Books.Queries.Handlers
{
    public class GetAllBookInfoHandler : IRequestHandler<GetAllBookInfo, List<Book>>
    {
        private readonly IBookRepositoryQuery _bookRepositoryQuery;

        public GetAllBookInfoHandler(IBookRepositoryQuery bookRepositoryQuery)
        {
            _bookRepositoryQuery = bookRepositoryQuery;
        }
        public async Task<List<Book>> Handle(GetAllBookInfo request, CancellationToken cancellationToken)
        {
            return await _bookRepositoryQuery.GetAllBook();

        }
    }
}