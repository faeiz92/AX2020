﻿/*
 * Created by SharpDevelop.
 * User: afiqah
 * Date: 20/06/2017
 * Time: 11:03 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace AX2020
{
	partial class frm_rpt_converting_jr
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
			this.panel2 = new System.Windows.Forms.Panel();
			this.lbl_username = new System.Windows.Forms.Label();
			this.lbl_header = new System.Windows.Forms.Label();
			this.panel1 = new System.Windows.Forms.Panel();
			this.groupBx_search = new System.Windows.Forms.GroupBox();
			this.txtbx_so_no = new System.Windows.Forms.TextBox();
			this.lbl_so_no = new System.Windows.Forms.Label();
			this.btn_search = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.dtp_date_to = new System.Windows.Forms.DateTimePicker();
			this.lbl_date = new System.Windows.Forms.Label();
			this.dtp_date_from = new System.Windows.Forms.DateTimePicker();
			this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
			this.btn_cancel = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.panel2.SuspendLayout();
			this.groupBx_search.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel2
			// 
			this.panel2.BackColor = System.Drawing.Color.Gainsboro;
			this.panel2.Controls.Add(this.lbl_username);
			this.panel2.Location = new System.Drawing.Point(-1, 50);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(998, 23);
			this.panel2.TabIndex = 144;
			// 
			// lbl_username
			// 
			this.lbl_username.BackColor = System.Drawing.Color.Gainsboro;
			this.lbl_username.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbl_username.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.lbl_username.Location = new System.Drawing.Point(688, -1);
			this.lbl_username.Name = "lbl_username";
			this.lbl_username.Size = new System.Drawing.Size(308, 23);
			this.lbl_username.TabIndex = 0;
			this.lbl_username.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// lbl_header
			// 
			this.lbl_header.BackColor = System.Drawing.Color.DarkCyan;
			this.lbl_header.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbl_header.ForeColor = System.Drawing.SystemColors.ControlLightLight;
			this.lbl_header.Location = new System.Drawing.Point(4, 17);
			this.lbl_header.Name = "lbl_header";
			this.lbl_header.Size = new System.Drawing.Size(959, 23);
			this.lbl_header.TabIndex = 142;
			this.lbl_header.Text = "CONVERTING OUTSTANDING JR";
			this.lbl_header.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.Color.DarkCyan;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(998, 52);
			this.panel1.TabIndex = 143;
			// 
			// groupBx_search
			// 
			this.groupBx_search.Controls.Add(this.txtbx_so_no);
			this.groupBx_search.Controls.Add(this.lbl_so_no);
			this.groupBx_search.Controls.Add(this.btn_search);
			this.groupBx_search.Controls.Add(this.label1);
			this.groupBx_search.Controls.Add(this.dtp_date_to);
			this.groupBx_search.Controls.Add(this.lbl_date);
			this.groupBx_search.Controls.Add(this.dtp_date_from);
			this.groupBx_search.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.groupBx_search.Location = new System.Drawing.Point(18, 83);
			this.groupBx_search.Name = "groupBx_search";
			this.groupBx_search.Size = new System.Drawing.Size(949, 98);
			this.groupBx_search.TabIndex = 150;
			this.groupBx_search.TabStop = false;
			// 
			// txtbx_so_no
			// 
			this.txtbx_so_no.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtbx_so_no.Location = new System.Drawing.Point(705, 25);
			this.txtbx_so_no.Name = "txtbx_so_no";
			this.txtbx_so_no.Size = new System.Drawing.Size(226, 26);
			this.txtbx_so_no.TabIndex = 1;
			// 
			// lbl_so_no
			// 
			this.lbl_so_no.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbl_so_no.Location = new System.Drawing.Point(624, 25);
			this.lbl_so_no.Name = "lbl_so_no";
			this.lbl_so_no.Size = new System.Drawing.Size(75, 26);
			this.lbl_so_no.TabIndex = 165;
			this.lbl_so_no.Text = "SO No";
			this.lbl_so_no.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// btn_search
			// 
			this.btn_search.BackColor = System.Drawing.Color.Silver;
			this.btn_search.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_search.Location = new System.Drawing.Point(811, 58);
			this.btn_search.Name = "btn_search";
			this.btn_search.Size = new System.Drawing.Size(120, 27);
			this.btn_search.TabIndex = 6;
			this.btn_search.Text = "Search";
			this.btn_search.UseVisualStyleBackColor = false;
			this.btn_search.Click += new System.EventHandler(this.Btn_searchClick);
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(18, 58);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(73, 26);
			this.label1.TabIndex = 153;
			this.label1.Text = "Date To";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// dtp_date_to
			// 
			this.dtp_date_to.Checked = false;
			this.dtp_date_to.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.dtp_date_to.Location = new System.Drawing.Point(115, 56);
			this.dtp_date_to.Name = "dtp_date_to";
			this.dtp_date_to.Size = new System.Drawing.Size(321, 26);
			this.dtp_date_to.TabIndex = 5;
			// 
			// lbl_date
			// 
			this.lbl_date.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbl_date.Location = new System.Drawing.Point(18, 24);
			this.lbl_date.Name = "lbl_date";
			this.lbl_date.Size = new System.Drawing.Size(91, 26);
			this.lbl_date.TabIndex = 151;
			this.lbl_date.Text = "Date From";
			this.lbl_date.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// dtp_date_from
			// 
			this.dtp_date_from.Checked = false;
			this.dtp_date_from.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.dtp_date_from.Location = new System.Drawing.Point(115, 24);
			this.dtp_date_from.Name = "dtp_date_from";
			this.dtp_date_from.Size = new System.Drawing.Size(321, 26);
			this.dtp_date_from.TabIndex = 4;
			// 
			// reportViewer1
			// 
			this.reportViewer1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.reportViewer1.Location = new System.Drawing.Point(18, 200);
			this.reportViewer1.Name = "ReportViewer";
			this.reportViewer1.Size = new System.Drawing.Size(950, 400);
			this.reportViewer1.TabIndex = 0;
			// 
			// btn_cancel
			// 
			this.btn_cancel.BackColor = System.Drawing.Color.Silver;
			this.btn_cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btn_cancel.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_cancel.Location = new System.Drawing.Point(432, 627);
			this.btn_cancel.Name = "btn_cancel";
			this.btn_cancel.Size = new System.Drawing.Size(120, 27);
			this.btn_cancel.TabIndex = 155;
			this.btn_cancel.Text = "Cancel";
			this.btn_cancel.UseVisualStyleBackColor = false;
			this.btn_cancel.Click += new System.EventHandler(this.Btn_cancelClick);
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(443, 655);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(100, 23);
			this.label2.TabIndex = 157;
			// 
			// frm_rpt_converting_jr
			// 
			this.AcceptButton = this.btn_search;
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.AutoScroll = true;
			this.CancelButton = this.btn_cancel;
			this.ClientSize = new System.Drawing.Size(1001, 679);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.btn_cancel);
			this.Controls.Add(this.groupBx_search);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.lbl_header);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.reportViewer1);
			this.Name = "frm_rpt_converting_jr";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Converting Outstanding JR";
			this.Load += new System.EventHandler(this.Frm_rpt_converting_progress_r1Load);
			this.panel2.ResumeLayout(false);
			this.groupBx_search.ResumeLayout(false);
			this.groupBx_search.PerformLayout();
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.Label lbl_so_no;
		private System.Windows.Forms.TextBox txtbx_so_no;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button btn_cancel;
		private System.Windows.Forms.GroupBox groupBx_search;
		private System.Windows.Forms.Button btn_search;
		private System.Windows.Forms.DateTimePicker dtp_date_to;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.DateTimePicker dtp_date_from;
		private System.Windows.Forms.Label lbl_date;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label lbl_header;
		private System.Windows.Forms.Label lbl_username;
		private System.Windows.Forms.Panel panel2;
		private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
	}
}