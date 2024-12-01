using Microsoft.AspNetCore.Mvc;
using ToDoApi.Models;
using ToDoApi.Repositories;

namespace ToDoApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ToDoController : ControllerBase
    {
        private readonly ToDoRepository _repository = new();

        [HttpGet]
        public IActionResult GetAll() => Ok(_repository.GetAll());

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var item = _repository.GetById(id);
            return item == null ? NotFound() : Ok(item);
        }

        [HttpPost]
        public IActionResult Add([FromBody] ToDoItem item)
        {
            if (string.IsNullOrEmpty(item.Title)) return BadRequest("Title is required.");
            var createdItem = _repository.Add(item.Title);
            return CreatedAtAction(nameof(GetById), new { id = createdItem.Id }, createdItem);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] ToDoItem item)
        {
            if (!_repository.Update(id, item.Status)) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (!_repository.Delete(id)) return NotFound();
            return NoContent();
        }
    }
}
