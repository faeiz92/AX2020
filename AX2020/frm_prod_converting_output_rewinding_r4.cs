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
using Microsoft.Reporting.WinForms;

namespace AX2020
{
	/// <summary>
	/// Description of frm_prod_converting_output_rewinding_r4.
	/// </summary>
	public partial class frm_prod_converting_output_rewinding_r4 : Form
	{
		string init = "0";
		public static string sqlconn = "Server=AX-UAT; Password=sbax2020sbg; User ID=sbax2020; Initial Catalog=SBG_AX_2020; Integrated Security=false";
		public static string sqlconn2 = "Server=AX-UAT; Password=sbax2020sbg; User ID=sbax2020; Initial Catalog=MyProductionTrack; Integrated Security=false";
		public static string sqlconnStaging = "Server=AX-SQL; Password=ax2020sbgroup; User ID=ax2020sb; Initial Catalog=AX2020StagingDB; Integrated Security=false";
        
		
		bool clickCheck = false, jrExist = false;
		string username, jr_lot_no, jr_ref_no, jr_color, jr_shipmark, jr_barcode, staff_id, jr_stockcode, jr_micron, jr_width, jr_length;
		string ref_no = null, line_no = null, prod_line = null;
		int NextNo = 0, NextNoLR = 0, NextNoLROdd = 0, NextNoShip = 0, shipmark_bal = 0, shipmark_ori_length = 0;
		int i = 0, sumLg = 0;
		double sumAllReject = 0, total =0, qty_ctn_ordered = 0, qty_roll_ordered =0, bal = 0, balance = 0, consume = 0;
		
		double shrinkage = 0, print_align = 0, telescope = 0, uneven_thk = 0, wrinkle = 0, bubble = 0, core_dented = 0;
		double core_label = 0, dirt = 0, edge = 0, fish_eye = 0, glue = 0, init_wind = 0, tape_cut = 0, tape_end = 0, tape_line = 0, wave = 0, film = 0;
		string batchValue, jr_desc;
		public static string ship_mark = "";
		public static double type_balance = 0;
		double qty_balance = 0;
		int last_lg = 0;
		

		public frm_prod_converting_output_rewinding_r4()
		{
			InitializeComponent();
			this.ControlBox = false;
			
			username = frm_menu_system.userName; 
			lbl_username.Text = "User : " + username;
			txtbx_last_lr.Text = Convert.ToString(last_lg);
				
			DropDownList("SELECT * FROM TBL_PROD_CONV_JO_MACHINE_LIST WHERE PART = 'REWINDING' order by MACHINE_NO", cbx_machine, "MACHINE_NO");	
			DropDownList("SELECT * FROM TBL_PROD_CONV_JO_OUTPUT_SHIFT", cbx_shift, "SHIFT");
			DropDownList("SELECT sysstaffname FROM TBL_ADMIN_USER_FACTORY where sysdept = 'SLITTING' or sysdept = 'RCP' or sysdept = 'PAPER CORE' or sysdept = 'RIBBON'", cbx_operator, "sysstaffname");
			DropDownList("SELECT sysstaffname FROM TBL_ADMIN_USER_FACTORY where sysdept = 'SLITTING' or sysdept = 'RCP' or sysdept = 'PAPER CORE' or sysdept = 'RIBBON'", cbx_helper, "sysstaffname");
			//DropDownList("SELECT reject FROM TBL_PROD_CONV_JO_REWINDING_REJECT_LIST order by reject", cbx_reject, "reject");
			
			txtbx_total_m.Hide();
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
		
		void Frm_prod_converting_output_rewindingLoad(object sender, EventArgs e)
		{
			ClearAllText(this);
			DataGrid();	
			btn_del.Enabled = false;	

		}
		
		void DataGrid()
		{
	
//			DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
//			dt_grid.Columns.Add(btn);
//			//btn.HeaderText = "Delete";
//			btn.Text = "Delete";
//			//btn.Name = "btn";
//			btn.UseColumnTextForButtonValue = true;
			
			try
			{
				string sql = "SELECT PROD_DOCNO, PROD_LINE, PROD_DATE, PROD_SHIFT, PROD_CUSTOMER, PROD_TOTALROLL, PROD_QTYREJECT, PROD_CODE, PROD_BRAND, PROD_COLOR, PROD_MICRON, PROD_WIDTH, PROD_LENGTH FROM TBL_PROD_CONV_JO_REWINDING WHERE PROD_DATE>= DATEADD(day,-14, getdate()) and PROD_USERREVISION <> 'SAPS' order by PROD_DATE DESC, PROD_SHIFT";
		        SqlConnection connection = new SqlConnection(sqlconn);
		        SqlDataAdapter dataadapter = new SqlDataAdapter(sql, connection);
		        //DataSet ds = new DataSet();
		        DataTable ds = new DataTable();
		        connection.Open();
		        //dataadapter.Fill(ds, "TBL_PROD_CONV_JO_SLITTING");
		        dataadapter.Fill(ds);
		                     
//		        DataTable tempDT = new DataTable();
//				tempDT = ds.DefaultView.ToTable(true, "PROD_DOCNO", "PROD_LINE", "PROD_CUSTOMER", "PROD_CODE", "PROD_BRAND", "PROD_COLOR", "PROD_MICRON", "PROD_WIDTH", "PROD_LENGTH");
//				dt_grid.DataSource = tempDT;
				 
				//connection.Close();
		        dt_grid.DataSource = ds;
//              dt_grid.DataMember = "TBL_PROD_CONV_JO_SLITTING";
//  			dt_grid.DataMember = ds;
			}
			catch(Exception ex)
			{
				MessageBox.Show("Error - Rewinding DataGrid \nCannot load DB" + ex.Message + ex.ToString());
				return;
			}
			finally
			{
				dt_grid.Columns[0].HeaderText = "Ref No";
				dt_grid.Columns[0].Width = 150;
				dt_grid.Columns[1].HeaderText = "Line No";
				dt_grid.Columns[1].Width = 80;
				dt_grid.Columns[2].HeaderText = "Date";
				dt_grid.Columns[2].DefaultCellStyle.Format = "dd/MM/yyyy";
				dt_grid.Columns[2].Width = 80;
				dt_grid.Columns[3].HeaderText = "Shift";
				dt_grid.Columns[3].Width = 80;
				dt_grid.Columns[4].HeaderText = "Customer";
				dt_grid.Columns[4].Width = 300;
				dt_grid.Columns[5].HeaderText = "Total (Roll)";
				dt_grid.Columns[5].Width = 60;
				dt_grid.Columns[6].HeaderText = "Total Reject";
				dt_grid.Columns[6].Width = 60;
				dt_grid.Columns[7].HeaderText = "Code";
				dt_grid.Columns[7].Width = 80;
				dt_grid.Columns[8].HeaderText = "Brand";
				dt_grid.Columns[8].Width = 80;
				dt_grid.Columns[9].HeaderText = "Color";
				dt_grid.Columns[9].Width = 80;
				dt_grid.Columns[10].HeaderText = "Micron";
				dt_grid.Columns[11].HeaderText = "Width";
				dt_grid.Columns[12].HeaderText = "Length";
				
			}

		}
		void Btn_searchClick(object sender, EventArgs e)
		{
			Search();			
			
		}
		
		void Search()
		{
			SqlConnection con_SP1 = new SqlConnection(sqlconn);
			SqlCommand cmd_SP1 = new SqlCommand();
			
			try 
			{
				cmd_SP1.CommandText = @"select * from TBL_PROD_CONV_JO where JODOCNO = @doc_no";
				cmd_SP1.Parameters.AddWithValue("@doc_no",  txtbx_ref_no.Text.ToUpper().Trim());
				cmd_SP1.Connection = con_SP1;
				con_SP1.Open();
				SqlDataReader rd_SP1 = cmd_SP1.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
				
				if (rd_SP1.Read())
				{	
					//checkButton = true;
//					btn_del.Visible = false;
//		        	btn_save.Visible = true;
					//btn_clear.Visible = true;
					//btn_cancel.Visible = true;
		        	//btn_del.Location = new Point(416, 1348);
		        	//grpbox_output.Visible = true;
					//grpbox_cust.Visible = true;
		        	//btn_save.Location = new Point(306, 871);
		        	//btn_clear.Location = new Point(432, 871);
		        	//btn_cancel.Location = new Point(558, 871);	
		        	ref_no = txtbx_ref_no.Text;
					txtbx_cust.Text = rd_SP1["JOCUSTOMER"].ToString();
					txtbx_prod_code.Text = rd_SP1["JOSTOCKCODE"].ToString();
					txtbx_color.Text = rd_SP1["JOSTOCKCOLOR"].ToString();
					txtbx_brand.Text = rd_SP1["JOSTOCKBRAND"].ToString();

					//int prod_length = Convert.ToInt32(rd_SP1["JOSTOCKLENGTH"].ToString());
					txtbx_width_cust.Text = rd_SP1["JOSTOCKWIDTH"].ToString();
					txtbx_length_cust.Text = rd_SP1["JOSTOCKLENGTH"].ToString();
					txtbx_conversion.Text = rd_SP1["JOSTOCKCONVERSION"].ToString();
					qty_ctn_ordered = Convert.ToDouble(rd_SP1["JOSTOCKQTYCTN"]);
					qty_roll_ordered = Convert.ToDouble(rd_SP1["JOSTOCKQTYROLL"]);
					txtbx_total_qty_order.Text = rd_SP1["JOPRODREMARK0c"].ToString();					
					txtbx_mic_cust.Text = rd_SP1["JOSTOCKMICRON"].ToString();
					txtbx_no_logroll.Text = rd_SP1["JOPRODREMARK0b"].ToString();
									
					
					txtbx_total_qty_balance.Text = rd_SP1["JOPRODQTYBAL"].ToString();
					bal = Convert.ToDouble(rd_SP1["JOPRODQTYBAL"]);
//					int pcore_length = Convert.ToInt32(new String(rd_SP1["JOPRODPCORELENGTH"].ToString().Where(Char.IsDigit).ToArray()));
//					txtbx_no_logroll.Text = Convert.ToString(pcore_length/prod_length);
					TotalMeterCalculation();
				} 
				else 
				{
					MessageBox.Show("Error - Rewinding Search \nCannot find JO!");
					return;
				}
			} 
			catch (Exception ex) 
			{
				MessageBox.Show("Error - Rewinding Search \nCannot load DB!" + ex.Message + ex.ToString());
				return;
			} 
			finally 
			{
				con_SP1.Close();
			}
			
			con_SP1.Dispose();
			con_SP1 = null;
			cmd_SP1 = null;	
			
			clickCheck = true;
			EnableAllControls(this);
			btn_del.Enabled = false;
		}
		
		void Btn_clearClick(object sender, EventArgs e)
		{
			OperatorID();
//			ClearAllText(this);
//			ClearVariable();
//			DataGrid();
//			btn_save.Enabled = true;
//			btn_del.Enabled = false;
//			txtbx_ref_no.Focus();
											
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
                //((ComboBox)c).Text = "Please Select";
      				((ComboBox)c).SelectedValue = "Please Select";
				
				if(c is DateTimePicker)
				{
					((DateTimePicker)c).Value = DateTime.Now;
				}      			
   			}
    		
			txtbx_no_logroll.Text = init;
			txtbx_no_logroll_store.Text = init;
			txtbx_rcp.Text = init;
			txtbx_linestop.Text = init;
			txtbx_tapewrinklecoat.Text = init;
			txtbx_tapewrinklerewind.Text = init;
			txtbx_linerwrinkle.Text = init;
			txtbx_backjoint.Text = init;
			txtbx_linerjoint.Text = init;
			txtbx_lastlog.Text = init;
			txtbx_linenoglue.Text = init;
			txtbx_edge.Text = init;
			txtbx_gap.Text = init;
			txtbx_dirt.Text = init;
			txtbx_noglueall.Text = init;
			txtbx_printdefect.Text = init;
			txtbx_torn.Text = init;
			txtbx_uneventhick.Text = init;
			txtbx_thickcheck.Text = init;
			txtbx_airtrap.Text = init;
			txtbx_sample.Text = init;
			

			
			txtbx_extra.Text = init;
			txtbx_total_m.Text = init;
			txtbx_total_meter.Text = init;
			txtbx_last_lr.Text = init;
			ClearVariable();

		}
		
		void ClearVariable()
		{
			sumAllReject = 0;
			total = 0;
			qty_ctn_ordered = 0;
			qty_roll_ordered =0;
			bal = 0;
			
			clickCheck = false;
			jr_lot_no = null;
			jr_ref_no = null;
			jr_color = null;
			jr_shipmark = null;
			jr_barcode = null;
			jr_micron = null;
			jr_width = null;
			jr_length = null;
			jr_desc = null;
			ref_no = null; 
			line_no = null;
			NextNo = 0;
			NextNoShip = 0;
			prod_line = null;
		 	balance = 0;
		 	consume = 0;
		 	shipmark_bal = 0;
		 	shipmark_ori_length = 0;
		 	
//		 	shrinkage = 0;
//			print_align = 0;
//			telescope = 0;
//			uneven_thk = 0;
//			wrinkle = 0;
//			bubble = 0;
//			core_dented = 0;
//			core_label = 0;
//			dirt = 0;
//			edge = 0;
//			fish_eye = 0;
//			glue = 0;
//			init_wind = 0;		
//			tape_cut = 0;
//			tape_end = 0;
//			tape_line = 0;
//			wave = 0;
//			film = 0;
		 	
		 	txtbx_length.ReadOnly = true;
		 	txtbx_width.ReadOnly = true;
		 	txtbx_mic.ReadOnly = true;
		 	txtbx_extra.ReadOnly = false;
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
		
		void DropDownList(string cmd, ComboBox cbx_text, string col_name)
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
            	MessageBox.Show("Error - Rewinding DropDown List \nCannot load DB" + se.ToString() + se.Message);
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
           	
           	if (CommonValidation.ValidateIsEmptyString(cbx_operator.Text.Trim()) || cbx_operator.Text == "Please Select")
            {
             	DialogBox.ShowWarningMessage(lbl_operator_name.Text + " cannot be empty.");
                cbx_operator.Focus();
                   	
                return false;     
            }
                 
           	else if (CommonValidation.ValidateIsEmptyString(cbx_helper.Text.Trim()) || cbx_helper.Text == "Please Select")
            {
                DialogBox.ShowWarningMessage(lbl_helper.Text + " cannot be empty.");
                cbx_helper.Focus();
                   	
                return false;       
            }
           	
           	
           	
           	else if (CommonValidation.ValidateIsEmptyString(txtbx_length.Text.Trim()) || txtbx_length.Text == "0")
            {
                DialogBox.ShowWarningMessage(lbl_length.Text + " cannot be empty.");
                txtbx_length.Focus();
                   	
                return false;       
            }
           	
           		
           	else if (Int32.Parse(txtbx_length.Text) < 0)
            {
                DialogBox.ShowWarningMessage(lbl_length.Text + " cannot be negative.");
                txtbx_length.Focus();
                   	
                return false;       
            }
           	
           	else if (CommonValidation.ValidateIsEmptyString(txtbx_width.Text.Trim()) || txtbx_width.Text == "0")
            {
                DialogBox.ShowWarningMessage(lbl_width.Text + " cannot be empty.");
                txtbx_width.Focus();
                   	
                return false;       
            }
           	
//           	else if (CommonValidation.ValidateIsEmptyString(txtbx_mic.Text.Trim()) || txtbx_mic.Text == "0")
//            {
//                DialogBox.ShowWarningMessage(lbl_mic.Text + " cannot be empty.");
//                txtbx_mic.Focus();
//                   	
//                return false;       
//            }
           	
           	
            return true;
        }
		
//		void RejectCalculation()
//		{
//			
//			foreach (Control c in grpbx_reject.Controls)
//            {
//                if (c is TextBox)
//                {
//                	sumAllReject = sumAllReject + Double.Parse(c.Text);
//                }
//            }
//			
//			total = Double.Parse(txtbx_qty_logroll.Text) * Double.Parse(txtbx_no_logroll.Text) - sumAllReject;
//			consume = Math.Round(Double.Parse(txtbx_length_cust.Text) * Double.Parse(txtbx_no_logroll.Text), 2);
//			balance = Math.Round(Double.Parse(txtbx_length.Text) - consume, 2);
//		}
		
