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
using System.IO;
using fyiReporting.RdlViewer;
using fyiReporting;
using System.Linq;

namespace AX2020
{
	/// <summary>
	/// Description of frm_prod_ribbon2.
	/// </summary>
	public partial class frm_prod_ribbon2_output : Form
	{
		
		
		public static string sqlconn = "Server=AX-UAT; Password=sbax2020sbg; User ID=sbax2020; Initial Catalog=SBG_AX_2020; Integrated Security=false";
		
		public static string sqlconn3 = "Server=AX-SQL; Password=ax2020sbgroup; User ID=ax2020sb; Initial Catalog=AX2020StagingDB; Integrated Security=false";
		DateTime issue_date;
		string username, issued_jo_by;
		string Fin_Next_No;
		public static string SetValueForText2 = "";
		public frm_prod_ribbon2_output()
		{

			InitializeComponent();
			helper_name();
			operator_name();
			machine_name();
			username = frm_menu_system.userName; 
			lbl_username.Text = username;
			ControlBox = false;
			disable_textbox();
			display_datagrid();
			
			
		}
		
		
		
		void Btn_sbtiClick(object sender, EventArgs e)
		{
			if (txtbx_joso.Text == null || txtbx_joso.Text == string.Empty) 
				{						
				MessageBox.Show("EMPTY  SO " );//+ ex.Message + ex.ToString());//Lbl_Message.Text = "Error? SO?";
				return;
				}
										
			else if (txtbx_soline.Text == null || txtbx_soline.Text == string.Empty) 
				{
				MessageBox.Show("EMPTY SO Line ");// + ex.Message + ex.ToString());//Lbl_Message.Text = "Error? SO Line?";
				return;
				}
			txtbx_refno.Text = txtbx_joso.Text + txtbx_soline.Text;
			check_dulicate_so();
			read_data_db();
			
			if(txtbx_item_code.Text.Substring(0,1) == "P")
			{
				txtbx_prod_type.Text = "PP";
			}
								
			else
			{
				txtbx_prod_type.Text = "FF";
			}
			
			
			
		}
		
		
		void read_data_db()
		{
			string ERP_P1_objSqlStatement = "select a.SALESID,a.NOTESINTERNAL, a.NOTESEXTERNAL, a.NOTESSHIPPINGLABEL, a.SALESNAME, a.DELIVERYNAME, b.CUSTGROUP, b.LINENUM, b.SALESID, b.ITEMID, b.SALESQTY, b.NAME, b.QTYORDERED, b.DOT_PRODATTRIBBRAND,b.DOT_PRODATTRIBCOLOR,b.DOT_PRODATTRIBLENGTH, b.DOT_PRODATTRIBMICRON, b.DOT_PRODATTRIBWIDTH, b.SALESUNIT, b.DOT_PRODATTRIBNETWEIGHT  from VIEW_AXERP_SO a, VIEW_AXERP_SO_DETAIL b where  a.SALESID = b.SALESID  and a.SALESID = '" + txtbx_joso.Text.ToUpper() + "' and b.LINENUM = '" + txtbx_soline.Text.ToUpper() + "' order by b.LINENUM";
					SqlConnection ERP_P1_objConn = new SqlConnection(sqlconn3);
					
					try 
					{
						
						ERP_P1_objConn.Open();
						SqlCommand ERP_P1_objCMD = new SqlCommand(ERP_P1_objSqlStatement, ERP_P1_objConn);
						SqlDataReader ERP_P1_objDR = ERP_P1_objCMD.ExecuteReader();
					
						
						if (ERP_P1_objDR.HasRows)
						{
							while (ERP_P1_objDR.Read()) 
							{
						//====================================================================================================================================================================================================================================================================================
								 string SOStockCode = ERP_P1_objDR["ITEMID"].ToString().ToUpper();
								txtbx_item_code.Text = ERP_P1_objDR["ITEMID"].ToString().ToUpper();
								txtbx_joso.Text = ERP_P1_objDR["SALESID"].ToString().ToUpper();
								txtbx_customer.Text = ERP_P1_objDR["DELIVERYNAME"].ToString().ToUpper();
								txtbx_sodesc1.Text = ERP_P1_objDR["NAME"].ToString().ToUpper();
								//txtbx_sodesc2.Text = ERP_P1_objDR["tdesc2"].ToString().ToUpper();
								txtbx_micron.Text = ERP_P1_objDR["DOT_PRODATTRIBMICRON"].ToString().ToUpper();
								txtbx_rbn_width.Text = ERP_P1_objDR["DOT_PRODATTRIBWIDTH"].ToString().ToUpper();
								txtbx_rbn_length.Text = ERP_P1_objDR["DOT_PRODATTRIBLENGTH"].ToString().ToUpper();
								
//---------------------------------------------------------------------------------------------------------------------------------------------------------------------------
							
								txtbx_sodesc2.Text = ERP_P1_objDR["DOT_PRODATTRIBBRAND"].ToString();
								txtbx_roll_ctn.Text = ERP_P1_objDR["QTYORDERED"].ToString();
								//txtbx_customertype.Text = ERP_P1_objDR["CUSTGROUP"].ToString();
								//netweight = ERP_P1_objDR["DOT_PRODATTRIBNETWEIGHT"].ToString();
								//MessageBox.Show(netweight.ToString());
						
								

								
								
								
							
				
									
							  //  MessageBox.Show(letter1.ToString());
//-----------------------------------------------------------------------------------------------------------------------------------------------

//-----------------------------------------------------------------------------------------------------------------------------------------------
								if (ERP_P1_objDR["DOT_PRODATTRIBCOLOR"].ToString() == null || ERP_P1_objDR["DOT_PRODATTRIBCOLOR"].ToString() == string.Empty)
								{
									txtbx_colour.Text = "-";
									MessageBox.Show("Error? SO Color?");
									return;
								} 
								else
								{
									txtbx_colour.Text = ERP_P1_objDR["DOT_PRODATTRIBCOLOR"].ToString();
								}
								
								
				
							
								
								
	
//=======================================================================================================================================================================================================================================================================================================		 
					}
						
					}
						 
						// TxtBx_JRColor1.Text = txtbx_colour.Text;
						 
						 //txtbx_remark1.Text = txtbx_socustomer.Text;
					}
		
					catch (Exception ERP_P1_exc) 
					{
						DialogBox.ShowWarningMessage("Error 2: Cannot read  DB" +ERP_P1_exc.Message+ ERP_P1_exc.ToString());//Lbl_Message.Text = "Error 2: Cannot read  DB" + ERP_P1_exc.ToString + ERP_P1_exc.Message;
						ERP_P1_objConn.Close();
						ERP_P1_objConn.Dispose();
						return;
					} 
					finally 
					{
						ERP_P1_objConn.Close();
						ERP_P1_objConn.Dispose();
					}
		
				
				
					ERP_P1_objConn = null;
					ERP_P1_objSqlStatement = null;
		}
		
