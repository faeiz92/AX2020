using System;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Data.SqlClient;      // For the database connections and objects.
using System.Data.Sql;
using System.Data.Sql;
using System.Data;
using CommonFunction;
using CommonLibrary;
using CommonControl.Functions;


namespace AX2020
{
	
	public partial class frm_prod_warehouse_fr_receive_pack : Form
	{
		public static string sqlconn = "Server=AX-UAT; Password=sbax2020sbg; User ID=sbax2020; Initial Catalog=SBG_AX_2020; Integrated Security=false";
		
		string ref_no = null; //, line_no;
		//string NextNo;
		string username, jo_desc;
		bool clickSearch = false, clickEdit = false;
		double ax_qty, totalRoll;
		int NextNo;
				
		public frm_prod_warehouse_fr_receive_pack()
		{
			InitializeComponent();
			this.ControlBox = false;
			
			
			username = frm_menu_system.userName; 
			lbl_username.Text = "User : " + username;
			
			ClearAllText(this);
		}
		
		void ClearAllText(Control con)
		{
    		foreach (Control c in con.Controls)
    		{
      			if (c is TextBox)
        			((TextBox)c).Clear();
      			else
      				ClearAllText(c);
      			if(c is ComboBox)
                ((ComboBox)c).Text = "Please Select";      								
   			}
    		
    		txtbx_qty_ctn.Text = "0";
    		txtbx_qty_ctn_received.Text = "0";
    		txtbx_qty_roll.Text = "0";
    		txtbx_qty_roll_received.Text = "0";	
    		btn_save.Enabled = true;
			btn_search.Enabled = true;
			btn_edit.Enabled = true;
			totalRoll = 0; 
			ax_qty = 0;
			jo_desc = string.Empty;
			
		}
		
		void Btn_cancelClick(object sender, EventArgs e)
		{
			ax();
			//this.Close();
			//SentEmail();
			
		}
		
		void Btn_clearClick(object sender, EventArgs e)
		{
			ClearAllText(this);
			DataGrid("SELECT PROD_LINE, PROD_DOCNO, PROD_CUSTOMER, PROD_REPORTDATE, PROD_CODE, PROD_BRAND, PROD_COLOR, PROD_MICRON, PROD_WIDTH, PROD_LENGTH, PROD_QTYCTN, PROD_QTYROLL FROM TBL_PROD_WAREHOUSE_FR_RECEIVED where PROD_DATE>= DATEADD(day,-14, getdate()) order by PROD_REPORTDATE DESC, PROD_LINE DESC", dt_grid);
			
		}
		
		void Btn_saveClick(object sender, EventArgs e)
		{
			if(String.IsNullOrWhiteSpace(txtbx_pack_no.Text))
			{
				MessageBox.Show("Please key in Packing Number first");
				return;
			}
			
			if(Convert.ToDouble(txtbx_qty_ctn_received.Text) > totalRoll)
			{
				MessageBox.Show("Qty received cannot more than qty packing");
			}
			
			ax();
			
			if (ax_qty < Convert.ToDouble(txtbx_qty_ctn_received.Text))
			{
				MessageBox.Show("Not enough quantity in AX. Please check Slitting production whether quantity production is correct or not.\n\nQuantity in AX now is " + ax_qty.ToString());
				return;
			}
			else
			{
			
				if(clickSearch == true)
				{
					if(sqlConnParm("SP_PROD_WAREHOUSE_FR_RECEIVED_ADD") & UpdateNotReceived())
					{
						
						DataGrid("SELECT PROD_LINE, PROD_DOCNO, PROD_CUSTOMER, PROD_REPORTDATE, PROD_CODE, PROD_BRAND, PROD_COLOR, PROD_MICRON, PROD_WIDTH, PROD_LENGTH, PROD_QTYCTN, PROD_QTYROLL FROM TBL_PROD_WAREHOUSE_FR_RECEIVED where PROD_REPORTDATE>= DATEADD(day,-8, getdate())", dt_grid);
						DataGrid("SELECT PROD_LINE, PROD_DOCNO, PROD_CUSTOMER, PROD_DATE, PROD_CODE, PROD_BRAND, PROD_COLOR, PROD_MICRON, PROD_WIDTH, PROD_LENGTH, PROD_QTYCTN, PROD_QTYROLL FROM TBL_PROD_CONV_JO_PACKING where flag1 = 'N' and PROD_DATE>= DATEADD(day,-8, getdate())", dt_grid_not_received);
						
						if(LineNoGenerator())
						{
							if(sqlConnParm2("SP_PROD_WAREHOUSE_FR_RECEIVED_TRANSFER"))
							{
								DialogBox.ShowSaveSuccessDialog();
								//SentEmail();
							}
							
						}
					}
				}
				else if(clickEdit == true)
				{
					if(sqlConnParm("SP_PROD_WAREHOUSE_FR_RECEIVED_EDIT"))
					{
						DialogBox.ShowSaveSuccessDialog();
						DataGrid("SELECT PROD_LINE, PROD_DOCNO, PROD_CUSTOMER, PROD_REPORTDATE, PROD_CODE, PROD_BRAND, PROD_COLOR, PROD_MICRON, PROD_WIDTH, PROD_LENGTH, PROD_QTYCTN, PROD_QTYROLL FROM TBL_PROD_WAREHOUSE_FR_RECEIVED where PROD_REPORTDATE>= DATEADD(day,-8, getdate())", dt_grid);
						DataGrid("SELECT PROD_LINE, PROD_DOCNO, PROD_CUSTOMER, PROD_DATE, PROD_CODE, PROD_BRAND, PROD_COLOR, PROD_MICRON, PROD_WIDTH, PROD_LENGTH, PROD_QTYCTN, PROD_QTYROLL FROM TBL_PROD_CONV_JO_PACKING where flag1 = 'N' and PROD_DATE>= DATEADD(day,-8, getdate())", dt_grid_not_received);				
					}
				}
			}
			clickSearch = false;
			clickEdit = false;	
			ClearAllText(this);
		}
		
