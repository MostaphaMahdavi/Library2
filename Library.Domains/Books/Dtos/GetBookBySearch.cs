using System.Collections.Generic;
using Library.Domains.Books.Entities;
using MediatR;

namespace Library.Domains.Books.Dtos
{
    public class GetBookBySearch:IRequest<List<Book>>
    {
     
        public string SearchBook { get; set; }

        public GetBookBySearch(string searchBook)
        {
            SearchBook = searchBook;
        }
     
    }
}