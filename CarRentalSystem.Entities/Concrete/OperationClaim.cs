using CarRentalSystem.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalSystem.Entities.Concrete
{
    public class OperationClaim:IEntity
    {
        public int OperationClaimId { get; set; }
        public string? Name { get; set; }

        public bool State { get; set; }

        public virtual ICollection<UserOperationClaim>? UserOperationClaims { get; set; }

    }
}
