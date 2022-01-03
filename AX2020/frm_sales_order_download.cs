using System;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic; // For generic collections like List.
using System.Data.SqlClient;      // For the database connections and objects.
using System.Data.Sql;
using System.Data.Sql;
using System.Data;
using CommonFunction;
using CommonLibrary;
using CommonControl.Functions;
using System.ComponentModel;
using System.Diagnostics;

namespace AX2020
{ 
	public partial class frm_sales_order_download : Form
	{
		DateTime TodayDate, SystemDate;
		string username, name, name2, StrSalesOrderNo = null, StockCheckJR, StockCheckFR, StockCheckGlue, StockCheckRibbon, StockCheckWL;
		int NextNo;
		public static string sqlconn = "Server=AX-UAT; Password=sbax2020sbg; User ID=sbax2020; Initial Catalog=SBG_AX_2020; Integrated Security=false";
		public static string sqlconn2 = "Server=FLEX-BARCODE-PC\\SBGROUP; Password=sbax2020sbg; User ID=sbax2020; Initial Catalog=SB_SAPS; Integrated Security=false";
		
		public frm_sales_order_download()
		{
			InitializeComponent();
			this.ControlBox = false;
			
			username = frm_menu_system.userName; 
			lbl_username.Text = "User : " + username;
		}
		
		void frm_sales_order_downloadLoad(object sender, EventArgs e)
		{
			TodayDate = System.DateTime.Now;
//			SystemDate = System.DateTime.Now;
//			
//			SqlConnection con_Check_Security_Access = new SqlConnection(sqlconn);
//			SqlCommand cmd_Check_Security_Access = new SqlCommand();
//			
//			try 
//			{
//				cmd_Check_Security_Access.CommandText = "Select * from tbl_authentication where email ='" + username + "' and department <> 'SAL' and [type]='A'";
//				cmd_Check_Security_Access.Connection = con_Check_Security_Access;
//				con_Check_Security_Access.Open();
//				System.Data.SqlClient.SqlDataReader rd_Check_Security_Access = cmd_Check_Security_Access.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
//				
//				if (rd_Check_Security_Access.HasRows)
//				{
//					if (rd_Check_Security_Access.Read())
//					{
//						string Dummy = null;
//						Dummy = null;
//					}
//				} 
//				else
//				{
//					//Response.Redirect["main_menu.aspx"];
//				}
//			} 
//			catch (Exception ex)
//			{
//				con_Check_Security_Access.Close();
//				//Response.Redirect["main_menu.aspx"];
//			} 
//			finally 
//			{
//				con_Check_Security_Access.Close();
//			}
//			
//			con_Check_Security_Access.Dispose();
//			cmd_Check_Security_Access.Dispose();
//			con_Check_Security_Access = null;
//			cmd_Check_Security_Access = null;
//			
//
//
//			SqlConnection con_SP1 = new SqlConnection(sqlconn);
//			System.Data.SqlClient.SqlCommand cmd_SP1 = new SqlCommand();
//			
//			try
//			{
//				cmd_SP1.Connection = con_SP1;
//				cmd_SP1.CommandText = "SP_SAPS_SO_UPDATE_STATUS";
//				cmd_SP1.CommandType = CommandType.StoredProcedure;
//				cmd_SP1.CommandTimeout = 9000;
//				con_SP1.Open();
//				cmd_SP1.ExecuteNonQuery();
//			} 
//			catch (Exception ex)
//			{
//				con_SP1.Close();
//				
//				MessageBox.Show("Error SP SO Update!" + ex.Message + ex.ToString());
//				return;
//			} 
//			finally
//			{
//				con_SP1.Close();
//			}
//			con_SP1.Dispose();
//			con_SP1 = null;
//			cmd_SP1 = null;			
			
			BindData();			
		}
		
		public void ClearVariable()
		{
			
		}
		
		private DataTable AutoNumberedTable(DataTable SourceTable)
		{
		
			DataTable ResultTable = new DataTable();
			DataColumn AutoNumberColumn = new DataColumn();
			AutoNumberColumn.ColumnName ="No";
			AutoNumberColumn.DataType = typeof(int);
			AutoNumberColumn.AutoIncrement = true;
			AutoNumberColumn.AutoIncrementSeed = 1;
			AutoNumberColumn.AutoIncrementStep = 1;
			
			ResultTable.Columns.Add(AutoNumberColumn);
			ResultTable.Merge(SourceTable);
			return ResultTable;
		
		}
	
	
		public void BindData()
		{
			DataTable ds = new DataTable();
			ds = CreateDataSet();
			dt_grid.DataSource = AutoNumberedTable(ds);
			//dt_grid_so.DataBind();
			
			
			dt_grid.Columns[0].Name = "No";
	        dt_grid.Columns[0].Width = 25;
	        dt_grid.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
			dt_grid.Columns[1].HeaderText = "Doc No";
			dt_grid.Columns[1].Width = 120;
			dt_grid.Columns[2].HeaderText = "Sales Order No";
			dt_grid.Columns[2].Width = 80;
			dt_grid.Columns[3].HeaderText = "Sales Order Date";
			dt_grid.Columns[3].Width = 60;
			dt_grid.Columns[3].DefaultCellStyle.Format = "dd/MM/yyyy";
			dt_grid.Columns[4].HeaderText = "Customer";
			dt_grid.Columns[4].Width = 200;
			
			dt_grid.Columns[5].HeaderText = "Desciption";
			dt_grid.Columns[5].Width = 100;
			
			dt_grid.Columns[6].HeaderText = "Checked";
			dt_grid.Columns[6].Width = 50;
		}
		
		void Btn_cancelClick(object sender, EventArgs e)
		{
			this.Close();
		}
		
		void Btn_saveClick(object sender, EventArgs e)
		{
			
						
		}
		
