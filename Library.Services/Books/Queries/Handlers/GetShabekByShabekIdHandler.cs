using System.Threading;
using System.Threading.Tasks;
using Library.Domains.Books.Queries;
using Library.Domains.Books.Repositories;
using MediatR;

namespace Library.Services.Books.Queries.Handlers
{

    
    public class GetShabekByShabekIdHandler:IRequestHandler<GetShabekByShabekId,bool>
    {
        private IBookRepositoryQuery _bookRepositoryQuery;

        public GetShabekByShabekIdHandler(IBookRepositoryQuery bookRepositoryQuery)
        {
            _bookRepositoryQuery = bookRepositoryQuery;
        }
        
        public async Task<bool> Handle(GetShabekByShabekId request, CancellationToken cancellationToken)
        {
            return await _bookRepositoryQuery.CheckShabek(request.ShabekNo);
        }
    }
}