namespace StudentTrackerApp.Services
{
    public class UserSession
    {
        public int? Id {  get; set; }
        public string? Email { get; set; }
        public string? UserType { get; set; }
        public bool IsLoggedIn => Id.HasValue;
    }
}
