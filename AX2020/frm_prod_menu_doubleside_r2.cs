/*
 * Created by SharpDevelop.
 * User: faeiz
 * Date: 2017-12-19
 * Time: 3:00 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;

namespace AX2020
{
	/// <summary>
	/// Description of frm_prod_menu_doubleside_r2.
	/// </summary>
	public partial class frm_prod_menu_doubleside_r2 : Form
	{
		public frm_prod_menu_doubleside_r2()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		void Btn_jo_dsClick(object sender, EventArgs e)
		{
			this.Hide();
			using(frm_prod_coating_double_side_r2 frm_prod_coating_double_side_r21 = new frm_prod_coating_double_side_r2())
			frm_prod_coating_double_side_r21.ShowDialog();
			this.Show();
		}
		
		void Btn_reprint_smClick(object sender, EventArgs e)
		{
			this.Hide();
			using(frm_prod_coating_double_side_print frm_prod_coating_double_side_print_R21 = new frm_prod_coating_double_side_print())
			frm_prod_coating_double_side_print_R21.ShowDialog();
			this.Show();
		}
	}
}
