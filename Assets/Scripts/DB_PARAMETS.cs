using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Data;
using System;
using UnityEngine.UI;
using MySql.Data;
using MySql.Data.MySqlClient;

public class DB_PARAMETS : MonoBehaviour
{
    public static MySqlConnection GetDBConnection()
    {
        string datasource = @"127.0.0.1";
        string database = "players";
        string username = "root";
        int port = 3306;
        string password = "root";

        return ConnectionString.GetDBConnection(datasource, username, database, port, password);
    }
}
