using System;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using System.Collections.Generic; // For generic collections like List.
using System.Data.SqlClient;      // For the database connections and objects.
using System.Data.Sql;
using System.Data;
using System.Data.Sql;

namespace AX2020
{
	
	public partial class frm_rpt_converting_tracking : Form
	{
		public static string sqlconn = "Server=AX-UAT; Password=sbax2020sbg; User ID=sbax2020; Initial Catalog=SBG_AX_2020; Integrated Security=false";
		public static string Sqlconn = "DSN=eb9gf;Port=2138;Uid=dba;Pwd=sql";
		
		//string date_fr, date_to;
		DateTime? date_fr, date_to;
		string username, doc_no;
		
		public frm_rpt_converting_tracking()
		{
			InitializeComponent();
			this.ControlBox = false;
			username = frm_menu_system.userName; 
			lbl_username.Text = "User : " + username;		
		}
		
		private DataSet GetData(string cmd_string, string textbox)
		{
			SqlConnection conn = new SqlConnection(sqlconn);
			SqlCommand cmd = new SqlCommand(cmd_string, conn);
			cmd.Parameters.AddWithValue("@doc_no", textbox);
			
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
				MessageBox.Show("Error - Converting Tracking \nCannot load DB" + ex.Message + ex.ToString());
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
		
		
		private DataSet GetData2(string cmd_string)
		{
			SqlConnection conn = new SqlConnection(sqlconn);
			SqlCommand cmd = new SqlCommand(cmd_string, conn);
			
			
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
				MessageBox.Show("Error - Converting Tracking \nCannot load DB" + ex.Message + ex.ToString());
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
			
		
		void DisplayCoat()
		{
					
			using (SqlConnection conn = new SqlConnection(sqlconn))
			{
				conn.Open();
				SqlCommand cmd  = new SqlCommand("SP_PROD_CONV_TRACKING_SO", conn);
				cmd.CommandType = CommandType.StoredProcedure;
				
				
				cmd.Parameters.Add(new SqlParameter("@SP_DOCNO", SqlDbType.NVarChar, 50));
				cmd.Parameters["@SP_DOCNO"].Value = doc_no;
										        
				
				cmd.ExecuteNonQuery();				
				
			}
		}
		
		void GetDateBtnJO(string jo_no)
		{
			DataSet ds1 = new DataSet();
			DataSet ds2 = new DataSet();
			DataSet ds3 = new DataSet();
			DataSet ds4 = new DataSet();
			DataSet ds5 = new DataSet();
			DataSet ds6 = new DataSet();
				
			ds1 = GetData("SELECT * FROM VIEW_PROD_CONV_TRACKING_SUMMARY WHERE JODOCNO = @doc_no", jo_no);
			ds2 = GetData("SELECT * FROM VIEW_PROD_CONV_TRACKING_SLITTING WHERE PROD_DOCNO = @doc_no", jo_no);
			ds3 = GetData("SELECT * FROM VIEW_PROD_CONV_TRACKING_REWINDING WHERE PROD_DOCNO = @doc_no", jo_no);
			ds4 = GetData("SELECT * FROM VIEW_PROD_CONV_TRACKING_CUTTING WHERE PROD_DOCNO = @doc_no", jo_no);
			ds5 = GetData("SELECT * FROM VIEW_PROD_CONV_TRACKING_PACKING WHERE PROD_DOCNO = @doc_no", jo_no);
			ds6 = GetData2("SELECT DocNo, TrxLotNo, TrxMacID, TrxLeaderID, TrxLeaderID2, TrxQcID, TrxQcID2, TrxOperatorID, TrxOperatorID2, TrxHelperID, TrxJoNo, TrxJoGlue, TrxJoWidth, TrxRawLotNo, TrxRawLotWidth, TrxRawLotThickness, TrxRawLotOriLength, TrxGradeID, TrxShipMark, TrxWeight FROM TBL_PROD_CONV_SUMMARY_COAT_TEMP");
		
			if (ds1.Tables[0].Rows.Count > 0)
				{
					reportViewer1.LocalReport.DataSources.Clear();
					ReportDataSource rds1 = new ReportDataSource("DataSet1", ds1.Tables[0]);
					ReportDataSource rds2 = new ReportDataSource("DataSet2", ds2.Tables[0]);
					ReportDataSource rds3 = new ReportDataSource("DataSet3", ds3.Tables[0]);
					ReportDataSource rds4 = new ReportDataSource("DataSet4", ds4.Tables[0]);
					ReportDataSource rds5 = new ReportDataSource("DataSet5", ds5.Tables[0]);
					ReportDataSource rds6 = new ReportDataSource("DataSet6", ds6.Tables[0]);
					reportViewer1.LocalReport.DataSources.Add(rds1);
					reportViewer1.LocalReport.DataSources.Add(rds2);
					reportViewer1.LocalReport.DataSources.Add(rds3);
					reportViewer1.LocalReport.DataSources.Add(rds4);
					reportViewer1.LocalReport.DataSources.Add(rds5);
					reportViewer1.LocalReport.DataSources.Add(rds6);
					reportViewer1.LocalReport.Refresh();
					reportViewer1.RefreshReport();
				}		
		
		}
		
		void GetDataBtnSO()
		{
			DataSet ds1 = new DataSet();
			DataSet ds2 = new DataSet();
			DataSet ds3 = new DataSet();
			DataSet ds4 = new DataSet();
			DataSet ds5 = new DataSet();
			DataSet ds6 = new DataSet();
				
			ds1 = GetData("SELECT * FROM VIEW_PROD_CONV_TRACKING_SUMMARY WHERE JODOCNO like @doc_no + '%'", doc_no);
			ds2 = GetData("SELECT * FROM VIEW_PROD_CONV_TRACKING_SLITTING WHERE PROD_DOCNO like @doc_no + '%'", doc_no);
			ds3 = GetData("SELECT * FROM VIEW_PROD_CONV_TRACKING_REWINDING WHERE PROD_DOCNO like @doc_no + '%'", doc_no);
			ds4 = GetData("SELECT * FROM VIEW_PROD_CONV_TRACKING_CUTTING WHERE PROD_DOCNO like @doc_no + '%'", doc_no);
			ds5 = GetData("SELECT * FROM VIEW_PROD_CONV_TRACKING_PACKING WHERE PROD_DOCNO like @doc_no + '%'", doc_no);
			ds6 = GetData2("SELECT DocNo, TrxLotNo, TrxMacID, TrxLeaderID, TrxLeaderID2, TrxQcID, TrxQcID2, TrxOperatorID, TrxOperatorID2, TrxHelperID, TrxJoNo, TrxJoGlue, TrxJoWidth, TrxRawLotNo, TrxRawLotWidth, TrxRawLotThickness, TrxRawLotOriLength, TrxGradeID, TrxShipMark, TrxWeight FROM TBL_PROD_CONV_SUMMARY_COAT_TEMP");
		
			if (ds1.Tables[0].Rows.Count > 0 || ds2.Tables[0].Rows.Count > 0 || ds3.Tables[0].Rows.Count > 0 || ds4.Tables[0].Rows.Count > 0 || ds5.Tables[0].Rows.Count > 0 || ds6.Tables[0].Rows.Count > 0)
			{
				reportViewer1.LocalReport.DataSources.Clear();
				ReportDataSource rds1 = new ReportDataSource("DataSet1", ds1.Tables[0]);
				ReportDataSource rds2 = new ReportDataSource("DataSet2", ds2.Tables[0]);
				ReportDataSource rds3 = new ReportDataSource("DataSet3", ds3.Tables[0]);
				ReportDataSource rds4 = new ReportDataSource("DataSet4", ds4.Tables[0]);
				ReportDataSource rds5 = new ReportDataSource("DataSet5", ds5.Tables[0]);
				ReportDataSource rds6 = new ReportDataSource("DataSet6", ds6.Tables[0]);
				reportViewer1.LocalReport.DataSources.Add(rds1);
				reportViewer1.LocalReport.DataSources.Add(rds2);
				reportViewer1.LocalReport.DataSources.Add(rds3);
				reportViewer1.LocalReport.DataSources.Add(rds4);
				reportViewer1.LocalReport.DataSources.Add(rds5);
				reportViewer1.LocalReport.DataSources.Add(rds6);
				reportViewer1.LocalReport.Refresh();
				reportViewer1.RefreshReport();
			}	
			
		}
		
		void Display()
		{
			try
			{
				reportViewer1.Visible = true;
				reportViewer1.ProcessingMode = ProcessingMode.Local;
				reportViewer1.LocalReport.ReportPath = @"..\..\report\PROD_CONV_TRACKING.rdl";
								
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message + ex.InnerException.Message + ex.InnerException.InnerException.Message);
			}
		}
				
		void Btn_cancelClick(object sender, EventArgs e)
		{
			this.Close();
		}
		
		
		void Btn_search_joClick(object sender, EventArgs e)
		{
			if (String.IsNullOrWhiteSpace(txtbx_jo_no.Text))
        	{
        		MessageBox.Show("Please key-in jo no");
        		return;
        	}
			
			doc_no = txtbx_jo_no.Text.ToUpper();
			DisplayCoat();
			Display();
			GetDateBtnJO(doc_no);
		}
		
		void Btn_search_soClick(object sender, EventArgs e)
		{
			if (String.IsNullOrWhiteSpace(txtbx_so_no.Text))
        	{
        		MessageBox.Show("Please key-in so no");
        		return;
        	}
			
			doc_no = txtbx_so_no.Text.ToUpper();
			DisplayCoat();
			Display();
			GetDataBtnSO();			
		}
		
		void Btn_search_packClick(object sender, EventArgs e)
		{
			if (String.IsNullOrWhiteSpace(txtbx_pack_no.Text))
        	{
        		MessageBox.Show("Please key-in packing no");
        		return;
        	}
			
        	//-------------------------------------------------------------------------------------------------------
        	
			SqlConnection con = new SqlConnection(sqlconn);
			SqlCommand cmd = new SqlCommand();
			
			try 
			{
				cmd.CommandText = @"select * from TBL_PROD_CONV_JO_PACKING where PROD_LINE = @line_no";
				cmd.Parameters.AddWithValue("@line_no",  txtbx_pack_no.Text.ToUpper());
				cmd.Connection = con;
				con.Open();
				SqlDataReader dr = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);

				while (dr.Read())
				{
					if (dr.HasRows)
					{
						doc_no = dr["PROD_DOCNO"].ToString();
					}
				}
			}
			catch (Exception ex)
			{
				con.Close();
				MessageBox.Show("Error - Converting Tracking Pack" + ex.Message + ex.ToString());
				return;
			} 
			finally 
			{
				con.Close();
			}
			
			con.Dispose();
			cmd.Dispose();
			con = null;
			cmd = null;       			
			
			DisplayCoat();
			Display();
			GetDateBtnJO(doc_no);
		}
		
