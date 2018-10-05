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
  public class CommentController : Controller
  {
    DataAccessLayer DAL = new DataAccessLayer();

    [HttpGet]
    public string Get()
    {
      return (DAL.GetType("comment"));
    }

    [HttpPost]
    public IActionResult AddComment([FromBody] Comment commentObj)
    {
      string message = DAL.AddComment(commentObj);
      if (message == "Success")
      {
        message = message + commentObj.comment_id;
        return StatusCode(200, message);
      }
      else
      {
        message = message + commentObj.comment_id;
        return StatusCode(400, message);
      }
    }
  }
}
