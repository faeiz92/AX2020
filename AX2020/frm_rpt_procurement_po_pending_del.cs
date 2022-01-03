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
using fyiReporting.RdlViewer;
using fyiReporting;
using Microsoft.Reporting.WinForms;
using Microsoft.ReportingServices;

namespace AX2020
{
	
	public partial class frm_rpt_procurement_po_pending_del : Form
	{
		public static string sqlconn = "Server=AX-UAT; Password=sbax2020sbg; User ID=sbax2020; Initial Catalog=SBG_AX_2020; Integrated Security=false";
		public static string Sqlconn1 = "DSN=eb9gf;Port=2138;Uid=dba;Pwd=sql";
		//DateTime date_fr, date_to;
		string date_fr, date_to;
		string username;
		
	
		public frm_rpt_procurement_po_pending_del()
		{	
			InitializeComponent();
			this.ControlBox = false;
			username = frm_menu_system.userName; 
			lbl_username.Text = "User : " + username;			
		}
		
		private DataSet GetData(string date_fr, string date_to)
		{
			SqlConnection conn = new SqlConnection(sqlconn);
			
			//SqlCommand cmd = new SqlCommand("SELECT PROD_MACHINE, SUM(PROD_QTYCTN) AS SUMQTYCTN, SUM(PROD_M2) AS SUMM2, SUM(PROD_TOTALROLL) AS SUMTOTALROLL FROM TBL_PROD_CONV_JO_QUICK_PACK_SUMMARY_TEMP WHERE PROD_DATE BETWEEN @from_date and @to_date GROUP BY PROD_MACHINE ORDER BY PROD_MACHINE", conn);
			SqlCommand cmd = new SqlCommand(@"SELECT * FROM [ax-sql].AX2020StagingDB.dbo.VIEW_AXERP_PO_PENDING_DELIVERY WHERE itemdeliverydate BETWEEN @from_date AND @to_date", conn);
				
			cmd.Parameters.AddWithValue("@from_date",  date_fr);
			cmd.Parameters.AddWithValue("@to_date",  date_to);
			
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
				MessageBox.Show("Error - Procurement PO Pending Delivery \nCannot load DB" + ex.Message + ex.ToString());
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
			
			date_fr = dtp_date_from.Value.Date.ToString("MM/dd/yyyy");
			date_to = dtp_date_to.Value.Date.AddDays(1).ToString("MM/dd/yyyy");
			
			
			
			try
				{
					reportViewer1.Visible = true;
					reportViewer1.ProcessingMode = ProcessingMode.Local;
					reportViewer1.LocalReport.ReportPath = @"..\..\report\PROD_PROC_PO_PENDING_DELIVERY.rdl";
					DataSet ds = new DataSet();
					//DataSet ds2 = new DataSet();
					ds = GetData(date_fr, date_to);
					//ds2 = GetData2();
					
					if (ds.Tables[0].Rows.Count > 0)
					{
						reportViewer1.LocalReport.DataSources.Clear();
						ReportDataSource rds = new ReportDataSource("DataSet1", ds.Tables[0]);
						//ReportDataSource rds2 = new ReportDataSource("DataSet2", ds2.Tables[0]);					
						ReportParameter[] parameters = new ReportParameter[2];
						parameters[0] = new ReportParameter("from_date", date_fr);
						parameters[1] = new ReportParameter("to_date", date_to);
				        this.reportViewer1.LocalReport.SetParameters(parameters);
						
						reportViewer1.LocalReport.DataSources.Add(rds);
						//reportViewer1.LocalReport.DataSources.Add(rds2);
						
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
		
		void Btn_cancelClick(object sender, EventArgs e)
		{
			this.Close();
		}
		
		void Button1Click(object sender, EventArgs e)
		{
			this.Hide();
			using(frm_rpt_converting_prod_detail_2 frm_conv_prod_detail_2 = new frm_rpt_converting_prod_detail_2())
				frm_conv_prod_detail_2.ShowDialog();
			this.Show();
			
		}
	}
}
	
