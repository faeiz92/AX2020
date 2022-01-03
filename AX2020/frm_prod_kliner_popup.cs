using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic; // For generic collections like List.
using System.Data.SqlClient;      // For the database connections and objects.
using System.Data.Sql;
using System.Data;


namespace AX2020
{
	
	public partial class frm_prod_kliner_popup : Form
	{
		public static string sqlconn = "Server=AX-UAT; Password=sbax2020sbg; User ID=sbax2020; Initial Catalog=SBG_AX_2020; Integrated Security=false";
		internal static string prod_code = null, prod_desc=null, prod_uom=null;

		DataTable ds;
		
		public frm_prod_kliner_popup()
		{
			
			InitializeComponent();
			this.ControlBox = false;
		}
		
		void DataGrid()
		{
			SqlConnection con_SP = new SqlConnection(sqlconn);
			SqlCommand cmd_SP = new SqlCommand();
				
			try 
			{
				cmd_SP.CommandText = @"SELECT PROD_CODE, PROD_DESC, PROD_UOM FROM TBL_PROD_RIBBON_BOM ORDER BY PROD_CODE";
				cmd_SP.Connection = con_SP;
				con_SP.Open();
				SqlDataAdapter dataadapter = new SqlDataAdapter(cmd_SP);	
								 
			    //DataSet ds = new DataSet();
			    //DataTable ds = new DataTable();
			    ds = new DataTable();
			    dataadapter.Fill(ds);
				this.dt_grid.DataSource = ds;
  				//this.dt_grid.DataSource = AutoNumberedTable(ds);

			}
			catch(Exception ex)
			{
				MessageBox.Show("Error" + ex.Message + ex.ToString());
				return;
			}
			finally
			{
				con_SP.Close();
//				dt_grid.Columns[0].Name = "No";
//	            dt_grid.Columns[0].Width = 35;
//	            dt_grid.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
//	            dt_grid.Columns[1].HeaderText = "Stock Code";
//	            dt_grid.Columns[1].Width = 150;
//	            dt_grid.Columns[2].HeaderText = "Description";
//				dt_grid.Columns[2].Width = 200;            
//	            dt_grid.Columns[3].HeaderText = "UOM"; 	
				
					           
	            dt_grid.Columns[0].HeaderText = "Stock Code";
	            dt_grid.Columns[0].Width = 150;
	            dt_grid.Columns[1].HeaderText = "Description";
				dt_grid.Columns[1].Width = 200;            
	            dt_grid.Columns[2].HeaderText = "UOM";
			}
			
			con_SP.Dispose();
			con_SP = null;
			cmd_SP = null;
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
				prod_code = dt_grid.SelectedRows[0].Cells[0].Value.ToString();
				prod_desc = dt_grid.SelectedRows[0].Cells[1].Value.ToString();
				prod_uom = dt_grid.SelectedRows[0].Cells[2].Value.ToString();
				this.Close();				
			}
			
		}
		
		void Frm_prod_kliner_popupLoad(object sender, EventArgs e)
		{
			DataGrid();
		}
		
		void Btn_cancelClick(object sender, EventArgs e)
		{
			prod_code = null;
			prod_desc = null;
			prod_uom = null;
			this.Close();
		}
		
		void Dt_gridDataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
		{
			dt_grid.ClearSelection();	
		}
		
		void Txtbx_stock_codeKeyUp(object sender, KeyEventArgs e)
		{
			//DataTable ds = new DataTable();
			ds.DefaultView.RowFilter = "PROD_CODE LIKE '%" + txtbx_stock_code.Text + "%'";
   			this.dt_grid.DataSource = ds.DefaultView;
		}
	}
}
