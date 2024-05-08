
using BackendServices.Core;
using BackendServices.Services;
using Microsoft.AspNetCore.Mvc;

namespace BackendServices.Controllers
{
    public class ServicesControllers : ControllerBase
    {
        private readonly IRegister RegisterService;

        public ServicesControllers(IRegister registerService)
        {
            RegisterService = registerService;
        }

        [HttpPost]
        [Route("auth/register")]
        public async ValueTask<IActionResult> RegisterAsync([FromBody] RegisterRequest request)
        {
            var response = await RegisterService.ExecuteAsync(request);

            if (!response.Success)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }
        
    }
}