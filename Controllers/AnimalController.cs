using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using ZooManagement.Models.Api;
using ZooManagement.Repositories;
using ZooManagement.Request;

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
            return new AnimalApi(animal);
        }

        [HttpPost("add")]
        public void AddAnimal([FromQuery] AddAnimalRequest addAnimalRequest)
        {
            //TODO
            //make postrequest object
            //make repo function to turn it into objects to add to the db.
            //Part 4 - add checks on whether the enclosure limit has been reached to halt execution. 
        }

        [Route("species")]
        [HttpGet]
        public IEnumerable<string> GetSpecies()
        {
            return _zooRepo.GetAllSpecies();
        }
        
        [Route("search")]
        [HttpGet]
        public IEnumerable<AnimalApi> FilteredSearchAnimals ([FromQuery] SearchRequest searchRequest)
        {
            var Animals = _zooRepo.SearchAnimalsByFilters(searchRequest);

            return Animals.Select(a => new AnimalApi(a));
        }


    }
}
