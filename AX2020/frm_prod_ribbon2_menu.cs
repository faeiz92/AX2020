/*
 * Created by SharpDevelop.
 * User: faeiz
 * Date: 2017-10-25
 * Time: 10:45 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;

namespace AX2020
{
	/// <summary>
	/// Description of frm_prod_ribbon2_menu.
	/// </summary>
	public partial class frm_prod_ribbon2_menu : Form
	{
		string username;
		public frm_prod_ribbon2_menu()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			ControlBox = false;
			username = frm_menu_system.userName; 
			lbl_username.Text = username;
			
			if(lbl_username.Text == "TESTING" || lbl_username.Text == "testing")
			{
				btn_rbn_jo.Enabled = false;
				btn_rbn_mtnce.Enabled = false;
				btn_reprint.Enabled = false;
				
			}
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		void Btn_rbn_outputClick(object sender, EventArgs e)
		{
			this.Hide();
			using(frm_prod_ribbon2_output frm_prod_ribbon2_output1 = new frm_prod_ribbon2_output())
			frm_prod_ribbon2_output1.ShowDialog();
			this.Show();
		}
		
		void Btn_rbn_joClick(object sender, EventArgs e)
		{
			this.Hide();
			using(frm_prod_ribbon2 frm_prod_ribbon21 = new frm_prod_ribbon2())
			frm_prod_ribbon21.ShowDialog();
			this.Show();
		}
		
		void Button1Click(object sender, EventArgs e)
		{
			this.Hide();
			using(frm_prod_ribbon2_print frm_prod_ribbon2_print1 = new frm_prod_ribbon2_print())
			frm_prod_ribbon2_print1.ShowDialog();
			this.Show();
		}
		
		void Btn_rbn_mtnceClick(object sender, EventArgs e)
		{
	
			this.Hide();
			using(frm_prod_ribbon2_maintenance frm_prod_ribbon2_maintenance1 = new frm_prod_ribbon2_maintenance())
			frm_prod_ribbon2_maintenance1.ShowDialog();
			this.Show();
			
		}
		
		void Btn_cancelClick(object sender, EventArgs e)
		{
			this.Close();		
		}
	}
}
