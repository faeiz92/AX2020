/*
 * Created by SharpDevelop.
 * User: it-4
 * Date: 17/11/2016
 * Time: 9:47 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;

namespace AX2020
{
	/// <summary>
	/// Description of frm_menu_planning_converting.
	/// </summary>
	public partial class frm_menu_planning_converting : Form
	{
		public frm_menu_planning_converting()
		{
			InitializeComponent();
			this.ControlBox = false;
			lbl_username.Text = "User : " + frm_menu_system.userName;
		}
		
		
		void Btn_backClick(object sender, EventArgs e)
		{
			this.Close();	
		}

		
		void Btn_JOClick(object sender, EventArgs e)
		{
			this.Hide();
			using(frm_prod_converting_jo frm_conv_jo = new frm_prod_converting_jo())
				frm_conv_jo.ShowDialog();
			this.Show();
		}
		
		void Btn_billClick(object sender, EventArgs e)
		{
			this.Hide();
			using(frm_prod_converting_bill frm_conv_bill = new frm_prod_converting_bill())
				frm_conv_bill.ShowDialog();
			this.Show();
		}
		
		void Btn_reprintClick(object sender, EventArgs e)
		{
			this.Hide();
			using(frm_prod_converting_jo_print frm_conv_jo_print = new frm_prod_converting_jo_print())
				frm_conv_jo_print.ShowDialog();
			this.Show();
		}
		
		void Btn_jo_progressClick(object sender, EventArgs e)
		{
			this.Hide();
			using(frm_rpt_converting_progress_r3 frm_conv_progress = new frm_rpt_converting_progress_r3())
				frm_conv_progress.ShowDialog();
			this.Show();
		}
		
		void Btn_prod_track_statClick(object sender, EventArgs e)
		{
			this.Hide();
			using(frm_rpt_converting_tracking_r1 frm_conv_tracking = new frm_rpt_converting_tracking_r1())
				frm_conv_tracking.ShowDialog();
			this.Show();
		}
		
		//---------------------------------------------------------------------------------

		void Btn_slit_outputClick(object sender, EventArgs e)
		{
			this.Hide();
			using(frm_rpt_converting_prod frm_conv_prod = new frm_rpt_converting_prod())
				frm_conv_prod.ShowDialog();
			this.Show();			
		}
		
		void Btn_slit_output_detailClick(object sender, EventArgs e)
		{
			this.Hide();
			using(frm_rpt_converting_prod_detail frm_conv_prod_detail = new frm_rpt_converting_prod_detail())
				frm_conv_prod_detail.ShowDialog();
			this.Show();
		}
		
		void Btn_slit_output_fastClick(object sender, EventArgs e)
		{
			this.Hide();
			using(frm_rpt_converting_prod_fast frm_conv_prod_fast = new frm_rpt_converting_prod_fast())
				frm_conv_prod_fast.ShowDialog();
			this.Show();
		}
		
		void Btn_slit_output_shift_fastClick(object sender, EventArgs e)
		{
			this.Hide();
			using(frm_rpt_converting_prod_shift_fast frm_conv_prod_shift_fast = new frm_rpt_converting_prod_shift_fast())
				frm_conv_prod_shift_fast.ShowDialog();
			this.Show();
		}
		
		
//-------------------------------------------------------------------------------------------		
		
		void Btn_pack_outputClick(object sender, EventArgs e)
		{
			this.Hide();
			using(frm_rpt_converting_pack frm_conv_pack = new frm_rpt_converting_pack())
				frm_conv_pack.ShowDialog();
			this.Show();
		}
				
				
		void Btn_pack_output_detailClick(object sender, EventArgs e)
		{
			this.Hide();
			using(frm_rpt_converting_pack_detail frm_conv_pack_detail = new frm_rpt_converting_pack_detail())
				frm_conv_pack_detail.ShowDialog();
			this.Show();			
		}
		
		void Btn_pack_output_fastClick(object sender, EventArgs e)
		{
			this.Hide();
			using(frm_rpt_converting_pack_fast frm_conv_pack_fast = new frm_rpt_converting_pack_fast())
				frm_conv_pack_fast.ShowDialog();
			this.Show();
		}
		
		void Btn_pack_output_shift_fastClick(object sender, EventArgs e)
		{
			this.Hide();
			using(frm_rpt_converting_pack_shift_fast frm_conv_pack_shift_fast = new frm_rpt_converting_pack_shift_fast())
				frm_conv_pack_shift_fast.ShowDialog();
			this.Show();
		}
			
		
//----------------------------------------------------------------------------------


		void Btn_cut_outputClick(object sender, EventArgs e)
		{
			this.Hide();
			using(frm_rpt_converting_cutting frm_conv_cut = new frm_rpt_converting_cutting())
				frm_conv_cut.ShowDialog();
			this.Show();
		}
		
		void Btn_cut_output_detailClick(object sender, EventArgs e)
		{
			this.Hide();
			using(frm_rpt_converting_cutting_detail frm_conv_cut_detail = new frm_rpt_converting_cutting_detail())
				frm_conv_cut_detail.ShowDialog();
			this.Show();			
		}
		
		void Btn_cut_output_fastClick(object sender, EventArgs e)
		{
			this.Hide();
			using(frm_rpt_converting_cutting_fast frm_conv_cut_fast = new frm_rpt_converting_cutting_fast())
				frm_conv_cut_fast.ShowDialog();
			this.Show();
		}
		
		void Btn_cut_output_shift_fastClick(object sender, EventArgs e)
		{
			this.Hide();
			using(frm_rpt_converting_cutting_shift_fast frm_conv_cut_shift_fast = new frm_rpt_converting_cutting_shift_fast())
				frm_conv_cut_shift_fast.ShowDialog();
			this.Show();			
		}
		
		
//------------------------------------------------------------------------------

		void Btn_rewind_outputClick(object sender, EventArgs e)
		{
			this.Hide();
			using(frm_rpt_converting_rewind frm_conv_rewind = new frm_rpt_converting_rewind())
				frm_conv_rewind.ShowDialog();
			this.Show();
		}
		
		void Btn_rewind_output_detailClick(object sender, EventArgs e)
		{
			this.Hide();
			using(frm_rpt_converting_rewind_detail frm_conv_rewind_detail = new frm_rpt_converting_rewind_detail())
				frm_conv_rewind_detail.ShowDialog();
			this.Show();			
		}
		
		void Btn_rewind_output_fastClick(object sender, EventArgs e)
		{
			this.Hide();
			using(frm_rpt_converting_rewind_fast frm_conv_rewind_fast = new frm_rpt_converting_rewind_fast())
				frm_conv_rewind_fast.ShowDialog();
			this.Show();			
		}
		
		void Btn_rewind_output_shift_fastClick(object sender, EventArgs e)
		{
			this.Hide();
			using(frm_rpt_converting_rewind_shift_fast frm_conv_rewind_shift_fast = new frm_rpt_converting_rewind_shift_fast())
				frm_conv_rewind_shift_fast.ShowDialog();
			this.Show();			
		}
		
		
		
		
		void Btn_bill_pcoreClick(object sender, EventArgs e)
		{
			this.Hide();
			using(frm_prod_converting_bill_papercore frm_conv_bom_pcore = new frm_prod_converting_bill_papercore())
				frm_conv_bom_pcore.ShowDialog();
			this.Show();
		}
		
		void Btn_prod_balClick(object sender, EventArgs e)
		{
			this.Hide();
			using(frm_rpt_converting_jr_balance_r2 frm_conv_jr_balance = new frm_rpt_converting_jr_balance_r2())
				frm_conv_jr_balance.ShowDialog();
			this.Show();
		}
		
		
		void Btn_get_soClick(object sender, EventArgs e)
		{
			this.Hide();
			using(frm_sales_order_download frm_get_so = new frm_sales_order_download())
				frm_get_so.ShowDialog();
			this.Show();
		}
		
		void Btn_backorder_rptClick(object sender, EventArgs e)
		{
			this.Hide();
			using(frm_rpt_conv_backorder frm_backorder = new frm_rpt_conv_backorder())
				frm_backorder.ShowDialog();
			this.Show();			
		}
		
		void Btn_prod_bal_lrClick(object sender, EventArgs e)
		{
			this.Hide();
			using(frm_rpt_converting_jr_balance_lr frm_conv_jr_balance_lr = new frm_rpt_converting_jr_balance_lr())
				frm_conv_jr_balance_lr.ShowDialog();
			this.Show();
		}
		
		
		
		void Btn_jr_outstandingClick(object sender, EventArgs e)
		{
			this.Hide();
			using (frm_rpt_converting_jr frm_rpt_conv_jr = new frm_rpt_converting_jr())
			frm_rpt_conv_jr.ShowDialog();
			this.Show();			
		}
		
		void Btn_maintenanceClick(object sender, EventArgs e)
		{
			this.Hide();
			using(frm_admin_factory frm_admin_fact1 = new frm_admin_factory())
				frm_admin_fact1.ShowDialog();
			this.Show();
		}
	}
}
