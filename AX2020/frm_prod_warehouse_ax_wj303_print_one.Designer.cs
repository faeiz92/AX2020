/*
 * Created by SharpDevelop.
 * User: afiqah
 * Date: 25/10/2017
 * Time: 2:12 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace AX2020
{
	partial class frm_prod_warehouse_ax_wj303_print_one
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
			this.panel1 = new System.Windows.Forms.Panel();
			this.lbl_header = new System.Windows.Forms.Label();
			this.txtbx_ref_no = new System.Windows.Forms.TextBox();
			this.lbl_ref_no = new System.Windows.Forms.Label();
			this.btn_search = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.btn_cancel = new System.Windows.Forms.Button();
			this.btn_clear = new System.Windows.Forms.Button();
			this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
			this.txtbx_po_no = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.btn_search_bn = new System.Windows.Forms.Button();
			this.panel2.SuspendLayout();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel2
			// 
			this.panel2.BackColor = System.Drawing.Color.Gainsboro;
			this.panel2.Controls.Add(this.lbl_username);
			this.panel2.Location = new System.Drawing.Point(-1, 50);
			this.panel2.Margin = new System.Windows.Forms.Padding(1);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(1000, 23);
			this.panel2.TabIndex = 111;
			// 
			// lbl_username
			// 
			this.lbl_username.BackColor = System.Drawing.Color.Gainsboro;
			this.lbl_username.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbl_username.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.lbl_username.Location = new System.Drawing.Point(655, -1);
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
			this.panel1.Location = new System.Drawing.Point(-1, 0);
			this.panel1.Margin = new System.Windows.Forms.Padding(1);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(1000, 52);
			this.panel1.TabIndex = 110;
			// 
			// lbl_header
			// 
			this.lbl_header.BackColor = System.Drawing.Color.DarkCyan;
			this.lbl_header.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbl_header.ForeColor = System.Drawing.SystemColors.ControlLightLight;
			this.lbl_header.Location = new System.Drawing.Point(1, 15);
			this.lbl_header.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
			this.lbl_header.Name = "lbl_header";
			this.lbl_header.Size = new System.Drawing.Size(1000, 23);
			this.lbl_header.TabIndex = 0;
			this.lbl_header.Text = "PRINT AX LABEL";
			this.lbl_header.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// txtbx_ref_no
			// 
			this.txtbx_ref_no.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtbx_ref_no.Location = new System.Drawing.Point(140, 90);
			this.txtbx_ref_no.Margin = new System.Windows.Forms.Padding(1);
			this.txtbx_ref_no.Name = "txtbx_ref_no";
			this.txtbx_ref_no.Size = new System.Drawing.Size(220, 26);
			this.txtbx_ref_no.TabIndex = 1;
			// 
			// lbl_ref_no
			// 
			this.lbl_ref_no.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbl_ref_no.Location = new System.Drawing.Point(21, 92);
			this.lbl_ref_no.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
			this.lbl_ref_no.Name = "lbl_ref_no";
			this.lbl_ref_no.Size = new System.Drawing.Size(113, 26);
			this.lbl_ref_no.TabIndex = 114;
			this.lbl_ref_no.Text = "Shipping Mark";
			this.lbl_ref_no.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// btn_search
			// 
			this.btn_search.BackColor = System.Drawing.Color.Silver;
			this.btn_search.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_search.Location = new System.Drawing.Point(364, 89);
			this.btn_search.Margin = new System.Windows.Forms.Padding(1);
			this.btn_search.Name = "btn_search";
			this.btn_search.Size = new System.Drawing.Size(120, 27);
			this.btn_search.TabIndex = 2;
			this.btn_search.Text = "Search";
			this.btn_search.UseVisualStyleBackColor = false;
			this.btn_search.Click += new System.EventHandler(this.Btn_searchClick);
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(464, 635);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(100, 23);
			this.label2.TabIndex = 153;
			// 
			// btn_cancel
			// 
			this.btn_cancel.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.btn_cancel.BackColor = System.Drawing.Color.Silver;
			this.btn_cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btn_cancel.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_cancel.Location = new System.Drawing.Point(510, 605);
			this.btn_cancel.Name = "btn_cancel";
			this.btn_cancel.Size = new System.Drawing.Size(120, 27);
			this.btn_cancel.TabIndex = 4;
			this.btn_cancel.Text = "Cancel";
			this.btn_cancel.UseVisualStyleBackColor = false;
			this.btn_cancel.Click += new System.EventHandler(this.Btn_cancelClick);
			// 
			// btn_clear
			// 
			this.btn_clear.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.btn_clear.BackColor = System.Drawing.Color.Silver;
			this.btn_clear.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_clear.Location = new System.Drawing.Point(384, 605);
			this.btn_clear.Name = "btn_clear";
			this.btn_clear.Size = new System.Drawing.Size(120, 27);
			this.btn_clear.TabIndex = 3;
			this.btn_clear.Text = "Clear";
			this.btn_clear.UseVisualStyleBackColor = false;
			this.btn_clear.Click += new System.EventHandler(this.Btn_clearClick);
			// 
			// reportViewer1
			// 
			this.reportViewer1.AutoScroll = true;
			this.reportViewer1.Location = new System.Drawing.Point(18, 160);
			this.reportViewer1.Name = "ReportViewer";
			this.reportViewer1.Size = new System.Drawing.Size(949, 420);
			this.reportViewer1.TabIndex = 0;
			// 
			// txtbx_po_no
			// 
			this.txtbx_po_no.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtbx_po_no.Location = new System.Drawing.Point(625, 90);
			this.txtbx_po_no.Margin = new System.Windows.Forms.Padding(1);
			this.txtbx_po_no.Name = "txtbx_po_no";
			this.txtbx_po_no.Size = new System.Drawing.Size(220, 26);
			this.txtbx_po_no.TabIndex = 154;
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(527, 92);
			this.label1.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(98, 26);
			this.label1.TabIndex = 156;
			this.label1.Text = "PO Number";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// btn_search_bn
			// 
			this.btn_search_bn.BackColor = System.Drawing.Color.Silver;
			this.btn_search_bn.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_search_bn.Location = new System.Drawing.Point(851, 88);
			this.btn_search_bn.Margin = new System.Windows.Forms.Padding(1);
			this.btn_search_bn.Name = "btn_search_bn";
			this.btn_search_bn.Size = new System.Drawing.Size(120, 27);
			this.btn_search_bn.TabIndex = 155;
			this.btn_search_bn.Text = "Search";
			this.btn_search_bn.UseVisualStyleBackColor = false;
			this.btn_search_bn.Click += new System.EventHandler(this.Btn_search_bnClick);
			// 
			// frm_prod_warehouse_ax_wj303_print_one
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.CancelButton = this.btn_cancel;
			this.ClientSize = new System.Drawing.Size(984, 662);
			this.Controls.Add(this.txtbx_po_no);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.btn_search_bn);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.btn_cancel);
			this.Controls.Add(this.btn_clear);
			this.Controls.Add(this.txtbx_ref_no);
			this.Controls.Add(this.lbl_ref_no);
			this.Controls.Add(this.btn_search);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.reportViewer1);
			this.Name = "frm_prod_warehouse_ax_wj303_print_one";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Print AX Label";
			this.panel2.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.Button btn_search_bn;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtbx_po_no;
		private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
		private System.Windows.Forms.Button btn_clear;
		private System.Windows.Forms.Button btn_cancel;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button btn_search;
		private System.Windows.Forms.Label lbl_ref_no;
		private System.Windows.Forms.TextBox txtbx_ref_no;
		private System.Windows.Forms.Label lbl_header;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label lbl_username;
		private System.Windows.Forms.Panel panel2;
	}
}
