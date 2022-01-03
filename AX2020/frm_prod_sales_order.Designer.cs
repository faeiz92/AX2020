/*
 * Created by SharpDevelop.
 * User: ax2020-1
 * Date: 2/20/2017
 * Time: 4:09 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace AX2020
{
	partial class frm_prod_sales_order
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
			this.grpbox_sales = new System.Windows.Forms.GroupBox();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.lbl_info_3 = new System.Windows.Forms.Label();
			this.txtbx_info_3 = new System.Windows.Forms.TextBox();
			this.lbl_info_2 = new System.Windows.Forms.Label();
			this.dtp_etd = new System.Windows.Forms.DateTimePicker();
			this.txtbx_cust = new System.Windows.Forms.TextBox();
			this.txtbx_cust_po = new System.Windows.Forms.TextBox();
			this.txtbx_info_2 = new System.Windows.Forms.TextBox();
			this.lbl_info_1 = new System.Windows.Forms.Label();
			this.txtbx_info_1 = new System.Windows.Forms.TextBox();
			this.lbl_etd = new System.Windows.Forms.Label();
			this.txtbx_unit_ordered = new System.Windows.Forms.TextBox();
			this.lbl_unit_ordered = new System.Windows.Forms.Label();
			this.lbl_customer_po = new System.Windows.Forms.Label();
			this.lbl_customer = new System.Windows.Forms.Label();
			this.dtp_so_date = new System.Windows.Forms.DateTimePicker();
			this.lbl_so_date = new System.Windows.Forms.Label();
			this.btn_cancel = new System.Windows.Forms.Button();
			this.btn_clear = new System.Windows.Forms.Button();
			this.btn_save = new System.Windows.Forms.Button();
			this.btn_del = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.groupBx_record = new System.Windows.Forms.GroupBox();
			this.dt_grid = new System.Windows.Forms.DataGridView();
			this.txtbx_so = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.btn_search = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.txt_pcore = new System.Windows.Forms.RichTextBox();
			this.txtbx_ctn = new System.Windows.Forms.RichTextBox();
			this.txtbx_att_so = new System.Windows.Forms.RichTextBox();
			this.btn_choose_file_other_3 = new System.Windows.Forms.Button();
			this.btn_choose_file_other_2 = new System.Windows.Forms.Button();
			this.btn_choose_file_other_1 = new System.Windows.Forms.Button();
			this.btn_choose_file_shipmark = new System.Windows.Forms.Button();
			this.btn_choose_file_pcore = new System.Windows.Forms.Button();
			this.btn_choose_file_ctn = new System.Windows.Forms.Button();
			this.btn_choose_file_so = new System.Windows.Forms.Button();
			this.lbl_other_3 = new System.Windows.Forms.Label();
			this.lbl_other_2 = new System.Windows.Forms.Label();
			this.lbl_other_1 = new System.Windows.Forms.Label();
			this.lbl_shipmark = new System.Windows.Forms.Label();
			this.lbl_att_papercore = new System.Windows.Forms.Label();
			this.lbl_att_ctn = new System.Windows.Forms.Label();
			this.lbl_att_so = new System.Windows.Forms.Label();
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.panel2.SuspendLayout();
			this.grpbox_sales.SuspendLayout();
			this.groupBx_record.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dt_grid)).BeginInit();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel2
			// 
			this.panel2.BackColor = System.Drawing.Color.Gainsboro;
			this.panel2.Controls.Add(this.lbl_username);
			this.panel2.Location = new System.Drawing.Point(0, 51);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(984, 23);
			this.panel2.TabIndex = 141;
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
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(966, 52);
			this.panel1.TabIndex = 139;
			// 
			// lbl_header
			// 
			this.lbl_header.BackColor = System.Drawing.Color.DarkCyan;
			this.lbl_header.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbl_header.ForeColor = System.Drawing.SystemColors.ControlLightLight;
			this.lbl_header.Location = new System.Drawing.Point(5, 17);
			this.lbl_header.Name = "lbl_header";
			this.lbl_header.Size = new System.Drawing.Size(959, 23);
			this.lbl_header.TabIndex = 138;
			this.lbl_header.Text = "SALES ORDER CONFIRMATION";
			this.lbl_header.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// grpbox_sales
			// 
			this.grpbox_sales.Controls.Add(this.textBox2);
			this.grpbox_sales.Controls.Add(this.textBox1);
			this.grpbox_sales.Controls.Add(this.lbl_info_3);
			this.grpbox_sales.Controls.Add(this.txtbx_info_3);
			this.grpbox_sales.Controls.Add(this.lbl_info_2);
			this.grpbox_sales.Controls.Add(this.dtp_etd);
			this.grpbox_sales.Controls.Add(this.txtbx_cust);
			this.grpbox_sales.Controls.Add(this.txtbx_cust_po);
			this.grpbox_sales.Controls.Add(this.txtbx_info_2);
			this.grpbox_sales.Controls.Add(this.lbl_info_1);
			this.grpbox_sales.Controls.Add(this.txtbx_info_1);
			this.grpbox_sales.Controls.Add(this.lbl_etd);
			this.grpbox_sales.Controls.Add(this.txtbx_unit_ordered);
			this.grpbox_sales.Controls.Add(this.lbl_unit_ordered);
			this.grpbox_sales.Controls.Add(this.lbl_customer_po);
			this.grpbox_sales.Controls.Add(this.lbl_customer);
			this.grpbox_sales.Controls.Add(this.dtp_so_date);
			this.grpbox_sales.Controls.Add(this.lbl_so_date);
			this.grpbox_sales.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.grpbox_sales.Location = new System.Drawing.Point(12, 134);
			this.grpbox_sales.Name = "grpbox_sales";
			this.grpbox_sales.Size = new System.Drawing.Size(949, 296);
			this.grpbox_sales.TabIndex = 1;
			this.grpbox_sales.TabStop = false;
			this.grpbox_sales.Text = "Sales Order";
			// 
			// textBox2
			// 
			this.textBox2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.textBox2.Location = new System.Drawing.Point(677, 92);
			this.textBox2.Name = "textBox2";
			this.textBox2.Size = new System.Drawing.Size(114, 26);
			this.textBox2.TabIndex = 67;
			// 
			// textBox1
			// 
			this.textBox1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.textBox1.Location = new System.Drawing.Point(455, 92);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(215, 26);
			this.textBox1.TabIndex = 66;
			// 
			// lbl_info_3
			// 
			this.lbl_info_3.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbl_info_3.Location = new System.Drawing.Point(8, 249);
			this.lbl_info_3.Name = "lbl_info_3";
			this.lbl_info_3.Size = new System.Drawing.Size(116, 26);
			this.lbl_info_3.TabIndex = 65;
			this.lbl_info_3.Text = "Info 3";
			this.lbl_info_3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtbx_info_3
			// 
			this.txtbx_info_3.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtbx_info_3.Location = new System.Drawing.Point(121, 249);
			this.txtbx_info_3.Name = "txtbx_info_3";
			this.txtbx_info_3.Size = new System.Drawing.Size(810, 26);
			this.txtbx_info_3.TabIndex = 64;
			// 
			// lbl_info_2
			// 
			this.lbl_info_2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbl_info_2.Location = new System.Drawing.Point(8, 217);
			this.lbl_info_2.Name = "lbl_info_2";
			this.lbl_info_2.Size = new System.Drawing.Size(116, 26);
			this.lbl_info_2.TabIndex = 63;
			this.lbl_info_2.Text = "Info 2";
			this.lbl_info_2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// dtp_etd
			// 
			this.dtp_etd.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.dtp_etd.Location = new System.Drawing.Point(121, 154);
			this.dtp_etd.Name = "dtp_etd";
			this.dtp_etd.Size = new System.Drawing.Size(328, 26);
			this.dtp_etd.TabIndex = 62;
			// 
			// txtbx_cust
			// 
			this.txtbx_cust.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtbx_cust.Location = new System.Drawing.Point(121, 58);
			this.txtbx_cust.Name = "txtbx_cust";
			this.txtbx_cust.Size = new System.Drawing.Size(328, 26);
			this.txtbx_cust.TabIndex = 61;
			// 
			// txtbx_cust_po
			// 
			this.txtbx_cust_po.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtbx_cust_po.Location = new System.Drawing.Point(121, 90);
			this.txtbx_cust_po.Name = "txtbx_cust_po";
			this.txtbx_cust_po.Size = new System.Drawing.Size(328, 26);
			this.txtbx_cust_po.TabIndex = 60;
			// 
			// txtbx_info_2
			// 
			this.txtbx_info_2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtbx_info_2.Location = new System.Drawing.Point(121, 217);
			this.txtbx_info_2.Name = "txtbx_info_2";
			this.txtbx_info_2.Size = new System.Drawing.Size(810, 26);
			this.txtbx_info_2.TabIndex = 6;
			// 
			// lbl_info_1
			// 
			this.lbl_info_1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbl_info_1.Location = new System.Drawing.Point(8, 188);
			this.lbl_info_1.Name = "lbl_info_1";
			this.lbl_info_1.Size = new System.Drawing.Size(116, 26);
			this.lbl_info_1.TabIndex = 53;
			this.lbl_info_1.Text = "Info 1";
			this.lbl_info_1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtbx_info_1
			// 
			this.txtbx_info_1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtbx_info_1.Location = new System.Drawing.Point(121, 185);
			this.txtbx_info_1.Name = "txtbx_info_1";
			this.txtbx_info_1.Size = new System.Drawing.Size(810, 26);
			this.txtbx_info_1.TabIndex = 5;
			// 
			// lbl_etd
			// 
			this.lbl_etd.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbl_etd.Location = new System.Drawing.Point(8, 154);
			this.lbl_etd.Name = "lbl_etd";
			this.lbl_etd.Size = new System.Drawing.Size(112, 26);
			this.lbl_etd.TabIndex = 51;
			this.lbl_etd.Text = "ETD";
			this.lbl_etd.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtbx_unit_ordered
			// 
			this.txtbx_unit_ordered.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtbx_unit_ordered.Location = new System.Drawing.Point(121, 122);
			this.txtbx_unit_ordered.Name = "txtbx_unit_ordered";
			this.txtbx_unit_ordered.Size = new System.Drawing.Size(328, 26);
			this.txtbx_unit_ordered.TabIndex = 4;
			// 
			// lbl_unit_ordered
			// 
			this.lbl_unit_ordered.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbl_unit_ordered.Location = new System.Drawing.Point(8, 122);
			this.lbl_unit_ordered.Name = "lbl_unit_ordered";
			this.lbl_unit_ordered.Size = new System.Drawing.Size(116, 26);
			this.lbl_unit_ordered.TabIndex = 49;
			this.lbl_unit_ordered.Text = "Unit Ordered";
			this.lbl_unit_ordered.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lbl_customer_po
			// 
			this.lbl_customer_po.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbl_customer_po.Location = new System.Drawing.Point(8, 91);
			this.lbl_customer_po.Name = "lbl_customer_po";
			this.lbl_customer_po.Size = new System.Drawing.Size(110, 26);
			this.lbl_customer_po.TabIndex = 42;
			this.lbl_customer_po.Text = "Customer P/O";
			this.lbl_customer_po.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lbl_customer
			// 
			this.lbl_customer.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbl_customer.Location = new System.Drawing.Point(8, 59);
			this.lbl_customer.Name = "lbl_customer";
			this.lbl_customer.Size = new System.Drawing.Size(110, 26);
			this.lbl_customer.TabIndex = 33;
			this.lbl_customer.Text = "Customer";
			this.lbl_customer.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// dtp_so_date
			// 
			this.dtp_so_date.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.dtp_so_date.Location = new System.Drawing.Point(121, 27);
			this.dtp_so_date.Name = "dtp_so_date";
			this.dtp_so_date.Size = new System.Drawing.Size(328, 26);
			this.dtp_so_date.TabIndex = 7;
			// 
			// lbl_so_date
			// 
			this.lbl_so_date.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbl_so_date.Location = new System.Drawing.Point(8, 27);
			this.lbl_so_date.Name = "lbl_so_date";
			this.lbl_so_date.Size = new System.Drawing.Size(107, 26);
			this.lbl_so_date.TabIndex = 26;
			this.lbl_so_date.Text = "S/O Date";
			this.lbl_so_date.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// btn_cancel
			// 
			this.btn_cancel.BackColor = System.Drawing.Color.Silver;
			this.btn_cancel.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_cancel.Location = new System.Drawing.Point(577, 1044);
			this.btn_cancel.Name = "btn_cancel";
			this.btn_cancel.Size = new System.Drawing.Size(120, 27);
			this.btn_cancel.TabIndex = 146;
			this.btn_cancel.Text = "Cancel";
			this.btn_cancel.UseVisualStyleBackColor = false;
			this.btn_cancel.Click += new System.EventHandler(this.Btn_cancelClick);
			// 
			// btn_clear
			// 
			this.btn_clear.BackColor = System.Drawing.Color.Silver;
			this.btn_clear.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_clear.Location = new System.Drawing.Point(451, 1044);
			this.btn_clear.Name = "btn_clear";
			this.btn_clear.Size = new System.Drawing.Size(120, 27);
			this.btn_clear.TabIndex = 145;
			this.btn_clear.Text = "Clear";
			this.btn_clear.UseVisualStyleBackColor = false;
			this.btn_clear.Click += new System.EventHandler(this.Btn_clearClick);
			// 
			// btn_save
			// 
			this.btn_save.BackColor = System.Drawing.Color.Silver;
			this.btn_save.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_save.Location = new System.Drawing.Point(325, 1044);
			this.btn_save.Name = "btn_save";
			this.btn_save.Size = new System.Drawing.Size(120, 27);
			this.btn_save.TabIndex = 144;
			this.btn_save.Text = "Save";
			this.btn_save.UseVisualStyleBackColor = false;
			this.btn_save.Click += new System.EventHandler(this.Btn_saveClick);
			// 
			// btn_del
			// 
			this.btn_del.BackColor = System.Drawing.Color.Silver;
			this.btn_del.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_del.Location = new System.Drawing.Point(326, 1043);
			this.btn_del.Name = "btn_del";
			this.btn_del.Size = new System.Drawing.Size(120, 27);
			this.btn_del.TabIndex = 147;
			this.btn_del.Text = "Delete";
			this.btn_del.UseVisualStyleBackColor = false;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(435, 1103);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(100, 23);
			this.label2.TabIndex = 148;
			// 
			// groupBx_record
			// 
			this.groupBx_record.Controls.Add(this.dt_grid);
			this.groupBx_record.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.groupBx_record.Location = new System.Drawing.Point(12, 735);
			this.groupBx_record.Name = "groupBx_record";
			this.groupBx_record.Size = new System.Drawing.Size(949, 286);
			this.groupBx_record.TabIndex = 149;
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
			this.dt_grid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.dt_grid.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
			this.dt_grid.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.dt_grid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
			dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
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
			this.dt_grid.Location = new System.Drawing.Point(17, 32);
			this.dt_grid.MultiSelect = false;
			this.dt_grid.Name = "dt_grid";
			this.dt_grid.ReadOnly = true;
			this.dt_grid.RowHeadersVisible = false;
			this.dt_grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dt_grid.Size = new System.Drawing.Size(914, 233);
			this.dt_grid.TabIndex = 131;
			// 
			// txtbx_so
			// 
			this.txtbx_so.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtbx_so.Location = new System.Drawing.Point(133, 97);
			this.txtbx_so.Name = "txtbx_so";
			this.txtbx_so.Size = new System.Drawing.Size(328, 26);
			this.txtbx_so.TabIndex = 150;
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(14, 97);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(116, 26);
			this.label1.TabIndex = 68;
			this.label1.Text = "Sales Order";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// btn_search
			// 
			this.btn_search.BackColor = System.Drawing.Color.Silver;
			this.btn_search.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_search.Location = new System.Drawing.Point(467, 97);
			this.btn_search.Name = "btn_search";
			this.btn_search.Size = new System.Drawing.Size(120, 27);
			this.btn_search.TabIndex = 151;
			this.btn_search.Text = "Search";
			this.btn_search.UseVisualStyleBackColor = false;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.txt_pcore);
			this.groupBox1.Controls.Add(this.txtbx_ctn);
			this.groupBox1.Controls.Add(this.txtbx_att_so);
			this.groupBox1.Controls.Add(this.btn_choose_file_other_3);
			this.groupBox1.Controls.Add(this.btn_choose_file_other_2);
			this.groupBox1.Controls.Add(this.btn_choose_file_other_1);
			this.groupBox1.Controls.Add(this.btn_choose_file_shipmark);
			this.groupBox1.Controls.Add(this.btn_choose_file_pcore);
			this.groupBox1.Controls.Add(this.btn_choose_file_ctn);
			this.groupBox1.Controls.Add(this.btn_choose_file_so);
			this.groupBox1.Controls.Add(this.lbl_other_3);
			this.groupBox1.Controls.Add(this.lbl_other_2);
			this.groupBox1.Controls.Add(this.lbl_other_1);
			this.groupBox1.Controls.Add(this.lbl_shipmark);
			this.groupBox1.Controls.Add(this.lbl_att_papercore);
			this.groupBox1.Controls.Add(this.lbl_att_ctn);
			this.groupBox1.Controls.Add(this.lbl_att_so);
			this.groupBox1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.groupBox1.Location = new System.Drawing.Point(12, 434);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(949, 257);
			this.groupBox1.TabIndex = 68;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Attachment";
			// 
			// txt_pcore
			// 
			this.txt_pcore.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txt_pcore.Location = new System.Drawing.Point(279, 84);
			this.txt_pcore.Name = "txt_pcore";
			this.txt_pcore.Size = new System.Drawing.Size(301, 26);
			this.txt_pcore.TabIndex = 154;
			this.txt_pcore.Text = "";
			// 
			// txtbx_ctn
			// 
			this.txtbx_ctn.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtbx_ctn.Location = new System.Drawing.Point(279, 55);
			this.txtbx_ctn.Name = "txtbx_ctn";
			this.txtbx_ctn.Size = new System.Drawing.Size(301, 26);
			this.txtbx_ctn.TabIndex = 153;
			this.txtbx_ctn.Text = "";
			// 
			// txtbx_att_so
			// 
			this.txtbx_att_so.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtbx_att_so.Location = new System.Drawing.Point(279, 27);
			this.txtbx_att_so.Name = "txtbx_att_so";
			this.txtbx_att_so.Size = new System.Drawing.Size(301, 26);
			this.txtbx_att_so.TabIndex = 152;
			this.txtbx_att_so.Text = "";
			// 
			// btn_choose_file_other_3
			// 
			this.btn_choose_file_other_3.BackColor = System.Drawing.Color.Silver;
			this.btn_choose_file_other_3.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_choose_file_other_3.Location = new System.Drawing.Point(153, 200);
			this.btn_choose_file_other_3.Name = "btn_choose_file_other_3";
			this.btn_choose_file_other_3.Size = new System.Drawing.Size(120, 27);
			this.btn_choose_file_other_3.TabIndex = 151;
			this.btn_choose_file_other_3.Text = "Choose File";
			this.btn_choose_file_other_3.UseVisualStyleBackColor = false;
			// 
			// btn_choose_file_other_2
			// 
			this.btn_choose_file_other_2.BackColor = System.Drawing.Color.Silver;
			this.btn_choose_file_other_2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_choose_file_other_2.Location = new System.Drawing.Point(153, 171);
			this.btn_choose_file_other_2.Name = "btn_choose_file_other_2";
			this.btn_choose_file_other_2.Size = new System.Drawing.Size(120, 27);
			this.btn_choose_file_other_2.TabIndex = 150;
			this.btn_choose_file_other_2.Text = "Choose File";
			this.btn_choose_file_other_2.UseVisualStyleBackColor = false;
			// 
			// btn_choose_file_other_1
			// 
			this.btn_choose_file_other_1.BackColor = System.Drawing.Color.Silver;
			this.btn_choose_file_other_1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_choose_file_other_1.Location = new System.Drawing.Point(153, 142);
			this.btn_choose_file_other_1.Name = "btn_choose_file_other_1";
			this.btn_choose_file_other_1.Size = new System.Drawing.Size(120, 27);
			this.btn_choose_file_other_1.TabIndex = 149;
			this.btn_choose_file_other_1.Text = "Choose File";
			this.btn_choose_file_other_1.UseVisualStyleBackColor = false;
			// 
			// btn_choose_file_shipmark
			// 
			this.btn_choose_file_shipmark.BackColor = System.Drawing.Color.Silver;
			this.btn_choose_file_shipmark.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_choose_file_shipmark.Location = new System.Drawing.Point(153, 113);
			this.btn_choose_file_shipmark.Name = "btn_choose_file_shipmark";
			this.btn_choose_file_shipmark.Size = new System.Drawing.Size(120, 27);
			this.btn_choose_file_shipmark.TabIndex = 148;
			this.btn_choose_file_shipmark.Text = "Choose File";
			this.btn_choose_file_shipmark.UseVisualStyleBackColor = false;
			// 
			// btn_choose_file_pcore
			// 
			this.btn_choose_file_pcore.BackColor = System.Drawing.Color.Silver;
			this.btn_choose_file_pcore.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_choose_file_pcore.Location = new System.Drawing.Point(153, 84);
			this.btn_choose_file_pcore.Name = "btn_choose_file_pcore";
			this.btn_choose_file_pcore.Size = new System.Drawing.Size(120, 27);
			this.btn_choose_file_pcore.TabIndex = 147;
			this.btn_choose_file_pcore.Text = "Choose File";
			this.btn_choose_file_pcore.UseVisualStyleBackColor = false;
			// 
			// btn_choose_file_ctn
			// 
			this.btn_choose_file_ctn.BackColor = System.Drawing.Color.Silver;
			this.btn_choose_file_ctn.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_choose_file_ctn.Location = new System.Drawing.Point(153, 55);
			this.btn_choose_file_ctn.Name = "btn_choose_file_ctn";
			this.btn_choose_file_ctn.Size = new System.Drawing.Size(120, 27);
			this.btn_choose_file_ctn.TabIndex = 146;
			this.btn_choose_file_ctn.Text = "Choose File";
			this.btn_choose_file_ctn.UseVisualStyleBackColor = false;
			// 
			// btn_choose_file_so
			// 
			this.btn_choose_file_so.BackColor = System.Drawing.Color.Silver;
			this.btn_choose_file_so.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_choose_file_so.Location = new System.Drawing.Point(153, 26);
			this.btn_choose_file_so.Name = "btn_choose_file_so";
			this.btn_choose_file_so.Size = new System.Drawing.Size(120, 27);
			this.btn_choose_file_so.TabIndex = 145;
			this.btn_choose_file_so.Text = "Choose File";
			this.btn_choose_file_so.UseVisualStyleBackColor = false;
			this.btn_choose_file_so.Click += new System.EventHandler(this.Btn_choose_file_soClick);
			// 
			// lbl_other_3
			// 
			this.lbl_other_3.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbl_other_3.Location = new System.Drawing.Point(8, 201);
			this.lbl_other_3.Name = "lbl_other_3";
			this.lbl_other_3.Size = new System.Drawing.Size(116, 26);
			this.lbl_other_3.TabIndex = 65;
			this.lbl_other_3.Text = "Other 3";
			this.lbl_other_3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lbl_other_2
			// 
			this.lbl_other_2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbl_other_2.Location = new System.Drawing.Point(8, 172);
			this.lbl_other_2.Name = "lbl_other_2";
			this.lbl_other_2.Size = new System.Drawing.Size(116, 26);
			this.lbl_other_2.TabIndex = 63;
			this.lbl_other_2.Text = "Other 2";
			this.lbl_other_2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lbl_other_1
			// 
			this.lbl_other_1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbl_other_1.Location = new System.Drawing.Point(8, 143);
			this.lbl_other_1.Name = "lbl_other_1";
			this.lbl_other_1.Size = new System.Drawing.Size(116, 26);
			this.lbl_other_1.TabIndex = 53;
			this.lbl_other_1.Text = "Other 1";
			this.lbl_other_1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lbl_shipmark
			// 
			this.lbl_shipmark.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbl_shipmark.Location = new System.Drawing.Point(9, 114);
			this.lbl_shipmark.Name = "lbl_shipmark";
			this.lbl_shipmark.Size = new System.Drawing.Size(112, 26);
			this.lbl_shipmark.TabIndex = 51;
			this.lbl_shipmark.Text = "Shipping Mark";
			this.lbl_shipmark.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lbl_att_papercore
			// 
			this.lbl_att_papercore.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbl_att_papercore.Location = new System.Drawing.Point(9, 84);
			this.lbl_att_papercore.Name = "lbl_att_papercore";
			this.lbl_att_papercore.Size = new System.Drawing.Size(138, 26);
			this.lbl_att_papercore.TabIndex = 49;
			this.lbl_att_papercore.Text = "Papercore Artwork";
			this.lbl_att_papercore.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lbl_att_ctn
			// 
			this.lbl_att_ctn.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbl_att_ctn.Location = new System.Drawing.Point(8, 55);
			this.lbl_att_ctn.Name = "lbl_att_ctn";
			this.lbl_att_ctn.Size = new System.Drawing.Size(110, 26);
			this.lbl_att_ctn.TabIndex = 42;
			this.lbl_att_ctn.Text = "Ctn Artwork";
			this.lbl_att_ctn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lbl_att_so
			// 
			this.lbl_att_so.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbl_att_so.Location = new System.Drawing.Point(8, 26);
			this.lbl_att_so.Name = "lbl_att_so";
			this.lbl_att_so.Size = new System.Drawing.Size(110, 26);
			this.lbl_att_so.TabIndex = 33;
			this.lbl_att_so.Text = "S/O";
			this.lbl_att_so.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// openFileDialog1
			// 
			this.openFileDialog1.FileName = ".pdf";
			this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.OpenFileDialog1FileOk);
			// 
			// frm_prod_sales_order
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.ClientSize = new System.Drawing.Size(984, 661);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.btn_search);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.txtbx_so);
			this.Controls.Add(this.groupBx_record);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.btn_cancel);
			this.Controls.Add(this.btn_clear);
			this.Controls.Add(this.btn_save);
			this.Controls.Add(this.btn_del);
			this.Controls.Add(this.grpbox_sales);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.lbl_header);
			this.Controls.Add(this.panel1);
			this.Name = "frm_prod_sales_order";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Ribbon";
			this.panel2.ResumeLayout(false);
			this.grpbox_sales.ResumeLayout(false);
			this.grpbox_sales.PerformLayout();
			this.groupBx_record.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dt_grid)).EndInit();
			this.groupBox1.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.RichTextBox txtbx_ctn;
		private System.Windows.Forms.RichTextBox txt_pcore;
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
		private System.Windows.Forms.RichTextBox txtbx_att_so;
		private System.Windows.Forms.Button btn_choose_file_other_1;
		private System.Windows.Forms.Button btn_choose_file_other_2;
		private System.Windows.Forms.Button btn_choose_file_other_3;
		private System.Windows.Forms.Button btn_choose_file_so;
		private System.Windows.Forms.Button btn_choose_file_ctn;
		private System.Windows.Forms.Button btn_choose_file_pcore;
		private System.Windows.Forms.Button btn_choose_file_shipmark;
		private System.Windows.Forms.Label lbl_att_so;
		private System.Windows.Forms.Label lbl_att_ctn;
		private System.Windows.Forms.Label lbl_att_papercore;
		private System.Windows.Forms.Label lbl_shipmark;
		private System.Windows.Forms.Label lbl_other_1;
		private System.Windows.Forms.Label lbl_other_2;
		private System.Windows.Forms.Label lbl_other_3;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Button btn_search;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtbx_so;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.Label lbl_info_2;
		private System.Windows.Forms.TextBox txtbx_info_3;
		private System.Windows.Forms.Label lbl_info_3;
		private System.Windows.Forms.TextBox txtbx_cust_po;
		private System.Windows.Forms.TextBox txtbx_cust;
		private System.Windows.Forms.DateTimePicker dtp_etd;
		private System.Windows.Forms.GroupBox groupBx_record;
		private System.Windows.Forms.DataGridView dt_grid;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button btn_del;
		private System.Windows.Forms.Button btn_save;
		private System.Windows.Forms.Button btn_clear;
		private System.Windows.Forms.Button btn_cancel;
		private System.Windows.Forms.Label lbl_unit_ordered;
		private System.Windows.Forms.TextBox txtbx_unit_ordered;
		private System.Windows.Forms.Label lbl_etd;
		private System.Windows.Forms.TextBox txtbx_info_1;
		private System.Windows.Forms.Label lbl_info_1;
		private System.Windows.Forms.TextBox txtbx_info_2;
		private System.Windows.Forms.Label lbl_customer_po;
		private System.Windows.Forms.Label lbl_so_date;
		private System.Windows.Forms.DateTimePicker dtp_so_date;
		private System.Windows.Forms.Label lbl_customer;
		private System.Windows.Forms.GroupBox grpbox_sales;
		private System.Windows.Forms.Label lbl_header;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label lbl_username;
		private System.Windows.Forms.Panel panel2;
		

	}
}
