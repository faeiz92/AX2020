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
using System.Linq;

namespace AX2020
{
	
	public partial class frm_prod_converting_output_slitting_packing : Form
	{
		string init = "0";
		public static string sqlconn = "Server=AX-UAT; Password=sbax2020sbg; User ID=sbax2020; Initial Catalog=SBG_AX_2020; Integrated Security=false";
		public static string sqlconn2 = "Server=AX-UAT; Password=sbax2020sbg; User ID=sbax2020; Initial Catalog=MyProductionTrack; Integrated Security=false";
		bool clickCheck = false;
		string username, jr_lot_no, jr_ref_no, jr_color, jr_shipmark;
		string ref_no = null, line_no = null;
		int NextNo = 0, NextNoShip = 0, NextNoPack = 0, prod_line;
		double sumAllReject = 0, total =0, qty_ctn_ordered = 0, qty_roll_ordered =0, bal = 0, balance = 0, consume = 0;
		
		
		public frm_prod_converting_output_slitting_packing()
		{
			InitializeComponent();
			this.ControlBox = false;
			
			username = frm_menu_system.userName; 
			lbl_username.Text = "User : " + username;
				
			DropDownList("SELECT * FROM TBL_PROD_CONV_JO_PACKING_MACHINE_LIST WHERE PART = 'PACKING' order by MACHINE_NO", cbx_machine_pack, "MACHINE_NO");	
			DropDownList("SELECT * FROM TBL_PROD_CONV_JO_MACHINE_LIST WHERE PART = 'SLITTING' order by MACHINE_NO", cbx_machine_slit, "MACHINE_NO");	
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
		
		
		void Frm_prod_converting_output_slittingLoad(object sender, EventArgs e)
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
				string sql = "SELECT PROD_DOCNO, PROD_LINE, PROD_DATE, PROD_SHIFT, PROD_CUSTOMER, PROD_TOTALROLL, PROD_QTYREJECT, PROD_CODE, PROD_BRAND, PROD_COLOR, PROD_MICRON, PROD_WIDTH, PROD_LENGTH FROM TBL_PROD_CONV_JO_SLITTING WHERE PROD_DATE>= DATEADD(day,-45, getdate()) and PROD_USERREVISION <> 'SAPS' order by PROD_DATE DESC, PROD_SHIFT";
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
				MessageBox.Show("Error - Slitting DataGrid \nCannot load DB" + ex.Message + ex.ToString());
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
				cmd_SP1.Parameters.AddWithValue("@doc_no",  txtbx_ref_no.Text.ToUpper());
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
					txtbx_qty_logroll.Text = rd_SP1["JOPRODREMARK0a"].ToString();
									
					txtbx_no_logroll.Text = rd_SP1["JOPRODREMARK0b"].ToString();
					txtbx_total_qty_balance.Text = rd_SP1["JOPRODQTYBAL"].ToString();
					bal = Convert.ToDouble(rd_SP1["JOPRODQTYBAL"]);
//					int pcore_length = Convert.ToInt32(new String(rd_SP1["JOPRODPCORELENGTH"].ToString().Where(Char.IsDigit).ToArray()));
//					txtbx_no_logroll.Text = Convert.ToString(pcore_length/prod_length);
					
				} 
				else 
				{
					MessageBox.Show("Error - Slitting Search \nCannot find JO!");
					return;
				}
			} 
			catch (Exception ex) 
			{
				MessageBox.Show("Error - Slitting Search \nCannot load DB!" + ex.Message + ex.ToString());
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
		}
		
