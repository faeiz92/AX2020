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
	public partial class frm_rpt_glue_consume : Form
	{
		public static string sqlconn = "Server=AX-UAT; Password=sbax2020sbg; User ID=sbax2020; Initial Catalog=SBG_AX_2020; Integrated Security=false";
		//string date_fr, date_to;
		DateTime date_fr, date_to;
		string username;
		
		public frm_rpt_glue_consume()
		{
			InitializeComponent();
			this.ControlBox = false;
			username = frm_menu_system.userName; 
			lbl_username.Text = "User : " + username;
			
			DropDownList("SELECT DISTINCT PRODC_MACHINE FROM TBL_PROD_GLUE_CONSUME order by PRODC_MACHINE", cbx_machine, "PRODC_MACHINE");
			DropDownList("SELECT DISTINCT PRODC_STOCKCODE FROM TBL_PROD_GLUE_CONSUME order by PRODC_STOCKCODE", cbx_stockcode, "PRODC_STOCKCODE");
			DropDownList("SELECT DISTINCT PRODC_REMARK1 FROM TBL_PROD_GLUE_CONSUME order by PRODC_REMARK1", cbx_prod_code, "PRODC_REMARK1");
			DropDownList("SELECT DISTINCT PRODC_REMARK2 FROM TBL_PROD_GLUE_CONSUME order by PRODC_REMARK2", cbx_desc, "PRODC_REMARK2");
			
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
			SqlCommand cmd = new SqlCommand(@"SELECT PRODC_DATE, PRODC_SHIFT, PRODC_MACHINE, PRODC_DOCNO, 
											PRODC_STOCKCODE, PRODC_STOCKDESC, PRODC_QTY , PRODC_QTYREJECT, PRODC_UOM,
											PRODC_OPERATOR, PRODC_HELPER, PRODC_SUPERVISOR 
											FROM TBL_PROD_GLUE_CONSUME WHERE PRODC_DATE between @from_date and @to_date and (PRODC_MACHINE = (@prodc_machine) or @prodc_machine is null) and (PRODC_STOCKCODE = (@prodc_stockcode) or @prodc_stockcode is null) and (PRODC_REMARK1 = (@prodc_prod_code) or @prodc_prod_code is null) and (PRODC_REMARK2 = (@prodc_prod_desc) or @prodc_prod_desc is null)", conn);
				
			cmd.Parameters.AddWithValue("@from_date",  date_fr);
			cmd.Parameters.AddWithValue("@to_date",  date_to);
			
			if(cbx_machine.Text == "Please Select")
			{
				cmd.Parameters.AddWithValue("@prodc_machine",  DBNull.Value);
				
			}
			else
			{
				cmd.Parameters.AddWithValue("@prodc_machine", cbx_machine.Text);
				
			}
			
			if(cbx_stockcode.Text == "Please Select")
			{
				cmd.Parameters.AddWithValue("@prodc_stockcode",  DBNull.Value);
				
			}
			else
			{
				cmd.Parameters.AddWithValue("@prodc_stockcode", cbx_stockcode.Text);
				
			}
			
			if(cbx_prod_code.Text == "Please Select")
			{
				cmd.Parameters.AddWithValue("@prodc_prod_code",  DBNull.Value);
				
			}
			else
			{
				cmd.Parameters.AddWithValue("@prodc_prod_code", cbx_prod_code.Text);
				
			}
			
			if(cbx_desc.Text == "Please Select")
			{
				cmd.Parameters.AddWithValue("@prodc_prod_desc",  DBNull.Value);
				
			}
			else
			{
				cmd.Parameters.AddWithValue("@prodc_prod_desc", cbx_desc.Text);
				
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
				MessageBox.Show("Error - Glue Consume \nCannot load DB" + ex.Message + ex.ToString());
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
					
					
				reportViewer1.LocalReport.ReportPath =  @"..\..\report\PROD_GLUE_CONSUME_LATEST.rdl";
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
	


