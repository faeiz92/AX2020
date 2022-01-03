using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic; // For generic collections like List.
using System.Data.SqlClient;      
using System.Data.Sql;
using System.Data;

namespace AX2020
{
	
	public partial class frm_menu_converting : Form
	{
		bool conv, convrpt;
		public static string sqlconn = "Server=AX-UAT; Password=sbax2020sbg; User ID=sbax2020; Initial Catalog=SBG_AX_2020; Integrated Security=false";
		
		public frm_menu_converting()
		{
			InitializeComponent();
			this.ControlBox = false;
			lbl_username.Text = "User : " + frm_menu_system.userName;
		}
		
		
		void Btn_backClick(object sender, EventArgs e)
		{
			this.Close();	
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
		
		
		
		void Btn_packClick(object sender, EventArgs e)
		{
			this.Hide();
			using(frm_prod_converting_output_packing frm_conv_pack = new frm_prod_converting_output_packing())
				frm_conv_pack.ShowDialog();
			this.Show();			
		}
		
		
		void Btn_slitClick(object sender, EventArgs e)
		{
			this.Hide();
			using(frm_prod_converting_output_slitting frm_conv_slit = new frm_prod_converting_output_slitting())
				frm_conv_slit.ShowDialog();
			this.Show();			
		}
		
		void Btn_rewindClick(object sender, EventArgs e)
		{
			this.Hide();
			using(frm_prod_converting_output_rewinding_r4 frm_conv_rewind = new frm_prod_converting_output_rewinding_r4())
				frm_conv_rewind.ShowDialog();
			this.Show();
		}
		
		
		void Btn_cutClick(object sender, EventArgs e)
		{
			this.Hide();
			using(frm_prod_converting_output_cutting_r1 frm_conv_cut = new frm_prod_converting_output_cutting_r1())
				frm_conv_cut.ShowDialog();
			this.Show();			
		}
		
		
		
		
		bool checkModule()
		{
			SqlConnection con = new SqlConnection(sqlconn);
			SqlCommand cmd = new SqlCommand();
			
			try 
			{
				cmd.CommandText = "select sysconv, sysconvrpt from TBL_ADMIN_USER_MODULE where sysusername = @username";
				cmd.Parameters.AddWithValue("@username", frm_menu_system.userName);
				cmd.Connection = con;
				con.Open();
				SqlDataReader rd = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
				
				if (rd.HasRows)
				{
					while (rd.Read())
					{	
						conv = Convert.ToBoolean(rd["sysconv"]);
						convrpt = Convert.ToBoolean(rd["sysconvrpt"]);   
					}
				} 
				else 
				{
					MessageBox.Show("Error - Converting User Module DB \nCannot find data");
					return false;		
				}
			} 
			catch (Exception ex) 
			{
				MessageBox.Show("Error - Converting User Module DB \nCannot load DB \n" + ex.Message + ex.ToString());
				return false;
			} 
			finally 
			{
				con.Close();
			}
			
			con.Dispose();
			con = null;
			cmd = null;
			return true;
		}
		
		
		
		void Frm_menu_convertingLoad(object sender, EventArgs e)
		{
			if(!checkModule())
				return;
			
			if(conv == false)
			{
				btn_slit.Enabled = false;
				btn_rewind.Enabled = false;
				btn_cut.Enabled = false;
				btn_pack.Enabled = false;
			}

			if(convrpt == false)
			{
				btn_slit_output.Enabled = false;
				btn_slit_output_detail.Enabled = false;
				btn_slit_output_fast.Enabled = false;
				btn_slit_output_shift_fast.Enabled = false;
				
				
				btn_rewind_output.Enabled = false;
				btn_rewind_output_detail.Enabled = false;
				btn_rewind_output_fast.Enabled = false;
				btn_rewind_output_shift_fast.Enabled = false;
				
				
				btn_cut_output.Enabled = false;
				btn_cut_output_detail.Enabled = false;
				btn_cut_output_fast.Enabled = false;
				btn_cut_output_shift_fast.Enabled = false;
				
				
				btn_pack_output.Enabled = false;
				btn_pack_output_detail.Enabled = false;
				btn_pack_output_fast.Enabled = false;
				btn_pack_output_shift_fast.Enabled = false;
			}
			
			if(frm_menu_system.userName.ToUpper() == "ADMIN")
			{
				btn_slit_pack.Enabled=true;
			}
		}
		
		void Btn_pack_reprintClick(object sender, EventArgs e)
		{
			this.Hide();
			using(frm_prod_converting_output_packing_print frm_conv_pack_print = new frm_prod_converting_output_packing_print())
				frm_conv_pack_print.ShowDialog();
			this.Show();			
		}
		
		void btn_slit_packClick(object sender, EventArgs e)
		{
			this.Hide();
			using(frm_prod_converting_output_packing_r4 frm_conv_slit_pack = new frm_prod_converting_output_packing_r4())
				frm_conv_slit_pack.ShowDialog();
			this.Show();
		}
		
		void Btn_slit_balClick(object sender, EventArgs e)
		{
			this.Hide();
			using(frm_prod_converting_output_shipmark_bal frm_conv_shipmark_bal = new frm_prod_converting_output_shipmark_bal())
				frm_conv_shipmark_bal.ShowDialog();
			this.Show();
		}
		
		
		
		void Btn_jr_bal_rptClick(object sender, EventArgs e)
		{
			this.Hide();
			using(frm_rpt_converting_jr_balance frm_conv_jr_bal_rpt = new frm_rpt_converting_jr_balance())
				frm_conv_jr_bal_rpt.ShowDialog();
			this.Show();
		}
		
		void Btn_rewind_labelClick(object sender, EventArgs e)
		{
			this.Hide();
			using(frm_prod_converting_output_rewinding_print frm_conv_rewind_print = new frm_prod_converting_output_rewinding_print())
				frm_conv_rewind_print.ShowDialog();
			this.Show();
		}
		
		void Btn_ship_markClick(object sender, EventArgs e)
		{
			this.Hide();
			using(frm_rpt_converting_jr_balance_jrstockcode frm_conv_shipmark = new frm_rpt_converting_jr_balance_jrstockcode())
				frm_conv_shipmark.ShowDialog();
			this.Show();	
			
		}
				
		
		void Btn_po_prClick(object sender, EventArgs e)
		{
			
			this.Hide();
			using(frm_po_via_pr frm_po_via_pr2 = new frm_po_via_pr())
				frm_po_via_pr2.ShowDialog();
			this.Show();
		}
		
		void Btn_stock_receiveClick(object sender, EventArgs e)
		{
			this.Hide();
			using(frm_prod_converting_transfer_received frm_prod_conv_trans = new frm_prod_converting_transfer_received())
				frm_prod_conv_trans.ShowDialog();
			this.Show();
		}
		
		void Btn_prod_trackClick(object sender, EventArgs e)
		{
			this.Hide();
			using(frm_prod_converting_jo_tracking frm_prod_converting_jo_tracking1 = new frm_prod_converting_jo_tracking())
			frm_prod_converting_jo_tracking1.ShowDialog();
			this.Show();
		}
		
		void Btn_rewind_openClick(object sender, EventArgs e)
		{
			this.Hide();
			using(frm_prod_converting_output_rewinding_open_r1 frm_conv_rewind_open = new frm_prod_converting_output_rewinding_open_r1())
				frm_conv_rewind_open.ShowDialog();
			this.Show();
			
		}
		
		void Button1Click(object sender, EventArgs e)
		{
			this.Hide();
			using(frm_prod_conv_menu_small_rewinding frm_prod_conv_menu_small_rewinding1 = new frm_prod_conv_menu_small_rewinding())
				frm_prod_conv_menu_small_rewinding1.ShowDialog();
			this.Show();
		}
		
		void Btn_jr_balClick(object sender, EventArgs e)
		{
			
			this.Hide();
			using(frm_prod_conv_jr_balance frm_prod_conv_jr_balance1 = new frm_prod_conv_jr_balance())
				frm_prod_conv_jr_balance1.ShowDialog();
			this.Show();
		}
		
		void Btn_print_ax_wl_labelClick(object sender, EventArgs e)
		{
			this.Hide();
			using(frm_prod_conv_ax_wl_print_one frm_prod_conv_ax_wl_print = new frm_prod_conv_ax_wl_print_one())
				frm_prod_conv_ax_wl_print.ShowDialog();
			this.Show();
		}
	}
}
