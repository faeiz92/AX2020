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
	
	public partial class frm_po_via_pr : Form
	{
		
		public static string sqlconn3 = "Server=AX-SQL; Password=ax2020sbgroup; User ID=ax2020sb; Initial Catalog=AX2020StagingDB; Integrated Security=false";
		public static string sqlconn = "Server=AX-UAT; Password=sbax2020sbg; User ID=sbax2020; Initial Catalog=SBG_AX_2020; Integrated Security=false";

		public frm_po_via_pr()
		{
			InitializeComponent();
			txtbx_prno2.Visible = false;
			date2.Visible = false;
			btn_pr2.Visible = false;
			btn_date2.Visible = false;
			dataGridView2.Visible = false;
			datagrid();
			datagrid2();
			
			
//			DateTime myDateTime = DateTime.Now;
		
		}
		
		
		void datagrid()
		{
			string sql = "SELECT * FROM RPT_AXERP_CONV_PO_LOCAL";
            SqlConnection connection = new SqlConnection(sqlconn);
            SqlDataAdapter dataadapter = new SqlDataAdapter(sql, connection);
            DataTable ds = new DataTable();
            connection.Open();
            dataadapter.Fill(ds);
                     
            DataTable tempDT = new DataTable();
  			tempDT = ds.DefaultView.ToTable(true,"purchid", "purchreqid", "itemid", "name", "purchqty", "receivedqty", "varianceqty", "remaininventphysical", "purchunit", "DeliveryDate","receiveddate", "purchname", "invoiceaccount", "createdby");
   			dataGridView1.DataSource = tempDT;
   
  			connection.Close();

   			dataGridView1.Columns[0].HeaderText = "PURCHID";
   			dataGridView1.Columns[1].HeaderText = "PURCHREQID";
  			dataGridView1.Columns[2].HeaderText = "ITEMID";
   			dataGridView1.Columns[3].HeaderText = "NAME";
   			dataGridView1.Columns[4].HeaderText = "PURCHQTY";
   			dataGridView1.Columns[5].HeaderText = "receivedqty";
   			dataGridView1.Columns[6].HeaderText = "varianceqty";
   			dataGridView1.Columns[7].HeaderText = "REMAININVENTPHYSICAL";
   			dataGridView1.Columns[8].HeaderText = "PURCHUNIT";
   			dataGridView1.Columns[9].HeaderText = "deliveryDate";
   			dataGridView1.Columns[10].HeaderText = "receiveddate";
   			dataGridView1.Columns[11].HeaderText = "purchname";
   			dataGridView1.Columns[12].HeaderText = "invoiceaccount";
   			dataGridView1.Columns[13].HeaderText = "CREATEDBY";
   			
   			
		}
		
		void Button1Click(object sender, EventArgs e)
		{
			 SqlConnection connection2 = new SqlConnection(sqlconn3);
           // SqlDataAdapter dataadapter = new SqlDataAdapter(sql, connection2);
           // DataTable ds2 = new DataTable();
         	connection2.Open();
            //dataadapter.Fill(ds2);
            
            
		
            SqlDataAdapter da = new SqlDataAdapter("Select * from VIEW_AXERP_PO_ETD_LOCAL_CONVERTING Where deliveryDate >= '" +  date.Value.ToString("MM/dd/yyyy") + "' and deliveryDate <='" +  date.Value.ToString("MM/dd/yyyy") + "'",connection2);
			DataTable dt2 = new DataTable();
			da.Fill(dt2);
			dataGridView1.DataSource= dt2;
			dataGridView1.Refresh();
			connection2.Close();
   			
		}
		
		
		
			
			
			
			
			void datagrid2()
		{

			string sql = "SELECT * FROM VIEW_AXERP_GRN_LOCAL_CONVERTING";
            SqlConnection connection = new SqlConnection(sqlconn3);
            SqlDataAdapter dataadapter = new SqlDataAdapter(sql, connection);
            DataTable ds = new DataTable();
            connection.Open();
            dataadapter.Fill(ds);
                     
            DataTable tempDT = new DataTable();
  			tempDT = ds.DefaultView.ToTable(true,"ORIGPURCHID","ITEMID","name" ,"QTY" ,"PURCHUNIT"  ,"deliveryDate" ,"packingslipid");
   			dataGridView2.DataSource = tempDT;
   
  			connection.Close();

   			dataGridView2.Columns[0].HeaderText = "ORIGPURCHID";
  			dataGridView2.Columns[1].HeaderText = "ITEMID";
   			dataGridView2.Columns[2].HeaderText = "NAME";
   			dataGridView2.Columns[3].HeaderText = "QTY";
   			dataGridView2.Columns[4].HeaderText = "PURCHUNIT";
   			dataGridView2.Columns[5].HeaderText = "deliveryDate";
   			dataGridView2.Columns[6].HeaderText = "packingslipid";
   			
   			
		}
		
//		void Button1Click(object sender, EventArgs e)
//		{
//			 SqlConnection connection2 = new SqlConnection(sqlconn3);
//           // SqlDataAdapter dataadapter = new SqlDataAdapter(sql, connection2);
//           // DataTable ds2 = new DataTable();
//         	connection2.Open();
//            //dataadapter.Fill(ds2);
//            
//            
//		
//            SqlDataAdapter da = new SqlDataAdapter("Select * from VIEW_AXERP_PO_ETD_LOCAL_CONVERTING Where deliveryDate >= '" +  date.Value.ToString("MM/dd/yyyy") + "' and deliveryDate <='" +  date.Value.ToString("MM/dd/yyyy") + "'",connection2);
//			DataTable dt2 = new DataTable();
//			da.Fill(dt2);
//			dataGridView1.DataSource= dt2;
//			dataGridView1.Refresh();
//			connection2.Close();
//   			
//		}
		
		
		
		
		void Button2Click(object sender, EventArgs e)
		{
			
			
			SqlConnection con_data_add2 = new SqlConnection(sqlconn);
			System.Data.SqlClient.SqlCommand cmd_data_add2 = new SqlCommand();  //adress pergi ke sql
			try 
			{

				cmd_data_add2.Connection = con_data_add2;		//coman run store procedure
				cmd_data_add2.CommandText = "SP_AXERP_PO_LOCAL_CONV";	//nama store procedure
				cmd_data_add2.CommandType = CommandType.StoredProcedure;		//declare comand
    	
				cmd_data_add2.Parameters.Add(new SqlParameter("@SP_PURCHID", SqlDbType.NVarChar, 100)); //create parameter pada sql bwk data SP_RefNumber untuk dihantar semula
				cmd_data_add2.Parameters["@SP_PURCHID"].Value = txtxbx_search.Text.ToUpper();
					
				//@SP_PURCHID [nvarchar] (100)		
				con_data_add2.Open();
				cmd_data_add2.ExecuteNonQuery();
			}
				
			catch (Exception ex) 
			{
				con_data_add2.Close();
				MessageBox.Show("ERROR ? " + ex.Message + ex.ToString());
				return;
			} 
			finally 
			{
				con_data_add2.Close();
			}
			con_data_add2.Dispose();
			con_data_add2 = null;
			cmd_data_add2 = null;
			
			
			
			SqlConnection connection3 = new SqlConnection(sqlconn);
         	connection3.Open();
            
            
		
			SqlDataAdapter da = new SqlDataAdapter("Select * from RPT_AXERP_CONV_PO_LOCAL Where PURCHREQID like '%" +  txtxbx_search.Text + "'",connection3);
			DataTable dt3 = new DataTable();
			da.Fill(dt3);
			dataGridView1.DataSource= dt3;
			dataGridView1.Refresh();
			connection3.Close();
		}
		
		void Btn_pr2Click(object sender, EventArgs e)
		{
			SqlConnection connection4 = new SqlConnection(sqlconn3);
           // SqlDataAdapter dataadapter = new SqlDataAdapter(sql, connection3);
           // DataTable ds2 = new DataTable();
         	connection4.Open();
            //dataadapter.Fill(ds2);
            
            
		
			SqlDataAdapter da4 = new SqlDataAdapter("Select * from VIEW_AXERP_GRN_LOCAL_CONVERTING Where ORIGPURCHID like '%" +  txtbx_prno2.Text + "'",connection4);
			DataTable dt4 = new DataTable();
			da4.Fill(dt4);
			dataGridView2.DataSource= dt4;
			dataGridView2.Refresh();
			connection4.Close();
			
		}
		
		void Btn_date2Click(object sender, EventArgs e)
		{
			 SqlConnection connection5 = new SqlConnection(sqlconn3);
           // SqlDataAdapter dataadapter = new SqlDataAdapter(sql, connection2);
           // DataTable ds2 = new DataTable();
         	connection5.Open();
            //dataadapter.Fill(ds2);
            
            
		
            SqlDataAdapter da5 = new SqlDataAdapter("Select * from VIEW_AXERP_GRN_LOCAL_CONVERTING Where deliveryDate >= '" +  date2.Value.ToString("MM/dd/yyyy") + "' and deliveryDate <='" +  date2.Value.ToString("MM/dd/yyyy") + "'",connection5);
			DataTable dt5 = new DataTable();
			da5.Fill(dt5);
			dataGridView2.DataSource= dt5;
			dataGridView2.Refresh();
			connection5.Close();
		}
		
		
	}
}
