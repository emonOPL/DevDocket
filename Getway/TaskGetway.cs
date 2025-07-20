using System.Data.SqlClient;
using DevDocket.Models;
using Task = DevDocket.Models.Task;

namespace DevDocket.Getway
{
    public class TaskGetway
    {
        //public void ConnectDb() {
        //    SqlConnection connection = new SqlConnection("Server=OPL\\SQLEXPRESS;Database=DevDocket;Integrated Security=true;TrustServerCertificate=true;");
        //    connection.Open();
        //    connection.Close();
        //}

        public int AddTask(Task task) {
            SqlConnection connection = new SqlConnection("Server=OPL\\SQLEXPRESS;Database=DevDocket;Integrated Security=true;TrustServerCertificate=true;");
            connection.Open();
            string query = "INSERT INTO dbo.task_tb(title, details, techTag, priority, deadline, status) VALUES('"+ task.Title +"', '"+ task.Details + "', '"+ task.TechTag + "', '"+ task.Priority + "', '"+ task.Deadline + "', '"+ task.Status +"')";
            SqlCommand cmd = new SqlCommand(query, connection);
            int rowCount = cmd.ExecuteNonQuery();
            connection.Close();
            return rowCount;
        }

        public int UpdateTask(Task task)
        {
            SqlConnection connection = new SqlConnection("Server=OPL\\SQLEXPRESS;Database=DevDocket;Integrated Security=true;TrustServerCertificate=true;");
            connection.Open();
            string query = "UPDATE dbo.task_tb SET title = '"+ task.Title +"', details = '"+ task.Details +"', techTag = '"+ task.TechTag +"', priority = '"+ task.Priority +"', deadline = '"+ task.Deadline +"', status = '"+ task.Status +"' WHERE id = '"+ task.Id +"'";
            SqlCommand cmd = new SqlCommand(query, connection);
            int rowCount = cmd.ExecuteNonQuery();
            connection.Close();
            return rowCount;
        }

        public List<Task> GetTask() { 
            List<Task> tasks = new List<Task>();

            SqlConnection connection = new SqlConnection("Server=OPL\\SQLEXPRESS; Database=DevDocket; Integrated Security=true; TrustServerCertificate=true;");
            connection.Open();
            string query = "SELECT * FROM dbo.task_tb";
            SqlCommand cmd = new SqlCommand(query,connection);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read()) { 
                Task aTask = new Task();
                aTask.Id = Convert.ToInt32(reader["id"]); 
                aTask.Title = reader["title"].ToString();
                aTask.Details = reader["details"].ToString();
                aTask.TechTag = reader["techTag"].ToString();
                aTask.Priority = Convert.ToInt32(reader["priority"]);
                aTask.Deadline = Convert.ToDateTime(reader["deadline"]);
                aTask.Status = Convert.ToInt32(reader["status"]);
                tasks.Add(aTask);
            }
            connection.Close();

            return tasks;
        }

        public Task GetTask(int id)
        {
            Task aTask = new Task();
            SqlConnection connection = new SqlConnection("Server=OPL\\SQLEXPRESS; Database=DevDocket; Integrated Security=true; TrustServerCertificate=true;");
            connection.Open();
            string query = "SELECT * FROM dbo.task_tb WHERE id = '"+ id +"'";
            SqlCommand cmd = new SqlCommand(query, connection);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                aTask.Id = Convert.ToInt32(reader["id"]);
                aTask.Title = reader["title"].ToString();
                aTask.Details = reader["details"].ToString();
                aTask.TechTag = reader["techTag"].ToString();
                aTask.Priority = Convert.ToInt32(reader["priority"]);
                aTask.Deadline = Convert.ToDateTime(reader["deadline"]);
                aTask.Status = Convert.ToInt32(reader["status"]);
            }
            connection.Close();

            return aTask;
        }

        public int DeleteTask(int id) {
            SqlConnection connection = new SqlConnection("Server=OPL\\SQLEXPRESS; Database=DevDocket; Integrated Security=true; TrustServerCertificate=true;");
            connection.Open();
            string query = "DELETE FROM dbo.task_tb WHERE id = '"+ id +"'";
            SqlCommand cmd = new SqlCommand(query, connection);
            int rowCount = cmd.ExecuteNonQuery();
            connection.Close();

            return rowCount;
        }
    }
}
