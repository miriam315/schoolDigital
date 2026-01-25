namespace SchoolDigital.Core.Entities
{
    public enum EStatus { active , inactive }
    public class User:BaseEntity
    {
        public string Password { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty; // teacher / student / admin
        public string Email { get; set; } = string.Empty;
        public EStatus Status { get; set; } = EStatus.active;
    }
}
