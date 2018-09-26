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
  [Route("api/[controller]/[action]")]
  [ApiController]
  public class UserController : Controller
  {
    DataAccessLayer DAL = new DataAccessLayer();

    [HttpGet]
    public ActionResult<IEnumerable<string>> Get()
    {
      return new string[] { "value1", "value2" };
    }

    // POST api/AddUser
    [HttpPost]
    public IActionResult AddUser([FromBody] User userObj)
    {
      string message = DAL.AddUser(userObj);
      if (message == "Success")
      {
        return StatusCode(200, message);
      }
      else
      {
        return StatusCode(400, message);
      }
    }
  }
}