		public DataTable CreateDataSet()
		{
		
			SqlConnection objConn = new SqlConnection();
			SqlCommand objCmd = new SqlCommand();
			SqlDataAdapter dtAdapter = new SqlDataAdapter();
			
			DataTable ds = new DataTable();
			
			string strSQL = null;
			
			DateTime TodayData = DateTime.Now.AddDays(-40);
			string Today_Data = TodayData.ToString("yyyy-MM-dd");
			
					
			//If User.Identity.Name.ToLower = "itteam.sbgroup@gmail.com" Then
			//strSQL = "select * from VIEW_SALES_STORE_PO_REGISTRATION where ReportDateTime >= '" & Today_Data & "'  order by SODateTime desc"
			//Else
			//strSQL = "select * from VIEW_SALES_STORE_PO_REGISTRATION where UserName = '" & User.Identity.Name.ToUpper() & "'  order by ReportDateTime desc"
			
			
			//strSQL = "select DocNo, SalesOrderNo, SODateTime, Customer, SalesOrder, flag1 from VIEW_SALES_ORDER_USER where SODateTime >= '" + Today_Data + "'  and flag1 = 'N' and username = '" + frm_menu_system.email + "' order by SalesOrderNo desc";
			strSQL = "select DocNo, SalesOrderNo, SODateTime, Customer, SalesOrder, flag1 from VIEW_SALES_ORDER_USER where flag1 = 'N' and username = '" + frm_menu_system.email + "' order by SalesOrderNo desc";			
			//strSQL = "select DocNo, SalesOrderNo, SODateTime, Customer, SalesOrder, flag1 from VIEW_SALES_ORDER_USER where flag1 = 'N'";
			
			
			//End If
			//strSQL = "select * from VIEW_SALES_STORE_PO_REGISTRATION_FILE"
			//***************************************************************************************************************************************************************************
			objConn.ConnectionString = sqlconn;
			
			var _with1 = objCmd;
			
			_with1.Connection = objConn;
			_with1.CommandText = strSQL;
			_with1.CommandType = CommandType.Text;
			dtAdapter.SelectCommand = objCmd;
			
			dtAdapter.Fill(ds);
			dtAdapter = null;
			objConn.Close();
			objConn = null;
			return ds;
			
		}
		
		
		public void Retrieve()
		{

			SqlConnection SP_CheckSO_SqlCon = new SqlConnection(sqlconn);
			//string SP_CheckSO_QueryStr = "select * from TBL_FORM_SALES_STORE_PO_REGISTRATION where SalesOrderNo = '" + StrSalesOrderNo + "'";
			
			SqlCommand SP_CheckSO_SqlCmd = new SqlCommand("select * from TBL_SALES_ORDER_REGISTRATION where SalesOrderNo = '" + StrSalesOrderNo + "'", SP_CheckSO_SqlCon);
			
			try
			{
				SP_CheckSO_SqlCon.Open();
				System.Data.SqlClient.SqlDataReader dbr_CheckSO_LIST = SP_CheckSO_SqlCmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
				if (dbr_CheckSO_LIST.HasRows) 
				{
					while (dbr_CheckSO_LIST.Read()) 
					{
						try 
						{
							txtbx_so.Text = dbr_CheckSO_LIST["SalesOrderNo"].ToString();
							dtp_so_date.Value = Convert.ToDateTime(dbr_CheckSO_LIST["SODateTime"]);
							txtbx_cust.Text = dbr_CheckSO_LIST["Customer"].ToString();
							txtbx_cust_code.Text = " ";
	
							if (dbr_CheckSO_LIST["CustomerType"].ToString() == null)
							{
								txtbx_cust_type.Text = " ";
							} 
							else 
							{
								txtbx_cust_type.Text = dbr_CheckSO_LIST["CustomerType"].ToString();
							}
	
							if (dbr_CheckSO_LIST["CustomerPO"].ToString()== null) 
							{
								txtbx_cust_po.Text = " ";
							} 
							else 
							{
								txtbx_cust_po.Text = dbr_CheckSO_LIST["CustomerPO"].ToString();
							}
	
							txtbx_unit_ordered.Text = dbr_CheckSO_LIST["SalesOrder"].ToString();
							dtp_etd.Value = Convert.ToDateTime(dbr_CheckSO_LIST["ETDDateTime"].ToString());
	
							if (dbr_CheckSO_LIST["SalesOrderInfo1"].ToString()== null) 
							{
								txtbx_info_1.Text = " ";
							} 
							else 
							{
								txtbx_info_1.Text = dbr_CheckSO_LIST["SalesOrderInfo1"].ToString();
							}
	
							if (dbr_CheckSO_LIST["SalesOrderInfo2"].ToString()== null) 
							{
								txtbx_info_2.Text = " ";
							} 
							else 
							{
								txtbx_info_2.Text = dbr_CheckSO_LIST["SalesOrderInfo2"].ToString();
							}
	
							if (dbr_CheckSO_LIST["SalesOrderInfo3"].ToString()== null) 
							{
								txtbx_info_3.Text = " ";
							} 
							else 
							{
								txtbx_info_3.Text = dbr_CheckSO_LIST["SalesOrderInfo3"].ToString();
							}
	
							if (dbr_CheckSO_LIST["FlagFileUpload"].ToString()== null) 
							{
								txtbx_att_so.Text = " ";
							} 
							else 
							{
								txtbx_att_so.Text = dbr_CheckSO_LIST["FlagFileUpload"].ToString();
							}
	
							if (dbr_CheckSO_LIST["FlagFileUpload2"].ToString()== null) 
							{
								txtbx_att_ctn.Text = " ";
							} 
							else 
							{
								txtbx_att_ctn.Text = dbr_CheckSO_LIST["FlagFileUpload2"].ToString();
							}
	
							if (dbr_CheckSO_LIST["FlagFileUpload3"].ToString()== null) 
							{
								txtbx_att_pcore.Text = " ";
							} 
							else 
							{
								txtbx_att_pcore.Text = dbr_CheckSO_LIST["FlagFileUpload3"].ToString();
							}
	
							if (dbr_CheckSO_LIST["FlagFileUpload4"].ToString()== null) 
							{
								txtbx_att_shipmark.Text = " ";
							} 
							else 
							{
								txtbx_att_shipmark.Text = dbr_CheckSO_LIST["FlagFileUpload4"].ToString();
							}
	
							if (dbr_CheckSO_LIST["FlagFileUpload5"].ToString()== null) 
							{
								txtbx_att_other1.Text = " ";
							} 
							else 
							{
								txtbx_att_other1.Text = dbr_CheckSO_LIST["FlagFileUpload5"].ToString();
							}
	
							if (dbr_CheckSO_LIST["FlagFileUpload6"].ToString()== null) 
							{
								txtbx_att_other2.Text = " ";
							} 
							else 
							{
								txtbx_att_other2.Text = dbr_CheckSO_LIST["FlagFileUpload6"].ToString();
							}
	
							if (dbr_CheckSO_LIST["FlagFileUpload7"].ToString()== null) 
							{
								txtbx_att_other3.Text = " ";
							} 
							else 
							{
								txtbx_att_other3.Text = dbr_CheckSO_LIST["FlagFileUpload7"].ToString();
							}
							
						} 
						catch (Exception CheckSO_ex1) 
						{
							MessageBox.Show(CheckSO_ex1.Message + CheckSO_ex1.ToString());
							return;
						}
					}
				}
				
				dbr_CheckSO_LIST = null;
			} 
			catch (Exception CheckSO_ex2) 
			{
				MessageBox.Show(CheckSO_ex2.Message + CheckSO_ex2.ToString());
				return;
			
			} 
			finally 
			{
				SP_CheckSO_SqlCon.Close();
				SP_CheckSO_SqlCon.Dispose();
			}
			SP_CheckSO_SqlCon = null;
			//SP_CheckSO_QueryStr = null;
			SP_CheckSO_SqlCmd = null;
		
			BindData();
		}
//
//	
//
//	protected void btnLoad_Click(object sender, System.EventArgs e)
//	{
//		string CmdDownloadFile = null;
//		CmdDownloadFile = null;
//		
//		SqlConnection con_GetSO_FIle = new SqlConnection(ConfigurationSettings.AppSettings("ConnectionString"));
//		SqlCommand cmd_GetSO_FIle = new SqlCommand();
//		
//		try 
//		{
//			cmd_GetSO_FIle.CommandText = "select * from TBL_FORM_SALES_STORE_PO_REGISTRATION where SalesOrderNo = '" + txtbx_so.Text + "'";
//			cmd_GetSO_FIle.Connection = con_GetSO_FIle;
//			con_GetSO_FIle.Open();
//			System.Data.SqlClient.SqlDataReader rd_GetSO_FIle = cmd_GetSO_FIle.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
//			
//			if (rd_GetSO_FIle.Read())
//			{
//				txtbx_att_so.Text = rd_GetSO_FIle["FlagFileUpload"].ToString();
//				CmdDownloadFile = rd_GetSO_FIle["FlagFileUpload"].ToString();
//			} 
//			else 
//			{
//				con_GetSO_FIle.Close();
//				return;
//			}
//		} 
//		catch (Exception ex) 
//		{
//			con_GetSO_FIle.Close();
//			MessageBox.Show("Error Download File :" + ex.ToString() + ex.Message);
//			return;
//		} 
//		finally 
//		{
//			con_GetSO_FIle.Close();
//		}
//		
//		con_GetSO_FIle.Dispose();
//		cmd_GetSO_FIle.Dispose();
//		con_GetSO_FIle = null;
//		cmd_GetSO_FIle = null;
//		
//		string value1 = txtbx_att_so.Text;
//		string value2 = value1.Replace("http://192.168.1.210/SAPS/", "D:\\SAPS\\");
//		//Dim value3 As String = value1.Replace["http://192.168.1.210/SAPS/", "DocNo"]
//		//**********************************************************************************************************************        
//		//txtbx_att_so.Text
//		//Dim filename As System.String = txtbx_att_so.Text
//		System.String filename = value2;
//		//value3
//
//		// set the http content type to "APPLICATION/OCTET-STREAM
//		Response.ContentType = "APPLICATION/OCTET-STREAM";
//
//		// initialize the http content-disposition header to
//		// indicate a file attachment with the default filename
//		System.String disHeader = "Attachment; Filename=\"" + filename + "\"";
//		Response.AppendHeader("Content-Disposition", disHeader);
//
//		// transfer the file byte-by-byte to the response object
//		System.IO.FileInfo fileToDownload = new System.IO.FileInfo(value2);
//		Response.Flush();
//		Response.WriteFile(fileToDownload.FullName);
//		
//		
//		
//		SqlConnection conUpdate_Acknowledgement = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);
//		System.Data.SqlClient.SqlCommand cmdUpdate_Acknowledgement = new SqlCommand();
//		
//		try 
//		{
//			cmdUpdate_Acknowledgement.CommandText = "update TBL_FORM_SALES_STORE_PO_REGISTRATION_USER set flag1 = 'Y', userdate = '" + System.DateTime.Now + "' where username = '" + User.Identity.Name.ToUpper() + "' and SalesOrderNo = '" + txtbx_so.Text + "'";
//			cmdUpdate_Acknowledgement.Connection = conUpdate_Acknowledgement;
//			conUpdate_Acknowledgement.Open();
//			cmdUpdate_Acknowledgement.ExecuteNonQuery();
//		} 
//		catch (Exception ex) 
//		{
//			conUpdate_Acknowledgement.Close();
//			MessageBox.Show("Error User Acknowledgement! " + ex.ToString() + ex.Message);
//			return;
//		} 
//		finally 
//		{
//			conUpdate_Acknowledgement.Close();
//		}
//		conUpdate_Acknowledgement.Dispose();
//		conUpdate_Acknowledgement = null;
//		cmdUpdate_Acknowledgement = null;
//		
//		
//		StockCheckJR = null;
//		StockCheckFR = null;
//		StockCheckGlue = null;
//		StockCheckRibbon = null;
//		StockCheckWL = null;
//		
//		
//		StockCheckJR = "N";
//		StockCheckFR = "N";
//		StockCheckGlue = "N";
//		StockCheckRibbon = "N";
//		StockCheckWL = "N";
//		
//		
//		SqlConnection SP_CheckStockType_Glue_SqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);
//		string SP_CheckStockType_Glue_QueryStr = "select * from TBL_FORM_SALES_STORE_PO_REGISTRATION_DETAIL where tno = '" + txtbx_so.Text.ToUpper + "' and tstk like 'EX%' or tno = '" + txtbx_so.Text.ToUpper + "' and tstk like 'WG%'";
//		
//		SqlCommand SP_CheckStockType_Glue_SqlCmd = new SqlCommand(SP_CheckStockType_Glue_QueryStr, SP_CheckStockType_Glue_SqlCon);
//		try 
//		{
//			SP_CheckStockType_Glue_SqlCon.Open();
//			System.Data.SqlClient.SqlDataReader dbr_CheckStockType_Glue_LIST = SP_CheckStockType_Glue_SqlCmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
//			
//			if (dbr_CheckStockType_Glue_LIST.HasRows)
//			{
//				while (dbr_CheckStockType_Glue_LIST.Read()) 
//				{
//					try 
//					{
//						StockCheckGlue = "Y";
//						
//					} 
//					catch (Exception CheckStockType_Glue_ex1) 
//					{
//						MessageBox.Show(CheckStockType_Glue_ex1.ToString() + CheckStockType_Glue_ex1.Message);
//						return;
//					}
//				}
//			}
//			dbr_CheckStockType_Glue_LIST = null;
//		} 
//		catch (Exception CheckStockType_Glue_ex2) 
//		{
//			MessageBox.Show(CheckStockType_Glue_ex2.ToString() + CheckStockType_Glue_ex2.Message);
//			return;
//		} 
//		finally 
//		{
//			SP_CheckStockType_Glue_SqlCon.Close();
//			SP_CheckStockType_Glue_SqlCon.Dispose();
//		}
//		
//		SP_CheckStockType_Glue_SqlCon = null;
//		SP_CheckStockType_Glue_QueryStr = null;
//		SP_CheckStockType_Glue_SqlCmd = null;
//		//-------------------------------------------------------------------------------------------------------------------------------------------------------------------
//		
//		SqlConnection SP_CheckStockType_JR_SqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);
//		string SP_CheckStockType_JR_QueryStr = "select * from TBL_FORM_SALES_STORE_PO_REGISTRATION_DETAIL where tno = '" + txtbx_so.Text.ToUpper + "' and tstk like 'WJ%'";
//		System.Data.SqlClient.SqlCommand SP_CheckStockType_JR_SqlCmd = new System.Data.SqlClient.SqlCommand(SP_CheckStockType_JR_QueryStr, SP_CheckStockType_JR_SqlCon);
//		try 
//		{
//			SP_CheckStockType_JR_SqlCon.Open();
//			SqlDataReader dbr_CheckStockType_JR_LIST = SP_CheckStockType_JR_SqlCmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
//			
//			if (dbr_CheckStockType_JR_LIST.HasRows) 
//			{
//				while (dbr_CheckStockType_JR_LIST.Read()) 
//				{
//					try 
//					{
//						//###################################################################################################################################################################
//						StockCheckJR = "Y";
//						//###################################################################################################################################################################
//					} 
//					catch (Exception CheckStockType_JR_ex1) 
//					{
//						MessageBox.Show(CheckStockType_JR_ex1.ToString());
//						return;
//					}
//				}
//			}
//			dbr_CheckStockType_JR_LIST = null;
//		} 
//		catch (Exception CheckStockType_JR_ex2) 
//		{
//			MessageBox.Show(CheckStockType_JR_ex2.ToString());
//			return;
//		} 
//		finally 
//		{
//			SP_CheckStockType_JR_SqlCon.Close();
//			SP_CheckStockType_JR_SqlCon.Dispose();
//		}
//		
//		SP_CheckStockType_JR_SqlCon = null;
//		SP_CheckStockType_JR_QueryStr = null;
//		SP_CheckStockType_JR_SqlCmd = null;
//		//-------------------------------------------------------------------------------------------------------------------------------------------------------------------
//		
//		SqlConnection SP_CheckStockType_LR_SqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);
//		string SP_CheckStockType_LR_QueryStr = "select * from TBL_FORM_SALES_STORE_PO_REGISTRATION_DETAIL where tno = '" + txtbx_so.Text.ToUpper + "' and tstk like 'WL%'";
//		SqlCommand SP_CheckStockType_LR_SqlCmd = new SqlCommand(SP_CheckStockType_LR_QueryStr, SP_CheckStockType_LR_SqlCon);
//		
//		try 
//		{
//			SP_CheckStockType_LR_SqlCon.Open();
//			System.Data.SqlClient.SqlDataReader dbr_CheckStockType_LR_LIST = SP_CheckStockType_LR_SqlCmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
//			if (dbr_CheckStockType_LR_LIST.HasRows) 
//			{
//				while (dbr_CheckStockType_LR_LIST.Read()) 
//				{
//					try 
//					{
//						//###################################################################################################################################################################
//						StockCheckWL = "Y";
//						//###################################################################################################################################################################
//					} 
//					catch (Exception CheckStockType_LR_ex1) 
//					{
//						MessageBox.Show(CheckStockType_LR_ex1.ToString());
//						return;
//					}
//				}
//			}
//			dbr_CheckStockType_LR_LIST = null;
//		} 
//		catch (Exception CheckStockType_LR_ex2) 
//		{
//			MessageBox.Show(CheckStockType_LR_ex2.ToString());
//			return;
//		} 
//		finally 
//		{
//			SP_CheckStockType_LR_SqlCon.Close();
//			SP_CheckStockType_LR_SqlCon.Dispose();
//		}
//		
//		SP_CheckStockType_LR_SqlCon = null;
//		SP_CheckStockType_LR_QueryStr = null;
//		SP_CheckStockType_LR_SqlCmd = null;
//		
//		//-------------------------------------------------------------------------------------------------------------------------------------------------------------------
//		SqlConnection SP_CheckStockType_Ribbon_SqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);
//		string SP_CheckStockType_Ribbon_QueryStr = "select * from TBL_FORM_SALES_STORE_PO_REGISTRATION_DETAIL where tno = '" + txtbx_so.Text.ToUpper + "' and tdesc1 like '%ribbon%' or tno = '" + txtbx_so.Text.ToUpper + "' and tdesc1 like '%ribbon%'";
//		System.Data.SqlClient.SqlCommand SP_CheckStockType_Ribbon_SqlCmd = new System.Data.SqlClient.SqlCommand(SP_CheckStockType_Ribbon_QueryStr, SP_CheckStockType_Ribbon_SqlCon);
//		try 
//		{
//			SP_CheckStockType_Ribbon_SqlCon.Open();
//			SqlDataReader dbr_CheckStockType_Ribbon_LIST = SP_CheckStockType_Ribbon_SqlCmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
//			if (dbr_CheckStockType_Ribbon_LIST.HasRows) 
//			{
//				while (dbr_CheckStockType_Ribbon_LIST.Read()) 
//				{
//					try 
//					{
//						//###################################################################################################################################################################
//						StockCheckRibbon = "Y";
//						//###################################################################################################################################################################
//					} 
//					catch (Exception CheckStockType_Ribbon_ex1) 
//					{
//						MessageBox.Show(CheckStockType_Ribbon_ex1.ToString());
//						return;
//					}
//				}
//			}
//			dbr_CheckStockType_Ribbon_LIST = null;
//		} 
//		catch (Exception CheckStockType_Ribbon_ex2) 
//		{
//			MessageBox.Show(CheckStockType_Ribbon_ex2.ToString());
//			return;
//		} 
//		finally 
//		{
//			SP_CheckStockType_Ribbon_SqlCon.Close();
//			SP_CheckStockType_Ribbon_SqlCon.Dispose();
//		}
//		
//		SP_CheckStockType_Ribbon_SqlCon = null;
//		SP_CheckStockType_Ribbon_QueryStr = null;
//		SP_CheckStockType_Ribbon_SqlCmd = null;
//		
//		//-------------------------------------------------------------------------------------------------------------------------------------------------------------------
//		SqlConnection SP_CheckStockType_OPPT_SqlCon = new SqlConnection(sqlconn2);
//		//string SP_CheckStockType_OPPT_QueryStr = "select * from TBL_FORM_SALES_STORE_PO_REGISTRATION_DETAIL where tno = '" + txtbx_so.Text.ToUpper + "' and tdesc1 like '%OPPT%' or tno = '" + txtbx_so.Text.ToUpper + "' and tdesc1 like '%OPPT%'";
//		SqlCommand SP_CheckStockType_OPPT_SqlCmd = new SqlCommand("select * from TBL_FORM_SALES_STORE_PO_REGISTRATION_DETAIL where tno = '" + txtbx_so.Text.ToUpper + "' and tdesc1 like '%OPPT%' or tno = '" + txtbx_so.Text.ToUpper + "' and tdesc1 like '%OPPT%'", SP_CheckStockType_OPPT_SqlCon);
//		
//		try 
//		{
//			SP_CheckStockType_OPPT_SqlCon.Open();
//			System.Data.SqlClient.SqlDataReader dbr_CheckStockType_OPPT_LIST = SP_CheckStockType_OPPT_SqlCmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
//			if (dbr_CheckStockType_OPPT_LIST.HasRows) 
//			{
//				while (dbr_CheckStockType_OPPT_LIST.Read()) 
//				{
//					try 
//					{
//						//###################################################################################################################################################################
//						StockCheckFR = "Y";
//						//###################################################################################################################################################################
//					} 
//					catch (Exception CheckStockType_OPPT_ex1) 
//					{
//						MessageBox.Show(CheckStockType_OPPT_ex1.ToString());
//						return;
//					}
//				}
//			}
//			dbr_CheckStockType_OPPT_LIST = null;
//		} 
//		catch (Exception CheckStockType_OPPT_ex2) 
//		{
//			MessageBox.Show(CheckStockType_OPPT_ex2.ToString());
//			return;
//		} 
//		finally 
//		{
//			SP_CheckStockType_OPPT_SqlCon.Close();
//			SP_CheckStockType_OPPT_SqlCon.Dispose();
//		}
//		
//		SP_CheckStockType_OPPT_SqlCon = null;
//		SP_CheckStockType_OPPT_QueryStr = null;
//		SP_CheckStockType_OPPT_SqlCmd = null;
//		
//		//------------------------------------------------------------------------------------------
//		// BEGIN EMAIL NOTIFICATION
//		//------------------------------------------------------------------------------------------
////		string FromName = "SAPS E-SERVICE";
////		string FromEmail = "itteam.sbgroup@gmail.com";
////		string Subject = "SAPS SO READ : " + txtbx_so.Text.ToUpper;
////
////		SmtpClient smtp = new SmtpClient();
////		smtp.Host = "smtp.gmail.com";
////		smtp.Credentials = new System.Net.NetworkCredential("itteam.sbgroup@gmail.com", "wsc4143pk");
////		smtp.EnableSsl = true;
////		smtp.Port = 587;
////
////		MailMessage msg = new MailMessage();
////		msg.From = new MailAddress(FromEmail, FromName);
////		//---> msg.To.Add(New MailAddress("samuel@sbgroup.com.my", "Samuel"))
////		msg.To.Add(new MailAddress("cath@sbgroup.com.my", "Catherine Teh"));
////
////		if (txtbx_cust_type.Text == "LC") {
////			//--> Customer Service Local
////			msg.To.Add(new MailAddress("kelly@sbgroup.com.my", "Kelly Chan"));
////			msg.To.Add(new MailAddress("salesco-1@sbgroup.com.my", "Han Chok Min Jie"));
////			msg.To.Add(new MailAddress("salesco-1@sbgroup.com.my", "SalesCo1"));
////			msg.To.Add(new MailAddress("salesco-3@sbgroup.com.my", "SalesCo"));
////
////			if (StockCheckGlue == "N") {
////				//--> Store1806
////				//msg.To.Add(New MailAddress("logistic-8@sbgroup.com.my", "Fan Phong Lin"))
////				msg.To.Add(new MailAddress("store-2@sbgroup.com.my", "Kalyani "));
////				msg.To.Add(new MailAddress("store-9@sbgroup.com.my", "Chin Chin"));
////				msg.To.Add(new MailAddress("logistic-5@sbgroup.com.my", "Arveenah"));
////				msg.To.Add(new MailAddress("cyyong@sbgroup.com.my", "CY Yong"));
////				msg.To.Add(new MailAddress("sosiaw@sbgroup.com.my", "SO Siaw"));
////			} else {
////				//--> Logistic
////				msg.To.Add(new MailAddress("logistic-5@sbgroup.com.my", "Arveenah"));
////				msg.To.Add(new MailAddress("store-4@sbgroup.com.my", "Shuairah "));
////				msg.To.Add(new MailAddress("store-7@sbgroup.com.my", "Hazlinda"));
////				msg.To.Add(new MailAddress("store-8@sbgroup.com.my", "Wong Wen Kuang"));
////				msg.To.Add(new MailAddress("logistic-10@sbgroup.com.my", "Jenny"));
////				msg.To.Add(new MailAddress("cyyong@sbgroup.com.my", "CY Yong"));
////				msg.To.Add(new MailAddress("sosiaw@sbgroup.com.my", "SO Siaw"));
////			}
////		} else if (txtbx_cust_type.Text == "SG") {
////			//--> Customer Service Local
////			msg.To.Add(new MailAddress("kelly@sbgroup.com.my", "Kelly Chan"));
////			msg.To.Add(new MailAddress("salesco-1@sbgroup.com.my", "Han Chok Min Jie"));
////			msg.To.Add(new MailAddress("salesco-1@sbgroup.com.my", "SalesCo1"));
////			msg.To.Add(new MailAddress("salesco-3@sbgroup.com.my", "SalesCo"));
////
////			//--> Store1806
////			//msg.To.Add(New MailAddress("logistic-8@sbgroup.com.my", "Fan Phong Lin"))
////			msg.To.Add(new MailAddress("store-2@sbgroup.com.my", "Kalyani "));
////			msg.To.Add(new MailAddress("store-9@sbgroup.com.my", "Chin Chin"));
////			msg.To.Add(new MailAddress("logistic-5@sbgroup.com.my", "Arveenah"));
////
////			//--> Customer Service Export
////			msg.To.Add(new MailAddress("exportsc-1@sbgroup.com.my", "Michelle Kang"));
////			msg.To.Add(new MailAddress("michelle.kang@sbgroup.com.my", "Daphiny Hoo Poe Yee"));
////
////			//--> Logistic
////			msg.To.Add(new MailAddress("logistic-5@sbgroup.com.my", "Arveenah"));
////			msg.To.Add(new MailAddress("store-4@sbgroup.com.my", "Shuairah "));
////			msg.To.Add(new MailAddress("store-7@sbgroup.com.my", "Hazlinda"));
////			msg.To.Add(new MailAddress("store-8@sbgroup.com.my", "Wong Wen Kuang"));
////			msg.To.Add(new MailAddress("logistic-10@sbgroup.com.my", "Jenny"));
////			msg.To.Add(new MailAddress("cyyong@sbgroup.com.my", "CY Yong"));
////			msg.To.Add(new MailAddress("sosiaw@sbgroup.com.my", "SO Siaw"));
////		} else if (txtbx_cust_type.Text == "FC") {
////			//--> Customer Service Export
////			msg.To.Add(new MailAddress("salesco-1@sbgroup.com.my", "SalesCo1"));
////			msg.To.Add(new MailAddress("exportsc-1@sbgroup.com.my", "Michelle Kang"));
////			msg.To.Add(new MailAddress("michelle.kang@sbgroup.com.my", "Daphiny Hoo Poe Yee"));
////
////			//--> Logistic
////			msg.To.Add(new MailAddress("logistic-5@sbgroup.com.my", "Arveenah"));
////			msg.To.Add(new MailAddress("store-4@sbgroup.com.my", "Shuairah "));
////			msg.To.Add(new MailAddress("store-7@sbgroup.com.my", "Hazlinda"));
////			msg.To.Add(new MailAddress("store-8@sbgroup.com.my", "Wong Wen Kuang"));
////			msg.To.Add(new MailAddress("logistic-10@sbgroup.com.my", "Jenny"));
////			msg.To.Add(new MailAddress("cyyong@sbgroup.com.my", "CY Yong"));
////			msg.To.Add(new MailAddress("sosiaw@sbgroup.com.my", "SO Siaw"));
////		} else {
////			//--> Customer Service Local
////			msg.To.Add(new MailAddress("kelly@sbgroup.com.my", "Kelly Chan"));
////			msg.To.Add(new MailAddress("salesco-1@sbgroup.com.my", "Han Chok Min Jie"));
////			msg.To.Add(new MailAddress("salesco-1@sbgroup.com.my", "SalesCo1"));
////			msg.To.Add(new MailAddress("salesco-3@sbgroup.com.my", "SalesCo"));
////
////			//--> Store1806
////			//msg.To.Add(New MailAddress("logistic-8@sbgroup.com.my", "Fan Phong Lin"))
////			msg.To.Add(new MailAddress("store-2@sbgroup.com.my", "Kalyani "));
////			msg.To.Add(new MailAddress("store-9@sbgroup.com.my", "Chin Chin"));
////			msg.To.Add(new MailAddress("logistic-5@sbgroup.com.my", "Arveenah"));
////
////			//--> Customer Service Export
////			msg.To.Add(new MailAddress("exportsc-1@sbgroup.com.my", "Michelle Kang"));
////			msg.To.Add(new MailAddress("michelle.kang@sbgroup.com.my", "Daphiny Hoo Poe Yee"));
////
////			//--> Logistic
////			msg.To.Add(new MailAddress("logistic-5@sbgroup.com.my", "Arveenah"));
////			msg.To.Add(new MailAddress("store-4@sbgroup.com.my", "Shuairah "));
////			msg.To.Add(new MailAddress("store-7@sbgroup.com.my", "Hazlinda"));
////			msg.To.Add(new MailAddress("store-8@sbgroup.com.my", "Wong Wen Kuang"));
////			msg.To.Add(new MailAddress("logistic-10@sbgroup.com.my", "Jenny"));
////			msg.To.Add(new MailAddress("cyyong@sbgroup.com.my", "CY Yong"));
////			msg.To.Add(new MailAddress("sosiaw@sbgroup.com.my", "SO Siaw"));
////		}
////
////		if (StockCheckGlue == "Y") 
////		{
////			//--> Glue
////			//msg.To.Add(New MailAddress("stacy@sbgroup.com.my", "Stacy Chooi"))
////			msg.To.Add(new MailAddress("co-3@sbgroup.com.my", "Elmer"));
////			msg.To.Add(new MailAddress("haiqal.bakar@sbgroup.com.my", "Haiqal"));
////			msg.To.Add(new MailAddress("st952@sbgroup.com.my", "Muhammad Rudzaimie"));
////			//msg.To.Add(New MailAddress("ystoh@sbgroup.com.my", "Mr TYS"))
////		} else if (StockCheckRibbon == "Y") {
////			//--> Ribbon
////			msg.To.Add(new MailAddress("stacy@sbgroup.com.my", "Stacy Chooi"));
////			//msg.To.Add(New MailAddress("production-4@sbgroup.com.my", "Jothi"))
////		} else if (StockCheckRibbon == "FR" | StockCheckWL == "Y") {
////			//msg.To.Add(New MailAddress("planner-3@sbgroup.com.my", "Simon Yew Chee Wang"))
////			msg.To.Add(new MailAddress("planner-5@sbgroup.com.my", "Jess Ng"));
////			msg.To.Add(new MailAddress("yap@sbgroup.com.my", "Yap Hong Kee "));
////			msg.To.Add(new MailAddress("converting-2@sbgroup.com.my", "Claudia"));
////		} else if (StockCheckJR == "Y") {
////			//--> Production
////			//msg.To.Add(New MailAddress("planner-3@sbgroup.com.my", "Simon Yew Chee Wang"))
////			msg.To.Add(new MailAddress("yap@sbgroup.com.my", "Yap Hong Kee "));
////		} else {
////			//msg.To.Add(New MailAddress("planner-3@sbgroup.com.my", "Simon Yew Chee Wang"))
////			msg.To.Add(new MailAddress("planner-5@sbgroup.com.my", "Jess Ng"));
////			msg.To.Add(new MailAddress("yap@sbgroup.com.my", "Yap Hong Kee "));
////			msg.To.Add(new MailAddress("converting-2@sbgroup.com.my", "Claudia"));
////		}
////		
////		string EmailUserName = null;
////		string EmailUserDept = null;
////		EmailUserName = null;
////		EmailUserDept = null;
//
////		SqlConnection con_Check_Recepient = new SqlConnection(sqlconn2);
////		SqlCommand cmd_Check_Recepient = new SqlCommand();
////		try {
////			cmd_Check_Recepient.CommandText = "Select * from tbl_authentication where email ='" + User.Identity.Name.ToUpper() + "'";
////			cmd_Check_Recepient.Connection = con_Check_Recepient;
////			con_Check_Recepient.Open();
////			System.Data.SqlClient.SqlDataReader rd_Check_Recepient = cmd_Check_Recepient.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
////			if (rd_Check_Recepient.HasRows) {
////				if (rd_Check_Recepient.Read) {
////					EmailUserName = rd_Check_Recepient["Name"].ToString();
////					EmailUserDept = rd_Check_Recepient["Department"].ToString();
////				}
////			}
////		} catch (Exception ex) {
////			con_Check_Recepient.Close();
////			Response.Redirect("main_menu.aspx");
////		} finally {
////			con_Check_Recepient.Close();
////		}
////		con_Check_Recepient.Dispose();
////		cmd_Check_Recepient.Dispose();
////		con_Check_Recepient = null;
////		cmd_Check_Recepient = null;
//		
////		msg.Subject = Subject;
////		msg.Body = "Dear All," + Constants.vbNewLine + Constants.vbNewLine + "Please be informed that " + User.Identity.Name.ToUpper() + " " + EmailUserName + " has read sales order ETD and will be processed it in the production and/or delivery" + Constants.vbNewLine + Constants.vbNewLine + "Customer   : " + txtbx_cust.Text.ToUpper + Constants.vbNewLine + Constants.vbNewLine + "S/O Number : " + txtbx_so.Text.ToUpper + Constants.vbNewLine + Constants.vbNewLine + Constants.vbNewLine + Constants.vbNewLine + "Info 1 : " + txtbx_info_1.Text.ToUpper + Constants.vbNewLine + Constants.vbNewLine + "Info 2 : " + txtbx_info_2.Text.ToUpper + Constants.vbNewLine + Constants.vbNewLine + "Info 3 : " + txtbx_info_3.Text.ToUpper + Constants.vbNewLine + Constants.vbNewLine + Constants.vbNewLine + Constants.vbNewLine + "Thank you." + Constants.vbNewLine + Constants.vbNewLine + "SAPS SOSystem Notification.";
////		try 
////		{
////			smtp.Send(msg);
////		} 
////		catch (FormatException ex) 
////		{
////			MessageBox.Show("Format Exception: " + ex.Message);
////		} 
//////		catch ( ex) 
//////		{
//////			MessageBox.Show("SMTP Exception:  " + ex.Message);
//////		} 
////		catch (Exception ex) 
////		{
////			MessageBox.Show("General Exception:  " + ex.Message);
////		}
////		
//		ClearVariable();
//		
//		MessageBox.Show("OK. File is downloaded.");
//	}
//
//	protected void btnLoad2_Click(object sender, System.EventArgs e)
//	{
//		
//		string CmdDownloadFile = null;
//		string CheckFile = null;
//		CmdDownloadFile = null;
//		CheckFile = null;
//		CheckFile = "N";
//		
//		SqlConnection con_GetSO_FIle = new SqlConnection(sqlconn2);
//		SqlCommand cmd_GetSO_FIle = new SqlCommand();
//		try 
//		{
//			cmd_GetSO_FIle.CommandText = "select * from TBL_FORM_SALES_STORE_PO_REGISTRATION where SalesOrderNo = '" + txtbx_so.Text + "'";
//			cmd_GetSO_FIle.Connection = con_GetSO_FIle;
//			con_GetSO_FIle.Open();
//			
//			SqlDataReader rd_GetSO_FIle = cmd_GetSO_FIle.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
//			
//			if (rd_GetSO_FIle.Read())
//			{
//				txtbx_att_ctn.Text = rd_GetSO_FIle["FlagFileUpload2"].ToString();
//				CmdDownloadFile = rd_GetSO_FIle["FlagFileUpload2"].ToString();
//				CheckFile = "Y";
//			} 
//			else 
//			{
//				CheckFile = "N";
//				con_GetSO_FIle.Close();
//				return;
//			}
//		} 
//		catch (Exception ex) 
//		{
//			con_GetSO_FIle.Close();
//			MessageBox.Show("Error Download File :" + ex.ToString());
//			return;
//		} 
//		finally 
//		{
//			con_GetSO_FIle.Close();
//		}
//		
//		con_GetSO_FIle.Dispose();
//		cmd_GetSO_FIle.Dispose();
//		con_GetSO_FIle = null;
//		cmd_GetSO_FIle = null;
//		
//		//**********************************************************************************************************************
//		string value1 = txtbx_att_ctn.Text;
//		string value2 = value1.Replace("http://192.168.1.210/SAPS/", "D:\\SAPS\\");
//		string value3 = value2;
//		//value1.Replace["http://192.168.1.210/SAPS/", "DocNo"]
//		//**********************************************************************************************************************        
//		//txtbx_att_so.Text
//		//Dim filename As System.String = txtbx_att_so.Text
//		System.String filename = value2;
//		//value3
//
//		if (CheckFile == "Y") {
//			//Response.Clear();
//		}
//
//		// set the http content type to "APPLICATION/OCTET-STREAM
//		//Response.ContentType = "APPLICATION/OCTET-STREAM";
//
//		// initialize the http content-disposition header to
//		// indicate a file attachment with the default filename
//		System.String disHeader = "Attachment; Filename=\"" + filename + "\"";
//		//Response.AppendHeader("Content-Disposition", disHeader);
//
//		// transfer the file byte-by-byte to the response object
//		System.IO.FileInfo fileToDownload = new System.IO.FileInfo(value2);
//		//Response.Flush();
//		//Response.WriteFile(fileToDownload.FullName);
//		//**********************************************************************************************************************
//		
//	}
//
//	protected void BTNLOAD3_Click(object sender, System.EventArgs e)
//	{
//		string CmdDownloadFile = null;
//		string CheckFile = null;
//		CmdDownloadFile = null;
//		CheckFile = null;
//		
//		SqlConnection con_GetSO_FIle = new SqlConnection(sqlconn2);
//		SqlCommand cmd_GetSO_FIle = new SqlCommand();
//		try {
//			cmd_GetSO_FIle.CommandText = "select * from TBL_FORM_SALES_STORE_PO_REGISTRATION where SalesOrderNo = '" + txtbx_so.Text + "'";
//			cmd_GetSO_FIle.Connection = con_GetSO_FIle;
//			con_GetSO_FIle.Open();
//			System.Data.SqlClient.SqlDataReader rd_GetSO_FIle = cmd_GetSO_FIle.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
//			if (rd_GetSO_FIle.Read())
//			{
//				txtbx_att_pcore.Text = rd_GetSO_FIle["FlagFileUpload3"].ToString();
//				CmdDownloadFile = rd_GetSO_FIle["FlagFileUpload3"].ToString();
//				CheckFile = "Y";
//			} 
//			else 
//			{
//				CheckFile = "N";
//				con_GetSO_FIle.Close();
//				return;
//			}
//		}
//		catch (Exception ex) 
//		{
//			con_GetSO_FIle.Close();
//			MessageBox.Show("Error Download File :" + ex.ToString());
//			return;
//		} 
//		finally 
//		{
//			con_GetSO_FIle.Close();
//		}
//		con_GetSO_FIle.Dispose();
//		cmd_GetSO_FIle.Dispose();
//		con_GetSO_FIle = null;
//		cmd_GetSO_FIle = null;
//		//**********************************************************************************************************************        
//		string value1 = txtbx_att_pcore.Text;
//		string value2 = value1.Replace("http://192.168.1.210/SAPS/", "D:\\SAPS\\");
//		string value3 = value2;
//		//value1.Replace["http://192.168.1.210/SAPS/", "DocNo"]
//		//**********************************************************************************************************************        
//		//txtbx_att_so.Text
//		//Dim filename As System.String = txtbx_att_so.Text
//		System.String filename = value2;
//		//value3
//
//		if (CheckFile == "Y")
//		{
//			//Response.Clear();
//		}
//
//		// set the http content type to "APPLICATION/OCTET-STREAM
//		//Response.ContentType = "APPLICATION/OCTET-STREAM";
//
//		// initialize the http content-disposition header to
//		// indicate a file attachment with the default filename
//		System.String disHeader = "Attachment; Filename=\"" + filename + "\"";
//		//Response.AppendHeader("Content-Disposition", disHeader);
//
//		// transfer the file byte-by-byte to the response object
//		System.IO.FileInfo fileToDownload = new System.IO.FileInfo(value2);
//		//Response.Flush();
//		//Response.WriteFile(fileToDownload.FullName);
//		//**********************************************************************************************************************
//		
//	}
//
//	protected void BTNLOAD4_Click(object sender, System.EventArgs e)
//	{
//		string CmdDownloadFile = null;
//		string CheckFile = null;
//		CmdDownloadFile = null;
//		CheckFile = null;
//		
//		SqlConnection con_GetSO_FIle = new SqlConnection(sqlconn2);
//		SqlCommand cmd_GetSO_FIle = new SqlCommand();
//		try 
//		{
//			cmd_GetSO_FIle.CommandText = "select * from TBL_FORM_SALES_STORE_PO_REGISTRATION where SalesOrderNo = '" + txtbx_so.Text + "'";
//			cmd_GetSO_FIle.Connection = con_GetSO_FIle;
//			con_GetSO_FIle.Open();
//			
//			SqlDataReader rd_GetSO_FIle = cmd_GetSO_FIle.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
//			if (rd_GetSO_FIle.Read())
//			{
//				txtbx_att_shipmark.Text = rd_GetSO_FIle["FlagFileUpload4"].ToString();
//				CmdDownloadFile = rd_GetSO_FIle["FlagFileUpload4"].ToString();
//				CheckFile = "Y";
//			} 
//			else 
//			{
//				CheckFile = "N";
//				con_GetSO_FIle.Close();
//				return;
//			}
//		} 
//		catch (Exception ex) 
//		{
//			con_GetSO_FIle.Close();
//			MessageBox.Show("Error Download File :" + ex.ToString());
//			return;
//		} 
//		finally 
//		{
//			con_GetSO_FIle.Close();
//		}
//		
//		con_GetSO_FIle.Dispose();
//		cmd_GetSO_FIle.Dispose();
//		con_GetSO_FIle = null;
//		cmd_GetSO_FIle = null;
//		//**********************************************************************************************************************        
//		string value1 = txtbx_att_shipmark.Text;
//		string value2 = value1.Replace("http://192.168.1.210/SAPS/", "D:\\SAPS\\");
//		string value3 = value2;
//		//value1.Replace["http://192.168.1.210/SAPS/", "DocNo"]
//		//**********************************************************************************************************************        
//		//txtbx_att_so.Text
//		//Dim filename As System.String = txtbx_att_so.Text
//		System.String filename = value2;
//		//value3
//
//		if (CheckFile == "Y") 
//		{
//			//Response.Clear();
//		}
//
//		// set the http content type to "APPLICATION/OCTET-STREAM
//		//Response.ContentType = "APPLICATION/OCTET-STREAM";
//
//		// initialize the http content-disposition header to
//		// indicate a file attachment with the default filename
//		System.String disHeader = "Attachment; Filename=\"" + filename + "\"";
//		//Response.AppendHeader("Content-Disposition", disHeader);
//
//		// transfer the file byte-by-byte to the response object
//		System.IO.FileInfo fileToDownload = new System.IO.FileInfo(value2);
//		//Response.Flush();
//		//Response.WriteFile(fileToDownload.FullName);
//		//**********************************************************************************************************************
//	}
//
//	protected void BTNLOAD5_Click(object sender, System.EventArgs e)
//	{
//		string CmdDownloadFile = null;
//		string CheckFile = null;
//		CmdDownloadFile = null;
//		CheckFile = null;
//		
//		SqlConnection con_GetSO_FIle = new SqlConnection(sqlconn2);
//		SqlCommand cmd_GetSO_FIle = new SqlCommand();
//		
//		try 
//		{
//			cmd_GetSO_FIle.CommandText = "select * from TBL_FORM_SALES_STORE_PO_REGISTRATION where SalesOrderNo = '" + txtbx_so.Text + "'";
//			cmd_GetSO_FIle.Connection = con_GetSO_FIle;
//			con_GetSO_FIle.Open();
//			SqlDataReader rd_GetSO_FIle = cmd_GetSO_FIle.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
//			
//			if (rd_GetSO_FIle.Read())
//			{
//				txtbx_att_other1.Text = rd_GetSO_FIle["FlagFileUpload5"].ToString();
//				CmdDownloadFile = rd_GetSO_FIle["FlagFileUpload5"].ToString();
//				CheckFile = "Y";
//			} 
//			else 
//			{
//				CheckFile = "N";
//				con_GetSO_FIle.Close();
//				return;
//			}
//		} 
//		catch (Exception ex) 
//		{
//			con_GetSO_FIle.Close();
//			MessageBox.Show("Error Download File :" + ex.ToString());
//			return;
//		} 
//		finally 
//		{
//			con_GetSO_FIle.Close();
//		}
//		
//		con_GetSO_FIle.Dispose();
//		cmd_GetSO_FIle.Dispose();
//		con_GetSO_FIle = null;
//		cmd_GetSO_FIle = null;
//		//**********************************************************************************************************************        
//		string value1 = txtbx_att_other1.Text;
//		string value2 = value1.Replace("http://192.168.1.210/SAPS/", "D:\\SAPS\\");
//		//Dim value3 As String = value1.Replace["http://192.168.1.210/SAPS/", "DocNo"]
//		//**********************************************************************************************************************        
//		//txtbx_att_so.Text
//		//Dim filename As System.String = txtbx_att_so.Text
//		System.String filename = value2;
//		//value3
//
//		if (CheckFile == "Y") 
//		{
//			//Response.Clear();
//		}
//
//		// set the http content type to "APPLICATION/OCTET-STREAM
//		
//		//Response.ContentType = "APPLICATION/OCTET-STREAM";
//
//		// initialize the http content-disposition header to
//		// indicate a file attachment with the default filename
//		System.String disHeader = "Attachment; Filename=\"" + filename + "\"";
//		//Response.AppendHeader("Content-Disposition", disHeader);
//
//		// transfer the file byte-by-byte to the response object
//		System.IO.FileInfo fileToDownload = new System.IO.FileInfo(value2);
//		//Response.Flush();
//		//Response.WriteFile(fileToDownload.FullName);
//		//**********************************************************************************************************************
//	}
//
////	protected void BTNLOAD6_Click(object sender, System.EventArgs e)
////	{
////		@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
////		string CmdDownloadFile = null;
////		string CheckFile = null;
////		CmdDownloadFile = null;
////		CheckFile = null;
////		@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
////		SqlConnection con_GetSO_FIle = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);
////		SqlCommand cmd_GetSO_FIle = new SqlCommand();
////		try {
////			cmd_GetSO_FIle.CommandText = "select * from TBL_FORM_SALES_STORE_PO_REGISTRATION where SalesOrderNo = '" + txtbx_so.Text + "'";
////			cmd_GetSO_FIle.Connection = con_GetSO_FIle;
////			con_GetSO_FIle.Open();
////			System.Data.SqlClient.SqlDataReader rd_GetSO_FIle = cmd_GetSO_FIle.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
////			if (rd_GetSO_FIle.Read) {
////				txt_att_other2.Text = rd_GetSO_FIle["FlagFileUpload6"];
////				CmdDownloadFile = rd_GetSO_FIle["FlagFileUpload6"];
////				CheckFile = "Y";
////			} else {
////				CheckFile = "N";
////				con_GetSO_FIle.Close();
////				return;
////			}
////		} catch (Exception ex) {
////			con_GetSO_FIle.Close();
////			Lbl_Message.Text = "Error Download File :" + ex.ToString;
////			return;
////		} finally {
////			con_GetSO_FIle.Close();
////		}
////		con_GetSO_FIle.Dispose();
////		cmd_GetSO_FIle.Dispose();
////		con_GetSO_FIle = null;
////		cmd_GetSO_FIle = null;
////		//**********************************************************************************************************************        
////		string value1 = txt_att_other2.Text;
////		string value2 = value1.Replace["http://192.168.1.210/SAPS/", "D:\\SAPS\\"];
////		string value3 = value2;
////		//value1.Replace["http://192.168.1.210/SAPS/", "DocNo"]
////		//**********************************************************************************************************************        
////		//txtbx_att_so.Text
////		//Dim filename As System.String = txtbx_att_so.Text
////		System.String filename = value2;
////		//value3
////
////		if (CheckFile == "Y"] {
////			Response.Clear();
////		}
////
////		// set the http content type to "APPLICATION/OCTET-STREAM
////		Response.ContentType = "APPLICATION/OCTET-STREAM";
////
////		// initialize the http content-disposition header to
////		// indicate a file attachment with the default filename
////		System.String disHeader = "Attachment; Filename=\"" + filename + "\"";
////		Response.AppendHeader["Content-Disposition", disHeader);
////
////		// transfer the file byte-by-byte to the response object
////		System.IO.FileInfo fileToDownload = new System.IO.FileInfo(value2);
////		Response.Flush();
////		Response.WriteFile(fileToDownload.FullName);
////		//**********************************************************************************************************************
////		@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
////	}
////
////	protected void BTNLOAD7_Click(object sender, System.EventArgs e)
////	{
////		@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
////		string CmdDownloadFile = null;
////		string CheckFile = null;
////		CmdDownloadFile = null;
////		CheckFile = null;
////		@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
////		SqlConnection con_GetSO_FIle = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);
////		SqlCommand cmd_GetSO_FIle = new SqlCommand();
////		try {
////			cmd_GetSO_FIle.CommandText = "select * from TBL_FORM_SALES_STORE_PO_REGISTRATION where SalesOrderNo = '" + txtbx_so.Text + "'";
////			cmd_GetSO_FIle.Connection = con_GetSO_FIle;
////			con_GetSO_FIle.Open();
////			System.Data.SqlClient.SqlDataReader rd_GetSO_FIle = cmd_GetSO_FIle.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
////			if (rd_GetSO_FIle.Read) {
////				txt_att_other3.Text = rd_GetSO_FIle["FlagFileUpload7"];
////				CmdDownloadFile = rd_GetSO_FIle["FlagFileUpload7"];
////				CheckFile = "Y";
////			} else {
////				CheckFile = "N";
////				con_GetSO_FIle.Close();
////				return;
////			}
////		} catch (Exception ex) {
////			con_GetSO_FIle.Close();
////			Lbl_Message.Text = "Error Download File :" + ex.ToString;
////			return;
////		} finally {
////			con_GetSO_FIle.Close();
////		}
////		con_GetSO_FIle.Dispose();
////		cmd_GetSO_FIle.Dispose();
////		con_GetSO_FIle = null;
////		cmd_GetSO_FIle = null;
////		//**********************************************************************************************************************        
////		string value1 = txt_att_other3.Text;
////		string value2 = value1.Replace["http://192.168.1.210/SAPS/", "D:\\SAPS\\"];
////		string value3 = value2;
////		//value1.Replace["http://192.168.1.210/SAPS/", "DocNo"]
////		//**********************************************************************************************************************        
////		//txtbx_att_so.Text
////		//Dim filename As System.String = txtbx_att_so.Text
////		System.String filename = value2;
////		//value3
////
////		if (CheckFile == "Y"] {
////			Response.Clear();
////		}
////
////		// set the http content type to "APPLICATION/OCTET-STREAM
////		Response.ContentType = "APPLICATION/OCTET-STREAM";
////
////		// initialize the http content-disposition header to
////		// indicate a file attachment with the default filename
////		System.String disHeader = "Attachment; Filename=\"" + filename + "\"";
////		Response.AppendHeader["Content-Disposition", disHeader);
////
////		// transfer the file byte-by-byte to the response object
////		System.IO.FileInfo fileToDownload = new System.IO.FileInfo(value2);
////		Response.Flush();
////		Response.WriteFile(fileToDownload.FullName);
////		}
//
//		protected void Btn_SO_Click(object sender, System.EventArgs e)
//		{
//			//Response.Redirect["form_sales_order_dept1.aspx"];
//		}
//		
//		
		void Btn_searchClick(object sender, EventArgs e)
		{
			//MessageBox.Show(frm_menu_system.email);
			
			if (txtbx_so.Text == null | txtbx_so.Text == string.Empty) 
			{
				MessageBox.Show("Please enter sales order number.");
				return;
			}
			
			SqlConnection SP_CheckSO_SqlCon = new SqlConnection(sqlconn);
			
			//string SP_CheckSO_QueryStr = "select * from TBL_FORM_SALES_STORE_PO_REGISTRATION where SalesOrderNo = '" + txtbx_so.Text + "'";
			SqlCommand SP_CheckSO_SqlCmd = new SqlCommand("select * from VIEW_SALES_ORDER_USER where SalesOrderNo = '" + txtbx_so.Text + "'", SP_CheckSO_SqlCon);
			
			try 
			{
				SP_CheckSO_SqlCon.Open();
				SqlDataReader dbr_CheckSO_LIST = SP_CheckSO_SqlCmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
				
				if (dbr_CheckSO_LIST.HasRows) 
				{
					while (dbr_CheckSO_LIST.Read()) 
					{
						try 
						{
							txtbx_so.Text = dbr_CheckSO_LIST["SalesOrderNo"].ToString();
							dtp_so_date.Value = Convert.ToDateTime(dbr_CheckSO_LIST["SODateTime"]);
							txtbx_cust.Text = dbr_CheckSO_LIST["Customer"].ToString();
							txtbx_cust_code.Text = " ";
	
							if (dbr_CheckSO_LIST["CustomerType"].ToString()== null) 
							{
								txtbx_cust_type.Text = " ";
							} 
							else 
							{
								txtbx_cust_type.Text = dbr_CheckSO_LIST["CustomerType"].ToString();
							}
	
							if (dbr_CheckSO_LIST["CustomerPO"].ToString()== null) 
							{
								txtbx_cust_po.Text = " ";
							}
							else 
							{
								txtbx_cust_po.Text = dbr_CheckSO_LIST["CustomerPO"].ToString();
							}
	
							txtbx_unit_ordered.Text = dbr_CheckSO_LIST["SalesOrder"].ToString();
							dtp_etd.Value = Convert.ToDateTime(dbr_CheckSO_LIST["ETDDateTime"]);
	
							if (dbr_CheckSO_LIST["SalesOrderInfo1"].ToString()== null) 
							{
								txtbx_info_1.Text = " ";
							} 
							else 
							
							{
								txtbx_info_1.Text = dbr_CheckSO_LIST["SalesOrderInfo1"].ToString();
							}
	
							if (dbr_CheckSO_LIST["SalesOrderInfo2"].ToString()== null) 
							{
								txtbx_info_2.Text = " ";
							} 
							else 
							{
								txtbx_info_2.Text = dbr_CheckSO_LIST["SalesOrderInfo2"].ToString();
							}
	
							if (dbr_CheckSO_LIST["SalesOrderInfo3"].ToString()== null) 
							{
								txtbx_info_3.Text = " ";
							} 
							else 
							{
								txtbx_info_3.Text = dbr_CheckSO_LIST["SalesOrderInfo3"].ToString();
							}
	
							if (dbr_CheckSO_LIST["FlagFileUpload"].ToString()== null) 
							{
								txtbx_att_so.Text = " ";
							} 
							else 
							{
								txtbx_att_so.Text = dbr_CheckSO_LIST["FlagFileUpload"].ToString();
							}
	
							if (dbr_CheckSO_LIST["FlagFileUpload2"].ToString()== null)
							{
								txtbx_att_ctn.Text = " ";
							} 
							else 
							{
								txtbx_att_ctn.Text = dbr_CheckSO_LIST["FlagFileUpload2"].ToString();
							}
	
							if (dbr_CheckSO_LIST["FlagFileUpload3"].ToString()== null) {
								txtbx_att_pcore.Text = " ";
							} 
							else 
							{
								txtbx_att_pcore.Text = dbr_CheckSO_LIST["FlagFileUpload3"].ToString();
							}
	
							if (dbr_CheckSO_LIST["FlagFileUpload4"].ToString()== null) {
								txtbx_att_shipmark.Text = " ";
							} 
							else 
							{
								txtbx_att_shipmark.Text = dbr_CheckSO_LIST["FlagFileUpload4"].ToString();
							}
	
							if (dbr_CheckSO_LIST["FlagFileUpload5"].ToString()== null) {
								txtbx_att_other1.Text = " ";
							} 
							else 
							{
								txtbx_att_other1.Text = dbr_CheckSO_LIST["FlagFileUpload5"].ToString();
							}
	
							if (dbr_CheckSO_LIST["FlagFileUpload6"].ToString()== null) {
								txtbx_att_other2.Text = " ";
							} 
							else 
							{
								txtbx_att_other2.Text = dbr_CheckSO_LIST["FlagFileUpload6"].ToString();
							}
	
							if (dbr_CheckSO_LIST["FlagFileUpload7"].ToString()== null) 
							{
								txtbx_att_other3.Text = " ";
							} 
							else 
							{
								txtbx_att_other3.Text = dbr_CheckSO_LIST["FlagFileUpload7"].ToString();
							}
							//###################################################################################################################################################################
						}
						catch (Exception CheckSO_ex1)
						{
							MessageBox.Show(CheckSO_ex1.ToString());
							return;
						}
					}
				}
				
				else
				{
					MessageBox.Show("Sales Order No not found");
					return;
				}
				dbr_CheckSO_LIST = null;
			} 
			catch (Exception CheckSO_ex2) 
			{
				MessageBox.Show(CheckSO_ex2.ToString());
				return;
			} 
			finally 
			{
				SP_CheckSO_SqlCon.Close();
				SP_CheckSO_SqlCon.Dispose();
			}
			
			SP_CheckSO_SqlCon = null;
			//SP_CheckSO_QueryStr = null;
			SP_CheckSO_SqlCmd = null;
			
			//BindData();
		}
		
		
		void Dt_gridCellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			if(dt_grid.SelectedRows.Count > 0) // make sure user select at least 1 row 
			{
			   	StrSalesOrderNo = dt_grid.SelectedRows[0].Cells[2].Value + string.Empty;
			   	Retrieve();
			}
		}
		
