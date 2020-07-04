using FluentValidation;
using Library.Domains.Books.Entities;

namespace Library.Services.Books.Validators
{
    public class BookValidations : AbstractValidator<Book>
    {
        public BookValidations()
        {
            RuleFor(b => b.BookName).NotEmpty().WithMessage("{PropertyName} نمی تواند خالی باشذ.")
                .NotNull().WithMessage("PropertyName نمی تواند خالی باشد")
                .MaximumLength(250).WithMessage("PropertyName حداکثر 250 کاراکتر می باشد")
                .WithName("نام کتاب");

            RuleFor(b => b.ImageName).NotEmpty().WithMessage("{PropertyName} نمی تواند خالی باشذ.")
              .NotNull().WithMessage("PropertyName نمی تواند خالی باشد")
              .WithName("تصویر کتاب");

            RuleFor(b => b.ShabekNo).NotEmpty().WithMessage("{PropertyName} نمی تواند خالی باشذ.")
                .NotNull().WithMessage("PropertyName نمی تواند خالی باشد")
                .MaximumLength(100).WithMessage("PropertyName حداکثر 250 کاراکتر می باشد")
                .WithName("شماره شابک ");

            RuleFor(b => b.Subject).NotEmpty().WithMessage("{PropertyName} نمی تواند خالی باشذ.")
                .NotNull().WithMessage("PropertyName نمی تواند خالی باشد")
                .MaximumLength(250).WithMessage("PropertyName حداکثر 250 کاراکتر می باشد")
                .WithName("موضوع کتاب");

            RuleFor(b => b.Content).NotEmpty().WithMessage("{PropertyName} نمی تواند خالی باشذ.")
                .NotNull().WithMessage("PropertyName نمی تواند خالی باشد")
                .WithName("نام کتاب");
        }
    }
}