using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication3.Entities;

namespace WebApplication3.Models.Entities.DTOs
{
    public class CarDTO
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public String Model { get; set; }
        public int CubicCap { get; set; }

        public String SerialNumber { get; set; }

        public String Plates { get; set; }

        public int OwnerId { get; set; }
        //public Address Address { get; set; }
    

        public CarDTO(Car car)
        {
            this.Id = car.Id;
            this.Brand = car.Brand;
            this.Model = car.Model;
            this.Plates = car.Plates;
            this.CubicCap = car.CubicCap;
            this.SerialNumber = car.SerialNumber;
            this.OwnerId = car.OwnerId;

        }

    }
}
