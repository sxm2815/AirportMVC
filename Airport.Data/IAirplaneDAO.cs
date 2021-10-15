using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport.Data
{
    public interface IAirplaneDAO
    {
        public IEnumerable<Airplane> GetAirplanes();
        public IEnumerable<Passenger> GetPassengers(int flightNumber);
        public Airplane GetAirplane(int Id);
        public void AddAirplane(Airplane airplane);
        public void UpdateAirplane(int Id, Airplane airplane);
        public void RemoveAirplane(int Id);
    }
}
