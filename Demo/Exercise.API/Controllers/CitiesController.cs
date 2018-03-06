using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Exercise.API.Controllers
{
    [Route("api/cities")]
    public class CitiesController : Controller
    {
        [HttpGet()]
        public IActionResult GetCities()
        {

            return Ok(CitiesDataStore.Current.Cities);
        } 

        [HttpGet("{id}")]
        public IActionResult GetCity(int id)
        {            
            var citiesToReturn = CitiesDataStore.Current.Cities.FirstOrDefault(c => c.Id == id);

            if (citiesToReturn == null)
            {
                return NotFound();
            }

            return Ok(citiesToReturn);
        }
    }
}
