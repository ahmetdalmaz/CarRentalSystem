using CarRentalSystem.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalSystem.Entities.Concrete
{
    public class RoleClaim : IEntity
    {
        public int RoleClaimId { get; set; }
        public string? Name { get; set; }
        public int RoleId { get; set; }

        public virtual Role? Role { get; set; }

    }
}
