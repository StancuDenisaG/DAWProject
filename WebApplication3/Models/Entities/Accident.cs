using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication3.Entities
{
    public class Accident
    {

        public int Id { get; set; }

        public DateTime Date { get; set; }

        public int ReportNumber { get; set; }

        public ICollection<CarAccident> CarAccidents { get; set; }
    }
}
