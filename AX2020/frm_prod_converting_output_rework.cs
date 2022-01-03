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
using System.Diagnostics;

namespace AX2020
{
	
	public partial class frm_prod_converting_output_rework : Form
	{
		public static string sqlconn = "Server=AX-UAT; Password=sbax2020sbg; User ID=sbax2020; Initial Catalog=SBG_AX_2020; Integrated Security=false";
		
		string ref_no = null, line_no = null, init = "0";
		string NextNo;
		string username;
		double qty_ctn_ordered=0, qty_roll_ordered=0, total=0, qty_roll_prod=0, qty_roll_prod_2=0;
		
		
		public frm_prod_converting_output_rework()
		{	
			InitializeComponent();
			this.ControlBox = false;
			
			username = frm_menu_system.userName; 
			lbl_username.Text = "User : " + username;
			
			DropDownList("SELECT * FROM TBL_PROD_CONV_JO_PACKING_MACHINE_NO_LIST order by MACHINE_NO", cbx_machine, "MACHINE_NO");	
			DropDownList("SELECT * FROM TBL_PROD_CONV_JO_OUTPUT_SHIFT", cbx_shift, "SHIFT");
			DropDownList("SELECT sysstaffname FROM TBL_ADMIN_USER_FACTORY where sysdept = 'SLITTING' or sysdept = 'RCP' or sysdept = 'PAPER CORE' or sysdept = 'RIBBON'", cbx_operator, "sysstaffname");
			DropDownList("SELECT sysstaffname FROM TBL_ADMIN_USER_FACTORY where sysdept = 'SLITTING' or sysdept = 'RCP' or sysdept = 'PAPER CORE' or sysdept = 'RIBBON'", cbx_helper, "sysstaffname");
			
			DisableControls(this);
			EnableControls(txtbx_ref_no);
			EnableControls(btn_search);
			EnableControls(btn_cancel);
			EnableControls(btn_clear);
			EnableControls(lbl_ref_no);
			EnableControls(dt_grid);
			EnableControls(lbl_header);
			EnableControls(btn_report);
		}
		
		private void DisableControls(Control con) 
		{
        	foreach (Control c in con.Controls) 
        	{
            	DisableControls(c);
        	}
        	
        	con.Enabled = false;
    	}
		
		 private void EnableControls(Control con) 
		 {
        	if (con != null) 
        	{
            	con.Enabled = true;
            	EnableControls(con.Parent);
        	}
    	}
		 
		private void EnableAllControls(Control con) 
		{
        	foreach (Control c in con.Controls) 
        	{
            	EnableAllControls(c);
        	}
        	
        	con.Enabled = true;
    	}
		
