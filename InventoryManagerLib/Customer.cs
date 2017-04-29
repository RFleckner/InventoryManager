﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool
//     Changes to this file will be lost if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

public class Customer : DBConnection
{
    public int    Customer_Id    { get; private set; }
    public string Company        { get; private set; }
    public string Last_Name      { get; private set; }
    public string First_Name     { get; private set; }
    public string Job_Title      { get; private set; }
    public string Address        { get; private set; }
    public string City           { get; private set; }
    public string State_Province { get; private set; }
    public int    Zip            { get; private set; }
    public string Phone_Number   { get; private set; }


    public Customer(string Company, string Last_Name, string First_Name, string Job_Title, string Address, string City, string State_Province, int Zip, string Phone_Number)
    {
        this.Company        = Company;
        this.Last_Name      = Last_Name;
        this.First_Name     = First_Name;
        this.Job_Title      = Job_Title;
        this.Address        = Address;
        this.City           = City;
        this.State_Province = State_Province;
        this.Zip            = Zip;
        this.Phone_Number   = Phone_Number;
        Customer_Id = -1;
    }

    private Customer(int Customer_Id, string Company, string Last_Name, string First_Name, string Job_Title, string Address, string City, string State_Province, int Zip, string Phone_Number)
    {
        this.Company = Company;
        this.Last_Name      = Last_Name;
        this.First_Name     = First_Name;
        this.Job_Title      = Job_Title;
        this.Address        = Address;
        this.City           = City;
        this.State_Province = State_Province;
        this.Zip            = Zip;
        this.Phone_Number   = Phone_Number;
        this.Customer_Id    = Customer_Id;
    }


    public void Save()
    {
        using (SqlConnection conn = new SqlConnection())
        {
            conn.ConnectionString = DBConnection.CONNECTION_STRING;
            conn.Open();

            string sql;

            if(Customer_Id == -1)
            {
                sql = "INSERT INTO Customers(Company, Last_Name, First_Name, Job_Title, Address, City, State_Province, Zip, Phone_Number, Customer_Id) "
                    + "VALUES(@Company, @Last_Name, @First_Name, @Job_Title, @Address, @City, @State_Province, @Zip, @Phone_Number, @Customer_Id) "
                    + "SELECT CAST (scope_identity() as int)";
            }
            else
            {
                sql = "UPDATE Customers SET "
                    + "Company = @Company, Last_Name = @Last_Name, First_Name = @First_Name, Job_Title = @Job_Title, Address = @Address, City = @City, State_Province = @State_Province, Zip = @Zip, Phone_Number = @Phone_Number "
                    + "WHERE Customer_Id = @Customer_Id";
            }

            SqlCommand command = new SqlCommand(sql, conn);
            command.Parameters.AddWithValue("Company", Company);
            command.Parameters.AddWithValue("Last_Name", Last_Name);
            command.Parameters.AddWithValue("First_Name", First_Name);
            command.Parameters.AddWithValue("Job_Title", Job_Title);
            command.Parameters.AddWithValue("Address", Address);
            command.Parameters.AddWithValue("City", City);
            command.Parameters.AddWithValue("State_Province", State_Province);
            command.Parameters.AddWithValue("Zip", Zip);
            command.Parameters.AddWithValue("Phone_Number", Phone_Number);

            if(Customer_Id == -1)
            {
                Customer_Id = (int)command.ExecuteScalar();
            }
            else
            {
                command.Parameters.AddWithValue("Customer_Id", Customer_Id);
                command.ExecuteNonQuery();
            }
        }
    }


    public static Customer Get(int Customer_Id)
    {
        using (SqlConnection conn = new SqlConnection())
        {
            conn.ConnectionString = DBConnection.CONNECTION_STRING;
            conn.Open();

            string sql = "SELECT Company, Last_Name, First_Name, Job_Title, Address, City, State, Zip, Phone_Number "
                       + "FROM Customers "
                       + "WHERE Customer_Id = @Customer_Id";

            SqlCommand command = new SqlCommand(sql, conn);
            command.Parameters.AddWithValue("Customer_Id", Customer_Id);

            using (SqlDataReader reader = command.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    reader.Read();

                    Customer c = new Customer(reader.GetInt32(0),
                                              reader.GetString(1),
                                              reader.GetString(2),
                                              reader.GetString(3),
                                              reader.GetString(4),
                                              reader.GetString(6),
                                              reader.GetString(7),
                                              reader.GetString(8),
                                              reader.GetInt32(9),
                                              reader.GetString(5));

                    return c;
                }
                else
                {
                    return null;
                }
            }
        }
    }

    public static List<Customer> GetAll()
    {
        using (SqlConnection conn = new SqlConnection())
        {
            conn.ConnectionString = DBConnection.CONNECTION_STRING;
            conn.Open();

            string sql;

            sql = "SELECT Customer_Id, Company, Last_Name, First_Name, Job_Title, Address, City, State, Zip, Phone_Number "
                + "FROM Customers ";

            SqlCommand command = new SqlCommand(sql, conn);
            using (SqlDataReader reader = command.ExecuteReader())
            {
                List<Customer> cList = new List<Customer>();

                while (reader.Read())
                {
                    Customer c = new Customer(reader.GetInt32(0),
                                              reader.GetString(1),
                                              reader.GetString(2),
                                              reader.GetString(3),
                                              reader.GetString(4),
                                              reader.GetString(6),
                                              reader.GetString(7),
                                              reader.GetString(8),
                                              reader.GetInt32(9),
                                              reader.GetString(5));
                    cList.Add(c);
                }

                return cList;
            }
        }
    }

    public override string ToString()
	{
        return this.First_Name + " " + this.Last_Name + ", " + this.Company;
	}

	

}

