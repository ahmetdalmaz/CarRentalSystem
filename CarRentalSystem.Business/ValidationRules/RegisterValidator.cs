using CarRentalSystem.Entities.Dtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalSystem.Business.ValidationRules
{
    public class RegisterValidator : AbstractValidator<RegisterDto>
    {
        public RegisterValidator()
        {
            RuleFor(u => u.Email).NotEmpty().WithMessage("Email Alanı Boş Geçilemez");
            RuleFor(u => u.Email).EmailAddress().WithMessage("Lütfen geçerli bir email adresi girin");
            RuleFor(u => u.IdentityNumber).NotEmpty().WithMessage("Tc alanı boş geçilemez");
            RuleFor(u => u.IdentityNumber).Length(11).WithMessage("Eksik Tc kimlik no girdiniz");
            RuleFor(u=>u.Name).NotEmpty().WithMessage("İsim alanı boş geçilemez");
            RuleFor(u => u.Surname).NotEmpty().WithMessage("Soyad alanı boş geçilemez");
            RuleFor(u => u.Password).Equal(u => u.PasswordConfirmation).WithMessage("Şifreleriniz uyuşmuyor");



        }

    }
}
