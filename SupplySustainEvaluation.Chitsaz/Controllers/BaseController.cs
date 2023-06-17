using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace SupplySustainEvaluation.Chitsaz.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    [EnableCors("ClientApp")]
    public class BaseController : ControllerBase
    {
    }
}
