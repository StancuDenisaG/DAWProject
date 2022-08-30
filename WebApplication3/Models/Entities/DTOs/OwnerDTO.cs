using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication3.Entities.DTOs
{
    public class OwnerDTO
    {
        //dto ul ajuta la trimiterea datelor catre front end; sa arate mai ok 
        public int Id { get; set; }
        public string FirstName { get; set; }

        public String LastName { get; set; }

        public int Age { get; set; }
        public String Gender { get; set; }

        public List<Car> Cars { get; set; }

        public OwnerDTO(Owner owner)
        {
            this.Id = owner.Id;
            this.FirstName = owner.FirstName;
            this.LastName = owner.LastName;
            this.Age = owner.Age;
            this.Gender = owner.Gender;
            this.Cars = new List<Car>(); 
        }

    }
}
