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
	
	public partial class frm_rpt_glue_output : Form
	{
		public static string sqlconn = "Server=AX-UAT; Password=sbax2020sbg; User ID=sbax2020; Initial Catalog=SBG_AX_2020; Integrated Security=false";
		//string date_fr, date_to;
		DateTime date_fr, date_to;
		string username;
		
		public frm_rpt_glue_output()
		{		
			InitializeComponent();
			this.ControlBox = false;
			username = frm_menu_system.userName; 
			lbl_username.Text = "User : " + username;	
			
			
			
			

			DropDownList("SELECT DISTINCT PROD_MACHINE FROM TBL_PROD_GLUE_OUTPUT order by PROD_MACHINE", cbx_machine, "PROD_MACHINE");
			DropDownList("SELECT DISTINCT PROD_STOCKCODE FROM TBL_PROD_GLUE_OUTPUT order by PROD_STOCKCODE", cbx_stockcode , "PROD_STOCKCODE");
			DropDownList("SELECT DISTINCT PROD_STOCKDESC FROM TBL_PROD_GLUE_OUTPUT order by PROD_STOCKDESC", cbx_prod_code, "PROD_STOCKDESC");			
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
			SqlCommand cmd = new SqlCommand(@"SELECT PROD_DATE, PROD_SHIFT, PROD_MACHINE, PROD_DOCNO, 
											PROD_STOCKCODE, PROD_STOCKDESC, PROD_QTY , PROD_QTYREJECT, PROD_UOM,
											PROD_OPERATOR, PROD_HELPER, PROD_SUPERVISOR 
											FROM TBL_PROD_GLUE_OUTPUT WHERE  PROD_DATE between @from_date and @to_date and (PROD_MACHINE = (@prod_machine) or @prod_machine is null) and (PROD_STOCKCODE = (@prod_stockcode) or @prod_stockcode is null) and (PROD_STOCKDESC = (@prod_prod_code) or @prod_prod_code is null)", conn);
				
			cmd.Parameters.AddWithValue("@from_date",  date_fr);
			cmd.Parameters.AddWithValue("@to_date",  date_to);
			
			if(cbx_machine.Text == "Please Select")
			{
				cmd.Parameters.AddWithValue("@prod_machine",  DBNull.Value);
				
			}
			else
			{
				cmd.Parameters.AddWithValue("@prod_machine", cbx_machine.Text);
				
			}
			
			if(cbx_stockcode.Text == "Please Select")
			{
				cmd.Parameters.AddWithValue("@prod_stockcode",  DBNull.Value);
				
			}
			else
			{
				cmd.Parameters.AddWithValue("@prod_stockcode", cbx_stockcode.Text);
				
			}
			
			if(cbx_prod_code.Text == "Please Select")
			{
				cmd.Parameters.AddWithValue("@prod_prod_code",  DBNull.Value);
				
			}
			else
			{
				cmd.Parameters.AddWithValue("@prod_prod_code", cbx_prod_code.Text);
				
			}
			
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
				MessageBox.Show("Error - Glue Output \nCannot load DB" + ex.Message + ex.ToString());
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
					
					
				reportViewer1.LocalReport.ReportPath =  @"..\..\report\PROD_GLUE_OUPUT2.rdl";
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
				return;
			}
		}
					
		void Btn_cancelClick(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}
	

