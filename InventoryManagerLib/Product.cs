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

public class Product : DBConnection
{
	private string Product_Name { get; set; }
	private string Product_Code { get; set; }
	private bool Discontine { get; set; }
	private string Category { get; set; }
	private int Product_Id { get; set; }
	private Double List_Price { get; set; }
	private Double Unit_Cost { get; set; }



	public override string ToString()
	{
		throw new System.NotImplementedException();
	}

	public Product(string productName, string productCode, string category, double listPrice, double unitCost)
	{
        this.Product_Name = productName;
        this.Product_Code = productCode;
        this.Category = category;
        this.List_Price = listPrice;
        this.Unit_Cost = unitCost;
        this.Discontine = false;
        this.Product_Id = -1;
	}


    public void Save()
    {
        using (SqlConnection conn = new SqlConnection())
        {
            conn.ConnectionString = DBConnection.CONNECTION_STRING;
            conn.Open();

            string sql;

            if (Product_Id == -1)
            {
                sql = "INSERT INTO Product(Product_Code, Product_Name, Unit_Cost, List_Price, Discontinue, Category) VALUES(@Product_Code, @Product_Name, @Unit_Cost, @List_Price, @Discontinue, @Category)"
                    + "SELECT CAST (scope_identity() as int)";
            }
            else
            {
                sql = "UPDATE Product set "
                    + "Product_code = @Product_Code, Product_Name = @Product_Name, Unit_Cost = @Unit_Cost, List_Price = @List_Price, Discontinue = @Discontinue, Category = @Category"
                    + "WHERE Product_Id = @Product_Id";
            }

            SqlCommand command = new SqlCommand(sql, conn);
            command.Parameters.AddWithValue("Product_Code", Product_Code);
            command.Parameters.AddWithValue("Product_Name", Product_Name);
            command.Parameters.AddWithValue("Unit_Cost", Unit_Cost);
            command.Parameters.AddWithValue("List_Price", List_Price);
            //command.Parameters.AddWithValue("Discontinue", Discontinue);
            command.Parameters.AddWithValue("Category", Category);

            if(Product_Id == -1)
            {
                Product_Id = (int)command.ExecuteScalar();
            }
            else
            {
                command.Parameters.AddWithValue("Product_Id", Product_Id);
                command.ExecuteNonQuery();
            }
        }
    }


    public static Product Get(int Product_Id)
    {
        using (SqlConnection conn = new SqlConnection())
        {
            conn.ConnectionString = DBConnection.CONNECTION_STRING;
            conn.Open();

            string sql = "SELECT Product_Id, Product_Code, Product_Name, Unit_Cost, List_Price, Discontinue, Category"
                       + "WHERE Product_Id = @Product_Id";

            SqlCommand command = new SqlCommand(sql, conn);
            command.Parameters.AddWithValue("Product_Id", Product_Id);

            using (SqlDataReader read = command.ExecuteReader())
            {
                if (read.HasRows)
                {
                    read.Read();
                    Product product = new Product(
                        read.GetString(2),
                        read.GetString(1),
                        read.GetString(6),
                        read.GetDouble(4),
                        read.GetDouble(3)
                        );
                    return product;
                }
                else
                {
                    return null;
                }
            }
        }
    }

}

