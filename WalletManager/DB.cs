using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;

namespace WalletManager
{
    class DB
    {
        private static DB instance;

        public static DB Instance
        {
            get
            {
                if (instance == null) instance = new DB();

                return instance;
            }
        }

        string strConnect;
        SqlConnection dbConnection;

        public DB()
        {
            /* For creating DB dynamically      NOT WORKING!!!
            strConnect = $@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}\WalletManager\WalletManager.mdf;Integrated Security=True;Connect Timeout=30";
            dbConnection = new SqlConnection(strConnect);
            dbConnection.Open();
            */

            strConnect = ConfigurationManager.ConnectionStrings["sql"].ToString();
            dbConnection = new SqlConnection(strConnect);
            dbConnection.Open();
        }

        ~DB()
        {
            try
            {
                dbConnection.Close();
            }
            catch (Exception e)
            {
                Console.Write(e.Message); 
            }
        }

        public void CreateFromFile(string dbDirectory, string createFilePath)   // NOT WORKING!!!
        {
            // DB name
            string dbName = Path.GetFileNameWithoutExtension(dbDirectory);

            // Create DB
            SqlConnection serverConnection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;Integrated Security=True;Connect Timeout=30");
            serverConnection.Open();
            string sql = $@"CREATE DATABASE {dbName} ON PRIMARY (NAME = {dbName}, FILENAME='{dbDirectory}')";
            SqlCommand command = new SqlCommand(sql, serverConnection);
            command.ExecuteNonQuery();

            // Create Tables
            serverConnection = new SqlConnection($@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={dbDirectory};Integrated Security=True;Connect Timeout=30");
            serverConnection.Open();
            sql = File.ReadAllText(createFilePath);
            command = new SqlCommand(sql, serverConnection);
            command.ExecuteNonQuery();
        }
        
        public SqlTransaction BegintTransaction()
        {
            return dbConnection.BeginTransaction();
        }

        public void ExecSQL(string sql)
        {
            SqlCommand command = new SqlCommand(sql, dbConnection);
            command.ExecuteNonQuery();
            command.Dispose();
            command = null;
        }

        public void ExecSQL(string sql, List<SqlParameter> parameters)
        {
            SqlCommand command = new SqlCommand(sql, dbConnection);
            command.Parameters.AddRange(parameters.ToArray());
            command.ExecuteNonQuery();
            command.Dispose();
            command = null;
        }

        public void ExecSQL(string sql, List<SqlParameter> parameters, SqlTransaction transaction)
        {
            SqlCommand command = new SqlCommand(sql, dbConnection);
            command.Parameters.AddRange(parameters.ToArray());
            command.Transaction = transaction;
            command.ExecuteNonQuery();
            command.Dispose();
            command = null;
        }

        public DataTable ExecQuery(string query)
        {
            SqlCommand command = new SqlCommand(query, dbConnection);
            DataTable registry = new DataTable();
            SqlDataReader data =  command.ExecuteReader();
            registry.Load(data);
            data = null;
            command.Dispose();
            return registry;
        }

        public DataTable ExecQuery(string query, List<SqlParameter> parameters)
        {
            SqlCommand command = new SqlCommand(query, dbConnection);
            command.Parameters.AddRange(parameters.ToArray());
            DataTable registry = new DataTable();
            SqlDataReader data = command.ExecuteReader();
            registry.Load(data);
            data = null;
            command.Dispose();
            return registry;
        }
    }
}
