/*
 * Created by SharpDevelop.
 * User: afiqah
 * Date: 11/08/2017
 * Time: 3:32 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace AX2020
{
	partial class frm_prod_warehouse_sample
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
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
			this.panel2 = new System.Windows.Forms.Panel();
			this.lbl_username = new System.Windows.Forms.Label();
			this.panel1 = new System.Windows.Forms.Panel();
			this.lbl_header = new System.Windows.Forms.Label();
			this.grpbox_output = new System.Windows.Forms.GroupBox();
			this.txtbx_ref_no = new System.Windows.Forms.TextBox();
			this.lbl_ref_no = new System.Windows.Forms.Label();
			this.txtbx_requested_by = new System.Windows.Forms.TextBox();
			this.txtbx_dept = new System.Windows.Forms.TextBox();
			this.lbl_date = new System.Windows.Forms.Label();
			this.lbl_dept = new System.Windows.Forms.Label();
			this.dtp_date = new System.Windows.Forms.DateTimePicker();
			this.lbl_requested_by = new System.Windows.Forms.Label();
			this.groupbx_consume = new System.Windows.Forms.GroupBox();
			this.panel3 = new System.Windows.Forms.Panel();
			this.dt_grid_consume = new System.Windows.Forms.DataGridView();
			this.btn_add = new System.Windows.Forms.Button();
			this.dt_grid_consume2 = new System.Windows.Forms.DataGridView();
			this.btn_cancel = new System.Windows.Forms.Button();
			this.btn_clear = new System.Windows.Forms.Button();
			this.btn_save = new System.Windows.Forms.Button();
			this.btn_del = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.groupBx_record = new System.Windows.Forms.GroupBox();
			this.dt_grid = new System.Windows.Forms.DataGridView();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.txtbx_company = new System.Windows.Forms.TextBox();
			this.cbx_purpose = new System.Windows.Forms.ComboBox();
			this.lbl_company = new System.Windows.Forms.Label();
			this.lbl_purpose = new System.Windows.Forms.Label();
			this.txtbx_dept_3 = new System.Windows.Forms.TextBox();
			this.lbl_dept_3 = new System.Windows.Forms.Label();
			this.lbl_dept_2 = new System.Windows.Forms.Label();
			this.txtbx_dept_2 = new System.Windows.Forms.TextBox();
			this.panel2.SuspendLayout();
			this.grpbox_output.SuspendLayout();
			this.groupbx_consume.SuspendLayout();
			this.panel3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dt_grid_consume)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dt_grid_consume2)).BeginInit();
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
			this.lbl_header.Text = "SAMPLE REQUEST FORM";
			this.lbl_header.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// grpbox_output
			// 
			this.grpbox_output.Controls.Add(this.txtbx_ref_no);
			this.grpbox_output.Controls.Add(this.lbl_ref_no);
			this.grpbox_output.Controls.Add(this.txtbx_requested_by);
			this.grpbox_output.Controls.Add(this.txtbx_dept);
			this.grpbox_output.Controls.Add(this.lbl_date);
			this.grpbox_output.Controls.Add(this.lbl_dept);
			this.grpbox_output.Controls.Add(this.dtp_date);
			this.grpbox_output.Controls.Add(this.lbl_requested_by);
			this.grpbox_output.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.grpbox_output.Location = new System.Drawing.Point(12, 85);
			this.grpbox_output.Name = "grpbox_output";
			this.grpbox_output.Size = new System.Drawing.Size(949, 93);
			this.grpbox_output.TabIndex = 1;
			this.grpbox_output.TabStop = false;
			this.grpbox_output.Text = "Requestor Info";
			// 
			// txtbx_ref_no
			// 
			this.txtbx_ref_no.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtbx_ref_no.Location = new System.Drawing.Point(603, 55);
			this.txtbx_ref_no.Name = "txtbx_ref_no";
			this.txtbx_ref_no.ReadOnly = true;
			this.txtbx_ref_no.Size = new System.Drawing.Size(328, 26);
			this.txtbx_ref_no.TabIndex = 65;
			// 
			// lbl_ref_no
			// 
			this.lbl_ref_no.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbl_ref_no.Location = new System.Drawing.Point(490, 56);
			this.lbl_ref_no.Name = "lbl_ref_no";
			this.lbl_ref_no.Size = new System.Drawing.Size(110, 26);
			this.lbl_ref_no.TabIndex = 64;
			this.lbl_ref_no.Text = "Ref No";
			this.lbl_ref_no.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtbx_requested_by
			// 
			this.txtbx_requested_by.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtbx_requested_by.Location = new System.Drawing.Point(121, 24);
			this.txtbx_requested_by.Name = "txtbx_requested_by";
			this.txtbx_requested_by.Size = new System.Drawing.Size(328, 26);
			this.txtbx_requested_by.TabIndex = 63;
			// 
			// txtbx_dept
			// 
			this.txtbx_dept.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtbx_dept.Location = new System.Drawing.Point(121, 56);
			this.txtbx_dept.Name = "txtbx_dept";
			this.txtbx_dept.Size = new System.Drawing.Size(328, 26);
			this.txtbx_dept.TabIndex = 62;
			// 
			// lbl_date
			// 
			this.lbl_date.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbl_date.Location = new System.Drawing.Point(490, 25);
			this.lbl_date.Name = "lbl_date";
			this.lbl_date.Size = new System.Drawing.Size(110, 26);
			this.lbl_date.TabIndex = 40;
			this.lbl_date.Text = "Date";
			this.lbl_date.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lbl_dept
			// 
			this.lbl_dept.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbl_dept.Location = new System.Drawing.Point(8, 57);
			this.lbl_dept.Name = "lbl_dept";
			this.lbl_dept.Size = new System.Drawing.Size(110, 26);
			this.lbl_dept.TabIndex = 33;
			this.lbl_dept.Text = "Department";
			this.lbl_dept.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// dtp_date
			// 
			this.dtp_date.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.dtp_date.Location = new System.Drawing.Point(603, 25);
			this.dtp_date.Name = "dtp_date";
			this.dtp_date.Size = new System.Drawing.Size(328, 26);
			this.dtp_date.TabIndex = 7;
			// 
			// lbl_requested_by
			// 
			this.lbl_requested_by.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbl_requested_by.Location = new System.Drawing.Point(8, 25);
			this.lbl_requested_by.Name = "lbl_requested_by";
			this.lbl_requested_by.Size = new System.Drawing.Size(107, 26);
			this.lbl_requested_by.TabIndex = 26;
			this.lbl_requested_by.Text = "Requested by";
			this.lbl_requested_by.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// groupbx_consume
			// 
			this.groupbx_consume.Controls.Add(this.panel3);
			this.groupbx_consume.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.groupbx_consume.Location = new System.Drawing.Point(12, 283);
			this.groupbx_consume.Name = "groupbx_consume";
			this.groupbx_consume.Size = new System.Drawing.Size(949, 373);
			this.groupbx_consume.TabIndex = 13;
			this.groupbx_consume.TabStop = false;
			this.groupbx_consume.Text = "Stock Requested";
			// 
			// panel3
			// 
			this.panel3.Controls.Add(this.dt_grid_consume);
			this.panel3.Controls.Add(this.btn_add);
			this.panel3.Controls.Add(this.dt_grid_consume2);
			this.panel3.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.panel3.Location = new System.Drawing.Point(13, 25);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(923, 333);
			this.panel3.TabIndex = 152;
			// 
			// dt_grid_consume
			// 
			this.dt_grid_consume.AllowUserToAddRows = false;
			this.dt_grid_consume.AllowUserToDeleteRows = false;
			this.dt_grid_consume.AllowUserToResizeRows = false;
			dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			this.dt_grid_consume.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
			this.dt_grid_consume.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.dt_grid_consume.BackgroundColor = System.Drawing.SystemColors.Control;
			this.dt_grid_consume.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.dt_grid_consume.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
			dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle2.BackColor = System.Drawing.Color.WhiteSmoke;
			dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.dt_grid_consume.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
			this.dt_grid_consume.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dt_grid_consume.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
			this.dt_grid_consume.EnableHeadersVisualStyles = false;
			this.dt_grid_consume.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.dt_grid_consume.Location = new System.Drawing.Point(6, 38);
			this.dt_grid_consume.MultiSelect = false;
			this.dt_grid_consume.Name = "dt_grid_consume";
			this.dt_grid_consume.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
			this.dt_grid_consume.RowHeadersVisible = false;
			this.dt_grid_consume.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
			this.dt_grid_consume.Size = new System.Drawing.Size(914, 292);
			this.dt_grid_consume.TabIndex = 154;
			this.dt_grid_consume.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Dt_grid_consumeCellClick);
			// 
			// btn_add
			// 
			this.btn_add.BackColor = System.Drawing.Color.Silver;
			this.btn_add.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_add.Location = new System.Drawing.Point(6, 7);
			this.btn_add.Margin = new System.Windows.Forms.Padding(1);
			this.btn_add.Name = "btn_add";
			this.btn_add.Size = new System.Drawing.Size(126, 27);
			this.btn_add.TabIndex = 152;
			this.btn_add.Text = "Add";
			this.btn_add.UseVisualStyleBackColor = false;
			this.btn_add.Click += new System.EventHandler(this.Btn_addClick);
			// 
			// dt_grid_consume2
			// 
			this.dt_grid_consume2.AllowUserToAddRows = false;
			this.dt_grid_consume2.AllowUserToDeleteRows = false;
			dataGridViewCellStyle3.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			this.dt_grid_consume2.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
			this.dt_grid_consume2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.dt_grid_consume2.BackgroundColor = System.Drawing.SystemColors.Control;
			this.dt_grid_consume2.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.dt_grid_consume2.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
			dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle4.BackColor = System.Drawing.Color.WhiteSmoke;
			dataGridViewCellStyle4.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.dt_grid_consume2.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
			this.dt_grid_consume2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dt_grid_consume2.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
			this.dt_grid_consume2.EnableHeadersVisualStyles = false;
			this.dt_grid_consume2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.dt_grid_consume2.Location = new System.Drawing.Point(1, 7);
			this.dt_grid_consume2.MultiSelect = false;
			this.dt_grid_consume2.Name = "dt_grid_consume2";
			this.dt_grid_consume2.ReadOnly = true;
			this.dt_grid_consume2.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
			this.dt_grid_consume2.RowHeadersVisible = false;
			this.dt_grid_consume2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dt_grid_consume2.Size = new System.Drawing.Size(914, 292);
			this.dt_grid_consume2.TabIndex = 153;
			this.dt_grid_consume2.VirtualMode = true;
			// 
			// btn_cancel
			// 
			this.btn_cancel.BackColor = System.Drawing.Color.Silver;
			this.btn_cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btn_cancel.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_cancel.Location = new System.Drawing.Point(577, 877);
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
			this.btn_clear.Location = new System.Drawing.Point(451, 877);
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
			this.btn_save.Location = new System.Drawing.Point(325, 877);
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
			this.btn_del.Location = new System.Drawing.Point(326, 876);
			this.btn_del.Name = "btn_del";
			this.btn_del.Size = new System.Drawing.Size(120, 27);
			this.btn_del.TabIndex = 147;
			this.btn_del.Text = "Delete";
			this.btn_del.UseVisualStyleBackColor = false;
			this.btn_del.Click += new System.EventHandler(this.Btn_delClick);
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(435, 907);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(100, 23);
			this.label2.TabIndex = 148;
			// 
			// groupBx_record
			// 
			this.groupBx_record.Controls.Add(this.dt_grid);
			this.groupBx_record.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.groupBx_record.Location = new System.Drawing.Point(12, 669);
			this.groupBx_record.Name = "groupBx_record";
			this.groupBx_record.Size = new System.Drawing.Size(949, 187);
			this.groupBx_record.TabIndex = 149;
			this.groupBx_record.TabStop = false;
			this.groupBx_record.Text = "Record Saved";
			// 
			// dt_grid
			// 
			this.dt_grid.AllowUserToAddRows = false;
			this.dt_grid.AllowUserToDeleteRows = false;
			this.dt_grid.AllowUserToResizeRows = false;
			dataGridViewCellStyle5.Font = new System.Drawing.Font("Arial", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			this.dt_grid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
			this.dt_grid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.dt_grid.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
			this.dt_grid.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.dt_grid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
			dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
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
			this.dt_grid.Location = new System.Drawing.Point(17, 32);
			this.dt_grid.MultiSelect = false;
			this.dt_grid.Name = "dt_grid";
			this.dt_grid.ReadOnly = true;
			this.dt_grid.RowHeadersVisible = false;
			this.dt_grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dt_grid.Size = new System.Drawing.Size(914, 136);
			this.dt_grid.TabIndex = 131;
			this.dt_grid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Dt_gridCellClick);
			this.dt_grid.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.Dt_gridDataBindingComplete);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.txtbx_dept_2);
			this.groupBox1.Controls.Add(this.txtbx_dept_3);
			this.groupBox1.Controls.Add(this.lbl_dept_3);
			this.groupBox1.Controls.Add(this.lbl_dept_2);
			this.groupBox1.Controls.Add(this.txtbx_company);
			this.groupBox1.Controls.Add(this.cbx_purpose);
			this.groupBox1.Controls.Add(this.lbl_company);
			this.groupBox1.Controls.Add(this.lbl_purpose);
			this.groupBox1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.groupBox1.Location = new System.Drawing.Point(12, 184);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(949, 94);
			this.groupBox1.TabIndex = 63;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Details";
			// 
			// txtbx_company
			// 
			this.txtbx_company.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtbx_company.Location = new System.Drawing.Point(121, 56);
			this.txtbx_company.Name = "txtbx_company";
			this.txtbx_company.Size = new System.Drawing.Size(328, 26);
			this.txtbx_company.TabIndex = 62;
			// 
			// cbx_purpose
			// 
			this.cbx_purpose.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			this.cbx_purpose.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
			this.cbx_purpose.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.cbx_purpose.FormattingEnabled = true;
			this.cbx_purpose.Location = new System.Drawing.Point(121, 24);
			this.cbx_purpose.Name = "cbx_purpose";
			this.cbx_purpose.Size = new System.Drawing.Size(328, 26);
			this.cbx_purpose.TabIndex = 1;
			// 
			// lbl_company
			// 
			this.lbl_company.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbl_company.Location = new System.Drawing.Point(8, 57);
			this.lbl_company.Name = "lbl_company";
			this.lbl_company.Size = new System.Drawing.Size(110, 26);
			this.lbl_company.TabIndex = 33;
			this.lbl_company.Text = "Company";
			this.lbl_company.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lbl_purpose
			// 
			this.lbl_purpose.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbl_purpose.Location = new System.Drawing.Point(8, 25);
			this.lbl_purpose.Name = "lbl_purpose";
			this.lbl_purpose.Size = new System.Drawing.Size(107, 26);
			this.lbl_purpose.TabIndex = 26;
			this.lbl_purpose.Text = "Purpose";
			this.lbl_purpose.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtbx_dept_3
			// 
			this.txtbx_dept_3.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtbx_dept_3.Location = new System.Drawing.Point(603, 56);
			this.txtbx_dept_3.Name = "txtbx_dept_3";
			this.txtbx_dept_3.Size = new System.Drawing.Size(328, 26);
			this.txtbx_dept_3.TabIndex = 66;
			// 
			// lbl_dept_3
			// 
			this.lbl_dept_3.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbl_dept_3.Location = new System.Drawing.Point(490, 57);
			this.lbl_dept_3.Name = "lbl_dept_3";
			this.lbl_dept_3.Size = new System.Drawing.Size(110, 26);
			this.lbl_dept_3.TabIndex = 65;
			this.lbl_dept_3.Text = "Department";
			this.lbl_dept_3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lbl_dept_2
			// 
			this.lbl_dept_2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbl_dept_2.Location = new System.Drawing.Point(490, 25);
			this.lbl_dept_2.Name = "lbl_dept_2";
			this.lbl_dept_2.Size = new System.Drawing.Size(107, 26);
			this.lbl_dept_2.TabIndex = 64;
			this.lbl_dept_2.Text = "Department";
			this.lbl_dept_2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtbx_dept_2
			// 
			this.txtbx_dept_2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtbx_dept_2.Location = new System.Drawing.Point(603, 24);
			this.txtbx_dept_2.Name = "txtbx_dept_2";
			this.txtbx_dept_2.Size = new System.Drawing.Size(328, 26);
			this.txtbx_dept_2.TabIndex = 67;
			// 
			// frm_prod_warehouse_sample
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.AutoScroll = true;
			this.CancelButton = this.btn_cancel;
			this.ClientSize = new System.Drawing.Size(984, 661);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.groupBx_record);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.btn_cancel);
			this.Controls.Add(this.btn_clear);
			this.Controls.Add(this.btn_save);
			this.Controls.Add(this.btn_del);
			this.Controls.Add(this.groupbx_consume);
			this.Controls.Add(this.grpbox_output);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.lbl_header);
			this.Controls.Add(this.panel1);
			this.Name = "frm_prod_warehouse_sample";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Sample Request Form ";
			this.Load += new System.EventHandler(this.Frm_prod_warehouse_sampleLoad);
			this.panel2.ResumeLayout(false);
			this.grpbox_output.ResumeLayout(false);
			this.grpbox_output.PerformLayout();
			this.groupbx_consume.ResumeLayout(false);
			this.panel3.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dt_grid_consume)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dt_grid_consume2)).EndInit();
			this.groupBx_record.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dt_grid)).EndInit();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.TextBox txtbx_dept_2;
		private System.Windows.Forms.Label lbl_dept_2;
		private System.Windows.Forms.Label lbl_dept_3;
		private System.Windows.Forms.TextBox txtbx_dept_3;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.Label lbl_ref_no;
		private System.Windows.Forms.TextBox txtbx_ref_no;
		private System.Windows.Forms.Label lbl_purpose;
		private System.Windows.Forms.Label lbl_company;
		private System.Windows.Forms.ComboBox cbx_purpose;
		private System.Windows.Forms.TextBox txtbx_company;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.TextBox txtbx_dept;
		private System.Windows.Forms.TextBox txtbx_requested_by;
		private System.Windows.Forms.Button btn_add;
		private System.Windows.Forms.GroupBox groupBx_record;
		private System.Windows.Forms.DataGridView dt_grid_consume2;
		private System.Windows.Forms.DataGridView dt_grid_consume;
		private System.Windows.Forms.DataGridView dt_grid;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button btn_del;
		private System.Windows.Forms.Button btn_save;
		private System.Windows.Forms.Button btn_clear;
		private System.Windows.Forms.Button btn_cancel;
		private System.Windows.Forms.GroupBox groupbx_consume;
		private System.Windows.Forms.Label lbl_requested_by;
		private System.Windows.Forms.DateTimePicker dtp_date;
		private System.Windows.Forms.Label lbl_dept;
		private System.Windows.Forms.Label lbl_date;
		private System.Windows.Forms.GroupBox grpbox_output;
		private System.Windows.Forms.Label lbl_header;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label lbl_username;
		private System.Windows.Forms.Panel panel2;
		

		
	}
}
