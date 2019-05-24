using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace DSUser.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private static ICollection<string> users;

        public UserController()
        {
            users = users ?? new List<string>();
        }

        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(users.OrderBy(o => o));
        }

        // GET api/values/5
        [HttpGet("{name}")]
        public IActionResult Get([FromRoute] string name)
        {
            return Ok(users.FirstOrDefault(u => u.Equals(name)));
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody] string name)
        {
            users.Add(name);
            return Ok();
        }

        // DELETE api/values/5
        [HttpDelete]
        public IActionResult Delete([FromBody] string name)
        {
            users.Remove(name);
            return Ok();
        }
    }
}
