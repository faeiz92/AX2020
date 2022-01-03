using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic; // For generic collections like List.
using System.Data.SqlClient;      
using System.Data.Sql;
using System.Data;
using CommonFunction;
using CommonLibrary;
using CommonControl.Functions;
using System.Data.Sql;

namespace AX2020
{
	
	public partial class frm_prod_converting_bill : Form
	{
		public static string sqlconn3 = "Server=AX-SQL; Password=ax2020sbgroup; User ID=ax2020sb; Initial Catalog=AX2020StagingDB; Integrated Security=false";
		public static string sqlconn = "Server=AX-UAT; Password=sbax2020sbg; User ID=sbax2020; Initial Catalog=SBG_AX_2020; Integrated Security=false";
		public static string Sqlconn = "DSN=eb9gf;Port=2138;Uid=dba;Pwd=sql";
		string username, innerbx_code;
		bool clickDatarid = false;
		DataTable ds;
		
		public frm_prod_converting_bill()
		{
			InitializeComponent();
			this.ControlBox = false;
			username = frm_menu_system.userName; 
			lbl_username.Text = "User : " + username;
			
			DropDownList("SELECT * FROM TBL_PROD_CONV_JO_TAPE_END_LIST", cbx_tape_end, "TAPE_END_LIST");
			DropDownList("SELECT * FROM TBL_PROD_CONV_JO_PACK_1_LIST", cbx_pack_type, "PACK_1_LIST");
			DropDownList("SELECT * FROM TBL_PROD_CONV_JO_PACK_2_LIST", cbx_pack, "PACK_2_LIST");
			DropDownList("SELECT * FROM TBL_PROD_CONV_JO_PACK_3_LIST", cbx_tear, "PACK_3_LIST");
			DropDownList("SELECT * FROM TBL_PROD_CONV_JO_PALLET order by PALLET", cbx_pallet, "PALLET");
			//DropDownList("SELECT * FROM TBL_PROD_CONV_JO_CTN_BX_LIST order by CTN_BX_LIST", cbx_ctn_bx, "CTN_BX_LIST");
			//DropDownList("SELECT * FROM TBL_PROD_CONV_JO_INNER_BX_LIST order by INNER_BX_LIST", cbx_inner_bx, "INNER_BX_LIST");
			DropDownListCtnBxCode();
			DropDownListInnerBxCode();
		}
		
