using System;
using System.Drawing;
using System.Windows.Forms;

namespace AX2020
{
	public partial class frm_menu_admin : Form
	{
		//string username;
		
		public frm_menu_admin()
		{
			InitializeComponent();
			this.ControlBox = false;
			lbl_username.Text = "User : " + frm_menu_system.userName;	
//			username = frm_menu_system.userName; 
//			lbl_username.Text = "User : " + username;			
		}
		
		void Btn_backClick(object sender, EventArgs e)
		{
			this.Close();
		}
		
		void Btn_factory_userClick(object sender, EventArgs e)
		{
			this.Hide();
			using(frm_admin_factory frm_admin_fact = new frm_admin_factory())
				frm_admin_fact.ShowDialog();
			this.Show();
		}
		
		void Btn_system_userClick(object sender, EventArgs e)
		{
			this.Hide();
			using(frm_admin frm_admin_system = new frm_admin())
				frm_admin_system.ShowDialog();
			this.Show();			
		}
	}
}
