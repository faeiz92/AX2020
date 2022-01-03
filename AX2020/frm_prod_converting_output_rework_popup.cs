
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic; // For generic collections like List.
using System.Data.SqlClient;      // For the database connections and objects.
using System.Data.Sql;
using System.Data;
using System.Data.Sql;


namespace AX2020
{
	
	public partial class frm_prod_converting_output_rework_popup : Form
	{
		public static string sqlconn = "Server=AX-UAT; Password=sbax2020sbg; User ID=sbax2020; Initial Catalog=SBG_AX_2020; Integrated Security=false";
		public static string Sqlconn = "DSN=eb9gf;Port=2138;Uid=dba;Pwd=sql";
		internal static string prod_code = null, prod_desc=null, prod_desc2=null;

		DataTable ds;
		
		public frm_prod_converting_output_rework_popup()
		{
			
			InitializeComponent();
			this.ControlBox = false;
		}
		
		void DataGrid()
		{
//			SqlConnection con_SP = new SqlConnection(sqlconn);
//			SqlCommand cmd_SP = new SqlCommand();
//				
//			try 
//			{
//				cmd_SP.CommandText = @"SELECT PROD_CODE, PROD_DESC, PROD_UOM FROM TBL_PROD_RIBBON_BOM ORDER BY PROD_CODE";
//				cmd_SP.Connection = con_SP;
//				con_SP.Open();
//				SqlDataAdapter dataadapter = new SqlDataAdapter(cmd_SP);	
//								 
//			    //DataSet ds = new DataSet();
//			    //DataTable ds = new DataTable();
//			    ds = new DataTable();
//			    dataadapter.Fill(ds);
//				this.dt_grid.DataSource = ds;
//  				//this.dt_grid.DataSource = AutoNumberedTable(ds);
//
//			}
//			catch(Exception ex)
//			{
//				MessageBox.Show("Error" + ex.Message + ex.ToString());
//				return;
//			}

			SqlConnection conn = new SqlConnection(Sqlconn);
			SqlCommand cmd = new SqlCommand();
			
            DataTable ds = new DataTable();
            cmd.CommandText = @"select mcode, mdesc1, mdesc2 from stk where mmc = 'GF' and mcode like '8%' and mstatus = 'A' and mcode not like '%OEM' and mcode not like '%m2'";
            //string cmdSql = "select mcode, mdesc1, mdesc2 from stk where mmc = 'GF' and mcode like '8%' and mstatus = 'A' and mcode not like '%OEM' and mcode not like '%m2'";
            cmd.Connection = conn;
            SqlDataAdapter sda = new SqlDataAdapter(cmd);

            try
            {
                conn.Open();
                sda.Fill(ds);
                this.dt_grid.DataSource = AutoNumberedTable(ds);
                
            }
            catch(SqlException se)
            {
            	MessageBox.Show("Error - Converting Rework Popup ERP \nCannot load DB \n" + se.ToString() + se.Message);
            	return;
            }
            finally
            {
                conn.Close();
            
//				dt_grid.Columns[0].Name = "No";
//	            dt_grid.Columns[0].Width = 35;
//	            dt_grid.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
//	            dt_grid.Columns[1].HeaderText = "Stock Code";
//	            dt_grid.Columns[1].Width = 150;
//	            dt_grid.Columns[2].HeaderText = "Description";
//				dt_grid.Columns[2].Width = 200;            
//	            dt_grid.Columns[3].HeaderText = "UOM"; 	
				
				dt_grid.Columns[0].Name = "No";
	            dt_grid.Columns[0].Width = 35;
	            dt_grid.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
	            	           
	            dt_grid.Columns[1].HeaderText = "Stock Code";
	            dt_grid.Columns[1].Width = 180;
	            dt_grid.Columns[2].HeaderText = "Description";
				dt_grid.Columns[2].Width = 350;            
				dt_grid.Columns[3].HeaderText = "Description 2";
	            dt_grid.Columns[3].Width = 375; 
			}
			
			conn.Dispose();
			conn = null;
			//cmd = null;
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
		
		void Dt_gridCellClick(object sender, DataGridViewCellEventArgs e)
		{
			if(dt_grid.SelectedRows.Count > 0) // make sure user select at least 1 row 
			{
				prod_code = dt_grid.SelectedRows[0].Cells[1].Value.ToString();
				prod_desc = dt_grid.SelectedRows[0].Cells[2].Value.ToString();
				prod_desc2 = dt_grid.SelectedRows[0].Cells[3].Value.ToString();
				this.Close();				
			}			
		}
	
		
		void Btn_cancelClick(object sender, EventArgs e)
		{
			prod_code = null;
			prod_desc = null;
			prod_desc2 = null;
			this.Close();
		}
		
		void Dt_gridDataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
		{
			dt_grid.ClearSelection();	
		}
		
		void Txtbx_stock_codeKeyUp(object sender, KeyEventArgs e)
		{
			//DataTable ds = new DataTable();
			ds.DefaultView.RowFilter = "mcode LIKE '%" + txtbx_stock_code.Text + "%'";
   			this.dt_grid.DataSource = ds.DefaultView;
		}
		
		void Frm_prod_converting_output_rework_popupLoad(object sender, EventArgs e)
		{
			DataGrid();
		}
	}
}
