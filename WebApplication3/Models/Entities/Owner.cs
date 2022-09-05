using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication3.Entities
{
    public class Owner
    {
        public int Id { get; set; }
        public string FirstName { get; set; }

        public String LastName { get; set; }

        public int Age { get; set; }
        public String Gender { get; set; }
        public ICollection<Car> Cars { get; set; } //am specificat ca un proprietar poate avea mai multe masini
                                                   




    }
}
