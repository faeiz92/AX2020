/*
 * Created by SharpDevelop.
 * User: ax2020-2
 * Date: 2/21/2017
 * Time: 9:06 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace AX2020
{
	partial class frm_prod_warehouse_jr_receive_barcode
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
			this.panel1 = new System.Windows.Forms.Panel();
			this.lbl_header = new System.Windows.Forms.Label();
			this.panel2 = new System.Windows.Forms.Panel();
			this.lbl_username = new System.Windows.Forms.Label();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.btn_confirmed = new System.Windows.Forms.Button();
			this.label9 = new System.Windows.Forms.Label();
			this.txtbx_shipmark = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.txtbx_barcode = new System.Windows.Forms.TextBox();
			this.Status = new System.Windows.Forms.GroupBox();
			this.txtbx_lotno = new System.Windows.Forms.TextBox();
			this.label10 = new System.Windows.Forms.Label();
			this.txtbx_customer = new System.Windows.Forms.TextBox();
			this.txtbx_length = new System.Windows.Forms.TextBox();
			this.txtbx_width = new System.Windows.Forms.TextBox();
			this.txtbx_color = new System.Windows.Forms.TextBox();
			this.txtbx_micron = new System.Windows.Forms.TextBox();
			this.txtbx_code = new System.Windows.Forms.TextBox();
			this.txtbx_shipmark2 = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.dataGridViewWarehouse = new System.Windows.Forms.DataGridView();
			this.btn_clear = new System.Windows.Forms.Button();
			this.btn_cancel = new System.Windows.Forms.Button();
			this.btn_save = new System.Windows.Forms.Button();
			this.dataGridViewReceive = new System.Windows.Forms.DataGridView();
			this.label11 = new System.Windows.Forms.Label();
			this.label12 = new System.Windows.Forms.Label();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.Status.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewWarehouse)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewReceive)).BeginInit();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.Color.DarkCyan;
			this.panel1.Controls.Add(this.lbl_header);
			this.panel1.Location = new System.Drawing.Point(-1, 0);
			this.panel1.Margin = new System.Windows.Forms.Padding(1);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(980, 38);
			this.panel1.TabIndex = 114;
			// 
			// lbl_header
			// 
			this.lbl_header.BackColor = System.Drawing.Color.DarkCyan;
			this.lbl_header.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbl_header.ForeColor = System.Drawing.SystemColors.ControlLightLight;
			this.lbl_header.Location = new System.Drawing.Point(1, 9);
			this.lbl_header.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
			this.lbl_header.Name = "lbl_header";
			this.lbl_header.Size = new System.Drawing.Size(980, 17);
			this.lbl_header.TabIndex = 0;
			this.lbl_header.Text = "JR RECEIVE 1813 / WIP ";
			this.lbl_header.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// panel2
			// 
			this.panel2.BackColor = System.Drawing.Color.Gainsboro;
			this.panel2.Controls.Add(this.lbl_username);
			this.panel2.Location = new System.Drawing.Point(-1, 36);
			this.panel2.Margin = new System.Windows.Forms.Padding(1);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(980, 17);
			this.panel2.TabIndex = 115;
			// 
			// lbl_username
			// 
			this.lbl_username.BackColor = System.Drawing.Color.Gainsboro;
			this.lbl_username.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbl_username.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.lbl_username.Location = new System.Drawing.Point(765, 0);
			this.lbl_username.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
			this.lbl_username.Name = "lbl_username";
			this.lbl_username.Size = new System.Drawing.Size(205, 17);
			this.lbl_username.TabIndex = 0;
			this.lbl_username.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.btn_confirmed);
			this.groupBox1.Controls.Add(this.label9);
			this.groupBox1.Controls.Add(this.txtbx_shipmark);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.txtbx_barcode);
			this.groupBox1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.groupBox1.Location = new System.Drawing.Point(13, 63);
			this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
			this.groupBox1.Size = new System.Drawing.Size(880, 58);
			this.groupBox1.TabIndex = 121;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Operation";
			// 
			// btn_confirmed
			// 
			this.btn_confirmed.Location = new System.Drawing.Point(727, 12);
			this.btn_confirmed.Margin = new System.Windows.Forms.Padding(2);
			this.btn_confirmed.Name = "btn_confirmed";
			this.btn_confirmed.Size = new System.Drawing.Size(114, 26);
			this.btn_confirmed.TabIndex = 124;
			this.btn_confirmed.Text = "Confirmed";
			this.btn_confirmed.UseVisualStyleBackColor = true;
			this.btn_confirmed.Click += new System.EventHandler(this.Btn_confirmedClick);
			// 
			// label9
			// 
			this.label9.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label9.Location = new System.Drawing.Point(341, 17);
			this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(151, 24);
			this.label9.TabIndex = 123;
			this.label9.Text = "Shipping Mark";
			// 
			// txtbx_shipmark
			// 
			this.txtbx_shipmark.Location = new System.Drawing.Point(535, 14);
			this.txtbx_shipmark.Margin = new System.Windows.Forms.Padding(2);
			this.txtbx_shipmark.Name = "txtbx_shipmark";
			this.txtbx_shipmark.Size = new System.Drawing.Size(132, 26);
			this.txtbx_shipmark.TabIndex = 122;
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(9, 18);
			this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(151, 24);
			this.label1.TabIndex = 121;
			this.label1.Text = "Barcode Number";
			// 
			// txtbx_barcode
			// 
			this.txtbx_barcode.Location = new System.Drawing.Point(172, 16);
			this.txtbx_barcode.Margin = new System.Windows.Forms.Padding(2);
			this.txtbx_barcode.Name = "txtbx_barcode";
			this.txtbx_barcode.Size = new System.Drawing.Size(132, 26);
			this.txtbx_barcode.TabIndex = 119;
			// 
			// Status
			// 
			this.Status.Controls.Add(this.txtbx_lotno);
			this.Status.Controls.Add(this.label10);
			this.Status.Controls.Add(this.txtbx_customer);
			this.Status.Controls.Add(this.txtbx_length);
			this.Status.Controls.Add(this.txtbx_width);
			this.Status.Controls.Add(this.txtbx_color);
			this.Status.Controls.Add(this.txtbx_micron);
			this.Status.Controls.Add(this.txtbx_code);
			this.Status.Controls.Add(this.txtbx_shipmark2);
			this.Status.Controls.Add(this.label8);
			this.Status.Controls.Add(this.label7);
			this.Status.Controls.Add(this.label6);
			this.Status.Controls.Add(this.label5);
			this.Status.Controls.Add(this.label4);
			this.Status.Controls.Add(this.label3);
			this.Status.Controls.Add(this.label2);
			this.Status.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Status.Location = new System.Drawing.Point(13, 167);
			this.Status.Margin = new System.Windows.Forms.Padding(2);
			this.Status.Name = "Status";
			this.Status.Padding = new System.Windows.Forms.Padding(2);
			this.Status.Size = new System.Drawing.Size(880, 134);
			this.Status.TabIndex = 122;
			this.Status.TabStop = false;
			this.Status.Text = "Status";
			// 
			// txtbx_lotno
			// 
			this.txtbx_lotno.Location = new System.Drawing.Point(622, 80);
			this.txtbx_lotno.Margin = new System.Windows.Forms.Padding(2);
			this.txtbx_lotno.Name = "txtbx_lotno";
			this.txtbx_lotno.Size = new System.Drawing.Size(190, 26);
			this.txtbx_lotno.TabIndex = 137;
			// 
			// label10
			// 
			this.label10.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label10.Location = new System.Drawing.Point(559, 80);
			this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(71, 17);
			this.label10.TabIndex = 136;
			this.label10.Text = "Lot No";
			// 
			// txtbx_customer
			// 
			this.txtbx_customer.Location = new System.Drawing.Point(363, 17);
			this.txtbx_customer.Margin = new System.Windows.Forms.Padding(2);
			this.txtbx_customer.Name = "txtbx_customer";
			this.txtbx_customer.Size = new System.Drawing.Size(270, 26);
			this.txtbx_customer.TabIndex = 135;
			// 
			// txtbx_length
			// 
			this.txtbx_length.Location = new System.Drawing.Point(362, 82);
			this.txtbx_length.Margin = new System.Windows.Forms.Padding(2);
			this.txtbx_length.Name = "txtbx_length";
			this.txtbx_length.Size = new System.Drawing.Size(190, 26);
			this.txtbx_length.TabIndex = 134;
			// 
			// txtbx_width
			// 
			this.txtbx_width.Location = new System.Drawing.Point(80, 84);
			this.txtbx_width.Margin = new System.Windows.Forms.Padding(2);
			this.txtbx_width.Name = "txtbx_width";
			this.txtbx_width.Size = new System.Drawing.Size(190, 26);
			this.txtbx_width.TabIndex = 133;
			// 
			// txtbx_color
			// 
			this.txtbx_color.Location = new System.Drawing.Point(621, 48);
			this.txtbx_color.Margin = new System.Windows.Forms.Padding(2);
			this.txtbx_color.Name = "txtbx_color";
			this.txtbx_color.Size = new System.Drawing.Size(190, 26);
			this.txtbx_color.TabIndex = 132;
			// 
			// txtbx_micron
			// 
			this.txtbx_micron.Location = new System.Drawing.Point(362, 50);
			this.txtbx_micron.Margin = new System.Windows.Forms.Padding(2);
			this.txtbx_micron.Name = "txtbx_micron";
			this.txtbx_micron.Size = new System.Drawing.Size(190, 26);
			this.txtbx_micron.TabIndex = 131;
			// 
			// txtbx_code
			// 
			this.txtbx_code.Location = new System.Drawing.Point(79, 49);
			this.txtbx_code.Margin = new System.Windows.Forms.Padding(2);
			this.txtbx_code.Name = "txtbx_code";
			this.txtbx_code.Size = new System.Drawing.Size(190, 26);
			this.txtbx_code.TabIndex = 130;
			// 
			// txtbx_shipmark2
			// 
			this.txtbx_shipmark2.Location = new System.Drawing.Point(79, 15);
			this.txtbx_shipmark2.Margin = new System.Windows.Forms.Padding(2);
			this.txtbx_shipmark2.Name = "txtbx_shipmark2";
			this.txtbx_shipmark2.Size = new System.Drawing.Size(190, 26);
			this.txtbx_shipmark2.TabIndex = 129;
			// 
			// label8
			// 
			this.label8.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label8.Location = new System.Drawing.Point(299, 85);
			this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(71, 17);
			this.label8.TabIndex = 128;
			this.label8.Text = "Length";
			// 
			// label7
			// 
			this.label7.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label7.Location = new System.Drawing.Point(24, 87);
			this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(71, 17);
			this.label7.TabIndex = 127;
			this.label7.Text = "Width";
			// 
			// label6
			// 
			this.label6.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label6.Location = new System.Drawing.Point(565, 51);
			this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(71, 17);
			this.label6.TabIndex = 126;
			this.label6.Text = "Color";
			// 
			// label5
			// 
			this.label5.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label5.Location = new System.Drawing.Point(300, 57);
			this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(71, 17);
			this.label5.TabIndex = 125;
			this.label5.Text = "Micron";
			// 
			// label4
			// 
			this.label4.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label4.Location = new System.Drawing.Point(25, 58);
			this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(71, 17);
			this.label4.TabIndex = 124;
			this.label4.Text = "Code";
			// 
			// label3
			// 
			this.label3.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.Location = new System.Drawing.Point(277, 22);
			this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(89, 21);
			this.label3.TabIndex = 123;
			this.label3.Text = "Customer";
			// 
			// label2
			// 
			this.label2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.Location = new System.Drawing.Point(15, 24);
			this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(71, 17);
			this.label2.TabIndex = 122;
			this.label2.Text = "S.Mark";
			// 
			// dataGridViewWarehouse
			// 
			this.dataGridViewWarehouse.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridViewWarehouse.Location = new System.Drawing.Point(13, 688);
			this.dataGridViewWarehouse.Name = "dataGridViewWarehouse";
			this.dataGridViewWarehouse.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dataGridViewWarehouse.Size = new System.Drawing.Size(880, 300);
			this.dataGridViewWarehouse.TabIndex = 123;
			this.dataGridViewWarehouse.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridViewWarehouseCellClick);
			// 
			// btn_clear
			// 
			this.btn_clear.Location = new System.Drawing.Point(396, 1007);
			this.btn_clear.Name = "btn_clear";
			this.btn_clear.Size = new System.Drawing.Size(75, 23);
			this.btn_clear.TabIndex = 124;
			this.btn_clear.Text = "Clear";
			this.btn_clear.UseVisualStyleBackColor = true;
			this.btn_clear.Click += new System.EventHandler(this.Btn_clearClick);
			// 
			// btn_cancel
			// 
			this.btn_cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btn_cancel.Location = new System.Drawing.Point(500, 1007);
			this.btn_cancel.Name = "btn_cancel";
			this.btn_cancel.Size = new System.Drawing.Size(75, 23);
			this.btn_cancel.TabIndex = 125;
			this.btn_cancel.Text = "Cancel";
			this.btn_cancel.UseVisualStyleBackColor = true;
			this.btn_cancel.Click += new System.EventHandler(this.Btn_cancelClick);
			// 
			// btn_save
			// 
			this.btn_save.Location = new System.Drawing.Point(294, 1007);
			this.btn_save.Name = "btn_save";
			this.btn_save.Size = new System.Drawing.Size(75, 23);
			this.btn_save.TabIndex = 126;
			this.btn_save.Text = "Save";
			this.btn_save.UseVisualStyleBackColor = true;
			this.btn_save.Click += new System.EventHandler(this.Btn_saveClick);
			// 
			// dataGridViewReceive
			// 
			this.dataGridViewReceive.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridViewReceive.Location = new System.Drawing.Point(13, 345);
			this.dataGridViewReceive.Name = "dataGridViewReceive";
			this.dataGridViewReceive.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dataGridViewReceive.Size = new System.Drawing.Size(880, 300);
			this.dataGridViewReceive.TabIndex = 127;
			this.dataGridViewReceive.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridViewReceiveCellClick);
			// 
			// label11
			// 
			this.label11.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label11.Location = new System.Drawing.Point(321, 662);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(304, 23);
			this.label11.TabIndex = 128;
			this.label11.Text = "LISTING JR NOT YET RECEIVE 1813";
			// 
			// label12
			// 
			this.label12.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label12.Location = new System.Drawing.Point(321, 309);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(304, 23);
			this.label12.TabIndex = 129;
			this.label12.Text = "LISTING JR RECEIVE 1813";
			// 
			// frm_prod_warehouse_jr_receive_barcode
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.AutoScroll = true;
			this.CancelButton = this.btn_cancel;
			this.ClientSize = new System.Drawing.Size(984, 662);
			this.Controls.Add(this.label12);
			this.Controls.Add(this.label11);
			this.Controls.Add(this.dataGridViewReceive);
			this.Controls.Add(this.btn_save);
			this.Controls.Add(this.btn_cancel);
			this.Controls.Add(this.btn_clear);
			this.Controls.Add(this.dataGridViewWarehouse);
			this.Controls.Add(this.Status);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.panel2);
			this.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Margin = new System.Windows.Forms.Padding(4);
			this.Name = "frm_prod_warehouse_jr_receive_barcode";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "frm_coating_receive_stock_warehouse";
			this.panel1.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.Status.ResumeLayout(false);
			this.Status.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewWarehouse)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewReceive)).EndInit();
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.DataGridView dataGridViewReceive;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.TextBox txtbx_lotno;
		private System.Windows.Forms.Button btn_save;
		private System.Windows.Forms.Button btn_cancel;
		private System.Windows.Forms.Button btn_clear;
		private System.Windows.Forms.DataGridView dataGridViewWarehouse;
		private System.Windows.Forms.TextBox txtbx_shipmark;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.TextBox txtbx_customer;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.TextBox txtbx_shipmark2;
		private System.Windows.Forms.TextBox txtbx_code;
		private System.Windows.Forms.TextBox txtbx_micron;
		private System.Windows.Forms.TextBox txtbx_color;
		private System.Windows.Forms.TextBox txtbx_width;
		private System.Windows.Forms.TextBox txtbx_length;
		private System.Windows.Forms.GroupBox Status;
		private System.Windows.Forms.TextBox txtbx_barcode;
		private System.Windows.Forms.Button btn_confirmed;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label lbl_username;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Label lbl_header;
		private System.Windows.Forms.Panel panel1;
		
		
		
	}
}
