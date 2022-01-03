using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic; // For generic collections like List.
using System.Data.SqlClient;      
using System.Data.Sql;
using System.Data;
using CommonFunction;
using CommonLibrary;
using CommonControl.Functions;

namespace AX2020
{
	public partial class frm_prod_shipping : Form
	{
		public static string sqlconn = "Server=AX-UAT; Password=sbax2020sbg; User ID=sbax2020; Initial Catalog=SBG_AX_2020; Integrated Security=false";
		string username;
		
		public frm_prod_shipping()
		{
			InitializeComponent();
			username = frm_menu_system.userName; 
			lbl_username.Text = "User : " + username;
			
			DropDownList("SELECT * FROM TBL_PROD_SHIPPING_CONTAINER_TYPE_LIST", cbx_container_type, "PROD_CONTAINER_TYPE");
			DropDownList("SELECT * FROM TBL_PROD_SHIPPING_CONTAINER_SIZE_LIST", cbx_container_size, "PROD_CONTAINER_SIZE");
		
		}
		void DataGrid()
		{
			SqlConnection con_SP = new SqlConnection(sqlconn);
			SqlCommand cmd_SP = new SqlCommand();
				
			try 
			{
				cmd_SP.CommandText = @"SELECT PROD_SHIPPINGNO, PROD_SHIPPINGCODE, PROD_EXPECTEDDELIVERY, PROD_EXPECTEDARRIVAL, PROD_CUSTOMER, PROD_CONTAINERTYPE, (PROD_CONTAINERSIZE + ' ' + PROD_CONTAINERSIZE2) AS CONTAINERSIZE, PROD_SONO, PROD_SALESINVOICENO, PROD_FORWARDER FROM TBL_PROD_SHIPPING ORDER BY PROD_SHIPPINGNO";
				cmd_SP.Connection = con_SP;
				con_SP.Open();
				SqlDataAdapter dataadapter = new SqlDataAdapter(cmd_SP);	
								 
			    //DataSet ds = new DataSet();
			    DataTable ds = new DataTable();
			    dataadapter.Fill(ds);
				 
  				this.dt_grid.DataSource = AutoNumberedTable(ds);

			}
			catch(Exception ex)
			{
				MessageBox.Show("Error Datagrid DB Cannot load DB" + ex.Message + ex.ToString());
				return;
			}
			finally
			{
				con_SP.Close();
				dt_grid.Columns[0].Name = "No";
	            dt_grid.Columns[0].Width = 50;
	            dt_grid.Columns[1].HeaderText = "Shipping No";
	            dt_grid.Columns[1].Width = 80;
	            dt_grid.Columns[2].HeaderText = "Shipping Code";
	            dt_grid.Columns[2].Width = 120;
	            dt_grid.Columns[3].HeaderText = "Expected Delivery";
	            dt_grid.Columns[3].DefaultCellStyle.Format = "dd/MM/yyyy";
			 	dt_grid.Columns[3].Width = 60;
			 	dt_grid.Columns[4].HeaderText = "Expected Arrival";
			 	dt_grid.Columns[4].DefaultCellStyle.Format = "dd/MM/yyyy";
			 	dt_grid.Columns[4].Width = 60;
			 	dt_grid.Columns[5].HeaderText = "Customer";
	            dt_grid.Columns[5].Width = 120;
			 	dt_grid.Columns[6].HeaderText = "Container Type";
	            dt_grid.Columns[6].Width = 100;
	            dt_grid.Columns[7].HeaderText = "Container Size";
				dt_grid.Columns[7].Width = 60;
			 	dt_grid.Columns[8].HeaderText = "SO No";
	            dt_grid.Columns[8].Width = 80;
	            dt_grid.Columns[9].HeaderText = "Invoice No";
				dt_grid.Columns[9].Width = 80;
			 	dt_grid.Columns[10].HeaderText = "Forwarder";
	            	            
			}
			
			con_SP.Dispose();
			con_SP = null;
			cmd_SP = null;	
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
		

		void Btn_delClick(object sender, EventArgs e)
		{
//			if (!Validation())
//                return;
//			
//			DialogResult del = new DialogResult();
//            del = MessageBox.Show("Are you sure you want to delete it?", "Delete", 
//                     MessageBoxButtons.YesNo, 
//                     MessageBoxIcon.Warning, 
//                     MessageBoxDefaultButton.Button2);
//            if (del == DialogResult.Yes)
//            {
//
//				if (this.dt_grid.SelectedRows.Count > 0)
//			    {
//								
//			       	if(sqlConnParm("SP_PROD_CONV_JO_BOM_DEL"))
//	            	{
//			       		dt_grid.Rows.RemoveAt(this.dt_grid.SelectedRows[0].Index);
//						DialogBox.ShowDeleteSuccessDialog();
//	            	}
//			       	else
//			       		return;
//							
//			    }   
//            	
//            }
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
					
					cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_SHIPPINGNO", SqlDbType.NVarChar, 50));
					cmd_data.Parameters["@SP_PROD_SHIPPINGNO"].Value = txtbx_ship_code.Text.ToUpper();
					
					cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_SHIPPINGCODE", SqlDbType.NVarChar, 50));
					cmd_data.Parameters["@SP_PROD_SHIPPINGCODE"].Value = txtbx_ship_code.Text.ToUpper();

					cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_EXPECTEDDELIVERY", SqlDbType.DateTime));
					cmd_data.Parameters["@SP_PROD_EXPECTEDDELIVERY"].Value = dtp_exp_delivery.Value;

					cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_EXPECTEDARRIVAL", SqlDbType.DateTime));
					cmd_data.Parameters["@SP_PROD_EXPECTEDARRIVAL"].Value = dtp_exp_arrival.Value;
					
					cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_CUSTOMER", SqlDbType.NVarChar, 50));
					cmd_data.Parameters["@SP_PROD_CUSTOMER"].Value = txtbx_cust.Text.ToUpper();

					cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_CONTAINERTYPE", SqlDbType.NVarChar, 50));
					cmd_data.Parameters["@SP_PROD_CONTAINERTYPE"].Value = cbx_container_type.Text;

					cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_CONTAINERSIZE", SqlDbType.NVarChar, 20));
					cmd_data.Parameters["@SP_PROD_CONTAINERSIZE"].Value = txtbx_container_size.Text;
					
					cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_CONTAINERSIZE2", SqlDbType.NVarChar, 20));
					cmd_data.Parameters["@SP_PROD_CONTAINERSIZE2"].Value = cbx_container_size.Text;
					
					cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_SONO", SqlDbType.NVarChar, 50));
					cmd_data.Parameters["@SP_PROD_SONO"].Value = txtbx_cust.Text.ToUpper();
					
					cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_SALESINVOICENO", SqlDbType.NVarChar, 50));
					cmd_data.Parameters["@SP_PROD_SALESINVOICENO"].Value = txtbx_sales_inv_no.Text.ToUpper();
					
					cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_FORWARDER", SqlDbType.NVarChar, 50));
					cmd_data.Parameters["@SP_PROD_FORWARDER"].Value = txtbx_forwarder.Text.ToUpper();
					
					
					
					cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_ISSUEBY", SqlDbType.NVarChar, 50));
					cmd_data.Parameters["@SP_PROD_ISSUEBY"].Value = username.ToUpper();
					
					cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_USER", SqlDbType.NVarChar, 50));
					cmd_data.Parameters["@SP_PROD_USER"].Value = username.ToUpper();
					
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
					
					
			} catch (Exception ex) {
				
				con_data.Close();
				MessageBox.Show("Error - Shipping Save DB \nCannot save data" + Environment.NewLine + ex.Message + ex.ToString());			
				return false;
			
			} finally {
				
				con_data.Close();
					
			}
			
			con_data.Dispose();
			con_data = null;
			cmd_data = null;
			
			return true;
		}
		
		
		void Btn_saveClick(object sender, EventArgs e)
		{
//			if(!Validation())
//				return;
			
			if(!sqlConnParm("SP_PROD_SHIPPING_ADD"))
				return;
			else
				DialogBox.ShowSaveSuccessDialog();
				DataGrid();
				ClearAllText(this);
				
		}
		
