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

        }
    }
}
