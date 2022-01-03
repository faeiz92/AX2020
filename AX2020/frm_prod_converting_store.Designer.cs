/*
 * Created by SharpDevelop.
 * User: it-4
 * Date: 12/12/2016
 * Time: 9:45 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace AX2020
{
	partial class frm_prod_converting_store
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
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
			this.txtbx_desc_1 = new System.Windows.Forms.TextBox();
			this.lbl_header = new System.Windows.Forms.Label();
			this.panel1 = new System.Windows.Forms.Panel();
			this.btn_search = new System.Windows.Forms.Button();
			this.txtbx_qty_order = new System.Windows.Forms.TextBox();
			this.lbl_qty = new System.Windows.Forms.Label();
			this.txtbx_stock_code = new System.Windows.Forms.TextBox();
			this.lbl_stock_code = new System.Windows.Forms.Label();
			this.grpbox_order = new System.Windows.Forms.GroupBox();
			this.lbl_m = new System.Windows.Forms.Label();
			this.lbl_mm = new System.Windows.Forms.Label();
			this.lbl_brand = new System.Windows.Forms.Label();
			this.txtbx_length = new System.Windows.Forms.TextBox();
			this.txtbx_conversion = new System.Windows.Forms.TextBox();
			this.lbl_stock_spec = new System.Windows.Forms.Label();
			this.txtbx_brand = new System.Windows.Forms.TextBox();
			this.txtbx_mic = new System.Windows.Forms.TextBox();
			this.lbl_conversion = new System.Windows.Forms.Label();
			this.txtbx_color = new System.Windows.Forms.TextBox();
			this.lbl_color = new System.Windows.Forms.Label();
			this.txtbx_width = new System.Windows.Forms.TextBox();
			this.lbl_mic = new System.Windows.Forms.Label();
			this.txtbx_desc_2 = new System.Windows.Forms.TextBox();
			this.lbl_desc_2 = new System.Windows.Forms.Label();
			this.txtbx_ref_no = new System.Windows.Forms.TextBox();
			this.lbl_ref_no = new System.Windows.Forms.Label();
			this.lbl_desc_1 = new System.Windows.Forms.Label();
			this.lbl_roll = new System.Windows.Forms.Label();
			this.btn_cancel = new System.Windows.Forms.Button();
			this.btn_clear = new System.Windows.Forms.Button();
			this.btn_save = new System.Windows.Forms.Button();
			this.panel2 = new System.Windows.Forms.Panel();
			this.lbl_username = new System.Windows.Forms.Label();
			this.txtbx_uom_2 = new System.Windows.Forms.TextBox();
			this.txtbx_uom_1 = new System.Windows.Forms.TextBox();
			this.lbl_uom = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.groupBx_record = new System.Windows.Forms.GroupBox();
			this.dt_grid = new System.Windows.Forms.DataGridView();
			this.btn_del = new System.Windows.Forms.Button();
			this.label3 = new System.Windows.Forms.Label();
			this.btn_post = new System.Windows.Forms.Button();
			this.btn_email = new System.Windows.Forms.Button();
			this.panel1.SuspendLayout();
			this.grpbox_order.SuspendLayout();
			this.panel2.SuspendLayout();
			this.groupBx_record.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dt_grid)).BeginInit();
			this.SuspendLayout();
			// 
			// txtbx_desc_1
			// 
			this.txtbx_desc_1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtbx_desc_1.Location = new System.Drawing.Point(143, 27);
			this.txtbx_desc_1.Name = "txtbx_desc_1";
			this.txtbx_desc_1.ReadOnly = true;
			this.txtbx_desc_1.Size = new System.Drawing.Size(795, 26);
			this.txtbx_desc_1.TabIndex = 99;
			// 
			// lbl_header
			// 
			this.lbl_header.BackColor = System.Drawing.Color.DarkCyan;
			this.lbl_header.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbl_header.ForeColor = System.Drawing.SystemColors.ControlLightLight;
			this.lbl_header.Location = new System.Drawing.Point(3, 14);
			this.lbl_header.Name = "lbl_header";
			this.lbl_header.Size = new System.Drawing.Size(965, 23);
			this.lbl_header.TabIndex = 0;
			this.lbl_header.Text = "CONVERTING STORE ORDER";
			this.lbl_header.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.Color.DarkCyan;
			this.panel1.Controls.Add(this.lbl_header);
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(1000, 52);
			this.panel1.TabIndex = 101;
			// 
			// btn_search
			// 
			this.btn_search.BackColor = System.Drawing.Color.Silver;
			this.btn_search.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_search.Location = new System.Drawing.Point(295, 92);
			this.btn_search.Name = "btn_search";
			this.btn_search.Size = new System.Drawing.Size(99, 27);
			this.btn_search.TabIndex = 2;
			this.btn_search.Text = "Search";
			this.btn_search.UseVisualStyleBackColor = false;
			this.btn_search.Click += new System.EventHandler(this.Btn_searchClick);
			// 
			// txtbx_qty_order
			// 
			this.txtbx_qty_order.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtbx_qty_order.Location = new System.Drawing.Point(157, 352);
			this.txtbx_qty_order.MaxLength = 50;
			this.txtbx_qty_order.Name = "txtbx_qty_order";
			this.txtbx_qty_order.Size = new System.Drawing.Size(281, 26);
			this.txtbx_qty_order.TabIndex = 3;
			// 
			// lbl_qty
			// 
			this.lbl_qty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbl_qty.Location = new System.Drawing.Point(23, 351);
			this.lbl_qty.Name = "lbl_qty";
			this.lbl_qty.Size = new System.Drawing.Size(116, 26);
			this.lbl_qty.TabIndex = 115;
			this.lbl_qty.Text = "Quantity Order";
			this.lbl_qty.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtbx_stock_code
			// 
			this.txtbx_stock_code.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtbx_stock_code.Location = new System.Drawing.Point(122, 93);
			this.txtbx_stock_code.Name = "txtbx_stock_code";
			this.txtbx_stock_code.Size = new System.Drawing.Size(167, 26);
			this.txtbx_stock_code.TabIndex = 1;
			// 
			// lbl_stock_code
			// 
			this.lbl_stock_code.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbl_stock_code.Location = new System.Drawing.Point(23, 93);
			this.lbl_stock_code.Name = "lbl_stock_code";
			this.lbl_stock_code.Size = new System.Drawing.Size(99, 26);
			this.lbl_stock_code.TabIndex = 117;
			this.lbl_stock_code.Text = "Stock Code";
			this.lbl_stock_code.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// grpbox_order
			// 
			this.grpbox_order.Controls.Add(this.lbl_m);
			this.grpbox_order.Controls.Add(this.lbl_mm);
			this.grpbox_order.Controls.Add(this.lbl_brand);
			this.grpbox_order.Controls.Add(this.txtbx_length);
			this.grpbox_order.Controls.Add(this.txtbx_conversion);
			this.grpbox_order.Controls.Add(this.lbl_stock_spec);
			this.grpbox_order.Controls.Add(this.txtbx_brand);
			this.grpbox_order.Controls.Add(this.txtbx_desc_1);
			this.grpbox_order.Controls.Add(this.txtbx_mic);
			this.grpbox_order.Controls.Add(this.lbl_conversion);
			this.grpbox_order.Controls.Add(this.txtbx_color);
			this.grpbox_order.Controls.Add(this.lbl_color);
			this.grpbox_order.Controls.Add(this.txtbx_width);
			this.grpbox_order.Controls.Add(this.lbl_mic);
			this.grpbox_order.Controls.Add(this.txtbx_desc_2);
			this.grpbox_order.Controls.Add(this.lbl_desc_2);
			this.grpbox_order.Controls.Add(this.txtbx_ref_no);
			this.grpbox_order.Controls.Add(this.lbl_ref_no);
			this.grpbox_order.Controls.Add(this.lbl_desc_1);
			this.grpbox_order.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.grpbox_order.Location = new System.Drawing.Point(14, 128);
			this.grpbox_order.Name = "grpbox_order";
			this.grpbox_order.Size = new System.Drawing.Size(956, 208);
			this.grpbox_order.TabIndex = 120;
			this.grpbox_order.TabStop = false;
			this.grpbox_order.Text = "Stock";
			// 
			// lbl_m
			// 
			this.lbl_m.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbl_m.Location = new System.Drawing.Point(909, 121);
			this.lbl_m.Name = "lbl_m";
			this.lbl_m.Size = new System.Drawing.Size(38, 25);
			this.lbl_m.TabIndex = 45;
			this.lbl_m.Text = "m";
			this.lbl_m.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lbl_mm
			// 
			this.lbl_mm.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbl_mm.Location = new System.Drawing.Point(713, 121);
			this.lbl_mm.Name = "lbl_mm";
			this.lbl_mm.Size = new System.Drawing.Size(68, 25);
			this.lbl_mm.TabIndex = 44;
			this.lbl_mm.Text = "mm    x";
			this.lbl_mm.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lbl_brand
			// 
			this.lbl_brand.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbl_brand.Location = new System.Drawing.Point(9, 90);
			this.lbl_brand.Name = "lbl_brand";
			this.lbl_brand.Size = new System.Drawing.Size(99, 26);
			this.lbl_brand.TabIndex = 40;
			this.lbl_brand.Text = "Brand";
			this.lbl_brand.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtbx_length
			// 
			this.txtbx_length.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtbx_length.Location = new System.Drawing.Point(784, 123);
			this.txtbx_length.Name = "txtbx_length";
			this.txtbx_length.ReadOnly = true;
			this.txtbx_length.Size = new System.Drawing.Size(120, 26);
			this.txtbx_length.TabIndex = 12;
			// 
			// txtbx_conversion
			// 
			this.txtbx_conversion.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtbx_conversion.Location = new System.Drawing.Point(580, 154);
			this.txtbx_conversion.Name = "txtbx_conversion";
			this.txtbx_conversion.ReadOnly = true;
			this.txtbx_conversion.Size = new System.Drawing.Size(358, 26);
			this.txtbx_conversion.TabIndex = 13;
			// 
			// lbl_stock_spec
			// 
			this.lbl_stock_spec.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbl_stock_spec.Location = new System.Drawing.Point(446, 124);
			this.lbl_stock_spec.Name = "lbl_stock_spec";
			this.lbl_stock_spec.Size = new System.Drawing.Size(110, 26);
			this.lbl_stock_spec.TabIndex = 41;
			this.lbl_stock_spec.Text = "Specification";
			// 
			// txtbx_brand
			// 
			this.txtbx_brand.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtbx_brand.Location = new System.Drawing.Point(143, 91);
			this.txtbx_brand.Name = "txtbx_brand";
			this.txtbx_brand.ReadOnly = true;
			this.txtbx_brand.Size = new System.Drawing.Size(281, 26);
			this.txtbx_brand.TabIndex = 8;
			// 
			// txtbx_mic
			// 
			this.txtbx_mic.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtbx_mic.Location = new System.Drawing.Point(143, 156);
			this.txtbx_mic.Name = "txtbx_mic";
			this.txtbx_mic.ReadOnly = true;
			this.txtbx_mic.Size = new System.Drawing.Size(281, 26);
			this.txtbx_mic.TabIndex = 11;
			// 
			// lbl_conversion
			// 
			this.lbl_conversion.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbl_conversion.Location = new System.Drawing.Point(446, 155);
			this.lbl_conversion.Name = "lbl_conversion";
			this.lbl_conversion.Size = new System.Drawing.Size(85, 26);
			this.lbl_conversion.TabIndex = 39;
			this.lbl_conversion.Text = "Roll/Carton";
			this.lbl_conversion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtbx_color
			// 
			this.txtbx_color.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtbx_color.Location = new System.Drawing.Point(143, 123);
			this.txtbx_color.Name = "txtbx_color";
			this.txtbx_color.ReadOnly = true;
			this.txtbx_color.Size = new System.Drawing.Size(281, 26);
			this.txtbx_color.TabIndex = 7;
			// 
			// lbl_color
			// 
			this.lbl_color.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbl_color.Location = new System.Drawing.Point(8, 123);
			this.lbl_color.Name = "lbl_color";
			this.lbl_color.Size = new System.Drawing.Size(116, 26);
			this.lbl_color.TabIndex = 38;
			this.lbl_color.Text = "Color";
			this.lbl_color.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtbx_width
			// 
			this.txtbx_width.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtbx_width.Location = new System.Drawing.Point(580, 123);
			this.txtbx_width.Name = "txtbx_width";
			this.txtbx_width.ReadOnly = true;
			this.txtbx_width.Size = new System.Drawing.Size(127, 26);
			this.txtbx_width.TabIndex = 10;
			// 
			// lbl_mic
			// 
			this.lbl_mic.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbl_mic.Location = new System.Drawing.Point(8, 155);
			this.lbl_mic.Name = "lbl_mic";
			this.lbl_mic.Size = new System.Drawing.Size(85, 26);
			this.lbl_mic.TabIndex = 35;
			this.lbl_mic.Text = "Micron";
			this.lbl_mic.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtbx_desc_2
			// 
			this.txtbx_desc_2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtbx_desc_2.Location = new System.Drawing.Point(143, 59);
			this.txtbx_desc_2.Name = "txtbx_desc_2";
			this.txtbx_desc_2.ReadOnly = true;
			this.txtbx_desc_2.Size = new System.Drawing.Size(795, 26);
			this.txtbx_desc_2.TabIndex = 6;
			// 
			// lbl_desc_2
			// 
			this.lbl_desc_2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbl_desc_2.Location = new System.Drawing.Point(8, 59);
			this.lbl_desc_2.Name = "lbl_desc_2";
			this.lbl_desc_2.Size = new System.Drawing.Size(116, 26);
			this.lbl_desc_2.TabIndex = 33;
			this.lbl_desc_2.Text = "Description 2";
			this.lbl_desc_2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtbx_ref_no
			// 
			this.txtbx_ref_no.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtbx_ref_no.Location = new System.Drawing.Point(580, 92);
			this.txtbx_ref_no.Name = "txtbx_ref_no";
			this.txtbx_ref_no.ReadOnly = true;
			this.txtbx_ref_no.Size = new System.Drawing.Size(358, 26);
			this.txtbx_ref_no.TabIndex = 9;
			// 
			// lbl_ref_no
			// 
			this.lbl_ref_no.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbl_ref_no.Location = new System.Drawing.Point(446, 91);
			this.lbl_ref_no.Name = "lbl_ref_no";
			this.lbl_ref_no.Size = new System.Drawing.Size(85, 26);
			this.lbl_ref_no.TabIndex = 29;
			this.lbl_ref_no.Text = "Ref No";
			this.lbl_ref_no.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lbl_desc_1
			// 
			this.lbl_desc_1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbl_desc_1.Location = new System.Drawing.Point(8, 28);
			this.lbl_desc_1.Name = "lbl_desc_1";
			this.lbl_desc_1.Size = new System.Drawing.Size(116, 26);
			this.lbl_desc_1.TabIndex = 26;
			this.lbl_desc_1.Text = "Description 1";
			this.lbl_desc_1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lbl_roll
			// 
			this.lbl_roll.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbl_roll.Location = new System.Drawing.Point(446, 353);
			this.lbl_roll.Name = "lbl_roll";
			this.lbl_roll.Size = new System.Drawing.Size(68, 25);
			this.lbl_roll.TabIndex = 100;
			this.lbl_roll.Text = "roll";
			this.lbl_roll.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// btn_cancel
			// 
			this.btn_cancel.BackColor = System.Drawing.Color.Silver;
			this.btn_cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btn_cancel.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_cancel.Location = new System.Drawing.Point(497, 714);
			this.btn_cancel.Name = "btn_cancel";
			this.btn_cancel.Size = new System.Drawing.Size(120, 27);
			this.btn_cancel.TabIndex = 6;
			this.btn_cancel.Text = "Cancel";
			this.btn_cancel.UseVisualStyleBackColor = false;
			this.btn_cancel.Click += new System.EventHandler(this.Btn_cancelClick);
			// 
			// btn_clear
			// 
			this.btn_clear.BackColor = System.Drawing.Color.Silver;
			this.btn_clear.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_clear.Location = new System.Drawing.Point(371, 714);
			this.btn_clear.Name = "btn_clear";
			this.btn_clear.Size = new System.Drawing.Size(120, 27);
			this.btn_clear.TabIndex = 5;
			this.btn_clear.Text = "Clear";
			this.btn_clear.UseVisualStyleBackColor = false;
			this.btn_clear.Click += new System.EventHandler(this.Btn_clearClick);
			// 
			// btn_save
			// 
			this.btn_save.BackColor = System.Drawing.Color.Silver;
			this.btn_save.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_save.Location = new System.Drawing.Point(244, 714);
			this.btn_save.Name = "btn_save";
			this.btn_save.Size = new System.Drawing.Size(120, 27);
			this.btn_save.TabIndex = 4;
			this.btn_save.Text = "Save";
			this.btn_save.UseVisualStyleBackColor = false;
			this.btn_save.Click += new System.EventHandler(this.Btn_saveClick);
			// 
			// panel2
			// 
			this.panel2.BackColor = System.Drawing.Color.Gainsboro;
			this.panel2.Controls.Add(this.lbl_username);
			this.panel2.Location = new System.Drawing.Point(0, 50);
			this.panel2.Margin = new System.Windows.Forms.Padding(1);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(1000, 23);
			this.panel2.TabIndex = 126;
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
			// txtbx_uom_2
			// 
			this.txtbx_uom_2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtbx_uom_2.Location = new System.Drawing.Point(863, 352);
			this.txtbx_uom_2.Name = "txtbx_uom_2";
			this.txtbx_uom_2.ReadOnly = true;
			this.txtbx_uom_2.Size = new System.Drawing.Size(81, 26);
			this.txtbx_uom_2.TabIndex = 101;
			// 
			// txtbx_uom_1
			// 
			this.txtbx_uom_1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtbx_uom_1.Location = new System.Drawing.Point(621, 352);
			this.txtbx_uom_1.Name = "txtbx_uom_1";
			this.txtbx_uom_1.ReadOnly = true;
			this.txtbx_uom_1.Size = new System.Drawing.Size(81, 26);
			this.txtbx_uom_1.TabIndex = 100;
			// 
			// lbl_uom
			// 
			this.lbl_uom.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbl_uom.Location = new System.Drawing.Point(514, 352);
			this.lbl_uom.Name = "lbl_uom";
			this.lbl_uom.Size = new System.Drawing.Size(104, 26);
			this.lbl_uom.TabIndex = 100;
			this.lbl_uom.Text = "Primary UOM";
			this.lbl_uom.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(734, 352);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(137, 26);
			this.label1.TabIndex = 127;
			this.label1.Text = "Secondary UOM";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// groupBx_record
			// 
			this.groupBx_record.Controls.Add(this.dt_grid);
			this.groupBx_record.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.groupBx_record.Location = new System.Drawing.Point(18, 394);
			this.groupBx_record.Name = "groupBx_record";
			this.groupBx_record.Size = new System.Drawing.Size(949, 286);
			this.groupBx_record.TabIndex = 150;
			this.groupBx_record.TabStop = false;
			this.groupBx_record.Text = "Record Saved";
			// 
			// dt_grid
			// 
			this.dt_grid.AllowUserToAddRows = false;
			this.dt_grid.AllowUserToDeleteRows = false;
			this.dt_grid.AllowUserToResizeRows = false;
			dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			this.dt_grid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
			this.dt_grid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.dt_grid.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
			this.dt_grid.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.dt_grid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
			dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle2.BackColor = System.Drawing.Color.WhiteSmoke;
			dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.dt_grid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
			this.dt_grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
			dataGridViewCellStyle3.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
			dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.dt_grid.DefaultCellStyle = dataGridViewCellStyle3;
			this.dt_grid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke;
			this.dt_grid.EnableHeadersVisualStyles = false;
			this.dt_grid.Location = new System.Drawing.Point(17, 32);
			this.dt_grid.MultiSelect = false;
			this.dt_grid.Name = "dt_grid";
			this.dt_grid.ReadOnly = true;
			this.dt_grid.RowHeadersVisible = false;
			this.dt_grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dt_grid.Size = new System.Drawing.Size(914, 233);
			this.dt_grid.TabIndex = 131;
			this.dt_grid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Dt_gridCellClick);
			// 
			// btn_del
			// 
			this.btn_del.BackColor = System.Drawing.Color.Silver;
			this.btn_del.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_del.Location = new System.Drawing.Point(245, 714);
			this.btn_del.Name = "btn_del";
			this.btn_del.Size = new System.Drawing.Size(120, 27);
			this.btn_del.TabIndex = 152;
			this.btn_del.Text = "Delete";
			this.btn_del.UseVisualStyleBackColor = false;
			this.btn_del.Click += new System.EventHandler(this.Btn_delClick);
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(413, 747);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(100, 23);
			this.label3.TabIndex = 153;
			// 
			// btn_post
			// 
			this.btn_post.BackColor = System.Drawing.Color.Silver;
			this.btn_post.Enabled = false;
			this.btn_post.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_post.Location = new System.Drawing.Point(624, 714);
			this.btn_post.Name = "btn_post";
			this.btn_post.Size = new System.Drawing.Size(120, 27);
			this.btn_post.TabIndex = 7;
			this.btn_post.Text = "Post";
			this.btn_post.UseVisualStyleBackColor = false;
			this.btn_post.Click += new System.EventHandler(this.Btn_postClick);
			// 
			// btn_email
			// 
			this.btn_email.BackColor = System.Drawing.Color.Silver;
			this.btn_email.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_email.Location = new System.Drawing.Point(750, 714);
			this.btn_email.Name = "btn_email";
			this.btn_email.Size = new System.Drawing.Size(121, 27);
			this.btn_email.TabIndex = 154;
			this.btn_email.Text = "Resend Email";
			this.btn_email.UseVisualStyleBackColor = false;
			this.btn_email.Click += new System.EventHandler(this.Button1Click);
			// 
			// frm_prod_converting_store
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.AutoScroll = true;
			this.CancelButton = this.btn_cancel;
			this.ClientSize = new System.Drawing.Size(1000, 700);
			this.Controls.Add(this.btn_email);
			this.Controls.Add(this.btn_post);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.txtbx_uom_1);
			this.Controls.Add(this.txtbx_uom_2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.lbl_uom);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.btn_cancel);
			this.Controls.Add(this.btn_clear);
			this.Controls.Add(this.lbl_roll);
			this.Controls.Add(this.txtbx_stock_code);
			this.Controls.Add(this.lbl_stock_code);
			this.Controls.Add(this.txtbx_qty_order);
			this.Controls.Add(this.lbl_qty);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.btn_search);
			this.Controls.Add(this.btn_save);
			this.Controls.Add(this.btn_del);
			this.Controls.Add(this.groupBx_record);
			this.Controls.Add(this.grpbox_order);
			this.Name = "frm_prod_converting_store";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Converting Store Order";
			this.Load += new System.EventHandler(this.Frm_prod_converting_storeLoad);
			this.panel1.ResumeLayout(false);
			this.grpbox_order.ResumeLayout(false);
			this.grpbox_order.PerformLayout();
			this.panel2.ResumeLayout(false);
			this.groupBx_record.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dt_grid)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.Button btn_email;
		private System.Windows.Forms.Button btn_post;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button btn_del;
		private System.Windows.Forms.DataGridView dt_grid;
		private System.Windows.Forms.GroupBox groupBx_record;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label lbl_uom;
		private System.Windows.Forms.TextBox txtbx_uom_1;
		private System.Windows.Forms.TextBox txtbx_uom_2;
		private System.Windows.Forms.Label lbl_username;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Button btn_save;
		private System.Windows.Forms.Button btn_clear;
		private System.Windows.Forms.Button btn_cancel;
		private System.Windows.Forms.Label lbl_roll;
		private System.Windows.Forms.Label lbl_desc_1;
		private System.Windows.Forms.Label lbl_ref_no;
		private System.Windows.Forms.TextBox txtbx_ref_no;
		private System.Windows.Forms.Label lbl_desc_2;
		private System.Windows.Forms.TextBox txtbx_desc_2;
		private System.Windows.Forms.Label lbl_mic;
		private System.Windows.Forms.TextBox txtbx_width;
		private System.Windows.Forms.Label lbl_color;
		private System.Windows.Forms.TextBox txtbx_color;
		private System.Windows.Forms.Label lbl_conversion;
		private System.Windows.Forms.TextBox txtbx_mic;
		private System.Windows.Forms.TextBox txtbx_brand;
		private System.Windows.Forms.Label lbl_stock_spec;
		private System.Windows.Forms.TextBox txtbx_conversion;
		private System.Windows.Forms.TextBox txtbx_length;
		private System.Windows.Forms.Label lbl_brand;
		private System.Windows.Forms.Label lbl_mm;
		private System.Windows.Forms.Label lbl_m;
		private System.Windows.Forms.GroupBox grpbox_order;
		private System.Windows.Forms.Label lbl_stock_code;
		private System.Windows.Forms.TextBox txtbx_stock_code;
		private System.Windows.Forms.Label lbl_qty;
		private System.Windows.Forms.TextBox txtbx_qty_order;
		private System.Windows.Forms.Button btn_search;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label lbl_header;
		private System.Windows.Forms.TextBox txtbx_desc_1;
	}
}
