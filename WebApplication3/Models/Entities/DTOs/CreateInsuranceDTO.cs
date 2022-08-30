using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication3.Models.Entities.DTOs
{
    public class CreateInsuranceDTO
    {
        public int Id { get; set; }
        public String Company { get; set; }
        public int Price { get; set; }

        public String PaymentType { get; set; }

        public int CarId { get; set; }

    }
}
