using FluentValidation;
using FluentValidation.Results;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalSystem.Business.Utilities
{
    public static class ValidationTool
    {
        public static List<string> Validate<TValidator>(object entity) 
        {
            var instance = Activator.CreateInstance(typeof(TValidator));
            IValidator validator = (IValidator)instance;

           var context = new ValidationContext<object>(entity);
           var result = validator.Validate(context);
            if (result.Errors.Count > 0)
            {
                List<string> errors = new List<string>();
                foreach (var item in result.Errors)
                {
                    errors.Add(item.ErrorMessage);
                }
                return errors;
            }
            return new List<string>();
        }
       

    }
}