		private void DropDownList(string cmd, ComboBox cbx_text, string col_name)
		{
		    SqlConnection conn = new SqlConnection(sqlconn);
            DataTable ds = new DataTable();
            string cmdSQL = cmd;
            SqlDataAdapter sda = new SqlDataAdapter(cmdSQL, conn);

            try
            {
                conn.Open();
                sda.Fill(ds);
                cbx_text.Text = "Please Select";
            
            }catch(SqlException se)
            {
            	MessageBox.Show("Error - Shipping Dropdown \nCannot load DB \n" + se.ToString() + se.Message);
            }
            finally
            {
                conn.Close();
            }
			
           	foreach(DataRow dr1 in ds.Rows)
           	{
               cbx_text.Items.Add(dr1[col_name].ToString());
           	}
            //cbx_jr_roll.DataSource = ds.Tables[0];
            //cbx_jr_roll.DisplayMember = ds.Tables[0].Columns[0].ToString();
            //cbx_jr_roll.SelectedIndex = 3;
		}
		
//		private bool Validation()
//        {
//                  
//               if (CommonValidation.ValidateIsEmptyString(txtbx_prod_code.Text.Trim()))
//                {
//                    DialogBox.ShowWarningMessage(lbl_prod_code.Text + " cannot be empty.");
//                    txtbx_prod_code.Focus();
//                   	
//                    return false;
//                }
//              
//               else if (CommonValidation.ValidateIsEmptyString(cbx_tape_end.Text.Trim()))
//                {
//                    DialogBox.ShowWarningMessage(lbl_tape_end.Text + " cannot be empty.");
//                    cbx_tape_end.Focus();
//                   	
//                    return false;
//                   
//                }
//               
//               else if (CommonValidation.ValidateIsEmptyString(cbx_pack.Text.Trim()))
//                {
//                    DialogBox.ShowWarningMessage(lbl_pack.Text + " cannot be empty.");
//                    cbx_pack.Focus();
//                   	
//                    return false;
//                    
//                }
//               
//               else if (CommonValidation.ValidateIsEmptyString(cbx_tear.Text.Trim()))
//                {
//                    DialogBox.ShowWarningMessage(lbl_tear.Text + " cannot be empty.");
//                    cbx_tear.Focus();
//                   	
//                    return false;
//                    
//                }
//               
//               else if (CommonValidation.ValidateIsEmptyString(txtbx_ctn_bx_code.Text.Trim()))
//                {
//                    DialogBox.ShowWarningMessage(lbl_ctn_bx_code.Text + " cannot be empty.");
//                    txtbx_ctn_bx_code.Focus();
//                   	
//                    return false;
//                    
//                }
//               
//               else if (CommonValidation.ValidateIsEmptyString(cbx_ctn_bx.Text.Trim()))
//                {
//                    DialogBox.ShowWarningMessage(lbl_ctn_bx.Text + " cannot be empty.");
//                    cbx_ctn_bx.Focus();
//                   	
//                    return false;
//                    
//                }
//               
//               else if (CommonValidation.ValidateIsEmptyString(cbx_inner_bx.Text.Trim()))
//                {
//                    DialogBox.ShowWarningMessage(lbl_inner_bx.Text + " cannot be empty.");
//                    cbx_inner_bx.Focus();
//                   	
//                    return false;
//                    
//                }
//               
//               
//               return true;
//        }
//		
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
      			
