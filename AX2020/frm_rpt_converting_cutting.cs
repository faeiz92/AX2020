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
	
	public partial class frm_rpt_converting_cutting : Form
	{
		public static string sqlconn = "Server=AX-UAT; Password=sbax2020sbg; User ID=sbax2020; Initial Catalog=SBG_AX_2020; Integrated Security=false";
		//string date_fr, date_to;
		DateTime date_fr, date_to;
		string username;
		
		public frm_rpt_converting_cutting()
		{			
			InitializeComponent();	
			this.ControlBox = false;
			username = frm_menu_system.userName; 
			lbl_username.Text = "User : " + username;			
		}
		
		private DataSet GetData(DateTime date_fr, DateTime date_to)
		{
			SqlConnection conn = new SqlConnection(sqlconn);
			
			//SqlCommand cmd = new SqlCommand("SELECT PROD_MACHINE, SUM(PROD_QTYCTN) AS SUMQTYCTN, SUM(PROD_M2) AS SUMM2, SUM(PROD_TOTALROLL) AS SUMTOTALROLL FROM TBL_PROD_CONV_JO_QUICK_PACK_SUMMARY_TEMP WHERE PROD_DATE BETWEEN @from_date and @to_date GROUP BY PROD_MACHINE ORDER BY PROD_MACHINE", conn);
			SqlCommand cmd = new SqlCommand(@"SELECT 	a.JODOCNO, 
												a.JODATE, 
												a.JOCUSTOMER, 
												a.JOSTOCKCODE, 
												a.JOSTOCKBRAND, 
												a.JOSTOCKCOLOR, 
												a.JOSTOCKMICRON, 
												a.JOSTOCKWIDTH, 
												a.JOSTOCKLENGTH, 
												a.JOSTOCKCONVERSION, 
												a.JOSTOCKQTYCTN, 
												a.JOSTOCKQTYROLL, 
												a.JOPRODREMARK0c,
											 	a.PROD_STARTDATE,
											 	a.PROD_ENDDATE,
												b.PROD_DATE, 
												b.PROD_TOTALROLL, 
												a.JOPACKQTYBAL 
											
											FROM 	TBL_PROD_CONV_JO a
											 
												INNER JOIN TBL_PROD_CONV_JO_SLITTING b 
												ON a.JODOCNO = b.PROD_DOCNO  
													INNER JOIN 
													(
														SELECT 	PROD_DOCNO, 
															MAX(PROD_DATE) MAXPRODDATE 
														
														FROM 	TBL_PROD_CONV_JO_SLITTING 
														GROUP BY PROD_DOCNO
													
													) c ON 	b.PROD_DOCNO = c.PROD_DOCNO AND 
														b.PROD_DATE = c.MAXPRODDATE WHERE PROD_DATE BETWEEN @from_date AND @to_date", conn);
				
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
				MessageBox.Show("Error - Converting Cutting \nCannot load DB \n" + ex.Message + ex.ToString());
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
			
			
			try
				{
					reportViewer1.Visible = true;
					reportViewer1.ProcessingMode = ProcessingMode.Local;
					reportViewer1.LocalReport.ReportPath = @"..\..\report\PROD_CONV_CUTTING_OUTPUT.rdl";
					DataSet ds = new DataSet();
					//DataSet ds2 = new DataSet();
					ds = GetData(date_fr, date_to);
					//ds2 = GetData2();
					
					if (ds.Tables[0].Rows.Count > 0)
					{
						reportViewer1.LocalReport.DataSources.Clear();
						ReportDataSource rds = new ReportDataSource("DataSet1", ds.Tables[0]);
						//ReportDataSource rds2 = new ReportDataSource("DataSet2", ds2.Tables[0]);					
//						ReportParameter[] parameters = new ReportParameter[2];
//						parameters[0] = new ReportParameter("@from_date", dtp_date_from.Text.ToString());
//						MessageBox.Show(date_fr.Date.ToString());
//						parameters[1] = new ReportParameter("@to_date", dtp_date_to.Text.ToString());
//				        reportViewer1.LocalReport.SetParameters(parameters);
						
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
					
		void Btn_cancelClick(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}
	

	