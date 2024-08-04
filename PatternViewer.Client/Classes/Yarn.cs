using System.Data.SqlClient;
using System.Data;

namespace PatternViewer.Client.Classes
{
  public class Yarn
  {
    readonly SqlConnection connection = new("Data Source=DESKTOP-HQKTKN8;Initial Catalog=PatternViewer;Integrated Security=True;");

    /// <summary>
    /// create a data table of Yarn weights 
    /// </summary>
    /// <returns>yarn weights</returns>
    public DataTable TryGetYarnWeights()
    {
      DataTable dt = new();
      using (connection)
      {
        string query = "SELECT Weight FROM Weight";
        using SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
        adapter.Fill(dt);
      }
      return dt;
    }

    /// <summary>
    /// Create a List of yarn weights from the data table
    /// </summary>
    /// <param name="dt">The data table</param>
    /// <returns>A list of yarn weights</returns>
    public List<string> YarnWeights(DataTable dt)
    {
      List<string> yarnWeight = [];
      foreach (DataRow dr in dt.Rows)
      {
        string weight = dr["Weight"].ToString();
        yarnWeight.Add(weight);
      }
      return yarnWeight;
    }
  }
}
