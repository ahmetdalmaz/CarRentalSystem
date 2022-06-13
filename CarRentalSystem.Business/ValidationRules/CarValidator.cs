using CarRentalSystem.Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalSystem.Business.ValidationRules
{
    public class CarValidator:AbstractValidator<Car>
    {
        public CarValidator()
        {
            RuleFor(x => x.Plate).NotEmpty().WithMessage("Plaka alanı boş geçilemez.");
            RuleFor(x => x.ModelId).NotEmpty().WithMessage("Model ve Marka Alanı Boş Geçilemez");
            RuleFor(x => x.Color).NotEmpty().WithMessage("Renk Alanı Boş Geçilemez");
            RuleFor(x => x.SegmentId).NotEmpty().WithMessage("Segment Alanı Boş Geçilemez");
            RuleFor(x => x.Kilometre).NotEmpty().WithMessage("Kilometre Alanı Boş Geçilemez");
            RuleFor(x => x.FuelType).NotEmpty().WithMessage("Yakıt Tipi Alanı Boş Geçilemez");

        }
    }
}
