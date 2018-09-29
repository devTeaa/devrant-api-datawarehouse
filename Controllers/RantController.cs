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
  public class RantController : Controller
  {
    DataAccessLayer DAL = new DataAccessLayer();

    [HttpGet]
    public string Get()
    {
      return (DAL.GetType("rant"));
    }

    // POST api/AddUser
    [HttpPost]
    public IActionResult AddRant([FromBody] Rant rantObj)
    {
      string message = DAL.AddRant(rantObj);
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
