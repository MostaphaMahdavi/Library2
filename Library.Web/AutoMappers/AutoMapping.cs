using AutoMapper;
using Library.Domains.Books.Commands;
using Library.Domains.Books.Entities;
using Library.Domains.Books.Queries;
using Library.Web.Books.ViewModels;

namespace Library.Web.AutoMappers
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<Book, AddBookViewModel>().ReverseMap();
            CreateMap<Book, AddBookInfo>().ReverseMap();
            CreateMap<Book, GetAllBookInfo>().ReverseMap();

        }
    }
}