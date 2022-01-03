using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Data.SqlClient;      // For the database connections and objects.
using System.Data.Sql;
using System.Data;
using CommonFunction;
using CommonLibrary;
using CommonControl.Functions;

namespace AX2020
{
	public partial class frm_prod_coating_store : Form
	{	
		public static string sqlconn = "Server=AX-UAT; Password=sbax2020sbg; User ID=sbax2020; Initial Catalog=SBG_AX_2020; Integrated Security=false";
		string username;
		int NextNo;
		string line_no;
		
		public frm_prod_coating_store()
		{
					
			InitializeComponent();
			this.ControlBox = false;
			username = frm_menu_system.userName; 
			//lbl_username.Text = "User : " + username;
			//string line_no;
			
//			btn_save.Visible = false;
//			//btn_clear.Visible = false;
//			btn_cancel.Visible = true;
//			btn_cancel.Location = new Point(445, 610);
			
		//	DropDownList("SELECT * FROM TBL_PROD_CONV_JO_STORE_REQUEST_BY order by REQUESTBY", cbx_requested_by, "REQUESTBY");
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
            	MessageBox.Show("Error - Coating BOM Dropdown \nCannot load DB \n" + se.ToString() + se.Message);
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
				cmd_SP.CommandText = @"SELECT JOLINENO, JODOCNO, JOSTOCKCODE, JOSTOCKDESC1, JOSTOCKDESC2, JOSTOCKCOLOR, JOSTOCKBRAND, JOSTOCKWIDTH, JOSTOCKLENGTH, JOSTOCKMICRON, JOSTOCKCONVERSION, JOSTOCKQTYORDER, JOSTOCKUOM1, JOSTOCKUOM2 FROM TBL_PROD_COAT_STORE";
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
	            dt_grid.Columns[12].HeaderText = "Qty Ordered (jr)";
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
		
		void Dt_gridCellClick(object sender, DataGridViewCellEventArgs e)
		{
			if(dt_grid.SelectedRows.Count > 0) // make sure user select at least 1 row 
			{
			   	txtbx_ref_no.Text = dt_grid.SelectedRows[0].Cells[2].Value + string.Empty;
			   	txtbx_ref_no.Text = dt_grid.SelectedRows[0].Cells[2].Value + string.Empty;
			   	txtbx_ref_no.Text = dt_grid.SelectedRows[0].Cells[2].Value + string.Empty;
			   	txtbx_ref_no.Text = dt_grid.SelectedRows[0].Cells[2].Value + string.Empty;
			   	txtbx_ref_no.Text = dt_grid.SelectedRows[0].Cells[2].Value + string.Empty;
			   	txtbx_ref_no.Text = dt_grid.SelectedRows[0].Cells[2].Value + string.Empty;
			   	txtbx_ref_no.Text = dt_grid.SelectedRows[0].Cells[2].Value + string.Empty;
			   	txtbx_ref_no.Text = dt_grid.SelectedRows[0].Cells[2].Value + string.Empty;
			   	txtbx_ref_no.Text = dt_grid.SelectedRows[0].Cells[2].Value + string.Empty;
			   	txtbx_ref_no.Text = dt_grid.SelectedRows[0].Cells[2].Value + string.Empty;
			   			   	
			}
 
		}
		
		
		
		
		void Btn_saveClick(object sender, EventArgs e)
		{
			if (!Validation())
                return;

			if(DocNoGenerator() & sqlConnParm("SP_PROD_COAT_STORE_ADD"))
			{
			 	DialogBox.ShowSaveSuccessDialog();
				DataGrid();
			}
			else 
				return;
		}
		
		private bool DocNoGenerator()
		{

			SqlConnection conNextNumber = new SqlConnection(sqlconn);
			SqlCommand cmdNextNumber = new SqlCommand();

			try
			{
					cmdNextNumber.CommandText = "Select JoStoreCoatNextnumber from TBL_ADMIN_NEXT_NUMBER";
					cmdNextNumber.Connection = conNextNumber;

					conNextNumber.Open();
					SqlDataReader rdNextNumber = cmdNextNumber.ExecuteReader(System.Data.CommandBehavior.CloseConnection);

					rdNextNumber.Read();
					NextNo = Convert.ToInt32(rdNextNumber["JoStoreCoatNextnumber"]);
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
			SqlConnection conUpdateNextNumber = new SqlConnection(sqlconn);
			SqlCommand cmdUpdateNextNumber = new SqlCommand();

			try
			{
				cmdUpdateNextNumber.CommandText = "update TBL_ADMIN_NEXT_NUMBER set JoStoreCoatNextnumber = JoStoreCoatNextnumber + 1";
				
				cmdUpdateNextNumber.Connection = conUpdateNextNumber;

				conUpdateNextNumber.Open();
				cmdUpdateNextNumber.ExecuteNonQuery();

			}
			catch (Exception ex)
			{
				conUpdateNextNumber.Close();
				MessageBox.Show("Error - Converting JO Next Number DB \nCannot update next number \n" + ex.Message + ex.ToString());
				return false;
			}
			finally 
			{
				conUpdateNextNumber.Close();
			}

			conUpdateNextNumber.Dispose();
			conUpdateNextNumber = null;
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
					cmd_data.Parameters["@SP_JOSTOCKCONVERSION"].Value = 0;
					
					cmd_data.Parameters.Add(new SqlParameter("@SP_JOSTOCKUOM1", SqlDbType.NVarChar, 10));
					cmd_data.Parameters["@SP_JOSTOCKUOM1"].Value = txtbx_uom_1.Text;

					cmd_data.Parameters.Add(new SqlParameter("@SP_JOSTOCKUOM2", SqlDbType.NVarChar, 10));
					cmd_data.Parameters["@SP_JOSTOCKUOM2"].Value = txtbx_uom_2.Text;

					cmd_data.Parameters.Add(new SqlParameter("@SP_JOLINENO", SqlDbType.NVarChar, 50));
					cmd_data.Parameters["@SP_JOLINENO"].Value = NextNo;
					
					cmd_data.Parameters.Add(new SqlParameter("@SP_JODOCNO", SqlDbType.NVarChar, 50));
					cmd_data.Parameters["@SP_JODOCNO"].Value = txtbx_ref_no.Text.ToUpper();
					
					cmd_data.Parameters.Add(new SqlParameter("@SP_JOSTOCKQTYORDER", SqlDbType.NVarChar, 50));
					cmd_data.Parameters["@SP_JOSTOCKQTYORDER"].Value = txtbx_qty_order.Text.ToUpper();
					
					cmd_data.Parameters.Add(new SqlParameter("@SP_JOREQUESTEDBY", SqlDbType.NVarChar, 50));
					cmd_data.Parameters["@SP_JOREQUESTEDBY"].Value = username;
					
					cmd_data.Parameters.Add(new SqlParameter("@SP_JOISSUEBY", SqlDbType.NVarChar, 50));
					cmd_data.Parameters["@SP_JOISSUEBY"].Value = username;
					
					cmd_data.Parameters.Add(new SqlParameter("@SP_JOUSER", SqlDbType.NVarChar, 50));
					cmd_data.Parameters["@SP_JOUSER"].Value = "0";
					
					cmd_data.Parameters.Add(new SqlParameter("@SP_JOUSEREMAIL", SqlDbType.NVarChar, 50));
					cmd_data.Parameters["@SP_JOUSEREMAIL"].Value = frm_menu_system.email;
					
					cmd_data.Parameters.Add(new SqlParameter("@SP_JOUSERPC", SqlDbType.NVarChar, 50));
					cmd_data.Parameters["@SP_JOUSERPC"].Value = frm_menu_system.ipAddress;
					
					cmd_data.Parameters.Add(new SqlParameter("@SP_JOUSERDATETIME", SqlDbType.DateTime));
					cmd_data.Parameters["@SP_JOUSERDATETIME"].Value = DateTime.Now;
					
					cmd_data.Parameters.Add(new SqlParameter("@SP_JOUSERREVISION", SqlDbType.NVarChar, 50));
					cmd_data.Parameters["@SP_JOUSERREVISION"].Value = "0";

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
        	
        	SqlConnection con_SP1 = new SqlConnection(sqlconn);
			SqlCommand cmd_SP1 = new SqlCommand();
			
			try 
			{
				cmd_SP1.CommandText = @"select * from TBL_PROD_STOCK_CODE where PROD_STOCKCODE = @stock_code";
				cmd_SP1.Parameters.AddWithValue("@stock_code",  txtbx_stock_code.Text.ToUpper());
				
				cmd_SP1.Connection = con_SP1;
				con_SP1.Open();
				SqlDataReader rd_SP1 = cmd_SP1.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
				
				if (rd_SP1.Read())
				{	
		        	//ref_no = txtbx_ref_no.Text;
		        	
					txtbx_stock_code.Text = rd_SP1["PROD_STOCKCODE"].ToString();
					txtbx_desc_1.Text = rd_SP1["PROD_DESC1"].ToString();
					txtbx_desc_2.Text = rd_SP1["PROD_DESC2"].ToString();
					txtbx_color.Text = rd_SP1["PROD_COLOR"].ToString();
					txtbx_brand.Text = rd_SP1["PROD_BRAND"].ToString();
					txtbx_width.Text = rd_SP1["PROD_WIDTH"].ToString();
					txtbx_length.Text = rd_SP1["PROD_LENGTH"].ToString();
					txtbx_mic.Text = rd_SP1["PROD_MIC"].ToString();
					//txtbx_conversion.Text = rd_SP1["PROD_CONVERSION"].ToString();
					//txtbx_ref_no
					txtbx_uom_1.Text = rd_SP1["PROD_UOM1"].ToString();
					txtbx_uom_2.Text = rd_SP1["PROD_UOM2"].ToString();
					
	
				} 
				else 
				{
					MessageBox.Show("Error - Converting Store Jo Search \nCannot find JO!");
					return;
				}
			} 
			catch (Exception ex) 
			{
				MessageBox.Show("Error - Coating Store Jo Search \nCannot load DB!" + ex.Message + ex.ToString());
				return;
			} 
			finally 
			{
				con_SP1.Close();
			}
			
			con_SP1.Dispose();
			con_SP1 = null;
			cmd_SP1 = null;	
					
		}
			
		
		void Frm_prod_coating_storeLoad(object sender, EventArgs e)
		{
			txtbx_ref_no.Text = "STORE" + DateTime.Now.ToString("yyyyMMdd");
			DataGrid();
		}
		
		
		
		
		void Dt_gridCellContentClick(object sender, DataGridViewCellEventArgs e)
		{
//			if(dt_grid.SelectedRows.Count > 0) // make sure user select at least 1 row 
			{
				//btn_del.Visible = true;
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
			   	//txtbx_conversion.Text = dt_grid.SelectedRows[0].Cells[11].Value + string.Empty;
			   	txtbx_qty_order.Text = dt_grid.SelectedRows[0].Cells[12].Value + string.Empty;
			   	txtbx_uom_1.Text = dt_grid.SelectedRows[0].Cells[13].Value + string.Empty;
			   	txtbx_uom_2.Text = dt_grid.SelectedRows[0].Cells[14].Value + string.Empty;
			   	
			   	line_no = dt_grid.SelectedRows[0].Cells[1].Value + string.Empty;
			   		   
			}
		}
		
		
		
		
		void Btn_deleteClick(object sender, EventArgs e)
		{
			//MessageBox.Show(line_no.ToString());
			SqlConnection con_Check_Duplicate_JO = new SqlConnection(sqlconn);
			SqlCommand cmd_Check_Duplicate_JO = new SqlCommand();
			try 
			{
				cmd_Check_Duplicate_JO.CommandText = @"select * from TBL_PROD_COAT_JO where JODOCNO = @doc_no + '-' + @line_no ";
				cmd_Check_Duplicate_JO.Parameters.AddWithValue("@doc_no",  txtbx_ref_no.Text);
				cmd_Check_Duplicate_JO.Parameters.AddWithValue("@line_no",  line_no);
				cmd_Check_Duplicate_JO.Connection = con_Check_Duplicate_JO;
				con_Check_Duplicate_JO.Open();
				SqlDataReader rd_Check_Duplicate_JO = cmd_Check_Duplicate_JO.ExecuteReader(System.Data.CommandBehavior.CloseConnection);

				if (rd_Check_Duplicate_JO.HasRows)
				{
					if (rd_Check_Duplicate_JO.Read())
					{
						MessageBox.Show("Cannot delete JO No already exist");
						return;
					}

				}
			}
			catch (Exception ex)
			{
				con_Check_Duplicate_JO.Close();
				MessageBox.Show("Error - Coating Store JO Duplicate " + ex.Message + ex.ToString());
				return;
			} 
			finally 
			{
				con_Check_Duplicate_JO.Close();
			}
			
			con_Check_Duplicate_JO.Dispose();
			cmd_Check_Duplicate_JO.Dispose();
			con_Check_Duplicate_JO = null;
			cmd_Check_Duplicate_JO = null;
			
			
			
			SqlConnection con_data_del = new SqlConnection (sqlconn);
			System.Data.SqlClient.SqlCommand cmd_data_del = new SqlCommand();  //adress pergi ke sql
			try {

				cmd_data_del.Connection = con_data_del;		//coman run store procedure
				cmd_data_del.CommandText = "SP_PROD_COAT_STORE_DEL";	//nama store procedure
				cmd_data_del.CommandType = CommandType.StoredProcedure;		//declare comand
    	
				cmd_data_del.Parameters.Add(new SqlParameter("@SP_JOSTOCKCODE", SqlDbType.NVarChar, 50));
				cmd_data_del.Parameters["@SP_JOSTOCKCODE"].Value = txtbx_stock_code.Text.ToUpper();
					
				cmd_data_del.Parameters.Add(new SqlParameter("@SP_JOSTOCKDESC1", SqlDbType.NVarChar, 50));
				cmd_data_del.Parameters["@SP_JOSTOCKDESC1"].Value = txtbx_desc_1.Text.ToUpper();
					
				cmd_data_del.Parameters.Add(new SqlParameter("@SP_JOSTOCKDESC2", SqlDbType.NVarChar, 50));
				cmd_data_del.Parameters["@SP_JOSTOCKDESC2"].Value = txtbx_desc_2.Text.ToUpper();

				cmd_data_del.Parameters.Add(new SqlParameter("@SP_JOSTOCKCOLOR", SqlDbType.NVarChar, 50));
				cmd_data_del.Parameters["@SP_JOSTOCKCOLOR"].Value = txtbx_color.Text.ToUpper();

				cmd_data_del.Parameters.Add(new SqlParameter("@SP_JOSTOCKBRAND", SqlDbType.NVarChar, 50));
				cmd_data_del.Parameters["@SP_JOSTOCKBRAND"].Value = txtbx_brand.Text.ToUpper();

				cmd_data_del.Parameters.Add(new SqlParameter("@SP_JOSTOCKWIDTH", SqlDbType.Float));
				cmd_data_del.Parameters["@SP_JOSTOCKWIDTH"].Value = Double.Parse(txtbx_width.Text);

				cmd_data_del.Parameters.Add(new SqlParameter("@SP_JOSTOCKLENGTH ", SqlDbType.Float));
				cmd_data_del.Parameters["@SP_JOSTOCKLENGTH "].Value = Double.Parse(txtbx_length.Text);

				cmd_data_del.Parameters.Add(new SqlParameter("@SP_JOSTOCKMICRON", SqlDbType.Float));
				cmd_data_del.Parameters["@SP_JOSTOCKMICRON"].Value = Double.Parse(txtbx_mic.Text);

				cmd_data_del.Parameters.Add(new SqlParameter("@SP_JOSTOCKCONVERSION", SqlDbType.Float));
				cmd_data_del.Parameters["@SP_JOSTOCKCONVERSION"].Value = 0;
					
				cmd_data_del.Parameters.Add(new SqlParameter("@SP_JOSTOCKUOM1", SqlDbType.NVarChar, 10));
				cmd_data_del.Parameters["@SP_JOSTOCKUOM1"].Value = txtbx_uom_1.Text;

				cmd_data_del.Parameters.Add(new SqlParameter("@SP_JOSTOCKUOM2", SqlDbType.NVarChar, 10));
				cmd_data_del.Parameters["@SP_JOSTOCKUOM2"].Value = txtbx_uom_2.Text;

				cmd_data_del.Parameters.Add(new SqlParameter("@SP_JOLINENO", SqlDbType.NVarChar, 50));
				cmd_data_del.Parameters["@SP_JOLINENO"].Value = line_no;
					
				cmd_data_del.Parameters.Add(new SqlParameter("@SP_JODOCNO", SqlDbType.NVarChar, 50));
				cmd_data_del.Parameters["@SP_JODOCNO"].Value = txtbx_ref_no.Text.ToUpper();
					
				cmd_data_del.Parameters.Add(new SqlParameter("@SP_JOSTOCKQTYORDER", SqlDbType.NVarChar, 50));
				cmd_data_del.Parameters["@SP_JOSTOCKQTYORDER"].Value = txtbx_qty_order.Text.ToUpper();
					
				cmd_data_del.Parameters.Add(new SqlParameter("@SP_JOREQUESTEDBY", SqlDbType.NVarChar, 50));
				cmd_data_del.Parameters["@SP_JOREQUESTEDBY"].Value = username;
					
				cmd_data_del.Parameters.Add(new SqlParameter("@SP_JOISSUEBY", SqlDbType.NVarChar, 50));
				cmd_data_del.Parameters["@SP_JOISSUEBY"].Value = username;
					
				cmd_data_del.Parameters.Add(new SqlParameter("@SP_JOUSER", SqlDbType.NVarChar, 50));
				cmd_data_del.Parameters["@SP_JOUSER"].Value = "0";
					
				cmd_data_del.Parameters.Add(new SqlParameter("@SP_JOUSEREMAIL", SqlDbType.NVarChar, 50));
				cmd_data_del.Parameters["@SP_JOUSEREMAIL"].Value = frm_menu_system.email;
					
				cmd_data_del.Parameters.Add(new SqlParameter("@SP_JOUSERPC", SqlDbType.NVarChar, 50));
				cmd_data_del.Parameters["@SP_JOUSERPC"].Value = frm_menu_system.ipAddress;
					
				cmd_data_del.Parameters.Add(new SqlParameter("@SP_JOUSERDATETIME", SqlDbType.DateTime));
				cmd_data_del.Parameters["@SP_JOUSERDATETIME"].Value = DateTime.Now;
					
				cmd_data_del.Parameters.Add(new SqlParameter("@SP_JOUSERREVISION", SqlDbType.NVarChar, 50));
				cmd_data_del.Parameters["@SP_JOUSERREVISION"].Value = "0";
					
					
				con_data_del.Open();
				cmd_data_del.ExecuteNonQuery();
				cmd_data_del.Parameters.Clear();
					
				//dt_grid.Update();
				//dt_grid.Refresh();
			}
				
				
			catch (Exception ex) 
			{
				con_data_del.Close();
				MessageBox.Show("ERROR ? " + ex.Message + ex.ToString());
				return;
			} 
			finally 
			{
				con_data_del.Close();
			}
			con_data_del.Dispose();
			con_data_del = null;
			cmd_data_del = null;
			
			DialogBox.ShowWarningMessage(" successfull del.");
			DataGrid();
			}
		
		
			
		
	}
}
