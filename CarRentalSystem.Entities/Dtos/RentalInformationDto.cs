using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalSystem.Entities.Dtos
{
    public class RentalInformationDto
    {
        public DateTime? RentalDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public string? BrandName { get; set; }
        public string? SegmentName { get; set; }
        public string? ModelName { get; set; }
        public double Price { get; set; }
        public string? CustomerName { get; set; }
        public string? CustomerSurname { get; set; }
        public string? CustomerMail { get; set; }
        public string? Address { get; set; }

    }
}
