// See https://aka.ms/new-console-template for more information
using Microsoft.Data.SqlClient;
using System.Data;

Console.WriteLine("Hello, World!");

SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder();
sqlConnectionStringBuilder.DataSource = ".";
sqlConnectionStringBuilder.InitialCatalog = "DotNet TrainingBatch2";
sqlConnectionStringBuilder.UserID = "sa";
sqlConnectionStringBuilder.Password = "sasa@123";
sqlConnectionStringBuilder.TrustServerCertificate = true;


SqlConnection connection = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);
Console.WriteLine("Connection Opening...");
connection.Open();
Console.WriteLine("Connection Open!");

string query = "select * from Tbl_Student";
SqlCommand cmd = new SqlCommand(query, connection);
SqlDataAdapter adapter = new SqlDataAdapter(cmd);
DataTable dt = new DataTable();
adapter.Fill(dt);

Console.WriteLine("Connection Closing...");
connection.Close();
Console.WriteLine("Connection Close!");

for (int i = 0; i < dt.Rows.Count; i++)
{
    DataRow row = dt.Rows[i];
    Console.WriteLine(i);
    Console.WriteLine(row["StudentId"]);
    Console.WriteLine(row["StudentNo"]);

}


Console.ReadKey();