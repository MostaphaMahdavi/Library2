using System.ComponentModel.DataAnnotations;

namespace Library.Web.Books.ViewModels
{
    public class SearchViewModel
    {
        [Display(Name = "جستجو")]
         [Required(ErrorMessage = "فیلد {0} اجباری می باشد")]

        public string SearchName { get; set; }
    }
}