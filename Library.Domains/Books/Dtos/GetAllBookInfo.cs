using Library.Domains.Books.Entities;
using MediatR;
using System.Collections.Generic;

namespace Library.Domains.Books.Dtos
{
    public class GetAllBookInfo : IRequest<List<Book>>
    {

    }
}