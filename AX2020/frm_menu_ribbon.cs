using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic; // For generic collections like List.
using System.Data.SqlClient;      
using System.Data.Sql;
using System.Data;

namespace AX2020
{
	public partial class frm_menu_ribbon : Form
	{
		bool ribbon, ribbonrpt;
		public static string sqlconn = "Server=AX-UAT; Password=sbax2020sbg; User ID=sbax2020; Initial Catalog=SBG_AX_2020; Integrated Security=false";
		
		public frm_menu_ribbon()
		{
		
			InitializeComponent();
			this.ControlBox = false;
			lbl_username.Text = "User : " + frm_menu_system.userName;
		}
		
		void Btn_reportClick(object sender, EventArgs e)
		{
			this.Hide();
			using(frm_prod_ribbon frm_ribbon = new frm_prod_ribbon())
			      frm_ribbon.ShowDialog();
			this.Show();
		}
		
		void Btn_backClick(object sender, EventArgs e)
		{
			this.Close();			
		}
		
		void Btn_ribbon_consumeClick(object sender, EventArgs e)
		{
			this.Hide();
			using(frm_rpt_ribbon_consume frm_ribbon_consume = new frm_rpt_ribbon_consume())
			      frm_ribbon_consume.ShowDialog();
			this.Show();
		}
		
		void Btn_ribbon_outputClick(object sender, EventArgs e)
		{
			this.Hide();
			using(frm_rpt_ribbon_output frm_ribbon_output = new frm_rpt_ribbon_output())
			      frm_ribbon_output.ShowDialog();
			this.Show();
		}
		
		bool checkModule()
		{
			SqlConnection con = new SqlConnection(sqlconn);
			SqlCommand cmd = new SqlCommand();
			
			try 
			{
				cmd.CommandText = "select sysribbon, sysribbonrpt from TBL_ADMIN_USER_MODULE where sysusername = @username";
				cmd.Parameters.AddWithValue("@username", frm_menu_system.userName);
				cmd.Connection = con;
				con.Open();
				SqlDataReader rd = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
				
				if (rd.HasRows)
				{
					while (rd.Read())
					{	
						ribbon = Convert.ToBoolean(rd["sysribbon"]);
						ribbonrpt = Convert.ToBoolean(rd["sysribbonrpt"]);   
					}
				} 
				else 
				{
					MessageBox.Show("Error - Ribbon User Module DB \nCannot find data");
					return false;		
				}
			} 
			catch (Exception ex) 
			{
				MessageBox.Show("Error - Ribbon User Module DB \nCannot load DB \n" + ex.Message + ex.ToString());
				return false;
			} 
			finally 
			{
				con.Close();
			}
			
			con.Dispose();
			con = null;
			cmd = null;
			return true;
		}
		
		void Frm_menu_ribbonLoad(object sender, EventArgs e)
		{
			if(!checkModule())
				return;
			
			if(ribbon == false)
			{
				btn_report.Enabled = false;
			}

			if(ribbonrpt == false)
			{
				btn_ribbon_consume.Enabled = false;
				btn_ribbon_output.Enabled = false;
				
			}			
		}
	}
}
