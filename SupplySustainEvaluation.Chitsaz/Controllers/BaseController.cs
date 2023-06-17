using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace SupplySustainEvaluation.Chitsaz.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    [Authorize]
    [EnableCors("ClientApp")]
    public class BaseController : ControllerBase
    {
    }
}
