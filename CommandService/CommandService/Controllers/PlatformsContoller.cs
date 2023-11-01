﻿using Microsoft.AspNetCore.Mvc;

namespace CommandService.Controllers
{
    [Route("api/c/[controller]")]
    [ApiController]
    public class PlatformsController: ControllerBase
    {
        public PlatformsController()
        {
            
        }


        [HttpPost]
        public ActionResult TestInboundConnection()
        {
            Console.WriteLine("--> Inbound Post # Command Service");
            return Ok("Inbound test of from Platform Controler");
        }
    }
}