		void Btn_searchClick(object sender, EventArgs e)
		{
			if(DateTime.Now.Date > Convert.ToDateTime("2017-01-07"))
			{
				if(!CheckDuplicate())
				return;
			
				else
				{
					SqlConnection con_search = new SqlConnection(sqlconn);
					SqlCommand cmd_search = new SqlCommand();
					
				try 
				{
					cmd_search.CommandText = @"SELECT * FROM TBL_PROD_CONV_JO_PACKING where PROD_LINE = @line_no";
					//cmd_search.Parameters.AddWithValue("@doc_no",  txtbx_ref_no.Text.ToUpper());
					cmd_search.Parameters.AddWithValue("@line_no",  txtbx_pack_no.Text);
					cmd_search.Connection = con_search;
					con_search.Open();
					SqlDataReader dr_search = cmd_search.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
						
					if (dr_search.Read())
					{
						ref_no = dr_search["PROD_DOCNO"].ToString();
						txtbx_cust.Text = dr_search["PROD_CUSTOMER"].ToString();
						txtbx_prod_code.Text = dr_search["PROD_CODE"].ToString();
						txtbx_color.Text = dr_search["PROD_COLOR"].ToString();
						txtbx_brand.Text = dr_search["PROD_BRAND"].ToString();
						txtbx_length_cust.Text = dr_search["PROD_LENGTH"].ToString();
						txtbx_width_cust.Text = dr_search["PROD_WIDTH"].ToString();
						txtbx_mic.Text = dr_search["PROD_MICRON"].ToString();
						txtbx_conversion.Text = dr_search["PROD_CONVERSION"].ToString();
						txtbx_qty_ctn.Text = dr_search["PROD_QTYCTN"].ToString();
						txtbx_qty_roll.Text = dr_search["PROD_QTYROLL"].ToString();
						txtbx_qty_ctn_received.Text = dr_search["PROD_TOTALROLL"].ToString();
						totalRoll = Convert.ToDouble(dr_search["PROD_TOTALROLL"].ToString());
	//					txtbx_qty_roll_received.Text = txtbx_qty_roll.Text;
						
					} 
					else 
					{
						MessageBox.Show("Error Search : Cannot find JO!");
						return;
					}
				} 
				catch (Exception ex) 
				{
					MessageBox.Show("Error Search : Cannot load DB!" + ex.Message + ex.ToString());
					return;
				} 
				finally 
				{
					con_search.Close();
				}
				con_search.Dispose();
				cmd_search = null;
				
				
				SqlConnection con_search_bal = new SqlConnection(sqlconn);
				SqlCommand cmd_search_bal = new SqlCommand();
					
				try 
				{
					cmd_search_bal.CommandText = @"SELECT * FROM TBL_PROD_CONV_JO where JODOCNO = @doc_no";
					cmd_search_bal.Parameters.AddWithValue("@doc_no",  ref_no);
					
					cmd_search_bal.Connection = con_search_bal;
					con_search_bal.Open();
					SqlDataReader dr_search_bal = cmd_search_bal.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
						
					if (dr_search_bal.Read())
					{						
						txtbx_total_qty_order.Text = dr_search_bal["JOPRODREMARK0c"].ToString();
						txtbx_total_qty_balance.Text = dr_search_bal["JOPACKQTYBAL"].ToString();
						jo_desc = dr_search_bal["JOSTOCPACKING1"].ToString();
					} 
					else 
					{
						MessageBox.Show("Error Search 2 : Cannot find JO!");
						return;
					}
				} 
				catch (Exception ex) 
				{
					MessageBox.Show("Error Search 2: Cannot load DB!" + ex.Message + ex.ToString());
					return;
				} 
				finally 
				{
					con_search_bal.Close();
				}
				
				con_search_bal.Dispose();
				cmd_search_bal = null;
			
				
				clickSearch = true;
			}
		}
						
					
		}
		
		void ax()
		{
			SqlConnection con_search = new SqlConnection(sqlconn);
			SqlCommand cmd_search = new SqlCommand();
				
				try 
				{
					cmd_search.CommandText = "SELECT sum(availphysical) as availphysical  FROM [AX-SQL].[AX2020StagingDB].[dbo].[VIEW_AXERP_QOH_PM04] " +
					" where itemid = @line_no and availphysical > 1";
					
					cmd_search.Parameters.AddWithValue("@line_no",  txtbx_prod_code.Text);
					cmd_search.Connection = con_search;
					con_search.Open();
					SqlDataReader dr_search = cmd_search.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
						
					if (dr_search.Read())
					{
					
						if (dr_search["availphysical"] !=DBNull.Value)
						{
								ax_qty = Convert.ToDouble(dr_search["availphysical"].ToString());
							
						}
						else
						{
							ax_qty = 0;
						}
						//ax_qty = Convert.ToDouble(dr_search["availphysical"].ToString());
						
							
					} 
					else 
					{
						MessageBox.Show("No Quantity in AX! Check Slitting production");
						ax_qty = 0;
						return;
					}
				} 
				catch (Exception ex) 
				{
					MessageBox.Show("Error Search : Cannot load DB!" + ex.Message + ex.ToString());
					return;
				} 
				finally 
				{
					con_search.Close();
				}
				con_search.Dispose();
				cmd_search = null;
			
			
			
	
		}
		void Dt_gridCellClick(object sender, DataGridViewCellEventArgs e)
		{
			if(dt_grid.SelectedRows.Count > 0) // make sure user select at least 1 row 
			{
				ref_no = dt_grid.SelectedRows[0].Cells[2].Value + string.Empty;
			   	txtbx_pack_no.Text = dt_grid.SelectedRows[0].Cells[1].Value + string.Empty;
			   	
			   	Retrieve();
			   	btn_save.Enabled = false;
			   	btn_search.Enabled = false;
				btn_edit.Enabled = false;			   	
			}	
		}
		
