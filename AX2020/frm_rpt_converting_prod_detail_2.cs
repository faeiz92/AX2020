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
	public partial class frm_rpt_converting_prod_detail_2 : Form
	{
		public static string sqlconn = "Server=AX-UAT; Password=sbax2020sbg; User ID=sbax2020; Initial Catalog=SBG_AX_2020; Integrated Security=false";
		string date_fr, date_to;
		//DateTime date_fr, date_to;
		string username;
		
		public frm_rpt_converting_prod_detail_2()
		{
			
			InitializeComponent();
			this.ControlBox = false;
			username = frm_menu_system.userName; 
			lbl_username.Text = "User : " + username;
			
		}
		
		void DataGrid(string date_fr, string date_to)
		{
			SqlConnection conn = new SqlConnection(sqlconn);
			
			//SqlCommand cmd = new SqlCommand("SELECT PROD_MACHINE, SUM(PROD_QTYCTN) AS SUMQTYCTN, SUM(PROD_M2) AS SUMM2, SUM(PROD_TOTALROLL) AS SUMTOTALROLL FROM TBL_PROD_CONV_JO_QUICK_PACK_SUMMARY_TEMP WHERE PROD_DATE BETWEEN @from_date and @to_date GROUP BY PROD_MACHINE ORDER BY PROD_MACHINE", conn);
			SqlCommand cmd = new SqlCommand(@"SELECT a.PROD_DOCNO, a.PROD_LINE, b.JODATE, a.PROD_CUSTOMER, a.PROD_CODE, a.PROD_BRAND, a.PROD_COLOR, a.PROD_MICRON, a.PROD_WIDTH, a.PROD_LENGTH, a.PROD_CONVERSION, a.PROD_QTYCTNORDERED, a.PROD_QTYROLLORDERED, a.PROD_QTYORDERED, a.PROD_MACHINE, a.PROD_DATE, a.PROD_SHIFT, a.PROD_OPERATOR, a.PROD_HELPER, a.PROD_QTYPERLOGROLL, a.PROD_NOLOGROLL, a.PROD_QTYREJECT, a.PROD_TOTALROLL, a.PROD_JRLOTNO, a.PROD_SHIPMARK, a.PROD_JRWIDTH, a.PROD_JRLENGTH FROM TBL_PROD_CONV_JO_SLITTING a INNER JOIN TBL_PROD_CONV_JO b ON b.JODOCNO = a.PROD_DOCNO WHERE PROD_DATE BETWEEN @from_date AND @to_date", conn);
				
			cmd.Parameters.AddWithValue("@from_date",  date_fr);
			cmd.Parameters.AddWithValue("@to_date",  date_to);
			
			try
			{
		        SqlDataAdapter dataadapter = new SqlDataAdapter(cmd);
		        conn.Open();
		        //dataadapter.SelectCommand = cmd;
		        DataSet ds = new DataSet();
		        dataadapter.Fill(ds);
		        
		        dt_grid.DataSource = ds;
		       
		                     	        
			}
			catch(Exception ex)
			{
				MessageBox.Show("Error - Converting Prod \nCannot load DB" + ex.Message + ex.ToString());
				return;
			}
			finally
			{
				conn.Close();
				//cmd = null;
				conn.Dispose();
				//conn = null;
				
			}
			
		}
		
		
		void Btn_searchClick(object sender, EventArgs e)
		{
			
//			date_fr = dtp_date_from.Value.Date.ToString();
//			date_to = dtp_date_to.Value.Date.AddDays(1).AddSeconds(-1).ToString();
			
			date_fr = dtp_date_from.Value.Date.ToString("MM/dd/yyyy");
			date_to = dtp_date_to.Value.Date.AddDays(1).ToString("MM/dd/yyyy");
			
			
			DataGrid(date_fr, date_to);
			
		}
		
		void Btn_cancelClick(object sender, EventArgs e)
		{
			this.Close();
		}
		
		
	}
}
	

	