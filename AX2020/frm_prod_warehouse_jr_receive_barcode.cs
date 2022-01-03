/*
 * Created by SharpDevelop.
 * User: ax2020-2
 * Date: 2/21/2017
 * Time: 9:06 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;									
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Data;						
using System.Collections.Generic;		/***header untuk jalankan akktiviti/jenis coding dalam c#***/
using System.ComponentModel;			
using System.IO.Ports;
using System.Text;
using CommonFunction;
using CommonLibrary;
using CommonControl.Functions;
using System.Drawing.Drawing2D;
using System.Data.Sql;
using System.IO;
using fyiReporting.RdlViewer;
using fyiReporting;

namespace AX2020
{
	
	public partial class frm_prod_warehouse_jr_receive_barcode : Form
	{
		//public static string sqlconn = "Server=AX-UAT; Password=sbax2020sbg; User ID=sbax2020; Initial Catalog=SBG_AX_2020; Integrated Security=false";
		//public static string sqlconn = "Server=AX-UAT; Password=sbax2020sbg; User ID=sbax2020; Initial Catalog=SBG_AX_2020; Integrated Security=false";
		//public static string sqlconn = "Server=AX-UAT; Password=sbax2020sbg; User ID=sbax2020; Initial Catalog=SBG_AX_2020; Integrated Security=false";
		public static string sqlconn = "Server=AX-UAT; Password=sbax2020sbg; User ID=sbax2020; Initial Catalog=MyProductionTrack; Integrated Security=false";



