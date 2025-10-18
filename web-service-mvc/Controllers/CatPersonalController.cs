using Microsoft.AspNetCore.Mvc;
using CiberInfraestructuraApi.DataAccess;

namespace CiberInfraestructuraApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CatPersonalController : ControllerBase
    {
        private readonly IDataAccessProvider _dataAccessProvider;

        public CatPersonalController(IDataAccessProvider dataAccessProvider)
        {
            _dataAccessProvider = dataAccessProvider;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCatPersonal()
        {
            var catPersonalList = await _dataAccessProvider.GetAllPersonal();
            return Ok(catPersonalList);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCatPersonal(int id)
        {
            var catPersonal = await _dataAccessProvider.GetPersonal(id);
            if (catPersonal == null)
            {
                return NotFound();
            }
            return Ok(catPersonal);
        }
    }
}

