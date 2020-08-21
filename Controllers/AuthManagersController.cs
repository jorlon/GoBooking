using System.Collections.Generic;
using System.Linq;
using GoBooking.Interfaces;
using GoBooking.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GoBooking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthManagersController : ControllerBase
    {
        private readonly IAuthRepository<AppUser> _authRepository;

        public AuthManagersController(IAuthRepository<AppUser> context)
        {
            _authRepository = context;
        }

        // GET: api/<AuthManagersController>
        [HttpGet]
        public ActionResult<IEnumerable<AppUser>> GetUsers()
        {
            return _authRepository.GetAllUsers().ToList();
        }

        // GET api/<AuthManagersController>/5
        [HttpGet("{id}")]
        public ActionResult<AppUser> GetSingleUser(int id)
        {
            var user = _authRepository.GetUser(id);

            if (user == null)
            {
                return NotFound("User not found");
            }

            return user;
        }

        // POST api/<AuthManagersController>
        [HttpPost]
        public ActionResult<AppUser> Post(AppUser user)
        {
            if (user == null)
            {
                return BadRequest("User is null.");
            }
            _authRepository.CreateUser(user);
            return NoContent();
        }

        // PUT api/<AuthManagersController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] AppUser user)
        {
            if (user == null)
            {
                return BadRequest("Reservation is null.");
            }

            AppUser userToUpdate = _authRepository.GetUser(id);
            if (userToUpdate == null)
            {
                return NotFound("The User record couldn't be found.");
            }

            _authRepository.UpdateUser(userToUpdate, user);
            return NoContent();
        }

        // DELETE api/<AuthManagersController>/5
        [HttpDelete("{id}")]
        public ActionResult<AppUser> Delete(int id)
        {
            AppUser user = _authRepository.GetUser(id);
            if (user == null)
            {
                return NotFound("The Reservation record couldn't be found.");
            }

            _authRepository.DeleteUser(user);
            return NoContent();
        }
    }
}
