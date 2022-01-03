using System;
using System.Drawing;									
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Data;						
using System.Collections.Generic;		/***header untuk jalankan akktiviti/jenis coding dalam c#***/
using System.ComponentModel;			
using System.IO.Ports;
using System.Text;
using CommonFunction;
using CommonLibrary;
using CommonControl.Functions;
using System.Drawing.Drawing2D;
using System.IO;
using fyiReporting.RdlViewer;
using fyiReporting;
using System.Linq;

namespace AX2020
{

	public partial class frm_menu_main : Form
	{
		string username = "";
		public static string sqlconn = "Server=AX-UAT; Password=sbax2020sbg; User ID=sbax2020; Initial Catalog=SBG_AX_2020; Integrated Security=false";
		bool sales, plan, whse, coat, coatrpt, conv, convrpt, glue, gluerpt, ribbon, ribbonrpt, papercore, papercorerpt, kliner, klinerrpt, qac, ship, admin, qis, pack, stretchfilm, stretchfilmrpt, mngmt, pro_whse;
		bool schwaner, doubleside, cino;
		
		public frm_menu_main()
		{
			InitializeComponent();
			
			//btn_schwaner.Enabled = false;
//			btn_ci.Enabled = false;
			
			//this.ControlBox = false;
			username = frm_menu_system.userName;
			lbl_username.Text = "User : " + username;	
		}
		
		protected override CreateParams CreateParams
	    {
	        get
	        {
	            CreateParams parms = base.CreateParams;
	            parms.ClassStyle |= 0x200;  // CS_NOCLOSE
	            return parms;
	        }
	    }
		void Frm_menu_mainLoad(object sender, EventArgs e)
		{
			if (!checkModule())
			{
				this.Close();
			}
		}
		
