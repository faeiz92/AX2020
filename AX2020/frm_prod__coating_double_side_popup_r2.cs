/*
 * Created by SharpDevelop.
 * User: ax2020-1
 * Date: 1/10/2017
 * Time: 3:59 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
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
	/// <summary>
	/// Description of frm_ribbon_popup.
	/// </summary>
	public partial class frm_prod_double_side_popup : Form
	{
		public static string sqlconn = "Server=AX-UAT; Password=sbax2020sbg; User ID=sbax2020; Initial Catalog=SBG_AX_2020; Integrated Security=false";
		public static string Sqlconn1 = "DSN=eb9gf;Port=2138;Uid=dba;Pwd=sql";
		public static string sqlconn2 = "Server=AX-SQL; Password=ax2020sbgroup; User ID=ax2020sb; Initial Catalog=AX2020StagingDB; Integrated Security=false";

		double wet_weight =0, ttl_weight_glue=0;	
		double fin_qty=0;
		
		internal static string prod_code = null, prod_desc=null, prod_uom=null;

		DataTable ds;
		
		public frm_prod_double_side_popup()
		{
			InitializeComponent();
			this.ControlBox = false;
			
		}
		
		void StockCode()
		{
			SqlConnection conn = new SqlConnection(sqlconn);
            DataTable ds = new DataTable();
            string cmdSql = "select * from TBL_AX2020_DOUBLESIDE_GLUE_DESCRIPTION";
            SqlDataAdapter sda = new SqlDataAdapter(cmdSql, conn);

            try
            {
                conn.Open();
                ds = new DataTable();
			    sda.Fill(ds);
				this.dt_grid.DataSource = ds;
                //sda.Fill(ds);
                //cbx_ctn_bx_code.Items.Add("Please Select");
            
            }catch(SqlException se)
            {
            	MessageBox.Show("Error - glue datarid \nCannot load DB \n" + se.ToString() + se.Message);
            }
            finally
            {
            	dt_grid.Columns[0].HeaderText = "Stock Code";
	            dt_grid.Columns[0].Width = 150;
	            dt_grid.Columns[1].HeaderText = "Description";
				dt_grid.Columns[1].Width = 200;            
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
			
		//	string rep_txtbx_stockcode = frm_prod_coating_double_side_r2.set_stockcode;
//			double rep_txtbx_width = frm_prod_coating_double_side_r2.set_width;
//			double rep_txtb_length = frm_prod_coating_double_side_r2.set_length;
//			string rep_dt_consume = frm_prod_coating_double_side_r2.set_dt_consume;			
			
			if(dt_grid.SelectedRows.Count > 0) // make sure user select at least 1 row 
			{
				prod_code = dt_grid.SelectedRows[0].Cells[0].Value.ToString();
				prod_desc = dt_grid.SelectedRows[0].Cells[1].Value.ToString();
				prod_uom = dt_grid.SelectedRows[0].Cells[2].Value.ToString();
				
			
				this.Close();
							
			}
			
		}
		
		void Frm_prod_glue_popupLoad(object sender, EventArgs e)
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
		
		void rep_txtbx_stockcodeKeyUp(object sender, KeyEventArgs e)
		{
			//DataTable ds = new DataTable();
			//(dt_grid.DataSource as DataTable)
   			//this.dt_grid.DataSource = ds.DefaultView;
		}
		
		void Txtbx_stockcodeTextChanged(object sender, EventArgs e)
		{
		(dt_grid.DataSource as DataTable).DefaultView.RowFilter = " itemid LIKE '%" + txtbx_stockcode.Text + "%'";
		}
	}
}
