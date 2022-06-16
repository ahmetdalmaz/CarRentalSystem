using CarRentalSystem.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalSystem.Entities.Concrete
{
    public class Role:IEntity
    {
        public int RoleId { get; set; }
        public string? Name { get; set; }


        public bool State { get; set; }

        public virtual ICollection<RoleClaim>? RoleClaims { get; set; }

        public virtual ICollection<User>? Users { get; set; }


    }
}
