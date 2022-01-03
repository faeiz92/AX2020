using System;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using System.Collections.Generic; // For generic collections like List.
using System.Data.SqlClient;      
using System.Data.Sql;
using System.Data;
using CommonFunction;
using CommonLibrary;
using CommonControl.Functions;

namespace AX2020
{
	/// <summary>
	/// Description of frm_prod_warehouse_ax_wj303_print_all.
	/// </summary>
	public partial class frm_prod_warehouse_ax_wj303_print_all : Form
	{
		public static string sqlconn = "Server=AX-UAT; Password=sbax2020sbg; User ID=sbax2020; Initial Catalog=SBG_AX_2020; Integrated Security=false";
		string jr_shipmark, jr_barcode;
		DataTable ds;
		
		public frm_prod_warehouse_ax_wj303_print_all()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			this.ControlBox = false;
			lbl_username.Text = "User : " + frm_menu_system.userName;
			reportViewer1.Visible = false;			
		}
		
		void Btn_cancelClick(object sender, EventArgs e)
		{
			this.Close();
		}
		
		void Btn_clearClick(object sender, EventArgs e)
		{
			txtbx_ref_no.Clear();
		}
		
		void DataGrid(string sql_statement, DataGridView dt)
		{
			try
			{
				string sql = sql_statement;
		        SqlConnection connection = new SqlConnection(sqlconn);
		        SqlDataAdapter dataadapter = new SqlDataAdapter(sql, connection);
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
				dt.Columns[0].HeaderText = "Stock Code";
				dt.Columns[0].Width = 120;
				dt.Columns[1].HeaderText = "Shipping Mark";
				dt.Columns[1].Width = 100;
				dt.Columns[2].HeaderText = "Color";
				dt.Columns[2].Width = 80;
				dt.Columns[3].HeaderText = "Width";
				dt.Columns[3].Width = 80;
				//dt.Columns[3].DefaultCellStyle.Format = "dd/MM/yyyy";
				dt.Columns[4].HeaderText = "Length";
				dt.Columns[4].Width = 80;
				dt.Columns[5].HeaderText = "Warehouse";
				dt.Columns[5].Width = 120;
				

			}

		}
		
