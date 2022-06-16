using CarRentalSystem.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalSystem.Business.Utilities
{
    public static class LoginCache
    {
        public static User? User { get; set; }
        public static string[]? RoleClaims { get; set; }

    }
}
