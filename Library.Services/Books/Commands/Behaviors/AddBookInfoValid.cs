using System;
using System.Threading;
using System.Threading.Tasks;
using Library.Domains.Books.Commands;
using Library.Domains.Enums;
using Library.Services.Books.Commands.Handlers;
using Library.Services.Books.Validators;
using MediatR;

namespace Library.Services.Books.Commands.Behaviors
{
    public class AddBookInfoValid<TRequest, TResponse> : IPipelineBehavior<AddBookInfo, ResultStatusType>
    {
        public async Task<ResultStatusType> Handle(AddBookInfo request, CancellationToken cancellationToken, RequestHandlerDelegate<ResultStatusType> next)
        {
            var bookValid=new AddBookInfoValidation();
            var check = bookValid.Validate(request);

            if (check.IsValid)
            {
                return await next();
            }
            else
            {
                throw new Exception("Not Valid");
            }
        }
    }
}