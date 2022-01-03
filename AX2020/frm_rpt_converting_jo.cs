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
	
	public partial class frm_rpt_converting_jo : Form
	{
		public static string sqlconn = "Server=AX-UAT; Password=sbax2020sbg; User ID=sbax2020; Initial Catalog=SBG_AX_2020; Integrated Security=false";
		//string date_fr, date_to;
		DateTime date_fr, date_to;
		string username;
		
		public frm_rpt_converting_jo()
		{
			InitializeComponent();
			this.ControlBox = false;
			username = frm_menu_system.userName; 
			lbl_username.Text = "User : " + username;
			
			DropDownList("SELECT DISTINCT JOISSUEBY FROM TBL_PROD_CONV_JO order by JOISSUEBY", cbx_issue_by, "JOISSUEBY");
			
		}
		
		void DropDownList(string cmd, ComboBox cbx_text, string col_name)
		{
		    SqlConnection conn = new SqlConnection(sqlconn);
            DataSet ds = new DataSet();
            string cmdSQL = cmd;
            SqlDataAdapter sda = new SqlDataAdapter(cmdSQL, conn);

            try
            {
                conn.Open();
                sda.Fill(ds);
                cbx_text.Items.Add("Please Select");           
            }
            catch(SqlException se)
            {
            	MessageBox.Show("Error - Rewinding DropDown List \nCannot load DB" + se.ToString() + se.Message);
            }
            finally
            {
                conn.Close();
            }
			
           	foreach(DataRow dr1 in ds.Tables[0].Rows)
           	{
               cbx_text.Items.Add(dr1[col_name].ToString());
           	}
            //cbx_tape.DataSource = ds.Tables[0];
            //cbx_tape.DisplayMember = ds.Tables[0].Columns[0].ToString();
            //cbx_tape.SelectedIndex = 3;
            cbx_text.SelectedItem = "Please Select";

		}

		
		private DataSet GetData(DateTime date_fr, DateTime date_to)
		{
			SqlConnection conn = new SqlConnection(sqlconn);
			
			//SqlCommand cmd = new SqlCommand("SELECT PROD_MACHINE, SUM(PROD_QTYCTN) AS SUMQTYCTN, SUM(PROD_M2) AS SUMM2, SUM(PROD_TOTALROLL) AS SUMTOTALROLL FROM TBL_PROD_CONV_JO_QUICK_PACK_SUMMARY_TEMP WHERE PROD_DATE BETWEEN @from_date and @to_date GROUP BY PROD_MACHINE ORDER BY PROD_MACHINE", conn);
			SqlCommand cmd = new SqlCommand(@"SELECT * FROM TBL_PROD_CONV_JO where JODATE between @from_date and @to_date and (JOISSUEBY = (@jo_issue_by) or @jo_issue_by is null)", conn);
				
			cmd.Parameters.AddWithValue("@from_date",  date_fr);
			cmd.Parameters.AddWithValue("@to_date",  date_to);
			
			if(cbx_issue_by.Text == "Please Select")
			{
				cmd.Parameters.AddWithValue("@jo_issue_by",  DBNull.Value);
				
			}
			else
			{
				cmd.Parameters.AddWithValue("@jo_issue_by",  cbx_issue_by.Text);
				
			}
				
					
			
			
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
			
			date_fr = dtp_date_from.Value.Date;
			date_to = dtp_date_to.Value.Date.AddDays(1).AddSeconds(-1);
			
			
			try
			{
				reportViewer1.Reset();
				reportViewer1.Visible = true;
				reportViewer1.ProcessingMode = ProcessingMode.Local;
				reportViewer1.LocalReport.ReportPath = @"..\..\report\IncomingOrder.rdl";
				DataSet ds = new DataSet();
				//DataSet ds2 = new DataSet();
				ds = GetData(date_fr, date_to);
				//ds2 = GetData2();
					
				if (ds.Tables[0].Rows.Count > 0)
				{
					
					//reportViewer1.LocalReport.DataSources.Clear();
					ReportDataSource rds = new ReportDataSource("DataSet1", ds.Tables[0]);
					//ReportDataSource rds2 = new ReportDataSource("DataSet2", ds2.Tables[0]);					
						
					ReportParameter[] parameters = new ReportParameter[2];
					parameters[0] = new ReportParameter("from_date", date_fr.ToString("yyyy-MM-dd"));
					parameters[1] = new ReportParameter("to_date", date_to.ToString("yyyy-MM-dd"));
				    
					//this.reportViewer1.RefreshReport(); 
					//reportViewer1.LocalReport.DataSources.Clear();					
//					ReportParameter p1 = new ReportParameter("@from_date", date_fr);
//    				ReportParameter p2 = new ReportParameter("@to_date", _p2);
//						
//					reportViewer1.LocalReport.SetParameters(

					reportViewer1.LocalReport.DataSources.Add(rds);
					reportViewer1.LocalReport.SetParameters(parameters);
					//reportViewer1.LocalReport.DataSources.Add(rds2);
						
					reportViewer1.LocalReport.Refresh();
					reportViewer1.RefreshReport();
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
	

