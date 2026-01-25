using Microsoft.AspNetCore.Mvc;
using SchoolDigital.Core.Entities;
using SchoolDigital.Core.Service;
using SchoolDigital.Service.Service;

namespace SchoolDigital.Controllers
{
    [Route("api/lessons/{lessonId}/[controller]")]
    [ApiController]
    public class MaterialController : ControllerBase
    {
        private readonly IMaterialService _materialsService;

        public MaterialController(IMaterialService materialsService)
        {
            _materialsService = materialsService;
        }

        // GET: api/lessons/1/Material
        [HttpGet]
        public ActionResult<IEnumerable<Material>> Get(int lessonId)
        {
            return Ok(_materialsService.GetMaterialsByLesson(lessonId));
        }

        // POST: api/lessons/1/Material
        [HttpPost]
        public ActionResult Post(int lessonId, [FromBody] Material value)
        {
            // וידוא שהחומר מקושר לשיעור הנכון מהנתיב
            value.LessonId = lessonId;

            var created = _materialsService.Add(value);
            return Ok(created);
        }

        // PUT: api/lessons/1/Material/5
        [HttpPut("{id}")]
        public ActionResult Put(int lessonId, int id, [FromBody] Material value)
        {
            if (id != value.Id) return BadRequest();

            value.LessonId = lessonId; // הבטחת שיוך לשיעור
            var updated = _materialsService.Update(value);

            if (updated == null) return NotFound();
            return Ok(updated);
        }

        // DELETE: api/lessons/1/Material/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            _materialsService.Delete(id);
            return NoContent();
        }
    }
}
/*using SchoolDigital.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SchoolDigital.Controllers
{
    [Route("api/lessons/{lessonId}/[controller]")]
    [ApiController]
    public class MaterialController : ControllerBase
    {
        public IDataContext _context { get; set; }
        public MaterialController(IDataContext context)
        {
            _context = context;
        }
        // GET: api/<MaterialController>
        [HttpGet]
        public IEnumerable<Material> Get(int lessonId) => _context.materials.Where(m => m.LessonId == lessonId);

        // GET api/<MaterialController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST api/<MaterialController>
        [HttpPost]
        public ActionResult Post(int lessonId, [FromBody] Material value)
        {
            var m = _context.materials.FirstOrDefault(x => x.Id==value.Id);
            if (m != null)
                return Conflict();
            _context.materials.Add(value);
            return Ok();
        }

        // PUT api/<MaterialController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int lessonId, int id, [FromBody] Material value)
        {
            var index = _context.materials.FindIndex(m => m.Id == id && m.LessonId == lessonId);
            if (index >= 0)
            {
                _context.materials[index].Title = value.Title;
                _context.materials[index].Type = value.Type;
                _context.materials[index].Url = value.Url;
                return Ok();
            }
            return BadRequest();
        }

        // DELETE api/<MaterialController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int lessonId, int id)
        {
            var material = _context.materials.FirstOrDefault(m => m.Id == id && m.LessonId == lessonId);
            if (material != null)
            {
                _context.materials.Remove(material);
                return Ok();
            }
            return BadRequest();
        }
    }
}*/
