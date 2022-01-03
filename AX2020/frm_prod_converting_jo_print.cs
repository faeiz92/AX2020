/*
 * Created by SharpDevelop.
 * User: ax2020-1
 * Date: 1/23/2017
 * Time: 5:28 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic; // For generic collections like List.
using System.Data.SqlClient;      
using System.Data.Sql;
using System.Data.Sql;
using System.Data;
using CommonFunction;
using CommonLibrary;
using CommonControl.Functions;
using fyiReporting;
using fyiReporting.RdlViewer;

namespace AX2020
{
	
	public partial class frm_prod_converting_jo_print : Form
	{
		public static string sqlconn = "Server=AX-UAT; Password=sbax2020sbg; User ID=sbax2020; Initial Catalog=SBG_AX_2020; Integrated Security=false";
		string job_type;
		
		public frm_prod_converting_jo_print()
		{
			InitializeComponent();
			this.ControlBox = false;
			lbl_username.Text = "User : " + frm_menu_system.userName;
		}
		
		void TempTable()
		{
			using (SqlConnection conn = new SqlConnection(sqlconn))
			{
				conn.Open();
				
				SqlCommand cmd  = new SqlCommand("SP_PROD_CONV_JO_SLITTING_LIST", conn);
				cmd.CommandType = CommandType.StoredProcedure;
				
				cmd.Parameters.Add(new SqlParameter("@SP_JODOCNO", SqlDbType.NVarChar, 50));
				cmd.Parameters["@SP_JODOCNO"].Value = txtbx_ref_no.Text.ToUpper();

								   
				cmd.ExecuteNonQuery();
				//return true;					
			}				
		}
		
		public void Print()
		{		
			//try
			//{
			using(Form frm = new Form())
			{
				//Form frm = new Form();
	        	frm.Height = 700;
	        	frm.Width = 800;
	
	        	//fyiReporting.RdlViewer.RdlViewer rdlView = new fyiReporting.RdlViewer.RdlViewer();
	        	var rdlViewer1 = new fyiReporting.RdlViewer.RdlViewer();
				var reportStrip = new fyiReporting.RdlViewer.ViewerToolstrip(rdlViewer1);
	        	//rdlViewer1.SourceFile = new Uri(@"D:\C# Project\Converting\Converting\report\BOPPFilmLabel2.rdl");
	        	Uri baseUri = new Uri(System.IO.Directory.GetCurrentDirectory());
	        	
	        	if(job_type == "SLITTING")
	        	{
	        		rdlViewer1.SourceFile = new Uri(baseUri, @"../report/planning_jo_converting_7_r2.rdl");
	        	}
	        	else
	        	{
	        		rdlViewer1.SourceFile = new Uri(baseUri, @"../report/planning_jo_converting_9_r1.rdl");
	        	}
	        	//rdlView.Parameters += string.Format("&TestParam1={0}&TestParam2={1}", "Value 1", "Value 2");
	        	
	        	rdlViewer1.Report.DataSets["Data"].SetSource("select * from TBL_PROD_CONV_JO_SLITTING_LIST_TEMP where JODOCNO = '" + txtbx_ref_no.Text + "'");
	        	rdlViewer1.Rebuild();
	
	        	rdlViewer1.Dock = DockStyle.Fill;
	        	frm.Controls.Add(rdlViewer1);
	        	frm.Controls.Add(reportStrip);

        		frm.ShowDialog(this);
        	
			}
//			catch(Exception ex)
//			{
//				MessageBox.Show("Error - Converting JO \nCannot print" + ex.Message + ex.ToString());
//			}
		}
		
		void Btn_searchClick(object sender, EventArgs e)
		{
			if (txtbx_ref_no.Text == null | txtbx_ref_no.Text == string.Empty) 
			{
        		MessageBox.Show("Please key-in Jo No");
				return;
			}
			
			
			SqlConnection con_SP1 = new SqlConnection(sqlconn);
			SqlCommand cmd_SP1 = new SqlCommand();
			
			try 
			{
				cmd_SP1.CommandText = "select * from TBL_PROD_CONV_JO where JODOCNO = '" + txtbx_ref_no.Text + "'";
				cmd_SP1.Connection = con_SP1;
				con_SP1.Open();
				SqlDataReader rd_SP1 = cmd_SP1.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
				
				if(rd_SP1.HasRows)
				{
					while (rd_SP1.Read())
					{
						job_type = rd_SP1["JOPRODREMARK5"].ToString();
					}
					TempTable();
					Print();
				}
				else
				{
					MessageBox.Show("JO no does not exist");
				}
				
			}
			catch(Exception ex)
			{
				MessageBox.Show("Error - Converting Jo Print \nCannot load DB \n" + ex.Message + ex.ToString());
				
			}
			 
			finally
			{
				con_SP1.Close();	
			}
			
			con_SP1.Dispose();
			con_SP1 = null;
			cmd_SP1 = null;
								
		}
		
		void Btn_cancelClick(object sender, EventArgs e)
		{
			this.Close();
		}
		
		void Btn_clearClick(object sender, EventArgs e)
		{
			txtbx_ref_no.Clear();
		}
	}
}
