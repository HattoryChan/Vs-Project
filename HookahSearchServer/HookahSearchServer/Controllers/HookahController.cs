using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using HookahSearchServer.Models;

namespace HookahApi.Controllers
{
    [Route("api/[controller]")]
    public class HookahController : Controller
    {
        public HookahController(IHookahRepository hookahItems)
        {
            HookahItems = hookahItems;
        }
        public IHookahRepository HookahItems { get; set; }

        public IEnumerable<HookahItem> GetAll()
        {
            return HookahItems.GetAll();
        }

        [HttpGet("{id}", Name = "GetHookah")]
        public IActionResult GetById(string id)
        {
            var item = HookahItems.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }

        [HttpPost]
        public IActionResult Create([FromBody] HookahItem item)
        {
            if (item == null)
            {
                return BadRequest();
            }
            HookahItems.Add(item);
            return CreatedAtRoute("GetTodo", new { id = item.Key }, item);
        }
    }
}