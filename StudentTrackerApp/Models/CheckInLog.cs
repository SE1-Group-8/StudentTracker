using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentTrackerApp.Models
{
    public class CheckInLog
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }

        public double CheckInLatitude { get; set; }
        public double CheckInLongitude { get; set; }
        public DateTime CheckInTime { get; set; }

        public double? CheckOutLatitude { get; set; }
        public double? CheckOutLongitude { get; set; }
        public DateTime? CheckOutTime { get; set; }

        // True if student was within 5 miles at checkout
        public bool WithinRange { get; set; }

        public virtual User? User { get; set; }
    }
}
