using Microsoft.AspNetCore.Mvc;
using SchoolDigital.Core.Entities;
using SchoolDigital.Core.Service;

namespace SchoolDigital.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        // GET: api/User
        [HttpGet]
        public ActionResult<IEnumerable<User>> Get()
        {
            return Ok(_userService.GetUsers());
        }

        // GET api/User/5
        [HttpGet("{id}")]
        public ActionResult<User> Get(int id)
        {
            var user = _userService.GetById(id);
            if (user == null) return NotFound();
            return Ok(user);
        }

        // POST api/User
        [HttpPost]
        public ActionResult Post([FromBody] User newUser)
        {
            // בדיקה אם משתמש עם אותם פרטים כבר קיים
            var existing = _userService.SearchUser(newUser.Password, newUser.Name);
            if (existing != null)
                return Conflict("משתמש זה כבר רשום במערכת.");

            var created = _userService.Add(newUser);
            return CreatedAtAction(nameof(Get), new { id = created.Id }, created);
        }

        // PUT api/User/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] User value)
        {
            var updated = _userService.Update(id, value);
            if (updated == null) return NotFound();
            return Ok(updated);
        }

        // DELETE api/User/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var user = _userService.GetById(id);
            if (user == null) return NotFound();

            _userService.Delete(user);
            return NoContent();
        }
    }
}