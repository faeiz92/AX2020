/*
 * Created by SharpDevelop.
 * User: ax2020-1
 * Date: 2/20/2017
 * Time: 5:18 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace AX2020
{
	partial class frm_prod_warehouse_fr_receive_pack
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
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
			this.panel1 = new System.Windows.Forms.Panel();
			this.lbl_header = new System.Windows.Forms.Label();
			this.grpbox_output = new System.Windows.Forms.GroupBox();
			this.txtbx_qty_roll = new System.Windows.Forms.TextBox();
			this.txtbx_qty_ctn = new System.Windows.Forms.TextBox();
			this.lbl_roll_qty = new System.Windows.Forms.Label();
			this.lbl_ctn_qty = new System.Windows.Forms.Label();
			this.grpbox_cust = new System.Windows.Forms.GroupBox();
			this.label1 = new System.Windows.Forms.Label();
			this.lbl_total_qty_balance = new System.Windows.Forms.Label();
			this.txtbx_length_cust = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.txtbx_total_qty_balance = new System.Windows.Forms.TextBox();
			this.txtbx_width_cust = new System.Windows.Forms.TextBox();
			this.lbl_roll_carton = new System.Windows.Forms.Label();
			this.txtbx_conversion = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.txtbx_mic = new System.Windows.Forms.TextBox();
			this.txtbx_color = new System.Windows.Forms.TextBox();
			this.lbl_total_qty_order = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.txtbx_total_qty_order = new System.Windows.Forms.TextBox();
			this.txtbx_brand = new System.Windows.Forms.TextBox();
			this.lbl_size = new System.Windows.Forms.Label();
			this.lbl_prod_code = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.txtbx_prod_code = new System.Windows.Forms.TextBox();
			this.txtbx_cust = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.btn_search = new System.Windows.Forms.Button();
			this.panel2 = new System.Windows.Forms.Panel();
			this.lbl_username = new System.Windows.Forms.Label();
			this.lbl_pack_no = new System.Windows.Forms.Label();
			this.txtbx_pack_no = new System.Windows.Forms.TextBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.txtbx_qty_roll_received = new System.Windows.Forms.TextBox();
			this.txtbx_qty_ctn_received = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.btn_cancel = new System.Windows.Forms.Button();
			this.btn_clear = new System.Windows.Forms.Button();
			this.btn_save = new System.Windows.Forms.Button();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.dt_grid = new System.Windows.Forms.DataGridView();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.dt_grid_not_received = new System.Windows.Forms.DataGridView();
			this.btn_edit = new System.Windows.Forms.Button();
			this.grpbox_output.SuspendLayout();
			this.grpbox_cust.SuspendLayout();
			this.panel2.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dt_grid)).BeginInit();
			this.groupBox3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dt_grid_not_received)).BeginInit();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.Color.DarkCyan;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(1000, 52);
			this.panel1.TabIndex = 114;
			// 
			// lbl_header
			// 
			this.lbl_header.BackColor = System.Drawing.Color.DarkCyan;
			this.lbl_header.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbl_header.ForeColor = System.Drawing.SystemColors.ControlLightLight;
			this.lbl_header.Location = new System.Drawing.Point(0, 14);
			this.lbl_header.Name = "lbl_header";
			this.lbl_header.Size = new System.Drawing.Size(998, 23);
			this.lbl_header.TabIndex = 108;
			this.lbl_header.Text = "FR STOCK RECEIVE";
			this.lbl_header.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// grpbox_output
			// 
			this.grpbox_output.Controls.Add(this.txtbx_qty_roll);
			this.grpbox_output.Controls.Add(this.txtbx_qty_ctn);
			this.grpbox_output.Controls.Add(this.lbl_roll_qty);
			this.grpbox_output.Controls.Add(this.lbl_ctn_qty);
			this.grpbox_output.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.grpbox_output.Location = new System.Drawing.Point(9, 319);
			this.grpbox_output.Name = "grpbox_output";
			this.grpbox_output.Size = new System.Drawing.Size(963, 61);
			this.grpbox_output.TabIndex = 112;
			this.grpbox_output.TabStop = false;
			this.grpbox_output.Text = "Output";
			// 
			// txtbx_qty_roll
			// 
			this.txtbx_qty_roll.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtbx_qty_roll.Location = new System.Drawing.Point(596, 25);
			this.txtbx_qty_roll.Name = "txtbx_qty_roll";
			this.txtbx_qty_roll.ReadOnly = true;
			this.txtbx_qty_roll.Size = new System.Drawing.Size(348, 26);
			this.txtbx_qty_roll.TabIndex = 20;
			this.txtbx_qty_roll.TabStop = false;
			this.txtbx_qty_roll.Text = "0";
			// 
			// txtbx_qty_ctn
			// 
			this.txtbx_qty_ctn.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtbx_qty_ctn.Location = new System.Drawing.Point(150, 23);
			this.txtbx_qty_ctn.Name = "txtbx_qty_ctn";
			this.txtbx_qty_ctn.ReadOnly = true;
			this.txtbx_qty_ctn.Size = new System.Drawing.Size(302, 26);
			this.txtbx_qty_ctn.TabIndex = 19;
			this.txtbx_qty_ctn.TabStop = false;
			this.txtbx_qty_ctn.Text = "0";
			// 
			// lbl_roll_qty
			// 
			this.lbl_roll_qty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbl_roll_qty.Location = new System.Drawing.Point(483, 25);
			this.lbl_roll_qty.Name = "lbl_roll_qty";
			this.lbl_roll_qty.Size = new System.Drawing.Size(118, 26);
			this.lbl_roll_qty.TabIndex = 79;
			this.lbl_roll_qty.Text = "Roll Quantity";
			this.lbl_roll_qty.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lbl_ctn_qty
			// 
			this.lbl_ctn_qty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbl_ctn_qty.Location = new System.Drawing.Point(6, 22);
			this.lbl_ctn_qty.Name = "lbl_ctn_qty";
			this.lbl_ctn_qty.Size = new System.Drawing.Size(138, 26);
			this.lbl_ctn_qty.TabIndex = 27;
			this.lbl_ctn_qty.Text = "Carton Quantity";
			this.lbl_ctn_qty.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// grpbox_cust
			// 
			this.grpbox_cust.Controls.Add(this.label1);
			this.grpbox_cust.Controls.Add(this.lbl_total_qty_balance);
			this.grpbox_cust.Controls.Add(this.txtbx_length_cust);
			this.grpbox_cust.Controls.Add(this.label3);
			this.grpbox_cust.Controls.Add(this.txtbx_total_qty_balance);
			this.grpbox_cust.Controls.Add(this.txtbx_width_cust);
			this.grpbox_cust.Controls.Add(this.lbl_roll_carton);
			this.grpbox_cust.Controls.Add(this.txtbx_conversion);
			this.grpbox_cust.Controls.Add(this.label7);
			this.grpbox_cust.Controls.Add(this.label8);
			this.grpbox_cust.Controls.Add(this.txtbx_mic);
			this.grpbox_cust.Controls.Add(this.txtbx_color);
			this.grpbox_cust.Controls.Add(this.lbl_total_qty_order);
			this.grpbox_cust.Controls.Add(this.label6);
			this.grpbox_cust.Controls.Add(this.txtbx_total_qty_order);
			this.grpbox_cust.Controls.Add(this.txtbx_brand);
			this.grpbox_cust.Controls.Add(this.lbl_size);
			this.grpbox_cust.Controls.Add(this.lbl_prod_code);
			this.grpbox_cust.Controls.Add(this.label2);
			this.grpbox_cust.Controls.Add(this.txtbx_prod_code);
			this.grpbox_cust.Controls.Add(this.txtbx_cust);
			this.grpbox_cust.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.grpbox_cust.Location = new System.Drawing.Point(9, 137);
			this.grpbox_cust.Name = "grpbox_cust";
			this.grpbox_cust.Size = new System.Drawing.Size(963, 179);
			this.grpbox_cust.TabIndex = 9;
			this.grpbox_cust.TabStop = false;
			this.grpbox_cust.Text = "Customer";
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(473, 132);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(26, 26);
			this.label1.TabIndex = 43;
			this.label1.Text = "m";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lbl_total_qty_balance
			// 
			this.lbl_total_qty_balance.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbl_total_qty_balance.Location = new System.Drawing.Point(666, 67);
			this.lbl_total_qty_balance.Name = "lbl_total_qty_balance";
			this.lbl_total_qty_balance.Size = new System.Drawing.Size(131, 26);
			this.lbl_total_qty_balance.TabIndex = 124;
			this.lbl_total_qty_balance.Text = "Total Qty Balance";
			this.lbl_total_qty_balance.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtbx_length_cust
			// 
			this.txtbx_length_cust.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtbx_length_cust.Location = new System.Drawing.Point(379, 131);
			this.txtbx_length_cust.Name = "txtbx_length_cust";
			this.txtbx_length_cust.ReadOnly = true;
			this.txtbx_length_cust.Size = new System.Drawing.Size(88, 26);
			this.txtbx_length_cust.TabIndex = 13;
			this.txtbx_length_cust.TabStop = false;
			// 
			// label3
			// 
			this.label3.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.Location = new System.Drawing.Point(330, 132);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(51, 26);
			this.label3.TabIndex = 42;
			this.label3.Text = "mm  x";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtbx_total_qty_balance
			// 
			this.txtbx_total_qty_balance.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtbx_total_qty_balance.Location = new System.Drawing.Point(803, 67);
			this.txtbx_total_qty_balance.Name = "txtbx_total_qty_balance";
			this.txtbx_total_qty_balance.ReadOnly = true;
			this.txtbx_total_qty_balance.Size = new System.Drawing.Size(141, 26);
			this.txtbx_total_qty_balance.TabIndex = 16;
			this.txtbx_total_qty_balance.TabStop = false;
			// 
			// txtbx_width_cust
			// 
			this.txtbx_width_cust.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtbx_width_cust.Location = new System.Drawing.Point(242, 131);
			this.txtbx_width_cust.Name = "txtbx_width_cust";
			this.txtbx_width_cust.ReadOnly = true;
			this.txtbx_width_cust.Size = new System.Drawing.Size(88, 26);
			this.txtbx_width_cust.TabIndex = 12;
			this.txtbx_width_cust.TabStop = false;
			// 
			// lbl_roll_carton
			// 
			this.lbl_roll_carton.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbl_roll_carton.Location = new System.Drawing.Point(355, 98);
			this.lbl_roll_carton.Name = "lbl_roll_carton";
			this.lbl_roll_carton.Size = new System.Drawing.Size(112, 26);
			this.lbl_roll_carton.TabIndex = 122;
			this.lbl_roll_carton.Text = "Roll per Carton";
			this.lbl_roll_carton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtbx_conversion
			// 
			this.txtbx_conversion.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtbx_conversion.Location = new System.Drawing.Point(473, 97);
			this.txtbx_conversion.Name = "txtbx_conversion";
			this.txtbx_conversion.ReadOnly = true;
			this.txtbx_conversion.Size = new System.Drawing.Size(171, 26);
			this.txtbx_conversion.TabIndex = 18;
			this.txtbx_conversion.TabStop = false;
			// 
			// label7
			// 
			this.label7.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label7.Location = new System.Drawing.Point(195, 131);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(42, 26);
			this.label7.TabIndex = 120;
			this.label7.Text = "mic";
			this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label8
			// 
			this.label8.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label8.Location = new System.Drawing.Point(355, 66);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(116, 26);
			this.label8.TabIndex = 119;
			this.label8.Text = "Color";
			this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtbx_mic
			// 
			this.txtbx_mic.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtbx_mic.Location = new System.Drawing.Point(123, 130);
			this.txtbx_mic.Name = "txtbx_mic";
			this.txtbx_mic.ReadOnly = true;
			this.txtbx_mic.Size = new System.Drawing.Size(66, 26);
			this.txtbx_mic.TabIndex = 15;
			this.txtbx_mic.TabStop = false;
			// 
			// txtbx_color
			// 
			this.txtbx_color.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtbx_color.Location = new System.Drawing.Point(473, 67);
			this.txtbx_color.Name = "txtbx_color";
			this.txtbx_color.ReadOnly = true;
			this.txtbx_color.Size = new System.Drawing.Size(171, 26);
			this.txtbx_color.TabIndex = 14;
			this.txtbx_color.TabStop = false;
			// 
			// lbl_total_qty_order
			// 
			this.lbl_total_qty_order.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbl_total_qty_order.Location = new System.Drawing.Point(666, 101);
			this.lbl_total_qty_order.Name = "lbl_total_qty_order";
			this.lbl_total_qty_order.Size = new System.Drawing.Size(131, 26);
			this.lbl_total_qty_order.TabIndex = 116;
			this.lbl_total_qty_order.Text = "Total Qty Ordered";
			this.lbl_total_qty_order.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label6
			// 
			this.label6.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label6.Location = new System.Drawing.Point(8, 97);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(112, 26);
			this.label6.TabIndex = 115;
			this.label6.Text = "Brand";
			this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtbx_total_qty_order
			// 
			this.txtbx_total_qty_order.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtbx_total_qty_order.Location = new System.Drawing.Point(803, 101);
			this.txtbx_total_qty_order.Name = "txtbx_total_qty_order";
			this.txtbx_total_qty_order.ReadOnly = true;
			this.txtbx_total_qty_order.Size = new System.Drawing.Size(141, 26);
			this.txtbx_total_qty_order.TabIndex = 17;
			this.txtbx_total_qty_order.TabStop = false;
			// 
			// txtbx_brand
			// 
			this.txtbx_brand.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtbx_brand.Location = new System.Drawing.Point(123, 98);
			this.txtbx_brand.Name = "txtbx_brand";
			this.txtbx_brand.ReadOnly = true;
			this.txtbx_brand.Size = new System.Drawing.Size(208, 26);
			this.txtbx_brand.TabIndex = 11;
			this.txtbx_brand.TabStop = false;
			// 
			// lbl_size
			// 
			this.lbl_size.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbl_size.Location = new System.Drawing.Point(6, 130);
			this.lbl_size.Name = "lbl_size";
			this.lbl_size.Size = new System.Drawing.Size(116, 26);
			this.lbl_size.TabIndex = 111;
			this.lbl_size.Text = "Size";
			this.lbl_size.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lbl_prod_code
			// 
			this.lbl_prod_code.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbl_prod_code.Location = new System.Drawing.Point(8, 65);
			this.lbl_prod_code.Name = "lbl_prod_code";
			this.lbl_prod_code.Size = new System.Drawing.Size(109, 26);
			this.lbl_prod_code.TabIndex = 110;
			this.lbl_prod_code.Text = "Product Code";
			this.lbl_prod_code.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label2
			// 
			this.label2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.Location = new System.Drawing.Point(8, 33);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(112, 26);
			this.label2.TabIndex = 109;
			this.label2.Text = "Name";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtbx_prod_code
			// 
			this.txtbx_prod_code.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtbx_prod_code.Location = new System.Drawing.Point(123, 66);
			this.txtbx_prod_code.Name = "txtbx_prod_code";
			this.txtbx_prod_code.ReadOnly = true;
			this.txtbx_prod_code.Size = new System.Drawing.Size(208, 26);
			this.txtbx_prod_code.TabIndex = 10;
			this.txtbx_prod_code.TabStop = false;
			// 
			// txtbx_cust
			// 
			this.txtbx_cust.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtbx_cust.Location = new System.Drawing.Point(123, 34);
			this.txtbx_cust.Name = "txtbx_cust";
			this.txtbx_cust.ReadOnly = true;
			this.txtbx_cust.Size = new System.Drawing.Size(821, 26);
			this.txtbx_cust.TabIndex = 9;
			this.txtbx_cust.TabStop = false;
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(446, 932);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(100, 23);
			this.label4.TabIndex = 130;
			// 
			// btn_search
			// 
			this.btn_search.BackColor = System.Drawing.Color.Silver;
			this.btn_search.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_search.Location = new System.Drawing.Point(283, 97);
			this.btn_search.Name = "btn_search";
			this.btn_search.Size = new System.Drawing.Size(120, 27);
			this.btn_search.TabIndex = 3;
			this.btn_search.Text = "Search";
			this.btn_search.UseVisualStyleBackColor = false;
			this.btn_search.Click += new System.EventHandler(this.Btn_searchClick);
			// 
			// panel2
			// 
			this.panel2.BackColor = System.Drawing.Color.Gainsboro;
			this.panel2.Controls.Add(this.lbl_username);
			this.panel2.Location = new System.Drawing.Point(0, 50);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(1000, 23);
			this.panel2.TabIndex = 137;
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
			// lbl_pack_no
			// 
			this.lbl_pack_no.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbl_pack_no.Location = new System.Drawing.Point(16, 97);
			this.lbl_pack_no.Name = "lbl_pack_no";
			this.lbl_pack_no.Size = new System.Drawing.Size(155, 26);
			this.lbl_pack_no.TabIndex = 139;
			this.lbl_pack_no.Text = "Packing Number";
			this.lbl_pack_no.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtbx_pack_no
			// 
			this.txtbx_pack_no.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtbx_pack_no.Location = new System.Drawing.Point(167, 98);
			this.txtbx_pack_no.Name = "txtbx_pack_no";
			this.txtbx_pack_no.Size = new System.Drawing.Size(110, 26);
			this.txtbx_pack_no.TabIndex = 2;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.txtbx_qty_roll_received);
			this.groupBox1.Controls.Add(this.txtbx_qty_ctn_received);
			this.groupBox1.Controls.Add(this.label5);
			this.groupBox1.Controls.Add(this.label9);
			this.groupBox1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.groupBox1.Location = new System.Drawing.Point(9, 386);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(963, 61);
			this.groupBox1.TabIndex = 4;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Received";
			// 
			// txtbx_qty_roll_received
			// 
			this.txtbx_qty_roll_received.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtbx_qty_roll_received.Location = new System.Drawing.Point(596, 25);
			this.txtbx_qty_roll_received.Name = "txtbx_qty_roll_received";
			this.txtbx_qty_roll_received.Size = new System.Drawing.Size(348, 26);
			this.txtbx_qty_roll_received.TabIndex = 5;
			this.txtbx_qty_roll_received.Text = "0";
			this.txtbx_qty_roll_received.Visible = false;
			// 
			// txtbx_qty_ctn_received
			// 
			this.txtbx_qty_ctn_received.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtbx_qty_ctn_received.Location = new System.Drawing.Point(150, 23);
			this.txtbx_qty_ctn_received.Name = "txtbx_qty_ctn_received";
			this.txtbx_qty_ctn_received.Size = new System.Drawing.Size(302, 26);
			this.txtbx_qty_ctn_received.TabIndex = 4;
			this.txtbx_qty_ctn_received.Text = "0";
			// 
			// label5
			// 
			this.label5.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label5.Location = new System.Drawing.Point(483, 25);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(118, 26);
			this.label5.TabIndex = 79;
			this.label5.Text = "Roll Quantity";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.label5.Visible = false;
			// 
			// label9
			// 
			this.label9.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label9.Location = new System.Drawing.Point(6, 22);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(138, 26);
			this.label9.TabIndex = 27;
			this.label9.Text = "Roll Quantity";
			this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// btn_cancel
			// 
			this.btn_cancel.BackColor = System.Drawing.Color.Silver;
			this.btn_cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btn_cancel.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_cancel.Location = new System.Drawing.Point(558, 904);
			this.btn_cancel.Name = "btn_cancel";
			this.btn_cancel.Size = new System.Drawing.Size(120, 27);
			this.btn_cancel.TabIndex = 8;
			this.btn_cancel.Text = "Cancel";
			this.btn_cancel.UseVisualStyleBackColor = false;
			this.btn_cancel.Click += new System.EventHandler(this.Btn_cancelClick);
			// 
			// btn_clear
			// 
			this.btn_clear.BackColor = System.Drawing.Color.Silver;
			this.btn_clear.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_clear.Location = new System.Drawing.Point(432, 904);
			this.btn_clear.Name = "btn_clear";
			this.btn_clear.Size = new System.Drawing.Size(120, 27);
			this.btn_clear.TabIndex = 7;
			this.btn_clear.Text = "Clear";
			this.btn_clear.UseVisualStyleBackColor = false;
			this.btn_clear.Click += new System.EventHandler(this.Btn_clearClick);
			// 
			// btn_save
			// 
			this.btn_save.BackColor = System.Drawing.Color.Silver;
			this.btn_save.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_save.Location = new System.Drawing.Point(306, 905);
			this.btn_save.Name = "btn_save";
			this.btn_save.Size = new System.Drawing.Size(120, 27);
			this.btn_save.TabIndex = 6;
			this.btn_save.Text = "Save";
			this.btn_save.UseVisualStyleBackColor = false;
			this.btn_save.Click += new System.EventHandler(this.Btn_saveClick);
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.dt_grid);
			this.groupBox2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.groupBox2.Location = new System.Drawing.Point(11, 688);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(963, 199);
			this.groupBox2.TabIndex = 143;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Stock Received";
			// 
			// dt_grid
			// 
			this.dt_grid.AllowUserToAddRows = false;
			this.dt_grid.AllowUserToDeleteRows = false;
			this.dt_grid.AllowUserToResizeRows = false;
			dataGridViewCellStyle5.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			this.dt_grid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
			this.dt_grid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.dt_grid.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
			this.dt_grid.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.dt_grid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
			dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle6.BackColor = System.Drawing.Color.WhiteSmoke;
			dataGridViewCellStyle6.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.dt_grid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
			this.dt_grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dt_grid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke;
			this.dt_grid.EnableHeadersVisualStyles = false;
			this.dt_grid.Location = new System.Drawing.Point(15, 27);
			this.dt_grid.MultiSelect = false;
			this.dt_grid.Name = "dt_grid";
			this.dt_grid.ReadOnly = true;
			this.dt_grid.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
			this.dt_grid.RowHeadersVisible = false;
			this.dt_grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dt_grid.Size = new System.Drawing.Size(937, 156);
			this.dt_grid.TabIndex = 130;
			this.dt_grid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Dt_gridCellClick);
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.dt_grid_not_received);
			this.groupBox3.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.groupBox3.Location = new System.Drawing.Point(10, 452);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(963, 230);
			this.groupBox3.TabIndex = 144;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Stock Not Yet Received";
			// 
			// dt_grid_not_received
			// 
			this.dt_grid_not_received.AllowUserToAddRows = false;
			this.dt_grid_not_received.AllowUserToDeleteRows = false;
			this.dt_grid_not_received.AllowUserToResizeRows = false;
			dataGridViewCellStyle7.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			this.dt_grid_not_received.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle7;
			this.dt_grid_not_received.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.dt_grid_not_received.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
			this.dt_grid_not_received.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.dt_grid_not_received.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
			dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle8.BackColor = System.Drawing.Color.WhiteSmoke;
			dataGridViewCellStyle8.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.dt_grid_not_received.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle8;
			this.dt_grid_not_received.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dt_grid_not_received.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke;
			this.dt_grid_not_received.EnableHeadersVisualStyles = false;
			this.dt_grid_not_received.Location = new System.Drawing.Point(15, 27);
			this.dt_grid_not_received.MultiSelect = false;
			this.dt_grid_not_received.Name = "dt_grid_not_received";
			this.dt_grid_not_received.ReadOnly = true;
			this.dt_grid_not_received.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
			this.dt_grid_not_received.RowHeadersVisible = false;
			this.dt_grid_not_received.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dt_grid_not_received.Size = new System.Drawing.Size(937, 185);
			this.dt_grid_not_received.TabIndex = 130;
			this.dt_grid_not_received.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Dt_grid_not_receivedCellClick);
			// 
			// btn_edit
			// 
			this.btn_edit.BackColor = System.Drawing.Color.Silver;
			this.btn_edit.Enabled = false;
			this.btn_edit.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_edit.Location = new System.Drawing.Point(409, 97);
			this.btn_edit.Name = "btn_edit";
			this.btn_edit.Size = new System.Drawing.Size(120, 27);
			this.btn_edit.TabIndex = 145;
			this.btn_edit.Text = "Edit Qty";
			this.btn_edit.UseVisualStyleBackColor = false;
			this.btn_edit.Click += new System.EventHandler(this.Btn_editClick);
			// 
			// frm_prod_warehouse_fr_receive_pack
			// 
			this.AcceptButton = this.btn_search;
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.AutoScroll = true;
			this.CancelButton = this.btn_cancel;
			this.ClientSize = new System.Drawing.Size(1001, 678);
			this.Controls.Add(this.btn_edit);
			this.Controls.Add(this.groupBox3);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.btn_cancel);
			this.Controls.Add(this.btn_clear);
			this.Controls.Add(this.btn_save);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.txtbx_pack_no);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.btn_search);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.grpbox_cust);
			this.Controls.Add(this.lbl_header);
			this.Controls.Add(this.grpbox_output);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.lbl_pack_no);
			this.Name = "frm_prod_warehouse_fr_receive_pack";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "FR Stock Receive";
			this.Load += new System.EventHandler(this.frm_prod_warehouse_fr_receive_packLoad);
			this.grpbox_output.ResumeLayout(false);
			this.grpbox_output.PerformLayout();
			this.grpbox_cust.ResumeLayout(false);
			this.grpbox_cust.PerformLayout();
			this.panel2.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dt_grid)).EndInit();
			this.groupBox3.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dt_grid_not_received)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.Button btn_edit;
		private System.Windows.Forms.DataGridView dt_grid_not_received;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox txtbx_qty_ctn_received;
		private System.Windows.Forms.TextBox txtbx_qty_roll_received;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.TextBox txtbx_pack_no;
		private System.Windows.Forms.Label lbl_pack_no;
		private System.Windows.Forms.Label lbl_username;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.DataGridView dt_grid;
		private System.Windows.Forms.Button btn_save;
		private System.Windows.Forms.Button btn_clear;
		private System.Windows.Forms.Button btn_cancel;
		private System.Windows.Forms.TextBox txtbx_cust;
		private System.Windows.Forms.TextBox txtbx_prod_code;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label lbl_prod_code;
		private System.Windows.Forms.Label lbl_size;
		private System.Windows.Forms.TextBox txtbx_brand;
		private System.Windows.Forms.TextBox txtbx_total_qty_order;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label lbl_total_qty_order;
		private System.Windows.Forms.TextBox txtbx_color;
		private System.Windows.Forms.TextBox txtbx_mic;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TextBox txtbx_conversion;
		private System.Windows.Forms.Label lbl_roll_carton;
		private System.Windows.Forms.TextBox txtbx_width_cust;
		private System.Windows.Forms.TextBox txtbx_total_qty_balance;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox txtbx_length_cust;
		private System.Windows.Forms.Label lbl_total_qty_balance;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.GroupBox grpbox_cust;
		private System.Windows.Forms.TextBox txtbx_qty_roll;
		private System.Windows.Forms.Button btn_search;
		private System.Windows.Forms.Label lbl_ctn_qty;
		private System.Windows.Forms.Label lbl_roll_qty;
		private System.Windows.Forms.TextBox txtbx_qty_ctn;
		private System.Windows.Forms.GroupBox grpbox_output;
		private System.Windows.Forms.Label lbl_header;
		private System.Windows.Forms.Panel panel1;
		


	}
}
