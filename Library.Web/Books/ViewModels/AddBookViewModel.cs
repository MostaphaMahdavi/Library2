using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace Library.Web.Books.ViewModels
{
    public class AddBookViewModel
    {

        [Display(Name = "نام کتاب")]
        [Required(ErrorMessage = "فیلد {0} اجباری می باشد")]
        [MaxLength(250,ErrorMessage = "طول فیلد {0} باید حداکثر {1} باشد")]
        public string BookName { get; set; }


        [Display(Name = "تصویر کتاب")]
        public string ImageName { get; set; }


        [Display(Name = "موضوع کتاب")]
        [Required(ErrorMessage = "فیلد {0} اجباری می باشد")]
        [MaxLength(250,ErrorMessage = "طول فیلد {0} باید حداکثر {1} باشد")]
        public string Subject { get; set; }


        [Display(Name = "شماره شابک")]
        [Required(ErrorMessage = "فیلد {0} اجباری می باشد")]
        [MaxLength(100,ErrorMessage = "طول فیلد {0} باید حداکثر {1} باشد")]
        [Remote("CheckShabek","Home",ErrorMessage = "{0} تکراری می باشد")]
        public string ShabekNo { get; set; }


        [Display(Name = "متن کتاب")]
        [Required(ErrorMessage = "فیلد {0} اجباری می باشد")]
        public string Content { get; set; }
    }
}