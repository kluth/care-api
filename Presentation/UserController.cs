using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

using CareApi.Entities.Models;

namespace CareApi.Presentation
{
    [Route("api/[controller]s")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserContext _context;
        public UserController(UserContext context) {
            _context = context;
        }
        // GET: api/<UserController>
        [HttpGet]
        public IActionResult GetAllUsers()
        {
            var users = _context.Users.ToList();
            return Ok(users);
        }

        // GET api/<UserController>/5
        [HttpGet("{id:guid}")]
        public IActionResult GetUserById([FromRoute] Guid id)
        {
            var user = _context.Users.Find(id);
            return user is null ? NotFound() : Ok(user);
        }

        // POST api/<UserController>
        [HttpPost]
        public IActionResult PostUser(UserDTO userDTO)
        {
            var userEntity = new User() {
                username = userDTO.username,
                password = userDTO.password
            };
            _context.Users.Add(userEntity);
            _context.SaveChanges();
            return Ok(userEntity);
        }

        // PUT api/<UserController>/5
        [HttpPut("{id:guid}")]
        public IActionResult PutUser(Guid id, UserDTO userDTO)
        {
            var user = _context.Users.Find(id);
            if (user is null) {
                return NotFound();
            }
            user.username = userDTO.username;
            user.password = userDTO.password;
            _context.SaveChanges();
            return Ok(user);
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public void DeleteUser(int id)
        {
        }
    }
}
