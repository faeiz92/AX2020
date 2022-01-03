using System;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using System.Collections.Generic; // For generic collections like List.
using System.Data.SqlClient;      
using System.Data.Sql;
using System.Data.Sql;
using System.Data;


namespace AX2020
{
	
	public partial class frm_rpt_converting_jr_balance_jrstockcode : Form
	{
		public static string sqlconn = "Server=AX-UAT; Password=sbax2020sbg; User ID=sbax2020; Initial Catalog=SBG_AX_2020; Integrated Security=false; Timeout = 80000";
		//string date_fr, date_to;
		DateTime date_fr, date_to;
		string username;
		
		public frm_rpt_converting_jr_balance_jrstockcode()
		{
			
			InitializeComponent();
			this.ControlBox = false;
			username = frm_menu_system.userName; 
			lbl_username.Text = "User : " + username;
		}
		
		private DataSet GetData()
		{
			SqlConnection conn = new SqlConnection(sqlconn);
			
			//SqlCommand cmd = new SqlCommand("SELECT PROD_MACHINE, SUM(PROD_QTYCTN) AS SUMQTYCTN, SUM(PROD_M2) AS SUMM2, SUM(PROD_TOTALROLL) AS SUMTOTALROLL FROM TBL_PROD_CONV_JO_QUICK_PACK_SUMMARY_TEMP WHERE PROD_DATE BETWEEN @from_date and @to_date GROUP BY PROD_MACHINE ORDER BY PROD_MACHINE", conn);
			SqlCommand cmd = new SqlCommand(@"SELECT * FROM TBL_PROD_CONV_JO_JR_BALANCE_FULL_TEMP", conn);
				
//			cmd.Parameters.AddWithValue("@from_date",  date_fr);
//			cmd.Parameters.AddWithValue("@to_date",  date_to);
//			cmd.Parameters.AddWithValue("@jo_no",  DBNull.Value);
			
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
				MessageBox.Show("Error - Converting Prod \nCannot load DB" + ex.Message + ex.ToString());
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
			
			//SqlCommand cmd = new SqlCommand("SELECT PROD_MACHINE, SUM(PROD_QTYCTN) AS SUMQTYCTN, SUM(PROD_M2) AS SUMM2, SUM(PROD_TOTALROLL) AS SUMTOTALROLL FROM TBL_PROD_CONV_JO_QUICK_PACK_SUMMARY_TEMP WHERE PROD_DATE BETWEEN @from_date and @to_date GROUP BY PROD_MACHINE ORDER BY PROD_MACHINE", conn);
			SqlCommand cmd = new SqlCommand(@"SELECT * FROM VIEW_PROD_CONV_JO_SLITTING_JR_BALANCE_FULL WHERE ((PROD_DATE BETWEEN @from_date AND @to_date) or (@from_date is null and @to_date is null)) and (PROD_JONO = @jo_no or @jo_no is null)", conn);
				
			cmd.Parameters.AddWithValue("@from_date",  DBNull.Value);
			cmd.Parameters.AddWithValue("@to_date",  DBNull.Value);
			cmd.Parameters.AddWithValue("@jo_no",  txtbx_jo_no.Text.ToUpper());
			
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
				MessageBox.Show("Error - Converting Prod \nCannot load DB" + ex.Message + ex.ToString());
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
			sqlConnParm("SP_PROD_CONV_JR_BALANCE_FULL_FILTER");
//			date_fr = dtp_date_from.Value.Date.ToString();
//			date_to = dtp_date_to.Value.Date.AddDays(1).AddSeconds(-1).ToString();
			
//			date_fr = dtp_date_from.Value.Date;			
//			date_to = dtp_date_to.Value.Date.AddDays(1).AddSeconds(-1);
//			
//			
//			try
//				{
//					reportViewer1.Visible = true;
//					reportViewer1.ProcessingMode = ProcessingMode.Local;
//					reportViewer1.LocalReport.ReportPath = @"..\..\report\PROD_CONV_WASTAGE_FULL.rdl";
//					DataSet ds = new DataSet();
//					//DataSet ds2 = new DataSet();
//					ds = GetData();
//					//ds2 = GetData2();
//					
//					if (ds.Tables[0].Rows.Count > 0)
//					{
//						reportViewer1.LocalReport.DataSources.Clear();
//						ReportDataSource rds = new ReportDataSource("DataSet1", ds.Tables[0]);
//						
//						reportViewer1.LocalReport.DataSources.Add(rds);
//						//reportViewer1.LocalReport.DataSources.Add(rds2);
//						
//						reportViewer1.LocalReport.Refresh();
//						reportViewer1.RefreshReport();
//					}				
//				}
//				catch(Exception ex)
//				{
//					MessageBox.Show(ex.Message + ex.InnerException.Message + ex.InnerException.InnerException.Message);
//				}
		}
					
