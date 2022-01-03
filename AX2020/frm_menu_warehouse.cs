using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic; // For generic collections like List.
using System.Data.SqlClient;      
using System.Data.Sql;
using System.Data;

namespace AX2020
{

	public partial class frm_menu_warehouse : Form
	{

	public static string sqlconn = "Server=AX-UAT; Password=sbax2020sbg; User ID=sbax2020; Initial Catalog=SBG_AX_2020; Integrated Security=false";


		
		
		public frm_menu_warehouse()
		{
			InitializeComponent();
			btn_jr_transfer.Enabled = false;
			this.ControlBox = false;
			lbl_username.Text = "User : " + frm_menu_system.userName;
		}
		
		
		void Btn_backClick(object sender, EventArgs e)
		{
			this.Close();	
		}

		
		void Btn_store_orderClick(object sender, EventArgs e)
		{
			this.Hide();
			using(frm_prod_converting_store frm_store = new frm_prod_converting_store())
				frm_store.ShowDialog();
			this.Show();	
		}
		
		
		void Btn_warehouse_orderClick(object sender, EventArgs e)
		{
			this.Hide();
			using(frm_prod_coating_store frm_store_coat = new frm_prod_coating_store())
				frm_store_coat.ShowDialog();
			this.Show();
		}
		
		void Btn_stock_receive_frClick(object sender, EventArgs e)
		{
			//MessageBox.Show("Use Microsoft Dynamic AX for stock receive");
//			this.Hide();
//			using(frm_prod_warehouse_fr_receive_ax frm_warehouse_fr_receive = new frm_prod_warehouse_fr_receive_ax())
//				frm_warehouse_fr_receive.ShowDialog();
//			this.Show();	
			this.Hide();
			using(frm_prod_warehouse_fr_receive_pack frm_prod_warehouse_fr_receive_pack1 = new frm_prod_warehouse_fr_receive_pack())
			frm_prod_warehouse_fr_receive_pack1.ShowDialog();
			this.Show();			
		}
				
		
		void Btn_stock_receive_klinerClick(object sender, EventArgs e)
		{
			MessageBox.Show("Use Microsoft Dynamic AX for stock receive");
//			this.Hide();
//			using(frm_prod_warehouse_kliner_received frm_warehouse_kliner_receive = new frm_prod_warehouse_kliner_received())
//				frm_warehouse_kliner_receive.ShowDialog();
//			this.Show();
		}
		
		void Btn_stock_receive_ribbonClick(object sender, EventArgs e)
		{
			MessageBox.Show("Use Microsoft Dynamic AX for stock receive");
//			this.Hide();
//			using(frm_prod_warehouse_ribbon_received frm_warehouse_ribbon_receive = new frm_prod_warehouse_ribbon_received())
//				frm_warehouse_ribbon_receive.ShowDialog();
//			this.Show();			
		}
		
		void Btn_stock_receive_filmClick(object sender, EventArgs e)
		{
			MessageBox.Show("Use Microsoft Dynamic AX for stock receive");
//  			this.Hide();
//			using(frm_prod_warehouse_stretch_film_received frm_warehouse_stretch_film_receive = new frm_prod_warehouse_stretch_film_received())
//				frm_warehouse_stretch_film_receive.ShowDialog();
//			this.Show();			
		}
		
		
		
		void Btn_stock_receive_jrClick(object sender, EventArgs e)
		{
			//MessageBox.Show("Use Microsoft Dynamic AX for stock receive");
			this.Hide();
			using(frm_prod_warehouse_jr_receive_barcode frm_prod_warehouse_jr_receive_barcode2 = new frm_prod_warehouse_jr_receive_barcode())
				frm_prod_warehouse_jr_receive_barcode2.ShowDialog();
			this.Show();
			//frm_prod_warehouse_jr_receive_barcode;
		}
		
		void Btn_get_soClick(object sender, EventArgs e)
		{
			this.Hide();
			using(frm_sales_order_download frm_get_so = new frm_sales_order_download())
				frm_get_so.ShowDialog();
			this.Show();
		}
		
		
		
		void Btn_stock_receive_fr_checklistClick(object sender, EventArgs e)
		{
			this.Hide();
			using(frm_rpt_warehouse_fr_checklist frm_warehouse_fr_rpt = new frm_rpt_warehouse_fr_checklist())
				frm_warehouse_fr_rpt.ShowDialog();
			this.Show();
		}
		