		void Retrieve()
		{
			SqlConnection con_SP1 = new SqlConnection(sqlconn);
			SqlCommand cmd_SP1 = new SqlCommand();
				
			try 
			{
				cmd_SP1.CommandText = @"SELECT * FROM TBL_PROD_WAREHOUSE_FR_RECEIVED where PROD_LINE = @line_no";
				//cmd_SP1.Parameters.AddWithValue("@doc_no",  txtbx_ref_no.Text);
        		cmd_SP1.Parameters.AddWithValue("@line_no",  txtbx_pack_no.Text);
				cmd_SP1.Connection = con_SP1;
				con_SP1.Open();
				SqlDataReader rd_SP1 = cmd_SP1.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
					
				if (rd_SP1.Read())
				{				        	
					txtbx_cust.Text = rd_SP1["PROD_CUSTOMER"].ToString();
					txtbx_prod_code.Text = rd_SP1["PROD_CODE"].ToString();
					txtbx_color.Text = rd_SP1["PROD_COLOR"].ToString();
					txtbx_brand.Text = rd_SP1["PROD_BRAND"].ToString();
					txtbx_length_cust.Text = rd_SP1["PROD_LENGTH"].ToString();
					txtbx_width_cust.Text = rd_SP1["PROD_WIDTH"].ToString();
					txtbx_mic.Text = rd_SP1["PROD_MICRON"].ToString();
					txtbx_conversion.Text = rd_SP1["PROD_CONVERSION"].ToString();
					txtbx_total_qty_order.Text = rd_SP1["PROD_QTYORDERED"].ToString();
					txtbx_qty_ctn.Text = rd_SP1["PROD_QTYCTN"].ToString();
					txtbx_qty_roll.Text = rd_SP1["PROD_QTYROLL"].ToString();
					txtbx_qty_ctn_received.Text = rd_SP1["PROD_QTYCTNRECEIVED"].ToString();
					txtbx_qty_roll_received.Text = rd_SP1["PROD_QTYROLLRECEIVED"].ToString();
				} 
				
			} 
			catch (Exception ex) 
			{
				MessageBox.Show("Error Warehouse FR Stock Received Pack Retrieve: Cannot load DB!" + ex.Message + ex.ToString());
				return;
			} 
			finally 
			{
				con_SP1.Close();
			}
			
			SqlConnection con_SP3 = new SqlConnection(sqlconn);
			SqlCommand cmd_SP3 = new SqlCommand();
			
			try 
			{
				cmd_SP3.CommandText = @"select * from TBL_PROD_CONV_JO where JODOCNO = @doc_no";
				cmd_SP3.Parameters.AddWithValue("@doc_no",  ref_no);
				cmd_SP3.Connection = con_SP3;
				con_SP3.Open();
				SqlDataReader rd_SP3 = cmd_SP3.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
				
				if (rd_SP3.Read())
				{	
					txtbx_total_qty_balance.Text = rd_SP3["JOPACKQTYBAL"].ToString();					
				} 
				else 
				{
					MessageBox.Show("Error - Warehouse FR Stock Received Pack Retrieve \nCannot find JO!");
					return;
				}
			} 
			catch (Exception ex) 
			{
				MessageBox.Show("Error - Warehouse FR Stock Received Pack Retrieve \nCannot load DB!" + ex.Message + ex.ToString());
				return;
			} 
			finally 
			{
				con_SP3.Close();
			}
			
			con_SP3.Dispose();
			con_SP3 = null;
			cmd_SP3 = null;
		}
		
