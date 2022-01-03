using System;
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

namespace AX2020
{
	
	public partial class frm_prod_warehouse_stretch_film_received : Form
	{
		public static string sqlconn = "Server=AX-UAT; Password=sbax2020sbg; User ID=sbax2020; Initial Catalog=SBG_AX_2020; Integrated Security=false";
		
		//string ref_no = null, line_no;
		//string NextNo;
		string username;
		bool clickSearch = false;
		
		public frm_prod_warehouse_stretch_film_received()
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
		}
		
		void Btn_cancelClick(object sender, EventArgs e)
		{
			this.Close();
		}
		
		void Btn_clearClick(object sender, EventArgs e)
		{
			ClearAllText(this);
		}
		
		void Btn_saveClick(object sender, EventArgs e)
		{
			
			if(clickSearch == true)
			{
				if(sqlConnParm("SP_PROD_WAREHOUSE_STRETCH_FILM_RECEIVED_ADD") & UpdateNotReceived())
				{
					DialogBox.ShowSaveSuccessDialog();
					DataGrid("SELECT PROD_DOCNO, PROD_DATE, PROD_STOCKCODE, PROD_STOCKDESC, PROD_UOM, PROD_QTY FROM TBL_PROD_WAREHOUSE_STRETCH_FILM_RECEIVED  where PROD_DATE>= DATEADD(day,-30, getdate())", dt_grid);
					DataGrid("SELECT PROD_DOCNO, PROD_DATE, PROD_STOCKCODE, PROD_STOCKDESC, PROD_UOM, PROD_QTY FROM TBL_PROD_STRETCH_FILM_OUTPUT where PROD_FLAG1 = 'N' and PROD_DATE>= DATEADD(day,-30, getdate())", dt_grid_not_received);
		
				}
			}
//			else
//			{
//				if(sqlConnParm("SP_PROD_WAREHOUSE_STRETCH_FILM_RECEIVED_EDIT"))
//				{
//					DialogBox.ShowSaveSuccessDialog();
//					DataGrid();
//				}
//			}
			
			clickSearch = false;
		}
		
