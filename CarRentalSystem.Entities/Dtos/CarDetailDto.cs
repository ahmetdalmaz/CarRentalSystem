using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalSystem.Entities.Dtos
{
    public class CarDetailDto
    {
        public int CarId { get; set; }
        public string? BrandName { get; set; }
        public string? ModelName { get; set; }
        public string? Color { get; set; }
        public string? SegmentName { get; set; }
        public string? Kilometre { get; set; }
        public string? FuelType { get; set; }
        public string? Plate { get; set; }
        public bool? State { get; set; }
    }
}
