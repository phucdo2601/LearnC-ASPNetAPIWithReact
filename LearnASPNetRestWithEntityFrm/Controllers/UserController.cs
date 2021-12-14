using LearnASPNetRestWithEntityFrmB1.Data;
using LearnASPNetRestWithEntityFrmB1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace LearnASPNetRestWithEntityFrm.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private LearnASPNetRestWithEntityFrmB1Context _dbContext;

        public UserController(LearnASPNetRestWithEntityFrmB1Context dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet("GetUsers")]
        public IActionResult GetUsers()
        {
            try
            {
                var users = _dbContext.users.ToList();
                if (users.Count == 0)
                {
                    return StatusCode(404, "No Users Found");
                }
                return Ok(users);
            }
            catch (System.Exception)
            {
                return StatusCode(500, "An Error has occurred");
            }
        }

        [HttpGet("GetUserDetail/{id}")]
        public IActionResult GetUserDetailById([FromRoute] int Id)
        {
            var user = _dbContext.users.FirstOrDefault(x => x.Id == Id);
            try
            {
                if (user == null)
                {
                    return StatusCode(404, "No Users Found");
                }

                return Ok(user);
            }
            catch (System.Exception)
            {

                return StatusCode(500, "An Error has occurred");
            }
        }

        [HttpPost("CreateUser")]
        public IActionResult CreateUser([FromBody] UserRequest request)
        {
            User user = new User();
            user.UserName = request.UserName;
            user.FirstName = request.FirstName;
            user.LastName = request.LastName;
            user.City = request.City;   
            user.Country = request.Country;
            user.State = request.State;

            try
            {

                _dbContext.users.Add(user); 
                _dbContext.SaveChanges();
                
            }
            catch (System.Exception ex)
            {

                return StatusCode(500, "An Error has occurred");
            }

            return Ok(user);
            

        }

        [HttpPut("UpdateUser")]
        public IActionResult UpdateUser([FromBody] UserRequest request)
        {
            var user = _dbContext.users.FirstOrDefault(x => x.Id == request.Id);
            try
            {
                
                if (user == null)
                {
                    return StatusCode(404, "No Users Found");
                }

                user.UserName = request.UserName;
                user.FirstName = request.FirstName;
                user.LastName = request.LastName;
                user.City = request.City;
                user.Country = request.Country;
                user.State = request.State;

                _dbContext.Entry(user).State = EntityState.Modified;
                _dbContext.SaveChanges();

            }
            catch (System.Exception)
            {

                return StatusCode(500, "An Error has occurred");

            }

            return Ok(user);

        }

        [HttpDelete("DeleteUser/{id}")]
        public IActionResult DeleteUser([FromRoute]int Id)
        {
            var user = _dbContext.users.FirstOrDefault(x => x.Id == Id);
            try
            {
                if (user == null)
                {
                    return StatusCode(404, "No Users Found");
                }
                _dbContext.Entry(user).State = EntityState.Deleted;
                _dbContext.SaveChanges();
            }
            catch (System.Exception)
            {

                return StatusCode(500, "An Error has occurred");
            }

            return Ok("Delete is Successfully");
        }

        
    }
}