		bool UpdateNotReceived()
		{
			SqlConnection conUpdate = new SqlConnection(sqlconn);
			SqlCommand cmdUpdate = new SqlCommand();

			try
			{
				cmdUpdate.CommandText = @"UPDATE TBL_PROD_STRETCH_FILM_OUTPUT SET PROD_FLAG1 = 'Y' where PROD_DOCNO = @doc_no";
				//cmd_SP1.Parameters.AddWithValue("@doc_no",  txtbx_ref_no.Text);
        		cmdUpdate.Parameters.AddWithValue("@doc_no",  txtbx_pack_no.Text);
				cmdUpdate.Connection = conUpdate;

				conUpdate.Open();
				cmdUpdate.ExecuteNonQuery();

			}
			catch (Exception ex)
			{
				conUpdate.Close();
				MessageBox.Show("Error - Warehouse Stretch Film Received Update \nCannot update DB" + ex.Message + ex.ToString());
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
		
		void Btn_searchClick(object sender, EventArgs e)
		{
			
			
			if(!CheckDuplicate())
				return;
			
			SqlConnection con_search = new SqlConnection(sqlconn);
			SqlCommand cmd_search = new SqlCommand();
				
			try 
			{
				cmd_search.CommandText = @"SELECT * FROM TBL_PROD_STRETCH_FILM_OUTPUT where PROD_DOCNO = @doc_no";
				cmd_search.Parameters.AddWithValue("@doc_no",  txtbx_pack_no.Text.ToUpper());
				cmd_search.Connection = con_search;
				con_search.Open();
				SqlDataReader dr_search = cmd_search.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
					
				if (dr_search.Read())
				{					

					txtbx_stock_code.Text = dr_search["PROD_STOCKCODE"].ToString();
					txtbx_desc.Text = dr_search["PROD_STOCKDESC"].ToString();
					txtbx_qty.Text = dr_search["PROD_QTY"].ToString();
					txtbx_uom.Text = dr_search["PROD_UOM"].ToString();
					txtbx_qty_received.Text = txtbx_qty.Text;
					
				} 
				else 
				{
					MessageBox.Show("Error Warehouse Stretch Film Search : Cannot find JO!");
					return;
				}
			} 
			catch (Exception ex) 
			{
				MessageBox.Show("Error Warehouse Stretch Film Search : Cannot load DB!" + ex.Message + ex.ToString());
				return;
			} 
			finally 
			{
				con_search.Close();
			}
			con_search.Dispose();
			cmd_search = null;
			
			
			clickSearch = true;
		}
		

		
		
		void Dt_gridCellClick(object sender, DataGridViewCellEventArgs e)
		{
			if(dt_grid.SelectedRows.Count > 0) // make sure user select at least 1 row 
			{
				txtbx_pack_no.Text = dt_grid.SelectedRows[0].Cells[1].Value + string.Empty;
				txtbx_stock_code.Text = dt_grid.SelectedRows[0].Cells[3].Value + string.Empty;
				txtbx_desc.Text = dt_grid.SelectedRows[0].Cells[4].Value + string.Empty;
				txtbx_uom.Text = dt_grid.SelectedRows[0].Cells[5].Value + string.Empty;
				txtbx_qty.Text = dt_grid.SelectedRows[0].Cells[6].Value + string.Empty;
			   	Retrieve();
				btn_save.Enabled = false;			   	
			}	
		}
		
		void Retrieve()
		{
			SqlConnection con_SP1 = new SqlConnection(sqlconn);
			SqlCommand cmd_SP1 = new SqlCommand();
				
			try 
			{
				cmd_SP1.CommandText = @"SELECT * FROM TBL_PROD_WAREHOUSE_STRETCH_FILM_RECEIVED where PROD_DOCNO = @doc_no";
				cmd_SP1.Parameters.AddWithValue("@doc_no",  txtbx_pack_no.Text);
 
				cmd_SP1.Connection = con_SP1;
				con_SP1.Open();
				SqlDataReader rd_SP1 = cmd_SP1.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
					
				if (rd_SP1.Read())
				{				        	
//					txtbx_stock_code.Text = rd_SP1["PROD_STOCKCODE"].ToString();
//					txtbx_desc.Text = rd_SP1["PROD_STOCKDESC"].ToString();
//					txtbx_uom.Text = rd_SP1["PROD_UOM"].ToString();
//					txtbx_qty.Text = rd_SP1["PROD_QTY"].ToString();
					
					txtbx_qty_received.Text = rd_SP1["PROD_QTYRECEIVED"].ToString();
				} 
				
			} 
			catch (Exception ex) 
			{
				MessageBox.Show("Error Warehouse Stretch FIlm Stock Received Pack Retrieve: Cannot load DB!" + ex.Message + ex.ToString());
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
				cmd_SP1.CommandText = @"SELECT * FROM TBL_PROD_STRETCH_FILM_OUTPUT where PROD_DOCNO = @doc_no";
				cmd_SP1.Parameters.AddWithValue("@doc_no",  txtbx_pack_no.Text);
 
				cmd_SP1.Connection = con_SP1;
				con_SP1.Open();
				SqlDataReader rd_SP1 = cmd_SP1.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
					
				if (rd_SP1.Read())
				{				        	
//					txtbx_stock_code.Text = rd_SP1["PROD_STOCKCODE"].ToString();
//					txtbx_desc.Text = rd_SP1["PROD_STOCKDESC"].ToString();
//					txtbx_uom.Text = rd_SP1["PROD_UOM"].ToString();
//					txtbx_qty.Text = rd_SP1["PROD_QTY"].ToString();
					
					txtbx_qty_received.Text = rd_SP1["PROD_QTYRECEIVED"].ToString();
				} 
				
			} 
			catch (Exception ex) 
			{
				MessageBox.Show("Error Warehouse Stretch Film Stock Received Pack Retrieve: Cannot load DB!" + ex.Message + ex.ToString());
				return;
			} 
			finally 
			{
				con_SP1.Close();
			}
			
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
				dt.Columns[1].HeaderText = "Doc No";
				dt.Columns[1].Width = 50;
				dt.Columns[2].HeaderText = "Date";
				dt.Columns[2].Width = 80;
				dt.Columns[2].DefaultCellStyle.Format = "dd/MM/yyyy";
				dt.Columns[3].HeaderText = "Stock Code";
				dt.Columns[3].Width = 80;
				dt.Columns[4].HeaderText = "Description";
				dt.Columns[4].Width = 150;
				dt.Columns[5].HeaderText = "UOM";
				dt.Columns[5].Width = 80;
				dt.Columns[6].HeaderText = "Qty";
				dt.Columns[6].Width = 80;
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
				cmd_check_duplicate.CommandText = @"SELECT * FROM TBL_PROD_WAREHOUSE_STRETCH_FILM_RECEIVED where PROD_DOCNO = @doc_no";
				cmd_check_duplicate.Parameters.AddWithValue("@doc_no",  txtbx_pack_no.Text.ToUpper());
				
				cmd_check_duplicate.Connection = con_check_duplicate;
				con_check_duplicate.Open();
				SqlDataReader dr_check_duplicate = cmd_check_duplicate.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
					
				if (dr_check_duplicate.HasRows)
				{	
					MessageBox.Show("Duplicate item. This item had already been received");
					return false;
				} 
			} 
			catch (Exception ex) 
			{
				MessageBox.Show("Error : Warehouse Stretch Film Stock Receive Pack\nCannot load Duplicate DB!" + ex.Message + ex.ToString());
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
		
		bool sqlConnParm(string sqlStatement)
		{
			SqlConnection con_data = new SqlConnection(sqlconn);
			SqlCommand cmd_data = new SqlCommand();
			
			try
			{
				cmd_data.Connection = con_data;
				cmd_data.CommandText = sqlStatement;
				cmd_data.CommandType = CommandType.StoredProcedure;
 				
					
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_DOCNO", SqlDbType.NVarChar, 50));
				cmd_data.Parameters["@SP_PROD_DOCNO"].Value = txtbx_pack_no.Text.ToUpper();
					
					
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_REPORTDATE", SqlDbType.DateTime));
				cmd_data.Parameters["@SP_PROD_REPORTDATE"].Value = DateTime.Now;
					
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_DATERECEIVED", SqlDbType.DateTime));
				cmd_data.Parameters["@SP_PROD_DATERECEIVED"].Value = DateTime.Now;	
					
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_QTYRECEIVED", SqlDbType.Float));
				cmd_data.Parameters["@SP_PROD_QTYRECEIVED"].Value = Double.Parse(txtbx_qty_received.Text);
					
				
					
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
				MessageBox.Show("Error Warehouse Stretch Film Stock Received \n" + ex.Message + ex.ToString());			
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
		
		void Frm_prod_warehouse_stretch_film_receivedLoad(object sender, EventArgs e)
		{
			DataGrid("SELECT PROD_DOCNO, PROD_DATE, PROD_STOCKCODE, PROD_STOCKDESC, PROD_UOM, PROD_QTY FROM TBL_PROD_WAREHOUSE_STRETCH_FILM_RECEIVED  where PROD_DATE>= DATEADD(day,-30, getdate())", dt_grid);
			DataGrid("SELECT PROD_DOCNO, PROD_DATE, PROD_STOCKCODE, PROD_STOCKDESC, PROD_UOM, PROD_QTY FROM TBL_PROD_STRETCH_FILM_OUTPUT where PROD_FLAG1 = 'N' and PROD_DATE>= DATEADD(day,-30, getdate())", dt_grid_not_received);
	
		}
		
		void Dt_grid_not_receivedCellClick(object sender, DataGridViewCellEventArgs e)
		{
			if(dt_grid_not_received.SelectedRows.Count > 0) // make sure user select at least 1 row 
			{
				clickSearch = true;
				ClearAllText(this);
				btn_save.Enabled = true;
				txtbx_pack_no.Text = dt_grid_not_received.SelectedRows[0].Cells[1].Value + string.Empty;
				txtbx_stock_code.Text = dt_grid_not_received.SelectedRows[0].Cells[3].Value + string.Empty;
				txtbx_desc.Text = dt_grid_not_received.SelectedRows[0].Cells[4].Value + string.Empty;
				txtbx_uom.Text = dt_grid_not_received.SelectedRows[0].Cells[5].Value + string.Empty;
				txtbx_qty.Text = dt_grid_not_received.SelectedRows[0].Cells[6].Value + string.Empty;
				txtbx_qty_received.Text = txtbx_qty.Text;
			   	//Retrieve2();	   		
			}	
		}
}
}