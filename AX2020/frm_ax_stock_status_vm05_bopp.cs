/*
 * Created by SharpDevelop.
 * User: faeiz
 * Date: 2017-10-14
 * Time: 1:19 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;									
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Data;						
using System.Collections.Generic;		/***header untuk jalankan akktiviti/jenis coding dalam c#***/
using System.ComponentModel;			
using System.IO.Ports;
using System.Text;
using CommonFunction;
using CommonLibrary;
using CommonControl.Functions;
using System.Drawing.Drawing2D;
using System.IO;
using fyiReporting.RdlViewer;
using fyiReporting;
using System.Linq;


namespace AX2020
{
	/// <summary>
	/// Description of frm_stock_status_vm05_bopp.
	/// </summary>
	public partial class frm_ax_stock_status_vm05_bopp : Form
	{
		public static string sqlconn = "Server=AX-UAT; Password=sbax2020sbg; User ID=sbax2020; Initial Catalog=SBG_AX_2020; Integrated Security=false";
		DataTable ds;
		
		public frm_ax_stock_status_vm05_bopp()
		{
			InitializeComponent();
			//datagridview1();
			DataGrid("SELECT * FROM VIEW_AXERP_TFRSTK_BOPP_VM05 where AVAILPHYSICAL > 1", dataGridView1);
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
		
		private void datagridview1()
        {
            string sql = "SELECT * FROM VIEW_AXERP_TFRSTK_BOPP_VM05 where AVAILPHYSICAL > 1";
            SqlConnection connection = new SqlConnection(sqlconn);
            SqlDataAdapter dataadapter = new SqlDataAdapter(sql, connection);
            DataSet ds = new DataSet();
            connection.Open();
            dataadapter.Fill(ds, "Authors_table");
            connection.Close();
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "Authors_table";
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
		                     
		        DataTable tempDT = new DataTable();
				tempDT = ds.DefaultView.ToTable(true, "ITEMID", "INVENTBATCHID", "COLOR", "MICRON", "WIDTH", "LLENGTH", "BRAND", "GRADE", "LOTNO", "PONUMBER", "SHIPMARK", "BATCHNUMBER", "AVAILPHYSICAL");
				//tempDT = ds.ToTable();
				dt.DataSource = AutoNumberedTable(tempDT);
					
		        //dt.DataSource = AutoNumberedTable(ds);
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
	            dt.Columns[0].Width = 45;
	            dt.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
				dt.Columns[0].HeaderText = "No";
				dt.Columns[1].HeaderText = "Stock Code";
				dt.Columns[1].Width = 130;
				dt.Columns[2].HeaderText = "Ship Mark";
				dt.Columns[2].Width = 130;
				dt.Columns[3].HeaderText = "Color";
				dt.Columns[3].Width = 50;
				dt.Columns[4].HeaderText = "Micron";
				dt.Columns[4].Width = 40;
//				dt.Columns[4].DefaultCellStyle.Format = "dd/MM/yyyy";
				dt.Columns[5].HeaderText = "Width";
				dt.Columns[5].Width = 50;
				dt.Columns[6].HeaderText = "Length";
				dt.Columns[6].Width = 50;
				dt.Columns[7].HeaderText = "Brand";
				dt.Columns[7].Width = 40;
				dt.Columns[8].HeaderText = "Grade";
				dt.Columns[8].Width = 40;
				dt.Columns[9].HeaderText = "Lot No";
				dt.Columns[9].Width = 40;
				dt.Columns[10].HeaderText = "Po No";
				dt.Columns[10].Width = 40;
				dt.Columns[11].HeaderText = "Shipmark";
				dt.Columns[11].Width = 70;
				dt.Columns[12].HeaderText = "Batch No";
				dt.Columns[12].Width = 70;
				dt.Columns[13].HeaderText = "Qty";
				dt.Columns[12].Width = 80;

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
		
	}
}
