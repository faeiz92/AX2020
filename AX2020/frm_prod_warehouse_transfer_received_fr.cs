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
	/// Description of frm_prod_warehouse_transfer_received_fr.
	/// </summary>
	public partial class frm_prod_warehouse_transfer_received_fr : Form
	{
		public static string sqlconn = "Server=AX-UAT; Password=sbax2020sbg; User ID=sbax2020; Initial Catalog=SBG_AX_2020; Integrated Security=false";
		public static string sqlconnStaging = "Server=AX-SQL; Password=ax2020sbgroup; User ID=ax2020sb; Initial Catalog=AX2020StagingDB; Integrated Security=false";
        						
		string username;
		int NextNo;
		
		public frm_prod_warehouse_transfer_received_fr()
		{
			InitializeComponent();

			username = frm_menu_system.userName; 
			lbl_username.Text = "User : " + username;
			
			InitializeDataGridOutput();	
			Data();
			//DropDownList("SELECT WAREHOUSEID FROM TBL_PROD_WAREHOUSE_AX_WAREHOUSE WHERE FLAG1 = 'FROM' and flag2 = 'REC-FR' ORDER BY WAREHOUSEID", cbx_warehouse_from, "WAREHOUSEID");
			//DropDownList("SELECT WAREHOUSEID FROM TBL_PROD_WAREHOUSE_AX_WAREHOUSE WHERE FLAG1 = 'TO' and flag2 = 'REC-FR' ORDER BY WAREHOUSEID", cbx_warehouse_to, "WAREHOUSEID");
		
		}
		
		bool UpdateToAX()
		{
			SqlConnection conProcessData1c = new SqlConnection(sqlconn);
			SqlCommand cmdProcessData1c = new SqlCommand();
				
			try
			{
				//cmdProcessData1c.CommandText = "select * from ax2020_sfa_extract where sfabatchnum = '" + sfanum + "' order by erpitemno"; //VIEW_SFA_AX_DATA_R9
				cmdProcessData1c.CommandText = "update TBL_PROD_WAREHOUSE_AX_TRANSFER_ORDER set flag2 = 'Y' where prod_line = @prod_line";
				cmdProcessData1c.Parameters.AddWithValue("@prod_line", txtbx_no.Text.ToUpper());				//VIEW_SFA_AX_DATA_R9
				
				cmdProcessData1c.Connection = conProcessData1c;
				conProcessData1c.Open();
				cmdProcessData1c.ExecuteNonQuery();
					
			} 
			catch (Exception ex) 
			{
				MessageBox.Show("Error 5 : " + ex.Message + ex.ToString());
				return false;	
			} 
			finally 
			{
				conProcessData1c.Close();
				
			}
			conProcessData1c.Dispose();
			conProcessData1c = null;
			cmdProcessData1c = null;
			
			return true;
		}
		
		void Data()
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
			jr_brand 			= string.Empty,
			jr_fromwhse			= string.Empty;
			
			SqlConnection con_search = new SqlConnection(sqlconn);
			SqlCommand cmd_search = new SqlCommand();
				
			try 
			{
				cmd_search.CommandText = "select * from TBL_PROD_WAREHOUSE_AX_TRANSFER_ORDER" +
					" where PROD_TOWAREHOUSE = 'GFWSM05' AND FLAG1 ='Y' AND FLAG1 ='N'";
				//cmd_search.Parameters.AddWithValue("@ship_mark",  txtbx_no.Text.ToUpper());
				//cmd_search.Parameters.AddWithValue("@whse",  cbx_warehouse_from.Text);
				cmd_search.Connection = con_search;
				con_search.Open();
				SqlDataReader rd_search = cmd_search.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
					
				if (rd_search.HasRows)
				{
					while (rd_search.Read())
					{		
						jr_shipmark 	= rd_search["PROD_SHIPMARK"].ToString();
						jr_barcode 		= rd_search["PROD_BARCODE"].ToString();
						//jr_ref_no 		= rd_search["PROD_"].ToString();						
						jr_color 		= rd_search["PROD_Color"].ToString();
						jr_stockcode 	= rd_search["PROD_CODE"].ToString();
						jr_lot_no 		= rd_search["PROD_LOTNO"].ToString();
						jr_mic 			= rd_search["PROD_MICRON"].ToString();
						jr_width 		= rd_search["PROD_Width"].ToString();
						jr_length 		= rd_search["PROD_Length"].ToString();
						jr_brand		= rd_search["PROD_Brand"].ToString();
						jr_fromwhse 	= rd_search["PROD_fromwarehouse"].ToString();
						
						
						//Code	LotNo	Customer	S.Mark	Barcode Color	Micron	Width	Length
									
									
						dt_grid_add.Rows.Add(jr_stockcode, jr_lot_no, jr_brand, jr_shipmark, jr_barcode, jr_color, jr_mic, jr_width, jr_length, jr_fromwhse);
				
												
					} 
				}
				
			} 
			catch (Exception ex) 
			{
				MessageBox.Show("Error - Converting Transfer Receive \nCannot load DB!" + ex.Message + ex.ToString());
				return;
			} 
			finally 
			{
				con_search.Close();
			}
				
			con_search.Dispose();
			con_search = null;
			cmd_search = null;
			
		}
		
		
		void Reject()
		{
			
			SqlConnection con_search = new SqlConnection(sqlconn);
			SqlCommand cmd_search = new SqlCommand();
				
			try 
			{
				cmd_search.CommandText = "insert into TBL_PROD_WAREHOUSE_AX_TRANSFER_ORDER_D select * from TBL_PROD_WAREHOUSE_AX_TRANSFER_ORDER" +
					" where PROD_TOWAREHOUSE = 'GFWSM05' AND FLAG1 ='Y' AND FLAG1 ='N'";
				//cmd_search.Parameters.AddWithValue("@ship_mark",  txtbx_no.Text.ToUpper());
				//cmd_search.Parameters.AddWithValue("@whse",  cbx_warehouse_from.Text);
				cmd_search.Connection = con_search;
				con_search.Open();
				
				
			} 
			catch (Exception ex) 
			{
				MessageBox.Show("Error - Warehouse Transfer Receive \nCannot load DB!" + ex.Message + ex.ToString());
				return;
			} 
			finally 
			{
				con_search.Close();
			}
				
			con_search.Dispose();
			con_search = null;
			cmd_search = null;
			
		}

		void Btn_addClick(object sender, EventArgs e)
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
			jr_brand 			= string.Empty,
			jr_fromwhse			= string.Empty;
			
			
			if(String.IsNullOrWhiteSpace(txtbx_no.Text))
			{
				MessageBox.Show("Please key in shipping mark or barcode");
				txtbx_no.Focus();
				return;
			}
