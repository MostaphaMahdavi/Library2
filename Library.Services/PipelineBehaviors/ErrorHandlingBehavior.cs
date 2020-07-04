using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Serilog;

namespace Library.Services.PipelineBehaviors
{
    public class ErrorHandlingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            try
            {
                return await next();
            }
            catch (Exception ex)
            {

                Log.ForContext("Message", ex.Message)
                    .Error($"Error: {ex.Message} ");
                throw;
            }
        }

    }
}