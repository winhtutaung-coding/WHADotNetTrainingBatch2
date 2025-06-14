using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using System.Data;

namespace WHADotNetTrainingBatch2.ConsoleApp
{
    public class AdoDotNetExample
    {
        SqlConnectionStringBuilder _sqlConnectionStringBuilder = new SqlConnectionStringBuilder()
        {
            DataSource = ".",
            InitialCatalog = "DotNet TrainingBatch2",
            UserID = "sa",
            Password = "sasa@123",
            TrustServerCertificate = true
        };
        //CREATE
        public void Create()
        {
            Console.Write("Enter Title: ");
            String title = Console.ReadLine()!;

            Console.Write("Enter Author: ");
            String author = Console.ReadLine()!;

            Console.Write("Enter Content: ");
            String content = Console.ReadLine()!;

            string query = $@"INSERT INTO [dbo].[Tbl_Blog]
           ([BlogTitle]
           ,[BlogAuthor]
           ,[BlogContent])
     VALUES
           (@Title
           ,@Author
           ,@Content)";

            SqlConnection connection = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
            connection.Open();

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("Title", title);
            cmd.Parameters.AddWithValue("Author", author);
            cmd.Parameters.AddWithValue("Content", content);
            int result = cmd.ExecuteNonQuery();

            connection.Close();

            Console.WriteLine(result > 0 ? "Insert Success!" : "Insert Failed!");

        }
        
        //READ
        public void Read()
        {

            SqlConnection connection = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
            connection.Open();

            string query = "select * from Tbl_Blog";
            SqlCommand cmd = new SqlCommand(query, connection);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            connection.Close();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow row = dt.Rows[i];
                Console.WriteLine(i);
                Console.WriteLine(" BlogId => " + row["BlogId"]);
                Console.WriteLine(" BlogTitle => " + row["BlogTitle"]);
                Console.WriteLine(" BlogAuthor => " + row["BlogAuthor"]);
                Console.WriteLine(" BlogContent => " + row["BlogContent"]);

            }
        }

        //UPDATE
        public void Update()
        {
            Console.Write("Enter Blog ID to update: ");
            String blogId = Console.ReadLine()!;

            Console.Write("Enter New Title: ");
            String blogTitle = Console.ReadLine()!;


            Console.Write("Enter New Author:  ");
            String blogAuthor = Console.ReadLine()!;

            Console.Write("Enter New Content:  ");
            String blogContent = Console.ReadLine()!;

            SqlConnection connection = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
            connection.Open();

            string query = @"UPDATE Tbl_Blog SET BlogTitle = @BlogTitle, BlogAuthor = @BlogAuthor, BlogContent = @BlogContent WHERE BlogId = @BlogId";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("BlogId", blogId);
            cmd.Parameters.AddWithValue("BlogTitle", blogTitle);
            cmd.Parameters.AddWithValue("BlogAuthor", blogAuthor);
            cmd.Parameters.AddWithValue("BlogContent", blogContent);
            int result = cmd.ExecuteNonQuery();
            Console.WriteLine(result > 0 ? "Update Success!" : "Update Failed!");

            connection.Close();

            //for (int i = 0; i < dt.Rows.Count; i++)
            //{
            //    DataRow row = dt.Rows[i];
            //    Console.WriteLine(i);
            //    Console.WriteLine(" BlogId => " + row["BlogId"]);
            //    Console.WriteLine(" BlogTitle => " + row["BlogTitle"]);
            //    Console.WriteLine(" BlogAuthor => " + row["BlogAuthor"]);
            //    Console.WriteLine(" BlogContent => " + row["BlogContent"]);

            //}
        }

        //DELETE
        public void Delete()
        {
            Console.Write("Enter Blog ID to delete: ");
            String blogId = Console.ReadLine()!;
            SqlConnection connection = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
            connection.Open();

            string query = @"DELETE FROM Tbl_Blog WHERE BlogId = @BlogId";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("BlogId", blogId);        
            int result = cmd.ExecuteNonQuery();
            Console.WriteLine(result > 0 ? "Delete Success!" : "Delete Failed!");

            connection.Close();
        }
                     
    }

}
