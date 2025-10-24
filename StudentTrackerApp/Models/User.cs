namespace StudentTrackerApp.Models
{
	public class User
	{
		public int Id { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Email { get; set; }
		public string Password { get; set; }
		public string UserType { get; set; }
/*
		public List<string> Messages { get; set; }
		public List<string> Notifications { get; set; }

		public User(int inID, string inFirst, string inLast, string inEmail, string inPass, string inRole){
			this.Id = inID;
			this.FirstName = inFirst;
			this.LastName = inLast;
			this.Email = inEmail;
			this.Password = inPass;
			this.UserType = inRole;
			this.Messages = new List<string>();
			this.Notifications = new List<string>();
		}

		public User() : this(0, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty){}
*/
		public User(int inID, string inFirst, string inLast, string inEmail, string inPass, string inRole){
			this.Id = inID;
			this.FirstName = inFirst;
			this.LastName = inLast;
			this.Email = inEmail;
			this.Password = inPass;
			this.UserType = inRole;
		}
		
		public User() : this(0, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty){}
	}
}
