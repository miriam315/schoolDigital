using SchoolDigital.Core.Entities;
using Microsoft.AspNetCore.Mvc;
using SchoolDigital.Core.Service;
using SchoolDigital.Service.Service;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SchoolDigital.Controllers
{
    [Route("api/lessons/{lessonId}/[controller]")]
    [ApiController]
    public class AttendanceController : ControllerBase
    {
        private readonly IAttendanceService _attendanceService;

        public AttendanceController(IAttendanceService attendanceService)
        {
            _attendanceService = attendanceService;
        }

        // GET: api/lessons/5/Attendance
        // שליפת דוח נוכחות לשיעור ספציפי
        [HttpGet]
        public ActionResult<IEnumerable<Attendance>> Get(int lessonId)
        {
            var attendanceList = _attendanceService.GetByLessonId(lessonId);
            return Ok(attendanceList);
        }

        // POST: api/lessons/5/Attendance
        // הזנת נוכחות חדשה לתלמיד בשיעור
        [HttpPost]
        public ActionResult Post(int lessonId, [FromBody] Attendance value)
        {
            value.LessonId = lessonId; // וידוא שיוך לשיעור מהנתיב
            var result = _attendanceService.Add(value);
            return Ok(result);
        }

        // PUT: api/lessons/5/Attendance/10
        // עדכון סטטוס נוכחות (למשל מ"נעדר" ל"נוכח")
        [HttpPut("{id}")]
        public ActionResult Put(int lessonId, int id, [FromBody] Attendance value)
        {
            if (id != value.Id) return BadRequest();

            value.LessonId = lessonId;
            var updated = _attendanceService.Update(value);

            if (updated == null) return NotFound();
            return Ok(updated);
        }
    }
}



