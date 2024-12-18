using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ZWTCampusCareerView.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Data2Controller : ControllerBase
    {
 

        // 示例：获取其他图表类型的数据
        [HttpGet("GetAlternativeChartData")]
        public IActionResult GetAlternativeChartData([FromQuery] string category)
        {
            List<int> data;
            switch (category)
            {
                case "CategoryA":
                    data = new List<int> { 50, 75, 100 };
                    break;
                case "CategoryB":
                    data = new List<int> { 150, 200, 250 };
                    break;
                case "CategoryC":
                    data = new List<int> { 300, 350, 400 };
                    break;
                default:
                    data = new List<int> { 0, 0, 0 }; // 默认数据
                    break;
            }
            return Ok(data);
        }
    }
}
