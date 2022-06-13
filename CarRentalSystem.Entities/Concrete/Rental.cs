using CarRentalSystem.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalSystem.Entities.Concrete
{
    public class Rental:IEntity
    {
        public int RentalId { get; set; }
        public int CarId { get; set; }
        public int CustomerId { get; set; }
        public int UserId { get; set; }
        public DateTime RentalDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public DateTime DateProcessed { get; set; }
        public double Price { get; set; }
        public string? State { get; set; }

        public virtual Customer? Customer { get; set; }
        public virtual User? User { get; set; }
        public virtual Car? Car { get; set; }


    }
}
