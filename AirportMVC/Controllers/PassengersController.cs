using Airport.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AirportMVC.Models;

namespace AirportMVC.Controllers {
    public class PassengersController : Controller {
        private readonly IPassengerDAO passengerDAO;

        public PassengersController(IPassengerDAO passengerDAO) {
            this.passengerDAO = passengerDAO;
        }
        public IActionResult Index() {
            IEnumerable<Passenger> passengers = passengerDAO.GetPassengers();
            List<PassengerViewModel> model = new List<PassengerViewModel>();

            foreach (var pass in passengers) {
                PassengerViewModel temp = new PassengerViewModel {
                    Name = pass.Name,
                    Age = pass.Age,
                    Email = pass.Email,
                    PhoneNumber = pass.PhoneNumber,
                    ReservationNumber = pass.ReservationNumber,
                    FlightNumber = pass.FlightNumber,
                    Id = pass.Id
                };

                model.Add(temp);
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult Create() {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind] PassengerViewModel pass) {
            if (ModelState.IsValid) {

                Passenger newPassenger = new Passenger();
                newPassenger.Name = pass.Name;
                newPassenger.Age = pass.Age;
                newPassenger.Email = pass.Email;
                newPassenger.PhoneNumber = pass.PhoneNumber;

                passengerDAO.AddPassenger(newPassenger);

                return RedirectToAction("Index");
            }
            return View(pass);
        }

        [HttpGet]
        public IActionResult Assign(int id) {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Assign([Bind] PassengerViewModel pass) {
            passengerDAO.AssignFlight(pass.Id, pass.FlightNumber);
            return RedirectToAction("Index");

            return View(pass);
        }

        public IActionResult Details(int id) {
            Passenger pass = passengerDAO.GetPassenger(id);
            return View(pass);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit([Bind] Passenger pass) {

            if (ModelState.IsValid) {
                Passenger newPassenger = new Passenger();
                newPassenger.Name = pass.Name;
                newPassenger.Age = pass.Age;
                newPassenger.Email = pass.Email;
                newPassenger.PhoneNumber = pass.PhoneNumber;

                passengerDAO.UpdatePassenger(pass.Id, newPassenger);

                return RedirectToAction("Index");
            }
            return View(pass);
        }

        public IActionResult Delete(int id) {
            passengerDAO.RemovePassenger(id);
            return RedirectToAction("Index");
        }
    }
}
