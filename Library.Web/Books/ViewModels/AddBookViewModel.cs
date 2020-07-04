using System.ComponentModel.DataAnnotations;

namespace Library.Web.Books.ViewModels
{
    public class AddBookViewModel
    {


        [Required(ErrorMessage = "فیلد {0} اجباری می باشد")]
        [MaxLength(250, ErrorMessage = "حداکثر {0} کاراکتر وارد نمایید")]
        [Display(Name = "نام کتاب")]
        public string BookName { get; set; }


        [Display(Name = "تصویر کتاب")]
        public string ImageName { get; set; }



        [Required(ErrorMessage = "فیلد {0} اجباری می باشد")]
        [MaxLength(250, ErrorMessage = "حداکثر {0} کاراکتر وارد نمایید")]
        [Display(Name = "موضوع کتاب")]
        public string Subject { get; set; }



        [Required(ErrorMessage = "فیلد {0} اجباری می باشد")]
        [MaxLength(100, ErrorMessage = "حداکثر {0} کاراکتر وارد نمایید")]
        [Display(Name = "شماره شابک")]
        public string ShabekNo { get; set; }



        [Required(ErrorMessage = "فیلد {0} اجباری می باشد")]
        [Display(Name = "متن کتاب")]
        public string Content { get; set; }
    }
}