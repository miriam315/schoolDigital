using Microsoft.AspNetCore.Mvc;
using SchoolDigital.Core.Entities;
using SchoolDigital.Core.Service;
using SchoolDigital.Service.Service;

namespace SchoolDigital.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LessonController : ControllerBase
    {
        private readonly ILessonsService _lessonsService;

        public LessonController(ILessonsService lessonsService)
        {
            _lessonsService = lessonsService;
        }

        // GET: api/Lesson
        // שליפת כל השיעורים הקיימים במערכת
        [HttpGet]
        public ActionResult<IEnumerable<Lesson>> Get()
        {
            var lessons = _lessonsService.GetLessons();
            return Ok(lessons);
        }

        // GET api/Lesson/5
        // שליפת פרטי שיעור ספציפי לפי מזהה ייחודי
        [HttpGet("{id}")]
        public ActionResult<Lesson> Get(int id)
        {
            var lesson = _lessonsService.GetById(id);
            if (lesson == null)
            {
                return NotFound();
            }
            return Ok(lesson);
        }

        // POST api/Lesson
        // יצירת שיעור חדש (מבוצע על ידי מורה או מנהל לפי האפיון)
        [HttpPost]
        public ActionResult Post([FromBody] Lesson value)
        {
            if (value == null)
                return BadRequest();

            // בדיקה אם המזהה כבר קיים כדי למנוע כפילויות
            var existing = _lessonsService.GetById(value.Id);
            if (existing != null)
                return Conflict("שיעור עם מזהה זה כבר קיים במערכת.");

            _lessonsService.Add(value);
            return CreatedAtAction(nameof(Get), new { id = value.Id }, value);
        }

        // PUT api/Lesson/5
        // עדכון פרטי שיעור קיים
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Lesson value)
        {
            if (id != value.Id)
                return BadRequest("המזהה בנתיב אינו תואם למזהה בגוף הבקשה.");

            var updatedLesson = _lessonsService.Update(value);
            if (updatedLesson == null)
            {
                return NotFound();
            }

            return Ok(updatedLesson);
        }

        // DELETE api/Lesson/5
        // ביטול או מחיקת שיעור מהמערכת
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var lesson = _lessonsService.GetById(id);
            if (lesson == null)
            {
                return NotFound();
            }

            _lessonsService.Delete(lesson);
            return NoContent();
        }

        // GET api/Lesson/search?name=math
        // חיפוש שיעור לפי כותרת
        [HttpGet("search")]
        public ActionResult<IEnumerable<Lesson>> Search([FromQuery] string name)
        {
            // שימוש בפונקציית החיפוש הקיימת ב-Service
            var results = _lessonsService.SearchLesson(name);
            return Ok(results);
        }
    }
}


/*using Microsoft.AspNetCore.Mvc;
using SchoolDigital.Core.Entities;
using SchoolDigital.Core.Service;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SchoolDigital.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LessonController : ControllerBase
    {
        private readonly ILessonsService _LessonsService;
        public LessonController(ILessonsService LessonsService)
        {
            _LessonsService = LessonsService;
        }
        // GET: api/<LessonController>
        [HttpGet]
        public IEnumerable<Lesson> Get()
        {
            return _LessonsService.GetLessons();
        }

        // GET api/<LessonController>/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            var lesson = _LessonsService.GetById(id);
            if(lesson != null)
                return Ok(lesson);
            return NotFound();
        }

        // POST api/<LessonController>
        [HttpPost]
        public ActionResult Post([FromBody] Lesson value)
        {
            var l = _LessonsService.GetById(value.Id);
            if (l != null)
                return Conflict();
            _LessonsService.Add(value);
            return Ok();
        }

        // PUT api/<LessonController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Lesson value)
        {
            var index = _LessonsService.GetById(value.Id);
            if (index !=null)
            {
                _LessonsService.Update(value);
                return Ok();
            }
            return BadRequest();
        }

        // DELETE api/<LessonController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var lesson = _LessonsService.GetById(id);
            if (lesson != null)
            {
               _LessonsService.Delete(lesson);
                return Ok();
            }
            return BadRequest();
        }
    }
}
*/