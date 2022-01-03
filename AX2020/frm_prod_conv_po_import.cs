/*
 * Created by SharpDevelop.
 * User: faeiz
 * Date: 2017-09-14
 * Time: 1:39 PM
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
	/// Description of frm_po_import.
	/// </summary>
	public partial class frm_po_import : Form
	{
						public static string sqlconn3 = "Server=AX-SQL; Password=ax2020sbgroup; User ID=ax2020sb; Initial Catalog=AX2020StagingDB; Integrated Security=false";

		public frm_po_import()
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
			string sql = "select * from  VIEW_AXERP_PO_ETD_IMPORT_WHSE order by deliverydate, purchname, itemid";
            SqlConnection connection = new SqlConnection(sqlconn3);
            SqlDataAdapter dataadapter = new SqlDataAdapter(sql, connection);
            DataTable ds = new DataTable();
            connection.Open();
            dataadapter.Fill(ds);
                     
            DataTable tempDT = new DataTable();
  			tempDT = ds.DefaultView.ToTable(true,"purchid","PURCHREQID","itemid","name" ,"PURCHQTY" ,"REMAININVENTPHYSICAL" ,"PURCHUNIT" ,"deliveryDate" ,"purchname", "invoiceaccount", "CREATEDBY");
   			dataGridView1.DataSource = tempDT;
   
  			connection.Close();

   			dataGridView1.Columns[0].HeaderText = "PURCHID";
   			dataGridView1.Columns[1].HeaderText = "PURCHREQID";
  			dataGridView1.Columns[2].HeaderText = "ITEMID";
   			dataGridView1.Columns[3].HeaderText = "NAME";
   			dataGridView1.Columns[4].HeaderText = "PURCHQTY";
   			dataGridView1.Columns[5].HeaderText = "REMAININVENTPHYSICAL";
   			dataGridView1.Columns[6].HeaderText = "PURCHUNIT";
   			dataGridView1.Columns[7].HeaderText = "deliveryDate";
   			dataGridView1.Columns[8].HeaderText = "purchname";
   			dataGridView1.Columns[9].HeaderText = "invoiceaccount";
   			dataGridView1.Columns[10].HeaderText = "CREATEDBY";
   			
		}
		
		
		
		
		
		void Button1Click(object sender, EventArgs e)
		{
			string sql = "select * from  VIEW_AXERP_PO_ETD_IMPORT_WHSE  where deliverydate >= '" + date_from.Value.ToString("MM/dd/yyyy") + "' and deliverydate <= '" + date_from.Value.ToString("MM/dd/yyyy") +"'";
            SqlConnection connection = new SqlConnection(sqlconn3);
            SqlDataAdapter dataadapter = new SqlDataAdapter(sql, connection);
            DataTable ds = new DataTable();
            connection.Open();
            dataadapter.Fill(ds);
                     
            DataTable tempDT = new DataTable();
  			tempDT = ds.DefaultView.ToTable(true,"purchid","PURCHREQID","itemid","name" ,"PURCHQTY" ,"REMAININVENTPHYSICAL" ,"PURCHUNIT" ,"deliveryDate" ,"purchname", "invoiceaccount", "CREATEDBY");
   			dataGridView1.DataSource = tempDT;
   
  			connection.Close();

   			dataGridView1.Columns[0].HeaderText = "PURCHID";
   			dataGridView1.Columns[1].HeaderText = "PURCHREQID";
  			dataGridView1.Columns[2].HeaderText = "ITEMID";
   			dataGridView1.Columns[3].HeaderText = "NAME";
   			dataGridView1.Columns[4].HeaderText = "PURCHQTY";
   			dataGridView1.Columns[5].HeaderText = "REMAININVENTPHYSICAL";
   			dataGridView1.Columns[6].HeaderText = "PURCHUNIT";
   			dataGridView1.Columns[7].HeaderText = "deliveryDate";
   			dataGridView1.Columns[8].HeaderText = "purchname";
   			dataGridView1.Columns[9].HeaderText = "invoiceaccount";
   			dataGridView1.Columns[10].HeaderText = "CREATEDBY";
		}
		
		void Btn_subsoClick(object sender, EventArgs e)
		{
			string sql = "select * from  VIEW_AXERP_PO_ETD_IMPORT_WHSE  where name like '" + txtbx_name.Text + "%'" ;
            SqlConnection connection = new SqlConnection(sqlconn3);
            SqlDataAdapter dataadapter = new SqlDataAdapter(sql, connection);
            DataTable ds = new DataTable();
            connection.Open();
            dataadapter.Fill(ds);
                     
            DataTable tempDT = new DataTable();
  			tempDT = ds.DefaultView.ToTable(true,"purchid","PURCHREQID","itemid","name" ,"PURCHQTY" ,"REMAININVENTPHYSICAL" ,"PURCHUNIT" ,"deliveryDate" ,"purchname", "invoiceaccount", "CREATEDBY");
   			dataGridView1.DataSource = tempDT;
   
  			connection.Close();

   			dataGridView1.Columns[0].HeaderText = "PURCHID";
   			dataGridView1.Columns[1].HeaderText = "PURCHREQID";
  			dataGridView1.Columns[2].HeaderText = "ITEMID";
   			dataGridView1.Columns[3].HeaderText = "NAME";
   			dataGridView1.Columns[4].HeaderText = "PURCHQTY";
   			dataGridView1.Columns[5].HeaderText = "REMAININVENTPHYSICAL";
   			dataGridView1.Columns[6].HeaderText = "PURCHUNIT";
   			dataGridView1.Columns[7].HeaderText = "deliveryDate";
   			dataGridView1.Columns[8].HeaderText = "purchname";
   			dataGridView1.Columns[9].HeaderText = "invoiceaccount";
   			dataGridView1.Columns[10].HeaderText = "CREATEDBY";
		}
		
		void Btn_sonoClick(object sender, EventArgs e)
		{
			string sql = "select * from  VIEW_AXERP_PO_ETD_IMPORT_WHSE  where purchid like '%" + txtxbx_search_so.Text + "'" ;
            SqlConnection connection = new SqlConnection(sqlconn3);
            SqlDataAdapter dataadapter = new SqlDataAdapter(sql, connection);
            DataTable ds = new DataTable();
            connection.Open();
            dataadapter.Fill(ds);
                     
            DataTable tempDT = new DataTable();
  			tempDT = ds.DefaultView.ToTable(true,"purchid","PURCHREQID","itemid","name" ,"PURCHQTY" ,"REMAININVENTPHYSICAL" ,"PURCHUNIT" ,"deliveryDate" ,"purchname", "invoiceaccount", "CREATEDBY");
   			dataGridView1.DataSource = tempDT;
   
  			connection.Close();

   			dataGridView1.Columns[0].HeaderText = "PURCHID";
   			dataGridView1.Columns[1].HeaderText = "PURCHREQID";
  			dataGridView1.Columns[2].HeaderText = "ITEMID";
   			dataGridView1.Columns[3].HeaderText = "NAME";
   			dataGridView1.Columns[4].HeaderText = "PURCHQTY";
   			dataGridView1.Columns[5].HeaderText = "REMAININVENTPHYSICAL";
   			dataGridView1.Columns[6].HeaderText = "PURCHUNIT";
   			dataGridView1.Columns[7].HeaderText = "deliveryDate";
   			dataGridView1.Columns[8].HeaderText = "purchname";
   			dataGridView1.Columns[9].HeaderText = "invoiceaccount";
   			dataGridView1.Columns[10].HeaderText = "CREATEDBY";
		}
		
		void Date_fromValueChanged(object sender, EventArgs e)
		{
			date_from.Format = DateTimePickerFormat.Custom;

			date_from.CustomFormat = "MMMM";

			date_from.ShowUpDown = true;
		}
	}
}
