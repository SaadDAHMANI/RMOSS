using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.IO;
using System.Data.OleDb;

namespace IOOperations
{
public	class ExcelFileIO
	{
		public ExcelFileIO ( string fileName)
		{
			this.FileName = fileName;
			ConnectionStr = string.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=\"Excel 12.0; HDR = YES;\";", FileName);
		}
		#region "Properties"

		public string FileName;

		public string ConnectionString
		{ get { return ConnectionStr; } }

		private List<string> mSheets =null; 
		public List<string> Sheets
		{ get
			{
				if (object.Equals(mSheets, null)) { Connect(); }
				return mSheets;
			}
		}

		private List<DataTable> mTables;
		public List<DataTable> Tables
		{
			get { return mTables; } 
				}

#endregion
		private OleDbConnection Connection;
		private string ConnectionStr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" ;

		public void Connect()
		{
			
			if (File .Exists (FileName))
			{				
				using (Connection = new OleDbConnection(ConnectionStr))
				{
					Connection.Open();

				mSheets = GetAllSheets();
			    LoadAllTables();

					Connection.Close();
				}
		   }		
				

		}

		public List<string> GetSheets()
		{
			List<string> sheets = null;
			try
			{

				if (File.Exists(FileName))
				{
					using (Connection = new OleDbConnection(ConnectionStr))
					{
						Connection.Open();
						DataTable dt = Connection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);

						if (object.Equals(dt, null) == false)
						{
							sheets = new List<string>();

							foreach (DataRow dr in dt.Rows)
							{
								sheets.Add(dr["TABLE_NAME"].ToString());
							}

						}
						Connection.Close();
					}
				}

			}
		catch (Exception ex)
			{ throw ex; }
			return sheets;
		}

		private List<string> GetAllSheets()
		{
			List<string> sheets = null;
			try
			{
					
						DataTable dt = Connection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);

						if (object.Equals(dt, null) == false)
						{
							sheets = new List<string>();

							foreach (DataRow dr in dt.Rows)
							{
								sheets.Add(dr["TABLE_NAME"].ToString());
							}

						}
											

			}
			catch (Exception ex)
			{ throw ex; }
			return sheets;
		}

		private void LoadAllTables()
		{
						try
			{
				if (object.Equals(this.Sheets, null)) { return; }

				OleDbDataAdapter dadapter = new OleDbDataAdapter();
				//Dim y As New Odbc.OdbcDataAdapter(strSQL, strConnString)
				string strSQL;
				DataTable dt;
				mTables = new List<DataTable>();

				foreach (string shet in Sheets)
				{
					strSQL = string.Format("SELECT * FROM [{0}]", shet);
					dadapter.SelectCommand =new OleDbCommand(strSQL);
					dadapter.SelectCommand.Connection = Connection;

					dt = new DataTable();
					dadapter.Fill(dt);
					mTables.Add(dt);
		     	}
											
			}
			catch (Exception ex)
			{ throw ex; }
			
		}

		public DataTable Table_Of( string sheet)
		{
			DataTable dt = null;
			try
			{
				if (sheet=="") { return dt; }

				if (File.Exists(FileName))
				{
					using (Connection = new OleDbConnection(ConnectionStr))
					{
						Connection.Open();

                 string strSQL= string.Format("SELECT * FROM [{0}]", sheet);
					
			   	OleDbDataAdapter dadapter = new OleDbDataAdapter(strSQL,Connection);
					dt = new DataTable();
					dadapter.Fill(dt);
						
						Connection.Close();

					}
				}					
						
					}
			catch (Exception ex)
			{ throw ex; }
			finally {
				if (Connection.State == ConnectionState.Open )
				{ Connection.Close(); }
					}
			return dt;
		}

	}
}
