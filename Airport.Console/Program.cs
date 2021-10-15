using System;
using System.Collections.Generic;
using Airport.Data;

namespace Airport.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //AirplaneDAO dao = new AirplaneDAO();
            //Airplane test = new Airplane("B2 Bomber", 3312, "Croatia", new TimeSpan(12, 15, 59), 20);

/*            //Create Plane
            dao.AddAirplane(test);

            //Get Plane by Id
            Console.Write(dao.GetAirplane(5).Destination);

            //Update Plane
            dao.UpdateAirplane(5, test);

            //Remove Plane by Id
            dao.RemoveAirplane(1);*/

            //Get All Planes
/*            IEnumerable<Airplane> airplanes = dao.GetAirplanes();

            foreach (Airplane airplane in airplanes) {
                Console.WriteLine("Plane Name: ");
                Console.WriteLine(airplane.Model);
            }*/

            //Get all passengers
            PassengerDAO dao = new PassengerDAO();
            IEnumerable<Passenger> passengers = dao.GetPassengers();

            foreach (Passenger pass in passengers) {
                Console.WriteLine("Passenger Age: ");
                Console.WriteLine(pass.Age);
            }

/*            //Get Passenger by Id
            Console.Write(dao.GetPassenger(2).Email);

            //Add passenger
            Passenger test = new Passenger("George Hann", 60, "testemail@test.com", "1332445642");
            dao.AddPassenger(test);

            //Remove Passenger
            dao.RemovePassenger(1);

            //Update Passenger
            Passenger test2 = new Passenger("George Hann", 42, "passenger@email.com", "1332615672");
            dao.UpdatePassenger(2, test2);*/

            //Assign flight to passenger
            //dao.AssignFlight(3,3155);

        }
    }
}
