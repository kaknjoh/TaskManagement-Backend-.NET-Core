using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TaskManagment.Domain;
using TaskManagment.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TaskManagment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskUnitController : ControllerBase
    {
        private readonly ITaskUnitService _taskUnitService;
        private readonly ILogger<TaskUnitController> _logger;
        public TaskUnitController(ITaskUnitService taskUnitService, ILogger<TaskUnitController> logger)
        {
            _taskUnitService = taskUnitService;
            _logger = logger;
        }

        // GET: api/taskunit
        [HttpGet]
        public async Task<IActionResult>GetAllTaskUnits()
        {
            return Ok(await _taskUnitService.GetAllTaskUnitsAsync());
        }

        // GET api/taskunit/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTaskUnitById(int id)
        {
            TaskUnit taskUnitInDb = await _taskUnitService.GetTaskUnitByIdAsync(id);
            if (taskUnitInDb == null)
            {
                return NotFound();
            }

            return  Ok(await _taskUnitService.GetTaskUnitByIdAsync(id));
        }

        // POST taskunit/Post
        [HttpPost]
        public async Task<IActionResult> SavePost(TaskUnit taskUnit)
        {
            await _taskUnitService.SaveTaskUnitAsync(taskUnit);
            return CreatedAtAction(nameof(GetTaskUnitById), new { id = taskUnit.TaskUnitId }, taskUnit);
        }

        // PUT api/taskunit
        [HttpPut]
        public async Task<IActionResult> Put( TaskUnit taskUnit)
        {
            TaskUnit taskUnitInDb = await _taskUnitService.GetTaskUnitByIdAsync(taskUnit.TaskUnitId);
            if (taskUnitInDb == null)
            {
                return NotFound();
            }
            await _taskUnitService.EditTaskUnitAsync(taskUnitInDb, taskUnit);
            return Ok();
        }

        // DELETE api/taskunit/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            TaskUnit taskUnitInDb = await _taskUnitService.GetTaskUnitByIdAsync(id);
            if(taskUnitInDb == null)
            {
                return NotFound();
            }
            await _taskUnitService.DeleteTaskUnitAsync(taskUnitInDb);
            return Ok();
        }
    }
}
