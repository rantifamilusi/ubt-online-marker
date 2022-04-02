using Microsoft.AspNetCore.Mvc;
using OnlineMarker.Api.Repository.Interfaces;
using OnlineMarker.Shared;

namespace OnlineMarker.Api.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class ServicesController : Controller
    {
        private readonly IOnlineMarkerService _onlineMarkerService;
        public ServicesController(IOnlineMarkerService onlineMarkerService)
        {
            _onlineMarkerService = onlineMarkerService;
        }

        [HttpGet]
        [Route("GetPaperQuestionInfo")]
        public async  Task<IActionResult> GetPaperQuestionInfo(string examtype, string papercode)
        {
            
                if (string.IsNullOrEmpty(examtype) || string.IsNullOrEmpty(papercode)) return BadRequest("Parameters are missing");
                return new OkObjectResult( await _onlineMarkerService.GetPaperQuesInfos(examtype, papercode));
            
        }
    }
}
