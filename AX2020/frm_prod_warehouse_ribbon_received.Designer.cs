/*
 * Created by SharpDevelop.
 * User: ax2020-1
 * Date: 2/21/2017
 * Time: 2:01 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace AX2020
{
	partial class frm_prod_warehouse_ribbon_received
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
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
			this.panel1 = new System.Windows.Forms.Panel();
			this.lbl_header = new System.Windows.Forms.Label();
			this.grpbox_output = new System.Windows.Forms.GroupBox();
			this.lbl_qty = new System.Windows.Forms.Label();
			this.txtbx_qty = new System.Windows.Forms.TextBox();
			this.grpbox_cust = new System.Windows.Forms.GroupBox();
			this.lbl_uom = new System.Windows.Forms.Label();
			this.txtbx_uom = new System.Windows.Forms.TextBox();
			this.lbl_stock_code = new System.Windows.Forms.Label();
			this.lbl_stock_desc = new System.Windows.Forms.Label();
			this.txtbx_stock_code = new System.Windows.Forms.TextBox();
			this.txtbx_desc = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.lbl_ref_no = new System.Windows.Forms.Label();
			this.txtbx_pack_no = new System.Windows.Forms.TextBox();
			this.btn_search = new System.Windows.Forms.Button();
			this.panel2 = new System.Windows.Forms.Panel();
			this.lbl_username = new System.Windows.Forms.Label();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.txtbx_qty_received = new System.Windows.Forms.TextBox();
			this.lbl_qty_received = new System.Windows.Forms.Label();
			this.btn_cancel = new System.Windows.Forms.Button();
			this.btn_clear = new System.Windows.Forms.Button();
			this.btn_save = new System.Windows.Forms.Button();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.dt_grid = new System.Windows.Forms.DataGridView();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.dt_grid_not_received = new System.Windows.Forms.DataGridView();
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
			this.lbl_header.Text = "RIBBON STOCK RECEIVE";
			this.lbl_header.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// grpbox_output
			// 
			this.grpbox_output.Controls.Add(this.lbl_qty);
			this.grpbox_output.Controls.Add(this.txtbx_qty);
			this.grpbox_output.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.grpbox_output.Location = new System.Drawing.Point(9, 272);
			this.grpbox_output.Name = "grpbox_output";
			this.grpbox_output.Size = new System.Drawing.Size(471, 61);
			this.grpbox_output.TabIndex = 112;
			this.grpbox_output.TabStop = false;
			this.grpbox_output.Text = "Output";
			// 
			// lbl_qty
			// 
			this.lbl_qty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbl_qty.Location = new System.Drawing.Point(11, 23);
			this.lbl_qty.Name = "lbl_qty";
			this.lbl_qty.Size = new System.Drawing.Size(108, 26);
			this.lbl_qty.TabIndex = 126;
			this.lbl_qty.Text = "Quantity";
			this.lbl_qty.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtbx_qty
			// 
			this.txtbx_qty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtbx_qty.Location = new System.Drawing.Point(125, 23);
			this.txtbx_qty.Name = "txtbx_qty";
			this.txtbx_qty.ReadOnly = true;
			this.txtbx_qty.Size = new System.Drawing.Size(208, 26);
			this.txtbx_qty.TabIndex = 125;
			this.txtbx_qty.TabStop = false;
			// 
			// grpbox_cust
			// 
			this.grpbox_cust.Controls.Add(this.lbl_uom);
			this.grpbox_cust.Controls.Add(this.txtbx_uom);
			this.grpbox_cust.Controls.Add(this.lbl_stock_code);
			this.grpbox_cust.Controls.Add(this.lbl_stock_desc);
			this.grpbox_cust.Controls.Add(this.txtbx_stock_code);
			this.grpbox_cust.Controls.Add(this.txtbx_desc);
			this.grpbox_cust.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.grpbox_cust.Location = new System.Drawing.Point(9, 137);
			this.grpbox_cust.Name = "grpbox_cust";
			this.grpbox_cust.Size = new System.Drawing.Size(963, 129);
			this.grpbox_cust.TabIndex = 9;
			this.grpbox_cust.TabStop = false;
			this.grpbox_cust.Text = "Customer";
			// 
			// lbl_uom
			// 
			this.lbl_uom.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbl_uom.Location = new System.Drawing.Point(9, 90);
			this.lbl_uom.Name = "lbl_uom";
			this.lbl_uom.Size = new System.Drawing.Size(108, 26);
			this.lbl_uom.TabIndex = 116;
			this.lbl_uom.Text = "UOM";
			this.lbl_uom.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtbx_uom
			// 
			this.txtbx_uom.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtbx_uom.Location = new System.Drawing.Point(123, 90);
			this.txtbx_uom.Name = "txtbx_uom";
			this.txtbx_uom.ReadOnly = true;
			this.txtbx_uom.Size = new System.Drawing.Size(208, 26);
			this.txtbx_uom.TabIndex = 17;
			this.txtbx_uom.TabStop = false;
			// 
			// lbl_stock_code
			// 
			this.lbl_stock_code.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbl_stock_code.Location = new System.Drawing.Point(8, 23);
			this.lbl_stock_code.Name = "lbl_stock_code";
			this.lbl_stock_code.Size = new System.Drawing.Size(109, 26);
			this.lbl_stock_code.TabIndex = 110;
			this.lbl_stock_code.Text = "Stock Code";
			this.lbl_stock_code.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lbl_stock_desc
			// 
			this.lbl_stock_desc.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbl_stock_desc.Location = new System.Drawing.Point(8, 55);
			this.lbl_stock_desc.Name = "lbl_stock_desc";
			this.lbl_stock_desc.Size = new System.Drawing.Size(112, 26);
			this.lbl_stock_desc.TabIndex = 109;
			this.lbl_stock_desc.Text = "Stock Desc";
			this.lbl_stock_desc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtbx_stock_code
			// 
			this.txtbx_stock_code.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtbx_stock_code.Location = new System.Drawing.Point(123, 24);
			this.txtbx_stock_code.Name = "txtbx_stock_code";
			this.txtbx_stock_code.ReadOnly = true;
			this.txtbx_stock_code.Size = new System.Drawing.Size(208, 26);
			this.txtbx_stock_code.TabIndex = 10;
			this.txtbx_stock_code.TabStop = false;
			// 
			// txtbx_desc
			// 
			this.txtbx_desc.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtbx_desc.Location = new System.Drawing.Point(123, 56);
			this.txtbx_desc.Name = "txtbx_desc";
			this.txtbx_desc.ReadOnly = true;
			this.txtbx_desc.Size = new System.Drawing.Size(821, 26);
			this.txtbx_desc.TabIndex = 9;
			this.txtbx_desc.TabStop = false;
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(446, 931);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(100, 23);
			this.label4.TabIndex = 130;
			// 
			// lbl_ref_no
			// 
			this.lbl_ref_no.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbl_ref_no.Location = new System.Drawing.Point(18, 98);
			this.lbl_ref_no.Name = "lbl_ref_no";
			this.lbl_ref_no.Size = new System.Drawing.Size(143, 26);
			this.lbl_ref_no.TabIndex = 135;
			this.lbl_ref_no.Text = "Packing Number";
			this.lbl_ref_no.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtbx_pack_no
			// 
			this.txtbx_pack_no.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtbx_pack_no.Location = new System.Drawing.Point(167, 98);
			this.txtbx_pack_no.Name = "txtbx_pack_no";
			this.txtbx_pack_no.Size = new System.Drawing.Size(110, 26);
			this.txtbx_pack_no.TabIndex = 1;
			// 
			// btn_search
			// 
			this.btn_search.BackColor = System.Drawing.Color.Silver;
			this.btn_search.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_search.Location = new System.Drawing.Point(283, 96);
			this.btn_search.Name = "btn_search";
			this.btn_search.Size = new System.Drawing.Size(120, 27);
			this.btn_search.TabIndex = 2;
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
			this.panel2.Size = new System.Drawing.Size(998, 23);
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
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.txtbx_qty_received);
			this.groupBox1.Controls.Add(this.lbl_qty_received);
			this.groupBox1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.groupBox1.Location = new System.Drawing.Point(487, 272);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(485, 61);
			this.groupBox1.TabIndex = 3;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Received";
			// 
			// txtbx_qty_received
			// 
			this.txtbx_qty_received.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtbx_qty_received.Location = new System.Drawing.Point(126, 22);
			this.txtbx_qty_received.Name = "txtbx_qty_received";
			this.txtbx_qty_received.Size = new System.Drawing.Size(207, 26);
			this.txtbx_qty_received.TabIndex = 3;
			this.txtbx_qty_received.Text = "0";
			// 
			// lbl_qty_received
			// 
			this.lbl_qty_received.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbl_qty_received.Location = new System.Drawing.Point(11, 21);
			this.lbl_qty_received.Name = "lbl_qty_received";
			this.lbl_qty_received.Size = new System.Drawing.Size(114, 26);
			this.lbl_qty_received.TabIndex = 27;
			this.lbl_qty_received.Text = "Quantity";
			this.lbl_qty_received.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// btn_cancel
			// 
			this.btn_cancel.BackColor = System.Drawing.Color.Silver;
			this.btn_cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btn_cancel.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_cancel.Location = new System.Drawing.Point(558, 903);
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
			this.btn_clear.Location = new System.Drawing.Point(432, 903);
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
			this.btn_save.Location = new System.Drawing.Point(306, 904);
			this.btn_save.Name = "btn_save";
			this.btn_save.Size = new System.Drawing.Size(120, 27);
			this.btn_save.TabIndex = 4;
			this.btn_save.Text = "Save";
			this.btn_save.UseVisualStyleBackColor = false;
			this.btn_save.Click += new System.EventHandler(this.Btn_saveClick);
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.dt_grid);
			this.groupBox2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.groupBox2.Location = new System.Drawing.Point(9, 617);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(963, 268);
			this.groupBox2.TabIndex = 117;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Stock Received";
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
			dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle2.BackColor = System.Drawing.Color.WhiteSmoke;
			dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.dt_grid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
			this.dt_grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dt_grid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke;
			this.dt_grid.EnableHeadersVisualStyles = false;
			this.dt_grid.Location = new System.Drawing.Point(20, 33);
			this.dt_grid.MultiSelect = false;
			this.dt_grid.Name = "dt_grid";
			this.dt_grid.ReadOnly = true;
			this.dt_grid.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
			this.dt_grid.RowHeadersVisible = false;
			this.dt_grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dt_grid.Size = new System.Drawing.Size(921, 213);
			this.dt_grid.TabIndex = 130;
			this.dt_grid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Dt_gridCellClick);
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.dt_grid_not_received);
			this.groupBox3.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.groupBox3.Location = new System.Drawing.Point(9, 339);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(963, 268);
			this.groupBox3.TabIndex = 138;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Stock Not Yet Received";
			// 
			// dt_grid_not_received
			// 
			this.dt_grid_not_received.AllowUserToAddRows = false;
			this.dt_grid_not_received.AllowUserToDeleteRows = false;
			this.dt_grid_not_received.AllowUserToResizeRows = false;
			dataGridViewCellStyle3.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			this.dt_grid_not_received.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
			this.dt_grid_not_received.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.dt_grid_not_received.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
			this.dt_grid_not_received.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.dt_grid_not_received.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
			dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle4.BackColor = System.Drawing.Color.WhiteSmoke;
			dataGridViewCellStyle4.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.dt_grid_not_received.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
			this.dt_grid_not_received.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dt_grid_not_received.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke;
			this.dt_grid_not_received.EnableHeadersVisualStyles = false;
			this.dt_grid_not_received.Location = new System.Drawing.Point(20, 33);
			this.dt_grid_not_received.MultiSelect = false;
			this.dt_grid_not_received.Name = "dt_grid_not_received";
			this.dt_grid_not_received.ReadOnly = true;
			this.dt_grid_not_received.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
			this.dt_grid_not_received.RowHeadersVisible = false;
			this.dt_grid_not_received.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dt_grid_not_received.Size = new System.Drawing.Size(921, 213);
			this.dt_grid_not_received.TabIndex = 130;
			this.dt_grid_not_received.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Dt_grid_not_receivedCellClick);
			// 
			// frm_prod_warehouse_ribbon_received
			// 
			this.AcceptButton = this.btn_search;
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.AutoScroll = true;
			this.CancelButton = this.btn_cancel;
			this.ClientSize = new System.Drawing.Size(1001, 678);
			this.Controls.Add(this.groupBox3);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.btn_cancel);
			this.Controls.Add(this.btn_clear);
			this.Controls.Add(this.btn_save);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.lbl_ref_no);
			this.Controls.Add(this.txtbx_pack_no);
			this.Controls.Add(this.btn_search);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.grpbox_cust);
			this.Controls.Add(this.lbl_header);
			this.Controls.Add(this.grpbox_output);
			this.Controls.Add(this.panel1);
			this.Name = "frm_prod_warehouse_ribbon_received";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Ribbon Stock Receive";
			this.Load += new System.EventHandler(this.frm_prod_warehouse_ribbon_receivedLoad);
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
		private System.Windows.Forms.DataGridView dt_grid_not_received;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Label lbl_qty_received;
		private System.Windows.Forms.TextBox txtbx_qty_received;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label lbl_username;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.DataGridView dt_grid;
		private System.Windows.Forms.Button btn_save;
		private System.Windows.Forms.Button btn_clear;
		private System.Windows.Forms.Button btn_cancel;
		private System.Windows.Forms.TextBox txtbx_desc;
		private System.Windows.Forms.TextBox txtbx_stock_code;
		private System.Windows.Forms.Label lbl_stock_desc;
		private System.Windows.Forms.Label lbl_stock_code;
		private System.Windows.Forms.TextBox txtbx_uom;
		private System.Windows.Forms.Label lbl_uom;
		private System.Windows.Forms.TextBox txtbx_qty;
		private System.Windows.Forms.Label lbl_qty;
		private System.Windows.Forms.GroupBox grpbox_cust;
		private System.Windows.Forms.TextBox txtbx_pack_no;
		private System.Windows.Forms.Label lbl_ref_no;
		private System.Windows.Forms.Button btn_search;
		private System.Windows.Forms.GroupBox grpbox_output;
		private System.Windows.Forms.Label lbl_header;
		private System.Windows.Forms.Panel panel1;
		
		
		
	}
}