		void Btn_search_frClick(object sender, EventArgs e)
		{
			if (String.IsNullOrWhiteSpace(txtbx_fr_lot_no.Text))
        	{
        		MessageBox.Show("Please key-in FR lot no");
        		return;
        	}
			
        	//-------------------------------------------------------------------------------------------------------
        	
			SqlConnection con = new SqlConnection(sqlconn);
			SqlCommand cmd = new SqlCommand();
			
			try 
			{
				cmd.CommandText = @"select * from TBL_PROD_CONV_JO_PACKING where PROD_LOTNO = @lot_no";
				cmd.Parameters.AddWithValue("@lot_no",  txtbx_fr_lot_no.Text.ToUpper());
				cmd.Connection = con;
				con.Open();
				SqlDataReader dr = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);

				while (dr.Read())
				{
					if (dr.HasRows)
					{
						doc_no = dr["PROD_DOCNO"].ToString();
					}
				}
			}
			catch (Exception ex)
			{
				con.Close();
				MessageBox.Show("Error - Converting Tracking FR Lot No" + ex.Message + ex.ToString());
				return;
			} 
			finally 
			{
				con.Close();
			}
			
			con.Dispose();
			cmd.Dispose();
			con = null;
			cmd = null;
			
			DisplayCoat();
			Display();
			GetDateBtnJO(doc_no);			
		}
		
