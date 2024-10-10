﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace WorkingBD
{
    public class Connection
    {
        static readonly string strConnection = "server=127.0.0.1;port=3307;database=Airlines;uid=root;pwd=;";
        public static MySqlConnection OpenConnection()
        {
            MySqlConnection connection = new MySqlConnection(strConnection);
            connection.Open();
            return connection;
        }
        public static MySqlDataReader Query(string Sql, MySqlConnection connection)
        {
            MySqlCommand command = new MySqlCommand("SELECT * FROM `Airlines`.`tickets`;", connection);
            return command.ExecuteReader();
        }
        public static void CloseConnection(MySqlConnection connection)
        {
            connection.Close();
            MySqlConnection.ClearPool(connection);
        }
    }
}
