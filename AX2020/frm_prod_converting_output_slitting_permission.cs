using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic; // For generic collections like List.
using System.Data.SqlClient;      // For the database connections and objects.
using System.Data.Sql;
using System.Data;

namespace AX2020
{
	
	public partial class frm_prod_converting_output_slitting_permission : Form
	{
		public static string sqlconn = "Server=AX-UAT; Password=sbax2020sbg; User ID=sbax2020; Initial Catalog=SBG_AX_2020; Integrated Security=false";
		public static string Sqlconn1 = "DSN=eb9gf;Port=2138;Uid=dba;Pwd=sql";
		public static string sqlconn2 = "Server=AX-SQL; Password=ax2020sbgroup; User ID=ax2020sb; Initial Catalog=AX2020StagingDB; Integrated Security=false";

		internal static bool pass = false;
		
		public frm_prod_converting_output_slitting_permission()
		{
			InitializeComponent();
			this.ControlBox = false;
		}
		
		void Btn_cancelClick(object sender, EventArgs e)
		{
			pass = false;
			this.Close();			
		}
		
		void Btn_okClick(object sender, EventArgs e)
		{
			//Grant();
			if (String.IsNullOrWhiteSpace(txtbx_stockcode.Text)) 
			{
        		MessageBox.Show("Please key-in password");
				return;
			}
			
			if(txtbx_stockcode.Text == "supervisor")
			{
				pass = true;
			}
			else
			{
				pass = false;
			}
			
			this.Close();
		}
		
//		bool Grant()
//		{
//			  
//			if (String.IsNullOrWhiteSpace(txtbx_stockcode.Text)) 
//			{
//        		MessageBox.Show("Please key-in password");
//				return false;
//			}
//			
//			if(txtbx_stockcode.Text == "supervisor")
//			{
//				return true;
//			}
//			else
//			{
//				return false;
//			}
//			
//		}  		
	}
}
