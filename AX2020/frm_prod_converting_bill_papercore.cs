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

namespace AX2020
{
	
	public partial class frm_prod_converting_bill_papercore : Form
	{
		public static string sqlconn = "Server=AX-UAT; Password=sbax2020sbg; User ID=sbax2020; Initial Catalog=SBG_AX_2020; Integrated Security=false";
		string username;
		
		public frm_prod_converting_bill_papercore()
		{
			
			InitializeComponent();
			this.ControlBox = false;
			username = frm_menu_system.userName; 
			lbl_username.Text = "User : " + username;
						
		}
		
		void DataGrid()
		{
			SqlConnection con_SP = new SqlConnection(sqlconn);
			SqlCommand cmd_SP = new SqlCommand();
				
			try 
			{
				cmd_SP.CommandText = @"SELECT DIA_LIST FROM TBL_PROD_CONV_JO_BOM_PCORE ORDER BY DIA_LIST";
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
				MessageBox.Show("Error Datagrid DB Cannot load DB" + ex.Message + ex.ToString());
				return;
			}
			finally
			{
				con_SP.Close();
				dt_grid.Columns[0].Name = "No";
	            dt_grid.Columns[0].Width = 50;
	            dt_grid.Columns[1].HeaderText = "Internal Diameter";	           	
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
				btn_save.Hide();
			   	txtbx_diameter.Text = dt_grid.SelectedRows[0].Cells[1].Value + string.Empty;
	
			   	//retrieve();  	
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
								
			       	if(sqlConnParm("SP_PROD_CONV_JO_BOM_PCORE_DEL"))
	            	{
			       		dt_grid.Rows.RemoveAt(this.dt_grid.SelectedRows[0].Index);
						DialogBox.ShowDeleteSuccessDialog();
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
					
					cmd_data.Parameters.Add(new SqlParameter("@SP_DIA_LIST", SqlDbType.NVarChar, 50));
					cmd_data.Parameters["@SP_DIA_LIST"].Value = txtbx_diameter.Text.ToUpper();

					
					cmd_data.Parameters.Add(new SqlParameter("@SP_USER", SqlDbType.NVarChar, 50));
					cmd_data.Parameters["@SP_USER"].Value = username.ToUpper();
					
					cmd_data.Parameters.Add(new SqlParameter("@SP_USEREMAIL", SqlDbType.NVarChar, 50));
					cmd_data.Parameters["@SP_USEREMAIL"].Value = frm_menu_system.email;
					
					cmd_data.Parameters.Add(new SqlParameter("@SP_USERPC", SqlDbType.NVarChar, 50));
					cmd_data.Parameters["@SP_USERPC"].Value = frm_menu_system.ipAddress;
					
					cmd_data.Parameters.Add(new SqlParameter("@SP_USERDATETIME", SqlDbType.DateTime));
					cmd_data.Parameters["@SP_USERDATETIME"].Value = DateTime.Now;
					
					cmd_data.Parameters.Add(new SqlParameter("@SP_USERREVISION", SqlDbType.NVarChar, 50));
					cmd_data.Parameters["@SP_USERREVISION"].Value = "0";

					
					con_data.Open();
					cmd_data.ExecuteNonQuery();
					
					
			} catch (Exception ex) {
				
				con_data.Close();
				MessageBox.Show("Error - Converting BOM PCORE Save DB \nCannot save data" + Environment.NewLine + ex.Message + ex.ToString());			
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
			
			if(!sqlConnParm("SP_PROD_CONV_JO_BOM_PCORE_ADD"))
				return;
			else
				DialogBox.ShowSaveSuccessDialog();
				DataGrid();
				ClearAllText(this);
				
		}
		
//		private void DropDownList(string cmd, ComboBox cbx_text, string col_name)
//		{
//		    SqlConnection conn = new SqlConnection(sqlconn);
//            DataTable ds = new DataTable();
//            string cmdSQL = cmd;
//            SqlDataAdapter sda = new SqlDataAdapter(cmdSQL, conn);
//
//            try
//            {
//                conn.Open();
//                sda.Fill(ds);
//                cbx_text.Text = "Please Select";
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
//               cbx_text.Items.Add(dr1[col_name].ToString());
//           	}
//            //cbx_jr_roll.DataSource = ds.Tables[0];
//            //cbx_jr_roll.DisplayMember = ds.Tables[0].Columns[0].ToString();
//            //cbx_jr_roll.SelectedIndex = 3;
//		}
		
		private bool Validation()
        {
                  
               if (CommonValidation.ValidateIsEmptyString(txtbx_diameter.Text.Trim()))
                {
                    DialogBox.ShowWarningMessage(lbl_diameter.Text + " cannot be empty.");
                    txtbx_diameter.Focus();
                   	
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
//      			if(c is ComboBox)
//                ((ComboBox)c).Text = "Please Select";

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
		
		void Frm_prod_converting_bill_papercoreLoad(object sender, EventArgs e)
		{
			DataGrid();
			btn_del.Hide();
		}
		

	}
}
