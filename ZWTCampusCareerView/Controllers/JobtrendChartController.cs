using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ZWTCampusCareerView.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobtrendChartController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetJobTrendData([FromQuery] string year)
        {
            List<double> data; // 使用 List<double>
            switch (year)
            {
                case "2024":
                    data = new List<double> { 100.0, 12.5, 70.5, 1.0, 20.1, 30.2, 5.0, 10.0, 3.0, 8.0, 50.0, 15.0, 2.0 }; // 2024年的数据
                    break;
                case "2023":
                    data = new List<double> { 180.0, 50.0, 200.0, 10.0, 160.0, 120.0, 140.0, 40.0, 60.0, 30.0, 70.0, 20.0, 15.0 }; // 2023年的数据
                    break;
                case "2022":
                    data = new List<double> { 130.0, 110.0, 90.0, 150.0, 70.0, 50.0, 5.0, 40.0, 20.0, 15.0, 10.0, 60.0, 2.0 }; // 2022年的数据
                    break;
                case "2021":
                    data = new List<double> { 80.0, 30.0, 120.0, 10.0, 40.0, 2.0, 6.0, 60.0, 20.0, 15.0, 4.0, 8.0, 100.0 };  // 2021年的数据
                    break;
                case "2020":
                    data = new List<double> { 90.0, 5.0, 30.0, 20.0, 0.5, 10.0, 3.0, 50.0, 15.0, 30.0, 2.0, 0.1, 40.0 };  // 2020年的数据
                    break;
                case "2019":
                    data = new List<double> { 60.0, 80.0, 40.0, 10.0, 5.0, 0.5, 3.0, 20.0, 2.0, 1.0, 0.1, 30.0, 15.0 };  // 2019年的数据
                    break;
                default:
                    data = new List<double> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }; // 默认数据
                    break;
            }
            return Ok(data);
        }
    }
}