		void Btn_search_jrClick(object sender, EventArgs e)
		{
			if (String.IsNullOrWhiteSpace(txtbx_jr_lot_no.Text))
        	{
        		MessageBox.Show("Please key-in JR lot no");
        		return;
        	}
			
        	//-------------------------------------------------------------------------------------------------------
        	
			SqlConnection con = new SqlConnection(sqlconn);
			SqlCommand cmd = new SqlCommand();
			
			try 
			{
				cmd.CommandText = @"select * from TBL_PROD_CONV_JO_SLITTING where PROD_JRLOTNO = @lot_no";
				cmd.Parameters.AddWithValue("@lot_no",  txtbx_jr_lot_no.Text.ToUpper());
				cmd.Connection = con;
				con.Open();
				SqlDataReader dr = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);

				while (dr.Read())
				{
					if (dr.HasRows)
					{
						doc_no = dr["PROD_DOCNO"].ToString();
					}
				}
			}
			catch (Exception ex)
			{
				con.Close();
				MessageBox.Show("Error - Converting Tracking JR Lot No" + ex.Message + ex.ToString());
				return;
			} 
			finally 
			{
				con.Close();
			}
			
			con.Dispose();
			cmd.Dispose();
			con = null;
			cmd = null;
			
			DisplayCoat();
			Display();
			GetDateBtnJO(doc_no);			
		}
		
		void Btn_search_piClick(object sender, EventArgs e)
		{
			
        	//string ERP_ST_P1_objSqlStatement = "Select * from so_detail";
			string ERP_ST_P1_objSqlStatement = "select * from so_detail where tsou_no = '" + txtbx_pi_no.Text.ToUpper() + "'";
        	SqlConnection ERP_ST_P1_objConn = new SqlConnection(Sqlconn);
               
			try
 			{
            	ERP_ST_P1_objConn.Open();
                SqlCommand ERP_ST_P1_objCMD = new SqlCommand(ERP_ST_P1_objSqlStatement, ERP_ST_P1_objConn);
               	SqlDataReader ERP_ST_P1_objDR  = ERP_ST_P1_objCMD.ExecuteReader();            	
            	
            	if (ERP_ST_P1_objDR.HasRows)
            	{
            		while (ERP_ST_P1_objDR.Read())
            		{
            			doc_no = ERP_ST_P1_objDR["tno"].ToString();
            			
//            			 for (int i = 0; i < ERP_ST_P1_objDR.FieldCount; i++)
//            			 MessageBox.Show(ERP_ST_P1_objDR.GetName(i));
            		} 
            	}
            	else
            	{
            		MessageBox.Show("Error - Converting Tracking PI \nCannot find PI No");
            		return;
            	}

            	//ERP_ST_P1_objDR.Close();
 			} 
 			
 			catch (Exception ERP_ST_P1_exc)
 			{
 				MessageBox.Show("Error - Converting Tracking PI \nCannot load DB" + ERP_ST_P1_exc.Message + ERP_ST_P1_exc.ToString());
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
			
			DisplayCoat();
			Display();
			GetDataBtnSO();			
		}
		
		void Btn_search_invClick(object sender, EventArgs e)
		{
			string ERP_ST_P1_objSqlStatement = "select * from so where tstring30 = '" + txtbx_inv_no.Text.ToUpper() + "'";
        	SqlConnection ERP_ST_P1_objConn = new SqlConnection(Sqlconn);
               
			try
 			{
            	ERP_ST_P1_objConn.Open();
                SqlCommand ERP_ST_P1_objCMD = new SqlCommand(ERP_ST_P1_objSqlStatement, ERP_ST_P1_objConn);
               	SqlDataReader ERP_ST_P1_objDR  = ERP_ST_P1_objCMD.ExecuteReader();            	
            	
            	if (ERP_ST_P1_objDR.HasRows)
            	{
            		while (ERP_ST_P1_objDR.Read())
            		{
            			doc_no = ERP_ST_P1_objDR["tno"].ToString();
            		} 
            	}
            	else
            	{
            		MessageBox.Show("Error - Converting Tracking Inv \nCannot find Inv No");
            		return;
            	}

            	//ERP_ST_P1_objDR.Close();
 			} 
 			
 			catch (Exception ERP_ST_P1_exc)
 			{
 				MessageBox.Show("Error - Converting Tracking Inv \nCannot load DB" + ERP_ST_P1_exc.Message + ERP_ST_P1_exc.ToString());
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
			
			DisplayCoat();
			Display();
			GetDataBtnSO();
						
		}
		
		
	}
}
		
		
	