using CarRentalSystem.Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalSystem.Business.ValidationRules
{
    public class CustomerValidator : AbstractValidator<Customer>
    {
        public CustomerValidator()
        {
            RuleFor(c => c.Email).NotEmpty().WithMessage("Email Alanı Boş Bırakılamaz");
            RuleFor(c => c.IdentityNumber).NotEmpty().WithMessage("Tc Alanı Boş Bırakılamaz");
            RuleFor(c => c.PhoneNumber).NotEmpty().WithMessage("Tel no Alanı Boş Bırakılamaz");
            RuleFor(c => c.Name).NotEmpty().WithMessage("Ad Alanı Boş Bırakılamaz");
            RuleFor(c => c.Surname).NotEmpty().WithMessage("Soyad Alanı Boş Bırakılamaz");
            RuleFor(c => c.Email).EmailAddress().WithMessage("Geçerli bir email giriniz");
        }
    }
}
