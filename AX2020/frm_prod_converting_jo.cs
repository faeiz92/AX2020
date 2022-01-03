/*
 * Created by SharpDevelop.
 * User: it-4
 * Date: 16/11/2016
 * Time: 10:42 AM
 */ 
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
using fyiReporting;
using fyiReporting.RdlViewer;
using System.Linq;
using Microsoft.Reporting.WinForms;

namespace AX2020
{
	
	public partial class frm_prod_converting_jo : Form
	{		
		public static string sqlconn3 = "Server=AX-UAT; Password=sbax2020sbg; User ID=sbax2020; Initial Catalog=SBG_AX_2020; Integrated Security=false";
        public static string sqlconn2 = "Server=AX-SQL; Password=ax2020sbgroup; User ID=ax2020sb; Initial Catalog=AX2020StagingDB; Integrated Security=false";
        public static string sqlconn = "Server=AX-UAT; Password=sbax2020sbg; User ID=sbax2020; Initial Catalog=SBG_AX_2020; Integrated Security=false";
        
		//public static string sqlconn2 = "Server=AX-UAT; Password=sbax2020sbg; User ID=sbax2020; Initial Catalog=SBG_AX_2020; Integrated Security=false";
        
		//public static string Sqlconn = "DSN=eb9gf;Port=2138;Uid=dba;Pwd=sql";
		private fyiReporting.RdlViewer.RdlViewer rdlViewer1;
        private fyiReporting.RdlViewer.ViewerToolstrip reportStrip;
		bool clickSBTI = false, clickStore = false;
		int NextNo = 0, weight = 0;
		string username, refNo, QAC_Weight = "0", ctn_bx_code = "0", innerbx_code = "0", uom=null;
		int VSalesQtyOrder=0, VSalesRctn=0, VQtyOrder=0;
        

		//>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        
		public frm_prod_converting_jo()
		{
			InitializeComponent();
			
			this.ControlBox = false;
			username = frm_menu_system.userName; 
			lbl_username.Text = "User : " + username;

			btn_del.Visible = false;
			btn_save.Visible = false;
			btn_clear.Visible = false;
			btn_cancel.Visible = true;
			clickSBTI = false;
					
		}
				
		//>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
		
	
		private void DropDownList(string cmd, ComboBox cbx_text, string col_name)
		{
		    SqlConnection conn = new SqlConnection(sqlconn3);
            DataTable ds = new DataTable();
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
            	MessageBox.Show("Error - Converting JO Dropdown \nCannot load DB \n" + se.ToString() + se.Message);
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
            cbx_text.SelectedItem = "Please Select";
		}
		
		
		private void DropDownList2(string cmd, ComboBox cbx_text, string col_name)
		{
			
		    SqlConnection conn = new SqlConnection(sqlconn);
            DataTable ds = new DataTable();
            // string cmdSQL = cmd;
           	SqlCommand cmdSQL = new SqlCommand(cmd, conn);
           	//cmdSQL.CommandText = cmd;
			cmdSQL.Parameters.AddWithValue("@prod_code",  txtbx_prod_code.Text);
			cmdSQL.Connection = conn;
			conn.Open();
			//SqlDataReader rd = cmdSQL.ExecuteReader();
			
            SqlDataAdapter sda = new SqlDataAdapter();          
            sda.SelectCommand = cmdSQL;
                        
            try
            {
//            	if (rd.HasRows)
//				{
//					if (rd.Read())
//					{
						 sda.Fill(ds);
		                //cbx_text.Text = "Please Select";
		                cbx_text.Items.Add("Please Select");
		                
		                foreach(DataRow dr1 in ds.Rows)
			           	{
			               cbx_text.Items.Add(dr1[col_name].ToString());
			           	}
			            //cbx_jr_roll.DataSource = ds.Tables[0];
			            //cbx_jr_roll.DisplayMember = ds.Tables[0].Columns[0].ToString();
			            //cbx_text.SelectedItem = "Please Select";
			            cbx_text.SelectedIndex = 1;
		                
					//}
					
//				}
//            	else
//            	{
//            		BindCombobox2();
////					
//            	}                        
            
            }
            catch(SqlException se)
            {
            	MessageBox.Show("Error - Converting JO Dropdown2 \nCannot load DB \n" + se.ToString() + se.Message);
            }
            finally
            {
                conn.Close();
            }			
           	
		}
		
		
//		private void ComboxJR()
//		{
//		    SqlConnection conn = new SqlConnection(sqlconn);
//            DataSet ds = new DataSet();
//            string cmdSQL = "SELECT * FROM TBL_PROD_CONV_JO_JR_LIST";
//            SqlDataAdapter sda = new SqlDataAdapter(cmdSQL, conn);
//
//            try
//            {
//                conn.Open();
//                sda.Fill(ds);
//                cbx_jr_roll.Text = "Please Select";
//            
//            }catch(SqlException se)
//            {
//            	MessageBox.Show("An error occured while connecting to database" + se.ToString() + se.Message);
//            }
//            finally
//            {
//                conn.Close();
//            }
//			
//           	foreach(DataRow dr1 in ds.Tables[0].Rows)
//           	{
//               cbx_jr_roll.Items.Add(dr1["JR_LIST"].ToString());
//           	}
//            //cbx_jr_roll.DataSource = ds.Tables[0];
//            //cbx_jr_roll.DisplayMember = ds.Tables[0].Columns[0].ToString();
//            //cbx_jr_roll.SelectedIndex = 3;
//		}
//		
		//>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
		
		void Btn_saveClick(object sender, EventArgs e)
		{				
			
			if (!Validation())
                return;
			
			if(cbx_remark4.Text != "-")
			{
				saveInnerBxCode();
			}
			else
				innerbx_code = "-";
			
			if(cbx_remark3.Text != "-")
			{
				GetCtnBxCode();
			}
			else
				ctn_bx_code = "-";
			

			if (clickSBTI == true)
			{
				if(DocNoGenerator() & sqlConnParm2("SP_PROD_CONV_JO_ADD_R1"))
				{
					DialogBox.ShowSaveSuccessDialog();
					TempTable();
					Print();
					clickSBTI = false;	
				}
				else
					return;
			}
			else 			
			{	
				if(sqlConnParm("SP_PROD_CONV_JO_EDIT_R1"))
				{
					DialogBox.ShowSaveSuccessDialog();
					TempTable();
					Print();
				}
				else
					return;
			}
			
			ClearAllText(this);
			ClearComboBox(this);
		}
		
		//>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
		
		void Btn_cancelClick(object sender, EventArgs e)
		{
			this.Close();    
		}
		
		//>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
		
