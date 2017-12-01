using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DotNetCoreSqlDb.Models;

namespace DotNetCoreSqlDb.Controllers
{
    // https://docs.microsoft.com/en-us/aspnet/core/tutorials/first-web-api-mac

    [Route("api/todo")]
    public class TodoController : Controller
    {
        private readonly MyDatabaseContext _context;

        public TodoController(MyDatabaseContext context)
        {
            _context = context;
        }

        [HttpGet("{id}", Name = "GetTodo")]
        public IActionResult GetById(int id)
        {
            var item = _context.Todo.FirstOrDefault(t => t.ID == id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Todo item)
        {
            if (item == null)
            {
                return BadRequest();
            }

            _context.Todo.Add(item);
            _context.SaveChanges();

            return CreatedAtRoute("GetTodo", new { id = item.ID }, item);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Todo item)
        {
            if (item == null || item.ID != id)
            {
                return BadRequest();
            }

            var todo = _context.Todo.FirstOrDefault(t => t.ID == id);
            if (todo == null)
            {
                return NotFound();
            }

            //todo.IsComplete = item.IsComplete;   // TODO: add IsComplete field to database
            todo.Description = item.Description;

            _context.Todo.Update(todo);
            _context.SaveChanges();
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var todo = _context.Todo.FirstOrDefault(t => t.ID == id);
            if (todo == null)
            {
                return NotFound();
            }

            _context.Todo.Remove(todo);
            _context.SaveChanges();
            return new NoContentResult();
        }
    }
}
