/*
 * Created by SharpDevelop.
 * User: faeiz
 * Date: 2017-10-14
 * Time: 11:29 AM
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


namespace AX2020
{
	/// <summary>
	/// Description of frm_menu_ax_stock_status.
	/// </summary>
	public partial class frm_menu_ax_stock_status : Form
	{
		public frm_menu_ax_stock_status()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			this.ControlBox = false;
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
	
		
		void Btn_pm01Click(object sender, EventArgs e)
		{
			this.Hide();
			using(frm_ax_stock_status_pm01 frm_ax_stock_status_pm011 = new frm_ax_stock_status_pm01())
			frm_ax_stock_status_pm011.ShowDialog();
			this.Show();	
		}
		
		
		
		void Btn_vm05_boppClick(object sender, EventArgs e)
		{
			this.Hide();
			using(frm_ax_stock_status_vm05_bopp frm_ax_stock_status_vm05_bopp1 = new frm_ax_stock_status_vm05_bopp())
			frm_ax_stock_status_vm05_bopp1.ShowDialog();
			this.Show();
		}
		
		void Btn_rm01Click(object sender, EventArgs e)
		{
			this.Hide();
			using(frm_ax_stock_status_rm01 ab = new frm_ax_stock_status_rm01())
				ab.ShowDialog();
			this.Show();
		}
		
		void Btn_rm02Click(object sender, EventArgs e)
		{
			this.Hide();
			using(frm_ax_stock_status_rm02 ab1 = new frm_ax_stock_status_rm02())
				ab1.ShowDialog();
			this.Show();
		}
		
		void Btn_pm02Click(object sender, EventArgs e)
		{
			this.Hide();
			using(frm_ax_stock_status_pm02 ab11 = new frm_ax_stock_status_pm02())
				ab11.ShowDialog();
			this.Show();
		}
		
		void Btn_pm03Click(object sender, EventArgs e)
		{
			this.Hide();
			using(frm_ax_stock_status_pm03 abc11 = new frm_ax_stock_status_pm03())
				abc11.ShowDialog();
			this.Show();
		}
		
		void Btn_pm04Click(object sender, EventArgs e)
		{
			this.Hide();
			using(frm_ax_stock_status_pm04 frm_ax_stock_status_pm041 = new frm_ax_stock_status_pm04())
				frm_ax_stock_status_pm041.ShowDialog();
			this.Show();
		}
		
		void Btn_sm01Click(object sender, EventArgs e)
		{
			this.Hide();
			using(frm_ax_stock_status_sm01 frm_ax_stock_status_sm011 = new frm_ax_stock_status_sm01())
				frm_ax_stock_status_sm011.ShowDialog();
			this.Show();
		}
		
		void Btn_sm02Click(object sender, EventArgs e)
		{
			this.Hide();
			using(frm_ax_stock_status_sm02 frm_ax_stock_status_sm021 = new frm_ax_stock_status_sm02())
				frm_ax_stock_status_sm021.ShowDialog();
			this.Show();
			
		}
		
		void Btn_sm03Click(object sender, EventArgs e)
		{
			this.Hide();
			using(frm_ax_stock_status_sm03 frm_ax_stock_status_sm031 = new frm_ax_stock_status_sm03())
				frm_ax_stock_status_sm031.ShowDialog();
			this.Show();
		}
		
		void Btn_sm04Click(object sender, EventArgs e)
		{
			this.Hide();
			using(frm_ax_stock_status_sm04 frm_ax_stock_status_sm041 = new frm_ax_stock_status_sm04())
				frm_ax_stock_status_sm041.ShowDialog();
			this.Show();
			
		}
		
		void Button6abtn_sm05Click(object sender, EventArgs e)
		{
			this.Hide();
			using(frm_ax_stock_status_sm05 frm_ax_stock_status_sm051 = new frm_ax_stock_status_sm05())
				frm_ax_stock_status_sm051.ShowDialog();
			this.Show();
		}
		
		void Btn_sm06Click(object sender, EventArgs e)
		{
			this.Hide();
			using(frm_ax_stock_status_sm06 frm_ax_stock_status_sm061 = new frm_ax_stock_status_sm06())
				frm_ax_stock_status_sm061.ShowDialog();
			this.Show();
		}
		
		void Btn_closeClick(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}