		bool checkModule()
		{
			SqlConnection con = new SqlConnection(sqlconn);
			SqlCommand cmd = new SqlCommand();
			
			try 
			{
				cmd.CommandText = "select * from TBL_ADMIN_USER_MODULE where sysusername = @username";
				cmd.Parameters.AddWithValue("@username", username);
				cmd.Connection = con;
				con.Open();
				SqlDataReader rd = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
				
				if (rd.HasRows)
				{
					while (rd.Read())
					{
						sales = Convert.ToBoolean(rd["syssales"]);
						plan = Convert.ToBoolean(rd["sysplan"]);
						whse = Convert.ToBoolean(rd["syswhse"]);
						coat = Convert.ToBoolean(rd["syscoat"]);
						coatrpt = Convert.ToBoolean(rd["syscoatrpt"]);
						conv = Convert.ToBoolean(rd["sysconv"]);
						convrpt = Convert.ToBoolean(rd["sysconvrpt"]);
						glue = Convert.ToBoolean(rd["sysglue"]);
						gluerpt = Convert.ToBoolean(rd["sysgluerpt"]);
						ribbon = Convert.ToBoolean(rd["sysribbon"]);
						ribbonrpt = Convert.ToBoolean(rd["sysribbonrpt"]);
						papercore = Convert.ToBoolean(rd["syspapercore"]);
						papercorerpt = Convert.ToBoolean(rd["syspapercorerpt"]);
						kliner = Convert.ToBoolean(rd["syskliner"]);
						klinerrpt = Convert.ToBoolean(rd["sysklinerrpt"]);
						qac = Convert.ToBoolean(rd["sysqac"]);
						ship = Convert.ToBoolean(rd["sysshipping"]);
						admin = Convert.ToBoolean(rd["sysadmin"]);
						stretchfilm = Convert.ToBoolean(rd["sysstretchfilm"]);
						stretchfilmrpt = Convert.ToBoolean(rd["sysstretchfilmrpt"]);
						qis = Convert.ToBoolean(rd["sysqis"]);
						pack = Convert.ToBoolean(rd["syspack"]);
						
						mngmt = Convert.ToBoolean(rd["sysmngmt"]);						
						pro_whse = Convert.ToBoolean(rd["sysprocurement"]);
						
//						cino = Convert.ToBoolean(rd["syscino"]);
//						doubleside = Convert.ToBoolean(rd["sysdoubleside"]);
//						schwaner = Convert.ToBoolean(rd["sysschwaner"]);
						
						
					       
					 }
				} 
				else 
				{
					MessageBox.Show("Error - Admin User Module DB \nCannot find data");
					return false;
					
				}
			} 
			catch (Exception ex) 
			{
				MessageBox.Show("Error - Admin User Module DB \nCannot load DB \n" + ex.Message + ex.ToString());
				return false;
			} 
			finally 
			{
				con.Close();
				SetButtonsEnabledDisabled(btn_sales, sales);
				SetButtonsEnabledDisabled(btn_plan, plan);
				SetButtonsEnabledDisabled(btn_warehouse, whse);
				
				//if ((coat==true && coatrpt==false)||(coat==false && coatrpt==true)||(coat==true && coatrpt==true))
				if (coat==false && coatrpt==false)
				{
					SetButtonsEnabledDisabled(btn_coat, coat);
				}
				//if ((conv==true && convrpt==false)||(conv==false && convrpt==true)||(conv==true && convrpt==true))
				if (conv==false && convrpt==false)
				{
					SetButtonsEnabledDisabled(btn_conv, conv);
				}
				//if ((glue==true && gluerpt==false)||(glue==false && gluerpt==true)||(glue==true && gluerpt==true))
				if (glue==false && gluerpt==false)
				{
					SetButtonsEnabledDisabled(btn_glue, glue);
				}
				
				//if ((ribbon==true && ribbonrpt==false)||(ribbon==false && ribbonrpt ==true)||(ribbon==true && ribbonrpt ==true))
				if (ribbon==false && ribbonrpt==false)
				{
					SetButtonsEnabledDisabled(btn_ribbon, ribbon);
				}
				
				//if ((papercore==true && papercorerpt==false)||(papercore==false && papercorerpt==true)||(papercore==true && papercorerpt==true))
				if (papercore==false && papercorerpt==false)
				{
					SetButtonsEnabledDisabled(btn_pcore, papercore);
				}
				//if ((kliner==true && klinerrpt==false)||(kliner==false && klinerrpt==true)||(kliner==true && klinerrpt==true))
				if (kliner==false && klinerrpt==false)
				{
					SetButtonsEnabledDisabled(btn_kliner, kliner);
				}
				//if ((stretchfilm==true && stretchfilmrpt==false)||(stretchfilm==false && stretchfilmrpt==true)||(stretchfilm==true && stretchfilmrpt==true))
				if (stretchfilm==false && stretchfilmrpt==false)
				{
					SetButtonsEnabledDisabled(btn_stretch_film, stretchfilm);
				}
				
				
				if (pro_whse==false && pro_whse==false)
				{
					SetButtonsEnabledDisabled(btn_procrument, pro_whse);
				}
				
				
				
				
				SetButtonsEnabledDisabled(btn_qac, qac);
				SetButtonsEnabledDisabled(btn_ship, ship);
				SetButtonsEnabledDisabled(btn_mngmt, mngmt);
				SetButtonsEnabledDisabled(btn_qis, qis);
				SetButtonsEnabledDisabled(btn_pack, pack);
				SetButtonsEnabledDisabled(btn_admin, admin);
				
				SetButtonsEnabledDisabled(btn_ci, cino);
				//SetButtonsEnabledDisabled(btn_doubleside, doubleside);
				SetButtonsEnabledDisabled(btn_schwaner, schwaner);
				
				//MessageBox.Show(sales.ToString() + plan.ToString() + whse.ToString() + coat.ToString() + conv.ToString() + glue.ToString() + ribbon.ToString() + papercore.ToString() + kliner.ToString() + qac.ToString() + ship.ToString() + admin.ToString() + qis.ToString() + pack.ToString() + stretch.ToString() + mngmt.ToString() );
				
			}
			
			con.Dispose();
			con = null;
			cmd = null;
			return true;
		}
		
		private void SetButtonsEnabledDisabled(Button btn, bool isEnabled)
		{
		    btn.Enabled = isEnabled;
		}
		
		void Btn_logoutClick(object sender, EventArgs e)
		{
			DialogResult logout = new DialogResult();
            logout = MessageBox.Show("Do you want to logout?", "Cancel", 
                     MessageBoxButtons.YesNo, 
                     MessageBoxIcon.Warning, 
                     MessageBoxDefaultButton.Button2);
            if (logout == DialogResult.Yes)
            {
                Application.Exit();
                //this.Close();
            }
		}
		
		void Btn_coatClick(object sender, EventArgs e)
		{
			this.Hide();
			using(frm_menu_coating frm_coat_menu = new frm_menu_coating())
				frm_coat_menu.ShowDialog();
			this.Show();
		}
		
		void Btn_convClick(object sender, EventArgs e)
		{
			this.Hide();
			using(frm_menu_converting frm_conv_menu = new frm_menu_converting())
				frm_conv_menu.ShowDialog();
			this.Show();
		}
		
		void Btn_planClick(object sender, EventArgs e)
		{
			this.Hide();
			using (frm_menu_planning frm_plan_menu = new frm_menu_planning())	
				frm_plan_menu.ShowDialog();
			this.Show();
		}
		
