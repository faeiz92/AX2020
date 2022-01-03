/*
 * Created by SharpDevelop.
 * User: ax2020-1
 * Date: 1/24/2017
 * Time: 10:00 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace AX2020
{
	partial class frm_prod_shipping
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
			this.panel2 = new System.Windows.Forms.Panel();
			this.lbl_username = new System.Windows.Forms.Label();
			this.panel1 = new System.Windows.Forms.Panel();
			this.lbl_header = new System.Windows.Forms.Label();
			this.grpbox_ship = new System.Windows.Forms.GroupBox();
			this.cbx_container_size = new System.Windows.Forms.ComboBox();
			this.txtbx_container_size = new System.Windows.Forms.TextBox();
			this.txtbx_sales_inv_no = new System.Windows.Forms.TextBox();
			this.txtbx_so_no = new System.Windows.Forms.TextBox();
			this.txtbx_forwarder = new System.Windows.Forms.TextBox();
			this.lbl_forwarder = new System.Windows.Forms.Label();
			this.txtbx_cust = new System.Windows.Forms.TextBox();
			this.lbl_so_no = new System.Windows.Forms.Label();
			this.lbl_sales_inv_no = new System.Windows.Forms.Label();
			this.lbl_cust = new System.Windows.Forms.Label();
			this.dtp_exp_arrival = new System.Windows.Forms.DateTimePicker();
			this.dtp_exp_delivery = new System.Windows.Forms.DateTimePicker();
			this.lbl_container_type = new System.Windows.Forms.Label();
			this.cbx_container_type = new System.Windows.Forms.ComboBox();
			this.lbl_container_size = new System.Windows.Forms.Label();
			this.txtbx_ship_code = new System.Windows.Forms.TextBox();
			this.lbl_exp_arrival = new System.Windows.Forms.Label();
			this.lbl_exp_delivery = new System.Windows.Forms.Label();
			this.lbl_ship_code = new System.Windows.Forms.Label();
			this.btn_cancel = new System.Windows.Forms.Button();
			this.btn_clear = new System.Windows.Forms.Button();
			this.btn_save = new System.Windows.Forms.Button();
			this.btn_del = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.groupBx_record = new System.Windows.Forms.GroupBox();
			this.dt_grid = new System.Windows.Forms.DataGridView();
			this.panel2.SuspendLayout();
			this.grpbox_ship.SuspendLayout();
			this.groupBx_record.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dt_grid)).BeginInit();
			this.SuspendLayout();
			// 
			// panel2
			// 
			this.panel2.BackColor = System.Drawing.Color.Gainsboro;
			this.panel2.Controls.Add(this.lbl_username);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel2.Location = new System.Drawing.Point(0, 52);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(1069, 23);
			this.panel2.TabIndex = 141;
			// 
			// lbl_username
			// 
			this.lbl_username.BackColor = System.Drawing.Color.Gainsboro;
			this.lbl_username.Dock = System.Windows.Forms.DockStyle.Top;
			this.lbl_username.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbl_username.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.lbl_username.Location = new System.Drawing.Point(0, 0);
			this.lbl_username.Name = "lbl_username";
			this.lbl_username.Size = new System.Drawing.Size(1069, 23);
			this.lbl_username.TabIndex = 0;
			this.lbl_username.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.Color.DarkCyan;
			this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(1069, 52);
			this.panel1.TabIndex = 139;
			// 
			// lbl_header
			// 
			this.lbl_header.BackColor = System.Drawing.Color.DarkCyan;
			this.lbl_header.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbl_header.ForeColor = System.Drawing.SystemColors.ControlLightLight;
			this.lbl_header.Location = new System.Drawing.Point(5, 17);
			this.lbl_header.Name = "lbl_header";
			this.lbl_header.Size = new System.Drawing.Size(1000, 23);
			this.lbl_header.TabIndex = 138;
			this.lbl_header.Text = "SHIPPING";
			this.lbl_header.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// grpbox_ship
			// 
			this.grpbox_ship.Controls.Add(this.cbx_container_size);
			this.grpbox_ship.Controls.Add(this.txtbx_container_size);
			this.grpbox_ship.Controls.Add(this.txtbx_sales_inv_no);
			this.grpbox_ship.Controls.Add(this.txtbx_so_no);
			this.grpbox_ship.Controls.Add(this.txtbx_forwarder);
			this.grpbox_ship.Controls.Add(this.lbl_forwarder);
			this.grpbox_ship.Controls.Add(this.txtbx_cust);
			this.grpbox_ship.Controls.Add(this.lbl_so_no);
			this.grpbox_ship.Controls.Add(this.lbl_sales_inv_no);
			this.grpbox_ship.Controls.Add(this.lbl_cust);
			this.grpbox_ship.Controls.Add(this.dtp_exp_arrival);
			this.grpbox_ship.Controls.Add(this.dtp_exp_delivery);
			this.grpbox_ship.Controls.Add(this.lbl_container_type);
			this.grpbox_ship.Controls.Add(this.cbx_container_type);
			this.grpbox_ship.Controls.Add(this.lbl_container_size);
			this.grpbox_ship.Controls.Add(this.txtbx_ship_code);
			this.grpbox_ship.Controls.Add(this.lbl_exp_arrival);
			this.grpbox_ship.Controls.Add(this.lbl_exp_delivery);
			this.grpbox_ship.Controls.Add(this.lbl_ship_code);
			this.grpbox_ship.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.grpbox_ship.Location = new System.Drawing.Point(13, 90);
			this.grpbox_ship.Name = "grpbox_ship";
			this.grpbox_ship.Size = new System.Drawing.Size(1027, 194);
			this.grpbox_ship.TabIndex = 1;
			this.grpbox_ship.TabStop = false;
			this.grpbox_ship.Text = "Shipping";
			// 
			// cbx_container_size
			// 
			this.cbx_container_size.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
			this.cbx_container_size.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
			this.cbx_container_size.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.cbx_container_size.FormattingEnabled = true;
			this.cbx_container_size.Location = new System.Drawing.Point(340, 154);
			this.cbx_container_size.Margin = new System.Windows.Forms.Padding(1);
			this.cbx_container_size.Name = "cbx_container_size";
			this.cbx_container_size.Size = new System.Drawing.Size(127, 26);
			this.cbx_container_size.TabIndex = 67;
			// 
			// txtbx_container_size
			// 
			this.txtbx_container_size.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtbx_container_size.Location = new System.Drawing.Point(149, 154);
			this.txtbx_container_size.Name = "txtbx_container_size";
			this.txtbx_container_size.Size = new System.Drawing.Size(187, 26);
			this.txtbx_container_size.TabIndex = 66;
			// 
			// txtbx_sales_inv_no
			// 
			this.txtbx_sales_inv_no.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtbx_sales_inv_no.Location = new System.Drawing.Point(638, 123);
			this.txtbx_sales_inv_no.Name = "txtbx_sales_inv_no";
			this.txtbx_sales_inv_no.Size = new System.Drawing.Size(369, 26);
			this.txtbx_sales_inv_no.TabIndex = 8;
			// 
			// txtbx_so_no
			// 
			this.txtbx_so_no.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtbx_so_no.Location = new System.Drawing.Point(638, 93);
			this.txtbx_so_no.Name = "txtbx_so_no";
			this.txtbx_so_no.Size = new System.Drawing.Size(369, 26);
			this.txtbx_so_no.TabIndex = 7;
			// 
			// txtbx_forwarder
			// 
			this.txtbx_forwarder.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtbx_forwarder.Location = new System.Drawing.Point(638, 63);
			this.txtbx_forwarder.Name = "txtbx_forwarder";
			this.txtbx_forwarder.Size = new System.Drawing.Size(369, 26);
			this.txtbx_forwarder.TabIndex = 6;
			// 
			// lbl_forwarder
			// 
			this.lbl_forwarder.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbl_forwarder.Location = new System.Drawing.Point(497, 62);
			this.lbl_forwarder.Name = "lbl_forwarder";
			this.lbl_forwarder.Size = new System.Drawing.Size(107, 26);
			this.lbl_forwarder.TabIndex = 65;
			this.lbl_forwarder.Text = "Forwarder";
			this.lbl_forwarder.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtbx_cust
			// 
			this.txtbx_cust.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtbx_cust.Location = new System.Drawing.Point(638, 33);
			this.txtbx_cust.Name = "txtbx_cust";
			this.txtbx_cust.Size = new System.Drawing.Size(369, 26);
			this.txtbx_cust.TabIndex = 5;
			// 
			// lbl_so_no
			// 
			this.lbl_so_no.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbl_so_no.Location = new System.Drawing.Point(497, 93);
			this.lbl_so_no.Name = "lbl_so_no";
			this.lbl_so_no.Size = new System.Drawing.Size(133, 26);
			this.lbl_so_no.TabIndex = 63;
			this.lbl_so_no.Text = "Sales Order No";
			this.lbl_so_no.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lbl_sales_inv_no
			// 
			this.lbl_sales_inv_no.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbl_sales_inv_no.Location = new System.Drawing.Point(497, 121);
			this.lbl_sales_inv_no.Name = "lbl_sales_inv_no";
			this.lbl_sales_inv_no.Size = new System.Drawing.Size(128, 26);
			this.lbl_sales_inv_no.TabIndex = 60;
			this.lbl_sales_inv_no.Text = "Sales Invoice No";
			this.lbl_sales_inv_no.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lbl_cust
			// 
			this.lbl_cust.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbl_cust.Location = new System.Drawing.Point(497, 33);
			this.lbl_cust.Name = "lbl_cust";
			this.lbl_cust.Size = new System.Drawing.Size(107, 26);
			this.lbl_cust.TabIndex = 59;
			this.lbl_cust.Text = "Customer";
			this.lbl_cust.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// dtp_exp_arrival
			// 
			this.dtp_exp_arrival.CustomFormat = "";
			this.dtp_exp_arrival.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.dtp_exp_arrival.Location = new System.Drawing.Point(149, 93);
			this.dtp_exp_arrival.Margin = new System.Windows.Forms.Padding(1);
			this.dtp_exp_arrival.Name = "dtp_exp_arrival";
			this.dtp_exp_arrival.Size = new System.Drawing.Size(318, 26);
			this.dtp_exp_arrival.TabIndex = 2;
			// 
			// dtp_exp_delivery
			// 
			this.dtp_exp_delivery.CustomFormat = "";
			this.dtp_exp_delivery.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.dtp_exp_delivery.Location = new System.Drawing.Point(149, 62);
			this.dtp_exp_delivery.Margin = new System.Windows.Forms.Padding(1);
			this.dtp_exp_delivery.Name = "dtp_exp_delivery";
			this.dtp_exp_delivery.Size = new System.Drawing.Size(318, 26);
			this.dtp_exp_delivery.TabIndex = 1;
			// 
			// lbl_container_type
			// 
			this.lbl_container_type.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbl_container_type.Location = new System.Drawing.Point(7, 122);
			this.lbl_container_type.Name = "lbl_container_type";
			this.lbl_container_type.Size = new System.Drawing.Size(133, 26);
			this.lbl_container_type.TabIndex = 55;
			this.lbl_container_type.Text = "Container Type";
			this.lbl_container_type.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// cbx_container_type
			// 
			this.cbx_container_type.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
			this.cbx_container_type.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
			this.cbx_container_type.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.cbx_container_type.FormattingEnabled = true;
			this.cbx_container_type.Location = new System.Drawing.Point(149, 123);
			this.cbx_container_type.Margin = new System.Windows.Forms.Padding(1);
			this.cbx_container_type.Name = "cbx_container_type";
			this.cbx_container_type.Size = new System.Drawing.Size(318, 26);
			this.cbx_container_type.TabIndex = 3;
			// 
			// lbl_container_size
			// 
			this.lbl_container_size.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbl_container_size.Location = new System.Drawing.Point(7, 153);
			this.lbl_container_size.Name = "lbl_container_size";
			this.lbl_container_size.Size = new System.Drawing.Size(128, 26);
			this.lbl_container_size.TabIndex = 47;
			this.lbl_container_size.Text = "Container Size";
			this.lbl_container_size.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtbx_ship_code
			// 
			this.txtbx_ship_code.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtbx_ship_code.Location = new System.Drawing.Point(149, 32);
			this.txtbx_ship_code.Name = "txtbx_ship_code";
			this.txtbx_ship_code.ReadOnly = true;
			this.txtbx_ship_code.Size = new System.Drawing.Size(318, 26);
			this.txtbx_ship_code.TabIndex = 1;
			this.txtbx_ship_code.TabStop = false;
			// 
			// lbl_exp_arrival
			// 
			this.lbl_exp_arrival.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbl_exp_arrival.Location = new System.Drawing.Point(8, 92);
			this.lbl_exp_arrival.Name = "lbl_exp_arrival";
			this.lbl_exp_arrival.Size = new System.Drawing.Size(133, 26);
			this.lbl_exp_arrival.TabIndex = 42;
			this.lbl_exp_arrival.Text = "Expected Arrival";
			this.lbl_exp_arrival.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lbl_exp_delivery
			// 
			this.lbl_exp_delivery.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbl_exp_delivery.Location = new System.Drawing.Point(8, 61);
			this.lbl_exp_delivery.Name = "lbl_exp_delivery";
			this.lbl_exp_delivery.Size = new System.Drawing.Size(144, 26);
			this.lbl_exp_delivery.TabIndex = 33;
			this.lbl_exp_delivery.Text = "Expected Delivery";
			this.lbl_exp_delivery.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lbl_ship_code
			// 
			this.lbl_ship_code.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbl_ship_code.Location = new System.Drawing.Point(8, 33);
			this.lbl_ship_code.Name = "lbl_ship_code";
			this.lbl_ship_code.Size = new System.Drawing.Size(133, 26);
			this.lbl_ship_code.TabIndex = 26;
			this.lbl_ship_code.Text = "Shipping Code";
			this.lbl_ship_code.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// btn_cancel
			// 
			this.btn_cancel.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.btn_cancel.BackColor = System.Drawing.Color.Silver;
			this.btn_cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btn_cancel.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_cancel.Location = new System.Drawing.Point(562, 606);
			this.btn_cancel.Name = "btn_cancel";
			this.btn_cancel.Size = new System.Drawing.Size(120, 27);
			this.btn_cancel.TabIndex = 146;
			this.btn_cancel.Text = "Cancel";
			this.btn_cancel.UseVisualStyleBackColor = false;
			this.btn_cancel.Click += new System.EventHandler(this.Btn_cancelClick);
			// 
			// btn_clear
			// 
			this.btn_clear.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.btn_clear.BackColor = System.Drawing.Color.Silver;
			this.btn_clear.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_clear.Location = new System.Drawing.Point(436, 606);
			this.btn_clear.Name = "btn_clear";
			this.btn_clear.Size = new System.Drawing.Size(120, 27);
			this.btn_clear.TabIndex = 145;
			this.btn_clear.Text = "Clear";
			this.btn_clear.UseVisualStyleBackColor = false;
			this.btn_clear.Click += new System.EventHandler(this.Btn_clearClick);
			// 
			// btn_save
			// 
			this.btn_save.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.btn_save.BackColor = System.Drawing.Color.Silver;
			this.btn_save.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_save.Location = new System.Drawing.Point(310, 606);
			this.btn_save.Name = "btn_save";
			this.btn_save.Size = new System.Drawing.Size(120, 27);
			this.btn_save.TabIndex = 144;
			this.btn_save.Text = "Save";
			this.btn_save.UseVisualStyleBackColor = false;
			this.btn_save.Click += new System.EventHandler(this.Btn_saveClick);
			// 
			// btn_del
			// 
			this.btn_del.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.btn_del.BackColor = System.Drawing.Color.Silver;
			this.btn_del.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_del.Location = new System.Drawing.Point(310, 606);
			this.btn_del.Name = "btn_del";
			this.btn_del.Size = new System.Drawing.Size(120, 27);
			this.btn_del.TabIndex = 147;
			this.btn_del.Text = "Delete";
			this.btn_del.UseVisualStyleBackColor = false;
			this.btn_del.Click += new System.EventHandler(this.Btn_delClick);
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(428, 636);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(100, 23);
			this.label2.TabIndex = 148;
			// 
			// groupBx_record
			// 
			this.groupBx_record.Controls.Add(this.dt_grid);
			this.groupBx_record.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.groupBx_record.Location = new System.Drawing.Point(13, 289);
			this.groupBx_record.Name = "groupBx_record";
			this.groupBx_record.Size = new System.Drawing.Size(1027, 286);
			this.groupBx_record.TabIndex = 150;
			this.groupBx_record.TabStop = false;
			this.groupBx_record.Text = "Record Saved";
			// 
			// dt_grid
			// 
			this.dt_grid.AllowUserToAddRows = false;
			this.dt_grid.AllowUserToDeleteRows = false;
			this.dt_grid.AllowUserToResizeRows = false;
			dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			this.dt_grid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
			this.dt_grid.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.dt_grid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.dt_grid.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
			this.dt_grid.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.dt_grid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
			dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle2.BackColor = System.Drawing.Color.WhiteSmoke;
			dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.dt_grid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
			this.dt_grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dt_grid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke;
			this.dt_grid.EnableHeadersVisualStyles = false;
			this.dt_grid.Location = new System.Drawing.Point(17, 32);
			this.dt_grid.MultiSelect = false;
			this.dt_grid.Name = "dt_grid";
			this.dt_grid.ReadOnly = true;
			this.dt_grid.RowHeadersVisible = false;
			this.dt_grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dt_grid.Size = new System.Drawing.Size(990, 233);
			this.dt_grid.TabIndex = 131;
			this.dt_grid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Dt_gridCellClick);
			// 
			// frm_prod_shipping
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.AutoScroll = true;
			this.CancelButton = this.btn_cancel;
			this.ClientSize = new System.Drawing.Size(1069, 662);
			this.Controls.Add(this.groupBx_record);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.btn_cancel);
			this.Controls.Add(this.btn_clear);
			this.Controls.Add(this.grpbox_ship);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.lbl_header);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.btn_save);
			this.Controls.Add(this.btn_del);
			this.Name = "frm_prod_shipping";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Shipping";
			this.Load += new System.EventHandler(this.Frm_prod_shippingLoad);
			this.panel2.ResumeLayout(false);
			this.grpbox_ship.ResumeLayout(false);
			this.grpbox_ship.PerformLayout();
			this.groupBx_record.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dt_grid)).EndInit();
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.ComboBox cbx_container_size;
		private System.Windows.Forms.TextBox txtbx_container_size;
		private System.Windows.Forms.TextBox txtbx_so_no;
		private System.Windows.Forms.TextBox txtbx_sales_inv_no;
		private System.Windows.Forms.DateTimePicker dtp_exp_delivery;
		private System.Windows.Forms.DateTimePicker dtp_exp_arrival;
		private System.Windows.Forms.Label lbl_cust;
		private System.Windows.Forms.Label lbl_sales_inv_no;
		private System.Windows.Forms.Label lbl_so_no;
		private System.Windows.Forms.TextBox txtbx_cust;
		private System.Windows.Forms.Label lbl_forwarder;
		private System.Windows.Forms.TextBox txtbx_forwarder;
		private System.Windows.Forms.Label lbl_container_type;
		private System.Windows.Forms.ComboBox cbx_container_type;
		private System.Windows.Forms.DataGridView dt_grid;
		private System.Windows.Forms.GroupBox groupBx_record;
		private System.Windows.Forms.Label lbl_container_size;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button btn_del;
		private System.Windows.Forms.Button btn_save;
		private System.Windows.Forms.Button btn_clear;
		private System.Windows.Forms.Button btn_cancel;
		private System.Windows.Forms.TextBox txtbx_ship_code;
		private System.Windows.Forms.Label lbl_exp_arrival;
		private System.Windows.Forms.Label lbl_ship_code;
		private System.Windows.Forms.Label lbl_exp_delivery;
		private System.Windows.Forms.GroupBox grpbox_ship;
		private System.Windows.Forms.Label lbl_header;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label lbl_username;
		private System.Windows.Forms.Panel panel2;
		
	
	}
}

