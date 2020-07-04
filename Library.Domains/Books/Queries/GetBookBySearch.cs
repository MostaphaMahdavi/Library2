using System.Collections.Generic;
using Library.Domains.Books.Entities;
using MediatR;

namespace Library.Domains.Books.Queries
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