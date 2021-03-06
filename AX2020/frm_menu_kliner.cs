using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic; // For generic collections like List.
using System.Data.SqlClient;      
using System.Data.Sql;
using System.Data;

namespace AX2020
{
	public partial class frm_menu_kliner : Form
	{
		bool kliner, klinerrpt;
		public static string sqlconn = "Server=AX-UAT; Password=sbax2020sbg; User ID=sbax2020; Initial Catalog=SBG_AX_2020; Integrated Security=false";
		
		public frm_menu_kliner()
		{
			InitializeComponent();
			lbl_username.Text = "User : " + frm_menu_system.userName;
		}
		
		void Btn_reportClick(object sender, EventArgs e)
		{
			this.Hide();
			using(frm_prod_kliner frm_kliner = new frm_prod_kliner())
			      frm_kliner.ShowDialog();
			this.Show();			
		}
		
		void Btn_backClick(object sender, EventArgs e)
		{
			this.Close();			
		}
		
		void Btn_consumeClick(object sender, EventArgs e)
		{
			this.Hide();
			using(frm_rpt_kliner_consume frm_kliner_consume = new frm_rpt_kliner_consume())
			      frm_kliner_consume.ShowDialog();
			this.Show();
		}
		
		void Btn_outputClick(object sender, EventArgs e)
		{
			this.Hide();
			using(frm_rpt_kliner_output frm_kliner_output = new frm_rpt_kliner_output())
			      frm_kliner_output.ShowDialog();
			this.Show();
		}
		
		
		bool checkModule()
		{
			SqlConnection con = new SqlConnection(sqlconn);
			SqlCommand cmd = new SqlCommand();
			
			try 
			{
				cmd.CommandText = "select syskliner, sysklinerrpt from TBL_ADMIN_USER_MODULE where sysusername = @username";
				cmd.Parameters.AddWithValue("@username", frm_menu_system.userName);
				cmd.Connection = con;
				con.Open();
				SqlDataReader rd = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
				
				if (rd.HasRows)
				{
					while (rd.Read())
					{	
						kliner = Convert.ToBoolean(rd["syskliner"]);
						klinerrpt = Convert.ToBoolean(rd["sysklinerrpt"]);   
					}
				} 
				else 
				{
					MessageBox.Show("Error - Kliner User Module DB \nCannot find data");
					return false;		
				}
			} 
			catch (Exception ex) 
			{
				MessageBox.Show("Error - Kliner User Module DB \nCannot load DB \n" + ex.Message + ex.ToString());
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
		
		void Frm_menu_klinerLoad(object sender, EventArgs e)
		{
			if(!checkModule())
				return;
			
			if(kliner == false)
			{
				btn_report.Enabled = false;
			}

			if(klinerrpt == false)
			{
				btn_consume.Enabled = false;
				btn_output.Enabled = false;
				
			}
			
		}
	}
}
