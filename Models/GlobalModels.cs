using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace devrant_api_datawarehouse.Models
{
  public class Test
  {
    public int id { get; set; }
    public string text { get; set; }
  }

  public class Rant
  {
    public string rant_id { get; set; }
    public string text { get; set; }
    public string score { get; set; }
    public string created_time { get; set; }
    public string attached_image { get; set; }
    public string edited { get; set; }
    public string link { get; set; }
    public string user_id { get; set; }
  }

  public class User
  {
    public string user_id { get; set; }
    public string username { get; set; }
    public string score { get; set; }
    public string about { get; set; }
    public string location { get; set; }
    public string created_time { get; set; }
    public string skills { get; set; }
    public string github { get; set; }
    public string website { get; set; }
    public string rants { get; set; }
    public string upvoted { get; set; }
    public string comments { get; set; }
    public string favorites { get; set; }
    public string collabs { get; set; }
    public string avatar_b { get; set; }
    public string avatar_i { get; set; }
    public string dpp { get; set; }
  }
}