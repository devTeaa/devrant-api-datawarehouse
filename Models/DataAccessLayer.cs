using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

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

    // AddUser  
    public void AddUser(User UserObj)
    {
      using (SqlConnection conn = new SqlConnection(ConnectionString))
      {
        SqlCommand cmd = new SqlCommand("spInsertTest", conn);
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.AddWithValue("@Text", UserObj.user_id);

        conn.Open();
        cmd.ExecuteNonQuery();
        conn.Close();
      }
    }
  }
}