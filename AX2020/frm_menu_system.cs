/*
 * Created by SharpDevelop.
 * User: it-4
 * Date: 17/11/2016
 * Time: 9:46 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Net.Mail;
using System.Globalization;
using System.Net;


namespace AX2020
{
	public partial class frm_menu_system : Form
	{
		public static string sqlconn = "Server=AX-UAT; Password=sbax2020sbg; User ID=sbax2020; Initial Catalog=SBG_AX_2020; Integrated Security=false";
		internal static string userName = "", ipAddress = "", email = "", fullname = "";
		string userPass, staffName;
		
		
		public frm_menu_system()
		{
			InitializeComponent();
			this.ControlBox = false;
			getIPAddress();
			//uptodateVersion();
		}
		
//		void uptodateVersion()
//		{
//			SqlConnection con_version = new SqlConnection(sqlconn);
//			SqlCommand cmd_version = new SqlCommand();
//			
//			try 
//			{
//				cmd_version.CommandText = @"Select * from TBL_SYSTEM_VERSION WHERE SYSTEMVERSIONNO = @version ";
//				cmd_version.Parameters.AddWithValue("@version",  system_version);
//				cmd_version.Connection = con_version;
//				
//				con_version.Open();
//				
//				SqlDataReader dr_version = cmd_version.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
//				
//				if (dr_version.Read() == true)
//				{
//					btn_update.Hide();
//					//return;
//					
//				} 
//				else 
//				{
//					btn_login.Enabled = false;
//					//MessageBox.Show("Click button update first");
//					return;
//					
//				}
//			} 
//			catch (Exception ex) 
//			{
//				MessageBox.Show("Error Update: Cannot load DB" + ex.Message + ex.ToString());
//				return;
//			} 
//			finally 
//			{
//				con_version.Close();
//			}
//			
//			con_version.Dispose();
//			con_version = null;
//			cmd_version = null;				
//			return; 
//		} 
//		
//		
		void getIPAddress()
		{
			string hostName = Dns.GetHostName(); // Retrive the Name of HOST
           	ipAddress = Dns.GetHostByName(hostName).AddressList[0].ToString();
		}
		void Btn_exitClick(object sender, EventArgs e)
		{
//			DialogResult cancel = new DialogResult();
//            cancel = MessageBox.Show("Are you sure you want to quit?", "Cancel", 
//                     MessageBoxButtons.YesNo, 
//                     MessageBoxIcon.Warning, 
//                     MessageBoxDefaultButton.Button2);
//            if (cancel == DialogResult.Yes)
//            {
            	ClearAllText(this);
            	Application.Exit();
            //}
		}
		
		void ClearAllText(Control con)
		{
    		foreach (Control c in con.Controls)
    		{
      			if (c is TextBox)
        			((TextBox)c).Clear();
      			else
      				ClearAllText(c);         		
   			}
		}
		
		
		void Btn_loginClick(object sender, EventArgs e)
		{
			if (!Login())
				return;
		}
		
		bool Login()
		{
			  
			if (String.IsNullOrWhiteSpace(txtbx_user_name.Text)) 
			{
        		MessageBox.Show("Please key-in Username");
				return false;
			}
			
			if(String.IsNullOrWhiteSpace(txtbx_user_pass.Text))
			{
			   	MessageBox.Show("Please key-in Password");
				return false;
			}
			
			SqlConnection con_user = new SqlConnection(sqlconn);
			SqlCommand cmd_user = new SqlCommand();
			
			try 
			{
				
				//SqlCommand cmd_user = new SqlCommand(@"Select * from TBL_ADMIN_USER_ACCESS where sysusername=@uname and syspassword=@pass", con_user);
				//cmd_user.CommandText = "select * from TBL_ADMIN_USER_ACCESS where sysusername = '" + txtbx_user_name.Text + "'AND syspassword = '" + txtbx_user_pass.Text + "'";
				cmd_user.CommandText = @"Select * from TBL_ADMIN_USER_ACCESS where sysusername=@uname and syspassword=@pass";
				cmd_user.Parameters.AddWithValue("@uname",  txtbx_user_name.Text);
        		cmd_user.Parameters.AddWithValue("@pass", txtbx_user_pass.Text);
				cmd_user.Connection = con_user;
				
				con_user.Open();
				
				SqlDataReader dr_user = cmd_user.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
				
				if (dr_user.Read() == true)
				{
					userName = txtbx_user_name.Text;
					email = dr_user["sysemail"].ToString();
					fullname = dr_user["sysstaffname"].ToString();
					this.Hide();
					
					using(frm_menu_main frm_main_menu = new frm_menu_main())
						frm_main_menu.ShowDialog();
					
					this.Show();
					txtbx_user_name.Clear();
					txtbx_user_pass.Clear();
					txtbx_user_name.Focus();
				} 
				else 
				{
					MessageBox.Show("Wrong username or password");
					//txtbx_user_name.Clear();
					txtbx_user_pass.Clear();
					txtbx_user_pass.Focus();
					return false;
				}
			} 
			catch (Exception ex) 
			{
				MessageBox.Show("Error Login: Cannot load DB" + ex.Message + ex.ToString());
				return false;
			} 
			finally 
			{
				con_user.Close();
			}
			
			con_user.Dispose();
			con_user = null;
			cmd_user = null;				
			return true; 
		}  			
		
		
		void Btn_forgot_passLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			if (String.IsNullOrWhiteSpace(txtbx_user_name.Text)) 
			{
        		MessageBox.Show("Please key-in Username");
        		return;
			}
			
			SqlConnection con_forgot = new SqlConnection(sqlconn);
			SqlCommand cmd_forgot = new SqlCommand();
			
			try 
			{
				
				cmd_forgot.CommandText = @"Select * from TBL_ADMIN_USER_ACCESS where sysusername=@uname";
				cmd_forgot.Parameters.AddWithValue("@uname",  txtbx_user_name.Text);
				cmd_forgot.Connection = con_forgot;
				
				con_forgot.Open();
				
				SqlDataReader dr_forgot = cmd_forgot.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
				
				if (dr_forgot.Read() == true)
				{	
					userPass = dr_forgot["syspassword"].ToString();
					staffName = dr_forgot["sysstaffname"].ToString().ToLower();
					
					TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;
					staffName = textInfo.ToTitleCase(staffName);
					email = dr_forgot["sysemail"].ToString();
					
					txtbx_user_pass.Focus();
				} 
				else 
				{
					MessageBox.Show("Wrong username or password");
					//txtbx_user_name.Clear();
					txtbx_user_pass.Clear();
					txtbx_user_name.Focus();

				}
			} 
			catch (Exception ex) 
			{
				MessageBox.Show("Error Forgot Password: Cannot load DB" + ex.Message + ex.ToString());
			} 
			finally 
			{
				con_forgot.Close();
			}
			
			con_forgot.Dispose();
			con_forgot = null;
			cmd_forgot = null;
			
			//----- BEGIN Email acknowledgement --------------------------------------------------

			SmtpClient StrEmailService1M_Smtp = new SmtpClient();
			StrEmailService1M_Smtp.Host = "smtp.gmail.com";
			StrEmailService1M_Smtp.Port = 587;
			StrEmailService1M_Smtp.Credentials = new System.Net.NetworkCredential("sbticket@sbgroup.com.my", "logticket1st");
			StrEmailService1M_Smtp.EnableSsl = true;
			
			string FromName = "IT E-SERVICE";
			string FromEmail = "sbticket@sbgroup.com.my";
			string Subject = "IT AX2020 User Account";
			
			SmtpClient smtp = new SmtpClient();
			smtp.Host = "mail.sbgroup.com.my";
			smtp.Credentials = new System.Net.NetworkCredential("sbticket@sbgroup.com.my", "logticket1st");
			smtp.Credentials = new System.Net.NetworkCredential("sbticket@sbgroup.com.my", "logticket1st");
			smtp.EnableSsl = false;
			
			MailMessage msg = new MailMessage();
			msg.From = new MailAddress(FromEmail, FromName);
			msg.To.Add(new MailAddress(email, staffName));
			
			msg.Subject = Subject;
			msg.Body = "Dear " + staffName + ", \n\n\nPlease find your user account for AX2020 System: \n\nEmail address : " + email + "\nPassword        : " + userPass + "\n\n\n\nThank you. \n\nIT Service Notification.";
			
			try 
			{
				smtp.Send(msg);
			} 
			catch (FormatException ex) 
			{
				MessageBox.Show("Format Exception: \n" + ex.Message + ex.ToString());
			} 
			catch (SmtpException ex) 
			{
				MessageBox.Show("SMTP Exception:  \n" + ex.Message + ex.ToString());
			} 
			catch (Exception ex)
			{
				MessageBox.Show("General Exception:  \n" + ex.Message + ex.ToString());
			}
			//----- END Email acknowledgement ----------------------------------------------------
			
			MessageBox.Show("Your AX2020 account is delivered to your external email. Please check it.");
			
			
		}
		
		void Btn_updateClick(object sender, EventArgs e)
		{
						
			SqlConnection con_version = new SqlConnection(sqlconn);
			SqlCommand cmd_version = new SqlCommand();
			
			try 
			{
				cmd_version.CommandText = @"Select * from TBL_SYSTEM_VERSION";
				cmd_version.Connection = con_version;
				
				con_version.Open();
				
				SqlDataReader dr_version = cmd_version.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
				
				if (dr_version.Read())
				{
					//btn_update.Hide();
					//return;
					lbl_version.Text = dr_version["SystemVersionNo"].ToString();					
				} 
				
			} 
			catch (Exception ex) 
			{
				MessageBox.Show("Error Update: Cannot load DB" + ex.Message + ex.ToString());
				return;
			} 
			finally 
			{
				con_version.Close();
			}
			
			con_version.Dispose();
			con_version = null;
			cmd_version = null;	

			System.Diagnostics.Process.Start(@"ax2020_upgrade.bat");			
			//return;			
		}
		
		void Frm_menu_systemLoad(object sender, EventArgs e)
		{
			lbl_version.Text = "20180404";			
		}
	}
}


