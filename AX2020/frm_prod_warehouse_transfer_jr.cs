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
using System.Linq;

namespace AX2020
{
	/// <summary>
	/// Description of frm_prod_warehouse_transfer_jr.
	/// </summary>
	public partial class frm_prod_warehouse_transfer_jr : Form
	{
		public static string sqlconn = "Server=AX-UAT; Password=sbax2020sbg; User ID=sbax2020; Initial Catalog=SBG_AX_2020; Integrated Security=false";
		public static string sqlconnStaging = "Server=AX-SQL; Password=ax2020sbgroup; User ID=ax2020sb; Initial Catalog=AX2020StagingDB; Integrated Security=false";
        						
		string username;
		int NextNo;
		
		public frm_prod_warehouse_transfer_jr()
		{
			InitializeComponent();

			username = frm_menu_system.userName; 
			lbl_username.Text = "User : " + username;
			
			InitializeDataGridOutput();	
			
			DropDownList("SELECT WAREHOUSEID FROM TBL_PROD_WAREHOUSE_AX_WAREHOUSE WHERE FLAG1 = 'FROM' and flag2 = 'JR' ORDER BY WAREHOUSEID", cbx_warehouse_from, "WAREHOUSEID");
			DropDownList("SELECT WAREHOUSEID FROM TBL_PROD_WAREHOUSE_AX_WAREHOUSE WHERE FLAG1 = 'TO' and flag2 = 'JR' ORDER BY WAREHOUSEID", cbx_warehouse_to, "WAREHOUSEID");
		
		}
		

		void Btn_addClick(object sender, EventArgs e)
		{
			
			
			if(String.IsNullOrWhiteSpace(txtbx_shipmark.Text))
			{
				MessageBox.Show("Please key in shipping mark or barcode");
				txtbx_shipmark.Focus();
				return;
			}
			else if(String.IsNullOrWhiteSpace(cbx_warehouse_from.Text) || cbx_warehouse_from.Text == "Please Select")
			{
				MessageBox.Show("Please select warehouse");
				cbx_warehouse_from.Focus();
				return;
			}
			
			for(int i=0; i<dt_grid_add.RowCount; i++)
			{
				if(dt_grid_add.Rows[i].Cells[3].Value.ToString() ==  txtbx_shipmark.Text)
				{
					MessageBox.Show("Shipping Mark already added");
					return;
				}
			}
			Search();
		
							
		}
		
		void dt_grid_addCellClick(object sender, DataGridViewCellEventArgs e)
		{
			if(e.RowIndex == -1) 
			return;

   			    if( e.RowIndex == dt_grid_add.NewRowIndex || e.RowIndex < 0)
		        return;
		
		    //Check if click is on specific column 
		    if(e.ColumnIndex  == dt_grid_add.Columns["dataGridViewDeleteButton"].Index)
		    {
		        //Put some logic here, for example to remove row from your binding list.
		        dt_grid_add.Rows.RemoveAt(e.RowIndex);
		    }
		}
		
		
		void InitializeDataGridOutput()
		{

			dt_grid_add.ColumnCount = 10;
			
//			dt_grid_add.Columns[0].Name = "No";
//            dt_grid_add.Columns[0].Width = 35;
//            dt_grid_add.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dt_grid_add.Columns[0].Name = "Stock Code";
            dt_grid_add.Columns[0].Width = 50;
            dt_grid_add.Columns[0].ReadOnly = true;
            dt_grid_add.Columns[1].Name = "LotNo";
			dt_grid_add.Columns[1].Width = 80;            
			dt_grid_add.Columns[1].ReadOnly = true;
			dt_grid_add.Columns[2].Name = "Customer";
			dt_grid_add.Columns[2].Width = 100;
			dt_grid_add.Columns[2].ReadOnly = true;
            dt_grid_add.Columns[3].Name = "Shipping Mark";
			dt_grid_add.Columns[3].Width = 80;
			dt_grid_add.Columns[3].ReadOnly = true;
			dt_grid_add.Columns[4].Name = "Barcode";
			dt_grid_add.Columns[4].Width = 70;
			dt_grid_add.Columns[4].ReadOnly = true;
			dt_grid_add.Columns[5].Name = "Color";
			dt_grid_add.Columns[5].Width = 50;
			dt_grid_add.Columns[5].ReadOnly = true;
			dt_grid_add.Columns[6].Name = "Micron";
			dt_grid_add.Columns[6].Width = 50;
			dt_grid_add.Columns[6].ReadOnly = true;
			dt_grid_add.Columns[7].Name = "Width";
			dt_grid_add.Columns[7].Width = 50;
			dt_grid_add.Columns[7].ReadOnly = true;
			dt_grid_add.Columns[8].Name = "Length";
			dt_grid_add.Columns[8].Width = 50;
			dt_grid_add.Columns[9].ReadOnly = true;
			dt_grid_add.Columns[9].Name = "Warehouse";
			dt_grid_add.Columns[9].Width = 50;
			dt_grid_add.Columns[9].ReadOnly = true;
			
			
			
//			Code	LotNo	Customer	S.Mark	Barcode Color	Micron	Width	Length

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
//                if(c is ComboBox)
//                	((ComboBox)c).Items.Clear(); 
	
				if(c is DateTimePicker)
				{
					((DateTimePicker)c).Value = DateTime.Now;
				}  
   			}
    		
