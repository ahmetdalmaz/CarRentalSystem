using CarRentalSystem.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalSystem.Entities.Concrete
{
    public class Customer:IEntity
    {
        public int CustomerId { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }
        public string? IdentityNumber { get; set; }
        public string?PhoneNumber { get; set; }
        public bool State { get; set; }
        public virtual ICollection<Rental>? Rentals { get; set; }

    }
}
