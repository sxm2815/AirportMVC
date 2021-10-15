using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AirportMVC.Models {
    public class AirplaneViewModel {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Model")]
        [StringLength(20)]
        public string Model { get; set; }

        [Required]
        [Display(Name = "Flight Number")]
        public int FlightNumber { get; set; }

        [Required]
        [Display(Name = "Destination")]
        public string Destination { get; set; }

        [Required]
        [Display(Name = "Departure Time")]
        public TimeSpan TimeDepart { get; set; }

        [Required]
        [Display(Name = "Capacity")]
        public int Capacity { get; set; }
    }
}