		void Retrieve2()
		{
			SqlConnection con_SP1 = new SqlConnection(sqlconn);
			SqlCommand cmd_SP1 = new SqlCommand();
				
			try 
			{
				cmd_SP1.CommandText = @"SELECT * FROM TBL_PROD_CONV_JO_PACKING where PROD_LINE = @line_no";
				//cmd_SP1.Parameters.AddWithValue("@doc_no",  txtbx_ref_no.Text);
        		cmd_SP1.Parameters.AddWithValue("@line_no",  txtbx_pack_no.Text);
				cmd_SP1.Connection = con_SP1;
				con_SP1.Open();
				SqlDataReader rd_SP1 = cmd_SP1.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
					
				if (rd_SP1.Read())
				{				        	
					txtbx_cust.Text = rd_SP1["PROD_CUSTOMER"].ToString();
					txtbx_prod_code.Text = rd_SP1["PROD_CODE"].ToString();
					txtbx_color.Text = rd_SP1["PROD_COLOR"].ToString();
					txtbx_brand.Text = rd_SP1["PROD_BRAND"].ToString();
					txtbx_length_cust.Text = rd_SP1["PROD_LENGTH"].ToString();
					txtbx_width_cust.Text = rd_SP1["PROD_WIDTH"].ToString();
					txtbx_mic.Text = rd_SP1["PROD_MICRON"].ToString();
					txtbx_conversion.Text = rd_SP1["PROD_CONVERSION"].ToString();
					txtbx_total_qty_order.Text = rd_SP1["PROD_QTYORDERED"].ToString();
					txtbx_qty_ctn.Text = rd_SP1["PROD_QTYCTN"].ToString();
					txtbx_qty_roll.Text = rd_SP1["PROD_QTYROLL"].ToString();
					txtbx_qty_ctn_received.Text = txtbx_qty_ctn.Text;
					txtbx_qty_roll_received.Text = txtbx_qty_roll.Text;

				} 
				
			} 
			catch (Exception ex) 
			{
				MessageBox.Show("Error Warehouse FR Stock Received Pack Retrieve 2: Cannot load DB!" + ex.Message + ex.ToString());
				return;
			} 
			finally 
			{
				con_SP1.Close();
			}
			
			SqlConnection con_SP3 = new SqlConnection(sqlconn);
			SqlCommand cmd_SP3 = new SqlCommand();
			
			try 
			{
				cmd_SP3.CommandText = @"select * from TBL_PROD_CONV_JO where JODOCNO = @doc_no";
				cmd_SP3.Parameters.AddWithValue("@doc_no",  ref_no);
				cmd_SP3.Connection = con_SP3;
				con_SP3.Open();
				SqlDataReader rd_SP3 = cmd_SP3.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
				
				if (rd_SP3.Read())
				{	
					txtbx_total_qty_balance.Text = rd_SP3["JOPACKQTYBAL"].ToString();
					
				} 
				else 
				{
					MessageBox.Show("Error - Warehouse FR Stock Received Pack Retrieve 2 \nCannot find JO!");
					return;
				}
			} 
			catch (Exception ex) 
			{
				MessageBox.Show("Error - Warehouse FR Stock Received Pack Retrieve 2 \nCannot load DB!" + ex.Message + ex.ToString());
				return;
			} 
			finally 
			{
				con_SP3.Close();
			}
			
			con_SP3.Dispose();
			con_SP3 = null;
			cmd_SP3 = null;
		}
		
//		private bool LineNoGenerator()
//		{
//			
//			SqlConnection conNextNumber = new SqlConnection(sqlconn);
//			SqlCommand cmdNextNumber = new SqlCommand();
//			
//			try 
//			{
//				cmdNextNumber.CommandText = "Select WhseConvFRReceived from TBL_ADMIN_NEXT_NUMBER";
//				cmdNextNumber.Connection = conNextNumber;
//
//				conNextNumber.Open();
//				SqlDataReader rdNextNumber = cmdNextNumber.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
//
//				rdNextNumber.Read();
//				NextNo = (rdNextNumber["WhseConvFRReceived"]).ToString();
//				
//				
//			} 
//			catch (Exception ex) 
//			{
//				MessageBox.Show("Error Running No : Cannot load DB!" + ex.Message + ex.ToString());
//				return false;
//			} 
//			finally 
//			{
//				conNextNumber.Close();	
//			}
//			
//			conNextNumber.Dispose();
//			conNextNumber = null;
//			cmdNextNumber = null;
//		
//	
//			SqlConnection conUpdate = new SqlConnection(sqlconn);
//			SqlCommand cmdUpdate = new SqlCommand();
//
//			try
//			{
//				cmdUpdate.CommandText = "update TBL_ADMIN_NEXT_NUMBER set WhseConvFRReceived = WhseConvFRReceived + 1";
//				
//				cmdUpdate.Connection = conUpdate;
//
//				conUpdate.Open();
//				cmdUpdate.ExecuteNonQuery();
//
//			}
//			catch (Exception ex)
//			{
//				conUpdate.Close();
//				MessageBox.Show("Error in updating next number" + ex.Message + ex.ToString());
//				return false;
//			}
//			finally 
//			{
//				conUpdate.Close();
//			}
//
//			conUpdate.Dispose();
//			conUpdate = null;
//			cmdUpdate = null;
//			return true;			
//		}
		
		bool UpdateNotReceived()
		{
			SqlConnection conUpdate = new SqlConnection(sqlconn);
			SqlCommand cmdUpdate = new SqlCommand();

			try
			{
				cmdUpdate.CommandText = @"UPDATE TBL_PROD_CONV_JO_PACKING SET flag1 = 'Y' where PROD_LINE = @line_no";
				//cmd_SP1.Parameters.AddWithValue("@doc_no",  txtbx_ref_no.Text);
        		cmdUpdate.Parameters.AddWithValue("@line_no",  txtbx_pack_no.Text);
				cmdUpdate.Connection = conUpdate;

				conUpdate.Open();
				cmdUpdate.ExecuteNonQuery();

			}
			catch (Exception ex)
			{
				conUpdate.Close();
				MessageBox.Show("Error - Warehouse FR Received Update \nCannot update DB" + ex.Message + ex.ToString());
				return false;
			}
			finally 
			{
				conUpdate.Close();
			}

			conUpdate.Dispose();
			conUpdate = null;
			cmdUpdate = null;
			return true;			
		}
		
