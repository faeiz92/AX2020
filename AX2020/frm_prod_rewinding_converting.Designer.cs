/*
 * Created by SharpDevelop.
 * User: faeiz
 * Date: 2017-10-10
 * Time: 11:34 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace AX2020
{
	partial class frm_prod_rewinding_converting
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
			this.label1 = new System.Windows.Forms.Label();
			this.btn_cancel = new System.Windows.Forms.Button();
			this.btn_clear = new System.Windows.Forms.Button();
			this.btn_save = new System.Windows.Forms.Button();
			this.cbx_operator = new System.Windows.Forms.ComboBox();
			this.label19 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.txtbx_defective = new System.Windows.Forms.TextBox();
			this.txtbx_rework = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.txtbx_color = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.txtbx_micron = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.txtbx_width = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.txtbx_length = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.txbx_to = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.txtbx_ao = new System.Windows.Forms.TextBox();
			this.label9 = new System.Windows.Forms.Label();
			this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
			this.label10 = new System.Windows.Forms.Label();
			this.txtbx_remark = new System.Windows.Forms.TextBox();
			this.Remark = new System.Windows.Forms.Label();
			this.panel2.SuspendLayout();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel2
			// 
			this.panel2.BackColor = System.Drawing.Color.Gainsboro;
			this.panel2.Controls.Add(this.lbl_username);
			this.panel2.Location = new System.Drawing.Point(2, 50);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(986, 16);
			this.panel2.TabIndex = 138;
			// 
			// lbl_username
			// 
			this.lbl_username.BackColor = System.Drawing.Color.Gainsboro;
			this.lbl_username.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbl_username.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.lbl_username.Location = new System.Drawing.Point(655, -1);
			this.lbl_username.Name = "lbl_username";
			this.lbl_username.Size = new System.Drawing.Size(308, 23);
			this.lbl_username.TabIndex = 0;
			this.lbl_username.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.Color.DarkCyan;
			this.panel1.Controls.Add(this.label1);
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(984, 52);
			this.panel1.TabIndex = 137;
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
			this.label1.Location = new System.Drawing.Point(406, 14);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(200, 23);
			this.label1.TabIndex = 0;
			this.label1.Text = "SMALL REWINDING";
			// 
			// btn_cancel
			// 
			this.btn_cancel.BackColor = System.Drawing.Color.Silver;
			this.btn_cancel.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_cancel.Location = new System.Drawing.Point(551, 554);
			this.btn_cancel.Margin = new System.Windows.Forms.Padding(2);
			this.btn_cancel.Name = "btn_cancel";
			this.btn_cancel.Size = new System.Drawing.Size(153, 26);
			this.btn_cancel.TabIndex = 163;
			this.btn_cancel.Text = "CANCEL";
			this.btn_cancel.UseVisualStyleBackColor = false;
			this.btn_cancel.Click += new System.EventHandler(this.Btn_cancelClick);
			// 
			// btn_clear
			// 
			this.btn_clear.BackColor = System.Drawing.Color.Silver;
			this.btn_clear.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_clear.Location = new System.Drawing.Point(392, 554);
			this.btn_clear.Margin = new System.Windows.Forms.Padding(2);
			this.btn_clear.Name = "btn_clear";
			this.btn_clear.Size = new System.Drawing.Size(153, 26);
			this.btn_clear.TabIndex = 162;
			this.btn_clear.Text = "CLEAR";
			this.btn_clear.UseVisualStyleBackColor = false;
			this.btn_clear.Click += new System.EventHandler(this.Btn_clearClick);
			// 
			// btn_save
			// 
			this.btn_save.BackColor = System.Drawing.Color.Silver;
			this.btn_save.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_save.Location = new System.Drawing.Point(232, 554);
			this.btn_save.Margin = new System.Windows.Forms.Padding(2);
			this.btn_save.Name = "btn_save";
			this.btn_save.Size = new System.Drawing.Size(153, 26);
			this.btn_save.TabIndex = 161;
			this.btn_save.Text = "SAVE";
			this.btn_save.UseVisualStyleBackColor = false;
			this.btn_save.Click += new System.EventHandler(this.Btn_saveClick);
			// 
			// cbx_operator
			// 
			this.cbx_operator.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.cbx_operator.FormattingEnabled = true;
			this.cbx_operator.Location = new System.Drawing.Point(285, 116);
			this.cbx_operator.Name = "cbx_operator";
			this.cbx_operator.Size = new System.Drawing.Size(277, 26);
			this.cbx_operator.TabIndex = 168;
			// 
			// label19
			// 
			this.label19.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label19.Location = new System.Drawing.Point(184, 116);
			this.label19.Name = "label19";
			this.label19.Size = new System.Drawing.Size(76, 20);
			this.label19.TabIndex = 167;
			this.label19.Text = "Operator";
			// 
			// label2
			// 
			this.label2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.Location = new System.Drawing.Point(144, 159);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(126, 20);
			this.label2.TabIndex = 169;
			this.label2.Text = "Defective Brand";
			// 
			// txtbx_defective
			// 
			this.txtbx_defective.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtbx_defective.Location = new System.Drawing.Point(285, 156);
			this.txtbx_defective.Name = "txtbx_defective";
			this.txtbx_defective.Size = new System.Drawing.Size(277, 26);
			this.txtbx_defective.TabIndex = 18;
			// 
			// txtbx_rework
			// 
			this.txtbx_rework.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtbx_rework.Location = new System.Drawing.Point(285, 197);
			this.txtbx_rework.Name = "txtbx_rework";
			this.txtbx_rework.Size = new System.Drawing.Size(277, 26);
			this.txtbx_rework.TabIndex = 170;
			// 
			// label3
			// 
			this.label3.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.Location = new System.Drawing.Point(158, 197);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(116, 20);
			this.label3.TabIndex = 171;
			this.label3.Text = "Rework Brand";
			// 
			// txtbx_color
			// 
			this.txtbx_color.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtbx_color.Location = new System.Drawing.Point(285, 275);
			this.txtbx_color.Name = "txtbx_color";
			this.txtbx_color.Size = new System.Drawing.Size(160, 26);
			this.txtbx_color.TabIndex = 173;
			// 
			// label4
			// 
			this.label4.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label4.Location = new System.Drawing.Point(213, 275);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(61, 26);
			this.label4.TabIndex = 172;
			this.label4.Text = "Color";
			// 
			// txtbx_micron
			// 
			this.txtbx_micron.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtbx_micron.Location = new System.Drawing.Point(285, 317);
			this.txtbx_micron.Name = "txtbx_micron";
			this.txtbx_micron.Size = new System.Drawing.Size(160, 26);
			this.txtbx_micron.TabIndex = 175;
			// 
			// label5
			// 
			this.label5.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label5.Location = new System.Drawing.Point(209, 317);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(61, 26);
			this.label5.TabIndex = 174;
			this.label5.Text = "Micron";
			// 
			// txtbx_width
			// 
			this.txtbx_width.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtbx_width.Location = new System.Drawing.Point(285, 360);
			this.txtbx_width.Name = "txtbx_width";
			this.txtbx_width.Size = new System.Drawing.Size(160, 26);
			this.txtbx_width.TabIndex = 177;
			// 
			// label6
			// 
			this.label6.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label6.Location = new System.Drawing.Point(209, 360);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(53, 26);
			this.label6.TabIndex = 176;
			this.label6.Text = "Width";
			// 
			// txtbx_length
			// 
			this.txtbx_length.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtbx_length.Location = new System.Drawing.Point(285, 401);
			this.txtbx_length.Name = "txtbx_length";
			this.txtbx_length.Size = new System.Drawing.Size(160, 26);
			this.txtbx_length.TabIndex = 179;
			// 
			// label7
			// 
			this.label7.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label7.Location = new System.Drawing.Point(201, 401);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(61, 26);
			this.label7.TabIndex = 178;
			this.label7.Text = "Length";
			// 
			// txbx_to
			// 
			this.txbx_to.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txbx_to.Location = new System.Drawing.Point(285, 440);
			this.txbx_to.Name = "txbx_to";
			this.txbx_to.Size = new System.Drawing.Size(160, 26);
			this.txbx_to.TabIndex = 181;
			// 
			// label8
			// 
			this.label8.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label8.Location = new System.Drawing.Point(160, 440);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(102, 26);
			this.label8.TabIndex = 180;
			this.label8.Text = "Target Output";
			// 
			// txtbx_ao
			// 
			this.txtbx_ao.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtbx_ao.Location = new System.Drawing.Point(285, 482);
			this.txtbx_ao.Name = "txtbx_ao";
			this.txtbx_ao.Size = new System.Drawing.Size(160, 26);
			this.txtbx_ao.TabIndex = 183;
			// 
			// label9
			// 
			this.label9.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label9.Location = new System.Drawing.Point(158, 482);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(102, 26);
			this.label9.TabIndex = 182;
			this.label9.Text = "Actual Output";
			// 
			// dateTimePicker1
			// 
			this.dateTimePicker1.CalendarFont = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.dateTimePicker1.Location = new System.Drawing.Point(285, 237);
			this.dateTimePicker1.Name = "dateTimePicker1";
			this.dateTimePicker1.Size = new System.Drawing.Size(231, 26);
			this.dateTimePicker1.TabIndex = 187;
			this.dateTimePicker1.Value = new System.DateTime(2017, 12, 27, 0, 0, 0, 0);
			// 
			// label10
			// 
			this.label10.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label10.Location = new System.Drawing.Point(166, 237);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(102, 26);
			this.label10.TabIndex = 186;
			this.label10.Text = "Date of Issue";
			// 
			// txtbx_remark
			// 
			this.txtbx_remark.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtbx_remark.Location = new System.Drawing.Point(285, 523);
			this.txtbx_remark.Name = "txtbx_remark";
			this.txtbx_remark.Size = new System.Drawing.Size(277, 26);
			this.txtbx_remark.TabIndex = 189;
			// 
			// Remark
			// 
			this.Remark.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Remark.Location = new System.Drawing.Point(179, 526);
			this.Remark.Name = "Remark";
			this.Remark.Size = new System.Drawing.Size(83, 26);
			this.Remark.TabIndex = 188;
			this.Remark.Text = "Remarks";
			// 
			// frm_prod_rewinding_converting
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.AutoScroll = true;
			this.ClientSize = new System.Drawing.Size(1001, 679);
			this.Controls.Add(this.txtbx_remark);
			this.Controls.Add(this.Remark);
			this.Controls.Add(this.dateTimePicker1);
			this.Controls.Add(this.label10);
			this.Controls.Add(this.txtbx_ao);
			this.Controls.Add(this.label9);
			this.Controls.Add(this.txbx_to);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.txtbx_length);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.txtbx_width);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.txtbx_micron);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.txtbx_color);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.txtbx_rework);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.txtbx_defective);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.cbx_operator);
			this.Controls.Add(this.label19);
			this.Controls.Add(this.btn_cancel);
			this.Controls.Add(this.btn_clear);
			this.Controls.Add(this.btn_save);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.panel1);
			this.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Name = "frm_prod_rewinding_converting";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "frm_prod_rewinding_converting";
			this.panel2.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.Label Remark;
		private System.Windows.Forms.TextBox txtbx_remark;
		private System.Windows.Forms.DateTimePicker dateTimePicker1;
		private System.Windows.Forms.TextBox txtbx_ao;
		private System.Windows.Forms.TextBox txbx_to;
		private System.Windows.Forms.TextBox txtbx_length;
		private System.Windows.Forms.TextBox txtbx_width;
		private System.Windows.Forms.TextBox txtbx_rework;
		private System.Windows.Forms.TextBox txtbx_defective;
		private System.Windows.Forms.Button btn_save;
		private System.Windows.Forms.Button btn_clear;
		private System.Windows.Forms.Button btn_cancel;
		private System.Windows.Forms.Label label19;
		private System.Windows.Forms.ComboBox cbx_operator;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox txtbx_color;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox txtbx_micron;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label lbl_username;
		private System.Windows.Forms.Panel panel2;
	}
}
