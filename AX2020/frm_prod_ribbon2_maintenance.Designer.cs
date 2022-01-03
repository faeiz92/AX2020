/*
 * Created by SharpDevelop.
 * User: faeiz
 * Date: 2017-10-29
 * Time: 1:51 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace AX2020
{
	partial class frm_prod_ribbon2_maintenance
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
			this.txtbx_operator = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.txtbx_helper = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.txtbx_machine = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.btn_add_operator = new System.Windows.Forms.Button();
			this.btn_add_helper = new System.Windows.Forms.Button();
			this.btn_add_machine = new System.Windows.Forms.Button();
			this.btn_cancel = new System.Windows.Forms.Button();
			this.panel2.SuspendLayout();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel2
			// 
			this.panel2.BackColor = System.Drawing.Color.Gainsboro;
			this.panel2.Controls.Add(this.lbl_username);
			this.panel2.Location = new System.Drawing.Point(-1, 48);
			this.panel2.Margin = new System.Windows.Forms.Padding(1);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(986, 23);
			this.panel2.TabIndex = 115;
			// 
			// lbl_username
			// 
			this.lbl_username.BackColor = System.Drawing.Color.Gainsboro;
			this.lbl_username.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbl_username.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.lbl_username.Location = new System.Drawing.Point(648, 3);
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
			this.lbl_header.Location = new System.Drawing.Point(-10, 12);
			this.lbl_header.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
			this.lbl_header.Name = "lbl_header";
			this.lbl_header.Size = new System.Drawing.Size(981, 23);
			this.lbl_header.TabIndex = 0;
			this.lbl_header.Text = "Ribbon Maintenance";
			this.lbl_header.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.Color.DarkCyan;
			this.panel1.Controls.Add(this.lbl_header);
			this.panel1.Location = new System.Drawing.Point(-1, -2);
			this.panel1.Margin = new System.Windows.Forms.Padding(1);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(984, 52);
			this.panel1.TabIndex = 114;
			// 
			// txtbx_operator
			// 
			this.txtbx_operator.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtbx_operator.Location = new System.Drawing.Point(328, 112);
			this.txtbx_operator.Name = "txtbx_operator";
			this.txtbx_operator.Size = new System.Drawing.Size(200, 26);
			this.txtbx_operator.TabIndex = 117;
			// 
			// label2
			// 
			this.label2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.Location = new System.Drawing.Point(184, 111);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(119, 23);
			this.label2.TabIndex = 116;
			this.label2.Text = "Operator Name";
			// 
			// txtbx_helper
			// 
			this.txtbx_helper.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtbx_helper.Location = new System.Drawing.Point(328, 162);
			this.txtbx_helper.Name = "txtbx_helper";
			this.txtbx_helper.Size = new System.Drawing.Size(200, 26);
			this.txtbx_helper.TabIndex = 119;
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(196, 162);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(107, 23);
			this.label1.TabIndex = 118;
			this.label1.Text = "Helper Name";
			// 
			// txtbx_machine
			// 
			this.txtbx_machine.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtbx_machine.Location = new System.Drawing.Point(328, 205);
			this.txtbx_machine.Name = "txtbx_machine";
			this.txtbx_machine.Size = new System.Drawing.Size(200, 26);
			this.txtbx_machine.TabIndex = 121;
			// 
			// label3
			// 
			this.label3.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.Location = new System.Drawing.Point(184, 205);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(119, 23);
			this.label3.TabIndex = 120;
			this.label3.Text = "Machine Name";
			// 
			// btn_add_operator
			// 
			this.btn_add_operator.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_add_operator.Location = new System.Drawing.Point(565, 109);
			this.btn_add_operator.Name = "btn_add_operator";
			this.btn_add_operator.Size = new System.Drawing.Size(125, 30);
			this.btn_add_operator.TabIndex = 122;
			this.btn_add_operator.Text = "Add Operator";
			this.btn_add_operator.UseVisualStyleBackColor = true;
			this.btn_add_operator.Click += new System.EventHandler(this.Btn_add_operatorClick);
			// 
			// btn_add_helper
			// 
			this.btn_add_helper.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_add_helper.Location = new System.Drawing.Point(565, 162);
			this.btn_add_helper.Name = "btn_add_helper";
			this.btn_add_helper.Size = new System.Drawing.Size(125, 30);
			this.btn_add_helper.TabIndex = 123;
			this.btn_add_helper.Text = "Add Helper";
			this.btn_add_helper.UseVisualStyleBackColor = true;
			this.btn_add_helper.Click += new System.EventHandler(this.Btn_add_helperClick);
			// 
			// btn_add_machine
			// 
			this.btn_add_machine.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_add_machine.Location = new System.Drawing.Point(565, 205);
			this.btn_add_machine.Name = "btn_add_machine";
			this.btn_add_machine.Size = new System.Drawing.Size(125, 30);
			this.btn_add_machine.TabIndex = 124;
			this.btn_add_machine.Text = "Add Machine";
			this.btn_add_machine.UseVisualStyleBackColor = true;
			this.btn_add_machine.Click += new System.EventHandler(this.Btn_add_machineClick);
			// 
			// btn_cancel
			// 
			this.btn_cancel.BackColor = System.Drawing.Color.Silver;
			this.btn_cancel.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_cancel.Location = new System.Drawing.Point(445, 505);
			this.btn_cancel.Margin = new System.Windows.Forms.Padding(2);
			this.btn_cancel.Name = "btn_cancel";
			this.btn_cancel.Size = new System.Drawing.Size(136, 26);
			this.btn_cancel.TabIndex = 165;
			this.btn_cancel.Text = "CANCEL";
			this.btn_cancel.UseVisualStyleBackColor = false;
			this.btn_cancel.Click += new System.EventHandler(this.Btn_cancelClick);
			// 
			// frm_prod_ribbon2_maintenance
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.ClientSize = new System.Drawing.Size(984, 662);
			this.Controls.Add(this.btn_cancel);
			this.Controls.Add(this.btn_add_machine);
			this.Controls.Add(this.btn_add_helper);
			this.Controls.Add(this.btn_add_operator);
			this.Controls.Add(this.txtbx_machine);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.txtbx_helper);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.txtbx_operator);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.panel1);
			this.Name = "frm_prod_ribbon2_maintenance";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "frm_prod_ribbon2_maintenance";
			this.panel2.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.Button btn_cancel;
		private System.Windows.Forms.Button btn_add_machine;
		private System.Windows.Forms.Button btn_add_helper;
		private System.Windows.Forms.Button btn_add_operator;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox txtbx_machine;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtbx_helper;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtbx_operator;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label lbl_header;
		private System.Windows.Forms.Label lbl_username;
		private System.Windows.Forms.Panel panel2;
	}
}
