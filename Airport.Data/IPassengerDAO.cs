using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport.Data
{
    public interface IPassengerDAO
    {
        public IEnumerable<Passenger> GetPassengers();
        public Passenger GetPassenger(int Id);
        public void AssignFlight(int Id, int flightNumber);
        public void AddPassenger(Passenger passenger);
        public void UpdatePassenger(int Id, Passenger passenger);
        public void RemovePassenger(int Id);
    }
}
