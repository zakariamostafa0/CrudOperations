using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudOperations
{
   
    public class DBManager
    {
        private string connectionString;
        private SqlConnection sqlConnection;

        public DBManager(string server, string database, string username, string password)
        {
            connectionString = $"Server={server};Database={database};User Id={username};Password={password};";
            sqlConnection = new SqlConnection(connectionString);
        }

        private void BindParameters (SqlCommand command, List<SqlParameter> parameters)
        {
            if(parameters != null)
            {
                foreach (SqlParameter parameter in parameters)
                {
                    command.Parameters.Add(parameter);
                }
            }
        }

        public DataTable SelectFromDB(string sql, List<SqlParameter> parameters)
        {
            DataTable dataTable = new DataTable();
            try
            {
                SqlCommand command = new SqlCommand(sql, sqlConnection);
                try
                {
                    BindParameters(command, parameters);
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    adapter.Fill(dataTable);
                }
                finally { command.Dispose(); }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error :{ex.Message}");
            }
            return dataTable;
        }

        private int ExecuteNonQuery(string sql, List<SqlParameter> parameters)
        {
            int rowsAffected = 0;
            try
            {
                sqlConnection.Open();
                SqlCommand command = new SqlCommand(sql, sqlConnection);
                try
                {
                    BindParameters(command, parameters);
                    rowsAffected = command.ExecuteNonQuery();
                }
                finally { command.Dispose(); }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error :{ex.Message}");
            }
            finally {  sqlConnection.Close(); }
            return rowsAffected;
        }

        public int InsertToDB(string sql, List<SqlParameter> parameters)
        {
            return ExecuteNonQuery(sql, parameters);
        }
        public int UpdateToDB(string sql, List<SqlParameter> parameters)
        {
            return ExecuteNonQuery(sql, parameters);
        }
        public int DeleteToDB(string sql, List<SqlParameter> parameters)
        {
            return ExecuteNonQuery(sql, parameters);
        }
    }
}
