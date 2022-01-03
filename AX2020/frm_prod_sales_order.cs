using System;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using System.Collections.Generic; // For generic collections like List.
using System.Data.SqlClient;      // For the database connections and objects.
using System.Data.Sql;
using System.Data;
using System.IO;
using System.Linq;

namespace AX2020
{
	public partial class frm_prod_sales_order : Form
	{
		public static string sqlconn = "Server=AX-UAT; Password=sbax2020sbg; User ID=sbax2020; Initial Catalog=SBG_AX_2020; Integrated Security=false";
		public static string Sqlconn = "DSN=eb9gf;Port=2138;Uid=dba;Pwd=sql";
		string username, file_path;
		int NextNo;
		byte [] file;
		
		public frm_prod_sales_order()
		{			
			InitializeComponent();	
			this.ControlBox = false;
			username = frm_menu_system.userName; 
			lbl_username.Text = "User : " + username;			
		}
		
		void Btn_cancelClick(object sender, EventArgs e)
		{
			this.Close();
		}
		
		void Btn_clearClick(object sender, EventArgs e)
		{
			
		}
		
		void Btn_saveClick(object sender, EventArgs e)
		{
			DocNoGenerator();
			sqlConnParm2("S0", 1);
			//DialogBox.ShowSaveSuccessDialog();
			MessageBox.Show("ok");			
		}
			
		private bool DocNoGenerator()
		{

			SqlConnection conNextNumber = new SqlConnection(sqlconn);
			SqlCommand cmdNextNumber = new SqlCommand();

			try
			{
					cmdNextNumber.CommandText = "Select ProdSalesOrderNextNumber from TBL_ADMIN_NEXT_NUMBER";
					cmdNextNumber.Connection = conNextNumber;

					conNextNumber.Open();
					SqlDataReader rdNextNumber = cmdNextNumber.ExecuteReader(System.Data.CommandBehavior.CloseConnection);

					rdNextNumber.Read();
					NextNo = Convert.ToInt32(rdNextNumber["ProdSalesOrderNextNumber"]);

			}
			catch (Exception ex) 
			{
				MessageBox.Show("Error - Sales Order Next Number DB \nCannot get next number \n" + ex.Message + ex.ToString());
				NextNo = 0;
				return false;
			}
			finally 
			{
				conNextNumber.Close();
				
			}

			conNextNumber.Dispose();
	
			conNextNumber = null;
			cmdNextNumber = null;

			//string SDate = txtbx_ref_no.Text.ToUpper() + "-" + NextNo;

			//---  Update next number
			SqlConnection conUpdate = new SqlConnection(sqlconn);
			SqlCommand cmdUpdateNextNumber = new SqlCommand();

			try
			{
				cmdUpdateNextNumber.CommandText = "update TBL_ADMIN_NEXT_NUMBER set ProdSalesOrderNextNumber = ProdSalesOrderNextNumber + 1";
				
				cmdUpdateNextNumber.Connection = conUpdate;

				conUpdate.Open();
				cmdUpdateNextNumber.ExecuteNonQuery();

			}
			catch (Exception ex)
			{
				conUpdate.Close();
				MessageBox.Show("Error - Sales Order Next Number DB \nCannot update next number \n" + ex.Message + ex.ToString());
				return false;
			}
			finally 
			{
				conUpdate.Close();
			}

			conUpdate.Dispose();
			conUpdate = null;
			cmdUpdateNextNumber = null;
			return true;
		}		
		
		void Btn_choose_file_soClick(object sender, EventArgs e)
		{
			openFileDialog1.ShowDialog();
			openFileDialog1.Filter = "PDF files (*.pdf)|*.pdf|All files (*.*)|*.*";
		}		
		
		void OpenFileDialog1FileOk(object sender, System.ComponentModel.CancelEventArgs e)
		{
			file_path = openFileDialog1.FileName;
			txtbx_att_so.Text = file_path;
	        			        
		}
		
		void sqlConnParm2(string Remark, int ItemNo)
		{
			FileStream stream = new FileStream(@file_path, FileMode.Open, FileAccess.Read);
	        BinaryReader reader = new BinaryReader(stream);
	        file = reader.ReadBytes((int)stream.Length);
	        reader.Close();
	        stream.Close();	
	        
			SqlConnection connection = new SqlConnection(sqlconn);
	        //SqlCommand command = new SqlCommand("INSERT INTO FileTable (File) Values(@File)", connection);
	        SqlCommand command = new SqlCommand("SP_PROD_SALES_ORDER_ATTACHMENT_ADD", connection);
			
	        command.Parameters.Add("@SP_PROD_NO", SqlDbType.Int).Value = NextNo;
	        command.Parameters.Add("@SP_PROD_SONO", SqlDbType.NVarChar, 50).Value = txtbx_so.Text.ToUpper();
	        command.Parameters.Add("@SP_PROD_LINENO", SqlDbType.Int).Value = NextNo;
	        command.Parameters.Add("@SP_PROD_FILE", SqlDbType.VarBinary, file.Length).Value = file;
	        command.Parameters.Add("@SP_PROD_PATH", SqlDbType.NVarChar, 50).Value = txtbx_att_so.Text;
	        command.Parameters.Add("@SP_PROD_REMARK", SqlDbType.NVarChar, 50).Value = Remark;
	        command.Parameters.Add("@SP_PROD_ITEMNO", SqlDbType.Int).Value = ItemNo;
	        
	        command.Parameters.Add("@SP_PROD_FLAG1", SqlDbType.NVarChar, 2).Value = "0";
	        command.Parameters.Add("@SP_PROD_FLAG2", SqlDbType.NVarChar, 2).Value = "0";
	        command.Parameters.Add("@SP_PROD_FLAG3", SqlDbType.NVarChar, 2).Value = "0";
	        command.Parameters.Add("@SP_PROD_FLAG4", SqlDbType.NVarChar, 2).Value = "0";
	        command.Parameters.Add("@SP_PROD_FLAG5", SqlDbType.NVarChar, 2).Value = "0";
	        command.Parameters.Add("@SP_PROD_FLAG6", SqlDbType.NVarChar, 2).Value = "0";
	        command.Parameters.Add("@SP_PROD_FLAG7", SqlDbType.NVarChar, 2).Value = "0";
	        command.Parameters.Add("@SP_PROD_FLAG8", SqlDbType.NVarChar, 2).Value = "0";
	        command.Parameters.Add("@SP_PROD_FLAGStatus", SqlDbType.NVarChar, 2).Value = "0";
	      
	        
	        command.Parameters.Add("@SP_PROD_USER", SqlDbType.NVarChar, 50).Value = username;
	        command.Parameters.Add("@SP_PROD_USEREMAIL", SqlDbType.NVarChar, 50).Value = frm_menu_system.email;
	        command.Parameters.Add("@SP_PROD_USERPC", SqlDbType.NVarChar, 50).Value = frm_menu_system.ipAddress;
	        command.Parameters.Add("@SP_PROD_USERDATETIME", SqlDbType.DateTime, 50).Value = DateTime.Now;
	        command.Parameters.Add("@SP_PROD_USERREVISION", SqlDbType.NVarChar, 50).Value = "0";
	        	        
	        connection.Open();
	        command.ExecuteNonQuery();
	        
	        MessageBox.Show("ok");
		}
	}
}