		void DataGrid()
		{
			SqlConnection con_SP = new SqlConnection(sqlconn);
			SqlCommand cmd_SP = new SqlCommand();
				
			try 
			{
				cmd_SP.CommandText = @"SELECT PROD_CODE, PROD_TAPEEND, PROD_PACK, PROD_TEAR, PROD_PACKTYPE, PROD_CTNBXCODE, PROD_CTNBX, PROD_INNERBX, PROD_PALLET FROM TBL_PROD_CONV_JO_BOM_R2 ORDER BY PROD_CODE";
				cmd_SP.Connection = con_SP;
				con_SP.Open();
				SqlDataAdapter dataadapter = new SqlDataAdapter(cmd_SP);	
								 
			    //DataSet ds = new DataSet();
			    ds = new DataTable();
			    dataadapter.Fill(ds);
				 
  				this.dt_grid.DataSource = ds;

			}
			catch(Exception ex)
			{
				MessageBox.Show("Error Datagrid DB Cannot load DB" + ex.Message + ex.ToString());
				return;
			}
			finally
			{
				con_SP.Close();
//				dt_grid.Columns[0].Name = "No";
//	            dt_grid.Columns[0].Width = 50;
	            dt_grid.Columns[0].HeaderText = "Product Code";
	            dt_grid.Columns[0].Width = 150;
	            dt_grid.Columns[1].HeaderText = "Tape End";
	            dt_grid.Columns[1].Width = 100;
	            dt_grid.Columns[2].HeaderText = "Pack";
			 	dt_grid.Columns[2].Width = 100;
			 	dt_grid.Columns[3].HeaderText = "Tear";
			 	dt_grid.Columns[3].Width = 50;
			 	
			 	dt_grid.Columns[4].HeaderText = "Pack Type";
			 	dt_grid.Columns[4].Width = 50;
			 	
			 	dt_grid.Columns[5].HeaderText = "Carton Box Code";
	            dt_grid.Columns[5].Width = 120;
			 	dt_grid.Columns[6].HeaderText = "Carton Box";
	            dt_grid.Columns[6].Width = 120;
	            dt_grid.Columns[7].HeaderText = "Inner Box";
				dt_grid.Columns[7].Width = 120;
	            dt_grid.Columns[8].HeaderText = "Pallet";	            
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
		
		void Dt_gridCellClick(object sender, DataGridViewCellEventArgs e)
		{
			if(dt_grid.SelectedRows.Count > 0) // make sure user select at least 1 row 
			{
				btn_del.Visible = true;
				btn_save.Visible = true;
				//btn_save.Hide();
			   	txtbx_prod_code.Text = dt_grid.SelectedRows[0].Cells[0].Value + string.Empty;
			   	cbx_tape_end.Text = dt_grid.SelectedRows[0].Cells[1].Value + string.Empty;
			   	cbx_pack.Text = dt_grid.SelectedRows[0].Cells[2].Value + string.Empty;
			   	cbx_tear.Text = dt_grid.SelectedRows[0].Cells[3].Value + string.Empty;
			   	
			   	cbx_pack_type.Text = dt_grid.SelectedRows[0].Cells[4].Value + string.Empty;
			   	cbx_ctn_bx_code.Text = dt_grid.SelectedRows[0].Cells[5].Value + string.Empty;
			   	txtbx_ctn_bx.Text = dt_grid.SelectedRows[0].Cells[6].Value + string.Empty;
			   	cbx_inner_bx.Text = dt_grid.SelectedRows[0].Cells[7].Value + string.Empty;
			   	cbx_pallet.Text = dt_grid.SelectedRows[0].Cells[8].Value + string.Empty;
			   	//retrieve();
				btn_del.Visible = true;
				clickDatarid = true;

			}
		}
		
		void Btn_delClick(object sender, EventArgs e)
		{
			if (!Validation())
                return;
			
			DialogResult del = new DialogResult();
            del = MessageBox.Show("Are you sure you want to delete it?", "Delete", 
                     MessageBoxButtons.YesNo, 
                     MessageBoxIcon.Warning, 
                     MessageBoxDefaultButton.Button2);
            if (del == DialogResult.Yes)
            {

				if (this.dt_grid.SelectedRows.Count > 0)
			    {
					if(cbx_inner_bx.Text != "-")
				{
					saveInnerBxCode();
				}
				else
					innerbx_code = "-";
								
			       	if(sqlConnParm("SP_PROD_CONV_JO_BOM_R2_DEL"))
	            	{
			       		dt_grid.Rows.RemoveAt(this.dt_grid.SelectedRows[0].Index);
						DialogBox.ShowDeleteSuccessDialog();
						ClearAllText(this);
						btn_save.Visible = true;
						btn_del.Visible = false;
						
	            	}
			       	else
			       		return;
							
			    }   
            	
            }
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
					
					cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_CODE", SqlDbType.NVarChar, 50));
					cmd_data.Parameters["@SP_PROD_CODE"].Value = txtbx_prod_code.Text.ToUpper();

					cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_TAPEEND", SqlDbType.NVarChar, 50));
					cmd_data.Parameters["@SP_PROD_TAPEEND"].Value = cbx_tape_end.Text.ToUpper();

					cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_PACK", SqlDbType.NVarChar, 50));
					cmd_data.Parameters["@SP_PROD_PACK"].Value = cbx_pack.Text.ToUpper();

					cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_TEAR", SqlDbType.NVarChar, 50));
					cmd_data.Parameters["@SP_PROD_TEAR"].Value = cbx_tear.Text.ToUpper();
					
					cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_PACKTYPE", SqlDbType.NVarChar, 50));
					cmd_data.Parameters["@SP_PROD_PACKTYPE"].Value = cbx_pack_type.Text.ToUpper();
					
					cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_CTNBXCODE", SqlDbType.NVarChar, 50));
					cmd_data.Parameters["@SP_PROD_CTNBXCODE"].Value = cbx_ctn_bx_code.Text;

					cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_CTNBX", SqlDbType.NVarChar, 150));
					cmd_data.Parameters["@SP_PROD_CTNBX"].Value = txtbx_ctn_bx.Text.ToUpper();
					
					cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_INNERBXCODE", SqlDbType.NVarChar, 100));
					cmd_data.Parameters["@SP_PROD_INNERBXCODE"].Value = innerbx_code;

					cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_INNERBX", SqlDbType.NVarChar, 100));
					cmd_data.Parameters["@SP_PROD_INNERBX"].Value = cbx_inner_bx.Text.ToUpper();
					
					cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_PALLET", SqlDbType.NVarChar, 100));
					cmd_data.Parameters["@SP_PROD_PALLET"].Value = cbx_pallet.Text.ToUpper();
					
					cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_ISSUEBY", SqlDbType.NVarChar, 50));
					cmd_data.Parameters["@SP_PROD_ISSUEBY"].Value = username.ToUpper();
					
					cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_USER", SqlDbType.NVarChar, 50));
					cmd_data.Parameters["@SP_PROD_USER"].Value = username.ToUpper();
					
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
					
					
			} catch (Exception ex) {
				
				con_data.Close();
				MessageBox.Show("Error - Converting BOM Save DB \nCannot save data" + Environment.NewLine + ex.Message + ex.ToString());			
				return false;
			
			} finally {
				
				con_data.Close();
					
			}
			
			con_data.Dispose();
			con_data = null;
			cmd_data = null;
			
			return true;
		}
		
		
		void Btn_saveClick(object sender, EventArgs e)
		{
			if(!Validation())
				return;
			
			if(cbx_inner_bx.Text != "-")
			{
				saveInnerBxCode();
			}
			else
				innerbx_code = "-";
			
			
			if (clickDatarid == true)
			{
				if(sqlConnParm("SP_PROD_CONV_JO_BOM_R2_EDIT"))
				{
					DialogBox.ShowSaveSuccessDialog();
					DataGrid();
					ClearAllText(this);
				}
			}
			else
			{
				if(!CheckDuplicate())
			
				return;
				
				if(sqlConnParm("SP_PROD_CONV_JO_BOM_R2_ADD"))
				{
					DialogBox.ShowSaveSuccessDialog();
					DataGrid();
					ClearAllText(this);
				}
			}
			
				
		}
		
//		void DropDownListCtnBxCode()
//		{
//			SqlConnection conn = new SqlConnection(sqlconn3);
//            DataTable ds = new DataTable();
//            string cmdSql = "select mcode, mdesc1, mdesc2, muom_p from stk where mmc = 'GF' and mcode like 'ZK%C%B%' and mstatus = 'A'";
//            SqlDataAdapter sda = new SqlDataAdapter(cmdSql, conn);
//
//            try
//            {
//                conn.Open();
//                sda.Fill(ds);
//                cbx_ctn_bx_code.Items.Add("Please Select");
//                cbx_ctn_bx_code.Items.Add("-");
//            
//            }catch(SqlException se)
//            {
//            	MessageBox.Show("Error - Converting BOM Dropdown \nCannot load DB \n" + se.ToString() + se.Message);
//            }
//            finally
//            {
//                conn.Close();
//            }
//			
//           	foreach(DataRow dr1 in ds.Rows)
//           	{
//               cbx_ctn_bx_code.Items.Add(dr1["mcode"].ToString());
//           	}
//           	cbx_ctn_bx_code.SelectedItem = "Please Select";
//
//		}
		
		void DropDownListCtnBxCode()
		{
			SqlConnection conn = new SqlConnection(sqlconn3);
            DataTable ds = new DataTable();
            string cmdSql = "select distinct itemid, DOT_DESCRIPTION from VIEW_AXERP_ITEM_MASTER where DATAAREAID = 'sbti' and itemid like 'ZK%C%B%'";
            SqlDataAdapter sda = new SqlDataAdapter(cmdSql, conn);

            try
            {
                conn.Open();
                sda.Fill(ds);
                cbx_ctn_bx_code.Items.Add("Please Select");
                cbx_ctn_bx_code.Items.Add("-");
            
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
               cbx_ctn_bx_code.Items.Add(dr1["itemid"].ToString());
           	}
           	cbx_ctn_bx_code.SelectedItem = "Please Select";

		}
		
		void DropDownListInnerBxCode()
		{
			SqlConnection conn = new SqlConnection(sqlconn3);
            DataTable ds = new DataTable();
            string cmdSql = "select distinct itemid, DOT_DESCRIPTION from VIEW_AXERP_ITEM_MASTER where DATAAREAID = 'sbti' and itemid like 'XZIB%'";
            SqlDataAdapter sda = new SqlDataAdapter(cmdSql, conn);

            try
            {
                conn.Open();
                sda.Fill(ds);
                cbx_inner_bx.Items.Add("Please Select");
                cbx_inner_bx.Items.Add("-");
            
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
           		cbx_inner_bx.Items.Add(dr1["DOT_DESCRIPTION"].ToString());//  +  dr1["mdesc2"].ToString());
           	}
           	cbx_inner_bx.SelectedItem = "Please Select";

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
                cbx_text.Items.Add("Please Select");
            
            }
            catch(SqlException se)
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
            cbx_text.SelectedItem = "Please Select";
		}
		