		void Btn_sbtiClick(object sender, EventArgs e)
		{
			//------------------------------------------------------------------------
	
			if (String.IsNullOrWhiteSpace(txtbx_so_no.Text.Trim()))
        	{
        		MessageBox.Show("Please key-in sales order number");
        		return;
        	}
        	
			if (String.IsNullOrWhiteSpace(txtbx_line_no.Text.Trim()))
        	{
        		MessageBox.Show("Please key-in line number");
        		return;
        	}
			
        	//-------------------------------------------------------------------------------------------------------
        	string stockcode;
        
			SqlConnection con_Check_Duplicate_JO = new SqlConnection(sqlconn);
			SqlCommand cmd = new SqlCommand();
			
			try 
			{
				cmd.CommandText = @"select * from TBL_PROD_CONV_JO where SUBSTRING(JODOCNO, 1, 11) = @so_no AND SUBSTRING(JODOCNO, (LEN(LEFT(JODOCNO, CHARINDEX ('-', JODOCNO))) + 1), ((CHARINDEX ('-', JODOCNO, 13)-(CHARINDEX ('-', JODOCNO)))-1)) = @line_no";// + "' and JODOCNO <> 'SMSO124608'";
				cmd.Parameters.AddWithValue("@so_no",  txtbx_so_no.Text.ToUpper().Trim());
				cmd.Parameters.AddWithValue("@line_no",  txtbx_line_no.Text.ToUpper().Trim());
				cmd.Connection = con_Check_Duplicate_JO;
				con_Check_Duplicate_JO.Open();
				SqlDataReader rd_Check_Duplicate_JO = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);

				if (rd_Check_Duplicate_JO.HasRows)
				{
					if (rd_Check_Duplicate_JO.Read())
					{
						MessageBox.Show("SO No already exist");
						return;
					}
				}
			}
			catch (Exception ex)
			{
				con_Check_Duplicate_JO.Close();
				MessageBox.Show("Error - Converting JO Duplicate " + ex.Message + ex.ToString());
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
        	
			txtbx_mic_int.Text 	= "52";
        	txtbx_density.Text 	= "0.96";
        	VSalesRctn 			= 0;
        	VSalesQtyOrder 		= 0;
        	VQtyOrder 			= 0;
        	
        	//------------------------------------------------------------------------
        	
        	btn_del.Visible 	= false;
        	btn_save.Visible 	= true;
			btn_clear.Visible 	= true;

        	
        	txtbx_ref_no.Text = txtbx_so_no.Text.ToUpper() + "-" + txtbx_line_no.Text.ToUpper();
        	
        	//--------------------------------------------------------------------------
        	        	
			string ERP_ST_P1_objSqlStatement = 	"select a.salesid, " +
											   	"b.ITEMID, " +
												"a.SALESNAME, " +
											   	"b.DOT_PRODATTRIBBRAND, " +
												"b.DOT_PRODATTRIBCOLOR, " +
												"b.DOT_PRODATTRIBLENGTH, " +
												"b.DOT_PRODATTRIBMICRON, " +
												"b.DOT_PRODATTRIBWIDTH, " +
												"b.QTYORDERED, " +
												"c.FACTOR, " +
												"b.[NAME], " +
												"a.notesinternal from VIEW_AXERP_SO a, VIEW_AXERP_SO_DETAIL b, VIEW_AXERP_ITEM_MASTER_ATTRIBUTE_FULLINFO4 c where  a.salesid = b.salesid and a.dataareaid = b.dataareaid and (c.FROMUNITOFMEASURESYMBOL = 'CTN' or c.FROMUNITOFMEASURESYMBOL = 'M2' or c.FROMUNITOFMEASURESYMBOL = 'LRO' or c.FROMUNITOFMEASURESYMBOL is null)  and b.itemid = c.itemid and a.salesid = '" + txtbx_so_no.Text.ToUpper() + "' and b.linenum = '" + txtbx_line_no.Text.ToUpper() + "'";
        	
			SqlConnection ERP_ST_P1_objConn = new SqlConnection(sqlconn2);
               
			try
 			{
            	ERP_ST_P1_objConn.Open();
                SqlCommand ERP_ST_P1_objCMD 	= new SqlCommand(ERP_ST_P1_objSqlStatement, ERP_ST_P1_objConn);
               	SqlDataReader ERP_ST_P1_objDR  	= ERP_ST_P1_objCMD.ExecuteReader();            	
            	
            	if (ERP_ST_P1_objDR.HasRows)
            	{
            		while (ERP_ST_P1_objDR.Read())
            		{
            		
            			stockcode = ERP_ST_P1_objDR["itemid"].ToString();
            			txtbx_prod_code.Text 	= ERP_ST_P1_objDR["itemid"].ToString();
            			txtbx_cust.Text 		= ERP_ST_P1_objDR["salesname"].ToString();
            			txtbx_color.Text 		= ERP_ST_P1_objDR["DOT_ProdAttribColor"].ToString();
            			txtbx_brand.Text 		= ERP_ST_P1_objDR["DOT_ProdAttribBrand"].ToString();
            			txtbx_mic_int.Text 		= ERP_ST_P1_objDR["DOT_ProdAttribMicron"].ToString();
            			txtbx_width.Text 		= ERP_ST_P1_objDR["DOT_ProdAttribWidth"].ToString();
            			txtbx_pcore_int.Text 	= ERP_ST_P1_objDR["DOT_ProdAttribWidth"].ToString();
            			txtbx_length.Text 		= ERP_ST_P1_objDR["DOT_ProdAttribLength"].ToString();
//            			
        				VSalesQtyOrder 			= Convert.ToInt32(ERP_ST_P1_objDR["QTYORDERED"]);
        				txtbx_pl_remark1.Text 	= ERP_ST_P1_objDR.GetDecimal(ERP_ST_P1_objDR.GetOrdinal("QTYORDERED")).ToString("0.##");
        			           						
                    	txtbx_desc.Text 		= ERP_ST_P1_objDR["name"].ToString();
                    	
                    	if(ERP_ST_P1_objDR["factor"] != DBNull.Value)
                    	{
                    		txtbx_conversion.Text 	= ERP_ST_P1_objDR.GetDecimal(ERP_ST_P1_objDR.GetOrdinal("factor")).ToString("0.##");
                    	}
                    	else
                    	{
                    		txtbx_conversion.Text 	= "0";
                    	}
                    	
                    	if (ERP_ST_P1_objDR["itemid"].ToString().Substring(0, 2) == "WL")
            			{
                    		
		                    if (string.IsNullOrWhiteSpace(txtbx_length.Text) || string.IsNullOrWhiteSpace(txtbx_width.Text))
							{
								string ERP_P1_objSqlStatement = "select itemid, Width, LLength from VIEW_AXERP_ITEM_MASTER_ATTRIBUTE_FULLINFO where itemid = '" + stockcode + "'" ;
								SqlConnection ERP_P1_objConn = new SqlConnection(sqlconn2);
												
								try 
								{								
									ERP_P1_objConn.Open();
									SqlCommand ERP_P1_objCMD = new SqlCommand(ERP_P1_objSqlStatement, ERP_P1_objConn);
									SqlDataReader ERP_P1_objDR = ERP_P1_objCMD.ExecuteReader();
								
									
									if (ERP_P1_objDR.HasRows)
									{
										while (ERP_P1_objDR.Read()) 
										{
											txtbx_width.Text = ERP_P1_objDR["Width"].ToString();
											txtbx_length.Text = ERP_P1_objDR["LLength"].ToString();
			
										}
									
									}
										 								
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
                    		
                    		
                    		
                    		
                    		
            				VSalesQtyOrder = Convert.ToInt32(ERP_ST_P1_objDR["QTYORDERED"])/(Int32.Parse(txtbx_length.Text)*Int32.Parse(txtbx_width.Text)/1000);
            				txtbx_pl_remark1.Text =VSalesQtyOrder.ToString();
            				txtbx_remark0b.Text = txtbx_pl_remark1.Text;
            				
            				if(txtbx_length.Text == "50"  && txtbx_width.Text == "510")
            				{
            					VSalesRctn = 4;
            					txtbx_conversion.Text = "4";
            				}
            				else if(txtbx_length.Text == "50")
            				{
            					VSalesRctn = 2;
            					txtbx_conversion.Text = "2";
            				}
            				else 
            				{
            					VSalesRctn = 1;
            					txtbx_conversion.Text = "1";
            				}
							          				
            			}
                    	else
                    	{
                    		VSalesRctn 				= Convert.ToInt32(txtbx_conversion.Text);
                    	}                    	
                    	
                    	//VSalesRctn 				= Convert.ToInt32(ERP_ST_P1_objDR["factor"]);
	               		txtbx_packing_1.Text 	= ERP_ST_P1_objDR["NOTESINTERNAL"].ToString();
            		} 
            	}
            	else
            	{
            		MessageBox.Show("Error - Converting JO SBTI \nCannot find SO No");
            		return;
            	}

            	//ERP_ST_P1_objDR.Close();
 			} 
 			
 			catch (Exception ERP_ST_P1_exc)
 			{
 				MessageBox.Show("Error - Converting JO SBTI \nCannot load DB" + ERP_ST_P1_exc.Message + ERP_ST_P1_exc.ToString());
            	ERP_ST_P1_objConn.Close();
            	ERP_ST_P1_objConn.Dispose();
            	return;
 			}
 			
        	finally
        	{
            	ERP_ST_P1_objConn.Close();
            	ERP_ST_P1_objConn.Dispose();
        	}
        	
        	ERP_ST_P1_objConn = null;
        	ERP_ST_P1_objSqlStatement = null;
        	
        	
        	if(String.IsNullOrWhiteSpace(txtbx_length.Text) || String.IsNullOrWhiteSpace(txtbx_width.Text) || String.IsNullOrWhiteSpace(txtbx_mic_int.Text) || String.IsNullOrWhiteSpace(txtbx_color.Text) || String.IsNullOrWhiteSpace(txtbx_brand.Text))
        	{
        		string ERP_ST_P1_objSqlStatement2 	= "select * from VIEW_AXERP_ITEM_MASTER_ATTRIBUTE_FULLINFO where itemid = '" + txtbx_prod_code.Text + "'";
        	
				SqlConnection ERP_ST_P1_objConn2 	= new SqlConnection(sqlconn2);
	               
				try
	 			{
	            	ERP_ST_P1_objConn2.Open();
	                SqlCommand ERP_ST_P1_objCMD2 	= new SqlCommand(ERP_ST_P1_objSqlStatement2, ERP_ST_P1_objConn2);
	               	SqlDataReader ERP_ST_P1_objDR2  = ERP_ST_P1_objCMD2.ExecuteReader();            	
	            	
	            	if (ERP_ST_P1_objDR2.HasRows)
	            	{
	            		while (ERP_ST_P1_objDR2.Read())
	            		{
	            			
	            			txtbx_color.Text 		= ERP_ST_P1_objDR2["Color"].ToString();
	            			txtbx_brand.Text 		= ERP_ST_P1_objDR2["Brand"].ToString();
	            			txtbx_mic_int.Text 		= ERP_ST_P1_objDR2["Micron"].ToString();
	            			txtbx_width.Text 		= ERP_ST_P1_objDR2["Width"].ToString();
	            			txtbx_pcore_int.Text 	= ERP_ST_P1_objDR2["Width"].ToString();
	            			txtbx_length.Text 		= ERP_ST_P1_objDR2["LLength"].ToString();
	            			
	            		} 
	            	}
	            	else
	            	{
	            		MessageBox.Show("Error - Converting JO SBTI \nCannot find product attributes");
	            		return;
	            	}
	 			} 
	 			
	 			catch (Exception ERP_ST_P1_exc2)
	 			{
	 				MessageBox.Show("Error - Converting JO SBTI \nCannot load DB" + ERP_ST_P1_exc2.Message + ERP_ST_P1_exc2.ToString());
	            	ERP_ST_P1_objConn2.Close();
	            	ERP_ST_P1_objConn2.Dispose();
	            	return;
	 			}
	 			
	        	finally
	        	{
	            	ERP_ST_P1_objConn2.Close();
	            	ERP_ST_P1_objConn2.Dispose();
	        	}
	        	
	        	ERP_ST_P1_objConn2 = null;
	        	ERP_ST_P1_objSqlStatement2 = null;
        		
        	}
        	

        	//-------------------------------------------------------------------------------------

        
        	if (VSalesRctn == 0)
        	{
        		VQtyOrder = 0;
            	txtbx_roll_order.Text = Convert.ToString(VSalesQtyOrder);
            	txtbx_conversion.Text = "0";         	
        	}
        	else
       		{        		
        		VQtyOrder = (VSalesQtyOrder / VSalesRctn);
        		txtbx_roll_order.Text = (VSalesQtyOrder % VSalesRctn).ToString();
        	}

        	txtbx_ctn_order.Text = Convert.ToString(VQtyOrder);


//        	if (String.IsNullOrWhiteSpace(txtbx_mic_int.Text))
//        	{
//            	txtbx_weight.Text = null;
//        	}
//        	else
//        	{	        		
//            	//calcWeight(); 
//				calcPCore();
//				calcWeight2();
//				
//				if(String.IsNullOrWhiteSpace(txtbx_pcore_int.Text))
//				{
//				   	calcWeight();
//				}            	
//        	}
        	       	
        	//-------------------------------------------------------------------------------------------------------
        	ClearComboBox(this);
        	
        	if(!CheckStockCode())
        	{
        		BindCombobox2();
        	}
        	else
        	
			BindCombobox();
			clickSBTI = true;

		}
		
		void calcWeight()
		{
			weight = Convert.ToInt32((((double)Convert.ToDouble(txtbx_mic_int.Text) / 1000) * Convert.ToDouble(txtbx_width.Text) * Convert.ToDouble(txtbx_length.Text) * Convert.ToDouble(txtbx_density.Text)) + (Convert.ToDouble(txtbx_pcore_int.Text) * (double)25 / 48));
       		
        	QAC_Weight = null;
        	int QAC_WeightMin = 0;
        	int QAC_WeightMax = 0;

        	QAC_WeightMin = Convert.ToInt32(((double)((double)Convert.ToDouble(txtbx_mic_int.Text) - 2) / 1000) * Convert.ToDouble(txtbx_width.Text) * Convert.ToDouble(txtbx_length.Text) * Convert.ToDouble(txtbx_density.Text) + Convert.ToDouble(txtbx_pcore_int.Text) * (double)25 / 48);
        	QAC_WeightMax = Convert.ToInt32(((double)((double)Convert.ToDouble(txtbx_mic_int.Text) + 2) / 1000) * Convert.ToDouble(txtbx_width.Text) * Convert.ToDouble(txtbx_length.Text) * Convert.ToDouble(txtbx_density.Text) + Convert.ToDouble(txtbx_pcore_int.Text) * (double)25 / 48);
        
        	if (QAC_WeightMax < 0 || QAC_WeightMin < 0)
        	{
            	QAC_Weight = "";
        	}
        	else
        	{
        		QAC_Weight = " (" + QAC_WeightMin.ToString() + " - " + QAC_WeightMax.ToString() + ")";
        	}
        	
        	txtbx_weight.Text = weight.ToString()  + QAC_Weight;
        	txtbx_weight2.Text = txtbx_weight.Text;
		}
		
		void calcWeight2()
		{
			weight = Convert.ToInt32((((double)Convert.ToDouble(txtbx_mic_int.Text) / 1000) * Convert.ToDouble(txtbx_width.Text) * Convert.ToDouble(txtbx_length.Text) * Convert.ToDouble(txtbx_density.Text)) + (Convert.ToDouble(txtbx_pcore_int.Text)));
       		
        	QAC_Weight = null;
        	int QAC_WeightMin = 0;
        	int QAC_WeightMax = 0;

        	QAC_WeightMin = Convert.ToInt32(((double)((double)Convert.ToDouble(txtbx_mic_int.Text) - 2) / 1000) * Convert.ToDouble(txtbx_width.Text) * Convert.ToDouble(txtbx_length.Text) * Convert.ToDouble(txtbx_density.Text) + Convert.ToDouble(txtbx_pcore_int.Text));
        	QAC_WeightMax = Convert.ToInt32(((double)((double)Convert.ToDouble(txtbx_mic_int.Text) + 2) / 1000) * Convert.ToDouble(txtbx_width.Text) * Convert.ToDouble(txtbx_length.Text) * Convert.ToDouble(txtbx_density.Text) + Convert.ToDouble(txtbx_pcore_int.Text));
        
        	if (QAC_WeightMax < 0 || QAC_WeightMin < 0)
        	{
            	QAC_Weight = "";
        	}
        	else
        	{
        		QAC_Weight = " (" + QAC_WeightMin.ToString() + " - " + QAC_WeightMax.ToString() + ")";
        	}
        	
        	txtbx_weight.Text = weight.ToString()  + QAC_Weight;
        	txtbx_weight2.Text = txtbx_weight.Text;
		}
		
		bool CheckStockCode()
		{
		    SqlConnection conn = new SqlConnection(sqlconn);
           	SqlCommand cmdSQL = new SqlCommand("select PROD_CODE from TBL_PROD_CONV_JO_BOM_R2 where PROD_CODE = @prod_code", conn);
           
			cmdSQL.Parameters.AddWithValue("@prod_code",  txtbx_prod_code.Text);
			cmdSQL.Connection = conn;
			conn.Open();
			SqlDataReader rd = cmdSQL.ExecuteReader();

			
            if (rd.HasRows)
			{
				//if (rd.Read())
				//{
					return true;
				//}
            }
            else
            	return false;
						
		}

		void DropDownListCtnBxCode()
		{
			SqlConnection conn = new SqlConnection(sqlconn2);
            DataTable ds = new DataTable();
            string cmdSql = "select itemid, DOT_Description as mdesc from VIEW_AXERP_ITEM_MASTER where dataareaid = 'sbti' and itemid like 'ZKCB%' or dataareaid = 'sbti' and itemid like 'ZK%CB%' order by mdesc";
            SqlDataAdapter sda = new SqlDataAdapter(cmdSql, conn);

            try
            {
                conn.Open();
                sda.Fill(ds);
                cbx_remark3.Items.Add("Please Select");
            
            }
            catch(SqlException se)
            {
            	MessageBox.Show("Error - Converting JO Dropdown ERP \nCannot load DB \n" + se.ToString() + se.Message);
            }
            finally
            {
                conn.Close();
            }
			
           	foreach(DataRow dr1 in ds.Rows)
           	{
               cbx_remark3.Items.Add(dr1["mdesc"].ToString());
           	}
           	cbx_remark3.SelectedItem = "Please Select";

		}
		
		//--------------------------------------------------------------------------------------------
		
		void Btn_clearClick(object sender, EventArgs e)
		{
			ClearAllText(this);
			ClearComboBox(this);
		}		
		
		//-------------------------------------------------------------------------------------------
		
		void Btn_recalc_intClick(object sender, EventArgs e)
		{
			
//        	if (String.IsNullOrWhiteSpace(txtbx_mic_int.Text))
//        	{
//            	txtbx_weight.Text = null;
//        	}
//        	else
//        	{	
//        		txtbx_weight.Text = Convert.ToString(Convert.ToInt32((((double)Convert.ToDouble(txtbx_mic_int.Text) / 1000) * Convert.ToDouble(txtbx_width.Text) * Convert.ToDouble(txtbx_length.Text) * Convert.ToDouble(txtbx_density.Text)) + (Convert.ToDouble(txtbx_pcore_int.Text) * (double)25 / 48)));
//       		
//            	//string QAC_Weight = "0";
//            	int QAC_WeightMin = 0;
//            	int QAC_WeightMax = 0;
//
//            	QAC_WeightMin = Convert.ToInt32(((double)(Convert.ToDouble(txtbx_mic_int.Text) - 2) / 1000) * Convert.ToDouble(txtbx_width.Text) * Convert.ToDouble(txtbx_length.Text) * Convert.ToDouble(txtbx_density.Text) + Convert.ToDouble(txtbx_pcore_int.Text) * (double)25 / 48);
//            	QAC_WeightMax = Convert.ToInt32(((double)(Convert.ToDouble(txtbx_mic_int.Text) + 2) / 1000) * Convert.ToDouble(txtbx_width.Text) * Convert.ToDouble(txtbx_length.Text) * Convert.ToDouble(txtbx_density.Text) + Convert.ToDouble(txtbx_pcore_int.Text) * (double)25 / 48);
//            
//            	if (QAC_WeightMax < 0 || QAC_WeightMin < 0)
//            	{
//                	QAC_Weight = "";
//            	}
//            	else
//            	{
//            		QAC_Weight = " (" + QAC_WeightMin.ToString() + " - " + QAC_WeightMax.ToString() + ")";
//            	}
//            	
//            	txtbx_weight.Text = weight.ToString()  + QAC_Weight;
//        	}
			calcPCore();
			
//			if(String.IsNullOrWhiteSpace(txtbx_length.Text) || String.IsNullOrWhiteSpace(txtbx_width.Text) || cbx_paper_core.Text == "Please select")
//			{
//				MessageBox.Show("Please make sure Product Size and Papercore thickness fields are filled");
//			}
//			else
//			{
//				if(!CheckPCore())
//					MessageBox.Show("Papercore weight not found");
//			}
			
			calcWeight2();
			
			if(String.IsNullOrWhiteSpace(txtbx_pcore_int.Text))
			{
				txtbx_pcore_int.Text = txtbx_width.Text;
			   	calcWeight();
			}
			
        	calcOrder();
		}
		
		bool CheckPCore()
		{
			string cmd;
			
		    SqlConnection conn = new SqlConnection(sqlconn);
		    
		    if (Convert.ToDouble(txtbx_length.Text) >= 200)
		    {
		    	cmd = "select * from TBL_PROD_CONV_JO_PAPERCORE_WEIGHT_LIST where JO_WIDTH = @JO_WIDTH AND PAPERCORE_WIDTH = @PAPERCORE_WIDTH AND PART = 'MACHINE'";
		    }
		    else
		    {
		    	cmd = "select * from TBL_PROD_CONV_JO_PAPERCORE_WEIGHT_LIST where JO_WIDTH = @JO_WIDTH AND PAPERCORE_WIDTH = @PAPERCORE_WIDTH AND PART = 'HAND'";
		    }
           	
		    SqlCommand cmdSQL = new SqlCommand(cmd, conn);
		    
		    
			cmdSQL.Parameters.AddWithValue("@JO_WIDTH",  txtbx_width.Text);
			cmdSQL.Parameters.AddWithValue("@PAPERCORE_WIDTH",  cbx_remark1c.Text);
			cmdSQL.Connection = conn;
			conn.Open();
			SqlDataReader rd = cmdSQL.ExecuteReader();

			
            if (rd.HasRows)
			{
				if (rd.Read())
				{
					txtbx_pcore_int.Text = rd["PAPERCORE_WEIGHT"].ToString();
					return true;
				}
				else
					return false;
            }
            else
            	return false;
            
           
			conn.Close();
			conn.Dispose();
			conn = null;
			cmdSQL = null;
						
		}
		
		void calcPCore()
		{
			if(String.IsNullOrWhiteSpace(txtbx_length.Text) || String.IsNullOrWhiteSpace(txtbx_width.Text) || cbx_paper_core.Text == "Please select")
			{
				MessageBox.Show("Please make sure Product Size and Papercore thickness fields are filled");
			}
			else if(cbx_remark1c.Text == "3.50 MM")
			{
				if(Convert.ToDouble(txtbx_length.Text) >= 200)
				{
					if(Convert.ToDouble(txtbx_width.Text) == 36)
					{
						txtbx_pcore_int.Text = "23";
					}
					else if(Convert.ToDouble(txtbx_width.Text) == 48)
					{
						txtbx_pcore_int.Text = "31";
					}
					else if(Convert.ToDouble(txtbx_width.Text) == 60)
					{
						txtbx_pcore_int.Text = "44";
					}
					else if(Convert.ToDouble(txtbx_width.Text) == 72 || Convert.ToDouble(txtbx_width.Text) == 75)
					{
						txtbx_pcore_int.Text = "45";
					}
					else if(Convert.ToDouble(txtbx_width.Text) == 110)
					{
						txtbx_pcore_int.Text = "69";
					}

					else if(Convert.ToDouble(txtbx_width.Text) == 96)
					{
						txtbx_pcore_int.Text = "61";
					}
					else if(Convert.ToDouble(txtbx_width.Text) == 100)
					{
						txtbx_pcore_int.Text = "62";
					}					
					else
					{
						//txtbx_pcore_int.Text = txtbx_width.Text;
						MessageBox.Show("Papercore weight not found");
					}	
				}
				
			}
			else if(cbx_remark1c.Text == "2.70 MM")  //handroll
			{
				if(Convert.ToDouble(txtbx_length.Text) < 200)
				{
					if(Convert.ToDouble(txtbx_width.Text) == 12)
					{
						txtbx_pcore_int.Text = "4";
					}
					else if(Convert.ToDouble(txtbx_width.Text) == 15)
					{
						txtbx_pcore_int.Text = "8";
					}
					else if(Convert.ToDouble(txtbx_width.Text) == 18)
					{
						txtbx_pcore_int.Text = "9";
					}
					else if(Convert.ToDouble(txtbx_width.Text) == 24)
					{
						txtbx_pcore_int.Text = "12";
					}
					else if(Convert.ToDouble(txtbx_width.Text) == 36)
					{
						txtbx_pcore_int.Text = "18";
					}	
					else if(Convert.ToDouble(txtbx_width.Text) == 45)
					{
						txtbx_pcore_int.Text = "23";
					}
					else if(Convert.ToDouble(txtbx_width.Text) == 46)
					{
						txtbx_pcore_int.Text = "23";
					}
					else if(Convert.ToDouble(txtbx_width.Text) == 48)
					{
						txtbx_pcore_int.Text = "25";
					}
					else if(Convert.ToDouble(txtbx_width.Text) == 50)
					{
						txtbx_pcore_int.Text = "26";
					}
					else if(Convert.ToDouble(txtbx_width.Text) == 60)
					{
						txtbx_pcore_int.Text = "30";
					}
					else if(Convert.ToDouble(txtbx_width.Text) == 72)
					{
						txtbx_pcore_int.Text = "34";
					}
					else if(Convert.ToDouble(txtbx_width.Text) == 75)
					{
						txtbx_pcore_int.Text = "39";
					}
					else if(Convert.ToDouble(txtbx_width.Text) == 96)
					{
						txtbx_pcore_int.Text = "49";
					}
					else if(Convert.ToDouble(txtbx_width.Text) == 120)
					{
						txtbx_pcore_int.Text = "62";
					}
					else if(Convert.ToDouble(txtbx_width.Text) == 144)
					{
						txtbx_pcore_int.Text = "73";
					}
					else
					{
						txtbx_pcore_int.Text = txtbx_width.Text;
						MessageBox.Show("Papercore weight not found");
					}					
				}
			}
			else if(cbx_remark1c.Text == "2\" x 3.50 MM")
			{
				if(Convert.ToDouble(txtbx_width.Text) == 48)
				{
					txtbx_pcore_int.Text = "23";
				}
				else
				{
					txtbx_pcore_int.Text = txtbx_width.Text;
				}
			}
			else if(cbx_remark1c.Text == "10.00 MM")
			{
				if(Convert.ToDouble(txtbx_width.Text) == 48)
				{
					txtbx_pcore_int.Text = "99";
				}
				else if(Convert.ToDouble(txtbx_width.Text) == 144)
				{
					txtbx_pcore_int.Text = "89";
				}
				else
				{
					MessageBox.Show("Papercore weight not found");
					//txtbx_pcore_int.Text = txtbx_width.Text;
				}
			}
			else
				MessageBox.Show("Papercore weight not found");
		}

		void calcOrder()
		{
			if(!String.IsNullOrWhiteSpace(txtbx_ctn_order.Text) && !String.IsNullOrWhiteSpace(txtbx_conversion.Text) && !String.IsNullOrWhiteSpace(txtbx_roll_order.Text))
				txtbx_pl_remark1.Text = ((Convert.ToDouble(txtbx_ctn_order.Text)*Convert.ToDouble(txtbx_conversion.Text)) + Convert.ToDouble(txtbx_roll_order.Text)).ToString();
			else
				MessageBox.Show("Make sure the Quantity and Roll/Ctn fields are filled");
		}
		//>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>

		void Btn_recal_2Click(object sender, EventArgs e)
		{
			try
			{ 
				if(String.IsNullOrWhiteSpace(txtbx_width.Text)|| String.IsNullOrWhiteSpace(txtbx_length.Text))
				{
					MessageBox.Show("Please enter Sales Order No first");
				}
				else
				{
					if(cbx_jr_roll.Text == "Please Select")
					{
						MessageBox.Show("Please select jumbo roll length first");
						cbx_jr_roll.Focus();
					}
					
					else if(cbx_paper_core.Text == "Please Select")
					{
						MessageBox.Show("Please select papercore length first");
						cbx_paper_core.Focus();
					}
					
					else
					{
						CalculationLogRoll();
						CalculationPaperCore();
						calcPCore();
//						if(String.IsNullOrWhiteSpace(txtbx_length.Text) || String.IsNullOrWhiteSpace(txtbx_width.Text) || cbx_paper_core.Text == "Please select")
//						{
//							MessageBox.Show("Please make sure Product Size and Papercore thickness fields are filled");
//						}
//						else
//						{
//							if(!CheckPCore())
//								MessageBox.Show("Papercore weight not found");
//						}
						calcWeight2();
			
						if(String.IsNullOrWhiteSpace(txtbx_pcore_int.Text))
						{
							txtbx_pcore_int.Text = txtbx_width.Text;
						   	calcWeight();
						}
						if(cbx_remark5.Text == "REWINDING + CUTTING")
						{
							txtbx_pcore_int.Text = txtbx_width.Text;
							calcWeight();							
						}
						calcOrder();
					}
				}
			}
			catch(Exception ex)
			{
				MessageBox.Show("Error - Converting JO Calculation \nCannot calculate" + Environment.NewLine + ex.Message + ex.ToString());
			}
		}
		
		//>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>.
		
		void ClearComboBox(Control con)
		{
			
    		foreach (Control c in con.Controls)
    		{    			
                if(c is ComboBox)
                {
                	((ComboBox)c).DataSource = null;
                	((ComboBox)c).Items.Clear();
                }
                else
                	ClearComboBox(c);
				
   			}
		}
//			cbx_tape_end.DataSource = null;
//			cbx_packing_1.DataSource = null;
//			cbx_packing_2.DataSource = null;
//			cbx_packing_3.DataSource = null;
//			cbx_paper_core.DataSource = null;
//			cbx_jr_roll.DataSource = null;
//			cbx_remark5.DataSource = null;
//			cbx_remark3.DataSource = null;
//			cbx_remark4.DataSource = null;
//			
//			cbx_tape_end.Items.Clear();
//			cbx_packing_2.Items.Clear();
//			cbx_packing_3.Items.Clear();
//			cbx_remark3.Items.Clear();
//			cbx_remark4.Items.Clear();
			
		
		
		void BindCombobox()
		{
			DropDownList2(@"select distinct PROD_TAPEEND from TBL_PROD_CONV_JO_BOM_R2 where PROD_CODE = @prod_code", cbx_tape_end, "PROD_TAPEEND");
			//DropDownList2(@"select * from TBL_PROD_CONV_JO_BOM where PROD_CODE = @prod_code", cbx_packing_1, "PACK_1_LIST");
			DropDownList2(@"select distinct PROD_PACK from TBL_PROD_CONV_JO_BOM_R2 where PROD_CODE = @prod_code", cbx_packing_2, "PROD_PACK");
			DropDownList2(@"select distinct PROD_TEAR from TBL_PROD_CONV_JO_BOM_R2 where PROD_CODE = @prod_code", cbx_packing_3, "PROD_TEAR");
			DropDownList2(@"select distinct PROD_PACKTYPE from TBL_PROD_CONV_JO_BOM_R2 where PROD_CODE = @prod_code", cbx_packing_1, "PROD_PACKTYPE");
			DropDownList2(@"select distinct PROD_CTNBX from TBL_PROD_CONV_JO_BOM_R2 where PROD_CODE = @prod_code order by PROD_CTNBX", cbx_remark3, "PROD_CTNBX");
			DropDownList2(@"select distinct PROD_INNERBX from TBL_PROD_CONV_JO_BOM_R2 where PROD_CODE = @prod_code order by PROD_INNERBX", cbx_remark4, "PROD_INNERBX");
        	DropDownList2(@"select distinct PROD_PALLET from TBL_PROD_CONV_JO_BOM_R2 where PROD_CODE = @prod_code order by PROD_PALLET", cbx_pallet, "PROD_PALLET");
			
			DropDownList("SELECT * FROM TBL_PROD_CONV_JO_JR_LIST", cbx_jr_roll, "JR_LIST");
			DropDownList("SELECT * FROM TBL_PROD_CONV_JO_PCORE_LIST", cbx_paper_core, "PCORE_LIST");
			DropDownList("SELECT * FROM TBL_PROD_CONV_JO_PCORE_THK_LIST", cbx_remark1c, "THK_LIST");
			DropDownList("SELECT * FROM TBL_PROD_CONV_JO_PCORE_COLOR_LIST", cbx_remark1d, "COLOR_LIST");
			//DropDownList("SELECT * FROM TBL_PROD_CONV_JO_TAPE_END_LIST", cbx_tape_end, "TAPE_END_LIST");
			//DropDownList("SELECT * FROM TBL_PROD_CONV_JO_PACK_1_LIST", cbx_packing_1, "PACK_1_LIST");
			//DropDownList("SELECT * FROM TBL_PROD_CONV_JO_PACK_2_LIST", cbx_packing_2, "PACK_2_LIST");
			//DropDownList("SELECT * FROM TBL_PROD_CONV_JO_PACK_3_LIST", cbx_packing_3, "PACK_3_LIST");
			//DropDownList("SELECT * FROM TBL_PROD_CONV_JO_CTN_BX_LIST order by CTN_BX_LIST", cbx_remark3, "CTN_BX_LIST");
			//DropDownList("SELECT * FROM TBL_PROD_CONV_JO_INNER_BX_LIST order by INNER_BX_LIST", cbx_remark4, "INNER_BX_LIST");
			//DropDownList("SELECT * FROM TBL_PROD_CONV_JO_MACHINE_LIST order by MACHINE_NO", cbx_machine_no, "MACHINE_NO");
			DropDownList("SELECT * FROM TBL_PROD_CONV_JOB_TYPE", cbx_remark5, "JOB_TYPE");
		}
		
		void BindCombobox2()
		{
			DropDownList("SELECT * FROM TBL_PROD_CONV_JO_JR_LIST", cbx_jr_roll, "JR_LIST");
			DropDownList("SELECT * FROM TBL_PROD_CONV_JO_PCORE_LIST", cbx_paper_core, "PCORE_LIST");
			DropDownList("SELECT * FROM TBL_PROD_CONV_JO_PCORE_THK_LIST", cbx_remark1c, "THK_LIST");
			DropDownList("SELECT * FROM TBL_PROD_CONV_JO_PCORE_COLOR_LIST", cbx_remark1d, "COLOR_LIST");
			
			DropDownList("SELECT * FROM TBL_PROD_CONV_JO_TAPE_END_LIST", cbx_tape_end, "TAPE_END_LIST");
			DropDownList("SELECT * FROM TBL_PROD_CONV_JO_PACK_1_LIST", cbx_packing_1, "PACK_1_LIST");
			DropDownList("SELECT * FROM TBL_PROD_CONV_JO_PACK_2_LIST", cbx_packing_2, "PACK_2_LIST");
			DropDownList("SELECT * FROM TBL_PROD_CONV_JO_PACK_3_LIST", cbx_packing_3, "PACK_3_LIST");
			//DropDownList("SELECT * FROM TBL_PROD_CONV_JO_CTN_BX_LIST order by CTN_BX_LIST", cbx_remark3, "CTN_BX_LIST");
			DropDownList("SELECT * FROM TBL_PROD_CONV_JO_INNER_BX_LIST order by INNER_BX_LIST", cbx_remark4, "INNER_BX_LIST");
			DropDownList("SELECT * FROM TBL_PROD_CONV_JOB_TYPE", cbx_remark5, "JOB_TYPE");
			DropDownList("SELECT * FROM TBL_PROD_CONV_JO_PALLET", cbx_pallet, "PALLET");
			
			DropDownListCtnBxCode();
		}
		
		
		//>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
		
		void Btn_retrieveClick(object sender, EventArgs e)
		{
			txtbx_mic_int.Text = "52";
        	txtbx_density.Text = "0.96";			
        	
			if (txtbx_ref_no.Text == null | txtbx_ref_no.Text == string.Empty) 
			{
        		MessageBox.Show("Please key-in JO No");
				return;
			}
			
			ClearComboBox(this);
			
			SqlConnection con_SP1 = new SqlConnection(sqlconn);
			SqlCommand cmd_SP1 = new SqlCommand();
			
			try 
			{
				cmd_SP1.CommandText = "select * from TBL_PROD_CONV_JO where JODOCNO = '" + txtbx_ref_no.Text + "'";
				cmd_SP1.Connection = con_SP1;
				con_SP1.Open();
				SqlDataReader rd_SP1 = cmd_SP1.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
				
				if(rd_SP1.HasRows)
				{
					while (rd_SP1.Read())
					{
						
						dtp_date_of_issue.Value = Convert.ToDateTime(rd_SP1["JODATE"]);
						txtbx_prod_code.Text = rd_SP1["JOSTOCKCODE"].ToString();
						
						if(!CheckStockCode())
			        	{
			        		BindCombobox2();
			        	}
			        	else
			        	
						BindCombobox();
						
						txtbx_desc.Text = rd_SP1["JOSTOCKDESC"].ToString();
						txtbx_color.Text = rd_SP1["JOSTOCKCOLOR"].ToString();
						txtbx_brand.Text = rd_SP1["JOSTOCKBRAND"].ToString();
						txtbx_width.Text = rd_SP1["JOSTOCKWIDTH"].ToString();
						txtbx_length.Text = rd_SP1["JOSTOCKLENGTH"].ToString();
						txtbx_mic_int.Text = rd_SP1["JOSTOCKMICRON"].ToString();
						
						txtbx_conversion.Text = rd_SP1["JOSTOCKCONVERSION"].ToString();
						weight = Convert.ToInt32(rd_SP1["JOSTOCKWEIGHT"]);
						QAC_Weight = rd_SP1["JOSTOCKWEIGHT2"].ToString();
						txtbx_weight.Text = weight.ToString()  + rd_SP1["JOSTOCKWEIGHT2"].ToString();
						txtbx_ref_no.Text = rd_SP1["JODOCNO"].ToString();
						txtbx_cust.Text = rd_SP1["JOCUSTOMER"].ToString();
						
						txtbx_ctn_order.Text = rd_SP1["JOSTOCKQTYCTN"].ToString();
						txtbx_roll_order.Text = rd_SP1["JOSTOCKQTYROLL"].ToString();
						
						//dtp_prod_date.Value = Convert.ToDateTime(rd_SP1["JOPRODDATE"]);
						dtp_etd_date.Value = Convert.ToDateTime(rd_SP1["JOETDDATE"]);
						
						//txtbx_ctn_prod.Text = rd_SP1["JOPRODQTYCTN"].ToString();
						//txtbx_roll_prod.Text = rd_SP1["JOPRODQTYROLL"].ToString();
						
						//txtbx_helper.Text = rd_SP1["JOPRODHELPER"].ToString();
						//txtbx_operator.Text = rd_SP1["JOPRODOPERATOR"].ToString();
						
						txtbx_desc.Text = rd_SP1["JOSTOCPACKING1"].ToString();
						txtbx_packing_1.Text = rd_SP1["JOSTOCPACKING2"].ToString();
						txtbx_packing_10.Text = rd_SP1["JOSTOCPACKING10"].ToString();
						
						txtbx_pcore_int.Text = rd_SP1["JOSTOCKPCORE"].ToString();
						txtbx_pl_remark1.Text = rd_SP1["JOPRODREMARK0c"].ToString();						
						
						cbx_jr_roll.Text = rd_SP1["JOPRODJRLENGTH"].ToString();
						cbx_jr_roll.SelectedValue = rd_SP1["JOPRODJRLENGTH"].ToString();
						
						txtbx_remark0a.Text = rd_SP1["JOPRODREMARK0a"].ToString();
						txtbx_remark0b.Text = rd_SP1["JOPRODREMARK0b"].ToString();
						txtbx_remark0c.Text = rd_SP1["JOPRODREMARK0d"].ToString();
						txtbx_remark0d.Text = rd_SP1["JOPRODJR1"].ToString();
						txtbx_remark0e.Text = rd_SP1["JOPRODJR2"].ToString();
						
						cbx_paper_core.Text = rd_SP1["JOPRODPCORELENGTH"].ToString();					
						cbx_paper_core.SelectedValue = rd_SP1["JOPRODPCORELENGTH"].ToString();
						
						txtbx_remark1a.Text = rd_SP1["JOPRODREMARK1a"].ToString();
						txtbx_remark1b.Text = rd_SP1["JOPRODREMARK1b"].ToString();
						
						//--------------------------------------------------------------------------------------------
						cbx_tape_end.SelectedItem = rd_SP1["JOSTOCPACKINGB"].ToString();
						cbx_tape_end.SelectedValue  = rd_SP1["JOSTOCPACKINGB"].ToString();
						//--------------------------------------------------------------------------------------------
						cbx_packing_1.SelectedItem = rd_SP1["JOSTOCPACKINGA"].ToString();
						cbx_packing_1.SelectedValue  = rd_SP1["JOSTOCPACKINGA"].ToString();
						//--------------------------------------------------------------------------------------------
						cbx_packing_2.SelectedItem = rd_SP1["JOSTOCPACKINGC"].ToString();
						cbx_packing_2.SelectedValue  = rd_SP1["JOSTOCPACKINGC"].ToString();
						//--------------------------------------------------------------------------------------------
						cbx_packing_3.SelectedItem = rd_SP1["JOSTOCPACKINGD"].ToString();
						cbx_packing_3.SelectedValue  = rd_SP1["JOSTOCPACKINGD"].ToString();
						//--------------------------------------------------------------------------------------------
						cbx_remark1c.SelectedItem = rd_SP1["JOPRODREMARK1c"].ToString();
						cbx_remark1c.SelectedValue  = rd_SP1["JOPRODREMARK1c"].ToString();
						//--------------------------------------------------------------------------------------------
						cbx_remark1d.SelectedItem = rd_SP1["JOPRODREMARK1d"].ToString();
						cbx_remark1d.SelectedValue  = rd_SP1["JOPRODREMARK1d"].ToString();
						//--------------------------------------------------------------------------------------------
						cbx_remark3.SelectedItem = rd_SP1["JOPRODREMARK3"].ToString();
						cbx_remark3.SelectedValue  = rd_SP1["JOPRODREMARK3"].ToString();
						//--------------------------------------------------------------------------------------------
						cbx_remark4.SelectedItem = rd_SP1["JOPRODREMARK4"].ToString();
						cbx_remark4.SelectedValue  = rd_SP1["JOPRODREMARK4"].ToString();
						//--------------------------------------------------------------------------------------------
						cbx_remark5.SelectedItem = rd_SP1["JOPRODREMARK5"].ToString();
						cbx_remark5.SelectedValue  = rd_SP1["JOPRODREMARK5"].ToString();
						//--------------------------------------------------------------------------------------------
//						cbx_machine_no.Text = rd_SP1["JOPRODMACHINENO"].ToString();
//						cbx_machine_no.SelectedValue  = rd_SP1["JOPRODMACHINENO"].ToString();
						//--------------------------------------------------------------------------------------------
					}
					} 
					else 
					{
						MessageBox.Show("Error - Converting JO Retrieve \nCannot find JO");
						return;
					}
				
			} 
			catch (Exception ex) 
			{
				MessageBox.Show("Error - Converting JO Retrieve DB \nCannot load DB \n" + ex.Message + ex.ToString());
				return;
			} 
			finally 
			{
				con_SP1.Close();
			}
			
			con_SP1.Dispose();
			con_SP1 = null;
			cmd_SP1 = null;
			
//			btn_del.Visible = true;
//        	btn_save.Visible = true;
//			btn_clear.Visible = true;
			//btn_cancel.Visible = true;
        	//btn_del.Location = new Point(370, 1390);
        	//btn_save.Location = new Point(239, 1390);
        	//btn_clear.Location = new Point(501, 1390);
        	//btn_cancel.Location = new Point(631, 1390);
        	//refNo = txtbx_ref_no.Text;
			clickSBTI = false;
            btn_del.Visible = false;
        	btn_save.Visible = true;
			btn_clear.Visible = true;			
			
		}
		
		//>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
		
		void Btn_delClick(object sender, EventArgs e)
		{
			if (!Validation())
                return;
			
			SqlConnection con_check = new SqlConnection(sqlconn);
			SqlCommand cmd_check = new SqlCommand();
			
			try 
			{
				cmd_check.CommandText = @"select * from TBL_PROD_CONV_JO_SLITTING where PROD_DOCNO = @doc_no";
				cmd_check.Parameters.AddWithValue("@doc_no",  txtbx_ref_no.Text);
				
				cmd_check.Connection = con_check;
				con_check.Open();
				SqlDataReader rd_check = cmd_check.ExecuteReader(System.Data.CommandBehavior.CloseConnection);

				if (rd_check.HasRows)
				{
					if (rd_check.Read())
					{
						MessageBox.Show("Cannot delete. Slitting already has been made. \nDelete Slitting first if you want to delete this.");
						return;
					}

				}
			}
			catch (Exception ex)
			{
				con_check.Close();
				MessageBox.Show("Error - Converting JO Check \n" + ex.Message + ex.ToString());
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
            	if(sqlConnParm("SP_PROD_CONV_JO_DEL"))
            	{
					//MessageBox.Show("The data has been deleted");
					DialogBox.ShowDeleteSuccessDialog();
					ClearAllText(this);
            	}
				
            }
						
		}
		
		//>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
		
		private bool DocNoGenerator()
		{

			SqlConnection conNextNumber = new SqlConnection(sqlconn);
			SqlCommand cmdNextNumber = new SqlCommand();

			try
			{
					cmdNextNumber.CommandText = "Select JoConvNextNumber from TBL_ADMIN_NEXT_NUMBER";
					cmdNextNumber.Connection = conNextNumber;

					conNextNumber.Open();
					SqlDataReader rdNextNumber = cmdNextNumber.ExecuteReader(System.Data.CommandBehavior.CloseConnection);

					rdNextNumber.Read();
					NextNo = Convert.ToInt32(rdNextNumber["JoConvNextNumber"]);

			}
			catch (Exception ex) 
			{
				MessageBox.Show("Error - Converting JO Next Number DB \nCannot get next number \n" + ex.Message + ex.ToString());
				NextNo = 0;
				return false;
			}
			finally 
			{
				conNextNumber.Close();
				
			}

			conNextNumber.Dispose();
	
			conNextNumber = null;
			cmdNextNumber = null;

			//string SDate = txtbx_ref_no.Text.ToUpper() + "-" + NextNo;

			if(NextNo == 9999)
			{
				SqlConnection conUpdate = new SqlConnection(sqlconn);
				SqlCommand cmdUpdateNextNumber = new SqlCommand();
	
				try
				{
					cmdUpdateNextNumber.CommandText = "update TBL_ADMIN_NEXT_NUMBER set JoConvNextNumber = 1000";
					
					cmdUpdateNextNumber.Connection = conUpdate;
	
					conUpdate.Open();
					cmdUpdateNextNumber.ExecuteNonQuery();
	
				}
				catch (Exception ex)
				{
					conUpdate.Close();
					MessageBox.Show("Error - Converting JO Next Number DB \nCannot update next number \n" + ex.Message + ex.ToString());
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
			
			else
			{
				//---  Update next number
				SqlConnection conUpdate2 = new SqlConnection(sqlconn);
				SqlCommand cmdUpdateNextNumber2 = new SqlCommand();
	
				try
				{
					cmdUpdateNextNumber2.CommandText = "update TBL_ADMIN_NEXT_NUMBER set JoConvNextNumber = JoConvNextNumber + 1";
					
					cmdUpdateNextNumber2.Connection = conUpdate2;
	
					conUpdate2.Open();
					cmdUpdateNextNumber2.ExecuteNonQuery();
	
				}
				catch (Exception ex)
				{
					conUpdate2.Close();
					MessageBox.Show("Error - Converting JO Next Number DB \nCannot update next number \n" + ex.Message + ex.ToString());
					return false;
				}
				finally 
				{
					conUpdate2.Close();
				}
	
				conUpdate2.Dispose();
				conUpdate2 = null;
				cmdUpdateNextNumber2 = null;
				return true;
			}
		}

		
		//>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
		
		public bool sqlConnParm(string sqlStatement)
		{
			txtbx_ctn_prod = null;
			txtbx_roll_prod = null;
			
			
			SqlConnection con_data = new SqlConnection(sqlconn);
			SqlCommand cmd_data = new SqlCommand();
			
			
			try
			{
				cmd_data.Connection = con_data;
				cmd_data.CommandText = sqlStatement;
				cmd_data.CommandType = CommandType.StoredProcedure;

				cmd_data.Parameters.Add(new SqlParameter("@SP_JODATE", SqlDbType.DateTime));
				cmd_data.Parameters["@SP_JODATE"].Value = dtp_date_of_issue.Value;

				cmd_data.Parameters.Add(new SqlParameter("@SP_JOSTOCKCODE", SqlDbType.NVarChar, 50));
				cmd_data.Parameters["@SP_JOSTOCKCODE"].Value = txtbx_prod_code.Text.ToUpper();
				
//				cmd_data.Parameters.Add(new SqlParameter("@SP_JOSONO", SqlDbType.NVarChar, 50));
//				cmd_data.Parameters["@SP_JOSONO"].Value = txtbx_so_no.Text.ToUpper();
//				
//				cmd_data.Parameters.Add(new SqlParameter("@SP_JOLINENO", SqlDbType.NVarChar, 50));
//				cmd_data.Parameters["@SP_JOLINENO"].Value = txtbx_line_no.Text.ToUpper();

				cmd_data.Parameters.Add(new SqlParameter("@SP_JOSTOCKDESC", SqlDbType.NVarChar, 100));
				cmd_data.Parameters["@SP_JOSTOCKDESC"].Value = txtbx_desc.Text.ToUpper();

				cmd_data.Parameters.Add(new SqlParameter("@SP_JOSTOCKCOLOR", SqlDbType.NVarChar, 50));
				cmd_data.Parameters["@SP_JOSTOCKCOLOR"].Value = txtbx_color.Text.ToUpper();

				cmd_data.Parameters.Add(new SqlParameter("@SP_JOSTOCKBRAND", SqlDbType.NVarChar, 50));
				cmd_data.Parameters["@SP_JOSTOCKBRAND"].Value = txtbx_brand.Text.ToUpper();

				cmd_data.Parameters.Add(new SqlParameter("@SP_JOSTOCKWIDTH", SqlDbType.Float));
				cmd_data.Parameters["@SP_JOSTOCKWIDTH"].Value = Double.Parse(txtbx_width.Text);

				cmd_data.Parameters.Add(new SqlParameter("@SP_JOSTOCKLENGTH ", SqlDbType.Float));
				cmd_data.Parameters["@SP_JOSTOCKLENGTH "].Value = Double.Parse(txtbx_length.Text);

				cmd_data.Parameters.Add(new SqlParameter("@SP_JOSTOCKMICRON", SqlDbType.Float));
				cmd_data.Parameters["@SP_JOSTOCKMICRON"].Value = Double.Parse(txtbx_mic_int.Text);

				cmd_data.Parameters.Add(new SqlParameter("@SP_JOSTOCKCONVERSION", SqlDbType.Float));
				cmd_data.Parameters["@SP_JOSTOCKCONVERSION"].Value = Double.Parse(txtbx_conversion.Text);
					
				cmd_data.Parameters.Add(new SqlParameter("@SP_JOSTOCKWEIGHT", SqlDbType.Float));
				cmd_data.Parameters["@SP_JOSTOCKWEIGHT"].Value = weight;
					
				cmd_data.Parameters.Add(new SqlParameter("@SP_JOSTOCKWEIGHT2",SqlDbType.NVarChar, 50));
				cmd_data.Parameters["@SP_JOSTOCKWEIGHT2"].Value = QAC_Weight;
				
				refNo =  txtbx_ref_no.Text.ToUpper();
					
				cmd_data.Parameters.Add(new SqlParameter("@SP_JODOCNO", SqlDbType.NVarChar, 50));
				cmd_data.Parameters["@SP_JODOCNO"].Value = refNo;
					
				cmd_data.Parameters.Add(new SqlParameter("@SP_JOCUSTOMER", SqlDbType.NVarChar, 50));
				cmd_data.Parameters["@SP_JOCUSTOMER"].Value = txtbx_cust.Text.ToUpper();
					
				cmd_data.Parameters.Add(new SqlParameter("@SP_JOSTOCKQTYCTN", SqlDbType.Float));
				//cmd_data.Parameters["@SP_JOSTOCKQTYCTN"].Value = Double.TryParse(txtbx_ctn_order.Text, out notParseDouble);
				cmd_data.Parameters["@SP_JOSTOCKQTYCTN"].Value = Double.Parse(txtbx_ctn_order.Text);
					
				cmd_data.Parameters.Add(new SqlParameter("@SP_JOSTOCKQTYROLL", SqlDbType.Float));
				//cmd_data.Parameters["@SP_JOSTOCKQTYROLL"].Value = Double.TryParse(txtbx_roll_order.Text, out notParseDouble);
				cmd_data.Parameters["@SP_JOSTOCKQTYROLL"].Value = Double.Parse(txtbx_roll_order.Text);
					
				cmd_data.Parameters.Add(new SqlParameter("@SP_JOSTOCPACKINGA", SqlDbType.NVarChar, 50));
				cmd_data.Parameters["@SP_JOSTOCPACKINGA"].Value = cbx_packing_1.Text.ToUpper();
					
				cmd_data.Parameters.Add(new SqlParameter("@SP_JOSTOCPACKINGB", SqlDbType.NVarChar, 50));
				cmd_data.Parameters["@SP_JOSTOCPACKINGB"].Value = cbx_tape_end.Text.ToUpper();
					
				cmd_data.Parameters.Add(new SqlParameter("@SP_JOSTOCPACKINGC", SqlDbType.NVarChar, 50));
				cmd_data.Parameters["@SP_JOSTOCPACKINGC"].Value = cbx_packing_2.Text.ToUpper();
					
				cmd_data.Parameters.Add(new SqlParameter("@SP_JOSTOCPACKINGD", SqlDbType.NVarChar, 50));
				cmd_data.Parameters["@SP_JOSTOCPACKINGD"].Value = cbx_packing_3.Text.ToUpper();
					
				cmd_data.Parameters.Add(new SqlParameter("@SP_JOSTOCPACKING1", SqlDbType.NVarChar, 1000));
				cmd_data.Parameters["@SP_JOSTOCPACKING1"].Value = txtbx_desc.Text.ToUpper();
//					
				cmd_data.Parameters.Add(new SqlParameter("@SP_JOSTOCPACKING2", SqlDbType.NVarChar, 1000));
				cmd_data.Parameters["@SP_JOSTOCPACKING2"].Value = txtbx_packing_1.Text.ToUpper();
					
				cmd_data.Parameters.Add(new SqlParameter("@SP_JOSTOCPACKING3", SqlDbType.NVarChar, 50));
				cmd_data.Parameters["@SP_JOSTOCPACKING3"].Value = "";
					
				cmd_data.Parameters.Add(new SqlParameter("@SP_JOSTOCPACKING4", SqlDbType.NVarChar, 50));
				cmd_data.Parameters["@SP_JOSTOCPACKING4"].Value = "";
				
				cmd_data.Parameters.Add(new SqlParameter("@SP_JOSTOCPACKING5", SqlDbType.NVarChar, 50));
				cmd_data.Parameters["@SP_JOSTOCPACKING5"].Value = "";
					
				cmd_data.Parameters.Add(new SqlParameter("@SP_JOSTOCPACKING6", SqlDbType.NVarChar, 50));
				cmd_data.Parameters["@SP_JOSTOCPACKING6"].Value = "";
					
				cmd_data.Parameters.Add(new SqlParameter("@SP_JOSTOCPACKING7", SqlDbType.NVarChar, 50));
				cmd_data.Parameters["@SP_JOSTOCPACKING7"].Value = "";
				
				cmd_data.Parameters.Add(new SqlParameter("@SP_JOSTOCPACKING8", SqlDbType.NVarChar, 50));
				cmd_data.Parameters["@SP_JOSTOCPACKING8"].Value = "";
					
				cmd_data.Parameters.Add(new SqlParameter("@SP_JOSTOCPACKING9", SqlDbType.NVarChar, 50));
				cmd_data.Parameters["@SP_JOSTOCPACKING9"].Value = "";
					
				cmd_data.Parameters.Add(new SqlParameter("@SP_JOSTOCPACKING10", SqlDbType.NVarChar, 50));
				cmd_data.Parameters["@SP_JOSTOCPACKING10"].Value = txtbx_packing_10.Text.ToUpper();
					
				cmd_data.Parameters.Add(new SqlParameter("@SP_JOPRODDATE", SqlDbType.DateTime));
				cmd_data.Parameters["@SP_JOPRODDATE"].Value = dtp_prod_date.Value;
					
				cmd_data.Parameters.Add(new SqlParameter("@SP_JOETDDATE", SqlDbType.DateTime));
				cmd_data.Parameters["@SP_JOETDDATE"].Value = dtp_etd_date.Value;
					
				cmd_data.Parameters.Add(new SqlParameter("@SP_JOPRODOPERATOR", SqlDbType.NVarChar, 50));
				cmd_data.Parameters["@SP_JOPRODOPERATOR"].Value = "-";
					
				cmd_data.Parameters.Add(new SqlParameter("@SP_JOPRODHELPER", SqlDbType.NVarChar, 50));
				cmd_data.Parameters["@SP_JOPRODHELPER"].Value = "-";
					
				cmd_data.Parameters.Add(new SqlParameter("@SP_JOPRODMACHINENO", SqlDbType.NVarChar, 50));
				cmd_data.Parameters["@SP_JOPRODMACHINENO"].Value = cbx_machine_no.Text.ToUpper();
					
				cmd_data.Parameters.Add(new SqlParameter("@SP_JOPRODQTYCTN", SqlDbType.Float));
					//cmd_data.Parameters["@SP_JOPRODQTYCTN"].Value = Double.TryParse(txtbx_ctn_prod.Text, out notParseDouble);
				cmd_data.Parameters["@SP_JOPRODQTYCTN"].Value = 0;
					
					
				cmd_data.Parameters.Add(new SqlParameter("@SP_JOPRODQTYROLL", SqlDbType.Float));
				//cmd_data.Parameters["@SP_JOPRODQTYROLL"].Value = Double.TryParse(txtbx_roll_prod.Text, out notParseDouble);
				cmd_data.Parameters["@SP_JOPRODQTYROLL"].Value = 0;
					
				cmd_data.Parameters.Add(new SqlParameter("@SP_JOPRODLOTNO", SqlDbType.NVarChar, 50));
				cmd_data.Parameters["@SP_JOPRODLOTNO"].Value = txtbx_jr_lot_no.Text.ToUpper();
					
				cmd_data.Parameters.Add(new SqlParameter("@SP_JOPRODBATCHNO", SqlDbType.NVarChar, 50));
				cmd_data.Parameters["@SP_JOPRODBATCHNO"].Value = txtbx_batch_no.Text.ToUpper();
					
				cmd_data.Parameters.Add(new SqlParameter("@SP_JOPRODREMARK0a", SqlDbType.Float));
				//cmd_data.Parameters["@SP_JOPRODREMARK0a"].Value = Double.TryParse(txtbx_remark0a.Text, out notParseDouble);
				cmd_data.Parameters["@SP_JOPRODREMARK0a"].Value = Double.Parse(txtbx_remark0a.Text);
					
				cmd_data.Parameters.Add(new SqlParameter("@SP_JOPRODREMARK0b", SqlDbType.Float));
				//cmd_data.Parameters["@SP_JOPRODREMARK0b"].Value = Double.TryParse(txtbx_remark0b.Text, out notParseDouble);
				cmd_data.Parameters["@SP_JOPRODREMARK0b"].Value = Double.Parse(txtbx_remark0b.Text);
					
				cmd_data.Parameters.Add(new SqlParameter("@SP_JOPRODREMARK0c", SqlDbType.Float));
				//cmd_data.Parameters["@SP_JOPRODREMARK0c"].Value = Double.TryParse(txtbx_pl_remark1.Text, out notParseDouble);
				cmd_data.Parameters["@SP_JOPRODREMARK0c"].Value = Double.Parse(txtbx_pl_remark1.Text);
					
				cmd_data.Parameters.Add(new SqlParameter("@SP_JOPRODREMARK0d", SqlDbType.Float));
				//cmd_data.Parameters["@SP_JOPRODREMARK0d"].Value = Double.TryParse(txtbx_remark0c.Text, out notParseDouble);
				cmd_data.Parameters["@SP_JOPRODREMARK0d"].Value = Double.Parse(txtbx_remark0c.Text);
					
					
				cmd_data.Parameters.Add(new SqlParameter("@SP_JOPRODJRLENGTH", SqlDbType.NVarChar, 50));
				//cmd_data.Parameters["@SP_JOPRODREMARK0c"].Value = Double.TryParse(txtbx_pl_remark1.Text, out notParseDouble);
				cmd_data.Parameters["@SP_JOPRODJRLENGTH"].Value = cbx_jr_roll.Text.ToUpper();
					
				cmd_data.Parameters.Add(new SqlParameter("@SP_JOPRODJR1", SqlDbType.Float));
				//cmd_data.Parameters["@SP_JOPRODREMARK0d"].Value = Double.TryParse(txtbx_remark0c.Text, out notParseDouble);
				cmd_data.Parameters["@SP_JOPRODJR1"].Value = Double.Parse(txtbx_remark0d.Text);
					
				cmd_data.Parameters.Add(new SqlParameter("@SP_JOPRODJR2", SqlDbType.Float));
				//cmd_data.Parameters["@SP_JOPRODREMARK0d"].Value = Double.TryParse(txtbx_remark0c.Text, out notParseDouble);
				cmd_data.Parameters["@SP_JOPRODJR2"].Value = Double.Parse(txtbx_remark0e.Text);
					

				cmd_data.Parameters.Add(new SqlParameter("@SP_JOPRODREMARK1a", SqlDbType.Float));
				cmd_data.Parameters["@SP_JOPRODREMARK1a"].Value = Double.Parse(txtbx_remark1a.Text);
					
				cmd_data.Parameters.Add(new SqlParameter("@SP_JOPRODREMARK1b", SqlDbType.Float));
				cmd_data.Parameters["@SP_JOPRODREMARK1b"].Value = Double.Parse(txtbx_remark1b.Text);
					
				cmd_data.Parameters.Add(new SqlParameter("@SP_JOPRODREMARK1c", SqlDbType.NVarChar, 50));
				cmd_data.Parameters["@SP_JOPRODREMARK1c"].Value = cbx_remark1c.Text.ToUpper();
					
				cmd_data.Parameters.Add(new SqlParameter("@SP_JOPRODREMARK1d", SqlDbType.NVarChar, 50));
				cmd_data.Parameters["@SP_JOPRODREMARK1d"].Value = cbx_remark1d.Text.ToUpper();
					
				cmd_data.Parameters.Add(new SqlParameter("@SP_JOPRODPCORELENGTH", SqlDbType.NVarChar, 50));
				cmd_data.Parameters["@SP_JOPRODPCORELENGTH"].Value = cbx_paper_core.Text.ToUpper();
					
				cmd_data.Parameters.Add(new SqlParameter("@SP_JOPRODREMARK3", SqlDbType.NVarChar, 255));
				cmd_data.Parameters["@SP_JOPRODREMARK3"].Value = cbx_remark3.Text.ToUpper().Replace(Environment.NewLine, " ");;
				
				cmd_data.Parameters.Add(new SqlParameter("@SP_JOPRODREMARK3A", SqlDbType.NVarChar, 20));
				cmd_data.Parameters["@SP_JOPRODREMARK3A"].Value = ctn_bx_code;
					
				cmd_data.Parameters.Add(new SqlParameter("@SP_JOPRODREMARK4", SqlDbType.NVarChar, 255));
				cmd_data.Parameters["@SP_JOPRODREMARK4"].Value = cbx_remark4.Text.ToUpper();
					
				cmd_data.Parameters.Add(new SqlParameter("@SP_JOPRODREMARK5", SqlDbType.NVarChar, 50));
				cmd_data.Parameters["@SP_JOPRODREMARK5"].Value = cbx_remark5.Text.ToUpper();
					
				cmd_data.Parameters.Add(new SqlParameter("@SP_JOISSUEBY", SqlDbType.NVarChar, 50));
				cmd_data.Parameters["@SP_JOISSUEBY"].Value = frm_menu_system.fullname.ToUpper();
					
				
					
				cmd_data.Parameters.Add(new SqlParameter("@SP_JOPRODQTY", SqlDbType.Float));
				//cmd_data.Parameters["@SP_JOPRODQTYROLL"].Value = Double.TryParse(txtbx_roll_prod.Text, out notParseDouble);
				cmd_data.Parameters["@SP_JOPRODQTY"].Value = 0;
					
				cmd_data.Parameters.Add(new SqlParameter("@SP_JOPRODQTYBAL", SqlDbType.Float));
				//cmd_data.Parameters["@SP_JOPRODQTYROLL"].Value = Double.TryParse(txtbx_roll_prod.Text, out notParseDouble);
				cmd_data.Parameters["@SP_JOPRODQTYBAL"].Value = txtbx_pl_remark1.Text;
					
				cmd_data.Parameters.Add(new SqlParameter("@SP_JOPACKQTY", SqlDbType.Float));
				//cmd_data.Parameters["@SP_JOPRODQTYROLL"].Value = Double.TryParse(txtbx_roll_prod.Text, out notParseDouble);
				cmd_data.Parameters["@SP_JOPACKQTY"].Value = 0;
					
				cmd_data.Parameters.Add(new SqlParameter("@SP_JOPACKQTYBAL", SqlDbType.Float));
				//cmd_data.Parameters["@SP_JOPRODQTYROLL"].Value = Double.TryParse(txtbx_roll_prod.Text, out notParseDouble);
				cmd_data.Parameters["@SP_JOPACKQTYBAL"].Value = txtbx_pl_remark1.Text;
				
				cmd_data.Parameters.Add(new SqlParameter("@SP_JOSTOCKPCORE", SqlDbType.Float));
				cmd_data.Parameters["@SP_JOSTOCKPCORE"].Value = Double.Parse(txtbx_pcore_int.Text);

				
				
				cmd_data.Parameters.Add(new SqlParameter("@SP_JOUSER", SqlDbType.NVarChar, 50));
				cmd_data.Parameters["@SP_JOUSER"].Value = username.ToUpper();
					
				cmd_data.Parameters.Add(new SqlParameter("@SP_JOUSEREMAIL", SqlDbType.NVarChar, 50));
				cmd_data.Parameters["@SP_JOUSEREMAIL"].Value = frm_menu_system.email;
					
				cmd_data.Parameters.Add(new SqlParameter("@SP_JOUSERPC", SqlDbType.NVarChar, 50));
				cmd_data.Parameters["@SP_JOUSERPC"].Value = frm_menu_system.ipAddress;
					
				cmd_data.Parameters.Add(new SqlParameter("@SP_JOUSERDATETIME", SqlDbType.DateTime));
				cmd_data.Parameters["@SP_JOUSERDATETIME"].Value = DateTime.Now;
					
				cmd_data.Parameters.Add(new SqlParameter("@SP_JOUSERREVISION", SqlDbType.NVarChar, 50));
				cmd_data.Parameters["@SP_JOUSERREVISION"].Value = "0";
				
				cmd_data.Parameters.Add(new SqlParameter("@SP_JOPRODREMARK4A", SqlDbType.NVarChar, 255));
				cmd_data.Parameters["@SP_JOPRODREMARK4A"].Value = innerbx_code;
				
				con_data.Open();
				cmd_data.ExecuteNonQuery();
					
					
			} catch (Exception ex) {
				
				con_data.Close();
				MessageBox.Show("Error - Converting JO Save DB \nCannot save data\n" + ex.Message + ex.ToString());			
				return false;
			
			} finally {
				
				con_data.Close();
				
				
			}
			
			con_data.Dispose();
			con_data = null;
			cmd_data = null;
		
			return true;
		}
		
		
		//>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
		
		public bool sqlConnParm2(string sqlStatement)
		{
			SqlConnection con_data_add = new SqlConnection(sqlconn);
			SqlCommand cmd_data_add = new SqlCommand();
			
			try
			{
				cmd_data_add.Connection = con_data_add;
				cmd_data_add.CommandText = sqlStatement;
				cmd_data_add.CommandType = CommandType.StoredProcedure;

				cmd_data_add.Parameters.Add(new SqlParameter("@SP_JODATE", SqlDbType.DateTime));
				cmd_data_add.Parameters["@SP_JODATE"].Value = dtp_date_of_issue.Value;

				cmd_data_add.Parameters.Add(new SqlParameter("@SP_JOSTOCKCODE", SqlDbType.NVarChar, 50));
				cmd_data_add.Parameters["@SP_JOSTOCKCODE"].Value = txtbx_prod_code.Text.ToUpper();
				
//				cmd_data_add.Parameters.Add(new SqlParameter("@SP_JOSONO", SqlDbType.NVarChar, 50));
//				cmd_data_add.Parameters["@SP_JOSONO"].Value = txtbx_so_no.Text.ToUpper();
//				
//				cmd_data_add.Parameters.Add(new SqlParameter("@SP_JOLINENO", SqlDbType.NVarChar, 50));
//				cmd_data_add.Parameters["@SP_JOLINENO"].Value = txtbx_line_no.Text.ToUpper();

				cmd_data_add.Parameters.Add(new SqlParameter("@SP_JOSTOCKDESC", SqlDbType.NVarChar, 100));
				cmd_data_add.Parameters["@SP_JOSTOCKDESC"].Value = txtbx_desc.Text.ToUpper();

				cmd_data_add.Parameters.Add(new SqlParameter("@SP_JOSTOCKCOLOR", SqlDbType.NVarChar, 50));
				cmd_data_add.Parameters["@SP_JOSTOCKCOLOR"].Value = txtbx_color.Text.ToUpper();

				cmd_data_add.Parameters.Add(new SqlParameter("@SP_JOSTOCKBRAND", SqlDbType.NVarChar, 50));
				cmd_data_add.Parameters["@SP_JOSTOCKBRAND"].Value = txtbx_brand.Text.ToUpper();

				cmd_data_add.Parameters.Add(new SqlParameter("@SP_JOSTOCKWIDTH", SqlDbType.Float));
				cmd_data_add.Parameters["@SP_JOSTOCKWIDTH"].Value = Double.Parse(txtbx_width.Text);

				cmd_data_add.Parameters.Add(new SqlParameter("@SP_JOSTOCKLENGTH ", SqlDbType.Float));
				cmd_data_add.Parameters["@SP_JOSTOCKLENGTH "].Value = Double.Parse(txtbx_length.Text);

				cmd_data_add.Parameters.Add(new SqlParameter("@SP_JOSTOCKMICRON", SqlDbType.Float));
				cmd_data_add.Parameters["@SP_JOSTOCKMICRON"].Value = Double.Parse(txtbx_mic_int.Text);

				cmd_data_add.Parameters.Add(new SqlParameter("@SP_JOSTOCKCONVERSION", SqlDbType.Float));
				cmd_data_add.Parameters["@SP_JOSTOCKCONVERSION"].Value = Double.Parse(txtbx_conversion.Text);
					
				cmd_data_add.Parameters.Add(new SqlParameter("@SP_JOSTOCKWEIGHT", SqlDbType.Float));
				cmd_data_add.Parameters["@SP_JOSTOCKWEIGHT"].Value = weight;
					
				cmd_data_add.Parameters.Add(new SqlParameter("@SP_JOSTOCKWEIGHT2",SqlDbType.NVarChar, 50));
				cmd_data_add.Parameters["@SP_JOSTOCKWEIGHT2"].Value = QAC_Weight;

				refNo = txtbx_ref_no.Text.ToUpper() + "-" + NextNo;
					
				cmd_data_add.Parameters.Add(new SqlParameter("@SP_JODOCNO", SqlDbType.NVarChar, 50));
				cmd_data_add.Parameters["@SP_JODOCNO"].Value = refNo;
					
				cmd_data_add.Parameters.Add(new SqlParameter("@SP_JOCUSTOMER", SqlDbType.NVarChar, 50));
				cmd_data_add.Parameters["@SP_JOCUSTOMER"].Value = txtbx_cust.Text.ToUpper();
					
				cmd_data_add.Parameters.Add(new SqlParameter("@SP_JOSTOCKQTYCTN", SqlDbType.Float));
				//cmd_data_add.Parameters["@SP_JOSTOCKQTYCTN"].Value = Double.TryParse(txtbx_ctn_order.Text, out notParseDouble);
				cmd_data_add.Parameters["@SP_JOSTOCKQTYCTN"].Value = Double.Parse(txtbx_ctn_order.Text);
					
				cmd_data_add.Parameters.Add(new SqlParameter("@SP_JOSTOCKQTYROLL", SqlDbType.Float));
				//cmd_data_add.Parameters["@SP_JOSTOCKQTYROLL"].Value = Double.TryParse(txtbx_roll_order.Text, out notParseDouble);
				cmd_data_add.Parameters["@SP_JOSTOCKQTYROLL"].Value = Double.Parse(txtbx_roll_order.Text);
					
				cmd_data_add.Parameters.Add(new SqlParameter("@SP_JOSTOCPACKINGA", SqlDbType.NVarChar, 50));
				cmd_data_add.Parameters["@SP_JOSTOCPACKINGA"].Value = cbx_packing_1.Text.ToUpper();
					
				cmd_data_add.Parameters.Add(new SqlParameter("@SP_JOSTOCPACKINGB", SqlDbType.NVarChar, 50));
				cmd_data_add.Parameters["@SP_JOSTOCPACKINGB"].Value = cbx_tape_end.Text.ToUpper();
					
				cmd_data_add.Parameters.Add(new SqlParameter("@SP_JOSTOCPACKINGC", SqlDbType.NVarChar, 50));
				cmd_data_add.Parameters["@SP_JOSTOCPACKINGC"].Value = cbx_packing_2.Text.ToUpper();
					
				cmd_data_add.Parameters.Add(new SqlParameter("@SP_JOSTOCPACKINGD", SqlDbType.NVarChar, 50));
				cmd_data_add.Parameters["@SP_JOSTOCPACKINGD"].Value = cbx_packing_3.Text.ToUpper();
					
				cmd_data_add.Parameters.Add(new SqlParameter("@SP_JOSTOCPACKING1", SqlDbType.NVarChar, 1000));
				cmd_data_add.Parameters["@SP_JOSTOCPACKING1"].Value = txtbx_desc.Text.ToUpper();
//					
				cmd_data_add.Parameters.Add(new SqlParameter("@SP_JOSTOCPACKING2", SqlDbType.NVarChar, 1000));
				cmd_data_add.Parameters["@SP_JOSTOCPACKING2"].Value = txtbx_packing_1.Text.ToUpper();
					
				cmd_data_add.Parameters.Add(new SqlParameter("@SP_JOSTOCPACKING3", SqlDbType.NVarChar, 50));
				cmd_data_add.Parameters["@SP_JOSTOCPACKING3"].Value = "";
					
				cmd_data_add.Parameters.Add(new SqlParameter("@SP_JOSTOCPACKING4", SqlDbType.NVarChar, 50));
				cmd_data_add.Parameters["@SP_JOSTOCPACKING4"].Value = "";
				
				cmd_data_add.Parameters.Add(new SqlParameter("@SP_JOSTOCPACKING5", SqlDbType.NVarChar, 50));
				cmd_data_add.Parameters["@SP_JOSTOCPACKING5"].Value = "";
					
					cmd_data_add.Parameters.Add(new SqlParameter("@SP_JOSTOCPACKING6", SqlDbType.NVarChar, 50));
				cmd_data_add.Parameters["@SP_JOSTOCPACKING6"].Value = "";
					
					cmd_data_add.Parameters.Add(new SqlParameter("@SP_JOSTOCPACKING7", SqlDbType.NVarChar, 50));
				cmd_data_add.Parameters["@SP_JOSTOCPACKING7"].Value = "";
				
				cmd_data_add.Parameters.Add(new SqlParameter("@SP_JOSTOCPACKING8", SqlDbType.NVarChar, 50));
				cmd_data_add.Parameters["@SP_JOSTOCPACKING8"].Value = "";
					
				cmd_data_add.Parameters.Add(new SqlParameter("@SP_JOSTOCPACKING9", SqlDbType.NVarChar, 50));
				cmd_data_add.Parameters["@SP_JOSTOCPACKING9"].Value = "";
					
				cmd_data_add.Parameters.Add(new SqlParameter("@SP_JOSTOCPACKING10", SqlDbType.NVarChar, 50));
				cmd_data_add.Parameters["@SP_JOSTOCPACKING10"].Value = txtbx_packing_10.Text.ToUpper();
					
				cmd_data_add.Parameters.Add(new SqlParameter("@SP_JOPRODDATE", SqlDbType.DateTime));
				cmd_data_add.Parameters["@SP_JOPRODDATE"].Value = dtp_prod_date.Value;
					
				cmd_data_add.Parameters.Add(new SqlParameter("@SP_JOETDDATE", SqlDbType.DateTime));
				cmd_data_add.Parameters["@SP_JOETDDATE"].Value = dtp_etd_date.Value;
					
				cmd_data_add.Parameters.Add(new SqlParameter("@SP_JOPRODOPERATOR", SqlDbType.NVarChar, 50));
				cmd_data_add.Parameters["@SP_JOPRODOPERATOR"].Value = "-";
					
				cmd_data_add.Parameters.Add(new SqlParameter("@SP_JOPRODHELPER", SqlDbType.NVarChar, 50));
				cmd_data_add.Parameters["@SP_JOPRODHELPER"].Value = "-";
					
				cmd_data_add.Parameters.Add(new SqlParameter("@SP_JOPRODMACHINENO", SqlDbType.NVarChar, 50));
				//cmd_data_add.Parameters["@SP_JOPRODMACHINENO"].Value = cbx_machine_no.Text.ToUpper();
				cmd_data_add.Parameters["@SP_JOPRODMACHINENO"].Value = "-";
					
				cmd_data_add.Parameters.Add(new SqlParameter("@SP_JOPRODQTYCTN", SqlDbType.Float));
				//cmd_data_add.Parameters["@SP_JOPRODQTYCTN"].Value = Double.TryParse(txtbx_ctn_prod.Text, out notParseDouble);
				cmd_data_add.Parameters["@SP_JOPRODQTYCTN"].Value = 0;
					
				cmd_data_add.Parameters.Add(new SqlParameter("@SP_JOPRODQTYROLL", SqlDbType.Float));
				//cmd_data_add.Parameters["@SP_JOPRODQTYROLL"].Value = Double.TryParse(txtbx_roll_prod.Text, out notParseDouble);
				cmd_data_add.Parameters["@SP_JOPRODQTYROLL"].Value = 0;
					
				cmd_data_add.Parameters.Add(new SqlParameter("@SP_JOPRODLOTNO", SqlDbType.NVarChar, 50));
				cmd_data_add.Parameters["@SP_JOPRODLOTNO"].Value = txtbx_jr_lot_no.Text.ToUpper();
					
				cmd_data_add.Parameters.Add(new SqlParameter("@SP_JOPRODBATCHNO", SqlDbType.NVarChar, 50));
				cmd_data_add.Parameters["@SP_JOPRODBATCHNO"].Value = txtbx_batch_no.Text.ToUpper();
					
				cmd_data_add.Parameters.Add(new SqlParameter("@SP_JOPRODREMARK0a", SqlDbType.Float));
				//cmd_data_add.Parameters["@SP_JOPRODREMARK0a"].Value = Double.TryParse(txtbx_remark0a.Text, out notParseDouble);
				cmd_data_add.Parameters["@SP_JOPRODREMARK0a"].Value = Double.Parse(txtbx_remark0a.Text);
					
				cmd_data_add.Parameters.Add(new SqlParameter("@SP_JOPRODREMARK0b", SqlDbType.Float));
				//cmd_data_add.Parameters["@SP_JOPRODREMARK0b"].Value = Double.TryParse(txtbx_remark0b.Text, out notParseDouble);
				cmd_data_add.Parameters["@SP_JOPRODREMARK0b"].Value = Double.Parse(txtbx_remark0b.Text);
				
				cmd_data_add.Parameters.Add(new SqlParameter("@SP_JOPRODREMARK0c", SqlDbType.Float));
				//cmd_data_add.Parameters["@SP_JOPRODREMARK0c"].Value = Double.TryParse(txtbx_pl_remark1.Text, out notParseDouble);
				cmd_data_add.Parameters["@SP_JOPRODREMARK0c"].Value = Double.Parse(txtbx_pl_remark1.Text);
					
				cmd_data_add.Parameters.Add(new SqlParameter("@SP_JOPRODREMARK0d", SqlDbType.Float));
				//cmd_data_add.Parameters["@SP_JOPRODREMARK0d"].Value = Double.TryParse(txtbx_remark0c.Text, out notParseDouble);
				cmd_data_add.Parameters["@SP_JOPRODREMARK0d"].Value = Double.Parse(txtbx_remark0c.Text);
					
					
				cmd_data_add.Parameters.Add(new SqlParameter("@SP_JOPRODJRLENGTH", SqlDbType.NVarChar, 50));
				//cmd_data_add.Parameters["@SP_JOPRODREMARK0c"].Value = Double.TryParse(txtbx_pl_remark1.Text, out notParseDouble);
				cmd_data_add.Parameters["@SP_JOPRODJRLENGTH"].Value = cbx_jr_roll.Text.ToUpper();
					
				cmd_data_add.Parameters.Add(new SqlParameter("@SP_JOPRODJR1", SqlDbType.Float));
				//cmd_data_add.Parameters["@SP_JOPRODREMARK0d"].Value = Double.TryParse(txtbx_remark0c.Text, out notParseDouble);
				cmd_data_add.Parameters["@SP_JOPRODJR1"].Value = Double.Parse(txtbx_remark0d.Text);
					
				cmd_data_add.Parameters.Add(new SqlParameter("@SP_JOPRODJR2", SqlDbType.Float));
					//cmd_data_add.Parameters["@SP_JOPRODREMARK0d"].Value = Double.TryParse(txtbx_remark0c.Text, out notParseDouble);
				cmd_data_add.Parameters["@SP_JOPRODJR2"].Value = Double.Parse(txtbx_remark0e.Text);
			

				cmd_data_add.Parameters.Add(new SqlParameter("@SP_JOPRODREMARK1a", SqlDbType.Float));
				cmd_data_add.Parameters["@SP_JOPRODREMARK1a"].Value = Double.Parse(txtbx_remark1a.Text);
					
				cmd_data_add.Parameters.Add(new SqlParameter("@SP_JOPRODREMARK1b", SqlDbType.Float));
				cmd_data_add.Parameters["@SP_JOPRODREMARK1b"].Value = Double.Parse(txtbx_remark1b.Text);
					
				cmd_data_add.Parameters.Add(new SqlParameter("@SP_JOPRODREMARK1c", SqlDbType.NVarChar, 50));
				cmd_data_add.Parameters["@SP_JOPRODREMARK1c"].Value = cbx_remark1c.Text.ToUpper();
					
				cmd_data_add.Parameters.Add(new SqlParameter("@SP_JOPRODREMARK1d", SqlDbType.NVarChar, 50));
				cmd_data_add.Parameters["@SP_JOPRODREMARK1d"].Value = cbx_remark1d.Text.ToUpper();
					
				cmd_data_add.Parameters.Add(new SqlParameter("@SP_JOPRODPCORELENGTH", SqlDbType.NVarChar, 50));
				cmd_data_add.Parameters["@SP_JOPRODPCORELENGTH"].Value = cbx_paper_core.Text.ToUpper();
					
				cmd_data_add.Parameters.Add(new SqlParameter("@SP_JOPRODREMARK3", SqlDbType.NVarChar, 255));
				cmd_data_add.Parameters["@SP_JOPRODREMARK3"].Value = cbx_remark3.Text.ToUpper();
				
				cmd_data_add.Parameters.Add(new SqlParameter("@SP_JOPRODREMARK3A", SqlDbType.NVarChar, 20));
				cmd_data_add.Parameters["@SP_JOPRODREMARK3A"].Value = ctn_bx_code;
					
				cmd_data_add.Parameters.Add(new SqlParameter("@SP_JOPRODREMARK4", SqlDbType.NVarChar, 255));
				cmd_data_add.Parameters["@SP_JOPRODREMARK4"].Value = cbx_remark4.Text.ToUpper();
					
				cmd_data_add.Parameters.Add(new SqlParameter("@SP_JOPRODREMARK5", SqlDbType.NVarChar, 50));
				cmd_data_add.Parameters["@SP_JOPRODREMARK5"].Value = cbx_remark5.Text.ToUpper();
					
				cmd_data_add.Parameters.Add(new SqlParameter("@SP_JOISSUEBY", SqlDbType.NVarChar, 50));
				cmd_data_add.Parameters["@SP_JOISSUEBY"].Value = frm_menu_system.fullname.ToUpper();
					
				cmd_data_add.Parameters.Add(new SqlParameter("@SP_JOUSER", SqlDbType.NVarChar, 50));
				cmd_data_add.Parameters["@SP_JOUSER"].Value = username;
					
				cmd_data_add.Parameters.Add(new SqlParameter("@SP_JOUSEREMAIL", SqlDbType.NVarChar, 50));
				cmd_data_add.Parameters["@SP_JOUSEREMAIL"].Value = frm_menu_system.email;
					
				cmd_data_add.Parameters.Add(new SqlParameter("@SP_JOUSERPC", SqlDbType.NVarChar, 50));
				cmd_data_add.Parameters["@SP_JOUSERPC"].Value = frm_menu_system.ipAddress;
					
				cmd_data_add.Parameters.Add(new SqlParameter("@SP_JOUSERDATETIME", SqlDbType.DateTime));
				cmd_data_add.Parameters["@SP_JOUSERDATETIME"].Value = DateTime.Now;
				
				cmd_data_add.Parameters.Add(new SqlParameter("@SP_JOUSERREVISION", SqlDbType.NVarChar, 50));
				cmd_data_add.Parameters["@SP_JOUSERREVISION"].Value = "0";
				
				cmd_data_add.Parameters.Add(new SqlParameter("@SP_JOPRODQTY", SqlDbType.Float));
				//cmd_data.Parameters["@SP_JOPRODQTYROLL"].Value = Double.TryParse(txtbx_roll_prod.Text, out notParseDouble);
				cmd_data_add.Parameters["@SP_JOPRODQTY"].Value = 0;
					
				cmd_data_add.Parameters.Add(new SqlParameter("@SP_JOPRODQTYBAL", SqlDbType.Float));
				//cmd_data.Parameters["@SP_JOPRODQTYROLL"].Value = Double.TryParse(txtbx_roll_prod.Text, out notParseDouble);
				cmd_data_add.Parameters["@SP_JOPRODQTYBAL"].Value = txtbx_pl_remark1.Text;
					
				cmd_data_add.Parameters.Add(new SqlParameter("@SP_JOPACKQTY", SqlDbType.Float));
				//cmd_data.Parameters["@SP_JOPRODQTYROLL"].Value = Double.TryParse(txtbx_roll_prod.Text, out notParseDouble);
				cmd_data_add.Parameters["@SP_JOPACKQTY"].Value = 0;
					
				cmd_data_add.Parameters.Add(new SqlParameter("@SP_JOPACKQTYBAL", SqlDbType.Float));
				//cmd_data.Parameters["@SP_JOPRODQTYROLL"].Value = Double.TryParse(txtbx_roll_prod.Text, out notParseDouble);
				cmd_data_add.Parameters["@SP_JOPACKQTYBAL"].Value = txtbx_pl_remark1.Text;

				cmd_data_add.Parameters.Add(new SqlParameter("@SP_JOSTOCKPCORE", SqlDbType.Float));
				cmd_data_add.Parameters["@SP_JOSTOCKPCORE"].Value = Double.Parse(txtbx_pcore_int.Text);
				
				cmd_data_add.Parameters.Add(new SqlParameter("@SP_JOPRODREMARK4A", SqlDbType.NVarChar, 255));
				cmd_data_add.Parameters["@SP_JOPRODREMARK4A"].Value = innerbx_code;
				
				con_data_add.Open();
				cmd_data_add.ExecuteNonQuery();
					
			} catch (Exception ex) {
				
				con_data_add.Close();
				MessageBox.Show("Error - Converting JO Save DB \nCannot save data" + Environment.NewLine + ex.Message + ex.ToString());			
				return false;
			
			} finally {
				
				con_data_add.Close();
				
			}
			
			con_data_add.Dispose();
			con_data_add = null;
			cmd_data_add = null;
		
			return true;
		}
		
		//>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
		
		void ClearAllText(Control con)
		{
    		foreach (Control c in con.Controls)
    		{
      			if (c is TextBox)
        			((TextBox)c).Clear();
      			else
      				ClearAllText(c);
//      			if(c is ComboBox)
//                ((ComboBox)c).SelectedValue = "Please Select";
//                if(c is ComboBox)
//                	((ComboBox)c).Items.Clear();
				if(c is DateTimePicker)
				{
					((DateTimePicker)c).Value = DateTime.Now;
				}
   			}
		}
		
		//>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
		
		private void CalculationLogRoll()
		{
			double prod_width = Convert.ToDouble(txtbx_width.Text);
			double prod_length = Convert.ToDouble(txtbx_length.Text);
			double jr_length = Convert.ToDouble(new String(cbx_jr_roll.Text.Where(Char.IsDigit).ToArray()));
						
			txtbx_remark0a.Text = Convert.ToString(Math.Floor(jr_length/prod_width));
			txtbx_remark0b.Text = Convert.ToString(Math.Ceiling((Convert.ToDecimal(txtbx_pl_remark1.Text)/Convert.ToDecimal(txtbx_remark0a.Text))));
			txtbx_remark0c.Text = Convert.ToString(Convert.ToInt32(Convert.ToDouble(txtbx_remark0b.Text)*prod_length));
			txtbx_remark0d.Text = (Math.Round((Convert.ToDouble(txtbx_remark0c.Text)/7000),2)).ToString("0.00");
			txtbx_remark0e.Text = Convert.ToString(Convert.ToInt32((double)jr_length/1000*Convert.ToDouble(txtbx_remark0c.Text)));
		}
		
		private void CalculationPaperCore()
		{
			double prod_width = Convert.ToDouble(txtbx_width.Text);
			double prod_length = Convert.ToDouble(txtbx_length.Text);		
						
			double pcore_height = Convert.ToDouble(new String(cbx_paper_core.Text.Where(Char.IsDigit).ToArray()));
			txtbx_remark1a.Text = Convert.ToString(Math.Floor(pcore_height/prod_width));
			txtbx_remark1b.Text = Convert.ToString(Math.Ceiling(Convert.ToDecimal(txtbx_pl_remark1.Text)/Convert.ToDecimal(txtbx_remark1a.Text)));			
		}
		//>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
		
		private bool Validation()
        {
                  
              if (CommonValidation.ValidateIsEmptyString(txtbx_prod_code.Text.Trim()))
                {
                    DialogBox.ShowWarningMessage(lbl_prod_code.Text + " cannot be empty.");
                    txtbx_prod_code.Focus();
                   	
                    return false;
                }
              
               	else if (CommonValidation.ValidateIsEmptyString(txtbx_width.Text.Trim()))
                {
                    DialogBox.ShowWarningMessage(lbl_size.Text + " cannot be empty.");
                    txtbx_width.Focus();
                   	
                    return false;
                   
                }
               
               	else if (CommonValidation.ValidateIsEmptyString(txtbx_length.Text.Trim()))
                {
                    DialogBox.ShowWarningMessage(lbl_size.Text + " cannot be empty.");
                    txtbx_length.Focus();
                   	
                    return false;
                    
                }
               
               	else if (CommonValidation.ValidateIsEmptyString(cbx_jr_roll.Text.Trim()) || cbx_jr_roll.Text == "Please Select")
            	{
                	DialogBox.ShowWarningMessage(lbl_jrroll.Text + " cannot be empty.");
                	cbx_jr_roll.Focus();
                   	
                	return false;       
            	}
               	
               	else if (CommonValidation.ValidateIsEmptyString(cbx_paper_core.Text.Trim()) || cbx_paper_core.Text == "Please Select")
            	{
                	DialogBox.ShowWarningMessage(lbl_paper_core.Text + " cannot be empty.");
                	cbx_paper_core.Focus();
                   	
                	return false;       
            	}
               	
               	else if (CommonValidation.ValidateIsEmptyString(cbx_packing_1.Text.Trim()) || cbx_packing_1.Text == "Please Select")
            	{
                	DialogBox.ShowWarningMessage(lbl_packing.Text + " cannot be empty.");
                	cbx_packing_1.Focus();
                   	
                	return false;       
            	}
               
               	else if (CommonValidation.ValidateIsEmptyString(cbx_packing_2.Text.Trim()) || cbx_packing_2.Text == "Please Select")
            	{
                	DialogBox.ShowWarningMessage(lbl_packing_2.Text + " cannot be empty.");
                	cbx_packing_2.Focus();
                   	
                	return false;       
            	}
               	
               	else if (CommonValidation.ValidateIsEmptyString(cbx_packing_3.Text.Trim()) || cbx_packing_3.Text == "Please Select")
            	{
                	DialogBox.ShowWarningMessage(lbl_tear.Text + " cannot be empty.");
                	cbx_packing_3.Focus();
                   	
                	return false;       
            	}
               	
               	else if (CommonValidation.ValidateIsEmptyString(cbx_tape_end.Text.Trim()) || cbx_tape_end.Text == "Please Select")
            	{
                	DialogBox.ShowWarningMessage(lbl_tape_end.Text + " cannot be empty.");
                	cbx_tape_end.Focus();
                   	
                	return false;       
            	}
               	
               	else if (CommonValidation.ValidateIsEmptyString(cbx_remark1c.Text.Trim()) || cbx_remark1c.Text == "Please Select")
            	{
                	DialogBox.ShowWarningMessage(lbl_paper_core.Text + " thickness cannot be empty.");
                	cbx_remark1c.Focus();
                   	
                	return false;       
            	}
               	
               	else if (CommonValidation.ValidateIsEmptyString(cbx_remark1d.Text.Trim()) || cbx_remark1d.Text == "Please Select")
            	{
                	DialogBox.ShowWarningMessage(lbl_paper_core.Text + " color cannot be empty.");
                	cbx_remark1d.Focus();
                   	
                	return false;       
            	}
               	
               	else if (CommonValidation.ValidateIsEmptyString(cbx_remark3.Text.Trim()) || cbx_remark3.Text == "Please Select")
            	{
                	DialogBox.ShowWarningMessage(lbl_ctn_bx.Text + " cannot be empty.");
                	cbx_remark3.Focus();
                   	
                	return false;       
            	}
               	
               	else if (CommonValidation.ValidateIsEmptyString(cbx_remark4.Text.Trim()) || cbx_remark4.Text == "Please Select")
            	{
                	DialogBox.ShowWarningMessage(lbl_inner_bx.Text + " cannot be empty.");
                	cbx_remark4.Focus();
                   	
                	return false;       
            	}
               	
               	else if (CommonValidation.ValidateIsEmptyString(cbx_remark5.Text.Trim()) || cbx_remark5.Text == "Please Select")
            	{
                	DialogBox.ShowWarningMessage(lbl_job_type.Text + " cannot be empty.");
                	cbx_remark5.Focus();
                   	
                	return false;       
            	}
               	
               	else if (CommonValidation.ValidateIsEmptyString(txtbx_weight2.Text.Trim()))
            	{
                	DialogBox.ShowWarningMessage("Must click calculate for weight to display");
                	btn_recal_2.Focus();
                   	
                	return false;       
            	}
               	
               
               return true;
        }

		//>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>		
		
		void TempTable()
		{
			using (SqlConnection conn = new SqlConnection(sqlconn))
			{
				conn.Open();
				
				SqlCommand cmd  = new SqlCommand("SP_PROD_CONV_JO_SLITTING_LIST", conn);
				cmd.CommandType = CommandType.StoredProcedure;
				
				cmd.Parameters.Add(new SqlParameter("@SP_JODOCNO", SqlDbType.NVarChar, 50));
				cmd.Parameters["@SP_JODOCNO"].Value = refNo;

								   
				cmd.ExecuteNonQuery();
				//return true;					
			}				
		}
		
		public void Print()
		{		
			
			using(Form frm = new Form())
			{
				
	        	frm.Height = 700;
	        	frm.Width = 800;
				frm.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
				
	        	
	        	var rdlViewer1 = new fyiReporting.RdlViewer.RdlViewer();
				var reportStrip = new fyiReporting.RdlViewer.ViewerToolstrip(rdlViewer1);
	        	//rdlViewer1.SourceFile = new Uri(@"D:\C# Project\Converting\Converting\report\BOPPFilmLabel2.rdl");
	        	Uri baseUri = new Uri(System.IO.Directory.GetCurrentDirectory());
	        	
	        	if(cbx_remark5.Text == "SLITTING")
	        	{
	        		rdlViewer1.SourceFile = new Uri(baseUri, @"../report/planning_jo_converting_7_r2.rdl");
	        	}
	        	else
	        	{
	        		rdlViewer1.SourceFile = new Uri(baseUri, @"../report/planning_jo_converting_9_r1.rdl");
	        	}
	        	//rdlView.Parameters += string.Format("&TestParam1={0}&TestParam2={1}", "Value 1", "Value 2");
	        	
	        	rdlViewer1.Report.DataSets["Data"].SetSource("select * from TBL_PROD_CONV_JO_SLITTING_LIST_TEMP where JODOCNO = '" + refNo + "'");
	        	rdlViewer1.Rebuild();
	
	        	rdlViewer1.Dock = DockStyle.Fill;
	        	frm.Controls.Add(rdlViewer1);
	        	frm.Controls.Add(reportStrip);

        		frm.ShowDialog(this);
        	
			}
//			catch(Exception ex)
//			{
//				MessageBox.Show("Error - Converting JO \nCannot print" + ex.Message + ex.ToString());
//			}
		}
				
		void Btn_storeClick(object sender, EventArgs e)
		{
			if (String.IsNullOrWhiteSpace(txtbx_so_no.Text))
        	{
        		MessageBox.Show("Please key-in sales order number");
        		return;
        	}
        	
        	if (String.IsNullOrWhiteSpace(txtbx_line_no.Text))
        	{
        		MessageBox.Show("Please key-in line number");
        		return;
        	}
        	
        	//-------------------------------------------------------------------------------------------------------
        	
			SqlConnection con_Check_Duplicate_JO = new SqlConnection(sqlconn3);
			SqlCommand cmd = new SqlCommand();
			
			try 
			{
				//cmd.CommandText = @"select * from TBL_PROD_CONV_JO where SUBSTRING(JODOCNO, 1, 13) = @doc_no AND SUBSTRING(JODOCNO, 15)  = @line_no";// + "' and JODOCNO <> 'SMSO124608'";
				cmd.CommandText = @"select * from TBL_PROD_CONV_JO where JODOCNO LIKE 'STORE%' AND SUBSTRING(JODOCNO, 1, 13) = @doc_no AND RIGHT(JODOCNO, CHARINDEX('-', REVERSE(JODOCNO)) - 1) = @line_no";
	
				cmd.Parameters.AddWithValue("@doc_no",  txtbx_so_no.Text.ToUpper());
				cmd.Parameters.AddWithValue("@line_no",  txtbx_line_no.Text.ToUpper());
				cmd.Connection = con_Check_Duplicate_JO;
				con_Check_Duplicate_JO.Open();
				SqlDataReader rd_Check_Duplicate_JO = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);

				if (rd_Check_Duplicate_JO.HasRows)
				{
					if (rd_Check_Duplicate_JO.Read())
					{
						MessageBox.Show("SO No already exist");
						return;
					}

				}
			}
			catch (Exception ex)
			{
				con_Check_Duplicate_JO.Close();
				MessageBox.Show("Error - Converting Store JO Duplicate " + ex.Message + ex.ToString());
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
        	
			//txtbx_mic_int.Text = "52";
			txtbx_pcore_int.Text = "0";
        	txtbx_density.Text = "0.96";
        	VSalesRctn = 0;
        	VSalesQtyOrder = 0;
        	VQtyOrder = 0;
        	
        	//------------------------------------------------------------------------
        	
        	btn_del.Visible = false;
        	btn_save.Visible = true;
			btn_clear.Visible = true;
			//btn_cancel.Visible = true;
			//btn_save.Location = new Point(313, 1390);
        	//btn_clear.Location = new Point(440, 1]\390);
        	//btn_cancel.Location = new Point(566, 1390);
        	
        	txtbx_ref_no.Text = txtbx_so_no.Text.ToUpper() + "-" + txtbx_line_no.Text.ToUpper();
        	
        	//--------------------------------------------------------------------------
        	
        	SqlConnection con_SP1 = new SqlConnection(sqlconn3);
			SqlCommand cmd_SP1 = new SqlCommand();
			
			try 
			{
				cmd_SP1.CommandText = @"select * from TBL_PROD_CONV_STORE_READY where JODOCNO = @doc_no and JOLINENO = @line_no";
				cmd_SP1.Parameters.AddWithValue("@doc_no",  txtbx_so_no.Text.ToUpper());
				cmd_SP1.Parameters.AddWithValue("@line_no",  txtbx_line_no.Text);
				cmd_SP1.Connection = con_SP1;
				con_SP1.Open();
				SqlDataReader rd_SP1 = cmd_SP1.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
				
				if (rd_SP1.Read())
				{	
		        	//ref_no = txtbx_ref_no.Text;
		        	txtbx_cust.Text = "Store 1806";
					txtbx_prod_code.Text = rd_SP1["JOSTOCKCODE"].ToString();
					txtbx_desc.Text = rd_SP1["JOSTOCKDESC1"].ToString();
					//txtbx_desc_2.Text = rd_SP1["JOSTOCKDESC2"].ToString();
					txtbx_color.Text = rd_SP1["JOSTOCKCOLOR"].ToString();
					txtbx_brand.Text = rd_SP1["JOSTOCKBRAND"].ToString();
					txtbx_color.Text = rd_SP1["JOSTOCKCOLOR"].ToString();
					txtbx_brand.Text = rd_SP1["JOSTOCKBRAND"].ToString();
					txtbx_width.Text = rd_SP1["JOSTOCKWIDTH"].ToString();
					txtbx_pcore_int.Text = rd_SP1["JOSTOCKWIDTH"].ToString();
					txtbx_length.Text = rd_SP1["JOSTOCKLENGTH"].ToString();
					txtbx_mic_int.Text = rd_SP1["JOSTOCKMICRON"].ToString();
					txtbx_conversion.Text = rd_SP1["JOSTOCKCONVERSION"].ToString();
					VSalesRctn = Int32.Parse(rd_SP1["JOSTOCKCONVERSION"].ToString());
					VSalesQtyOrder = Int32.Parse(rd_SP1["JOSTOCKQTYORDER"].ToString());
					
					double order_roll = Convert.ToDouble(rd_SP1["JOSTOCKQTYORDER"]);
					txtbx_pl_remark1.Text = order_roll.ToString();
					
					//double ctn_qty = order_roll/Convert.ToDouble(txtbx_conversion.Text);
					txtbx_ctn_order.Text = Math.Floor(order_roll/Convert.ToDouble(txtbx_conversion.Text)).ToString();
					
					txtbx_roll_order.Text = (order_roll % Convert.ToDouble(txtbx_conversion.Text)).ToString();
					
					txtbx_cust.Text = "Store 1806";
					//MessageBox.Show((order_roll % Convert.ToDouble(txtbx_conversion.Text)).ToString());
				} 
				else 
				{
					MessageBox.Show("Error - Converting Store Jo Search \nCannot find JO!");
					return;
				}
			} 
			catch (Exception ex) 
			{
				MessageBox.Show("Error - Converting Store Jo Search \nCannot load DB!" + ex.Message + ex.ToString());
				return;
			} 
			finally 
			{
				con_SP1.Close();
			}
			
			con_SP1.Dispose();
			con_SP1 = null;
			cmd_SP1 = null;	
        	
        	
        	
        	 //------------------------------------------------------------------------

//        	if (VSalesRctn == 0)
//        	{
//            	VQtyOrder = 0;
//            	txtbx_roll_order.Text = Convert.ToString(VSalesQtyOrder);
//            	txtbx_conversion.Text = "0";
//            	
//        	}
//        	else
//       		{
//        		VQtyOrder = (VSalesQtyOrder / VSalesRctn);
//            	txtbx_roll_order.Text = "0";
//            	
//        	}
//
//        	txtbx_ctn_order.Text = Convert.ToString(VQtyOrder);

        	if (String.IsNullOrWhiteSpace(txtbx_mic_int.Text))
        	{
            	txtbx_weight.Text = null;
            //'Lbl_Message.Text = "Please key-in micron because it is zero Otherwise weight is also zero"
        	}
        	else
        	{	
        		weight = Convert.ToInt32((((double)Convert.ToDouble(txtbx_mic_int.Text) / 1000) * Convert.ToDouble(txtbx_width.Text) * Convert.ToDouble(txtbx_length.Text) * Convert.ToDouble(txtbx_density.Text)) + (Convert.ToDouble(txtbx_pcore_int.Text) * (double)25 / 48));
       		
            	QAC_Weight = null;
            	int QAC_WeightMin = 0;
            	int QAC_WeightMax = 0;

            	QAC_WeightMin = Convert.ToInt32((((double)(Convert.ToDouble(txtbx_mic_int.Text) - 2) / 1000) * Convert.ToDouble(txtbx_width.Text) * Convert.ToDouble(txtbx_length.Text) * Convert.ToDouble(txtbx_density.Text)) + (Convert.ToDouble(txtbx_pcore_int.Text) * (double)25 / 48));
            	QAC_WeightMax = Convert.ToInt32((((double)(Convert.ToDouble(txtbx_mic_int.Text) + 2) / 1000) * Convert.ToDouble(txtbx_width.Text) * Convert.ToDouble(txtbx_length.Text) * Convert.ToDouble(txtbx_density.Text)) + (Convert.ToDouble(txtbx_pcore_int.Text) * (double)25 / 48));
            
            	if (QAC_WeightMax < 0 || QAC_WeightMin < 0)
            	{
                	QAC_Weight = "";
            	}
            	else
            	{
            		QAC_Weight = " (" + QAC_WeightMin.ToString() + " - " + QAC_WeightMax.ToString() + ")";
            	}
            	
            	txtbx_weight.Text = weight.ToString()  + QAC_Weight;
            	
            	if(!CheckStockCode())
	        	{
	        		BindCombobox2();
	        	}
	        	else
	        	
				BindCombobox();
            	clickStore = true;
            		                            
        	}
        	
        	//-------------------------------------------------------------------------------------------------------
        	
        	ClearComboBox(this);
        	if(!CheckStockCode())
        	{
        		BindCombobox2();
        	}
        	else
        	BindCombobox();
        	      	
		}
		
		
		void Cbx_jr_rollSelectedIndexChanged(object sender, EventArgs e)
		{
			if(cbx_jr_roll.SelectedItem == "Please Select")
			{
				return;
			}
			else if(String.IsNullOrWhiteSpace(txtbx_length.Text))
			{
				MessageBox.Show("Key in length first");
				txtbx_length.Focus();
				return;
			}
			else
				CalculationLogRoll();					
		}
		
		
		void Cbx_paper_coreSelectedIndexChanged(object sender, EventArgs e)
		{
			 if(cbx_paper_core.SelectedItem == "Please Select")
			{
				return;
			}
			else if(String.IsNullOrWhiteSpace(txtbx_length.Text))
			{
				MessageBox.Show("Key in length first");
				txtbx_length.Focus();
				return;
			}
			else if(clickStore == true)
            {
				if(txtbx_desc.Text.Contains("D.S")||txtbx_desc.Text.Contains("MASKING")||txtbx_desc.Text.Contains("CLOTH")||txtbx_desc.Text.Contains("ALUMINIUM")||txtbx_desc.Text.Contains("FLOOR"))
				{
	            	txtbx_remark1a.Text = txtbx_remark0a.Text;
	            	txtbx_remark1b.Text = txtbx_remark0b.Text;
				}
            }
			              
			else
				CalculationPaperCore();	
		}

		void Frm_prod_converting_joLoad(object sender, EventArgs e)
		{
			ClearAllText(this);		
//			dtp_etd_date.Format = DateTimePickerFormat.Custom;
//			dtp_etd_date.CustomFormat = " ";	
			txtbx_etd.Text = string.Empty;			
		}
		
		void Btn_reportClick(object sender, EventArgs e)
		{
			this.Hide();
			using(frm_rpt_converting_jo frm_rpt = new frm_rpt_converting_jo())
			      frm_rpt.ShowDialog();
			this.Show();
//			using(Form frm = new Form())
//			{
//				//Form frm = new Form();
//	        	frm.Height = 700;
//	        	frm.Width = 800;
//				frm.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
//				
//				var reportViewer1 = new ReportViewer();
//				
//				reportViewer1.Visible = true;
//				reportViewer1.ProcessingMode = ProcessingMode.Local;
//				reportViewer1.LocalReport.ReportPath = @"..\..\report\PROD_CONV_JO.rdl";
//				DataSet ds = new DataSet();
//				
//				ds = GetData();
//					
//					
//				if (ds.Tables[0].Rows.Count > 0)
//				{
//					reportViewer1.LocalReport.DataSources.Clear();
//					ReportDataSource rds = new ReportDataSource("DataSet1", ds.Tables[0]);					
//					reportViewer1.LocalReport.DataSources.Add(rds);
//					reportViewer1.LocalReport.Refresh();
//					reportViewer1.RefreshReport();
//				}
//				
//	        	reportViewer1.Dock = DockStyle.Fill;
//	        	frm.Controls.Add(reportViewer1);
//
//        		frm.ShowDialog(this);
//        	
//			}
//			catch(Exception ex)
//			{
//				MessageBox.Show("Error - Converting JO \nCannot print" + ex.Message + ex.ToString());
//			}
					
		}
		
		private DataSet GetData()
		{
			SqlConnection conn = new SqlConnection(sqlconn);
			SqlCommand cmd = new SqlCommand("SELECT * FROM TBL_PROD_CONV_JO", conn);
			
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
				MessageBox.Show("Error - Converting JO Report \nCannot load DB" + ex.Message + ex.ToString());
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
		
		
		void GetCtnBxCode()
		{
			string sql = "select itemid from VIEW_AXERP_ITEM_MASTER where dataareaid = 'sbti' and itemid like 'ZKCB%' or dataareaid = 'GF' and itemid like 'ZK%CB%' and DOT_Description ='" + cbx_remark3.Text.Trim() + "'";
        	SqlConnection conn = new SqlConnection(sqlconn2);
               
			try
 			{
            	conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
               	SqlDataReader dr  = cmd.ExecuteReader();            	
            	
            	if (dr.HasRows)
            	{
            		while (dr.Read())
            		{
            			ctn_bx_code = dr["itemid"].ToString();           			
            		} 
            	}
            	else
            	{
            		MessageBox.Show("Error - Converting JO Ctn Bx Code \nCannot find carton box");
            		return;
            	}

            	//dr.Close();
 			} 
 			
 			catch (Exception exc)
 			{
 				MessageBox.Show("Error - Converting JO SBTI \nCannot load DB" + exc.Message + exc.ToString());
            	conn.Close();
            	conn.Dispose();
            	return;
 			}
 			
        	finally
        	{
            	conn.Close();
            	conn.Dispose();

        	}
        	
        	conn = null;
        	sql = null;
		}
		
		void saveInnerBxCode()
		{
			string ERP_ST_P1_objSqlStatement = "select * from VIEW_AXERP_ITEM_MASTER where dataareaid = 'sbti' and itemid like 'XZIB%' and DOT_Description = '" + cbx_remark4.Text.Trim() +"'";
        	SqlConnection ERP_ST_P1_objConn = new SqlConnection(sqlconn2);
               
			try
 			{
            	ERP_ST_P1_objConn.Open();
                SqlCommand ERP_ST_P1_objCMD = new SqlCommand(ERP_ST_P1_objSqlStatement, ERP_ST_P1_objConn);
               	SqlDataReader ERP_ST_P1_objDR  = ERP_ST_P1_objCMD.ExecuteReader();            	
            	
            	if (ERP_ST_P1_objDR.HasRows)
            	{
            		while (ERP_ST_P1_objDR.Read())
            		{
            			innerbx_code = ERP_ST_P1_objDR["itemid"].ToString();
            			
            		} 
            	}
            	else
            	{
            		MessageBox.Show("Error - Converting JO BOM Save Inner Bx \nCannot find Stock Code");
            		return;
            	}

            	//ERP_ST_P1_objDR.Close();
 			} 
 			
 			catch (Exception ERP_ST_P1_exc)
 			{
 				MessageBox.Show("Error - Converting JO BOM Save Inner Bx\nCannot load DB" + ERP_ST_P1_exc.Message + ERP_ST_P1_exc.ToString());
            	ERP_ST_P1_objConn.Close();
            	ERP_ST_P1_objConn.Dispose();
            	return;
 			}
 			
        	finally
        	{
            	ERP_ST_P1_objConn.Close();
            	ERP_ST_P1_objConn.Dispose();

        	}
        	
        	ERP_ST_P1_objConn = null;
        	ERP_ST_P1_objSqlStatement = null;
		}
		
		void Btn_switClick(object sender, EventArgs e)
		{
			this.Hide();
			using(frm_prod_converting_jo_swit frm_conv_jo_swit = new frm_prod_converting_jo_swit())
				frm_conv_jo_swit.ShowDialog();
			this.Show();
			
		}
		
		void Cbx_palletSelectedIndexChanged(object sender, EventArgs e)
		{
			txtbx_packing_10.Text = cbx_pallet.Text;
		}
		
		void Dtp_etd_dateValueChanged(object sender, EventArgs e)
		{
			//txtbx_etd.Hide();
			txtbx_etd.Text = dtp_etd_date.Value.ToString("dd/MM/yyyy");
		}
	}
}