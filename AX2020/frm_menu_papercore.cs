using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic; // For generic collections like List.
using System.Data.SqlClient;      
using System.Data.Sql;
using System.Data;

namespace AX2020
{
	
	public partial class frm_menu_papercore : Form
	{
		bool papercore, papercorerpt;
		public static string sqlconn = "Server=AX-UAT; Password=sbax2020sbg; User ID=sbax2020; Initial Catalog=SBG_AX_2020; Integrated Security=false";
		
		public frm_menu_papercore()
		{
			InitializeComponent();
			this.ControlBox = false;
			lbl_username.Text = "User : " + frm_menu_system.userName;
		}
		
		void Btn_backClick(object sender, EventArgs e)
		{
			this.Close();			
		}
		
		void Btn_reportClick(object sender, EventArgs e)
		{
			this.Hide();
			using(frm_prod_papercore frm_papercore = new frm_prod_papercore())
			      frm_papercore.ShowDialog();
			this.Show();			
		}
		
		void Btn_consumeClick(object sender, EventArgs e)
		{
			this.Hide();
			using(frm_rpt_papercore_consume frm_papercore_consume = new frm_rpt_papercore_consume())
			      frm_papercore_consume.ShowDialog();
			this.Show();
		}
		
		void Btn_outputClick(object sender, EventArgs e)
		{
			this.Hide();
			using(frm_rpt_papercore_output frm_papercore_output = new frm_rpt_papercore_output())
			      frm_papercore_output.ShowDialog();
			this.Show();
		}
		
		bool checkModule()
		{
			SqlConnection con = new SqlConnection(sqlconn);
			SqlCommand cmd = new SqlCommand();
			
			try 
			{
				cmd.CommandText = "select syspapercore, syspapercorerpt from TBL_ADMIN_USER_MODULE where sysusername = @username";
				cmd.Parameters.AddWithValue("@username", frm_menu_system.userName);
				cmd.Connection = con;
				con.Open();
				SqlDataReader rd = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
				
				if (rd.HasRows)
				{
					while (rd.Read())
					{	
						papercore = Convert.ToBoolean(rd["syspapercore"]);
						papercorerpt = Convert.ToBoolean(rd["syspapercorerpt"]);   
					}
				} 
				else 
				{
					MessageBox.Show("Error - Papercore User Module DB \nCannot find data");
					return false;		
				}
			} 
			catch (Exception ex) 
			{
				MessageBox.Show("Error - Papercore User Module DB \nCannot load DB \n" + ex.Message + ex.ToString());
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
		
		void Frm_menu_papercoreLoad(object sender, EventArgs e)
		{
			
		}
	}
}
