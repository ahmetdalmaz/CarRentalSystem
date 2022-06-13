using CarRentalSystem.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace CarRentalSystem.Entities.Concrete
{
    public class Segment : IEntity
    {
        public int SegmentId { get; set; }
        public string? SegmentName { get; set; }
        public float DailyPrice { get; set; }
        public float WeeklyPrice { get; set; }
        public float MonthlyPrice { get; set; }
        public bool State { get; set; }

        public virtual ICollection<Car>? Cars { get; set; }

    }
}
