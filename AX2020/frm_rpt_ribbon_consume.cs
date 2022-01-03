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
	
	public partial class frm_rpt_ribbon_consume : Form
	{
		public static string sqlconn = "Server=AX-UAT; Password=sbax2020sbg; User ID=sbax2020; Initial Catalog=SBG_AX_2020; Integrated Security=false";
		//string date_fr, date_to;
		DateTime date_fr, date_to;
		string username;
		
		public frm_rpt_ribbon_consume()
		{
			
			InitializeComponent();
			
		}
		
		private DataSet GetData(DateTime date_fr, DateTime date_to)
		{
			SqlConnection conn = new SqlConnection(sqlconn);
			SqlCommand cmd = new SqlCommand(@"SELECT PRODC_DATE, PRODC_SHIFT, PRODC_MACHINE, PRODC_DOCNO, 
											PRODC_STOCKCODE, PRODC_STOCKDESC, PRODC_QTY , PRODC_QTYREJECT, PRODC_UOM,
											PRODC_OPERATOR, PRODC_HELPER, PRODC_SUPERVISOR 
											FROM TBL_PROD_RIBBON_CONSUME WHERE PRODC_DATE BETWEEN @from_date AND @to_date", conn);
				
			cmd.Parameters.AddWithValue("@from_date",  date_fr);
			cmd.Parameters.AddWithValue("@to_date",  date_to);
			
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
				MessageBox.Show("Error - Ribbon Consume \nCannot load DB" + ex.Message + ex.ToString());
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
			
			date_fr = dtp_date_from.Value.Date;
			date_to = dtp_date_to.Value.Date.AddDays(1).AddSeconds(-1);
			
			try
				{
					reportViewer1.Visible = true;
					reportViewer1.ProcessingMode = ProcessingMode.Local;
					
					
					reportViewer1.LocalReport.ReportPath =  @"..\..\report\PROD_RIBBON_CONSUME.rdl";
					DataSet ds = new DataSet();
					//DataSet ds2 = new DataSet();
					ds = GetData(date_fr, date_to);
					//ds2 = GetData2();
					
					if (ds.Tables[0].Rows.Count > 0)
					{
						reportViewer1.LocalReport.DataSources.Clear();
						ReportDataSource rds = new ReportDataSource("DataSet1", ds.Tables[0]);
						
						reportViewer1.LocalReport.DataSources.Add(rds);
						
						reportViewer1.LocalReport.Refresh();
						reportViewer1.RefreshReport();
					}				
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
	}
}
	


