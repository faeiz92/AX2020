using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic; // For generic collections like List.
using System.Data.SqlClient;      
using System.Data.Sql;
using System.Data;

namespace AX2020
{
	
	public partial class frm_menu_coating : Form
	{
		bool coat, coatrpt;
		public static string sqlconn = "Server=AX-UAT; Password=sbax2020sbg; User ID=sbax2020; Initial Catalog=SBG_AX_2020; Integrated Security=false";
		
		public frm_menu_coating()
		{
			InitializeComponent();
			
		}
		
		void Btn_joClick(object sender, EventArgs e)
		{
			this.Hide();
			using (frm_prod_coating_jo frm_coat_jo = new frm_prod_coating_jo())
			frm_coat_jo.ShowDialog();
			this.Show();
			
			
		}
		
		void Btn_dsClick(object sender, EventArgs e)
		{
			this.Hide();
			using (frm_prod_coating_double_side frm_coat_double_side = new frm_prod_coating_double_side())
			frm_coat_double_side.ShowDialog();
			this.Show(); 
		}
		
		void Btn_poopClick(object sender, EventArgs e)
		{
			this.Hide();
			using (frm_prod_coating_jo_printing frm_coating_printing = new frm_prod_coating_jo_printing())
			frm_coating_printing.ShowDialog();
			this.Show();
		}
		
		void Btn_backClick(object sender, EventArgs e)
		{
			this.Close();
		}
		
		void Btn_swrClick(object sender, EventArgs e)
		{
			
			this.Hide();
			using (frm_prod_coating_schwaner frm_coating_schwaner = new frm_prod_coating_schwaner())
			frm_coating_schwaner.ShowDialog();
			this.Show();
			//frm_prod_coating_schwaner
		}
		
	
		
		void Btn_BSOClick(object sender, EventArgs e)
		{
			
		}
		
		void GroupBox1Enter(object sender, EventArgs e)
		{
			
		}
		
