using System;
using System.Drawing;
using System.Windows.Forms;

namespace AX2020
{
	
	public partial class frm_menu_planning : Form
	{
		public frm_menu_planning()
		{
			InitializeComponent();
			this.ControlBox = false;
			lbl_username.Text = "User : " + frm_menu_system.userName;
		}
		
		void Btn_coatingClick(object sender, EventArgs e)
		{
			this.Hide();
			using(frm_menu_planning_coating frm_main_menu_coating2 = new frm_menu_planning_coating())
				frm_main_menu_coating2.ShowDialog();
			this.Show();
			
		}
		
		void Btn_backClick(object sender, EventArgs e)
		{
			this.Close();
		}
		
		void Btn_convertingClick(object sender, EventArgs e)
		{
			this.Hide();
			using(frm_menu_planning_converting frm_plan_conv_menu = new frm_menu_planning_converting())
				frm_plan_conv_menu.ShowDialog();
			this.Show();
		}
	}
}
