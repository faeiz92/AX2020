/*
 * Created by SharpDevelop.
 * User: it-4
 * Date: 16/5/2017
 * Time: 3:01 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;
using System.IO;

namespace AX2020
{
	
	public partial class frm_glue_transferdata_erp : Form
	{
		private const string ConnectionString = "server = '192.168.1.210'; Integrated Security=false; Initial Catalog=SB_IOSS_SFA; User ID=sbax2020; Password=sbax2020sbg; Connection TimeOut=900";
    
		public frm_glue_transferdata_erp()
		{
			InitializeComponent();
		}
		
		void CompareData()
		{
			
		}
		void UploadToTempTable()
		{
			SqlConnection conProcessData = new SqlConnection(ConnectionString);
			SqlCommand cmdProcessData = new SqlCommand();
						
			try
			{
				cmdProcessData.CommandText = @"BULK INSERT TBL_IOSS_CURRENT_ORDER_CUSTOMER_DETAIL_POST_R1_TEMP FROM 'C:\AXSFA\axsfa.txt' WITH (FIELDTERMINATOR = '\t', ROWTERMINATOR = '\n')";
				cmdProcessData.Connection = conProcessData;
				conProcessData.Open();						
				
			}
			catch (Exception ex) 
			{
				MessageBox.Show("Error UploadToTempTable : " + ex.Message + ex.ToString());
			} 
			finally 
			{
				conProcessData.Close();
			}
			conProcessData.Dispose();
			conProcessData = null;
			cmdProcessData = null;
			
		}
		
		
		
		void Extract()
		{	
			//*******************************************************************************************************************************************************************
			//BEGIN CREATE TEXT FILE - DETAIL
			//*******************************************************************************************************************************************************************	
			
//				string FILEsourcefile1 = null;
//				StreamWriter FILEsw1 = default(StreamWriter);
//				FILEsourcefile1 = "D:\\Shared9\\export_sad_d.txt";
//				
//				try
//				{
//					FILEsw1 = File.CreateText(FILEsourcefile1);
//					FILEsw1.Flush();
//					FILEsw1.Close();
//				} 
//				catch (Exception ex) 
//				{
//					//Lbl_Message.Text = Lbl_Message.Text + " - " + ex.ToString;
//					MessageBox.Show("Error 1 : " + ex.Message() + ex.ToString());
//					//Interaction.MsgBox("Error File Header : " + ex.ToString());
//					//Exit Sub
//				}
//				
//				*******************************************************************************************************************************************************************
//				END CREATE TEXT FILE - DETAIL
//				*******************************************************************************************************************************************************************
//			
				
			
			
			
				//*******************************************************************************************************************************************************************
				//BEGIN SUMMARY STOCK RECV
				//*******************************************************************************************************************************************************************
				SqlConnection sqlcon_SP_ProcessData1 = new SqlConnection(ConnectionString);
				SqlCommand cmd_SP_ProcessData1 = new SqlCommand();
				
				try
				{
					cmd_SP_ProcessData1.Connection = sqlcon_SP_ProcessData1;
					cmd_SP_ProcessData1.CommandText = "SP_IOSS_CURRENT_ORDER_CUSTOMER_DETAIL_POST_R1";
					cmd_SP_ProcessData1.CommandType = CommandType.StoredProcedure;
					//------------------------------------------------------------------------------------------------------
					//cmd_SP_ProcessData1.Parameters.Add(new SqlParameter("@SP_SAPSNO", SqlDbType.VarChar, 20));
					//cmd_SP_ProcessData1.Parameters("@SP_SAPSNO").Value = SAPSNo;
					//------------------------------------------------------------------------------------------------------
					sqlcon_SP_ProcessData1.Open();
					cmd_SP_ProcessData1.ExecuteNonQuery();
				}
				catch (Exception ex)
				{
					//Lbl_Message.Text = Lbl_Message.Text + " - " + ex.ToString;
					MessageBox.Show("Error 1 : " + ex.Message + ex.ToString());
					//Interaction.MsgBox("Error SP_ProcessData1a " + ex.Message);
					//Exit Sub
				} 
				finally
				{
					sqlcon_SP_ProcessData1.Close();
				}
				
				sqlcon_SP_ProcessData1.Dispose();
				sqlcon_SP_ProcessData1 = null;
				
				//*******************************************************************************************************************************************************************
				//END SUMMARY STOCK RECV
				//*******************************************************************************************************************************************************************
				
				
				
				
//				
//				//*******************************************************************************************************************************************************************
//				//BEGIN SUMMARY STOCK RECV - Incremental Value
//				//*******************************************************************************************************************************************************************
//				System.Data.SqlClient.SqlConnection SP_ProcessData3a_SqlCon = new System.Data.SqlClient.SqlConnection(ConnectionString);
//				string SP_ProcessData3a_QueryStr = "select * from TBL_FORM_PRODUCTION_OUTPUT_PACK_RECEIVED_ERP1 order by productcode";
//				System.Data.SqlClient.SqlCommand SP_ProcessData3a_SqlCmd = new System.Data.SqlClient.SqlCommand(SP_ProcessData3a_QueryStr, SP_ProcessData3a_SqlCon);
//				int ProdNextNumber = 0;
//				ProdNextNumber = 1;
//				
//				try
//				{
//					SP_ProcessData3a_SqlCon.Open();
//					System.Data.SqlClient.SqlDataReader dbr_SP_ProcessData3a_SR = SP_ProcessData3a_SqlCmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
//					if (dbr_SP_ProcessData3a_SR.HasRows) 
//					{
//						while (dbr_SP_ProcessData3a_SR.Read()) 
//						{
//							//*******************************************************************************************************************************************************************
//							System.Data.SqlClient.SqlConnection sqlcon_Update_ProcessData3a = new System.Data.SqlClient.SqlConnection(ConnectionString);
//							System.Data.SqlClient.SqlCommand cmd_Update_Update_ProcessData3a = new SqlCommand();
//							
//							try 
//							{
//								cmd_Update_Update_ProcessData3a.CommandText = "UPDATE TBL_FORM_PRODUCTION_OUTPUT_PACK_RECEIVED_ERP1 set PRODUOM= 'M2', PRODNextNo = " + ProdNextNumber + " where PRODUCTCODE = '" + dbr_SP_ProcessData3a_SR("PRODUCTCODE") + "'";
//								cmd_Update_Update_ProcessData3a.Connection = sqlcon_Update_ProcessData3a;
//								sqlcon_Update_ProcessData3a.Open();
//								cmd_Update_Update_ProcessData3a.ExecuteNonQuery();
//							}
//							catch (Exception ex) 
//							{
//								Lbl_Message.Text = Lbl_Message.Text + " - " + ex.ToString;
//								Interaction.MsgBox("Update ProcessData3a : " + ex.Message);
//								//Exit Sub
//							} finally {
//								sqlcon_Update_ProcessData3a.Close();
//							}
//							sqlcon_Update_ProcessData3a.Dispose();
//							sqlcon_Update_ProcessData3a = null;
//							//*******************************************************************************************************************************************************************
//							ProdNextNumber = ProdNextNumber + 1;
//						}
//					}
//				} catch (Exception ex) {
//					Lbl_Message.Text = Lbl_Message.Text + " - " + ex.ToString;
//					Interaction.MsgBox("Error ProcessData3a :" + ex.ToString(), MsgBoxStyle.Exclamation);
//					//Exit Sub
//				} finally {
//					SP_ProcessData3a_SqlCon.Close();
//					SP_ProcessData3a_SqlCon.Dispose();
//				}
//				SP_ProcessData3a_SqlCon = null;
//				SP_ProcessData3a_QueryStr = null;
//				SP_ProcessData3a_SqlCmd = null;
//				//*******************************************************************************************************************************************************************
//				//END SUMMARY STOCK RECV - Incremental Value
//				//*******************************************************************************************************************************************************************
//			
				
				
				
	//start from this			



				using(FileStream fileStream = new FileStream("C:\\shared9\\glue_erp.txt", FileMode.Create, FileAccess.ReadWrite, FileShare.None))
				{
					using (StreamWriter writer = new StreamWriter(fileStream))
					{
						//*******************************************************************************************************************************************************************
						//BEGIN STOCK ADJUSTMENT DETAIL
						//*******************************************************************************************************************************************************************
						
						//StreamWriter sw1 = new StreamWriter(FILEsourcefile1);
						
						SqlConnection conProcessData1b = new SqlConnection(ConnectionString);
						SqlCommand cmdProcessData1b = new SqlCommand();
						
						try
						{
							cmdProcessData1b.CommandText = "select * from VIEW_GLUE_ERPSI_AX2020";
							cmdProcessData1b.Connection = conProcessData1b;
							conProcessData1b.Open();
							
							SqlDataReader rdProcessData1 = cmdProcessData1b.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
							
							if (rdProcessData1.HasRows)
							{
								while(rdProcessData1.Read())
								{
									for (int index = 0; index < rdProcessData1.FieldCount; index++)
						            {
						                writer.Write(rdProcessData1.GetValue(index));
						
						                if (index < rdProcessData1.FieldCount - 1)
						                {
						                    writer.Write("\t");
						                }
						                else
						                {
						                    writer.WriteLine();
						                }
						            }
					                
								    //fileStream.WriteLine(sqlReader["COLUMN1"] + "\t" + sqlReader["COLUMN2"]);   	
								}
										
								
								//SAPSNumber = rdProcessData3("PROD_JRLOTNO1")
		//						SAPSNumber = SAPSNo;
		//						FlagHasRow = "Y";
							}
						} 
						catch (Exception ex) 
						{
		//					Lbl_Message.Text = Lbl_Message.Text + " - " + ex.ToString;
		//					Lbl_Message.Text = "Error Next Number! " + ex.ToString;
							MessageBox.Show("Error 2 : " + ex.Message + ex.ToString());
							//NextNo = null;
							//Exit Sub
						} 
						finally 
						{
							conProcessData1b.Close();
						}
						conProcessData1b.Dispose();
						conProcessData1b = null;
						cmdProcessData1b = null;
					}
				}
				
				
				//@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
				//===================================================================================================================================================================
				//@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
				
//				
//				System.Data.SqlClient.SqlConnection SP_ProcessData3c_SqlCon = new System.Data.SqlClient.SqlConnection(ConnectionString);
//				string SP_ProcessData3c_QueryStr = "select * from TBL_FORM_PRODUCTION_OUTPUT_PACK_RECEIVED_ERP1 order by productcode";
//				System.Data.SqlClient.SqlCommand SP_ProcessData3c_SqlCmd = new System.Data.SqlClient.SqlCommand(SP_ProcessData3c_QueryStr, SP_ProcessData3c_SqlCon);
//				try {
//					SP_ProcessData3c_SqlCon.Open();
//					System.Data.SqlClient.SqlDataReader dbr_SP_ProcessData3c_SR = SP_ProcessData3c_SqlCmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
//					if (dbr_SP_ProcessData3c_SR.HasRows) {
//						while (dbr_SP_ProcessData3c_SR.Read()) {
//							//*******************************************************************************************************************************************************************
//							sw3.WriteLine(("GF") + Microsoft.VisualBasic.ControlChars.Tab + ("SAD") + Microsoft.VisualBasic.ControlChars.Tab + (SAPSNumber) + Microsoft.VisualBasic.ControlChars.Tab + (dbr_SP_ProcessData3c_SR("PRODNextNo").ToString) + Microsoft.VisualBasic.ControlChars.Tab + (dbr_SP_ProcessData3c_SR("PRODUCTCODE").ToString.Trim) + Microsoft.VisualBasic.ControlChars.Tab + ("GF") + Microsoft.VisualBasic.ControlChars.Tab + (dbr_SP_ProcessData3c_SR("PRODUOM").ToString.Trim) + Microsoft.VisualBasic.ControlChars.Tab + ("1") + Microsoft.VisualBasic.ControlChars.Tab + (dbr_SP_ProcessData3c_SR("PROD_RTOTALROLL").ToString.Trim) + Microsoft.VisualBasic.ControlChars.Tab + ("0") + Microsoft.VisualBasic.ControlChars.Tab + ("T") + Microsoft.VisualBasic.ControlChars.Tab + "0" + Microsoft.VisualBasic.ControlChars.Tab + "0" + Microsoft.VisualBasic.ControlChars.Tab + Microsoft.VisualBasic.ControlChars.Tab + (dbr_SP_ProcessData3c_SR("PROD_RTOTALROLL").ToString.Trim) + Microsoft.VisualBasic.ControlChars.Tab + (dbr_SP_ProcessData3c_SR("PRODUOM").ToString.Trim) + Microsoft.VisualBasic.ControlChars.Tab + ("0") + Microsoft.VisualBasic.ControlChars.Tab + ("N") + Microsoft.VisualBasic.ControlChars.Tab + ("T") + Microsoft.VisualBasic.ControlChars.Tab + ("0") + Microsoft.VisualBasic.ControlChars.Tab + ("0") + Microsoft.VisualBasic.ControlChars.Tab + (dbr_SP_ProcessData3c_SR("PRODUCTDESC1").ToString.Trim) + Microsoft.VisualBasic.ControlChars.Tab + (dbr_SP_ProcessData3c_SR("PRODUCTDESC2").ToString.Trim) + Microsoft.VisualBasic.ControlChars.Tab + (ERPTime) + Microsoft.VisualBasic.ControlChars.Tab);
//							//*******************************************************************************************************************************************************************
//							FlagHasRow = "Y";
//						}
//					}
//				} catch (Exception ex) {
//					Lbl_Message.Text = Lbl_Message.Text + " - " + ex.ToString;
//					Interaction.MsgBox("Error ProcessData3c :" + ex.ToString(), MsgBoxStyle.Exclamation);
//					//Exit Sub
//				} finally {
//					SP_ProcessData3c_SqlCon.Close();
//					SP_ProcessData3c_SqlCon.Dispose();
//				}
//				SP_ProcessData3c_SqlCon = null;
//				SP_ProcessData3c_QueryStr = null;
//				SP_ProcessData3c_SqlCmd = null;
//				//@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
//				//===================================================================================================================================================================
//				//@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
//				sw3.Flush();
//				sw3.Close();
//			}
			//*******************************************************************************************************************************************************************
			//END STOCK ADJUSTMENT DETAIL
			//*******************************************************************************************************************************************************************
			

		}
		
		void MainFormLoad(object sender, EventArgs e)
		{
			UploadToTempTable();
			Extract();
			//textBox1.Text = "Success";
			Application.Exit();
		}
	}
}