		private bool Validation()
		{
			try
			{
				if (cbx_helper.Text =="Please Select" || cbx_helper.Text =="PLEASE SELECT")
	                {
	                    DialogBox.ShowWarningMessage(" cannot be empty");
	                    cbx_helper.Focus();
	                    return false;
	                }
				
				
			else if (cbx_operator.Text =="Please Select" || cbx_operator.Text =="PLEASE SELECT")
	                {
	                    DialogBox.ShowWarningMessage(" cannot be empty");
	                    cbx_operator.Focus();
	                    return false;
	                }
			
			
			else if (cbx_machine.Text =="Please Select" || cbx_machine.Text =="PLEASE SELECT")
	                {
	                    DialogBox.ShowWarningMessage(" cannot be empty");
	                    cbx_machine.Focus();
	                    return false;
	                }
			
			
			
			 else  if (CommonValidation.ValidateIsEmptyString(txtbx_ctn_prd.Text.Trim()))
	                {
	                    DialogBox.ShowWarningMessage(txtbx_ctn_prd.Text + " cannot be empty.");
	                    txtbx_ctn_prd.Focus();
	                    return false;
	                }
			 
			 
			  else  if (CommonValidation.ValidateIsEmptyString(txbx_roll_prd.Text.Trim()))
	                {
	                    DialogBox.ShowWarningMessage(txbx_roll_prd.Text + " cannot be empty.");
	                    txbx_roll_prd.Focus();
	                    return false;
	                }
			 
			   
			 
			}
			 catch
			 {
			 	;
			 }
			 
			 return true;
			
			
		}
		
		
		void check_dulicate_so()
		{
			SqlConnection con_Check_Duplicate_JO = new SqlConnection(sqlconn);
			SqlCommand cmd = new SqlCommand();

			try {
				cmd.CommandText = "select * from TBL_PROD_RIBBON where SO_NUMBER = '" + txtbx_joso.Text.ToUpper() + "' and SO_LINENO = '"  + txtbx_soline.Text.ToUpper() + "'";
				cmd.Connection = con_Check_Duplicate_JO;
				con_Check_Duplicate_JO.Open();
				SqlDataReader rd_Check_Duplicate_JO = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
					
					if (rd_Check_Duplicate_JO.Read())
							{
								if (rd_Check_Duplicate_JO.HasRows) 
									{
										MessageBox.Show("Duplicate JO");//Lbl_Message.Text = "Error 1.0 : Duplicate JO! ";
										return;
									}
							}
				} 
				catch (Exception ex) 
					{
						con_Check_Duplicate_JO.Close();
						MessageBox.Show("Error 2.0 : Duplicate JO!" + ex.ToString() + ex.Message);
						return;
					} 
					
				finally 
					{
						con_Check_Duplicate_JO.Close();
					}
								
						con_Check_Duplicate_JO.Dispose();
						cmd.Dispose();
						con_Check_Duplicate_JO = null;
						cmd = null;
							
		}
		
		
		
