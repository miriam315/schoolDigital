using SchoolDigital.Core;
using SchoolDigital.Core.Entities;


namespace SchoolDigital
{
    public class DataContext:DbContext
    {
        public List<Lesson> lessons { get; set; }
        public List<User> users { get; set; }
        public List<Attendance> attendanceList { get; set; }
        public List<Material> materialsList { get; set; }

    }
}


