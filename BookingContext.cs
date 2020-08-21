using GoBooking.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace GoBooking
{
    public class BookingContext : DbContext
    {
        public BookingContext(DbContextOptions<BookingContext> options)
            : base(options)
        {
        }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Room> Room { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Room>().HasData(new Room
            {
                RoomID = 1,
                RoomTitle = "Lavender Room",
                Description = "Well lite room with ocean views",
                Address = "21 Ocean st Marrochydore",
                Capacity = 5,

            }, new Room
            {
                RoomID = 2,
                RoomTitle = "Oval Room",
                Description = "Spacious room for all your parliamentary needs",
                Address = "21 Ocean st Marrochydore",
                Capacity = 15,
            });

            modelBuilder.Entity<Image>().HasData(new Image
            {
                ImageID = 1,
                RoomId = 1,
                FileName = "lanenderRoom.png"

            }, new Image
            {
                ImageID = 2,
                RoomId = 2,
                FileName = "ovalRomm.png"

            });
        }
    }
}
