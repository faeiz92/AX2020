/*
 * Created by SharpDevelop.
 * User: it-4
 * Date: 17/11/2016
 * Time: 1:02 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace AX2020
{
	partial class frm_prod_converting_output_papercore
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
			this.txtbox_brand = new System.Windows.Forms.TextBox();
			this.lbl_brand = new System.Windows.Forms.Label();
			this.lbl_operator = new System.Windows.Forms.Label();
			this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
			this.lbl_prod_date = new System.Windows.Forms.Label();
			this.lbl_size_2 = new System.Windows.Forms.Label();
			this.lbl_size_1 = new System.Windows.Forms.Label();
			this.grpbox_remarks = new System.Windows.Forms.GroupBox();
			this.lbl_color = new System.Windows.Forms.Label();
			this.lbl_size = new System.Windows.Forms.Label();
			this.cbx_int_dia = new System.Windows.Forms.ComboBox();
			this.cbx_length = new System.Windows.Forms.ComboBox();
			this.cbx_width = new System.Windows.Forms.ComboBox();
			this.txtbox_output = new System.Windows.Forms.TextBox();
			this.cbox_color = new System.Windows.Forms.ComboBox();
			this.lbl_output = new System.Windows.Forms.Label();
			this.btn_cancel = new System.Windows.Forms.Button();
			this.btn_clear = new System.Windows.Forms.Button();
			this.btn_save = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.lbl_username = new System.Windows.Forms.Label();
			this.panel2 = new System.Windows.Forms.Panel();
			this.cbx_operator1 = new System.Windows.Forms.ComboBox();
			this.cbx_operator2 = new System.Windows.Forms.ComboBox();
			this.cbx_operator3 = new System.Windows.Forms.ComboBox();
			this.grpbox_remarks.SuspendLayout();
			this.panel2.SuspendLayout();
			this.SuspendLayout();
			// 
			// lbl_header
			// 
			this.lbl_header.BackColor = System.Drawing.Color.DarkCyan;
			this.lbl_header.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbl_header.ForeColor = System.Drawing.SystemColors.ControlLightLight;
			this.lbl_header.Location = new System.Drawing.Point(2, 15);
			this.lbl_header.Name = "lbl_header";
			this.lbl_header.Size = new System.Drawing.Size(979, 23);
			this.lbl_header.TabIndex = 89;
			this.lbl_header.Text = "CONVERTING OUTPUT PAPERCORE";
			this.lbl_header.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.Color.DarkCyan;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(1000, 52);
			this.panel1.TabIndex = 102;
			// 
			// txtbox_brand
			// 
			this.txtbox_brand.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtbox_brand.Location = new System.Drawing.Point(664, 140);
			this.txtbox_brand.Name = "txtbox_brand";
			this.txtbox_brand.Size = new System.Drawing.Size(288, 26);
			this.txtbox_brand.TabIndex = 106;
			// 
			// lbl_brand
			// 
			this.lbl_brand.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbl_brand.Location = new System.Drawing.Point(527, 140);
			this.lbl_brand.Name = "lbl_brand";
			this.lbl_brand.Size = new System.Drawing.Size(116, 26);
			this.lbl_brand.TabIndex = 109;
			this.lbl_brand.Text = "Brand";
			this.lbl_brand.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lbl_operator
			// 
			this.lbl_operator.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbl_operator.Location = new System.Drawing.Point(22, 109);
			this.lbl_operator.Name = "lbl_operator";
			this.lbl_operator.Size = new System.Drawing.Size(116, 26);
			this.lbl_operator.TabIndex = 108;
			this.lbl_operator.Text = "Operator 1";
			this.lbl_operator.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// dateTimePicker1
			// 
			this.dateTimePicker1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.dateTimePicker1.Location = new System.Drawing.Point(664, 106);
			this.dateTimePicker1.Name = "dateTimePicker1";
			this.dateTimePicker1.Size = new System.Drawing.Size(288, 26);
			this.dateTimePicker1.TabIndex = 103;
			// 
			// lbl_prod_date
			// 
			this.lbl_prod_date.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbl_prod_date.Location = new System.Drawing.Point(527, 106);
			this.lbl_prod_date.Name = "lbl_prod_date";
			this.lbl_prod_date.Size = new System.Drawing.Size(135, 26);
			this.lbl_prod_date.TabIndex = 104;
			this.lbl_prod_date.Text = "Production Date";
			this.lbl_prod_date.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lbl_size_2
			// 
			this.lbl_size_2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbl_size_2.Location = new System.Drawing.Point(344, 28);
			this.lbl_size_2.Name = "lbl_size_2";
			this.lbl_size_2.Size = new System.Drawing.Size(22, 25);
			this.lbl_size_2.TabIndex = 116;
			this.lbl_size_2.Text = "x";
			this.lbl_size_2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lbl_size_1
			// 
			this.lbl_size_1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbl_size_1.Location = new System.Drawing.Point(214, 27);
			this.lbl_size_1.Name = "lbl_size_1";
			this.lbl_size_1.Size = new System.Drawing.Size(22, 25);
			this.lbl_size_1.TabIndex = 117;
			this.lbl_size_1.Text = "x";
			this.lbl_size_1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// grpbox_remarks
			// 
			this.grpbox_remarks.Controls.Add(this.lbl_color);
			this.grpbox_remarks.Controls.Add(this.lbl_size);
			this.grpbox_remarks.Controls.Add(this.cbx_int_dia);
			this.grpbox_remarks.Controls.Add(this.cbx_length);
			this.grpbox_remarks.Controls.Add(this.cbx_width);
			this.grpbox_remarks.Controls.Add(this.txtbox_output);
			this.grpbox_remarks.Controls.Add(this.cbox_color);
			this.grpbox_remarks.Controls.Add(this.lbl_size_2);
			this.grpbox_remarks.Controls.Add(this.lbl_output);
			this.grpbox_remarks.Controls.Add(this.lbl_size_1);
			this.grpbox_remarks.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.grpbox_remarks.Location = new System.Drawing.Point(9, 221);
			this.grpbox_remarks.Name = "grpbox_remarks";
			this.grpbox_remarks.Size = new System.Drawing.Size(963, 134);
			this.grpbox_remarks.TabIndex = 97;
			this.grpbox_remarks.TabStop = false;
			this.grpbox_remarks.Text = "Paper Core";
			// 
			// lbl_color
			// 
			this.lbl_color.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbl_color.Location = new System.Drawing.Point(11, 59);
			this.lbl_color.Name = "lbl_color";
			this.lbl_color.Size = new System.Drawing.Size(87, 26);
			this.lbl_color.TabIndex = 124;
			this.lbl_color.Text = "Color";
			this.lbl_color.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lbl_size
			// 
			this.lbl_size.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbl_size.Location = new System.Drawing.Point(12, 26);
			this.lbl_size.Name = "lbl_size";
			this.lbl_size.Size = new System.Drawing.Size(89, 26);
			this.lbl_size.TabIndex = 123;
			this.lbl_size.Text = "Size";
			this.lbl_size.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// cbx_int_dia
			// 
			this.cbx_int_dia.FormattingEnabled = true;
			this.cbx_int_dia.Location = new System.Drawing.Point(365, 26);
			this.cbx_int_dia.Name = "cbx_int_dia";
			this.cbx_int_dia.Size = new System.Drawing.Size(104, 27);
			this.cbx_int_dia.TabIndex = 122;
			// 
			// cbx_length
			// 
			this.cbx_length.FormattingEnabled = true;
			this.cbx_length.Location = new System.Drawing.Point(235, 26);
			this.cbx_length.Name = "cbx_length";
			this.cbx_length.Size = new System.Drawing.Size(104, 27);
			this.cbx_length.TabIndex = 121;
			// 
			// cbx_width
			// 
			this.cbx_width.FormattingEnabled = true;
			this.cbx_width.Location = new System.Drawing.Point(104, 25);
			this.cbx_width.Name = "cbx_width";
			this.cbx_width.Size = new System.Drawing.Size(104, 27);
			this.cbx_width.TabIndex = 120;
			// 
			// txtbox_output
			// 
			this.txtbox_output.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtbox_output.Location = new System.Drawing.Point(104, 91);
			this.txtbox_output.Name = "txtbox_output";
			this.txtbox_output.Size = new System.Drawing.Size(365, 26);
			this.txtbox_output.TabIndex = 112;
			// 
			// cbox_color
			// 
			this.cbox_color.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.cbox_color.FormattingEnabled = true;
			this.cbox_color.Location = new System.Drawing.Point(104, 59);
			this.cbox_color.Name = "cbox_color";
			this.cbox_color.Size = new System.Drawing.Size(365, 26);
			this.cbox_color.TabIndex = 119;
			// 
			// lbl_output
			// 
			this.lbl_output.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbl_output.Location = new System.Drawing.Point(11, 91);
			this.lbl_output.Name = "lbl_output";
			this.lbl_output.Size = new System.Drawing.Size(131, 26);
			this.lbl_output.TabIndex = 118;
			this.lbl_output.Text = "Output";
			this.lbl_output.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// btn_cancel
			// 
			this.btn_cancel.BackColor = System.Drawing.Color.Silver;
			this.btn_cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btn_cancel.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_cancel.Location = new System.Drawing.Point(532, 611);
			this.btn_cancel.Name = "btn_cancel";
			this.btn_cancel.Size = new System.Drawing.Size(120, 27);
			this.btn_cancel.TabIndex = 114;
			this.btn_cancel.Text = "Cancel";
			this.btn_cancel.UseVisualStyleBackColor = false;
			// 
			// btn_clear
			// 
			this.btn_clear.BackColor = System.Drawing.Color.Silver;
			this.btn_clear.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_clear.Location = new System.Drawing.Point(406, 610);
			this.btn_clear.Name = "btn_clear";
			this.btn_clear.Size = new System.Drawing.Size(120, 27);
			this.btn_clear.TabIndex = 113;
			this.btn_clear.Text = "Clear";
			this.btn_clear.UseVisualStyleBackColor = false;
			// 
			// btn_save
			// 
			this.btn_save.BackColor = System.Drawing.Color.Silver;
			this.btn_save.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_save.Location = new System.Drawing.Point(280, 610);
			this.btn_save.Name = "btn_save";
			this.btn_save.Size = new System.Drawing.Size(120, 27);
			this.btn_save.TabIndex = 112;
			this.btn_save.Text = "Save";
			this.btn_save.UseVisualStyleBackColor = false;
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(22, 141);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(116, 26);
			this.label1.TabIndex = 116;
			this.label1.Text = "Operator 2";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label2
			// 
			this.label2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.Location = new System.Drawing.Point(22, 173);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(116, 26);
			this.label2.TabIndex = 118;
			this.label2.Text = "Operator 3";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
			// panel2
			// 
			this.panel2.BackColor = System.Drawing.Color.Gainsboro;
			this.panel2.Controls.Add(this.lbl_username);
			this.panel2.Location = new System.Drawing.Point(0, 50);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(1000, 23);
			this.panel2.TabIndex = 138;
			// 
			// cbx_operator1
			// 
			this.cbx_operator1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.cbx_operator1.FormattingEnabled = true;
			this.cbx_operator1.Location = new System.Drawing.Point(113, 106);
			this.cbx_operator1.Name = "cbx_operator1";
			this.cbx_operator1.Size = new System.Drawing.Size(365, 26);
			this.cbx_operator1.TabIndex = 139;
			// 
			// cbx_operator2
			// 
			this.cbx_operator2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.cbx_operator2.FormattingEnabled = true;
			this.cbx_operator2.Location = new System.Drawing.Point(113, 139);
			this.cbx_operator2.Name = "cbx_operator2";
			this.cbx_operator2.Size = new System.Drawing.Size(365, 26);
			this.cbx_operator2.TabIndex = 140;
			// 
			// cbx_operator3
			// 
			this.cbx_operator3.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.cbx_operator3.FormattingEnabled = true;
			this.cbx_operator3.Location = new System.Drawing.Point(113, 174);
			this.cbx_operator3.Name = "cbx_operator3";
			this.cbx_operator3.Size = new System.Drawing.Size(365, 26);
			this.cbx_operator3.TabIndex = 141;
			// 
			// frm_prod_converting_output_papercore
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.AutoScroll = true;
			this.CancelButton = this.btn_cancel;
			this.ClientSize = new System.Drawing.Size(984, 662);
			this.Controls.Add(this.cbx_operator3);
			this.Controls.Add(this.cbx_operator2);
			this.Controls.Add(this.cbx_operator1);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.btn_cancel);
			this.Controls.Add(this.btn_clear);
			this.Controls.Add(this.btn_save);
			this.Controls.Add(this.txtbox_brand);
			this.Controls.Add(this.lbl_brand);
			this.Controls.Add(this.lbl_operator);
			this.Controls.Add(this.dateTimePicker1);
			this.Controls.Add(this.lbl_prod_date);
			this.Controls.Add(this.lbl_header);
			this.Controls.Add(this.grpbox_remarks);
			this.Controls.Add(this.panel1);
			this.Name = "frm_prod_converting_output_papercore";
			this.Text = "Converting Output Paper Core";
			this.grpbox_remarks.ResumeLayout(false);
			this.grpbox_remarks.PerformLayout();
			this.panel2.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.ComboBox cbx_operator3;
		private System.Windows.Forms.ComboBox cbx_operator2;
		private System.Windows.Forms.ComboBox cbx_operator1;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Label lbl_username;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox cbx_width;
		private System.Windows.Forms.ComboBox cbx_length;
		private System.Windows.Forms.ComboBox cbx_int_dia;
		private System.Windows.Forms.Button btn_save;
		private System.Windows.Forms.Button btn_clear;
		private System.Windows.Forms.Button btn_cancel;
		private System.Windows.Forms.ComboBox cbox_color;
		private System.Windows.Forms.TextBox txtbox_output;
		private System.Windows.Forms.Label lbl_size_1;
		private System.Windows.Forms.Label lbl_size_2;
		private System.Windows.Forms.Label lbl_color;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label lbl_prod_date;
		private System.Windows.Forms.DateTimePicker dateTimePicker1;
		private System.Windows.Forms.Label lbl_operator;
		private System.Windows.Forms.Label lbl_brand;
		private System.Windows.Forms.TextBox txtbox_brand;
		private System.Windows.Forms.Label lbl_size;
		private System.Windows.Forms.GroupBox grpbox_remarks;
		private System.Windows.Forms.Label lbl_header;
		private System.Windows.Forms.Label lbl_output;
	}
}
