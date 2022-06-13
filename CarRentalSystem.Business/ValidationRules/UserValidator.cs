using CarRentalSystem.Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalSystem.Business.ValidationRules
{
    public class UserValidator:AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(u=>u.Email).EmailAddress().WithMessage("Lütfen geçerli bir email adresi girin");
            RuleFor(u => u.Email).NotEmpty().WithMessage("EMAİL alanı boş geçilemez");
            RuleFor(u=>u.IdentityNumber).NotEmpty().WithMessage("Tc kimlik alanı boş geçilemez");
            RuleFor(u => u.IdentityNumber).Length(11).WithMessage("Eksik Tc");

        }

    }
}
