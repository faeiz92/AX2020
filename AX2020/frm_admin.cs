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
	public partial class frm_admin : Form
	{
		public static string sqlconn = "Server=AX-UAT; Password=sbax2020sbg; User ID=sbax2020; Initial Catalog=SBG_AX_2020; Integrated Security=false";
		string staff_username, staff_pass, username;
		//int sales, plan, whse, coat, conv, glue, ribbon, papercore, kliner, qac, ship, admin, qis, pack, stretch, mngmt;
		
		public frm_admin()
		{
			InitializeComponent();
			this.ControlBox = false;
			
			username = frm_menu_system.userName; 
			lbl_username.Text = "User : " + username;
		}
		
		//>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
		
		void DataGrid()
		{
			SqlConnection con_SP = new SqlConnection(sqlconn);
			SqlCommand cmd_SP = new SqlCommand();
				
			try 
			{
				cmd_SP.CommandText = @"SELECT sysusername, sysstaffname, sysdept, sysemail FROM TBL_ADMIN_USER_ACCESS ORDER BY sysstaffname";
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
	            dt_grid.Columns[1].HeaderText = "UserName";
	            dt_grid.Columns[1].Width = 100;
	            dt_grid.Columns[2].HeaderText = "Staff Name";
	            dt_grid.Columns[2].Width = 400;
	            dt_grid.Columns[3].HeaderText = "Department";
			 	dt_grid.Columns[3].Width = 200;
			 	dt_grid.Columns[4].HeaderText = "Email";
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
					
					staff_username = txtbx_username.Text;
					staff_pass = txtbx_pass.Text;
					
					cmd_data.Parameters.Add(new SqlParameter("@SP_sysusername", SqlDbType.NVarChar, 50));
					cmd_data.Parameters["@SP_sysusername"].Value = staff_username;

					cmd_data.Parameters.Add(new SqlParameter("@SP_syspassword", SqlDbType.NVarChar, 10));
					cmd_data.Parameters["@SP_syspassword"].Value = staff_pass;

					cmd_data.Parameters.Add(new SqlParameter("@SP_sysstaffname", SqlDbType.NVarChar, 50));
					cmd_data.Parameters["@SP_sysstaffname"].Value = txtbx_name.Text.ToUpper();

					cmd_data.Parameters.Add(new SqlParameter("@SP_sysdept", SqlDbType.NVarChar, 10));
					cmd_data.Parameters["@SP_sysdept"].Value = cbx_dept.Text;

					cmd_data.Parameters.Add(new SqlParameter("@SP_sysemail", SqlDbType.NVarChar, 50));
					cmd_data.Parameters["@SP_sysemail"].Value = txtbx_email.Text;

					cmd_data.Parameters.Add(new SqlParameter("@SP_sysstatus", SqlDbType.NVarChar, 50));
					cmd_data.Parameters["@SP_sysstatus"].Value = "0";

					cmd_data.Parameters.Add(new SqlParameter("@SP_systype", SqlDbType.NVarChar, 50));
					cmd_data.Parameters["@SP_systype"].Value = "0";
					
					cmd_data.Parameters.Add(new SqlParameter("@SP_sysflag", SqlDbType.NVarChar, 50));
					cmd_data.Parameters["@SP_sysflag"].Value = "0";

					cmd_data.Parameters.Add(new SqlParameter("@SP_syssection", SqlDbType.NVarChar, 50));
					cmd_data.Parameters["@SP_syssection"].Value =  "0";
					
					cmd_data.Parameters.Add(new SqlParameter("@SP_syscustomer", SqlDbType.NVarChar, 50));
					cmd_data.Parameters["@SP_syscustomer"].Value =  "0";
					
					cmd_data.Parameters.Add(new SqlParameter("@SP_sysmicron", SqlDbType.Float));
					cmd_data.Parameters["@SP_sysmicron"].Value =  0;
					
					con_data.Open();
					cmd_data.ExecuteNonQuery();
					
					
			} catch (Exception ex) {
				
				con_data.Close();
				MessageBox.Show("Error - Admin System User Info Save DB \nCannot save data" + Environment.NewLine + ex.Message + ex.ToString());			
				return false;
			
			} finally {
				
				con_data.Close();
					
			}
			
			con_data.Dispose();
			con_data = null;
			cmd_data = null;
			
			return true;
		}
		

		bool sqlConnParm2(string sqlStatement)
		{
			
			SqlConnection con_data = new SqlConnection(sqlconn);
			SqlCommand cmd_data = new SqlCommand();
			
			try
			{
					cmd_data.Connection = con_data;
					cmd_data.CommandText = sqlStatement;
					cmd_data.CommandType = CommandType.StoredProcedure;

					cmd_data.Parameters.Add(new SqlParameter("@SP_sysusername", SqlDbType.NVarChar, 50));
					cmd_data.Parameters["@SP_sysusername"].Value = staff_username;

					cmd_data.Parameters.Add(new SqlParameter("@SP_syspassword", SqlDbType.NVarChar, 10));
					cmd_data.Parameters["@SP_syspassword"].Value = staff_pass;

					cmd_data.Parameters.Add(new SqlParameter("@SP_syssales", SqlDbType.Bit));
					cmd_data.Parameters["@SP_syssales"].Value = chkbx_sales.Checked;
					
					cmd_data.Parameters.Add(new SqlParameter("@SP_sysplan", SqlDbType.Bit));
					cmd_data.Parameters["@SP_sysplan"].Value = chkbx_plan.Checked;

					cmd_data.Parameters.Add(new SqlParameter("@SP_syswhse", SqlDbType.Bit));
					cmd_data.Parameters["@SP_syswhse"].Value = chkbx_whse.Checked;

					cmd_data.Parameters.Add(new SqlParameter("@SP_syscoat", SqlDbType.Bit));
					cmd_data.Parameters["@SP_syscoat"].Value = chkbx_coat.Checked;
					
					cmd_data.Parameters.Add(new SqlParameter("@SP_syscoatrpt", SqlDbType.Bit));
					cmd_data.Parameters["@SP_syscoatrpt"].Value = chkbx_coat_report.Checked;

					cmd_data.Parameters.Add(new SqlParameter("@SP_sysconv", SqlDbType.Bit));
					cmd_data.Parameters["@SP_sysconv"].Value = chkbx_conv.Checked;
					
					cmd_data.Parameters.Add(new SqlParameter("@SP_sysconvrpt", SqlDbType.Bit));
					cmd_data.Parameters["@SP_sysconvrpt"].Value = chkbx_conv_report.Checked;
					
					cmd_data.Parameters.Add(new SqlParameter("@SP_sysglue", SqlDbType.Bit));
					cmd_data.Parameters["@SP_sysglue"].Value = chkbx_glue.Checked;
					
					cmd_data.Parameters.Add(new SqlParameter("@SP_sysgluerpt", SqlDbType.Bit));
					cmd_data.Parameters["@SP_sysgluerpt"].Value = chkbx_glue_report.Checked;

					cmd_data.Parameters.Add(new SqlParameter("@SP_sysribbon", SqlDbType.Bit));
					cmd_data.Parameters["@SP_sysribbon"].Value = chkbx_ribbon.Checked;
					
					cmd_data.Parameters.Add(new SqlParameter("@SP_sysribbonrpt", SqlDbType.Bit));
					cmd_data.Parameters["@SP_sysribbonrpt"].Value = chkbx_ribbon_report.Checked;

					cmd_data.Parameters.Add(new SqlParameter("@SP_syspapercore", SqlDbType.Bit));
					cmd_data.Parameters["@SP_syspapercore"].Value = chkbx_papercore.Checked;
					
					cmd_data.Parameters.Add(new SqlParameter("@SP_syspapercorerpt", SqlDbType.Bit));
					cmd_data.Parameters["@SP_syspapercorerpt"].Value = chkbx_papercore_report.Checked;
					
					cmd_data.Parameters.Add(new SqlParameter("@SP_syskliner", SqlDbType.Bit));
					cmd_data.Parameters["@SP_syskliner"].Value = chkbx_kliner.Checked;
					
					cmd_data.Parameters.Add(new SqlParameter("@SP_sysklinerrpt", SqlDbType.Bit));
					cmd_data.Parameters["@SP_sysklinerrpt"].Value = chkbx_kliner_report.Checked;

					cmd_data.Parameters.Add(new SqlParameter("@SP_sysqac", SqlDbType.Bit));
					cmd_data.Parameters["@SP_sysqac"].Value = chkbx_qac.Checked;

					cmd_data.Parameters.Add(new SqlParameter("@SP_sysshipping", SqlDbType.Bit));
					cmd_data.Parameters["@SP_sysshipping"].Value = chkbx_ship.Checked;
					
					cmd_data.Parameters.Add(new SqlParameter("@SP_sysadmin", SqlDbType.Bit));
					cmd_data.Parameters["@SP_sysadmin"].Value = chkbx_admin.Checked;

					cmd_data.Parameters.Add(new SqlParameter("@SP_sysqis", SqlDbType.Bit));
					cmd_data.Parameters["@SP_sysqis"].Value = chkbx_qis.Checked;

					cmd_data.Parameters.Add(new SqlParameter("@SP_syspack", SqlDbType.Bit));
					cmd_data.Parameters["@SP_syspack"].Value = chkbx_pack.Checked;

					cmd_data.Parameters.Add(new SqlParameter("@SP_sysstretchfilm", SqlDbType.Bit));
					cmd_data.Parameters["@SP_sysstretchfilm"].Value = chkbx_stretch_film.Checked;
					
					cmd_data.Parameters.Add(new SqlParameter("@SP_sysstretchfilmrpt", SqlDbType.Bit));
					cmd_data.Parameters["@SP_sysstretchfilmrpt"].Value = chkbx_stretch_film.Checked;

					cmd_data.Parameters.Add(new SqlParameter("@SP_sysmngmt", SqlDbType.Bit));
					cmd_data.Parameters["@SP_sysmngmt"].Value = chkbx_mngmt.Checked;
					
					cmd_data.Parameters.Add(new SqlParameter("@SP_sysprocurement", SqlDbType.Bit));
					cmd_data.Parameters["@SP_sysprocurement"].Value = chkbx_procurement.Checked;
					
					cmd_data.Parameters.Add(new SqlParameter("@SP_sysaxstockstatus", SqlDbType.Bit));
					cmd_data.Parameters["@SP_sysaxstockstatus"].Value = chkbx_alldepartment.Checked;
					
					
					cmd_data.Parameters.Add(new SqlParameter("@SP_sysflag", SqlDbType.NVarChar, 1));
					cmd_data.Parameters["@SP_sysflag"].Value = "0";

					cmd_data.Parameters.Add(new SqlParameter("@SP_sysstatus", SqlDbType.NVarChar, 1));
					cmd_data.Parameters["@SP_sysstatus"].Value = "0";
					
					con_data.Open();
					cmd_data.ExecuteNonQuery();
					
					
			} catch (Exception ex) {
				
				con_data.Close();
				MessageBox.Show("Error - Admin System User Save DB \nCannot save data" + Environment.NewLine + ex.Message + ex.ToString());			
				return false;
			
			} finally {
				
				con_data.Close();	
			}
			
			con_data.Dispose();
			con_data = null;
			cmd_data = null;
			
			ClearAllText(this);
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
				
				if (c.GetType() == typeof(CheckBox))
                {
                    ((CheckBox)c).Checked = false;
                }
   			}
		}
		
		void Retrieve()
		{
			SqlConnection con_retrieve = new SqlConnection(sqlconn);
			SqlCommand cmd_retrieve = new SqlCommand();
				
			try 
			{
				cmd_retrieve.CommandText = @"SELECT * FROM TBL_ADMIN_USER_ACCESS where sysusername = @username";
				cmd_retrieve.Parameters.AddWithValue("@username",  staff_username);
				cmd_retrieve.Connection = con_retrieve;
				con_retrieve.Open();
				SqlDataReader rd_retrieve = cmd_retrieve.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
				
				if (rd_retrieve.HasRows)
				{
					while (rd_retrieve.Read())
					{				        	
						txtbx_username.Text = rd_retrieve["sysusername"].ToString();
						txtbx_pass.Text = rd_retrieve["syspassword"].ToString();
						txtbx_name.Text = rd_retrieve["sysstaffname"].ToString();
						cbx_dept.Text = rd_retrieve["sysdept"].ToString();
						txtbx_email.Text = rd_retrieve["sysemail"].ToString();
					} 
					
				}
			} 
			catch (Exception ex) 
			{
				MessageBox.Show("Error - Admin System User Retrieve DB \nCannot load DB!" + ex.Message + ex.ToString());
				return;
			} 
			finally 
			{
				con_retrieve.Close();
			}
				
			con_retrieve.Dispose();
			con_retrieve = null;
			cmd_retrieve = null;		
			
			//--------------------------------------------------------------------------
			
			SqlConnection con_retrieve_2 = new SqlConnection(sqlconn);
			SqlCommand cmd_retrieve_2 = new SqlCommand();
				
			try 
			{
				cmd_retrieve_2.CommandText = @"SELECT * FROM TBL_ADMIN_USER_MODULE where sysusername = @username";
				cmd_retrieve_2.Parameters.AddWithValue("@username",  staff_username);
				cmd_retrieve_2.Connection = con_retrieve_2;
				con_retrieve_2.Open();
				SqlDataReader rd_retrieve_2 = cmd_retrieve_2.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
				
				if (rd_retrieve_2.HasRows)
				{
					while (rd_retrieve_2.Read())
					{	
					
						chkbx_sales.Checked = (bool) (rd_retrieve_2["syssales"]);
						chkbx_plan.Checked = (bool) rd_retrieve_2["sysplan"];
						chkbx_whse.Checked = (bool) rd_retrieve_2["syswhse"];
						chkbx_coat.Checked = (bool) rd_retrieve_2["syscoat"];
						chkbx_coat_report.Checked = (bool) rd_retrieve_2["syscoatrpt"];
						chkbx_conv.Checked = (bool) rd_retrieve_2["sysconv"];
						chkbx_conv_report.Checked = (bool) rd_retrieve_2["sysconvrpt"];
						chkbx_glue.Checked = (bool) rd_retrieve_2["sysglue"];
						chkbx_glue_report.Checked = (bool) rd_retrieve_2["sysgluerpt"];
						chkbx_ribbon.Checked = (bool) rd_retrieve_2["sysribbon"];
						chkbx_ribbon_report.Checked = (bool) rd_retrieve_2["sysribbonrpt"];
						chkbx_papercore.Checked = (bool) rd_retrieve_2["syspapercore"];
						chkbx_papercore_report.Checked = (bool) rd_retrieve_2["syspapercorerpt"];
						chkbx_kliner.Checked = (bool) rd_retrieve_2["syskliner"];
						chkbx_kliner_report.Checked = (bool) rd_retrieve_2["sysklinerrpt"];
						chkbx_mngmt.Checked = (bool) rd_retrieve_2["sysmngmt"];
						chkbx_pack.Checked = (bool) rd_retrieve_2["syspack"];
						chkbx_admin.Checked = (bool) (rd_retrieve_2["sysadmin"]);
						chkbx_qac.Checked = (bool) rd_retrieve_2["sysqac"];
						chkbx_qis.Checked = (bool) rd_retrieve_2["sysqis"];
						chkbx_ship.Checked = (bool) rd_retrieve_2["sysshipping"];
						chkbx_stretch_film.Checked = (bool) rd_retrieve_2["sysstretchfilm"];
						chkbx_stretch_film_report.Checked = (bool) rd_retrieve_2["sysstretchfilmrpt"];
						
							
					} 
					
				}
			} 
			catch (Exception ex) 
			{
				MessageBox.Show("Error - Admin System User Retrieve DB \nCannot load DB!" + ex.Message + ex.ToString());
				return;
			} 
			finally 
			{
				con_retrieve_2.Close();
			}
				
			con_retrieve_2.Dispose();
			con_retrieve_2 = null;
			cmd_retrieve_2 = null;	
			btn_save.Visible = false;
			
         }
		
		void Btn_saveClick(object sender, EventArgs e)
		{
			
			if (!Validation())
                return;
			
			if(sqlConnParm("SP_ADMIN_USER_ACCESS_ADD") & sqlConnParm2("SP_ADMIN_USER_MODULE_ADD"))
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
              
               else if (CommonValidation.ValidateIsEmptyString(txtbx_email.Text.Trim()))
                {
                    DialogBox.ShowWarningMessage(lbl_email.Text + " cannot be empty.");
                    txtbx_email.Focus();
                   	
                    return false;
                }
               
               else if (CommonValidation.ValidateIsEmptyString(cbx_dept.Text.Trim()))
                {
                    DialogBox.ShowWarningMessage(lbl_dept.Text + " cannot be empty.");
                    cbx_dept.Focus();
                   	
                    return false; 
                }
               
               else if (CommonValidation.ValidateIsEmptyString(txtbx_username.Text.Trim()))
                {
                    DialogBox.ShowWarningMessage(lbl_user_name.Text + " cannot be empty.");
                    txtbx_username.Focus();
                   	
                    return false;  
                }
               
               else if (CommonValidation.ValidateIsEmptyString(txtbx_pass.Text.Trim()))
                {
                    DialogBox.ShowWarningMessage(lbl_pass.Text + " cannot be empty.");
                    txtbx_pass.Focus();
                   	
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
            	if(sqlConnParm("SP_ADMIN_USER_ACCESS_DEL") & sqlConnParm2("SP_ADMIN_USER_MODULE_DEL"))
            	{
					//MessageBox.Show("The data has been deleted");
					dt_grid.Rows.RemoveAt(this.dt_grid.SelectedRows[0].Index);
					DialogBox.ShowDeleteSuccessDialog();
					btn_save.Visible = true;
					btn_del.Hide();
            	}
            }			
		}
		
		void Frm_mngmtLoad(object sender, EventArgs e)
		{
			DataGrid();
			DropDownList("SELECT * FROM TBL_ADMIN_DEPARTMENT_LIST", cbx_dept, "DEPT");
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
            	MessageBox.Show("Error - Admin System User Dropdown \nCannot load DB \n" + se.ToString() + se.Message);
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
			   	staff_username = dt_grid.SelectedRows[0].Cells[1].Value + string.Empty;
			   	txtbx_username.Text = staff_username;
			   	Retrieve(); 
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
