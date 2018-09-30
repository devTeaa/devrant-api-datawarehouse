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
  public class DateTimeController : Controller
  {
    DataAccessLayer DAL = new DataAccessLayer();

    [HttpGet]
    public string Get()
    {
      return (DAL.GetType("rant"));
    }

    // POST api/AddUser
    [HttpPost]
    public IActionResult AddDate([FromBody] DateModel date)
    {
      string message = DAL.AddDate(date);
      if (message == "Success")
      {
        return StatusCode(200, message);
      }
      else
      {
        return StatusCode(400, message);
      }
    }

    [HttpPost]
    public IActionResult AddTime([FromBody] TimeModel time)
    {
      string message = DAL.AddTime(time);
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
