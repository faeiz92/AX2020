/*
 * Created by SharpDevelop.
 * User: faeiz
 * Date: 2017-07-07
 * Time: 5:32 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace AX2020
{
	partial class frm_menu_sub_schwaner
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
			this.btn_billschwnaer = new System.Windows.Forms.Button();
			this.btn_joschwaner = new System.Windows.Forms.Button();
			this.btn_print = new System.Windows.Forms.Button();
			this.panel2 = new System.Windows.Forms.Panel();
			this.lbl_username = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.panel1 = new System.Windows.Forms.Panel();
			this.btn_cancel = new System.Windows.Forms.Button();
			this.panel2.SuspendLayout();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// btn_billschwnaer
			// 
			this.btn_billschwnaer.BackColor = System.Drawing.Color.Silver;
			this.btn_billschwnaer.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_billschwnaer.Location = new System.Drawing.Point(390, 103);
			this.btn_billschwnaer.Margin = new System.Windows.Forms.Padding(2);
			this.btn_billschwnaer.Name = "btn_billschwnaer";
			this.btn_billschwnaer.Size = new System.Drawing.Size(243, 70);
			this.btn_billschwnaer.TabIndex = 28;
			this.btn_billschwnaer.Text = "Bill Of Material Schwaner";
			this.btn_billschwnaer.UseVisualStyleBackColor = false;
			this.btn_billschwnaer.Click += new System.EventHandler(this.Btn_billschwnaerClick);
			// 
			// btn_joschwaner
			// 
			this.btn_joschwaner.BackColor = System.Drawing.Color.Silver;
			this.btn_joschwaner.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_joschwaner.Location = new System.Drawing.Point(390, 188);
			this.btn_joschwaner.Margin = new System.Windows.Forms.Padding(2);
			this.btn_joschwaner.Name = "btn_joschwaner";
			this.btn_joschwaner.Size = new System.Drawing.Size(243, 70);
			this.btn_joschwaner.TabIndex = 29;
			this.btn_joschwaner.Text = "Schwaner Jo Memo";
			this.btn_joschwaner.UseVisualStyleBackColor = false;
			this.btn_joschwaner.Click += new System.EventHandler(this.Btn_joschwanerClick);
			// 
			// btn_print
			// 
			this.btn_print.BackColor = System.Drawing.Color.Silver;
			this.btn_print.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_print.Location = new System.Drawing.Point(390, 275);
			this.btn_print.Margin = new System.Windows.Forms.Padding(2);
			this.btn_print.Name = "btn_print";
			this.btn_print.Size = new System.Drawing.Size(243, 70);
			this.btn_print.TabIndex = 30;
			this.btn_print.Text = "Print Schwaner Jo Memo";
			this.btn_print.UseVisualStyleBackColor = false;
			this.btn_print.Click += new System.EventHandler(this.Btn_printClick);
			// 
			// panel2
			// 
			this.panel2.BackColor = System.Drawing.Color.Gainsboro;
			this.panel2.Controls.Add(this.lbl_username);
			this.panel2.Location = new System.Drawing.Point(1, 50);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(986, 16);
			this.panel2.TabIndex = 140;
			// 
			// lbl_username
			// 
			this.lbl_username.BackColor = System.Drawing.Color.Gainsboro;
			this.lbl_username.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.lbl_username.Location = new System.Drawing.Point(655, -1);
			this.lbl_username.Name = "lbl_username";
			this.lbl_username.Size = new System.Drawing.Size(308, 23);
			this.lbl_username.TabIndex = 0;
			this.lbl_username.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label10
			// 
			this.label10.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label10.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
			this.label10.Location = new System.Drawing.Point(400, 14);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(300, 23);
			this.label10.TabIndex = 0;
			this.label10.Text = "COATING SCHWANER JOB ORDER";
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.Color.DarkCyan;
			this.panel1.Controls.Add(this.label10);
			this.panel1.Location = new System.Drawing.Point(1, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(984, 52);
			this.panel1.TabIndex = 139;
			// 
			// btn_cancel
			// 
			this.btn_cancel.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_cancel.Location = new System.Drawing.Point(429, 395);
			this.btn_cancel.Name = "btn_cancel";
			this.btn_cancel.Size = new System.Drawing.Size(130, 27);
			this.btn_cancel.TabIndex = 141;
			this.btn_cancel.Text = "Cancel";
			this.btn_cancel.UseVisualStyleBackColor = true;
			this.btn_cancel.Click += new System.EventHandler(this.Btn_cancelClick);
			// 
			// frm_menu_sub_schwaner
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.AutoScroll = true;
			this.ClientSize = new System.Drawing.Size(984, 662);
			this.Controls.Add(this.btn_cancel);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.btn_print);
			this.Controls.Add(this.btn_joschwaner);
			this.Controls.Add(this.btn_billschwnaer);
			this.Name = "frm_menu_sub_schwaner";
			this.Text = "frm_menu_sub_schwaner";
			this.panel2.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.Button btn_cancel;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label lbl_username;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Button btn_print;
		private System.Windows.Forms.Button btn_billschwnaer;
		private System.Windows.Forms.Button btn_joschwaner;
	}
}
