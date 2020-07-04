using Library.Domains.Books.Commands;
using Library.Domains.Commons;
using Library.Domains.Enums;
using MediatR;
using Serilog;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Library.Services.Books.Commands.Handlers
{
    public class AddBookInfoHandler : IRequestHandler<AddBookInfo, ResultStatusType>
    {
        private readonly IUnitOfWork _unitOfWork;

        public AddBookInfoHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ResultStatusType> Handle(AddBookInfo request, CancellationToken cancellationToken)
        {


            await _unitOfWork.BookRepositoryCommand.AddBook(request);
            await _unitOfWork.Save();
            return ResultStatusType.Success;



        }
    }
}