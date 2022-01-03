/*
 * Created by SharpDevelop.
 * User: it-4
 * Date: 17/11/2016
 * Time: 9:46 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace AX2020
{
	partial class frm_menu_system
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
			this.btn_forgot_pass = new System.Windows.Forms.LinkLabel();
			this.btn_login = new System.Windows.Forms.Button();
			this.txtbx_user_name = new System.Windows.Forms.TextBox();
			this.lbl_user_name = new System.Windows.Forms.Label();
			this.txtbx_user_pass = new System.Windows.Forms.TextBox();
			this.lbl_user_pass = new System.Windows.Forms.Label();
			this.btn_exit = new System.Windows.Forms.Button();
			this.btn_update = new System.Windows.Forms.Button();
			this.lbl_version = new System.Windows.Forms.TextBox();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// lbl_header
			// 
			this.lbl_header.BackColor = System.Drawing.Color.DarkCyan;
			this.lbl_header.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbl_header.ForeColor = System.Drawing.SystemColors.ControlLightLight;
			this.lbl_header.Location = new System.Drawing.Point(30, 13);
			this.lbl_header.Name = "lbl_header";
			this.lbl_header.Size = new System.Drawing.Size(258, 23);
			this.lbl_header.TabIndex = 122;
			this.lbl_header.Text = "AX2020";
			this.lbl_header.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.Color.DarkCyan;
			this.panel1.Controls.Add(this.lbl_version);
			this.panel1.Controls.Add(this.lbl_header);
			this.panel1.Location = new System.Drawing.Point(-1, -1);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(388, 52);
			this.panel1.TabIndex = 126;
			// 
			// btn_forgot_pass
			// 
			this.btn_forgot_pass.ActiveLinkColor = System.Drawing.Color.DarkCyan;
			this.btn_forgot_pass.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_forgot_pass.LinkColor = System.Drawing.Color.Black;
			this.btn_forgot_pass.Location = new System.Drawing.Point(194, 132);
			this.btn_forgot_pass.Name = "btn_forgot_pass";
			this.btn_forgot_pass.Size = new System.Drawing.Size(166, 23);
			this.btn_forgot_pass.TabIndex = 142;
			this.btn_forgot_pass.TabStop = true;
			this.btn_forgot_pass.Text = "Forgot your password?";
			this.btn_forgot_pass.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btn_forgot_pass.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.Btn_forgot_passLinkClicked);
			// 
			// btn_login
			// 
			this.btn_login.BackColor = System.Drawing.Color.Silver;
			this.btn_login.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_login.Location = new System.Drawing.Point(140, 162);
			this.btn_login.Name = "btn_login";
			this.btn_login.Size = new System.Drawing.Size(108, 27);
			this.btn_login.TabIndex = 3;
			this.btn_login.Text = "Login";
			this.btn_login.UseVisualStyleBackColor = false;
			this.btn_login.Click += new System.EventHandler(this.Btn_loginClick);
			// 
			// txtbx_user_name
			// 
			this.txtbx_user_name.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtbx_user_name.Location = new System.Drawing.Point(113, 71);
			this.txtbx_user_name.Name = "txtbx_user_name";
			this.txtbx_user_name.Size = new System.Drawing.Size(247, 26);
			this.txtbx_user_name.TabIndex = 1;
			// 
			// lbl_user_name
			// 
			this.lbl_user_name.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbl_user_name.Location = new System.Drawing.Point(23, 71);
			this.lbl_user_name.Name = "lbl_user_name";
			this.lbl_user_name.Size = new System.Drawing.Size(89, 26);
			this.lbl_user_name.TabIndex = 140;
			this.lbl_user_name.Text = "Username";
			this.lbl_user_name.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtbx_user_pass
			// 
			this.txtbx_user_pass.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtbx_user_pass.Location = new System.Drawing.Point(113, 103);
			this.txtbx_user_pass.Name = "txtbx_user_pass";
			this.txtbx_user_pass.Size = new System.Drawing.Size(247, 26);
			this.txtbx_user_pass.TabIndex = 2;
			this.txtbx_user_pass.UseSystemPasswordChar = true;
			// 
			// lbl_user_pass
			// 
			this.lbl_user_pass.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbl_user_pass.Location = new System.Drawing.Point(23, 103);
			this.lbl_user_pass.Name = "lbl_user_pass";
			this.lbl_user_pass.Size = new System.Drawing.Size(89, 26);
			this.lbl_user_pass.TabIndex = 139;
			this.lbl_user_pass.Text = "Password";
			this.lbl_user_pass.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// btn_exit
			// 
			this.btn_exit.BackColor = System.Drawing.Color.Silver;
			this.btn_exit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btn_exit.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_exit.Location = new System.Drawing.Point(258, 162);
			this.btn_exit.Name = "btn_exit";
			this.btn_exit.Size = new System.Drawing.Size(108, 27);
			this.btn_exit.TabIndex = 4;
			this.btn_exit.Text = "Exit";
			this.btn_exit.UseVisualStyleBackColor = false;
			this.btn_exit.Click += new System.EventHandler(this.Btn_exitClick);
			// 
			// btn_update
			// 
			this.btn_update.BackColor = System.Drawing.Color.Silver;
			this.btn_update.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_update.Location = new System.Drawing.Point(20, 162);
			this.btn_update.Name = "btn_update";
			this.btn_update.Size = new System.Drawing.Size(108, 27);
			this.btn_update.TabIndex = 143;
			this.btn_update.Text = "Version Upgrade";
			this.btn_update.UseVisualStyleBackColor = false;
			this.btn_update.Click += new System.EventHandler(this.Btn_updateClick);
			// 
			// lbl_version
			// 
			this.lbl_version.BackColor = System.Drawing.Color.DarkCyan;
			this.lbl_version.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.lbl_version.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbl_version.ForeColor = System.Drawing.SystemColors.ControlLightLight;
			this.lbl_version.Location = new System.Drawing.Point(193, 15);
			this.lbl_version.Name = "lbl_version";
			this.lbl_version.Size = new System.Drawing.Size(130, 19);
			this.lbl_version.TabIndex = 144;
			// 
			// frm_menu_system
			// 
			this.AcceptButton = this.btn_login;
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.CancelButton = this.btn_exit;
			this.ClientSize = new System.Drawing.Size(384, 213);
			this.Controls.Add(this.btn_update);
			this.Controls.Add(this.btn_forgot_pass);
			this.Controls.Add(this.btn_login);
			this.Controls.Add(this.txtbx_user_name);
			this.Controls.Add(this.lbl_user_name);
			this.Controls.Add(this.txtbx_user_pass);
			this.Controls.Add(this.lbl_user_pass);
			this.Controls.Add(this.btn_exit);
			this.Controls.Add(this.panel1);
			this.MaximizeBox = false;
			this.Name = "frm_menu_system";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Login";
			this.Load += new System.EventHandler(this.Frm_menu_systemLoad);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.Button btn_update;
		private System.Windows.Forms.TextBox lbl_version;
		private System.Windows.Forms.Button btn_login;
		private System.Windows.Forms.LinkLabel btn_forgot_pass;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Button btn_exit;
		private System.Windows.Forms.Label lbl_header;
		private System.Windows.Forms.Label lbl_user_pass;
		private System.Windows.Forms.TextBox txtbx_user_pass;
		private System.Windows.Forms.Label lbl_user_name;
		private System.Windows.Forms.TextBox txtbx_user_name;
	}
}
