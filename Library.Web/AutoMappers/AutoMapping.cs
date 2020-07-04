using AutoMapper;
using Library.Domains.Books.Dtos;
using Library.Domains.Books.Entities;
using Library.Web.Books.ViewModels;

namespace Library.Web.AutoMappers
{
    public class AutoMapping:Profile
    {
        public AutoMapping()
        {
            CreateMap<Book, AddBookViewModel>().ReverseMap();
            CreateMap<Book, AddBookInfo>().ReverseMap();
            CreateMap<Book, GetAllBookInfo>().ReverseMap();
          
        }
    }
}