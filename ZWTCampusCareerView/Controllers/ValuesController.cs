using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace MyWebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ValuesController : ControllerBase
    {
        // GET: api/values
        [HttpGet]
        public IActionResult Get()
        {
            var data = new List<string> { "value1", "value2", "value3" };
            return Ok(data);  // 返回 200 OK 响应，并附带数据
        }

        // GET: api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var data = $"value{id}";
            return Ok(data);  // 返回指定 id 的值
        }

        // POST: api/values
        [HttpPost]
        public IActionResult Post([FromBody] string value)
        {
            // 处理接收到的 POST 数据
            return CreatedAtAction(nameof(Get), new { id = 1 }, value);  // 返回 201 Created 响应
        }
    }
}
