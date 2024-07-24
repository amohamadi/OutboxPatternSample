using Microsoft.AspNetCore.Mvc;

namespace OrderApi.Controllers;

[ApiController]
[Route("api/v1/[controller]/[action]")]
public class BaseController : ControllerBase
{
}