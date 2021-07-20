using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using ZooManagement.Models.Api;

namespace ZooManagement.Controllers
{
    [ApiController]
    [Route("/animal")]
    public class AnimalController : ControllerBase
    {
        private readonly ILogger<AnimalController> _logger;

        public AnimalController(ILogger<AnimalController> logger)
        {
            _logger = logger;
        }

        [HttpGet("{id}")]
        public IEnumerable<AnimalApi> Get(int id)
        {
            // lookup the id in the database
            // convert the animaldBmodel to API model 
            //return API model (do we need to json?)
            return
        }
    }
}
