using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic; // For generic collections like List.
using System.Data.SqlClient;      // For the database connections and objects.
using System.Data.Sql;
using System.Data.Sql;
using System.Data;
using CommonFunction;
using CommonLibrary;
using CommonControl.Functions;
using System.Linq;

namespace AX2020
{
	public partial class frm_prod_ribbon : Form
	{
		public static string sqlconn = "Server=AX-UAT; Password=sbax2020sbg; User ID=sbax2020; Initial Catalog=SBG_AX_2020; Integrated Security=false";
		string ref_no = null, line_no = null;
		int NextNo = 0;
		string username, doc_no, prodc_stock_code, prodc_stock_desc;
		Double  prodc_qty;
		int i=0, rowCount=0;
		//DataGridView row;
	
		public frm_prod_ribbon()
		{
			InitializeComponent();
			this.ControlBox = false;
			
			username = frm_menu_system.userName; 
			lbl_username.Text = "User : " + username;
			
			DropDownList("SELECT * FROM TBL_PROD_CONV_JO_MACHINE_NO_LIST order by MACHINE_NO", cbx_machine, "MACHINE_NO");	
			DropDownList("SELECT * FROM TBL_PROD_CONV_JO_OUTPUT_SHIFT", cbx_shift, "SHIFT");
			DropDownList("SELECT sysstaffname FROM TBL_ADMIN_USER_FACTORY where sysdept = 'SLITTING' or sysdept = 'RCP' or sysdept = 'PAPER CORE' or sysdept = 'RIBBON'", cbx_operator, "sysstaffname");
			DropDownList("SELECT sysstaffname FROM TBL_ADMIN_USER_FACTORY where sysdept = 'SLITTING' or sysdept = 'RCP' or sysdept = 'PAPER CORE' or sysdept = 'RIBBON'", cbx_helper, "sysstaffname");
			//DataGrid();
			
			dt_grid_consume2.Hide();
			
			InitializeDataGridOutput();				
						
		}
		
		void Frm_prod_ribbonLoad(object sender, EventArgs e)
		{
			ClearAllText(this);
			DataGrid();
			btn_del.Visible = false;
		}
		
		void Txtbx_qtyKeyPress(object sender, KeyPressEventArgs e)
		{
		     if (!(Char.IsDigit(e.KeyChar) || (e.KeyChar == (char)Keys.Back)))
		     {
		          e.Handled = true;
		          MessageBox.Show("Key in number only");
		     }
		    
		}
		
		void InitializeDataGridOutput()
		{

			dt_grid_consume.ColumnCount = 4;
//			dt_grid_consume.Columns[0].Name = "No";
//            dt_grid_consume.Columns[0].Width = 35;
//            dt_grid_consume.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dt_grid_consume.Columns[0].Name = "Stock Code";
            dt_grid_consume.Columns[0].Width = 150;
            dt_grid_consume.Columns[1].Name = "Description";
			dt_grid_consume.Columns[1].Width = 350;            
			
			dt_grid_consume.Columns[2].Name = "UOM";
			dt_grid_consume.Columns[2].Width = 150;
            dt_grid_consume.Columns[3].Name = "Quantity";
			dt_grid_consume.Columns[3].Width = 150;
//			dt_grid_consume.RowCount = 10;
//			
//			for(int n=0; n<dt_grid_consume.Rows.Count; n++)
//			{
//				dt_grid_consume.Rows[n].Cells[0].Value = n+1;
//			}
		}
		
