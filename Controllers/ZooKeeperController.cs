using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZooManagement.Repositories;
using ZooManagement.Request;
using ZooManagement.Models.Api;

namespace ZooManagement.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ZooKeeperController : ControllerBase
    {
        private readonly ILogger<AnimalController> _logger;
        private readonly IZooRepo _zooRepo;

        public ZooKeeperController(ILogger<AnimalController> logger, IZooRepo zooRepo)
        {
            _logger = logger;
            _zooRepo = zooRepo;
        }

        [HttpGet("{id}")]
        public ZooKeeperApi Get(int id)
        {
            //var animal = _zooRepo.GetAnimalById(id);
            //return new AnimalApi(animal);
        }

        [HttpPost("add")]
        public string Add([FromQuery] AddZooKeeperRequest addZooKeeperRequest)
        {
            //var AddSuccess = _zooRepo.AddAnimal(addAnimalRequest);
            //return AddSuccess;
        }

    }
}