    		dt_grid_add.Rows.Clear();
		}
		
		
		private void DropDownList(string cmd, ComboBox cbx_text, string col_name)
		{
		    SqlConnection conn = new SqlConnection(sqlconn);
            DataSet ds = new DataSet();
            string cmdSQL = cmd;
            SqlDataAdapter sda = new SqlDataAdapter(cmdSQL, conn);

            try
            {
                conn.Open();
                sda.Fill(ds);
                cbx_text.Items.Add("Please Select");           
            }
            catch(SqlException se)
            {
            	MessageBox.Show("Error - Warehouse Transfer DropDown List \nCannot load DB" + se.ToString() + se.Message);
            }
            finally
            {
                conn.Close();
            }
			
           	foreach(DataRow dr1 in ds.Tables[0].Rows)
           	{
               cbx_text.Items.Add(dr1[col_name].ToString());
           	}
            //cbx_tape.DataSource = ds.Tables[0];
            //cbx_tape.DisplayMember = ds.Tables[0].Columns[0].ToString();
            //cbx_tape.SelectedIndex = 3;
            cbx_text.SelectedItem = "Please Select";

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
		

		
		void Btn_saveClick(object sender, EventArgs e)
		{
			if(cbx_warehouse_to.Text == "Please Select")
			{
				MessageBox.Show("Please select To Warehouse");
				return;
			}
			
			for(int i=0; i<dt_grid_add.RowCount; i++)
			{
				if(dt_grid_add.Rows[i].Cells[9].Value.ToString() ==  cbx_warehouse_to.Text)
				{
					MessageBox.Show("Cannot transfer to same warehouse");
					return;
				}
			}
			
			
				
			
			if(!LineNoGenerator())
				return;
			
			for(int i=0; i<dt_grid_add.RowCount; i++)
			{
				//string shipmark = dt_grid_consume.Rows[i].Cells[0].Value.ToString().ToUpper();
				
				if(!sqlConnParm("SP_PROD_WAREHOUSE_AX_TRANSFER_ORDER_ADD", i))
					return;
//				else
//				{
//					DialogBox.ShowSaveSuccessDialog();
//					ClearAllText(this);
//				}
			}
			DialogBox.ShowSaveSuccessDialog();
			ClearAllText(this);			
		}
		
		public bool sqlConnParm(string sqlStatement, int i)
		{
			string jr_grossweight = string.Empty, jr_netweight = string.Empty;
			double jr_qty = 0;
			
			SqlConnection con = new SqlConnection(sqlconnStaging);
			SqlCommand cmd = new SqlCommand();
				
			try 
			{
				cmd.CommandText = "SELECT top 1 * FROM [AX2020StagingDB].[dbo].[VIEW_AXERP_QOH_ALL] a left join [AX2020StagingDB].[dbo].[VIEW_AXERP_PDSBATCHATTRIBUTES_FULLINFO] b " +
  					" on a.INVENTBATCHID = b.INVENTBATCHID and a.itemid = b.ITEMID " +
					" where (a.INVENTBATCHID like @ship_mark + '%' or B.GRADE like @ship_mark + '%') and a.inventlocationid = @whse and a.availphysical > 1";
				cmd.Parameters.AddWithValue("@ship_mark",  dt_grid_add.Rows[i].Cells[3].Value.ToString().ToUpper());
				cmd.Parameters.AddWithValue("@whse",  dt_grid_add.Rows[i].Cells[9].Value.ToString().ToUpper());
				cmd.Connection = con;
				con.Open();
				SqlDataReader rd = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
					
				if (rd.HasRows)
				{
					while (rd.Read())
					{
						if(rd["GROSSWEIGHT"] != DBNull.Value)
							jr_grossweight	= rd["GROSSWEIGHT"].ToString();
				
						if(rd["NETWEIGHT"] != DBNull.Value)
							jr_netweight		= rd["NETWEIGHT"].ToString();
						
						if(rd["availphysical"] != DBNull.Value)
							jr_qty		= Convert.ToDouble(rd["availphysical"].ToString());
										
												
					} 
				}
//				else 
//				{
//					MessageBox.Show("Error 2 - Cannot find shipping mark attributes!");
//					return;
//				}
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
				cmd_data.Parameters["@SP_PROD_LINE"].Value = "W1." + NextNo;
					
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_REPORTDATE", SqlDbType.DateTime));
				cmd_data.Parameters["@SP_PROD_REPORTDATE"].Value = DateTime.Now;

				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_CODE", SqlDbType.NVarChar, 50));
				cmd_data.Parameters["@SP_PROD_CODE"].Value = dt_grid_add.Rows[i].Cells[0].Value.ToString().ToUpper();
					
						
					
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_SHIPMARK", SqlDbType.NVarChar, 50));
				cmd_data.Parameters["@SP_PROD_SHIPMARK"].Value = dt_grid_add.Rows[i].Cells[3].Value.ToString().ToUpper();
					
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_BARCODE", SqlDbType.NVarChar, 50));
				cmd_data.Parameters["@SP_PROD_BARCODE"].Value = dt_grid_add.Rows[i].Cells[4].Value.ToString().ToUpper();
						
					
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_LOTNO", SqlDbType.NVarChar, 50));
				cmd_data.Parameters["@SP_PROD_LOTNO"].Value = dt_grid_add.Rows[i].Cells[1].Value.ToString().ToUpper();
					
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_CUSTOMER", SqlDbType.NVarChar, 50));
				cmd_data.Parameters["@SP_PROD_CUSTOMER"].Value = dt_grid_add.Rows[i].Cells[2].Value.ToString().ToUpper();
					
					
		
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_COLOR", SqlDbType.NVarChar, 50));
				cmd_data.Parameters["@SP_PROD_COLOR"].Value = dt_grid_add.Rows[i].Cells[5].Value.ToString().ToUpper();
					
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_BRAND", SqlDbType.NVarChar, 50));
				cmd_data.Parameters["@SP_PROD_BRAND"].Value = dt_grid_add.Rows[i].Cells[2].Value.ToString().ToUpper();
				

				//--------------------------------------------------------------------------------------------------------------
					
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_WIDTH", SqlDbType.Float));
				//cmd_data.Parameters["@SP_PRODC_STOCKDESC"].Value = dt_grid_consume.Rows[i].Cells[2].Value.ToString().ToUpper();
				cmd_data.Parameters["@SP_PROD_WIDTH"].Value = dt_grid_add.Rows[i].Cells[7].Value.ToString().ToUpper();
				
				
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_LENGTH", SqlDbType.Float));
				cmd_data.Parameters["@SP_PROD_LENGTH"].Value = dt_grid_add.Rows[i].Cells[8].Value.ToString().ToUpper();
					
					
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_MICRON", SqlDbType.Float));
				cmd_data.Parameters["@SP_PROD_MICRON"].Value = dt_grid_add.Rows[i].Cells[6].Value.ToString().ToUpper();
					
				
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_FROMWAREHOUSE", SqlDbType.NVarChar, 50));
				cmd_data.Parameters["@SP_PROD_FROMWAREHOUSE"].Value = dt_grid_add.Rows[i].Cells[9].Value.ToString().ToUpper();
				
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_TOWAREHOUSE", SqlDbType.NVarChar, 50));
				cmd_data.Parameters["@SP_PROD_TOWAREHOUSE"].Value = cbx_warehouse_to.Text;
					
								

				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_GROSSWEIGT", SqlDbType.NVarChar, 50));
				cmd_data.Parameters["@SP_PROD_GROSSWEIGT"].Value = jr_grossweight;
					
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_NETWIGHT", SqlDbType.NVarChar, 50));
				cmd_data.Parameters["@SP_PROD_NETWIGHT"].Value = jr_netweight;
				
				
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_QTY", SqlDbType.Float));
				cmd_data.Parameters["@SP_PROD_QTY"].Value = jr_qty;
				
				
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_REMARK1", SqlDbType.NVarChar, 50));
				cmd_data.Parameters["@SP_PROD_REMARK1"].Value = "";
					
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_REMARK2", SqlDbType.NVarChar, 50));
				cmd_data.Parameters["@SP_PROD_REMARK2"].Value = "";
				
				cmd_data.Parameters.Add(new SqlParameter("@SP_FLAG1", SqlDbType.NVarChar, 2));
				cmd_data.Parameters["@SP_FLAG1"].Value = "Y";
				
				cmd_data.Parameters.Add(new SqlParameter("@SP_FLAG2", SqlDbType.NVarChar, 2));
				cmd_data.Parameters["@SP_FLAG2"].Value = "N";
				
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
		
		void Btn_clearClick(object sender, EventArgs e)
		{
			ClearAllText(this);	
		}
				
		void Btn_cancelClick(object sender, EventArgs e)
		{
			this.Close();
		}
		
		void Search()
		{
			string jr_shipmark 	= string.Empty,
			jr_lot_no  			= string.Empty,
			jr_ref_no 			= string.Empty,
			jr_mic 				= string.Empty, 
			jr_color 			= string.Empty, 
			jr_barcode 			= string.Empty, 
			jr_stockcode 		= string.Empty, 
			jr_width 			= string.Empty, 
			jr_length 			= string.Empty, 
			jr_brand 			= string.Empty;
			
			//------------------------------------------------------------------------
			
			string searchShipaMark = txtbx_shipmark.Text;
			
			//------------------------------------------------------------------------
			
//			SqlConnection con_search = new SqlConnection(sqlconn);
//			SqlCommand cmd_search = new SqlCommand();
//				
//			try 
//			{
//				cmd_search.CommandText = "select top 1 * from VIEW_CONVERTING_BARCODE" +
//					" where JRBarcode like @ship_mark +'%'";
//				cmd_search.Parameters.AddWithValue("@ship_mark",  txtbx_shipmark.Text.ToUpper());
//				//cmd_search.Parameters.AddWithValue("@whse",  cbx_warehouse_from.Text);
//				cmd_search.Connection = con_search;
//				con_search.Open();
//				SqlDataReader rd_search = cmd_search.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
//					
//				if (rd_search.HasRows)
//				{
//					while (rd_search.Read())
//					{		
//						jr_shipmark 	= rd_search["trxshipmark"].ToString();
//						jr_barcode 		= rd_search["JRBarcode"].ToString();
//						//jr_ref_no 		= rd_search["trxJono"].ToString();
//						
//						
//						//jr_color 		= rd_search["trxjoColor"].ToString();
//						
//						//if(jr_shipmark != txtbx_shipmark.Text.ToUpper())
//						//{
//							//jr_stockcode 	= rd_search["trxJOrawcode"].ToString();
//							//jr_lot_no 		= rd_search["trxrawLOTNO"].ToString();
//							//jr_mic 			= rd_search["trxrawlotthickness"].ToString();
//						//}
//						//else
//						//{
//							//jr_stockcode 	= rd_search["trxjostkcode"].ToString();
//							//jr_lot_no 		= rd_search["trxLOTNO"].ToString();
//							//jr_mic 			= rd_search["trxjothickness"].ToString();
//						//}
//						
//													
//						//jr_width 		= rd_search["trxjoWidth"].ToString();
//						//jr_length 		= rd_search["trxtotalLength"].ToString();
//						//jr_brand		= rd_search["trxjoBrand"].ToString();
//												
//					} 
//				}
//				
//			} 
//			catch (Exception ex) 
//			{
//				MessageBox.Show("Error - Warehouse Transfer \nCannot load DB!" + ex.Message + ex.ToString());
//				return;
//			} 
//			finally 
//			{
//				con_search.Close();
//			}
//				
//			con_search.Dispose();
//			con_search = null;
//			cmd_search = null;
			
			
			//------------------------------------------------------------------------
			
			
			SqlConnection con = new SqlConnection(sqlconnStaging);
			SqlCommand cmd = new SqlCommand();
				
			try 
			{
				cmd.CommandText = "SELECT top 1 * FROM [AX2020StagingDB].[dbo].[VIEW_AXERP_QOH_ALL] a left join [AX2020StagingDB].[dbo].[VIEW_AXERP_PDSBATCHATTRIBUTES_FULLINFO] b " +
  					" on a.INVENTBATCHID = b.INVENTBATCHID and a.itemid = b.ITEMID " +
					" where (a.INVENTBATCHID like @ship_mark + '%' or B.GRADE like @ship_mark + '%') and a.inventlocationid = @whse and a.availphysical > 1";
				cmd.Parameters.AddWithValue("@ship_mark",  txtbx_shipmark.Text.ToUpper());
				cmd.Parameters.AddWithValue("@whse",  cbx_warehouse_from.Text);
				cmd.Connection = con;
				con.Open();
				SqlDataReader rd = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
					
				if (rd.HasRows)
				{
					while (rd.Read())
					{
					if(rd["INVENTBATCHID"] != DBNull.Value)
						jr_shipmark 	= rd["INVENTBATCHID"].ToString();
//					else
//						jr_shipmark 	= "";
					
					if(rd["LOTNO"] != DBNull.Value)
						jr_lot_no 		= rd["LOTNO"].ToString();
					
					if(rd["Grade"] != DBNull.Value)
						jr_barcode 		= rd["Grade"].ToString();
					
					if(rd["Micron"] != DBNull.Value)
						jr_mic 			= rd["Micron"].ToString();
					
					if(rd["Color"] != DBNull.Value)
						jr_color 		= rd["Color"].ToString();
					
//					if(String.IsNullOrWhiteSpace(jr_barcode) && rd["SHIPMARK"] != DBNull.Value)
//						jr_barcode 		= rd["SHIPMARK"].ToString();
					
					if(rd["ITEMID"] != DBNull.Value)
						jr_stockcode 	= rd["ITEMID"].ToString();

					if(rd["Width"] != DBNull.Value)						
						jr_width 		= rd["Width"].ToString();
					
					if(rd["LLength"] != DBNull.Value)	
						jr_length 		= rd["LLength"].ToString();
					
					if(rd["Brand"] != DBNull.Value)	
						jr_brand		= rd["Brand"].ToString();
						
						//---------------------------------------Add Rows-----------------------------------
			
			//			Code	LotNo	Customer	S.Mark	Barcode Color	Micron	Width	Length
						
						if(jr_shipmark != txtbx_shipmark.Text.ToUpper())
						{
							dt_grid_add.Rows.Add(jr_stockcode, jr_lot_no, jr_brand, jr_lot_no, jr_lot_no, jr_color, jr_mic, jr_width, jr_length, cbx_warehouse_from.Text);
			
						}
						else						
							dt_grid_add.Rows.Add(jr_stockcode, jr_lot_no, jr_brand, jr_shipmark, jr_barcode, jr_color, jr_mic, jr_width, jr_length, cbx_warehouse_from.Text);
			
						if (! dt_grid_add.Columns.Contains("dataGridViewDeleteButton"))
						{
							var deleteButton = new DataGridViewButtonColumn();
							deleteButton.Name="dataGridViewDeleteButton";
							deleteButton.HeaderText="";
							deleteButton.Text="X";
							deleteButton.CellTemplate.Style.ForeColor = Color.Red;
							deleteButton.CellTemplate.Style.Font = new Font("Arial", 12, FontStyle.Bold);
							//deleteButton.CellTemplate.Style.Font
							deleteButton.UseColumnTextForButtonValue=true;
							this.dt_grid_add.Columns.Add(deleteButton);
							this.dt_grid_add.Columns[10].Width = 15;
						}
												
					} 
				}
				else 
				{
					MessageBox.Show("Error 2 - Cannot find shipping mark attributes!");
					return;
				}
			} 
			catch (Exception ex) 
			{
				MessageBox.Show("Error - Warehouse Transfer \nCannot load DB!" + ex.Message + ex.ToString());
				return;
			} 
			finally 
			{
				con.Close();
			}
				
			con.Dispose();
			con = null;
			cmd = null;
		}
		
		
		void Txtbx_shipmarkKeyDown(object sender, KeyEventArgs e)
		{
			if(e.KeyCode == Keys.Enter)
			{
				//if (txtbx_ref_no.Text.Substring(0, 4) == "GFSO" || txtbx_ref_no.Text.Substring(0, 4) == "SWSO" || txtbx_ref_no.Text.Substring(0, 5) == "STORE")
				     Search();
			}
			else return;
			
		}
	}
}
