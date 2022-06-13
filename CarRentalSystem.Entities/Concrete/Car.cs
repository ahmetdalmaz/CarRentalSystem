using CarRentalSystem.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalSystem.Entities.Concrete
{
    public class Car : IEntity
    {
        public int CarId { get; set; }
        public int ModelId { get; set; }
        public string? Color { get; set; }
        public int SegmentId { get; set; }
        public string? Kilometre { get; set; }
        public string? FuelType { get; set; }
        public string? Plate { get; set; }
        public bool? State { get; set; }

        public virtual Model? Model { get; set; }
        public virtual Segment? Segment { get; set; }
        public virtual ICollection<Rental>? Rentals { get; set; }


    }
}
