using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TaskManagment.DAL;
using TaskManagment.Domain;
using TaskManagment.DTOS;
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
        private readonly ITaskUnitRepository _taskUnitRepository;
        public TaskUnitController(ITaskUnitService taskUnitService, ILogger<TaskUnitController> logger, ITaskUnitRepository _taskUnitRepository)
        {
            _taskUnitService = taskUnitService;
            _logger = logger;
            this._taskUnitRepository = _taskUnitRepository;
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
            ViewTaskUnitDTO taskUnitInDb = await _taskUnitService.GetTaskUnitByIdAsync(id);
            if (taskUnitInDb == null)
            {
                return NotFound();
            }

            return  Ok(await _taskUnitService.GetTaskUnitByIdAsync(id));
        }

        // POST taskunit/Post
        [HttpPost]
        public async Task<IActionResult> SavePost(TaskUnitDTO taskUnitDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var result=await _taskUnitService.SaveTaskUnitAsync(taskUnitDto);
            return CreatedAtAction(nameof(GetTaskUnitById), new { id =  result.TaskUnitId}, taskUnitDto);
        }

        // PUT api/taskunit
        [HttpPut]
        public async Task<IActionResult> Put( TaskUnitDTO taskUnit)
        {
            ViewTaskUnitDTO taskUnitDTO = await _taskUnitService.GetTaskUnitByIdAsync(taskUnit.TaskUnitId);
            if (taskUnitDTO == null)
            {
                return NotFound();
            }
            await _taskUnitService.EditTaskUnitAsync(taskUnit);
            return Ok();
        }

        // DELETE api/taskunit/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            ViewTaskUnitDTO taskUnitDTO = await _taskUnitService.GetTaskUnitByIdAsync(id);
            if(taskUnitDTO == null)
            {
                return NotFound();
            }
            await _taskUnitService.DeleteTaskUnitAsync(taskUnitDTO);
            return Ok();
        }
    }
}
