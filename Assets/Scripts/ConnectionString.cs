using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Data;
using System;
using UnityEngine.UI;
using MySql.Data;
using MySql.Data.MySqlClient;

public class ConnectionString : MonoBehaviour
{
    public static MySqlConnection GetDBConnection(string datasource, string username, string database, int port, string password)
    {
        String connString = "Data Source=" + datasource + ";user=" + username + ";database=" + database + ";port=" + port + ";password=" + password;

        MySqlConnection conn = new MySqlConnection(connString);

        return conn;
    }
}