		void DataGrid()
		{
			SqlConnection con_SP = new SqlConnection(sqlconn);
			SqlCommand cmd_SP = new SqlCommand();
				
			try 
			{
				cmd_SP.CommandText = @"SELECT PROD_DATE, PROD_SHIFT, PROD_DOCNO, PROD_STOCKCODE, PROD_STOCKDESC, PROD_QTY, PROD_UOM FROM TBL_PROD_RIBBON_OUTPUT ORDER BY PROD_REPORTDATE DESC";
				cmd_SP.Connection = con_SP;
				con_SP.Open();
				SqlDataAdapter dataadapter = new SqlDataAdapter(cmd_SP);	
								 
			    //DataSet ds = new DataSet();
			    DataTable ds = new DataTable();
			    dataadapter.Fill(ds);
				 
  				this.dt_grid.DataSource = AutoNumberedTable(ds);

			}
			catch(Exception ex)
			{
				MessageBox.Show("Error" + ex.Message + ex.ToString());
				return;
			}
			finally
			{
				con_SP.Close();
				dt_grid.Columns[0].Name = "No";
	            dt_grid.Columns[0].Width = 35;
	            dt_grid.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
	            dt_grid.Columns[1].HeaderText = "Date";
	            dt_grid.Columns[1].Width = 110;
	            dt_grid.Columns[2].HeaderText = "Shift";
	            dt_grid.Columns[2].Width = 80;
	            dt_grid.Columns[3].HeaderText = "Ref No";
	            dt_grid.Columns[3].Width = 150;
	            dt_grid.Columns[4].HeaderText = "Stock Code";
	            dt_grid.Columns[4].Width = 150;
	            dt_grid.Columns[5].HeaderText = "Description";
				dt_grid.Columns[5].Width = 200;            
				dt_grid.Columns[6].HeaderText = "Quantity";
				dt_grid.Columns[6].Width = 100;
	            dt_grid.Columns[7].HeaderText = "UOM"; 
					
			}
			
			con_SP.Dispose();
			con_SP = null;
			cmd_SP = null;	
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
		
		void Btn_clearClick(object sender, EventArgs e)
		{
			InitializeAll();
		}
		
		void InitializeAll()
		{
			ClearAllText(this);
			dt_grid_consume.Columns.Clear();
			dt_grid_consume.Visible = true;
			dt_grid_consume2.Columns.Clear();
			dt_grid_consume2.Hide();
			InitializeDataGridOutput();
			DataGrid();
			btn_save.Visible = true;
			btn_add.Visible = true;
		}
		
		void ClearAllText(Control con)
		{
    		foreach (Control c in con.Controls)
    		{
      			if (c is TextBox)
        			((TextBox)c).Clear();
      			else
      				ClearAllText(c);
      			
      			if(c is ComboBox)
                ((ComboBox)c).Text = "Please Select";
//                if(c is ComboBox)
//                	((ComboBox)c).Items.Clear(); 

				if(c is DateTimePicker)
				{
					((DateTimePicker)c).Value = DateTime.Now;
				}  
   			}
		}
		
		void Btn_cancelClick(object sender, EventArgs e)
		{
//			DialogResult cancel = new DialogResult();
//            cancel = MessageBox.Show("Do you want to cancel?", "Cancel", 
//                     MessageBoxButtons.YesNo, 
//                     MessageBoxIcon.Warning, 
//                     MessageBoxDefaultButton.Button2);
//            if (cancel == DialogResult.Yes)
//            {
//            	ClearAllText(this);
                //Application.Exit();
                this.Close();
            //}    
		}
		
		private void DropDownList(string cmd, ComboBox cbx_text, string col_name)
		{
		    SqlConnection conn = new SqlConnection(sqlconn);
            DataSet ds = new DataSet();
            string cmdSQL = cmd;
            SqlDataAdapter sda = new SqlDataAdapter(cmdSQL, conn);

            try
            {
                conn.Open();
                sda.Fill(ds);
                cbx_text.Text = "Please Select";
            }
            catch(SqlException se)
            {
            	MessageBox.Show("Error Ribbon \nCannot load ComboBox DB \n" + se.ToString() + se.Message);
            }
            finally
            {
                conn.Close();
            }
			
           	foreach(DataRow dr1 in ds.Tables[0].Rows)
           	{
               cbx_text.Items.Add(dr1[col_name].ToString());
           	}

		}

		//>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
		
		private bool Validation()
        {
                  
               if (CommonValidation.ValidateIsEmptyString(cbx_machine.Text.Trim()) || cbx_machine.Text == "Please Select")
               {
                    DialogBox.ShowWarningMessage(lbl_machine_no.Text + " cannot be empty.");
                   	cbx_machine.Focus();
                   	
                    return false;     
               }
              
               else if (CommonValidation.ValidateIsEmptyString(cbx_shift.Text.Trim()) || cbx_shift.Text == "Please Select")
               {
                    DialogBox.ShowWarningMessage(lbl_shift.Text + " cannot be empty.");
                    cbx_shift.Focus();
                   	
                    return false;       
               }
               
               else if (CommonValidation.ValidateIsEmptyString(txtbx_stock_code.Text.Trim()) || txtbx_stock_code.Text == "Please Select")
               {
                    DialogBox.ShowWarningMessage(lbl_stock_code.Text + " cannot be empty.");
                    txtbx_stock_code.Focus();
                   	
                    return false;       
               }
                
               else if (CommonValidation.ValidateIsEmptyString(txtbx_qty.Text.Trim()) || txtbx_qty.Text == "Please Select")
               {
                    DialogBox.ShowWarningMessage(lbl_qty.Text + " cannot be empty.");
                    txtbx_qty.Focus();
                   	
                    return false;       
               }
               
               else if (CommonValidation.ValidateIsEmptyString(txtbx_oum.Text.Trim()) || txtbx_oum.Text == "Please Select")
               {
                    DialogBox.ShowWarningMessage(lbl_uom.Text + " cannot be empty.");
                    txtbx_oum.Focus();
                   	
                    return false;       
               }


               return true;
        }
		
		
		void Btn_saveClick(object sender, EventArgs e)
		{
			if (!Validation())
                return;
			
			for(i=0; i< dt_grid_consume.Rows.Count;i++)
			{
				if (dt_grid_consume.Rows[i].Cells[3].Value != null)
				{
					rowCount = rowCount + 1;
				}
				else
				{
					MessageBox.Show("Quantity in Consume section cannot be empty");
					dt_grid_consume.Rows[i].Cells[3].Selected = true;
					return;
				}
			
			}
			
			if (LineNoGenerator())
			{
				if (sqlConnParmOutput("SP_PROD_RIBBON_OUTPUT_ADD"))
				{
					for(i=0; i<rowCount; i++)
					{
						prodc_stock_code = dt_grid_consume.Rows[i].Cells[0].Value.ToString().ToUpper();
						prodc_stock_desc = dt_grid_consume.Rows[i].Cells[1].Value.ToString().ToUpper();
						prodc_qty = Convert.ToDouble(dt_grid_consume.Rows[i].Cells[3].Value.ToString());
						if(!sqlConnParmConsume("SP_PROD_RIBBON_CONSUME_ADD"))
							return;
					}
				}
				//MessageBox.Show("Keyin successfully, Record is saved" + Environment.NewLine +"အောင်မြင်စွာ ထိုအခါ စံချိန်သိမ်းဆည်း ");
				frm_messageBox msg = new frm_messageBox();
				msg.Show();
				InitializeAll();
				//PrintReport();
			}
			
		}
		
		
//		void PrintReport()
//		{
//		System.Windows.Forms.Form frm = new System.Windows.Forms.Form();
//        frm.Height = 600;
//        frm.Width = 800;
//
//        fyiReporting.RdlViewer.RdlViewer rdlView = new fyiReporting.RdlViewer.RdlViewer();
//        fyiReporting.RdlViewer.ViewerToolstrip report = new fyiReporting.RdlViewer.ViewerToolstrip(rdlView);
//        Uri baseUri = new Uri(System.IO.Directory.GetCurrentDirectory());
//        rdlView.SourceFile = new Uri(baseUri,@"../report/prod_output_ribbon.rdl");
//        
//        
//        rdlView.Report.DataSets["Data"].SetSource("select * from TBL_PROD_RIBBON_CONSUME where PRODC_DOCNO = '" + txtbx_ref_no.Text + "'");
//        rdlView.Report.DataSets["Data2"].SetSource("select * from TBL_PROD_RIBBON_OUTPUT where PRODC_DOCNO = '" + txtbx_ref_no.Text + "'");
//    
//        rdlView.Rebuild();
//
//        rdlView.Dock = DockStyle.Fill;
//        frm.Controls.Add(rdlView);
//        frm.Controls.Add(report);
//
//        frm.ShowDialog(this);
//		}
		
		private bool LineNoGenerator()
		{
			
			SqlConnection conNextNumber = new SqlConnection(sqlconn);
			SqlCommand cmdNextNumber = new SqlCommand();
			
			try 
			{
				cmdNextNumber.CommandText = "Select ProdRibbonNextNumber from TBL_ADMIN_NEXT_NUMBER";
				cmdNextNumber.Connection = conNextNumber;

				conNextNumber.Open();
				SqlDataReader rdNextNumber = cmdNextNumber.ExecuteReader(System.Data.CommandBehavior.CloseConnection);

				rdNextNumber.Read();
				NextNo = Convert.ToInt32(rdNextNumber["ProdRibbonNextNumber"]);
				
			
			} 
			catch (Exception ex) 
			{
				MessageBox.Show("Error Ribbon \nCannot get next number \n" + ex.Message + ex.ToString());
				return false;
			} 
			finally 
			{
				conNextNumber.Close();
				
			}
			
			conNextNumber.Dispose();
			conNextNumber = null;
			cmdNextNumber = null;
			
			
			SqlConnection conUpdate = new SqlConnection(sqlconn);
			SqlCommand cmdUpdateNextNumber = new SqlCommand();

			try
			{
				cmdUpdateNextNumber.CommandText = "update TBL_ADMIN_NEXT_NUMBER set ProdRibbonNextNumber = ProdRibbonNextNumber + 1";
				
				cmdUpdateNextNumber.Connection = conUpdate;

				conUpdate.Open();
				cmdUpdateNextNumber.ExecuteNonQuery();

			}
			catch (Exception ex)
			{
				conUpdate.Close();
				MessageBox.Show("Error Ribbon \nCannot update next number \n" + ex.Message + ex.ToString());
				return false;
			}
			finally 
			{
				conUpdate.Close();
			}

			conUpdate.Dispose();
			conUpdate = null;
			cmdUpdateNextNumber = null;
			txtbx_ref_no.Text = NextNo.ToString();
			return true;			
		}
		
		bool sqlConnParmOutput(string sqlStatement)
		{
			SqlConnection con_data = new SqlConnection(sqlconn);
			SqlCommand cmd_data = new SqlCommand();
			
			try
			{
				cmd_data.Connection = con_data;
				cmd_data.CommandText = sqlStatement;
				cmd_data.CommandType = CommandType.StoredProcedure;

				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_DOCNO", SqlDbType.NVarChar, 50));
				cmd_data.Parameters["@SP_PROD_DOCNO"].Value = txtbx_ref_no.Text;
					
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_REPORTDATE", SqlDbType.DateTime));
				cmd_data.Parameters["@SP_PROD_REPORTDATE"].Value = dtp_date.Value;

				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_BATCHNO", SqlDbType.NVarChar, 50));
				cmd_data.Parameters["@SP_PROD_BATCHNO"].Value = txtbx_batch_no.Text.ToUpper();
							
						
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_MACHINE", SqlDbType.NVarChar, 50));
				cmd_data.Parameters["@SP_PROD_MACHINE"].Value = cbx_machine.Text;
					
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_MACHINESPEED", SqlDbType.Float));
				cmd_data.Parameters["@SP_PROD_MACHINESPEED"].Value = Double.Parse("0");
						
					
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_OPERATOR", SqlDbType.NVarChar, 50));
				cmd_data.Parameters["@SP_PROD_OPERATOR"].Value = cbx_operator.Text;
					
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_HELPER", SqlDbType.NVarChar, 50));
				cmd_data.Parameters["@SP_PROD_HELPER"].Value = cbx_helper.Text;
					
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_SUPERVISOR", SqlDbType.NVarChar, 50));
				cmd_data.Parameters["@SP_PROD_SUPERVISOR"].Value = cbx_helper.Text;
					
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_SHIFT", SqlDbType.NVarChar, 50));
				cmd_data.Parameters["@SP_PROD_SHIFT"].Value = cbx_shift.Text;	
					
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_DATE", SqlDbType.DateTime));
				cmd_data.Parameters["@SP_PROD_DATE"].Value = dtp_date.Value;
								
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_STOCKCODE", SqlDbType.NVarChar, 50));
				cmd_data.Parameters["@SP_PROD_STOCKCODE"].Value = txtbx_stock_code.Text.ToUpper();
					
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_STOCKDESC", SqlDbType.NVarChar, 50));
				cmd_data.Parameters["@SP_PROD_STOCKDESC"].Value = txtbx_desc.Text.ToUpper();
					
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_QTY", SqlDbType.Float));
				cmd_data.Parameters["@SP_PROD_QTY"].Value = Double.Parse(txtbx_qty.Text);
				
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_UOM", SqlDbType.NVarChar, 50));
				cmd_data.Parameters["@SP_PROD_UOM"].Value = txtbx_oum.Text.ToUpper();	
				
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_QTYREJECT", SqlDbType.Float));
				cmd_data.Parameters["@SP_PROD_QTYREJECT"].Value = 0;
					
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_TOTALROLL", SqlDbType.Float));
				cmd_data.Parameters["@SP_PROD_TOTALROLL"].Value = 0;
					
					
					
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_REMARK1", SqlDbType.NVarChar, 50));
				cmd_data.Parameters["@SP_PROD_REMARK1"].Value = cbx_helper.Text.ToUpper();
					
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_REMARK2", SqlDbType.NVarChar, 50));
				cmd_data.Parameters["@SP_PROD_REMARK2"].Value = cbx_shift.Text.ToUpper();	
				
				
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_FLAG1", SqlDbType.NVarChar, 2));
				cmd_data.Parameters["@SP_PROD_FLAG1"].Value = "N";
					
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_FLAG2", SqlDbType.NVarChar, 2));
				cmd_data.Parameters["@SP_PROD_FLAG2"].Value = "0";
					
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_FLAG3", SqlDbType.NVarChar, 2));
				cmd_data.Parameters["@SP_PROD_FLAG3"].Value = "0";
					
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_FLAG4", SqlDbType.NVarChar, 2));
				cmd_data.Parameters["@SP_PROD_FLAG4"].Value = "0";
					
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_FLAG5", SqlDbType.NVarChar, 2));
				cmd_data.Parameters["@SP_PROD_FLAG5"].Value = "0";
					
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_FLAG6", SqlDbType.NVarChar, 2));
				cmd_data.Parameters["@SP_PROD_FLAG6"].Value = "0";
					
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_FLAG7", SqlDbType.NVarChar, 2));
				cmd_data.Parameters["@SP_PROD_FLAG7"].Value = "0";
					
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_FLAG8", SqlDbType.NVarChar, 2));
				cmd_data.Parameters["@SP_PROD_FLAG8"].Value = "0";
					
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_FLAGStatus", SqlDbType.NVarChar, 2));
				cmd_data.Parameters["@SP_PROD_FLAGStatus"].Value = "0";

										
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_ISSUEBY", SqlDbType.NVarChar, 50));
				cmd_data.Parameters["@SP_PROD_ISSUEBY"].Value = username;
					
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_USER", SqlDbType.NVarChar, 50));
				cmd_data.Parameters["@SP_PROD_USER"].Value = username;
					
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_USEREMAIL", SqlDbType.NVarChar, 50));
				cmd_data.Parameters["@SP_PROD_USEREMAIL"].Value = frm_menu_system.email;
					
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_USERPC", SqlDbType.NVarChar, 50));
				cmd_data.Parameters["@SP_PROD_USERPC"].Value = frm_menu_system.ipAddress;
					
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_USERDATETIME", SqlDbType.DateTime));
				cmd_data.Parameters["@SP_PROD_USERDATETIME"].Value = DateTime.Now;
					
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_USERREVISION", SqlDbType.NVarChar, 50));
				cmd_data.Parameters["@SP_PROD_USERREVISION"].Value = "0";

				con_data.Open();
				cmd_data.ExecuteNonQuery();				
					
			} 
			catch (Exception ex) 
			{	
				con_data.Close();
				MessageBox.Show("Error Ribbon \nCannot save Output in DB \n" + ex.Message + ex.ToString());			
				return false;
			} 
			finally 
			{	
				con_data.Close();	
			}
			
			con_data.Dispose();
			con_data = null;
			cmd_data = null;
			return true;	
		}
		
		public bool sqlConnParmConsume(string sqlStatement)
		{
			SqlConnection con_data_consume = new SqlConnection(sqlconn);
			SqlCommand cmd_data_consume = new SqlCommand();
			
			try
			{
				cmd_data_consume.Connection = con_data_consume;
				cmd_data_consume.CommandText = sqlStatement;
				cmd_data_consume.CommandType = CommandType.StoredProcedure;

				cmd_data_consume.Parameters.Add(new SqlParameter("@SP_PRODC_DOCNO", SqlDbType.NVarChar, 50));
				cmd_data_consume.Parameters["@SP_PRODC_DOCNO"].Value = txtbx_ref_no.Text + "C";
					
				cmd_data_consume.Parameters.Add(new SqlParameter("@SP_PRODC_REPORTDATE", SqlDbType.DateTime));
				cmd_data_consume.Parameters["@SP_PRODC_REPORTDATE"].Value = dtp_date.Value;

				cmd_data_consume.Parameters.Add(new SqlParameter("@SP_PRODC_BATCHNO", SqlDbType.NVarChar, 50));
				cmd_data_consume.Parameters["@SP_PRODC_BATCHNO"].Value = txtbx_batch_no.Text.ToUpper();
					
						
					
				cmd_data_consume.Parameters.Add(new SqlParameter("@SP_PRODC_MACHINE", SqlDbType.NVarChar, 50));
				cmd_data_consume.Parameters["@SP_PRODC_MACHINE"].Value = cbx_machine.Text.ToUpper();
					
				cmd_data_consume.Parameters.Add(new SqlParameter("@SP_PRODC_MACHINESPEED", SqlDbType.Float));
				cmd_data_consume.Parameters["@SP_PRODC_MACHINESPEED"].Value = Double.Parse("0");
						
					
				cmd_data_consume.Parameters.Add(new SqlParameter("@SP_PRODC_OPERATOR", SqlDbType.NVarChar, 50));
				cmd_data_consume.Parameters["@SP_PRODC_OPERATOR"].Value = cbx_operator.Text.ToUpper();
					
				cmd_data_consume.Parameters.Add(new SqlParameter("@SP_PRODC_HELPER", SqlDbType.NVarChar, 50));
				cmd_data_consume.Parameters["@SP_PRODC_HELPER"].Value = cbx_helper.Text.ToUpper();
					
				cmd_data_consume.Parameters.Add(new SqlParameter("@SP_PRODC_SUPERVISOR", SqlDbType.NVarChar, 50));
				cmd_data_consume.Parameters["@SP_PRODC_SUPERVISOR"].Value = cbx_helper.Text.ToUpper();
					
				cmd_data_consume.Parameters.Add(new SqlParameter("@SP_PRODC_SHIFT", SqlDbType.NVarChar, 50));
				cmd_data_consume.Parameters["@SP_PRODC_SHIFT"].Value = cbx_shift.Text.ToUpper();	
					
				cmd_data_consume.Parameters.Add(new SqlParameter("@SP_PRODC_DATE", SqlDbType.DateTime));
				cmd_data_consume.Parameters["@SP_PRODC_DATE"].Value = dtp_date.Value;
				
				//--------------------------------------------------------------------------------------------------------------
				
				cmd_data_consume.Parameters.Add(new SqlParameter("@SP_PRODC_STOCKCODE", SqlDbType.NVarChar, 50));
				//cmd_data_consume.Parameters["@SP_PRODC_STOCKCODE"].Value = dt_grid_consume.Rows[i].Cells[1].Value.ToString().ToUpper();
				cmd_data_consume.Parameters["@SP_PRODC_STOCKCODE"].Value = prodc_stock_code;
					
				cmd_data_consume.Parameters.Add(new SqlParameter("@SP_PRODC_STOCKDESC", SqlDbType.NVarChar, 50));
				//cmd_data_consume.Parameters["@SP_PRODC_STOCKDESC"].Value = dt_grid_consume.Rows[i].Cells[2].Value.ToString().ToUpper();
				cmd_data_consume.Parameters["@SP_PRODC_STOCKDESC"].Value = prodc_stock_desc;
				
				cmd_data_consume.Parameters.Add(new SqlParameter("@SP_PRODC_QTY", SqlDbType.Float));
				cmd_data_consume.Parameters["@SP_PRODC_QTY"].Value = prodc_qty;
				//cmd_data_consume.Parameters["@SP_PRODC_QTY"].Value = Convert.ToDouble(dt_grid_consume.Rows[i].Cells[3].Value);
				
				//-----------------------------------------------------------------------------------------------------------------
				
				cmd_data_consume.Parameters.Add(new SqlParameter("@SP_PRODC_UOM", SqlDbType.NVarChar, 50));
				cmd_data_consume.Parameters["@SP_PRODC_UOM"].Value = txtbx_oum.Text.ToUpper();	
					
					
				cmd_data_consume.Parameters.Add(new SqlParameter("@SP_PRODC_QTYREJECT", SqlDbType.Float));
				cmd_data_consume.Parameters["@SP_PRODC_QTYREJECT"].Value = Convert.ToDouble("0");
					
				cmd_data_consume.Parameters.Add(new SqlParameter("@SP_PRODC_TOTALROLL", SqlDbType.Float));
				cmd_data_consume.Parameters["@SP_PRODC_TOTALROLL"].Value = Convert.ToDouble("0");
					
					
					
				cmd_data_consume.Parameters.Add(new SqlParameter("@SP_PRODC_REMARK1", SqlDbType.NVarChar, 50));
				cmd_data_consume.Parameters["@SP_PRODC_REMARK1"].Value = cbx_helper.Text.ToUpper();
					
				cmd_data_consume.Parameters.Add(new SqlParameter("@SP_PRODC_REMARK2", SqlDbType.NVarChar, 50));
				cmd_data_consume.Parameters["@SP_PRODC_REMARK2"].Value = cbx_shift.Text.ToUpper();	
					
 				//-----------------------------------------------------------------------------------------
 				
// 				cmd_data_consume.Parameters.Add(new SqlParameter("@SP_PRODC_FLAG1", SqlDbType.NVarChar, 2));
//				cmd_data_consume.Parameters["@SP_PRODC_ISSUEBY"].Value = lbl_date.Text.ToUpper();
//					
//				cmd_data_consume.Parameters.Add(new SqlParameter("@SP_PRODC_FLAG2", SqlDbType.NVarChar, 2));
//				cmd_data_consume.Parameters["@SP_PRODC_USER"].Value = lbl_date.Text.ToUpper();
//				
//				cmd_data_consume.Parameters.Add(new SqlParameter("@SP_PRODC_FLAG3", SqlDbType.NVarChar,2));
//				cmd_data_consume.Parameters["@SP_PRODC_ISSUEBY"].Value = lbl_date.Text.ToUpper();
//					
//				cmd_data_consume.Parameters.Add(new SqlParameter("@SP_PRODC_FLAG4", SqlDbType.NVarChar, 2));
//				cmd_data_consume.Parameters["@SP_PRODC_USER"].Value = lbl_date.Text.ToUpper();
//				
//				cmd_data_consume.Parameters.Add(new SqlParameter("@SP_PRODC_FLAG5", SqlDbType.NVarChar, 2));
//				cmd_data_consume.Parameters["@SP_PRODC_ISSUEBY"].Value = lbl_date.Text.ToUpper();
//					
//				cmd_data_consume.Parameters.Add(new SqlParameter("@SP_PRODC_FLAG6", SqlDbType.NVarChar, 2));
//				cmd_data_consume.Parameters["@SP_PRODC_USER"].Value = lbl_date.Text.ToUpper();
//				
//				cmd_data_consume.Parameters.Add(new SqlParameter("@SP_PRODC_FLAG7", SqlDbType.NVarChar, 2));
//				cmd_data_consume.Parameters["@SP_PRODC_ISSUEBY"].Value = lbl_date.Text.ToUpper();
//					
//				cmd_data_consume.Parameters.Add(new SqlParameter("@SP_PRODC_FLAG8", SqlDbType.NVarChar, 2));
//				cmd_data_consume.Parameters["@SP_PRODC_USER"].Value = lbl_date.Text.ToUpper();
//				
//				cmd_data_consume.Parameters.Add(new SqlParameter("@SP_PRODC_FLAGStatus", SqlDbType.NVarChar, 2));
//				cmd_data_consume.Parameters["@SP_PRODC_USER"].Value = lbl_date.Text.ToUpper();
				
				//-----------------------------------------------------------------------------------------------
										
				cmd_data_consume.Parameters.Add(new SqlParameter("@SP_PRODC_ISSUEBY", SqlDbType.NVarChar, 50));
				cmd_data_consume.Parameters["@SP_PRODC_ISSUEBY"].Value = username;
					
				cmd_data_consume.Parameters.Add(new SqlParameter("@SP_PRODC_USER", SqlDbType.NVarChar, 50));
				cmd_data_consume.Parameters["@SP_PRODC_USER"].Value = username;
					
				cmd_data_consume.Parameters.Add(new SqlParameter("@SP_PRODC_USEREMAIL", SqlDbType.NVarChar, 50));
				cmd_data_consume.Parameters["@SP_PRODC_USEREMAIL"].Value = frm_menu_system.email;
					
				cmd_data_consume.Parameters.Add(new SqlParameter("@SP_PRODC_USERPC", SqlDbType.NVarChar, 50));
				cmd_data_consume.Parameters["@SP_PRODC_USERPC"].Value = frm_menu_system.ipAddress;
					
				cmd_data_consume.Parameters.Add(new SqlParameter("@SP_PRODC_USERDATETIME", SqlDbType.DateTime));
				cmd_data_consume.Parameters["@SP_PRODC_USERDATETIME"].Value = DateTime.Now;
					
				cmd_data_consume.Parameters.Add(new SqlParameter("@SP_PRODC_USERREVISION", SqlDbType.NVarChar, 50));
				cmd_data_consume.Parameters["@SP_PRODC_USERREVISION"].Value = "0";

				con_data_consume.Open();
				cmd_data_consume.ExecuteNonQuery();		
		
			}
			catch (Exception ex) 
			{	
				con_data_consume.Close();
				MessageBox.Show("Error Ribbon \nCannot save Consume in DB \n" + ex.Message + ex.ToString());			
				return false;
			} 
			finally 
			{
				con_data_consume.Close();
			}
			
			con_data_consume.Dispose();
			con_data_consume = null;
			cmd_data_consume = null;

			return true;
		}
		
		
		void Btn_delClick(object sender, EventArgs e)
		{
			
			DialogResult del = new DialogResult();
            del = MessageBox.Show("Are you sure you want to delete it?", "Delete", 
                     MessageBoxButtons.YesNo, 
                     MessageBoxIcon.Warning, 
                     MessageBoxDefaultButton.Button2);
            
			if (del == DialogResult.Yes)
            {

				if (this.dt_grid.SelectedRows.Count > 0)
			    {
					if (sqlConnParmOutput("SP_PROD_RIBBON_OUTPUT_DEL"))
					{
						for(i=0; i< dt_grid_consume2.Rows.Count;i++)
						{
							prodc_stock_code = dt_grid_consume2.Rows[i].Cells[1].Value.ToString().ToUpper();
							prodc_stock_desc = dt_grid_consume2.Rows[i].Cells[2].Value.ToString().ToUpper();
							prodc_qty = Convert.ToDouble(dt_grid_consume2.Rows[i].Cells[3].Value.ToString());
							if(!sqlConnParmConsume("SP_PROD_RIBBON_CONSUME_DEL"))
								return;
						}
						
						dt_grid.Rows.RemoveAt(this.dt_grid.SelectedRows[0].Index);
						DialogBox.ShowDeleteSuccessDialog();
						InitializeAll();
					}
							
				}
			    	  	
			}
            
		}
		
		void Dt_gridCellClick(object sender, DataGridViewCellEventArgs e)
		{
			if(dt_grid.SelectedRows.Count > 0) // make sure user select at least 1 row 
			{
			   	doc_no = dt_grid.SelectedRows[0].Cells[3].Value + string.Empty;
			   	txtbx_ref_no.Text = doc_no;
			   	
			   	dt_grid_consume2.Visible = true;
			   	btn_add.Visible = false;
			   	Retrieve(); 
				btn_del.Visible = true;			   	
			}
 
		}
			
//		void Btn_retrieveClick(object sender, EventArgs e)
		void Retrieve()
		{
			SqlConnection con_SP1 = new SqlConnection(sqlconn);
			SqlCommand cmd_SP1 = new SqlCommand();
				
			try 
			{
				cmd_SP1.CommandText = @"SELECT * FROM TBL_PROD_RIBBON_OUTPUT where PROD_DOCNO = @doc_no";
				cmd_SP1.Parameters.AddWithValue("@doc_no",  doc_no);
				cmd_SP1.Connection = con_SP1;
				con_SP1.Open();
				SqlDataReader rd_SP1 = cmd_SP1.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
					
				if (rd_SP1.Read())
				{				        	
					txtbx_batch_no.Text = rd_SP1["PROD_BATCHNO"].ToString();
					cbx_machine.Text = rd_SP1["PROD_MACHINE"].ToString();
					cbx_shift.Text = rd_SP1["PROD_SHIFT"].ToString();
					cbx_operator.Text = rd_SP1["PROD_OPERATOR"].ToString();
					cbx_helper.Text = rd_SP1["PROD_HELPER"].ToString();
					cbx_supervisor.Text = rd_SP1["PROD_SUPERVISOR"].ToString();
					dtp_date.Value = Convert.ToDateTime(rd_SP1["PROD_DATE"]);
					txtbx_stock_code.Text = rd_SP1["PROD_STOCKCODE"].ToString();
					txtbx_desc.Text = rd_SP1["PROD_STOCKDESC"].ToString();
					txtbx_qty.Text = rd_SP1["PROD_QTY"].ToString();
					txtbx_oum.Text = rd_SP1["PROD_UOM"].ToString();
				} 
				else 
				{
					MessageBox.Show("Error : Cannot find JO!");
					return;
				}
			} 
			catch (Exception ex) 
			{
				MessageBox.Show("Error : Cannot load DB!" + ex.Message + ex.ToString());
				return;
			} 
			finally 
			{
				con_SP1.Close();
			}
				
			con_SP1.Dispose();
			con_SP1 = null;
			cmd_SP1 = null;		
			
			//--------------------------------------------------------------------------
			
			SqlConnection con_SP2 = new SqlConnection(sqlconn);
			SqlCommand cmd_SP2 = new SqlCommand();
				
			try 
			{
				dt_grid_consume.Columns.Clear();
				dt_grid_consume.Hide();
		        
				cmd_SP2.CommandText = @"SELECT PRODC_STOCKCODE, PRODC_STOCKDESC, PRODC_QTY, PRODC_UOM FROM TBL_PROD_RIBBON_CONSUME where SUBSTRING(PRODC_DOCNO,1,3) = @doc_no";
				cmd_SP2.Parameters.AddWithValue("@doc_no",  doc_no);
				cmd_SP2.Connection = con_SP2;
				con_SP2.Open();
				SqlDataAdapter dataadapter = new SqlDataAdapter(cmd_SP2);	
								 
			    //DataSet ds = new DataSet();
			    DataTable ds = new DataTable();
			    dataadapter.Fill(ds);
			    //dt_grid_consume2.DataSource = ds;
			    this.dt_grid_consume2.DataSource = AutoNumberedTable(ds); 
		
			} 
			catch (Exception ex) 
			{
				MessageBox.Show("Error : Cannot load DB!" + ex.Message + ex.ToString());
				return;
			} 
			finally 
			{
				con_SP2.Close();
				dt_grid_consume2.Columns[0].Name = "No";
	            dt_grid_consume2.Columns[0].Width = 35;
	            dt_grid_consume2.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
	            dt_grid_consume2.Columns[1].HeaderText = "Stock Code";
	            dt_grid_consume2.Columns[1].Width = 150;
	            dt_grid_consume2.Columns[2].HeaderText = "Description";
				dt_grid_consume2.Columns[2].Width = 500;            
				dt_grid_consume2.Columns[3].HeaderText = "Quantity";
				dt_grid_consume2.Columns[3].Width = 150;
	            dt_grid_consume2.Columns[4].HeaderText = "UOM"; 
			}
				
			con_SP2.Dispose();
			con_SP2 = null;
			cmd_SP2 = null;	
			btn_save.Visible = false;
			
         }
		
		
		void Dt_gridDataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
		{
			dt_grid.ClearSelection();
		}
		
		void Dt_grid_consumeDataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
		{
			dt_grid_consume.ClearSelection();
		}
		
		void Dt_grid_consume2DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
		{
			dt_grid_consume2.ClearSelection();
		}
			
		
		void Btn_addClick(object sender, EventArgs e)
		{
			//string prod_code_add, prod_desc_add, prod_uom_add;
			if (dt_grid_consume.Rows.Count < 10)
			{
				    
				using(frm_prod_ribbon_popup frm_popup_ribbon =  new frm_prod_ribbon_popup())
				{
					frm_popup_ribbon.ShowDialog();
					
					string prod_code_add = frm_prod_ribbon_popup.prod_code;
					string prod_desc_add = frm_prod_ribbon_popup.prod_desc;
					string prod_uom_add = frm_prod_ribbon_popup.prod_uom;
					
					if (!string.IsNullOrWhiteSpace(prod_code_add))
					{
						dt_grid_consume.Rows.Add(prod_code_add, prod_desc_add, prod_uom_add);

						if (! dt_grid_consume.Columns.Contains("dataGridViewDeleteButton"))
						{
							var deleteButton = new DataGridViewButtonColumn();
							deleteButton.Name="dataGridViewDeleteButton";
							deleteButton.HeaderText="";
							deleteButton.Text="X";
							deleteButton.CellTemplate.Style.ForeColor = Color.Red;
							deleteButton.CellTemplate.Style.Font = new Font("Arial", 12, FontStyle.Bold);
							//deleteButton.CellTemplate.Style.Font
							deleteButton.UseColumnTextForButtonValue=true;
							this.dt_grid_consume.Columns.Add(deleteButton);
							this.dt_grid_consume.Columns[4].Width = 20;
						}
				
					}
					
				}
				
			}
			else
				MessageBox.Show("Cannot add more rows");
		}
		
		void Dt_grid_consumeCellClick(object sender, DataGridViewCellEventArgs e)
		{
			//if click is on new row or header row
		    if( e.RowIndex == dt_grid_consume.NewRowIndex || e.RowIndex < 0)
		        return;
		
		    //Check if click is on specific column 
		    if(e.ColumnIndex  == dt_grid_consume.Columns["dataGridViewDeleteButton"].Index)
		    {
		        //Put some logic here, for example to remove row from your binding list.
		        dt_grid_consume.Rows.RemoveAt(e.RowIndex);
		    }
		    
		    

//		    
		    
		    
		}
		
		
	}
}
