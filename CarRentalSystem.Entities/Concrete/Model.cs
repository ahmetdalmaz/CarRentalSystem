using CarRentalSystem.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalSystem.Entities.Concrete
{
    public class Model:IEntity
    {
        public int ModelId { get; set; }
        public string?ModelName { get; set; }
        public int BrandId { get; set; }
        public bool State { get; set; }

        public virtual Brand? Brand { get; set; }

        public virtual ICollection<Car>? Cars { get; set; }
    }
}
