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

public class PurchaseOrder : DBConnection
{
	private int      PurchaseOrders_Id   { get; set; }
    private DateTime Order_Date          { get; set; }
	private string   Created_By          { get; set; }
	private DateTime Created_Date        { get; set; }
	private double   Shipping_Fee        { get; set; }
	private double   Tax                 { get; set; }
	private DateTime Payment_Date        { get; set; }
	private double   Payment_Amount      { get; set; }
    private double   Order_Subtotal      { get; set; }
	private double   Order_Total         { get; set; }


    public PurchaseOrder(DateTime Order_Date, string Created_By, DateTime Created_Date,double Shipping_Fee, double Tax, DateTime Payment_Date,double Payment_Amount, double Order_Subtotal, double Order_Total)
    {
        this.PurchaseOrders_Id = -1;
        this.Order_Date     = Order_Date;
        this.Created_By     = Created_By;
        this.Created_Date   = Created_Date;
        this.Shipping_Fee   = Shipping_Fee;
        this.Tax            = Tax;
        this.Payment_Date   = Payment_Date;
        this.Payment_Amount = Payment_Amount;
        this.Order_Subtotal = Order_Subtotal;
        this.Order_Total    = Order_Total;
    }

    private PurchaseOrder(int PurchaseOrders_Id, DateTime Order_Date, string Created_By, DateTime Created_Date, double Shipping_Fee, double Tax, DateTime Payment_Date, double Payment_Amount, double Order_Subtotal, double Order_Total)
    {
        this.PurchaseOrders_Id = PurchaseOrders_Id;
        this.Order_Date = Order_Date;
        this.Created_By = Created_By;
        this.Created_Date = Created_Date;
        this.Shipping_Fee = Shipping_Fee;
        this.Tax = Tax;
        this.Payment_Date = Payment_Date;
        this.Payment_Amount = Payment_Amount;
        this.Order_Subtotal = Order_Subtotal;
        this.Order_Total = Order_Total;
    }



    public void Save()
    {
        using (SqlConnection conn = new SqlConnection())
        {
            conn.ConnectionString = DBConnection.CONNECTION_STRING;
            conn.Open();

            string sql;

            if (PurchaseOrders_Id == -1)
            {
                sql = "INSERT INTO PurchaseOrders(Order_Date, Created_By, Created_Date, Shipping_Fee, Tax, Payment_Date, Payment_Amount, Order_Subtotal, Order_Total) "
                    + "Values(@Order_Date, @Created_By, @Created_Date, @Shipping_Fee, @Tax, @Payment_Date, @Payment_Amount, @Order_Subtotal, @Order_Total) "
                    + "SELECT CAST (scope_identity() as int)";
            }
            else
            {
                sql = "UPDATE PurchaseOrders SET "
                    + "Order_Date = @Order_Date, Created_By = @Created_By, Created_Date = @Created_Date, Shipping_Fee = @Shipping_Fee, Tax = @Tax, Payment_Date = @Payment_Date, Payment_Amount = @Payment_Amount, Order_Subtotal = @Order_Subtotal, Order_Total = @Order_Total "
                    + "WHERE PurchaseOrder_Id = @PurchaseOrder_Id ";
            }

            SqlCommand command = new SqlCommand(sql, conn);

            command.Parameters.AddWithValue("Order_Date", Order_Date);
            command.Parameters.AddWithValue("Created_By", Created_By);
            command.Parameters.AddWithValue("Created_Date", Created_Date);
            command.Parameters.AddWithValue("Shipping_Fee", Shipping_Fee);
            command.Parameters.AddWithValue("Tax", Tax);
            command.Parameters.AddWithValue("Payment_Date", Payment_Date);
            command.Parameters.AddWithValue("Payment_Amount", Payment_Amount);
            command.Parameters.AddWithValue("Order_Subtotal", Order_Subtotal);
            command.Parameters.AddWithValue("Order_Total", Order_Total);

            if (PurchaseOrders_Id == -1)
            {
                PurchaseOrders_Id = (int)command.ExecuteScalar();
            }
            else
            {
                command.Parameters.AddWithValue("PurchaseOrders_Id", PurchaseOrders_Id);
                command.ExecuteNonQuery();
            }
        }
    }

    public PurchaseOrder Get(int Purchase)
    {
        using (SqlConnection conn = new SqlConnection())
        {
            conn.ConnectionString = DBConnection.CONNECTION_STRING;
            conn.Open();

            string sql = "SELECT PurchaseOrders_Id, Order_Date, Created_By, Created_Date, Shipping_Fee, Tax, Payment_Date, Payment_Amount, Order_Subtotal, Order_Total "
                       + "FROM PurchaseOrders "
                       + "WHERE PurchaseOrders_Id = @PurchaseOrders_Id";

            SqlCommand command = new SqlCommand(sql, conn);
            command.Parameters.AddWithValue("PurchaseOrders_Id", PurchaseOrders_Id);

            using (SqlDataReader reader = command.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    reader.Read();

                    PurchaseOrder purchaseOrder = new PurchaseOrder(reader.GetInt32(0),
                                                                    reader.GetDateTime(1),
                                                                    reader.GetString(2),
                                                                    reader.GetDateTime(3),
                                                                    reader.GetDouble(4),
                                                                    reader.GetDouble(5),
                                                                    reader.GetDateTime(6),
                                                                    reader.GetDouble(7),
                                                                    reader.GetDouble(8),
                                                                    reader.GetDouble(9));
                    return purchaseOrder;
                }
                else
                {
                    return null;
                }
            }
        }
    }

    public List<PurchaseOrder> GetAll()
    {
        using (SqlConnection conn = new SqlConnection())
        {
            conn.ConnectionString = DBConnection.CONNECTION_STRING;
            conn.Open();

            string sql = "SELECT PurchaseOrders_Id, Order_Date, Created_By, Created_Date, Shipping_Fee, Tax, Payment_Date, Payment_Amount, Order_Subtotal, Order_Total "
                       + "FROM PurchaseOrders ";

            SqlCommand command = new SqlCommand(sql, conn);
            using (SqlDataReader reader = command.ExecuteReader())
            {
                List<PurchaseOrder> PurchaseOrderList = new List<PurchaseOrder>();

                while (reader.Read())
                {
                    PurchaseOrder purchaseOrder = new PurchaseOrder(reader.GetInt32(0),
                                                                    reader.GetDateTime(1),
                                                                    reader.GetString(2),
                                                                    reader.GetDateTime(3),
                                                                    reader.GetDouble(4),
                                                                    reader.GetDouble(5),
                                                                    reader.GetDateTime(6),
                                                                    reader.GetDouble(7),
                                                                    reader.GetDouble(8),
                                                                    reader.GetDouble(9));

                    PurchaseOrderList.Add(purchaseOrder);
                }

                return PurchaseOrderList;
            }
        }
    }

    public override string ToString()
    {
		throw new System.NotImplementedException();
	}

}