      			if(c is DateTimePicker)
				{
					((DateTimePicker)c).Value = DateTime.Now;
				}
   			}
		}
		
		void Btn_clearClick(object sender, EventArgs e)
		{
			ClearAllText(this);	
		}	
		
		void Btn_cancelClick(object sender, EventArgs e)
		{
			this.Close();    
		}
		
		void Frm_prod_shippingLoad(object sender, EventArgs e)
		{
			DataGrid();
			btn_del.Hide();
			txtbx_ship_code.Text = DateTime.Now.ToString("MM.yyyy");
		}
		
		
		void Dt_gridCellClick(object sender, DataGridViewCellEventArgs e)
		{
			if(dt_grid.SelectedRows.Count > 0) // make sure user select at least 1 row 
			{
				btn_del.Visible = true;
				btn_save.Hide();
			   	txtbx_ship_code.Text = dt_grid.SelectedRows[0].Cells[2].Value + string.Empty;
			   	dtp_exp_delivery.Value = Convert.ToDateTime(dt_grid.SelectedRows[0].Cells[3].Value + string.Empty);
			   	dtp_exp_arrival.Value = Convert.ToDateTime(dt_grid.SelectedRows[0].Cells[4].Value + string.Empty);
			   	txtbx_cust.Text = dt_grid.SelectedRows[0].Cells[5].Value + string.Empty;
			   	cbx_container_type.Text = dt_grid.SelectedRows[0].Cells[6].Value + string.Empty;
			   	txtbx_so_no.Text = dt_grid.SelectedRows[0].Cells[8].Value + string.Empty;
			   	txtbx_sales_inv_no.Text = dt_grid.SelectedRows[0].Cells[9].Value + string.Empty;
			    txtbx_forwarder.Text = dt_grid.SelectedRows[0].Cells[10].Value + string.Empty;
			   
			    Retrieve();
			}			
		}
		
		void Retrieve()
		{
			
			SqlConnection con_SP1 = new SqlConnection(sqlconn);
			SqlCommand cmd_SP1 = new SqlCommand();
				
			try 
			{
				cmd_SP1.CommandText = @"SELECT * FROM TBL_PROD_SHIPPING where PROD_SHIPPINGNO = @doc_no";
				//cmd_SP1.Parameters.AddWithValue("@doc_no",  txtbx_ref_no.Text);
				cmd_SP1.Connection = con_SP1;
				con_SP1.Open();
				SqlDataReader rd_SP1 = cmd_SP1.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
				if (rd_SP1.HasRows)
				{
					while (rd_SP1.Read())
					{				        	
						//txtbx_cust.Text = rd_SP1["PROD_CUSTOMER"].ToString();
						
					} 	
				}
		
			} 
			catch (Exception ex) 
			{
				MessageBox.Show("Error - Shipping Retrieve \nCannot retrieve DB!" + ex.Message + ex.ToString());
				return;
			} 
			finally 
			{
				con_SP1.Close();
			}
				
			con_SP1.Dispose();
			con_SP1 = null;
			cmd_SP1 = null;		
			
			
			
        }
		
		
	}
}