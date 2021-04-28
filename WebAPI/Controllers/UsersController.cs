using Business.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities.Concrete;


namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("getuserbyemail")]
        public IActionResult GetUserByEmail(string email)
        {
            var result = _userService.GetByMail(email);

          
                return Ok(result);
            

            return BadRequest(result);
        }

        [HttpGet("getusersdetailsbyemail")]
        public IActionResult GetUsersDetailsByEmail(string email)
        {
            var result = _userService.GetUserDetailsByEmail(email);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);



        }

    }
}
