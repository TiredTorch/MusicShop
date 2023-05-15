using ClosedXML.Excel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MusicShopc.Models;
using MusicShopc.Services;

namespace MusicShopc.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    [ApiVersion("2.0")]
    [ApiVersion("3.0")]
    [Obsolete("This version is deprecated.")]
    public class MyController : ControllerBase
    {
        private readonly IMyService _myService;

        public MyController(IMyService myService)
        {
            _myService = myService;
        }   

        [HttpGet]
        [MapToApiVersion("1.0")]
        public IActionResult GetV1()
        {
            int randomInt = _myService.GetRandomInt();
            return Ok(randomInt);
        }

        [HttpGet]
        [MapToApiVersion("2.0")]
        public IActionResult GetV2()
        {
            string randomText = _myService.GetRandomText();
            return Ok(randomText);
        }

        [HttpGet]
        [MapToApiVersion("3.0")]
        public IActionResult GetV3()
        {
            byte[] excelFile = _myService.GetExcelFile();
            return File(excelFile, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "sample.xlsx");
        }
    }
}

