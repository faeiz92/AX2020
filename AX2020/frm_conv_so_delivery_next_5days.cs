/*
 * Created by SharpDevelop.
 * User: faeiz
 * Date: 2017-09-14
 * Time: 1:51 PM
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
using System.Data.Sql;
using System.IO;
using fyiReporting.RdlViewer;
using fyiReporting;
using System.Linq;

namespace AX2020
{
	/// <summary>
	/// Description of frm_conv_so_delivery_next_5days.
	/// </summary>
	public partial class frm_conv_so_delivery_next_5days : Form
	{
		public static string sqlconn3 = "Server=AX-SQL; Password=ax2020sbgroup; User ID=ax2020sb; Initial Catalog=AX2020StagingDB; Integrated Security=false";

		public frm_conv_so_delivery_next_5days()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			datagrid();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		
		void datagrid()
		{
			string sql = "select * from  [dbo].[VIEW_AXERP_SO_DETAIL_BACKORDER_ADVDUE] ORDER BY SoETD, SoCustomer, SoItemcode";
            SqlConnection connection = new SqlConnection(sqlconn3);
            SqlDataAdapter dataadapter = new SqlDataAdapter(sql, connection);
            DataTable ds = new DataTable();
            connection.Open();
            dataadapter.Fill(ds);
                     
            DataTable tempDT = new DataTable();
  			tempDT = ds.DefaultView.ToTable(true,"SoCustomer","SoNo","SoLineNo","SoItemCode" ,"SoItemName" ,"SoQty" ,"SoUOM" ,"SoETD" ,"Salesman");
   			dataGridView1.DataSource = tempDT;
   
  			connection.Close();

   			dataGridView1.Columns[0].HeaderText = "SoCustomer";
   			dataGridView1.Columns[1].HeaderText = "SoNo";
  			dataGridView1.Columns[2].HeaderText = "SoLineNo";
   			dataGridView1.Columns[3].HeaderText = "SoItemCode";
   			dataGridView1.Columns[4].HeaderText = "SoItemName";
   			dataGridView1.Columns[5].HeaderText = "SoQty";
   			dataGridView1.Columns[6].HeaderText = "SoUOM";
   			dataGridView1.Columns[7].HeaderText = "SoETD";
   			dataGridView1.Columns[8].HeaderText = "Salesman";
   			
		}
	}
}
