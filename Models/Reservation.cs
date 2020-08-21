using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GoBooking.Models
{
    public class Reservation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BookingID { get; set; }
        [ForeignKey("Room")]
        public int RoomID { get; set; }
        public string Email { get; set; }
        public DateTime DateBookedFrom { get; set; }
        public DateTime DateBookedTo { get; set; }
        public int Occupants { get; set; }
    }
}
