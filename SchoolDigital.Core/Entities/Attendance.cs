namespace SchoolDigital.Core.Entities
{
    public class Attendance:BaseEntity
    {
        public int LessonId { get; set; }
        public int StudentId { get; set; }
        public string Status { get; set; } = string.Empty; // present / absent
    }
}