		bool checkModule()
		{
			SqlConnection con = new SqlConnection(sqlconn);
			SqlCommand cmd = new SqlCommand();
			
			try 
			{
				cmd.CommandText = "select syscoat, syscoatrpt from TBL_ADMIN_USER_MODULE where sysusername = @username";
				cmd.Parameters.AddWithValue("@username", frm_menu_system.userName);
				cmd.Connection = con;
				con.Open();
				SqlDataReader rd = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
				
				if (rd.HasRows)
				{
					while (rd.Read())
					{	
						coat = Convert.ToBoolean(rd["syscoat"]);
						coatrpt = Convert.ToBoolean(rd["syscoatrpt"]);   
					}
				} 
				else 
				{
					MessageBox.Show("Error - Coating User Module DB \nCannot find data");
					return false;		
				}
			} 
			catch (Exception ex) 
			{
				MessageBox.Show("Error - Coating User Module DB \nCannot load DB \n" + ex.Message + ex.ToString());
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
		
		void Frm_menu_coatingLoad(object sender, EventArgs e)
		{
			if(!checkModule())
				return;
			
			if(coat == false)
			{
			}

			if(coatrpt == false)
			{
				btn_po.Enabled = false;
				btn_pc.Enabled = false;
				btn_pod.Enabled = false;
				btn_podj.Enabled = false;
				btn_pb.Enabled = false;
				btn_pw.Enabled = false;
				btn_cjsm.Enabled = false;
				btn_cjso.Enabled = false;
				btn_ple.Enabled = false;
						
			}			
		}
		
		void Button2Click(object sender, EventArgs e)
		{
			
		}
		
		void GroupBox2Enter(object sender, EventArgs e)
		{
			
		}
		
		void Button4Click(object sender, EventArgs e)
		{
			this.Hide();
			using (frm_rpt_coating_Bgrade frm_prod_output = new frm_rpt_coating_Bgrade())
			 frm_prod_output.ShowDialog();
			this.Show();
		}
		
		void Btn_bomClick(object sender, EventArgs e)
		{
			this.Hide();
			using (frm_prod_coating_printing_bom frm_coating_bom = new frm_prod_coating_printing_bom())
			frm_coating_bom.ShowDialog();
			this.Show();			
		}
		
		void Btn_prod_coating_prodClick(object sender, EventArgs e)
		{
			this.Hide();
			using (frm_rpt_coating_output frm_prod_output = new frm_rpt_coating_output())
			 frm_prod_output.ShowDialog();
			this.Show();
		}
		
		void Button1Click(object sender, EventArgs e)
		{
			this.Hide();
			using (frm_rpt_coating_consumption prod_consumption = new frm_rpt_coating_consumption())
			 prod_consumption.ShowDialog();
			this.Show();
		}
		
		
		
		
		
		void Button8Click(object sender, EventArgs e)
		{
			this.Hide();
			using (frm_rpt_coating_local frm_prod_output = new frm_rpt_coating_local())
			 frm_prod_output.ShowDialog();
			this.Show();
		}
		
		void Button9Click(object sender, EventArgs e)
		{
			this.Hide();
			using (frm_rpt_coating_output_detail_jo frm_prod_output = new frm_rpt_coating_output_detail_jo())
			frm_prod_output.ShowDialog();
			this.Show();
		}
		
		void Button7Click(object sender, EventArgs e)
		{
			this.Hide();
			using (frm_rpt_coating_output_detail frm_prod_output5 = new frm_rpt_coating_output_detail())
			frm_prod_output5.ShowDialog();
			this.Show();
		}
		
		void Button10Click(object sender, EventArgs e)
		{
			this.Hide();
			using (frm_rpt_coating_check_jrshipmark frm_rpt_coating_check_jrshipmark5 = new frm_rpt_coating_check_jrshipmark())
			frm_rpt_coating_check_jrshipmark5.ShowDialog();
			this.Show();
		}
		
		void Button6Click(object sender, EventArgs e)
		{
			this.Hide();
			using (frm_rpt_coating_check_saleorder frm_rpt_coating_check_saleorder5 = new frm_rpt_coating_check_saleorder())
			frm_rpt_coating_check_saleorder5.ShowDialog();
			this.Show();
		}
		
		void Button5Click(object sender, EventArgs e)
		{
			this.Hide();
			using (frm_rpt_coating_wastage frm_rpt_coating_check_saleorder6 = new frm_rpt_coating_wastage())
			frm_rpt_coating_check_saleorder6.ShowDialog();
			this.Show();

		}
		
		void Button11Click(object sender, EventArgs e)
		{
			this.Hide();
			using (frm_rpt_coating_output frm_rpt_coating_check_saleorder9 = new frm_rpt_coating_output())
			frm_rpt_coating_check_saleorder9.ShowDialog();
			this.Show();
		}
		
		void Btn_pjoClick(object sender, EventArgs e)
		{
			
			this.Hide();
			using (frm_prod_coating_jo_print frm_prod_coating_jo_print1 = new frm_prod_coating_jo_print())
			frm_prod_coating_jo_print1.ShowDialog();
			this.Show();
			
		}
		
		void Btn_CgradeClick(object sender, EventArgs e)
		{
			using (frm_rpt_coating_Cgrade frm_rpt_coating_Cgrade3 = new frm_rpt_coating_Cgrade())
			frm_rpt_coating_Cgrade3.ShowDialog();
			this.Show();
		}
		
		void Btn_conv_outstanding_jrClick(object sender, EventArgs e)
		{
			using (frm_rpt_converting_jr frm_rpt_conv_jr = new frm_rpt_converting_jr())
			frm_rpt_conv_jr.ShowDialog();
			this.Show();			
		}
		
		void Btn_sumboppClick(object sender, EventArgs e)
		{
			using (frm_rpt_summary_bopp_stock_status frm_rpt_summary_bopp_stock_status2 = new frm_rpt_summary_bopp_stock_status())
			frm_rpt_summary_bopp_stock_status2.ShowDialog();
			this.Show();	
		}
		
		void Btn_stock_receiveClick(object sender, EventArgs e)
		{
			this.Hide();
			using(frm_prod_coating_transfer_received frm_prod_coat_trans = new frm_prod_coating_transfer_received())
				frm_prod_coat_trans.ShowDialog();
			this.Show();
			
		}
		
		void Btn_prod_output_overweightClick(object sender, EventArgs e)
		{
			this.Hide();
			using(frm_rpt_coating_output_overweight frm_prod_coat_over = new frm_rpt_coating_output_overweight())
				frm_prod_coat_over.ShowDialog();
			this.Show();
			
		}
		
		void Btn_prod_output_underweightClick(object sender, EventArgs e)
		{
			this.Hide();
			using(frm_rpt_coating_output_underweight frm_prod_coat_under = new frm_rpt_coating_output_underweight())
				frm_prod_coat_under.ShowDialog();
			this.Show();
		}
		
		void Btn_capacityClick(object sender, EventArgs e)
		{
			this.Hide();
			using(frm_rpt_coating_capacity frm_rpt_coating_capacity1 = new frm_rpt_coating_capacity())
			frm_rpt_coating_capacity1.ShowDialog();
			this.Show();
		}
	}
}
