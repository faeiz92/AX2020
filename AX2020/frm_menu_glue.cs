using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic; // For generic collections like List.
using System.Data.SqlClient;      
using System.Data.Sql;
using System.Data;

namespace AX2020
{
	
	public partial class frm_menu_glue : Form
	{
		bool glue, gluerpt;
		public static string sqlconn = "Server=AX-UAT; Password=sbax2020sbg; User ID=sbax2020; Initial Catalog=SBG_AX_2020; Integrated Security=false";
		
		public frm_menu_glue()
		{
			InitializeComponent();
			this.ControlBox = false;
			lbl_username.Text = "User : " + frm_menu_system.userName;	
			btn_update.Visible = false;
		}
		
		void Btn_reportClick(object sender, EventArgs e)
		{
			this.Hide();
			using(frm_prod_glue frm_glue = new frm_prod_glue())
			      frm_glue.ShowDialog();
			this.Show();
		}
		
		void Btn_backClick(object sender, EventArgs e)
		{
			this.Close();			
		}
		
		void Btn_consumeClick(object sender, EventArgs e)
		{
			this.Hide();
			using(frm_rpt_glue_consume frm_glue_consume = new frm_rpt_glue_consume())
			      frm_glue_consume.ShowDialog();
			this.Show();
		}
		
		void Btn_outputClick(object sender, EventArgs e)
		{
			this.Hide();
			using(frm_rpt_glue_output frm_glue_output = new frm_rpt_glue_output())
			      frm_glue_output.ShowDialog();
			this.Show();
		}
		
		
		bool checkModule()
		{
			SqlConnection con = new SqlConnection(sqlconn);
			SqlCommand cmd = new SqlCommand();
			
			try 
			{
				cmd.CommandText = "select sysglue, sysgluerpt from TBL_ADMIN_USER_MODULE where sysusername = @username";
				cmd.Parameters.AddWithValue("@username", frm_menu_system.userName);
				cmd.Connection = con;
				con.Open();
				SqlDataReader rd = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
				
				if (rd.HasRows)
				{
					while (rd.Read())
					{	
						glue = Convert.ToBoolean(rd["sysglue"]);
						gluerpt = Convert.ToBoolean(rd["sysgluerpt"]);   
					}
				} 
				else 
				{
					MessageBox.Show("Error - Glue User Module DB \nCannot find data");
					return false;		
				}
			} 
			catch (Exception ex) 
			{
				MessageBox.Show("Error - Glue User Module DB \nCannot load DB \n" + ex.Message + ex.ToString());
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
		
		void Frm_menu_glueLoad(object sender, EventArgs e)
		{
			if(!checkModule())
				return;
			
			if(glue == false)
			{
				btn_report.Enabled = false;
			}

			if(gluerpt == false)
			{
				btn_consume.Enabled = false;
				btn_output.Enabled = false;
				
			}
					
		}
		
		void Btn_consumptionClick(object sender, EventArgs e)
		{
			this.Hide();
			using(frm_rpt_glue_consume_stockcode frm_glue_consume_2 = new frm_rpt_glue_consume_stockcode())
			      frm_glue_consume_2.ShowDialog();
			this.Show();			
		}
		
//		void Btn_updateClick(object sender, EventArgs e)
//		{
//			this.Hide();
//			using(frm_glue_transferdata_erp frm_glue_transferdata_erp2 = new frm_glue_transferdata_erp())
//			      frm_glue_transferdata_erp2.ShowDialog();
//			this.Show();
//		}
	}
}
