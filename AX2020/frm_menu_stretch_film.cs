using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic; // For generic collections like List.
using System.Data.SqlClient;      
using System.Data.Sql;
using System.Data;

namespace AX2020
{
	
	public partial class frm_menu_stretch_film : Form
	{
		bool stretch_film, stretch_filmrpt;
		public static string sqlconn = "Server=AX-UAT; Password=sbax2020sbg; User ID=sbax2020; Initial Catalog=SBG_AX_2020; Integrated Security=false";
		
		public frm_menu_stretch_film()
		{
			
			InitializeComponent();
			this.ControlBox = false;
			lbl_username.Text = "User : " + frm_menu_system.userName;
		}
		
		void Btn_reportClick(object sender, EventArgs e)
		{
			this.Hide();
			using(frm_prod_stretch_film frm_stretch_film = new frm_prod_stretch_film())
			      frm_stretch_film.ShowDialog();
			this.Show();
		}
		
		void Btn_backClick(object sender, EventArgs e)
		{
			this.Close();			
		}
		
		void Btn_stretch_film_consumeClick(object sender, EventArgs e)
		{
			this.Hide();
			using(frm_rpt_stretch_film_consume frm_stretch_film_consume = new frm_rpt_stretch_film_consume())
			      frm_stretch_film_consume.ShowDialog();
			this.Show();
		}
		
		void Btn_stretch_film_outputClick(object sender, EventArgs e)
		{
			this.Hide();
			using(frm_rpt_stretch_film_output frm_stretch_film_output = new frm_rpt_stretch_film_output())
			      frm_stretch_film_output.ShowDialog();
			this.Show();
		}
		
		bool checkModule()
		{
			SqlConnection con = new SqlConnection(sqlconn);
			SqlCommand cmd = new SqlCommand();
			
			try 
			{
				cmd.CommandText = "select sysstretchfilm, sysstretchfilmrpt from TBL_ADMIN_USER_MODULE where sysusername = @username";
				cmd.Parameters.AddWithValue("@username", frm_menu_system.userName);
				cmd.Connection = con;
				con.Open();
				SqlDataReader rd = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
				
				if (rd.HasRows)
				{
					while (rd.Read())
					{	
						stretch_film = Convert.ToBoolean(rd["sysstretchfilm"]);
						stretch_filmrpt = Convert.ToBoolean(rd["sysstretchfilmrpt"]);   
					}
				} 
				else 
				{
					MessageBox.Show("Error - Stretch Film User Module DB \nCannot find data");
					return false;		
				}
			} 
			catch (Exception ex) 
			{
				MessageBox.Show("Error - Stretch Film User Module DB \nCannot load DB \n" + ex.Message + ex.ToString());
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
		
		void Frm_menu_stretch_filmLoad(object sender, EventArgs e)
		{
			if(!checkModule())
				return;
			
			if(stretch_film == false)
			{
				btn_report.Enabled = false;
			}

			if(stretch_filmrpt == false)
			{
				btn_stretch_film_consume.Enabled = false;
				btn_stretch_film_output.Enabled = false;
				
			}			
		}
		
		
	}
}
