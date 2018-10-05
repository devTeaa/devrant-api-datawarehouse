using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

using Microsoft.Extensions.Configuration;

namespace devrant_api_datawarehouse.Models
{
  public class DataAccessLayer
  {
    // string ConnectionString = "Server=DESKTOP-52DK8L2\\SQLEXPRESS;Database=devrantapi;User ID=sa;Password=password";
    string ConnectionString = "Server=DESKTOP-52DK8L2;Database=devrantapi;User ID=sa;Password=password.1";
    // string ConnectionString = "Server=tcp:azure-devrantapi.database.windows.net,1433;Initial Catalog=devrantapi;Persist Security Info=False;User ID=thisadmin;Password=Password123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

    public IEnumerable<Test> GetAllTest()
    {
      List<Test> lstTest = new List<Test>();

      using (SqlConnection conn = new SqlConnection(ConnectionString))
      {
        SqlCommand cmd = new SqlCommand("spGetAllTest", conn);

        cmd.CommandType = CommandType.StoredProcedure;

        conn.Open();

        SqlDataReader rdr = cmd.ExecuteReader();

        while (rdr.Read())
        {
          Test test = new Test();

          test.id = Convert.ToInt32(rdr["id"]);
          test.text = rdr["text"].ToString();

          lstTest.Add(test);
        }
        conn.Close();
      }
      return lstTest;
    }

    // Get details
    public string GetType(string type)
    {
      using (SqlConnection conn = new SqlConnection(ConnectionString))
      {
        SqlCommand cmd = new SqlCommand("spGetTypeInfo", conn);
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.AddWithValue("@type", type);

        try
        {
          conn.Open();
          DataSet ds = new DataSet();

          SqlDataAdapter da = new SqlDataAdapter(cmd);
          da.Fill(ds);
          ds.Dispose();

          conn.Close();
          return (JsonConvert.SerializeObject(ds));
        }
        catch (Exception ex)
        {
          return (ex.Message.ToString());
        }
      }
    }

    // AddUser  
    public string AddUser(User UserObj)
    {
      using (SqlConnection conn = new SqlConnection(ConnectionString))
      {
        SqlCommand cmd = new SqlCommand("spAddUser", conn);
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.AddWithValue("@user_id", Convert.ToInt32(UserObj.user_id));
        cmd.Parameters.AddWithValue("@username", UserObj.username);
        cmd.Parameters.AddWithValue("@score", Convert.ToInt32(UserObj.score));
        cmd.Parameters.AddWithValue("@about", UserObj.about);
        cmd.Parameters.AddWithValue("@location", UserObj.location);
        cmd.Parameters.AddWithValue("@created_time", Convert.ToDateTime(UserObj.created_time));
        cmd.Parameters.AddWithValue("@skills", UserObj.skills);
        cmd.Parameters.AddWithValue("@github", UserObj.github);
        cmd.Parameters.AddWithValue("@website", UserObj.website);
        cmd.Parameters.AddWithValue("@rants", Convert.ToInt32(UserObj.rants));
        cmd.Parameters.AddWithValue("@upvoted", Convert.ToInt32(UserObj.upvoted));
        cmd.Parameters.AddWithValue("@comments", Convert.ToInt32(UserObj.comments));
        cmd.Parameters.AddWithValue("@favorites", Convert.ToInt32(UserObj.favorites));
        cmd.Parameters.AddWithValue("@collabs", Convert.ToInt32(UserObj.collabs));
        cmd.Parameters.AddWithValue("@avatar_b", UserObj.avatar_b);
        cmd.Parameters.AddWithValue("@avatar_i", UserObj.avatar_i);
        cmd.Parameters.AddWithValue("@dpp", UserObj.dpp);

        try
        {
          conn.Open();
          cmd.ExecuteNonQuery();
          conn.Close();
          return ("Success");
        }
        catch (Exception ex)
        {
          return (ex.Message.ToString());
        }
      }
    }

    // AddRant
    public string AddRant(Rant RantObj)
    {
      using (SqlConnection conn = new SqlConnection(ConnectionString))
      {
        SqlCommand cmd = new SqlCommand("spAddRant", conn);
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.AddWithValue("@rant_id", Convert.ToInt32(RantObj.rant_id));
        cmd.Parameters.AddWithValue("@text", RantObj.text);
        cmd.Parameters.AddWithValue("@user_id", Convert.ToInt32(RantObj.user_id));
        cmd.Parameters.AddWithValue("@num_comments", Convert.ToInt32(RantObj.num_comments));
        cmd.Parameters.AddWithValue("@score", Convert.ToInt32(RantObj.score));
        cmd.Parameters.AddWithValue("@created_time", Convert.ToDateTime(RantObj.created_time));
        cmd.Parameters.AddWithValue("@edited", Convert.ToBoolean(RantObj.edited));
        cmd.Parameters.AddWithValue("@link", RantObj.link);
        cmd.Parameters.AddWithValue("@tags", RantObj.tags);

        try
        {
          conn.Open();
          cmd.ExecuteNonQuery();
          conn.Close();
          return ("Success");
        }
        catch (Exception ex)
        {
          return (ex.Message.ToString());
        }
      }
    }

