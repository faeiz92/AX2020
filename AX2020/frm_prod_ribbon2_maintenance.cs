/*
 * Created by SharpDevelop.
 * User: faeiz
 * Date: 2017-10-29
 * Time: 1:51 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
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
using System.Data.Sql;
using System.IO;
using fyiReporting.RdlViewer;
using fyiReporting;
using System.Linq;
using System.Net;
using System.Net.Mail;

namespace AX2020
{
	/// <summary>
	/// Description of frm_prod_ribbon2_maintenance.
	/// </summary>
	public partial class frm_prod_ribbon2_maintenance : Form
	{
		public static string sqlconn = "Server=AX-UAT; Password=sbax2020sbg; User ID=sbax2020; Initial Catalog=SBG_AX_2020; Integrated Security=false";
		string username;
		
		public frm_prod_ribbon2_maintenance()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			ControlBox = false;
			username = frm_menu_system.userName; 
			lbl_username.Text = "User : " + username;
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		
		
		void Btn_add_operatorClick(object sender, EventArgs e)
		{
			using (SqlConnection cmd = new SqlConnection(sqlconn))
			{
				cmd.Open();
				try
				{
					SqlCommand cmd_command = new SqlCommand("INSERT INTO TBL_PROD_RIBBON_OPERATOR_NAME (OPERATOR_NAME) VALUES (@OPERATOR_NAME)",cmd);
					cmd_command.Parameters.AddWithValue("@OPERATOR_NAME", txtbx_operator.Text.ToUpper());
					
					cmd_command.ExecuteNonQuery();

				}
				
				catch(Exception ex)
				{
					MessageBox.Show("Error:" + ex.ToString() + ex.Message);
					return;
				}
				finally
				{
					cmd.Close();
					MessageBox.Show("Succesfull Save Operator Name");
				}
				
			}
		}
		
		void Btn_add_helperClick(object sender, EventArgs e)
		{
			using (SqlConnection cmd_add_helper = new SqlConnection(sqlconn))
			{
				cmd_add_helper.Open();
				try
				{
					SqlCommand cmd_command_helper = new SqlCommand("INSERT INTO TBL_PROD_RIBBON_HELPER_NAME (HELPER_NAME) VALUES (@HELPER_NAME)",cmd_add_helper);
					cmd_command_helper.Parameters.AddWithValue("@HELPER_NAME", txtbx_helper.Text.ToUpper());
					
					cmd_command_helper.ExecuteNonQuery();

				}
				
				catch(Exception ex)
				{
					MessageBox.Show("Error:" + ex.ToString() + ex.Message);
					return;
				}
				finally
				{
					cmd_add_helper.Close();
					MessageBox.Show("Succesfull Save helper Name");
				}
				
			}
		}
		
		void Btn_add_machineClick(object sender, EventArgs e)
		{
			using (SqlConnection cmd_add_machine = new SqlConnection(sqlconn))
			{
				cmd_add_machine.Open();
				try
				{
					SqlCommand cmd_command_machine = new SqlCommand("INSERT INTO TBL_PROD_RIBBON_MACHINE_NAME (MACHINE_NAME) VALUES (@MACHINE_NAME)",cmd_add_machine);
					cmd_command_machine.Parameters.AddWithValue("@MACHINE_NAME", txtbx_machine.Text.ToUpper());
					
					cmd_command_machine.ExecuteNonQuery();

				}
				
				catch(Exception ex)
				{
					MessageBox.Show("Error:" + ex.ToString() + ex.Message);
					return;
				}
				finally
				{
					cmd_add_machine.Close();
					MessageBox.Show("Succesfull Save Machine Name");
				}
				
			}
		}
		
		void Btn_cancelClick(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}
