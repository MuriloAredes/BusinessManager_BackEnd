using BusinessManagement.Application.RegionService.Register;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BusinessManagement.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RegionController : Controller
    {
        private readonly IRegisterRegionService _registerRegionService;
        public RegionController(IRegisterRegionService registerRegionService)
        {
            _registerRegionService = registerRegionService;
        }
        // GET: RegionController
        [HttpGet(Name = "RegistrarCarga")]
        public async Task<IActionResult> Index()
        {
            try
            {
                var result = await _registerRegionService.RegisterRegion();

                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }


    }
}
