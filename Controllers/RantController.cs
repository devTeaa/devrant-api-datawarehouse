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
        message = message + rantObj.rant_id;
        return StatusCode(200, message);
      }
      else
      {
        message = message + rantObj.rant_id;
        return StatusCode(400, message);
      }
    }

    [HttpPost]
    public IActionResult AddTags([FromBody] Tag tagObj)
    {
      string message = DAL.AddTag(tagObj);
      if (message == "Success")
      {
        message = message + tagObj.tags_value;
        return StatusCode(200, message);
      }
      else
      {
        message = message + tagObj.tags_value;
        return StatusCode(400, message);
      }
    }

    [HttpPost]
    public IActionResult AddRantTags([FromBody] RantTags rantTagsObj)
    {
      string message = DAL.AddRantTags(rantTagsObj);
      if (message == "Success")
      {
        message = message + rantTagsObj.rant_id + ',' + rantTagsObj.tags_value;
        return StatusCode(200, message);
      }
      else
      {
        message = message + rantTagsObj.rant_id + ',' + rantTagsObj.tags_value;
        return StatusCode(400, message);
      }
    }
  }
}
