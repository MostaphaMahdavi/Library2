using AutoMapper;
using Library.Domains.Books.Commands;
using Library.Domains.Books.Dtos;
using Library.Domains.Books.Entities;
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
        private readonly IAddBookService _addBookService;
        

        public AddBookInfoHandler(IAddBookService addBookService)
        {
            _addBookService = addBookService;
           
        }

        public async Task<ResultStatusType> Handle(AddBookInfo request, CancellationToken cancellationToken)
        {

            try
            {
                await _addBookService.Execute(request);
                return ResultStatusType.Success;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                Log.ForContext("Error", ex.Message)
                    .ForContext("Error", "").Information(ex.Message.ToString());

                return ResultStatusType.Error;

            }

        }
    }
}