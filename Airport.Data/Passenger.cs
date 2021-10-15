using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport.Data
{
    public class Passenger {
        public int Id { get; set; }
        public String Name { get; set; }
        public int Age { get; set; }
        public String Email { get; set; }
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }
        [Display(Name = "Reservation Number")]
        public int ReservationNumber { get; set; }
        public int FlightNumber { get; set; }

        public Passenger() { }
        public Passenger(String name, int age, string email)
        {
            this.Name = name;
            this.Age = age;
            this.Email = email;
        }
        public Passenger(String name, int age, string email, string phonenumber)
        {
            this.Name = name;
            this.Age = age;
            this.Email = email;
            this.PhoneNumber = phonenumber;
        }
    }
}