		private void PerformProcess()
        {
            frm_process_dialog frm = new frm_process_dialog();
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Show();
            this.Enabled = false;
            try
            {
                if (LineNoGenerator())
				{
				
					if (sqlConnParm("SP_PROD_CONV_JO_REWINDING_ADD") & sqlConnParmReject("SP_PROD_CONV_JO_REWINDING_REJECT_R2_ADD") & sqlConnParmShipMark("SP_PROD_CONV_JO_REWINDING_SHIPMARK_ADD_R3"))
					{
						//MessageBox.Show("အောင်မြင်စွာ ထိုအခါ \nစံချိန်သိမ်းဆည်း");
						//DialogBox.ShowSaveSuccessDialog();
						
						for (i = 1; i< Int32.Parse(txtbx_no_logroll.Text); i++)
						{
							sqlConnParmLR("SP_PROD_CONV_JO_REWINDING_SHIPMARK_LR_ADD");
							
							if(i == Int32.Parse(txtbx_no_logroll.Text))
							{
								sqlConnParmLast("SP_PROD_CONV_JO_REWINDING_SHIPMARK_LR_ADD");
							}
							
							sumLg = sumLg + 1;						
						}
						
						for (i = 0; i< Int32.Parse(txtbx_no_logroll_store.Text); i++)
						{
							sqlConnParmLRStore("SP_PROD_CONV_JO_REWINDING_SHIPMARK_LR_ADD");
							sumLg = sumLg + 1;						
						}
						
						//MessageBox.Show(i.ToString());
						
						UpdateBal("SP_PROD_CONV_UPDATE");		
						ship_mark = txtbx_shipping_mark.Text;	
						//type_balance = 						
						
							
						frm_messageBox msg = new frm_messageBox();
						msg.ShowDialog();
						Print();
						
						
						ship_mark = txtbx_shipping_mark.Text; 
						
						qty_balance = Convert.ToDouble(txtbx_no_logroll.Text) * Convert.ToDouble(txtbx_length_cust.Text);
						
						type_balance = Convert.ToDouble(txtbx_total_m.Text) - qty_balance;
						
						
						MessageBox.Show("Quantityt balance is:" + type_balance);
						
						


						frm_prod_conv_output_rewinding_popup_yesno obj_yesno = new frm_prod_conv_output_rewinding_popup_yesno();
						obj_yesno.Show();
				
							
						txtbx_ref_no.Clear();
						ClearAllTextGroupBx(groupbox_jr);
						ClearAllTextGroupBxInit(grpbox_output);	
						ClearAllTextGroupBxInit(grpbx_reject);
						ClearAllTextGroupBxInit(grpbox_cust);
						txtbx_extra.Text = init;
						ClearVariable();
							
						txtbx_ref_no.Focus();
						btn_save.Enabled = true;
						btn_del.Enabled = false;
						DataGrid();
					}
		
				}
			
            }
            finally
            {
                this.Enabled = true;
                frm.Close();
            }
        }
		  
