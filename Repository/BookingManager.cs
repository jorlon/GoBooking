using GoBooking.Interfaces;
using GoBooking.Models;
using System.Collections.Generic;
using System.Linq;

namespace GoBooking.Repository
{
    public class BookingManager : IDataRepository<Reservation>
    {
        readonly BookingContext _bookingContext;
        public BookingManager(BookingContext context)
        {
            _bookingContext = context;
        }

        public void Add(Reservation res)
        {
            _bookingContext.Reservations.Add(res);
            _bookingContext.SaveChanges();
        }

        public void Delete(Reservation res)
        {
            _bookingContext.Reservations.Remove(res);
            _bookingContext.SaveChanges();
        }

        public Reservation Get(long id)
        {
            return _bookingContext.Reservations
                .FirstOrDefault(x => x.BookingID == id);
        }

        public IEnumerable<Reservation> GetAll()
        {
            return _bookingContext.Reservations.ToList();

        }

        public void Update(Reservation dbRes, Reservation res)
        {
            dbRes.BookingID = res.BookingID;
            dbRes.RoomID = res.RoomID;
            dbRes.DateBookedFrom = res.DateBookedFrom;
            dbRes.DateBookedTo = res.DateBookedTo;
            dbRes.Email = res.Email;
            dbRes.Occupants = res.Occupants;

            _bookingContext.SaveChanges();
        }
    }
}