		private DataSet GetData()
		{
			SqlConnection conn = new SqlConnection(sqlconn);
			
			//SqlCommand cmd = new SqlCommand("SELECT PROD_MACHINE, SUM(PROD_QTYCTN) AS SUMQTYCTN, SUM(PROD_M2) AS SUMM2, SUM(PROD_TOTALROLL) AS SUMTOTALROLL FROM TBL_PROD_CONV_JO_QUICK_PACK_SUMMARY_TEMP WHERE PROD_DATE BETWEEN @from_date and @to_date GROUP BY PROD_MACHINE ORDER BY PROD_MACHINE", conn);
			SqlCommand cmd = new SqlCommand(@"SELECT * FROM TBL_PROD_WAREHOUSE_AX_WJ303_ALL_TEMP order by prod_stockcode, prod_shipmark", conn);
				
			//cmd.Parameters.AddWithValue("@sp_ship_mark", txtbx_ref_no.Text.ToUpper());
			
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
				MessageBox.Show("Error - Warehouse \nCannot load DB" + ex.Message + ex.ToString());
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
		
		void TempTable()
		{
			using (SqlConnection conn = new SqlConnection(sqlconn))
			{
				conn.Open();
				
				SqlCommand cmd  = new SqlCommand("SP_PROD_WAREHOUSE_AX_WJ303_ALL_TEMP", conn);
				cmd.CommandType = CommandType.StoredProcedure;
				
//				cmd.Parameters.Add(new SqlParameter("@SP_PROD_SHIPMARK", SqlDbType.NVarChar, 50));
//				cmd.Parameters["@SP_PROD_SHIPMARK"].Value = txtbx_ref_no.Text.ToUpper();
					
											   
				cmd.ExecuteNonQuery();
				//return true;					
			}				
		}
		
		void Btn_searchClick(object sender, EventArgs e)
		{
			if (txtbx_ref_no.Text == null | txtbx_ref_no.Text == string.Empty) 
			{
        		MessageBox.Show("Please key-in Shipping Mark");
				return;
			}
			
//			if (txtbx_ref_no.Text == "999") 
//			{
//        		MessageBox.Show("This Shipping Mark cannot be track");
//				return;
//			}
//			
//			SqlConnection con = new SqlConnection(sqlconn);
//			SqlCommand cmd = new SqlCommand();
//			
//			try 
//			{
//				//cmd.CommandText = "select twh, tstk, tlot_no, tref_no, twidth, tlength, tthickness, tcolor from stk_lot where tstk like 'WJ%' and twh = 'GF1' and tbal_qty > 1 '" + txtbx_ref_no.Text + "'";
//				cmd.CommandText = "select JRBarcode, TrxLotNo, TrxJoNo, TrxJoThickness, TrxJoWidth, TrxTotalLength, TrxJoColor, TrxShipMark from VIEW_CONVERTING_BARCODE where TrxShipMark like @ship_mark + '%' or JRBarcode = @ship_mark";
//				cmd.Parameters.AddWithValue("@ship_mark",  txtbx_ref_no.Text.ToUpper());
//				cmd.Connection = con;
//				con.Open();
//				SqlDataReader rd = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
//				
//				if (rd.HasRows)
//				{
//					while (rd.Read())
//					{			        	
//						jr_shipmark = rd["TrxShipMark"].ToString();
//						jr_barcode = rd["JrBarcode"].ToString();
//						jr_lot_no = rd["TrxLotNo"].ToString();
//						jr_ref_no = rd["TrxJoNo"].ToString();
//						txtbx_mic.Text = (Convert.ToInt32(rd["TrxJoThickness"])).ToString();
//						jr_color = rd["TrxJoColor"].ToString();	
//						TempTable();
//										
//					} 
//				}
//				else 
//				{
//					MessageBox.Show("Shipping Mark does not exist");
//					return;
//				}
//			} 
//			catch (Exception ex) 
//			{
//				MessageBox.Show("Error - Shipmark Check \nCannot load DB!" + ex.Message + ex.ToString());
//				return;
//			} 
//			finally 
//			{
//				con.Close();
//			}
//			
//			con.Dispose();
//			con = null;
//			cmd = null;
			
						
			Print();
		}
		
		
		void Frm_prod_warehouse_ax_wj303_print_allLoad(object sender, EventArgs e)
		{
			DataGrid("SELECT * FROM [AX-SQL].[AX2020StagingDB].dbo.[VIEW_AXERP_QOH_SM02_WJ303] order by itemid, shippingmark", dt_grid);
			
			
		}
		
		private Microsoft.Reporting.WinForms.ReportViewer reportViewer2;
		
		void Print()
		{
			using(Form frm = new Form())
			{
				//TempTable();
	        	frm.Height = 700;
	        	frm.Width = 800;
				frm.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
				
				
				try
				{
					this.reportViewer2 = new Microsoft.Reporting.WinForms.ReportViewer();
					this.reportViewer2.AutoScroll = true;
					this.reportViewer2.Location = new System.Drawing.Point(0, 0);
					this.reportViewer2.Name = "ReportViewer";
					this.reportViewer2.Size = new System.Drawing.Size(949, 700);
					this.reportViewer2.TabIndex = 0;
					frm.Controls.Add(this.reportViewer2);
					reportViewer2.Visible = true;
					reportViewer2.ProcessingMode = ProcessingMode.Local;
					reportViewer2.LocalReport.ReportPath = @"..\..\report\PROD_CONV_AX_WJ303_LABEL.rdl";
					DataSet ds = new DataSet();
					//DataSet ds2 = new DataSet();
					ds = GetData();
					//ds2 = GetData2();
						
					if (ds.Tables[0].Rows.Count > 0)
					{
						reportViewer2.LocalReport.DataSources.Clear();
						ReportDataSource rds = new ReportDataSource("DataSet1", ds.Tables[0]);
						//ReportDataSource rds2 = new ReportDataSource("DataSet2", ds2.Tables[0]);					
	
						reportViewer2.LocalReport.DataSources.Add(rds);
						//reportViewer1.LocalReport.DataSources.Add(rds2);
							
						reportViewer2.LocalReport.Refresh();
						reportViewer2.RefreshReport();
						frm.ShowDialog(this);
					}				
				}
				catch(Exception ex)
				{
					MessageBox.Show(ex.Message + ex.InnerException.Message + ex.InnerException.InnerException.Message);
				}
			}
		}
		
		void Btn_printClick(object sender, EventArgs e)
		{
			Print();
		}
	}
}