		void Btn_convertingClick(object sender, EventArgs e)
		{
			this.Hide();
			using(frm_rpt_converting_prod_detail_3 frm_conv_rpt = new frm_rpt_converting_prod_detail_3())
				frm_conv_rpt.ShowDialog();
			this.Show();
						
		}
		
		void Btn_sample_requestClick(object sender, EventArgs e)
		{
			this.Hide();
			using(frm_prod_warehouse_sample frm_sample = new frm_prod_warehouse_sample())
				frm_sample.ShowDialog();
			this.Show();			
		}
		
		void Btn_polocalClick(object sender, EventArgs e)
		{
			
			this.Hide();
			using(frm_po_local frm_po_local1 = new frm_po_local())
			frm_po_local1.ShowDialog();
			this.Show();	
		}
		
		void Btn_poimportClick(object sender, EventArgs e)
		{
			
			this.Hide();
			using(frm_po_import frm_po_import1 = new frm_po_import())
			frm_po_import1.ShowDialog();
			this.Show();
			
		}
		
		void Button2Click(object sender, EventArgs e)
		{
			this.Hide();
			using(frm_conv_sales_backorder_due frm_conv_sales_backorder_due1 = new frm_conv_sales_backorder_due())
			frm_conv_sales_backorder_due1.ShowDialog();
			this.Show();
			
		}
		
		void Button1Click(object sender, EventArgs e)
		{
			this.Hide();
			using(frm_conv_so_delivery_next_5days frm_conv_so_delivery_next_5days1 = new frm_conv_so_delivery_next_5days())
			frm_conv_so_delivery_next_5days1.ShowDialog();
			this.Show();
		}
		
	
		
		void Btn_ax_stock_transferClick(object sender, EventArgs e)
		{
			this.Hide();
			using(frm_prod_warehouse_transfer_bopp frm_warehouse_transfer_bopp = new frm_prod_warehouse_transfer_bopp())
			frm_warehouse_transfer_bopp.ShowDialog();
			this.Show();
		}
		
		void Btn_whse_transfer_vmClick(object sender, EventArgs e)
		{
			this.Hide();
			using(frm_prod_warehouse_transfer_jr frm_warehouse_transfer_jr = new frm_prod_warehouse_transfer_jr())
			frm_warehouse_transfer_jr.ShowDialog();
			this.Show();
		}
		
		void Btn_jr_movClick(object sender, EventArgs e)
		{
			this.Hide();
			using(frm_prod_warehouse_transfer_mov frm_warehouse_transfer_mov = new frm_prod_warehouse_transfer_mov())
			frm_warehouse_transfer_mov.ShowDialog();
			this.Show();
		}
		
		void Btn_stock_recive_jrClick(object sender, EventArgs e)
		{
			this.Hide();
			using(frm_prod_warehouse_transfer_receive frm_warehouse_received_jr = new frm_prod_warehouse_transfer_receive())
			frm_warehouse_received_jr.ShowDialog();
			this.Show();
			
		}
		
		void Btn_stock_recive_frClick(object sender, EventArgs e)
		{
			this.Hide();
			using(frm_prod_warehouse_transfer_received_fr frm_warehouse_received_fr = new frm_prod_warehouse_transfer_received_fr())
			frm_warehouse_received_fr.ShowDialog();
			this.Show();
			
		}
		
		void Btn_menu_wj303Click(object sender, EventArgs e)
		{
			this.Hide();
			using(frm_prod_warehouse_ax_print frm_warehouse_ax_print = new frm_prod_warehouse_ax_print())
			frm_warehouse_ax_print.ShowDialog();
			this.Show();
						
		}
		
		void Btn_bopp_labelClick(object sender, EventArgs e)
		{
			this.Hide();
			using(frm_rpt_warehouse_bopp_print_2 frm_warehouse_bopp_print = new frm_rpt_warehouse_bopp_print_2())
			frm_warehouse_bopp_print.ShowDialog();
			this.Show();
		}
		
		void Btn_bopp_uploadClick(object sender, EventArgs e)
		{
			this.Hide();
			using(frm_rpt_warehouse_bopp_print frm_warehouse_bopp_upload = new frm_rpt_warehouse_bopp_print())
			frm_warehouse_bopp_upload.ShowDialog();
			this.Show();
		}
	}
}
