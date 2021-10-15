using System;
using System.Collections.Generic;

namespace Airport.Data
{
    public class Airplane {

        private List<Passenger> passengers;
        public int Id { get; set; }
        public String Model { get; set; }
        public int FlightNumber { get; set; }
        public String Destination { get; set; }
        public TimeSpan TimeDepart { get; set; }
        public int Capacity { get; set; }
        public List<Passenger> Passengers {
            get { return passengers; }
            set { passengers = value; }
        }

        public Airplane() { }

        public Airplane(String model, int flightnumber, string destination, TimeSpan timedepart, int capacity)
        {
            this.Model = model;
            this.FlightNumber = flightnumber;
            this.Destination = destination;
            this.TimeDepart = timedepart;
            this.Capacity = capacity;
            this.Passengers = new List<Passenger>();
        }
        public Airplane(String model, int flightnumber, string destination, TimeSpan timedepart, int capacity, List<Passenger> passengers) {
            this.Model = model;
            this.FlightNumber = flightnumber;
            this.Destination = destination;
            this.TimeDepart = timedepart;
            this.Capacity = capacity;
            this.Passengers = passengers;
        }
        public void addPassenger(Passenger newPassenger)
        {
            this.passengers.Add(newPassenger);
        }

        public void removePassenger(Passenger passenger)
        {
            this.passengers.Remove(passenger);
        }
    }
}