		public static string Sqlconn = "DSN=eb9gf;Port=2138;Uid=dba;Pwd=sql";
		string barcode_no, username;
		bool clickSearch = false;
		//bool clicksave = false;	
		string lot_no;
		public frm_prod_warehouse_jr_receive_barcode()
		{
			InitializeComponent();
			DataGrid();
			DataGrid2();
			//DataGrid2();		
			username = frm_menu_system.userName; 
			lbl_username.Text = "User : " + username;			
		}
		
				
		void Btn_confirmedClick(object sender, System.EventArgs e)
		{
			
			clickSearch = true;
			if (txtbx_barcode.Text == null && txtbx_shipmark.Text == null) // && txtbx_shipmark.Text == null || txtbx_shipmark.Text == string.Empty)
			{			
				MessageBox.Show("BARCODE OR SHIPPING MARK CAN'T NULL" );//+ ex.Message + ex.ToString());//Lbl_Message.Text = "Error? SO?";
				return;
			}
										
			if (txtbx_barcode.Text == string.Empty && txtbx_shipmark.Text == string.Empty) 
				{
				MessageBox.Show("BARCODE OR SHIPPING MARK CAN'T EMPTY");//( + ex.Message + ex.ToString());//Lbl_Message.Text = "Error? SO Line?";
					return;
				}
			
			
			SqlConnection con_Check_Duplicate_JO = new SqlConnection(sqlconn);
				SqlCommand cmd = new SqlCommand();
								
								
				try {
						cmd.CommandText = "select * from TBL_AX2020_COATING_RECEIVE_STOCK_WAREHOUSE where JRBarcode = '" + txtbx_barcode.Text.ToUpper() + "' or TrxShipMark = '"  + txtbx_shipmark.Text.ToUpper() + "'";
						cmd.Connection = con_Check_Duplicate_JO;
						con_Check_Duplicate_JO.Open();
						SqlDataReader rd_Check_Duplicate_JO = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
					
						if (rd_Check_Duplicate_JO.Read())
								{
									if (rd_Check_Duplicate_JO.HasRows) 
										{
											MessageBox.Show("Duplicate Shipping Mark or Barcode");//Lbl_Message.Text = "Error 1.0 : Duplicate JO! ";
											return;
										}
									
								}
						else
						{
							MessageBox.Show("CAN DO RECEIVING");
						}
						
					} 
					catch (Exception ex) 
						{
							con_Check_Duplicate_JO.Close();
							MessageBox.Show("Duplicate Shipping Mark or Barcode" + ex.ToString() + ex.Message);
							return;
						} 
					
					finally 
						{
							con_Check_Duplicate_JO.Close();
						}
								
							con_Check_Duplicate_JO.Dispose();
							cmd.Dispose();
							con_Check_Duplicate_JO = null;
							cmd = null;
							
							getdata();
		}
		
		
		void getdata()
		{
							
			SqlConnection con_SP2 = new SqlConnection(sqlconn);
			SqlCommand cmd_SP2 = new SqlCommand();
			
			try 
			{
				cmd_SP2.CommandText =  "select * from TBL_AX2020_COATING_WAREHOUSE_NOT_RECEIVE_STOCK_WAREHOUSE where TrxShipMark = '" + txtbx_shipmark.Text.ToUpper() + "' or JRBarcode = '"  + txtbx_barcode.Text.ToUpper() + "'";
				cmd_SP2.Connection = con_SP2;
				con_SP2.Open();
				SqlDataReader rd_SP2 = cmd_SP2.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
				
				if (rd_SP2.Read())
				{
				
					
						txtbx_barcode.Text = rd_SP2["JRBarcode"].ToString();
						txtbx_shipmark.Text = rd_SP2["TrxShipMark"].ToString();
						txtbx_shipmark2.Text = rd_SP2["TrxShipMark"].ToString();
						txtbx_customer.Text = rd_SP2["TrxLblCustomer"].ToString(); //+"  "+ rd_SP2["JOSTOCKMICRON"].ToString() + "MICRON    " + rd_SP2["JOSTOCKWIDTH"].ToString() + "MM   "+ "X " + rd_SP2["JOSTOCKLENGTH"].ToString() + "M"  ;
						txtbx_code.Text = rd_SP2["TrxJoStkCode"].ToString();
						txtbx_micron.Text = rd_SP2["TrxJoThickness"].ToString();
						txtbx_color.Text = rd_SP2["TrxJoColor"].ToString();
						txtbx_width.Text = rd_SP2["TrxJoWidth"].ToString();
						txtbx_length.Text = rd_SP2["TrxTotalLength"].ToString();
						txtbx_lotno.Text = rd_SP2["TrxLotNo"].ToString();
						//TxtBx_JRColor1.Text = rd_SP2["JOSTOCKCOLOR"].ToString();
					
					
//--------------------------------------------------------------------------------------------			
				} 
				else 
				{
					MessageBox.Show("Error Edit : Cannot find Shipping Mark!");
					return;
				}
			} 
			catch (Exception ex) 
			{
				MessageBox.Show("Error Edit : Cannot load DB!" + ex.Message + ex.ToString());
				return;
			} 
			finally 
			{
				con_SP2.Close();
			}
			
			con_SP2.Dispose();
			con_SP2 = null;
			cmd_SP2 = null;
		}
		
void DataGrid2()
		{
			SqlConnection con_SP3 = new SqlConnection(sqlconn);
			SqlCommand cmd_SP3 = new SqlCommand();
				
			try 
			{
				cmd_SP3.CommandText = @"SELECT JRBarcode, TrxShipMark, TrxLblCustomer, TrxJoStkCode, TrxJoThickness, TrxJoColor, TrxJoWidth,TrxTotalLength, TrxLotNo  FROM TBL_AX2020_COATING_RECEIVE_STOCK_WAREHOUSE";
				cmd_SP3.Connection = con_SP3;
				con_SP3.Open();
				SqlDataAdapter dataadapter = new SqlDataAdapter(cmd_SP3);

			
								 
			    //DataSet ds = new DataSet();
			    DataTable ds2 = new DataTable();
			    dataadapter.Fill(ds2);
				 
  				this.dataGridViewReceive.DataSource = AutoNumberedTable(ds2);

			}
			catch(Exception ex)
			{
				MessageBox.Show("Error" + ex.Message + ex.ToString());
				return;
			}
			finally
			{
				
				//TrxShipMark, TrxLblCustomer, TrxJoStkCode, TrxJoThickness, TrxJoColor, TrxJoWidth, TrxTotalLength	
				con_SP3.Close();
				dataGridViewReceive.Columns[0].Name = "No";
	            dataGridViewReceive.Columns[0].Width = 35;
	            dataGridViewReceive.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
	            dataGridViewReceive.Columns[1].HeaderText = "Barcode";
	            dataGridViewReceive.Columns[1].Width = 110;
	            dataGridViewReceive.Columns[2].HeaderText = "Shipping Mark";
	            dataGridViewReceive.Columns[2].Width = 110;
	            dataGridViewReceive.Columns[3].HeaderText = "Customer";
	            dataGridViewReceive.Columns[3].Width = 80;
	            dataGridViewReceive.Columns[4].HeaderText = "Code";
	            dataGridViewReceive.Columns[4].Width = 150;
	            dataGridViewReceive.Columns[5].HeaderText = "Micron";
	            dataGridViewReceive.Columns[5].Width = 150;
	            dataGridViewReceive.Columns[6].HeaderText = "Color";
				dataGridViewReceive.Columns[6].Width = 200;            
				dataGridViewReceive.Columns[7].HeaderText = "Width";
				dataGridViewReceive.Columns[7].Width = 100;
	            dataGridViewReceive.Columns[8].HeaderText = "Length"; 
	            dataGridViewReceive.Columns[8].Width = 100;
	            dataGridViewReceive.Columns[9].HeaderText = "Lot No"; 
	            dataGridViewReceive.Columns[9].Width = 100;
					
			}
			
			con_SP3.Dispose();
			con_SP3 = null;
			cmd_SP3 = null;	
		}
		
		
		private DataTable AutoNumberedTable2(DataTable SourceTable)
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
		
		
		
