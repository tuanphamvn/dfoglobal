using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DFO.Services;
using DFO.Entities;
using DFO.WebAPI.Models;
using AutoMapper;
namespace UserAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        // GET api/users
        [HttpGet]
        public IActionResult GetAllUsers()
        {
            var users = _userService.GetUsers();
            var userModels = Mapper.Map<IEnumerable<UserViewModel>>(users);
            return Ok(userModels);
        }

        // GET api/users/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var user = _userService.GetUser(id);
            if (user == null)
                return NotFound();
            var userModel = Mapper.Map<UserViewModel>(user);
            return Ok(userModel);
        }

        //// POST api/users
        [HttpPost]
        public IActionResult Post([FromBody] UserUpdateModel userUpdateModel)
        {
            var user = Mapper.Map<User>(userUpdateModel);
            var isSuccessful = _userService.AddUser(user);
            if (!isSuccessful)
                return Conflict();
            return CreatedAtAction(nameof(Get), new { id = user.Id }, user);
        }

        //// PUT api/users/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UserUpdateModel userUpdateModel)
        {
            var user = Mapper.Map<User>(userUpdateModel);
            user.Id = id;
            var isSuccessful = _userService.UpdateUser(user);
            if (!isSuccessful)
                return NotFound();
            return NoContent();
        }

        //// DELETE api/users/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var user = _userService.GetUser(id);
            if (user == null)
                return NotFound();
            _userService.DeleteUser(id);
            return NoContent();
        }
    }
}
