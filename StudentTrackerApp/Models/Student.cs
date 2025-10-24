namespace StudentTrackerApp.Models
{
    public class Student : User
    {
        public string Location {get; set;}
        public int? CheckInTime {get; set;}
        public int? CheckOutTime {get; set;}

        public Student(int inID, string inFirst, string inLast, string inEmail, string inPass, string inRole, string inLoc, int inCheckIn, int inCheckOut) : base(inID, inFirst, inLast, inEmail, inPass, inRole) {
            this.Location = inLoc;
            this.CheckInTime = inCheckIn;
            this.CheckOutTime = inCheckOut; 
        }
    }
}

