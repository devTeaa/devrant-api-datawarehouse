using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using devrant_api_datawarehouse.Models;
using System.Net.Http;
using System.Net;

namespace devrant_api_datawarehouse.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class ValuesController : Controller
  {
    TestDataAccess objTest = new TestDataAccess();

    // GET api/values
    [HttpGet]
    public ActionResult<IEnumerable<string>> Get()
    {
      return new string[] { "value1", "value2" };
    }

    // GET api/values/5
    [HttpGet("{id}")]
    public JsonResult Get(int id)
    {
      List<Test> lstTest = new List<Test>();
      lstTest = objTest.GetAllTest().ToList();

      return Json(lstTest);
    }

    // POST api/values
    [HttpPost]
    public IActionResult AddTest([FromBody] Test test)
    {
      return StatusCode(200, test);
    }
  }
}
