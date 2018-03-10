using System;
using System.Collections.Generic;
using AutoMapper;
using hotels.api.Models;
using Microsoft.AspNetCore.Mvc;

namespace hotels.api.Controllers
{
    [Route("api/users")]
    public class UserController : Controller
    {
 

        private readonly IUserQueryHandler userQueryHandler;
        private readonly IMapper mapper;

        public UserController(IUserQueryHandler userQueryHandler, IMapper mapper)
        {
            this.userQueryHandler = userQueryHandler;
            this.mapper = mapper;
        }

        // protected UserController(IUserQueryHandler userQueryHandler) =>
        //     this.userQueryHandler = userQueryHandler;

        [HttpGet]
        public IActionResult GetUsers(){

            var result = new List<UserResponse>();

            var users = this.userQueryHandler.GetUsers();
            if(users != null)
            {
                result = mapper.Map<List<UserData>, List<UserResponse>>(users);               
            }

            return Ok(result);
            
        }
    }
}