		void Btn_saveClick(object sender, EventArgs e)
		{
			if (!Validation())
                return;
			
			if (clickCheck == false)
			{
				MessageBox.Show("Please make sure you click the Check button");
				return;
			}
			
			if(!NoLRCheck())
			{
				MessageBox.Show("No of Log Roll is incorrect");
				txtbx_no_logroll.Focus();
				return;
			}
			
			
//			if(Double.Parse(txtbx_rcp.Text) > (Double.Parse(txtbx_length.Text) - Double.Parse(txtbx_total_meter.Text)))
//			{
//				MessageBox.Show("Balance of No Good Output is incorrect");
//				txtbx_rcp.Focus();
//				return;
//			}
		
			
//			if(txtbx_bal_m.Text != "0" && cbx_reject.Text == "Please Select")
//			{
//				MessageBox.Show("Please select Reject list");
//				cbx_reject.Focus();
//				return;
//			}
			RejectCalculation();
			//Reject();
			
			OperatorID();
						
			PerformProcess();
			
			clickCheck = false;		
			
			
			
			
			
			
			
		}
		
		
		
		
		void OperatorID()
		{
			SqlConnection con_SP1 = new SqlConnection(sqlconn);
			SqlCommand cmd_SP1 = new SqlCommand();
			
			try 
			{
				cmd_SP1.CommandText = @"select * from TBL_ADMIN_USER_FACTORY where sysstaffname = @staff_name";
				cmd_SP1.Parameters.AddWithValue("@staff_name",  cbx_operator.Text);
				cmd_SP1.Connection = con_SP1;
				con_SP1.Open();
				SqlDataReader rd_SP1 = cmd_SP1.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
				
				if (rd_SP1.Read())
				{	
					
					staff_id = rd_SP1["sysstaffid"].ToString();
				} 
				else 
				{
					MessageBox.Show("Error - Rewinding Save ID \nCannot find JO!");
					return;
				}
			} 
			catch (Exception ex) 
			{
				MessageBox.Show("Error - Rewinding Save ID \nCannot load DB!" + ex.Message + ex.ToString());
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
		
		void ClearAllTextGroupBxInit(GroupBox gbx)
        {
            foreach (Control c in gbx.Controls)
            {
                if (c is TextBox)
                {
                	c.Text = init;
                }
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
					
				cmd.Parameters.Add(new SqlParameter("@SP_JOPRODQTYTOTAL", SqlDbType.Float));
				cmd.Parameters["@SP_JOPRODQTYTOTAL"].Value = bal;
								        
				cmd.Parameters.Add(new SqlParameter("@SP_JOTOTALSLIT", SqlDbType.Float));
				cmd.Parameters["@SP_JOTOTALSLIT"].Value = total;
					
					
				cmd.Parameters.Add(new SqlParameter("@SP_PROD_SHIPMARK", SqlDbType.NVarChar, 50));
				cmd.Parameters["@SP_PROD_SHIPMARK"].Value = txtbx_shipping_mark.Text;
								        
				cmd.Parameters.Add(new SqlParameter("@SP_PROD_CONSUME", SqlDbType.Float));
				cmd.Parameters["@SP_PROD_CONSUME"].Value = consume;
					
				cmd.Parameters.Add(new SqlParameter("@SP_PROD_BALANCE", SqlDbType.Float));
				cmd.Parameters["@SP_PROD_BALANCE"].Value = balance;

				cmd.ExecuteNonQuery();				
			}				
		}
		
		bool LineNoGenerator()
		{			
			SqlConnection conNextNumber = new SqlConnection(sqlconn);
			SqlCommand cmdNextNumber = new SqlCommand();
			
			try 
			{
				cmdNextNumber.CommandText = "Select ProdConvRewindNextNumber, ProdConvSlitShipNextNumber, ProdConvRewindShipLRNextNumber, ProdConvRewindShipLROddNextNumber from TBL_ADMIN_NEXT_NUMBER";
				cmdNextNumber.Connection = conNextNumber;

				conNextNumber.Open();
				SqlDataReader rdNextNumber = cmdNextNumber.ExecuteReader(System.Data.CommandBehavior.CloseConnection);

				rdNextNumber.Read();
				NextNo = Convert.ToInt32(rdNextNumber["ProdConvRewindNextNumber"]);
				
				NextNoLR = Convert.ToInt32(rdNextNumber["ProdConvRewindShipLRNextNumber"]);
				NextNoLROdd = Convert.ToInt32(rdNextNumber["ProdConvRewindShipLROddNextNumber"]);
				
				NextNoShip = Convert.ToInt32(rdNextNumber["ProdConvSlitShipNextNumber"]);
			
			} 
			catch (Exception ex) 
			{
				MessageBox.Show("Error - Rewinding Next Number \nCannot load DB!" + ex.Message + ex.ToString());
				return false;
			} 
			finally 
			{
				conNextNumber.Close();
				
			}
			
			conNextNumber.Dispose();
			conNextNumber = null;
			cmdNextNumber = null;
			
			prod_line = NextNo.ToString("0000");

			if(NextNo == 9999)
			{
				SqlConnection conUpdate = new SqlConnection(sqlconn);
				SqlCommand cmdUpdateNextNumber = new SqlCommand();
	
				try
				{
					cmdUpdateNextNumber.CommandText = "update TBL_ADMIN_NEXT_NUMBER set ProdConvRewindNextNumber = 1000";
					
					cmdUpdateNextNumber.Connection = conUpdate;
	
					conUpdate.Open();
					cmdUpdateNextNumber.ExecuteNonQuery();
	
				}
				catch (Exception ex)
				{
					conUpdate.Close();
					MessageBox.Show("Error - Rewinding Next Number \nCannot update DB" + ex.Message + ex.ToString());
					return false;
				}
				finally 
				{
					conUpdate.Close();
				}
	
				conUpdate.Dispose();
				conUpdate = null;
				cmdUpdateNextNumber = null;
			}
			else
			{
				SqlConnection conUpdate2 = new SqlConnection(sqlconn);
				SqlCommand cmdUpdateNextNumber2 = new SqlCommand();
	
				try
				{
					cmdUpdateNextNumber2.CommandText = "update TBL_ADMIN_NEXT_NUMBER set ProdConvRewindNextNumber = ProdConvRewindNextNumber + 1";
					
					cmdUpdateNextNumber2.Connection = conUpdate2;
	
					conUpdate2.Open();
					cmdUpdateNextNumber2.ExecuteNonQuery();
	
				}
				catch (Exception ex)
				{
					conUpdate2.Close();
					MessageBox.Show("Error - Rewinding Next Number \nCannot update DB" + ex.Message + ex.ToString());
					return false;
				}
				finally 
				{
					conUpdate2.Close();
				}
	
				conUpdate2.Dispose();
				conUpdate2 = null;
				cmdUpdateNextNumber2 = null;
			}
			
			
			
			
			
			SqlConnection conUpdate3 = new SqlConnection(sqlconn);
			SqlCommand cmdUpdateNextNumber3 = new SqlCommand();

			try
			{
				cmdUpdateNextNumber3.CommandText = "update TBL_ADMIN_NEXT_NUMBER set ProdConvSlitShipNextNumber = ProdConvSlitShipNextNumber + 1";
				
				cmdUpdateNextNumber3.Connection = conUpdate3;

				conUpdate3.Open();
				cmdUpdateNextNumber3.ExecuteNonQuery();

			}
			catch (Exception ex)
			{
				conUpdate3.Close();
				MessageBox.Show("Error - Rewinding Next Number Shipmark \nCannot update DB" + ex.Message + ex.ToString());
				return false;
			}
			finally 
			{
				conUpdate3.Close();
			}

			conUpdate3.Dispose();
			conUpdate3 = null;
			cmdUpdateNextNumber3 = null;
			
			
			return true;			
		}
		
		bool LineNoGeneratorLR()
		{
			SqlConnection conNextNumber8 = new SqlConnection(sqlconn);
			SqlCommand cmdNextNumber8 = new SqlCommand();
			
			try 
			{
				cmdNextNumber8.CommandText = "Select ProdConvRewindShipLRNextNumber, ProdConvRewindShipLROddNextNumber from TBL_ADMIN_NEXT_NUMBER";
				cmdNextNumber8.Connection = conNextNumber8;

				conNextNumber8.Open();
				SqlDataReader rdNextNumber8 = cmdNextNumber8.ExecuteReader(System.Data.CommandBehavior.CloseConnection);

				rdNextNumber8.Read();
				
				
				NextNoLR = Convert.ToInt32(rdNextNumber8["ProdConvRewindShipLRNextNumber"]);
				NextNoLROdd = Convert.ToInt32(rdNextNumber8["ProdConvRewindShipLROddNextNumber"]);
				
				
			
			} 
			catch (Exception ex) 
			{
				MessageBox.Show("Error - Rewinding Next Number LR\nCannot load DB!" + ex.Message + ex.ToString());
				return false;
			} 
			finally 
			{
				conNextNumber8.Close();
				
			}
			
			conNextNumber8.Dispose();
			conNextNumber8 = null;
			cmdNextNumber8 = null;
			
			if(NextNoLR == 99)
			{
				SqlConnection conUpdate4 = new SqlConnection(sqlconn);
				SqlCommand cmdUpdateNextNumber4 = new SqlCommand();
	
				try
				{
					cmdUpdateNextNumber4.CommandText = "update TBL_ADMIN_NEXT_NUMBER set ProdConvRewindShipLRNextNumber = 01";
					
					cmdUpdateNextNumber4.Connection = conUpdate4;
	
					conUpdate4.Open();
					cmdUpdateNextNumber4.ExecuteNonQuery();
	
				}
				catch (Exception ex)
				{
					conUpdate4.Close();
					MessageBox.Show("Error - Rewinding Next Number LR\nCannot update DB" + ex.Message + ex.ToString());
					return false;
				}
				finally 
				{
					conUpdate4.Close();
				}
	
				conUpdate4.Dispose();
				conUpdate4 = null;
				cmdUpdateNextNumber4 = null;
			}
			else
			{
				SqlConnection conUpdate5 = new SqlConnection(sqlconn);
				SqlCommand cmdUpdateNextNumber5 = new SqlCommand();
	
				try
				{
					cmdUpdateNextNumber5.CommandText = "update TBL_ADMIN_NEXT_NUMBER set ProdConvRewindShipLRNextNumber = ProdConvRewindShipLRNextNumber + 1";
					
					cmdUpdateNextNumber5.Connection = conUpdate5;
	
					conUpdate5.Open();
					cmdUpdateNextNumber5.ExecuteNonQuery();
	
				}
				catch (Exception ex)
				{
					conUpdate5.Close();
					MessageBox.Show("Error - Rewinding Next Number LR \nCannot update DB" + ex.Message + ex.ToString());
					return false;
				}
				finally 
				{
					conUpdate5.Close();
				}
	
				conUpdate5.Dispose();
				conUpdate5 = null;
				cmdUpdateNextNumber5 = null;
			}
			
			//--------------------------Odd Number Next No----------------------------------
			
//			if(NextNo == 99)
//			{
//				SqlConnection conUpdate6 = new SqlConnection(sqlconn);
//				SqlCommand cmdUpdateNextNumber6 = new SqlCommand();
//	
//				try
//				{
//					cmdUpdateNextNumber6.CommandText = "update TBL_ADMIN_NEXT_NUMBER set ProdConvRewindShipLROddNextNumber = 01";
//					
//					cmdUpdateNextNumber6.Connection = conUpdate6;
//	
//					conUpdate6.Open();
//					cmdUpdateNextNumber6.ExecuteNonQuery();
//	
//				}
//				catch (Exception ex)
//				{
//					conUpdate6.Close();
//					MessageBox.Show("Error - Rewinding Next Number LR Odd\nCannot update DB" + ex.Message + ex.ToString());
//					return false;
//				}
//				finally 
//				{
//					conUpdate6.Close();
//				}
//	
//				conUpdate6.Dispose();
//				conUpdate6 = null;
//				cmdUpdateNextNumber6 = null;
//			}
//			else
//			{
//				SqlConnection conUpdate7 = new SqlConnection(sqlconn);
//				SqlCommand cmdUpdateNextNumber7 = new SqlCommand();
//	
//				try
//				{
//					cmdUpdateNextNumber7.CommandText = "update TBL_ADMIN_NEXT_NUMBER set ProdConvRewindShipLROddNextNumber = ProdConvRewindShipLROddNextNumber + 2";
//					
//					cmdUpdateNextNumber7.Connection = conUpdate7;
//	
//					conUpdate7.Open();
//					cmdUpdateNextNumber7.ExecuteNonQuery();
//	
//				}
//				catch (Exception ex)
//				{
//					conUpdate7.Close();
//					MessageBox.Show("Error - Rewinding Next Number LR Odd \nCannot update DB" + ex.Message + ex.ToString());
//					return false;
//				}
//				finally 
//				{
//					conUpdate7.Close();
//				}
//	
//				conUpdate7.Dispose();
//				conUpdate7 = null;
//				cmdUpdateNextNumber7 = null;
//			}
			
			return true;
		}
		
		bool sqlConnParm(string sqlStatement)
		{
			string trim_ref_no = ref_no.Substring(0, ref_no.LastIndexOf("-"));
			string line_no = trim_ref_no.Substring(trim_ref_no.IndexOf('-')+1);
			
			SqlConnection con_data = new SqlConnection(sqlconn);
			SqlCommand cmd_data = new SqlCommand();
			
			try
			{
					cmd_data.Connection = con_data;
					cmd_data.CommandText = sqlStatement;
					cmd_data.CommandType = CommandType.StoredProcedure;

					cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_SONO", SqlDbType.NVarChar, 20));
					cmd_data.Parameters["@SP_PROD_SONO"].Value = ref_no.Substring(0, ref_no.IndexOf('-')).ToUpper();
					
					cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_SOLINENO", SqlDbType.NVarChar, 20));
					cmd_data.Parameters["@SP_PROD_SOLINENO"].Value = line_no;
					
					cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_DOCNO", SqlDbType.NVarChar, 50));
					cmd_data.Parameters["@SP_PROD_DOCNO"].Value = ref_no.ToUpper();
					
					cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_REPORTDATE", SqlDbType.DateTime));
					cmd_data.Parameters["@SP_PROD_REPORTDATE"].Value = dtp_date.Value;

					cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_CODE", SqlDbType.NVarChar, 50));
					cmd_data.Parameters["@SP_PROD_CODE"].Value = txtbx_prod_code.Text.ToUpper();

					cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_CUSTOMER", SqlDbType.NVarChar, 50));
					cmd_data.Parameters["@SP_PROD_CUSTOMER"].Value = txtbx_cust.Text.ToUpper();

					cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_COLOR", SqlDbType.NVarChar, 50));
					cmd_data.Parameters["@SP_PROD_COLOR"].Value = txtbx_color.Text.ToUpper();

					cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_BRAND", SqlDbType.NVarChar, 50));
					cmd_data.Parameters["@SP_PROD_BRAND"].Value = txtbx_brand.Text.ToUpper();

					cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_WIDTH", SqlDbType.Float));
					cmd_data.Parameters["@SP_PROD_WIDTH"].Value = Double.Parse(txtbx_width_cust.Text);

					cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_LENGTH ", SqlDbType.Float));
					cmd_data.Parameters["@SP_PROD_LENGTH "].Value = Double.Parse(txtbx_length_cust.Text);

					cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_MICRON", SqlDbType.Float));
					cmd_data.Parameters["@SP_PROD_MICRON"].Value = Double.Parse(txtbx_mic_cust.Text);
					
					cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_QTYORDERED", SqlDbType.Float));
					cmd_data.Parameters["@SP_PROD_QTYORDERED"].Value = Convert.ToDouble(txtbx_total_qty_order.Text);

					cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_QTYCTNORDERED", SqlDbType.Float));
					cmd_data.Parameters["@SP_PROD_QTYCTNORDERED"].Value = qty_ctn_ordered;
					
					cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_QTYROLLORDERED", SqlDbType.Float));
					cmd_data.Parameters["@SP_PROD_QTYROLLORDERED"].Value = qty_roll_ordered;
					
					cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_CONVERSION", SqlDbType.Float));
					cmd_data.Parameters["@SP_PROD_CONVERSION"].Value = Double.Parse(txtbx_conversion.Text);
				
					cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_ETDDATE", SqlDbType.DateTime));
					cmd_data.Parameters["@SP_PROD_ETDDATE"].Value = dtp_date.Value;
					
					cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_STARTDATE", SqlDbType.DateTime));
					cmd_data.Parameters["@SP_PROD_STARTDATE"].Value = dtp_date.Value;
					
					cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_ENDDATE", SqlDbType.DateTime));
					cmd_data.Parameters["@SP_PROD_ENDDATE"].Value = dtp_date.Value;
					
					
					cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_SHIPMARK", SqlDbType.NVarChar, 50));
					cmd_data.Parameters["@SP_PROD_SHIPMARK"].Value = jr_shipmark;		
					
					cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_JRWIDTH", SqlDbType.Float));
					//cmd_data.Parameters["@SP_JOSTOCKQTYCTN"].Value = Double.TryParse(txtbx_ctn_order.Text, out notParseDouble);
					cmd_data.Parameters["@SP_PROD_JRWIDTH"].Value = Double.Parse(txtbx_width.Text);
					
					cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_JRLENGTH", SqlDbType.Float));
					//cmd_data.Parameters["@SP_JOSTOCKQTYROLL"].Value = Double.TryParse(txtbx_roll_order.Text, out notParseDouble);
					cmd_data.Parameters["@SP_PROD_JRLENGTH"].Value = Double.Parse(txtbx_length.Text);
					
					cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_JRMICRON", SqlDbType.Float));
					cmd_data.Parameters["@SP_PROD_JRMICRON"].Value = 0;//Double.Parse(txtbx_mic.Text);
					
					cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_JRLOTNO", SqlDbType.NVarChar, 50));
					cmd_data.Parameters["@SP_PROD_JRLOTNO"].Value = jr_lot_no;
					
					cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_JRJONO", SqlDbType.NVarChar, 50));
					cmd_data.Parameters["@SP_PROD_JRJONO"].Value = jr_ref_no;
					
					
					cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_JRCOLOR", SqlDbType.NVarChar, 50));
					cmd_data.Parameters["@SP_PROD_JRCOLOR"].Value = jr_color;
					
					cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_LINE", SqlDbType.NVarChar, 50));
					cmd_data.Parameters["@SP_PROD_LINE"].Value = prod_line;
					
					cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_MACHINE", SqlDbType.NVarChar, 50));
					cmd_data.Parameters["@SP_PROD_MACHINE"].Value = cbx_machine.Text.ToUpper();
					
					cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_MACHINESPEED", SqlDbType.Float));
					cmd_data.Parameters["@SP_PROD_MACHINESPEED"].Value = 0;
						
					
					cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_OPERATOR", SqlDbType.NVarChar, 50));
					cmd_data.Parameters["@SP_PROD_OPERATOR"].Value = cbx_operator.Text.ToUpper();
					
					cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_HELPER", SqlDbType.NVarChar, 50));
					cmd_data.Parameters["@SP_PROD_HELPER"].Value = cbx_helper.Text.ToUpper();
					
					cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_SUPERVISOR", SqlDbType.NVarChar, 50));
					cmd_data.Parameters["@SP_PROD_SUPERVISOR"].Value = cbx_helper.Text.ToUpper();
					
					cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_SHIFT", SqlDbType.NVarChar, 50));
					cmd_data.Parameters["@SP_PROD_SHIFT"].Value = cbx_shift.Text.ToUpper();	
					
					cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_DATE", SqlDbType.DateTime));
					cmd_data.Parameters["@SP_PROD_DATE"].Value = dtp_date.Value;
								
					
					cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_QTYPERLOGROLL", SqlDbType.Float));
					cmd_data.Parameters["@SP_PROD_QTYPERLOGROLL"].Value = 0;
					
					cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_NOLOGROLL", SqlDbType.Float));
					cmd_data.Parameters["@SP_PROD_NOLOGROLL"].Value = Convert.ToDouble(txtbx_no_logroll.Text);
					
					cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_QTYREJECT", SqlDbType.Float));
					cmd_data.Parameters["@SP_PROD_QTYREJECT"].Value = sumAllReject;
					
					cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_TOTALROLL", SqlDbType.Float));
					cmd_data.Parameters["@SP_PROD_TOTALROLL"].Value = total;
					
					
					cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_REMARK1", SqlDbType.NVarChar, 50));
					cmd_data.Parameters["@SP_PROD_REMARK1"].Value = staff_id;
					
					cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_REMARK2", SqlDbType.NVarChar, 50));
					cmd_data.Parameters["@SP_PROD_REMARK2"].Value = jr_desc;	
					

										
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
				MessageBox.Show("Error - Rewinding Save \nCannot load DB" + ex.Message + ex.ToString());			
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
		
		bool sqlConnParmLR(string sqlStatement)
		{
			string trim_ref_no = ref_no.Substring(0, ref_no.LastIndexOf("-"));
			string line_no = trim_ref_no.Substring(trim_ref_no.IndexOf('-')+1);
			
			SqlConnection con_data = new SqlConnection(sqlconn);
			SqlCommand cmd_data = new SqlCommand();
			
			try
			{
				cmd_data.Connection = con_data;
				cmd_data.CommandText = sqlStatement;
				cmd_data.CommandType = CommandType.StoredProcedure;

				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_SONO", SqlDbType.NVarChar, 20));
				cmd_data.Parameters["@SP_PROD_SONO"].Value = ref_no.Substring(0, ref_no.IndexOf('-')).ToUpper();
				
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_SOLINENO", SqlDbType.NVarChar, 20));
				cmd_data.Parameters["@SP_PROD_SOLINENO"].Value = line_no;
				
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_DOCNO", SqlDbType.NVarChar, 50));
				cmd_data.Parameters["@SP_PROD_DOCNO"].Value = ref_no.ToUpper();
				
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_REPORTDATE", SqlDbType.DateTime));
				cmd_data.Parameters["@SP_PROD_REPORTDATE"].Value = dtp_date.Value;

				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_CODE", SqlDbType.NVarChar, 50));
				cmd_data.Parameters["@SP_PROD_CODE"].Value = txtbx_prod_code.Text.ToUpper();

				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_CUSTOMER", SqlDbType.NVarChar, 50));
				cmd_data.Parameters["@SP_PROD_CUSTOMER"].Value = txtbx_cust.Text.ToUpper();

				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_COLOR", SqlDbType.NVarChar, 50));
				cmd_data.Parameters["@SP_PROD_COLOR"].Value = txtbx_color.Text.ToUpper();

				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_BRAND", SqlDbType.NVarChar, 50));
				cmd_data.Parameters["@SP_PROD_BRAND"].Value = txtbx_brand.Text.ToUpper();

				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_WIDTH", SqlDbType.Float));
				cmd_data.Parameters["@SP_PROD_WIDTH"].Value = Double.Parse(txtbx_width_cust.Text);

				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_LENGTH ", SqlDbType.Float));
				cmd_data.Parameters["@SP_PROD_LENGTH "].Value = Double.Parse(txtbx_length_cust.Text);

				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_MICRON", SqlDbType.Float));
				cmd_data.Parameters["@SP_PROD_MICRON"].Value = Double.Parse(txtbx_mic_cust.Text);
				
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_QTYORDERED", SqlDbType.Float));
				cmd_data.Parameters["@SP_PROD_QTYORDERED"].Value = Convert.ToDouble(txtbx_total_qty_order.Text);

				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_QTYCTNORDERED", SqlDbType.Float));
				cmd_data.Parameters["@SP_PROD_QTYCTNORDERED"].Value = qty_ctn_ordered;
				
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_QTYROLLORDERED", SqlDbType.Float));
				cmd_data.Parameters["@SP_PROD_QTYROLLORDERED"].Value = qty_roll_ordered;
				
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_CONVERSION", SqlDbType.Float));
				cmd_data.Parameters["@SP_PROD_CONVERSION"].Value = Double.Parse(txtbx_conversion.Text);
			
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_ETDDATE", SqlDbType.DateTime));
				cmd_data.Parameters["@SP_PROD_ETDDATE"].Value = dtp_date.Value;
				
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_STARTDATE", SqlDbType.DateTime));
				cmd_data.Parameters["@SP_PROD_STARTDATE"].Value = dtp_date.Value;
				
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_ENDDATE", SqlDbType.DateTime));
				cmd_data.Parameters["@SP_PROD_ENDDATE"].Value = dtp_date.Value;
				
				
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_SHIPMARK", SqlDbType.NVarChar, 50));
				cmd_data.Parameters["@SP_PROD_SHIPMARK"].Value = jr_shipmark;		
				
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_JRWIDTH", SqlDbType.Float));
				//cmd_data.Parameters["@SP_JOSTOCKQTYCTN"].Value = Double.TryParse(txtbx_ctn_order.Text, out notParseDouble);
				cmd_data.Parameters["@SP_PROD_JRWIDTH"].Value = Double.Parse(txtbx_width.Text);
				
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_JRLENGTH", SqlDbType.Float));
				//cmd_data.Parameters["@SP_JOSTOCKQTYROLL"].Value = Double.TryParse(txtbx_roll_order.Text, out notParseDouble);
				cmd_data.Parameters["@SP_PROD_JRLENGTH"].Value = Double.Parse(txtbx_length.Text);
				
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_JRMICRON", SqlDbType.Float));
				cmd_data.Parameters["@SP_PROD_JRMICRON"].Value = 0;//Double.Parse(txtbx_mic.Text);
				
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_JRLOTNO", SqlDbType.NVarChar, 50));
				cmd_data.Parameters["@SP_PROD_JRLOTNO"].Value = jr_lot_no;
				
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_JRJONO", SqlDbType.NVarChar, 50));
				cmd_data.Parameters["@SP_PROD_JRJONO"].Value = jr_ref_no;
				
				
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_JRCOLOR", SqlDbType.NVarChar, 50));
				cmd_data.Parameters["@SP_PROD_JRCOLOR"].Value = jr_color;
				
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_LINE", SqlDbType.NVarChar, 50));
				cmd_data.Parameters["@SP_PROD_LINE"].Value = prod_line;
				
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_MACHINE", SqlDbType.NVarChar, 50));
				cmd_data.Parameters["@SP_PROD_MACHINE"].Value = cbx_machine.Text.ToUpper();
				
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_MACHINESPEED", SqlDbType.Float));
				cmd_data.Parameters["@SP_PROD_MACHINESPEED"].Value = 0;
					
				
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_OPERATOR", SqlDbType.NVarChar, 50));
				cmd_data.Parameters["@SP_PROD_OPERATOR"].Value = cbx_operator.Text.ToUpper();
				
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_HELPER", SqlDbType.NVarChar, 50));
				cmd_data.Parameters["@SP_PROD_HELPER"].Value = cbx_helper.Text.ToUpper();
				
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_SUPERVISOR", SqlDbType.NVarChar, 50));
				cmd_data.Parameters["@SP_PROD_SUPERVISOR"].Value = cbx_helper.Text.ToUpper();
				
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_SHIFT", SqlDbType.NVarChar, 50));
				cmd_data.Parameters["@SP_PROD_SHIFT"].Value = cbx_shift.Text.ToUpper();	
				
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_DATE", SqlDbType.DateTime));
				cmd_data.Parameters["@SP_PROD_DATE"].Value = dtp_date.Value;
							
				
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_QTYPERLOGROLL", SqlDbType.Float));
				cmd_data.Parameters["@SP_PROD_QTYPERLOGROLL"].Value = 0;
				
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_NOLOGROLL", SqlDbType.Float));
				cmd_data.Parameters["@SP_PROD_NOLOGROLL"].Value = Convert.ToDouble(txtbx_no_logroll.Text);
				
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_QTYREJECT", SqlDbType.Float));
				cmd_data.Parameters["@SP_PROD_QTYREJECT"].Value = Convert.ToDouble(txtbx_rcp.Text);
				
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_TOTALROLL", SqlDbType.Float));
				cmd_data.Parameters["@SP_PROD_TOTALROLL"].Value = Convert.ToDouble(txtbx_total_meter.Text);
				
				
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_REMARK1", SqlDbType.NVarChar, 50));
				cmd_data.Parameters["@SP_PROD_REMARK1"].Value = staff_id;
				
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_REMARK2", SqlDbType.NVarChar, 50));
				cmd_data.Parameters["@SP_PROD_REMARK2"].Value = jr_desc;
				
//					string jr_shipmark_short=null;
//					
//					if(txtbx_shipping_mark.Text.Substring(0,7).ToUpper()=="BAL-999")
//					{
//						jr_shipmark_short = "999";
//					}
//					else
//					{
//						int index = jr_shipmark.LastIndexOf("-");
//						
//						if (index > 0)
//						{
//						    jr_shipmark_short = jr_shipmark.Substring(0, index);
//							jr_shipmark_short = jr_shipmark_short.Replace("-", String.Empty);
//						}
//					}
					
				if( jr_stockcode.ToUpper().Substring(0, 2) == "WJ")
				{
					string lr = null;
					
					lr = jr_shipmark.ToUpper().Substring(0, 6) + jr_shipmark.ToUpper().Substring(jr_shipmark.Length-4);
					cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_SHIPMARKLR", SqlDbType.NVarChar, 50));
					cmd_data.Parameters["@SP_PROD_SHIPMARKLR"].Value = DateTime.Now.ToString("yyMMdd") + "-" + lr + "-" + sumLg.ToString("00");					
				}
				else
				{
					cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_SHIPMARKLR", SqlDbType.NVarChar, 50));
					cmd_data.Parameters["@SP_PROD_SHIPMARKLR"].Value = DateTime.Now.ToString("yyMMdd") + "-" + jr_shipmark + "-" + sumLg.ToString("00");
				}

//				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_SHIPMARKLR", SqlDbType.NVarChar, 50));
//				cmd_data.Parameters["@SP_PROD_SHIPMARKLR"].Value = DateTime.Now.ToString("yyMMdd") + "-" + jr_shipmark + "-" + sumLg.ToString("00");
					//DateTime.Now.Year.ToString().Substring(3,1) + DateTime.Now.ToString("MMdd") + jr_shipmark_short + prod_line + i.ToString("00");
				

									
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
				MessageBox.Show("Error - Rewinding Save \nCannot load DB" + ex.Message + ex.ToString());			
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
		
		bool sqlConnParmLast(string sqlStatement)
		{
			string trim_ref_no = ref_no.Substring(0, ref_no.LastIndexOf("-"));
			string line_no = trim_ref_no.Substring(trim_ref_no.IndexOf('-')+1);
			
			SqlConnection con_data = new SqlConnection(sqlconn);
			SqlCommand cmd_data = new SqlCommand();
			
			try
			{
				cmd_data.Connection = con_data;
				cmd_data.CommandText = sqlStatement;
				cmd_data.CommandType = CommandType.StoredProcedure;

				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_SONO", SqlDbType.NVarChar, 20));
				cmd_data.Parameters["@SP_PROD_SONO"].Value = ref_no.Substring(0, ref_no.IndexOf('-')).ToUpper();
				
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_SOLINENO", SqlDbType.NVarChar, 20));
				cmd_data.Parameters["@SP_PROD_SOLINENO"].Value = line_no;
				
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_DOCNO", SqlDbType.NVarChar, 50));
				cmd_data.Parameters["@SP_PROD_DOCNO"].Value = ref_no.ToUpper();
				
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_REPORTDATE", SqlDbType.DateTime));
				cmd_data.Parameters["@SP_PROD_REPORTDATE"].Value = dtp_date.Value;

				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_CODE", SqlDbType.NVarChar, 50));
				cmd_data.Parameters["@SP_PROD_CODE"].Value = txtbx_prod_code.Text.ToUpper();

				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_CUSTOMER", SqlDbType.NVarChar, 50));
				cmd_data.Parameters["@SP_PROD_CUSTOMER"].Value = txtbx_cust.Text.ToUpper();

				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_COLOR", SqlDbType.NVarChar, 50));
				cmd_data.Parameters["@SP_PROD_COLOR"].Value = txtbx_color.Text.ToUpper();

				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_BRAND", SqlDbType.NVarChar, 50));
				cmd_data.Parameters["@SP_PROD_BRAND"].Value = txtbx_brand.Text.ToUpper();

				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_WIDTH", SqlDbType.Float));
				cmd_data.Parameters["@SP_PROD_WIDTH"].Value = Double.Parse(txtbx_width_cust.Text);

				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_LENGTH ", SqlDbType.Float));
				cmd_data.Parameters["@SP_PROD_LENGTH "].Value = Double.Parse(txtbx_last_lr.Text);

				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_MICRON", SqlDbType.Float));
				cmd_data.Parameters["@SP_PROD_MICRON"].Value = Double.Parse(txtbx_mic_cust.Text);
				
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_QTYORDERED", SqlDbType.Float));
				cmd_data.Parameters["@SP_PROD_QTYORDERED"].Value = Convert.ToDouble(txtbx_total_qty_order.Text);

				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_QTYCTNORDERED", SqlDbType.Float));
				cmd_data.Parameters["@SP_PROD_QTYCTNORDERED"].Value = qty_ctn_ordered;
				
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_QTYROLLORDERED", SqlDbType.Float));
				cmd_data.Parameters["@SP_PROD_QTYROLLORDERED"].Value = qty_roll_ordered;
				
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_CONVERSION", SqlDbType.Float));
				cmd_data.Parameters["@SP_PROD_CONVERSION"].Value = Double.Parse(txtbx_conversion.Text);
			
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_ETDDATE", SqlDbType.DateTime));
				cmd_data.Parameters["@SP_PROD_ETDDATE"].Value = dtp_date.Value;
				
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_STARTDATE", SqlDbType.DateTime));
				cmd_data.Parameters["@SP_PROD_STARTDATE"].Value = dtp_date.Value;
				
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_ENDDATE", SqlDbType.DateTime));
				cmd_data.Parameters["@SP_PROD_ENDDATE"].Value = dtp_date.Value;
				
				
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_SHIPMARK", SqlDbType.NVarChar, 50));
				cmd_data.Parameters["@SP_PROD_SHIPMARK"].Value = jr_shipmark;		
				
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_JRWIDTH", SqlDbType.Float));
				//cmd_data.Parameters["@SP_JOSTOCKQTYCTN"].Value = Double.TryParse(txtbx_ctn_order.Text, out notParseDouble);
				cmd_data.Parameters["@SP_PROD_JRWIDTH"].Value = Double.Parse(txtbx_width.Text);
				
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_JRLENGTH", SqlDbType.Float));
				//cmd_data.Parameters["@SP_JOSTOCKQTYROLL"].Value = Double.TryParse(txtbx_roll_order.Text, out notParseDouble);
				cmd_data.Parameters["@SP_PROD_JRLENGTH"].Value = Double.Parse(txtbx_length.Text);
				
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_JRMICRON", SqlDbType.Float));
				cmd_data.Parameters["@SP_PROD_JRMICRON"].Value = 0;//Double.Parse(txtbx_mic.Text);
				
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_JRLOTNO", SqlDbType.NVarChar, 50));
				cmd_data.Parameters["@SP_PROD_JRLOTNO"].Value = jr_lot_no;
				
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_JRJONO", SqlDbType.NVarChar, 50));
				cmd_data.Parameters["@SP_PROD_JRJONO"].Value = jr_ref_no;
				
				
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_JRCOLOR", SqlDbType.NVarChar, 50));
				cmd_data.Parameters["@SP_PROD_JRCOLOR"].Value = jr_color;
				
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_LINE", SqlDbType.NVarChar, 50));
				cmd_data.Parameters["@SP_PROD_LINE"].Value = prod_line;
				
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_MACHINE", SqlDbType.NVarChar, 50));
				cmd_data.Parameters["@SP_PROD_MACHINE"].Value = cbx_machine.Text.ToUpper();
				
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_MACHINESPEED", SqlDbType.Float));
				cmd_data.Parameters["@SP_PROD_MACHINESPEED"].Value = 0;
					
				
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_OPERATOR", SqlDbType.NVarChar, 50));
				cmd_data.Parameters["@SP_PROD_OPERATOR"].Value = cbx_operator.Text.ToUpper();
				
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_HELPER", SqlDbType.NVarChar, 50));
				cmd_data.Parameters["@SP_PROD_HELPER"].Value = cbx_helper.Text.ToUpper();
				
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_SUPERVISOR", SqlDbType.NVarChar, 50));
				cmd_data.Parameters["@SP_PROD_SUPERVISOR"].Value = cbx_helper.Text.ToUpper();
				
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_SHIFT", SqlDbType.NVarChar, 50));
				cmd_data.Parameters["@SP_PROD_SHIFT"].Value = cbx_shift.Text.ToUpper();	
				
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_DATE", SqlDbType.DateTime));
				cmd_data.Parameters["@SP_PROD_DATE"].Value = dtp_date.Value;
							
				
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_QTYPERLOGROLL", SqlDbType.Float));
				cmd_data.Parameters["@SP_PROD_QTYPERLOGROLL"].Value = 0;
				
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_NOLOGROLL", SqlDbType.Float));
				cmd_data.Parameters["@SP_PROD_NOLOGROLL"].Value = Convert.ToDouble(txtbx_no_logroll.Text);
				
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_QTYREJECT", SqlDbType.Float));
				cmd_data.Parameters["@SP_PROD_QTYREJECT"].Value = Convert.ToDouble(txtbx_rcp.Text);
				
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_TOTALROLL", SqlDbType.Float));
				cmd_data.Parameters["@SP_PROD_TOTALROLL"].Value = Convert.ToDouble(txtbx_total_meter.Text);
				
				
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_REMARK1", SqlDbType.NVarChar, 50));
				cmd_data.Parameters["@SP_PROD_REMARK1"].Value = staff_id;
				
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_REMARK2", SqlDbType.NVarChar, 50));
				cmd_data.Parameters["@SP_PROD_REMARK2"].Value = jr_desc;
				
//					string jr_shipmark_short=null;
//					
//					if(txtbx_shipping_mark.Text.Substring(0,7).ToUpper()=="BAL-999")
//					{
//						jr_shipmark_short = "999";
//					}
//					else
//					{
//						int index = jr_shipmark.LastIndexOf("-");
//						
//						if (index > 0)
//						{
//						    jr_shipmark_short = jr_shipmark.Substring(0, index);
//							jr_shipmark_short = jr_shipmark_short.Replace("-", String.Empty);
//						}
//					}
					
				if( jr_stockcode.ToUpper().Substring(0, 2) == "WJ")
				{
					string lr = null;
					
					lr = jr_shipmark.ToUpper().Substring(0, 6) + jr_shipmark.ToUpper().Substring(jr_shipmark.Length-4);
					cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_SHIPMARKLR", SqlDbType.NVarChar, 50));
					cmd_data.Parameters["@SP_PROD_SHIPMARKLR"].Value = DateTime.Now.ToString("yyMMdd") + "-" + lr + "-" + sumLg.ToString("00");					
				}
				else
				{
					cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_SHIPMARKLR", SqlDbType.NVarChar, 50));
					cmd_data.Parameters["@SP_PROD_SHIPMARKLR"].Value = DateTime.Now.ToString("yyMMdd") + "-" + jr_shipmark + "-" + sumLg.ToString("00");
				}

//				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_SHIPMARKLR", SqlDbType.NVarChar, 50));
//				cmd_data.Parameters["@SP_PROD_SHIPMARKLR"].Value = DateTime.Now.ToString("yyMMdd") + "-" + jr_shipmark + "-" + sumLg.ToString("00");
					//DateTime.Now.Year.ToString().Substring(3,1) + DateTime.Now.ToString("MMdd") + jr_shipmark_short + prod_line + i.ToString("00");
				

									
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
				MessageBox.Show("Error - Rewinding Save \nCannot load DB" + ex.Message + ex.ToString());			
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
		
		bool sqlConnParmLRStore(string sqlStatement)
		{
			string trim_ref_no = ref_no.Substring(0, ref_no.LastIndexOf("-"));
			string line_no = trim_ref_no.Substring(trim_ref_no.IndexOf('-')+1);
			
			SqlConnection con_data = new SqlConnection(sqlconn);
			SqlCommand cmd_data = new SqlCommand();
			
			try
			{
				cmd_data.Connection = con_data;
				cmd_data.CommandText = sqlStatement;
				cmd_data.CommandType = CommandType.StoredProcedure;

				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_SONO", SqlDbType.NVarChar, 20));
				cmd_data.Parameters["@SP_PROD_SONO"].Value = ref_no.Substring(0, ref_no.IndexOf('-')).ToUpper();
				
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_SOLINENO", SqlDbType.NVarChar, 20));
				cmd_data.Parameters["@SP_PROD_SOLINENO"].Value = line_no;
				
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_DOCNO", SqlDbType.NVarChar, 50));
				cmd_data.Parameters["@SP_PROD_DOCNO"].Value = ref_no.ToUpper();
				
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_REPORTDATE", SqlDbType.DateTime));
				cmd_data.Parameters["@SP_PROD_REPORTDATE"].Value = dtp_date.Value;

				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_CODE", SqlDbType.NVarChar, 50));
				cmd_data.Parameters["@SP_PROD_CODE"].Value = txtbx_prod_code.Text.ToUpper();

				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_CUSTOMER", SqlDbType.NVarChar, 50));
				cmd_data.Parameters["@SP_PROD_CUSTOMER"].Value = "STORE";

				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_COLOR", SqlDbType.NVarChar, 50));
				cmd_data.Parameters["@SP_PROD_COLOR"].Value = txtbx_color.Text.ToUpper();

				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_BRAND", SqlDbType.NVarChar, 50));
				cmd_data.Parameters["@SP_PROD_BRAND"].Value = txtbx_brand.Text.ToUpper();

				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_WIDTH", SqlDbType.Float));
				cmd_data.Parameters["@SP_PROD_WIDTH"].Value = Double.Parse(txtbx_width_cust.Text);

				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_LENGTH ", SqlDbType.Float));
				cmd_data.Parameters["@SP_PROD_LENGTH "].Value = Double.Parse(txtbx_length_cust.Text);

				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_MICRON", SqlDbType.Float));
				cmd_data.Parameters["@SP_PROD_MICRON"].Value = Double.Parse(txtbx_mic_cust.Text);
				
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_QTYORDERED", SqlDbType.Float));
				cmd_data.Parameters["@SP_PROD_QTYORDERED"].Value = Convert.ToDouble(txtbx_total_qty_order.Text);

				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_QTYCTNORDERED", SqlDbType.Float));
				cmd_data.Parameters["@SP_PROD_QTYCTNORDERED"].Value = qty_ctn_ordered;
				
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_QTYROLLORDERED", SqlDbType.Float));
				cmd_data.Parameters["@SP_PROD_QTYROLLORDERED"].Value = qty_roll_ordered;
				
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_CONVERSION", SqlDbType.Float));
				cmd_data.Parameters["@SP_PROD_CONVERSION"].Value = Double.Parse(txtbx_conversion.Text);
			
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_ETDDATE", SqlDbType.DateTime));
				cmd_data.Parameters["@SP_PROD_ETDDATE"].Value = dtp_date.Value;
				
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_STARTDATE", SqlDbType.DateTime));
				cmd_data.Parameters["@SP_PROD_STARTDATE"].Value = dtp_date.Value;
				
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_ENDDATE", SqlDbType.DateTime));
				cmd_data.Parameters["@SP_PROD_ENDDATE"].Value = dtp_date.Value;
				
				
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_SHIPMARK", SqlDbType.NVarChar, 50));
				cmd_data.Parameters["@SP_PROD_SHIPMARK"].Value = jr_shipmark;		
				
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_JRWIDTH", SqlDbType.Float));
				//cmd_data.Parameters["@SP_JOSTOCKQTYCTN"].Value = Double.TryParse(txtbx_ctn_order.Text, out notParseDouble);
				cmd_data.Parameters["@SP_PROD_JRWIDTH"].Value = Double.Parse(txtbx_width.Text);
				
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_JRLENGTH", SqlDbType.Float));
				//cmd_data.Parameters["@SP_JOSTOCKQTYROLL"].Value = Double.TryParse(txtbx_roll_order.Text, out notParseDouble);
				cmd_data.Parameters["@SP_PROD_JRLENGTH"].Value = Double.Parse(txtbx_length.Text);
				
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_JRMICRON", SqlDbType.Float));
				cmd_data.Parameters["@SP_PROD_JRMICRON"].Value = 0;//Double.Parse(txtbx_mic.Text);
				
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_JRLOTNO", SqlDbType.NVarChar, 50));
				cmd_data.Parameters["@SP_PROD_JRLOTNO"].Value = jr_lot_no;
				
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_JRJONO", SqlDbType.NVarChar, 50));
				cmd_data.Parameters["@SP_PROD_JRJONO"].Value = jr_ref_no;
				
				
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_JRCOLOR", SqlDbType.NVarChar, 50));
				cmd_data.Parameters["@SP_PROD_JRCOLOR"].Value = jr_color;
				
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_LINE", SqlDbType.NVarChar, 50));
				cmd_data.Parameters["@SP_PROD_LINE"].Value = prod_line;
				
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_MACHINE", SqlDbType.NVarChar, 50));
				cmd_data.Parameters["@SP_PROD_MACHINE"].Value = cbx_machine.Text.ToUpper();
				
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_MACHINESPEED", SqlDbType.Float));
				cmd_data.Parameters["@SP_PROD_MACHINESPEED"].Value = 0;
					
				
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_OPERATOR", SqlDbType.NVarChar, 50));
				cmd_data.Parameters["@SP_PROD_OPERATOR"].Value = cbx_operator.Text.ToUpper();
				
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_HELPER", SqlDbType.NVarChar, 50));
				cmd_data.Parameters["@SP_PROD_HELPER"].Value = cbx_helper.Text.ToUpper();
				
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_SUPERVISOR", SqlDbType.NVarChar, 50));
				cmd_data.Parameters["@SP_PROD_SUPERVISOR"].Value = cbx_helper.Text.ToUpper();
				
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_SHIFT", SqlDbType.NVarChar, 50));
				cmd_data.Parameters["@SP_PROD_SHIFT"].Value = cbx_shift.Text.ToUpper();	
				
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_DATE", SqlDbType.DateTime));
				cmd_data.Parameters["@SP_PROD_DATE"].Value = dtp_date.Value;
							
				
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_QTYPERLOGROLL", SqlDbType.Float));
				cmd_data.Parameters["@SP_PROD_QTYPERLOGROLL"].Value = 0;
				
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_NOLOGROLL", SqlDbType.Float));
				cmd_data.Parameters["@SP_PROD_NOLOGROLL"].Value = Convert.ToDouble(txtbx_no_logroll.Text);
				
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_QTYREJECT", SqlDbType.Float));
				cmd_data.Parameters["@SP_PROD_QTYREJECT"].Value = Convert.ToDouble(txtbx_rcp.Text);
				
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_TOTALROLL", SqlDbType.Float));
				cmd_data.Parameters["@SP_PROD_TOTALROLL"].Value = Convert.ToDouble(txtbx_total_meter.Text);
				
				
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_REMARK1", SqlDbType.NVarChar, 50));
				cmd_data.Parameters["@SP_PROD_REMARK1"].Value = staff_id;
				
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_REMARK2", SqlDbType.NVarChar, 50));
				cmd_data.Parameters["@SP_PROD_REMARK2"].Value = jr_desc;
				
//					string jr_shipmark_short=null;
//					
//					if(txtbx_shipping_mark.Text.Substring(0,7).ToUpper()=="BAL-999")
//					{
//						jr_shipmark_short = "999";
//					}
//					else
//					{
//						int index = jr_shipmark.LastIndexOf("-");
//						
//						if (index > 0)
//						{
//						    jr_shipmark_short = jr_shipmark.Substring(0, index);
//							jr_shipmark_short = jr_shipmark_short.Replace("-", String.Empty);
//						}
//					}
					
	
				if( jr_stockcode.ToUpper().Substring(0, 2) == "WJ")
				{
					string lr = null;
					
					lr = jr_shipmark.ToUpper().Substring(0, 6) + jr_shipmark.ToUpper().Substring(jr_shipmark.Length-4);
					cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_SHIPMARKLR", SqlDbType.NVarChar, 50));
					cmd_data.Parameters["@SP_PROD_SHIPMARKLR"].Value = DateTime.Now.ToString("yyMMdd") + "-" + lr + "-" + sumLg.ToString("00");					
				}
				else
				{
					cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_SHIPMARKLR", SqlDbType.NVarChar, 50));
					cmd_data.Parameters["@SP_PROD_SHIPMARKLR"].Value = DateTime.Now.ToString("yyMMdd") + "-" + jr_shipmark + "-" + sumLg.ToString("00");
				}
				
//				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_SHIPMARKLR", SqlDbType.NVarChar, 50));
//				cmd_data.Parameters["@SP_PROD_SHIPMARKLR"].Value = DateTime.Now.ToString("yyMMdd") + "-" + jr_shipmark + "-" + sumLg.ToString("00");
					//DateTime.Now.Year.ToString().Substring(3,1) + DateTime.Now.ToString("MMdd") + jr_shipmark_short + prod_line + i.ToString("00");
				

									
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
				MessageBox.Show("Error - Rewinding Save \nCannot load DB" + ex.Message + ex.ToString());			
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
		
		bool sqlConnParmReject(string sqlStatement)
		{
			
			SqlConnection con_data_reject = new SqlConnection(sqlconn);
			SqlCommand cmd_data_reject = new SqlCommand();
			
			try
			{
				cmd_data_reject.Connection = con_data_reject;
				cmd_data_reject.CommandText = sqlStatement;
				cmd_data_reject.CommandType = CommandType.StoredProcedure;
									

				
				cmd_data_reject.Parameters.Add(new SqlParameter("@SP_PROD_DOCNO", SqlDbType.NVarChar, 50));
				cmd_data_reject.Parameters["@SP_PROD_DOCNO"].Value = txtbx_ref_no.Text.ToUpper();
			
				cmd_data_reject.Parameters.Add(new SqlParameter("@SP_PROD_CUSTOMER", SqlDbType.NVarChar, 50));
				cmd_data_reject.Parameters["@SP_PROD_CUSTOMER"].Value = txtbx_cust.Text.ToUpper();
					
				cmd_data_reject.Parameters.Add(new SqlParameter("@SP_PROD_MACHINE", SqlDbType.NVarChar, 50));
				cmd_data_reject.Parameters["@SP_PROD_MACHINE"].Value = cbx_machine.Text.ToUpper();
				
				cmd_data_reject.Parameters.Add(new SqlParameter("@SP_PROD_DATE", SqlDbType.DateTime));
				cmd_data_reject.Parameters["@SP_PROD_DATE"].Value = dtp_date.Value;
					
				cmd_data_reject.Parameters.Add(new SqlParameter("@SP_PROD_LINE", SqlDbType.NVarChar, 50));
				cmd_data_reject.Parameters["@SP_PROD_LINE"].Value = prod_line;
			
				
				
				
				cmd_data_reject.Parameters.Add(new SqlParameter("@SP_PROD_REJECT_RCPSETUP", SqlDbType.Float));
				cmd_data_reject.Parameters["@SP_PROD_REJECT_RCPSETUP"].Value = Double.Parse(txtbx_rcp.Text);
					
				cmd_data_reject.Parameters.Add(new SqlParameter("@SP_PROD_REJECT_LINESTOP", SqlDbType.Float));
				cmd_data_reject.Parameters["@SP_PROD_REJECT_LINESTOP"].Value = Double.Parse(txtbx_linestop.Text);
					
				cmd_data_reject.Parameters.Add(new SqlParameter("@SP_PROD_REJECT_TAPEWRINKLECOAT", SqlDbType.Float));
				cmd_data_reject.Parameters["@SP_PROD_REJECT_TAPEWRINKLECOAT"].Value = Double.Parse(txtbx_tapewrinklecoat.Text);
					
				cmd_data_reject.Parameters.Add(new SqlParameter("@SP_PROD_REJECT_TAPEWRINKLEREWIND", SqlDbType.Float));
				cmd_data_reject.Parameters["@SP_PROD_REJECT_TAPEWRINKLEREWIND"].Value = Double.Parse(txtbx_tapewrinklerewind.Text);
					
				cmd_data_reject.Parameters.Add(new SqlParameter("@SP_PROD_REJECT_LINERWRINKLE", SqlDbType.Float));
				cmd_data_reject.Parameters["@SP_PROD_REJECT_LINERWRINKLE"].Value = Double.Parse(txtbx_linerwrinkle.Text);
					
				cmd_data_reject.Parameters.Add(new SqlParameter("@SP_PROD_REJECT_BACKINGJOINT", SqlDbType.Float));
				cmd_data_reject.Parameters["@SP_PROD_REJECT_BACKINGJOINT"].Value = Double.Parse(txtbx_backjoint.Text);
					
				cmd_data_reject.Parameters.Add(new SqlParameter("@SP_PROD_REJECT_LINERJOINT", SqlDbType.Float));
				cmd_data_reject.Parameters["@SP_PROD_REJECT_LINERJOINT"].Value = Double.Parse(txtbx_linerjoint.Text);
				
		
				cmd_data_reject.Parameters.Add(new SqlParameter("@SP_PROD_REJECT_LASTLOG", SqlDbType.Float));
				cmd_data_reject.Parameters["@SP_PROD_REJECT_LASTLOG"].Value = Double.Parse(txtbx_lastlog.Text);
					
				cmd_data_reject.Parameters.Add(new SqlParameter("@SP_PROD_REJECT_LINENOGLUE", SqlDbType.Float));
				cmd_data_reject.Parameters["@SP_PROD_REJECT_LINENOGLUE"].Value = Double.Parse(txtbx_linenoglue.Text);
					
				cmd_data_reject.Parameters.Add(new SqlParameter("@SP_PROD_REJECT_EDGEPOSITIONALIGN", SqlDbType.Float));
				cmd_data_reject.Parameters["@SP_PROD_REJECT_EDGEPOSITIONALIGN"].Value = Double.Parse(txtbx_edge.Text);
					
				cmd_data_reject.Parameters.Add(new SqlParameter("@SP_PROD_REJECT_GAPPING", SqlDbType.Float));
				cmd_data_reject.Parameters["@SP_PROD_REJECT_GAPPING"].Value = Double.Parse(txtbx_gap.Text);
					
				cmd_data_reject.Parameters.Add(new SqlParameter("@SP_PROD_REJECT_DIRT", SqlDbType.Float));
				cmd_data_reject.Parameters["@SP_PROD_REJECT_DIRT"].Value = Double.Parse(txtbx_dirt.Text);
					
				cmd_data_reject.Parameters.Add(new SqlParameter("@SP_PROD_REJECT_NOGLUEALL", SqlDbType.Float));
				cmd_data_reject.Parameters["@SP_PROD_REJECT_NOGLUEALL"].Value = Double.Parse(txtbx_noglueall.Text);
				
				cmd_data_reject.Parameters.Add(new SqlParameter("@SP_PROD_REJECT_PRINTDEFECT", SqlDbType.Float));
				cmd_data_reject.Parameters["@SP_PROD_REJECT_PRINTDEFECT"].Value = Double.Parse(txtbx_printdefect.Text);
					
				cmd_data_reject.Parameters.Add(new SqlParameter("@SP_PROD_REJECT_TORN", SqlDbType.Float));
				cmd_data_reject.Parameters["@SP_PROD_REJECT_TORN"].Value = Double.Parse(txtbx_torn.Text);
					
				cmd_data_reject.Parameters.Add(new SqlParameter("@SP_PROD_REJECT_UNEVENTHICK", SqlDbType.Float));
				cmd_data_reject.Parameters["@SP_PROD_REJECT_UNEVENTHICK"].Value = Double.Parse(txtbx_uneventhick.Text);
					
				cmd_data_reject.Parameters.Add(new SqlParameter("@SP_PROD_REJECT_THICKCHECK", SqlDbType.Float));
				cmd_data_reject.Parameters["@SP_PROD_REJECT_THICKCHECK"].Value = Double.Parse(txtbx_thickcheck.Text);
					
				cmd_data_reject.Parameters.Add(new SqlParameter("@SP_PROD_REJECT_AIRTRAP", SqlDbType.Float));
				cmd_data_reject.Parameters["@SP_PROD_REJECT_AIRTRAP"].Value = Double.Parse(txtbx_airtrap.Text);
				
				cmd_data_reject.Parameters.Add(new SqlParameter("@SP_PROD_REJECT_SAMPLE", SqlDbType.Float));
				cmd_data_reject.Parameters["@SP_PROD_REJECT_SAMPLE"].Value = Double.Parse(txtbx_sample.Text);
				
				cmd_data_reject.Parameters.Add(new SqlParameter("@SP_PROD_ISSUEBY", SqlDbType.NVarChar, 50));
				cmd_data_reject.Parameters["@SP_PROD_ISSUEBY"].Value = username;
					
				cmd_data_reject.Parameters.Add(new SqlParameter("@SP_PROD_USER", SqlDbType.NVarChar, 50));
				cmd_data_reject.Parameters["@SP_PROD_USER"].Value = username;
					
				cmd_data_reject.Parameters.Add(new SqlParameter("@SP_PROD_USEREMAIL", SqlDbType.NVarChar, 50));
				cmd_data_reject.Parameters["@SP_PROD_USEREMAIL"].Value = frm_menu_system.email;
					
				cmd_data_reject.Parameters.Add(new SqlParameter("@SP_PROD_USERPC", SqlDbType.NVarChar, 50));
				cmd_data_reject.Parameters["@SP_PROD_USERPC"].Value = frm_menu_system.ipAddress;
					
				cmd_data_reject.Parameters.Add(new SqlParameter("@SP_PROD_USERDATETIME", SqlDbType.DateTime));
				cmd_data_reject.Parameters["@SP_PROD_USERDATETIME"].Value = DateTime.Now;
					
				cmd_data_reject.Parameters.Add(new SqlParameter("@SP_PROD_USERREVISION", SqlDbType.NVarChar, 50));
				cmd_data_reject.Parameters["@SP_PROD_USERREVISION"].Value = "0";
				
				con_data_reject.Open();
				cmd_data_reject.ExecuteNonQuery();		

					
			}
			catch (Exception ex) 
			{	
				con_data_reject.Close();
				MessageBox.Show("Error - Rewinding Save Reject \nCannot load DB"  + ex.Message + ex.ToString());			
				return false;
			
			} 
			finally 
			{	
				con_data_reject.Close();	
			}
			
			con_data_reject.Dispose();
			con_data_reject = null;
			cmd_data_reject = null;
			//ClearTextBox();
			//ClearAllText(this);
			return true;
		}
		
		
		bool sqlConnParmShipMark(string sqlStatement)
		{
			
			SqlConnection con_data_shipmark = new SqlConnection(sqlconn);
			SqlCommand cmd_data_shipmark  = new SqlCommand();
			
			try
			{
				cmd_data_shipmark.Connection = con_data_shipmark;
				cmd_data_shipmark.CommandText = sqlStatement;
				cmd_data_shipmark.CommandType = CommandType.StoredProcedure;
					
				cmd_data_shipmark.Parameters.Add(new SqlParameter("@SP_PROD_JONO", SqlDbType.NVarChar, 50));
				cmd_data_shipmark.Parameters["@SP_PROD_JONO"].Value = txtbx_ref_no.Text.ToUpper();
					
				cmd_data_shipmark.Parameters.Add(new SqlParameter("@SP_PROD_LINENO", SqlDbType.Int));
				cmd_data_shipmark.Parameters["@SP_PROD_LINENO"].Value = Int32.Parse(prod_line);
					
	
					
				cmd_data_shipmark.Parameters.Add(new SqlParameter("@SP_PROD_WIDTH", SqlDbType.Float));
				cmd_data_shipmark.Parameters["@SP_PROD_WIDTH"].Value = Double.Parse(txtbx_width.Text);

				cmd_data_shipmark.Parameters.Add(new SqlParameter("@SP_PROD_LENGTH ", SqlDbType.Float));
				cmd_data_shipmark.Parameters["@SP_PROD_LENGTH "].Value = shipmark_ori_length;

				cmd_data_shipmark.Parameters.Add(new SqlParameter("@SP_PROD_MICRON", SqlDbType.Float));
				cmd_data_shipmark.Parameters["@SP_PROD_MICRON"].Value = 0; //Double.Parse(txtbx_mic.Text);
						
					
					
				cmd_data_shipmark.Parameters.Add(new SqlParameter("@SP_PROD_STOCKCODE", SqlDbType.NVarChar, 50));
				cmd_data_shipmark.Parameters["@SP_PROD_STOCKCODE"].Value = jr_stockcode;	
					
				cmd_data_shipmark.Parameters.Add(new SqlParameter("@SP_PROD_COLOR", SqlDbType.NVarChar, 50));
				cmd_data_shipmark.Parameters["@SP_PROD_COLOR"].Value = jr_color;	
					
				cmd_data_shipmark.Parameters.Add(new SqlParameter("@SP_PROD_BRAND", SqlDbType.NVarChar, 50));
				cmd_data_shipmark.Parameters["@SP_PROD_BRAND"].Value = txtbx_brand.Text;	
					
				cmd_data_shipmark.Parameters.Add(new SqlParameter("@SP_PROD_LOTNO", SqlDbType.NVarChar, 50));
				cmd_data_shipmark.Parameters["@SP_PROD_LOTNO"].Value = jr_lot_no;	
					
				cmd_data_shipmark.Parameters.Add(new SqlParameter("@SP_PROD_JRSHIPMARK", SqlDbType.NVarChar, 50));
				cmd_data_shipmark.Parameters["@SP_PROD_JRSHIPMARK"].Value = jr_shipmark;	
					
				cmd_data_shipmark.Parameters.Add(new SqlParameter("@SP_PROD_JRBARCODE", SqlDbType.NVarChar, 50));
				cmd_data_shipmark.Parameters["@SP_PROD_JRBARCODE"].Value = jr_barcode;	
					
					
					
					
				cmd_data_shipmark.Parameters.Add(new SqlParameter("@SP_PROD_CONSUME", SqlDbType.Float));
				cmd_data_shipmark.Parameters["@SP_PROD_CONSUME"].Value = Double.Parse(txtbx_total_meter.Text);

				cmd_data_shipmark.Parameters.Add(new SqlParameter("@SP_PROD_BALANCE", SqlDbType.Float));
				cmd_data_shipmark.Parameters["@SP_PROD_BALANCE"].Value = 0;
					
					
	
				
										
				cmd_data_shipmark.Parameters.Add(new SqlParameter("@SP_PROD_ISSUEBY", SqlDbType.NVarChar, 50));
				cmd_data_shipmark.Parameters["@SP_PROD_ISSUEBY"].Value = username;
					
				cmd_data_shipmark.Parameters.Add(new SqlParameter("@SP_PROD_USER", SqlDbType.NVarChar, 50));
				cmd_data_shipmark.Parameters["@SP_PROD_USER"].Value = username;
					
				cmd_data_shipmark.Parameters.Add(new SqlParameter("@SP_PROD_USEREMAIL", SqlDbType.NVarChar, 50));
				cmd_data_shipmark.Parameters["@SP_PROD_USEREMAIL"].Value = frm_menu_system.email;
					
				cmd_data_shipmark.Parameters.Add(new SqlParameter("@SP_PROD_USERPC", SqlDbType.NVarChar, 50));
				cmd_data_shipmark.Parameters["@SP_PROD_USERPC"].Value = frm_menu_system.ipAddress;
					
				cmd_data_shipmark.Parameters.Add(new SqlParameter("@SP_PROD_USERDATETIME", SqlDbType.DateTime));
				cmd_data_shipmark.Parameters["@SP_PROD_USERDATETIME"].Value = DateTime.Now;
					
				cmd_data_shipmark.Parameters.Add(new SqlParameter("@SP_PROD_USERREVISION", SqlDbType.NVarChar, 50));
				cmd_data_shipmark.Parameters["@SP_PROD_USERREVISION"].Value = "0";

				con_data_shipmark.Open();
				cmd_data_shipmark.ExecuteNonQuery();				
					
			} 
			catch (Exception ex) 
			{	
				con_data_shipmark.Close();
				MessageBox.Show("Error - Rewinding Save \nCannot load DB" + ex.Message + ex.ToString());			
				return false;
			} 
			finally 
			{
				con_data_shipmark.Close();
			}
			
			con_data_shipmark.Dispose();
			con_data_shipmark = null;
			cmd_data_shipmark = null;
			return true;
			
		}
		
		
		
		void Btn_delClick(object sender, EventArgs e)
		{
			if (!Validation())
                return;
			
			SqlConnection con_check = new SqlConnection(sqlconn);
			SqlCommand cmd_check = new SqlCommand();
			
			try 
			{
				cmd_check.CommandText = @"select * from TBL_PROD_CONV_JO_PACKING where PROD_DOCNO = @doc_no";
				cmd_check.Parameters.AddWithValue("@doc_no",  txtbx_ref_no.Text);
				
				cmd_check.Connection = con_check;
				con_check.Open();
				SqlDataReader rd_check = cmd_check.ExecuteReader(System.Data.CommandBehavior.CloseConnection);

				if (rd_check.HasRows)
				{
					if (rd_check.Read())
					{
						MessageBox.Show("Cannot delete. Packing already has been made. \nDelete Packing first if you want to delete this.");
						return;
					}

				}
			}
			catch (Exception ex)
			{
				con_check.Close();
				MessageBox.Show("Error - Rewinding Check \n" + ex.Message + ex.ToString());
				return;
			} 
			finally 
			{
				con_check.Close();
			}
			
			con_check.Dispose();
			cmd_check.Dispose();
			con_check = null;
			cmd_check = null;
			
			
			DialogResult del = new DialogResult();
            del = MessageBox.Show("Are you sure you want to delete it?", "Delete", 
                     MessageBoxButtons.YesNo, 
                     MessageBoxIcon.Warning, 
                     MessageBoxDefaultButton.Button2);
            if (del == DialogResult.Yes)
            {

				if (this.dt_grid.SelectedRows.Count > 0)
			    {
					//RejectCalculation();
					Reject();
					
			       	if(sqlConnParm("SP_PROD_CONV_JO_REWINDING_DEL") && sqlConnParmReject("SP_PROD_CONV_JO_REWINDING_REJECT_DEL"))
	            	{
			       		UpdateBal("SP_PROD_CONV_UPDATE_DEL");
			       		dt_grid.Rows.RemoveAt(this.dt_grid.SelectedRows[0].Index);
						//MessageBox.Show("The data has been deleted");
						DialogBox.ShowDeleteSuccessDialog();
	            	}
							
			    }
				
				ClearAllText(this);	
				btn_del.Enabled = false;
				btn_save.Enabled = true;
            }
		}
		
		void Btn_checkClick(object sender, EventArgs e)
		{
			if(String.IsNullOrWhiteSpace(txtbx_shipping_mark.Text))
			{
				MessageBox.Show("Key in Shipping Mark first");
				txtbx_shipping_mark.Focus();
				return;
			}
			
			jr_shipmark 	= string.Empty;
			jr_lot_no 		= string.Empty;
			jr_ref_no 		= string.Empty;
			txtbx_mic.Text 	= string.Empty;
			jr_color 		= string.Empty;
			jr_barcode 		= string.Empty;
			jr_stockcode 	= string.Empty;
			jr_micron 		= string.Empty;
			jr_width 		= string.Empty;
			jr_length 		= string.Empty;
			jr_desc			= string.Empty;
				
			txtbx_width.Text 	= string.Empty;
			shipmark_ori_length = 0;
			txtbx_length.Text 	= string.Empty;

			SqlConnection con_Check_Duplicate_JO = new SqlConnection(sqlconn);
			SqlCommand cmd_Check_Duplicate_JO = new SqlCommand();
				
			try 
			{
				cmd_Check_Duplicate_JO.CommandText = @"select sum(PROD_NOLOGROLL) as lgNo from TBL_PROD_CONV_JO_REWINDING where PROD_SHIPMARK = @ship_mark group by PROD_SHIPMARK";// + "' and JODOCNO <> 'SMSO124608'";
				cmd_Check_Duplicate_JO.Parameters.AddWithValue("@ship_mark",  txtbx_shipping_mark.Text.ToUpper());
					
				cmd_Check_Duplicate_JO.Connection = con_Check_Duplicate_JO;
				con_Check_Duplicate_JO.Open();
				SqlDataReader rd_Check_Duplicate_JO = cmd_Check_Duplicate_JO.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
	
				if (rd_Check_Duplicate_JO.HasRows)
				{
					if (rd_Check_Duplicate_JO.Read())
					{
						//isDuplicate = true;
						shipmark_bal = Convert.ToInt32(rd_Check_Duplicate_JO["PROD_BALANCE"]);
						//txtbx_width.Text = Convert.ToInt32(rd_Check_Duplicate_JO["PROD_WIDTH"]);
						
						if (shipmark_bal != 0)
						{
							jrExist = true;
							sumLg = Convert.ToInt32(rd_Check_Duplicate_JO["lgNo"]) + 1;
						}
						else
						{
							jr_length = (shipmark_bal*1000/Convert.ToDouble(txtbx_width.Text)).ToString();
						}
						//MessageBox.Show("Shipping Mark already used");
						//return;
						
					}
				}
				else
				{
					sumLg = 1;
					jr_length = "0";
				}
			}
			catch (Exception ex)
			{
				con_Check_Duplicate_JO.Close();
				MessageBox.Show("Error - Converting Slitting Shipping Mark Duplicate " + ex.Message + ex.ToString());
				return;
			} 
			finally 
			{
				con_Check_Duplicate_JO.Close();
			}
				
			con_Check_Duplicate_JO.Dispose();
			cmd_Check_Duplicate_JO.Dispose();
			con_Check_Duplicate_JO = null;
			cmd_Check_Duplicate_JO = null;
	        	
			
			
			SqlConnection con = new SqlConnection(sqlconnStaging);
			SqlCommand cmd = new SqlCommand();
				
			try 
			{
				
				cmd.CommandText = "select top 1 a.*, b.DOT_DESCRIPTION from VIEW_AXERP_PDSBATCHATTRIBUTES_FULLINFO a inner join VIEW_AXERP_ITEM_MASTER b " +
					"on a.itemid = b.itemid " +
					"where INVENTBATCHID = @ship_mark or grade = @ship_mark";
				cmd.Parameters.AddWithValue("@ship_mark",  txtbx_shipping_mark.Text.ToUpper()); //INVENTBATCHID like @ship_mark + '%'
				cmd.Connection = con;
				con.Open();
				SqlDataReader rd = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
					
				if (rd.HasRows)
				{
					while (rd.Read())
					{	
	//					checkButton = true;
	//					btn_del.Visible = false;
	//			        btn_save.Visible = true;
	//					//btn_clear.Visible = true;
	//					//btn_cancel.Visible = true;
	//			        //btn_del.Location = new Point(416, 1348);
	//			        grpbox_output.Visible = true;
	//					grpbox_cust.Visible = true;
	//			        btn_save.Location = new Point(306, 912);
	//			        btn_clear.Location = new Point(432, 912);
	//			        btn_cancel.Location = new Point(558, 912);	
				        	
						jr_shipmark = rd["INVENTBATCHID"].ToString();
						jr_lot_no = rd["LOTNO"].ToString();
						jr_ref_no = rd["Grade"].ToString();
						jr_micron = rd["Micron"].ToString();
						jr_color = rd["Color"].ToString();
						jr_barcode = rd["SHIPMARK"].ToString();
						jr_stockcode = rd["ITEMID"].ToString();
							
						jr_width = rd["Width"].ToString();
						shipmark_ori_length = Convert.ToInt32(rd["LLength"]);
						
						if(jr_length == "0")
						{
							jr_length = rd["LLength"].ToString();
						}
						
						
						if(jr_stockcode.ToUpper().Substring(0, 4) == "WJ303" || jr_stockcode.ToUpper().Substring(0, 4) == "WJ305" || jr_stockcode.ToUpper().Substring(0, 4) == "WJRA70")
						{
							jr_desc = rd["DOT_DESCRIPTION"].ToString().Substring(0, 15);
						}
						else //if(jr_stockcode.ToUpper().Substring(0, 4) = "WJ303")
						{
							jr_desc = rd["DOT_DESCRIPTION"].ToString().Substring(0, 29);
						}
						
															
					} 
				}
				else 
				{
					MessageBox.Show("Error 1 - Rewinding Check \nCannot find shipping mark!");
					return;
				}
			} 
			catch (Exception ex) 
			{
				MessageBox.Show("Error 2 - Rewinding Check \nCannot load DB!" + ex.Message + ex.ToString());
				return;
			} 
			finally 
			{
				con.Close();
			}
				
			con.Dispose();
			con = null;
			cmd = null;
				
			if (!CheckQty())
			{
				jr_shipmark 	= string.Empty;
				jr_lot_no 		= string.Empty;
				jr_ref_no 		= string.Empty;
				txtbx_mic.Text 	= string.Empty;
				jr_color 		= string.Empty;
				jr_barcode 		= string.Empty;
				jr_stockcode 	= string.Empty;
				jr_micron 		= string.Empty;
				jr_width 		= string.Empty;
				jr_length 		= string.Empty;
				jr_desc			= string.Empty;
					
				txtbx_width.Text 	= string.Empty;
				shipmark_ori_length = 0;
				txtbx_length.Text 	= string.Empty;
				return;
			}
			else
			{
				txtbx_mic.Text = jr_micron;
				txtbx_width.Text = jr_width;
				txtbx_length.Text = jr_length;						
			}
			
//				if(!String.IsNullOrEmpty(txtbx_length_cust.Text))
//				{			
//					txtbx_no_logroll.Text = ((int)Math.Floor(Double.Parse(txtbx_length.Text)/Double.Parse(txtbx_length_cust.Text))).ToString();
//				}
				
//				if(!String.IsNullOrEmpty(txtbx_length_cust.Text))
//				{
//					txtbx_no_logroll.Text = ((int)Math.Floor(Double.Parse(txtbx_length.Text)/Double.Parse(txtbx_length_cust.Text))).ToString();
//				}
				
				TotalMeterCalculation();
				//isDuplicate = false;
			
			
			
		}
		
		bool CheckQty()
		{
			double sumQty = 0;
			
			SqlConnection con = new SqlConnection(sqlconnStaging);
			SqlCommand cmd = new SqlCommand();
				
			try 
			{
				
				//cmd.CommandText = "select * from VIEW_AXERP_INVENT_TRANSACTION where itemid = @stock_code and inventbatchid = @ship_mark";
				cmd.CommandText = "select TOP 1 * from VIEW_AXERP_QOH_PM04 where inventbatchid = @ship_mark";
				
				//cmd.Parameters.AddWithValue("@stock_code",  jr_stockcode);
				cmd.Parameters.AddWithValue("@ship_mark",  jr_shipmark);
				cmd.Connection = con;
				con.Open();
				SqlDataReader rd = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
				
				if(rd.HasRows)
				{
					//while (rd.HasRows)
					//{
						while (rd.Read())
						{	
							double  get_qty, qty_realmetre;
							//string qty_realmetre;
							qty_realmetre = Convert.ToDouble(rd["AVAILPHYSICAL"].ToString());
							
							
							//txtbx_wtglue.Text = Convert.ToString(Math.Round(((Convert.ToDouble(txtbx_gluemicron.Text) * 1.05 * (double) Convert.ToDouble(txtbx_gluewidth.Text) / 1000 *  Convert.ToDouble(txtbx_jrlength.Text) / 1000)),2));
							get_qty = qty_realmetre / Convert.ToDouble(jr_width) * 1000;
							txtbx_length.Text = get_qty.ToString();
							//sumQty = sumQty + Convert.ToDouble(rd["QTY"].ToString());
						    
							//jr_shipmark = rd["INVENTBATCHID"].ToString();											
						}
						
						//txtbx_length.Text = sumQty.ToString();
					//}
				}
				else
				{
					MessageBox.Show("Qty for shipping mark is zero!");
					return false;
				}
				
				
			} 
			catch (Exception ex) 
			{
				MessageBox.Show("Error - Slitting Check \nCannot load DB!" + ex.Message + ex.ToString());
				return false;
			} 
			finally 
			{
				con.Close();
			}
				
			con.Dispose();
			con = null;
			cmd = null;
			return true;
		}
		
		string Batch(string id)
		{
			SqlConnection con2 = new SqlConnection(sqlconnStaging);
			SqlCommand cmd2 = new SqlCommand();
				
			try
			{
				cmd2.CommandText = "select PDSBATCHATTRIBVALUE from VIEW_AXERP_PDSBATCHATTRIBUTES where INVENTBATCHID = '" + jr_shipmark + "' and PDSBATCHATTRIBID = '" + id  + "'";
				cmd2.Parameters.AddWithValue("@ship_mark",  txtbx_shipping_mark.Text.ToUpper());
						
						
				cmd2.Connection = con2;
				con2.Open();
				SqlDataReader rd2 = cmd2.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
						
				if (rd2.HasRows)
				{
					while (rd2.Read())
					{								
						batchValue = rd2["PDSBATCHATTRIBVALUE"].ToString();													
					} 
				}
				else 
				{
					MessageBox.Show("Error - Slitting Check \nCannot find shipping_mark!");
					//return "false";
				}
			} 
			catch (Exception ex) 
			{
				MessageBox.Show("Error - Slitting Check \nCannot load DB!" + ex.Message + ex.ToString());
				//return "false";
			} 
			finally 
			{
				con2.Close();
			}
			
			return batchValue;			
			con2.Dispose();
			con2 = null;
			cmd2 = null;
		}
		
		void Dt_gridCellClick(object sender, DataGridViewCellEventArgs e)
		{
			if(dt_grid.SelectedRows.Count > 0) // make sure user select at least 1 row 
			{
				
			   	ref_no = dt_grid.SelectedRows[0].Cells[0].Value + string.Empty;
			   	txtbx_ref_no.Text = ref_no;
			   	line_no = dt_grid.SelectedRows[0].Cells[1].Value + string.Empty;
			   	retrieve();
			   	//btn_del.Enabled = true;
			   	btn_save.Enabled = false;
			   	//ReadOnlyTxtbx(this);
			   	//txtbx_ref_no.ReadOnly = false;
			   	EnableAllControls(this);
			   	btn_del.Enabled = false;
			   	
			   	if(username.ToUpper() == "ADMIN")
				{
					btn_del.Enabled = true;
				}
			}
 
		}
		
		
//		void ReadOnlyTxtbx(Control con)
//		{
//    		foreach (Control c in con.Controls)
//    		{
//      			if (c is TextBox)
//        			((TextBox)c).ReadOnly = true;
//      			else
//      				ReadOnlyTxtbx(c);
//    		}
//		}
		
		//void Btn_retrieveClick(object sender, EventArgs e)
		void retrieve()
		{
			
			SqlConnection con_SP1 = new SqlConnection(sqlconn);
			SqlCommand cmd_SP1 = new SqlCommand();
				
			try 
			{
				cmd_SP1.CommandText = @"SELECT * FROM TBL_PROD_CONV_JO_REWINDING where PROD_DOCNO = @doc_no and PROD_LINE = @line_no";
				cmd_SP1.Parameters.AddWithValue("@doc_no",  txtbx_ref_no.Text);
        		cmd_SP1.Parameters.AddWithValue("@line_no",  line_no);
				cmd_SP1.Connection = con_SP1;
				con_SP1.Open();
				SqlDataReader rd_SP1 = cmd_SP1.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
				if (rd_SP1.HasRows)
				{
					while (rd_SP1.Read())
					{				        	
						txtbx_cust.Text = rd_SP1["PROD_CUSTOMER"].ToString();
						txtbx_prod_code.Text = rd_SP1["PROD_CODE"].ToString();
						txtbx_color.Text = rd_SP1["PROD_COLOR"].ToString();
						txtbx_brand.Text = rd_SP1["PROD_BRAND"].ToString();
						txtbx_length_cust.Text = rd_SP1["PROD_LENGTH"].ToString();
						txtbx_width_cust.Text = rd_SP1["PROD_WIDTH"].ToString();
						txtbx_mic_cust.Text = rd_SP1["PROD_MICRON"].ToString();
						txtbx_conversion.Text = rd_SP1["PROD_CONVERSION"].ToString();
						txtbx_shipping_mark.Text = rd_SP1["PROD_SHIPMARK"].ToString();
						txtbx_width.Text = rd_SP1["PROD_JRWIDTH"].ToString();
						txtbx_length.Text = rd_SP1["PROD_JRLENGTH"].ToString();
						txtbx_mic.Text = rd_SP1["PROD_JRMICRON"].ToString();
						jr_lot_no = rd_SP1["PROD_JRLOTNO"].ToString();
						jr_ref_no = rd_SP1["PROD_JRJONO"].ToString();
						jr_color = rd_SP1["PROD_JRCOLOR"].ToString();
						prod_line = rd_SP1["PROD_LINE"].ToString();
						
						
						cbx_machine.Text = rd_SP1["PROD_MACHINE"].ToString();
						cbx_shift.Text = rd_SP1["PROD_SHIFT"].ToString();
						txtbx_no_logroll.Text = rd_SP1["PROD_QTYPERLOGROLL"].ToString();

						txtbx_total_qty_order.Text = rd_SP1["PROD_QTYORDERED"].ToString();
						
					} 	
				}
				else 
				{
					MessageBox.Show("Error - Rewinding Retrieve \nCannot find JO!");
					return;
				}
			} 
			catch (Exception ex) 
			{
				MessageBox.Show("Error - Rewinding Retrieve \nCannot retrieve DB!" + ex.Message + ex.ToString());
				return;
			} 
			finally 
			{
				con_SP1.Close();
			}
				
			con_SP1.Dispose();
			con_SP1 = null;
			cmd_SP1 = null;		
			
			
			SqlConnection con_SP2 = new SqlConnection(sqlconn);
			SqlCommand cmd_SP2 = new SqlCommand();
				
			try 
			{
				cmd_SP2.CommandText = @"SELECT * FROM TBL_PROD_CONV_JO_REWINDING_REJECT where PROD_DOCNO = @doc_no and PROD_LINE = @line_no";
				cmd_SP2.Parameters.AddWithValue("@doc_no",  txtbx_ref_no.Text);
        		cmd_SP2.Parameters.AddWithValue("@line_no",  line_no);
				cmd_SP2.Connection = con_SP2;
				con_SP2.Open();
				SqlDataReader rd_SP2 = cmd_SP2.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
				
				if(rd_SP2.HasRows)
				{
					while (rd_SP2.Read())
					{				        	
						txtbx_rcp.Text = rd_SP2["PROD_REJECT_SHRINKAGE"].ToString();
						
					}
				} 
				else 
				{
					MessageBox.Show("Error - Rewinding Retrieve Reject \nCannot read DB!");
					return;
				}
			} 
			catch (Exception ex) 
			{
				MessageBox.Show("Error - Rewinding Retrieve Reject \nCannot load DB!" + ex.Message + ex.ToString());
				return;
			} 
			finally 
			{
				con_SP2.Close();
			}
				
			con_SP2.Dispose();
			con_SP2 = null;
			cmd_SP2 = null;	
			
			SqlConnection con_SP3 = new SqlConnection(sqlconn);
			SqlCommand cmd_SP3 = new SqlCommand();
			
			try 
			{
				cmd_SP3.CommandText = @"select * from TBL_PROD_CONV_JO where JODOCNO = @doc_no";
				cmd_SP3.Parameters.AddWithValue("@doc_no",  txtbx_ref_no.Text.ToUpper());
				cmd_SP3.Connection = con_SP3;
				con_SP3.Open();
				SqlDataReader rd_SP3 = cmd_SP3.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
				
				if (rd_SP3.Read())
				{	
					txtbx_total_qty_balance.Text = rd_SP3["JOPRODQTYBAL"].ToString();
					bal = Convert.ToDouble(rd_SP3["JOPRODQTYBAL"]);	
				} 
				else 
				{
					MessageBox.Show("Error - Rewinding Retrieve \nCannot find JO!");
					return;
				}
			} 
			catch (Exception ex) 
			{
				MessageBox.Show("Error - Rewinding Retrieve \nCannot load DB!" + ex.Message + ex.ToString());
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
           
		void Dt_gridDataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
		{
			dt_grid.ClearSelection();
		}	

		
		
		void Txtbx_ref_noKeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode == Keys.Enter)
			{
				if (txtbx_ref_no.Text.Substring(0, 4) == "GFSO" || txtbx_ref_no.Text.Substring(0, 4) == "SWSO" || txtbx_ref_no.Text.Substring(0, 5) == "STORE" || txtbx_ref_no.Text.Substring(0, 4) == "SBSD")
				     Search();
			}
			else return;
		}
		
		void Txtbx_lengthTextChanged(object sender, EventArgs e)
		{
			if(!String.IsNullOrWhiteSpace(txtbx_length.Text))
			{
				txtbx_total_m.Text = ((int)(Convert.ToDouble(txtbx_extra.Text) + Convert.ToDouble(txtbx_length.Text))).ToString();
			
//				if(!String.IsNullOrEmpty(txtbx_length_cust.Text))
//				{						
//					txtbx_no_logroll.Text = (Int32.Parse(txtbx_length.Text)/Int32.Parse(txtbx_length_cust.Text)).ToString();
//				}
//				else
//				{
//					//txtbx_length.Text = "0";
//					return;
//				}
			}  
			else 
			{
				//txtbx_length.Text = "0";
				return;
			}
				
			
		}
		
		void Txtbx_extraTextChanged(object sender, EventArgs e)
		{
			if(!String.IsNullOrWhiteSpace(txtbx_extra.Text))
			{
				if(!String.IsNullOrEmpty(txtbx_length.Text))
				{
			   		txtbx_total_m.Text = (Convert.ToDouble(txtbx_extra.Text) + Convert.ToDouble(txtbx_length.Text)).ToString();
				}
				else
					return;
				
				if(!String.IsNullOrEmpty(txtbx_length_cust.Text))
				{						
					txtbx_no_logroll.Text = ((int)Math.Floor((Double.Parse(txtbx_length.Text) + Double.Parse(txtbx_extra.Text))/(int)Double.Parse(txtbx_length_cust.Text))).ToString();
					TotalMeterCalculation();
				}
				else
				{
					//txtbx_extra.Text = "0";
					return;
				}
			}  
			else
			{
				//txtbx_extra.Text = "0";
				return;
			}
		}

		
//		bool QtyLRCheck()
//		{
//			int qty_logroll = 0;
//
//			qty_logroll	= ((int)Math.Floor(Double.Parse(txtbx_width.Text)/Double.Parse(txtbx_width_cust.Text)));
//			
//			if(Int32.Parse(txtbx_qty_logroll.Text) <= qty_logroll && Int32.Parse(txtbx_qty_logroll.Text) >= (qty_logroll - 10))
//			{
//				return true;
//			}
//			else
//				return false;
//		}
		
//		
		bool NoLRCheck()
		{
			if((Int32.Parse(txtbx_no_logroll.Text) + Int32.Parse(txtbx_no_logroll_store.Text)) > (Double.Parse(txtbx_total_m.Text)/Double.Parse(txtbx_length_cust.Text)))
			{
				return false;
			}
			else
				return true;
		}
		
		void TotalMeterCalculation()
		{
			txtbx_total_meter.Text = (((Int32.Parse(txtbx_no_logroll.Text) + Int32.Parse(txtbx_no_logroll_store.Text) - 1) * Int32.Parse(txtbx_length_cust.Text) + Int32.Parse(txtbx_last_lr.Text) ).ToString()) ; 
		}
		
		
		void EnterNumberOnly(KeyPressEventArgs e)
		{
			if (!(Char.IsDigit(e.KeyChar) || (e.KeyChar == (char)Keys.Back)))
		     {
		          e.Handled = true;
		          MessageBox.Show("Key in number only");
		     }
		}
		void Txtbx_lengthKeyPress(object sender, KeyPressEventArgs e)
		{
			EnterNumberOnly(e);
		}
		
		void Txtbx_extraKeyPress(object sender, KeyPressEventArgs e)
		{
			EnterNumberOnly(e);
		}		
		
		void Txtbx_qty_logrollKeyPress(object sender, KeyPressEventArgs e)
		{
			EnterNumberOnly(e);
		}
		
		void Txtbx_no_logrollKeyPress(object sender, KeyPressEventArgs e)
		{
			EnterNumberOnly(e);
		}
		
	
				
		void Btn_reportClick(object sender, EventArgs e)
		{
			this.Hide();
			using(frm_rpt_converting_rewind_detail frm_conv_prod_detail = new frm_rpt_converting_rewind_detail())
				frm_conv_prod_detail.ShowDialog();
			this.Show();			
		}
		
	
		
		void Reject()
		{
			shrinkage = 0;
			print_align = 0;
			telescope = 0;
			uneven_thk = 0;
			wrinkle = 0;
			bubble = 0;
			core_dented = 0;
			core_label = 0;
			dirt = 0;
			edge = 0;
			fish_eye = 0;
			glue = 0;
			init_wind = 0;		
			tape_cut = 0;
			tape_end = 0;
			tape_line = 0;
			wave = 0;
			film = 0;
			
//			if(cbx_reject.Text == "SHRINKAGE")
//				shrinkage = Double.Parse(txtbx_bal_m.Text);
//			
//			else if(cbx_reject.Text == "WRINKLE")
//				wrinkle = Double.Parse(txtbx_bal_m.Text);
//			
//			else if(cbx_reject.Text == "UNEVEN THICKNESS")
//				uneven_thk = Double.Parse(txtbx_bal_m.Text);
//			
//			else if(cbx_reject.Text == "TELESCOPE")
//				telescope = Double.Parse(txtbx_bal_m.Text);
//			
//			else if(cbx_reject.Text == "PRINTING ALIGNMENT")
//				print_align = Double.Parse(txtbx_bal_m.Text);
//			
//			else if(cbx_reject.Text == "FILM BREAK")
//				film = Double.Parse(txtbx_bal_m.Text);
//			
//			else if(cbx_reject.Text == "DIRT")
//				dirt = Double.Parse(txtbx_bal_m.Text);
//			
//			else if(cbx_reject.Text == "CORE LABEL LIFT")
//				core_label = Double.Parse(txtbx_bal_m.Text);
//			
//			else if(cbx_reject.Text == "BUBBLE")
//				bubble = Double.Parse(txtbx_bal_m.Text);
//			
//			else if(cbx_reject.Text == "TAPE LINE")
//				tape_line = Double.Parse(txtbx_bal_m.Text);
//			
//			else if(cbx_reject.Text == "INITIAL WINDING")
//				init_wind = Double.Parse(txtbx_bal_m.Text);
//			
//			else if(cbx_reject.Text == "EDGE ALIGNMENT")
//				edge = Double.Parse(txtbx_bal_m.Text);
//			
//			else if(cbx_reject.Text == "GLUE TRANSFER/ GLUE NOT DRY")
//				glue = Double.Parse(txtbx_bal_m.Text);
//			
//			else if(cbx_reject.Text == "WAVE")
//				wave = Double.Parse(txtbx_bal_m.Text);
//			
//			else if(cbx_reject.Text == "TAPE END INSIDE")
//				tape_end = Double.Parse(txtbx_bal_m.Text);
//			
//			else if(cbx_reject.Text == "FISH EYE")
//				fish_eye = Double.Parse(txtbx_bal_m.Text);
//			
//			else if(cbx_reject.Text == "CORE DENTED")
//				core_dented = Double.Parse(txtbx_bal_m.Text);
//			
//			else if(cbx_reject.Text == "TAPE CUT")
//				tape_cut = Double.Parse(txtbx_bal_m.Text);
			
			
			
		}
		
		void Txtbx_no_logrollTextChanged(object sender, EventArgs e)
		{
			if(String.IsNullOrWhiteSpace(txtbx_no_logroll.Text) || String.IsNullOrWhiteSpace(txtbx_no_logroll_store.Text) || String.IsNullOrWhiteSpace(txtbx_length.Text))
				return;
			
			else
			{
				TotalMeterCalculation();
				//txtbx_bal_m.Text = Convert.ToString(Double.Parse(txtbx_length.Text) - Double.Parse(txtbx_total_meter.Text));
			}
			
		}
		
		void Print()
		{
			using(Form frm = new Form())
			{
	        	frm.Height = 500;
	        	frm.Width = 600;
				frm.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;				
				
				var reportViewer1 = new ReportViewer();
				
				try
				{
					reportViewer1.Reset();
					reportViewer1.Visible = true;
					reportViewer1.ProcessingMode = ProcessingMode.Local;
					reportViewer1.LocalReport.ReportPath = @"..\..\report\PROD_CONV_REWIND_LABEL_3.rdl";
					DataSet ds = new DataSet();
					//DataSet ds2 = new DataSet();
					ds = GetData();
					//ds2 = GetData2();
					
					if (ds.Tables[0].Rows.Count > 0)
					{
					
						//reportViewer1.LocalReport.DataSources.Clear();
						ReportDataSource rds = new ReportDataSource("DataSet1", ds.Tables[0]);
						//ReportDataSource rds2 = new ReportDataSource("DataSet2", ds2.Tables[0]);					
						
						ReportParameter[] parameters = new ReportParameter[1];
						parameters[0] = new ReportParameter("prod_line", prod_line);
						//parameters[1] = new ReportParameter("to_date", date_to.ToString("yyyy-MM-dd"));
				    
						//this.reportViewer1.RefreshReport(); 
						//reportViewer1.LocalReport.DataSources.Clear();					
//						ReportParameter p1 = new ReportParameter("@from_date", date_fr);
//    					ReportParameter p2 = new ReportParameter("@to_date", _p2);
//						
//						reportViewer1.LocalReport.SetParameters(

						reportViewer1.LocalReport.DataSources.Add(rds);
						reportViewer1.LocalReport.SetParameters(parameters);
						//reportViewer1.LocalReport.DataSources.Add(rds2);
						
						reportViewer1.LocalReport.Refresh();
						reportViewer1.RefreshReport();
						
						reportViewer1.Dock = DockStyle.Fill;
						
						// myPageSettings = new ReportPageSettings();
				        //myPageSettings.Margins = new Margin(0, 0, 0 , 0);
//				        Dim paperSize As PaperSize = New PaperSize()
//				        'ToDo: update with the PaperKind 
//				        'that your printer uses
//				        paperSize.RawKind = PaperKind.A4
//				        ' paperSize.RawKind = System.Drawing.Printing.PaperKind.A4
//				        myPageSettings.PaperSize = paperSize
//				        'False for "Portrait"
//				        'True for "Landscape"
				       // myPageSettings.Landscape = False;
				
				        //reportViewer1.SetPageSettings(myPageSettings);
						//reportViewer1.PrinterSettings.
						//reportViewer1.PrinterSettings.Copies = short.Parse(txtbx_no_logroll.Text);
	        			frm.Controls.Add(reportViewer1);

        				frm.ShowDialog(this);
					}				
				}
				catch(Exception ex)
				{
					MessageBox.Show(ex.Message + ex.ToString());// + ex.InnerException.Message);
					//return false;
				}
			}
		}
		
		private DataSet GetData()
		{
			SqlConnection conn = new SqlConnection(sqlconn);
			
			SqlCommand cmd = new SqlCommand("SELECT * FROM TBL_PROD_CONV_JO_REWINDING_SHIPMARK_LR where PROD_LINE like @prod_line + '%'", conn);
			//SqlCommand cmd = new SqlCommand(@"SELECT * FROM TBL_PROD_CONV_JO WHERE JODATE BETWEEN @from_date AND @to_date", conn);
			
			cmd.Parameters.AddWithValue("@prod_line",  prod_line);			
			//cmd.Parameters.AddWithValue("@from_date",  date_fr);
			//cmd.Parameters.AddWithValue("@to_date",  date_to);
			
			try
			{
		        SqlDataAdapter dataadapter = new SqlDataAdapter(cmd);
		        conn.Open();
		        //dataadapter.SelectCommand = cmd;
		        DataSet ds = new DataSet();
		        dataadapter.Fill(ds);
		        return (ds);
		                     	        
			}
			catch(Exception ex)
			{
				MessageBox.Show("Error - Converting Pack \nCannot load DB" + ex.Message + ex.ToString());
				return null;
			}
			finally
			{
				conn.Close();
				cmd = null;
				conn.Dispose();
				conn = null;
			}
			
		}
		
		
		void Txtbx_bal_mTextChanged(object sender, EventArgs e)
		{
			if(!String.IsNullOrWhiteSpace(txtbx_length.Text) && !String.IsNullOrWhiteSpace(txtbx_total_m.Text) && !String.IsNullOrWhiteSpace(txtbx_rcp.Text))
				TotalMeterCalculation();
			else
				return;
					
		}
		
		
		void RejectCalculation()
		{
			foreach (Control c in grpbx_reject.Controls)
            {
                if (c is TextBox)
                {
                	sumAllReject = sumAllReject + Double.Parse(c.Text);
                }
            }
			
			total = Double.Parse(txtbx_total_meter.Text) - sumAllReject;
			consume = Math.Round(Double.Parse(txtbx_length_cust.Text) * (Double.Parse(txtbx_no_logroll.Text) + Double.Parse(txtbx_no_logroll_store.Text)),2);
			balance = Math.Round(Double.Parse(txtbx_length.Text) - consume,2);
		}
	}
}