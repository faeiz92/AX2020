using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic; // For generic collections like List.
using System.Data.SqlClient;      
using System.Data.Sql;
using System.Data.Sql;
using System.Data;
using CommonFunction;
using CommonLibrary;
using CommonControl.Functions;
using Microsoft.Reporting.WinForms;

namespace AX2020
{
	
	public partial class frm_prod_converting_output_rewinding_print : Form
	{
		public static string sqlconn = "Server=AX-UAT; Password=sbax2020sbg; User ID=sbax2020; Initial Catalog=SBG_AX_2020; Integrated Security=false";
		string prod_line;
		
		
		public frm_prod_converting_output_rewinding_print()
		{
			
			InitializeComponent();
			this.ControlBox = false;
			lbl_username.Text = "User : " + frm_menu_system.userName;
		}
		
		void Btn_cancelClick(object sender, EventArgs e)
		{
			this.Close();
		}
		
		void Btn_clearClick(object sender, EventArgs e)
		{
			txtbx_ref_no.Clear();
		}
		
		void DataGrid(string sql)
		{
			try
			{
		        SqlConnection connection = new SqlConnection(sqlconn);
		        SqlDataAdapter dataadapter = new SqlDataAdapter(sql, connection);
		        //DataSet ds = new DataSet();
		        DataTable ds = new DataTable();
		        connection.Open();
		        //dataadapter.Fill(ds, "TBL_PROD_CONV_JO_SLITTING");
		        dataadapter.Fill(ds);
		                     
		        DataTable tempDT = new DataTable();
				tempDT = ds.DefaultView.ToTable(true, "PROD_DOCNO", "PROD_LINE", "PROD_DATE", "PROD_SHIFT", "PROD_CUSTOMER", "PROD_CODE", "PROD_BRAND", "PROD_COLOR", "PROD_MICRON", "PROD_WIDTH", "PROD_LENGTH", "PROD_QTYREJECT", "PROD_TOTALROLL");
				dt_grid.DataSource = tempDT;
					
				//connection.Close();
//		        dt_grid.DataSource = ds;
//              dt_grid.DataMember = "TBL_PROD_CONV_JO_SLITTING";
//  			dt_grid.DataMember = ds;
			}
			catch(Exception ex)
			{
				MessageBox.Show("Error" + ex.Message + ex.ToString());
				return;
			}
			finally
			{
				dt_grid.Columns[0].HeaderText = "Ref No";
				dt_grid.Columns[0].Width = 150;
				dt_grid.Columns[1].HeaderText = "Line No";
				dt_grid.Columns[1].Width = 80;
				
				dt_grid.Columns[2].HeaderText = "Date";
				dt_grid.Columns[2].Width = 60;
				
				dt_grid.Columns[3].HeaderText = "Shift";
				dt_grid.Columns[3].Width = 80;
				
				dt_grid.Columns[4].HeaderText = "Customer";
				dt_grid.Columns[4].Width = 150;
				dt_grid.Columns[5].HeaderText = "Code";
				dt_grid.Columns[5].Width = 80;
				dt_grid.Columns[6].HeaderText = "Brand";
				dt_grid.Columns[6].Width = 80;
				dt_grid.Columns[7].HeaderText = "Color";
				dt_grid.Columns[7].Width = 80;
				dt_grid.Columns[8].HeaderText = "Micron";
				dt_grid.Columns[9].HeaderText = "Width";
				dt_grid.Columns[10].HeaderText = "Length";
				dt_grid.Columns[11].HeaderText = "Qty Reject";
				dt_grid.Columns[12].HeaderText = "Total Roll";

			}
		}
		
