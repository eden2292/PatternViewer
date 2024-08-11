using System.Data.SqlClient;
using System.Data;

namespace PatternViewer.Client.Classes
{
  public class Tool
  {
    /// <summary>
    /// create a data table of tool sizes 
    /// </summary>
    /// <returns>tool sizes</returns>
    public DataTable TryGetToolSize()
    {
      DataTable sizeDt = new();

      using (SqlConnection connection =  new("Data Source=DESKTOP-HQKTKN8;Initial Catalog=PatternViewer;Integrated Security=True;"))
      {
        string query = "SELECT * FROM ToolSize";
        using SqlDataAdapter adapter = new(query, connection);
        adapter.Fill(sizeDt);
      }
      return sizeDt;
    }

    /// <summary>
    /// Create a List of Tool sizes from the data table
    /// </summary>
    /// <param name="dt">The data table</param>
    /// <returns>A list of tool sizes</returns>
    public List<string> ToolSizes(DataTable sizeDt, string selectedOption)
    {
      List<string> toolSizes = [];
      foreach (DataRow dr in sizeDt.Rows)
      {
#pragma warning disable CS8600
        string toolSize = selectedOption switch
        {
          "Metric" => dr["Metric"].ToString(),
          "US" => dr["USSize"].ToString(),
          "UK" => dr["UKSize"].ToString(),
          _ => dr["Metric"].ToString(),
        };
#pragma warning restore CS8600
        toolSizes.Add(toolSize);
      }
      return toolSizes;
    }

  }
}
