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
	
	public partial class frm_rpt_conv_backorder : Form
	{
		public static string sqlconn = "Server=AX-UAT; Password=sbax2020sbg; User ID=sbax2020; Initial Catalog=SBG_AX_2020; Integrated Security=false";
		//string date_fr, date_to;
		DateTime date_fr, date_to;
		string username;
		
		public frm_rpt_conv_backorder()
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
			SqlCommand cmd = new SqlCommand(@"SELECT   	A.JODOCNO, 
				min(A.JODATE) as JODATE,
				MIN(A.JOETDDATE) AS JOETDDATE,
				A.JOCUSTOMER, 
				A.JOSTOCKCODE, 
				A.JOSTOCKBRAND, 
				A.JOSTOCKCOLOR, 
				A.JOSTOCKMICRON, 
				A.JOSTOCKWIDTH, 
				A.JOSTOCKLENGTH,
				A.JOSTOCKCONVERSION,
				A.JOPRODREMARK0c,
				max(A.JOSTOCKQTYCTN) as JOSTOCKQTYCTN,
				max(A.JOSTOCKQTYROLL) as JOSTOCKQTYROLL,
				max(A.TOTAL_SLIT) as TOTAL_SLIT,
				max(B.TOTAL_PACK) as TOTAL_PACK,
				(max(A.JOPRODREMARK0c - B.TOTAL_PACK)) AS BALANCE_PACK,
				max(C.TOTAL_RECEIVED) AS TOTAL_RECEIVED
			FROM   VIEW_PROD_CONV_JO_BACKORDER as A inner join VIEW_PROD_CONV_JO_BACKORDER_PACK AS B on A.JODOCNO = B.JODOCNO inner join VIEW_PROD_CONV_JO_BACKORDER_WAREHOUSE AS C ON B.JODOCNO = C.JODOCNO
			
			WHERE (((A.JOETDDATE between @from_date and  @to_date)) or (@from_date is null and @to_date is null))  and (A.JODOCNO like @so_no + '%' or @so_no is null)
			and (BALANCE_PACK > 0)
			GROUP BY A.JOETDDATE, A.JODOCNO, A.JOCUSTOMER, A.JOSTOCKCODE, A.JOSTOCKBRAND, A.JOSTOCKCOLOR, A.JOSTOCKMICRON, A.JOSTOCKWIDTH, A.JOSTOCKLENGTH, 
			A.JOSTOCKCONVERSION, A.JOPRODREMARK0c ORDER BY A.JOETDDATE, A.JODOCNO", conn);
			
			
				
			cmd.Parameters.AddWithValue("@from_date",  date_fr);
			cmd.Parameters.AddWithValue("@to_date",  date_to);
			
			cmd.Parameters.AddWithValue("@so_no",  DBNull.Value);
			
			
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
				MessageBox.Show("Error - Converting Backorder \nCannot load DB" + ex.Message + ex.ToString());
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
			SqlCommand cmd = new SqlCommand(@"SELECT   	A.JODOCNO, 
				min(A.JODATE) as JODATE,
				MIN(A.JOETDDATE) AS JOETDDATE,
				A.JOCUSTOMER, 
				A.JOSTOCKCODE, 
				A.JOSTOCKBRAND, 
				A.JOSTOCKCOLOR, 
				A.JOSTOCKMICRON, 
				A.JOSTOCKWIDTH, 
				A.JOSTOCKLENGTH,
				A.JOSTOCKCONVERSION,
				A.JOPRODREMARK0c,
				max(A.JOSTOCKQTYCTN) as JOSTOCKQTYCTN,
				max(A.JOSTOCKQTYROLL) as JOSTOCKQTYROLL,
				max(A.TOTAL_SLIT) as TOTAL_SLIT,
				max(B.TOTAL_PACK) as TOTAL_PACK,
				(max(A.JOPRODREMARK0c - B.TOTAL_PACK)) AS BALANCE_PACK,
				max(C.TOTAL_RECEIVED) AS TOTAL_RECEIVED
			FROM   VIEW_PROD_CONV_JO_BACKORDER as A inner join VIEW_PROD_CONV_JO_BACKORDER_PACK AS B on A.JODOCNO = B.JODOCNO inner join VIEW_PROD_CONV_JO_BACKORDER_WAREHOUSE AS C ON B.JODOCNO = C.JODOCNO
			
			WHERE (((A.JOETDDATE between @from_date and @to_date)) or (@from_date is null and @to_date is null))  and (A.JODOCNO like @so_no + '%' or @so_no is null)
			and (BALANCE_PACK > 0)
			GROUP BY A.JOETDDATE, A.JODOCNO, A.JOCUSTOMER, A.JOSTOCKCODE, A.JOSTOCKBRAND, A.JOSTOCKCOLOR, A.JOSTOCKMICRON, A.JOSTOCKWIDTH, A.JOSTOCKLENGTH, 
			A.JOSTOCKCONVERSION, A.JOPRODREMARK0c ORDER BY A.JOETDDATE, A.JODOCNO", conn);
				
			
			cmd.Parameters.AddWithValue("@so_no",  txtbx_so_no.Text.ToUpper());
				
			cmd.Parameters.AddWithValue("@from_date", DBNull.Value);
			cmd.Parameters.AddWithValue("@to_date", DBNull.Value);
						
			
			
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
				MessageBox.Show("Error - Converting Backorder \nCannot load DB" + ex.Message + ex.ToString());
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

		
//		private DataSet GetData(DateTime date_fr, DateTime date_to)
//		{
//			SqlConnection conn = new SqlConnection(sqlconn);
//			SqlCommand cmd = new SqlCommand(@"SELECT PROD_DATE, PROD_SHIFT, PROD_MACHINE, PROD_DOCNO, 
//											PROD_STOCKCODE, PROD_STOCKDESC, PROD_QTY , PROD_QTYREJECT, PROD_UOM,
//											PROD_OPERATOR, PROD_HELPER, PROD_SUPERVISOR 
//											FROM TBL_PROD_GLUE_OUTPUT WHERE PROD_DATE BETWEEN @from_date AND @to_date", conn);
//				
//			cmd.Parameters.AddWithValue("@from_date",  date_fr);
//			cmd.Parameters.AddWithValue("@to_date",  date_to);
//			
//			try
//			{
//		        SqlDataAdapter dataadapter = new SqlDataAdapter(cmd);
//		        conn.Open();
//		        DataSet ds = new DataSet();
//		        dataadapter.Fill(ds);
//		        return (ds);
//		                     	        
//			}
//			catch(Exception ex)
//			{
//				MessageBox.Show("Error - Glue Output \nCannot load DB" + ex.Message + ex.ToString());
//				return null;
//			}
//			finally
//			{
//				conn.Close();
//				cmd = null;
//				conn.Dispose();
//				conn = null;
//			}
//			
//		}
				
		
		
					
		void Btn_cancelClick(object sender, EventArgs e)
		{
			this.Close();
		}
		
		
		void Btn_searchClick(object sender, EventArgs e)
		{
			date_fr = dtp_date_from.Value.Date;
			date_to = dtp_date_to.Value.Date.AddDays(1).AddSeconds(-1);
			
			try
			{
				reportViewer1.Visible = true;
				reportViewer1.ProcessingMode = ProcessingMode.Local;
					
					
				reportViewer1.LocalReport.ReportPath =  @"..\..\report\PROD_CONV_BACKORDER.rdl";
				DataSet ds = new DataSet();
				//DataSet ds2 = new DataSet();
				ds = GetData(date_fr, date_to);
				//ds2 = GetData2();
					
				if (ds.Tables[0].Rows.Count > 0)
				{
					reportViewer1.LocalReport.DataSources.Clear();
					ReportDataSource rds = new ReportDataSource("DataSet1", ds.Tables[0]);
					
					ReportParameter[] parameters = new ReportParameter[3];
					parameters[0] = new ReportParameter("from_date", date_fr.ToString("yyyy-MM-dd"));
					parameters[1] = new ReportParameter("to_date", date_to.ToString("yyyy-MM-dd"));
					parameters[2] = new ReportParameter("so_no", "");
				    
					reportViewer1.LocalReport.DataSources.Add(rds);
					reportViewer1.LocalReport.SetParameters(parameters);
						
					reportViewer1.LocalReport.Refresh();
					reportViewer1.RefreshReport();
				}	
				else
				{
					MessageBox.Show("Cannot find JO in the date duration selected");
				}				
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message + ex.InnerException.Message + ex.InnerException.InnerException.Message);
				return;
			}
		}
		
		void Btn_search_soClick(object sender, EventArgs e)
		{
			if(String.IsNullOrWhiteSpace(txtbx_so_no.Text))
			{
				MessageBox.Show("SO No cannot be empty");
				return;
			}
			try
			{
				reportViewer1.Visible = true;
				reportViewer1.ProcessingMode = ProcessingMode.Local;
										
				reportViewer1.LocalReport.ReportPath =  @"..\..\report\PROD_CONV_BACKORDER.rdl";
				DataSet ds = new DataSet();
				//DataSet ds2 = new DataSet();
				ds = GetData2();
				//ds2 = GetData2();
					
				if (ds.Tables[0].Rows.Count > 0)
				{
					reportViewer1.LocalReport.DataSources.Clear();
					ReportDataSource rds = new ReportDataSource("DataSet1", ds.Tables[0]);
					
					ReportParameter[] parameters = new ReportParameter[3];
					parameters[0] = new ReportParameter("from_date", "");
					parameters[1] = new ReportParameter("to_date", "");
					parameters[2] = new ReportParameter("so_no", txtbx_so_no.Text.ToUpper());
				    
					reportViewer1.LocalReport.DataSources.Add(rds);
					reportViewer1.LocalReport.SetParameters(parameters);
						
					reportViewer1.LocalReport.Refresh();
					reportViewer1.RefreshReport();
				}	
				else
				{
					MessageBox.Show("Cannot find SO No");
				}
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message + ex.InnerException.Message + ex.InnerException.InnerException.Message);
				return;
			}			
		}
	}
}
	