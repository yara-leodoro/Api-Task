using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using taskMenager.Data.Repositories;
using taskMenager.Models;
using taskMenager.Models.InputModels;

namespace taskMenager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class taskController : ControllerBase
    {
        private ITaskRepository _taskRepository;

        public taskController(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var response = _taskRepository.listAll();
            return Ok(response);
        }

        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            var response = _taskRepository.list(id);

            if (response == null) return NotFound();
            return Ok(response);
        }

        [HttpPost]
        public IActionResult Post([FromBody] TaskInputModel newTask)
        {
            var task = new task(newTask.Name, newTask.Details);

            _taskRepository.Create(task);
            return Created("", task);
        }

        [HttpPut("{id}")]
        public IActionResult Put(string id, [FromBody] TaskInputModel newTask)
        {
            var task = _taskRepository.list(id);

            if (task == null) return NotFound();

            task.UpdateTask(newTask.Name, newTask.Details, newTask.Concluded);

            _taskRepository.Update(id, task);

            return Ok(task);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            var task = _taskRepository.list(id);

            if (task == null) return NotFound();

            _taskRepository.Delete(id);

            return NoContent();
        }
    }
}
