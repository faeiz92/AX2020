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
	
	public partial class frm_rpt_converting_jo_rewinding_label : Form
	{
		public static string sqlconn = "Server=AX-UAT; Password=sbax2020sbg; User ID=sbax2020; Initial Catalog=SBG_AX_2020; Integrated Security=false";
		//string date_fr, date_to;
		//DateTime date_fr, date_to;
		string username;
		
		public frm_rpt_converting_jo_rewinding_label()
		{
			
			InitializeComponent();
			this.ControlBox = false;
			username = frm_menu_system.userName; 
			//lbl_username.Text = "User : " + username;
		}
		
		private DataSet GetData(DateTime date_fr, DateTime date_to)
		{
			SqlConnection conn = new SqlConnection(sqlconn);
			
			SqlCommand cmd = new SqlCommand("SELECT * FROM TBL_PROD_CONV_JO_REWINDING WHERE PROD_LINE = @prod_line", conn);
			//SqlCommand cmd = new SqlCommand(@"SELECT * FROM TBL_PROD_CONV_JO WHERE JODATE BETWEEN @from_date AND @to_date", conn);
			
			//cmd.Parameters.AddWithValue("@prod_line",  prod_line);			
			//cmd.Parameters.AddWithValue("@from_date",  date_fr);
			//cmd.Parameters.AddWithValue("@to_date",  date_to);
			
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
				MessageBox.Show("Error - Converting Pack \nCannot load DB" + ex.Message + ex.ToString());
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
			
			//date_fr = dtp_date_from.Value.Date;
			//date_to = dtp_date_to.Value.Date.AddDays(1).AddSeconds(-1);
			
			
			try
			{
				//reportViewer1.Reset();
				//reportViewer1.Visible = true;
				//reportViewer1.ProcessingMode = ProcessingMode.Local;
				//reportViewer1.LocalReport.ReportPath = @"..\..\report\IncomingOrder.rdl";
				DataSet ds = new DataSet();
				//DataSet ds2 = new DataSet();
				//ds = GetData(date_fr, date_to);
				//ds2 = GetData2();
					
				if (ds.Tables[0].Rows.Count > 0)
				{
					
					//reportViewer1.LocalReport.DataSources.Clear();
					ReportDataSource rds = new ReportDataSource("DataSet1", ds.Tables[0]);
					//ReportDataSource rds2 = new ReportDataSource("DataSet2", ds2.Tables[0]);					
						
					ReportParameter[] parameters = new ReportParameter[2];
					//parameters[0] = new ReportParameter("from_date", date_fr.ToString("yyyy-MM-dd"));
					//parameters[1] = new ReportParameter("to_date", date_to.ToString("yyyy-MM-dd"));
				    
					//this.reportViewer1.RefreshReport(); 
					//reportViewer1.LocalReport.DataSources.Clear();					
//					ReportParameter p1 = new ReportParameter("@from_date", date_fr);
//    				ReportParameter p2 = new ReportParameter("@to_date", _p2);
//						
//					reportViewer1.LocalReport.SetParameters(

					//reportViewer1.LocalReport.DataSources.Add(rds);
					//reportViewer1.LocalReport.SetParameters(parameters);
					//reportViewer1.LocalReport.DataSources.Add(rds2);
						
					//reportViewer1.LocalReport.Refresh();
					//reportViewer1.RefreshReport();
				}				
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message + ex.ToString());// + ex.InnerException.Message);
				//return false;
			}
			
			
		}
		
		
		
		void Btn_cancelClick(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}
	

