﻿/*
 * Created by SharpDevelop.
 * User: ax2020-2
 * Date: 2/7/2017
 * Time: 1:49 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace AX2020
{
	partial class frm_rpt_summary_bopp_stock_status
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			this.date_from = new System.Windows.Forms.DateTimePicker();
			this.label2 = new System.Windows.Forms.Label();
			this.btn_generate = new System.Windows.Forms.Button();
			this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
			this.panel2 = new System.Windows.Forms.Panel();
			this.lbl_username = new System.Windows.Forms.Label();
			this.panel1 = new System.Windows.Forms.Panel();
			this.lbl_header = new System.Windows.Forms.Label();
			this.button1 = new System.Windows.Forms.Button();
			this.panel2.SuspendLayout();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// date_from
			// 
			this.date_from.CalendarFont = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.date_from.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.date_from.Location = new System.Drawing.Point(434, 86);
			this.date_from.Name = "date_from";
			this.date_from.Size = new System.Drawing.Size(200, 26);
			this.date_from.TabIndex = 2;
			// 
			// label2
			// 
			this.label2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.Location = new System.Drawing.Point(345, 90);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(92, 23);
			this.label2.TabIndex = 3;
			this.label2.Text = "Date From";
			// 
			// btn_generate
			// 
			this.btn_generate.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_generate.Location = new System.Drawing.Point(666, 84);
			this.btn_generate.Name = "btn_generate";
			this.btn_generate.Size = new System.Drawing.Size(96, 30);
			this.btn_generate.TabIndex = 6;
			this.btn_generate.Text = "Generate";
			this.btn_generate.UseVisualStyleBackColor = true;
			this.btn_generate.Click += new System.EventHandler(this.Btn_generateClick);
			// 
			// reportViewer1
			// 
			this.reportViewer1.AllowDrop = true;
			this.reportViewer1.Location = new System.Drawing.Point(13, 119);
			this.reportViewer1.Name = "ReportViewer";
			this.reportViewer1.Size = new System.Drawing.Size(980, 500);
			this.reportViewer1.TabIndex = 0;
			// 
			// panel2
			// 
			this.panel2.BackColor = System.Drawing.Color.Gainsboro;
			this.panel2.Controls.Add(this.lbl_username);
			this.panel2.Location = new System.Drawing.Point(-10, 52);
			this.panel2.Margin = new System.Windows.Forms.Padding(1);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(986, 23);
			this.panel2.TabIndex = 113;
			// 
			// lbl_username
			// 
			this.lbl_username.BackColor = System.Drawing.Color.Gainsboro;
			this.lbl_username.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbl_username.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.lbl_username.Location = new System.Drawing.Point(655, -2);
			this.lbl_username.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
			this.lbl_username.Name = "lbl_username";
			this.lbl_username.Size = new System.Drawing.Size(308, 23);
			this.lbl_username.TabIndex = 0;
			this.lbl_username.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.Color.DarkCyan;
			this.panel1.Controls.Add(this.lbl_header);
			this.panel1.Location = new System.Drawing.Point(-10, 2);
			this.panel1.Margin = new System.Windows.Forms.Padding(1);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(984, 52);
			this.panel1.TabIndex = 112;
			// 
			// lbl_header
			// 
			this.lbl_header.BackColor = System.Drawing.Color.DarkCyan;
			this.lbl_header.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbl_header.ForeColor = System.Drawing.SystemColors.ControlLightLight;
			this.lbl_header.Location = new System.Drawing.Point(1, 14);
			this.lbl_header.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
			this.lbl_header.Name = "lbl_header";
			this.lbl_header.Size = new System.Drawing.Size(981, 23);
			this.lbl_header.TabIndex = 0;
			this.lbl_header.Text = "SUMMARY BOPP STOCK STATUS - Raw Mat";
			this.lbl_header.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// button1
			// 
			this.button1.BackColor = System.Drawing.Color.Silver;
			this.button1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.button1.Location = new System.Drawing.Point(516, 656);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(95, 28);
			this.button1.TabIndex = 114;
			this.button1.Text = "Cancel";
			this.button1.UseVisualStyleBackColor = false;
			this.button1.Click += new System.EventHandler(this.Button1Click);
			// 
			// frm_rpt_summary_bopp_stock_status
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.AutoSize = true;
			this.ClientSize = new System.Drawing.Size(984, 662);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.btn_generate);
			this.Controls.Add(this.date_from);
			this.Controls.Add(this.reportViewer1);
			this.Controls.Add(this.label2);
			this.MinimumSize = new System.Drawing.Size(1000, 700);
			this.Name = "frm_rpt_summary_bopp_stock_status";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "frm_rpt_coating_Bgrade";
			this.panel2.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Label lbl_header;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label lbl_username;
		private System.Windows.Forms.Panel panel2;
		private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
		private System.Windows.Forms.Button btn_generate;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.DateTimePicker date_from;
	}
}
