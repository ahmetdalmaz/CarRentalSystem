using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalSystem.Entities.Dtos
{
    public class RoleClaimDto
    {
        public int RoleClaimId { get; set; }
        public string ClaimName { get; set; }
        public string RoleName { get; set; }

    }
}
