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
    string ConnectionString = "Server=tcp:azure-devrantapi.database.windows.net,1433;Initial Catalog=devrantapi;Persist Security Info=False;User ID=thisadmin;Password=Password123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

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

        cmd.Parameters.AddWithValue("@rant_id", Convert.ToInt32(RantObj.user_id));
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

  }
}