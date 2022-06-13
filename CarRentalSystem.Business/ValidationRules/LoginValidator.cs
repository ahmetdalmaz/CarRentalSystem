using CarRentalSystem.Entities.Dtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalSystem.Business.ValidationRules
{
    public class LoginValidator:AbstractValidator<LoginDto>
    {
        public LoginValidator()
        {
            RuleFor(u=>u.Email).NotEmpty().WithMessage("Email alanı boş bırakılamaz");
            RuleFor(u=>u.Email).EmailAddress().WithMessage("Lütfen geçerli bir email adresi girin");
            RuleFor(u => u.Password).NotEmpty().WithMessage("Parola alanı boş bırakılamaz");
        }
        

    }
}
