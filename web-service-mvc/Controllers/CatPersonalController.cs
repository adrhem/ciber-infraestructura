using Microsoft.AspNetCore.Mvc;
using CiberInfraestructuraApi.DataAccess;

namespace CiberInfraestructuraApi.Controllers
{
    public class CatPersonalController : Controller
    {
        private readonly IDataAccessProvider _dataAccessProvider;

        public CatPersonalController(IDataAccessProvider dataAccessProvider)
        {
            _dataAccessProvider = dataAccessProvider;
        }

        [HttpGet("api/catpersonal")]
        public async Task<IActionResult> GetAllCatPersonal()
        {
            var catPersonalList = await _dataAccessProvider.GetAllPersonal();
            return Ok(catPersonalList);
        }
    }

}

