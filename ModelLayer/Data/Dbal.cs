using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Diagnostics;
using System.IO;
using System.Data;
using System.Linq;

namespace Model.Data
{
    public class Dbal
    {
        private MySqlConnection connection;

        //Constructor
        public Dbal(string database, string server = "localhost", string uid = "root", string password = "root")
        {
            Initialize(
                server,
                database,
                uid,
                password
                );
        }

        //Initialize values
        private void Initialize(string server, string database, string uid, string password)
        {
            string connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" +
            database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";

            connection = new MySqlConnection(connectionString);
        }

        //open connection to database
        private bool OpenConnection()
        {
            try
            {
                connection.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                //When handling errors, you can your application's response based 
                //on the error number.
                //The two most common error numbers when connecting are as follows:
                //0: Cannot connect to server.
                //1045: Invalid user name and/or password.
                switch (ex.Number)
                {
                    case 0:
                        Console.WriteLine("Cannot connect to server.  Contact administrator");
                        break;

                    case 1045:
                        Console.WriteLine("Invalid username/password, please try again");
                        break;
                }
                return false;
            }
        }

        //Close connection
        private bool CloseConnection()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        //Insert statement
        /// <summary>
        /// Result of example: INSERT INTO tableinfo (name, age) VALUES('John Smith', '33'),(Jean Luc, '43')
        /// </summary>
        /// <param name="table">Example: tableinfo (name, age)</param>
        /// <param name="values">Example: ('John Smith', '33'),(Jean Luc, '43')</param>
        public void Insert(string table, Dictionary<string, dynamic> values)
        {
            string query = "INSERT INTO " + table + " (";
            foreach (var val in values)
            {
                query += val.Key;
                if (values.Last().Key != val.Key) query += ",";
            }
            query += ") VALUES (";
            foreach (var val in values)
            {
                if (val.Value is string) query += "'" + val.Value + "'";
                else if (val.Value is DateTime) query += "'" + val.Value.ToString("yyyy-M-d") + "'";
                else if (val.Value is bool)
                {
                    if (val.Value) query += "1";
                    else query += "0";
                }
                else query += val.Value;
                if (values.Last().Key != val.Key) query += ",";
            }
            query += ")";

            //open connection
            if (this.OpenConnection())
            {
                //create command and assign the query and connection from the constructor
                MySqlCommand cmd = new MySqlCommand(query, connection);

                try
                {
                    //Execute command
                    cmd.ExecuteNonQuery();

                    //close connection
                    this.CloseConnection();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    throw;
                }
            }
        }

        //Update statement
        public void Update(string table, Dictionary<string, dynamic> values, string where)
        {
            string query = "UPDATE " + table + " SET ";
            foreach (var val in values)
            {
                query += val.Key + " = ";
                if (val.Value is string) query += "'" + val.Value + "'";
                else if (val.Value is DateTime) query += "'" + val.Value.ToString("yyyy-M-d") + "'";
                else if (val.Value is bool)
                {
                    if (val.Value) query += "1";
                    else query += "0";
                }
                else query += val.Value;
                if (values.Last().Key != val.Key) query += ",";
            }
            query += " WHERE " + where;

            //Open connection
            if (this.OpenConnection())
            {
                //create mysql command
                MySqlCommand cmd = new MySqlCommand();
                //Assign the query using CommandText
                cmd.CommandText = query;
                //Assign the connection using Connection
                cmd.Connection = connection;

                //Execute query
                cmd.ExecuteNonQuery();

                //close connection
                this.CloseConnection();
            }
        }

        //Delete statement
        public void Delete(string table, string where)
        {
            string query = "DELETE FROM " + table + " WHERE " + where;

            if (this.OpenConnection())
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();
                this.CloseConnection();
            }
        }

        public DataSet RQuery(string query)
        {
            System.Console.WriteLine(query);
            DataSet dataset = new DataSet();
            if (this.OpenConnection())
            {
                MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection);
                adapter.Fill(dataset);
                this.CloseConnection();
            }
            return dataset;
        }
        public DataTable SelectAll(string table)
        {
            return this.RQuery("select * from " + table).Tables[0];
        }
        public DataTable SelectByField(string table, string fieldTestCondition)
        {
            string query = "SELECT * FROM " + table + " where " + fieldTestCondition;
            DataSet dataset = RQuery(query);
            return dataset.Tables[0];
            // return this.RQuery("select * from " + table + " where " + fieldTestCondition).Tables[0];
        }
        public DataRow SelectById(string table, int id)
        {
            return this.RQuery("select * from " + table + " where id = " + id).Tables[0].Rows[0];
        }

        //Select statement
        public List<string>[] Select(string where)
        {
            string query = "SELECT * FROM tableinfo WHERE " + where;

            //Create a list to store the result
            List<string>[] list = new List<string>[2];
            list[0] = new List<string>();
            list[1] = new List<string>();

            System.Console.WriteLine(query);

            //Open connection
            if (this.OpenConnection())
            {
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, connection);
                //Create a data reader and Execute the command
                MySqlDataReader dataReader = cmd.ExecuteReader();

                //Read the data and store them in the list
                while (dataReader.Read())
                {
                    list[0].Add(dataReader["id"] + "");
                    list[1].Add(dataReader["nom"] + "");
                }

                //close Data Reader
                dataReader.Close();

                //close Connection
                this.CloseConnection();

                //return list to be displayed
                return list;
            }
            else
            {
                return list;
            }
        }

        //Count statement
        public int Count()
        {
            string query = "SELECT Count(*) FROM tableinfo";
            int Count = -1;

            //Open Connection
            if (this.OpenConnection() == true)
            {
                //Create Mysql Command
                MySqlCommand cmd = new MySqlCommand(query, connection);

                //ExecuteScalar will return one value
                Count = int.Parse(cmd.ExecuteScalar() + "");

                //close Connection
                this.CloseConnection();

                return Count;
            }
            else
            {
                return Count;
            }
        }
    }
}
