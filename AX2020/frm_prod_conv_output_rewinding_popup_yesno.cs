/*
 * Created by SharpDevelop.
 * User: faeiz
 * Date: 2018-01-09
 * Time: 3:48 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;

namespace AX2020
{
	/// <summary>
	/// Description of frm_prod_conv_output_rewinding_popup_yesno.
	/// </summary>
	public partial class frm_prod_conv_output_rewinding_popup_yesno : Form
	{
		
		public static string ship_mark2 = "";
		public static double type_balance2 = 0;
		public frm_prod_conv_output_rewinding_popup_yesno()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		void Btn_yesClick(object sender, EventArgs e)
		{
			frm_prod_coverting_output_rewinding_check_bal obj_rewind = new frm_prod_coverting_output_rewinding_check_bal();
			obj_rewind.Show();
			ship_mark2 = frm_prod_converting_output_rewinding_r4.ship_mark;
			type_balance2 = frm_prod_converting_output_rewinding_r4.type_balance;
			
			//frm_prod_converting_output_rewinding_r4 frm_prod_converting_output_rewinding_r41 = new frm_prod_converting_output_rewinding_r4())		
		
			

		}
		
		
	
		
		void Btn_noClick(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}
