using System;
using System.Drawing;
using System.Windows.Forms;
using System.Data;
using CommonFunction;
using CommonLibrary;
using CommonControl.Functions;
using System.Data.SqlClient;      
using System.Data.Sql;
using System.Collections.Generic;

namespace AX2020
{
	
	public partial class frm_admin_factory : Form
	{
		public static string sqlconn = "Server=AX-UAT; Password=sbax2020sbg; User ID=sbax2020; Initial Catalog=SBG_AX_2020; Integrated Security=false";
		string username;
		
		public frm_admin_factory()
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
				cmd_SP.CommandText = @"SELECT sysstaffid, sysstaffname, sysdept, sysnation FROM TBL_ADMIN_USER_FACTORY ORDER BY sysstaffname";
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
	            dt_grid.Columns[0].Width = 35;
	            dt_grid.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;	
	            dt_grid.Columns[1].HeaderText = "Staff ID";
	            dt_grid.Columns[1].Width = 100;
	            dt_grid.Columns[2].HeaderText = "Staff Name";
	            dt_grid.Columns[2].Width = 400;
	            dt_grid.Columns[3].HeaderText = "Department";
			 	dt_grid.Columns[3].Width = 200;
			 	dt_grid.Columns[4].HeaderText = "Nationality";
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
		
		bool sqlConnParm(string sqlStatement)
		{
			SqlConnection con_data = new SqlConnection(sqlconn);
			SqlCommand cmd_data = new SqlCommand();
			
			try
			{
					cmd_data.Connection = con_data;
					cmd_data.CommandText = sqlStatement;
					cmd_data.CommandType = CommandType.StoredProcedure;
					
					
					cmd_data.Parameters.Add(new SqlParameter("@SP_sysstaffid", SqlDbType.NVarChar, 20));
					cmd_data.Parameters["@SP_sysstaffid"].Value = cbx_dept.Text;
					
					cmd_data.Parameters.Add(new SqlParameter("@SP_sysstaffname", SqlDbType.NVarChar, 50));
					cmd_data.Parameters["@SP_sysstaffname"].Value = txtbx_name.Text.ToUpper();

					cmd_data.Parameters.Add(new SqlParameter("@SP_sysdept", SqlDbType.NVarChar, 20));
					cmd_data.Parameters["@SP_sysdept"].Value = cbx_dept.Text;

					cmd_data.Parameters.Add(new SqlParameter("@SP_sysnation", SqlDbType.NVarChar, 20));
					cmd_data.Parameters["@SP_sysnation"].Value = cbx_nation.Text;

					cmd_data.Parameters.Add(new SqlParameter("@SP_sysstatus", SqlDbType.NVarChar, 5));
					cmd_data.Parameters["@SP_sysstatus"].Value = "";
					
					con_data.Open();
					cmd_data.ExecuteNonQuery();
					
					
			} catch (Exception ex) {
				
				con_data.Close();
				MessageBox.Show("Error - Admin Factory Info Save DB \nCannot save data" + Environment.NewLine + ex.Message + ex.ToString());			
				return false;
			
			} finally {
				
				con_data.Close();
					
			}
			
			con_data.Dispose();
			con_data = null;
			cmd_data = null;
			
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
                ((ComboBox)c).Text = "Please Select";
//                if(c is ComboBox)
//                	((ComboBox)c).Items.Clear(); 
				
				
   			}
		}
		
		
		
		void Btn_saveClick(object sender, EventArgs e)
		{
			
			if (!Validation())
                return;
			
			if(sqlConnParm("SP_ADMIN_USER_FACTORY_ADD"))
			{    
				DialogBox.ShowSaveSuccessDialog();
				DataGrid();
			}
			
		}
		
		void Btn_clearClick(object sender, EventArgs e)
		{
			ClearAllText(this);
			DataGrid();
			btn_save.Visible = true;
		}
		
		void Btn_cancelClick(object sender, EventArgs e)
		{
			this.Close();
		}
		
		private bool Validation()
        {
                  
               if (CommonValidation.ValidateIsEmptyString(txtbx_name.Text.Trim()))
                {
                    DialogBox.ShowWarningMessage(lbl_name.Text + " cannot be empty.");
                    txtbx_name.Focus();
                   	
                    return false;
                }
              
               else if (CommonValidation.ValidateIsEmptyString(txtbx_staff_id.Text.Trim()))
                {
                    DialogBox.ShowWarningMessage(lbl_staff_id.Text + " cannot be empty.");
                    txtbx_staff_id.Focus();
                   	
                    return false;
                }
               
               else if (CommonValidation.ValidateIsEmptyString(cbx_dept.Text.Trim()))
                {
                    DialogBox.ShowWarningMessage(lbl_dept.Text + " cannot be empty.");
                    cbx_dept.Focus();
                   	
                    return false; 
                }
               
               else if (CommonValidation.ValidateIsEmptyString(cbx_nation.Text.Trim()))
                {
                    DialogBox.ShowWarningMessage(lbl_nation.Text + " cannot be empty.");
                    cbx_nation.Focus();
                   	
                    return false; 
                }
               
               
               return true;
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
            	if(sqlConnParm("SP_ADMIN_USER_FACTORY_DEL"))
            	{
					//MessageBox.Show("The data has been deleted");
					dt_grid.Rows.RemoveAt(this.dt_grid.SelectedRows[0].Index);
					DialogBox.ShowDeleteSuccessDialog();
					ClearAllText(this);
            	}
            }			
		}
		
		void Frm_mngmtLoad(object sender, EventArgs e)
		{
			DataGrid();
			DropDownList("SELECT * FROM TBL_ADMIN_DEPARTMENT_LIST", cbx_dept, "DEPT");
			DropDownList("SELECT * FROM TBL_COUNTRY_LIST", cbx_nation, "Country");
		}
		
		void DropDownList(string cmd, ComboBox cbx_text, string col_name)
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
            	MessageBox.Show("Error - Admin Factory Dropdown \nCannot load DB \n" + se.ToString() + se.Message);
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
		
		void Dt_gridCellClick(object sender, DataGridViewCellEventArgs e)
		{
			if(dt_grid.SelectedRows.Count > 0)
			{
			   	txtbx_staff_id.Text = dt_grid.SelectedRows[0].Cells[1].Value + string.Empty;
			   	txtbx_name.Text = dt_grid.SelectedRows[0].Cells[2].Value + string.Empty;
			   	cbx_dept.Text = dt_grid.SelectedRows[0].Cells[3].Value + string.Empty;
			   	cbx_nation.Text = dt_grid.SelectedRows[0].Cells[4].Value + string.Empty;
			   	
				btn_del.Visible = true;	
				btn_save.Hide();
			}
		}
		
		void Dt_gridDataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
		{
			dt_grid.ClearSelection();
		}
	}
}

