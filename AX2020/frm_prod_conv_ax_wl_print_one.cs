using System;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using System.Collections.Generic; // For generic collections like List.
using System.Data.SqlClient;      
using System.Data.Sql;
using System.Data;
using CommonFunction;
using CommonLibrary;
using CommonControl.Functions;

namespace AX2020
{
	
	public partial class frm_prod_conv_ax_wl_print_one : Form
	{
		public static string sqlconn = "Server=AX-UAT; Password=sbax2020sbg; User ID=sbax2020; Initial Catalog=SBG_AX_2020; Integrated Security=false";
		string jr_shipmark, jr_barcode;
		
		public frm_prod_conv_ax_wl_print_one()
		{
			InitializeComponent();
			this.ControlBox = false;
			lbl_username.Text = "User : " + frm_menu_system.userName;
			reportViewer1.Visible = false;
		}
		
		void Btn_cancelClick(object sender, EventArgs e)
		{
			this.Close();
		}
		
		void Btn_clearClick(object sender, EventArgs e)
		{
			txtbx_ref_no.Clear();
		}
		
		
		private DataSet GetData()
		{
			SqlConnection conn = new SqlConnection(sqlconn);
			
			//SqlCommand cmd = new SqlCommand("SELECT PROD_MACHINE, SUM(PROD_QTYCTN) AS SUMQTYCTN, SUM(PROD_M2) AS SUMM2, SUM(PROD_TOTALROLL) AS SUMTOTALROLL FROM TBL_PROD_CONV_JO_QUICK_PACK_SUMMARY_TEMP WHERE PROD_DATE BETWEEN @from_date and @to_date GROUP BY PROD_MACHINE ORDER BY PROD_MACHINE", conn);
			SqlCommand cmd = new SqlCommand(@"SELECT * FROM TBL_PROD_WAREHOUSE_AX_WL_TEMP order by prod_stockcode, prod_shipmark", conn);
				
			//cmd.Parameters.AddWithValue("@sp_ship_mark", txtbx_ref_no.Text.ToUpper());
			
			try
			{
		        SqlDataAdapter dataadapter = new SqlDataAdapter(cmd);
		        conn.Open();
		        DataSet ds = new DataSet();
		        dataadapter.Fill(ds);
		        return (ds);
		                     	        
			}
			catch(Exception ex)
			{
				MessageBox.Show("Error - Warehouse \nCannot load DB" + ex.Message + ex.ToString());
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
		
		void TempTable()
		{
			using (SqlConnection conn = new SqlConnection(sqlconn))
			{
				conn.Open();
				
				SqlCommand cmd  = new SqlCommand("SP_PROD_WAREHOUSE_AX_WL_TEMP", conn);
				cmd.CommandType = CommandType.StoredProcedure;
				
				cmd.Parameters.Add(new SqlParameter("@SP_PROD_STOCKCODE", SqlDbType.NVarChar, 50));
				cmd.Parameters["@SP_PROD_STOCKCODE"].Value = txtbx_ref_no.Text.ToUpper();
					
											   
				cmd.ExecuteNonQuery();
				//return true;					
			}				
		}
		
		
		
		void TempTable2()
		{
			using (SqlConnection conn = new SqlConnection(sqlconn))
			{
				conn.Open();
				
				SqlCommand cmd  = new SqlCommand("SP_PROD_WAREHOUSE_AX_WJ303_TEMP_PO", conn);
				cmd.CommandType = CommandType.StoredProcedure;
				
				cmd.Parameters.Add(new SqlParameter("@SP_PROD_BATCHNUMBER", SqlDbType.NVarChar, 50));
				cmd.Parameters["@SP_PROD_BATCHNUMBER"].Value = txtbx_po_no.Text.ToUpper();
					
											   
				cmd.ExecuteNonQuery();
				//return true;					
			}				
		}
		
		void Btn_searchClick(object sender, EventArgs e)
		{
			if (txtbx_ref_no.Text == null | txtbx_ref_no.Text == string.Empty) 
			{
        		MessageBox.Show("Please key-in stock code");
				return;
			}
			
//			if (txtbx_ref_no.Text == "999") 
//			{
//        		MessageBox.Show("This Shipping Mark cannot be track");
//				return;
//			}
//			
//			SqlConnection con = new SqlConnection(sqlconn);
//			SqlCommand cmd = new SqlCommand();
//			
//			try 
//			{
//				//cmd.CommandText = "select twh, tstk, tlot_no, tref_no, twidth, tlength, tthickness, tcolor from stk_lot where tstk like 'WJ%' and twh = 'GF1' and tbal_qty > 1 '" + txtbx_ref_no.Text + "'";
//				cmd.CommandText = "select JRBarcode, TrxLotNo, TrxJoNo, TrxJoThickness, TrxJoWidth, TrxTotalLength, TrxJoColor, TrxShipMark from VIEW_CONVERTING_BARCODE where TrxShipMark like @ship_mark + '%' or JRBarcode = @ship_mark";
//				cmd.Parameters.AddWithValue("@ship_mark",  txtbx_ref_no.Text.ToUpper());
//				cmd.Connection = con;
//				con.Open();
//				SqlDataReader rd = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
//				
//				if (rd.HasRows)
//				{
//					while (rd.Read())
//					{			        	
//						jr_shipmark = rd["TrxShipMark"].ToString();
//						jr_barcode = rd["JrBarcode"].ToString();
//						jr_lot_no = rd["TrxLotNo"].ToString();
//						jr_ref_no = rd["TrxJoNo"].ToString();
//						txtbx_mic.Text = (Convert.ToInt32(rd["TrxJoThickness"])).ToString();
//						jr_color = rd["TrxJoColor"].ToString();	
						TempTable();
										
//					} 
//				}
//				else 
//				{
//					MessageBox.Show("Shipping Mark does not exist");
//					return;
//				}
//			} 
//			catch (Exception ex) 
//			{
//				MessageBox.Show("Error - Shipmark Check \nCannot load DB!" + ex.Message + ex.ToString());
//				return;
//			} 
//			finally 
//			{
//				con.Close();
//			}
//			
//			con.Dispose();
//			con = null;
//			cmd = null;
			
						
			try
			{
				reportViewer1.Clear();
				reportViewer1.Visible = true;
				reportViewer1.ProcessingMode = ProcessingMode.Local;
				reportViewer1.LocalReport.ReportPath = @"..\..\report\PROD_CONV_AX_WJ303_LABEL.rdl";
				DataSet ds = new DataSet();
				//DataSet ds2 = new DataSet();
				ds = GetData();
				//ds2 = GetData2();
					
				if (ds.Tables[0].Rows.Count > 0)
				{
					reportViewer1.LocalReport.DataSources.Clear();
					ReportDataSource rds = new ReportDataSource("DataSet1", ds.Tables[0]);
					//ReportDataSource rds2 = new ReportDataSource("DataSet2", ds2.Tables[0]);					

					reportViewer1.LocalReport.DataSources.Add(rds);
					//reportViewer1.LocalReport.DataSources.Add(rds2);
						
					reportViewer1.LocalReport.Refresh();
					reportViewer1.RefreshReport();
				}				
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message + ex.InnerException.Message + ex.InnerException.InnerException.Message);
			}
		}
		
		
		void Btn_search_bnClick(object sender, EventArgs e)
		{
			if (btn_search_bn.Text == null | btn_search_bn.Text == string.Empty) 
			{
        		MessageBox.Show("Please key-in Batch Number");
				return;
			}
			
			
		    TempTable2();
									
			try
			{
				reportViewer1.Clear();
				reportViewer1.Visible = true;
				reportViewer1.ProcessingMode = ProcessingMode.Local;
				reportViewer1.LocalReport.ReportPath = @"..\..\report\PROD_CONV_AX_WJ303_LABEL.rdl";
				DataSet ds = new DataSet();
				//DataSet ds2 = new DataSet();
				ds = GetData();
				//ds2 = GetData2();
					
				if (ds.Tables[0].Rows.Count > 0)
				{
					reportViewer1.LocalReport.DataSources.Clear();
					ReportDataSource rds = new ReportDataSource("DataSet1", ds.Tables[0]);
					//ReportDataSource rds2 = new ReportDataSource("DataSet2", ds2.Tables[0]);					

					reportViewer1.LocalReport.DataSources.Add(rds);
					//reportViewer1.LocalReport.DataSources.Add(rds2);
						
					reportViewer1.LocalReport.Refresh();
					reportViewer1.RefreshReport();
				}				
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message + ex.InnerException.Message + ex.InnerException.InnerException.Message);
			}
			
		}
	}
}
