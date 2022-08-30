using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication3.Entities
{
    public class CarAccident
    {

        public int CarId { get; set; }

        public Car Car { get; set; }

        public int AccidentId { get; set; }

        public Accident Accident { get; set;  }
    }
}
