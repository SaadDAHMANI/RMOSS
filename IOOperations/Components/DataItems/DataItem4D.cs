﻿/*
 * Created by SharpDevelop.
 * User: Saad
 * Date: 01/11/2015
 * Time: 12:06
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace IOOperations.Components
{
	/// <summary>
	/// DataItem5D is (Title, A, B, C, D, E) item.
	/// </summary>
	[Serializable]
	public class DataItem4D
	{
		public DataItem4D()
		{ }
		public DataItem4D(string title, double aValue, double bValue, double cValue, double dValue)
		{
			if (title == string.Empty) { mTitle = "/"; }
			else { mTitle = title; }
			mA_Value = aValue;
			mB_Value = bValue;
			mC_Value = cValue;
			mD_Value = dValue;
		}

		string mTitle = "/";
		public string Title
		{
			get { return mTitle; }
			set
			{
				if (value == string.Empty)
				{ mTitle = "/"; }
				else { mTitle = value; }
			}
		}

		double mA_Value;
		public double A_Value
		{
			get { return mA_Value; }
			set { mA_Value = value; }
		}

		double mB_Value;
		public double B_Value
		{
			get { return mB_Value; }
			set { mB_Value = value; }
		}

		double mC_Value;
		public double C_Value
		{
			get { return mC_Value; }
			set { mC_Value = value; }
		}

		double mD_Value;
		public double D_Value
		{
			get { return mD_Value; }
			set { mD_Value = value; }
		}

		
	}
}
