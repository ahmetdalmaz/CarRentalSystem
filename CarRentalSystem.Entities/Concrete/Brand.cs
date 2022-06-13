using CarRentalSystem.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalSystem.Entities.Concrete
{
    public class Brand : IEntity
    {
        public int BrandId { get; set; }
        public string? BrandName { get; set; }
        public bool State { get; set; }

        public virtual ICollection<Model>? Models { get; set; }
    }
}
