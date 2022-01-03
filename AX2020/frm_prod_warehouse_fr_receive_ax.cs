using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic; // For generic collections like List.
using System.Data.SqlClient;      // For the database connections and objects.
using System.Data.Sql;
using System.Data;
using CommonFunction;
using CommonLibrary;
using CommonControl.Functions;

namespace AX2020
{
	
	public partial class frm_prod_warehouse_fr_receive_ax : Form
	{
		public static string sqlconn = "Server=AX-UAT; Password=sbax2020sbg; User ID=sbax2020; Initial Catalog=SBG_AX_2020; Integrated Security=false";
		public static string sqlconnStaging = "Server=AX-SQL; Password=ax2020sbgroup; User ID=ax2020sb; Initial Catalog=AX2020StagingDB; Integrated Security=false";
        
		string ref_no = null; //, line_no;
		//string NextNo;
		string username;
		bool clickSearch = false, clickEdit = false;
		
		public frm_prod_warehouse_fr_receive_ax()
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

    		txtbx_qty_roll.Text = "0";	
    		btn_save.Enabled = true;
			btn_search.Enabled = true;
			
			
		}
		
		void Btn_cancelClick(object sender, EventArgs e)
		{
			this.Close();
		}
		
		void Btn_clearClick(object sender, EventArgs e)
		{
			ClearAllText(this);
			//DataGrid("SELECT PROD_LINE, PROD_DOCNO, PROD_CUSTOMER, PROD_REPORTDATE, PROD_CODE, PROD_BRAND, PROD_COLOR, PROD_MICRON, PROD_WIDTH, PROD_LENGTH, PROD_QTYCTN, PROD_QTYROLL FROM TBL_PROD_WAREHOUSE_FR_RECEIVED where PROD_DATE>= DATEADD(day,-14, getdate()) order by PROD_REPORTDATE DESC, PROD_LINE DESC", dt_grid);
			
		}
		
		void Btn_saveClick(object sender, EventArgs e)
		{
			if(String.IsNullOrWhiteSpace(txtbx_pack_no.Text))
			{
				MessageBox.Show("Please key in Packing Number first");
				return;
			}


			if(sqlConnParm("SP_PROD_WAREHOUSE_FR_RECEIVED_ADD") & UpdateNotReceived())
			{
				DialogBox.ShowSaveSuccessDialog();
				//DataGrid("SELECT PROD_LINE, PROD_DOCNO, PROD_CUSTOMER, PROD_REPORTDATE, PROD_CODE, PROD_BRAND, PROD_COLOR, PROD_MICRON, PROD_WIDTH, PROD_LENGTH, PROD_QTYCTN, PROD_QTYROLL FROM TBL_PROD_WAREHOUSE_FR_RECEIVED where PROD_REPORTDATE>= DATEADD(day,-3, getdate())", dt_grid);
				//DataGrid("SELECT PROD_LINE, PROD_DOCNO, PROD_CUSTOMER, PROD_DATE, PROD_CODE, PROD_BRAND, PROD_COLOR, PROD_MICRON, PROD_WIDTH, PROD_LENGTH, PROD_QTYCTN, PROD_QTYROLL FROM TBL_PROD_CONV_JO_PACKING where flag1 = 'N' and PROD_DATE>= DATEADD(day,-3, getdate())", dt_grid_not_received);
			}
			
			
			clickSearch = false;
			ClearAllText(this);
		}
		