		void Btn_searchClick(object sender, EventArgs e)
		{
			if (txtbx_ref_no.Text == null | txtbx_ref_no.Text == string.Empty) 
			{
        		MessageBox.Show("Please key-in Jo No");
				return;
			}
			
			
			SqlConnection con_SP1 = new SqlConnection(sqlconn);
			SqlCommand cmd_SP1 = new SqlCommand();
			
			try 
			{
				cmd_SP1.CommandText = "select * from TBL_PROD_CONV_JO_REWINDING where PROD_DOCNO = '" + txtbx_ref_no.Text + "'";
				cmd_SP1.Connection = con_SP1;
				con_SP1.Open();
				SqlDataReader rd_SP1 = cmd_SP1.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
				
				if(rd_SP1.HasRows)
				{
					DataGrid("SELECT * FROM TBL_PROD_CONV_JO_REWINDING  where PROD_DOCNO = '" + txtbx_ref_no.Text + "' order by PROD_DATE DESC, PROD_SHIFT, PROD_LINE");				
				}
				else
				{
					MessageBox.Show("JO no does not exist");
				}
				
			}
			catch(Exception ex)
			{
				MessageBox.Show("Error - Converting Packing Print \nCannot load DB \n" + ex.Message + ex.ToString());
				
			}
			 
			finally
			{
				con_SP1.Close();	
			}
			
			con_SP1.Dispose();
			con_SP1 = null;
			cmd_SP1 = null;
		}
		
		public void Print()
		{		
			using(Form frm = new Form())
			{
				
	        	frm.Height = 500;
	        	frm.Width = 600;
				frm.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;				
				
				var reportViewer1 = new ReportViewer();
				
				try
				{
					reportViewer1.Reset();
					reportViewer1.Visible = true;
					reportViewer1.ProcessingMode = ProcessingMode.Local;
					reportViewer1.LocalReport.ReportPath = @"..\..\report\PROD_CONV_REWIND_LABEL_3.rdl";
					DataSet ds = new DataSet();
					//DataSet ds2 = new DataSet();
					ds = GetData();
					//ds2 = GetData2();
					
					if (ds.Tables[0].Rows.Count > 0)
					{
					
						//reportViewer1.LocalReport.DataSources.Clear();
						ReportDataSource rds = new ReportDataSource("DataSet1", ds.Tables[0]);
						//ReportDataSource rds2 = new ReportDataSource("DataSet2", ds2.Tables[0]);					
						
						ReportParameter[] parameters = new ReportParameter[1];
						parameters[0] = new ReportParameter("prod_line", prod_line);
						//parameters[1] = new ReportParameter("to_date", date_to.ToString("yyyy-MM-dd"));
				    
						//this.reportViewer1.RefreshReport(); 
						//reportViewer1.LocalReport.DataSources.Clear();					
//						ReportParameter p1 = new ReportParameter("@from_date", date_fr);
//    					ReportParameter p2 = new ReportParameter("@to_date", _p2);
//						
//						reportViewer1.LocalReport.SetParameters(

						reportViewer1.LocalReport.DataSources.Add(rds);
						reportViewer1.LocalReport.SetParameters(parameters);
						//reportViewer1.LocalReport.DataSources.Add(rds2);
						
						reportViewer1.LocalReport.Refresh();
						reportViewer1.RefreshReport();
						
						reportViewer1.Dock = DockStyle.Fill;
				
				        //reportViewer1.SetPageSettings(myPageSettings);
						reportViewer1.PrinterSettings.DefaultPageSettings.Landscape = true;
						//reportViewer1.PrinterSettings.Copies = short.Parse(txtbx_no_logroll.Text);
	        			frm.Controls.Add(reportViewer1);

        				frm.ShowDialog(this);
					}				
				}
				catch(Exception ex)
				{
					MessageBox.Show(ex.Message + ex.ToString());// + ex.InnerException.Message);
					//return false;
				}
			}
				
		}
				
		private DataSet GetData()
		{
			SqlConnection conn = new SqlConnection(sqlconn);
			
			SqlCommand cmd = new SqlCommand("SELECT * FROM TBL_PROD_CONV_JO_REWINDING_SHIPMARK_LR where PROD_LINE like @prod_line + '%'", conn);
			//SqlCommand cmd = new SqlCommand(@"SELECT * FROM TBL_PROD_CONV_JO WHERE JODATE BETWEEN @from_date AND @to_date", conn);
			
			cmd.Parameters.AddWithValue("@prod_line",  prod_line);			
			//cmd.Parameters.AddWithValue("@from_date",  date_fr);
			//cmd.Parameters.AddWithValue("@to_date",  date_to);
			
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
				
		void Dt_gridCellClick(object sender, DataGridViewCellEventArgs e)
		{
			//ref_no = 
			txtbx_ref_no.Text = dt_grid.SelectedRows[0].Cells[0].Value + string.Empty;
			prod_line = dt_grid.SelectedRows[0].Cells[1].Value + string.Empty;
			Print();
		}
	}
}
