using Entities.Concrete;
using FluentValidation;
using WebApp.Areas.Admin.Models;

namespace WebApp.ValidationRules.GuestValidationRules
{
    public class GuestValidationRules:AbstractValidator<GuestViewModel>
    {
        public GuestValidationRules() 
        {
            RuleFor(x => x.name).NotEmpty().WithMessage("İsim alanı boş geçilemez");
            RuleFor(x => x.surname).NotEmpty().WithMessage("Soyisim alanı boş geçilemez");
            RuleFor(x => x.city).NotEmpty().WithMessage("Şehir alanı boş geçilemez");
            RuleFor(x => x.name).MinimumLength(3).WithMessage("Lütfen en az 3 karakter veri girişi yapınız");
            RuleFor(x => x.surname).MinimumLength(2).WithMessage("Lütfen en az 2 karakter veri girişi yapınız");
            RuleFor(x => x.city).MinimumLength(3).WithMessage("Lütfen en az 3 karakter veri girişi yapınız");
            RuleFor(x => x.name).MaximumLength(20).WithMessage("Lütfen en fazla 20 karakter veri girişi yapınız");
            RuleFor(x => x.surname).MaximumLength(30).WithMessage("Lütfen en fazla 30 karakter veri girişi yapınız");
            RuleFor(x => x.city).MaximumLength(20).WithMessage("Lütfen en fazla 20 karakter veri girişi yapınız");
        }
    }
}
