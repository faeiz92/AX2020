/*
 * Created by SharpDevelop.
 * User: it-4
 * Date: 17/11/2016
 * Time: 4:52 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace AX2020
{
	partial class frm_prod_converting_grn_film
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
			this.btn_cancel = new System.Windows.Forms.Button();
			this.panel1 = new System.Windows.Forms.Panel();
			this.lbl_width = new System.Windows.Forms.Label();
			this.txtbx_qty = new System.Windows.Forms.TextBox();
			this.lbl_qty = new System.Windows.Forms.Label();
			this.txtbx_width = new System.Windows.Forms.TextBox();
			this.lbl_po = new System.Windows.Forms.Label();
			this.txtbx_mic = new System.Windows.Forms.TextBox();
			this.lbl_mic = new System.Windows.Forms.Label();
			this.lbl_country = new System.Windows.Forms.Label();
			this.txtbx_stock_code = new System.Windows.Forms.TextBox();
			this.lbl_stock_code = new System.Windows.Forms.Label();
			this.txtbx_po = new System.Windows.Forms.TextBox();
			this.lbl_length = new System.Windows.Forms.Label();
			this.txtbx_status = new System.Windows.Forms.TextBox();
			this.lbl_status = new System.Windows.Forms.Label();
			this.txtbx_length = new System.Windows.Forms.TextBox();
			this.txtbx_type = new System.Windows.Forms.TextBox();
			this.lbl_type = new System.Windows.Forms.Label();
			this.txtbx_ref_no = new System.Windows.Forms.TextBox();
			this.lbl_ref_no = new System.Windows.Forms.Label();
			this.btn_del = new System.Windows.Forms.Button();
			this.btn_add = new System.Windows.Forms.Button();
			this.cbx_country = new System.Windows.Forms.ComboBox();
			this.lbl_username = new System.Windows.Forms.Label();
			this.panel2 = new System.Windows.Forms.Panel();
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
			this.lbl_header.Size = new System.Drawing.Size(970, 23);
			this.lbl_header.TabIndex = 1;
			this.lbl_header.Text = "FILM RAW MATERIAL LABEL";
			this.lbl_header.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// btn_cancel
			// 
			this.btn_cancel.BackColor = System.Drawing.Color.Silver;
			this.btn_cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btn_cancel.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_cancel.Location = new System.Drawing.Point(497, 480);
			this.btn_cancel.Name = "btn_cancel";
			this.btn_cancel.Size = new System.Drawing.Size(120, 27);
			this.btn_cancel.TabIndex = 13;
			this.btn_cancel.Text = "Cancel";
			this.btn_cancel.UseVisualStyleBackColor = false;
			this.btn_cancel.Click += new System.EventHandler(this.Btn_cancelClick);
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.Color.DarkCyan;
			this.panel1.Location = new System.Drawing.Point(-1, -1);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(985, 52);
			this.panel1.TabIndex = 102;
			// 
			// lbl_width
			// 
			this.lbl_width.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbl_width.Location = new System.Drawing.Point(17, 197);
			this.lbl_width.Name = "lbl_width";
			this.lbl_width.Size = new System.Drawing.Size(116, 26);
			this.lbl_width.TabIndex = 113;
			this.lbl_width.Text = "Width";
			this.lbl_width.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtbx_qty
			// 
			this.txtbx_qty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtbx_qty.Location = new System.Drawing.Point(617, 197);
			this.txtbx_qty.Name = "txtbx_qty";
			this.txtbx_qty.Size = new System.Drawing.Size(329, 26);
			this.txtbx_qty.TabIndex = 9;
			// 
			// lbl_qty
			// 
			this.lbl_qty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbl_qty.Location = new System.Drawing.Point(508, 197);
			this.lbl_qty.Name = "lbl_qty";
			this.lbl_qty.Size = new System.Drawing.Size(116, 26);
			this.lbl_qty.TabIndex = 114;
			this.lbl_qty.Text = "Quantity";
			// 
			// txtbx_width
			// 
			this.txtbx_width.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtbx_width.Location = new System.Drawing.Point(139, 197);
			this.txtbx_width.Name = "txtbx_width";
			this.txtbx_width.Size = new System.Drawing.Size(329, 26);
			this.txtbx_width.TabIndex = 4;
			// 
			// lbl_po
			// 
			this.lbl_po.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbl_po.Location = new System.Drawing.Point(508, 165);
			this.lbl_po.Name = "lbl_po";
			this.lbl_po.Size = new System.Drawing.Size(77, 26);
			this.lbl_po.TabIndex = 112;
			this.lbl_po.Text = "PO";
			this.lbl_po.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtbx_mic
			// 
			this.txtbx_mic.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtbx_mic.Location = new System.Drawing.Point(139, 165);
			this.txtbx_mic.Name = "txtbx_mic";
			this.txtbx_mic.Size = new System.Drawing.Size(329, 26);
			this.txtbx_mic.TabIndex = 3;
			// 
			// lbl_mic
			// 
			this.lbl_mic.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbl_mic.Location = new System.Drawing.Point(17, 165);
			this.lbl_mic.Name = "lbl_mic";
			this.lbl_mic.Size = new System.Drawing.Size(116, 26);
			this.lbl_mic.TabIndex = 111;
			this.lbl_mic.Text = "Micron";
			this.lbl_mic.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lbl_country
			// 
			this.lbl_country.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbl_country.Location = new System.Drawing.Point(508, 133);
			this.lbl_country.Name = "lbl_country";
			this.lbl_country.Size = new System.Drawing.Size(116, 26);
			this.lbl_country.TabIndex = 109;
			this.lbl_country.Text = "Country";
			this.lbl_country.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtbx_stock_code
			// 
			this.txtbx_stock_code.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtbx_stock_code.Location = new System.Drawing.Point(139, 133);
			this.txtbx_stock_code.Name = "txtbx_stock_code";
			this.txtbx_stock_code.Size = new System.Drawing.Size(329, 26);
			this.txtbx_stock_code.TabIndex = 2;
			// 
			// lbl_stock_code
			// 
			this.lbl_stock_code.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbl_stock_code.Location = new System.Drawing.Point(17, 133);
			this.lbl_stock_code.Name = "lbl_stock_code";
			this.lbl_stock_code.Size = new System.Drawing.Size(116, 26);
			this.lbl_stock_code.TabIndex = 108;
			this.lbl_stock_code.Text = "Stock Code";
			this.lbl_stock_code.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtbx_po
			// 
			this.txtbx_po.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtbx_po.Location = new System.Drawing.Point(617, 166);
			this.txtbx_po.Name = "txtbx_po";
			this.txtbx_po.Size = new System.Drawing.Size(329, 26);
			this.txtbx_po.TabIndex = 8;
			// 
			// lbl_length
			// 
			this.lbl_length.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbl_length.Location = new System.Drawing.Point(17, 229);
			this.lbl_length.Name = "lbl_length";
			this.lbl_length.Size = new System.Drawing.Size(116, 26);
			this.lbl_length.TabIndex = 117;
			this.lbl_length.Text = "Length";
			this.lbl_length.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtbx_status
			// 
			this.txtbx_status.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtbx_status.Location = new System.Drawing.Point(617, 230);
			this.txtbx_status.Name = "txtbx_status";
			this.txtbx_status.Size = new System.Drawing.Size(329, 26);
			this.txtbx_status.TabIndex = 10;
			// 
			// lbl_status
			// 
			this.lbl_status.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbl_status.Location = new System.Drawing.Point(508, 229);
			this.lbl_status.Name = "lbl_status";
			this.lbl_status.Size = new System.Drawing.Size(116, 26);
			this.lbl_status.TabIndex = 118;
			this.lbl_status.Text = "Status";
			// 
			// txtbx_length
			// 
			this.txtbx_length.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtbx_length.Location = new System.Drawing.Point(139, 229);
			this.txtbx_length.Name = "txtbx_length";
			this.txtbx_length.Size = new System.Drawing.Size(329, 26);
			this.txtbx_length.TabIndex = 5;
			// 
			// txtbx_type
			// 
			this.txtbx_type.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtbx_type.Location = new System.Drawing.Point(617, 101);
			this.txtbx_type.Name = "txtbx_type";
			this.txtbx_type.Size = new System.Drawing.Size(329, 26);
			this.txtbx_type.TabIndex = 6;
			// 
			// lbl_type
			// 
			this.lbl_type.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbl_type.Location = new System.Drawing.Point(508, 101);
			this.lbl_type.Name = "lbl_type";
			this.lbl_type.Size = new System.Drawing.Size(116, 26);
			this.lbl_type.TabIndex = 122;
			this.lbl_type.Text = "Type";
			this.lbl_type.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtbx_ref_no
			// 
			this.txtbx_ref_no.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtbx_ref_no.Location = new System.Drawing.Point(139, 101);
			this.txtbx_ref_no.Name = "txtbx_ref_no";
			this.txtbx_ref_no.Size = new System.Drawing.Size(329, 26);
			this.txtbx_ref_no.TabIndex = 1;
			// 
			// lbl_ref_no
			// 
			this.lbl_ref_no.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbl_ref_no.Location = new System.Drawing.Point(17, 101);
			this.lbl_ref_no.Name = "lbl_ref_no";
			this.lbl_ref_no.Size = new System.Drawing.Size(116, 26);
			this.lbl_ref_no.TabIndex = 121;
			this.lbl_ref_no.Text = "Ref No";
			this.lbl_ref_no.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// btn_del
			// 
			this.btn_del.BackColor = System.Drawing.Color.Silver;
			this.btn_del.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_del.Location = new System.Drawing.Point(371, 479);
			this.btn_del.Name = "btn_del";
			this.btn_del.Size = new System.Drawing.Size(120, 27);
			this.btn_del.TabIndex = 12;
			this.btn_del.Text = "Delete";
			this.btn_del.UseVisualStyleBackColor = false;
			this.btn_del.Click += new System.EventHandler(this.Btn_delClick);
			// 
			// btn_add
			// 
			this.btn_add.BackColor = System.Drawing.Color.Silver;
			this.btn_add.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_add.Location = new System.Drawing.Point(245, 479);
			this.btn_add.Name = "btn_add";
			this.btn_add.Size = new System.Drawing.Size(120, 27);
			this.btn_add.TabIndex = 11;
			this.btn_add.Text = "Save && Print";
			this.btn_add.UseVisualStyleBackColor = false;
			this.btn_add.Click += new System.EventHandler(this.Btn_addClick);
			// 
			// cbx_country
			// 
			this.cbx_country.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.cbx_country.FormattingEnabled = true;
			this.cbx_country.Location = new System.Drawing.Point(617, 134);
			this.cbx_country.Name = "cbx_country";
			this.cbx_country.Size = new System.Drawing.Size(329, 26);
			this.cbx_country.TabIndex = 124;
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
			this.panel2.Location = new System.Drawing.Point(-1, 50);
			this.panel2.Margin = new System.Windows.Forms.Padding(1);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(1000, 23);
			this.panel2.TabIndex = 125;
			// 
			// frm_prod_converting_grn_film
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.CancelButton = this.btn_cancel;
			this.ClientSize = new System.Drawing.Size(984, 535);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.cbx_country);
			this.Controls.Add(this.btn_del);
			this.Controls.Add(this.txtbx_type);
			this.Controls.Add(this.lbl_type);
			this.Controls.Add(this.txtbx_ref_no);
			this.Controls.Add(this.lbl_ref_no);
			this.Controls.Add(this.lbl_length);
			this.Controls.Add(this.txtbx_status);
			this.Controls.Add(this.lbl_status);
			this.Controls.Add(this.txtbx_length);
			this.Controls.Add(this.lbl_width);
			this.Controls.Add(this.txtbx_qty);
			this.Controls.Add(this.lbl_qty);
			this.Controls.Add(this.txtbx_width);
			this.Controls.Add(this.lbl_po);
			this.Controls.Add(this.txtbx_mic);
			this.Controls.Add(this.lbl_mic);
			this.Controls.Add(this.lbl_country);
			this.Controls.Add(this.txtbx_stock_code);
			this.Controls.Add(this.lbl_stock_code);
			this.Controls.Add(this.txtbx_po);
			this.Controls.Add(this.lbl_header);
			this.Controls.Add(this.btn_add);
			this.Controls.Add(this.btn_cancel);
			this.Controls.Add(this.panel1);
			this.Name = "frm_prod_converting_grn_film";
			this.Text = "Film Raw Material Label";
			this.panel2.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Label lbl_username;
		private System.Windows.Forms.ComboBox cbx_country;
		private System.Windows.Forms.Button btn_del;
		private System.Windows.Forms.Label lbl_ref_no;
		private System.Windows.Forms.TextBox txtbx_ref_no;
		private System.Windows.Forms.Label lbl_type;
		private System.Windows.Forms.TextBox txtbx_type;
		private System.Windows.Forms.TextBox txtbx_length;
		private System.Windows.Forms.Label lbl_status;
		private System.Windows.Forms.TextBox txtbx_status;
		private System.Windows.Forms.Label lbl_length;
		private System.Windows.Forms.Label lbl_po;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.TextBox txtbx_po;
		private System.Windows.Forms.Label lbl_stock_code;
		private System.Windows.Forms.TextBox txtbx_stock_code;
		private System.Windows.Forms.Label lbl_country;
		private System.Windows.Forms.Label lbl_mic;
		private System.Windows.Forms.TextBox txtbx_mic;
		private System.Windows.Forms.TextBox txtbx_width;
		private System.Windows.Forms.Label lbl_qty;
		private System.Windows.Forms.TextBox txtbx_qty;
		private System.Windows.Forms.Label lbl_width;
		private System.Windows.Forms.Button btn_cancel;
		private System.Windows.Forms.Button btn_add;
		private System.Windows.Forms.Label lbl_header;
		

	}
}
