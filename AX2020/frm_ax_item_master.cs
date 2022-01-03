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
	public partial class frm_ax_item_master : Form
	{
		public static string sqlconn = "Server=AX-SQL; Password=ax2020sbgroup; User ID=ax2020sb; Initial Catalog=AX2020StagingDB; Integrated Security=false";
		//string date_fr, date_to;
		DateTime date_fr, date_to;
		string username;
		DataTable ds;
		
		public frm_ax_item_master()
		{
			InitializeComponent();
			this.ControlBox = false;
			username = frm_menu_system.userName; 
			lbl_username.Text = "User : " + username;
		}
		
		void DataGrid(string sql_statement, DataGridView dt)
		{
			try
			{
				string sql = sql_statement;
		        SqlConnection connection = new SqlConnection(sqlconn);
		        SqlDataAdapter dataadapter = new SqlDataAdapter(sql, connection);
		        dataadapter.ReturnProviderSpecificTypes = true;
		        ds = new DataTable();
		        connection.Open();
		        dataadapter.Fill(ds);
		                     
//		        DataTable tempDT = new DataTable();
//				tempDT = ds.DefaultView.ToTable(true, "PROD_LINE", "PROD_DOCNO", "PROD_CUSTOMER", "PROD_DATE", "PROD_CODE", "PROD_BRAND", "PROD_COLOR", "PROD_MICRON", "PROD_WIDTH", "PROD_LENGTH", "PROD_QTYCTNRECEIVED", "PROD_QTYROLLRECEIVED");
//				dt_grid.DataSource = AutoNumberedTable(tempDT);
					
		        //dt.DataSource = AutoNumberedTable(ds);
		        dt.DataSource = ds;
			}
			catch(Exception ex)
			{
				MessageBox.Show("Error" + ex.Message + ex.ToString());
				return;
			}
			finally
			{
//				dt.Columns[0].Name = "No";
//	            dt.Columns[0].Width = 35;
//	            dt.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
//				dt.Columns[0].HeaderText = "Line No";
//				dt.Columns[0].Width = 80;
//				dt.Columns[1].HeaderText = "Jo No";
//				dt.Columns[1].Width = 80;
//				dt.Columns[2].HeaderText = "Customer";
//				dt.Columns[2].Width = 200;
//				dt.Columns[3].HeaderText = "Date";
//				dt.Columns[3].Width = 80;
//				dt.Columns[3].DefaultCellStyle.Format = "dd/MM/yyyy";
//				dt.Columns[4].HeaderText = "Code";
//				dt.Columns[4].Width = 80;
//				dt.Columns[5].HeaderText = "Brand";
//				dt.Columns[5].Width = 80;
//				dt.Columns[6].HeaderText = "Color";
//				dt.Columns[6].Width = 80;
//				dt.Columns[7].HeaderText = "Micron";
//				dt.Columns[8].HeaderText = "Width";
//				dt.Columns[9].HeaderText = "Length";
//				dt.Columns[10].HeaderText = "Qty Ctn";
//				dt.Columns[11].HeaderText = "Qty Roll";

			}

		}
		
		private DataSet GetData(DateTime date_fr, DateTime date_to)
		{
			SqlConnection conn = new SqlConnection(sqlconn);
			
			//SqlCommand cmd = new SqlCommand("SELECT PROD_MACHINE, SUM(PROD_QTYCTN) AS SUMQTYCTN, SUM(PROD_M2) AS SUMM2, SUM(PROD_TOTALROLL) AS SUMTOTALROLL FROM TBL_PROD_CONV_JO_QUICK_PACK_SUMMARY_TEMP WHERE PROD_DATE BETWEEN @from_date and @to_date GROUP BY PROD_MACHINE ORDER BY PROD_MACHINE", conn);
			SqlCommand cmd = new SqlCommand(@"SELECT * FROM TBL_PROD_CONV_JO WHERE JODATE BETWEEN @from_date AND @to_date", conn);
				
			cmd.Parameters.AddWithValue("@from_date",  date_fr);
			cmd.Parameters.AddWithValue("@to_date",  date_to);
			
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
			
			//date_fr = dtp_date_from.Value.Date;
			//date_to = dtp_date_to.Value.Date.AddDays(1).AddSeconds(-1);
			
			DataGrid("SELECT * FROM VIEW_AXERP_ITEM_MASTER_ATTRIBUTE_FULLINFO4 order by ITEMID", dt_grid);
			
//			try
//				{
//					reportViewer1.Visible = true;
//					reportViewer1.ProcessingMode = ProcessingMode.Local;
//					reportViewer1.LocalReport.ReportPath = @"..\..\report\IncomingOrder.rdl";
//					DataSet ds = new DataSet();
//					//DataSet ds2 = new DataSet();
//					ds = GetData(date_fr, date_to);
//					//ds2 = GetData2();
//					
//					if (ds.Tables[0].Rows.Count > 0)
//					{
//						reportViewer1.LocalReport.DataSources.Clear();
//						ReportDataSource rds = new ReportDataSource("DataSet1", ds.Tables[0]);
//						//ReportDataSource rds2 = new ReportDataSource("DataSet2", ds2.Tables[0]);					
//						
//						ReportParameter[] parameters = new ReportParameter[2];
//						parameters[0] = new ReportParameter("@from_date", dtp_date_from.Value.ToString("yyyy-MM-dd"));
//						MessageBox.Show(date_fr.Date.ToString());
//						parameters[1] = new ReportParameter("@to_date", dtp_date_to.Value.ToString("yyyy-MM-dd"));
//				        reportViewer1.LocalReport.SetParameters(parameters);
//						
////						ReportParameter p1 = new ReportParameter("@from_date", date_fr);
////    					ReportParameter p2 = new ReportParameter("@to_date", _p2);
////						
////						reportViewer1.LocalReport.SetParameters(
//						reportViewer1.LocalReport.DataSources.Add(rds);
//						//reportViewer1.LocalReport.DataSources.Add(rds2);
//						
//						reportViewer1.LocalReport.Refresh();
//						reportViewer1.RefreshReport();
//					}				
//				}
//				catch(Exception ex)
//				{
//					MessageBox.Show(ex.Message + ex.InnerException.Message);
//					//return false;
//				}
		}
		
		
		
		void Btn_cancelClick(object sender, EventArgs e)
		{
			this.Close();
		}
		
		void Frm_rpt_warehouse_fr_checklistLoad(object sender, EventArgs e)
		{
			DataGrid("SELECT * FROM VIEW_AXERP_ITEM_MASTER_ATTRIBUTE_FULLINFO4 order by ITEMID", dt_grid);
						
		}
		
		private DataTable AutoNumberedTable(DataTable SourceTable)
		{
		
			DataTable ResultTable = new DataTable();
			DataColumn AutoNumberColumn = new DataColumn();
			AutoNumberColumn.ColumnName ="No";
			AutoNumberColumn.DataType = typeof(int);
			AutoNumberColumn.AutoIncrement = true;
			AutoNumberColumn.AutoIncrementSeed = 1;
			AutoNumberColumn.AutoIncrementStep = 1;
			
			ResultTable.Columns.Add(AutoNumberColumn);
			ResultTable.Merge(SourceTable);
			return ResultTable;
		
		}
		

		
		void Txtbx_pack_noKeyUp(object sender, KeyEventArgs e)
		{
			//DataTable ds = new DataTable();
			ds.DefaultView.RowFilter = "itemid LIKE '%" + txtbx_pack_no.Text + "%'";
   			this.dt_grid.DataSource = ds.DefaultView;
		}
	}
}
	

