using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Data;
using System;
using UnityEngine.UI;
using MySql.Data;
using MySql.Data.MySqlClient;

public class DB : MonoBehaviour
{
    private string nick_name_player;
    [Header("Registration")]
    [SerializeField] private InputField name_user_reg;
    [SerializeField] private InputField login_user_reg;
    [SerializeField] private InputField password_user_reg;
    [SerializeField] private InputField password2_user_reg;
    public GameObject PasswordError;

    [Header("Authorization")]
    [SerializeField] private InputField login_user_auth;
    [SerializeField] private InputField password_user_auth;
    public GameObject EnterButton;
    public GameObject StartMenu;
    public GameObject autorizationMenu;
    public GameObject AuthorizationError;

    public void CheckRegistration()
    {
        if (password_user_reg.text == password2_user_reg.text)
        {
            PasswordError.SetActive(false);
            RegistrUser();
        }
        else
        {
            PasswordError.SetActive(true);
        }
    }

    public void RegistrUser()
    {
        MySqlCommand command = new MySqlCommand();
        MySqlConnection connection = DB_PARAMETS.GetDBConnection();

        try
        {
            string nick = name_user_reg.text;
            string log = login_user_reg.text;
            string pass = password_user_reg.text;

            command.Connection = connection;
            command.CommandText = "Insert into players.registration (nickname, login, password) values (@nick, @log, @pass)";

            command.Parameters.AddWithValue("@nick", nick);
            command.Parameters.AddWithValue("@log", log);
            command.Parameters.AddWithValue("@pass", pass);

            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }
        catch(Exception e)
        {
            Debug.Log("Error: " + e.Message);
        }
    }
    
    public void AuthUser()
    {
        MySqlCommand command = new MySqlCommand();
        MySqlConnection connection = DB_PARAMETS.GetDBConnection();


        try
        {
            string com = string.Format("select nickname from registration where login = '{0}' and password = '{1}'", login_user_auth.text, password_user_auth.text);
            command.Connection = connection;
            command.CommandText = com;
            connection.Open();
            if(command.ExecuteScalar() != null)
            {
                nick_name_player = Convert.ToString(command.ExecuteScalar());
                Debug.Log(nick_name_player);
                autorizationMenu.SetActive(false);
                StartMenu.SetActive(true);
                
            }
            else
            {
                AuthorizationError.SetActive(true);
            }
            connection.Close();
        }
        catch (Exception e)
        {
            Debug.Log("Error: " + e.Message);
        }
    }

}
