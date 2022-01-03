/*
 * Created by SharpDevelop.
 * User: faeiz
 * Date: 2017-10-10
 * Time: 11:34 AM
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
using System.Linq;

namespace AX2020
{
	/// <summary>
	/// Description of frm_prod_ribbon2.
	/// </summary>
	public partial class frm_prod_rewinding_converting : Form
	{
		
		
		public static string sqlconn = "Server=AX-UAT; Password=sbax2020sbg; User ID=sbax2020; Initial Catalog=SBG_AX_2020; Integrated Security=false";
		
		public static string sqlconn3 = "Server=AX-SQL; Password=ax2020sbgroup; User ID=ax2020sb; Initial Catalog=AX2020StagingDB; Integrated Security=false";
		DateTime issue_date;
		string username;
		string Fin_Next_No;
		string ip_address;
		public frm_prod_rewinding_converting()
		{

			InitializeComponent();
			ControlBox = false;
			username = frm_menu_system.userName; 
			lbl_username.Text = username;
			//cbx_operator.Enabled = false;
			//cbx_operator.Text = "-";
			txbx_to.Text = "600";
			txtbx_remark.Text = "-";
			//DateTime myPicker;
			DropDownList("SELECT sysstaffname FROM TBL_ADMIN_USER_FACTORY where sysdept = 'SLITTING' or sysdept = 'RCP' or sysdept = 'PAPER CORE' or sysdept = 'RIBBON'", cbx_operator, "sysstaffname");

			
			
			
			
			
			
	
			
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
            cbx_text.SelectedItem = "Please Select";

		}
		
	
		
		
		
		void Btn_saveClick(object sender, EventArgs e)
		{
			if (!Validation())
				return;
			
			
			
			
			SqlConnection con_data_add = new SqlConnection(sqlconn);
			System.Data.SqlClient.SqlCommand cmd_data_add = new SqlCommand(); 
			try 
			{
				cmd_data_add.Connection = con_data_add;		
				cmd_data_add.CommandText = "SP_PROD_CONV_SMALL_REWINDING";
				cmd_data_add.CommandType = CommandType.StoredProcedure;	
							
				cmd_data_add.Parameters.Add(new SqlParameter("@SP_OPERATOR_NAME", SqlDbType. NVarChar, 100)); 
				cmd_data_add.Parameters["@SP_OPERATOR_NAME"].Value = cbx_operator.Text;
				
				cmd_data_add.Parameters.Add(new SqlParameter("@SP_DEFECTIVE_BRAND", SqlDbType. NVarChar, 50)); 
				cmd_data_add.Parameters["@SP_DEFECTIVE_BRAND"].Value = txtbx_defective.Text.ToUpper();
				
				
				cmd_data_add.Parameters.Add(new SqlParameter("@SP_REWORK_BRAND", SqlDbType. NVarChar, 50)); //create parameter pada sql bwk data SP_RefNumber untuk dihantar semula
				cmd_data_add.Parameters["@SP_REWORK_BRAND"].Value = txtbx_rework.Text.ToUpper();
						
				cmd_data_add.Parameters.Add(new SqlParameter("@SP_COLOR", SqlDbType.NVarChar, 50));
				cmd_data_add.Parameters["@SP_COLOR"].Value = txtbx_color.Text.ToUpper();
						
				cmd_data_add.Parameters.Add(new SqlParameter("@SP_MICRON", SqlDbType. Float));
				cmd_data_add.Parameters["@SP_MICRON"].Value = Convert.ToDouble(txtbx_micron.Text);
						
				cmd_data_add.Parameters.Add(new SqlParameter("@SP_WIDTH", SqlDbType. Float));
				cmd_data_add.Parameters["@SP_WIDTH"].Value = Convert.ToDouble(txtbx_width.Text);  //tukar daripada string kepada nombor
						
				cmd_data_add.Parameters.Add(new SqlParameter("@SP_LENGTH", SqlDbType. Float));
				cmd_data_add.Parameters["@SP_LENGTH"].Value = Convert.ToDouble(txtbx_length.Text);  //tukar daripada string kepada nom
						
    			cmd_data_add.Parameters.Add(new SqlParameter("@SP_TARGET_OUTPUT", SqlDbType. Float));
    			cmd_data_add.Parameters["@SP_TARGET_OUTPUT"].Value= Convert.ToDouble(txbx_to.Text);
						
				cmd_data_add.Parameters.Add(new SqlParameter("@SP_ACTUAL_OUTPUT", SqlDbType. Float));
				cmd_data_add.Parameters["@SP_ACTUAL_OUTPUT"].Value = Convert.ToDouble(txtbx_ao.Text);
				
				cmd_data_add.Parameters.Add(new SqlParameter("@SP_REMARKS", SqlDbType. NVarChar, 100));
				cmd_data_add.Parameters["@SP_REMARKS"].Value = txtbx_remark.Text.ToUpper();
						
				cmd_data_add.Parameters.Add(new SqlParameter("@SP_ISSUEBY", SqlDbType. NVarChar, 100));
				cmd_data_add.Parameters["@SP_ISSUEBY"].Value = lbl_username.Text.ToUpper();
						
				cmd_data_add.Parameters.Add(new SqlParameter("@SP_USER_DATETIME", SqlDbType. DateTime));
				cmd_data_add.Parameters["@SP_USER_DATETIME"].Value= DateTime.Now;
						
				cmd_data_add.Parameters.Add(new SqlParameter("@SP_USER_PC", SqlDbType. NVarChar, 50));
				cmd_data_add.Parameters["@SP_USER_PC"].Value = frm_menu_system.ipAddress;
				
				
				cmd_data_add.Parameters.Add(new SqlParameter("@SP_ISSUEDATE", SqlDbType. DateTime));
				cmd_data_add.Parameters["@SP_ISSUEDATE"].Value = dateTimePicker1.Value;
						
				
						

				con_data_add.Open();
				cmd_data_add.ExecuteNonQuery();
			}
			
			catch (Exception ex) 
			{
				con_data_add.Close();
				MessageBox.Show("ERROR ? " + ex.Message + ex.ToString());
				return;
			} 
			finally 
			{
				con_data_add.Close();
			}
			con_data_add.Dispose();
			con_data_add = null;
			con_data_add = null;
			MessageBox.Show("SUCCESFULL SAVE");
			
		//	MessageBox.Show(SetValueForText1.ToString());
			
			
			//frm_prod_ribbon2_print obj_ribbon = new frm_prod_ribbon2_print();
			//obj_ribbon.ShowDialog();
			//SetValueForText1 = txtbx_refno.Text;
			//this.ClearTextBoxes(this);
			this.ClearTextBoxes(this);
			txbx_to.Text = "600";
			txtbx_remark.Text = "-";
		}
		
		void Btn_cancelClick(object sender, EventArgs e)
		{
			this.Close();
		}
		
		void Btn_clearClick(object sender, EventArgs e)
		{
			
			btn_save.Visible = true;
			this.ClearTextBoxes(this);
			txbx_to.Text = "600";
			txtbx_remark.Text = "-";
			
		}
		
		private void ClearTextBoxes(Control control)
			{
				foreach (Control c in control.Controls)
				{

					DateTimePicker myPicker = c as DateTimePicker;
					
					var box = c as TextBox;
					var box2 = c as ComboBox;
					if (box != null)
					{
						box.Text = string.Empty;
					}
					
					if (box2 != null)
					{
						box2.Text = "Please Select";
					}
					
					if (myPicker != null)
					{
						myPicker.Value = DateTime.Now;
					}
					
					
					this.ClearTextBoxes(c);
				}
			}
		

		private bool Validation() 
		{
      
            try
            {
                if (CommonValidation.ValidateIsEmptyString(cbx_operator.Text.Trim()))
	                {
	                    DialogBox.ShowWarningMessage(cbx_operator.Text + " cannot be empty.");
	                    cbx_operator.Focus();
	                    return false;
	                }
                
                	


             	else   if (CommonValidation.ValidateIsEmptyString(txtbx_defective.Text.Trim()))
	                {
	                    DialogBox.ShowWarningMessage(txtbx_defective.Text + " cannot be empty.");
	                    txtbx_defective.Focus();
	                    return false;
	                }


              	else  if (CommonValidation.ValidateIsEmptyString(txtbx_rework.Text.Trim()))
	                {
	                    DialogBox.ShowWarningMessage(txtbx_rework.Text + " cannot be empty.");
	                    txtbx_rework.Focus();
	                    return false;
	                }
              	
              	
              	else  if (CommonValidation.ValidateIsEmptyString(txtbx_color.Text.Trim()))
	                {
	                    DialogBox.ShowWarningMessage(txtbx_color.Text + " cannot be empty.");
	                    txtbx_color.Focus();
	                    return false;
	                }
              	
              	
              		else  if (CommonValidation.ValidateIsEmptyString(txtbx_micron.Text.Trim()))
	                {
	                    DialogBox.ShowWarningMessage(txtbx_micron.Text + " cannot be empty.");
	                    txtbx_micron.Focus();
	                    return false;
	                }
              		
              		else  if (CommonValidation.ValidateIsEmptyString(txtbx_width.Text.Trim()))
	                {
	                    DialogBox.ShowWarningMessage(txtbx_width.Text + " cannot be empty.");
	                    txtbx_width.Focus();
	                    return false;
	                }
              		
              		
              		else  if (CommonValidation.ValidateIsEmptyString(txtbx_length.Text.Trim()))
	                {
	                    DialogBox.ShowWarningMessage(txtbx_length.Text + " cannot be empty.");
	                    txtbx_length.Focus();
	                    return false;
	                }
              		
              		else  if (CommonValidation.ValidateIsEmptyString(txbx_to.Text.Trim()))
	                {
	                    DialogBox.ShowWarningMessage(txbx_to.Text + " cannot be empty.");
	                    txbx_to.Focus();
	                    return false;
	                }
              		
              		else  if (CommonValidation.ValidateIsEmptyString(txtbx_ao.Text.Trim()))
	                {
	                    DialogBox.ShowWarningMessage(txtbx_ao.Text + " cannot be empty.");
	                    txtbx_ao.Focus();
	                    return false;
	                }
              		
              		else  if (CommonValidation.ValidateIsEmptyString(txtbx_remark.Text.Trim()))
	                {
	                    DialogBox.ShowWarningMessage(txtbx_remark.Text + " cannot be empty.");
	                    txtbx_remark.Focus();
	                    return false;
	                }
     
              

              }
              
              
            
        
            catch(Exception e)
            {
          	;
            }
           //throw();
            
			return true;
	
		}
		
		

		
		
		
		
		
	}
}
