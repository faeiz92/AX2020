﻿/*
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
	/// Description of frm_production_output.
	/// </summary>
	public partial class frm_rpt_po_listing : Form
	{
		public static string sqlconn = "Server=AX-UAT; Password=sbax2020sbg; User ID=sbax2020; Initial Catalog=SBG_AX_2020; Integrated Security=false";
		public static string Sqlconn1 = "DSN=eb9gf;Port=2138;Uid=dba;Pwd=sql";
		DateTime date_fr, date_to;
		//string date_fr, date_to;
		
			// The InitializeComponent() call is required for Windows Forms designer supp
		public frm_rpt_po_listing()
		{
			//ort.
			//
			InitializeComponent();
			//numbershift();
			this.ControlBox = false;
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		
		
		private DataSet GetData(string cmd_string)
		{
			SqlConnection conn = new SqlConnection(sqlconn);
			
			SqlCommand cmd = new SqlCommand(cmd_string, conn);	//(@"select TrxMacID, COUNT(TrxLotNo) as JR_QTY_OUTPUT ,count (TrxJoWidth) as JO_WIDTH,sum(TrxTotalLength) as TOTAL_M, sum((trxjowidth/1000)* TrxTotalLength) as TOTAL_M2 from TBL_PROD_COATING_OUTPUT_CALC_DATA group by TrxMacID ", conn);
			try
			{
		        SqlDataAdapter dataadapter = new SqlDataAdapter(cmd);
		        conn.Open();
		        //dataadapter.SelectCommand = cmd;
		        DataSet ds = new DataSet();
		        dataadapter.Fill(ds);
		        return (ds);
		                     	        
			}
			catch(Exception ex)
			{
				MessageBox.Show("Error - Coating Prod Fast \nCannot load DB" + ex.Message + ex.ToString());
				return null;
			}
			finally
			{
				conn.Close();
				cmd = null;
				conn.Dispose();
				conn = null;
			}
			
		}
		
	 
	 
	 
	 bool sqlConnParm(string cmd_update)
		{
			using (SqlConnection conn = new SqlConnection(sqlconn))
			{
							
				conn.Open();
				SqlCommand cmd  = new SqlCommand(cmd_update, conn);
				cmd.CommandType = CommandType.StoredProcedure;
				
				//cmd.Parameters.Add(new SqlParameter("@SP_DATEFR", SqlDbType.NVarChar, 20));
				cmd.Parameters.Add(new SqlParameter("@SP_DATEFR", SqlDbType.DateTime));
				cmd.Parameters["@SP_DATEFR"].Value = date_fr;
					
				//cmd.Parameters.Add(new SqlParameter("@SP_DATETO", SqlDbType.NVarChar, 20));
				cmd.Parameters.Add(new SqlParameter("@SP_DATETO", SqlDbType.DateTime));
				cmd.Parameters["@SP_DATETO"].Value = date_to;
								        
				
				cmd.ExecuteNonQuery();	

				try
				{
					
					reportViewer1.Visible = true;
					reportViewer1.ProcessingMode = ProcessingMode.Local;
					reportViewer1.LocalReport.ReportPath = @"..\..\report\po_listing.rdl";
					DataSet ds = new DataSet();
					DataSet ds2 = new DataSet();
					DataSet ds3 = new DataSet();
					DataSet ds4 = new DataSet();
					DataSet ds5 = new DataSet();
					
					ds = GetData(@"select * from VIEW_RPT_PO_LISTING");
					
					//ds2 = GetData2();
					
					if (ds.Tables[0].Rows.Count > 0)
					{
						reportViewer1.LocalReport.DataSources.Clear();
						ReportDataSource rds = new ReportDataSource("DataSet1",ds.Tables[0]);
						
						
						ReportParameter[] parameters = new ReportParameter[2];
						
						reportViewer1.LocalReport.DataSources.Clear();
						reportViewer1.LocalReport.DataSources.Add(rds);

						reportViewer1.LocalReport.Refresh();
						reportViewer1.RefreshReport();
					}				
				}
				catch(Exception ex)
				{
					MessageBox.Show(ex.Message + ex.InnerException.Message + ex.InnerException.InnerException.Message);
					return false;
				}
				
			}
			return true;
		}


	
		
		void Btn_generateClick(object sender, EventArgs e)
		{
			
			//date_fr = date_from.Value.Date;
			//date_to = date_to.Value.Date.AddDays(1).AddSeconds(-1);
	 	
	 		date_fr = date_from.Value.Date;
			date_to = date_too.Value.Date.AddDays(1).AddSeconds(-1);
			
			//date_to = DateTime.Today;
			

			if(!sqlConnParm("SP_AX2020_RPT_PO_LISTING"))
				return;
	 		 	
	
		}
		
		
		void Button1Click(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}