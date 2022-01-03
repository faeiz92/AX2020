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
	public partial class frm_prod_coating_double_side_r2 : Form
	{
		public static string sqlconn = "Server=AX-UAT; Password=sbax2020sbg; User ID=sbax2020; Initial Catalog=SBG_AX_2020; Integrated Security=false";
		string ref_no = null, line_no = null;
		string shift_time;
		int NextNo = 0;
		string username, doc_no, prodc_stock_code, prodc_stock_desc, prodc_stock_uom;
		Double  prodc_qty;
		int i=0, rowCount=0;
		//DataGridView row;
		string shippingmark, stockcodeshipmark;
		public static string SetValueForText1 = "";
		public static string set_stockcode = "" ;
		public static string set_dt_consume;
		double wet_weight =0, ttl_weight_glue=0;	
		double fin_qty=0;
	
		
		public frm_prod_coating_double_side_r2()
		{
			InitializeComponent();
		
			txtbx_batch_no.Text = Convert.ToString(0);
			this.ControlBox = false;
			PRODUCT_CODE_OPTION();
			
			username = frm_menu_system.userName; 
			lbl_username.Text = "User : " + username;
			
			DropDownList("SELECT * FROM TBL_PROD_COAT_DOUBLESIDE_MACHINENAME", cbx_machine, "MACHINE_NAME");	
			DropDownList("SELECT * FROM TBL_PROD_DOUBLE_SIDE_OUTPUT_SHIFT", cbx_shift, "SHIFT2");
			DropDownList("SELECT * FROM TBL_PROD_COAT_DOUBLESIDE_OPERATORNAME", cbx_operator, "OPERATOR_NAME");
			DropDownList("SELECT * FROM TBL_PROD_COAT_DOUBLESIDE_HELPERNAME", cbx_helper, "HELPER_NAME");
			DropDownList("SELECT * FROM TBL_PROD_COAT_DOUBLESIDE_SUPERVISORNAME", cbx_supervisor, "SUPERVISOR_NAME");
			
			//DataGrid();
			
			dt_grid_consume2.Hide();
			
			InitializeDataGridOutput();
		
		}
		
		void Frm_prod_glueLoad(object sender, EventArgs e)
		{
			ClearAllText(this);
			DataGrid();
			//btn_del.Visible = false;
			txtbx_oum.Text = "KG";
			txtbx_batch_no.Text = "-";
			txtbx_desc.Enabled = true;
			
			if(username.ToUpper() == "ADMIN")
			{
				btn_del.Enabled = true;
			}
			else
			{
				;//btn_del.Enabled = false;
			}
			
		}
		
		private void Txtbx_qtyKeyPress(object sender, KeyPressEventArgs e)
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
			
			
			if (dt_grid_consume.Rows.Count == 1)
			
			{
				
			}
            
//			Code	LotNo	Customer	S.Mark	Color	Micron	Width	Length
	
		}
		
		
		private DataTable AutoNumberedTable2(DataTable SourceTable)
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
		
		void DataGrid()
		{
			SqlConnection con_SP = new SqlConnection(sqlconn);
			SqlCommand cmd_SP = new SqlCommand();
				
			try 
			{
				cmd_SP.CommandText = @"SELECT PROD_DATE, PROD_SHIFT, PROD_DOCNO, PROD_STOCKCODE, PROD_STOCKDESC, PROD_UOM FROM TBL_PROD_DOUBLE_SIDE_OUTPUT where PROD_REPORTDATE>= DATEADD(day,-7, getdate()) ORDER BY PROD_REPORTDATE DESC";
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
	            dt_grid.Columns[6].HeaderText = "UOM"; 
					
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
			txtbx_batch_no.Text = "-";
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
                this.Close();   
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
            	MessageBox.Show("Error Glue \nCannot load ComboBox DB \n" + se.ToString() + se.Message);
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
		
		
		void Txtbx_stock_codeSelectedIndexChanged(object sender, EventArgs e)
		{
			txtbx_desc.Items.Clear();
			SqlConnection con = new SqlConnection(sqlconn);
			string sqlStatement = "select PROD_DESC  from TBL_DOUBLESIDE_PRODUCTCODE where ITEM_ID = '" + txtbx_stock_code.Text.ToString() +"'";
			SqlCommand cmd = new SqlCommand( sqlStatement,con);
			SqlDataReader dbr;
			try
			{
				con.Open();
				dbr = cmd.ExecuteReader();
				while(dbr.Read())
				{
					txtbx_desc.Text = (string) dbr["PROD_DESC"].ToString();
				}
								
			}
			
			catch(Exception es)
			{
				MessageBox.Show("Error" + es.Message + es.ToString());
			}				
				
		}


		
		
		
		
		public void PRODUCT_CODE_OPTION()	
		{
			string sqlStatement = "select ITEM_ID  from TBL_DOUBLESIDE_PRODUCTCODE";
			SqlConnection sqlConn = new SqlConnection(sqlconn);
			DataSet ds = new DataSet();
			SqlDataAdapter sda = new SqlDataAdapter(sqlStatement, sqlConn);
					
			try 
			{		
				sqlConn.Open();
				sda.Fill(ds);
				txtbx_stock_code.Text = "Please Select";
						
			}
			catch (Exception exc) 
			{
				DialogBox.ShowWarningMessage("An error occured while connecting to database" + exc.Message+ exc.ToString());
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
				txtbx_stock_code.Items.Add(dr1["ITEM_ID"].ToString());
			}
				
		}
		
		
//		public void PRODUCT_CODE_DESC_OPTION()
//		{
//			string sqlStatement = "select * from TBL_PRODUCT_CODE_GLUE_DESCRIPTION where PRODUCT_CODE_DESC like '" + txtbx_stock_code.Text.ToString() + "%'";
//			SqlConnection sqlConn = new SqlConnection(sqlconn);
//			DataSet ds = new DataSet();
//			SqlDataAdapter sda = new SqlDataAdapter(sqlStatement, sqlConn);
//					
//			try 
//			{		
//				sqlConn.Open();
//				sda.Fill(ds);
//			txtbx_desc.Text = "Please Select";
//						
//			}
//			catch (Exception exc) 
//			{
//				DialogBox.ShowWarningMessage("An error occured while connecting to database" + exc.Message+ exc.ToString());
//				sqlConn.Close();
//				sqlConn.Dispose();
//				return;
//			} 
//			finally 
//			{
//				sqlConn.Close();
//				sqlConn.Dispose();
//			}
//		
//			foreach(DataRow dr1 in ds.Tables[0].Rows)
//			{
//				txtbx_desc.Items.AddRange(dr1["PRODUCT_CODE_DESC"].ToString());
//			}
//				
//		}

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
                
//               else if (CommonValidation.ValidateIsEmptyString(txtbx_qty.Text.Trim()) || txtbx_qty.Text == "Please Select")
//               {
//                    DialogBox.ShowWarningMessage(lbl_qty.Text + " cannot be empty.");
//                    txtbx_qty.Focus();
//                   	
//                    return false;       
//               }
               
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
			
			if(cbx_shift.Text == "SHIFT2-8AM to 8PM")
			{
				 shift_time = "2I";
				 MessageBox.Show(shift_time.ToString());
			}
			
			else if(cbx_shift.Text == "SHIFT1-8PM to 8AM")
			{
				shift_time = "1I";
				MessageBox.Show(shift_time.ToString());
			}
			
			//Dt_grid_consumeCellClick(this);
			if (!Validation())
                return;
			
	
			
			for(i= 0; i< dt_grid_consume.RowCount;i++)
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
				NextNumberRetrieve();
				if (sqlConnParmOutput("SP_PROD_DOUBLE_SIDE_OUTPUT_ADD"))
				{
					
					for(i=0; i<dt_grid_consume.RowCount; i++)
					{
						prodc_stock_code = dt_grid_consume.Rows[i].Cells[0].Value.ToString().ToUpper();
						prodc_stock_desc = dt_grid_consume.Rows[i].Cells[1].Value.ToString().ToUpper();
						//prodc_stock_uom = dt_grid_consume.Rows[i].Cells[2].Value.ToString().ToUpper();
						prodc_qty = Convert.ToDouble(dt_grid_consume.Rows[i].Cells[3].Value.ToString());
						if(!sqlConnParmConsume("SP_PROD_DOUBLE_SIDE_CONSUME_ADD"))
							return;
					}
					

					frm_messageBox msg = new frm_messageBox();
					msg.Show();
					//MessageBox.Show("Keyin successfully, Record is saved" + Environment.NewLine +"အောင်မြင်စွာ ထိုအခါ စံချိန်သိမ်းဆည်း ");
					InitializeAll();
					//PrintReport();
				}
				
				MessageBox.Show(shippingmark);
				frm_prod_coating_double_side_print obj_doubleside = new frm_prod_coating_double_side_print();
				obj_doubleside.ShowDialog();
				SetValueForText1 = shippingmark;
			}
			
			//PrintReport();
			
			
			
			
			
		}
		
		
		
		
		private bool LineNoGenerator()
		{
			
			SqlConnection conNextNumber = new SqlConnection(sqlconn);
			SqlCommand cmdNextNumber = new SqlCommand();
			
			try 
			{
				cmdNextNumber.CommandText = "Select ProdDoubleSideNextNumber from TBL_ADMIN_NEXT_NUMBER";
				cmdNextNumber.Connection = conNextNumber;

				conNextNumber.Open();
				SqlDataReader rdNextNumber = cmdNextNumber.ExecuteReader(System.Data.CommandBehavior.CloseConnection);

				rdNextNumber.Read();
				NextNo = Convert.ToInt32(rdNextNumber["ProdDoubleSideNextNumber"]);
				
			
			} 
			catch (Exception ex) 
			{
				MessageBox.Show("Error Glue \nCannot get next number \n" + ex.Message + ex.ToString());
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
				cmdUpdateNextNumber.CommandText = "update TBL_ADMIN_NEXT_NUMBER set ProdDoubleSideNextNumber = ProdDoubleSideNextNumber + 1";
				
				cmdUpdateNextNumber.Connection = conUpdate;

				conUpdate.Open();
				cmdUpdateNextNumber.ExecuteNonQuery();

			}
			catch (Exception ex)
			{
				conUpdate.Close();
				MessageBox.Show("Error Glue \nCannot update next number \n" + ex.Message + ex.ToString());
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
				cmd_data.Parameters["@SP_PROD_SUPERVISOR"].Value = "-";
					
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_SHIFT", SqlDbType.NVarChar, 50));
				cmd_data.Parameters["@SP_PROD_SHIFT"].Value = cbx_shift.Text;	
					
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_DATE", SqlDbType.DateTime));
				cmd_data.Parameters["@SP_PROD_DATE"].Value = dtp_date.Value;
								
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_STOCKCODE", SqlDbType.NVarChar, 50));
				cmd_data.Parameters["@SP_PROD_STOCKCODE"].Value = txtbx_stock_code.SelectedItem.ToString();
					
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_STOCKDESC", SqlDbType.NVarChar, 50));
				cmd_data.Parameters["@SP_PROD_STOCKDESC"].Value = txtbx_desc.Text;
					
				//cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_QTY", SqlDbType.Float));
				//cmd_data.Parameters["@SP_PROD_QTY"].Value = Double.Parse(txtbx_qty.Text);
				
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_UOM", SqlDbType.NVarChar, 50));
				cmd_data.Parameters["@SP_PROD_UOM"].Value = txtbx_oum.Text.ToUpper();	
				
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_QTYREJECT", SqlDbType.Float));
				cmd_data.Parameters["@SP_PROD_QTYREJECT"].Value = 0;
				
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_FLAG_WAREHOUSE", SqlDbType.NVarChar, 2));
				cmd_data.Parameters["@SP_PROD_FLAG_WAREHOUSE"].Value = "N";
				
							
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
				
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_REMARK1", SqlDbType. NVarChar, 50)); //create parameter pada sql bwk data SP_RefNumber untuk dihantar semula
				cmd_data.Parameters["@SP_PROD_REMARK1"].Value = "0";

				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_REMARK2", SqlDbType. NVarChar, 50)); //create parameter pada sql bwk data SP_RefNumber untuk dihantar semula
				cmd_data.Parameters["@SP_PROD_REMARK2"].Value = 0;
				
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_LENGTH", SqlDbType. Float)); //create parameter pada sql bwk data SP_RefNumber untuk dihantar semula
				cmd_data.Parameters["@SP_PROD_LENGTH"].Value = Convert.ToDouble(txtbx_length.Text);
				
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_WIDTH", SqlDbType. Float)); //create parameter pada sql bwk data SP_RefNumber untuk dihantar semula
				cmd_data.Parameters["@SP_PROD_WIDTH"].Value = Convert.ToDouble(txtbx_width.Text);
				
				
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_DOUBLESIDE_SHIPMARK", SqlDbType.NVarChar, 50)); //create parameter pada sql bwk data SP_RefNumber untuk dihantar semula
				cmd_data.Parameters["@SP_PROD_DOUBLESIDE_SHIPMARK"].Value = shippingmark; 
						
				con_data.Open();
				cmd_data.ExecuteNonQuery();				
					
			} 
			catch (Exception ex) 
			{	
				con_data.Close();
				MessageBox.Show("Error Glue \nCannot save Output in DB \n" + ex.Message + ex.ToString());			
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
				cmd_data_consume.Parameters["@SP_PRODC_SUPERVISOR"].Value = "-";
					
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
					
				
					
					
					
				cmd_data_consume.Parameters.Add(new SqlParameter("@SP_PRODC_REMARK1", SqlDbType.NVarChar, 50));
				cmd_data_consume.Parameters["@SP_PRODC_REMARK1"].Value = txtbx_stock_code.Text.ToUpper();
					
				cmd_data_consume.Parameters.Add(new SqlParameter("@SP_PRODC_REMARK2", SqlDbType.NVarChar, 50));
				cmd_data_consume.Parameters["@SP_PRODC_REMARK2"].Value = txtbx_desc.Text;
					
 				//-----------------------------------------------------------------------------------------
 				cmd_data_consume.Parameters.Add(new SqlParameter("@SP_PRODC_FLAG_WAREHOUSE", SqlDbType.NVarChar, 2));
				cmd_data_consume.Parameters["@SP_PRODC_FLAG_WAREHOUSE"].Value = "N";
 				
				cmd_data_consume.Parameters.Add(new SqlParameter("@SP_PRODC_FLAG1", SqlDbType.NVarChar, 2));
				cmd_data_consume.Parameters["@SP_PRODC_FLAG1"].Value = "N";
					
				cmd_data_consume.Parameters.Add(new SqlParameter("@SP_PRODC_FLAG2", SqlDbType.NVarChar, 2));
				cmd_data_consume.Parameters["@SP_PRODC_FLAG2"].Value = "0";
					
				cmd_data_consume.Parameters.Add(new SqlParameter("@SP_PRODC_FLAG3", SqlDbType.NVarChar, 2));
				cmd_data_consume.Parameters["@SP_PRODC_FLAG3"].Value = "0";
					
				cmd_data_consume.Parameters.Add(new SqlParameter("@SP_PRODC_FLAG4", SqlDbType.NVarChar, 2));
				cmd_data_consume.Parameters["@SP_PRODC_FLAG4"].Value = "0";
					
				cmd_data_consume.Parameters.Add(new SqlParameter("@SP_PRODC_FLAG5", SqlDbType.NVarChar, 2));
				cmd_data_consume.Parameters["@SP_PRODC_FLAG5"].Value = "0";
					
				cmd_data_consume.Parameters.Add(new SqlParameter("@SP_PRODC_FLAGStatus", SqlDbType.NVarChar, 2));
				cmd_data_consume.Parameters["@SP_PRODC_FLAGStatus"].Value = "0";
				
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
				MessageBox.Show("Error Glue \nCannot save Consume in DB \n" + ex.Message + ex.ToString());			
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
					if (sqlConnParmOutput("SP_PROD_DOUBLE_SIDE_OUTPUT_DEL"))
					{
						for(i=0; i< dt_grid_consume2.Rows.Count;i++)
						{
							prodc_stock_code = dt_grid_consume2.Rows[i].Cells[0].Value.ToString().ToUpper();
							prodc_stock_desc = dt_grid_consume2.Rows[i].Cells[1].Value.ToString().ToUpper();
							prodc_qty = Convert.ToDouble(dt_grid_consume2.Rows[i].Cells[3].Value.ToString());
							if(!sqlConnParmConsume("SP_PROD_DOUBLE_SIDE_CONSUME_DEL"))
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
			

		void Retrieve()
		{
			SqlConnection con_SP1 = new SqlConnection(sqlconn);
			SqlCommand cmd_SP1 = new SqlCommand();
				
			try 
			{
				cmd_SP1.CommandText = @"SELECT * FROM TBL_PROD_DOUBLE_SIDE_OUTPUT where PROD_DOCNO = @doc_no";
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
					//txtbx_qty.Text = rd_SP1["PROD_QTY"].ToString();
					txtbx_oum.Text = rd_SP1["PROD_UOM"].ToString();
					txtbx_width.Text = rd_SP1["PROD_WIDTH"].ToString();
					txtbx_length.Text = rd_SP1["PROD_LENGTH"].ToString();
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
		        
				cmd_SP2.CommandText = @"SELECT PRODC_STOCKCODE, PRODC_STOCKDESC, PRODC_QTY, PRODC_UOM FROM TBL_PROD_DOUBLE_SIDE_CONSUME where SUBSTRING(PRODC_DOCNO,1,3) = @doc_no";
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
			if (string.IsNullOrWhiteSpace(txtbx_width.Text) || string.IsNullOrWhiteSpace(txtbx_length.Text))
			{
				MessageBox.Show("Please Keyin Length and Width");
				return;
			}
			if (dt_grid_consume.Rows.Count < 5)
			{
				    
				using(frm_prod_double_side_popup frm_popup_double_side =  new frm_prod_double_side_popup())
				{
					frm_popup_double_side.ShowDialog();
					
					string prod_code_add = frm_prod_double_side_popup.prod_code;
					string prod_desc_add = frm_prod_double_side_popup.prod_desc;
					string prod_uom_add = frm_prod_double_side_popup.prod_uom;
					
					
				
					
					
					
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
					
					
					
						if(txtbx_stock_code.SelectedItem.ToString().Substring(0, 6) == "WJ5040")
						{
							
						
							string desc_rawmat = null;
							for(int a = 0; a< dt_grid_consume.Rows.Count;a++)
							{
								

								desc_rawmat	= Convert.ToString(dt_grid_consume.Rows[a].Cells[0].Value);
								
								
								string fin_desc_rawmat = desc_rawmat;
							
							if((fin_desc_rawmat.Substring(0,4) == "ZP-T")) //|| (fin_desc_rawmat.Substring(0,15) == "TISSUE PAPER-14") | (fin_desc_rawmat.Substring(0,15) = "TISSUE PAPER-22"))
							{
								string desc_rawmat_detail = null;
								for(int b = 0; b < dt_grid_consume.Rows.Count;b++)
								{
									
								desc_rawmat_detail	= Convert.ToString(dt_grid_consume.Rows[a].Cells[1].Value);
								
								string fin_desc_rawmat_detail = desc_rawmat_detail;
								
								if(fin_desc_rawmat_detail.Substring(0,15) == "TISSUE PAPER-12")
								{
								double uom1 = Convert.ToDouble(Convert.ToString(12  * Convert.ToDouble(txtbx_width.Text) / 1000	* Convert.ToDouble(txtbx_length.Text) / 1000));
								this.dt_grid_consume.Rows[a].Cells[3].Value = uom1;
								}
								
								else if (fin_desc_rawmat_detail.Substring(0,15) == "TISSUE PAPER-14")
								{
								double uom1 = Convert.ToDouble(Convert.ToString(14  * Convert.ToDouble(txtbx_width.Text) / 1000	* Convert.ToDouble(txtbx_length.Text) / 1000));
								this.dt_grid_consume.Rows[a].Cells[3].Value = uom1;
								}
								
								else
								{
								double uom1 = Convert.ToDouble(Convert.ToString(22  * Convert.ToDouble(txtbx_width.Text) / 1000	* Convert.ToDouble(txtbx_length.Text) / 1000));
								this.dt_grid_consume.Rows[a].Cells[3].Value = uom1;
								}
								}
							}
								
								
								
								
							
							
							else if((fin_desc_rawmat.Substring(0,4) == "ZPF5") || (fin_desc_rawmat.Substring(0,4) == "ZPRE") || (fin_desc_rawmat.Substring(0,4) == "ZP70") || (fin_desc_rawmat.Substring(0,4) == "ZPEF") || (fin_desc_rawmat.Substring(0,4) == "ZPF-") || (fin_desc_rawmat.Substring(0,4) == "ZPR-"))
								
							{
								double width= 0;
								width = Convert.ToDouble(txtbx_width.Text);
								width = width / 1000;
								
								ttl_weight_glue = Math.Round(width * Convert.ToDouble(txtbx_length.Text),3);
								
								
								this.dt_grid_consume.Rows[a].Cells[3].Value = ttl_weight_glue ;
	
							}
				

//@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
//FOR hardener
							else if((fin_desc_rawmat.Substring(0,5) == "WG-SV") || (fin_desc_rawmat.Substring(0,4) == "ZPRE") || (fin_desc_rawmat.Substring(0,4) == "ZP70") || (fin_desc_rawmat.Substring(0,4) == "ZPEF") || (fin_desc_rawmat.Substring(0,4) == "ZPF-") || (fin_desc_rawmat.Substring(0,4) == "ZPR-"))
								
							{
								double width= 0;
								width = Convert.ToDouble(txtbx_width.Text);
								width = width / 1000;
								
								ttl_weight_glue = Math.Round(width * Convert.ToDouble(txtbx_length.Text),3);
								
								
								this.dt_grid_consume.Rows[a].Cells[3].Value = ttl_weight_glue ;
	
							}
							
							
							
							
										
							else
							{
								wet_weight = 78 * 100 / 57;
								Math.Round(wet_weight,2);
								
								double width = 0;
								double length = 0;
								
								length = Convert.ToDouble(txtbx_length.Text);
								length = length / 1000;
								
								width = Convert.ToDouble(txtbx_width.Text);
								width = width / 1000;
								ttl_weight_glue = Math.Round( width * length * wet_weight,2);
								
								this.dt_grid_consume.Rows[a].Cells[3].Value = ttl_weight_glue;
				
							}
														
								
							}
						}
							
			
									
					
						
						else if ((txtbx_stock_code.SelectedItem.ToString().Substring(0,5) == "WJ707") || (txtbx_stock_code.SelectedItem.ToString().Substring(0,5) == "WJ700"))
							{
							string desc_rawmat = null;
								for(int a = 0; a< dt_grid_consume.Rows.Count;a++)
							{
								

								desc_rawmat	= Convert.ToString(dt_grid_consume.Rows[a].Cells[0].Value);
								
								
								string fin_desc_rawmat = desc_rawmat;
							
							if((fin_desc_rawmat.Substring(0,4) == "ZP-T")) //|| (fin_desc_rawmat.Substring(0,15) == "TISSUE PAPER-14") | (fin_desc_rawmat.Substring(0,15) = "TISSUE PAPER-22"))
							{
								if(desc_rawmat.Substring(0,15) == "TISSUE PAPER-12")
								{
								double uom1 = Convert.ToDouble(Convert.ToString(12  * Convert.ToDouble(txtbx_width.Text) / 1000	* Convert.ToDouble(txtbx_length.Text) / 1000));
								this.dt_grid_consume.Rows[a].Cells[3].Value = uom1;
								}
								
								else if (desc_rawmat.Substring(0,15) == "TISSUE PAPER-14")
								{
								double uom1 = Convert.ToDouble(Convert.ToString(14  * Convert.ToDouble(txtbx_width.Text) / 1000	* Convert.ToDouble(txtbx_length.Text) / 1000));
								this.dt_grid_consume.Rows[a].Cells[3].Value = uom1;
								}
								
								else
								{
								double uom1 = Convert.ToDouble(Convert.ToString(22  * Convert.ToDouble(txtbx_width.Text) / 1000	* Convert.ToDouble(txtbx_length.Text) / 1000));
								this.dt_grid_consume.Rows[a].Cells[3].Value = uom1;
								}
							}
								
								
								
								
							
							
							else if((fin_desc_rawmat.Substring(0,4) == "ZPF5") || (fin_desc_rawmat.Substring(0,4) == "ZPRE") || (fin_desc_rawmat.Substring(0,4) == "ZP70") || (fin_desc_rawmat.Substring(0,4) == "ZPEF") || (fin_desc_rawmat.Substring(0,4) == "ZPF-") || (fin_desc_rawmat.Substring(0,4) == "ZPR-"))
								
							{
								double width= 0;
								width = Convert.ToDouble(txtbx_width.Text);
								width = width / 1000;
								
								ttl_weight_glue = Math.Round(width * Convert.ToDouble(txtbx_length.Text),3);
								
								
								this.dt_grid_consume.Rows[a].Cells[3].Value = ttl_weight_glue ;
	
							}
							
							
							
										
							else
							{
								wet_weight = 115 * 100 / 57;
								Math.Round(wet_weight,2);
								
								double width = 0;
								double length = 0;
								
								length = Convert.ToDouble(txtbx_length.Text);
								length = length / 1000;
								
								width = Convert.ToDouble(txtbx_width.Text);
								width = width / 1000;
								ttl_weight_glue = Math.Round( width * length * wet_weight,2);
								
								this.dt_grid_consume.Rows[a].Cells[3].Value = ttl_weight_glue;
				
							}
							
						
									
								
								
							}
							}
						
						
						else if(txtbx_stock_code.SelectedItem.ToString().Substring(0,4)== "WJF5")
						{
							string desc_rawmat = null;
							for(int a = 0; a< dt_grid_consume.Rows.Count;a++)
							{
								

								desc_rawmat	= Convert.ToString(dt_grid_consume.Rows[a].Cells[0].Value);
								
								
								string fin_desc_rawmat = desc_rawmat;
							
							if((fin_desc_rawmat.Substring(0,4) == "ZP-T")) //|| (fin_desc_rawmat.Substring(0,15) == "TISSUE PAPER-14") | (fin_desc_rawmat.Substring(0,15) = "TISSUE PAPER-22"))
							{
								if(desc_rawmat.Substring(0,15) == "TISSUE PAPER-12")
								{
								double uom1 = Convert.ToDouble(Convert.ToString(12  * Convert.ToDouble(txtbx_width.Text) / 1000	* Convert.ToDouble(txtbx_length.Text) / 1000));
								this.dt_grid_consume.Rows[a].Cells[3].Value = uom1;
								}
								
								else if (desc_rawmat.Substring(0,15) == "TISSUE PAPER-14")
								{
								double uom1 = Convert.ToDouble(Convert.ToString(14  * Convert.ToDouble(txtbx_width.Text) / 1000	* Convert.ToDouble(txtbx_length.Text) / 1000));
								this.dt_grid_consume.Rows[a].Cells[3].Value = uom1;
								}
								
								else
								{
								double uom1 = Convert.ToDouble(Convert.ToString(22  * Convert.ToDouble(txtbx_width.Text) / 1000	* Convert.ToDouble(txtbx_length.Text) / 1000));
								this.dt_grid_consume.Rows[a].Cells[3].Value = uom1;
								}
							}
								
								
								
								
							
							
							else if((fin_desc_rawmat.Substring(0,4) == "ZPF5") || (fin_desc_rawmat.Substring(0,4) == "ZPRE") || (fin_desc_rawmat.Substring(0,4) == "ZP70") || (fin_desc_rawmat.Substring(0,4) == "ZPEF") || (fin_desc_rawmat.Substring(0,4) == "ZPF-") || (fin_desc_rawmat.Substring(0,4) == "ZPR-"))
								
							{
								double width= 0;
								width = Convert.ToDouble(txtbx_width.Text);
								width = width / 1000;
								
								ttl_weight_glue = Math.Round(width * Convert.ToDouble(txtbx_length.Text),3);
								
								
								this.dt_grid_consume.Rows[a].Cells[3].Value = ttl_weight_glue ;
	
							}
							
							
							
										
							else
							{
								wet_weight = 100 * 100 / 57;
								Math.Round(wet_weight,2);
								
								double width = 0;
								double length = 0;
								
								length = Convert.ToDouble(txtbx_length.Text);
								length = length / 1000;
								
								width = Convert.ToDouble(txtbx_width.Text);
								width = width / 1000;
								ttl_weight_glue = Math.Round( width * length * wet_weight,2);
								
								this.dt_grid_consume.Rows[a].Cells[3].Value = ttl_weight_glue;
				
							}
							
						
									
								
								
							}
							
						}
						
						
						
						
						
						else
						{
							
							string desc_rawmat = null;
							//string desc_rawmat = null;
							for(int a = 0; a< dt_grid_consume.Rows.Count;a++)
							{
								

								desc_rawmat	= Convert.ToString(dt_grid_consume.Rows[a].Cells[0].Value);
								
								
								string fin_desc_rawmat = desc_rawmat;
							
								if((fin_desc_rawmat.Substring(0,4) == "TISS") || (fin_desc_rawmat.Substring(0,12) == "ZPR-SRLM5207")) //|| (fin_desc_rawmat.Substring(0,15) == "TISSUE PAPER-14") | (fin_desc_rawmat.Substring(0,15) = "TISSUE PAPER-22"))
							{
								//MessageBox.Show("masuk bahagian tissue");
								
								double uom1 = Convert.ToDouble(Convert.ToString(Convert.ToDouble(txtbx_width.Text) / 1000	* Convert.ToDouble(txtbx_length.Text) / 1000 * 12));
								this.dt_grid_consume.Rows[a].Cells[3].Value = uom1;
								
								//for(int c = 0; c<dt_grid_consume.Rows.Count;c++)
								//{
								//for(int j = 3; j < dt_grid_consume.Columns.Count; j++)
								// {
								//this.dt_grid_consume.Rows[c].Cells[3].Value = uom1;
								// }
								//	}
						//	}
										//DataGridView dt_grid_consume2 = new DataGridView();
							}
								
								
							else if((fin_desc_rawmat.Substring(0,4) == "ZPF5") || (fin_desc_rawmat.Substring(0,4) == "ZPRE") || (fin_desc_rawmat.Substring(0,4) == "ZP70") || (fin_desc_rawmat.Substring(0,4) == "ZPEF") || (fin_desc_rawmat.Substring(0,4) == "ZPF-") || (fin_desc_rawmat.Substring(0,4) == "ZPR-"))
								
							{
								double width= 0;
								width = Convert.ToDouble(txtbx_width.Text);
								width = width / 1000;
								
								ttl_weight_glue = Math.Round(width * Convert.ToDouble(txtbx_length.Text),3);
								
								this.dt_grid_consume.Rows[a].Cells[3].Value = ttl_weight_glue;
								MessageBox.Show(ttl_weight_glue.ToString() + "paper");
							}
										
							else
							{
							
								wet_weight = 78 * 100 / 57;
										
								double width = 0;
								double length = 0;
								
								length = Convert.ToDouble(txtbx_length.Text);
								length = length / 1000;
								
								width = Convert.ToDouble(txtbx_width.Text);
								width = width / 1000;
								ttl_weight_glue = Math.Round( width * length * wet_weight,2);
		
								this.dt_grid_consume.Rows[a].Cells[3].Value = ttl_weight_glue;
							}
							}
									
								
								
							

						
						
			
						}
			
			}
			}
				
			
				
			
				
			
		else
		MessageBox.Show("Cannot add more rows");
		
			
		}
		
		void Dt_grid_consumeCellClick(object sender, DataGridViewCellEventArgs e)
		{
			if(e.RowIndex == -1) 
			return;

   			    if( e.RowIndex == dt_grid_consume.NewRowIndex || e.RowIndex < 0)
		        return;
		
		    //Check if click is on specific column 
		    if(e.ColumnIndex  == dt_grid_consume.Columns["dataGridViewDeleteButton"].Index)
		    {
		        //Put some logic here, for example to remove row from your binding list.
		        dt_grid_consume.Rows.RemoveAt(e.RowIndex);
		    }
		}
		

		
		void NextNumberRetrieve()
		{
			
			stockcodeshipmark = txtbx_stock_code.Text;
			int NextNo ;
			
						NextNo = 0;
//************************************************************************************************************************
						SqlConnection conNextNumber = new SqlConnection(sqlconn);
						SqlCommand cmdNextNumber = new SqlCommand();
						try {
							cmdNextNumber.CommandText = "Select * from TBL_ADMIN_NEXT_NUMBER";
							cmdNextNumber.Connection = conNextNumber;
							conNextNumber.Open();
							SqlDataReader rdNextNumber = cmdNextNumber.ExecuteReader(System.Data.CommandBehavior.CloseConnection); //UNTUK BACA DATA DALAM TABLE
							rdNextNumber.Read();
							NextNo = Convert.ToInt32(rdNextNumber["ProdDoubleSideNextNumberShipMark"].ToString());
							
						} 
						
						
						catch (Exception ex) 
						
						{
							MessageBox.Show("ERROR NEXT NUMBER!" + ex.ToString() + ex.Message);
							NextNo = 0;
							return;
							
						} 
						
						finally
						{
							conNextNumber.Close();
						}
						conNextNumber.Dispose();
						conNextNumber = null;
						cmdNextNumber = null;
						//************************************************************************************************************************
						if (NextNo >= 9999) 
						{
							NextNo = 1000;
							SqlConnection conUpdateNextNumberZero = new SqlConnection(sqlconn);
							System.Data.SqlClient.SqlCommand cmdUpdateNextNumberZero = new SqlCommand();
							try {
								cmdUpdateNextNumberZero.CommandText = "update TBL_ADMIN_NEXT_NUMBER set ProdDoubleSideNextNumberShipMark = 1000";
								cmdUpdateNextNumberZero.Connection = conUpdateNextNumberZero;
								conUpdateNextNumberZero.Open();
								cmdUpdateNextNumberZero.ExecuteNonQuery();
								} 
							
							catch (Exception ex) 
							{
								conUpdateNextNumberZero.Close();
								MessageBox.Show("Error Updates Next Number" + ex.ToString() + ex.Message);
								return;
							}
							
							finally
							{
								conUpdateNextNumberZero.Close();
							}
							
							
							
							conUpdateNextNumberZero.Dispose();
							conUpdateNextNumberZero = null;
							cmdUpdateNextNumberZero = null;
						}
						//************************************************************************************************************************
						//************************************************************************************************************************
						//DateTime JODSDate = DateTime.Now;
						string JODSDate = dtp_date.Value.ToString("yyMMdd");
						
						
						
						string JODSDateString = null;
						//JODSDate = null;
						JODSDateString = null;
						//JODSDate = System.DateTime.Now;
						//JODSDateString = (JODSDate.ToString("yy")) + (JODSDate.ToString("MM")) + (JODSDate.ToString("dd"));
						JODSDateString = dtp_date.Value.ToString("yyMMdd");
						string SDate;
						//MessageBox.Show(JODSDateString.ToString());
			
						//************************************************************************************************************************
						SDate = shift_time + JODSDateString + "-" + stockcodeshipmark + "-" + NextNo;
						
						shippingmark = SDate;
						
						//************************************************************************************************************************
						//************************************************************************************************************************
						//---  Update next number
						SqlConnection conUpdateNextNumber = new SqlConnection(sqlconn);
						System.Data.SqlClient.SqlCommand cmdUpdateNextNumber = new SqlCommand();
						try {
							cmdUpdateNextNumber.CommandText = "update TBL_ADMIN_NEXT_NUMBER set ProdDoubleSideNextNumberShipMark = ProdDoubleSideNextNumberShipMark + 1";
							cmdUpdateNextNumber.Connection = conUpdateNextNumber;
							conUpdateNextNumber.Open();
							cmdUpdateNextNumber.ExecuteNonQuery();
						}
						catch (Exception ex)
						{
							conUpdateNextNumber.Close();
							MessageBox.Show("Error Update Next Number!" + ex.ToString() + ex.Message); 
							return;
						}
						finally 
						{
							conUpdateNextNumber.Close();
						}
						conUpdateNextNumber.Dispose();
						conUpdateNextNumber = null;
						cmdUpdateNextNumber = null;
						
						
						SetValueForText1 = shippingmark;
					
		}
		
		
		
		void calculation_weight_of_glue()
		{
			//if (
		}
		
		
		
		
	}
}
