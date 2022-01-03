using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic; // For generic collections like List.
using System.Data.SqlClient;      
using System.Data.Sql;

namespace AX2020
{
	
	public partial class frm_menu_management : Form
	{
		public static string sqlconn = "Server=AX-UAT; Password=sbax2020sbg; User ID=sbax2020; Initial Catalog=SBG_AX_2020; Integrated Security=false";
        
		public frm_menu_management()
		{
			InitializeComponent();
			lbl_username.Text = "User : " + frm_menu_system.userName;	
		}
		
		void Btn_backClick(object sender, EventArgs e)
		{
			this.Close();
		}
		
		void Btn_prod_track_statClick(object sender, EventArgs e)
		{
			this.Hide();
			using(frm_rpt_converting_tracking frm_conv_tracking = new frm_rpt_converting_tracking())
				frm_conv_tracking.ShowDialog();
			this.Show();
		}
		
		void Btn_get_soClick(object sender, EventArgs e)
		{
			this.Hide();
			using(frm_sales_order_download frm_get_so = new frm_sales_order_download())
				frm_get_so.ShowDialog();
			this.Show();			
		}
		
		
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
			using(frm_rpt_converting_prod_detail frm_conv_prod_detail = new frm_rpt_converting_prod_detail())
				frm_conv_prod_detail.ShowDialog();
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
		
		
		//--------------------------------------------------------------------------
		
		void Btn_poClick(object sender, EventArgs e)
		{
			this.Hide();
			using (frm_rpt_coating_output frm_rpt_coating_check_saleorder9 = new frm_rpt_coating_output())
			frm_rpt_coating_check_saleorder9.ShowDialog();
			this.Show();			
		}
		
		void Btn_pbClick(object sender, EventArgs e)
		{
			this.Hide();
			using (frm_rpt_coating_Bgrade frm_prod_output = new frm_rpt_coating_Bgrade())
			 frm_prod_output.ShowDialog();
			this.Show();			
		}
		
		void Btn_podClick(object sender, EventArgs e)
		{
			this.Hide();
			using (frm_rpt_coating_output_detail frm_prod_output5 = new frm_rpt_coating_output_detail())
			frm_prod_output5.ShowDialog();
			this.Show();			
		}
		
		void Btn_cjsmClick(object sender, EventArgs e)
		{
			this.Hide();
			using (frm_rpt_coating_check_jrshipmark frm_rpt_coating_check_jrshipmark5 = new frm_rpt_coating_check_jrshipmark())
			frm_rpt_coating_check_jrshipmark5.ShowDialog();
			this.Show();			
		}
		
		void Btn_pcClick(object sender, EventArgs e)
		{
			this.Hide();
			using (frm_rpt_coating_consumption prod_consumption = new frm_rpt_coating_consumption())
			 prod_consumption.ShowDialog();
			this.Show();			
		}
		
		void Btn_pwClick(object sender, EventArgs e)
		{
			this.Hide();
			using (frm_rpt_coating_wastage frm_rpt_coating_wastage6 = new frm_rpt_coating_wastage())
			frm_rpt_coating_wastage6.ShowDialog();
			this.Show();
			
		}
		
		void Btn_podjClick(object sender, EventArgs e)
		{
			this.Hide();
			using (frm_rpt_coating_output_detail_jo frm_prod_output = new frm_rpt_coating_output_detail_jo())
			frm_prod_output.ShowDialog();
			this.Show();			
		}
		
		void Btn_cjsoClick(object sender, EventArgs e)
		{
			this.Hide();
			using (frm_rpt_coating_check_saleorder frm_rpt_coating_check_saleorder5 = new frm_rpt_coating_check_saleorder())
			frm_rpt_coating_check_saleorder5.ShowDialog();
			this.Show();			
		}
		
		void Btn_pleClick(object sender, EventArgs e)
		{
			this.Hide();
			using (frm_rpt_coating_local frm_prod_output = new frm_rpt_coating_local())
			 frm_prod_output.ShowDialog();
			this.Show();			
		}
		
		void Frm_menu_managementLoad(object sender, EventArgs e)
		{
			string dept = string.Empty; 
			
			SqlConnection con_Check_Dept = new SqlConnection(sqlconn);
			SqlCommand cmd = new SqlCommand();
			
			try 
			{
				cmd.CommandText = @"select * from TBL_ADMIN_USER_ACCESS where sysusername = @username";// + "' and JODOCNO <> 'SMSO124608'";
				cmd.Parameters.AddWithValue("@username",  frm_menu_system.userName.ToUpper());
				cmd.Connection = con_Check_Dept;
				con_Check_Dept.Open();
				SqlDataReader rd_Check_Dept = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);

				if (rd_Check_Dept.HasRows)
				{
					if (rd_Check_Dept.Read())
					{
						dept = rd_Check_Dept["sysdept"].ToString();
					}

				}
			}
			catch (Exception ex)
			{
				con_Check_Dept.Close();
				MessageBox.Show("Error - Menu Management Dept " + ex.Message + ex.ToString());
				return;
			} 
			finally 
			{
				con_Check_Dept.Close();
			}
			
			con_Check_Dept.Dispose();
			cmd.Dispose();
			con_Check_Dept = null;
			cmd = null;	

			if (dept == "ACCOUNT & FINANCE")
			{
				btn_get_so.Enabled =  false;
				btn_prod_track_stat.Enabled = false;
			}
			
		}
		
		void Button1Click(object sender, EventArgs e)
		{
			this.Hide();
			using(frm_rpt_glue_output frm_glue_output1 = new frm_rpt_glue_output())
			 frm_glue_output1.ShowDialog();
			this.Show();
		}
		
		void Button3Click(object sender, EventArgs e)
		{
			this.Hide();
			using(frm_rpt_glue_consume frm_glue_consume1 = new frm_rpt_glue_consume())
			frm_glue_consume1.ShowDialog();
			this.Show();
		}
		
		void Button2Click(object sender, EventArgs e)
		{
			this.Hide();
			using(frm_rpt_glue_consume_stockcode frm_glue_consume_1 = new frm_rpt_glue_consume_stockcode())
			      frm_glue_consume_1.ShowDialog();
			this.Show();	
		}
		
		void Btn_item_masterClick(object sender, EventArgs e)
		{
			this.Hide();
			using(frm_ax_item_master frm_item_master = new frm_ax_item_master())
			      frm_item_master.ShowDialog();
			this.Show();
			
		}
	}
}
