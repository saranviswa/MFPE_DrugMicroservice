using DrugsMicroservice.Models;
using DrugsMicroservice.Repository;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DrugsMicroservice.Controllers
{

    [Route("api/[controller]/[action]")]
    [ApiController]
    public class DrugController : ControllerBase
    {
        private IRepository drugrepository;
        static readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(DrugController));

        public DrugController(IRepository _drugrepository)
        {
            drugrepository = _drugrepository;

        }

        /// <summary>
        /// This Method gets the drug id and returns the details
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        // GET api/<DrugController>/5
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(DrugList), 200)]
        [ProducesResponseType(400)]
        public ActionResult GetDrugById(int id)
        {
            _log4net.Info("The drug id " + id + "received from GetDrugById method");
            drugrepository = new DrugRepository();
            DrugList drugList = drugrepository.GetDrugById(id);
            if (drugList != null)
            {
                return Ok(drugList);
            }
            return BadRequest("Invalid Drug Id");
        }
        /// <summary>
        /// This Method gets the drug name and returns the details
        /// </summary>
        /// <param name="Name"></param>
        /// <returns></returns>
        [HttpGet("{Name}")]
        [ProducesResponseType(typeof(DrugList), 200)]
        [ProducesResponseType(400)]
        public ActionResult GetDrugByName(string Name)
        {
            _log4net.Info("The drug name " + Name + "received from GetDrugByName method");
            drugrepository = new DrugRepository();
            DrugList drugList = drugrepository.GetDrugByName(Name);
            if (drugList != null)
            {
                _log4net.Info("Returning the druglist");
                return Ok(drugList);
            }
            _log4net.Info("Returning bad request");
            return BadRequest("Invalid Drug Name");
        }
        /// <summary>
        /// This Methods gets the drug id, location and returns the quantity in that location
        /// </summary>
        /// <param name="DrugId"></param>
        /// <param name="Location"></param>
        /// <returns></returns>
        // POST api/<DrugController>
        [HttpPost]
        [ProducesResponseType(typeof(DrugLocationWise), 200)]
        [ProducesResponseType(400)]
        public ActionResult GetDrugByLocation(int DrugId, [FromBody] string Location)
        {
            _log4net.Info("The drug id " + DrugId + "location" + Location + "received from GetDrugByLocation method");
            drugrepository = new DrugRepository();
            DrugLocationWise drugLocationWise = drugrepository.GetDrugByLocation(DrugId, Location);
            if (drugLocationWise != null)
            {
                _log4net.Info("Returning the druglocationwise");
                return Ok(drugLocationWise);
            }
            _log4net.Info("Returning bad request");
            return BadRequest("Invalid Details");
        }


    }
}
