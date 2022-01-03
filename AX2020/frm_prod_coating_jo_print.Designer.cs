/*
 * Created by SharpDevelop.
 * User: ax2020-2
 * Date: 2/27/2017
 * Time: 11:58 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace AX2020
{
	partial class frm_prod_coating_jo_print
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
			this.lbl_ref_no = new System.Windows.Forms.Label();
			this.btn_search = new System.Windows.Forms.Button();
			this.lbl_header = new System.Windows.Forms.Label();
			this.txtbx_ref_no = new System.Windows.Forms.TextBox();
			this.panel2 = new System.Windows.Forms.Panel();
			this.lbl_username = new System.Windows.Forms.Label();
			this.panel1 = new System.Windows.Forms.Panel();
			this.button1 = new System.Windows.Forms.Button();
			this.panel2.SuspendLayout();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// lbl_ref_no
			// 
			this.lbl_ref_no.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbl_ref_no.Location = new System.Drawing.Point(37, 105);
			this.lbl_ref_no.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
			this.lbl_ref_no.Name = "lbl_ref_no";
			this.lbl_ref_no.Size = new System.Drawing.Size(131, 26);
			this.lbl_ref_no.TabIndex = 119;
			this.lbl_ref_no.Text = "JO No";
			this.lbl_ref_no.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// btn_search
			// 
			this.btn_search.BackColor = System.Drawing.Color.Silver;
			this.btn_search.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_search.Location = new System.Drawing.Point(339, 102);
			this.btn_search.Margin = new System.Windows.Forms.Padding(1);
			this.btn_search.Name = "btn_search";
			this.btn_search.Size = new System.Drawing.Size(120, 27);
			this.btn_search.TabIndex = 117;
			this.btn_search.Text = "Search";
			this.btn_search.UseVisualStyleBackColor = false;
			this.btn_search.Click += new System.EventHandler(this.Btn_searchClick);
			// 
			// lbl_header
			// 
			this.lbl_header.BackColor = System.Drawing.Color.DarkCyan;
			this.lbl_header.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbl_header.ForeColor = System.Drawing.SystemColors.ControlLightLight;
			this.lbl_header.Location = new System.Drawing.Point(0, 15);
			this.lbl_header.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
			this.lbl_header.Name = "lbl_header";
			this.lbl_header.Size = new System.Drawing.Size(981, 23);
			this.lbl_header.TabIndex = 0;
			this.lbl_header.Text = "REPRINT COATING JOB ORDER";
			this.lbl_header.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// txtbx_ref_no
			// 
			this.txtbx_ref_no.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtbx_ref_no.Location = new System.Drawing.Point(104, 103);
			this.txtbx_ref_no.Margin = new System.Windows.Forms.Padding(1);
			this.txtbx_ref_no.Name = "txtbx_ref_no";
			this.txtbx_ref_no.Size = new System.Drawing.Size(220, 26);
			this.txtbx_ref_no.TabIndex = 118;
			// 
			// panel2
			// 
			this.panel2.BackColor = System.Drawing.Color.Gainsboro;
			this.panel2.Controls.Add(this.lbl_username);
			this.panel2.Location = new System.Drawing.Point(-1, 49);
			this.panel2.Margin = new System.Windows.Forms.Padding(1);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(986, 23);
			this.panel2.TabIndex = 116;
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
			this.panel1.Location = new System.Drawing.Point(-1, -1);
			this.panel1.Margin = new System.Windows.Forms.Padding(1);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(984, 52);
			this.panel1.TabIndex = 115;
			// 
			// button1
			// 
			this.button1.BackColor = System.Drawing.Color.Silver;
			this.button1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.button1.Location = new System.Drawing.Point(450, 590);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(130, 30);
			this.button1.TabIndex = 120;
			this.button1.Text = "Cancel";
			this.button1.UseVisualStyleBackColor = false;
			this.button1.Click += new System.EventHandler(this.Button1Click);
			// 
			// frm_prod_coating_jo_print
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.ClientSize = new System.Drawing.Size(984, 662);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.btn_search);
			this.Controls.Add(this.txtbx_ref_no);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.lbl_ref_no);
			this.Name = "frm_prod_coating_jo_print";
			this.Text = "frm_prod_coating_jo_print";
			this.panel2.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label lbl_username;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.TextBox txtbx_ref_no;
		private System.Windows.Forms.Label lbl_header;
		private System.Windows.Forms.Button btn_search;
		private System.Windows.Forms.Label lbl_ref_no;
	}
}
