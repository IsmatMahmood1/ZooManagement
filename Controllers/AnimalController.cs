using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using ZooManagement.Models.Api;
using ZooManagement.Repositories;

namespace ZooManagement.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AnimalController : ControllerBase
    {
        private readonly ILogger<AnimalController> _logger;
        private readonly IZooRepo _zooRepo;


        public AnimalController(ILogger<AnimalController> logger, IZooRepo zooRepo)
        {
            _logger = logger;
            _zooRepo = zooRepo;
        }

        [HttpGet("{id}")]
        public AnimalApi Get(int id)
        {
            var animal= _zooRepo.SearchAnimalById(id);
            // lookup the id in the database
            // convert the animaldBmodel to API model 
            //return API model (do we need to json?)
            return new AnimalApi(animal);
        }
    }
}
