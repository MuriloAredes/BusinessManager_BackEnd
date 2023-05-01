using BusinessManagement.Application.SellerService.Create;
using BusinessManagement.Domain.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace BusinessManagement.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SellerController : Controller
    {
        private readonly ICreateSellerService _createSellerService;
        public SellerController(ICreateSellerService createSellerService)
        {
                _createSellerService= createSellerService;  
        }

        [HttpPost(Name = "AdicionarSeller")]
        public async Task<IActionResult> AdicionarSeller( CreateSellerRequest request)
        {
            try 
            {
                var result = await _createSellerService.Create(request);

                return Ok(result);
            }catch(Exception ex) 
            {
                return BadRequest(ex.Message); 
            }
        }
    }
}