		private bool LineNoGenerator()
		{
			
			SqlConnection conNextNumber = new SqlConnection(sqlconn);
			SqlCommand cmdNextNumber = new SqlCommand();
			
			try 
			{
				cmdNextNumber.CommandText = "Select ProdConvReworkNextNumber from TBL_ADMIN_NEXT_NUMBER";
				cmdNextNumber.Connection = conNextNumber;

				conNextNumber.Open();
				SqlDataReader rdNextNumber = cmdNextNumber.ExecuteReader(System.Data.CommandBehavior.CloseConnection);

				rdNextNumber.Read();
				NextNo = (rdNextNumber["ProdConvReworkNextNumber"]).ToString();
								
			} 
			catch (Exception ex) 
			{
				MessageBox.Show("Error Edit : Cannot load DB!" + ex.Message + ex.ToString());
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
				cmdUpdateNextNumber.CommandText = "update TBL_ADMIN_NEXT_NUMBER set ProdConvReworkNextNumber = ProdConvReworkNextNumber + 1";
				
				cmdUpdateNextNumber.Connection = conUpdate;

				conUpdate.Open();
				cmdUpdateNextNumber.ExecuteNonQuery();

			}
			catch (Exception ex)
			{
				conUpdate.Close();
				MessageBox.Show("Error in updating next number" + ex.Message + ex.ToString());
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
		
		void DataGrid()
		{
			try
			{
				string sql = "SELECT * FROM TBL_PROD_CONV_JO_PACKING WHERE PROD_DATE>= DATEADD(day,-45, getdate()) and PROD_USERREVISION <> 'SAPS' order by PROD_DATE DESC, PROD_SHIFT";
		        SqlConnection connection = new SqlConnection(sqlconn);
		        SqlDataAdapter dataadapter = new SqlDataAdapter(sql, connection);
		        //DataSet ds = new DataSet();
		        DataTable ds = new DataTable();
		        connection.Open();
		        //dataadapter.Fill(ds, "TBL_PROD_CONV_JO_SLITTING");
		        dataadapter.Fill(ds);
		                     
		        DataTable tempDT = new DataTable();
				tempDT = ds.DefaultView.ToTable(true, "PROD_DOCNO", "PROD_LINE", "PROD_CUSTOMER", "PROD_CODE", "PROD_BRAND", "PROD_COLOR", "PROD_MICRON", "PROD_WIDTH", "PROD_LENGTH", "PROD_QTYCTN", "PROD_QTYROLL");
				dt_grid.DataSource = tempDT;
					
				//connection.Close();
//		        dt_grid.DataSource = ds;
//              dt_grid.DataMember = "TBL_PROD_CONV_JO_SLITTING";
//  			dt_grid.DataMember = ds;
			}
			catch(Exception ex)
			{
				MessageBox.Show("Error" + ex.Message + ex.ToString());
				return;
			}
			finally
			{
				dt_grid.Columns[0].HeaderText = "Ref No";
				dt_grid.Columns[0].Width = 150;
				dt_grid.Columns[1].HeaderText = "Line No";
				dt_grid.Columns[1].Width = 80;
				dt_grid.Columns[2].HeaderText = "Customer";
				dt_grid.Columns[2].Width = 200;
				dt_grid.Columns[3].HeaderText = "Code";
				dt_grid.Columns[3].Width = 80;
				dt_grid.Columns[4].HeaderText = "Brand";
				dt_grid.Columns[4].Width = 80;
				dt_grid.Columns[5].HeaderText = "Color";
				dt_grid.Columns[5].Width = 80;
				dt_grid.Columns[6].HeaderText = "Micron";
				dt_grid.Columns[7].HeaderText = "Width";
				dt_grid.Columns[8].HeaderText = "Length";
				dt_grid.Columns[9].HeaderText = "Qty Ctn";
				dt_grid.Columns[10].HeaderText = "Qty Roll";

			}

		}
		
		bool searchDB()
		{
			SqlConnection con_searchDB = new SqlConnection(sqlconn);
			SqlCommand cmd_searchDB = new SqlCommand();
				
			try 
			{
				cmd_searchDB.CommandText = @"SELECT * FROM TBL_PROD_CONV_JO_PACKING where PROD_DOCNO = @doc_no";
				cmd_searchDB.Parameters.AddWithValue("@doc_no",  txtbx_ref_no.Text.ToUpper());
				cmd_searchDB.Connection = con_searchDB;
				con_searchDB.Open();
				SqlDataReader dr_searchDB = cmd_searchDB.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
					
				if (dr_searchDB.Read())
				{	
					ref_no = txtbx_ref_no.Text;					
					txtbx_cust.Text = dr_searchDB["PROD_CUSTOMER"].ToString();
					txtbx_prod_code.Text = dr_searchDB["PROD_CODE"].ToString();
					txtbx_color.Text = dr_searchDB["PROD_COLOR"].ToString();
					txtbx_brand.Text = dr_searchDB["PROD_BRAND"].ToString();
					txtbx_length_cust.Text = dr_searchDB["PROD_LENGTH"].ToString();
					txtbx_width_cust.Text = dr_searchDB["PROD_WIDTH"].ToString();
					txtbx_mic.Text = dr_searchDB["PROD_MICRON"].ToString();
					txtbx_conversion.Text = dr_searchDB["PROD_CONVERSION"].ToString();
				} 
				else 
				{
					MessageBox.Show("Error : Cannot find JO!");
					return false;
				}
			} 
			catch (Exception ex) 
			{
				MessageBox.Show("Error : Cannot load DB!" + ex.Message + ex.ToString());
				return false;
			} 
			finally 
			{
				con_searchDB.Close();
			}
			con_searchDB.Dispose();
			cmd_searchDB = null;
			return true;
			
		}
		
		void Btn_searchClick(object sender, EventArgs e)
		{
			//Search();
//			frm_prod_converting_output_rework_popup popup = new frm_prod_converting_output_rework_popup();
//			popup.Show();
			
			getStockCode();
			
		}
		
		void Search()
		{
			SqlConnection con_search = new SqlConnection(sqlconn);
			SqlCommand cmd_seach = new SqlCommand();
				
			try 
			{
				//cmd_seach.CommandText = @"SELECT * FROM TBL_PROD_CONV_JO_SLITTING where PROD_DOCNO = @doc_no";
				cmd_seach.CommandText = @"SELECT * FROM TBL_PROD_CONV_JO where JODOCNO = @doc_no";
				cmd_seach.Parameters.AddWithValue("@doc_no",  txtbx_ref_no.Text.ToUpper());
				cmd_seach.Connection = con_search;
				con_search.Open();
				SqlDataReader dr_search = cmd_seach.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
					
				if (dr_search.Read())
				{	
					ref_no = txtbx_ref_no.Text;					
//					txtbx_cust.Text = dr_search["PROD_CUSTOMER"].ToString();
//					txtbx_prod_code.Text = dr_search["PROD_CODE"].ToString();
//					txtbx_color.Text = dr_search["PROD_COLOR"].ToString();
//					txtbx_brand.Text = dr_search["PROD_BRAND"].ToString();
//					txtbx_length_cust.Text = dr_search["PROD_LENGTH"].ToString();
//					txtbx_width_cust.Text = dr_search["PROD_WIDTH"].ToString();
//					txtbx_mic.Text = dr_search["PROD_MICRON"].ToString();
//					txtbx_conversion.Text = dr_search["PROD_CONVERSION"].ToString();
					
					txtbx_cust.Text = dr_search["JOCUSTOMER"].ToString();
					txtbx_prod_code.Text = dr_search["JOSTOCKCODE"].ToString();
					txtbx_color.Text = dr_search["JOSTOCKCOLOR"].ToString();
					txtbx_brand.Text = dr_search["JOSTOCKBRAND"].ToString();
					txtbx_length_cust.Text = dr_search["JOSTOCKLENGTH"].ToString();
					txtbx_width_cust.Text = dr_search["JOSTOCKWIDTH"].ToString();
					txtbx_mic.Text = dr_search["JOSTOCKMICRON"].ToString();
					qty_ctn_ordered = Convert.ToDouble(dr_search["JOSTOCKQTYCTN"]);
					qty_roll_ordered = Convert.ToDouble(dr_search["JOSTOCKQTYROLL"]);
					txtbx_conversion.Text = dr_search["JOSTOCKCONVERSION"].ToString();
					qty_roll_prod = Double.Parse(dr_search["JOPRODQTY"].ToString());
					qty_roll_prod_2 = Double.Parse(dr_search["JOPRODQTYBAL"].ToString());
				} 
				else 
				{
					MessageBox.Show("Error : Cannot find JO!");
					return;
				}
			} 
			catch (Exception ex) 
			{
				MessageBox.Show("Error : Cannot load DB!" + ex.Message + ex.ToString());
				return;
			} 
			finally 
			{
				con_search.Close();
			}
			con_search.Dispose();
			cmd_seach = null;
			EnableAllControls(this);
			btn_del.Enabled = false;
		}
		
		void ClearAllText(Control con)
		{
    		foreach (Control c in con.Controls)
    		{
      			if (c is TextBox)
        			((TextBox)c).Clear();
      			else
      				//ClearAllText(c);
      			if(c is ComboBox)
                //((ComboBox)c).Text = "Please Select";
      				((ComboBox)c).SelectedValue = "Please Select";
				
      			if(c is DateTimePicker)
				{
					((DateTimePicker)c).Value = DateTime.Now;
				}        			
								
   			}
    		ClearVariable();
    		
		  		
		}
		
		void ClearAllTextGroupBx(GroupBox gbx)
        {
            foreach (Control c in gbx.Controls)
            {
                if (c is TextBox)
                {
                	((TextBox)c).Clear();
                }
            }
        }
		
		void ClearVariable()
		{
			total = 0;
    		qty_ctn_ordered = 0;
    		qty_roll_ordered = 0;
    		qty_roll_prod = 0;
    		qty_roll_prod_2 = 0;
    		
    		txtbx_ctn_qty.Text = init;
    		txtbx_roll_qty.Text = init;
    		txtbx_total_roll.Text = init;
    		
    		ref_no = null;
    		line_no = null;
			NextNo = null;
		}
		
		void Btn_clearClick(object sender, EventArgs e)
		{
			ClearAllText(this);	
			ClearVariable();
			DataGrid();	
			btn_save.Enabled = true;
			btn_del.Enabled = false;
			txtbx_ref_no.Focus();
						
		}
		
		void Btn_cancelClick(object sender, EventArgs e)
		{
//			DialogResult cancel = new DialogResult();
//            cancel = MessageBox.Show("Do you want to cancel?", "Cancel", 
//                     MessageBoxButtons.YesNo, 
//                     MessageBoxIcon.Warning, 
//                     MessageBoxDefaultButton.Button2);
//            if (cancel == DialogResult.Yes)
//            {
//            	ClearAllText(this);
//                Application.Exit();
//            }
			this.Close();
              
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
            	MessageBox.Show("An error occured while connecting to database" + se.ToString() + se.Message);
            }
            finally
            {
                conn.Close();
 
	           	foreach(DataRow dr1 in ds.Tables[0].Rows)
	           	{
	               cbx_text.Items.Add(dr1[col_name].ToString());
	           	}
            }
            cbx_text.SelectedItem = "Please Select";
		}
		
		//>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
		
		private bool Validation()
        {
                  
               if (CommonValidation.ValidateIsEmptyString(cbx_machine.Text.Trim()) || cbx_machine.Text == "Please Select")
                {
                    DialogBox.ShowWarningMessage(lbl_machine_no.Text + " cannot be empty.");
                   	cbx_machine.Focus();
                   	
                    return false;     
                }
              
               
               else if (CommonValidation.ValidateIsEmptyString(cbx_shift.Text.Trim()) || cbx_shift.Text == "Please Select")
                {
                    DialogBox.ShowWarningMessage(lbl_shift.Text + " cannot be empty.");
                    cbx_shift.Focus();
                   	
                    return false;       
                }
               
               else if (CommonValidation.ValidateIsEmptyString(txtbx_ctn_qty.Text.Trim()) || txtbx_ctn_qty.Text == "Please Select")
                {
                    DialogBox.ShowWarningMessage(lbl_ctn_qty.Text + " cannot be empty.");
                    txtbx_ctn_qty.Focus();
                   	
                    return false;       
                }
               
               else if (CommonValidation.ValidateIsEmptyString(txtbx_roll_qty.Text.Trim()) || txtbx_roll_qty.Text == "Please Select")
                {
                    DialogBox.ShowWarningMessage(lbl_roll_qty.Text + " cannot be empty.");
                    txtbx_roll_qty.Focus();
                   	
                    return false;       
                }
               
               if (CommonValidation.ValidateIsEmptyString(cbx_operator.Text.Trim()) || cbx_operator.Text == "Please Select")
            {
             	DialogBox.ShowWarningMessage(lbl_name.Text + " cannot be empty.");
                cbx_operator.Focus();
                   	
                return false;     
            }
                 
           	else if (CommonValidation.ValidateIsEmptyString(cbx_helper.Text.Trim()) || cbx_helper.Text == "Please Select")
            {
                DialogBox.ShowWarningMessage(lbl_helper.Text + " cannot be empty.");
                cbx_helper.Focus();
                   	
                return false;       
            }
               
               return true;
        }
		
		void TotalCalculation()
		{
			total = Double.Parse(txtbx_ctn_qty.Text) * Double.Parse(txtbx_conversion.Text) + Double.Parse(txtbx_roll_qty.Text);
		}
		
		void Btn_saveClick(object sender, EventArgs e)
		{
			if (!Validation())
                return;
			
			TotalCalculation();
			
			
//			if (!sqlConnParm2("SP_PROD_CONV_JO_SLIT_CHECK"))
//				return;
			
//			if (!sqlConnParmCount())
//				return;
			
//			if(total>qty_roll_prod)
//			{
//				MessageBox.Show("Qty packing cannot more than slitting qty");
//				return;
//			}
			
			if (LineNoGenerator() & sqlConnParm("SP_PROD_CONV_JO_PACKING_ADD"))
			{	
				//MessageBox.Show("Data is saved");
				UpdateBal("SP_PROD_CONV_UPDATE_PACK");
				//DialogBox.ShowSaveSuccessDialog();
				frm_messageBox msg = new frm_messageBox();
						msg.Show();
				DataGrid();
			}
			
			TempTable();
			Print();
			ClearAllTextGroupBx(grpbox_output);
			ClearAllTextGroupBx(grpbox_cust);
			ClearVariable();
			txtbx_ref_no.Clear();
			txtbx_ref_no.Focus();
			btn_save.Enabled = true;
			btn_del.Enabled = false;
		}
		
		void Dt_gridCellClick(object sender, DataGridViewCellEventArgs e)
		{
			if(dt_grid.SelectedRows.Count > 0) // make sure user select at least 1 row 
			{
				ref_no = dt_grid.SelectedRows[0].Cells[0].Value + string.Empty;
			   	txtbx_ref_no.Text = ref_no;
			   	NextNo = dt_grid.SelectedRows[0].Cells[1].Value + string.Empty;
			   	
			   	Retrieve();
			   	//btn_del.Enabled = true;
			   	btn_save.Enabled = false;
			   	EnableAllControls(this);
			   	btn_del.Enabled = false;
			}		
 
		}
		
		void UpdateBal(string cmd_update)
		{
			using (SqlConnection conn = new SqlConnection(sqlconn))
			{
				conn.Open();
				
				SqlCommand cmd  = new SqlCommand(cmd_update, conn);
				cmd.CommandType = CommandType.StoredProcedure;
				
				cmd.Parameters.Add(new SqlParameter("@SP_JODOCNO", SqlDbType.NVarChar, 50));
				cmd.Parameters["@SP_JODOCNO"].Value = txtbx_ref_no.Text.ToUpper();
					
				cmd.Parameters.Add(new SqlParameter("@SP_JOPACKQTYTOTAL", SqlDbType.Float));
				cmd.Parameters["@SP_JOPACKQTYTOTAL"].Value = total;
								   
				cmd.ExecuteNonQuery();				
			}				
		}
		
		bool sqlConnParm(string sqlStatement)
		{
//			string trim_ref_no = ref_no.Substring(0, ref_no.LastIndexOf("-"));
//			line_no = trim_ref_no.Substring(trim_ref_no.IndexOf('-')+1);
			
			SqlConnection con_data = new SqlConnection(sqlconn);
			SqlCommand cmd_data = new SqlCommand();
			
			try
			{
					cmd_data.Connection = con_data;
					cmd_data.CommandText = sqlStatement;
					cmd_data.CommandType = CommandType.StoredProcedure;

					cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_SONO", SqlDbType.NVarChar, 20));
					cmd_data.Parameters["@SP_PROD_SONO"].Value = "REWORK";
					
					cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_SOLINENO", SqlDbType.NVarChar, 20));
					cmd_data.Parameters["@SP_PROD_SOLINENO"].Value = NextNo;
					
					cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_DOCNO", SqlDbType.NVarChar, 50));
					cmd_data.Parameters["@SP_PROD_DOCNO"].Value = "REWORK-" + NextNo;
					
					cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_REPORTDATE", SqlDbType.DateTime));
					cmd_data.Parameters["@SP_PROD_REPORTDATE"].Value = DateTime.Now;

					cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_CODE", SqlDbType.NVarChar, 50));
					cmd_data.Parameters["@SP_PROD_CODE"].Value = txtbx_prod_code.Text.ToUpper();

					cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_CUSTOMER", SqlDbType.NVarChar, 50));
					cmd_data.Parameters["@SP_PROD_CUSTOMER"].Value = txtbx_cust.Text.ToUpper();

					cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_COLOR", SqlDbType.NVarChar, 50));
					cmd_data.Parameters["@SP_PROD_COLOR"].Value = txtbx_color.Text.ToUpper();

					cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_BRAND", SqlDbType.NVarChar, 50));
					cmd_data.Parameters["@SP_PROD_BRAND"].Value = txtbx_brand.Text.ToUpper();

					cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_WIDTH", SqlDbType.Float));
					cmd_data.Parameters["@SP_PROD_WIDTH"].Value = Convert.ToDouble(txtbx_width_cust.Text);

					cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_LENGTH ", SqlDbType.Float));
					cmd_data.Parameters["@SP_PROD_LENGTH "].Value = Double.Parse(txtbx_length_cust.Text);

					cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_MICRON", SqlDbType.Float));
					cmd_data.Parameters["@SP_PROD_MICRON"].Value = Double.Parse(txtbx_mic.Text);
					
					
	//-----------------x siap lg--------------------------------------------------------
					cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_QTYORDERED", SqlDbType.Float));
					cmd_data.Parameters["@SP_PROD_QTYORDERED"].Value = 0;

					cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_QTYCTNORDERED", SqlDbType.Float));
					cmd_data.Parameters["@SP_PROD_QTYCTNORDERED"].Value = qty_ctn_ordered;
					
					cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_QTYROLLORDERED", SqlDbType.Float));
					cmd_data.Parameters["@SP_PROD_QTYROLLORDERED"].Value = qty_roll_ordered;

					cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_CONVERSION", SqlDbType.Float));
					cmd_data.Parameters["@SP_PROD_CONVERSION"].Value =Double.Parse(txtbx_conversion.Text);
				
					cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_ETDDATE", SqlDbType.DateTime));
					cmd_data.Parameters["@SP_PROD_ETDDATE"].Value = dtp_date.Value;
					
					cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_STARTDATE", SqlDbType.DateTime));
					cmd_data.Parameters["@SP_PROD_STARTDATE"].Value = dtp_date.Value;
					
					cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_ENDDATE", SqlDbType.DateTime));
					cmd_data.Parameters["@SP_PROD_ENDDATE"].Value = dtp_date.Value;
					
					cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_LOTNO", SqlDbType.NVarChar, 50));
					cmd_data.Parameters["@SP_PROD_LOTNO"].Value = txtbx_jr_lot_no.Text.ToUpper();
					
					cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_BATCHNO", SqlDbType.NVarChar, 50));
					cmd_data.Parameters["@SP_PROD_BATCHNO"].Value = txtbx_batch_no.Text.ToUpper();
					
					cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_LINE", SqlDbType.NVarChar, 50));
					cmd_data.Parameters["@SP_PROD_LINE"].Value = NextNo;
					
					cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_MACHINE", SqlDbType.NVarChar, 50));
					cmd_data.Parameters["@SP_PROD_MACHINE"].Value = cbx_machine.Text.ToUpper();
					
					cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_MACHINESPEED", SqlDbType.Float));
					cmd_data.Parameters["@SP_PROD_MACHINESPEED"].Value = 0;
						
					
					cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_OPERATOR", SqlDbType.NVarChar, 50));
					cmd_data.Parameters["@SP_PROD_OPERATOR"].Value = cbx_operator.Text;
					
					cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_HELPER", SqlDbType.NVarChar, 50));
					cmd_data.Parameters["@SP_PROD_HELPER"].Value = cbx_helper.Text;
					
					cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_SUPERVISOR", SqlDbType.NVarChar, 50));
					cmd_data.Parameters["@SP_PROD_SUPERVISOR"].Value = cbx_helper.Text.ToUpper();
					
					cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_SHIFT", SqlDbType.NVarChar, 50));
					cmd_data.Parameters["@SP_PROD_SHIFT"].Value = cbx_shift.Text;	
					
					cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_DATE", SqlDbType.DateTime));
					cmd_data.Parameters["@SP_PROD_DATE"].Value = dtp_date.Value;
								
					
					
					cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_QTYCTN", SqlDbType.Float));
					cmd_data.Parameters["@SP_PROD_QTYCTN"].Value = Double.Parse(txtbx_ctn_qty.Text);
					
					cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_QTYROLL", SqlDbType.Float));
					cmd_data.Parameters["@SP_PROD_QTYROLL"].Value = Double.Parse(txtbx_roll_qty.Text);
					
					cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_TOTALROLL", SqlDbType.Float));
					cmd_data.Parameters["@SP_PROD_TOTALROLL"].Value = total;
					
					
					cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_REMARK1", SqlDbType.NVarChar, 50));
					cmd_data.Parameters["@SP_PROD_REMARK1"].Value = cbx_shift.Text.ToUpper();
					
					cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_REMARK2", SqlDbType.NVarChar, 50));
					cmd_data.Parameters["@SP_PROD_REMARK2"].Value = cbx_shift.Text.ToUpper();	
					
					
					cmd_data.Parameters.Add(new SqlParameter("@SP_flag1", SqlDbType.NVarChar, 2));
					cmd_data.Parameters["@SP_flag1"].Value = "N";

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
					cmd_data.Parameters["@SP_flagStatus"].Value = "0";

									
					
						
					cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_ISSUEBY", SqlDbType.NVarChar, 50));
					cmd_data.Parameters["@SP_PROD_ISSUEBY"].Value = username;
					
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
				MessageBox.Show("Unexpected error happen" + Environment.NewLine + ex.Message + ex.ToString());			
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

				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_DOCNO", SqlDbType.NVarChar, 50));
				cmd_data.Parameters["@SP_PROD_DOCNO"].Value = txtbx_ref_no.Text;
					
				con_data.Open();
				cmd_data.ExecuteNonQuery();					
			} 
			catch (Exception ex) 
			{	
				con_data.Close();
				MessageBox.Show("Unexpected error happen" + Environment.NewLine + ex.Message + ex.ToString());			
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
		
		bool sqlConnParmCount()
		{
			
			SqlConnection con_data_count = new SqlConnection(sqlconn);
			SqlCommand cmd_data_count = new SqlCommand();
			
			try 
			{
				cmd_data_count.CommandText = @"select PROD_TOTALMUSTPACK from TBL_PROD_CONV_JO_SLIT_CHECK_TEMP";
				//cmd_data_count.Parameters.AddWithValue("@doc_no",  txtbx_ref_no.Text.ToUpper());
				cmd_data_count.Connection = con_data_count;
				con_data_count.Open();
				SqlDataReader rd_count = cmd_data_count.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
				
				if (rd_count.Read())
				{	
					qty_roll_prod = Double.Parse(rd_count["PROD_TOTALMUSTPACK"].ToString());
				} 
				else 
				{
					MessageBox.Show("Error - Packing Save \nCannot find JO!");
					return false;
				}
			} 
			catch (Exception ex) 
			{
				MessageBox.Show("Error - Packing Save \nCannot load DB!" + ex.Message + ex.ToString());
				return false;
			} 
			finally 
			{
				con_data_count.Close();
			}
			
			con_data_count.Dispose();
			con_data_count = null;
			cmd_data_count = null;	
			return true;
		}
		
		
		
		//void Btn_retrieveClick(object sender, EventArgs e)
		void Retrieve()
		{
			SqlConnection con_SP1 = new SqlConnection(sqlconn);
			SqlCommand cmd_SP1 = new SqlCommand();
				
			try 
			{
				cmd_SP1.CommandText = @"SELECT * FROM TBL_PROD_CONV_JO_PACKING where PROD_DOCNO = @doc_no and PROD_LINE = @line_no";
				cmd_SP1.Parameters.AddWithValue("@doc_no",  ref_no);
        		cmd_SP1.Parameters.AddWithValue("@line_no",  NextNo);
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


					cbx_machine.Text = rd_SP1["PROD_MACHINE"].ToString();
					cbx_shift.Text = rd_SP1["PROD_SHIFT"].ToString();
					txtbx_ctn_qty.Text = rd_SP1["PROD_QTYCTN"].ToString();
					txtbx_roll_qty.Text = rd_SP1["PROD_QTYROLL"].ToString();
					txtbx_jr_lot_no.Text = rd_SP1["PROD_LOTNO"].ToString();
					txtbx_batch_no.Text = rd_SP1["PROD_BATCHNO"].ToString();
				} 
				else 
				{
					MessageBox.Show("Error : Cannot find JO!");
					return;
				}
			} 
			catch (Exception ex) 
			{
				MessageBox.Show("Error : Cannot load DB!" + ex.Message + ex.ToString());
				return;
			} 
			finally 
			{
				con_SP1.Close();
			}
			
//			SqlConnection con_SP3 = new SqlConnection(sqlconn);
//			SqlCommand cmd_SP3 = new SqlCommand();
//			
//			try 
//			{
//				cmd_SP3.CommandText = @"select * from TBL_PROD_CONV_JO where JODOCNO = @doc_no";
//				cmd_SP3.Parameters.AddWithValue("@doc_no",  txtbx_ref_no.Text.ToUpper());
//				cmd_SP3.Connection = con_SP3;
//				con_SP3.Open();
//				SqlDataReader rd_SP3 = cmd_SP3.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
//				
//				if (rd_SP3.Read())
//				{	
//					txtbx_total_qty_balance.Text = rd_SP3["JOPACKQTYBAL"].ToString();
//					
//				} 
//				else 
//				{
//					MessageBox.Show("Error - Packing Retrieve \nCannot find JO!");
//					return;
//				}
//			} 
//			catch (Exception ex) 
//			{
//				MessageBox.Show("Error - Packing Retrieve \nCannot load DB!" + ex.Message + ex.ToString());
//				return;
//			} 
//			finally 
//			{
//				con_SP3.Close();
//			}
//			
//			con_SP3.Dispose();
//			con_SP3 = null;
//			cmd_SP3 = null;
		}
		
		void Btn_delClick(object sender, EventArgs e)
		{
			if (!Validation())
                return;
			
//			SqlConnection con_check = new SqlConnection(sqlconn);
//			SqlCommand cmd_check = new SqlCommand();
//			
//			try 
//			{
//				cmd_check.CommandText = @"select * from TBL_PROD_CONV_JO_PACKING where PROD_DOCNO = @doc_no";
//				cmd_check.Parameters.AddWithValue("@doc_no",  txtbx_ref_no.Text);
//				
//				cmd_check.Connection = con_check;
//				con_check.Open();
//				SqlDataReader rd_check = cmd_check.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
//
//				if (rd_check.HasRows)
//				{
//					if (rd_check.Read())
//					{
//						MessageBox.Show("Cannot delete. Packing already has been made. \nDelete Packing first if you want to delete this.");
//						return;
//					}
//
//				}
//			}
//			catch (Exception ex)
//			{
//				con_check.Close();
//				MessageBox.Show("Error - Slitting Check \n" + ex.Message + ex.ToString());
//				return;
//			} 
//			finally 
//			{
//				con_check.Close();
//			}
//			
//			con_check.Dispose();
//			cmd_check.Dispose();
//			con_check = null;
//			cmd_check = null;
			
			
			DialogResult del = new DialogResult();
            del = MessageBox.Show("Are you sure you want to delete it?", "Delete", 
                     MessageBoxButtons.YesNo, 
                     MessageBoxIcon.Warning, 
                     MessageBoxDefaultButton.Button2);
            if (del == DialogResult.Yes)
            {
            	TotalCalculation();
            	
            	if (this.dt_grid.SelectedRows.Count > 0)
            	{
	            	if(sqlConnParm("SP_PROD_CONV_JO_PACKING_DEL"))
	            	{
	            		UpdateBal("SP_PROD_CONV_UPDATE_PACK_DEL");
	            		dt_grid.Rows.RemoveAt(this.dt_grid.SelectedRows[0].Index);
						//MessageBox.Show("The data has been deleted");
						DialogBox.ShowDeleteSuccessDialog();
	            	}
	            	else return;
            	}
            	ClearAllText(this);
            	btn_del.Enabled = false;
            	btn_save.Enabled = true;
            }
		}
		
		void Frm_prod_converting_output_packingLoad(object sender, EventArgs e)
		{
			DataGrid();
			ClearAllText(this);	
			btn_del.Enabled = false;
		}
		
		void Dt_gridDataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
		{
			dt_grid.ClearSelection();
		}
		
		void TempTable()
		{
			using (SqlConnection conn = new SqlConnection(sqlconn))
			{
				conn.Open();
				
				SqlCommand cmd  = new SqlCommand("SP_PROD_CONV_JO_PACKING_LIST", conn);
				cmd.CommandType = CommandType.StoredProcedure;
				
				cmd.Parameters.Add(new SqlParameter("@SP_DOCNO", SqlDbType.NVarChar, 50));
				cmd.Parameters["@SP_DOCNO"].Value = txtbx_ref_no.Text.ToUpper();
					
				cmd.Parameters.Add(new SqlParameter("@SP_PACKNO", SqlDbType.Float));
				cmd.Parameters["@SP_PACKNO"].Value = NextNo;
								   
				cmd.ExecuteNonQuery();
				//return true;					
			}				
		}
		
		public void Print()
		{		
			//try
			//{
			using(Form frm = new Form())
			{
				//Form frm = new Form();
	        	frm.Height = 700;
	        	frm.Width = 800;

	
	        	//fyiReporting.RdlViewer.RdlViewer rdlView = new fyiReporting.RdlViewer.RdlViewer();
	        	var rdlViewer1 = new fyiReporting.RdlViewer.RdlViewer();
				var reportStrip = new fyiReporting.RdlViewer.ViewerToolstrip(rdlViewer1);
	        	Uri baseUri = new Uri(System.IO.Directory.GetCurrentDirectory());
	        	
//	        	if(cbx_remark5.Text == "SLITTING")
//	        	{
//	        		rdlViewer1.SourceFile = new Uri(baseUri, @"../report/planning_jo_converting_7.rdl");
//	        	}
//	        	else
//	        	{
//	        		rdlViewer1.SourceFile = new Uri(baseUri, @"../report/planning_jo_converting_9.rdl");
//	        	}
	        	//rdlView.Parameters += string.Format("&TestParam1={0}&TestParam2={1}", "Value 1", "Value 2");
	        	rdlViewer1.SourceFile = new Uri(baseUri, @"../report/planning_jo_converting_10.rdl");
	        	rdlViewer1.Report.DataSets["Data"].SetSource("select * from TBL_PROD_CONV_JO_PACKING_LIST_TEMP where PROD_LINE = '" + NextNo + "'");
	        	rdlViewer1.Rebuild();
	
	        	rdlViewer1.Dock = DockStyle.Fill;
	        	frm.Controls.Add(rdlViewer1);
	        	frm.Controls.Add(reportStrip);

        		frm.ShowDialog(this);
        	
			}	
		}
	
		
		void Txtbx_ref_noKeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode == Keys.Enter)
			{
				if (txtbx_ref_no.Text.Substring(0, 4) == "GFSO" || txtbx_ref_no.Text.Substring(0, 4) == "SWSO" || txtbx_ref_no.Text.Substring(0, 5) == "STORE")
				     Search();
			}
			else return;
		}
		
