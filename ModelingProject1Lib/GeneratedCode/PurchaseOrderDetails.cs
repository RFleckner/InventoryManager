﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool
//     Changes to this file will be lost if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class PurchaseOrderDetails : DBConnection
{
	public virtual int PurchaseOrderDetails_Id
	{
		get;
		set;
	}

	public virtual int Purchase_Order_Number
	{
		get;
		set;
	}

	public virtual string Product
	{
		get;
		set;
	}

	public virtual int Quantity
	{
		get;
		set;
	}

	public virtual double Unit_Price
	{
		get;
		set;
	}

	public virtual double Extended_Price
	{
		get;
		set;
	}

	public virtual void ToString()
	{
		throw new System.NotImplementedException();
	}

	public PurchaseOrderDetails()
	{
	}

	private PurchaseOrderDetails()
	{
	}

	public virtual void Save()
	{
		throw new System.NotImplementedException();
	}

	public virtual void Get(int PurchaseOrderDetails_Id)
	{
		throw new System.NotImplementedException();
	}

	public virtual void GetAll()
	{
		throw new System.NotImplementedException();
	}

	public virtual void GetAllAt(int Purchase_Order_Number)
	{
		throw new System.NotImplementedException();
	}

}