		void Btn_down_soClick(object sender, EventArgs e)
		{			
			string CmdDownloadFile = null;
			CmdDownloadFile = null;
			
			SqlConnection con_GetSO_FIle = new SqlConnection(sqlconn);
			SqlCommand cmd_GetSO_FIle = new SqlCommand();
			
			try 
			{
				cmd_GetSO_FIle.CommandText = "select * from TBL_SALES_ORDER_REGISTRATION where SalesOrderNo = '" + txtbx_so.Text + "'";
				cmd_GetSO_FIle.Connection = con_GetSO_FIle;
				con_GetSO_FIle.Open();
				System.Data.SqlClient.SqlDataReader rd_GetSO_FIle = cmd_GetSO_FIle.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
				
				if (rd_GetSO_FIle.Read())
				{
					txtbx_att_so.Text = rd_GetSO_FIle["FlagFileUpload"].ToString();
					CmdDownloadFile = rd_GetSO_FIle["FlagFileUpload"].ToString();
				} 
				else 
				{
					con_GetSO_FIle.Close();
					return;
				}
			} 
			catch (Exception ex) 
			{
				con_GetSO_FIle.Close();
				MessageBox.Show("Error Download File :" + ex.ToString() + ex.Message);
				return;
			} 
			finally 
			{
				con_GetSO_FIle.Close();
			}
			
			con_GetSO_FIle.Dispose();
			cmd_GetSO_FIle.Dispose();
			con_GetSO_FIle = null;
			cmd_GetSO_FIle = null;
			
		
			try
			{
				name = txtbx_att_so.Text.Substring(26);
				
				string sourcePath = @"B:\";
				string targetPath = @"C:\AX2020\doc";
					
				string sourceFile = System.IO.Path.Combine(sourcePath, name);
	            string destFile = System.IO.Path.Combine(targetPath, name);
	            
	            
	            
				string[] files = Directory.GetFiles(targetPath);

				foreach (string file in files)
				{
				   FileInfo fi = new FileInfo(file);
				   if (fi.LastAccessTime < DateTime.Now.AddMonths(-6))
				      fi.Delete();
				}
								          	            	
	            
		        ProcessStartInfo startInfo = new ProcessStartInfo();
			    startInfo.WindowStyle = ProcessWindowStyle.Hidden;
			    startInfo.FileName = @"..\..\dll\ax2020doc.bat";
			            
			    Process processTemp = new Process();
				processTemp.StartInfo = startInfo;
				processTemp.Start();
				        
			    File.Copy(sourceFile, destFile, true);
			            
			    ProcessStartInfo startInfo2 = new ProcessStartInfo();
			    startInfo2.WindowStyle = ProcessWindowStyle.Hidden;
			    startInfo2.FileName = @"..\..\dll\ax2020rev.bat";
				        
			    Process processTemp2 = new Process();
				processTemp2.StartInfo = startInfo2;
				processTemp2.Start();
				
				
				MessageBox.Show("OK. File is downloaded.");
				System.Diagnostics.Process.Start(destFile);
			
			}
			catch(Exception ex)
			{
				MessageBox.Show("Error : Sales Order Retrieval \n" + ex.Message + ex.ToString());
			}
			

			
		  
			SqlConnection conUpdate_Acknowledgement = new SqlConnection(sqlconn);
			SqlCommand cmdUpdate_Acknowledgement = new SqlCommand();
			
			try 
			{
				cmdUpdate_Acknowledgement.CommandText = "update TBL_SALES_ORDER_REGISTRATION_USER set flag1 = 'Y', userdate = '" + DateTime.Now.ToString("yyyy-MM-dd") + "' where username = '" + username.ToUpper() + "' and SalesOrderNo = '" + txtbx_so.Text + "'";
				cmdUpdate_Acknowledgement.Connection = conUpdate_Acknowledgement;
				conUpdate_Acknowledgement.Open();
				cmdUpdate_Acknowledgement.ExecuteNonQuery();
			} 
			catch (Exception ex) 
			{
				conUpdate_Acknowledgement.Close();
				MessageBox.Show("Error User Acknowledgement! " + ex.ToString() + ex.Message);
				return;
			} 
			finally 
			{
				conUpdate_Acknowledgement.Close();
			}
			conUpdate_Acknowledgement.Dispose();
			conUpdate_Acknowledgement = null;
			cmdUpdate_Acknowledgement = null;
			
			
			StockCheckJR = null;
			StockCheckFR = null;
			StockCheckGlue = null;
			StockCheckRibbon = null;
			StockCheckWL = null;
			
			
			StockCheckJR = "N";
			StockCheckFR = "N";
			StockCheckGlue = "N";
			StockCheckRibbon = "N";
			StockCheckWL = "N";
			
			
			SqlConnection SP_CheckStockType_Glue_SqlCon = new SqlConnection(sqlconn);
			string SP_CheckStockType_Glue_QueryStr = "select * from TBL_SALES_ORDER_REGISTRATION_DETAIL where tno = '" + txtbx_so.Text.ToUpper() + "' and tstk like 'EX%' or tno = '" + txtbx_so.Text.ToUpper() + "' and tstk like 'WG%'";
			
			SqlCommand SP_CheckStockType_Glue_SqlCmd = new SqlCommand(SP_CheckStockType_Glue_QueryStr, SP_CheckStockType_Glue_SqlCon);
			try 
			{
				SP_CheckStockType_Glue_SqlCon.Open();
				System.Data.SqlClient.SqlDataReader dbr_CheckStockType_Glue_LIST = SP_CheckStockType_Glue_SqlCmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
				
				if (dbr_CheckStockType_Glue_LIST.HasRows)
				{
					while (dbr_CheckStockType_Glue_LIST.Read()) 
					{
						try 
						{
							StockCheckGlue = "Y";
							
						} 
						catch (Exception CheckStockType_Glue_ex1) 
						{
							MessageBox.Show(CheckStockType_Glue_ex1.ToString() + CheckStockType_Glue_ex1.Message);
							return;
						}
					}
				}
				dbr_CheckStockType_Glue_LIST = null;
			} 
			catch (Exception CheckStockType_Glue_ex2) 
			{
				MessageBox.Show(CheckStockType_Glue_ex2.ToString() + CheckStockType_Glue_ex2.Message);
				return;
			} 
			finally 
			{
				SP_CheckStockType_Glue_SqlCon.Close();
				SP_CheckStockType_Glue_SqlCon.Dispose();
			}
			
			SP_CheckStockType_Glue_SqlCon = null;
			SP_CheckStockType_Glue_QueryStr = null;
			SP_CheckStockType_Glue_SqlCmd = null;
			//-------------------------------------------------------------------------------------------------------------------------------------------------------------------
			
			SqlConnection SP_CheckStockType_JR_SqlCon = new SqlConnection(sqlconn);
			string SP_CheckStockType_JR_QueryStr = "select * from TBL_SALES_ORDER_REGISTRATION_DETAIL where tno = '" + txtbx_so.Text.ToUpper() + "' and tstk like 'WJ%'";
			SqlCommand SP_CheckStockType_JR_SqlCmd = new SqlCommand(SP_CheckStockType_JR_QueryStr, SP_CheckStockType_JR_SqlCon);
			try 
			{
				SP_CheckStockType_JR_SqlCon.Open();
				SqlDataReader dbr_CheckStockType_JR_LIST = SP_CheckStockType_JR_SqlCmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
				
				if (dbr_CheckStockType_JR_LIST.HasRows) 
				{
					while (dbr_CheckStockType_JR_LIST.Read()) 
					{
						try 
						{
							//###################################################################################################################################################################
							StockCheckJR = "Y";
							//###################################################################################################################################################################
						} 
						catch (Exception CheckStockType_JR_ex1) 
						{
							MessageBox.Show(CheckStockType_JR_ex1.ToString());
							return;
						}
					}
				}
				dbr_CheckStockType_JR_LIST = null;
			} 
			catch (Exception CheckStockType_JR_ex2) 
			{
				MessageBox.Show(CheckStockType_JR_ex2.ToString());
				return;
			} 
			finally 
			{
				SP_CheckStockType_JR_SqlCon.Close();
				SP_CheckStockType_JR_SqlCon.Dispose();
			}
			
			SP_CheckStockType_JR_SqlCon = null;
			SP_CheckStockType_JR_QueryStr = null;
			SP_CheckStockType_JR_SqlCmd = null;
			//-------------------------------------------------------------------------------------------------------------------------------------------------------------------
			
			SqlConnection SP_CheckStockType_LR_SqlCon = new SqlConnection(sqlconn);
			string SP_CheckStockType_LR_QueryStr = "select * from TBL_SALES_ORDER_REGISTRATION_DETAIL where tno = '" + txtbx_so.Text.ToUpper() + "' and tstk like 'WL%'";
			SqlCommand SP_CheckStockType_LR_SqlCmd = new SqlCommand(SP_CheckStockType_LR_QueryStr, SP_CheckStockType_LR_SqlCon);
			
			try 
			{
				SP_CheckStockType_LR_SqlCon.Open();
				System.Data.SqlClient.SqlDataReader dbr_CheckStockType_LR_LIST = SP_CheckStockType_LR_SqlCmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
				if (dbr_CheckStockType_LR_LIST.HasRows) 
				{
					while (dbr_CheckStockType_LR_LIST.Read()) 
					{
						try 
						{
							//###################################################################################################################################################################
							StockCheckWL = "Y";
							//###################################################################################################################################################################
						} 
						catch (Exception CheckStockType_LR_ex1) 
						{
							MessageBox.Show(CheckStockType_LR_ex1.ToString());
							return;
						}
					}
				}
				dbr_CheckStockType_LR_LIST = null;
			} 
			catch (Exception CheckStockType_LR_ex2) 
			{
				MessageBox.Show(CheckStockType_LR_ex2.ToString());
				return;
			} 
			finally 
			{
				SP_CheckStockType_LR_SqlCon.Close();
				SP_CheckStockType_LR_SqlCon.Dispose();
			}
			
			SP_CheckStockType_LR_SqlCon = null;
			SP_CheckStockType_LR_QueryStr = null;
			SP_CheckStockType_LR_SqlCmd = null;
			
			//-------------------------------------------------------------------------------------------------------------------------------------------------------------------
			SqlConnection SP_CheckStockType_Ribbon_SqlCon = new SqlConnection(sqlconn);
			string SP_CheckStockType_Ribbon_QueryStr = "select * from TBL_SALES_ORDER_REGISTRATION_DETAIL where tno = '" + txtbx_so.Text.ToUpper() + "' and tdesc1 like '%ribbon%' or tno = '" + txtbx_so.Text.ToUpper() + "' and tdesc1 like '%ribbon%'";
			SqlCommand SP_CheckStockType_Ribbon_SqlCmd = new System.Data.SqlClient.SqlCommand(SP_CheckStockType_Ribbon_QueryStr, SP_CheckStockType_Ribbon_SqlCon);
			try 
			{
				SP_CheckStockType_Ribbon_SqlCon.Open();
				SqlDataReader dbr_CheckStockType_Ribbon_LIST = SP_CheckStockType_Ribbon_SqlCmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
				if (dbr_CheckStockType_Ribbon_LIST.HasRows) 
				{
					while (dbr_CheckStockType_Ribbon_LIST.Read()) 
					{
						try 
						{
							//###################################################################################################################################################################
							StockCheckRibbon = "Y";
							//###################################################################################################################################################################
						} 
						catch (Exception CheckStockType_Ribbon_ex1) 
						{
							MessageBox.Show(CheckStockType_Ribbon_ex1.ToString());
							return;
						}
					}
				}
				dbr_CheckStockType_Ribbon_LIST = null;
			} 
			catch (Exception CheckStockType_Ribbon_ex2) 
			{
				MessageBox.Show(CheckStockType_Ribbon_ex2.ToString());
				return;
			} 
			finally 
			{
				SP_CheckStockType_Ribbon_SqlCon.Close();
				SP_CheckStockType_Ribbon_SqlCon.Dispose();
			}
			
			SP_CheckStockType_Ribbon_SqlCon = null;
			SP_CheckStockType_Ribbon_QueryStr = null;
			SP_CheckStockType_Ribbon_SqlCmd = null;
			
			//-------------------------------------------------------------------------------------------------------------------------------------------------------------------
			SqlConnection SP_CheckStockType_OPPT_SqlCon = new SqlConnection(sqlconn);
			string SP_CheckStockType_OPPT_QueryStr = "select * from TBL_SALES_ORDER_REGISTRATION_DETAIL where tno = '" + txtbx_so.Text.ToUpper() + "' and tdesc1 like '%OPPT%' or tno = '" + txtbx_so.Text.ToUpper() + "' and tdesc1 like '%OPPT%'";
			SqlCommand SP_CheckStockType_OPPT_SqlCmd = new SqlCommand(SP_CheckStockType_OPPT_QueryStr, SP_CheckStockType_OPPT_SqlCon);
			
			try 
			{
				SP_CheckStockType_OPPT_SqlCon.Open();
				System.Data.SqlClient.SqlDataReader dbr_CheckStockType_OPPT_LIST = SP_CheckStockType_OPPT_SqlCmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
				if (dbr_CheckStockType_OPPT_LIST.HasRows) 
				{
					while (dbr_CheckStockType_OPPT_LIST.Read()) 
					{
						try 
						{
							//###################################################################################################################################################################
							StockCheckFR = "Y";
							//###################################################################################################################################################################
						} 
						catch (Exception CheckStockType_OPPT_ex1) 
						{
							MessageBox.Show(CheckStockType_OPPT_ex1.ToString());
							return;
						}
					}
				}
				dbr_CheckStockType_OPPT_LIST = null;
			} 
			catch (Exception CheckStockType_OPPT_ex2) 
			{
				MessageBox.Show(CheckStockType_OPPT_ex2.ToString());
				return;
			} 
			finally 
			{
				SP_CheckStockType_OPPT_SqlCon.Close();
				SP_CheckStockType_OPPT_SqlCon.Dispose();
			}
			
			SP_CheckStockType_OPPT_SqlCon = null;
			SP_CheckStockType_OPPT_QueryStr = null;
			SP_CheckStockType_OPPT_SqlCmd = null;
			
			
		//------------------------------------------------------------------------------------------
		// BEGIN EMAIL NOTIFICATION
		//------------------------------------------------------------------------------------------
		string FromName = "SAPS E-SERVICE";
		string FromEmail = "sbti.ax2020@gmail.com";
		string Subject = "SAPS SO READ : " + txtbx_so.Text.ToUpper();

		SmtpClient smtp = new SmtpClient();
		smtp.Host = "smtp.gmail.com";
		smtp.Credentials = new NetworkCredential("sbti.ax2020@gmail.com", "wsc4143pk");
		smtp.EnableSsl = true;
		smtp.Port = 587;

		MailMessage msg = new MailMessage();
		
		msg.From = new MailAddress(FromEmail, FromName);
		
		msg.To.Add(new MailAddress("it-4@sbgroup.com.my", "Afiqah"));
		
//		//---> msg.To.Add(New MailAddress("samuel@sbgroup.com.my", "Samuel"))
		msg.To.Add(new MailAddress("cath@sbgroup.com.my", "Catherine Teh"));

		if (txtbx_cust_type.Text == "LC") 
		{
			//--> Customer Service Local
			msg.To.Add(new MailAddress("kelly@sbgroup.com.my", "Kelly Chan"));
			msg.To.Add(new MailAddress("salesco-1@sbgroup.com.my", "Han Chok Min Jie"));
			msg.To.Add(new MailAddress("salesco-1@sbgroup.com.my", "SalesCo1"));
			msg.To.Add(new MailAddress("salesco-3@sbgroup.com.my", "SalesCo"));

			if (StockCheckGlue == "N") 
			{
				//--> Store1806
				//msg.To.Add(New MailAddress("logistic-8@sbgroup.com.my", "Fan Phong Lin"))
				msg.To.Add(new MailAddress("ST963@sbgroup.com.my", "Suriani"));
				msg.To.Add(new MailAddress("store-2@sbgroup.com.my", "Kalyani"));
				msg.To.Add(new MailAddress("store-9@sbgroup.com.my", "Chin Chin"));
				msg.To.Add(new MailAddress("logistic-5@sbgroup.com.my", "Arveenah"));
				msg.To.Add(new MailAddress("cyyong@sbgroup.com.my", "CY Yong"));
				msg.To.Add(new MailAddress("sosiaw@sbgroup.com.my", "SO Siaw"));
			} 
			else 
			{
				//--> Logistic
				msg.To.Add(new MailAddress("logistic-5@sbgroup.com.my", "Arveenah"));
				msg.To.Add(new MailAddress("store-4@sbgroup.com.my", "Shuairah "));
				msg.To.Add(new MailAddress("store-7@sbgroup.com.my", "Hazlinda"));
				msg.To.Add(new MailAddress("store-8@sbgroup.com.my", "Wong Wen Kuang"));
				msg.To.Add(new MailAddress("logistic-10@sbgroup.com.my", "Jenny"));
				msg.To.Add(new MailAddress("cyyong@sbgroup.com.my", "CY Yong"));
				msg.To.Add(new MailAddress("sosiaw@sbgroup.com.my", "SO Siaw"));
			}
		} 
		else if (txtbx_cust_type.Text == "SG") 
		{
			//--> Customer Service Local
			msg.To.Add(new MailAddress("kelly@sbgroup.com.my", "Kelly Chan"));
			msg.To.Add(new MailAddress("salesco-1@sbgroup.com.my", "Han Chok Min Jie"));
			msg.To.Add(new MailAddress("salesco-1@sbgroup.com.my", "SalesCo1"));
			msg.To.Add(new MailAddress("salesco-3@sbgroup.com.my", "SalesCo"));

			//--> Store1806
			//msg.To.Add(New MailAddress("logistic-8@sbgroup.com.my", "Fan Phong Lin"))
		 	msg.To.Add(new MailAddress("ST963@sbgroup.com.my", "Suriani"));
			msg.To.Add(new MailAddress("store-2@sbgroup.com.my", "Kalyani"));
			msg.To.Add(new MailAddress("store-9@sbgroup.com.my", "Chin Chin"));
			msg.To.Add(new MailAddress("logistic-5@sbgroup.com.my", "Arveenah"));

			//--> Customer Service Export
			msg.To.Add(new MailAddress("exportsc-1@sbgroup.com.my", "Michelle Kang"));
			msg.To.Add(new MailAddress("michelle.kang@sbgroup.com.my", "Daphiny Hoo Poe Yee"));

			//--> Logistic
			msg.To.Add(new MailAddress("logistic-5@sbgroup.com.my", "Arveenah"));
			msg.To.Add(new MailAddress("store-4@sbgroup.com.my", "Shuairah "));
			msg.To.Add(new MailAddress("store-7@sbgroup.com.my", "Hazlinda"));
			msg.To.Add(new MailAddress("store-8@sbgroup.com.my", "Wong Wen Kuang"));
			msg.To.Add(new MailAddress("logistic-10@sbgroup.com.my", "Jenny"));
			msg.To.Add(new MailAddress("cyyong@sbgroup.com.my", "CY Yong"));
			msg.To.Add(new MailAddress("sosiaw@sbgroup.com.my", "SO Siaw"));
		} 
		else if (txtbx_cust_type.Text == "FC") 
		{
			//--> Customer Service Export
			msg.To.Add(new MailAddress("salesco-1@sbgroup.com.my", "SalesCo1"));
			msg.To.Add(new MailAddress("exportsc-1@sbgroup.com.my", "Michelle Kang"));
			msg.To.Add(new MailAddress("michelle.kang@sbgroup.com.my", "Daphiny Hoo Poe Yee"));

			//--> Logistic
			msg.To.Add(new MailAddress("logistic-5@sbgroup.com.my", "Arveenah"));
			msg.To.Add(new MailAddress("store-4@sbgroup.com.my", "Shuairah "));
			msg.To.Add(new MailAddress("store-7@sbgroup.com.my", "Hazlinda"));
			msg.To.Add(new MailAddress("store-8@sbgroup.com.my", "Wong Wen Kuang"));
			msg.To.Add(new MailAddress("logistic-10@sbgroup.com.my", "Jenny"));
			msg.To.Add(new MailAddress("cyyong@sbgroup.com.my", "CY Yong"));
			msg.To.Add(new MailAddress("sosiaw@sbgroup.com.my", "SO Siaw"));
		} 
		else 
		{
			//--> Customer Service Local
			msg.To.Add(new MailAddress("kelly@sbgroup.com.my", "Kelly Chan"));
			msg.To.Add(new MailAddress("salesco-1@sbgroup.com.my", "Han Chok Min Jie"));
			msg.To.Add(new MailAddress("salesco-1@sbgroup.com.my", "SalesCo1"));
			msg.To.Add(new MailAddress("salesco-3@sbgroup.com.my", "SalesCo"));

			//--> Store1806
			//msg.To.Add(New MailAddress("logistic-8@sbgroup.com.my", "Fan Phong Lin"))
			msg.To.Add(new MailAddress("ST963@sbgroup.com.my", "Suriani"));
			msg.To.Add(new MailAddress("store-2@sbgroup.com.my", "Kalyani "));
			msg.To.Add(new MailAddress("store-9@sbgroup.com.my", "Chin Chin"));
			msg.To.Add(new MailAddress("logistic-5@sbgroup.com.my", "Arveenah"));

			//--> Customer Service Export
			msg.To.Add(new MailAddress("exportsc-1@sbgroup.com.my", "Michelle Kang"));
			msg.To.Add(new MailAddress("michelle.kang@sbgroup.com.my", "Daphiny Hoo Poe Yee"));

			//--> Logistic
			msg.To.Add(new MailAddress("logistic-5@sbgroup.com.my", "Arveenah"));
			msg.To.Add(new MailAddress("store-4@sbgroup.com.my", "Shuairah "));
			msg.To.Add(new MailAddress("store-7@sbgroup.com.my", "Hazlinda"));
			msg.To.Add(new MailAddress("store-8@sbgroup.com.my", "Wong Wen Kuang"));
			msg.To.Add(new MailAddress("logistic-10@sbgroup.com.my", "Jenny"));
			msg.To.Add(new MailAddress("cyyong@sbgroup.com.my", "CY Yong"));
			msg.To.Add(new MailAddress("sosiaw@sbgroup.com.my", "SO Siaw"));
		}

		if (StockCheckGlue == "Y") 
		{
			//--> Glue
			//msg.To.Add(New MailAddress("stacy@sbgroup.com.my", "Stacy Chooi"))
			msg.To.Add(new MailAddress("co-3@sbgroup.com.my", "Elmer"));
			msg.To.Add(new MailAddress("haiqal.bakar@sbgroup.com.my", "Haiqal"));
			msg.To.Add(new MailAddress("st952@sbgroup.com.my", "Muhammad Rudzaimie"));
			//msg.To.Add(New MailAddress("ystoh@sbgroup.com.my", "Mr TYS"))
		} 
		else if (StockCheckRibbon == "Y") 
		{
			//--> Ribbon
			msg.To.Add(new MailAddress("stacy@sbgroup.com.my", "Stacy Chooi"));
			//msg.To.Add(New MailAddress("production-4@sbgroup.com.my", "Jothi"))
		} 
		else if (StockCheckRibbon == "FR" | StockCheckWL == "Y") 
		{
			//msg.To.Add(New MailAddress("planner-3@sbgroup.com.my", "Simon Yew Chee Wang"))
			msg.To.Add(new MailAddress("planner-5@sbgroup.com.my", "Jess Ng"));
			msg.To.Add(new MailAddress("yap@sbgroup.com.my", "Yap Hong Kee "));
			msg.To.Add(new MailAddress("converting-2@sbgroup.com.my", "Claudia"));
		} 
		else if (StockCheckJR == "Y") 
		{
			//--> Production
			//msg.To.Add(New MailAddress("planner-3@sbgroup.com.my", "Simon Yew Chee Wang"))
			msg.To.Add(new MailAddress("yap@sbgroup.com.my", "Yap Hong Kee "));
		} 
		else 
		{
			//msg.To.Add(New MailAddress("planner-3@sbgroup.com.my", "Simon Yew Chee Wang"))
			msg.To.Add(new MailAddress("planner-5@sbgroup.com.my", "Jess Ng"));
			msg.To.Add(new MailAddress("yap@sbgroup.com.my", "Yap Hong Kee "));
			msg.To.Add(new MailAddress("converting-2@sbgroup.com.my", "Claudia"));
		}
		
		string EmailUserName = null;
		string EmailUserDept = null;
		
		EmailUserName = null;
		EmailUserDept = null;

		SqlConnection con_Check_Recepient = new SqlConnection(sqlconn);
		SqlCommand cmd_Check_Recepient = new SqlCommand();
		
		try
		{
			cmd_Check_Recepient.CommandText = "Select * from TBL_ADMIN_USER_ACCESS where sysusername ='" + username.ToUpper() + "'";
			cmd_Check_Recepient.Connection = con_Check_Recepient;
			con_Check_Recepient.Open();
			
			SqlDataReader rd_Check_Recepient = cmd_Check_Recepient.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
			
			if (rd_Check_Recepient.HasRows) 
			{
				if (rd_Check_Recepient.Read()) 
				{
					EmailUserName = rd_Check_Recepient["sysstaffname"].ToString();
					EmailUserDept = rd_Check_Recepient["sysdept"].ToString();
				}
			}
			} 
			catch (Exception ex) 
			{
				con_Check_Recepient.Close();
				
			} 
			finally 
			{
				con_Check_Recepient.Close();
			}
			
			con_Check_Recepient.Dispose();
			cmd_Check_Recepient.Dispose();
			con_Check_Recepient = null;
			cmd_Check_Recepient = null;
			
			msg.Subject = Subject;
			msg.Body = "Dear All, \n\nPlease be informed that " + EmailUserName + " has read sales order ETD and will be processed it in the production and/or delivery \n\nCustomer      : " + txtbx_cust.Text.ToUpper() + "\n\nS/O Number : " + txtbx_so.Text.ToUpper() + "\n\n\n\nInfo 1 : " + txtbx_info_1.Text.ToUpper() + "\n\nInfo 2 : " + txtbx_info_2.Text.ToUpper() + "\n\nInfo 3 : " + txtbx_info_3.Text.ToUpper() + "\n\n\n\nThank you." + "\n\nSAPS SOSystem Notification.";
			
			try
			{
				smtp.Send(msg);
			} 
			catch (FormatException ex) 
			{
				MessageBox.Show("Format Exception: " + ex.Message);
			} 
			catch (SmtpException ex) 
			{
				MessageBox.Show("SMTP Exception:  " + ex.Message);
			} 
			catch (Exception ex) 
			{
				MessageBox.Show("General Exception:  " + ex.Message);
			}
			
			ClearVariable();
			
			
			
		}
		
		void Frm_sales_order_downloadLoad(object sender, EventArgs e)
		{
			BindData();	
			
		}
		
	}
}
