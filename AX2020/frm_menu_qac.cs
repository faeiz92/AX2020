using System;
using System.Drawing;
using System.Windows.Forms;

namespace AX2020
{
	
	public partial class frm_menu_qac : Form
	{
		public frm_menu_qac()
		{
			
			InitializeComponent();
			lbl_username.Text = "User : " + frm_menu_system.userName;
		}
		
		void Btn_backClick(object sender, EventArgs e)
		{
			this.Close();
		}
		
		void Btn_prod_track_statClick(object sender, EventArgs e)
		{
			this.Hide();
			using(frm_rpt_converting_tracking frm_conv_tracking = new frm_rpt_converting_tracking())
				frm_conv_tracking.ShowDialog();
			this.Show();
		}
		
		void Btn_coat_overweightClick(object sender, EventArgs e)
		{
			this.Hide();
			using(frm_rpt_coating_output_overweight frm_prod_coat_over = new frm_rpt_coating_output_overweight())
				frm_prod_coat_over.ShowDialog();
			this.Show();
			
		}
		
		void Btn_coat_underweightClick(object sender, EventArgs e)
		{
			this.Hide();
			using(frm_rpt_coating_output_underweight frm_prod_coat_under = new frm_rpt_coating_output_underweight())
				frm_prod_coat_under.ShowDialog();
			this.Show();
		}
	}
}
