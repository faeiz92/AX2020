using System;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using System.Collections.Generic; // For generic collections like List.
using System.Data.SqlClient;      // For the database connections and objects.
using System.Data.Sql;
using System.Data;

namespace AX2020
{
	public partial class frm_rpt_converting_prod_shift_fast : Form
	{
		public static string sqlconn = "Server=AX-UAT; Password=sbax2020sbg; User ID=sbax2020; Initial Catalog=SBG_AX_2020; Integrated Security=false";
		//string date_fr, date_to;a
		DateTime date_fr, date_to;
		string username;
		
		public frm_rpt_converting_prod_shift_fast()
		{
			InitializeComponent();
			this.ControlBox = false;
			username = frm_menu_system.userName; 
			lbl_username.Text = "User : " + username;
		}
		
		bool Report()
		{
			try
			{
				reportViewer1.Visible = true;
				reportViewer1.ProcessingMode = ProcessingMode.Local;
				reportViewer1.LocalReport.ReportPath = @"..\..\report\PROD_CONV_PROD_FAST.rdl";
				DataSet ds = new DataSet();
				ds = GetData();
				
				if (ds.Tables[0].Rows.Count > 0)
				{
					reportViewer1.LocalReport.DataSources.Clear();
					ReportDataSource rds = new ReportDataSource("DataSet1", ds.Tables[0]);
					ReportDataSource rds2 = new ReportDataSource("DataSet2", ds.Tables[0]);
					reportViewer1.LocalReport.DataSources.Add(rds);
					reportViewer1.LocalReport.DataSources.Add(rds2);
					reportViewer1.LocalReport.Refresh();
					reportViewer1.RefreshReport();
				}
				else
				{
					MessageBox.Show("Cannot find data");
				}	
				
				return true;
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message + ex.InnerException.Message + ex.InnerException.InnerException.Message);
				return false;
			}
		}
	
		
		private DataSet GetData()
		{
			SqlConnection conn = new SqlConnection(sqlconn);
			
			SqlCommand cmd = new SqlCommand("Select  PROD_MACHINE, PROD_SHIFT, SUM(PROD_QTYCTN) AS SUMQTYCTN, SUM(PROD_M2) AS SUMM2, SUM(PROD_TOTALROLL) AS SUMTOTALROLL From TBL_PROD_CONV_JO_QUICK_PROD_SUMMARY_SHIFT_TEMP GROUP BY PROD_MACHINE, PROD_SHIFT ORDER BY PROD_MACHINE, PROD_SHIFT", conn);
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
				MessageBox.Show("Error - Converting Prod Fast \nCannot load DB" + ex.Message + ex.ToString());
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
		
		private DataSet GetData2()
		{
			SqlConnection conn = new SqlConnection(sqlconn);
			//SqlCommand cmd = new SqlCommand("SELECT PROD_DOCNO, PROD_LINE, PROD_DATE, PROD_SHIFT, PROD_CUSTOMER, PROD_TOTALROLL, PROD_QTYREJECT, PROD_CODE, PROD_BRAND, PROD_COLOR, PROD_MICRON, PROD_WIDTH, PROD_LENGTH FROM TBL_PROD_CONV_JO_SLITTING", conn);
			SqlCommand cmd = new SqlCommand("SELECT PROD_DOCNO, PROD_SHIFT, PROD_STARTDATE, PROD_CUSTOMER, PROD_MACHINE, PROD_CODE, PROD_MICRON, PROD_WIDTH, PROD_LENGTH, PROD_COLOR, PROD_CONVERSION, PROD_QTYORDERED, PROD_TOTALROLL, PROD_QTYCTN, PROD_QTYREJECT, PROD_QTYM2 FROM TBL_PROD_CONV_JO_QUICK_PROD_SHIFT_TEMP", conn);
			try
			{
		        SqlDataAdapter dataadapter = new SqlDataAdapter(cmd);
		        conn.Open();
		        //dataadapter.SelectCommand = cmd;
		        DataSet ds2 = new DataSet();
		        dataadapter.Fill(ds2);
		        return (ds2);
		                     	        
			}
			catch(Exception ex)
			{
				MessageBox.Show("Error - Converting Prod Fast \nCannot load DB" + ex.Message + ex.ToString());
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
		
		void Btn_searchClick(object sender, EventArgs e)
		{
						
//			date_fr = dtp_date_from.Value.Date.ToString();
//			date_to = dtp_date_to.Value.Date.AddDays(1).AddSeconds(-1).ToString();
			
			date_fr = dtp_date_from.Value.Date;
			date_to = dtp_date_to.Value.Date.AddDays(1).AddSeconds(-1);
			
			//date_to = DateTime.Today;
			

			if(!sqlConnParm("SP_PROD_CONV_JO_QUICK_PROD_SHIFT"))
				return;
				
		}
		
		bool sqlConnParm(string cmd_update)
		{
			using (SqlConnection conn = new SqlConnection(sqlconn))
			{
				conn.Open();

				SqlCommand cmd  = new SqlCommand(cmd_update, conn);
				cmd.CommandType = CommandType.StoredProcedure;
				
				//cmd.Parameters.Add(new SqlParameter("@SP_DATEFR", SqlDbType.NVarChar, 20));
				cmd.Parameters.Add(new SqlParameter("@SP_DATEFR", SqlDbType.DateTime));
				cmd.Parameters["@SP_DATEFR"].Value = date_fr;
					
				//cmd.Parameters.Add(new SqlParameter("@SP_DATETO", SqlDbType.NVarChar, 20));
				cmd.Parameters.Add(new SqlParameter("@SP_DATETO", SqlDbType.DateTime));
				cmd.Parameters["@SP_DATETO"].Value = date_to;
								        
				
				cmd.ExecuteNonQuery();	

				try
				{
					reportViewer1.Visible = true;
					reportViewer1.ProcessingMode = ProcessingMode.Local;
					reportViewer1.LocalReport.ReportPath = @"..\..\report\PROD_CONV_PROD_SHIFT_FAST.rdl";
					DataSet ds = new DataSet();
					DataSet ds2 = new DataSet();
					ds = GetData();
					ds2 = GetData2();
					
					if (ds.Tables[0].Rows.Count > 0)
					{
						reportViewer1.LocalReport.DataSources.Clear();
						ReportDataSource rds = new ReportDataSource("DataSet1", ds.Tables[0]);
						ReportDataSource rds2 = new ReportDataSource("DataSet2", ds2.Tables[0]);					
						reportViewer1.LocalReport.DataSources.Add(rds);
						reportViewer1.LocalReport.DataSources.Add(rds2);
						reportViewer1.LocalReport.Refresh();
						reportViewer1.RefreshReport();
					}				
				}
				catch(Exception ex)
				{
					MessageBox.Show(ex.Message + ex.InnerException.Message + ex.InnerException.InnerException.Message);
					return false;
				}
				 return true;

			}
		}

		
		void Btn_cancelClick(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}
