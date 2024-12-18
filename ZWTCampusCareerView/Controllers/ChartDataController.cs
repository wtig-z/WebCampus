using Microsoft.AspNetCore.Mvc;

namespace ZWTCampusCareerView.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetChartData([FromQuery] string year)
        {
            List<int> data;
            switch (year)
            {
                case "2024":
                    data = new List<int> { 106, 108 };
                    break;
                case "2023":
                    data = new List<int> { 20, 138 };
                    break;
                case "2022":
                    data = new List<int> { 280, 20 };
                    break;
                case "2021":
                    data = new List<int> { 10, 120 };
                    break;
                case "2019":
                    data = new List<int> { 1, 320 };
                    break;
                default:
                    data = new List<int> { 0, 0 }; // 默认数据
                    break;
            }
            return Ok(data);
        }
    }

}
