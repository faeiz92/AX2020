/*
 * Created by SharpDevelop.
 * User: ax2020-1
 * Date: 2/20/2017
 * Time: 9:40 AMfrm_prod_menu_doubleside_r2
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace AX2020
{
	partial class frm_menu_qac
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
			this.lbl_header = new System.Windows.Forms.Label();
			this.panel1 = new System.Windows.Forms.Panel();
			this.lbl_username = new System.Windows.Forms.Label();
			this.panel2 = new System.Windows.Forms.Panel();
			this.btn_back = new System.Windows.Forms.Button();
			this.btn_prod_track_stat = new System.Windows.Forms.Button();
			this.btn_coat_overweight = new System.Windows.Forms.Button();
			this.btn_coat_underweight = new System.Windows.Forms.Button();
			this.panel2.SuspendLayout();
			this.SuspendLayout();
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
			this.lbl_header.TabIndex = 89;
			this.lbl_header.Text = "QAC";
			this.lbl_header.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.Color.DarkCyan;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Margin = new System.Windows.Forms.Padding(1);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(1000, 52);
			this.panel1.TabIndex = 90;
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
			// panel2
			// 
			this.panel2.BackColor = System.Drawing.Color.Gainsboro;
			this.panel2.Controls.Add(this.lbl_username);
			this.panel2.Location = new System.Drawing.Point(0, 50);
			this.panel2.Margin = new System.Windows.Forms.Padding(1);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(1000, 23);
			this.panel2.TabIndex = 111;
			// 
			// btn_back
			// 
			this.btn_back.BackColor = System.Drawing.Color.Silver;
			this.btn_back.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btn_back.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_back.Location = new System.Drawing.Point(440, 615);
			this.btn_back.Margin = new System.Windows.Forms.Padding(1);
			this.btn_back.Name = "btn_back";
			this.btn_back.Size = new System.Drawing.Size(120, 27);
			this.btn_back.TabIndex = 114;
			this.btn_back.Text = "Cancel";
			this.btn_back.UseVisualStyleBackColor = false;
			this.btn_back.Click += new System.EventHandler(this.Btn_backClick);
			// 
			// btn_prod_track_stat
			// 
			this.btn_prod_track_stat.BackColor = System.Drawing.Color.Silver;
			this.btn_prod_track_stat.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_prod_track_stat.Location = new System.Drawing.Point(380, 120);
			this.btn_prod_track_stat.Margin = new System.Windows.Forms.Padding(1);
			this.btn_prod_track_stat.Name = "btn_prod_track_stat";
			this.btn_prod_track_stat.Size = new System.Drawing.Size(231, 61);
			this.btn_prod_track_stat.TabIndex = 1;
			this.btn_prod_track_stat.Text = "Job Order Tracking Status";
			this.btn_prod_track_stat.UseVisualStyleBackColor = false;
			this.btn_prod_track_stat.Click += new System.EventHandler(this.Btn_prod_track_statClick);
			// 
			// btn_coat_overweight
			// 
			this.btn_coat_overweight.BackColor = System.Drawing.Color.Silver;
			this.btn_coat_overweight.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_coat_overweight.Location = new System.Drawing.Point(380, 192);
			this.btn_coat_overweight.Margin = new System.Windows.Forms.Padding(1);
			this.btn_coat_overweight.Name = "btn_coat_overweight";
			this.btn_coat_overweight.Size = new System.Drawing.Size(231, 61);
			this.btn_coat_overweight.TabIndex = 115;
			this.btn_coat_overweight.Text = "Coating Output Overweight";
			this.btn_coat_overweight.UseVisualStyleBackColor = false;
			this.btn_coat_overweight.Click += new System.EventHandler(this.Btn_coat_overweightClick);
			// 
			// btn_coat_underweight
			// 
			this.btn_coat_underweight.BackColor = System.Drawing.Color.Silver;
			this.btn_coat_underweight.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_coat_underweight.Location = new System.Drawing.Point(380, 266);
			this.btn_coat_underweight.Margin = new System.Windows.Forms.Padding(1);
			this.btn_coat_underweight.Name = "btn_coat_underweight";
			this.btn_coat_underweight.Size = new System.Drawing.Size(231, 61);
			this.btn_coat_underweight.TabIndex = 116;
			this.btn_coat_underweight.Text = "Coating Output Underweight";
			this.btn_coat_underweight.UseVisualStyleBackColor = false;
			this.btn_coat_underweight.Click += new System.EventHandler(this.Btn_coat_underweightClick);
			// 
			// frm_menu_qac
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.CancelButton = this.btn_back;
			this.ClientSize = new System.Drawing.Size(984, 662);
			this.Controls.Add(this.btn_coat_underweight);
			this.Controls.Add(this.btn_coat_overweight);
			this.Controls.Add(this.btn_prod_track_stat);
			this.Controls.Add(this.btn_back);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.lbl_header);
			this.Controls.Add(this.panel1);
			this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Name = "frm_menu_qac";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Qac";
			this.panel2.ResumeLayout(false);
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.Button btn_coat_underweight;
		private System.Windows.Forms.Button btn_coat_overweight;
		private System.Windows.Forms.Button btn_back;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Label lbl_username;
		private System.Windows.Forms.Button btn_prod_track_stat;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label lbl_header;
	}
}