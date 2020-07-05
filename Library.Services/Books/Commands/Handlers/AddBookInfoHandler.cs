using AutoMapper;
using Library.Domains.Books.Commands;
using Library.Domains.Commons;
using Library.Domains.Enums;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Library.Domains.Books.Entities;

namespace Library.Services.Books.Commands.Handlers
{
    public class AddBookInfoHandler : IRequestHandler<AddBookInfo, ResultStatusType>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AddBookInfoHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<ResultStatusType> Handle(AddBookInfo request, CancellationToken cancellationToken)
        {
            var book = _mapper.Map<Book>(request);
            await _unitOfWork.BookRepositoryCommand.AddBook(book);
            await _unitOfWork.Save();
            return ResultStatusType.Success;



        }
    }
}