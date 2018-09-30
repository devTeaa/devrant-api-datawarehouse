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
    public string user_id { get; set; }
    public string num_comments { get; set; }
    public string score { get; set; }
    public string created_time { get; set; }
    public string edited { get; set; }
    public string link { get; set; }
    public string tags { get; set; }
  }

  public class Tag
  {
    public string tags_value { get; set; }
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

  public class Comment
  {
    public string rant_id { get; set; }
    public string comment_id { get; set; }
    public string body { get; set; }
    public string score { get; set; }
    public string user_id { get; set; }
    public string created_time { get; set; }
  }

  public class DateModel
  {
    public string date_short { get; set; }
    public string date_medium { get; set; }
    public string date_full { get; set; }
    public string day { get; set; }
    public string day_full { get; set; }
    public string month { get; set; }
    public string month_full { get; set; }
    public string year { get; set; }
  }

  public class TimeModel
  {
    public string time_value { get; set; }
    public string hours_24 { get; set; }
    public string hours_12 { get; set; }
    public string minutes { get; set; }
    public string am_pm { get; set; }
  }
}