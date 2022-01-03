using System;
using System.Drawing;
using System.Windows.Forms;

namespace AX2020
{
	public partial class frm_menu_packing_list : Form
	{
		public frm_menu_packing_list()
		{
			InitializeComponent();
			this.ControlBox = false;
			lbl_username.Text = "User : " + frm_menu_system.userName;
		}
		
		
		void Btn_backClick(object sender, EventArgs e)
		{
			this.Close();
		}
	
		
		
		
		void Btn_frClick(object sender, EventArgs e)
		{
			this.Hide();
			using(frm_rpt_converting_packing_list_jr frm_conv_jr = new frm_rpt_converting_packing_list_jr())
				frm_conv_jr.ShowDialog();
			this.Show();
		}
		
		void Btn_jrClick(object sender, EventArgs e)
		{
			this.Hide();
			using(frm_rpt_converting_packing_list_fr frm_conv_fr = new frm_rpt_converting_packing_list_fr())
				frm_conv_fr.ShowDialog();
			this.Show();
		}
	}
}