		void Btn_saveClick(object sender, EventArgs e)
		{
			
			if(!Validation())
				return;

			SqlConnection con_data_add = new SqlConnection(sqlconn);
			System.Data.SqlClient.SqlCommand cmd_data_add = new SqlCommand(); 
			try 
			{
				cmd_data_add.Connection = con_data_add;		
				cmd_data_add.CommandText = "SP_PROD_RIBBON_ADD";
				cmd_data_add.CommandType = CommandType.StoredProcedure;	
							
				cmd_data_add.Parameters.Add(new SqlParameter("@SP_SO_NUMBER", SqlDbType. NVarChar, 50)); 
				cmd_data_add.Parameters["@SP_SO_NUMBER"].Value = txtbx_joso.Text.ToUpper();
				
				cmd_data_add.Parameters.Add(new SqlParameter("@SP_SO_LINENO", SqlDbType. Int)); 
				cmd_data_add.Parameters["@SP_SO_LINENO"].Value = Convert.ToInt32(txtbx_soline.Text);
				
				
				cmd_data_add.Parameters.Add(new SqlParameter("@SP_JO_NO", SqlDbType. NVarChar, 50)); //create parameter pada sql bwk data SP_RefNumber untuk dihantar semula
				cmd_data_add.Parameters["@SP_JO_NO"].Value = txtbx_refno.Text.ToUpper();
						
				cmd_data_add.Parameters.Add(new SqlParameter("@SP_ITEM_ID", SqlDbType.NVarChar, 50));
				cmd_data_add.Parameters["@SP_ITEM_ID"].Value = txtbx_item_code.Text.ToUpper();
						
				cmd_data_add.Parameters.Add(new SqlParameter("@SP_TYPE_ITEM", SqlDbType.NVarChar, 5));
				cmd_data_add.Parameters["@SP_TYPE_ITEM"].Value = txtbx_prod_type.Text.ToUpper();
						
				cmd_data_add.Parameters.Add(new SqlParameter("@SP_CUSTOMER_NAME", SqlDbType.NVarChar, 100));
				cmd_data_add.Parameters["@SP_CUSTOMER_NAME"].Value= txtbx_customer.Text.ToUpper();  //tukar daripada string kepada nombor
						
				cmd_data_add.Parameters.Add(new SqlParameter("@SP_DESCRIPTION1", SqlDbType.NVarChar, 350));
				cmd_data_add.Parameters["@SP_DESCRIPTION1"].Value = txtbx_sodesc1.Text.ToUpper();  //tukar daripada string kepada nom
						
    			cmd_data_add.Parameters.Add(new SqlParameter("@SP_DESCRIPTION2", SqlDbType.NVarChar, 200));
				cmd_data_add.Parameters["@SP_DESCRIPTION2"].Value= txtbx_sodesc2.Text.ToUpper(); 
						
				cmd_data_add.Parameters.Add(new SqlParameter("@SP_WIDTH", SqlDbType.Int));
				cmd_data_add.Parameters["@SP_WIDTH"].Value= Convert.ToInt32(txtbx_rbn_width.Text);
				
				cmd_data_add.Parameters.Add(new SqlParameter("@SP_LENGTH", SqlDbType.Int));
				cmd_data_add.Parameters["@SP_LENGTH"].Value= Convert.ToInt32(txtbx_rbn_length.Text);
						
				cmd_data_add.Parameters.Add(new SqlParameter("@SP_MICRON", SqlDbType.Int));
				cmd_data_add.Parameters["@SP_MICRON"].Value = Convert.ToInt32(txtbx_micron.Text);
						
				cmd_data_add.Parameters.Add(new SqlParameter("@SP_ROLL_CTN", SqlDbType.Float));
				cmd_data_add.Parameters["@SP_ROLL_CTN"].Value= Math.Round(Convert.ToDouble(txtbx_roll_ctn.Text),0);
						
				cmd_data_add.Parameters.Add(new SqlParameter("@SP_COLOR", SqlDbType. NVarChar, 10));
				cmd_data_add.Parameters["@SP_COLOR"].Value = txtbx_colour.Text;
						
				
						
				cmd_data_add.Parameters.Add(new SqlParameter("@SP_QTY_ORDER_CTN", SqlDbType.Int));
				cmd_data_add.Parameters["@SP_QTY_ORDER_CTN"].Value = Convert.ToInt32(txtbx_ctn_odr.Text);
						
				cmd_data_add.Parameters.Add(new SqlParameter("@SP_QTY_ORDER_ROLL", SqlDbType. Int));
				cmd_data_add.Parameters["@SP_QTY_ORDER_ROLL"].Value = Convert.ToInt32(txtbx_roll_odr.Text);
							
    			cmd_data_add.Parameters.Add(new SqlParameter("@SP_DATE_PRODUCTION", SqlDbType. DateTime));
				cmd_data_add.Parameters["@SP_DATE_PRODUCTION"].Value = dtp_production.Value;
						
				cmd_data_add.Parameters.Add(new SqlParameter("@SP_OPERATOR", SqlDbType.NVarChar, 100));
				cmd_data_add.Parameters["@SP_OPERATOR"].Value = cbx_operator.Text.ToUpper(); 
				
						
				cmd_data_add.Parameters.Add(new SqlParameter("@SP_QTY_PRODUCE_CTN", SqlDbType.Int));
				cmd_data_add.Parameters["@SP_QTY_PRODUCE_CTN"].Value = Convert.ToInt32(txtbx_ctn_prd.Text);
						
				cmd_data_add.Parameters.Add(new SqlParameter("@SP_QTY_PRODUCE_ROLL", SqlDbType. Int));
				cmd_data_add.Parameters["@SP_QTY_PRODUCE_ROLL"].Value = Convert.ToInt32(txbx_roll_prd.Text);
						
				cmd_data_add.Parameters.Add(new SqlParameter("@SP_MACHINE_NO", SqlDbType.NVarChar, 20));
				cmd_data_add.Parameters["@SP_MACHINE_NO"].Value = cbx_machine.Text.ToUpper();
						
				cmd_data_add.Parameters.Add(new SqlParameter("@SP_HELPER", SqlDbType.NVarChar, 100));
				cmd_data_add.Parameters["@SP_HELPER"].Value = cbx_helper.Text.ToUpper();

				cmd_data_add.Parameters.Add(new SqlParameter("@SP_ISSUE_DATE", SqlDbType.DateTime));
				cmd_data_add.Parameters["@SP_ISSUE_DATE"].Value = DateTime.Now;
    	
    			cmd_data_add.Parameters.Add(new SqlParameter("@SP_DELIVERY_DATE", SqlDbType.DateTime));
    			cmd_data_add.Parameters["@SP_DELIVERY_DATE"].Value = dtp_delivery.Value;
					
    			cmd_data_add.Parameters.Add(new SqlParameter("@SP_ISSUED_BY", SqlDbType. NVarChar));
				cmd_data_add.Parameters["@SP_ISSUED_BY"].Value = issued_jo_by;
						
			

				con_data_add.Open();
				cmd_data_add.ExecuteNonQuery();
				//cmd_data_add.Parameters.Clear();
						
						
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
			
			SetValueForText2 = txtbx_refno.Text;
			
			
			//MessageBox.Show(SetValueForText2.ToString());
			//frm_prod_ribbon2_print
			
			
			frm_prod_ribbon2_print2 obj_ribbon2 = new frm_prod_ribbon2_print2();
			obj_ribbon2.ShowDialog();
			//SetValueForText2 = txtbx_refno.Text;
			this.ClearTextBoxes(this);
		}
		
		void Btn_cancelClick(object sender, EventArgs e)
		{
			this.Close();
		}
		
		void Btn_clearClick(object sender, EventArgs e)
		{
			this.ClearTextBoxes(this);
			
		}
		
		private void ClearTextBoxes(Control control)
			{
				foreach (Control c in control.Controls)
				{
					var box = c as TextBox;
					var box2 = c as ComboBox;
					DateTimePicker myPicker = c as DateTimePicker;
					
					
					if (box != null)
					{
						box.Text = string.Empty;
					}
					
					if (box2 != null)
					{
						box2.Text = "Please Select";
					}
					
					if(myPicker != null)
					{
						myPicker.Value = DateTime.Now;
					}
					
					
					
					
					this.ClearTextBoxes(c);
				}
			}
		
		
		public void operator_name()
		{
			string sqlStatement = "select OPERATOR_NAME from TBL_PROD_RIBBON_OPERATOR_NAME";
			SqlConnection sqlConn = new SqlConnection(sqlconn);
			DataSet ds = new DataSet();
			SqlDataAdapter sda = new SqlDataAdapter(sqlStatement, sqlConn);
					
			try 
			{
						
				sqlConn.Open();
				sda.Fill(ds);
				cbx_operator.Text = "Please Select";
						

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
				cbx_operator.Items.Add(dr1["OPERATOR_NAME"].ToString());
			}
				
		}
		
		public void helper_name()
		{string sqlStatement = "select HELPER_NAME from TBL_PROD_RIBBON_HELPER_NAME";
			SqlConnection sqlConn = new SqlConnection(sqlconn);
			DataSet ds = new DataSet();
			SqlDataAdapter sda = new SqlDataAdapter(sqlStatement, sqlConn);
					
			try 
			{
						
				sqlConn.Open();
				sda.Fill(ds);
				cbx_helper.Text = "Please Select";
						

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
				cbx_helper.Items.Add(dr1["HELPER_NAME"].ToString());
			}
			
		}
		
		
		
		
		public void machine_name()
		{string sqlStatement = "select MACHINE_NAME from TBL_PROD_RIBBON_MACHINE_NAME";
			SqlConnection sqlConn = new SqlConnection(sqlconn);
			DataSet ds = new DataSet();
			SqlDataAdapter sda = new SqlDataAdapter(sqlStatement, sqlConn);
					
			try 
			{
						
				sqlConn.Open();
				sda.Fill(ds);
				cbx_machine.Text = "Please Select";
						

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
				cbx_machine.Items.Add(dr1["MACHINE_NAME"].ToString());
			}
			
		}
		
		
//		public void NextNumberRetrieve()
//		{
//			int NextNo ;
//			
//						NextNo = 0;
////************************************************************************************************************************
//						SqlConnection conNextNumber = new SqlConnection(sqlconn);
//						SqlCommand cmdNextNumber = new SqlCommand();
//						try {
//							cmdNextNumber.CommandText = "Select * from TBL_ADMIN_NEXT_NUMBER";
//							cmdNextNumber.Connection = conNextNumber;
//							conNextNumber.Open();
//							SqlDataReader rdNextNumber = cmdNextNumber.ExecuteReader(System.Data.CommandBehavior.CloseConnection); //UNTUK BACA DATA DALAM TABLE
//							rdNextNumber.Read();
//							NextNo = Convert.ToInt32(rdNextNumber["ProdRibbonNextNumber_R1"].ToString());
//							
//						} 
//						
//						
//						catch (Exception ex) 
//						
//						{
//							MessageBox.Show("ERROR NEXT NUMBER!" + ex.ToString() + ex.Message);
//							NextNo = 0;
//							return;
//							
//						} 
//						
//						finally
//						{
//							conNextNumber.Close();
//						}
//						conNextNumber.Dispose();
//						conNextNumber = null;
//						cmdNextNumber = null;
//						//************************************************************************************************************************
//						SqlConnection conUpdateNextNumber = new SqlConnection(sqlconn);
//						System.Data.SqlClient.SqlCommand cmdUpdateNextNumber = new SqlCommand();
//						try {
//							cmdUpdateNextNumber.CommandText = "update TBL_ADMIN_NEXT_NUMBER set ProdRibbonNextNumber_R1 = ProdRibbonNextNumber_R1 + 1";
//							cmdUpdateNextNumber.Connection = conUpdateNextNumber;
//							conUpdateNextNumber.Open();
//							cmdUpdateNextNumber.ExecuteNonQuery();
//						}
//						catch (Exception ex)
//						{
//							conUpdateNextNumber.Close();
//							MessageBox.Show("Error Update Next Number!" + ex.ToString() + ex.Message); 
//							return;
//						}
//						finally 
//						{
//							conUpdateNextNumber.Close();
//						}
//						conUpdateNextNumber.Dispose();
//						conUpdateNextNumber = null;
//						cmdUpdateNextNumber = null;
//						//************************************************************************************************************************
//						//************************************************************************************************************************
//						
//						Fin_Next_No = txtbx_joso.Text+ "-" + txtbx_soline.Text + "-" + NextNo;
//			
//						//************************************************************************************************************************
//						
//						
//						//MessageBox.Show(NextNo.ToString());
//		}
		
		void Btn_deleteClick(object sender, EventArgs e)
		{
			SqlConnection con_data_del = new SqlConnection(sqlconn);
			System.Data.SqlClient.SqlCommand cmd_data_del = new SqlCommand(); 
			try 
			{
				cmd_data_del.Connection = con_data_del;		
				cmd_data_del.CommandText = "SP_PROD_RIBBON_DEL";
				cmd_data_del.CommandType = CommandType.StoredProcedure;	
							
				cmd_data_del.Parameters.Add(new SqlParameter("@SP_SO_NUMBER", SqlDbType. NVarChar, 50)); 
				cmd_data_del.Parameters["@SP_SO_NUMBER"].Value = txtbx_joso.Text.ToUpper();
				
				cmd_data_del.Parameters.Add(new SqlParameter("@SP_SO_LINENO", SqlDbType. Int)); 
				cmd_data_del.Parameters["@SP_SO_LINENO"].Value = Convert.ToInt32(txtbx_soline.Text);
				
				
				cmd_data_del.Parameters.Add(new SqlParameter("@SP_JO_NO", SqlDbType. NVarChar, 50)); //create parameter pada sql bwk data SP_RefNumber untuk dihantar semula
				cmd_data_del.Parameters["@SP_JO_NO"].Value = txtbx_refno.Text.ToUpper();
						
				cmd_data_del.Parameters.Add(new SqlParameter("@SP_ITEM_ID", SqlDbType.NVarChar, 50));
				cmd_data_del.Parameters["@SP_ITEM_ID"].Value = txtbx_item_code.Text.ToUpper();
						
				cmd_data_del.Parameters.Add(new SqlParameter("@SP_TYPE_ITEM", SqlDbType.NVarChar, 5));
				cmd_data_del.Parameters["@SP_TYPE_ITEM"].Value = txtbx_prod_type.Text.ToUpper();
						
				cmd_data_del.Parameters.Add(new SqlParameter("@SP_CUSTOMER_NAME", SqlDbType.NVarChar, 100));
				cmd_data_del.Parameters["@SP_CUSTOMER_NAME"].Value= txtbx_customer.Text.ToUpper();
						
				cmd_data_del.Parameters.Add(new SqlParameter("@SP_DESCRIPTION1", SqlDbType.NVarChar, 350));
				cmd_data_del.Parameters["@SP_DESCRIPTION1"].Value = txtbx_sodesc1.Text.ToUpper();  
						
    				cmd_data_del.Parameters.Add(new SqlParameter("@SP_DESCRIPTION2", SqlDbType.NVarChar, 200));
				cmd_data_del.Parameters["@SP_DESCRIPTION2"].Value= txtbx_sodesc2.Text.ToUpper(); 
						
				cmd_data_del.Parameters.Add(new SqlParameter("@SP_WIDTH", SqlDbType.Int));
				cmd_data_del.Parameters["@SP_WIDTH"].Value= Convert.ToInt32(txtbx_rbn_width.Text);
				
				cmd_data_del.Parameters.Add(new SqlParameter("@SP_LENGTH", SqlDbType.Int));
				cmd_data_del.Parameters["@SP_LENGTH"].Value= Convert.ToInt32(txtbx_rbn_length.Text);
						
				cmd_data_del.Parameters.Add(new SqlParameter("@SP_MICRON", SqlDbType.Int));
				cmd_data_del.Parameters["@SP_MICRON"].Value = Convert.ToInt32(txtbx_micron.Text);
						
				cmd_data_del.Parameters.Add(new SqlParameter("@SP_ROLL_CTN", SqlDbType.Float));
				cmd_data_del.Parameters["@SP_ROLL_CTN"].Value= Convert.ToDouble(txtbx_roll_ctn.Text);
						
				cmd_data_del.Parameters.Add(new SqlParameter("@SP_COLOR", SqlDbType. NVarChar, 10));
				cmd_data_del.Parameters["@SP_COLOR"].Value = txtbx_colour.Text;
						
				
						
				cmd_data_del.Parameters.Add(new SqlParameter("@SP_QTY_ORDER_CTN", SqlDbType.Int));
				cmd_data_del.Parameters["@SP_QTY_ORDER_CTN"].Value = Convert.ToInt32(txtbx_ctn_odr.Text);
						
				cmd_data_del.Parameters.Add(new SqlParameter("@SP_QTY_ORDER_ROLL", SqlDbType. Int));
				cmd_data_del.Parameters["@SP_QTY_ORDER_ROLL"].Value = Convert.ToInt32(txtbx_roll_odr.Text);
							
    			cmd_data_del.Parameters.Add(new SqlParameter("@SP_DATE_PRODUCTION", SqlDbType. DateTime));
				cmd_data_del.Parameters["@SP_DATE_PRODUCTION"].Value = dtp_production.Value;
						
				cmd_data_del.Parameters.Add(new SqlParameter("@SP_OPERATOR", SqlDbType.NVarChar, 100));
				cmd_data_del.Parameters["@SP_OPERATOR"].Value = cbx_operator.Text.ToUpper(); 
				
						
				cmd_data_del.Parameters.Add(new SqlParameter("@SP_QTY_PRODUCE_CTN", SqlDbType.Int));
				cmd_data_del.Parameters["@SP_QTY_PRODUCE_CTN"].Value = Convert.ToInt32(txtbx_ctn_prd.Text);
						
				cmd_data_del.Parameters.Add(new SqlParameter("@SP_QTY_PRODUCE_ROLL", SqlDbType. Int));
				cmd_data_del.Parameters["@SP_QTY_PRODUCE_ROLL"].Value = Convert.ToInt32(txbx_roll_prd.Text);
						
				cmd_data_del.Parameters.Add(new SqlParameter("@SP_MACHINE_NO", SqlDbType.NVarChar, 20));
				cmd_data_del.Parameters["@SP_MACHINE_NO"].Value = cbx_machine.Text.ToUpper();
						
				cmd_data_del.Parameters.Add(new SqlParameter("@SP_HELPER", SqlDbType.NVarChar, 100));
				cmd_data_del.Parameters["@SP_HELPER"].Value = cbx_machine.Text.ToUpper();

				cmd_data_del.Parameters.Add(new SqlParameter("@SP_ISSUE_DATE", SqlDbType.DateTime));
				cmd_data_del.Parameters["@SP_ISSUE_DATE"].Value = DateTime.Now;
    	
    			cmd_data_del.Parameters.Add(new SqlParameter("@SP_DELIVERY_DATE", SqlDbType.DateTime));
    			cmd_data_del.Parameters["@SP_DELIVERY_DATE"].Value = dtp_delivery.Value;
					
    			cmd_data_del.Parameters.Add(new SqlParameter("@SP_ISSUED_BY", SqlDbType. NVarChar));
				cmd_data_del.Parameters["@SP_ISSUED_BY"].Value = lbl_username.Text;
						
			

				con_data_del.Open();
				cmd_data_del.ExecuteNonQuery();
				
						
						
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
			con_data_del = null;
			MessageBox.Show("SUCCESFULL DELETE");
			this.ClearTextBoxes(this);
		}
		
		void Btn_retrieveClick(object sender, EventArgs e)
		{
			SqlConnection con_SP1 = new SqlConnection(sqlconn);
			SqlCommand cmd_SP1 = new SqlCommand();
			
			try 
			{
				cmd_SP1.CommandText = "select * from TBL_PROD_RIBBON where JO_NO = '" + txtbx_refno.Text + "'";
				cmd_SP1.Connection = con_SP1;
				con_SP1.Open();
				SqlDataReader rd_SP1 = cmd_SP1.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
				
				if (rd_SP1.Read())
				{
				
					
					
						txtbx_joso.Text = rd_SP1["SO_NUMBER"].ToString();
						txtbx_soline.Text = rd_SP1["SO_LINENO"].ToString();
						txtbx_item_code.Text = rd_SP1["ITEM_ID"].ToString();
						txtbx_prod_type.Text = rd_SP1["TYPE_ITEM"].ToString();
						txtbx_customer.Text = rd_SP1["CUSTOMER_NAME"].ToString(); 
						//txtbx_customertype.Text = rd_SP1["JOCUSTOMERTYPE"].ToString();
						txtbx_sodesc1.Text = rd_SP1["DESCRIPTION1"].ToString();
						
						txtbx_sodesc2.Text = rd_SP1["DESCRIPTION2"].ToString();
						txtbx_rbn_width.Text = rd_SP1["WIDTH"].ToString();
						txtbx_rbn_length.Text = rd_SP1["LENGTH"].ToString();
						txtbx_micron.Text = rd_SP1["MICRON"].ToString();
						
						txtbx_roll_ctn.Text = rd_SP1["ROLL_CTN"].ToString();
						txtbx_colour.Text = rd_SP1["COLOR"].ToString();
						
						txtbx_ctn_odr.Text = rd_SP1["QTY_ORDER_CTN"].ToString();
						txtbx_roll_odr.Text = rd_SP1["QTY_ORDER_ROLL"].ToString();
						
						cbx_operator.Text = rd_SP1["OPERATOR"].ToString();
						
						txtbx_ctn_prd.Text = rd_SP1["QTY_PRODUCE_CTN"].ToString();
						
						txbx_roll_prd.Text = rd_SP1["QTY_PRODUCE_ROLL"].ToString();
						cbx_machine.Text = rd_SP1["MACHINE_NO"].ToString();
				
				
						
						cbx_helper.Text = rd_SP1["HELPER"].ToString();
						issued_jo_by = rd_SP1["ISSUED_BY"].ToString();
						


						dtp_delivery.Value = Convert.ToDateTime(rd_SP1["DELIVERY_DATE"]);
						dtp_production.Value = Convert.ToDateTime(rd_SP1["DATE_PRODUCTION"]);

						
				
					
						
    				
//--------------------------------------------------------------------------------------------
					//dateTimePicker1.Text = rd_SP1["DELIVERY_DATE"].ToString();
					//dateTimePicker1.Value  = rd_SP1["@SP_JOUSERDATETIME"].ToString();
					
					
					//combo_box3.Text = rd_SP1["JOFILMCODE"].ToString();
					//combo_box3.SelectedValue  = rd_SP1["JOFILMCODE"].ToString();
					//combo_box3.Text = rd_SP1["JOFILMCODE"].ToString();
					
					
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
		
		void disable_textbox()
		{
			txtbx_joso.Enabled = false;
			txtbx_soline.Enabled = false;
			btn_sbti.Enabled = false;
			txtbx_sodesc1.Enabled = false;
			txtbx_sodesc2.Enabled = false;
			txtbx_micron.Enabled = false;
			txtbx_rbn_width.Enabled = false;
			txtbx_rbn_length.Enabled = false;
			txtbx_colour.Enabled = false;
			txtbx_ctn_odr.Enabled = false;
			txtbx_roll_odr.Enabled = false;
			txtbx_roll_ctn.Enabled = false;
			txtbx_customer.Enabled = false;
			txtbx_item_code.Enabled = false;
			txtbx_prod_type.Enabled = false;
			btn_delete.Enabled = false;
			dtp_delivery.Enabled = false;
		}
		
		
		
		
		private void display_datagrid()
        {
            string sql = "SELECT * FROM TBL_PROD_RIBBON";
            SqlConnection connection = new SqlConnection(sqlconn);
            SqlDataAdapter dataadapter = new SqlDataAdapter(sql, connection);
            DataSet ds = new DataSet();
            connection.Open();
            dataadapter.Fill(ds, "Authors_table");
            connection.Close();
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "Authors_table";
        }
		
		
		
		
		
		
	}
}