		void TotalRollCalculation()
		{
			try
			{
				txtbx_total_roll.Text = ((Int32.Parse(txtbx_ctn_qty.Text) * Int32.Parse(txtbx_conversion.Text)) + Int32.Parse(txtbx_roll_qty.Text)).ToString();
			}
			catch(Exception e)
			{
				//LogFile(e);
			}
		}
		
		void Txtbx_ctn_qtyTextChanged(object sender, EventArgs e)
		{
			if(!String.IsNullOrWhiteSpace(txtbx_ctn_qty.Text))
			{
				TotalRollCalculation();
			}
			else
				return;	
		}
		
		void Txtbx_roll_qtyTextChanged(object sender, EventArgs e)
		{
			if(!String.IsNullOrWhiteSpace(txtbx_roll_qty.Text))
			{
				TotalRollCalculation();
			}
			else
				return;				
		}
		
		void LogFile(Exception exc)
		{
			EventLog AX2020Log = new EventLog();
			AX2020Log.Source = "AX2020 Code Error / Failure";
			AX2020Log.WriteEntry(exc.Message, EventLogEntryType.Error);
		}
		
		void EnterNumberOnly(KeyPressEventArgs e)
		{
			if (!(Char.IsDigit(e.KeyChar) || (e.KeyChar == (char)Keys.Back)))
		     {
		          e.Handled = true;
		          MessageBox.Show("Key in number only");
		     }
		}
		
		void Txtbx_ctn_qtyKeyPress(object sender, KeyPressEventArgs e)
		{
			EnterNumberOnly(e);
		}
		
		void Txtbx_roll_qtyKeyPress(object sender, KeyPressEventArgs e)
		{
			EnterNumberOnly(e);
		}
		
		void Btn_reportClick(object sender, EventArgs e)
		{
			this.Hide();
			using(frm_rpt_converting_pack_detail frm_conv_pack_detail = new frm_rpt_converting_pack_detail())
				frm_conv_pack_detail.ShowDialog();
			this.Show();			
		}
		
		
		void getStockCode()
		{
			using(frm_prod_converting_output_rework_popup frm_popup =  new frm_prod_converting_output_rework_popup())
			{
				
				frm_popup.ShowDialog();
				
				string prod_code_add = frm_prod_converting_output_rework_popup.prod_code;
				txtbx_ref_no.Text = prod_code_add;
								
			}
		}
	}
}
