using System;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Data.SqlClient;      // For the database connections and objects.
using System.Data.Sql;
using System.Data.Sql;
using System.Data;
using CommonFunction;
using CommonLibrary;
using CommonControl.Functions;

namespace AX2020
{
	public partial class frm_prod_converting_store : Form
	{	
		public static string sqlconn = "Server=AX-UAT; Password=sbax2020sbg; User ID=sbax2020; Initial Catalog=SBG_AX_2020; Integrated Security=false";
		public static string sqlconn2 = "Server=AX-SQL; Password=ax2020sbgroup; User ID=ax2020sb; Initial Catalog=AX2020StagingDB; Integrated Security=false";
        
		public static string Sqlconn = "DSN=eb9gf;Port=2138;Uid=dba;Pwd=sql";
		string username;
		int NextNo;
		string line_no;
		string CheckPRRecord; 
			
		
		public frm_prod_converting_store()
		{
					
			InitializeComponent();
			this.ControlBox = false;
			username = frm_menu_system.userName; 
			//lbl_username.Text = "User : " + username;
			
//			btn_save.Visible = false;
//			//btn_clear.Visible = false;
//			btn_cancel.Visible = true;
//			btn_cancel.Location = new Point(445, 610);
			//DropDownList("SELECT * FROM TBL_PROD_CONV_JO_STORE_REQUEST_BY order by REQUESTBY", cbx_requested_by, "REQUESTBY");
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
         		
   			}
		}
		
		void Btn_cancelClick(object sender, EventArgs e)
		{
//			DialogResult cancel = new DialogResult();
//            cancel = MessageBox.Show("Do you want to cancel?", "Cancel", 
//                     MessageBoxButtons.YesNo, 
//                     MessageBoxIcon.Warning, 
//                     MessageBoxDefaultButton.Button2);
//            
//			if (cancel == DialogResult.Yes)
//            {
            	ClearAllText(this);
            	this.Close();
                
            //}
              
		}
		
		void Btn_clearClick(object sender, EventArgs e)
		{
			ClearAllText(this);
			txtbx_ref_no.Text = "STORE" + DateTime.Now.ToString("yyyyMMdd");
		}
		
		private void DropDownList(string cmd, ComboBox cbx_text, string col_name)
		{
		    SqlConnection conn = new SqlConnection(sqlconn);
            DataTable ds = new DataTable();
            string cmdSQL = cmd;
            SqlDataAdapter sda = new SqlDataAdapter(cmdSQL, conn);

            try
            {
                conn.Open();
                sda.Fill(ds);
                cbx_text.Text = "Please Select";
            
            }catch(SqlException se)
            {
            	MessageBox.Show("Error - Converting BOM Dropdown \nCannot load DB \n" + se.ToString() + se.Message);
            }
            finally
            {
                conn.Close();
            }
			
           	foreach(DataRow dr1 in ds.Rows)
           	{
               cbx_text.Items.Add(dr1[col_name].ToString());
           	}
            //cbx_jr_roll.DataSource = ds.Tables[0];
            //cbx_jr_roll.DisplayMember = ds.Tables[0].Columns[0].ToString();
            //cbx_jr_roll.SelectedIndex = 3;
		}
		
		private bool Validation()
        {
                  
               if (CommonValidation.ValidateIsEmptyString(txtbx_stock_code.Text.Trim()))
                {
                    DialogBox.ShowWarningMessage(lbl_stock_code.Text + " cannot be empty.");
                    txtbx_stock_code.Focus();
                   	
                    return false;
           
                }
              
               
//               else if (CommonValidation.ValidateIsEmptyString(cbx_mic.Text.Trim()))
//                {
//                    DialogBox.ShowWarningMessage(lbl_mic.Text + " cannot be empty.");
//                    cbx_mic.Focus();
//                   	
//                    return false;
//                    
//                }
               
               
               else if (CommonValidation.ValidateIsEmptyString(txtbx_mic.Text.Trim()))
                {
                    DialogBox.ShowWarningMessage(lbl_stock_spec.Text + " cannot be empty.");
                    txtbx_mic.Focus();
                   	
                    return false;                  
                }
               
               else if (CommonValidation.ValidateIsEmptyString(txtbx_length.Text.Trim()))
                {
                    DialogBox.ShowWarningMessage(lbl_stock_spec.Text + " cannot be empty.");
                    txtbx_length.Focus();
                   	
                    return false;                   
                }
               
               return true;
        }

