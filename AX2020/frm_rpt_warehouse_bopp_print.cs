using System;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;
using Microsoft.Reporting.WinForms;
using System.Collections.Generic; // For generic collections like List.
using System.Data.SqlClient;      // For the database connections and objects.
using System.Data.Sql;
using System.Data;
using System.IO;
using System.Diagnostics;
using CommonFunction;
using GenCode128;


namespace AX2020
{
	public partial class frm_rpt_warehouse_bopp_print : Form
	{
		public static string sqlconn = "Server=AX-UAT; Password=sbax2020sbg; User ID=sbax2020; Initial Catalog=SBG_AX_2020; Integrated Security=false";
		public static string sqlconn38 = "Server=WIN7-AX\\SBGAX; Password=sbax2020sbg; User ID=sbax2020; Initial Catalog=SBG_AX_2020; Integrated Security=false";
		
		string username;
		DataTable ds;
		private Microsoft.Reporting.WinForms.ReportViewer reportViewer2;
		
		public frm_rpt_warehouse_bopp_print()
		{
			InitializeComponent();
			//this.ControlBox = false;
			username = frm_menu_system.userName; 
			lbl_username.Text = "User : " + username;
		}
		
		protected override CreateParams CreateParams
	    {
	        get
	        {
	            CreateParams parms = base.CreateParams;
	            parms.ClassStyle |= 0x200;  // CS_NOCLOSE
	            return parms;
	        }
	    }

		void DataGrid(string sql_statement, DataGridView dt)
		{
			try
			{
				string sql = sql_statement;
		        SqlConnection connection = new SqlConnection(sqlconn38);
		        SqlDataAdapter dataadapter = new SqlDataAdapter(sql, connection);
		        ds = new DataTable();
		        connection.Open();
		        dataadapter.Fill(ds);
		                     
		        DataTable tempDT = new DataTable();
				tempDT = ds.DefaultView.ToTable(true, "stockcode", "barcode", "MICRON", "WIDTH", "lLength", "Color", "SupplierCode", "netweight", "invoiceno", "pono", "containerno", "flag");
				dt_grid.DataSource = AutoNumberedTable(tempDT);
					
		        dt.DataSource = AutoNumberedTable(ds);
		        //dt.DataSource = ds;
			}
			catch(Exception ex)
			{
				MessageBox.Show("Error" + ex.Message + ex.ToString());
				return;
			}
			finally
			{
				dt.Columns[0].Name = "No";
	            dt.Columns[0].Width = 30;
	            dt.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
				dt.Columns[0].HeaderText = "No";
				dt.Columns[1].HeaderText = "Stock Code";
				dt.Columns[1].Width = 50;
				dt.Columns[2].HeaderText = "Ship Mark";
				dt.Columns[2].Width = 100;
				dt.Columns[3].HeaderText = "Micron";
				dt.Columns[3].Width = 40;
				dt.Columns[4].HeaderText = "Width";
				dt.Columns[4].Width = 70;
//				dt.Columns[4].DefaultCellStyle.Format = "dd/MM/yyyy";
				dt.Columns[5].HeaderText = "Length";
				dt.Columns[5].Width = 70;
				dt.Columns[6].HeaderText = "Color";
				dt.Columns[6].Width = 80;
				dt.Columns[7].HeaderText = "Code";
				dt.Columns[7].Width = 40;
				dt.Columns[8].HeaderText = "Net Weight";
				dt.Columns[9].HeaderText = "Invoice";
				dt.Columns[10].HeaderText = "Po No";
				dt.Columns[11].HeaderText = "Container No";
				dt.Columns[12].HeaderText = "Duplicate";

			}

		}
		
		void Btn_cancelClick(object sender, EventArgs e)
		{
			this.Close();
		}
		