		void Btn_ribbonClick(object sender, EventArgs e)
		{
			this.Hide();
			using(frm_prod_ribbon2_menu frm_prod_ribbon2_menu1 = new frm_prod_ribbon2_menu())
			      frm_prod_ribbon2_menu1.ShowDialog();
			this.Show();			
		}
		
		void Btn_klinerClick(object sender, EventArgs e)
		{
			this.Hide();
			using(frm_menu_kliner frm_kliner_menu = new frm_menu_kliner())
			      frm_kliner_menu.ShowDialog();
			this.Show();
		}
		
		void Btn_pcoreClick(object sender, EventArgs e)
		{
			this.Hide();
			using(frm_menu_papercore frm_papercore_menu = new frm_menu_papercore())
			      frm_papercore_menu.ShowDialog();
			this.Show();			
		}
		
		void Btn_glueClick(object sender, EventArgs e)
		{
			this.Hide();
			using(frm_menu_glue frm_glue_menu = new frm_menu_glue())
			      frm_glue_menu.ShowDialog();
			this.Show();			
		}
		
		void Btn_adminClick(object sender, EventArgs e)
		{
			this.Hide();
			using(frm_menu_admin frm_admin_menu = new frm_menu_admin())
			      frm_admin_menu.ShowDialog();
			this.Show();			
		}
		
		void Btn_packClick(object sender, EventArgs e)
		{
			this.Hide();
			using(frm_menu_packing_list frm_packing_list_menu = new frm_menu_packing_list())
				frm_packing_list_menu.ShowDialog();
			this.Show();
		}
		    
		void Btn_mngmtClick(object sender, EventArgs e)
		{
			this.Hide();
			using(frm_menu_management frm_management_menu = new frm_menu_management())
			      frm_management_menu.ShowDialog();
			this.Show();			
		}
		
		void Btn_stretch_filmClick(object sender, EventArgs e)
		{
			this.Hide();
			using(frm_menu_stretch_film frm_stretch_film_menu = new frm_menu_stretch_film())
			      frm_stretch_film_menu.ShowDialog();
			this.Show();
		}
		
		void Btn_warehouseClick(object sender, EventArgs e)
		{
			this.Hide();
			using(frm_menu_warehouse frm_warehouse_menu = new frm_menu_warehouse())
			      frm_warehouse_menu.ShowDialog();
			this.Show();
		}
		
		void Btn_shipClick(object sender, EventArgs e)
		{
			this.Hide();
			using(frm_prod_shipping frm_ship = new frm_prod_shipping())
			      frm_ship.ShowDialog();
			this.Show();
		}
		
		void Btn_qacClick(object sender, EventArgs e)
		{
			this.Hide();
			using(frm_menu_qac frm_qac_menu = new frm_menu_qac())
			      frm_qac_menu.ShowDialog();
			this.Show();
		}
		
		void Btn_salesClick(object sender, EventArgs e)
		{
			this.Hide();
			using(frm_menu_sales frm_sales_menu = new frm_menu_sales())
			frm_sales_menu.ShowDialog();
			this.Show();
		}
		
		
		
		void Btn_schwanerClick(object sender, EventArgs e)
		{
			this.Hide();
			using(frm_menu_sub_schwaner frm_menu_sub_schwaner2 = new frm_menu_sub_schwaner())
			frm_menu_sub_schwaner2.ShowDialog();
			this.Show();	
		}
	
		
		void Btn_ciClick(object sender, EventArgs e)
		{
			this.Hide();
			using(frm_get_CI_NO frm_prod_get_CI_NO2 = new frm_get_CI_NO())
			frm_prod_get_CI_NO2.ShowDialog();
			this.Show();
			
		}
		
		void Btn_procrumentClick(object sender, EventArgs e)
		{
		
			this.Hide();
			using(frm_rpt_procurement frm_rpt_procurement1 = new frm_rpt_procurement())
			frm_rpt_procurement1.ShowDialog();
			this.Show();
			
		}
		
		void Txtbx_ribbonClick(object sender, EventArgs e)
		{
			this.Hide();
			using(frm_prod_ribbon2_menu frm_prod_ribbon2_menu1 = new frm_prod_ribbon2_menu())
			frm_prod_ribbon2_menu1.ShowDialog();
			this.Show();
		}
		
		
		
		void Btn_ax_stk_stsClick(object sender, EventArgs e)
		{
			this.Hide();
			using(frm_menu_ax_stock_status frm_menu_ax_stock_status1 = new frm_menu_ax_stock_status())
			frm_menu_ax_stock_status1.ShowDialog();
			this.Show();
		}
		
	
		
		void Btn_doublesideClick(object sender, EventArgs e)
		{
			this.Hide();
			using(frm_prod_menu_doubleside_r2 obj_ds1 = new frm_prod_menu_doubleside_r2())
			obj_ds1.ShowDialog();
			this.Show();
		}
	}
}