		void Btn_searchClick(object sender, EventArgs e)
		{			
			if(!CheckDuplicate())
				return;
			
			else
			{
				SqlConnection con_search = new SqlConnection(sqlconn);
				SqlCommand cmd_search = new SqlCommand();
				
				try 
				{
					cmd_search.CommandText = "SELECT top 1 * FROM [AX2020StagingDB].[dbo].[VIEW_AXERP_QOH_ATTRIBUTE_FULLINFO_PM04] " +
					" where INVENTBATCHID like @line_no and a.availphysical > 1";
					
					cmd_search.Parameters.AddWithValue("@line_no",  txtbx_pack_no.Text);
					cmd_search.Connection = con_search;
					con_search.Open();
					SqlDataReader dr_search = cmd_search.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
						
					if (dr_search.Read())
					{
//						if(dr_search["INVENTBATCHID"] != DBNull.Value)
//						jr_shipmark 	= dr_search["INVENTBATCHID"].ToString();
////					else
////						jr_shipmark 	= "";
//					
//					if(dr_search["LOTNO"] != DBNull.Value)
//						jr_lot_no 		= dr_search["LOTNO"].ToString();
//					
//					if(dr_search["Grade"] != DBNull.Value)
//						jr_barcode 		= dr_search["Grade"].ToString();
					
					if(dr_search["Micron"] != DBNull.Value)
						txtbx_mic.Text 			= dr_search["Micron"].ToString();
					
					if(dr_search["Color"] != DBNull.Value)
						txtbx_color.Text 		= dr_search["Color"].ToString();
					
//					if(String.IsNullOrWhiteSpace(jr_barcode) && dr_search["SHIPMARK"] != DBNull.Value)
//						jr_barcode 		= dr_search["SHIPMARK"].ToString();
					
					if(dr_search["ITEMID"] != DBNull.Value)
						txtbx_prod_code.Text  	= dr_search["ITEMID"].ToString();

					if(dr_search["Width"] != DBNull.Value)						
						txtbx_width_cust.Text 		= dr_search["Width"].ToString();
					
					if(dr_search["LLength"] != DBNull.Value)	
						txtbx_length_cust.Text 		= dr_search["LLength"].ToString();
					
					if(dr_search["Brand"] != DBNull.Value)	
						txtbx_cust.Text		= dr_search["Brand"].ToString();
					
					txtbx_qty_roll.Text = dr_search["availphysical"].ToString();
						
						
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
			
			
			}
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
					
					txtbx_qty_roll.Text = rd_SP1["PROD_QTYROLL"].ToString();
					
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
					
					txtbx_qty_roll.Text = rd_SP1["PROD_QTYROLL"].ToString();
					

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
				dt.Columns[2].HeaderText = "Date";
				dt.Columns[2].Width = 80;
				dt.Columns[2].DefaultCellStyle.Format = "dd/MM/yyyy";
				dt.Columns[3].HeaderText = "Code";
				dt.Columns[3].Width = 80;
				dt.Columns[4].HeaderText = "Brand";
				dt.Columns[4].Width = 80;
				dt.Columns[5].HeaderText = "Color";
				dt.Columns[5].Width = 80;
				dt.Columns[6].HeaderText = "Micron";
				dt.Columns[7].HeaderText = "Width";
				dt.Columns[9].HeaderText = "Length";
				dt.Columns[10].HeaderText = "Qty";
				//No   Line No    Date     Code       Brand    Color   Micron   Width   Length  qty
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
				cmd_check_duplicate.CommandText = @"SELECT * FROM TBL_PROD_WAREHOUSE_AX_TRANSFER_ORDER where PROD_LINE = @line_no";
				//cmd_check_duplicate.Parameters.AddWithValue("@doc_no",  txtbx_ref_no.Text.ToUpper());
				cmd_check_duplicate.Parameters.AddWithValue("@line_no",  txtbx_pack_no.Text);
				cmd_check_duplicate.Connection = con_check_duplicate;
				con_check_duplicate.Open();
				SqlDataReader dr_check_duplicate = cmd_check_duplicate.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
					
				if (dr_check_duplicate.HasRows)
				{	
					MessageBox.Show("Duplicate item. This item had already been received");
					//DataGrid("SELECT PROD_LINE, PROD_DOCNO, PROD_CUSTOMER, PROD_REPORTDATE, PROD_CODE, PROD_BRAND, PROD_COLOR, PROD_MICRON, PROD_WIDTH, PROD_LENGTH, PROD_QTYCTN, PROD_QTYROLL FROM TBL_PROD_WAREHOUSE_FR_RECEIVED where PROD_LINE = '" + txtbx_pack_no.Text + "'", dt_grid);
		
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
			//No   Line No    Date     Code       Brand    Color   Micron   Width   Length  qty
			
			DataGrid("SELECT PROD_LINE, PROD_REPORTDATE, PROD_CODE, PROD_BRAND, PROD_COLOR, PROD_MICRON, PROD_WIDTH, PROD_LENGTH, PROD_QTY FROM TBL_PROD_WAREHOUSE_AX_TRANSFER_ORDER where PROD_REPORTDATE>= DATEADD(day,-3, getdate()) order by PROD_REPORTDATE DESC, PROD_LINE DESC and prod_remark1 = 'Packing'", dt_grid);
			//DataGrid("SELECT PROD_LINE, PROD_DATE, PROD_CODE, PROD_BRAND, PROD_COLOR, PROD_MICRON, PROD_WIDTH, PROD_LENGTH, PROD_QTY FROM TBL_PROD_WAREHOUSE_AX_TRANSFER_ORDER where flag1 = 'N' and PROD_DATE > '2017-10-01' and PROD_DATE>= DATEADD(day,-3, getdate()) and PROD_USERREVISION <> 'SAPS' ORDER BY PROD_DATE DESC, PROD_LINE", dt_grid_not_received);
						
		}
		
		
		bool sqlConnParm(string sqlStatement)
		{
			double jr_grossweight = 0;//string.Empty;
			double jr_netweight = 0;//string.Empty;
			double jr_qty = 0;
			
			SqlConnection con = new SqlConnection(sqlconnStaging);
			SqlCommand cmd = new SqlCommand();
				
			try 
			{
				cmd.CommandText = "SELECT top 1 * FROM [AX2020StagingDB].[dbo].[VIEW_AXERP_QOH_ALL] a left join [AX2020StagingDB].[dbo].[VIEW_AXERP_PDSBATCHATTRIBUTES_FULLINFO] b " +
  					" on a.INVENTBATCHID = b.INVENTBATCHID and a.itemid = b.ITEMID " +
					" where (a.INVENTBATCHID like @line_no and a.availphysical > 1";
					
				cmd.Parameters.AddWithValue("@line_no",  txtbx_pack_no.Text);
				cmd.Connection = con;
				con.Open();
				SqlDataReader rd = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
					
				if (rd.HasRows)
				{
					while (rd.Read())
					{
						if(rd["GROSSWEIGHT"] != DBNull.Value)
							jr_grossweight	= Convert.ToDouble(rd["GROSSWEIGHT"].ToString());
				
						if(rd["NETWEIGHT"] != DBNull.Value)
							jr_netweight		= Convert.ToDouble(rd["NETWEIGHT"].ToString());
						
						if(rd["availphysical"] != DBNull.Value)
							jr_qty		= Convert.ToDouble(rd["availphysical"].ToString());
																						
					} 
				}

			} 
			catch (Exception ex) 
			{
				MessageBox.Show("Error - Warehouse Transfer \nCannot load DB!" + ex.Message + ex.ToString());
				return false;
			} 
			finally 
			{
				con.Close();
			}
				
			con.Dispose();
			con = null;
			cmd = null;
			
			
			SqlConnection con_data = new SqlConnection(sqlconn);
			SqlCommand cmd_data = new SqlCommand();
			
			//			Code	LotNo	Customer	S.Mark	Barcode Color	Micron	Width	Length
	
			try
			{
				cmd_data.Connection = con_data;
				cmd_data.CommandText = sqlStatement;
				cmd_data.CommandType = CommandType.StoredProcedure;

				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_LINE", SqlDbType.NVarChar, 50));
				cmd_data.Parameters["@SP_PROD_LINE"].Value = txtbx_pack_no.Text.ToUpper();
					
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_REPORTDATE", SqlDbType.DateTime));
				cmd_data.Parameters["@SP_PROD_REPORTDATE"].Value = DateTime.Now;

				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_CODE", SqlDbType.NVarChar, 50));
				cmd_data.Parameters["@SP_PROD_CODE"].Value = txtbx_prod_code.Text;
					
						
					
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_SHIPMARK", SqlDbType.NVarChar, 50));
				cmd_data.Parameters["@SP_PROD_SHIPMARK"].Value = txtbx_pack_no.Text;
					
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_BARCODE", SqlDbType.NVarChar, 50));
				cmd_data.Parameters["@SP_PROD_BARCODE"].Value = txtbx_pack_no.Text;
						
					
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_LOTNO", SqlDbType.NVarChar, 50));
				cmd_data.Parameters["@SP_PROD_LOTNO"].Value = txtbx_pack_no.Text;
					
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_CUSTOMER", SqlDbType.NVarChar, 50));
				cmd_data.Parameters["@SP_PROD_CUSTOMER"].Value = txtbx_brand.Text;	
					
		
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_COLOR", SqlDbType.NVarChar, 50));
				cmd_data.Parameters["@SP_PROD_COLOR"].Value = txtbx_color.Text;
					
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_BRAND", SqlDbType.NVarChar, 50));
				cmd_data.Parameters["@SP_PROD_BRAND"].Value = txtbx_brand.Text;
				

				//--------------------------------------------------------------------------------------------------------------
					
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_WIDTH", SqlDbType.Float));
				//cmd_data.Parameters["@SP_PRODC_STOCKDESC"].Value = dt_grid_consume.Rows[i].Cells[2].Value.ToString().ToUpper();
				cmd_data.Parameters["@SP_PROD_WIDTH"].Value = Convert.ToDouble(txtbx_width_cust.Text);
				
				
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_LENGTH", SqlDbType.Float));
				cmd_data.Parameters["@SP_PROD_LENGTH"].Value = Convert.ToDouble(txtbx_length_cust.Text);
					
					
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_MICRON", SqlDbType.Float));
				cmd_data.Parameters["@SP_PROD_MICRON"].Value = txtbx_mic.Text;
					
				
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_FROMWAREHOUSE", SqlDbType.NVarChar, 50));
				cmd_data.Parameters["@SP_PROD_FROMWAREHOUSE"].Value = "GFWPM04";
				
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_TOWAREHOUSE", SqlDbType.NVarChar, 50));
				cmd_data.Parameters["@SP_PROD_TOWAREHOUSE"].Value = "GFWSM05";
					
								

				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_GROSSWEIGT", SqlDbType.NVarChar, 50));
				cmd_data.Parameters["@SP_PROD_GROSSWEIGT"].Value = jr_grossweight;
					
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_NETWIGHT", SqlDbType.NVarChar, 50));
				cmd_data.Parameters["@SP_PROD_NETWIGHT"].Value = jr_netweight;
				
				
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_QTY", SqlDbType.Float));
				cmd_data.Parameters["@SP_PROD_QTY"].Value = jr_qty;
				
				
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_REMARK1", SqlDbType.NVarChar, 50));
				cmd_data.Parameters["@SP_PROD_REMARK1"].Value = "PACKING";
					
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_REMARK2", SqlDbType.NVarChar, 50));
				cmd_data.Parameters["@SP_PROD_REMARK2"].Value = "";
				
				cmd_data.Parameters.Add(new SqlParameter("@SP_FLAG1", SqlDbType.NVarChar, 2));
				cmd_data.Parameters["@SP_FLAG1"].Value = "Y";
				
				cmd_data.Parameters.Add(new SqlParameter("@SP_FLAG2", SqlDbType.NVarChar, 2));
				cmd_data.Parameters["@SP_FLAG2"].Value = "Y";
				
				cmd_data.Parameters.Add(new SqlParameter("@SP_FLAG3", SqlDbType.NVarChar, 2));
				cmd_data.Parameters["@SP_FLAG3"].Value = "N";
				
				
									
				
				//-----------------------------------------------------------------------------------------------
															
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
				MessageBox.Show("Error Glue \nCannot save Warehouse Transfer in DB \n" + ex.Message + ex.ToString());			
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
	
			   		
			}	
		}
		
		
	}
}
