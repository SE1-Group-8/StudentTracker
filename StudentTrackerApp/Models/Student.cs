namespace StudentTrackerApp.Models
{
    public class Student : User
    {
        public string Location {get; set;}
        public string? CheckInTime {get; set;}
        public string? CheckOutTime {get; set;}

        public Student(int inID, string inFirst, string inLast, string inEmail, string inPass, string inRole, string inLoc, string inCheckIn, string inCheckOut) : base(inID, inFirst, inLast, inEmail, inPass, inRole) {
            this.Location = inLoc;
            this.CheckInTime = inCheckIn;
            this.CheckOutTime = inCheckOut; 
        }

        public Student(User u):this(u.Id, u.FirstName, u.LastName, u.Email, u.Password, u.UserType, string.Empty, string.Empty, string.Empty) {}

        public Student() : this(0, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty){}
    }
}

