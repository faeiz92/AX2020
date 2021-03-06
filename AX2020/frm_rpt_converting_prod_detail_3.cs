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
	public partial class frm_rpt_converting_prod_detail_3 : Form
	{
		public static string sqlconn = "Server=AX-UAT; Password=sbax2020sbg; User ID=sbax2020; Initial Catalog=SBG_AX_2020; Integrated Security=false";
		string date_fr, date_to;
		//DateTime date_fr, date_to;
		string username;
		
		public frm_rpt_converting_prod_detail_3()
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
			SqlCommand cmd = new SqlCommand(@"SELECT a.PROD_DOCNO, a.PROD_LINE, b.JODATE, a.PROD_CUSTOMER, a.PROD_CODE, a.PROD_BRAND, a.PROD_COLOR, a.PROD_MICRON, a.PROD_WIDTH, a.PROD_LENGTH, a.PROD_CONVERSION, a.PROD_QTYCTNORDERED, a.PROD_QTYROLLORDERED, a.PROD_QTYORDERED, a.PROD_MACHINE, a.PROD_DATE, a.PROD_SHIFT, a.PROD_OPERATOR, a.PROD_HELPER, a.PROD_QTYPERLOGROLL, a.PROD_NOLOGROLL, a.PROD_QTYREJECT, a.PROD_TOTALROLL, a.PROD_JRLOTNO, a.PROD_SHIPMARK, a.PROD_JRWIDTH, a.PROD_JRLENGTH FROM TBL_PROD_CONV_JO_SLITTING a INNER JOIN TBL_PROD_CONV_JO b ON b.JODOCNO = a.PROD_DOCNO WHERE a.PROD_SHIPMARK like @shipmark + '%'", conn);
				
			cmd.Parameters.AddWithValue("@shipmark",  txtbx_shipmark.Text.ToUpper());
			
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
			
//			date_fr = dtp_date_from.Value.Date.ToString();
//			date_to = dtp_date_to.Value.Date.AddDays(1).AddSeconds(-1).ToString();
			
//			date_fr = dtp_date_from.Value.Date.ToString("MM/dd/yyyy");
//			date_to = dtp_date_to.Value.Date.AddDays(1).ToString("MM/dd/yyyy");
						
			
			try
			{
				reportViewer1.Visible = true;
				reportViewer1.ProcessingMode = ProcessingMode.Local;
				reportViewer1.LocalReport.ReportPath = @"..\..\report\PROD_CONV_PROD_DETAIL_OUTPUT_2.rdl";
				DataSet ds = new DataSet();
				//DataSet ds2 = new DataSet();
				ds = GetData();
				//ds2 = GetData2();
					
				if (ds.Tables[0].Rows.Count > 0)
				{
					reportViewer1.LocalReport.DataSources.Clear();
					ReportDataSource rds = new ReportDataSource("DataSet1", ds.Tables[0]);
					//ReportDataSource rds2 = new ReportDataSource("DataSet2", ds2.Tables[0]);					
					ReportParameter[] parameters = new ReportParameter[1];
					parameters[0] = new ReportParameter("shipmark", txtbx_shipmark.Text.ToUpper());
					
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
	

	