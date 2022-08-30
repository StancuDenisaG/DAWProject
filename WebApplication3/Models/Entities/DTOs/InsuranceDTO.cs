using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication3.Models.Entities.DTOs
{
    public class InsuranceDTO
    {
        public int Id { get; set; }
        public String Company { get; set; }
        public int Price { get; set; }

        public String PaymentType { get; set; }

        public int CarId { get; set; }

        public InsuranceDTO(InsuranceDTO insurance)
        {
            this.Id = insurance.Id;
            this.Company = insurance.Company;
            this.Price = insurance.Price;
            this.CarId = insurance.CarId;
            this.PaymentType = insurance.PaymentType;
        }
    }
}
