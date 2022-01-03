using System;
using System.Drawing;
using System.Windows.Forms;

namespace AX2020
{
	
	public partial class frm_menu_sales : Form
	{
		public frm_menu_sales()
		{
			
			InitializeComponent();
			this.ControlBox = false;
			lbl_username.Text = "User : " + frm_menu_system.userName;
		}
		
		void Btn_coatingClick(object sender, EventArgs e)
		{
			this.Hide();
			using(frm_sales_order_download frm_so = new frm_sales_order_download())
				frm_so.ShowDialog();
			this.Show();
			
		}
		
		void Btn_backClick(object sender, EventArgs e)
		{
			this.Close();
		}
		
		void Btn_convertingClick(object sender, EventArgs e)
		{
			this.Hide();
			using(frm_prod_sales_order frm_so_upload = new frm_prod_sales_order())
				frm_so_upload.ShowDialog();
			this.Show();
		}
	}
}
