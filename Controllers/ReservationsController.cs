using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GoBooking.Models;
using GoBooking.Interfaces;

namespace GoBooking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationsController : ControllerBase
    {
        private readonly IDataRepository<Reservation> _dataRepository;

        public ReservationsController(IDataRepository<Reservation> context)
        {
            _dataRepository = context;
        }

        // GET: api/Reservations
        [HttpGet]
        public ActionResult<IEnumerable<Reservation>> GetReservations()
        {
            return _dataRepository.GetAll().ToList();
        }

        // GET: api/Reservations/5
        [HttpGet("{id}")]
        public ActionResult<Reservation> GetReservation(int id)
        {
            var reservation = _dataRepository.Get(id);

            if (reservation == null)
            {
                return NotFound("Reservation not found");
            }

            return reservation;
        }

        // PUT: api/Reservations/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public IActionResult PutReservation(int id, [FromBody]Reservation reservation)
        {
            if (reservation == null)
            {
                return BadRequest("Reservation is null.");
            }

            Reservation reservationToUpdate = _dataRepository.Get(id);
            if (reservationToUpdate == null)
            {
                return NotFound("The Reservation record couldn't be found.");
            }

            _dataRepository.Update(reservationToUpdate, reservation);
            return NoContent();
        }

        // POST: api/Reservations
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public ActionResult<Reservation> PostReservation(Reservation reservation)
        {
            if (reservation == null)
            {
                return BadRequest("Reservation is null.");
            }
            _dataRepository.Add(reservation);
            return NoContent();

        }

        // DELETE: api/Reservations/5
        [HttpDelete("{id}")]
        public ActionResult<Reservation> DeleteReservation(int id)
        {
            Reservation reservation = _dataRepository.Get(id);
            if (reservation == null)
            {
                return NotFound("The Reservation record couldn't be found.");
            }

            _dataRepository.Delete(reservation);
            return NoContent();
        }
    }
}