		void Btn_clearClick(object sender, EventArgs e)
		{
			ClearAllText(this);
			DataGrid();
			btn_save.Enabled = true;
			btn_del.Enabled = false;
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
    		
			txtbx_qty_logroll.Text = init;
			txtbx_shrinkage.Text = init;
			txtbx_print_align.Text = init;
			txtbx_telescope.Text = init;
			txtbx_uneven_thk.Text = init;
			txtbx_wrinkle.Text = init;
			txtbx_bubble.Text = init;
			txtbx_core_dented.Text = init;
			txtbx_core_label.Text = init;
			txtbx_dirt.Text = init;
			txtbx_edge.Text = init;
			txtbx_fish_eye.Text = init;
			txtbx_glue.Text = init;
			txtbx_init.Text = init;
			txtbx_no_logroll.Text = init;
			txtbx_qty_logroll.Text = init;
			txtbx_tape_cut.Text = init;
			txtbx_tape_end.Text = init;
			txtbx_tape_line.Text = init;
			txtbx_wave.Text = init;
			txtbx_film.Text = init;
			txtbx_roll_qty.Text = init;
			txtbx_ctn_qty.Text = init;
			
			sumAllReject = 0;
			total =0;
			qty_ctn_ordered = 0;
			qty_roll_ordered =0;
			bal = 0;
			
			clickCheck = false;
			jr_lot_no = null;
			jr_ref_no = null;
			jr_color = null;
			jr_shipmark = null;
			ref_no = null; 
			line_no = null;
			NextNo = 0;
			NextNoShip = 0;
			prod_line = 0;
			//qty_logroll = 0;
		 	balance = 0;
		 	consume = 0;
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
            	MessageBox.Show("Error - Slitting DropDown List \nCannot load DB" + se.ToString() + se.Message);
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

		}

		//>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
		
