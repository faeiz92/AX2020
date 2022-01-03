/*
 * Created by SharpDevelop.
 * User: faeiz
 * Date: 2017-09-21
 * Time: 11:43 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace AX2020
{
	partial class frm_rpt_procurement
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
			this.btn_poimport = new System.Windows.Forms.Button();
			this.btn_polocal = new System.Windows.Forms.Button();
			this.btn_pro = new System.Windows.Forms.Button();
			this.btn_po_pending = new System.Windows.Forms.Button();
			this.panel2.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel2
			// 
			this.panel2.BackColor = System.Drawing.Color.Gainsboro;
			this.panel2.Controls.Add(this.lbl_username);
			this.panel2.Location = new System.Drawing.Point(-4, 48);
			this.panel2.Margin = new System.Windows.Forms.Padding(1);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(984, 23);
			this.panel2.TabIndex = 117;
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
			// lbl_header
			// 
			this.lbl_header.BackColor = System.Drawing.Color.DarkCyan;
			this.lbl_header.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbl_header.ForeColor = System.Drawing.SystemColors.ControlLightLight;
			this.lbl_header.Location = new System.Drawing.Point(-3, 13);
			this.lbl_header.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
			this.lbl_header.Name = "lbl_header";
			this.lbl_header.Size = new System.Drawing.Size(1000, 23);
			this.lbl_header.TabIndex = 115;
			this.lbl_header.Text = "PROCUREMENT REPORT";
			this.lbl_header.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.Color.DarkCyan;
			this.panel1.Location = new System.Drawing.Point(-4, -2);
			this.panel1.Margin = new System.Windows.Forms.Padding(1);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(1000, 52);
			this.panel1.TabIndex = 116;
			// 
			// btn_poimport
			// 
			this.btn_poimport.BackColor = System.Drawing.Color.Silver;
			this.btn_poimport.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_poimport.Location = new System.Drawing.Point(370, 292);
			this.btn_poimport.Margin = new System.Windows.Forms.Padding(1);
			this.btn_poimport.Name = "btn_poimport";
			this.btn_poimport.Size = new System.Drawing.Size(231, 46);
			this.btn_poimport.TabIndex = 119;
			this.btn_poimport.Text = "Po Import";
			this.btn_poimport.UseVisualStyleBackColor = false;
			this.btn_poimport.Click += new System.EventHandler(this.Btn_poimportClick);
			// 
			// btn_polocal
			// 
			this.btn_polocal.BackColor = System.Drawing.Color.Silver;
			this.btn_polocal.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_polocal.Location = new System.Drawing.Point(370, 241);
			this.btn_polocal.Margin = new System.Windows.Forms.Padding(1);
			this.btn_polocal.Name = "btn_polocal";
			this.btn_polocal.Size = new System.Drawing.Size(231, 46);
			this.btn_polocal.TabIndex = 118;
			this.btn_polocal.Text = "Po Local";
			this.btn_polocal.UseVisualStyleBackColor = false;
			this.btn_polocal.Click += new System.EventHandler(this.Btn_polocalClick);
			// 
			// btn_pro
			// 
			this.btn_pro.BackColor = System.Drawing.Color.Silver;
			this.btn_pro.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_pro.Location = new System.Drawing.Point(370, 190);
			this.btn_pro.Margin = new System.Windows.Forms.Padding(1);
			this.btn_pro.Name = "btn_pro";
			this.btn_pro.Size = new System.Drawing.Size(231, 46);
			this.btn_pro.TabIndex = 120;
			this.btn_pro.Text = "Po Detail Report";
			this.btn_pro.UseVisualStyleBackColor = false;
			this.btn_pro.Click += new System.EventHandler(this.Btn_proClick);
			// 
			// btn_po_pending
			// 
			this.btn_po_pending.BackColor = System.Drawing.Color.Silver;
			this.btn_po_pending.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_po_pending.Location = new System.Drawing.Point(370, 343);
			this.btn_po_pending.Margin = new System.Windows.Forms.Padding(1);
			this.btn_po_pending.Name = "btn_po_pending";
			this.btn_po_pending.Size = new System.Drawing.Size(231, 46);
			this.btn_po_pending.TabIndex = 121;
			this.btn_po_pending.Text = "Po Pending Delivery";
			this.btn_po_pending.UseVisualStyleBackColor = false;
			this.btn_po_pending.Click += new System.EventHandler(this.Btn_po_pendingClick);
			// 
			// frm_rpt_procurement
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(984, 662);
			this.Controls.Add(this.btn_po_pending);
			this.Controls.Add(this.btn_pro);
			this.Controls.Add(this.btn_poimport);
			this.Controls.Add(this.btn_polocal);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.lbl_header);
			this.Controls.Add(this.panel1);
			this.Name = "frm_rpt_procurement";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "frm_prod_procurement";
			this.panel2.ResumeLayout(false);
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.Button btn_po_pending;
		private System.Windows.Forms.Button btn_pro;
		private System.Windows.Forms.Button btn_polocal;
		private System.Windows.Forms.Button btn_poimport;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label lbl_header;
		private System.Windows.Forms.Label lbl_username;
		private System.Windows.Forms.Panel panel2;
	}
}
