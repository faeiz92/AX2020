/*
 * Created by SharpDevelop.
 * User: ax2020-2
 * Date: 2/7/2017
 * Time: 1:49 PM
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
using Microsoft.Reporting.WinForms;
using Microsoft.ReportingServices;
namespace AX2020
{
	/// <summary>
	/// Description of frm_rpt_coating_output.
	/// </summary>
	public partial class frm_get_CI_NO_rpt : Form
	{
		frm_get_CI_NO f2 = new frm_get_CI_NO();
		
		public static string sqlconn = "Server=AX-UAT; Password=sbax2020sbg; User ID=sbax2020; Initial Catalog=SBG_AX_2020; Integrated Security=false";
		public static string Sqlconn1 = "DSN=eb9gf;Port=2138;Uid=dba;Pwd=sql";
		
		

		
			// The InitializeComponent() call is required for Windows Forms designer supp
		public frm_get_CI_NO_rpt( )
		{
			
			InitializeComponent();
			
			txtbx_CINO.Text = frm_get_CI_NO.SetValueForText1;
			
			MessageBox.Show(txtbx_CINO.Text);
			
			
				 //label1.Text = Form1.SetValueForText1;  

		}
		
 void report1()
	 {
	 			reportViewer1.Visible = true;
				
				

				reportViewer1.ProcessingMode = ProcessingMode.Local;
				reportViewer1.LocalReport.ReportPath = (@"..\..\report\RPT_CI_NO_LATEST.rdl");
				DataSet ds = new DataSet();
				ds = GetDate();
				
				
		if (ds.Tables[0].Rows.Count > 0)
		{
			reportViewer1.LocalReport.DataSources.Clear();
			ReportDataSource rds = new ReportDataSource("DataSet1",ds.Tables[0]);

			reportViewer1.LocalReport.DataSources.Clear();
			reportViewer1.LocalReport.DataSources.Add(rds);
			
			reportViewer1.LocalReport.Refresh();
			reportViewer1.RefreshReport();
		}
	 }
	 
	 
	 


private DataSet GetDate ()
{
	SqlConnection con_SP1 = new SqlConnection(sqlconn);
	SqlCommand cmd_SP1 = new SqlCommand();
	
	
	try
	{
			cmd_SP1.CommandText = cmd_SP1.CommandText = "select * from TBL_PROD_CI_NUMBER_TEMP where CI_NO =  '" + txtbx_CINO.Text + "'";
			cmd_SP1.Connection = con_SP1;
			con_SP1.Open();
			SqlDataReader rd_SP1 = cmd_SP1.ExecuteReader(System.Data.CommandBehavior.CloseConnection);

			rd_SP1.Close();

		
			SqlDataAdapter dataadapter = new SqlDataAdapter();
			dataadapter.SelectCommand = cmd_SP1;
			DataSet ds =new DataSet();
			
			dataadapter.Fill(ds);
			
			return (ds);
			

	}
	catch (Exception ex)
	{
		MessageBox.Show("Error -Production Output error!" + ex.Message + ex.ToString());
		return null;

	}
	
	finally
	{
		con_SP1.Close();	
	}
			con_SP1.Dispose();
			con_SP1 = null;
			cmd_SP1 = null;


}

		
		void Button1Click(object sender, EventArgs e)
		{
			this.Close();
		}
		

		
		void Btn_printClick(object sender, EventArgs e)
		{
			//this.pass_jo_no.PassValue(txtbx_jo_schwaner.Text.ToUpper());
       // this.Close();
	 	
	 	//reportViewer1.Visible = true;
	 	SqlConnection con_data_add = new SqlConnection(sqlconn);
		System.Data.SqlClient.SqlCommand cmd_data_add = new SqlCommand();
		cmd_data_add.CommandText = "SP_PROD_CI_NUMBER_TEMP";
		
		cmd_data_add.Parameters.Add(new SqlParameter("@SP_CI_NO", SqlDbType. NVarChar, 50)); //create parameter pada sql bwk data SP_RefNumber untuk dihantar semula
		cmd_data_add.Parameters["@SP_CI_NO"].Value = txtbx_CINO.Text.ToUpper();
		//MessageBox.Show("masuk x 2");
		
	 	report1();
			
		}
	}
}