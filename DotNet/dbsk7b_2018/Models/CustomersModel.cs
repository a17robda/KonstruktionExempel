﻿using System;
using MySql.Data.MySqlClient;
using System.Data;

namespace dbsk7_2018.Models
{
    public class CustomersModel
    {
        private string connectionString = "Server=localhost;Database=a00leifo;User ID=myusername;Password=mypassword;Pooling=false;SslMode=none;convert zero datetime=True;";

        public CustomersModel()
        {
        }

        public DataTable GetAllCustomers()
        {
            MySqlConnection dbcon = new MySqlConnection(connectionString);
            dbcon.Open();
            MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT * FROM CUSTOMER;", dbcon);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "result");
            DataTable customersTable = ds.Tables["result"];
            dbcon.Close();

            return customersTable;
        }

        public void InsertCustomer(string custno, string ssn, string name)
        {
            MySqlConnection dbcon = new MySqlConnection(connectionString);
            dbcon.Open();
            string deleteString = "INSERT INTO CUSTOMER(CUSTNO,SSN,NAME) VALUES(@CUSTNO,@SSN,@NAME);";
            MySqlCommand sqlCmd = new MySqlCommand(deleteString, dbcon);
            sqlCmd.Parameters.AddWithValue("@CUSTNO", custno);
            sqlCmd.Parameters.AddWithValue("@SSN", ssn);
            sqlCmd.Parameters.AddWithValue("@NAME", name);
            int rows = sqlCmd.ExecuteNonQuery();
            dbcon.Close();
        }

    }
}
