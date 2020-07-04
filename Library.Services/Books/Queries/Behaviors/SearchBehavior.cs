using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Library.Domains.Books.Entities;
using Library.Domains.Books.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Library.Services.Books.Queries.Behaviors
{
    public class SearchBehavior<TRequest, TResponse> : IPipelineBehavior<GetBookBySearch, List<Book>>
    {
        public async Task<List<Book>> Handle(GetBookBySearch request, CancellationToken cancellationToken, RequestHandlerDelegate<List<Book>> next)
        {
            if (request.SearchBook != null)
            {
                var response = await next();

                return response;
            }
            else
            {
                throw new Exception("Error");
            }


        }
    }
}