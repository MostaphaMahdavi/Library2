using Library.Domains.Books.Queries;
using Library.Web.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Library.Web.Controllers
{
    public class HomeController : Controller
    {

        private readonly IMediator _mediator;
        public HomeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public IActionResult Index()
        {
            return View();
        }


        #region ListSearch

        [HttpGet]
        public async Task<IActionResult> ListSearch(string SearchName)
        {


            if (string.IsNullOrEmpty(SearchName))
            {

                ModelState.AddModelError("SearchName", "فیلد اجباری می باشد");
                return View(SearchName);

            }


            var query = new GetBookBySearch(SearchName);
            var result = await _mediator.Send(query);




            return View(result);
        }

        #endregion


        #region ReadBook

        [HttpGet]
        public async Task<IActionResult> ReadBook(int bookId)
        {

            var query = new GetBookByIdInfo(bookId);
            var result = await _mediator.Send(query);
            return View(result);
        }


        #endregion



        #region CheckShabek

        public async Task<bool> CheckShabek(string ShabekNo)
        {
            var result = await _mediator.Send(new GetShabekByShabekId(ShabekNo));
            return result is true ? true : false;
        }

        #endregion


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
