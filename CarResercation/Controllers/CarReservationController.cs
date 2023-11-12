using CarResercation.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarResercation.Controllers
{
    public class CarReservationController : Controller
    {
        private static List<CarReservation> _carReservations = new List<CarReservation>();
        // GET: CarReservationController
        public ActionResult Index()
        {
            return View(_carReservations);
        }

        // GET: CarReservationController/Details/5
        public ActionResult Details(int id)
        {
            var reservation = _carReservations.Find(r => r.Id == id);

            if (reservation == null)
            {
                return NotFound();
            }

            return View(reservation);
        }

        // GET: CarReservationController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CarReservationController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CarReservation reservation)
        {
            try
            {
                reservation.Id = _carReservations.Count + 1;
                _carReservations.Add(reservation);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: CarReservationController/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reservation = _carReservations.Find(r => r.Id == id);
            if (reservation == null)
            {
                return NotFound();
            }

            return View(reservation);
        }

        // POST: CarReservationController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, CarReservation reservation)
        {
            try
            {
                if (id != reservation.Id)
                {
                    return NotFound();
                }

                if (ModelState.IsValid)
                {
                    var existingReservation = _carReservations.Find(r => r.Id == id);
                    existingReservation.CustomerName = reservation.CustomerName;
                    existingReservation.CarModel = reservation.CarModel;
                    existingReservation.ReservationDate = reservation.ReservationDate;

                    return RedirectToAction("Index");             
                 }
            }
            catch
            {
                return View();
            }
            return View(reservation);
        }

        // GET: CarReservationController/Delete/5
        public ActionResult Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reservation = _carReservations.Find(r => r.Id == id);
            if (reservation == null)
            {
                return NotFound();
            }

            return View(reservation);
        }

        // POST: CarReservationController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // Usuń rezerwację o podanym identyfikatorze
                _carReservations.RemoveAll(r => r.Id == id);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