		void DataGrid(string sql_statement, DataGridView dt)
		{
			try
			{
				string sql = sql_statement;
		        SqlConnection connection = new SqlConnection(sqlconn);
		        SqlDataAdapter dataadapter = new SqlDataAdapter(sql, connection);
		        DataTable ds = new DataTable();
		        connection.Open();
		        dataadapter.Fill(ds);
		                     
//		        DataTable tempDT = new DataTable();
//				tempDT = ds.DefaultView.ToTable(true, "PROD_LINE", "PROD_DOCNO", "PROD_CUSTOMER", "PROD_DATE", "PROD_CODE", "PROD_BRAND", "PROD_COLOR", "PROD_MICRON", "PROD_WIDTH", "PROD_LENGTH", "PROD_QTYCTNRECEIVED", "PROD_QTYROLLRECEIVED");
//				dt_grid.DataSource = AutoNumberedTable(tempDT);
					
		        dt.DataSource = AutoNumberedTable(ds);
			}
			catch(Exception ex)
			{
				MessageBox.Show("Error" + ex.Message + ex.ToString());
				return;
			}
			finally
			{
				dt.Columns[0].Name = "No";
	            dt.Columns[0].Width = 35;
	            dt.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
				dt.Columns[1].HeaderText = "Line No";
				dt.Columns[1].Width = 80;
				dt.Columns[2].HeaderText = "Jo No";
				dt.Columns[2].Width = 80;
				dt.Columns[3].HeaderText = "Customer";
				dt.Columns[3].Width = 200;
				dt.Columns[4].HeaderText = "Date";
				dt.Columns[4].Width = 80;
				dt.Columns[4].DefaultCellStyle.Format = "dd/MM/yyyy";
				dt.Columns[5].HeaderText = "Code";
				dt.Columns[5].Width = 80;
				dt.Columns[6].HeaderText = "Brand";
				dt.Columns[6].Width = 80;
				dt.Columns[7].HeaderText = "Color";
				dt.Columns[7].Width = 80;
				dt.Columns[8].HeaderText = "Micron";
				dt.Columns[9].HeaderText = "Width";
				dt.Columns[10].HeaderText = "Length";
				dt.Columns[11].HeaderText = "Qty Ctn";
				dt.Columns[12].HeaderText = "Qty Roll";

			}

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
		
		bool CheckDuplicate()
		{
			SqlConnection con_check_duplicate = new SqlConnection(sqlconn);
			SqlCommand cmd_check_duplicate = new SqlCommand();
				
			try 
			{
				cmd_check_duplicate.CommandText = @"SELECT * FROM TBL_PROD_WAREHOUSE_FR_RECEIVED where PROD_LINE = @line_no";
				//cmd_check_duplicate.Parameters.AddWithValue("@doc_no",  txtbx_ref_no.Text.ToUpper());
				cmd_check_duplicate.Parameters.AddWithValue("@line_no",  txtbx_pack_no.Text);
				cmd_check_duplicate.Connection = con_check_duplicate;
				con_check_duplicate.Open();
				SqlDataReader dr_check_duplicate = cmd_check_duplicate.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
					
				if (dr_check_duplicate.HasRows)
				{	
					MessageBox.Show("Duplicate item. This item had already been received");
					DataGrid("SELECT PROD_LINE, PROD_DOCNO, PROD_CUSTOMER, PROD_REPORTDATE, PROD_CODE, PROD_BRAND, PROD_COLOR, PROD_MICRON, PROD_WIDTH, PROD_LENGTH, PROD_QTYCTN, PROD_QTYROLL FROM TBL_PROD_WAREHOUSE_FR_RECEIVED where PROD_LINE = '" + txtbx_pack_no.Text + "'", dt_grid);
		
					return false;
				} 
			} 
			catch (Exception ex) 
			{
				MessageBox.Show("Error : Warehouse FR Stock Receive Pack\nCannot load Duplicate DB!" + ex.Message + ex.ToString());
				return false;
			} 
			finally 
			{
				con_check_duplicate.Close();
			}
			con_check_duplicate.Dispose();
			cmd_check_duplicate = null;
			return true;
			
		}
		
		void frm_prod_warehouse_fr_receive_packLoad(object sender, EventArgs e)
		{
			DataGrid("SELECT PROD_LINE, PROD_DOCNO, PROD_CUSTOMER, PROD_REPORTDATE, PROD_CODE, PROD_BRAND, PROD_COLOR, PROD_MICRON, PROD_WIDTH, PROD_LENGTH, PROD_QTYCTN, PROD_QTYROLL FROM TBL_PROD_WAREHOUSE_FR_RECEIVED where PROD_REPORTDATE>= DATEADD(day,-14, getdate()) order by PROD_REPORTDATE DESC, PROD_LINE DESC", dt_grid);
			DataGrid("SELECT PROD_LINE, PROD_DOCNO, PROD_CUSTOMER, PROD_DATE, PROD_CODE, PROD_BRAND, PROD_COLOR, PROD_MICRON, PROD_WIDTH, PROD_LENGTH, PROD_QTYCTN, PROD_QTYROLL FROM TBL_PROD_CONV_JO_PACKING where flag1 = 'N' and PROD_DATE > '2017-03-24' and PROD_DATE>= DATEADD(day,-30, getdate()) and PROD_USERREVISION <> 'SAPS' ORDER BY PROD_DATE DESC, PROD_LINE", dt_grid_not_received);
			
			if(username.ToUpper() == "ADMIN")
			{
				btn_edit.Enabled = true;
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

				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_LINE", SqlDbType.NVarChar, 50));
				cmd_data.Parameters["@SP_PROD_LINE"].Value = txtbx_pack_no.Text.ToUpper();
				
					
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_DOCNO", SqlDbType.NVarChar, 50));
				cmd_data.Parameters["@SP_PROD_DOCNO"].Value = ref_no;
					
					
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_REPORTDATE", SqlDbType.DateTime));
				cmd_data.Parameters["@SP_PROD_REPORTDATE"].Value = DateTime.Now;
					
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_DATERECEIVED", SqlDbType.DateTime));
				cmd_data.Parameters["@SP_PROD_DATERECEIVED"].Value = DateTime.Now;	
					
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_QTYCTNRECEIVED", SqlDbType.Float));
				cmd_data.Parameters["@SP_PROD_QTYCTNRECEIVED"].Value = 0;
					
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_QTYROLLRECEIVED", SqlDbType.Float));
				cmd_data.Parameters["@SP_PROD_QTYROLLRECEIVED"].Value = 0;
					
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_TOTALROLLRECEIVED", SqlDbType.Float));
				cmd_data.Parameters["@SP_PROD_TOTALROLLRECEIVED"].Value = Double.Parse(txtbx_qty_ctn_received.Text);
						
				
				
				cmd_data.Parameters.Add(new SqlParameter("@SP_flag1", SqlDbType.NVarChar, 2));
				cmd_data.Parameters["@SP_flag1"].Value = "0";

				cmd_data.Parameters.Add(new SqlParameter("@SP_flag2", SqlDbType.NVarChar, 2));
				cmd_data.Parameters["@SP_flag2"].Value = "0";

				cmd_data.Parameters.Add(new SqlParameter("@SP_flag3", SqlDbType.NVarChar, 2));
				cmd_data.Parameters["@SP_flag3"].Value = "0";

				cmd_data.Parameters.Add(new SqlParameter("@SP_flag4", SqlDbType.NVarChar, 2));
				cmd_data.Parameters["@SP_flag4"].Value = "0";

				cmd_data.Parameters.Add(new SqlParameter("@SP_flag5", SqlDbType.NVarChar, 2));
				cmd_data.Parameters["@SP_flag5"].Value = "0";

				cmd_data.Parameters.Add(new SqlParameter("@SP_flag6", SqlDbType.NVarChar, 2));
				cmd_data.Parameters["@SP_flag6"].Value = "0";

				cmd_data.Parameters.Add(new SqlParameter("@SP_flag7", SqlDbType.NVarChar, 2));
				cmd_data.Parameters["@SP_flag7"].Value = "0";

				cmd_data.Parameters.Add(new SqlParameter("@SP_flag8", SqlDbType.NVarChar, 2));
				cmd_data.Parameters["@SP_flag8"].Value = "0";

				cmd_data.Parameters.Add(new SqlParameter("@SP_flagStatus", SqlDbType.NVarChar, 2));
				cmd_data.Parameters["@SP_flagStatus"].Value = "N";
					
					
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_USER", SqlDbType.NVarChar, 50));
				cmd_data.Parameters["@SP_PROD_USER"].Value = username;
					
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_USEREMAIL", SqlDbType.NVarChar, 50));
				cmd_data.Parameters["@SP_PROD_USEREMAIL"].Value = frm_menu_system.email;
					
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_USERPC", SqlDbType.NVarChar, 50));
				cmd_data.Parameters["@SP_PROD_USERPC"].Value = frm_menu_system.ipAddress;
					
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_USERDATETIME", SqlDbType.DateTime));
				cmd_data.Parameters["@SP_PROD_USERDATETIME"].Value = DateTime.Now;
					
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_USERREVISION", SqlDbType.NVarChar, 50));
				cmd_data.Parameters["@SP_PROD_USERREVISION"].Value = "0";

				con_data.Open();
				cmd_data.ExecuteNonQuery();					
			} 
			catch (Exception ex) 
			{	
				con_data.Close();
				MessageBox.Show("Error Warehouse FR Stock Received \n" + ex.Message + ex.ToString());			
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

				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_LINE", SqlDbType.NVarChar, 50));
				cmd_data.Parameters["@SP_PROD_LINE"].Value = txtbx_pack_no.Text.ToUpper();
				
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_LINE2", SqlDbType.NVarChar, 50));
				cmd_data.Parameters["@SP_PROD_LINE2"].Value = NextNo;
							
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_DOCNO", SqlDbType.NVarChar, 50));
				cmd_data.Parameters["@SP_PROD_DOCNO"].Value = ref_no;
										
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_REPORTDATE", SqlDbType.DateTime));
				cmd_data.Parameters["@SP_PROD_REPORTDATE"].Value = DateTime.Now;
					
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_DATERECEIVED", SqlDbType.DateTime));
				cmd_data.Parameters["@SP_PROD_DATERECEIVED"].Value = DateTime.Now;	
					
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_QTYCTNRECEIVED", SqlDbType.Float));
				cmd_data.Parameters["@SP_PROD_QTYCTNRECEIVED"].Value = 0;
					
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_QTYROLLRECEIVED", SqlDbType.Float));
				cmd_data.Parameters["@SP_PROD_QTYROLLRECEIVED"].Value = 0;
					
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_TOTALROLLRECEIVED", SqlDbType.Float));
				cmd_data.Parameters["@SP_PROD_TOTALROLLRECEIVED"].Value = Double.Parse(txtbx_qty_ctn_received.Text);
						
				
				
				cmd_data.Parameters.Add(new SqlParameter("@SP_flag1", SqlDbType.NVarChar, 2));
				cmd_data.Parameters["@SP_flag1"].Value = "Y";

				cmd_data.Parameters.Add(new SqlParameter("@SP_flag2", SqlDbType.NVarChar, 2));
				cmd_data.Parameters["@SP_flag2"].Value = "Y";

				cmd_data.Parameters.Add(new SqlParameter("@SP_flag3", SqlDbType.NVarChar, 2));
				cmd_data.Parameters["@SP_flag3"].Value = "N";

				cmd_data.Parameters.Add(new SqlParameter("@SP_flag4", SqlDbType.NVarChar, 2));
				cmd_data.Parameters["@SP_flag4"].Value = "0";

				cmd_data.Parameters.Add(new SqlParameter("@SP_flag5", SqlDbType.NVarChar, 2));
				cmd_data.Parameters["@SP_flag5"].Value = "0";

				cmd_data.Parameters.Add(new SqlParameter("@SP_flag6", SqlDbType.NVarChar, 2));
				cmd_data.Parameters["@SP_flag6"].Value = "0";

				cmd_data.Parameters.Add(new SqlParameter("@SP_flag7", SqlDbType.NVarChar, 2));
				cmd_data.Parameters["@SP_flag7"].Value = "0";

				cmd_data.Parameters.Add(new SqlParameter("@SP_flag8", SqlDbType.NVarChar, 2));
				cmd_data.Parameters["@SP_flag8"].Value = "0";

				cmd_data.Parameters.Add(new SqlParameter("@SP_flagStatus", SqlDbType.NVarChar, 2));
				cmd_data.Parameters["@SP_flagStatus"].Value = "0";
					
					
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_USER", SqlDbType.NVarChar, 50));
				cmd_data.Parameters["@SP_PROD_USER"].Value = username;
					
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_USEREMAIL", SqlDbType.NVarChar, 50));
				cmd_data.Parameters["@SP_PROD_USEREMAIL"].Value = frm_menu_system.email;
					
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_USERPC", SqlDbType.NVarChar, 50));
				cmd_data.Parameters["@SP_PROD_USERPC"].Value = frm_menu_system.ipAddress;
					
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_USERDATETIME", SqlDbType.DateTime));
				cmd_data.Parameters["@SP_PROD_USERDATETIME"].Value = DateTime.Now;
					
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_USERREVISION", SqlDbType.NVarChar, 50));
				cmd_data.Parameters["@SP_PROD_USERREVISION"].Value = "0";

				con_data.Open();
				cmd_data.ExecuteNonQuery();					
			} 
			catch (Exception ex) 
			{	
				con_data.Close();
				MessageBox.Show("Error Warehouse FR Stock Received \n" + ex.Message + ex.ToString());			
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
		
		bool LineNoGenerator()
		{
			
			SqlConnection conNextNumber = new SqlConnection(sqlconn);
			SqlCommand cmdNextNumber = new SqlCommand();
			
			try 
			{
				cmdNextNumber.CommandText = "Select WhseTransfer from TBL_ADMIN_NEXT_NUMBER";
				cmdNextNumber.Connection = conNextNumber;

				conNextNumber.Open();
				SqlDataReader rdNextNumber = cmdNextNumber.ExecuteReader(System.Data.CommandBehavior.CloseConnection);

				rdNextNumber.Read();
				NextNo = Convert.ToInt32(rdNextNumber["WhseTransfer"]);
				
			
			} 
			catch (Exception ex) 
			{
				MessageBox.Show("Error Warehouse Transfer \nCannot get next number \n" + ex.Message + ex.ToString());
				return false;
			} 
			finally 
			{
				conNextNumber.Close();
				
			}
			
			conNextNumber.Dispose();
			conNextNumber = null;
			cmdNextNumber = null;
			
			
			SqlConnection conUpdate = new SqlConnection(sqlconn);
			SqlCommand cmdUpdateNextNumber = new SqlCommand();

			try
			{
				cmdUpdateNextNumber.CommandText = "update TBL_ADMIN_NEXT_NUMBER set WhseTransfer = WhseTransfer + 1";
				
				cmdUpdateNextNumber.Connection = conUpdate;

				conUpdate.Open();
				cmdUpdateNextNumber.ExecuteNonQuery();

			}
			catch (Exception ex)
			{
				conUpdate.Close();
				MessageBox.Show("Error Warehouse Transfer \nCannot update next number \n" + ex.Message + ex.ToString());
				return false;
			}
			finally 
			{
				conUpdate.Close();
			}

			conUpdate.Dispose();
			conUpdate = null;
			cmdUpdateNextNumber = null;

			return true;			
		}
		
		void Dt_grid_not_receivedCellClick(object sender, DataGridViewCellEventArgs e)
		{
			if(dt_grid.SelectedRows.Count > 0) // make sure user select at least 1 row 
			{
				clickSearch = true;
				ClearAllText(this);
				btn_save.Enabled = true;
				ref_no = dt_grid_not_received.SelectedRows[0].Cells[2].Value + string.Empty;
			   	txtbx_pack_no.Text = dt_grid_not_received.SelectedRows[0].Cells[1].Value + string.Empty;
			   	
			   	Retrieve2();
			   	btn_search.Enabled = false;
				btn_edit.Enabled = false;
			   		
			}	
		}
		
		void SentEmail()
		{
		//------------------------------------------------------------------------------------------
		// BEGIN EMAIL NOTIFICATION
		//------------------------------------------------------------------------------------------
			string FromName = "AX2020 E-SERVICE";
			string FromEmail = "sbti.ax2020@gmail.com";
			string Subject = "AX2020 FR - " + txtbx_pack_no.Text + " - " + txtbx_cust.Text.Substring(0, Math.Min(30, txtbx_cust.Text.Length));
	
			SmtpClient smtp = new SmtpClient();
			smtp.Host = "smtp.gmail.com";
			smtp.Credentials = new System.Net.NetworkCredential("sbti.ax2020@gmail.com", "wsc4143pk");
			smtp.EnableSsl = true;
			smtp.Port = 587;
			//smtp.Port = 25;
			
			
			MailMessage msg = new MailMessage();
			msg.IsBodyHtml = true;
			msg.From = new MailAddress(FromEmail, FromName);
			
			msg.To.Add(new MailAddress("it-4@sbgroup.com.my", "Afiqah"));
			msg.To.Add(new MailAddress("samuel@sbgroup.com.my", "Samuel"));
			msg.To.Add(new MailAddress("it-2@sbgroup.com.my", "Kelvin"));
			

			msg.To.Add(new MailAddress("cath@sbgroup.com.my", "Catherine Teh"));
			//msg.To.Add(new MailAddress("Kelly@sbgroup.com.my", "Kelly"));
			//msg.To.Add(new MailAddress("angelalau@sbgroup.com.my", "Angela Lau"));
			
					
			msg.To.Add(new MailAddress("store-2@sbgroup.com.my", "Kalyani"));
			msg.To.Add(new MailAddress("store-9@sbgroup.com.my", "Chin Chin"));
			msg.To.Add(new MailAddress("logistic-5@sbgroup.com.my", "Arveenah"));
			msg.To.Add(new MailAddress("cyyong@sbgroup.com.my", "CY Yong"));
//			msg.To.Add(new MailAddress("sosiaw@sbgroup.com.my", "SO Siaw"));
				
						
			msg.To.Add(new MailAddress("lew.pohling@sbgroup.com.my", "Lew Poh Ling"));			
//			msg.To.Add(new MailAddress("yap@sbgroup.com.my", "Yap Hong Kee "));
			msg.To.Add(new MailAddress("slitting-1@sbgroup.com.my","Sufia"));
			msg.To.Add(new MailAddress("zuhaili.salehen@sbgroup.com.my","Ain Zuhaili"));
			msg.To.Add(new MailAddress("planner-5@sbgroup.com.my", "Jess Ng"));
			
		
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
			msg.Body = "Please be informed that " + EmailUserName + " has done receiving for packing list, " + txtbx_pack_no.Text + " as follows:\n\n";//Ref Number         Line Number StockCode      Desc1                             Desc2                             Qty Ordered\n";
			
//			SqlDataAdapter thisAdapter = new SqlDataAdapter("Select * from TBL_PROD_CONV_JO where JODOCNO = '" + txtbx_pack_no.Text + "' order by JOLINENO", sqlconn);
//			
//			DataSet DataSet = new DataSet();
//			
//			thisAdapter.Fill(DataSet, "TBL_PROD_CONV_STORE_READY");
			
			msg.Body = msg.Body + "<table> <tr> <th>Jo No</th> <th>StockCode</th> <th>Customer</th> <th>Description</th> <th>Qty Ordered</th> <th>Qty Received</th> </tr>";
//			
//			foreach (DataRow Row in DataSet.Tables["TBL_PROD_CONV_STORE_READY"].Rows)	
//			{
//			 	//msg.Body = msg.Body + "\n" + Row["JODOCNO"] + "  " + Row["JOLINENO"] + "  " + Row["JOSTOCKCODE"] + "  " + Row["JOSTOCKDESC1"] + "  " + Row["JOSTOCKDESC2"] + "  " + Row["JOSTOCKQTYORDER"]; 
//			 	msg.Body = msg.Body + "<tr> <td>" + Row["JODOCNO"].ToString() + "</td> <td>" + Row["JOLINENO"].ToString() + "</td> <td>" + Row["JOSTOCKCODE"].ToString() + "</td> <td>" + Row["JOSTOCKDESC1"].ToString() + "</td> <td>" + Row["JOSTOCKDESC2"].ToString() + "</td> <td>" + Row["JOSTOCKQTYORDER"].ToString() + "</td> </tr>";
//			}
//			
			msg.Body = msg.Body + "<tr> <td>" + ref_no + "</td> <td>" + txtbx_prod_code.Text + "</td> <td>" + txtbx_cust.Text + "</td> <td>" + jo_desc + "</td> <td>" + txtbx_total_qty_order.Text + "</td> <td>" + txtbx_qty_ctn_received.Text + "</td> </tr>";
//		
			msg.Body = msg.Body + "</table>";
			msg.Body = msg.Body + "<br> <br> <br> <br>Thank you.<br> <br>AX2020 SO System Notification.";
			
			try
			{
				smtp.Send(msg);
			} 
			catch (FormatException ex) 
			{
				MessageBox.Show("Format Exception: " + ex.Message + ex.ToString());
				return;
			} 
			catch (SmtpException ex) 
			{
				MessageBox.Show("SMTP Exception:  " + ex.Message + ex.ToString());
				return;
			} 
			catch (Exception ex) 
			{
				MessageBox.Show("General Exception:  " + ex.Message + ex.ToString());
				return;
			}
			
			
		}
		
		void Btn_editClick(object sender, EventArgs e)
		{
			if(String.IsNullOrWhiteSpace(txtbx_pack_no.Text))
			{
				MessageBox.Show("Please key in the Packing Number first");
				return;
			}
			
			else
			{
				SqlConnection con_check_edit = new SqlConnection(sqlconn);
				SqlCommand cmd_check_edit = new SqlCommand();
					
				try 
				{
					cmd_check_edit.CommandText = @"SELECT * FROM TBL_PROD_WAREHOUSE_FR_RECEIVED where PROD_LINE = @line_no";
					//cmd_check_edit.Parameters.AddWithValue("@doc_no",  txtbx_ref_no.Text.ToUpper());
					cmd_check_edit.Parameters.AddWithValue("@line_no",  txtbx_pack_no.Text);
					cmd_check_edit.Connection = con_check_edit;
					con_check_edit.Open();
					SqlDataReader dr_check_edit = cmd_check_edit.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
						
					if (dr_check_edit.HasRows)
					{	
						while(dr_check_edit.Read())
						{
							ref_no = dr_check_edit["PROD_DOCNO"].ToString();
							txtbx_cust.Text = dr_check_edit["PROD_CUSTOMER"].ToString();
							txtbx_prod_code.Text = dr_check_edit["PROD_CODE"].ToString();
							txtbx_color.Text = dr_check_edit["PROD_COLOR"].ToString();
							txtbx_brand.Text = dr_check_edit["PROD_BRAND"].ToString();
							txtbx_length_cust.Text = dr_check_edit["PROD_LENGTH"].ToString();
							txtbx_width_cust.Text = dr_check_edit["PROD_WIDTH"].ToString();
							txtbx_mic.Text = dr_check_edit["PROD_MICRON"].ToString();
							txtbx_conversion.Text = dr_check_edit["PROD_CONVERSION"].ToString();
							txtbx_qty_ctn.Text = dr_check_edit["PROD_QTYCTN"].ToString();
							txtbx_qty_roll.Text = dr_check_edit["PROD_QTYROLL"].ToString();
							txtbx_qty_ctn_received.Text = dr_check_edit["PROD_QTYCTNRECEIVED"].ToString();
							txtbx_qty_roll_received.Text = dr_check_edit["PROD_QTYROLLRECEIVED"].ToString();
						}
					} 
					else
					{
						MessageBox.Show("Packing Number does not exist");
						return;
					}
				} 
				catch (Exception ex) 
				{
					MessageBox.Show("Error : Warehouse FR Stock Receive Pack\nCannot load Retrieve DB!" + ex.Message + ex.ToString());
					return;
				} 
				finally 
				{
					con_check_edit.Close();
				}
				con_check_edit.Dispose();
				cmd_check_edit = null;	
	
				
				SqlConnection con_edit_bal = new SqlConnection(sqlconn);
				SqlCommand cmd_edit_bal = new SqlCommand();
					
				try 
				{
					cmd_edit_bal.CommandText = @"SELECT * FROM TBL_PROD_CONV_JO where JODOCNO = @doc_no";
					cmd_edit_bal.Parameters.AddWithValue("@doc_no",  ref_no);
					
					cmd_edit_bal.Connection = con_edit_bal;
					con_edit_bal.Open();
					SqlDataReader dr_edit_bal = cmd_edit_bal.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
						
					if (dr_edit_bal.Read())
					{						
						txtbx_total_qty_order.Text = dr_edit_bal["JOPRODREMARK0c"].ToString();
						txtbx_total_qty_balance.Text = dr_edit_bal["JOPACKQTYBAL"].ToString();
					} 
					else 
					{
						MessageBox.Show("Error Search 2 : Cannot find JO!");
						return;
					}
				} 
				catch (Exception ex) 
				{
					MessageBox.Show("Error Search 2: Cannot load DB!" + ex.Message + ex.ToString());
					return;
				} 
				finally 
				{
					con_edit_bal.Close();
				}
				con_edit_bal.Dispose();
				cmd_edit_bal = null;
	
				clickEdit = true;
			}
		}
	}
}
