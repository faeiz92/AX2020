using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic; // For generic collections like List.
using System.Data.SqlClient;      
using System.Data.Sql;
using System.Data;

namespace AX2020
{
	
	public partial class frm_prod_conv_menu_small_rewinding : Form
	{
		bool glue, gluerpt;
		public static string sqlconn = "Server=AX-UAT; Password=sbax2020sbg; User ID=sbax2020; Initial Catalog=SBG_AX_2020; Integrated Security=false";
		
		public frm_prod_conv_menu_small_rewinding()
		{
			InitializeComponent();
			this.ControlBox = false;
			lbl_username.Text = "User : " + frm_menu_system.userName;	
			//btn_update.Visible = false;
		}
		
		void Btn_reportClick(object sender, EventArgs e)
		{
			this.Hide();
			using(frm_rpt_prod_conv_smallrewind frm_rpt_prod_conv_smallrewind1 = new frm_rpt_prod_conv_smallrewind())
			      frm_rpt_prod_conv_smallrewind1.ShowDialog();
			this.Show();
		}
		
		void Btn_backClick(object sender, EventArgs e)
		{
			this.Close();			
		}
		
		
		
		void Btn_outputClick(object sender, EventArgs e)
		{
			this.Hide();
			using(frm_prod_rewinding_converting frm_prod_rewinding_converting1 = new frm_prod_rewinding_converting())
			      frm_prod_rewinding_converting1.ShowDialog();
			this.Show();
		}
		
		
		
		
		
		void Btn_consumptionClick(object sender, EventArgs e)
		{
			this.Hide();
			using(frm_rpt_glue_consume_stockcode frm_glue_consume_2 = new frm_rpt_glue_consume_stockcode())
			      frm_glue_consume_2.ShowDialog();
			this.Show();			
		}
		
//		void Btn_updateClick(object sender, EventArgs e)
//		{
//			this.Hide();
//			using(frm_glue_transferdata_erp frm_glue_transferdata_erp2 = new frm_glue_transferdata_erp())
//			      frm_glue_transferdata_erp2.ShowDialog();
//			this.Show();
//		}
		
		void Btn_cancelClick(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}
