using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TaskManagment.Domain;
using TaskManagment.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TaskManagment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssignedUserController : ControllerBase
    {
        private readonly IAssignedUserService _assignedUserService;

        public AssignedUserController(IAssignedUserService assignedUserService)
        {
            _assignedUserService = assignedUserService;
        }
        // GET: api/<AssignedUserController>
        [HttpGet]
        public async Task<IActionResult> GetAllAssignedUsers()
        {
            return Ok(await _assignedUserService.GetAllAssignedUsersAsync());
        }

        // GET api/<AssignedUserController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAssignedUserById(int id)
        {
            AssignedUser assignedUserInDb = await _assignedUserService.GetAssignedUserByIdAsync(id);
            if (assignedUserInDb == null)
            {
                return NotFound();
            }
            return Ok(await _assignedUserService.GetAssignedUserByIdAsync(id));
        }

        // POST api/<AssignedUserController>
        [HttpPost]
        public async Task<IActionResult> CreateAssignedUser(AssignedUser assignedUser)
        {
            await _assignedUserService.SaveAssignedUserAsync(assignedUser);
            return CreatedAtAction(nameof(GetAssignedUserById), new { id = assignedUser.AssignedUserId }, assignedUser);
        }

        // PUT api/<AssignedUserController>
        [HttpPut]
        public async Task<IActionResult> EditAssignedUser(AssignedUser assignedUser)
        {
            AssignedUser assignedUserInDb = await _assignedUserService.GetAssignedUserByIdAsync(assignedUser.AssignedUserId);
            if (assignedUserInDb == null)
            {
                return NotFound();
            }
            await _assignedUserService.EditAssignedUserAsync(assignedUserInDb, assignedUser);
            return Ok();

        }

        // DELETE api/<AssignedUserController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAssignedUser(int id)
        {
            AssignedUser assignedUserInDb = await _assignedUserService.GetAssignedUserByIdAsync(id);
            if (assignedUserInDb == null)
            {
                return NotFound();
            }
            await _assignedUserService.DeleteAssignedUserAsync(assignedUserInDb);
            return Ok();
        }
    }
}