		void DataGridViewReceiveCellClick(object sender, DataGridViewCellEventArgs e)
		{
			if(dataGridViewWarehouse.SelectedRows.Count > 0) // make sure user select at least 1 row 
			{
			   txtbx_barcode.Text = dataGridViewReceive.SelectedRows[0].Cells[1].Value + string.Empty;
			   	txtbx_shipmark2.Text = dataGridViewReceive.SelectedRows[0].Cells[2].Value + string.Empty;
			   	//txtbx_shipmark2.Text = dataGridViewWarehouse.SelectedRows[0].Cells[2].Value + string.Empty;
			   	txtbx_customer.Text = dataGridViewReceive.SelectedRows[0].Cells[3].Value + string.Empty;
			   	txtbx_code.Text = dataGridViewReceive.SelectedRows[0].Cells[4].Value + string.Empty;
			   	txtbx_micron.Text = dataGridViewReceive.SelectedRows[0].Cells[5].Value + string.Empty;
			   	txtbx_color.Text = dataGridViewReceive.SelectedRows[0].Cells[6].Value + string.Empty;
			   	txtbx_width.Text = dataGridViewReceive.SelectedRows[0].Cells[7].Value + string.Empty;
			   	txtbx_length.Text = dataGridViewReceive.SelectedRows[0].Cells[8].Value + string.Empty;
			   	txtbx_lotno.Text = dataGridViewReceive.SelectedRows[0].Cells[9].Value + string.Empty;
		   			   //	Code	LotNo	Customer	S.Mark	Color	Micron	Width	Length
		   			   
		   			   txtbx_shipmark.Text = txtbx_shipmark2.Text;
			}
		}
		
		
		
