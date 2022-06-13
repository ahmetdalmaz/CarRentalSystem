using CarRentalSystem.Entities.Dtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalSystem.Business.ValidationRules
{
    public class ProfileValidator: AbstractValidator<RegisterDto>
    {
        public ProfileValidator()
        {
            var a = RuleFor(x => x.Name).ToString();
            
         
        }


    }
}
