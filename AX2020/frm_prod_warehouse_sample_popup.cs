using System;
using System.Drawing;
using System.Windows.Forms;
using System.Data;
using System.Collections.Generic; // For generic collections like List.
using System.Data.SqlClient;      // For the database connections and objects.
using System.Data.Sql;
using System.Data;
using System.Data.Sql;

namespace AX2020
{
	
	public partial class frm_prod_warehouse_sample_popup : Form
	{
		public static string sqlconn = "Server=AX-UAT; Password=sbax2020sbg; User ID=sbax2020; Initial Catalog=SBG_AX_2020; Integrated Security=false";
		public static string sqlconn2 = "Server=AX-SQL; Password=ax2020sbgroup; User ID=ax2020sb; Initial Catalog=AX2020StagingDB; Integrated Security=false";
		
		internal static string prod_code = null, prod_desc=null, prod_uom=null;

		
		DataTable ds;
		
		public frm_prod_warehouse_sample_popup()
		{
			InitializeComponent();
			this.ControlBox = false;
		}
		
		void StockCode()
		{
			SqlConnection conn = new SqlConnection(sqlconn2);
            DataTable ds = new DataTable();
            string cmdSql = "select itemid, DOT_Description, unitid from VIEW_AXERP_INVENTTABLE where dataareaid = 'sbti' and itemid not like 'WJ%' and itemid not like 'WG%' and itemid not like 'Z%' and itemid not like 'X%' and itemid not like 'P%' and itemid not like 'Q%'";
            SqlDataAdapter sda = new SqlDataAdapter(cmdSql, conn);

            try
            {
                conn.Open();
                ds = new DataTable();
			    sda.Fill(ds);
				this.dt_grid.DataSource = ds;
            
            }catch(SqlException se)
            {
            	MessageBox.Show("Error - Sampple datagrid \nCannot load DB \n" + se.ToString() + se.Message);
            }
            finally
            {
            	dt_grid.Columns[0].HeaderText = "Stock Code";
	            dt_grid.Columns[0].Width = 150;
	            dt_grid.Columns[1].HeaderText = "Description";
				dt_grid.Columns[1].Width = 400;            
	            dt_grid.Columns[2].HeaderText = "UOM";
                conn.Close();
                conn.Dispose();
				conn = null;
				cmdSql = null;
            }
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
		
		void Frm_prod_warehouse_sample_popupLoad(object sender, EventArgs e)
		{
			//DataGrid();
			StockCode();
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
			//(dt_grid.DataSource as DataTable)
			(dt_grid.DataSource as DataTable).DefaultView.RowFilter = " itemid LIKE '%" + txtbx_stockcode.Text + "%'";
   			//this.dt_grid.DataSource = ds.DefaultView;
		}
	}
}