		void Frm_rpt_warehouse_fr_checklistLoad(object sender, EventArgs e)
		{
			//DataGrid("SELECT PROD_LINE, PROD_DOCNO, PROD_CUSTOMER, PROD_REPORTDATE, PROD_CODE, PROD_BRAND, PROD_COLOR, PROD_MICRON, PROD_WIDTH, PROD_LENGTH, PROD_QTYCTN, PROD_QTYROLL FROM TBL_PROD_WAREHOUSE_FR_RECEIVED where PROD_REPORTDATE>= cast (GETDATE() as DATE) order by PROD_REPORTDATE DESC, PROD_LINE DESC", dt_grid);
						
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
		
		static void LaunchCommandLineApp()
	    {
	        
	        // Use ProcessStartInfo class.
	        ProcessStartInfo startInfo = new ProcessStartInfo();
	        startInfo.CreateNoWindow = false;
	        startInfo.UseShellExecute = false;
	        startInfo.FileName = "ax2020_bopp.bat";
	        startInfo.WindowStyle = ProcessWindowStyle.Hidden;
	        //startInfo.Arguments = "-f j -o \"" + ex1 + "\" -z 1.0 -s y " + ex2;
	
	        try
	        {
	            // Start the process with the info we specified.
	            // Call WaitForExit and then the using-statement will close.
	            using (Process exeProcess = Process.Start(@startInfo))
	            {
	                exeProcess.WaitForExit();
	            }
	        }
	        catch
	        {
	            // Log error.
	        }
	    }
				
		void Btn_uploadClick(object sender, EventArgs e)
		{			
			OpenFileDialog fdlg = new OpenFileDialog();
			
			fdlg.Title = "Browse the File";
			fdlg.InitialDirectory = @"c:\";
			fdlg.Filter = "Text|*.txt|All|*.*";
			fdlg.FilterIndex = 2;
			fdlg.RestoreDirectory = true;
			
			if (fdlg.ShowDialog() == DialogResult.OK)
			{
				LaunchCommandLineApp();     
	        
				//System.Diagnostics.Process.Start(@"ax2020_bopp.bat");
				
				txtbx_upload_file.Text = Path.GetFileName(fdlg.FileName.ToString());
				string dest = Path.Combine(@"\\192.168.1.38\ZAXGRNBOPP\", Path.GetFileName(fdlg.FileName));
				File.Copy(Path.GetFullPath(fdlg.FileName), dest, true);
				//MessageBox.Show(Path.GetFullPath(fdlg.FileName.ToString()));
				
				TempTable("SP_AXERP_GRN_TEMPLATE_TXT_R2", dest);
				DataGrid("SELECT * FROM TBL_AXERP_GRN_TEMPLATE_TXT_R2 order by stockcode, barcode", dt_grid);
			}	
			
			
		}
		
		void TempTable(string statement, string dest)
		{
			using (SqlConnection conn = new SqlConnection(sqlconn38))
			{
				conn.Open();
				
				SqlCommand cmd  = new SqlCommand(statement, conn);
				cmd.CommandType = CommandType.StoredProcedure;
				
				cmd.Parameters.Add(new SqlParameter("@sp_doc", SqlDbType.NVarChar, 50));
				cmd.Parameters["@sp_doc"].Value = dest;
											   
				cmd.ExecuteNonQuery();
				//return true;					
			}				
		}
		
		void TempTable2(string statement)
		{
			using (SqlConnection conn = new SqlConnection(sqlconn38))
			{
				conn.Open();
				
				SqlCommand cmd  = new SqlCommand(statement, conn);
				cmd.CommandType = CommandType.StoredProcedure;
											   
				cmd.ExecuteNonQuery();
				//return true;					
			}				
		}
		
		void Btn_saveClick(object sender, EventArgs e)
		{
			for(int i = 0; i< dt_grid.RowCount; i++)
			{
				if (dt_grid.Rows[i].Cells[12].Value.ToString().Trim() == "Yes")
				{
					MessageBox.Show("Cannot have duplicate Shipping mark");
					return;					
				}	
			}
			
			TempTable2("SP_AXERP_GRN_TEMPLATE_TXT_R2_2");
			DialogBox.ShowSaveSuccessDialog();
			Print();		
		}
		
		void Print()
		{			
			using(Form frm = new Form())
			{
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
					reportViewer2.LocalReport.ReportPath = @"..\..\report\PROD_CONV_AX_BOPP_LABEL_TEMP.rdl";
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
		
		private DataSet GetData()
		{
			SqlConnection conn = new SqlConnection(sqlconn38);
			
			SqlCommand cmd = new SqlCommand("SELECT * FROM TBL_AXERP_GRN_ZPBOPPRM01", conn);
//			SqlCommand cmd = new SqlCommand(@"SELECT [itemcode]
//											,[itemshipmark]
//											,[itemcolor]
//											,[itemmicron]
//											,[itemwidth]
//											,[itemlength]
//											,[itemlotno]
//											,[itembarcode]
//											,[itemwarehouse]
//											,[itemnetweight]
//											,[itemstatus]
//            FROM TBL_AXERP_GRN_ZPBOPPRM01 WHERE itemwarehouse like @container + '%'", conn);
				
			//cmd.Parameters.AddWithValue("@container",  txtbx_container_no.Text.ToUpper());
			
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
				MessageBox.Show("Error - Warehouse BOPP Print \nCannot load DB" + ex.Message + ex.ToString());
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
	}
}