//			else if(String.IsNullOrWhiteSpace(cbx_warehouse_from.Text) || cbx_warehouse_from.Text == "Please Select")
//			{
//				MessageBox.Show("Please select warehouse");
//				cbx_warehouse_from.Focus();
//				return;
//			}
			
			//------------------------------------------------------------------------
			
			
			if(String.IsNullOrWhiteSpace(txtbx_no.Text))
			{
				MessageBox.Show("Please key in transfer no");
				txtbx_no.Focus();
				return;
			}
			
			dt_grid_add.Rows.Clear();
			
			SqlConnection con_search = new SqlConnection(sqlconn);
			SqlCommand cmd_search = new SqlCommand();
				
			try 
			{
				cmd_search.CommandText = "select * from TBL_PROD_WAREHOUSE_AX_TRANSFER_ORDER" +
					" where PROD_LINE = @ship_mark and PROD_TOWAREHOUSE = 'GFWSM05'";
				cmd_search.Parameters.AddWithValue("@ship_mark",  txtbx_no.Text.ToUpper());
				//cmd_search.Parameters.AddWithValue("@whse",  cbx_warehouse_from.Text);
				cmd_search.Connection = con_search;
				con_search.Open();
				SqlDataReader rd_search = cmd_search.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
					
				if (rd_search.HasRows)
				{
					while (rd_search.Read())
					{		
						jr_shipmark 	= rd_search["PROD_SHIPMARK"].ToString();
						jr_barcode 		= rd_search["PROD_BARCODE"].ToString();
						//jr_ref_no 		= rd_search["PROD_"].ToString();						
						jr_color 		= rd_search["PROD_Color"].ToString();
						jr_stockcode 	= rd_search["PROD_CODE"].ToString();
						jr_lot_no 		= rd_search["PROD_LOTNO"].ToString();
						jr_mic 			= rd_search["PROD_MICRON"].ToString();
						jr_width 		= rd_search["PROD_Width"].ToString();
						jr_length 		= rd_search["PROD_Length"].ToString();
						jr_brand		= rd_search["PROD_Brand"].ToString();
						jr_fromwhse 	= rd_search["PROD_fromwarehouse"].ToString();
						
						
						//Code	LotNo	Customer	S.Mark	Barcode Color	Micron	Width	Length
									
									
						dt_grid_add.Rows.Add(jr_stockcode, jr_lot_no, jr_brand, jr_shipmark, jr_barcode, jr_color, jr_mic, jr_width, jr_length, jr_fromwhse);
				
												
					} 
				}
				else 
				{
					MessageBox.Show("Error 1 - Cannot find shipping mark!");
					return;
				}
			} 
			catch (Exception ex) 
			{
				MessageBox.Show("Error - Converting Transfer Receive \nCannot load DB!" + ex.Message + ex.ToString());
				return;
			} 
			finally 
			{
				con_search.Close();
			}
				
			con_search.Dispose();
			con_search = null;
			cmd_search = null;
			
							
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
			dt_grid_add.Columns[8].ReadOnly = true;
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
		
		
		
		void Btn_saveClick(object sender, EventArgs e)
		{
//			if(cbx_warehouse_to.Text == "Please Select")
//			{
//				MessageBox.Show("Please select To Warehouse");
//				return;
//			}
			
			if(!UpdateToAX())
					return;
			else
			{
				DialogBox.ShowSaveSuccessDialog();
				ClearAllText(this);
			}
			
			
					
		}
		
		
		
		void Btn_clearClick(object sender, EventArgs e)
		{
			Reject();
			ClearAllText(this);	
		}
				
		void Btn_cancelClick(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}