		void DataGrid()
		{
			SqlConnection con_SP = new SqlConnection(sqlconn);
			SqlCommand cmd_SP = new SqlCommand();
				
			try 
			{
				cmd_SP.CommandText = @"SELECT JOLINENO, JODOCNO, JOSTOCKCODE, JOSTOCKDESC1, JOSTOCKDESC2, JOSTOCKCOLOR, JOSTOCKBRAND, JOSTOCKWIDTH, JOSTOCKLENGTH, JOSTOCKMICRON, JOSTOCKCONVERSION, JOSTOCKQTYORDER, JOSTOCKUOM1, JOSTOCKUOM2 FROM TBL_PROD_CONV_STORE order by JOLINENO";
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
	            dt_grid.Columns[0].Width = 28;
	            dt_grid.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
	            dt_grid.Columns[1].HeaderText = "Line No";
	            dt_grid.Columns[1].Width = 40;
	            dt_grid.Columns[2].HeaderText = "Ref No";
	            dt_grid.Columns[2].Width = 80;
	            dt_grid.Columns[3].HeaderText = "Stock Code";
	            dt_grid.Columns[3].Width = 80;
	            dt_grid.Columns[4].HeaderText = "Description 1";
	            dt_grid.Columns[4].Width = 120;
	            dt_grid.Columns[5].HeaderText = "Description 2";
				dt_grid.Columns[5].Width = 120;            
				dt_grid.Columns[6].HeaderText = "Color";
				dt_grid.Columns[6].Width = 50;
	            dt_grid.Columns[7].HeaderText = "Brand";
	            dt_grid.Columns[7].Width = 50;
				dt_grid.Columns[8].HeaderText = "Width";
				dt_grid.Columns[8].Width = 50;            
				dt_grid.Columns[9].HeaderText = "Length";
				dt_grid.Columns[9].Width = 50;
	            dt_grid.Columns[10].HeaderText = "Micron";
				dt_grid.Columns[10].Width = 50;	            
				dt_grid.Columns[11].HeaderText = "Roll/Ctn";
				dt_grid.Columns[11].Width = 55;
	            dt_grid.Columns[12].HeaderText = "Qty Ordered (Roll)";
				dt_grid.Columns[12].Width = 55;	            
				dt_grid.Columns[13].HeaderText = "UOM1";
				dt_grid.Columns[13].Width = 42;
	            dt_grid.Columns[14].HeaderText = "UOM2";
				
						            		
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
		
		
		void Btn_saveClick(object sender, EventArgs e)
		{
			if (!Validation())
                return;
			
//			CheckTime();
			
//			if (CheckPRRecord == "Y")
//			{
				if(DocNoGenerator() & sqlConnParm("SP_PROD_CONV_STORE_ADD"))
				{
				 	DialogBox.ShowSaveSuccessDialog();
					DataGrid();
				}
				else 
					return;
				
//			}
//			else
//				MessageBox.Show("Store PR only can post 11:00am / 3:30pm");
			
		}
		
		private bool DocNoGenerator()
		{

			SqlConnection conNextNumber = new SqlConnection(sqlconn);
			SqlCommand cmdNextNumber = new SqlCommand();

			try
			{
				cmdNextNumber.CommandText = "Select JoStoreNextNumber from TBL_ADMIN_NEXT_NUMBER";
				cmdNextNumber.Connection = conNextNumber;

				conNextNumber.Open();
				SqlDataReader rdNextNumber = cmdNextNumber.ExecuteReader(System.Data.CommandBehavior.CloseConnection);

				rdNextNumber.Read();
				NextNo = Convert.ToInt32(rdNextNumber["JoStoreNextNumber"]);
				line_no = NextNo.ToString();

			}
			catch (Exception ex) 
			{
				MessageBox.Show("Error - Converting JO Next Number DB \nCannot get next number \n" + ex.Message + ex.ToString());
				NextNo = 0;
				return false;
			}
			finally 
			{
				conNextNumber.Close();
				
			}

			conNextNumber.Dispose();
	
			conNextNumber = null;
			cmdNextNumber = null;

			//string SDate = txtbx_ref_no.Text.ToUpper() + "-" + NextNo;

			//---  Update next number
			SqlConnection conUpdate = new SqlConnection(sqlconn);
			SqlCommand cmdUpdateNextNumber = new SqlCommand();

			try
			{
				cmdUpdateNextNumber.CommandText = "update TBL_ADMIN_NEXT_NUMBER set JoStoreNextNumber = JoStoreNextNumber + 100";
				
				cmdUpdateNextNumber.Connection = conUpdate;

				conUpdate.Open();
				cmdUpdateNextNumber.ExecuteNonQuery();

			}
			catch (Exception ex)
			{
				conUpdate.Close();
				MessageBox.Show("Error - Converting JO Next Number DB \nCannot update next number \n" + ex.Message + ex.ToString());
				return false;
			}
			finally 
			{
				conUpdate.Close();
			}

			conUpdate.Dispose();
			conUpdate = null;
			cmdUpdateNextNumber = null;
			return true;
		}
		
		bool sqlConnParm(string sqlStatement)
		{
			SqlConnection con_data = new SqlConnection(sqlconn);
			SqlCommand cmd_data = new SqlCommand();
			
			try
			{
					cmd_data.Connection = con_data;
					cmd_data.CommandText = sqlStatement;
					cmd_data.CommandType = CommandType.StoredProcedure;

					cmd_data.Parameters.Add(new SqlParameter("@SP_JOSTOCKCODE", SqlDbType.NVarChar, 50));
					cmd_data.Parameters["@SP_JOSTOCKCODE"].Value = txtbx_stock_code.Text.ToUpper();
					
					cmd_data.Parameters.Add(new SqlParameter("@SP_JOSTOCKDESC1", SqlDbType.NVarChar, 50));
					cmd_data.Parameters["@SP_JOSTOCKDESC1"].Value = txtbx_desc_1.Text.ToUpper();
					
					cmd_data.Parameters.Add(new SqlParameter("@SP_JOSTOCKDESC2", SqlDbType.NVarChar, 50));
					cmd_data.Parameters["@SP_JOSTOCKDESC2"].Value = txtbx_desc_2.Text.ToUpper();

					cmd_data.Parameters.Add(new SqlParameter("@SP_JOSTOCKCOLOR", SqlDbType.NVarChar, 50));
					cmd_data.Parameters["@SP_JOSTOCKCOLOR"].Value = txtbx_color.Text.ToUpper();

					cmd_data.Parameters.Add(new SqlParameter("@SP_JOSTOCKBRAND", SqlDbType.NVarChar, 50));
					cmd_data.Parameters["@SP_JOSTOCKBRAND"].Value = txtbx_brand.Text.ToUpper();

					cmd_data.Parameters.Add(new SqlParameter("@SP_JOSTOCKWIDTH", SqlDbType.Float));
					cmd_data.Parameters["@SP_JOSTOCKWIDTH"].Value = Double.Parse(txtbx_width.Text);

					cmd_data.Parameters.Add(new SqlParameter("@SP_JOSTOCKLENGTH ", SqlDbType.Float));
					cmd_data.Parameters["@SP_JOSTOCKLENGTH "].Value = Double.Parse(txtbx_length.Text);

					cmd_data.Parameters.Add(new SqlParameter("@SP_JOSTOCKMICRON", SqlDbType.Float));
					cmd_data.Parameters["@SP_JOSTOCKMICRON"].Value = Double.Parse(txtbx_mic.Text);

					cmd_data.Parameters.Add(new SqlParameter("@SP_JOSTOCKCONVERSION", SqlDbType.Float));
					cmd_data.Parameters["@SP_JOSTOCKCONVERSION"].Value = Double.Parse(txtbx_conversion.Text);
					
					cmd_data.Parameters.Add(new SqlParameter("@SP_JOSTOCKUOM1", SqlDbType.NVarChar, 10));
					cmd_data.Parameters["@SP_JOSTOCKUOM1"].Value = txtbx_uom_1.Text;

					cmd_data.Parameters.Add(new SqlParameter("@SP_JOSTOCKUOM2", SqlDbType.NVarChar, 10));
					cmd_data.Parameters["@SP_JOSTOCKUOM2"].Value = txtbx_uom_2.Text;

					cmd_data.Parameters.Add(new SqlParameter("@SP_JOLINENO", SqlDbType.NVarChar, 50));
					cmd_data.Parameters["@SP_JOLINENO"].Value = line_no;
					
					cmd_data.Parameters.Add(new SqlParameter("@SP_JODOCNO", SqlDbType.NVarChar, 50));
					cmd_data.Parameters["@SP_JODOCNO"].Value = txtbx_ref_no.Text.ToUpper();
					
					cmd_data.Parameters.Add(new SqlParameter("@SP_JOSTOCKQTYORDER", SqlDbType.NVarChar, 50));
					cmd_data.Parameters["@SP_JOSTOCKQTYORDER"].Value = txtbx_qty_order.Text.ToUpper();
					
					cmd_data.Parameters.Add(new SqlParameter("@SP_JOREQUESTEDBY", SqlDbType.NVarChar, 50));
					cmd_data.Parameters["@SP_JOREQUESTEDBY"].Value = username.ToUpper();
					
//					cmd_data.Parameters.Add(new SqlParameter("@SP_JOISSUEBY", SqlDbType.NVarChar, 50));
//					cmd_data.Parameters["@SP_JOISSUEBY"].Value = username.ToUpper();
					
					cmd_data.Parameters.Add(new SqlParameter("@SP_JOUSER", SqlDbType.NVarChar, 50));
					cmd_data.Parameters["@SP_JOUSER"].Value = username.ToUpper();
					
					cmd_data.Parameters.Add(new SqlParameter("@SP_JOUSEREMAIL", SqlDbType.NVarChar, 50));
					cmd_data.Parameters["@SP_JOUSEREMAIL"].Value = frm_menu_system.email;
					
					cmd_data.Parameters.Add(new SqlParameter("@SP_JOUSERPC", SqlDbType.NVarChar, 50));
					cmd_data.Parameters["@SP_JOUSERPC"].Value = frm_menu_system.ipAddress;
					
					cmd_data.Parameters.Add(new SqlParameter("@SP_JOUSERDATETIME", SqlDbType.DateTime));
					cmd_data.Parameters["@SP_JOUSERDATETIME"].Value = DateTime.Now;
					
					cmd_data.Parameters.Add(new SqlParameter("@SP_JOUSERREVISION", SqlDbType.NVarChar, 50));
					cmd_data.Parameters["@SP_JOUSERREVISION"].Value = "0";
					
					cmd_data.Parameters.Add(new SqlParameter("@SP_JOSTOCKSTATUS", SqlDbType.NVarChar, 25));
					cmd_data.Parameters["@SP_JOSTOCKSTATUS"].Value = "0";

					con_data.Open();
					cmd_data.ExecuteNonQuery();
					
			} catch (Exception ex) {
				
				con_data.Close();
				MessageBox.Show("Unexpected error happen" + Environment.NewLine + ex.Message + ex.ToString());			
				return false;
			
			} finally {
				
				con_data.Close();
				
			}
			
			con_data.Dispose();
			con_data = null;
			cmd_data = null;
			return true;
			//ClearTextBox();
			ClearAllText(this);
		}
		
		void Btn_searchClick(object sender, EventArgs e)
		{
			if (String.IsNullOrWhiteSpace(txtbx_stock_code.Text))
        	{
        		MessageBox.Show("Please key-in stock code");
        		return;
        	}	
			
			//--------------------------------------------------------------------------
        	

//			string ERP_ST_P1_objSqlStatement = "select mcode, mdesc1, mdesc2, mbrand, muom_p, muom_s, mfraction, mremark1, mpack_length, mpack_width, mpack_height from stk where mmc = 'GF' and mstatus = 'A' and mcode = '" + txtbx_stock_code.Text.ToUpper() + "'";
//        	SqlConnection ERP_ST_P1_objConn = new SqlConnection(Sqlconn);
//               
//			try
// 			{
//            	ERP_ST_P1_objConn.Open();
//                SqlCommand ERP_ST_P1_objCMD = new SqlCommand(ERP_ST_P1_objSqlStatement, ERP_ST_P1_objConn);
//               	SqlDataReader ERP_ST_P1_objDR  = ERP_ST_P1_objCMD.ExecuteReader();            	
//            	
//            	if (ERP_ST_P1_objDR.HasRows)
//            	{
//            		while (ERP_ST_P1_objDR.Read())
//            		{
//            			txtbx_stock_code.Text = ERP_ST_P1_objDR["mcode"].ToString();
//            			txtbx_color.Text = ERP_ST_P1_objDR["mremark1"].ToString();
//            			txtbx_brand.Text = ERP_ST_P1_objDR["mbrand"].ToString();
//            			txtbx_mic.Text = ERP_ST_P1_objDR["mpack_height"].ToString();
//            			txtbx_width.Text = ERP_ST_P1_objDR["mpack_width"].ToString();
//            			txtbx_length.Text = ERP_ST_P1_objDR["mpack_length"].ToString();
//            			txtbx_conversion.Text = ERP_ST_P1_objDR["mfraction"].ToString();
//            			txtbx_uom_1.Text = ERP_ST_P1_objDR["muom_p"].ToString();
//            			txtbx_uom_2.Text = ERP_ST_P1_objDR["muom_s"].ToString();
//            			
//                    	txtbx_desc_1.Text = ERP_ST_P1_objDR["mdesc1"].ToString();
//                    	txtbx_desc_2.Text = ERP_ST_P1_objDR["mdesc2"].ToString();
//                    	//txtbx_cust.Text = ERP_ST_P1_objDR["tdoline1"].ToString();
//                    	//txtbx_desc_2.Text = "CTN MARKING: " + ERP_ST_P1_objDR["tdouble01"].ToString() + "MM X " + ERP_ST_P1_objDR["tdouble02"].ToString() + "M";
//            		} 
//            	}
//            	else
//            	{
//            		MessageBox.Show("Error - Store Order \nCannot find Stock Code");
//            		return;
//            	}
//
//            	//ERP_ST_P1_objDR.Close();
// 			} 
// 			
// 			catch (Exception ERP_ST_P1_exc)
// 			{
// 				MessageBox.Show("Error - Store Order \nCannot load DB" + ERP_ST_P1_exc.Message + ERP_ST_P1_exc.ToString());
//            	ERP_ST_P1_objConn.Close();
//            	ERP_ST_P1_objConn.Dispose();
//            	return;
// 			}
// 			
//        	finally
//        	{
//            	ERP_ST_P1_objConn.Close();
//            	ERP_ST_P1_objConn.Dispose();
//
//        	}
//        	
//        	ERP_ST_P1_objConn = null;
//        	ERP_ST_P1_objSqlStatement = null;


			string ERP_ST_P1_objSqlStatement = "select top 1  * from VIEW_AXERP_ITEM_MASTER_ATTRIBUTE_FULLINFO where itemid = '" + txtbx_stock_code.Text.ToUpper() + "'";
        	SqlConnection ERP_ST_P1_objConn = new SqlConnection(sqlconn2);
               
			try
 			{
            	ERP_ST_P1_objConn.Open();
                SqlCommand ERP_ST_P1_objCMD = new SqlCommand(ERP_ST_P1_objSqlStatement, ERP_ST_P1_objConn);
               	SqlDataReader ERP_ST_P1_objDR  = ERP_ST_P1_objCMD.ExecuteReader();            	
            	
            	if (ERP_ST_P1_objDR.HasRows)
            	{
            		while (ERP_ST_P1_objDR.Read())
            		{
            			txtbx_stock_code.Text = ERP_ST_P1_objDR["itemid"].ToString();
            			txtbx_color.Text = ERP_ST_P1_objDR["color"].ToString();
            			txtbx_brand.Text = ERP_ST_P1_objDR["brand"].ToString();
            			txtbx_mic.Text = ERP_ST_P1_objDR["micron"].ToString();
            			txtbx_width.Text = ERP_ST_P1_objDR["width"].ToString();
            			txtbx_length.Text = ERP_ST_P1_objDR["llength"].ToString();
//            			txtbx_conversion.Text = ERP_ST_P1_objDR["mfraction"].ToString();
//            			txtbx_uom_1.Text = ERP_ST_P1_objDR["muom_p"].ToString();
//            			txtbx_uom_2.Text = ERP_ST_P1_objDR["muom_s"].ToString();
//            			
//                    	txtbx_desc_1.Text = ERP_ST_P1_objDR["mdesc1"].ToString();
//                    	txtbx_desc_2.Text = ERP_ST_P1_objDR["mdesc2"].ToString();
                    	//txtbx_cust.Text = ERP_ST_P1_objDR["tdoline1"].ToString();
                    	//txtbx_desc_2.Text = "CTN MARKING: " + ERP_ST_P1_objDR["tdouble01"].ToString() + "MM X " + ERP_ST_P1_objDR["tdouble02"].ToString() + "M";
            		} 
            	}
            	else
            	{
            		MessageBox.Show("Error - Store Order \nCannot find Stock Code");
            		return;
            	}

            	//ERP_ST_P1_objDR.Close();
 			} 
 			
 			catch (Exception ERP_ST_P1_exc)
 			{
 				MessageBox.Show("Error - Store Order \nCannot load DB" + ERP_ST_P1_exc.Message + ERP_ST_P1_exc.ToString());
            	ERP_ST_P1_objConn.Close();
            	ERP_ST_P1_objConn.Dispose();
            	return;
 			}
 			
        	finally
        	{
            	ERP_ST_P1_objConn.Close();
            	ERP_ST_P1_objConn.Dispose();

        	}
        	
        	ERP_ST_P1_objConn = null;
        	ERP_ST_P1_objSqlStatement = null;
        	
        	
        	
        	
        	//--------------------------------------------------------------------
        	
        	string ERP_ST_P2_objSqlStatement = "select top 1  * from VIEW_AXERP_ITEM_MASTER where itemid = '" + txtbx_stock_code.Text.ToUpper() + "'";
        	SqlConnection ERP_ST_P2_objConn = new SqlConnection(sqlconn2);
               
			try
 			{
            	ERP_ST_P2_objConn.Open();
                SqlCommand ERP_ST_P2_objCMD = new SqlCommand(ERP_ST_P2_objSqlStatement, ERP_ST_P2_objConn);
               	SqlDataReader ERP_ST_P2_objDR  = ERP_ST_P2_objCMD.ExecuteReader();            	
            	
            	if (ERP_ST_P2_objDR.HasRows)
            	{
            		while (ERP_ST_P2_objDR.Read())
            		{
            			if(ERP_ST_P2_objDR["factor"] != DBNull.Value)
                    	{
                    		txtbx_conversion.Text 	= ERP_ST_P2_objDR.GetDecimal(ERP_ST_P2_objDR.GetOrdinal("factor")).ToString("0.##");
                    	}
                    	else
                    	{
                    		txtbx_conversion.Text 	= "0";
                    	}
            			
            			//txtbx_conversion.Text = Convert.ToInt32(ERP_ST_P2_objDR["factor"]).ToString();
            			txtbx_uom_1.Text = ERP_ST_P2_objDR["TOUNITOFMEASURESYMBOL"].ToString();
            			txtbx_uom_2.Text = ERP_ST_P2_objDR["FROMUNITOFMEASURESYMBOL"].ToString();
            			
            			string theText =  ERP_ST_P2_objDR["DOT_DESCRIPTION"].ToString();
            			string[] lines = theText.Split(new[] { "\r\n", "\r", "\n"  }, StringSplitOptions.None);
            			
            			txtbx_desc_1.Text = lines[0];
            			txtbx_desc_2.Text = lines[1];
//                    	txtbx_desc_1.Text = ERP_ST_P2_objDR["mdesc1"].ToString();
//                    	txtbx_desc_2.Text = ERP_ST_P2_objDR["mdesc2"].ToString();
                    	//txtbx_cust.Text = ERP_ST_P2_objDR["tdoline1"].ToString();
                    	//txtbx_desc_2.Text = "CTN MARKING: " + ERP_ST_P2_objDR["tdouble01"].ToString() + "MM X " + ERP_ST_P2_objDR["tdouble02"].ToString() + "M";
            		} 
            	}
            	else
            	{
            		MessageBox.Show("Error - Store Order \nCannot find Stock Code");
            		return;
            	}

            	//ERP_ST_P2_objDR.Close();
 			} 
 			
 			catch (Exception ERP_ST_P2_exc)
 			{
 				MessageBox.Show("Error - Store Order \nCannot load DB" + ERP_ST_P2_exc.Message + ERP_ST_P2_exc.ToString());
            	ERP_ST_P2_objConn.Close();
            	ERP_ST_P2_objConn.Dispose();
            	return;
 			}
 			
        	finally
        	{
            	ERP_ST_P2_objConn.Close();
            	ERP_ST_P2_objConn.Dispose();

        	}
        	
        	ERP_ST_P2_objConn = null;
        	ERP_ST_P2_objSqlStatement = null;
					
		}
			
		
		void Frm_prod_converting_storeLoad(object sender, EventArgs e)
		{
			txtbx_ref_no.Text = "STORE" + DateTime.Now.ToString("yyyyMMdd");
			
			DataGrid();
			
			if(AlreadyPost())
			{
				if(DateTime.Now.Hour > 15)
				{
					btn_post.Enabled = true;
				}
			}
			else
				btn_post.Enabled = false;
				
			if(Check11am())
			{
				btn_post.Enabled = true;
			}
			else
				btn_post.Enabled = false;
		}
		
		
		
		void Btn_delClick(object sender, EventArgs e)
		{
			if (!Validation())
                return;
			
			MessageBox.Show(txtbx_ref_no.Text + line_no);
			SqlConnection con_check = new SqlConnection(sqlconn);
			SqlCommand cmd_check = new SqlCommand();
			
			try 
			{
				cmd_check.CommandText = @"select * from TBL_PROD_CONV_JO where JODOCNO = @doc_no + '-' + @line_no";
				cmd_check.Parameters.AddWithValue("@doc_no",  txtbx_ref_no.Text);
				cmd_check.Parameters.AddWithValue("@line_no",  line_no);
				cmd_check.Connection = con_check;
				con_check.Open();
				SqlDataReader rd_check = cmd_check.ExecuteReader(System.Data.CommandBehavior.CloseConnection);

				if (rd_check.HasRows)
				{
					if (rd_check.Read())
					{
						MessageBox.Show("Cannot delete. Job Order already has been made. \nDelete Job Order first if you want to delete this.");
						return;
					}
				}
			}
			catch (Exception ex)
			{
				con_check.Close();
				MessageBox.Show("Error - Store Check \n" + ex.Message + ex.ToString());
				return;
			} 
			finally 
			{
				con_check.Close();
			}
			
			con_check.Dispose();
			cmd_check.Dispose();
			con_check = null;
			cmd_check = null;

			
			
			DialogResult del = new DialogResult();
            del = MessageBox.Show("Are you sure you want to delete it?", "Delete", 
                     MessageBoxButtons.YesNo, 
                     MessageBoxIcon.Warning, 
                     MessageBoxDefaultButton.Button2);
            if (del == DialogResult.Yes)
            {
            	if(sqlConnParm("SP_PROD_CONV_STORE_DEL"))
            	{
					//MessageBox.Show("The data has been deleted");
					DialogBox.ShowDeleteSuccessDialog();
					btn_save.Visible = true;
					btn_del.Visible = false;
					ClearAllText(this);
            	}
				
            	DataGrid();
            }
						
		}
		
		
		void Dt_gridCellClick(object sender, DataGridViewCellEventArgs e)
		{
			if(dt_grid.SelectedRows.Count > 0) // make sure user select at least 1 row 
			{
				btn_del.Visible = true;
				btn_save.Hide();
				txtbx_ref_no.Text = dt_grid.SelectedRows[0].Cells[2].Value + string.Empty;
			   	txtbx_stock_code.Text = dt_grid.SelectedRows[0].Cells[3].Value + string.Empty;
			   	txtbx_desc_1.Text = dt_grid.SelectedRows[0].Cells[4].Value + string.Empty;
			   	txtbx_desc_2.Text = dt_grid.SelectedRows[0].Cells[5].Value + string.Empty;
			   	txtbx_color.Text = dt_grid.SelectedRows[0].Cells[6].Value + string.Empty;
			   	txtbx_brand.Text = dt_grid.SelectedRows[0].Cells[7].Value + string.Empty;
			   	txtbx_width.Text = dt_grid.SelectedRows[0].Cells[8].Value + string.Empty;
			   	txtbx_length.Text = dt_grid.SelectedRows[0].Cells[9].Value + string.Empty;
			   	txtbx_mic.Text = dt_grid.SelectedRows[0].Cells[10].Value + string.Empty;
			   	txtbx_conversion.Text = dt_grid.SelectedRows[0].Cells[11].Value + string.Empty;
			   	txtbx_qty_order.Text = dt_grid.SelectedRows[0].Cells[12].Value + string.Empty;
			   	txtbx_uom_1.Text = dt_grid.SelectedRows[0].Cells[13].Value + string.Empty;
			   	txtbx_uom_2.Text = dt_grid.SelectedRows[0].Cells[14].Value + string.Empty;
			   	
			   	line_no = dt_grid.SelectedRows[0].Cells[1].Value + string.Empty;
			   		   
			}
		}
				
		
		void Btn_postClick(object sender, EventArgs e)
		{	
//			if(!Check11am())
//			{
//				MessageBox.Show("Store PR only can post 11:00am);
//				return;
//			}
				
			
			CheckPost();
			
			//if (CheckPRRecord == "N")
			//{
				if(!sqlConnParm2("SP_PROD_CONV_STORE_POST"))
					return;
				
				
				
				if(!sqlConnParm2("SP_PROD_CONV_STORE_READY"))
					return;
			
				
				
			//}
			//else
				//MessageBox.Show("Store PR only can post 11:00am / 3:30pm");
			
			DataGrid();
			SentEmail();
			DialogBox.ShowSaveSuccessDialog();
			MessageBox.Show("Email sent");
		}
		
		bool sqlConnParm2(string sqlStatement)
		{
			SqlConnection con_data_post = new SqlConnection(sqlconn);
			SqlCommand cmd_data_post = new SqlCommand();
			
			try
			{
				cmd_data_post.Connection = con_data_post;
				cmd_data_post.CommandText = sqlStatement;
				cmd_data_post.CommandType = CommandType.StoredProcedure;
				
				cmd_data_post.Parameters.Add(new SqlParameter("@SP_JODOCNO", SqlDbType.NVarChar, 50));
				cmd_data_post.Parameters["@SP_JODOCNO"].Value = txtbx_ref_no.Text;
								
				cmd_data_post.Parameters.Add(new SqlParameter("@SP_JOUSER", SqlDbType.NVarChar, 50));
				cmd_data_post.Parameters["@SP_JOUSER"].Value = username.ToUpper();
					
				cmd_data_post.Parameters.Add(new SqlParameter("@SP_JOUSEREMAIL", SqlDbType.NVarChar, 50));
				cmd_data_post.Parameters["@SP_JOUSEREMAIL"].Value = frm_menu_system.email;
					
				cmd_data_post.Parameters.Add(new SqlParameter("@SP_JOUSERPC", SqlDbType.NVarChar, 50));
				cmd_data_post.Parameters["@SP_JOUSERPC"].Value = frm_menu_system.ipAddress;
					
				cmd_data_post.Parameters.Add(new SqlParameter("@SP_JOUSERDATETIME", SqlDbType.DateTime));
				cmd_data_post.Parameters["@SP_JOUSERDATETIME"].Value = DateTime.Now;
					
				cmd_data_post.Parameters.Add(new SqlParameter("@SP_JOUSERREVISION", SqlDbType.NVarChar, 50));
				cmd_data_post.Parameters["@SP_JOUSERREVISION"].Value = "0";

					
				con_data_post.Open();
				cmd_data_post.ExecuteNonQuery();
					
			} catch (Exception ex) {
				
				con_data_post.Close();
				MessageBox.Show("Error Converting Store Order Post \nCannot load DB \n" + ex.Message + ex.ToString());			
				return false;
			
			} finally {
				
				con_data_post.Close();				
			}
			
			con_data_post.Dispose();
			con_data_post = null;
			cmd_data_post = null;
			return true;
		}
		
		bool Check11am()
		{
			if(DateTime.Now.Hour >= 11)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		
		void SentEmail()
		{
		//------------------------------------------------------------------------------------------
		// BEGIN EMAIL NOTIFICATION
		//------------------------------------------------------------------------------------------
			string FromName = "AX2020 E-SERVICE";
			string FromEmail = "sbti.ax2020@gmail.com";
			string Subject = "STORE STOCK REQUISITION";
	
			SmtpClient smtp = new SmtpClient();
			smtp.Host = "smtp.gmail.com";
			smtp.Credentials = new System.Net.NetworkCredential("sbti.ax2020@gmail.com", "wsc4143pk");
			smtp.EnableSsl = true;
			smtp.Port = 587;
			//smtp.Port = 25;
	
			MailMessage msg = new MailMessage();
			msg.IsBodyHtml = true;
			msg.From = new MailAddress(FromEmail, FromName);
			
			msg.To.Add(new MailAddress("it-4@sbgroup.com.my", "Afiqah"));
			msg.To.Add(new MailAddress("samuel@sbgroup.com.my", "Samuel"));
			msg.To.Add(new MailAddress("it-2@sbgroup.com.my", "Kelvin"));
			

			msg.To.Add(new MailAddress("cath@sbgroup.com.my", "Catherine Teh"));
			msg.To.Add(new MailAddress("Kelly@sbgroup.com.my", "Kelly"));
			
			
			
			
	//
	//		if (txtbx_cust_type.Text == "LC") {
//			//--> Customer Service Local
//			msg.To.Add(new MailAddress("kelly@sbgroup.com.my", "Kelly Chan"));
//			msg.To.Add(new MailAddress("salesco-1@sbgroup.com.my", "Han Chok Min Jie"));
//			msg.To.Add(new MailAddress("salesco-1@sbgroup.com.my", "SalesCo1"));
//			msg.To.Add(new MailAddress("salesco-3@sbgroup.com.my", "SalesCo"));
//
//			if (StockCheckGlue == "N") {
//				//--> Store1806
//				//msg.To.Add(New MailAddress("logistic-8@sbgroup.com.my", "Fan Phong Lin"))
				//msg.To.Add(new MailAddress("ST963@sbgroup.com.my", "Suriani"));
				
//	in			
				msg.To.Add(new MailAddress("store-2@sbgroup.com.my", "Kalyani"));
				msg.To.Add(new MailAddress("store-9@sbgroup.com.my", "Chin Chin"));
				msg.To.Add(new MailAddress("logistic-5@sbgroup.com.my", "Arveenah"));
				msg.To.Add(new MailAddress("cyyong@sbgroup.com.my", "CY Yong"));
				msg.To.Add(new MailAddress("sosiaw@sbgroup.com.my", "SO Siaw"));
				
				
				
//			} else {
//				//--> Logistic
//				msg.To.Add(new MailAddress("logistic-5@sbgroup.com.my", "Arveenah"));
//				msg.To.Add(new MailAddress("store-4@sbgroup.com.my", "Shuairah "));
//				msg.To.Add(new MailAddress("store-7@sbgroup.com.my", "Hazlinda"));
//				msg.To.Add(new MailAddress("store-8@sbgroup.com.my", "Wong Wen Kuang"));
//				msg.To.Add(new MailAddress("logistic-10@sbgroup.com.my", "Jenny"));
//				msg.To.Add(new MailAddress("cyyong@sbgroup.com.my", "CY Yong"));
//				msg.To.Add(new MailAddress("sosiaw@sbgroup.com.my", "SO Siaw"));
//			}
//		
//			//--> Store1806
//			//msg.To.Add(New MailAddress("logistic-8@sbgroup.com.my", "Fan Phong Lin"))
//			msg.To.Add(new MailAddress("store-2@sbgroup.com.my", "Kalyani "));
//			msg.To.Add(new MailAddress("store-9@sbgroup.com.my", "Chin Chin"));
//			msg.To.Add(new MailAddress("logistic-5@sbgroup.com.my", "Arveenah"));
//
//			
//			//--> Logistic
//			msg.To.Add(new MailAddress("logistic-5@sbgroup.com.my", "Arveenah"));
//			msg.To.Add(new MailAddress("store-4@sbgroup.com.my", "Shuairah "));
//			msg.To.Add(new MailAddress("store-7@sbgroup.com.my", "Hazlinda"));
//			msg.To.Add(new MailAddress("store-8@sbgroup.com.my", "Wong Wen Kuang"));
//			msg.To.Add(new MailAddress("logistic-10@sbgroup.com.my", "Jenny"));
//			msg.To.Add(new MailAddress("cyyong@sbgroup.com.my", "CY Yong"));
//			msg.To.Add(new MailAddress("sosiaw@sbgroup.com.my", "SO Siaw"));
//		
				//in				
			msg.To.Add(new MailAddress("stacy@sbgroup.com.my", "Stacy Chooi"));			
			msg.To.Add(new MailAddress("yap@sbgroup.com.my", "Yap Hong Kee "));
			msg.To.Add(new MailAddress("slitting-1@sbgroup.com.my","Sufia"));
			msg.To.Add(new MailAddress("zuhaili.salehen@sbgroup.com.my","Ain Zuhaili"));
			msg.To.Add(new MailAddress("planner-5@sbgroup.com.my", "Jess Ng"));
			
			
//			
//		
		string EmailUserName = null;
		string EmailUserDept = null;
		
		EmailUserName = null;
		EmailUserDept = null;

		SqlConnection con_Check_Recepient = new SqlConnection(sqlconn);
		SqlCommand cmd_Check_Recepient = new SqlCommand();
		
		try
		{
			cmd_Check_Recepient.CommandText = "Select * from TBL_ADMIN_USER_ACCESS where sysusername ='" + username.ToUpper() + "'";
			cmd_Check_Recepient.Connection = con_Check_Recepient;
			con_Check_Recepient.Open();
			
			SqlDataReader rd_Check_Recepient = cmd_Check_Recepient.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
			
			if (rd_Check_Recepient.HasRows) 
			{
				if (rd_Check_Recepient.Read()) 
				{
					EmailUserName = rd_Check_Recepient["sysstaffname"].ToString();
					EmailUserDept = rd_Check_Recepient["sysdept"].ToString();
				}
			}
			} 
			catch (Exception ex) 
			{
				con_Check_Recepient.Close();
				
			} 
			finally 
			{
				con_Check_Recepient.Close();
			}
			
			con_Check_Recepient.Dispose();
			cmd_Check_Recepient.Dispose();
			con_Check_Recepient = null;
			cmd_Check_Recepient = null;
			
			msg.Subject = Subject;
			msg.Body = "Please be informed that " + EmailUserName + " submitted stock requisition as follows:\n\n";//Ref Number         Line Number StockCode      Desc1                             Desc2                             Qty Ordered\n";
			
			SqlDataAdapter thisAdapter = new SqlDataAdapter("Select JODOCNO, JOLINENO, JOSTOCKCODE, JOSTOCKDESC1, JOSTOCKDESC2, JOSTOCKQTYORDER from TBL_PROD_CONV_STORE_READY where JODOCNO = '" + txtbx_ref_no.Text + "' order by JOLINENO", sqlconn);
			//SqlDataAdapter thisAdapter = new SqlDataAdapter("Select JODOCNO, JOLINENO, JOSTOCKCODE, JOSTOCKDESC1, JOSTOCKDESC2, JOSTOCKQTYORDER from TBL_PROD_CONV_STORE_READY where JODOCNO = 'STORE20171208' order by JOLINENO", sqlconn);
			
			
			DataSet DataSet = new DataSet();
			
			thisAdapter.Fill(DataSet, "TBL_PROD_CONV_STORE_READY");
			
			msg.Body = msg.Body + "<table> <tr> <th>Ref Number</th> <th>Line Number</th> <th>StockCode</th> <th>Desc1</th> <th>Desc2</th> <th>Qty Ordered</th> </tr>";
			
			foreach (DataRow Row in DataSet.Tables["TBL_PROD_CONV_STORE_READY"].Rows)	
			{
			 	//msg.Body = msg.Body + "\n" + Row["JODOCNO"] + "  " + Row["JOLINENO"] + "  " + Row["JOSTOCKCODE"] + "  " + Row["JOSTOCKDESC1"] + "  " + Row["JOSTOCKDESC2"] + "  " + Row["JOSTOCKQTYORDER"]; 
			 	msg.Body = msg.Body + "<tr> <td>" + Row["JODOCNO"].ToString() + "</td> <td>" + Row["JOLINENO"].ToString() + "</td> <td>" + Row["JOSTOCKCODE"].ToString() + "</td> <td>" + Row["JOSTOCKDESC1"].ToString() + "</td> <td>" + Row["JOSTOCKDESC2"].ToString() + "</td> <td>" + Row["JOSTOCKQTYORDER"].ToString() + "</td> </tr>";
			}
			
			msg.Body = msg.Body + "</table>";
			msg.Body = msg.Body + "<br> <br> <br> <br>Thank you.<br> <br>AX2020 SO System Notification.";
			
			try
			{
				smtp.Send(msg);
			} 
			catch (FormatException ex) 
			{
				MessageBox.Show("Format Exception: " + ex.Message + ex.ToString());
				return;
			} 
			catch (SmtpException ex) 
			{
				MessageBox.Show("SMTP Exception:  " + ex.Message + ex.ToString());
				return;
			} 
			catch (Exception ex) 
			{
				MessageBox.Show("General Exception:  " + ex.Message + ex.ToString());
				return;
			}
			
			
		}
		
		void Button1Click(object sender, EventArgs e)
		{
			SentEmail();
			MessageBox.Show("Email resent");
		}
		
		void CheckPost()
		{
			//CheckPRRecord = null;
			//CheckPRRecord = "N";
			
			
			SqlConnection con_Check = new SqlConnection(sqlconn);
			SqlCommand cmd_Check = new SqlCommand();
			
			try
			{
				cmd_Check.CommandText = "Select * from TBL_PROD_CONV_STORE_READY where JODOCNO ='" + txtbx_ref_no.Text + "' and JOSTOCKSTATUS = '2'";
				cmd_Check.Connection = con_Check;
				con_Check.Open();
				
				SqlDataReader rd_Check = cmd_Check.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
				
				if (rd_Check.HasRows) 
				{
					if (rd_Check.Read()) 
					{
//						if (DateTime.Now.Hour > 15)
//							CheckPRRecord = "Y";
//						
//						else if (DateTime.Now.Hour > 11)
//							CheckPRRecord = "Y";
						
//						if(DateTime.Now.Hour > 11)
//						{
//							if(rd_Check["JOSTOCKSTATUS"] == "1")
//							{
//								CheckPRRecord = "Y";
//							}
//						}
//						if(DateTime.Now.Hour > 15)
//						{
//							if(rd_Check["JOSTOCKSTATUS"] == "2")
//							{
//								CheckPRRecord = "Y";
//							}
//						}
						MessageBox.Show("Post can be made two times per day only");
						return;
						
							
					}
				}
			} 
			catch (Exception ex) 
			{
				con_Check.Close();
					
			} 
			finally 
			{
				con_Check.Close();
			}
				
			con_Check.Dispose();
			cmd_Check.Dispose();
			con_Check = null;
			cmd_Check = null;
		}
		
		bool AlreadyPost()
		{
			
			SqlConnection con_Check = new SqlConnection(sqlconn);
			SqlCommand cmd_Check = new SqlCommand();
			
			try
			{
				cmd_Check.CommandText = "Select * from TBL_PROD_CONV_STORE_READY where JODOCNO ='" + txtbx_ref_no.Text + "'";
				cmd_Check.Connection = con_Check;
				con_Check.Open();
				
				SqlDataReader rd_Check = cmd_Check.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
				
				if (rd_Check.HasRows) 
				{
					if (rd_Check.Read()) 
					{
						return true;							
					}
				}
			} 
			catch (Exception ex) 
			{
				con_Check.Close();
					
			} 
			finally 
			{
				con_Check.Close();
			}
				
			con_Check.Dispose();
			cmd_Check.Dispose();
			con_Check = null;
			cmd_Check = null;
			
			return false;
		}
	}
}