		void Btn_cancelClick(object sender, EventArgs e)
		{
			this.Close();
		}
		
		void Btn_search_joClick(object sender, EventArgs e)
		{
//			try
//				{
//					reportViewer1.Visible = true;
//					reportViewer1.ProcessingMode = ProcessingMode.Local;
//					reportViewer1.LocalReport.ReportPath = @"..\..\report\PROD_CONV_WASTAGE_FULL.rdl";
//					DataSet ds = new DataSet();
//					//DataSet ds2 = new DataSet();
//					ds = GetData2();
//					//ds2 = GetData2();
//					
//					if (ds.Tables[0].Rows.Count > 0)
//					{
//						reportViewer1.LocalReport.DataSources.Clear();
//						ReportDataSource rds = new ReportDataSource("DataSet1", ds.Tables[0]);
//						
//						reportViewer1.LocalReport.DataSources.Add(rds);
//						//reportViewer1.LocalReport.DataSources.Add(rds2);
//						
//						reportViewer1.LocalReport.Refresh();
//						reportViewer1.RefreshReport();
//					}				
//				}
//				catch(Exception ex)
//				{
//					MessageBox.Show(ex.Message + ex.InnerException.Message + ex.InnerException.InnerException.Message);
//				}
			
			sqlConnParm("SP_PROD_CONV_JR_BALANCE_FULL_FILTER");
		}
		
		void sqlConnParm(string cmd_update)
		{
			using (SqlConnection conn = new SqlConnection(sqlconn))
			{
				conn.Open();
				SqlCommand cmd  = new SqlCommand(cmd_update, conn);
				cmd.CommandType = CommandType.StoredProcedure;
				
				cmd.Parameters.Add(new SqlParameter("@SP_JODATEFROM", SqlDbType.DateTime));
				cmd.Parameters.Add(new SqlParameter("@SP_JODATETO", SqlDbType.DateTime));
				cmd.Parameters.Add(new SqlParameter("@SP_JODOCNO", SqlDbType.NVarChar, 50));
//				cmd.Parameters.Add(new SqlParameter("@SP_JOSONO", SqlDbType.NVarChar, 50));
//				cmd.Parameters.Add(new SqlParameter("@SP_JOCUSTOMER", SqlDbType.NVarChar, 50));
				
//				if(dtp_date_from.Checked == false)
//				{
//					cmd.Parameters["@SP_JODATEFROM"].Value = DBNull.Value;
//					cmd.Parameters["@SP_JODATETO"].Value = DBNull.Value;	
//				}
//				else
//				{
					date_fr = dtp_date_from.Value.Date;             
					date_to = dtp_date_to.Value.Date.AddDays(1).AddSeconds(-1);
					
					cmd.Parameters["@SP_JODATEFROM"].Value = date_fr;
					cmd.Parameters["@SP_JODATETO"].Value = date_to;
//				}
				
				if(String.IsNullOrWhiteSpace(txtbx_jo_no.Text))
				{
					cmd.Parameters["@SP_JODOCNO"].Value = DBNull.Value;
				}
				else
				{
				   	cmd.Parameters["@SP_JODOCNO"].Value = txtbx_jo_no.Text;
				}
				
//				if(String.IsNullOrWhiteSpace(txtbx_so_no.Text))
//				{
//					cmd.Parameters["@SP_JOSONO"].Value = DBNull.Value;
//				}
//				else
//				{
//				   	cmd.Parameters["@SP_JOSONO"].Value = txtbx_so_no.Text;
//				}
//				
//				if(String.IsNullOrWhiteSpace(txtbx_cust.Text))
//				{
//					cmd.Parameters["@SP_JOCUSTOMER"].Value = DBNull.Value;
//				}
//				else
//				{
//				   	cmd.Parameters["@SP_JOCUSTOMER"].Value = txtbx_cust.Text;
//				}
				
								        
				
				cmd.ExecuteNonQuery();	

				try
				{
					reportViewer1.Visible = true;
					reportViewer1.ProcessingMode = ProcessingMode.Local;
					reportViewer1.LocalReport.ReportPath = @"..\..\report\PROD_CONV_WASTAGE_FULL.rdl";
					DataSet ds = new DataSet();
					
					ds = GetData();
					
					
					if (ds.Tables[0].Rows.Count > 0)
					{
						reportViewer1.LocalReport.DataSources.Clear();
						ReportDataSource rds = new ReportDataSource("DataSet1", ds.Tables[0]);
											
						reportViewer1.LocalReport.DataSources.Add(rds);
						
						reportViewer1.LocalReport.Refresh();
						reportViewer1.RefreshReport();
					}
					else
					{
						MessageBox.Show("Cannot find data");
					}					
				}
				catch(Exception ex)
				{
					MessageBox.Show(ex.Message + ex.InnerException.Message + ex.InnerException.InnerException.Message);
					//return false;
				}
			}
		}
	}
}
	

