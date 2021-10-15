using Microsoft.AspNetCore.Mvc;
using Airport.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AirportMVC.Models;

namespace AirportMVC.Controllers {
    public class AirplanesController : Controller {
        private readonly IAirplaneDAO airplaneDAO;

        public AirplanesController(IAirplaneDAO airplaneDAO) {
            this.airplaneDAO = airplaneDAO;
        }

        public IActionResult Index() {
            IEnumerable<Airplane> airplanes = airplaneDAO.GetAirplanes();
            List<AirplaneViewModel> model = new List<AirplaneViewModel>();

            foreach(var airplane in airplanes) {
                AirplaneViewModel temp = new AirplaneViewModel {
                    Model = airplane.Model,
                    FlightNumber = airplane.FlightNumber,
                    Destination = airplane.Destination,
                    TimeDepart = airplane.TimeDepart,
                    Capacity = airplane.Capacity,
                    Id = airplane.Id
                };
                model.Add(temp);
            }
    
            return View(model);
        }

        public IActionResult Details(int id) {
            Airplane plane = airplaneDAO.GetAirplane(id);
            plane.Passengers = airplaneDAO.GetPassengers(plane.FlightNumber).ToList();

            return View(plane);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit([Bind] Airplane plane) {

            if (ModelState.IsValid) {
                Airplane newPlane = new Airplane();
                newPlane.Model = plane.Model;
                newPlane.FlightNumber = plane.FlightNumber;
                newPlane.Destination = plane.Destination;
                newPlane.TimeDepart = plane.TimeDepart;
                newPlane.Capacity = plane.Capacity;

                airplaneDAO.UpdateAirplane(plane.Id, newPlane);

                return RedirectToAction("Index");
            }
            return View(plane);
        }

        public IActionResult Delete(int id) {
            airplaneDAO.RemoveAirplane(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Create() {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind] AirplaneViewModel plane) {
            if (ModelState.IsValid) {
                Airplane newPlane = new Airplane();
                newPlane.Model = plane.Model;
                newPlane.FlightNumber = plane.FlightNumber;
                newPlane.Destination = plane.Destination;
                newPlane.TimeDepart = plane.TimeDepart;
                newPlane.Capacity = plane.Capacity;

                airplaneDAO.AddAirplane(newPlane);

                return RedirectToAction("Index");
            }
            return View(plane);
        }
    }
}
