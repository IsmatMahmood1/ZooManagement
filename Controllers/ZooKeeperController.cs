using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ZooManagement.Models.Api;
using ZooManagement.Repositories;
using ZooManagement.Request;

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
            //var zooKeeper = _zooRepo.GetZooKeeperById(id);
            //return new ZooKeeperApi(zooKeeper);
            return null;
        }

        [HttpPost("add")]
        public string Add([FromQuery] AddZooKeeperRequest addZooKeeperRequest)
        {
            //var AddSuccess = _zooRepo.AddAnimal(addAnimalRequest);
            //return AddSuccess;

            return null;
        }

    }
}
