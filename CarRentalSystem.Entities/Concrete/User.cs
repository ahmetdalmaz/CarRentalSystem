using CarRentalSystem.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalSystem.Entities.Concrete
{
    public class User:IEntity
    {
        public int UserId { get; set; }
        public int RoleId { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Email { get; set; }
    
        public byte[]? PasswordHash { get; set; }
   
        public byte[]? PasswordSalt { get; set; }
        public char Gender { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Address { get; set; }
        public bool State { get; set; }
        public string? IdentityNumber { get; set; }
        public string? SecurityQuestion { get; set; }
        public string? SecurityQuestionAnswer { get; set; }

        public virtual Role Role { get; set; }
        public virtual ICollection<Rental>? Rentals { get; set; }


    }
}
