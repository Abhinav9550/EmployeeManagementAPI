using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestApi_ED.Data;
using RestApi_ED.Models;
using RestApi_ED.Services;

namespace RestApi_ED.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private IAuthenticateService _authenticateService;
        
        public AuthenticationController(IAuthenticateService autherizeService)
        {
          _authenticateService =autherizeService;
        }
        [HttpPost]
        public IActionResult Post([FromBody]Credentials model)
        {
            var user = _authenticateService.Authenticate(model.Email, model.Password);

            if (user == null)
            {
                return BadRequest(new { message = "EmailId or Password is incorrect" });

            }
            return Ok(user);

        }





        public class Credentials
        {
            public string Email { set; get; }
            public string Password { set; get; }

        }











































    }
}
