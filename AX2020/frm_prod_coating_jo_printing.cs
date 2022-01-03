/*
 * Created by SharpDevelop.
 * User: ax2020-2
 * Date: 1/5/2017
 * Time: 3:21 PM
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
using System.Resources;

namespace AX2020
{
	/// <summary>
	/// Description of frm_production_coating_jo_printing.
	/// </summary>
	public partial class frm_prod_coating_jo_printing : Form
	{
		public static string sqlconn = "Server=AX-UAT; Password=sbax2020sbg; User ID=sbax2020; Initial Catalog=SBG_AX_2020; Integrated Security=false";
		string username, combine_micron_width_length;
		string remark ="";
		string film_mic, film_width, film_length;
		int NextNo;
		bool checkrunningno = true;
		bool checkstoreprocedure = true;
		public frm_prod_coating_jo_printing()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			this.ControlBox = false;
			//btn_delete.Visible = false;
			//Unable_Edit();
			WORDINGLIST();
			datagrid();
			//ClearText();
			txtbx_stockcode.Text = "POPP";
			
			combobox_word.Text = "Please, select any value";
			username = frm_menu_system.userName;
			lbl_username.Text = "User : " + username;
			
			btn_SBTI.Visible = false;
			btn_store.Visible = false;
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		
		
		
		
//		public void Unable_Edit()
//		{
//			
//			//txtbx_refno.Enabled = false;
//			txtbx_code.Enabled = false;
//			txtbx_filmsize.Enabled = false;
//			txtbx_color.Enabled = false;
//			txtbx_customer.Enabled = false;
//		}
		
		
		public void WORDINGLIST()
		{
			string sqlStatement = "select JOPPWORDING from TBL_PROD_COAT_PRINTING_BOM order by JOPPWORDING";
			SqlConnection sqlConn = new SqlConnection(sqlconn);
			DataSet ds = new DataSet();
			SqlDataAdapter sda = new SqlDataAdapter(sqlStatement, sqlConn);
					
			try 
			{
						
				sqlConn.Open();
				sda.Fill(ds);
				combobox_word.Text = "Please Select";
						

			}
			catch (Exception exc) 
			{
					DialogBox.ShowWarningMessage("An error occured while connecting to database" + exc.Message+ exc.ToString());
					sqlConn.Close();
					sqlConn.Dispose();
					return;
			} 
			finally 
			{
					sqlConn.Close();
					sqlConn.Dispose();
			}
		
			foreach(DataRow dr1 in ds.Tables[0].Rows)
			{
				combobox_word.Items.Add(dr1["JOPPWORDING"].ToString());
			}
				
		}
		
		void Btn_saveClick(object sender, EventArgs e)
		{
				if (!Validation())
				return;
				
				if (checkrunningno == true)
				{
					nextnumber();
				}
				
						
					
				SqlConnection con_data_add = new SqlConnection(sqlconn);
				System.Data.SqlClient.SqlCommand cmd_data_add = new SqlCommand();   //adress pergi ke sql
				try {
					
					

						cmd_data_add.Connection = con_data_add;	
						cmd_data_add.CommandType = CommandType.StoredProcedure;						
							//coman run store procedure
							//nama store procedure
							//declare comand
						
						if(checkstoreprocedure == true)
						{
							cmd_data_add.CommandText = "SP_PROD_COAT_PRINTING_JOB_ORDER_ADD";
							
						}
    	
						else
						{
							
							cmd_data_add.CommandText = "SP_PROD_COAT_PRINTING_JOB_ORDER_ADD_EDIT";
						}
						
						cmd_data_add.CommandType = CommandType.StoredProcedure;	
					
				
						cmd_data_add.Parameters.Add(new SqlParameter("@SP_JODOCNO", SqlDbType. NVarChar, 50)); //create parameter pada sql bwk data SP_RefNumber untuk dihantar semula
						cmd_data_add.Parameters["@SP_JODOCNO"].Value =txtbx_refno.Text.ToUpper();//txtbx_refno.Text.ToUpper();
						
						
						
						cmd_data_add.Parameters.Add(new SqlParameter("@SP_JRSTOCKCODE", SqlDbType.NVarChar, 50));
						cmd_data_add.Parameters["@SP_JRSTOCKCODE"].Value = "POPP";
						
						//txtbx_stockcode2
						cmd_data_add.Parameters.Add(new SqlParameter("@SP_JR_STOCKCODE", SqlDbType.NVarChar, 50));
						cmd_data_add.Parameters["@SP_JR_STOCKCODE"].Value = txtbx_stockcode2.Text.ToUpper() ;
						
						
						
						
						
						//cmd_data_add.Parameters.Add(new SqlParameter("@SP_JRCOLOR", SqlDbType.NVarChar, 50));
						//cmd_data_add.Parameters["@SP_JRCOLOR"].Value = txtbx_color.Text.ToUpper();  //tukar daripada string kepada nom
						
    					cmd_data_add.Parameters.Add(new SqlParameter("@SP_JRMICRON", SqlDbType.NVarChar, 50));
    					cmd_data_add.Parameters["@SP_JRMICRON"].Value = txtbx_micron.Text.ToUpper();
						
						cmd_data_add.Parameters.Add(new SqlParameter("@SP_JRWIDTH", SqlDbType.NVarChar, 50));
						cmd_data_add.Parameters["@SP_JRWIDTH"].Value = textbx_width.Text.ToUpper();
						
						cmd_data_add.Parameters.Add(new SqlParameter("@SP_JRLENGTH",SqlDbType.NVarChar, 50));
						cmd_data_add.Parameters["@SP_JRLENGTH"].Value = txtbx_length.Text.ToUpper();
						
						
						cmd_data_add.Parameters.Add(new SqlParameter("@SP_JODATE", SqlDbType.DateTime)); //create parameter pada sql bwk data SP_RefNumber untuk dihantar semula
						cmd_data_add.Parameters["@SP_JODATE"].Value = dateTimePicker1.Value;
						
						
						
						//MessageBox.Show(txtbx
						
						//TUKAR QTY ORDERED KEPADA JO JR QTY
					
						
						cmd_data_add.Parameters.Add(new SqlParameter("@SP_JOPPCUSTOMER", SqlDbType.NVarChar, 50));
						cmd_data_add.Parameters["@SP_JOPPCUSTOMER"].Value = txtbx_customer.Text.ToUpper();
						
						cmd_data_add.Parameters.Add(new SqlParameter("@SP_JOREMARK", SqlDbType.NVarChar, 50));
						cmd_data_add.Parameters["@SP_JOREMARK"].Value = remark;
    
    					cmd_data_add.Parameters.Add(new SqlParameter("@SP_JOREMARK1", SqlDbType.NVarChar, 50));
						cmd_data_add.Parameters["@SP_JOREMARK1"].Value = txtbx_remark1.Text.ToUpper();

						cmd_data_add.Parameters.Add(new SqlParameter("@SP_JOREMARK2", SqlDbType.NVarChar, 50));
						cmd_data_add.Parameters["@SP_JOREMARK2"].Value = txtbx_remark2.Text.ToUpper();
						
						cmd_data_add.Parameters.Add(new SqlParameter("@SP_JOREMARK3", SqlDbType.NVarChar, 50));
						cmd_data_add.Parameters["@SP_JOREMARK3"].Value = txtbx_remark3.Text.ToUpper();
						
						cmd_data_add.Parameters.Add(new SqlParameter("@SP_JOREMARK4", SqlDbType.NVarChar, 50));
						cmd_data_add.Parameters["@SP_JOREMARK4"].Value = txtbx_remark4.Text.ToUpper();
						
						cmd_data_add.Parameters.Add(new SqlParameter("@SP_JOREMARK5", SqlDbType.NVarChar, 50));
						cmd_data_add.Parameters["@SP_JOREMARK5"].Value = txtbx_remark5.Text.ToUpper();
						
						
						
						
						
						cmd_data_add.Parameters.Add(new SqlParameter("@SP_JOPPCODE", SqlDbType.NVarChar, 80));
						cmd_data_add.Parameters["@SP_JOPPCODE"].Value =txtbx_code.Text.ToUpper();
						
						cmd_data_add.Parameters.Add(new SqlParameter("@SP_JOPPTOLUNE", SqlDbType.NVarChar, 80));
						cmd_data_add.Parameters["@SP_JOPPTOLUNE"].Value = txtbx_tolune.Text.ToUpper();
 
						cmd_data_add.Parameters.Add(new SqlParameter("@SP_JOPPWording", SqlDbType.NVarChar, 80));
						cmd_data_add.Parameters["@SP_JOPPWording"].Value = combobox_word.Text.ToUpper();
						
						combine_micron_width_length = txtbx_filmsize_micron.Text + "MIC    X    " + txtbx_filmsize_width.Text + "MM   X   " + txtbx_filmsize_length.Text + "M";
						
						cmd_data_add.Parameters.Add(new SqlParameter("@SP_JOPPFilmSize", SqlDbType.NVarChar, 80));
						cmd_data_add.Parameters["@SP_JOPPFilmSize"].Value = combine_micron_width_length;
						
						cmd_data_add.Parameters.Add(new SqlParameter("@SP_JOPPColor", SqlDbType.NVarChar, 80));
						cmd_data_add.Parameters["@SP_JOPPColor"].Value = txtbx_color.Text.ToUpper();
						
						cmd_data_add.Parameters.Add(new SqlParameter("@SP_JOPPSizeArt", SqlDbType.NVarChar, 80));
						cmd_data_add.Parameters["@SP_JOPPSizeArt"].Value = txtbx_sizeart.Text.ToUpper();
						
						cmd_data_add.Parameters.Add(new SqlParameter("@SP_JOPPColorKG", SqlDbType.NVarChar, 80));
						cmd_data_add.Parameters["@SP_JOPPColorKG"].Value = txtbx_colorkg.Text.ToUpper();
						
						cmd_data_add.Parameters.Add(new SqlParameter("@SP_JOPPColorRemark", SqlDbType.NVarChar, 80));
						cmd_data_add.Parameters["@SP_JOPPColorRemark"].Value = txtbx_color1.Text.ToUpper();
						
						cmd_data_add.Parameters.Add(new SqlParameter("@SP_ISSUEDATE", SqlDbType.DateTime));
						cmd_data_add.Parameters["@SP_ISSUEDATE"].Value = DateTime.Now;

						cmd_data_add.Parameters.Add(new SqlParameter("@SP_JOISSUEBY", SqlDbType.NVarChar, 50));
						cmd_data_add.Parameters["@SP_JOISSUEBY"].Value = username.ToUpper();
						
						
						cmd_data_add.Parameters.Add(new SqlParameter("@SP_FILMMICRON", SqlDbType.NVarChar, 50));
						cmd_data_add.Parameters["@SP_FILMMICRON"].Value =txtbx_filmsize_micron.Text;
						
						cmd_data_add.Parameters.Add(new SqlParameter("@SP_FILMWIDTH", SqlDbType.NVarChar, 50));
						cmd_data_add.Parameters["@SP_FILMWIDTH"].Value = txtbx_filmsize_width.Text;
						
						cmd_data_add.Parameters.Add(new SqlParameter("@SP_FILMLENGTH", SqlDbType.NVarChar, 50));
						cmd_data_add.Parameters["@SP_FILMLENGTH"].Value = txtbx_filmsize_length.Text;
						
						
						con_data_add.Open();
						cmd_data_add.ExecuteNonQuery();
						cmd_data_add.Parameters.Clear();
						
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
			cmd_data_add = null;
			
			
			
			DialogBox.ShowWarningMessage("SUCCESFULL SAVE");
			
			
			SqlConnection con_data_add2 = new SqlConnection(sqlconn);
			System.Data.SqlClient.SqlCommand cmd_data_add2 = new SqlCommand();  //adress pergi ke sql
				try 
				{

						cmd_data_add2.Connection = con_data_add2;		//coman run store procedure
						cmd_data_add2.CommandText = "SP_PROD_COAT_PRINTING_JOB_ORDER_TRANSFER_DATA_ADD";	//nama store procedure
						cmd_data_add2.CommandType = CommandType.StoredProcedure;		//declare comand
    	
						cmd_data_add2.Parameters.Add(new SqlParameter("@SP_JODOCNO", SqlDbType.NVarChar, 50)); //create parameter pada sql bwk data SP_RefNumber untuk dihantar semula
						cmd_data_add2.Parameters["@SP_JODOCNO"].Value = txtbx_refno.Text.ToUpper();
						
						
						con_data_add2.Open();
						cmd_data_add2.ExecuteNonQuery();
				}
				
				catch (Exception ex) 
				{
						con_data_add2.Close();
						MessageBox.Show("ERROR ? " + ex.Message + ex.ToString());
						return;
				} 
				finally 
				{
						con_data_add2.Close();
				}
			con_data_add2.Dispose();
			con_data_add2 = null;
			cmd_data_add2 = null;
			
			
			SqlConnection con_data_add3 = new SqlConnection(sqlconn);
			System.Data.SqlClient.SqlCommand cmd_data_add3 = new SqlCommand();  //adress pergi ke sql
			try 
			{

				cmd_data_add3.Connection = con_data_add3;		//coman run store procedure
				cmd_data_add3.CommandText = "SP_TEMP_PROD_COAT_PRINTING_JOB_ORDER";	//nama store procedure
				cmd_data_add3.CommandType = CommandType.StoredProcedure;		//declare comand
    	
				cmd_data_add3.Parameters.Add(new SqlParameter("@SP_JODOCNO", SqlDbType.NVarChar, 50)); //create parameter pada sql bwk data SP_RefNumber untuk dihantar semula
				cmd_data_add3.Parameters["@SP_JODOCNO"].Value = txtbx_refno.Text.ToUpper();
						
						
				con_data_add3.Open();
				cmd_data_add3.ExecuteNonQuery();
			}
				
			catch (Exception ex) 
			{
				con_data_add3.Close();
				MessageBox.Show("ERROR ? " + ex.Message + ex.ToString());
				return;
			} 
			finally 
			{
				con_data_add3.Close();
			}
			con_data_add3.Dispose();
			con_data_add3 = null;
			cmd_data_add3 = null;
			
			//txtbx_refno.Text = Convert.ToString(NextNo);
			printreport();
			checkstoreprocedure = true;
			checkrunningno = true;	
			ClearAllText(this);		
			txtbx_refno.Text = "0";		
			txtbx_stockcode.Text = "POPP";			
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
		}	
		
		
		void printreport()
		{
			
		System.Windows.Forms.Form frm = new System.Windows.Forms.Form();
        frm.Height = 600;
        frm.Width = 800;

        fyiReporting.RdlViewer.RdlViewer rdlView = new fyiReporting.RdlViewer.RdlViewer();
        fyiReporting.RdlViewer.ViewerToolstrip report = new fyiReporting.RdlViewer.ViewerToolstrip(rdlView);
        Uri baseUri = new Uri(System.IO.Directory.GetCurrentDirectory());
        rdlView.SourceFile = new Uri(baseUri,@"../report/planning_jo_coating_printing_R12.rdl");
        
        
        rdlView.Report.DataSets["Data"].SetSource("select * from TBL_TEMP_PROD_COAT_PRINTING_JOB_ORDER where JODOCNO = '" + txtbx_refno.Text + "'");
    
        rdlView.Rebuild();

        rdlView.Dock = DockStyle.Fill;
        frm.Controls.Add(rdlView);
        frm.Controls.Add(report);

        frm.ShowDialog(this);
		
		}
		
		
		void nextnumber()
		{
			int NextNo ;
			
						NextNo = 0;
//************************************************************************************************************************
						SqlConnection conNextNumber = new SqlConnection(sqlconn);
						SqlCommand cmdNextNumber = new SqlCommand();
						try {
							cmdNextNumber.CommandText = "Select * from TBL_ADMIN_NEXT_NUMBER";
							cmdNextNumber.Connection = conNextNumber;
							conNextNumber.Open();
							SqlDataReader rdNextNumber = cmdNextNumber.ExecuteReader(System.Data.CommandBehavior.CloseConnection); //UNTUK BACA DATA DALAM TABLE
							rdNextNumber.Read();
							NextNo = Convert.ToInt32(rdNextNumber["ProdCoatJoPrintingNextNumber"].ToString());
							
						} 
						
						
						catch (Exception ex) 
						
						{
							MessageBox.Show("ERROR NEXT NUMBER!" + ex.ToString() +ex.Message);
							NextNo = 0;
							return;
							
						} 
						
						
						
						finally
						{
							conNextNumber.Close();
						}
						conNextNumber.Dispose();
						conNextNumber = null;
						cmdNextNumber = null;
						DateTime JODSDate = DateTime.Now;						
						string JODSDateString;
						JODSDateString = (JODSDate.ToString("yy")) + (JODSDate.ToString("MM"));
						string SDate;
						SDate = "P" + NextNo + JODSDateString;
						txtbx_refno.Text = Convert.ToString(SDate);
						//************************************************************************************************************************
						
						
						SqlConnection conUpdateNextNumber = new SqlConnection(sqlconn);
						System.Data.SqlClient.SqlCommand cmdUpdateNextNumber = new SqlCommand();
						try {
							cmdUpdateNextNumber.CommandText = "update TBL_ADMIN_NEXT_NUMBER set ProdCoatJoPrintingNextNumber = ProdCoatJoPrintingNextNumber + 1";
							cmdUpdateNextNumber.Connection = conUpdateNextNumber;
							conUpdateNextNumber.Open();
							cmdUpdateNextNumber.ExecuteNonQuery();
						}
						catch (Exception ex) 
						{
							conUpdateNextNumber.Close();
							MessageBox.Show("Error Update Next Number!" + ex.ToString() + ex.Message); //Lbl_Message.Text = "Error Update Next Number! " + ex.ToString + ex.Message;
							return;
						} 
						finally 
						{
							conUpdateNextNumber.Close();
						}
						conUpdateNextNumber.Dispose();
						conUpdateNextNumber = null;
						cmdUpdateNextNumber = null;
		}
		
			
		
		
		private bool Validation() 
		{
      
            try
            {
//                if (CommonValidation.ValidateIsEmptyString(txtbx_refno.Text.Trim()))
//	                {
//	                    DialogBox.ShowWarningMessage(txtbx_refno.Text + " cannot be empty.");
//	                    txtbx_refno.Focus();
//	                    return false;
//	                }
                
//                else if (CommonValidation.ValidateIsEmptyString(txtbx_remark1.Text.Trim()))
//	                {
//	                    DialogBox.ShowWarningMessage(txtbx_remark1.Text + " cannot be empty.");
//	                    txtbx_remark1.Focus();
//	                    return false;
//	                }
//              else  if (CommonValidation.ValidateIsEmptyString(txtbx_remark2.Text.Trim()))
//	                {
//	                   DialogBox.ShowWarningMessage(txtbx_remark2.Text + " cannot be empty.");
//	                   txtbx_remark2.Focus();
//	                    return false;
//	                }
//             else   if (CommonValidation.ValidateIsEmptyString(txtbx_remark3.Text.Trim()))
//	                {
//	                    DialogBox.ShowWarningMessage(txtbx_remark3.Text + " cannot be empty.");
//	                    txtbx_remark3.Focus();
//	                    return false;
//	                }
//
//              else  if (CommonValidation.ValidateIsEmptyString(txtbx_remark4.Text.Trim()))
//	                {
//	                    DialogBox.ShowWarningMessage(txtbx_remark4.Text + " cannot be empty.");
//	                    txtbx_remark4.Focus();
//	                    return false;
//	                }
//              
//              
//                else if (CommonValidation.ValidateIsEmptyString(txtbx_remark5.Text.Trim()))
//	                {
//	                    DialogBox.ShowWarningMessage(txtbx_remark5.Text + " cannot be empty.");
//	                    txtbx_remark5.Focus();
//	                    return false;
//	                }
               if (CommonValidation.ValidateIsEmptyString(txtbx_length.Text.Trim()))
	                {
	                   DialogBox.ShowWarningMessage(txtbx_length.Text + " cannot be empty.");
	                   txtbx_length.Focus();
	                    return false;
	                }
//             else   if (CommonValidation.ValidateIsEmptyString(txtbx_width.Text.Trim()))
//	                {
//	                    DialogBox.ShowWarningMessage(txtbx_width.Text + " cannot be empty.");
//	                    txtbx_width.Focus();
//	                    return false;
//	                }

//              else  if (CommonValidation.ValidateIsEmptyString(txtbx_code.Text.Trim()))
//	                {
//	                    DialogBox.ShowWarningMessage(txtbx_code.Text + " cannot be empty.");
//	                    txtbx_code.Focus();
//	                    return false;
//	                }
              
              else if (CommonValidation.ValidateIsEmptyString(txtbx_tolune.Text.Trim()))
	                {
	                    DialogBox.ShowWarningMessage(txtbx_tolune.Text + " cannot be empty.");
	                    txtbx_tolune.Focus();
	                    return false;
	                }
//              else  if (CommonValidation.ValidateIsEmptyString(combobox_wordText.Trim()))
//	                {
//	                   DialogBox.ShowWarningMessage(txtbx_wording.Text + " cannot be empty.");
//	                   txtbx_wording.Focus();
//	                    return false;
//	                }
             else   if (CommonValidation.ValidateIsEmptyString(txtbx_filmsize_micron.Text.Trim()))
	                {
	                    DialogBox.ShowWarningMessage(txtbx_filmsize_micron.Text + " cannot be empty.");
	                    txtbx_filmsize_micron.Focus();
	                    return false;
	                }

              else  if (CommonValidation.ValidateIsEmptyString(txtbx_color.Text.Trim()))
	                {
	                    DialogBox.ShowWarningMessage(txtbx_color.Text + " cannot be empty.");
	                    txtbx_color.Focus();
	                    return false;
	                }
              
              else  if (CommonValidation.ValidateIsEmptyString(txtbx_sizeart.Text.Trim()))
	                {
	                    DialogBox.ShowWarningMessage(txtbx_sizeart.Text + " cannot be empty.");
	                    txtbx_sizeart.Focus();
	                    return false;
	                }
              
              else  if (CommonValidation.ValidateIsEmptyString(txtbx_colorkg.Text.Trim()))
	                {
	                    DialogBox.ShowWarningMessage(txtbx_colorkg.Text + " cannot be empty.");
	                    txtbx_colorkg.Focus();
	                    return false;
	                }
            }
              
              catch (Exception ex)
              {
              	MessageBox.Show("Error" + ex.ToString() + ex.Message);
              }
              
              return true;
            
		}
		
		
		
		
		void Btn_deleteClick(object sender, EventArgs e)
		{
			SqlConnection con_data_del = new SqlConnection(sqlconn);
			System.Data.SqlClient.SqlCommand cmd_data_del = new SqlCommand();
			
			try {
					cmd_data_del.Connection = con_data_del;
					cmd_data_del.CommandText = "SP_PROD_COAT_PRINTING_JOB_ORDER_DEL";
					cmd_data_del.CommandType = CommandType.StoredProcedure;
					
						
    	
						cmd_data_del.Parameters.Add(new SqlParameter("@SP_JODOCNO", SqlDbType. NVarChar, 50)); //create parameter pada sql bwk data SP_RefNumber untuk dihantar semula
						cmd_data_del.Parameters["@SP_JODOCNO"].Value = txtbx_refno.Text.ToUpper();
						
						
						
						cmd_data_del.Parameters.Add(new SqlParameter("@SP_JRSTOCKCODE", SqlDbType.NVarChar, 50));
						cmd_data_del.Parameters["@SP_JRSTOCKCODE"].Value = "POPP";
						
						cmd_data_del.Parameters.Add(new SqlParameter("@SP_JR_STOCKCODE", SqlDbType.NVarChar, 50));
						cmd_data_del.Parameters["@SP_JR_STOCKCODE"].Value = txtbx_stockcode2.Text.ToUpper() ;
						
						
						
						//cmd_data_del.Parameters.Add(new SqlParameter("@SP_JRCOLOR", SqlDbType.NVarChar, 50));
						//cmd_data_del.Parameters["@SP_JRCOLOR"].Value = txtbx_color.Text.ToUpper();  //tukar daripada string kepada nom
						
    						cmd_data_del.Parameters.Add(new SqlParameter("@SP_JRMICRON", SqlDbType.NVarChar, 50));
    						cmd_data_del.Parameters["@SP_JRMICRON"].Value = txtbx_micron.Text.ToUpper();
						
						cmd_data_del.Parameters.Add(new SqlParameter("@SP_JRWIDTH", SqlDbType.NVarChar, 50));
						cmd_data_del.Parameters["@SP_JRWIDTH"].Value = textbx_width.Text.ToUpper();
						
						cmd_data_del.Parameters.Add(new SqlParameter("@SP_JRLENGTH", SqlDbType.NVarChar, 50));
						cmd_data_del.Parameters["@SP_JRLENGTH"].Value =txtbx_length.Text.ToUpper();
						
						
						cmd_data_del.Parameters.Add(new SqlParameter("@SP_JODATE", SqlDbType.DateTime)); //create parameter pada sql bwk data SP_RefNumber untuk dihantar semula
						cmd_data_del.Parameters["@SP_JODATE"].Value = dateTimePicker1.Value;
						
						
						
						//MessageBox.Show(txtbx
						
						//TUKAR QTY ORDERED KEPADA JO JR QTY
					
						
						cmd_data_del.Parameters.Add(new SqlParameter("@SP_JOPPCUSTOMER", SqlDbType.NVarChar, 50));
						cmd_data_del.Parameters["@SP_JOPPCUSTOMER"].Value = txtbx_customer.Text.ToUpper();
						
						
    
    					cmd_data_del.Parameters.Add(new SqlParameter("@SP_JOREMARK1", SqlDbType.NVarChar, 50));
						cmd_data_del.Parameters["@SP_JOREMARK1"].Value = txtbx_remark1.Text.ToUpper();
						
						cmd_data_del.Parameters.Add(new SqlParameter("@SP_JOREMARK", SqlDbType.NVarChar, 50));
						cmd_data_del.Parameters["@SP_JOREMARK"].Value = remark;
						
						cmd_data_del.Parameters.Add(new SqlParameter("@SP_JOREMARK2", SqlDbType.NVarChar, 50));
						cmd_data_del.Parameters["@SP_JOREMARK2"].Value = txtbx_remark2.Text.ToUpper();
						
						cmd_data_del.Parameters.Add(new SqlParameter("@SP_JOREMARK3", SqlDbType.NVarChar, 50));
						cmd_data_del.Parameters["@SP_JOREMARK3"].Value = txtbx_remark3.Text.ToUpper();
						
						cmd_data_del.Parameters.Add(new SqlParameter("@SP_JOREMARK4", SqlDbType.NVarChar, 50));
						cmd_data_del.Parameters["@SP_JOREMARK4"].Value = txtbx_remark4.Text.ToUpper();
						
						cmd_data_del.Parameters.Add(new SqlParameter("@SP_JOREMARK5", SqlDbType.NVarChar, 50));
						cmd_data_del.Parameters["@SP_JOREMARK5"].Value = txtbx_remark5.Text.ToUpper();
						
						
						
						
						
						cmd_data_del.Parameters.Add(new SqlParameter("@SP_JOPPCODE", SqlDbType.NVarChar, 80));
						cmd_data_del.Parameters["@SP_JOPPCODE"].Value =txtbx_code.Text.ToUpper();
						
						cmd_data_del.Parameters.Add(new SqlParameter("@SP_JOPPTOLUNE", SqlDbType.NVarChar, 80));
						cmd_data_del.Parameters["@SP_JOPPTOLUNE"].Value = txtbx_tolune.Text.ToUpper();
 
						cmd_data_del.Parameters.Add(new SqlParameter("@SP_JOPPWording", SqlDbType.NVarChar, 80));
						cmd_data_del.Parameters["@SP_JOPPWording"].Value = combobox_word.Text.ToUpper(); // "-"
						
						cmd_data_del.Parameters.Add(new SqlParameter("@SP_JOPPFilmSize", SqlDbType.NVarChar, 80));
						cmd_data_del.Parameters["@SP_JOPPFilmSize"].Value = "";
						
						cmd_data_del.Parameters.Add(new SqlParameter("@SP_JOPPColor", SqlDbType.NVarChar, 80));
						cmd_data_del.Parameters["@SP_JOPPColor"].Value = txtbx_color.Text.ToUpper();
						
						cmd_data_del.Parameters.Add(new SqlParameter("@SP_JOPPSizeArt", SqlDbType.NVarChar, 80));
						cmd_data_del.Parameters["@SP_JOPPSizeArt"].Value = txtbx_sizeart.Text.ToUpper();
						
						cmd_data_del.Parameters.Add(new SqlParameter("@SP_JOPPColorKG", SqlDbType.NVarChar, 80));
						cmd_data_del.Parameters["@SP_JOPPColorKG"].Value = txtbx_colorkg.Text.ToUpper();
						
						cmd_data_del.Parameters.Add(new SqlParameter("@SP_JOPPColorRemark", SqlDbType.NVarChar, 80));
						cmd_data_del.Parameters["@SP_JOPPColorRemark"].Value = txtbx_color1.Text.ToUpper();
						
						cmd_data_del.Parameters.Add(new SqlParameter("@SP_ISSUEDATE", SqlDbType.DateTime));
						cmd_data_del.Parameters["@SP_ISSUEDATE"].Value = DateTime.Now;
						
						cmd_data_del.Parameters.Add(new SqlParameter("@SP_JOISSUEBY", SqlDbType.NVarChar, 50));
						cmd_data_del.Parameters["@SP_JOISSUEBY"].Value = username.ToUpper();
						
						cmd_data_del.Parameters.Add(new SqlParameter("@SP_FILMMICRON", SqlDbType.NVarChar, 50));
						cmd_data_del.Parameters["@SP_FILMMICRON"].Value = txtbx_filmsize_micron.Text;
						
						cmd_data_del.Parameters.Add(new SqlParameter("@SP_FILMWIDTH", SqlDbType.NVarChar, 50));
						cmd_data_del.Parameters["@SP_FILMWIDTH"].Value = txtbx_filmsize_width.Text;
						
						cmd_data_del.Parameters.Add(new SqlParameter("@SP_FILMLENGTH", SqlDbType.NVarChar, 50));
						cmd_data_del.Parameters["@SP_FILMLENGTH"].Value = txtbx_filmsize_length.Text;
    	
						con_data_del.Open();
						cmd_data_del.ExecuteNonQuery();
						//cmd_data_add.Parameters.Clear();
						
				} 
					
				
				catch (Exception ex) 
				{
						con_data_del.Close();
						MessageBox.Show("ERROR ? " + ex.Message + ex.ToString());
						return;
				} 
				finally 
				{
						con_data_del.Close();
				}
			con_data_del.Dispose();
			con_data_del = null;
			cmd_data_del = null;
			DialogBox.ShowWarningMessage(" SUCCESFULL DELETE");
			checkrunningno = true;
			checkstoreprocedure = true;
			ClearAllText(this);
			txtbx_refno.Text = "0";			
		}
		
		public void Btn_cancelClick(object sender, EventArgs e)
		{
           	this.Close();						
		}
		
//		public void ClearText()
//		{
//			txtbx_refno.Clear();
//			txtbx_code.Clear();
//			txtbx_wording.Clear();
//			txtbx_filmsize.Clear();
//			txtbx_color.Clear();
//			txtbx_sizeart.Clear();
//			txtbx_tolune.Clear();
//			txtbx_colorkg.Clear();
//			txtbx_customer.Clear();
//			
//			txtbx_color1.Clear();
//			txtbx_micron.Clear();
//			textbx_width.Clear();
//			txtbx_length.Clear();
//			txtbx_remark1.Clear();
//			txtbx_remark2.Clear();
//			txtbx_remark3.Clear();
//			txtbx_remark4.Clear();
//			txtbx_remark5.Clear();
//			txtbx_stockcode.Clear();
//			//txtbx_color1.SelectedIndex = 0;
//			
//		}
//		
		void Btn_clearClick(object sender, EventArgs e)
		{
			txtbx_refno.Clear();
			txtbx_code.Clear();
			//combobox_word.Clear();
			txtbx_filmsize_micron.Clear();
			txtbx_color.Clear();
			txtbx_sizeart.Clear();
			txtbx_tolune.Clear();
			txtbx_colorkg.Clear();
			txtbx_customer.Clear();
			
			txtbx_color1.Clear();
			txtbx_micron.Clear();
			textbx_width.Clear();
			txtbx_length.Clear();
			txtbx_remark1.Clear();
			txtbx_remark2.Clear();
			txtbx_remark3.Clear();
			txtbx_remark4.Clear();
			txtbx_remark5.Clear();
			txtbx_stockcode.Clear();
			//txtbx_color1.SelectedIndex = 0;
			combobox_word.Text = "Please, select any value";
			checkrunningno = true;
			checkstoreprocedure = true;
			txtbx_stockcode.Text = "POPP";
			txtbx_refno.Text = "0";
			
		}
		
		
		
		void Btn_retrieveClick(object sender, EventArgs e)
		{
			checkstoreprocedure = false;
			checkrunningno = false;
			
			btn_delete.Visible = true;
			btn_save.Visible = true;
			
			
			SqlConnection con_SP1 = new SqlConnection(sqlconn);
			SqlCommand cmd_SP1 = new SqlCommand();
			
			
			if (txtbx_refno.Text == null | txtbx_refno.Text == string.Empty) 
			{
        		MessageBox.Show("Please key-in Ref No");
				return;
			}
			
			//SqlConnection con_SP1 = new SqlConnection(sqlconn);
			//SqlCommand cmd_SP1 = new SqlCommand();
			
			try 
			{
				cmd_SP1.CommandText = "select * from TBL_PROD_COAT_PRINTING_JOB_ORDER where JODOCNO = '" + txtbx_refno.Text + "'";
				cmd_SP1.Connection = con_SP1;
				con_SP1.Open();
				SqlDataReader rd_SP1 = cmd_SP1.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
				
				if (rd_SP1.Read())
				{
					
		
						txtbx_refno.Text = rd_SP1["JODOCNO"].ToString();
						txtbx_code.Text = rd_SP1["JOPPCODE"].ToString();
						combobox_word.Text = rd_SP1["JOPPWORDING"].ToString(); 
						txtbx_filmsize_micron.Text = rd_SP1["FILMMICRON"].ToString();
						txtbx_filmsize_width.Text = rd_SP1["FILMWIDTH"].ToString();
						txtbx_filmsize_length.Text = rd_SP1["FILMLENGTH"].ToString();
						
						
						txtbx_color.Text = rd_SP1["JOPPColor"].ToString();
						txtbx_sizeart.Text = rd_SP1["JOPPSizeArt"].ToString();
						txtbx_tolune.Text = rd_SP1["JOPPTOLUNE"].ToString();
						txtbx_colorkg.Text = rd_SP1["JOPPColorKG"].ToString();
						txtbx_remark1.Text = rd_SP1["JOREMARK1"].ToString();
						txtbx_remark2.Text = rd_SP1["JOREMARK2"].ToString();
						txtbx_remark3.Text = rd_SP1["JOREMARK3"].ToString();
						txtbx_remark4.Text = rd_SP1["JOREMARK4"].ToString();
						txtbx_remark5.Text = rd_SP1["JOREMARK5"].ToString();
						txtbx_color1.Text = rd_SP1["JOPPColorRemark"].ToString();
						txtbx_stockcode.Text = rd_SP1["JRSTOCKCODE"].ToString();
						txtbx_micron.Text = rd_SP1["JRMICRON"].ToString();
						//txtbx_customer.Text = rd_SP1["JOCUSTOMER"].ToString();
						txtbx_customer.Text = rd_SP1["JOPPCUSTOMER"].ToString();						
						textbx_width.Text = rd_SP1["JRWIDTH"].ToString();
						txtbx_length.Text = rd_SP1["JRLENGTH"].ToString();
						txtbx_stockcode2.Text = rd_SP1["JR_STOCKCODE"].ToString();
						

					dateTimePicker1.Value = Convert.ToDateTime(rd_SP1["JODATE"]);
					dateTimePicker1.Text = rd_SP1["JODATE"].ToString();
				
						
    					//txtbx_jrm2.Text = rd_SP1["JOJRM2"].ToString();
						
						
    					
    					
    					//combo_box3.Text = rd_SP1["JOJRCATEGORY"].ToString();
						//combo_box3.SelectedValue = rd_SP1["JOJRCATEGORY"].ToString();
//--------------------------------------------------------------------------------------------
					dateTimePicker1.Text = rd_SP1["JODATE"].ToString();
					//dateTimePicker1.Value  = rd_SP1["@SP_JOUSERDATETIME"].ToString();
					
					
					//combo_box3.Text = rd_SP1["JOFILMCODE"].ToString();
					//combo_box3.SelectedValue  = rd_SP1["JOFILMCODE"].ToString();
					//combo_box3.Text = rd_SP1["JOFILMCODE"].ToString();
					username = rd_SP1["JOISSUEBY"].ToString();
					
					
//--------------------------------------------------------------------------------------------			
				} 
				else 
				{
					MessageBox.Show("Error Edit : Cannot find JO!");
					return;
				}
			} 
			catch (Exception ex) 
			{
				MessageBox.Show("Error Edit : Cannot load DB!" + ex.Message + ex.ToString());
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
		
		
			public void BOPPFilmList()
		{
			string sqlStatement = "select combobox_word from TBL_PROD_COAT_PRINTING_BOM";
			SqlConnection sqlConn = new SqlConnection(sqlconn);
			DataSet ds = new DataSet();
			SqlDataAdapter sda = new SqlDataAdapter(sqlStatement, sqlConn);
					
			try 
			{
						
				sqlConn.Open();
				sda.Fill(ds);
				combobox_word.Text = "Please Select";
						

			}
			catch (Exception exc) 
			{
					DialogBox.ShowWarningMessage("An error occured while connecting to database" + exc.Message+ exc.ToString());
					sqlConn.Close();
					sqlConn.Dispose();
					return;
			} 
			finally 
			{
					sqlConn.Close();
					sqlConn.Dispose();
			}
		
			foreach(DataRow dr1 in ds.Tables[0].Rows)
			{
				combobox_word.Items.Add(dr1["JOPPWORDING"].ToString());
			}
				
		}
			
			
			
			
		
		
		void Combobox_wordSelectedIndexChanged(object sender, EventArgs e)
		{
			string combine_micron_width_length;
			SqlConnection con = new SqlConnection(sqlconn);
			string sqlStatement = "select JOPPREFNO, JOPPCOLOR, JOPPMICRON, JOPPWIDTH, JOPPLENGTH, JOPPCUSTOMER, JOPPCOLORKG from TBL_PROD_COAT_PRINTING_BOM where JOPPWORDING = '"+combobox_word.Text+"'";
			SqlCommand cmd = new SqlCommand( sqlStatement,con);
			SqlDataReader dbr;
			try
			{
				con.Open();
				dbr = cmd.ExecuteReader();
				while(dbr.Read())
				{
//					int stockwidth = (string) dbr["ID"].tostring;
//					int  = (string) dbr["name"] // name is string value
//					string ssurname = (string) dbr["surname"]
//					string sage = (string) dbr["age"].tostring;
					//txtbx_refno.Text = (string) dbr ["JOPPREFNO"].ToString();
					//film_mic =  dbr["JOPPMICRON"].ToString();
					//film_width = dbr["JOPPWIDTH"].ToString();
					//film_length = dbr["JOPPLENGTH"].ToString();
					
					
					
					txtbx_code.Text = (string) dbr ["JOPPREFNO"].ToString();
					
					combine_micron_width_length = (string) dbr["JOPPMICRON"].ToString() + "MIC    X    " + dbr["JOPPWIDTH"].ToString()+ "MM   X   " + dbr["JOPPLENGTH"].ToString() + "M";
					txtbx_filmsize_micron.Text = (string) dbr["JOPPMICRON"].ToString(); 
					txtbx_filmsize_width.Text = (string) dbr["JOPPWIDTH"].ToString();
					txtbx_filmsize_length.Text = (string) dbr["JOPPLENGTH"].ToString();
					txtbx_color.Text = (string) dbr["JOPPCOLOR"].ToString();
					txtbx_customer.Text = (string) dbr["JOPPCUSTOMER"].ToString();
					txtbx_colorkg.Text = (string) dbr["JOPPCOLORKG"].ToString();
					
					
					
			
				}
			}
			catch(Exception es)
			{
				MessageBox.Show("Error" + es.Message + es.ToString());
			}
		}
		
		
		void datagrid()
		{
			string sql = "SELECT * FROM TBL_PROD_COAT_PRINTING_BOM";
            SqlConnection connection = new SqlConnection(sqlconn);
            SqlDataAdapter dataadapter = new SqlDataAdapter(sql, connection);
            DataTable ds = new DataTable();
            connection.Open();
            dataadapter.Fill(ds);
                     
            DataTable tempDT = new DataTable();
  			tempDT = ds.DefaultView.ToTable(true,"JOPPREFNO", "JOPPWORDING", "JOPPCOLOR", "JOPPMICRON", "JOPPWIDTH", "JOPPLENGTH", "JOPPCOLORKG", "JOPPCUSTOMER");
   			dataGridView1.DataSource = tempDT;
   
  			connection.Close();

   			dataGridView1.Columns[0].HeaderText = "Ref No";
   			dataGridView1.Columns[1].HeaderText = "Wording";
  			dataGridView1.Columns[2].HeaderText = "Color";
   			dataGridView1.Columns[3].HeaderText = "Micron";
   			dataGridView1.Columns[4].HeaderText = "Width";
   			dataGridView1.Columns[5].HeaderText = "Length";
   			dataGridView1.Columns[6].HeaderText = "Color/Kg";
   			dataGridView1.Columns[7].HeaderText = "Customer";
		}
		
	
		
		
		
		void Frm_prod_coating_jo_printingLoad(object sender, EventArgs e)
		{
			//txtbx_refno.Enabled = false;
			txtbx_stockcode.Text = "POPP";
			txtbx_refno.Text = "0";
		}
		
		void DataGridView1CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
			 	   txtbx_code.Text = dataGridView1.SelectedRows[0].Cells[0].Value + string.Empty;
			       combobox_word.Text = dataGridView1.SelectedRows[0].Cells[1].Value + string.Empty;
			       txtbx_color.Text = dataGridView1.SelectedRows[0].Cells[2].Value + string.Empty;
			       txtbx_filmsize_micron.Text = dataGridView1.SelectedRows[0].Cells[3].Value + string.Empty;
			       txtbx_filmsize_width.Text = dataGridView1.SelectedRows[0].Cells[4].Value + string.Empty;
			       txtbx_filmsize_length.Text = dataGridView1.SelectedRows[0].Cells[5].Value + string.Empty;
			       txtbx_colorkg.Text = dataGridView1.SelectedRows[0].Cells[6].Value + string.Empty;
			       txtbx_customer.Text = dataGridView1.SelectedRows[0].Cells[7].Value + string.Empty;
			
		}
		
		void Txtxbx_searchTextChanged(object sender, EventArgs e)
		{
			//string sql = "SELECT * FROM TBL_PROD_COAT_PRINTING_BOM";
            SqlConnection connection2 = new SqlConnection(sqlconn);
           // SqlDataAdapter dataadapter = new SqlDataAdapter(sql, connection2);
           // DataTable ds2 = new DataTable();
         	connection2.Open();
            //dataadapter.Fill(ds2);
            
            
		
			SqlDataAdapter da = new SqlDataAdapter("Select JOPPREFNO, JOPPWORDING, JOPPCOLOR, JOPPMICRON, JOPPWIDTH, JOPPLENGTH, JOPPCOLORKG, JOPPCUSTOMER from TBL_PROD_COAT_PRINTING_BOM Where JOPPWORDING like '" +  txtxbx_search.Text + "%'",connection2);
			DataTable dt2 = new DataTable();
			da.Fill(dt2);
			dataGridView1.DataSource= dt2;
			dataGridView1.Refresh();
			connection2.Close();

		}
	}
}