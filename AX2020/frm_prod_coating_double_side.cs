/*
 * Created by SharpDevelop.
 * User: it-3
 * Date: 22/12/2016
 * Time: 9:30 AM
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

namespace AX2020
{
	/// <summary>
	/// Description of frm_prod_coating_double_side.
	/// </summary>
	public partial class frm_prod_coating_double_side : Form
	{
		public static string sqlconn = "Server=AX-UAT; Password=sbax2020sbg; User ID=sbax2020; Initial Catalog=SBG_AX_2020; Integrated Security=false";
		public static string Sqlconn = "DSN=eb9gf;Port=2138;Uid=dba;Pwd=sql";
		
		public frm_prod_coating_double_side()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			JrCategory();
			BOPPFilmList();
			datagridOutput();
			
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		
		
		void datagridOutput()
		{
			string sql = "SELECT * FROM TBL_PROD_COATING_DOUBLE_SIDE";
            SqlConnection connection = new SqlConnection(sqlconn);
            SqlDataAdapter dataadapter = new SqlDataAdapter(sql, connection);
            DataTable ds = new DataTable();
            connection.Open();
            dataadapter.Fill(ds);
                     
            DataTable tempDT = new DataTable();
  			tempDT = ds.DefaultView.ToTable(true,"JOSALESNO", "JOSALESLINE", "JODOCNO","JOCUSTOMER", "JOSTOCKDESC", "JOSTOCKDESC2", "JOGLUEWIDTH", "JOGLUECODE", "JOFILMMICRON","JOSTOCKWIDTH","JOSTOCKLENGTH","JOQTY");
   			dataGridView1.DataSource = tempDT;
   
  			connection.Close();
			//dataGridView1.DataSource = ds;
			//dataGridView1.DataMember = "TBL_PROD_CONV_JO_SLITTING";
            //dataGridView1.DataMember = ds;

   			dataGridView1.Columns[0].HeaderText = "S/O";
   			dataGridView1.Columns[1].HeaderText = "S/O LINE";
  			dataGridView1.Columns[2].HeaderText = "REF NO";
   			dataGridView1.Columns[3].HeaderText = "CUSTOMER";
   			dataGridView1.Columns[4].HeaderText = "DESC1";
   			dataGridView1.Columns[5].HeaderText = "DESC2";
   			dataGridView1.Columns[6].HeaderText = "GLUEWIDTH";
   			dataGridView1.Columns[7].HeaderText = "GLUETYPE";
   			dataGridView1.Columns[8].HeaderText = "JOFILMMICRON";
   			dataGridView1.Columns[9].HeaderText = "JRWIDTH";
   			dataGridView1.Columns[10].HeaderText = "JRLENGTH";
			dataGridView1.Columns[11].HeaderText = "JOQTY";   			
		}
		
		void DataGridView1CellClick(object sender, DataGridViewCellEventArgs e)
		{

			if (dataGridView1.SelectedRows.Count >0)
			{
				  txtbx_joso.Text = dataGridView1.SelectedRows[0].Cells[0].Value + string.Empty;
			      txtbx_soline.Text = dataGridView1.SelectedRows[0].Cells[1].Value + string.Empty;
			      txtbx_refno.Text = dataGridView1.SelectedRows[0].Cells[2].Value + string.Empty;
			      txtbx_socustomer.Text = dataGridView1.SelectedRows[0].Cells[3].Value + string.Empty;
			      txtbx_sodesc1.Text = dataGridView1.SelectedRows[0].Cells[4].Value + string.Empty;
			      txtbx_sodesc2.Text = dataGridView1.SelectedRows[0].Cells[5].Value + string.Empty;
			      txtbx_gluewidth.Text = dataGridView1.SelectedRows[0].Cells[6].Value + string.Empty;
			      txtbx_gluecode.Text = dataGridView1.SelectedRows[0].Cells[7].Value + string.Empty;
			      txtbx_bopp_micron.Text = dataGridView1.SelectedRows[0].Cells[8].Value + string.Empty;
			      txtbx_bopp_width.Text = dataGridView1.SelectedRows[0].Cells[9].Value + string.Empty;
			      txtbx_productwidth.Text = dataGridView1.SelectedRows[0].Cells[10].Value + string.Empty;
			      txtbx_jrqty.Text = dataGridView1.SelectedRows[0].Cells[11].Value + string.Empty;
			}
		}
		
			
		
		void Btn_jrstockcodeClick(object sender, EventArgs e)
		{
			//btn_save.Visible = true;
								//TxtBx_JRColor1.ReadOnly = false;
								//TxtBx_StockCode1.ReadOnly = false;
//---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
							if (txtbx_joso.Text == null || txtbx_joso.Text == string.Empty) 
								{
								
									
								MessageBox.Show("ERROR ? SO ");  //+ ex.ToString() + ex.Message);//+ ex.Message + ex.ToString());//Lbl_Message.Text = "Error? SO?";
									return;
								}
										
							else if (txtbx_soline.Text == null || txtbx_soline.Text == string.Empty) 
								{
								MessageBox.Show("ERROR ? SO Line ");// + ex.Message + ex.ToString());//Lbl_Message.Text = "Error? SO Line?";
									return;
								}
							
							
								SqlConnection con_Check_Duplicate_JO = new SqlConnection(sqlconn);
								SqlCommand cmd_Check_Duplicate_JO = new SqlCommand();
								//SqlCommand	rd_Check_Duplicate_JO = new SqlCommand();
								
								
								try {
									cmd_Check_Duplicate_JO.CommandText = "select * from TBL_PROD_COATING_DOUBLE_SIDE where JOSALESNO = '" + txtbx_joso.Text.ToUpper() + "' and JOSALESLINE = '" + txtbx_soline.Text.ToUpper()+"'";
									cmd_Check_Duplicate_JO.Connection = con_Check_Duplicate_JO;
									con_Check_Duplicate_JO.Open();
									SqlDataReader rd_Check_Duplicate_JO = cmd_Check_Duplicate_JO.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
					
									if (rd_Check_Duplicate_JO.Read())
										{
											if (rd_Check_Duplicate_JO.HasRows) 
												{
												MessageBox.Show("Error1.0 : Duplicate JO");//Lbl_Message.Text = "Error 1.0 : Duplicate JO! ";
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
								cmd_Check_Duplicate_JO.Dispose();
								con_Check_Duplicate_JO = null;
								cmd_Check_Duplicate_JO = null;
//=============================================================================================================================================

						string SOCustomerType = null;
						string SOCustomerCode = null;
						string SOStockCode = null;
//===========================================================================================================================================================
					//System.Data.Sql.SqlConnection ERP_P1_objConn = new System.Data.Sql.SqlConnection();
					string ERP_P1_objConnString = null;
					
					

					
				
				
					string ERP_P1_objSqlStatement = "select a.tstring24, a.tstring25, a.tstring26, a.tmc, a.ttype, a.tno, a.tcode, a.tdate, a.tdo_date, a.tdoline1, b.tline, b.tstk, b.tdesc1, b.tdesc2, b.tstk_qty, b.tstk_uom, c.tstring01,c.tstring03,c.tstring04,c.tdouble01,c.tdouble02, b.tsou_no from so a, so_detail b, so_detail_info c where  a.tno = b.tno and a.ttype = b.ttype and a.tmc  = b.tmc and c.tmc  = b.tmc and c.tline = b.tline and c.ttype = b.ttype and c.tno = b.tno and a.tno = '" + txtbx_joso.Text.ToUpper() + "' and c.tline = '" + txtbx_soline.Text.ToUpper() + "' order by c.tline";
					SqlConnection ERP_P1_objConn = new SqlConnection(Sqlconn);
					
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
								SOCustomerType = null;
								SOCustomerCode = ERP_P1_objDR["tcode"].ToString().ToUpper();
								SOStockCode = ERP_P1_objDR["tstk"].ToString().ToUpper();
								//TxtBx_StockCode1.Text = ERP_P1_objDR["tstk"].ToString().ToUpper();
				
								txtbx_joso.Text = ERP_P1_objDR["tno"].ToString().ToUpper();
								txtbx_socustomer.Text = ERP_P1_objDR["tdoline1"].ToString().ToUpper();
								string socust2 = ERP_P1_objDR["tdoline1"].ToString().ToUpper();
								//txtbx_socustomer2.Text = socust2.Substring(0, 30);
								txtbx_remark6.Text = ERP_P1_objDR["tdoline1"].ToString().ToUpper();
								txtbx_sodesc1.Text = ERP_P1_objDR["tdesc1"].ToString().ToUpper();
								txtbx_sodesc2.Text = ERP_P1_objDR["tdesc2"].ToString().ToUpper();
								txtbx_micron.Text = ERP_P1_objDR["tstring04"].ToString().ToUpper();
								txtbx_micmax.Text = ERP_P1_objDR["tstring04"].ToString().ToUpper();
								//txtbx_jrwidth.Text = ERP_P1_objDR["tdouble01"].ToString().ToUpper();
								//txtbx_jrlength.Text = ERP_P1_objDR["tdouble02"].ToString().ToUpper();
								//MessageBox.Show (txtbx_jrlenght.Text);
								//---------------------------------------------------------------------------------------------------------------------------------------------------------------------------
							
										
								//if (ERP_P1_objDR("tstring24").ToString() == null || ERP_P1_objDR("tstring24").ToString() == string.Empty || Information.IsDBNull(ERP_P1_objDR("tstring24").ToString()))
								if (ERP_P1_objDR["tstring24"].ToString() == null || ERP_P1_objDR["tstring24"].ToString() == string.Empty)
								{
									txtbx_remark6.Text = " ";
								} 
								else
								{
									txtbx_remark6.Text = ERP_P1_objDR["tstring24"].ToString();
								}
								//-----------------------------------------------------------------------------------------------------------------------------------------------
								//if (ERP_P1_objDR("tstring25").ToString() == null || ERP_P1_objDR("tstring25").ToString() == string.Empty || Information.IsDBNull(ERP_P1_objDR("tstring25").ToString()))
								if (ERP_P1_objDR["tstring25"].ToString() == null || ERP_P1_objDR["tstring25"].ToString() == string.Empty)
								{
									txtbx_remark8.Text = " ";
								} 
								else
								{
									txtbx_remark8.Text = ERP_P1_objDR["tstring25"].ToString();
								}
								//-----------------------------------------------------------------------------------------------------------------------------------------------
								//if (ERP_P1_objDR["tstring26"].ToString() == null || ERP_P1_objDR["tstring26"].ToString() == string.Empty || Information.IsDBNull(ERP_P1_objDR["tstring26"].ToString()))
								if (ERP_P1_objDR["tstring26"].ToString() == null || ERP_P1_objDR["tstring26"].ToString() == string.Empty)
								{
									txtbx_remark3.Text = " ";
								} 
								else 
								{
									txtbx_remark9.Text = ERP_P1_objDR["tstring26"].ToString();
								}
								//-----------------------------------------------------------------------------------------------------------------------------------------------
								if (ERP_P1_objDR["tstring03"].ToString() == null || ERP_P1_objDR["tstring03"].ToString() == string.Empty)
								{
									txtbx_color.Text = "-";
									MessageBox.Show("Error? SO Color?");
									return;
								} 
								else
								{
									txtbx_color.Text = ERP_P1_objDR["tstring03"].ToString();
									
								}
								
								
				
								txtbx_jrqty.Text = ERP_P1_objDR["tstk_qty"].ToString();
								txtbx_M2.Text = ERP_P1_objDR["tstk_uom"].ToString();
				
								//txtbx_jrwidth.Text = txtbx_jrwidth.Text;
								
				
							
						
					
				//=======================================================================================================================================================================================================================================================================================================		 
					}
						
					}
						 //txtbx_productwidth.Text = txtbx_jrwidth.Text;
						 //txtbx_productlength.Text = txtbx_jrlength.Text;
						 //TxtBx_JRColor1.Text = txtbx_colour.Text;
						 
						 txtbx_remark1.Text = txtbx_socustomer.Text;
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
				
					//@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
				
					SqlConnection ERP_P2_objConn = new SqlConnection(Sqlconn); //trial
					string ERP_P2_objSqlStatement = null;
					//string ERP_P1_objConnString = null;
					
//					if (txtbx_so.Text.Substring(0,4) == "STSO")
//					
//					if (txtbx_so.Text.Substring(0,4) == "STSO")
//					{
//						ERP_P2_objConnString = "DSN=ebuilder9;Port=2138;Uid=dba;Pwd=sql";
//						ERP_P2_objSqlStatement = "select * from ar where mmc = 'ST' and mcode = '" + SOCustomerCode + "'";
//					} 
//					
//					else if ((txtbx_so.Text.SubString(0, 4) == "GFMO" )|| (txtbx_so.Text.SubString(0, 4) == "GFSO"))
//					{
//						ERP_P2_objConnString = "DSN=eb9gf;Port=2138;Uid=dba;Pwd=sql";
//						ERP_P2_objSqlStatement = "select * from ar where mmc = 'GF' and mcode = '" + SOCustomerCode + "'";
//					} 
//					else if (txtbx_so.Text.Substring(0, 4) == "SMSO") 
//					{
//						ERP_P2_objConnString = "DSN=eb9sbsm;Port=2138;Uid=dba;Pwd=sql";
//						ERP_P2_objSqlStatement = "select * from ar where mmc = 'SBSM' and mcode = '" + SOCustomerCode + "'";
//					} 
//					else 
//					{
//						DialogBox.ShowWarningMessage("Error? SO Invalid?"); //Lbl_Message.Text = "Error? SO Invalid?";
//						return;
//					}
					
					//SqlConnection ERP_P2_objConn = new SqlConnection(Sqlconn);
					ERP_P2_objSqlStatement = "select * from ar where mmc = 'GF' and mcode = '" + SOCustomerCode + "'";
					try {
						ERP_P2_objConn.Open();
						SqlCommand ERP_P2_objCMD = new SqlCommand(ERP_P2_objSqlStatement, ERP_P2_objConn);
						SqlDataReader ERP_P2_objDR = ERP_P2_objCMD.ExecuteReader();
					 
						if (ERP_P2_objDR.HasRows) 
						{
							while (ERP_P2_objDR.Read()) 
							{
						//====================================================================================================================================================================================================================================================================================
								SOCustomerType = ERP_P2_objDR["mcat"].ToString();
								//txtbx_customertype.Text = ERP_P2_objDR["mcat"].ToString();
								//txtbx_brand.Text = ERP_P2_objDR["marea"].ToString();
				
								if(SOStockCode.Substring(0,5) =="WJ820"  && SOCustomerType == "LC") //if (String.Left(SOStockCode, 5) == "WJ820" & SOCustomerType == "LC") 
								{
									//TxtBx_JRLength.Text = TxtBx_JRLength.Text + 30;
									//txtbx_jrlength.Text = Convert.ToString( Convert.ToInt32(txtbx_jrlength.Text) + Convert.ToInt32(30));
									txtbx_micmax.Text =  Convert.ToString(Convert.ToInt32(txtbx_micmax.Text) - Convert.ToInt32(1));
								}
								
								//====================================================================================================================================================================================================================================================================================
							
							
							}
						}
						else
						{
							DialogBox.ShowWarningMessage("Error 1 : Cannot find  SO");//Lbl_Message.Text = "Error 1 : Cannot find  SO";
						}
						
					 
							
				  }
				//}
					//}
						
					catch (Exception ERP_P2_exc)
					{
						DialogBox.ShowWarningMessage("Error 2 : read DB"+ ERP_P2_exc.ToString().ToUpper() + ERP_P2_exc.Message);//Lbl_Message.Text = "Error 2: Cannot read  DB" + ERP_P2_exc.ToString.ToUpper + ERP_P2_exc.Message;
						ERP_P2_objConn.Close();
						ERP_P2_objConn.Dispose();
						return;
					} 
					
					finally 
					{
					
						ERP_P2_objConn.Close();
						ERP_P2_objConn.Dispose();
					}
//					
//					
//				
//					ERP_P2_objConn = null;
//					//ERP_P2_objConnString = null;
//					ERP_P2_objSqlStatement = null;
	//@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
				


					//string ERP_JRColor_objSqlStatement = "select * from stk where mmc = 'GF' and mcode like 'WJ820%' and mcode = '" + TxtBx_StockCode1.Text.ToString() +"'";
//					SqlConnection ERP_JRColor_objConn = new SqlConnection(Sqlconn);
//					try 
//					{
//						ERP_JRColor_objConn.Open();
//						//SqlCommand ERP_JRColor_objCMD = new SqlCommand(ERP_JRColor_objSqlStatement, ERP_JRColor_objConn);
//						SqlDataReader ERP_JRColor_objDR = ERP_JRColor_objCMD.ExecuteReader();
//											
//						if (ERP_JRColor_objDR.HasRows) 
//						{
//						
//							while (ERP_JRColor_objDR.Read())
//							{
//								TxtBx_JRColor1.Text = ERP_JRColor_objDR["mremark1"].ToString().ToUpper();
//							}
//							
//						}
							
												
//							else 
//							{
//							   DialogBox.ShowWarningMessage(" Error 1 : Cannot find  JR Color?");//Lbl_Message.Text = "Error 1 : Cannot find  JR Color?";
//							}
//						
//						}
						
					
//					catch (Exception ERP_JRColor_exc) 
//					{
//						 DialogBox.ShowWarningMessage("Error 2: Cannot read  DB? JR Color ?");//Lbl_Message.Text = "Error 2: Cannot read  DB? JR Color ?" + ERP_JRColor_exc.ToString + ERP_JRColor_exc.Message;
//						ERP_JRColor_objConn.Close();
//						ERP_JRColor_objConn.Dispose();
//						return;
//					} 
//					finally
//					{
//						ERP_JRColor_objConn.Close();
//						ERP_JRColor_objConn.Dispose();					
//					}
//									
//					ERP_JRColor_objConn = null;
//					ERP_JRColor_objSqlStatement = null;
//				//-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
//				TxtBx_JRColor1.ReadOnly = true;
//				//	//----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
//				//
//                 double jrm2 = 0;
//                 double jojrqty = 0;
//                 jrm2 = Convert.ToDouble(txtbx_jrwidth.Text)/1000 * Convert.ToDouble(txtbx_jrlength.Text);
//	             txtbx_jrm2.Text = Convert.ToString (jrm2.ToString());
//	             //txtbx_jojrqty.Text = Convert.ToString (jojrqty.ToString());
//	             
//	             if (txtbx_M2.Text.ToUpper() == "M2")
//	             {
//	                 //TxtBx_JRQty.Text = Convert.ToInt32(TxtBx_JRQtyM2.Text / TxtBx_JRM2.Text);
//	                 jojrqty =Convert.ToDouble(txtbx_qtyorder.Text) / Convert.ToDouble(txtbx_jrm2.Text);
//	                 	txtbx_jojrqty.Text = Convert.ToString (jojrqty.ToString());
//	                 //txtbx_jojrqty.Text = Convert.ToString(Convert.ToDouble(txtbx_jojrqty.Text) / Convert.ToDouble(txtbx_jrm2.Text));
//	                 
//	                 //txtbx_jojrqty.Text = Convert.ToDouble(txtbx_qtyorder.Text) / Convert.ToDouble(txtbx_jrm2.Text);
//	                 //txtbx_jojrqty.Text =   Convert.ToString (jojrqty.ToString());
//                 } 
//	             else 
//	             {
//	                 txtbx_jojrqty.Text = "0";
//                 }
	             
	            
	             


//					txtbx_bopp_width.Text = txtbx_bopp_width.Text;
					//txtbx_jrlenght.Text = "0";
					//==================================================================================================================================================================
					txtbx_refno.Text = txtbx_joso.Text + txtbx_soline.Text;
					//==================================================================================================================================================================
					//TxtBx_JRColor1.ReadOnly = true;
					//TxtBx_StockCode1.ReadOnly = true;
					//==================================================================================================================================================================
					txtbx_minimummic.Focus();
					//======================================================================================================================================================================
					 


		
	}
		
		void Btn_saveClick(object sender, EventArgs e)
		{
				SqlConnection con_data_add = new SqlConnection(sqlconn);
				System.Data.SqlClient.SqlCommand cmd_data_add = new SqlCommand();  //adress pergi ke sql
				try {

						cmd_data_add.Connection = con_data_add;		//coman run store procedure
						cmd_data_add.CommandText = "SP_PROD_COATING_DOUBLE_SIDE_ADD";	//nama store procedure
						cmd_data_add.CommandType = CommandType.StoredProcedure;		//declare comand
    	
						cmd_data_add.Parameters.Add(new SqlParameter("@SP_JODATE", SqlDbType.DateTime)); //create parameter pada sql bwk data SP_RefNumber untuk dihantar semula
						cmd_data_add.Parameters["@SP_JODATE"].Value = dateTimePicker1.Value;
				
						cmd_data_add.Parameters.Add(new SqlParameter("@SP_JODOCNO", SqlDbType. NVarChar, 50)); //create parameter pada sql bwk data SP_RefNumber untuk dihantar semula
						cmd_data_add.Parameters["@SP_JODOCNO"].Value = txtbx_refno.Text.ToUpper();
						
						cmd_data_add.Parameters.Add(new SqlParameter("@SP_JOSALESNO", SqlDbType. NVarChar, 50)); //create parameter pada sql bwk data SP_RefNumber untuk dihantar semula
						cmd_data_add.Parameters["@SP_JOSALESNO"].Value = txtbx_joso.Text.ToUpper();
						
						cmd_data_add.Parameters.Add(new SqlParameter("@SP_JOSALESLINE", SqlDbType. NVarChar, 50)); //create parameter pada sql bwk data SP_RefNumber untuk dihantar semula
						cmd_data_add.Parameters["@SP_JOSALESLINE"].Value = "0";
						
						cmd_data_add.Parameters.Add(new SqlParameter("@SP_JOSTOCKCODE", SqlDbType.NVarChar, 50));
						cmd_data_add.Parameters["@SP_JOSTOCKCODE"].Value = txtbx_joso.Text.ToUpper();
						
						cmd_data_add.Parameters.Add(new SqlParameter("@SP_JRSTOCKCODE", SqlDbType.NVarChar, 50));
						cmd_data_add.Parameters["@SP_JRSTOCKCODE"].Value = "0";
						
						cmd_data_add.Parameters.Add(new SqlParameter("@SP_JOSTOCKDESC", SqlDbType.NVarChar, 50));
						cmd_data_add.Parameters["@SP_JOSTOCKDESC"].Value = txtbx_sodesc1.Text.ToUpper();
						
						cmd_data_add.Parameters.Add(new SqlParameter("@SP_JOSTOCKDESC2", SqlDbType.NVarChar, 50));
						cmd_data_add.Parameters["@SP_JOSTOCKDESC2"].Value = txtbx_sodesc2.Text.ToUpper();
						
						cmd_data_add.Parameters.Add(new SqlParameter("@SP_JOSTOCKCOLOR", SqlDbType.NVarChar, 50));
						cmd_data_add.Parameters["@SP_JOSTOCKCOLOR"].Value="0";  //tukar daripada string kepada nombor
						
						cmd_data_add.Parameters.Add(new SqlParameter("@SP_JRCOLOR", SqlDbType.NVarChar, 50));
						cmd_data_add.Parameters["@SP_JRCOLOR"].Value = "0";  //tukar daripada string kepada nom
						
    					cmd_data_add.Parameters.Add(new SqlParameter("@SP_JOSTOCKBRAND", SqlDbType.NVarChar, 50));
						cmd_data_add.Parameters["@SP_JOSTOCKBRAND"].Value= "0"; 
						
						cmd_data_add.Parameters.Add(new SqlParameter("@SP_JOSMARKCODE", SqlDbType.NVarChar, 50));
						cmd_data_add.Parameters["@SP_JOSMARKCODE"].Value=txtbx_smarkcode.Text.ToUpper(); 
						
						cmd_data_add.Parameters.Add(new SqlParameter("@SP_JOJRCATEGORY", SqlDbType.NVarChar, 50));
						cmd_data_add.Parameters["@SP_JOJRCATEGORY"].Value = combobx_category.Text;
						
						cmd_data_add.Parameters.Add(new SqlParameter("@SP_JOSMARKLINE", SqlDbType.NVarChar, 50));
						cmd_data_add.Parameters["@SP_JOSMARKLINE"].Value=txtbx_smarkicode.Text.ToUpper(); 
						
						cmd_data_add.Parameters.Add(new SqlParameter("@SP_JOSTOCKWIDTH", SqlDbType.Float));
						cmd_data_add.Parameters["@SP_JOSTOCKWIDTH"].Value = 0;
						
						cmd_data_add.Parameters.Add(new SqlParameter("@SP_JOSTOCKLENGTH", SqlDbType.Float));
						cmd_data_add.Parameters["@SP_JOSTOCKLENGTH"].Value = 0;
						
						//MessageBox.Show(txtbx
						
						//TUKAR QTY ORDERED KEPADA JO JR QTY
					
    					cmd_data_add.Parameters.Add(new SqlParameter("@SP_JOSTOCKMICRON", SqlDbType.Float));
						cmd_data_add.Parameters["@SP_JOSTOCKMICRON"].Value =Convert.ToDouble(txtbx_micron.Text);
						
						cmd_data_add.Parameters.Add(new SqlParameter("@SP_JOSTOCKMICRONM2", SqlDbType.NVarChar, 50));
						cmd_data_add.Parameters["@SP_JOSTOCKMICRONM2"].Value = txtbx_M2.Text.ToUpper(); 
				
						
						cmd_data_add.Parameters.Add(new SqlParameter("@SP_JOJRM2", SqlDbType.Float));
						cmd_data_add.Parameters["@SP_JOJRM2"].Value = 0;
						
						cmd_data_add.Parameters.Add(new SqlParameter("@SP_PRODUCTWIDTH", SqlDbType.Float));
						cmd_data_add.Parameters["@SP_PRODUCTWIDTH"].Value =Convert.ToDouble(txtbx_productwidth.Text);
						
						cmd_data_add.Parameters.Add(new SqlParameter("@SP_PRODUCTLENGTH", SqlDbType.Float));
						cmd_data_add.Parameters["@SP_PRODUCTLENGTH"].Value =Convert.ToDouble(txtbx_productlength.Text);
						
						cmd_data_add.Parameters.Add(new SqlParameter("@SP_JOSTOCKMICRONMIN", SqlDbType.Float));
						cmd_data_add.Parameters["@SP_JOSTOCKMICRONMIN"].Value = Convert.ToDouble(txtbx_minimummic.Text);
    
			
    
						cmd_data_add.Parameters.Add(new SqlParameter("@SP_JOSTOCKMICRONMAX", SqlDbType.Float));
						cmd_data_add.Parameters["@SP_JOSTOCKMICRONMAX"].Value = Convert.ToDouble(txtbx_micmax.Text);
    		
    					cmd_data_add.Parameters.Add(new SqlParameter("@SP_JOSTOCKKGMIN", SqlDbType.Float));
    					cmd_data_add.Parameters["@SP_JOSTOCKKGMIN"].Value = Convert.ToDouble(txtbx_kgmin.Text);
					
    					cmd_data_add.Parameters.Add(new SqlParameter("@SP_JOSTOCKKGMAX", SqlDbType.Float));
						cmd_data_add.Parameters["@SP_JOSTOCKKGMAX"].Value = Convert.ToDouble(txtbx_kgmax.Text);
						
						cmd_data_add.Parameters.Add(new SqlParameter("@SP_JOQTY", SqlDbType.Float));
						cmd_data_add.Parameters["@SP_JOQTY"].Value = 0;
						
						cmd_data_add.Parameters.Add(new SqlParameter("@SP_JOCUSTOMER", SqlDbType.NVarChar, 50));
						cmd_data_add.Parameters["@SP_JOCUSTOMER"].Value = txtbx_socustomer.Text.ToUpper();
						
						cmd_data_add.Parameters.Add(new SqlParameter("@SP_JOCUSTOMERTYPE", SqlDbType.NVarChar, 50));
						cmd_data_add.Parameters["@SP_JOCUSTOMERTYPE"].Value = "0";
						
						cmd_data_add.Parameters.Add(new SqlParameter("@SP_JOGLUECODE", SqlDbType.NVarChar, 50));
						cmd_data_add.Parameters["@SP_JOGLUECODE"].Value = txtbx_gluecode.Text.ToUpper();
				
						cmd_data_add.Parameters.Add(new SqlParameter("@SP_JOGLUEWIDTH", SqlDbType.Float));
						cmd_data_add.Parameters["@SP_JOGLUEWIDTH"].Value = Convert.ToDouble(txtbx_gluewidth.Text);
			
						cmd_data_add.Parameters.Add(new SqlParameter("@SP_JOGLUELENGTH", SqlDbType.Float));
						cmd_data_add.Parameters["@SP_JOGLUELENGTH"].Value = Convert.ToDouble(txtbx_bopp_length.Text);
						
						cmd_data_add.Parameters.Add(new SqlParameter("@SP_JOGLUEMICRON", SqlDbType.Float));
						cmd_data_add.Parameters["@SP_JOGLUEMICRON"].Value = Convert.ToDouble(txtbx_gluemicron.Text);
					
						cmd_data_add.Parameters.Add(new SqlParameter("@SP_JOGLUEKG", SqlDbType.Float));
						cmd_data_add.Parameters["@SP_JOGLUEKG"].Value = Convert.ToDouble(txtbx_gluemicron.Text);
    
    					cmd_data_add.Parameters.Add(new SqlParameter("@SP_JOFILMCODE", SqlDbType.NVarChar, 50));
						cmd_data_add.Parameters["@SP_JOFILMCODE"].Value = combo_box3.Text;
    
    					cmd_data_add.Parameters.Add(new SqlParameter("@SP_JOFILMWIDTH", SqlDbType.Float));
						cmd_data_add.Parameters["@SP_JOFILMWIDTH"].Value =Convert.ToDouble(txtbx_bopp_width.Text);
    					                        
   						cmd_data_add.Parameters.Add(new SqlParameter("@SP_JOFILMLENGTH", SqlDbType.Float));
    					cmd_data_add.Parameters["@SP_JOFILMLENGTH"].Value = Convert.ToDouble(txtbx_bopp_length.Text);

    	
    					cmd_data_add.Parameters.Add(new SqlParameter("@SP_JOFILMMICRON", SqlDbType.Float));
						cmd_data_add.Parameters["@SP_JOFILMMICRON"].Value =Convert.ToDouble(txtbx_bopp_micron.Text);
						
						cmd_data_add.Parameters.Add(new SqlParameter("@SP_JOFILMKG", SqlDbType.Float));
						cmd_data_add.Parameters["@SP_JOFILMKG"].Value = Convert.ToDouble(txtbx_bopp_micron.Text);
	
						cmd_data_add.Parameters.Add(new SqlParameter("@SP_JOPRODDATE", SqlDbType.DateTime)); //create parameter pada sql bwk data SP_RefNumber untuk dihantar semula
						cmd_data_add.Parameters["@SP_JOPRODDATE"].Value = dateTimePicker1.Value;
						
						cmd_data_add.Parameters.Add(new SqlParameter("@SP_JOPRODOPERATOR", SqlDbType.NVarChar, 50));
						cmd_data_add.Parameters["@SP_JOPRODOPERATOR"].Value = "0";
						
						cmd_data_add.Parameters.Add(new SqlParameter("@SP_JOPRODHELPER", SqlDbType.NVarChar, 50));
						cmd_data_add.Parameters["@SP_JOPRODHELPER"].Value = "0";
						
						cmd_data_add.Parameters.Add(new SqlParameter("@SP_JOPRODQTY", SqlDbType.Float));
						cmd_data_add.Parameters["@SP_JOPRODQTY"].Value = "0";
						
						cmd_data_add.Parameters.Add(new SqlParameter("@SP_JOPRODLOTNO", SqlDbType.NVarChar, 50));
						cmd_data_add.Parameters["@SP_JOPRODLOTNO"].Value ="0";
						
						cmd_data_add.Parameters.Add(new SqlParameter("@SP_JOPRODBATCHNO", SqlDbType.NVarChar, 50));
						cmd_data_add.Parameters["@SP_JOPRODBATCHNO"].Value = "0";
						
						cmd_data_add.Parameters.Add(new SqlParameter("@SP_JOPRODMACHINENO", SqlDbType.NVarChar, 50));
						cmd_data_add.Parameters["@SP_JOPRODMACHINENO"].Value = "0";
						
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
						
						cmd_data_add.Parameters.Add(new SqlParameter("@SP_JOREMARK6", SqlDbType.NVarChar, 50));
						cmd_data_add.Parameters["@SP_JOREMARK6"].Value = txtbx_remark6.Text.ToUpper();
						
						cmd_data_add.Parameters.Add(new SqlParameter("@SP_JOREMARK7", SqlDbType.NVarChar, 50));
						cmd_data_add.Parameters["@SP_JOREMARK7"].Value = txtbx_remark7.Text.ToUpper();
						
						cmd_data_add.Parameters.Add(new SqlParameter("@SP_JOREMARK8", SqlDbType.NVarChar, 50));
						cmd_data_add.Parameters["@SP_JOREMARK8"].Value = txtbx_remark8.Text.ToUpper();
						
						cmd_data_add.Parameters.Add(new SqlParameter("@SP_JOREMARK9", SqlDbType.NVarChar, 50));
						cmd_data_add.Parameters["@SP_JOREMARK9"].Value = txtbx_remark9.Text.ToUpper();
						
						cmd_data_add.Parameters.Add(new SqlParameter("@SP_JOREMARK10", SqlDbType.NVarChar, 50));
						cmd_data_add.Parameters["@SP_JOREMARK10"].Value = txtbx_remark10.Text.ToUpper();
						
						cmd_data_add.Parameters.Add(new SqlParameter("@SP_JOSO", SqlDbType.NVarChar, 50));
						cmd_data_add.Parameters["@SP_JOSO"].Value ="0";
						
						cmd_data_add.Parameters.Add(new SqlParameter("@SP_JOWTGLUE", SqlDbType.Float));
						cmd_data_add.Parameters["@SP_JOWTGLUE"].Value = Convert.ToDouble(txtbx_wtglue.Text);
						
						cmd_data_add.Parameters.Add(new SqlParameter("@SP_JOWTFILM", SqlDbType.Float));
						cmd_data_add.Parameters["@SP_JOWTFILM"].Value = Convert.ToDouble(txtbx_wtfilm.Text);
						
						cmd_data_add.Parameters.Add(new SqlParameter("@SP_JOWTTOTAL1", SqlDbType.Float));
						cmd_data_add.Parameters["@SP_JOWTTOTAL1"].Value = Convert.ToDouble(txtbx_total1.Text);
    	
    					cmd_data_add.Parameters.Add(new SqlParameter("@SP_JOWTCORE", SqlDbType.Float));
						cmd_data_add.Parameters["@SP_JOWTCORE"].Value = Convert.ToDouble(txtbx_total1.Text);

    	
 						cmd_data_add.Parameters.Add(new SqlParameter("@SP_JOWTTOTAL2", SqlDbType.Float));
						cmd_data_add.Parameters["@SP_JOWTTOTAL2"].Value = Convert.ToDouble(txtbx_total2.Text);
    	
						cmd_data_add.Parameters.Add(new SqlParameter("@SP_JOWTPACK", SqlDbType.Float));
						cmd_data_add.Parameters["@SP_JOWTPACK"].Value = Convert.ToDouble(txtbx_packing.Text);
						
						cmd_data_add.Parameters.Add(new SqlParameter("@SP_JOWTTOTAL3", SqlDbType.Float));
						cmd_data_add.Parameters["@SP_JOWTTOTAL3"].Value = Convert.ToDouble(txtbx_totalfinal.Text);
						
    	
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
			DialogBox.ShowWarningMessage(" successfull add.");
			
			
			System.Windows.Forms.Form frm = new System.Windows.Forms.Form();
        frm.Height = 600;
        frm.Width = 800;

        fyiReporting.RdlViewer.RdlViewer rdlView = new fyiReporting.RdlViewer.RdlViewer();
        fyiReporting.RdlViewer.ViewerToolstrip report = new fyiReporting.RdlViewer.ViewerToolstrip(rdlView);
        Uri baseUri = new Uri(System.IO.Directory.GetCurrentDirectory());
        rdlView.SourceFile = new Uri(baseUri,@"../report/planning_jo_coating_double_side.rdl");
    
        rdlView.Report.DataSets["Data"].SetSource("select * from TBL_PROD_COATING_DOUBLE_SIDE where JODOCNO = '" + txtbx_refno.Text + "'");
	    rdlView.Rebuild();

        rdlView.Dock = DockStyle.Fill;
        frm.Controls.Add(rdlView);
        frm.Controls.Add(report);

        frm.ShowDialog(this);
		
			}
		
		
		void Btn_deleteClick(object sender, EventArgs e)
		{
			SqlConnection con_data_del = new SqlConnection(sqlconn);
				System.Data.SqlClient.SqlCommand cmd_data_del = new SqlCommand();  //adress pergi ke sql
				try {

						cmd_data_del.Connection = con_data_del;		//coman run store procedure
						cmd_data_del.CommandText = "SP_PROD_COATING_DOUBLE_SIDE_DEL";	//nama store procedure
						cmd_data_del.CommandType = CommandType.StoredProcedure;		//declare comand
    	
						cmd_data_del.Parameters.Add(new SqlParameter("@SP_JODATE", SqlDbType.DateTime)); //create parameter pada sql bwk data SP_RefNumber untuk dihantar semula
						cmd_data_del.Parameters["@SP_JODATE"].Value = dateTimePicker1.Value;
				
						cmd_data_del.Parameters.Add(new SqlParameter("@SP_JODOCNO", SqlDbType. NVarChar, 50)); //create parameter pada sql bwk data SP_RefNumber untuk dihantar semula
						cmd_data_del.Parameters["@SP_JODOCNO"].Value = txtbx_joso.Text.ToUpper();
						
						cmd_data_del.Parameters.Add(new SqlParameter("@SP_JOSALESNO", SqlDbType. NVarChar, 50)); //create parameter pada sql bwk data SP_RefNumber untuk dihantar semula
						cmd_data_del.Parameters["@SP_JOSALESNO"].Value = txtbx_joso.Text.ToUpper();
						
						cmd_data_del.Parameters.Add(new SqlParameter("@SP_JOSALESLINE", SqlDbType. NVarChar, 50)); //create parameter pada sql bwk data SP_RefNumber untuk dihantar semula
						cmd_data_del.Parameters["@SP_JOSALESLINE"].Value = "0";
						
						cmd_data_del.Parameters.Add(new SqlParameter("@SP_JOSTOCKCODE", SqlDbType.NVarChar, 50));
						cmd_data_del.Parameters["@SP_JOSTOCKCODE"].Value = txtbx_joso.Text.ToUpper();
						
						cmd_data_del.Parameters.Add(new SqlParameter("@SP_JRSTOCKCODE", SqlDbType.NVarChar, 50));
						cmd_data_del.Parameters["@SP_JRSTOCKCODE"].Value = "0";
						
						cmd_data_del.Parameters.Add(new SqlParameter("@SP_JOSTOCKDESC", SqlDbType.NVarChar, 50));
						cmd_data_del.Parameters["@SP_JOSTOCKDESC"].Value = txtbx_sodesc1.Text.ToUpper();
						
						cmd_data_del.Parameters.Add(new SqlParameter("@SP_JOSTOCKDESC2", SqlDbType.NVarChar, 50));
						cmd_data_del.Parameters["@SP_JOSTOCKDESC2"].Value = txtbx_sodesc2.Text.ToUpper();
						
						cmd_data_del.Parameters.Add(new SqlParameter("@SP_JOSTOCKCOLOR", SqlDbType.NVarChar, 50));
						cmd_data_del.Parameters["@SP_JOSTOCKCOLOR"].Value="0";  //tukar daripada string kepada nombor
						
						cmd_data_del.Parameters.Add(new SqlParameter("@SP_JRCOLOR", SqlDbType.NVarChar, 50));
						cmd_data_del.Parameters["@SP_JRCOLOR"].Value = "0";  //tukar daripada string kepada nom
						
    						cmd_data_del.Parameters.Add(new SqlParameter("@SP_JOSTOCKBRAND", SqlDbType.NVarChar, 50));
						cmd_data_del.Parameters["@SP_JOSTOCKBRAND"].Value= "0"; 
						
						cmd_data_del.Parameters.Add(new SqlParameter("@SP_JOSMARKCODE", SqlDbType.NVarChar, 50));
						cmd_data_del.Parameters["@SP_JOSMARKCODE"].Value=txtbx_smarkcode.Text.ToUpper(); 
						
						cmd_data_del.Parameters.Add(new SqlParameter("@SP_JOJRCATEGORY", SqlDbType.NVarChar, 50));
						cmd_data_del.Parameters["@SP_JOJRCATEGORY"].Value = combobx_category.Text;
						
						cmd_data_del.Parameters.Add(new SqlParameter("@SP_JOSMARKLINE", SqlDbType.NVarChar, 50));
						cmd_data_del.Parameters["@SP_JOSMARKLINE"].Value=txtbx_smarkicode.Text.ToUpper(); 
						
						cmd_data_del.Parameters.Add(new SqlParameter("@SP_JOSTOCKWIDTH", SqlDbType.Float));
						cmd_data_del.Parameters["@SP_JOSTOCKWIDTH"].Value = 0;
						
						cmd_data_del.Parameters.Add(new SqlParameter("@SP_JOSTOCKLENGTH", SqlDbType.Float));
						cmd_data_del.Parameters["@SP_JOSTOCKLENGTH"].Value = 0;
						
						//MessageBox.Show(txtbx
						
						//TUKAR QTY ORDERED KEPADA JO JR QTY
					
    						cmd_data_del.Parameters.Add(new SqlParameter("@SP_JOSTOCKMICRON", SqlDbType.Float));
						cmd_data_del.Parameters["@SP_JOSTOCKMICRON"].Value =Convert.ToDouble(txtbx_micron.Text);
						
						cmd_data_del.Parameters.Add(new SqlParameter("@SP_JOSTOCKMICRONM2", SqlDbType.NVarChar, 50));
						cmd_data_del.Parameters["@SP_JOSTOCKMICRONM2"].Value = txtbx_M2.Text.ToUpper(); 
				
						
						cmd_data_del.Parameters.Add(new SqlParameter("@SP_JOJRM2", SqlDbType.Float));
						cmd_data_del.Parameters["@SP_JOJRM2"].Value = 0;
						
						cmd_data_del.Parameters.Add(new SqlParameter("@SP_PRODUCTWIDTH", SqlDbType.Float));
						cmd_data_del.Parameters["@SP_PRODUCTWIDTH"].Value =Convert.ToDouble(txtbx_productwidth.Text);
						
						cmd_data_del.Parameters.Add(new SqlParameter("@SP_PRODUCTLENGTH", SqlDbType.Float));
						cmd_data_del.Parameters["@SP_PRODUCTLENGTH"].Value =Convert.ToDouble(txtbx_productlength.Text);
						
						cmd_data_del.Parameters.Add(new SqlParameter("@SP_JOSTOCKMICRONMIN", SqlDbType.Float));
						cmd_data_del.Parameters["@SP_JOSTOCKMICRONMIN"].Value = Convert.ToDouble(txtbx_minimummic.Text);
    
			
    
						cmd_data_del.Parameters.Add(new SqlParameter("@SP_JOSTOCKMICRONMAX", SqlDbType.Float));
						cmd_data_del.Parameters["@SP_JOSTOCKMICRONMAX"].Value = Convert.ToDouble(txtbx_micmax.Text);
    		
    					cmd_data_del.Parameters.Add(new SqlParameter("@SP_JOSTOCKKGMIN", SqlDbType.Float));
    					cmd_data_del.Parameters["@SP_JOSTOCKKGMIN"].Value = Convert.ToDouble(txtbx_kgmin.Text);
					
    					cmd_data_del.Parameters.Add(new SqlParameter("@SP_JOSTOCKKGMAX", SqlDbType.Float));
						cmd_data_del.Parameters["@SP_JOSTOCKKGMAX"].Value = Convert.ToDouble(txtbx_kgmax.Text);
						
						cmd_data_del.Parameters.Add(new SqlParameter("@SP_JOQTY", SqlDbType.Float));
						cmd_data_del.Parameters["@SP_JOQTY"].Value = 0;
						
						cmd_data_del.Parameters.Add(new SqlParameter("@SP_JOCUSTOMER", SqlDbType.NVarChar, 50));
						cmd_data_del.Parameters["@SP_JOCUSTOMER"].Value = txtbx_socustomer.Text.ToUpper();
						
						cmd_data_del.Parameters.Add(new SqlParameter("@SP_JOCUSTOMERTYPE", SqlDbType.NVarChar, 50));
						cmd_data_del.Parameters["@SP_JOCUSTOMERTYPE"].Value = "0";
						
						cmd_data_del.Parameters.Add(new SqlParameter("@SP_JOGLUECODE", SqlDbType.NVarChar, 50));
						cmd_data_del.Parameters["@SP_JOGLUECODE"].Value = txtbx_gluecode.Text.ToUpper();
				
						cmd_data_del.Parameters.Add(new SqlParameter("@SP_JOGLUEWIDTH", SqlDbType.Float));
						cmd_data_del.Parameters["@SP_JOGLUEWIDTH"].Value = Convert.ToDouble(txtbx_gluewidth.Text);
			
						cmd_data_del.Parameters.Add(new SqlParameter("@SP_JOGLUELENGTH", SqlDbType.Float));
						cmd_data_del.Parameters["@SP_JOGLUELENGTH"].Value = Convert.ToDouble(txtbx_bopp_length.Text);
						
						cmd_data_del.Parameters.Add(new SqlParameter("@SP_JOGLUEMICRON", SqlDbType.Float));
						cmd_data_del.Parameters["@SP_JOGLUEMICRON"].Value = Convert.ToDouble(txtbx_gluemicron.Text);
					
						cmd_data_del.Parameters.Add(new SqlParameter("@SP_JOGLUEKG", SqlDbType.Float));
						cmd_data_del.Parameters["@SP_JOGLUEKG"].Value = Convert.ToDouble(txtbx_gluemicron.Text);
    
    					cmd_data_del.Parameters.Add(new SqlParameter("@SP_JOFILMCODE", SqlDbType.NVarChar, 50));
						cmd_data_del.Parameters["@SP_JOFILMCODE"].Value = combo_box3.Text;
    
    					cmd_data_del.Parameters.Add(new SqlParameter("@SP_JOFILMWIDTH", SqlDbType.Float));
						cmd_data_del.Parameters["@SP_JOFILMWIDTH"].Value =Convert.ToDouble(txtbx_bopp_width.Text);
    					                        
   						cmd_data_del.Parameters.Add(new SqlParameter("@SP_JOFILMLENGTH", SqlDbType.Float));
    					cmd_data_del.Parameters["@SP_JOFILMLENGTH"].Value = Convert.ToDouble(txtbx_bopp_length.Text);

    	
    					cmd_data_del.Parameters.Add(new SqlParameter("@SP_JOFILMMICRON", SqlDbType.Float));
						cmd_data_del.Parameters["@SP_JOFILMMICRON"].Value =Convert.ToDouble(txtbx_bopp_micron.Text);
						
						cmd_data_del.Parameters.Add(new SqlParameter("@SP_JOFILMKG", SqlDbType.Float));
						cmd_data_del.Parameters["@SP_JOFILMKG"].Value = Convert.ToDouble(txtbx_bopp_micron.Text);
	
						cmd_data_del.Parameters.Add(new SqlParameter("@SP_JOPRODDATE", SqlDbType.DateTime)); //create parameter pada sql bwk data SP_RefNumber untuk dihantar semula
						cmd_data_del.Parameters["@SP_JOPRODDATE"].Value = dateTimePicker1.Value;
						
						cmd_data_del.Parameters.Add(new SqlParameter("@SP_JOPRODOPERATOR", SqlDbType.NVarChar, 50));
						cmd_data_del.Parameters["@SP_JOPRODOPERATOR"].Value = "0";
						
						cmd_data_del.Parameters.Add(new SqlParameter("@SP_JOPRODHELPER", SqlDbType.NVarChar, 50));
						cmd_data_del.Parameters["@SP_JOPRODHELPER"].Value = "0";
						
						cmd_data_del.Parameters.Add(new SqlParameter("@SP_JOPRODQTY", SqlDbType.Float));
						cmd_data_del.Parameters["@SP_JOPRODQTY"].Value = "0";
						
						cmd_data_del.Parameters.Add(new SqlParameter("@SP_JOPRODLOTNO", SqlDbType.NVarChar, 50));
						cmd_data_del.Parameters["@SP_JOPRODLOTNO"].Value ="0";
						
						cmd_data_del.Parameters.Add(new SqlParameter("@SP_JOPRODBATCHNO", SqlDbType.NVarChar, 50));
						cmd_data_del.Parameters["@SP_JOPRODBATCHNO"].Value = "0";
						
						cmd_data_del.Parameters.Add(new SqlParameter("@SP_JOPRODMACHINENO", SqlDbType.NVarChar, 50));
						cmd_data_del.Parameters["@SP_JOPRODMACHINENO"].Value = "0";
						
						cmd_data_del.Parameters.Add(new SqlParameter("@SP_JOREMARK1", SqlDbType.NVarChar, 50));
						cmd_data_del.Parameters["@SP_JOREMARK1"].Value = txtbx_remark1.Text.ToUpper();
						
						cmd_data_del.Parameters.Add(new SqlParameter("@SP_JOREMARK2", SqlDbType.NVarChar, 50));
						cmd_data_del.Parameters["@SP_JOREMARK2"].Value = txtbx_remark2.Text.ToUpper();
						
						cmd_data_del.Parameters.Add(new SqlParameter("@SP_JOREMARK3", SqlDbType.NVarChar, 50));
						cmd_data_del.Parameters["@SP_JOREMARK3"].Value = txtbx_remark3.Text.ToUpper();
						
						cmd_data_del.Parameters.Add(new SqlParameter("@SP_JOREMARK4", SqlDbType.NVarChar, 50));
						cmd_data_del.Parameters["@SP_JOREMARK4"].Value = txtbx_remark4.Text.ToUpper();
						
						cmd_data_del.Parameters.Add(new SqlParameter("@SP_JOREMARK5", SqlDbType.NVarChar, 50));
						cmd_data_del.Parameters["@SP_JOREMARK5"].Value = txtbx_remark5.Text.ToUpper();
						
						cmd_data_del.Parameters.Add(new SqlParameter("@SP_JOREMARK6", SqlDbType.NVarChar, 50));
						cmd_data_del.Parameters["@SP_JOREMARK6"].Value = txtbx_remark6.Text.ToUpper();
						
						cmd_data_del.Parameters.Add(new SqlParameter("@SP_JOREMARK7", SqlDbType.NVarChar, 50));
						cmd_data_del.Parameters["@SP_JOREMARK7"].Value = txtbx_remark7.Text.ToUpper();
						
						cmd_data_del.Parameters.Add(new SqlParameter("@SP_JOREMARK8", SqlDbType.NVarChar, 50));
						cmd_data_del.Parameters["@SP_JOREMARK8"].Value = txtbx_remark8.Text.ToUpper();
						
						cmd_data_del.Parameters.Add(new SqlParameter("@SP_JOREMARK9", SqlDbType.NVarChar, 50));
						cmd_data_del.Parameters["@SP_JOREMARK9"].Value = txtbx_remark9.Text.ToUpper();
						
						cmd_data_del.Parameters.Add(new SqlParameter("@SP_JOREMARK10", SqlDbType.NVarChar, 50));
						cmd_data_del.Parameters["@SP_JOREMARK10"].Value = txtbx_remark10.Text.ToUpper();
						
						cmd_data_del.Parameters.Add(new SqlParameter("@SP_JOSO", SqlDbType.NVarChar, 50));
						cmd_data_del.Parameters["@SP_JOSO"].Value ="0";
						
						cmd_data_del.Parameters.Add(new SqlParameter("@SP_JOWTGLUE", SqlDbType.Float));
						cmd_data_del.Parameters["@SP_JOWTGLUE"].Value = Convert.ToDouble(txtbx_wtglue.Text);
						
						cmd_data_del.Parameters.Add(new SqlParameter("@SP_JOWTFILM", SqlDbType.Float));
						cmd_data_del.Parameters["@SP_JOWTFILM"].Value = Convert.ToDouble(txtbx_wtfilm.Text);
						
						cmd_data_del.Parameters.Add(new SqlParameter("@SP_JOWTTOTAL1", SqlDbType.Float));
						cmd_data_del.Parameters["@SP_JOWTTOTAL1"].Value = Convert.ToDouble(txtbx_total1.Text);
    	
    						cmd_data_del.Parameters.Add(new SqlParameter("@SP_JOWTCORE", SqlDbType.Float));
						cmd_data_del.Parameters["@SP_JOWTCORE"].Value = Convert.ToDouble(txtbx_total1.Text);

    	
 						cmd_data_del.Parameters.Add(new SqlParameter("@SP_JOWTTOTAL2", SqlDbType.Float));
						cmd_data_del.Parameters["@SP_JOWTTOTAL2"].Value = Convert.ToDouble(txtbx_total2.Text);
    	
						cmd_data_del.Parameters.Add(new SqlParameter("@SP_JOWTPACK", SqlDbType.Float));
						cmd_data_del.Parameters["@SP_JOWTPACK"].Value = Convert.ToDouble(txtbx_packing.Text);
						
						cmd_data_del.Parameters.Add(new SqlParameter("@SP_JOWTTOTAL3", SqlDbType.Float));
						cmd_data_del.Parameters["@SP_JOWTTOTAL3"].Value = Convert.ToDouble(txtbx_totalfinal.Text);
						
    	
						con_data_del.Open();
						cmd_data_del.ExecuteNonQuery();
						cmd_data_del.Parameters.Clear();
						
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
			DialogBox.ShowWarningMessage(" successfull del.");
		}
		
		public void JrCategory()
		{
			string sqlStatement = "SELECT Category FROM TBL_JUMBO_ROLE_CATEGORY";
			SqlConnection sqlConn = new SqlConnection(sqlconn);
			DataSet ds = new DataSet();
			SqlDataAdapter sda = new SqlDataAdapter(sqlStatement, sqlConn);
					
			try 
			{
						
				sqlConn.Open();
				sda.Fill(ds);
				combobx_category.Text = "Please Select";
					
			}
						

			
		
			catch (Exception ex) 
			{
					DialogBox.ShowWarningMessage("An error occured while connecting to database" + ex.Message + ex.ToString());
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
				combobx_category.Items.Add(dr1["Category"].ToString());
			}
				
		}
		
		public void BOPPFilmList()	//hanya untuk dropdown
		{
			string sqlStatement = "select StockCode from TBL_PROD_COAT_BOPP_FILM_LIST";
			SqlConnection sqlConn = new SqlConnection(sqlconn);
			DataSet ds = new DataSet();
			SqlDataAdapter sda = new SqlDataAdapter(sqlStatement, sqlConn);
					
			try 
			{
						
				sqlConn.Open();
				sda.Fill(ds);
				combo_box3.Text = "Please Select";
						

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
				combo_box3.Items.Add(dr1["StockCode"].ToString());
			}
				
		}
		
		void Combo_box3SelectedIndexChanged(object sender, EventArgs e)
		{
			SqlConnection con = new SqlConnection(sqlconn);
			string sqlStatement = "select StockMicron, StockWidth, StockLength from TBL_PROD_COAT_BOPP_FILM_LIST where StockCode = '"+combo_box3.Text+"'";
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
					txtbx_bopp_micron.Text = (string) dbr["StockMicron"].ToString();
					txtbx_bopp_width.Text = (string) dbr["StockWidth"].ToString();
					txtbx_bopp_length.Text = (string) dbr["StockLength"].ToString();
			
				}
			}
			catch(Exception es)
			{
				MessageBox.Show("Error" + es.Message + es.ToString());
			}
				
						if (txtbx_bopp_width.Text == "1615")
					{
						txtbx_gluewidth.Text = "1600";
					}
					else if (txtbx_bopp_width.Text == "1610")
					{
						txtbx_gluewidth.Text = "1595";
					}
					else if (txtbx_bopp_width.Text == "1270" || txtbx_bopp_width.Text == "1280")
					{
						txtbx_gluewidth.Text = "1260";
					}
					else if (txtbx_bopp_width.Text == "990") 
					{
						txtbx_gluewidth.Text = "970";
					}
					else if	(txtbx_bopp_width.Text == "900")
					{
						txtbx_gluewidth.Text = "890";
					} 
					else if (txtbx_bopp_width.Text == "1320")
					{
						txtbx_gluewidth.Text = "1305";
					} 
					else 
					{
						txtbx_gluewidth.Text = "0";
					}
				
					
					
					if (txtbx_bopp_width.Text == "1615")
					{
						txtbx_core.Text = "3.5";
					}
					else if (txtbx_bopp_width.Text == "1610") 
					{
						//TxtBx_WTCORE.Text = 3.5
						txtbx_core.Text = "3";
					} 
					//else if (txtbx_bopp_width.Text == "1270" || txtbx_jrwidth.Text == "1280")
					//{
						//TxtBx_WTCORE.Text = 3
						//txtbx_core.Text = "2.5";
					//} 
					else if (txtbx_bopp_width.Text == "990")
					{
						txtbx_core.Text = "2";
					} 
					else if (txtbx_bopp_width.Text == "900")
					{
						txtbx_core.Text = "2";
					} 
					else if (txtbx_bopp_width.Text == "1320") 
					{
						txtbx_core.Text = "3";
					}
					else 
					{
						txtbx_core.Text = "0";
					}
					
					
					
				
					if (txtbx_bopp_width.Text == "1615")
					{
						txtbx_packing.Text = "3";
					} 
					else if (txtbx_bopp_width.Text == "1610")
					{
						txtbx_packing.Text = "3";
					} 
					//else if(txtbx_bopp_width.Text == "1270" || txtbx_jrwidth.Text == "1280") 
					//{
					//	txtbx_packing.Text = "2.5";
					//} 
					else if (txtbx_bopp_width.Text == "990")
					{
						txtbx_packing.Text = "2";
					}
					else if (txtbx_bopp_width.Text == "900")
					{
						txtbx_packing.Text = "2";
					} 
					else if (txtbx_bopp_width.Text == "1320")
					{
						txtbx_packing.Text = "2.5";
					} 
					else
					{
						txtbx_packing.Text = "0";
					}

					txtbx_bopp_width.Text = txtbx_bopp_width.Text;
		
//			try
//			{
//				con.Open();
//				dbr = cmd.ExecuteReader();
//				while(dbr.Read())
//				{
//					int stockwidth = (string) dbr["ID"].tostring;
//					int  = (string) dbr["name"] // name is string value
//					string ssurname = (string) dbr["surname"]
//					string sage = (string) dbr["age"].tostring;
//					txtbx_bopp_micron.Text = (string) dbr["StockMicron"].ToString();
//					txtbx_bopp_width.Text = (string) dbr["StockWidth"].ToString();
//					txtbx_bopp_length.Text = (string) dbr["StockLength"].ToString();
//			
//				}			
	//		}
			
//			catch(Exception es)
//			{
//				MessageBox.Show("Error" + es.Message + es.ToString());
//			}
		}

		void Btn_cancelClick(object sender, EventArgs e)
		{
//			DialogResult cancel = new DialogResult();
//            cancel = MessageBox.Show("Are you sure to exit?", "Cancel", 
//                     MessageBoxButtons.YesNo, 
//                     MessageBoxIcon.Warning, 
//                     MessageBoxDefaultButton.Button2);
//            if (cancel == DialogResult.Yes)
                //Application.Exit();	

            this.Close();
		}
		
		void Btn_clearClick(object sender, EventArgs e)
		{
			txtbx_refno.Clear();
			txtbx_joso.Clear();
			//txtbx_soline.Clear();
			txtbx_socustomer.Clear();
			//txtbx_brand.Clear();
			//txtbx_customertype.Clear();
			combobx_category.SelectedIndex = 0;
			txtbx_sodesc1.Clear();
			txtbx_sodesc2.Clear();
			
			txtbx_micron.Clear();
			txtbx_M2.Clear();
			txtbx_minimummic.Clear();
			txtbx_micmax.Clear();
			//txtbx_jrwidth.Clear();
			//txtbx_jrlength.Clear();
			//txtbx_colour.Clear();
			//txtbx_qtyorder.Clear();
			//txtbx_jrm2.Clear();
			//txtbx_jojrqty.Clear();
			//txtbx_color1.SelectedIndex = 0;
			//combo_box3.SelectedIndex = 0;
			txtbx_bopp_micron.Clear();
			txtbx_bopp_width.Clear();
			txtbx_bopp_length.Clear();
			txtbx_gluecode.Clear();
			txtbx_gluemicron.Clear();
			txtbx_gluewidth.Clear();
			txtbx_wtfilm.Clear();
			txtbx_wtglue.Clear();
			txtbx_total1.Clear();
			
			//combo_box3.SelectedIndex = 0;
			txtbx_core.Clear();
			txtbx_total2.Clear();
			txtbx_packing.Clear();
			txtbx_totalfinal.Clear();
			txtbx_productwidth.Clear();
			txtbx_productlength.Clear();
			txtbx_kgmin.Clear();
			txtbx_kgmax.Clear();
			//txtbx_extrameter.Clear();
			
			
			txtbx_remark1.Clear();
			txtbx_remark2.Clear();
			txtbx_remark3.Clear();
			txtbx_remark4.Clear();
			txtbx_remark5.Clear();
			txtbx_smarkcode.Clear();
			txtbx_smarkicode.Clear();
			txtbx_remark6.Clear();
			txtbx_remark7.Clear();
			
			txtbx_remark8.Clear();
			txtbx_remark9.Clear();
			txtbx_remark10.Clear();
			//TxtBx_StockCode1.Clear();
			//TxtBx_JRColor1.Clear();
			//txtbx_costglue.Clear();
			txtbx_productlength.Clear();
			//txtbx_costconvert.Clear();
			//txtbx_costservice.Clear();			
		}
		
		void Btn_calcweightClick(object sender, EventArgs e)
		{
			txtbx_gluemicron.Text = Convert.ToString(Math.Round(((Convert.ToDouble(txtbx_micmax.Text)  + Convert.ToDouble(txtbx_minimummic.Text)) / 2 - (Convert.ToDouble(txtbx_bopp_micron.Text))),2));
			txtbx_wtfilm.Text = Convert.ToString(Math.Round(((Convert.ToDouble(txtbx_bopp_micron.Text) * 0.91 * (double) Convert.ToDouble(txtbx_bopp_length.Text) / 1000 *  Convert.ToInt32(txtbx_bopp_length.Text) / 1000)),2));
			txtbx_wtglue.Text = Convert.ToString(Math.Round(((Convert.ToDouble(txtbx_gluemicron.Text) * 1.05 * (double) Convert.ToDouble(txtbx_bopp_length.Text) / 1000 *  Convert.ToInt32(txtbx_bopp_length.Text) / 1000)),2));
			txtbx_total1.Text = Convert.ToString(Math.Round(((Convert.ToDouble(txtbx_wtfilm.Text) + Convert.ToDouble(txtbx_wtglue.Text))),2));
			txtbx_total2.Text = Convert.ToString(Math.Round(((Convert.ToDouble(txtbx_total1.Text) + Convert.ToDouble(txtbx_core.Text))),2));
			txtbx_totalfinal.Text = Convert.ToString(Convert.ToDouble(txtbx_total2.Text) + Convert.ToDouble(txtbx_packing.Text));
			txtbx_kgmin.Text = Convert.ToString(Math.Round(((Convert.ToDouble(txtbx_totalfinal.Text) - 2.0)),2));
			txtbx_kgmax.Text = Convert.ToString(Math.Round(((Convert.ToDouble(txtbx_totalfinal.Text) + 2.0)),2));
		}
		
		
		
		
		
		
	
		
		
	}
	
}