		void saveInnerBxCode()
		{
			string ERP_ST_P1_objSqlStatement = "select top 1 * from VIEW_AXERP_ITEM_MASTER where DATAAREAID = 'sbti' and itemid like 'XZIB%' and DOT_Description = '" + cbx_inner_bx.Text + "'";
        	SqlConnection ERP_ST_P1_objConn = new SqlConnection(sqlconn3);
               
			try
 			{
            	ERP_ST_P1_objConn.Open();
                SqlCommand ERP_ST_P1_objCMD = new SqlCommand(ERP_ST_P1_objSqlStatement, ERP_ST_P1_objConn);
               	SqlDataReader ERP_ST_P1_objDR  = ERP_ST_P1_objCMD.ExecuteReader();            	
            	
            	if (ERP_ST_P1_objDR.HasRows)
            	{
            		while (ERP_ST_P1_objDR.Read())
            		{
            			innerbx_code = ERP_ST_P1_objDR["itemid"].ToString();
            			
            		} 
            	}
            	else
            	{
            		MessageBox.Show("Error - Converting JO BOM Save Inner Bx \nCannot find Stock Code");
            		return;
            	}

            	//ERP_ST_P1_objDR.Close();
 			} 
 			
 			catch (Exception ERP_ST_P1_exc)
 			{
 				MessageBox.Show("Error - Converting JO BOM Save Inner Bx\nCannot load DB" + ERP_ST_P1_exc.Message + ERP_ST_P1_exc.ToString());
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
		}
		
		private bool Validation()
        {
                  
               if (CommonValidation.ValidateIsEmptyString(txtbx_prod_code.Text.Trim()))
                {
                    DialogBox.ShowWarningMessage(lbl_prod_code.Text + " cannot be empty.");
                    txtbx_prod_code.Focus();
                   	
                    return false;
                }
              
               else if (CommonValidation.ValidateIsEmptyString(cbx_tape_end.Text.Trim()) || cbx_tape_end.Text == "Please Select")
                {
                    DialogBox.ShowWarningMessage(lbl_tape_end.Text + " cannot be empty.");
                    cbx_tape_end.Focus();
                   	
                    return false;
                   
                }
               
               else if (CommonValidation.ValidateIsEmptyString(cbx_pack.Text.Trim()) || cbx_pack.Text == "Please Select")
                {
                    DialogBox.ShowWarningMessage(lbl_pack.Text + " cannot be empty.");
                    cbx_pack.Focus();
                   	
                    return false;
                    
                }
               
               else if (CommonValidation.ValidateIsEmptyString(cbx_tear.Text.Trim()) || cbx_tear.Text == "Please Select")
                {
                    DialogBox.ShowWarningMessage(lbl_tear.Text + " cannot be empty.");
                    cbx_tear.Focus();
                   	
                    return false;
                    
                }
               
               else if (CommonValidation.ValidateIsEmptyString(cbx_ctn_bx_code.Text.Trim()) || cbx_ctn_bx_code.Text == "Please Select")
                {
                    DialogBox.ShowWarningMessage(lbl_ctn_bx_code.Text + " cannot be empty.");
                    cbx_ctn_bx_code.Focus();
                   	
                    return false;
                    
                }
               
               else if (CommonValidation.ValidateIsEmptyString(txtbx_ctn_bx.Text.Trim()))
                {
                    DialogBox.ShowWarningMessage(lbl_ctn_bx.Text + " cannot be empty.");
                    txtbx_ctn_bx.Focus();
                   	
                    return false;
                    
                }
               
               else if (CommonValidation.ValidateIsEmptyString(cbx_inner_bx.Text.Trim()) || cbx_inner_bx.Text == "Please Select")
                {
                    DialogBox.ShowWarningMessage(lbl_inner_bx.Text + " cannot be empty.");
                    cbx_inner_bx.Focus();
                   	
                    return false;
                    
                }
               
               else if (CommonValidation.ValidateIsEmptyString(cbx_pack_type.Text.Trim()) || cbx_pack_type.Text == "Please Select")
                {
                    DialogBox.ShowWarningMessage(lbl_pack_type.Text + " cannot be empty.");
                    cbx_pack_type.Focus();
                   	
                    return false;
                    
                }
               
               else if (CommonValidation.ValidateIsEmptyString(cbx_pallet.Text.Trim()) || cbx_pallet.Text == "Please Select")
                {
                    DialogBox.ShowWarningMessage(lbl_pallet.Text + " cannot be empty.");
                    cbx_pallet.Focus();
                   	
                    return false;
                    
                }
               
               
               
               
               return true;
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
                ((ComboBox)c).SelectedItem = "Please Select";
      				//((ComboBox)c).Dat

   			}
		}
		
