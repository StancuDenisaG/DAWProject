using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication3.Entities
{
    public class Car
    {

        public int Id { get; set; }

        public String Brand { get; set; }

        public String Model { get; set; }

        public int CubicCap { get; set; }

        public String SerialNumber { get; set; }

        public String Plates { get; set; }

        public int OwnerId { get; set; }

        //proprietatea de navigare:
        public Owner Owner { get; set; }

        public Insurance Insurance { get; set; }

        public ICollection<CarAccident> CarAccidents { get; set; }



    }
}
