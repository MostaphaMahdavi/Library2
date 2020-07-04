using AutoMapper;
using Library.Domains.Books.Commands;
using Library.Domains.Books.Queries;
using Library.Domains.Commons;
using Library.Domains.Enums;
using Library.Web.Books.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Threading.Tasks;

namespace Library.Web.Areas.AdminPanel.Controllers
{
    public class BookManagerController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public BookManagerController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            var query = new GetAllBookInfo();
            var bookList = await _mediator.Send(query);

            return View(bookList);
        }


        public async Task<IActionResult> AddBook()
        {


            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddBook(AddBookViewModel book, IFormFile imagePath)
        {

            var imageName = "BookDefault.jpg";

            if (imagePath == null)
            {
                ModelState.AddModelError("ImageName", "تصویر اجباری می باشد");
                return View(book);
            }

            else
            {
                imageName = Generator.GenerateGuid() + Path.GetExtension(imagePath.FileName);

                using (var stream = new FileStream(Directory.GetCurrentDirectory() + "/wwwroot/Images/" + imageName, FileMode.Create))
                {
                    imagePath.CopyTo(stream);
                }

            }



            var query = new AddBookInfo()
            {
                ShabekNo = book.ShabekNo,
                Subject = book.Subject,
                BookName = book.BookName,
                Content = book.Content,
                ImageName = imageName
            };



            var res = await _mediator.Send(query);

            switch (res)
            {
                case ResultStatusType.Success:
                    return RedirectToAction("Index");
                case ResultStatusType.Error:
                    return View(book);
                default:
                    return View(book);
            }
        }



        public async Task<IActionResult> EditBook(int BookId)
        {
            ViewBag.bookId = BookId;
            return View();
        }

    }
}
