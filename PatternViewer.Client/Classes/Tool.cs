using System.Data.SqlClient;
using System.Data;

namespace PatternViewer.Client.Classes
{
  public class Tool
  {
    readonly SqlConnection connection = new("Data Source=DESKTOP-HQKTKN8;Initial Catalog=PatternViewer;Integrated Security=True;");
    public string? SelectedOption;

    /// <summary>
    /// create a data table of tool sizes 
    /// </summary>
    /// <returns>tool sizes</returns>
    public DataTable TryGetToolSize()
    {
      DataTable sizeDt = new();

      using (connection)
      {
        string query = SelectedOption switch
        {
          "UK" => "SELECT UKSize FROM ToolSize",
          "US" => "SELECT USSize FROM ToolSize",
          _ => "SELECT Metric FROM ToolSize"
        };
        using SqlDataAdapter adapter = new(query, connection);
        adapter.Fill(sizeDt);
      }
      return sizeDt;
    }

    /// <summary>
    /// Create a List of pattern names from the data table
    /// </summary>
    /// <param name="dt">The data table</param>
    /// <returns>A list of pattern names</returns>
    public List<string> ToolSizes(DataTable sizeDt)
    {
      List<string> toolSizes = [];
      foreach (DataRow dr in sizeDt.Rows)
      {
        string toolSize = string.Empty;
        switch(SelectedOption)
        {
          case "Metric":
            toolSize = dr["Metric"].ToString();
            break;
          case "US":
            toolSize = dr["USSize"].ToString();
            break;
          case "UK":
            toolSize = dr["UKSize"].ToString();
            break;
          default:
            toolSize = dr["Metric"].ToString();
            break;
        }
        toolSizes.Add(toolSize);
      }
      return toolSizes;
    }
  }
}