		void DataGrid()
		{
			SqlConnection con_SP2 = new SqlConnection(sqlconn);
			SqlCommand cmd_SP2 = new SqlCommand();
				
			try 
			{
				cmd_SP2.CommandText = @"SELECT JRBarcode, TrxShipMark, TrxLblCustomer, TrxJoStkCode, TrxJoThickness, TrxJoColor, TrxJoWidth, TrxTotalLength, TrxLotNo from TBL_AX2020_COATING_WAREHOUSE_NOT_RECEIVE_STOCK_WAREHOUSE";
				cmd_SP2.Connection = con_SP2;
				con_SP2.Open();
				SqlDataAdapter dataadapter = new SqlDataAdapter(cmd_SP2);

			
								 
			    //DataSet ds = new DataSet();
			    DataTable ds = new DataTable();
			    dataadapter.Fill(ds);
				 
  				this.dataGridViewWarehouse.DataSource = AutoNumberedTable(ds);

			}
			catch(Exception ex)
			{
				MessageBox.Show("Error" + ex.Message + ex.ToString());
				return;
			}
			finally
			{
				
				//TrxShipMark, TrxLblCustomer, TrxJoStkCode, TrxJoThickness, TrxJoColor, TrxJoWidth, TrxTotalLength	
				con_SP2.Close();
				dataGridViewWarehouse.Columns[0].Name = "No";
	            dataGridViewWarehouse.Columns[0].Width = 35;
	            dataGridViewWarehouse.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
	            dataGridViewWarehouse.Columns[1].HeaderText = "Barcode";
	            dataGridViewWarehouse.Columns[1].Width = 110;
	            dataGridViewWarehouse.Columns[2].HeaderText = "Shipping Mark";
	            dataGridViewWarehouse.Columns[2].Width = 110;
	            dataGridViewWarehouse.Columns[3].HeaderText = "Customer";
	            dataGridViewWarehouse.Columns[3].Width = 80;
	            dataGridViewWarehouse.Columns[4].HeaderText = "Code";
	            dataGridViewWarehouse.Columns[4].Width = 150;
	            dataGridViewWarehouse.Columns[5].HeaderText = "Micron";
	            dataGridViewWarehouse.Columns[5].Width = 150;
	            dataGridViewWarehouse.Columns[6].HeaderText = "Color";
				dataGridViewWarehouse.Columns[6].Width = 200;            
				dataGridViewWarehouse.Columns[7].HeaderText = "Width";
				dataGridViewWarehouse.Columns[7].Width = 100;
	            dataGridViewWarehouse.Columns[8].HeaderText = "Length"; 
	            dataGridViewWarehouse.Columns[8].Width = 100;
	            dataGridViewWarehouse.Columns[9].HeaderText = "Lot No"; 
	            dataGridViewWarehouse.Columns[9].Width = 100;
					
			}
			
			con_SP2.Dispose();
			con_SP2 = null;
			cmd_SP2 = null;	
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
		
		
		
		
		
		
		
		void Btn_cancelClick(object sender, EventArgs e)
		{
			this.Close();
		}
		
		void ClearAllText(Control con)
		{
		foreach (Control c in con.Controls)
    		{
      			if (c is TextBox)
        			((TextBox)c).Clear();
      			else
      				ClearAllText(c);
//      			if(c is ComboBox)
//                ((ComboBox)c).Text = "Please Select";
         		
   			}
		}
		void Btn_clearClick(object sender, EventArgs e)
		{
			ClearAllText(this);
		}
		
		void DataGridViewWarehouseCellClick(object sender, DataGridViewCellEventArgs e)
		{
			if(dataGridViewWarehouse.SelectedRows.Count > 0) // make sure user select at least 1 row 
			{
			   	//txtbx_barcode.Text = dataGridViewWarehouse.SelectedRows[0].Cells[0].Value + string.Empty;
			   	txtbx_barcode.Text = dataGridViewWarehouse.SelectedRows[0].Cells[1].Value + string.Empty;
			   	txtbx_shipmark2.Text = dataGridViewWarehouse.SelectedRows[0].Cells[2].Value + string.Empty;
			   	//txtbx_shipmark2.Text = dataGridViewWarehouse.SelectedRows[0].Cells[2].Value + string.Empty;
			   	txtbx_customer.Text = dataGridViewWarehouse.SelectedRows[0].Cells[3].Value + string.Empty;
			   	txtbx_code.Text = dataGridViewWarehouse.SelectedRows[0].Cells[4].Value + string.Empty;
			   	txtbx_micron.Text = dataGridViewWarehouse.SelectedRows[0].Cells[5].Value + string.Empty;
			   	txtbx_color.Text = dataGridViewWarehouse.SelectedRows[0].Cells[6].Value + string.Empty;
			   	txtbx_width.Text = dataGridViewWarehouse.SelectedRows[0].Cells[7].Value + string.Empty;
			   	txtbx_length.Text = dataGridViewWarehouse.SelectedRows[0].Cells[8].Value + string.Empty;
			   	txtbx_lotno.Text = dataGridViewWarehouse.SelectedRows[0].Cells[9].Value + string.Empty;
		   			   //	Code	LotNo	Customer	S.Mark	Color	Micron	Width	Length
		   		txtbx_shipmark.Text = txtbx_shipmark2.Text;
			}
		}
		
		
		
		bool sqlConnParm(string sqlStatement)
		{
			SqlConnection con_data = new SqlConnection(sqlconn);
			SqlCommand cmd_data = new SqlCommand();
			
			try
			{
				cmd_data.Connection = con_data;
				cmd_data.CommandText = sqlStatement;
				cmd_data.CommandType = CommandType.StoredProcedure;
 
				cmd_data.Parameters.Add(new SqlParameter("@SP_TrxShipMark", SqlDbType.NVarChar, 50));
				cmd_data.Parameters["@SP_TrxShipMark"].Value = txtbx_shipmark.Text.ToUpper();
				
					
				cmd_data.Parameters.Add(new SqlParameter("@SP_JRBarcode", SqlDbType.NVarChar, 50));
				cmd_data.Parameters["@SP_JRBarcode"].Value = txtbx_barcode.Text.ToUpper();
						
					
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_USER", SqlDbType.NVarChar, 50));
				cmd_data.Parameters["@SP_PROD_USER"].Value = "0";
					
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_USEREMAIL", SqlDbType.NVarChar, 50));
				cmd_data.Parameters["@SP_PROD_USEREMAIL"].Value = frm_menu_system.email;
					
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_USERPC", SqlDbType.NVarChar, 50));
				cmd_data.Parameters["@SP_PROD_USERPC"].Value = frm_menu_system.ipAddress;
					
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_USERDATETIME", SqlDbType.DateTime));
				cmd_data.Parameters["@SP_PROD_USERDATETIME"].Value = DateTime.Now;
				
				cmd_data.Parameters.Add(new SqlParameter("@SP_TrxLotNo", SqlDbType.NVarChar, 50));
				cmd_data.Parameters["@SP_TrxLotNo"].Value = txtbx_lotno.Text;
					
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_USERREVISION", SqlDbType.NVarChar, 50));
				cmd_data.Parameters["@SP_PROD_USERREVISION"].Value = "0";

				con_data.Open();
				cmd_data.ExecuteNonQuery();					
			} 
			catch (Exception ex) 
			{	
				con_data.Close();
				MessageBox.Show("Error Warehouse JR Stock Received \n" + ex.Message + ex.ToString());			
				return false;
			} 
			finally 
			{
				con_data.Close();		
			}
			
			con_data.Dispose();
			con_data = null;
			cmd_data = null;
			return true;
		}
		
		bool sqlConnParm2(string sqlStatement)
		{
			SqlConnection con_data = new SqlConnection(sqlconn);
			SqlCommand cmd_data = new SqlCommand();
			
			try
			{
				cmd_data.Connection = con_data;
				cmd_data.CommandText = sqlStatement;
				cmd_data.CommandType = CommandType.StoredProcedure;
 
				con_data.Open();
				cmd_data.ExecuteNonQuery();					
			} 
			catch (Exception ex) 
			{	
				con_data.Close();
				MessageBox.Show("Error Warehouse JR Stock Received \n" + ex.Message + ex.ToString());			
				return false;
			} 
			finally 
			{
				con_data.Close();		
			}
			
			con_data.Dispose();
			con_data = null;
			cmd_data = null;
			return true;
		}
		
		
		void Btn_saveClick(object sender, EventArgs e)
		{
			if (txtbx_barcode.Text == null && txtbx_shipmark.Text == string.Empty) // && txtbx_shipmark.Text == null || txtbx_shipmark.Text == string.Empty)
			{			
				MessageBox.Show("EMPTY  BARCODE OR SHIPPING MARK" );//+ ex.Message + ex.ToString());//Lbl_Message.Text = "Error? SO?";
				return;
			}
										
			if (txtbx_barcode.Text == string.Empty && txtbx_shipmark.Text == string.Empty) 
				{
				MessageBox.Show("Cannot Empty");//( + ex.Message + ex.ToString());//Lbl_Message.Text = "Error? SO Line?";
					return;
				}
			SqlConnection con_Check_Duplicate_JO = new SqlConnection(sqlconn);
				SqlCommand cmd = new SqlCommand();
								
								
				try {
						cmd.CommandText = "select * from TBL_AX2020_COATING_RECEIVE_STOCK_WAREHOUSE where JRBarcode = '" + txtbx_barcode.Text.ToUpper() + "' or TrxShipMark = '"  + txtbx_shipmark.Text.ToUpper() + "'";
						cmd.Connection = con_Check_Duplicate_JO;
						con_Check_Duplicate_JO.Open();
						SqlDataReader rd_Check_Duplicate_JO = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
					
						if (rd_Check_Duplicate_JO.Read())
								{
									if (rd_Check_Duplicate_JO.HasRows) 
										{
											MessageBox.Show("Duplicate Shipping Mark or Barcode");//Lbl_Message.Text = "Error 1.0 : Duplicate JO! ";
											return;
										}
								}
					} 
					catch (Exception ex) 
						{
							con_Check_Duplicate_JO.Close();
							MessageBox.Show("Duplicate Shipping Mark or Barcode" + ex.ToString() + ex.Message);
							return;
						} 
					
					finally 
						{
							con_Check_Duplicate_JO.Close();
						}
								
							con_Check_Duplicate_JO.Dispose();
							cmd.Dispose();
							con_Check_Duplicate_JO = null;
							cmd = null;

		//	if(clickSearch == true)
				
				
			//{
				if(sqlConnParm("SP_AX2020_COATING_RECEIVE_STOCK_WAREHOUSE")) //&& sqlConnParm("SP_COATING_NOT_RECEIVE_STOCK_WAREHOUSE"))
				{
					DialogBox.ShowSaveSuccessDialog();
					sqlConnParm2("SP_AX2020_COATING_NOT_RECEIVE_STOCK_WAREHOUSE");
					DataGrid();
					DataGrid2();
					
				}
			//}
//			else
//			{
//				if(sqlConnParm("SP_AX2020_COATING_RECEIVE_STOCK_WAREHOUSE_EDIT"))
//				{
//					DialogBox.ShowSaveSuccessDialog();
//					
//					DataGrid();
//					DataGrid2();
//				}
//			}
//			
			//clickSearch = false;	
			

		}
		
	}
}
