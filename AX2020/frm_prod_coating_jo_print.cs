/*
 * Created by SharpDevelop.
 * User: ax2020-2
 * Date: 2
 * Time: 11:58 AM
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

namespace AX2020
{
	/// <summary>
	/// Description of frm_prod_coating_jo_print.
	/// </summary>
	public partial class frm_prod_coating_jo_print : Form
	{
		
		public static string sqlconn = "Server=AX-UAT; Password=sbax2020sbg; User ID=sbax2020; Initial Catalog=SBG_AX_2020; Integrated Security=false";
		//string refnumber;
		
		public frm_prod_coating_jo_print()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		void Btn_searchClick(object sender, EventArgs e)
		{
			
			//txtbx_ref_no.Text = refnumber.Substring(0,10);
			
			if (txtbx_ref_no.Text == null | txtbx_ref_no.Text == string.Empty) 
			{
        		MessageBox.Show("Please key-in Ref No");
				return;
			}
			
			if(txtbx_ref_no.Text.Substring(0,1) == "J" || txtbx_ref_no.Text.Substring(0,1) == "j")
			{
			
			SqlConnection con_data_add2 = new SqlConnection(sqlconn);
			System.Data.SqlClient.SqlCommand cmd_data_add2 = new SqlCommand();  //adress pergi ke sql
			try 
			{

				cmd_data_add2.Connection = con_data_add2;		//coman run store procedure
				cmd_data_add2.CommandText = "SP_TEMP_PROD_COAT_JO_ADD_R2";	//nama store procedure
				cmd_data_add2.CommandType = CommandType.StoredProcedure;		//declare comand
    	
				cmd_data_add2.Parameters.Add(new SqlParameter("@SP_JODOCNO", SqlDbType.NVarChar, 50)); //create parameter pada sql bwk data SP_RefNumber untuk dihantar semula
				cmd_data_add2.Parameters["@SP_JODOCNO"].Value = txtbx_ref_no.Text.ToUpper();
						
						
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
			
			
			
			PrintReport();
			}
			
			else {
			
			
			SqlConnection con_data_add3 = new SqlConnection(sqlconn);
			System.Data.SqlClient.SqlCommand cmd_data_add3 = new SqlCommand();  //adress pergi ke sql
			try 
			{

				cmd_data_add3.Connection = con_data_add3;		//coman run store procedure
				cmd_data_add3.CommandText = "SP_TEMP_PROD_COAT_PRINTING_JOB_ORDER";	//nama store procedure
				cmd_data_add3.CommandType = CommandType.StoredProcedure;		//declare comand
    	
				cmd_data_add3.Parameters.Add(new SqlParameter("@SP_JODOCNO", SqlDbType.NVarChar, 50)); //create parameter pada sql bwk data SP_RefNumber untuk dihantar semula
				cmd_data_add3.Parameters["@SP_JODOCNO"].Value = txtbx_ref_no.Text.ToUpper();
						
						
				con_data_add3.Open();
				cmd_data_add3.ExecuteNonQuery();
			}
				
			catch (Exception ex) 
			{
				con_data_add3.Close();
				MessageBox.Show("ERROR ? " + ex.Message + ex.ToString());
				return;
			} 
			finally 
			{
				con_data_add3.Close();
			}
			con_data_add3.Dispose();
			con_data_add3 = null;
			cmd_data_add3 = null;
			
			PrintReport2();
			}
		}
		
		
		void PrintReport()
		{
		System.Windows.Forms.Form frm = new System.Windows.Forms.Form();
        frm.Height = 600;
        frm.Width = 800;

        fyiReporting.RdlViewer.RdlViewer rdlView = new fyiReporting.RdlViewer.RdlViewer();
        fyiReporting.RdlViewer.ViewerToolstrip report = new fyiReporting.RdlViewer.ViewerToolstrip(rdlView);
        Uri baseUri = new Uri(System.IO.Directory.GetCurrentDirectory());
        rdlView.SourceFile = new Uri(baseUri,@"../report/planning_jo_coating_R19.rdl");
        
        
        rdlView.Report.DataSets["Data"].SetSource("select * from TBL_TEMP_PROD_COAT_JO where JODOCNO = '" + txtbx_ref_no.Text + "'");
    
        rdlView.Rebuild();

        rdlView.Dock = DockStyle.Fill;
        frm.Controls.Add(rdlView);
        frm.Controls.Add(report);

        frm.ShowDialog(this);
		}
		
		
		void PrintReport2()
		{
		System.Windows.Forms.Form frm = new System.Windows.Forms.Form();
        frm.Height = 600;
        frm.Width = 800;

        fyiReporting.RdlViewer.RdlViewer rdlView = new fyiReporting.RdlViewer.RdlViewer();
        fyiReporting.RdlViewer.ViewerToolstrip report = new fyiReporting.RdlViewer.ViewerToolstrip(rdlView);
        Uri baseUri = new Uri(System.IO.Directory.GetCurrentDirectory());
        rdlView.SourceFile = new Uri(baseUri,@"../report/planning_jo_coating_printing_R12.rdl");
        
        
        rdlView.Report.DataSets["Data"].SetSource("select * from TBL_PROD_COAT_PRINTING_JOB_ORDER where JODOCNO = '" + txtbx_ref_no.Text + "'");
    
        rdlView.Rebuild();

        rdlView.Dock = DockStyle.Fill;
        frm.Controls.Add(rdlView);
        frm.Controls.Add(report);

        frm.ShowDialog(this);
		}
		
		
		void Button1Click(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}
