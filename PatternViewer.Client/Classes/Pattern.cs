using System.Data.SqlClient;
using System.Data;

namespace PatternViewer.Client.Classes
{
  public class Pattern
  {
    readonly SqlConnection connection = new("Data Source=DESKTOP-HQKTKN8;Initial Catalog=PatternViewer;Integrated Security=True;");
    /// <summary>
    /// create a data table of pattern names 
    /// </summary>
    /// <returns>Pattern names</returns>
    public DataTable TryGetPatternNames()
    {
      DataTable dt = new DataTable();
      using (connection)
      {
        string query = "SELECT PatternName FROM Pattern";
        using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
        {
          adapter.Fill(dt);
        }
      }
      return dt;
    }

    /// <summary>
    /// Create a List of pattern names from the data table
    /// </summary>
    /// <param name="dt">The data table</param>
    /// <returns>A list of pattern names</returns>
    public List<string> PatternNames(DataTable dt)
    {
      List<string> patternNames = new List<string>();
      foreach (DataRow dr in dt.Rows)
      {
        string patternName = dr["PatternName"].ToString();
        patternNames.Add(patternName);
      }
      return patternNames;
    }

  }
}
