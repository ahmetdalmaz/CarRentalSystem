using CarRentalSystem.Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalSystem.Business.ValidationRules
{
    public class SegmentValidator:AbstractValidator<Segment>
    {
        public SegmentValidator()
        {
            RuleFor(s => s.SegmentName).NotEmpty().WithMessage("Segment adı boş geçilemez");
            RuleFor(s => s.DailyPrice).NotEmpty().WithMessage("Segment ücreti boş geçilemez");
            RuleFor(s => s.MonthlyPrice).NotEmpty().WithMessage("Segment ücreti boş geçilemez");
            RuleFor(s => s.WeeklyPrice).NotEmpty().WithMessage("Segment ücreti boş geçilemez");
        }
    }
}
