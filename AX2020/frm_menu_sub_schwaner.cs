/*
 * Created by SharpDevelop.
 * User: faeiz
 * Date: 2017-07-07
 * Time: 5:32 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;

namespace AX2020
{
	/// <summary>
	/// Description of frm_menu_sub_schwaner.
	/// </summary>
	public partial class frm_menu_sub_schwaner : Form
	{
		string username;
		public frm_menu_sub_schwaner()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			username = frm_menu_system.userName; 
			lbl_username.Text = "User : " + username;
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		
		void Btn_joschwanerClick(object sender, EventArgs e)
		{
			this.Hide();
			using (frm_prod_coat_schwaner_jo_memo frm_prod_coat_schwaner_jo_memo9 = new frm_prod_coat_schwaner_jo_memo())
			frm_prod_coat_schwaner_jo_memo9.ShowDialog();
			this.Show();
		}
		
		void Btn_billschwnaerClick(object sender, EventArgs e)
		{
			this.Hide();
			using (frm_prod_coat_schwaner_bill_of_material frm_prod_coat_schwaner_bill_of_material9 = new frm_prod_coat_schwaner_bill_of_material())
			frm_prod_coat_schwaner_bill_of_material9.ShowDialog();
			this.Show();
		}
		
		void Btn_printClick(object sender, EventArgs e)
		{
			this.Hide();
			using (frm_prod_coat_schwaner_jo_memo_rpt frm_prod_coat_schwaner_jo_memo_rpt9 = new frm_prod_coat_schwaner_jo_memo_rpt())
			frm_prod_coat_schwaner_jo_memo_rpt9.ShowDialog();
			this.Show();
		}
		
		void Btn_cancelClick(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}
