using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MiniERP.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesOrder : ControllerBase
    {
        // GET: api/<SalesOrder>
        [HttpGet]
        [Authorize(Roles = "string")]
        public string Get()
        {
            return String.Format("Autenticado: {0}", User.Identity.Name);
        }

        // GET api/<SalesOrder>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<SalesOrder>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<SalesOrder>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<SalesOrder>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
