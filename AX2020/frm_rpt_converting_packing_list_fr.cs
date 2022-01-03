using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using System.Collections.Generic; // For generic collections like List.
using System.Data.SqlClient;      // For the database connections and objects.
using System.Data.Sql;

namespace AX2020
{
	/// <summary>
	/// Description of frm_rpt_converting_packing_list_fr.
	/// </summary>
	public partial class frm_rpt_converting_packing_list_fr : Form
	{
		public static string sqlconn = "Server=AX-UAT; Password=sbax2020sbg; User ID=sbax2020; Initial Catalog=SBG_AX_2020; Integrated Security=false";
		public static string sqlconnstaging = "Server=AX-SQL; Password=ax2020sbgroup; User ID=ax2020sb; Initial Catalog=AX2020StagingDB; Integrated Security=false";
		//string date_fr, date_to;
		DateTime date_fr, date_to;
		string username;
		
		public frm_rpt_converting_packing_list_fr()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			this.ControlBox = false;
			username = frm_menu_system.userName; 
			lbl_username.Text = "User : " + username;
		}
		
		void Loop()
		{
			SqlConnection conProcessData1b = new SqlConnection(sqlconnstaging);
			SqlCommand cmdProcessData1b = new SqlCommand();
						
			try
			{
				cmdProcessData1b.CommandText = "select * from TBL_SALESPACKINGSLIPROWSTMP"; //VIEW_SFA_AX_DATA_R9
				cmdProcessData1b.Connection = conProcessData1b;
				conProcessData1b.Open();
							
				SqlDataReader rdProcessData1 = cmdProcessData1b.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
							
				if (rdProcessData1.HasRows)
				{
					while(rdProcessData1.Read())
					{
						int ship_mark = Convert.ToInt32(rdProcessData1["DOT_PRODATTRIBSHIPPINGMARK"].ToString());
						double gross_weight = Convert.ToDouble(rdProcessData1["DOT_PRODATTRIBGROSSWEIGHT"].ToString());
						double net_weight = Convert.ToDouble(rdProcessData1["DOT_PRODATTRIBNETWEIGHT"].ToString());					
					}
										
				}
			} 
			catch (Exception ex) 
			{
				MessageBox.Show("Error 2 : " + ex.Message + ex.ToString());
							
			} 
			finally 
			{
				conProcessData1b.Close();
			}
			conProcessData1b.Dispose();
			conProcessData1b = null;
			cmdProcessData1b = null;
			
		}
		
		void Insert()
		{
			SqlConnection conProcessData1b = new SqlConnection(sqlconnstaging);
			SqlCommand cmdProcessData1b = new SqlCommand();
						
			try
			{
				cmdProcessData1b.CommandText = "insert into TBL_SALESPACKINGSLIPROWSTMP_FR select * from TBL_SALESPACKINGSLIPROWSTMP"; //VIEW_SFA_AX_DATA_R9
				cmdProcessData1b.Connection = conProcessData1b;
				conProcessData1b.Open();
							
				SqlDataReader rdProcessData1 = cmdProcessData1b.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
							
				if (rdProcessData1.HasRows)
				{
					while(rdProcessData1.Read())
					{
						int ship_mark = Convert.ToInt32(rdProcessData1["DOT_PRODATTRIBSHIPPINGMARK"].ToString());
						double gross_weight = Convert.ToDouble(rdProcessData1["DOT_PRODATTRIBGROSSWEIGHT"].ToString());
						double net_weight = Convert.ToDouble(rdProcessData1["DOT_PRODATTRIBNETWEIGHT"].ToString());					
					}
										
				}
			} 
			catch (Exception ex) 
			{
				MessageBox.Show("Error 2 : " + ex.Message + ex.ToString());
							
			} 
			finally 
			{
				conProcessData1b.Close();
			}
			conProcessData1b.Dispose();
			conProcessData1b = null;
			cmdProcessData1b = null;
			
		}
		
