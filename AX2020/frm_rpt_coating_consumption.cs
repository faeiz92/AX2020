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
	/// Description of frm_production_output.
	/// </summary>
	public partial class frm_rpt_coating_consumption : Form
	{
		//public static string sqlconn = "Server=WIN7-PC\\SBGROUP; Password=ax2020sb; User ID=ax2020sb; Initial Catalog=MyProductionTrack; Integrated Security=false";
			public static string sqlconn = "Server=AX-UAT; Password=sbax2020sbg; User ID=sbax2020; Initial Catalog=MyProductionTrack; Integrated Security=false";

		public static string Sqlconn = "DSN=eb9gf;Port=2138;Uid=dba;Pwd=sql";
		DateTime date_fr, date_to;
		//string date_fr, date_to;
		
		
			// The InitializeComponent() call is required for Windows Forms designer supp
		public frm_rpt_coating_consumption()
		{
			//ort.
			//
			InitializeComponent();
			numbershift();
			comboBox1.Text = "Please Select";
			this.ControlBox = false;
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		
		
		private DataSet GetData(string cmd_string)
		{
			SqlConnection conn = new SqlConnection(sqlconn);
			
			SqlCommand cmd = new SqlCommand(cmd_string, conn);	//(@"select TrxMacID, COUNT(TrxLotNo) as JR_QTY_OUTPUT ,count (TrxJoWidth) as JO_WIDTH,sum(TrxTotalLength) as TOTAL_M, sum((trxjowidth/1000)* TrxTotalLength) as TOTAL_M2 from TBL_PROD_COATING_OUTPUT_CALC_DATA group by TrxMacID ", conn);
			cmd.Parameters.AddWithValue("@machine", Convert.ToString(comboBox1.Text));
			
			
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
		
		
		
		
		private DataSet GetData2(string cmd_string)
		{
			SqlConnection conn = new SqlConnection(sqlconn);
			
			SqlCommand cmd = new SqlCommand(cmd_string, conn);	//(@"select TrxMacID, COUNT(TrxLotNo) as JR_QTY_OUTPUT ,count (TrxJoWidth) as JO_WIDTH,sum(TrxTotalLength) as TOTAL_M, sum((trxjowidth/1000)* TrxTotalLength) as TOTAL_M2 from TBL_PROD_COATING_OUTPUT_CALC_DATA group by TrxMacID ", conn);
			//cmd.Parameters.AddWithValue("@datefrom", date_fr);
			//cmd.Parameters.AddWithValue("@dateto", date_to);
			//cmd.Parameters.AddWithValue("@machine", comboBox1.SelectedValue);
			
			
			
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
				MessageBox.Show("Error - Coating Prod Consumption \nCannot load DB" + ex.Message + ex.ToString());
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
				
				cmd.Parameters.Add(new SqlParameter("@SP_MACHINE", SqlDbType.NVarChar, 5));
				cmd.Parameters["@SP_MACHINE"].Value = comboBox1.SelectedValue;
								        
				
				cmd.ExecuteNonQuery();	

				try
				{
					
					reportViewer1.Visible = true;
					reportViewer1.ProcessingMode = ProcessingMode.Local;
					reportViewer1.LocalReport.ReportPath = @"..\..\report\Production_Consumption_Latest.rdl";
					DataSet ds = new DataSet();
					DataSet ds2 = new DataSet();
					DataSet ds3 = new DataSet();
					DataSet ds4 = new DataSet();
					DataSet ds5 = new DataSet();
					
					if (comboBox1.SelectedIndex == -1 || comboBox1.Text == "Please Select")
					{
					
					ds = GetData2(@"select * FROM VIEW_AX2020_COATING_OUTPUT_FILM where TrxProductID !='80' ");
					ds2 = GetData2(@"SELECT * from VIEW_AX2020_COATING_OUTPUT_BOPPF");
					ds3= GetData2(@"SELECT   * from VIEW_AX2020_COATING_OUTPUT_GLUE");
					ds4 = GetData2(@"SELECT * FROM VIEW_AX2020_COATING_OUTPUT_BOPPF2");
					ds5 = GetData2(@"SELECt *  FROM VIEW_AX2020_DETAIL_JR_OPP_GLUE_ONLY"); 
					}
					
					else 
					{
					
					ds = GetData(@"select * FROM VIEW_AX2020_COATING_OUTPUT_FILM where TrxMacID = @machine");
					ds2 = GetData(@"SELECT * from VIEW_AX2020_COATING_OUTPUT_BOPPF where TrxMacID = @machine");
					ds3= GetData(@"SELECT   * from VIEW_AX2020_COATING_OUTPUT_GLUE where TrxMacID = @machine");
					ds4 = GetData(@"SELECT * FROM VIEW_AX2020_COATING_OUTPUT_BOPPF2 where TrxMacID = @machine");
					ds5 = GetData(@"SELECt *  FROM VIEW_AX2020_DETAIL_JR_OPP_GLUE_ONLY where TrxMacID = @machine");
					}
					
					if (ds.Tables[0].Rows.Count > 0)
					{
						reportViewer1.LocalReport.DataSources.Clear();
						ReportDataSource rds = new ReportDataSource("DataSet1",ds.Tables[0]);
						ReportDataSource rds2 = new ReportDataSource("DataSet2",ds2.Tables[0]);
						ReportDataSource rds3 = new ReportDataSource("DataSet3",ds3.Tables[0]);
						ReportDataSource rds4 = new ReportDataSource("DataSet4",ds4.Tables[0]);
						ReportDataSource rds5 = new ReportDataSource("DataSet5",ds5.Tables[0]);
						
						ReportParameter[] parameters = new ReportParameter[2];
						
						reportViewer1.LocalReport.DataSources.Clear();
						reportViewer1.LocalReport.DataSources.Add(rds);
						reportViewer1.LocalReport.DataSources.Add(rds2);
						reportViewer1.LocalReport.DataSources.Add(rds3);
						reportViewer1.LocalReport.DataSources.Add(rds4);
						reportViewer1.LocalReport.DataSources.Add(rds5);			
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


		public void numbershift()
		{
			string sqlStatement = "SELECT MacID FROM MAC_MTN where MacID <>'TEST' AND MacID <>'TEST2' AND MacID <>'PR1' AND MacID <>'SCO1'";
			SqlConnection sqlConn = new SqlConnection(sqlconn);
			DataSet ds = new DataSet();
			SqlDataAdapter sda = new SqlDataAdapter(sqlStatement, sqlConn);
					
			try 
			{
						
				sqlConn.Open();
				sda.Fill(ds);
				comboBox1.Text = "Please Select";
					
			}
						

			
		
			catch (Exception ex) 
			{
					DialogBox.ShowWarningMessage("An error occured while connecting to database" + ex.Message + ex.ToString());
					sqlConn.Close();
					sqlConn.Dispose();
					return;
			} 
			finally 
			{
					sqlConn.Close();
					sqlConn.Dispose();
			}
		
			foreach(DataRow dr1 in ds.Tables[0].Rows)
			{
				comboBox1.Items.Add(dr1["MacID"].ToString());
			}
				
	}
		
		void Btn_generateClick(object sender, EventArgs e)
		{
			
			
	 	
	 		date_fr = date_from.Value.Date;
			date_to = date_too.Value.Date.AddDays(1).AddSeconds(-1);
			
			
			
			if (comboBox1.Text == "Please Select")
			{
				comboBox1.SelectedIndex = -1;
			}
			
		
			
			if(!sqlConnParm("SP_AX2020_PRODUCTION_CONSUMPTION2"))
				return;
			
	
		}
		
		
		
		void Button1Click(object sender, EventArgs e)
		{
			this.Close();
		}
		
		
		
	
	}
}