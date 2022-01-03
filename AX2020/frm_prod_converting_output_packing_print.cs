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
using fyiReporting;
using fyiReporting.RdlViewer;

namespace AX2020
{
	
	public partial class frm_prod_converting_output_packing_print : Form
	{
		public static string sqlconn = "Server=AX-UAT; Password=sbax2020sbg; User ID=sbax2020; Initial Catalog=SBG_AX_2020; Integrated Security=false";
		string pack_no;
		
		public frm_prod_converting_output_packing_print()
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
				tempDT = ds.DefaultView.ToTable(true, "PROD_DOCNO", "PROD_LINE", "PROD_DATE", "PROD_SHIFT", "PROD_CUSTOMER", "PROD_CODE", "PROD_BRAND", "PROD_COLOR", "PROD_MICRON", "PROD_WIDTH", "PROD_LENGTH", "PROD_QTYCTN", "PROD_QTYROLL", "PROD_TOTALROLL");
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
				dt_grid.Columns[11].HeaderText = "Qty Ctn";
				dt_grid.Columns[12].HeaderText = "Qty Roll";
				dt_grid.Columns[13].HeaderText = "Total Roll";

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
				cmd_SP1.CommandText = "select * from TBL_PROD_CONV_JO_PACKING where PROD_DOCNO = '" + txtbx_ref_no.Text + "'";
				cmd_SP1.Connection = con_SP1;
				con_SP1.Open();
				SqlDataReader rd_SP1 = cmd_SP1.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
				
				if(rd_SP1.HasRows)
				{
					DataGrid("SELECT * FROM TBL_PROD_CONV_JO_PACKING  where PROD_DOCNO = '" + txtbx_ref_no.Text + "' order by PROD_DATE DESC, PROD_SHIFT, PROD_LINE");				
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
			//try
			//{
			using(Form frm = new Form())
			{
				//Form frm = new Form();
	        	frm.Height = 700;
	        	frm.Width = 800;
				frm.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
	
	        	//fyiReporting.RdlViewer.RdlViewer rdlView = new fyiReporting.RdlViewer.RdlViewer();
	        	var rdlViewer1 = new fyiReporting.RdlViewer.RdlViewer();
				var reportStrip = new fyiReporting.RdlViewer.ViewerToolstrip(rdlViewer1);
	        	Uri baseUri = new Uri(System.IO.Directory.GetCurrentDirectory());
	        	
//	        	if(cbx_remark5.Text == "SLITTING")
//	        	{
//	        		rdlViewer1.SourceFile = new Uri(baseUri, @"../report/planning_jo_converting_7.rdl");
//	        	}
//	        	else
//	        	{
//	        		rdlViewer1.SourceFile = new Uri(baseUri, @"../report/planning_jo_converting_9.rdl");
//	        	}
	        	//rdlView.Parameters += string.Format("&TestParam1={0}&TestParam2={1}", "Value 1", "Value 2");
	        	rdlViewer1.SourceFile = new Uri(baseUri, @"../report/planning_jo_converting_10_1.rdl");
	        	rdlViewer1.Report.DataSets["Data"].SetSource("select * from TBL_PROD_CONV_JO_PACKING_LIST_TEMP where PROD_LINE = '" + pack_no + "'");
	        	rdlViewer1.Rebuild();
	
	        	rdlViewer1.Dock = DockStyle.Fill;
	        	frm.Controls.Add(rdlViewer1);
	        	frm.Controls.Add(reportStrip);

        		frm.ShowDialog(this);
        	
			}	
		}
				
		void TempTable()
		{
			using (SqlConnection conn = new SqlConnection(sqlconn))
			{
				conn.Open();
				
				SqlCommand cmd  = new SqlCommand("SP_PROD_CONV_JO_PACKING_LIST", conn);
				cmd.CommandType = CommandType.StoredProcedure;
				
				cmd.Parameters.Add(new SqlParameter("@SP_DOCNO", SqlDbType.NVarChar, 50));
				cmd.Parameters["@SP_DOCNO"].Value = txtbx_ref_no.Text.ToUpper();
					
				cmd.Parameters.Add(new SqlParameter("@SP_PACKNO", SqlDbType.NVarChar, 50));
				cmd.Parameters["@SP_PACKNO"].Value = pack_no;
								   
				cmd.ExecuteNonQuery();
				//return true;					
			}				
		}
		
		void Dt_gridCellClick(object sender, DataGridViewCellEventArgs e)
		{
			//ref_no = 
			txtbx_ref_no.Text = dt_grid.SelectedRows[0].Cells[0].Value + string.Empty;
			pack_no = dt_grid.SelectedRows[0].Cells[1].Value + string.Empty;
			TempTable();
			Print();
		}
	}
}
