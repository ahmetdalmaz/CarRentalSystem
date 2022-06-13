using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalSystem.Entities.Dtos
{
    public class RegisterDto
    {
        public int UserId { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public int RoleId { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? PasswordConfirmation { get; set; }
        public char Gender { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Address { get; set; }
        public string? SecurityQuestion { get; set; }
        public string? SecurityQuestionAnswer { get; set; }
        public string? IdentityNumber { get; set; }
        public bool State { get; set; }
    }
}
