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

public class Inventory
{
	private int reorderLevel
	{
		get;
		set;
	}

	private string productName
	{
		get;
		set;
	}

	private int shipped
	{
		get;
		set;
	}

	private int minReorderQuanity
	{
		get;
		set;
	}

	private int received
	{
		get;
		set;
	}

	private int onOrder
	{
		get;
		set;
	}

	private int onHand
	{
		get;
		set;
	}

	private int reorderQuanity
	{
		get;
		set;
	}

	private string location
	{
		get;
		set;
	}

	public virtual void ToString()
	{
		throw new System.NotImplementedException();
	}

	public virtual void AddNewItem()
	{
		throw new System.NotImplementedException();
	}

	public virtual void ModifyItemDetails()
	{
		throw new System.NotImplementedException();
	}

	public virtual void ModifyItemStock()
	{
		throw new System.NotImplementedException();
	}

	public virtual void RemoveItem()
	{
		throw new System.NotImplementedException();
	}

	public virtual void setFiltersToOrder()
	{
		throw new System.NotImplementedException();
	}

}