		private bool Validation()
        {
                  
        	if (CommonValidation.ValidateIsEmptyString(cbx_machine_pack.Text.Trim()) || cbx_machine_pack.Text == "Please Select")
            {
             	DialogBox.ShowWarningMessage(lbl_pack_machine.Text + " cannot be empty.");
                cbx_machine_pack.Focus();
                   	
                return false;     
            }
        	
        	else if (CommonValidation.ValidateIsEmptyString(cbx_machine_slit.Text.Trim()) || cbx_machine_slit.Text == "Please Select")
            {
             	DialogBox.ShowWarningMessage(lbl_slit_machine.Text + " cannot be empty.");
                cbx_machine_pack.Focus();
                   	
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
           	
           	else if (CommonValidation.ValidateIsEmptyString(txtbx_batch_no.Text.Trim()))
            {
                DialogBox.ShowWarningMessage(lbl_batch_no.Text + " cannot be empty.");
                txtbx_batch_no.Focus();
                   	
                return false;       
            }
           	
           		
            else if (CommonValidation.ValidateIsEmptyString(txtbx_jr_lot_no.Text.Trim()))
            {
                DialogBox.ShowWarningMessage(lbl_jr_lot_no.Text + " cannot be empty.");
                txtbx_jr_lot_no.Focus();
                   	
                return false;       
            }
                   	      	
               
            return true;
        }
		
		void RejectCalculation()
		{
			foreach (Control c in groupbx_reject.Controls)
            {
                if (c is TextBox)
                {
                	sumAllReject = sumAllReject + Double.Parse(c.Text);
                }
            }
			
			total = Double.Parse(txtbx_qty_logroll.Text) * Double.Parse(txtbx_no_logroll.Text) - sumAllReject;
			consume = Double.Parse(txtbx_length_cust.Text) * Double.Parse(txtbx_no_logroll.Text);
			balance = Double.Parse(txtbx_length.Text) - consume;
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
			
			RejectCalculation();
			
			if (LineNoGenerator())
			{
			
				if (sqlConnParm("SP_PROD_CONV_JO_SLITTING_ADD") & sqlConnParmReject("SP_PROD_CONV_JO_SLITTING_REJECT_ADD") & sqlConnParmShipMark("SP_PROD_CONV_JO_SLITTING_SHIPMARK_ADD") & sqlConnParm2("SP_PROD_CONV_JO_PACKING_ADD"))
				{
					//MessageBox.Show("Data is saved");
					DialogBox.ShowSaveSuccessDialog();
					DataGrid();
					UpdateBal("SP_PROD_CONV_UPDATE");
					UpdateBal2("SP_PROD_CONV_UPDATE_PACK");
					TempTable();
					Print();
					ClearAllText(this);
					
				}
	
			}
			
			clickCheck = false;			
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
		
		void UpdateBal2(string cmd_update)
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
		
		bool LineNoGenerator()
		{
			
			SqlConnection conNextNumber = new SqlConnection(sqlconn);
			SqlCommand cmdNextNumber = new SqlCommand();
			
			try 
			{
				cmdNextNumber.CommandText = "Select ProdConvSlitNextNumber, ProdConvSlitShipNextNumber, ProdPackingNextNumber from TBL_ADMIN_NEXT_NUMBER";
				cmdNextNumber.Connection = conNextNumber;

				conNextNumber.Open();
				SqlDataReader rdNextNumber = cmdNextNumber.ExecuteReader(System.Data.CommandBehavior.CloseConnection);

				rdNextNumber.Read();
				NextNo = Convert.ToInt32(rdNextNumber["ProdConvSlitNextNumber"]);
				NextNoShip = Convert.ToInt32(rdNextNumber["ProdConvSlitShipNextNumber"]);
				NextNoPack = Convert.ToInt32(rdNextNumber["ProdPackingNextNumber"]);
			
			} 
			catch (Exception ex) 
			{
				MessageBox.Show("Error - Slitting Packing Next Number \nCannot load DB!" + ex.Message + ex.ToString());
				return false;
			} 
			finally 
			{
				conNextNumber.Close();
				
			}
			
			conNextNumber.Dispose();
			conNextNumber = null;
			cmdNextNumber = null;
			prod_line = NextNo;

			
			SqlConnection conUpdate = new SqlConnection(sqlconn);
			SqlCommand cmdUpdateNextNumber = new SqlCommand();

			try
			{
				cmdUpdateNextNumber.CommandText = "update TBL_ADMIN_NEXT_NUMBER set ProdConvSlitNextNumber = ProdConvSlitNextNumber + 1";
				
				cmdUpdateNextNumber.Connection = conUpdate;

				conUpdate.Open();
				cmdUpdateNextNumber.ExecuteNonQuery();

			}
			catch (Exception ex)
			{
				conUpdate.Close();
				MessageBox.Show("Error - Slitting Next Number \nCannot update DB" + ex.Message + ex.ToString());
				return false;
			}
			finally 
			{
				conUpdate.Close();
			}

			conUpdate.Dispose();
			conUpdate = null;
			cmdUpdateNextNumber = null;
			
			
			SqlConnection conUpdate2 = new SqlConnection(sqlconn);
			SqlCommand cmdUpdateNextNumber2 = new SqlCommand();

			try
			{
				cmdUpdateNextNumber2.CommandText = "update TBL_ADMIN_NEXT_NUMBER set ProdConvSlitShipNextNumber = ProdConvSlitShipNextNumber + 1";
				
				cmdUpdateNextNumber2.Connection = conUpdate2;

				conUpdate2.Open();
				cmdUpdateNextNumber2.ExecuteNonQuery();

			}
			catch (Exception ex)
			{
				conUpdate2.Close();
				MessageBox.Show("Error - Slitting ShipMark Next Number \nCannot update DB" + ex.Message + ex.ToString());
				return false;
			}
			finally 
			{
				conUpdate2.Close();
			}

			conUpdate2.Dispose();
			conUpdate2 = null;
			cmdUpdateNextNumber2 = null;
			
			
			SqlConnection conUpdate3 = new SqlConnection(sqlconn);
			SqlCommand cmdUpdateNextNumber3 = new SqlCommand();

			try
			{
				cmdUpdateNextNumber3.CommandText = "update TBL_ADMIN_NEXT_NUMBER set ProdPackingNextNumber = ProdPackingNextNumber + 1";
				
				cmdUpdateNextNumber3.Connection = conUpdate3;

				conUpdate3.Open();
				cmdUpdateNextNumber3.ExecuteNonQuery();

			}
			catch (Exception ex)
			{
				conUpdate3.Close();
				MessageBox.Show("Error - Slitting Packing Next Number \nCannot update DB" + ex.Message + ex.ToString());
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
					cmd_data.Parameters["@SP_PROD_JRMICRON"].Value = Double.Parse(txtbx_mic.Text);
					
					cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_JRLOTNO", SqlDbType.NVarChar, 50));
					cmd_data.Parameters["@SP_PROD_JRLOTNO"].Value = jr_lot_no;
					
					cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_JRJONO", SqlDbType.NVarChar, 50));
					cmd_data.Parameters["@SP_PROD_JRJONO"].Value = jr_ref_no;
					
					
					cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_JRCOLOR", SqlDbType.NVarChar, 50));
					cmd_data.Parameters["@SP_PROD_JRCOLOR"].Value = jr_color;
					
					cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_LINE", SqlDbType.NVarChar, 50));
					cmd_data.Parameters["@SP_PROD_LINE"].Value = prod_line;
					
					cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_MACHINE", SqlDbType.NVarChar, 50));
					cmd_data.Parameters["@SP_PROD_MACHINE"].Value = cbx_machine_slit.Text.ToUpper();
					
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
					cmd_data.Parameters["@SP_PROD_QTYPERLOGROLL"].Value = Convert.ToDouble(txtbx_qty_logroll.Text);
					
					cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_NOLOGROLL", SqlDbType.Float));
					cmd_data.Parameters["@SP_PROD_NOLOGROLL"].Value = Convert.ToDouble(txtbx_no_logroll.Text);
					
					cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_QTYREJECT", SqlDbType.Float));
					cmd_data.Parameters["@SP_PROD_QTYREJECT"].Value = sumAllReject;
					
					cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_TOTALROLL", SqlDbType.Float));
					cmd_data.Parameters["@SP_PROD_TOTALROLL"].Value = total;
					
					
					cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_REMARK1", SqlDbType.NVarChar, 50));
					cmd_data.Parameters["@SP_PROD_REMARK1"].Value = cbx_helper.Text.ToUpper();
					
					cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_REMARK2", SqlDbType.NVarChar, 50));
					cmd_data.Parameters["@SP_PROD_REMARK2"].Value = cbx_shift.Text.ToUpper();	
					

										
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
				MessageBox.Show("Error - Slitting Save \nCannot load DB" + ex.Message + ex.ToString());			
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
			string trim_ref_no = ref_no.Substring(0, ref_no.LastIndexOf("-"));
			line_no = trim_ref_no.Substring(trim_ref_no.IndexOf('-')+1);
			
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
					
					cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_QTYORDERED", SqlDbType.Float));
					cmd_data.Parameters["@SP_PROD_QTYORDERED"].Value = Double.Parse(txtbx_total_qty_order.Text);

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
					cmd_data.Parameters["@SP_PROD_LINE"].Value = NextNoPack;
					
					cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_MACHINE", SqlDbType.NVarChar, 50));
					cmd_data.Parameters["@SP_PROD_MACHINE"].Value = cbx_machine_pack.Text.ToUpper();
					
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
				cmd_data_reject.Parameters["@SP_PROD_MACHINE"].Value = cbx_machine_pack.Text.ToUpper();
				
				cmd_data_reject.Parameters.Add(new SqlParameter("@SP_PROD_DATE", SqlDbType.DateTime));
				cmd_data_reject.Parameters["@SP_PROD_DATE"].Value = dtp_date.Value;
					
				cmd_data_reject.Parameters.Add(new SqlParameter("@SP_PROD_LINE", SqlDbType.NVarChar, 50));
				cmd_data_reject.Parameters["@SP_PROD_LINE"].Value = NextNo;
			
				
				cmd_data_reject.Parameters.Add(new SqlParameter("@SP_PROD_REJECT_SHRINKAGE", SqlDbType.Float));
				cmd_data_reject.Parameters["@SP_PROD_REJECT_SHRINKAGE"].Value = Convert.ToDouble(txtbx_shrinkage.Text);
					
				cmd_data_reject.Parameters.Add(new SqlParameter("@SP_PROD_REJECT_WRINKLE", SqlDbType.Float));
				cmd_data_reject.Parameters["@SP_PROD_REJECT_WRINKLE"].Value = Convert.ToDouble(txtbx_wrinkle.Text);
					
				cmd_data_reject.Parameters.Add(new SqlParameter("@SP_PROD_REJECT_UNEVENTHK", SqlDbType.Float));
				cmd_data_reject.Parameters["@SP_PROD_REJECT_UNEVENTHK"].Value = Convert.ToDouble(txtbx_uneven_thk.Text);
					
				cmd_data_reject.Parameters.Add(new SqlParameter("@SP_PROD_REJECT_TELESCOPE", SqlDbType.Float));
				cmd_data_reject.Parameters["@SP_PROD_REJECT_TELESCOPE"].Value = Convert.ToDouble(txtbx_telescope.Text);
					
				cmd_data_reject.Parameters.Add(new SqlParameter("@SP_PROD_REJECT_PRINTALIGN", SqlDbType.Float));
				cmd_data_reject.Parameters["@SP_PROD_REJECT_PRINTALIGN"].Value = Convert.ToDouble(txtbx_print_align.Text);
					
				cmd_data_reject.Parameters.Add(new SqlParameter("@SP_PROD_REJECT_FILMBREAK", SqlDbType.Float));
				cmd_data_reject.Parameters["@SP_PROD_REJECT_FILMBREAK"].Value = Convert.ToDouble(txtbx_film.Text);
					
				cmd_data_reject.Parameters.Add(new SqlParameter("@SP_PROD_REJECT_DIRT", SqlDbType.Float));
				cmd_data_reject.Parameters["@SP_PROD_REJECT_DIRT"].Value = Convert.ToDouble(txtbx_dirt.Text);
					
				cmd_data_reject.Parameters.Add(new SqlParameter("@SP_PROD_REJECT_CORELBLLIFT", SqlDbType.Float));
				cmd_data_reject.Parameters["@SP_PROD_REJECT_CORELBLLIFT"].Value = Convert.ToDouble(txtbx_core_label.Text);
					
				cmd_data_reject.Parameters.Add(new SqlParameter("@SP_PROD_REJECT_BUBBLE", SqlDbType.Float));
				cmd_data_reject.Parameters["@SP_PROD_REJECT_BUBBLE"].Value = Convert.ToDouble(txtbx_bubble.Text);
					
				cmd_data_reject.Parameters.Add(new SqlParameter("@SP_PROD_REJECT_TAPELINE", SqlDbType.Float));
				cmd_data_reject.Parameters["@SP_PROD_REJECT_TAPELINE"].Value = Convert.ToDouble(txtbx_tape_line.Text);
					
				cmd_data_reject.Parameters.Add(new SqlParameter("@SP_PROD_REJECT_INITWIND", SqlDbType.Float));
				cmd_data_reject.Parameters["@SP_PROD_REJECT_INITWIND"].Value = Convert.ToDouble(txtbx_init.Text);
					
				cmd_data_reject.Parameters.Add(new SqlParameter("@SP_PROD_REJECT_EDGEALIGN", SqlDbType.Float));
				cmd_data_reject.Parameters["@SP_PROD_REJECT_EDGEALIGN"].Value = Convert.ToDouble(txtbx_edge.Text);
					
				cmd_data_reject.Parameters.Add(new SqlParameter("@SP_PROD_REJECT_GLUETRANS", SqlDbType.Float));
				cmd_data_reject.Parameters["@SP_PROD_REJECT_GLUETRANS"].Value = Convert.ToDouble(txtbx_glue.Text);
				
				cmd_data_reject.Parameters.Add(new SqlParameter("@SP_PROD_REJECT_WAVE", SqlDbType.Float));
				cmd_data_reject.Parameters["@SP_PROD_REJECT_WAVE"].Value = Convert.ToDouble(txtbx_wave.Text);
					
				cmd_data_reject.Parameters.Add(new SqlParameter("@SP_PROD_REJECT_TAPEENDIN ", SqlDbType.Float));
				cmd_data_reject.Parameters["@SP_PROD_REJECT_TAPEENDIN "].Value = Convert.ToDouble(txtbx_tape_end.Text);
					
				cmd_data_reject.Parameters.Add(new SqlParameter("@SP_PROD_REJECT_FISHEYE", SqlDbType.Float));
				cmd_data_reject.Parameters["@SP_PROD_REJECT_FISHEYE"].Value = Convert.ToDouble(txtbx_fish_eye.Text);
					
				cmd_data_reject.Parameters.Add(new SqlParameter("@SP_PROD_REJECT_COREDENTED", SqlDbType.Float));
				cmd_data_reject.Parameters["@SP_PROD_REJECT_COREDENTED"].Value = Convert.ToDouble(txtbx_core_dented.Text);
					
				cmd_data_reject.Parameters.Add(new SqlParameter("@SP_PROD_REJECT_TAPECUT", SqlDbType.Float));
				cmd_data_reject.Parameters["@SP_PROD_REJECT_TAPECUT"].Value = Convert.ToDouble(txtbx_tape_cut.Text);
				
				
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
				MessageBox.Show("Error - Slitting Save Reject \nCannot load DB"  + ex.Message + ex.ToString());			
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
					
					cmd_data_shipmark.Parameters.Add(new SqlParameter("@SP_PROD_LINENO", SqlDbType.Float));
					cmd_data_shipmark.Parameters["@SP_PROD_LINENO"].Value = NextNoShip;
					
					cmd_data_shipmark.Parameters.Add(new SqlParameter("@SP_PROD_SHIPMARK", SqlDbType.NVarChar, 50));
					cmd_data_shipmark.Parameters["@SP_PROD_SHIPMARK"].Value = jr_shipmark;		
					
					cmd_data_shipmark.Parameters.Add(new SqlParameter("@SP_PROD_WIDTH", SqlDbType.Float));
					cmd_data_shipmark.Parameters["@SP_PROD_WIDTH"].Value = Double.Parse(txtbx_width.Text);

					cmd_data_shipmark.Parameters.Add(new SqlParameter("@SP_PROD_LENGTH ", SqlDbType.Float));
					cmd_data_shipmark.Parameters["@SP_PROD_LENGTH "].Value = Double.Parse(txtbx_length.Text);

					cmd_data_shipmark.Parameters.Add(new SqlParameter("@SP_PROD_MICRON", SqlDbType.Float));
					cmd_data_shipmark.Parameters["@SP_PROD_MICRON"].Value = Double.Parse(txtbx_mic.Text);
					
					cmd_data_shipmark.Parameters.Add(new SqlParameter("@SP_PROD_CONSUME", SqlDbType.Float));
					cmd_data_shipmark.Parameters["@SP_PROD_CONSUME"].Value = consume;

					cmd_data_shipmark.Parameters.Add(new SqlParameter("@SP_PROD_BALANCE", SqlDbType.Float));
					cmd_data_shipmark.Parameters["@SP_PROD_BALANCE"].Value = balance;
					
					

										
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
				MessageBox.Show("Error - Slitting Save \nCannot load DB" + ex.Message + ex.ToString());			
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
				MessageBox.Show("Error - Slitting Check \n" + ex.Message + ex.ToString());
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
					RejectCalculation();
					
			       	if(sqlConnParm("SP_PROD_CONV_JO_SLITTING_DEL") && sqlConnParmReject("SP_PROD_CONV_JO_SLITTING_REJECT_DEL"))
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
			SqlConnection con_Check_Duplicate_JO = new SqlConnection(sqlconn);
			SqlCommand cmd_Check_Duplicate_JO = new SqlCommand();
			
			try 
			{
				cmd_Check_Duplicate_JO.CommandText = @"select * from TBL_PROD_CONV_JO_SLITTING_SHIPMARK where PROD_SHIPMARK like @ship_mark + '%'";// + "' and JODOCNO <> 'SMSO124608'";
				cmd_Check_Duplicate_JO.Parameters.AddWithValue("@ship_mark",  txtbx_shipping_mark.Text.ToUpper());
				
				cmd_Check_Duplicate_JO.Connection = con_Check_Duplicate_JO;
				con_Check_Duplicate_JO.Open();
				SqlDataReader rd_Check_Duplicate_JO = cmd_Check_Duplicate_JO.ExecuteReader(System.Data.CommandBehavior.CloseConnection);

				if (rd_Check_Duplicate_JO.HasRows)
				{
					if (rd_Check_Duplicate_JO.Read())
					{
						MessageBox.Show("Shipping Mark already used");
						return;
					}

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
        	
			
			SqlConnection con = new SqlConnection(sqlconn);
			SqlCommand cmd = new SqlCommand();
			
			try 
			{
				//cmd.CommandText = "select twh, tstk, tlot_no, tref_no, twidth, tlength, tthickness, tcolor from stk_lot where tstk like 'WJ%' and twh = 'GF1' and tbal_qty > 1 '" + txtbx_ref_no.Text + "'";
				cmd.CommandText = "select JRBarcode, TrxLotNo, TrxJoNo, TrxJoThickness, TrxJoWidth, TrxTotalLength, TrxJoColor, TrxShipMark from VIEW_CONVERTING_BARCODE where TrxShipMark like @ship_mark + '%' or JRBarcode = @ship_mark";
				cmd.Parameters.AddWithValue("@ship_mark",  txtbx_shipping_mark.Text.ToUpper());
				cmd.Connection = con;
				con.Open();
				SqlDataReader rd = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
				
				if (rd.HasRows)
				{
					while (rd.Read())
					{	
//						checkButton = true;
//						btn_del.Visible = false;
//			        	btn_save.Visible = true;
//						//btn_clear.Visible = true;
//						//btn_cancel.Visible = true;
//			        	//btn_del.Location = new Point(416, 1348);
//			        	grpbox_output.Visible = true;
//						grpbox_cust.Visible = true;
//			        	btn_save.Location = new Point(306, 912);
//			        	btn_clear.Location = new Point(432, 912);
//			        	btn_cancel.Location = new Point(558, 912);	
			        	
						jr_shipmark = rd["TrxShipMark"].ToString();
						jr_lot_no = rd["TrxLotNo"].ToString();
						jr_ref_no = rd["TrxJoNo"].ToString();
						txtbx_mic.Text = (Convert.ToInt32(rd["TrxJoThickness"])).ToString();
						jr_color = rd["TrxJoColor"].ToString();	
						
						txtbx_width.Text = (Convert.ToInt32(rd["TrxJoWidth"])).ToString();
						txtbx_length.Text = (Convert.ToInt32(rd["TrxTotalLength"])).ToString();
						
						txtbx_shipping_mark.Text = rd["TrxShipMark"].ToString();
											
					} 
				}
				else 
				{
					MessageBox.Show("Error - Slitting Check \nCannot find shipping_mark!");
					return;
				}
			} 
			catch (Exception ex) 
			{
				MessageBox.Show("Error - Slitting Check \nCannot load DB!" + ex.Message + ex.ToString());
				return;
			} 
			finally 
			{
				con.Close();
			}
			
			con.Dispose();
			con = null;
			cmd = null;
			
			if(!String.IsNullOrEmpty(txtbx_length_cust.Text))
			{
				
				txtbx_no_logroll.Text = ((int)Math.Floor(Double.Parse(txtbx_length.Text)/Double.Parse(txtbx_length_cust.Text))).ToString();
			}
			
			if(!String.IsNullOrEmpty(txtbx_width_cust.Text))
			{
				txtbx_qty_logroll.Text = ((int)Math.Floor(Double.Parse(txtbx_width.Text)/Double.Parse(txtbx_width_cust.Text))).ToString();
			}
			
			txtbx_ctn_qty.Text = ((int)Math.Floor(Double.Parse(txtbx_no_logroll.Text) * Double.Parse(txtbx_qty_logroll.Text) / Double.Parse(txtbx_conversion.Text))).ToString();
			
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
				cmd_SP1.CommandText = @"SELECT * FROM TBL_PROD_CONV_JO_SLITTING where PROD_DOCNO = @doc_no and PROD_LINE = @line_no";
				cmd_SP1.Parameters.AddWithValue("@doc_no",  txtbx_ref_no.Text);
        		cmd_SP1.Parameters.AddWithValue("@line_no",  line_no);
				cmd_SP1.Connection = con_SP1;
				con_SP1.Open();
				SqlDataReader rd_SP1 = cmd_SP1.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
				if (rd_SP1.HasRows)
				{
					while (rd_SP1.Read())
					{
						dtp_date.Value = Convert.ToDateTime(rd_SP1["PROD_DATE"]);
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
						prod_line = Convert.ToInt32(rd_SP1["PROD_LINE"].ToString());						
						
						cbx_machine_slit.Text = rd_SP1["PROD_MACHINE"].ToString();
						cbx_operator.Text = rd_SP1["PROD_OPERATOR"].ToString();
						cbx_helper.Text = rd_SP1["PROD_HELPER"].ToString();
						cbx_shift.Text = rd_SP1["PROD_SHIFT"].ToString();
						txtbx_qty_logroll.Text = rd_SP1["PROD_QTYPERLOGROLL"].ToString();
						txtbx_no_logroll.Text = rd_SP1["PROD_NOLOGROLL"].ToString();
						txtbx_total_qty_order.Text = rd_SP1["PROD_QTYORDERED"].ToString();
						
					} 	
				}
				else 
				{
					MessageBox.Show("Error - Slitting Retrieve \nCannot find JO!");
					return;
				}
			} 
			catch (Exception ex) 
			{
				MessageBox.Show("Error - Slitting Retrieve \nCannot retrieve DB!" + ex.Message + ex.ToString());
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
				cmd_SP2.CommandText = @"SELECT * FROM TBL_PROD_CONV_JO_SLITTING_REJECT where PROD_DOCNO = @doc_no and PROD_LINE = @line_no";
				cmd_SP2.Parameters.AddWithValue("@doc_no",  txtbx_ref_no.Text);
        		cmd_SP2.Parameters.AddWithValue("@line_no",  line_no);
				cmd_SP2.Connection = con_SP2;
				con_SP2.Open();
				SqlDataReader rd_SP2 = cmd_SP2.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
				
				if(rd_SP2.HasRows)
				{
					while (rd_SP2.Read())
					{				        	
						txtbx_shrinkage.Text = rd_SP2["PROD_REJECT_SHRINKAGE"].ToString();
						txtbx_wrinkle.Text = rd_SP2["PROD_REJECT_WRINKLE"].ToString();
						txtbx_uneven_thk.Text = rd_SP2["PROD_REJECT_UNEVENTHK"].ToString();
						txtbx_telescope.Text = rd_SP2["PROD_REJECT_TELESCOPE"].ToString();
						txtbx_print_align.Text = rd_SP2["PROD_REJECT_PRINTALIGN"].ToString();
						txtbx_film.Text = rd_SP2["PROD_REJECT_FILMBREAK"].ToString();
						txtbx_dirt.Text = rd_SP2["PROD_REJECT_DIRT"].ToString();
						txtbx_core_label.Text = rd_SP2["PROD_REJECT_CORELBLLIFT"].ToString();
						txtbx_bubble.Text = rd_SP2["PROD_REJECT_BUBBLE"].ToString();
						txtbx_tape_line.Text = rd_SP2["PROD_REJECT_TAPELINE"].ToString();
						txtbx_init.Text = rd_SP2["PROD_REJECT_INITWIND"].ToString();
						txtbx_edge.Text = rd_SP2["PROD_REJECT_EDGEALIGN"].ToString();
						txtbx_glue.Text = rd_SP2["PROD_REJECT_GLUETRANS"].ToString();
						txtbx_wave.Text = rd_SP2["PROD_REJECT_WAVE"].ToString();
						txtbx_tape_end.Text = rd_SP2["PROD_REJECT_TAPEENDIN"].ToString();
						txtbx_fish_eye.Text = rd_SP2["PROD_REJECT_FISHEYE"].ToString();
						txtbx_core_dented.Text = rd_SP2["PROD_REJECT_COREDENTED"].ToString();
						txtbx_tape_cut.Text = rd_SP2["PROD_REJECT_TAPECUT"].ToString();
					}
				} 
				else 
				{
					MessageBox.Show("Error - Slitting Retrieve Reject \nCannot read DB!");
					return;
				}
			} 
			catch (Exception ex) 
			{
				MessageBox.Show("Error - Slitting Retrieve Reject \nCannot load DB!" + ex.Message + ex.ToString());
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
					MessageBox.Show("Error - Slitting Retrieve \nCannot find JO!");
					return;
				}
			} 
			catch (Exception ex) 
			{
				MessageBox.Show("Error - Slitting Retrieve \nCannot load DB!" + ex.Message + ex.ToString());
				return;
			} 
			finally 
			{
				con_SP3.Close();
			}
			
			con_SP3.Dispose();
			con_SP3 = null;
			cmd_SP3 = null;	

			
			SqlConnection con_SP4 = new SqlConnection(sqlconn);
			SqlCommand cmd_SP4 = new SqlCommand();
				
			try 
			{
				cmd_SP4.CommandText = @"SELECT * FROM TBL_PROD_CONV_JO_PACKING where PROD_DOCNO = @doc_no and PROD_LINE = @line_no";
				cmd_SP4.Parameters.AddWithValue("@doc_no",  txtbx_ref_no.Text);
        		cmd_SP4.Parameters.AddWithValue("@line_no",  line_no);
				cmd_SP4.Connection = con_SP4;
				con_SP4.Open();
				SqlDataReader rd_SP4 = cmd_SP4.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
				if (rd_SP4.HasRows)
				{
					while (rd_SP4.Read())
					{				        	
						cbx_machine_pack.Text = rd_SP4["PROD_MACHINE"].ToString();
						txtbx_ctn_qty.Text = rd_SP4["PROD_QTYCTN"].ToString();
						txtbx_roll_qty.Text = rd_SP4["PROD_QTYROLL"].ToString();
						txtbx_batch_no.Text = rd_SP4["PROD_BATCHNO"].ToString();
						txtbx_jr_lot_no.Text = rd_SP4["PROD_LOTNO"].ToString();
											
					} 	
				}
				else 
				{
					MessageBox.Show("Error - Packing Retrieve \nCannot find JO!");
					return;
				}
			} 
			catch (Exception ex) 
			{
				MessageBox.Show("Error - Packing Retrieve \nCannot retrieve DB!" + ex.Message + ex.ToString());
				return;
			} 
			finally 
			{
				con_SP4.Close();
			}
				
			con_SP4.Dispose();
			con_SP4 = null;
			cmd_SP4 = null;			
			
        }
           
		void Dt_gridDataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
		{
			dt_grid.ClearSelection();
		}	
		
		
		//---------------------------------------------------------------------------
		
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
	}
}
