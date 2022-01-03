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
	
	public partial class frm_rpt_converting_progress_r3 : Form
	{
		public static string sqlconn = "Server=AX-UAT; Password=sbax2020sbg; User ID=sbax2020; Initial Catalog=SBG_AX_2020; Integrated Security=false";
		DateTime? date_fr, date_to;
		string username;
		
		public frm_rpt_converting_progress_r3()
		{			
			InitializeComponent();
			this.ControlBox = false;
			username = frm_menu_system.userName; 
			lbl_username.Text = "User : " + username;
		}
		
		void Btn_searchClick(object sender, EventArgs e)
		{
			if(String.IsNullOrWhiteSpace(txtbx_jo_no.Text) && String.IsNullOrWhiteSpace(txtbx_so_no.Text) && String.IsNullOrWhiteSpace(txtbx_cust.Text) 
			   && dtp_date_from.Checked == false && dtp_date_to.Checked == false && String.IsNullOrWhiteSpace(txtbx_brand.Text) && String.IsNullOrWhiteSpace(txtbx_color.Text) && String.IsNullOrWhiteSpace(txtbx_ctn_bx.Text)
			   && String.IsNullOrWhiteSpace(txtbx_code.Text))
			{
				MessageBox.Show("Please input data to search");
				return;
			}
			
			if(dtp_date_from.Checked == true && dtp_date_to.Checked == false)
			{
				MessageBox.Show("Please select date to");
				return;
			}
			
			if(dtp_date_from.Checked == false && dtp_date_to.Checked == true)
			{
				MessageBox.Show("Please select date from");
				return;
			}
			
			using (SqlConnection conn = new SqlConnection(sqlconn))
			{
				conn.Open();
				SqlCommand cmd  = new SqlCommand("SP_PROD_CONV_PROGRESS_FILTER_R3", conn);
				cmd.CommandType = CommandType.StoredProcedure;
				
				cmd.Parameters.Add(new SqlParameter("@SP_JODATEFROM", SqlDbType.DateTime));
				cmd.Parameters.Add(new SqlParameter("@SP_JODATETO", SqlDbType.DateTime));
				cmd.Parameters.Add(new SqlParameter("@SP_JODOCNO", SqlDbType.NVarChar, 50));
				cmd.Parameters.Add(new SqlParameter("@SP_JOSONO", SqlDbType.NVarChar, 50));
				cmd.Parameters.Add(new SqlParameter("@SP_JOCUSTOMER", SqlDbType.NVarChar, 50));
				cmd.Parameters.Add(new SqlParameter("@SP_JOBRAND", SqlDbType.NVarChar, 50));
				cmd.Parameters.Add(new SqlParameter("@SP_JOCTNBX", SqlDbType.NVarChar, 250));
				cmd.Parameters.Add(new SqlParameter("@SP_JOCOLOR", SqlDbType.NVarChar, 50));
				cmd.Parameters.Add(new SqlParameter("@SP_JOSTOCKCODE", SqlDbType.NVarChar, 50));
				
				if(dtp_date_from.Checked == false)
				{
					cmd.Parameters["@SP_JODATEFROM"].Value = DBNull.Value;
					cmd.Parameters["@SP_JODATETO"].Value = DBNull.Value;	
				}
				else
				{
					date_fr = dtp_date_from.Value.Date;             
					date_to = dtp_date_to.Value.Date.AddDays(1).AddSeconds(-1);
					
					cmd.Parameters["@SP_JODATEFROM"].Value = date_fr;
					cmd.Parameters["@SP_JODATETO"].Value = date_to;
				}
				
				if(String.IsNullOrWhiteSpace(txtbx_jo_no.Text))
				{
					cmd.Parameters["@SP_JODOCNO"].Value = DBNull.Value;
				}
				else
				{
				   	cmd.Parameters["@SP_JODOCNO"].Value = txtbx_jo_no.Text;
				}
				
				if(String.IsNullOrWhiteSpace(txtbx_so_no.Text))
				{
					cmd.Parameters["@SP_JOSONO"].Value = DBNull.Value;
				}
				else
				{
				   	cmd.Parameters["@SP_JOSONO"].Value = txtbx_so_no.Text;
				}
				
				if(String.IsNullOrWhiteSpace(txtbx_cust.Text))
				{
					cmd.Parameters["@SP_JOCUSTOMER"].Value = DBNull.Value;
				}
				else
				{
				   	cmd.Parameters["@SP_JOCUSTOMER"].Value = txtbx_cust.Text;
				}
				
				
				if(String.IsNullOrWhiteSpace(txtbx_brand.Text))
				{
					cmd.Parameters["@SP_JOBRAND"].Value = DBNull.Value;
				}
				else
				{
				   	cmd.Parameters["@SP_JOBRAND"].Value = txtbx_brand.Text;
				}
				
				
				if(String.IsNullOrWhiteSpace(txtbx_ctn_bx.Text))
				{
					cmd.Parameters["@SP_JOCTNBX"].Value = DBNull.Value;
				}
				else
				{
				   	cmd.Parameters["@SP_JOCTNBX"].Value = txtbx_ctn_bx.Text;
				}
				
				if(String.IsNullOrWhiteSpace(txtbx_color.Text))
				{
					cmd.Parameters["@SP_JOCOLOR"].Value = DBNull.Value;
				}
				else
				{
				   	cmd.Parameters["@SP_JOCOLOR"].Value = txtbx_color.Text;
				}
				
				if(String.IsNullOrWhiteSpace(txtbx_code.Text))
				{
					cmd.Parameters["@SP_JOSTOCKCODE"].Value = DBNull.Value;
				}
				else
				{
				   	cmd.Parameters["@SP_JOSTOCKCODE"].Value = txtbx_code.Text;
				}
			
				
				cmd.ExecuteNonQuery();
				DataGrid();
				SSRS();
				
			}
			
		}
		
		private DataSet GetData()
		{
			SqlConnection conn = new SqlConnection(sqlconn);
			SqlCommand cmd = new SqlCommand("SELECT * FROM TBL_PROD_CONV_JO_PROGRESS_TEMP", conn);
			
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
				MessageBox.Show("Error - Converting Prod Progress \nCannot load DB" + ex.Message + ex.ToString());
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
		
		void DataGrid()
		{			
			try
			{	        
		        string sql = "SELECT * FROM TBL_PROD_CONV_JO_PROGRESS_TEMP";
		        SqlConnection connection = new SqlConnection(sqlconn);
		        SqlDataAdapter dataadapter = new SqlDataAdapter(sql, connection);
		        DataTable ds = new DataTable();
		        connection.Open();
		        dataadapter.Fill(ds);
		               
		        dt_grid.DataSource = ds;
		                     	        
			}
			catch(Exception ex)
			{
				MessageBox.Show("Error - Converting Prod Progress \nCannot load DB" + ex.Message + ex.ToString());
			}	
			finally
			{
				dt_grid.Columns[0].HeaderText = "Jo No";
				dt_grid.Columns[0].Width = 150;
				dt_grid.Columns[1].HeaderText = "Jo Date";
				dt_grid.Columns[1].Width = 70;
				dt_grid.Columns[1].DefaultCellStyle.Format = "dd/MM/yyyy";
				dt_grid.Columns[2].HeaderText = "Customer";
				dt_grid.Columns[2].Width = 150;
				dt_grid.Columns[3].HeaderText = "Stock Code";
				dt_grid.Columns[3].Width = 80;
				dt_grid.Columns[4].HeaderText = "Brand";
				dt_grid.Columns[4].Width = 70;
				dt_grid.Columns[5].HeaderText = "Color";
				dt_grid.Columns[5].Width = 60;
				dt_grid.Columns[6].HeaderText = "Micron";
				dt_grid.Columns[6].Width = 60;
				dt_grid.Columns[7].HeaderText = "Width";
				dt_grid.Columns[7].Width = 60;
				dt_grid.Columns[8].HeaderText = "Length";
				dt_grid.Columns[8].Width = 60;
				dt_grid.Columns[9].HeaderText = "Roll/Ctn";
				dt_grid.Columns[9].Width = 60;
				dt_grid.Columns[10].HeaderText = "Total Qty Order";
				dt_grid.Columns[10].Width = 60;
				
				dt_grid.Columns[11].HeaderText = "Prod.Qty";
				dt_grid.Columns[11].Width = 60;
				dt_grid.Columns[12].HeaderText = "Prod.Qty.Bal";
				dt_grid.Columns[12].Width = 60;
				dt_grid.Columns[13].HeaderText = "Pack.Qty";
				dt_grid.Columns[13].Width = 60;
				dt_grid.Columns[14].HeaderText = "Pack.Qty.Bal";
				dt_grid.Columns[14].Width = 60;
				
				dt_grid.Columns[15].HeaderText = "Start Date";
				dt_grid.Columns[15].Width = 60;
				dt_grid.Columns[15].DefaultCellStyle.Format = "dd/MM/yyyy";
				dt_grid.Columns[16].HeaderText = "End Date";
				dt_grid.Columns[16].Width = 60;
				dt_grid.Columns[16].DefaultCellStyle.Format = "dd/MM/yyyy";
				
				dt_grid.Columns[17].HeaderText = "Ctn Box";
				dt_grid.Columns[17].Width = 80;
			}
			
		}
			
		void SSRS()
		{
			try
			{
				reportViewer1.Visible = true;
				reportViewer1.ProcessingMode = ProcessingMode.Local;
				reportViewer1.LocalReport.ReportPath = @"..\..\report\PROD_CONV_PROGRESS_R1.rdl";
				DataSet ds = new DataSet();
				
				ds = GetData();
					
					
				if (ds.Tables[0].Rows.Count > 0)
				{
					reportViewer1.LocalReport.DataSources.Clear();
					ReportDataSource rds = new ReportDataSource("DataSet1", ds.Tables[0]);					
					reportViewer1.LocalReport.DataSources.Add(rds);
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
			}
		}
		
		void Btn_cancelClick(object sender, EventArgs e)
		{
			this.Close();
		}
		
		
		
		void Frm_rpt_converting_progress_r3Load(object sender, EventArgs e)
		{
			reportViewer1.AutoSize = false;			
		}
	}
}
