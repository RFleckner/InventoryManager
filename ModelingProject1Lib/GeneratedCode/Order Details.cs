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

public class Order Details : DBConnection
{
	public virtual int OrderDetails_Id
	{
		get;
		set;
	}

	public virtual int Order_Id
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

	public virtual Double Extended_Price
	{
		get;
		set;
	}

	public virtual string Status
	{
		get;
		set;
	}

	public virtual void ToString()
	{
		throw new System.NotImplementedException();
	}

	public virtual void OrderDetails()
	{
		throw new System.NotImplementedException();
	}

	private void OrderDetails()
	{
		throw new System.NotImplementedException();
	}

	public virtual void Save()
	{
		throw new System.NotImplementedException();
	}

	public virtual void Get(int OrderDetails_Id)
	{
		throw new System.NotImplementedException();
	}

	public virtual void GetAll()
	{
		throw new System.NotImplementedException();
	}

	public virtual void GetAllAt(int Order_Id)
	{
		throw new System.NotImplementedException();
	}

}

