using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HookahSearchServer.Models;

namespace HookahSearchServer.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        DbTables db;
        public UserController(DbTables context)
        {   
            
            this.db = context;
            if (!db.usr.Any())
            {
                db.usr.Add(new User { login = "Tom", pass_hash = "1hher4" });
                db.SaveChanges();
            }
        }

        // GET api/users
        [HttpGet]
        public IEnumerable<User> Get()
        {
            return db.usr.ToList();             
        }
        // GET api/users/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            User user = db.usr.FirstOrDefault(x => x.id == id);
            if (user == null)
                return NotFound();
            return new ObjectResult(user);
        }

        // POST api/users
        [HttpPost]
        public IActionResult Post([FromBody]User user)
        {
            if (user == null)
            {
                return BadRequest();
            }
            db.usr.Add(user);
            db.SaveChanges();
            return Ok(user);
        }

        // PUT api/users/
        [HttpPut]
        public IActionResult Put([FromBody]User user)
        {
            if (user == null)
            {
                return BadRequest();
            }
            if (!db.usr.Any(x => x.id == user.id))
            {
                return NotFound();
            }

            db.Update(user);
            db.SaveChanges();
            return Ok(user);
        }

        // DELETE api/users/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            User user = db.usr.FirstOrDefault(x => x.id == id);
            if (user == null)
            {
                return NotFound();
            }

            db.usr.Remove(user);
            db.SaveChanges();
            return Ok(user);
        }
    }
}