		bool Report()
		{
			try
			{
				reportViewer1.Visible = true;
				reportViewer1.ProcessingMode = ProcessingMode.Local;
				reportViewer1.LocalReport.ReportPath = @"..\..\report\PROD_CONV_PACKING_FR.rdl";
				DataSet ds = new DataSet();
				ds = GetData();
				
				if (ds.Tables[0].Rows.Count > 0)
				{
					reportViewer1.LocalReport.DataSources.Clear();
					ReportDataSource rds = new ReportDataSource("DataSet1", ds.Tables[0]);
					ReportDataSource rds2 = new ReportDataSource("DataSet2", ds.Tables[0]);
					ReportDataSource rds3 = new ReportDataSource("DataSet3", ds.Tables[0]);
					reportViewer1.LocalReport.DataSources.Add(rds);
					reportViewer1.LocalReport.DataSources.Add(rds2);
					reportViewer1.LocalReport.DataSources.Add(rds3);
					reportViewer1.LocalReport.Refresh();
					reportViewer1.RefreshReport();
				}
				
				return true;
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message + ex.InnerException.Message + ex.InnerException.InnerException.Message);
				return false;
			}
		}
		
		
	
		
		private DataSet GetData()
		{
			SqlConnection conn = new SqlConnection(sqlconnstaging);
			
			SqlCommand cmd = new SqlCommand("SELECT * FROM VIEW_AXERP_SO_PACKING where salesid = @so", conn);
			cmd.Parameters.Add("@so", txtbx_so_no.Text.ToUpper());
			
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
				MessageBox.Show("Error - Converting Prod Fast \nCannot load DB" + ex.Message + ex.ToString());
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
		
		private DataSet GetData2()
		{
			SqlConnection conn = new SqlConnection(sqlconnstaging);
			
			SqlCommand cmd = new SqlCommand("select * from TBL_SALESPACKINGSLIPROWSTMP_FR", conn);
			
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
				MessageBox.Show("Error - Converting Prod Fast \nCannot load DB" + ex.Message + ex.ToString());
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
		
		private DataSet GetData3()
		{
			SqlConnection conn = new SqlConnection(sqlconnstaging);
			//SqlCommand cmd = new SqlCommand("SELECT PROD_DOCNO, PROD_LINE, PROD_DATE, PROD_SHIFT, PROD_CUSTOMER, PROD_TOTALROLL, PROD_QTYREJECT, PROD_CODE, PROD_BRAND, PROD_COLOR, PROD_MICRON, PROD_WIDTH, PROD_LENGTH FROM TBL_PROD_CONV_JO_SLITTING", conn);
			SqlCommand cmd = new SqlCommand("select * from VIEW_AXERP_SO where salesid = @so", conn);
			cmd.Parameters.Add("@so", txtbx_so_no.Text.ToUpper());
			
			try
			{
		        SqlDataAdapter dataadapter = new SqlDataAdapter(cmd);
		        conn.Open();
		        //dataadapter.SelectCommand = cmd;
		        DataSet ds2 = new DataSet();
		        dataadapter.Fill(ds2);
		        return (ds2);
		                     	        
			}
			catch(Exception ex)
			{
				MessageBox.Show("Error - Converting Prod Fast \nCannot load DB" + ex.Message + ex.ToString());
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
		
		void Btn_searchClick(object sender, EventArgs e)
		{
						
//			if(!sqlConnParm("SP_PROD_CONV_JO_QUICK_PROD"))
//				return;
//			else
//			{
				sqlConnParm("SP_SALESPACKINGSLIPROWSTMP_FR");
//				if(!Report())
//					return;
//			}			
		}
		
		void sqlConnParm(string cmd_update)
		{
			using (SqlConnection conn = new SqlConnection(sqlconnstaging))
			{
				conn.Open();
				SqlCommand cmd  = new SqlCommand(cmd_update, conn);
				cmd.CommandType = CommandType.StoredProcedure;
				
				//cmd.Parameters.Add(new SqlParameter("@SP_DATEFR", SqlDbType.NVarChar, 20));
				cmd.Parameters.Add(new SqlParameter("@SP_SALESID", SqlDbType.NVarChar, 50));
				cmd.Parameters["@SP_SALESID"].Value = txtbx_so_no.Text.ToUpper();
				
								        	
				cmd.ExecuteNonQuery();	

				try
				{
					reportViewer1.Visible = true;
					reportViewer1.ProcessingMode = ProcessingMode.Local;
					reportViewer1.LocalReport.ReportPath = @"..\..\report\PROD_CONV_PACKING_FR.rdl";
					DataSet ds = new DataSet();
					DataSet ds2 = new DataSet();
					DataSet ds3 = new DataSet();
					ds = GetData();
					ds2 = GetData2();
					ds3 = GetData3();
					
					if (ds.Tables[0].Rows.Count > 0)
					{
						reportViewer1.LocalReport.DataSources.Clear();
						ReportDataSource rds = new ReportDataSource("DataSet1", ds.Tables[0]);
						ReportDataSource rds2 = new ReportDataSource("DataSet2", ds2.Tables[0]);
						ReportDataSource rds3 = new ReportDataSource("DataSet3", ds3.Tables[0]);							
						reportViewer1.LocalReport.DataSources.Add(rds);
						reportViewer1.LocalReport.DataSources.Add(rds2);
						reportViewer1.LocalReport.DataSources.Add(rds3);
						reportViewer1.LocalReport.Refresh();
						reportViewer1.RefreshReport();
					}
					else
					{
						MessageBox.Show("Cannot find data");
					}					
				}
				catch(Exception ex)
				{
					MessageBox.Show(ex.Message + ex.InnerException.Message + ex.InnerException.InnerException.Message);
					//return false;
				}
			}
		}
		
		void Btn_cancelClick(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}