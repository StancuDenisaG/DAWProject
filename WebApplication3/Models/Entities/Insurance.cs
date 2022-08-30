using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication3.Entities
{
    public class Insurance
    {
        public int Id { get; set; }
        public String Company { get; set; }
        public int Price { get; set; }

        public String PaymentType { get; set; }

        public int CarId { get; set; }
        public Car Car { get; set; }

    }
}