		void Btn_clearClick(object sender, EventArgs e)
		{
			ClearAllText(this);
			btn_save.Visible = true;
			btn_del.Hide();			
		}	
		
		void Btn_cancelClick(object sender, EventArgs e)
		{
			this.Close();    
		}
		
		void Frm_prod_converting_billLoad(object sender, EventArgs e)
		{
			
			DataGrid();
			btn_del.Visible = false;
		}
		
		bool CheckDuplicate()
		{
			if(txtbx_prod_code.Text.ToUpper().Substring(txtbx_prod_code.Text.Length - 2) == "M2" || txtbx_prod_code.Text.ToUpper() == "P/OPP(1COL)")
			{
				return true;
			}
			else
			{			
				SqlConnection con_Check_Duplicate_JO = new SqlConnection(sqlconn);
				SqlCommand cmd = new SqlCommand();
				
				try 
				{
					cmd.CommandText = @"select PROD_CODE, PROD_CTNBXCODE from TBL_PROD_CONV_JO_BOM_r2 where PROD_CODE = @prod_code and PROD_CTNBXCODE = @prod_ctnbx_code";
					cmd.Parameters.AddWithValue("@prod_code",  txtbx_prod_code.Text.ToUpper());
					cmd.Parameters.AddWithValue("@prod_ctnbx_code", cbx_ctn_bx_code.Text);
					cmd.Connection = con_Check_Duplicate_JO;
					con_Check_Duplicate_JO.Open();
					SqlDataReader rd_Check_Duplicate_JO = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
	
					if (rd_Check_Duplicate_JO.HasRows)
					{
						if (rd_Check_Duplicate_JO.Read())
						{
							MessageBox.Show("Combination of Bill of Material already exist");
							return false;
						}
					}
				}
				catch (Exception ex)
				{
					con_Check_Duplicate_JO.Close();
					MessageBox.Show("Error - Converting BOM Duplicate " + ex.Message + ex.ToString());
					return false;
				} 
				finally 
				{
					con_Check_Duplicate_JO.Close();
				}
				
				con_Check_Duplicate_JO.Dispose();
				cmd.Dispose();
				con_Check_Duplicate_JO = null;
				cmd = null;
				return true;
			}
		}
		
		
		void Cbx_ctn_bx_codeSelectionChangeCommitted(object sender, EventArgs e)
		{
			if(cbx_ctn_bx_code.Text == "Please Select")
			{
				txtbx_ctn_bx.Text = string.Empty;
				return;
			}
			else if(cbx_ctn_bx_code.Text == "-")
			{
				txtbx_ctn_bx.Text = "-";
				return;
			}
			
			string ERP_ST_P1_objSqlStatement = "select top 1 * from VIEW_AXERP_ITEM_MASTER where DATAAREAID = 'sbti' and itemid = '" + cbx_ctn_bx_code.Text + "'";
			SqlConnection ERP_ST_P1_objConn = new SqlConnection(sqlconn3);
               
			try
 			{
            	ERP_ST_P1_objConn.Open();
                SqlCommand ERP_ST_P1_objCMD = new SqlCommand(ERP_ST_P1_objSqlStatement, ERP_ST_P1_objConn);
               	SqlDataReader ERP_ST_P1_objDR  = ERP_ST_P1_objCMD.ExecuteReader();            	
            	
            	if (ERP_ST_P1_objDR.HasRows)
            	{
            		while (ERP_ST_P1_objDR.Read())
            		{
            			txtbx_ctn_bx.Text = ERP_ST_P1_objDR["DOT_Description"].ToString();// + " " + ERP_ST_P1_objDR["mdesc2"].ToString();
            		} 
            	}
            	else
            	{
            		MessageBox.Show("Error - Converting BOM Ctn Bx \nCannot find BOM");
            		return;
            	}

            	//ERP_ST_P1_objDR.Close();
 			} 
 			
 			catch (Exception ERP_ST_P1_exc)
 			{
 				MessageBox.Show("Error - Converting BOM Ctn Bx \nCannot load DB" + ERP_ST_P1_exc.Message + ERP_ST_P1_exc.ToString());
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
		}
		
		
		
		void Txtbx_stock_codeKeyUp(object sender, KeyEventArgs e)
		{
			//DataTable ds = new DataTable();
			ds.DefaultView.RowFilter = "PROD_CODE LIKE '%" + txtbx_stock_code.Text + "%'";
   			this.dt_grid.DataSource = ds.DefaultView;
		}
		
			
		void Txtbx_ctn_bx_searchKeyUp(object sender, KeyEventArgs e)
		{
			ds.DefaultView.RowFilter = "PROD_CTNBX LIKE '%" + txtbx_ctn_bx_search.Text + "%'";
   			this.dt_grid.DataSource = ds.DefaultView;
		}
	}
}