    // AddRant
    public string AddTag(Tag TagObj)
    {
      using (SqlConnection conn = new SqlConnection(ConnectionString))
      {
        SqlCommand cmd = new SqlCommand("spAddTag", conn);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@tags_value", TagObj.tags_value);

        try
        {
          conn.Open();
          cmd.ExecuteNonQuery();
          conn.Close();
          return ("Success");
        }
        catch (Exception ex)
        {
          return (ex.Message.ToString());
        }
      }
    }

    // AddRantTags
    public string AddRantTags(RantTags RantTagsObj)
    {
      using (SqlConnection conn = new SqlConnection(ConnectionString))
      {
        SqlCommand cmd = new SqlCommand("spAddRantTags", conn);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@rant_id", RantTagsObj.rant_id);
        cmd.Parameters.AddWithValue("@tags_value", RantTagsObj.tags_value);

        try
        {
          conn.Open();
          cmd.ExecuteNonQuery();
          conn.Close();
          return ("Success");
        }
        catch (Exception ex)
        {
          return (ex.Message.ToString());
        }
      }
    }

    // AddComments
    public string AddComment(Comment CommentObj)
    {
      using (SqlConnection conn = new SqlConnection(ConnectionString))
      {
        SqlCommand cmd = new SqlCommand("spAddComments", conn);
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.AddWithValue("@rant_id", Convert.ToInt32(CommentObj.rant_id));
        cmd.Parameters.AddWithValue("@comment_id", Convert.ToInt32(CommentObj.comment_id));
        cmd.Parameters.AddWithValue("@body", CommentObj.body);
        cmd.Parameters.AddWithValue("@score", Convert.ToInt32(CommentObj.score));
        cmd.Parameters.AddWithValue("@user_id", Convert.ToInt32(CommentObj.user_id));
        cmd.Parameters.AddWithValue("@created_time", Convert.ToDateTime(CommentObj.created_time));
        try
        {
          conn.Open();
          cmd.ExecuteNonQuery();
          conn.Close();
          return ("Success");
        }
        catch (Exception ex)
        {
          return (ex.Message.ToString());
        }
      }
    }

    // AddDate
    public string AddDate(DateModel DateObj)
    {
      using (SqlConnection conn = new SqlConnection(ConnectionString))
      {
        SqlCommand cmd = new SqlCommand("spAddDate", conn);
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.AddWithValue("@date_short", DateObj.date_short);
        cmd.Parameters.AddWithValue("@date_medium", DateObj.date_medium);
        cmd.Parameters.AddWithValue("@date_full", DateObj.date_full);
        cmd.Parameters.AddWithValue("@day", Convert.ToInt32(DateObj.day));
        cmd.Parameters.AddWithValue("@day_full", DateObj.day_full);
        cmd.Parameters.AddWithValue("@month", Convert.ToInt32(DateObj.month));
        cmd.Parameters.AddWithValue("@month_full", DateObj.month_full);
        cmd.Parameters.AddWithValue("@year", Convert.ToInt32(DateObj.year));
        try
        {
          conn.Open();
          cmd.ExecuteNonQuery();
          conn.Close();
          return ("Success");
        }
        catch (Exception ex)
        {
          return (ex.Message.ToString());
        }
      }
    }

    // AddTime
    public string AddTime(TimeModel TimeObj)
    {
      using (SqlConnection conn = new SqlConnection(ConnectionString))
      {
        SqlCommand cmd = new SqlCommand("spAddTime", conn);
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.AddWithValue("@time_value", TimeObj.time_value);
        cmd.Parameters.AddWithValue("@hours_24", TimeObj.hours_24);
        cmd.Parameters.AddWithValue("@hours_12", TimeObj.hours_12);
        cmd.Parameters.AddWithValue("@minutes", TimeObj.minutes);
        cmd.Parameters.AddWithValue("@am_pm", TimeObj.am_pm);
        try
        {
          conn.Open();
          cmd.ExecuteNonQuery();
          conn.Close();
          return ("Success");
        }
        catch (Exception ex)
        {
          return (ex.Message.ToString());
        }
      }
    }
  }
}