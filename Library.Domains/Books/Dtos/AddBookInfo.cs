using Library.Domains.Enums;
using MediatR;

namespace Library.Domains.Books.Dtos
{
    public class AddBookInfo:IRequest<ResultStatusType>
    {
       
        public string BookName { get; set; }
        public string ImageName { get; set; }
        public string Subject { get; set; }
        public string ShabekNo { get; set; }
        public string Content { get; set; }
    }
}