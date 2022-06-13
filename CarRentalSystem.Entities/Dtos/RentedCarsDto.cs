using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalSystem.Entities.Dtos
{
    public class RentedCarsDto
    {
        public int RentalId { get; set; }
        public string? CustomerIdentityNumber { get; set; }
        public string? CustomerName { get; set; }
        public DateTime RentalDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public string? CarBrand { get; set; }
        public string? CarModel { get; set; }
        public string? CarColor { get; set; }
        public string? RentalState { get; set; }

    }
}
