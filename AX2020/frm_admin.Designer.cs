/*
 * Created by SharpDevelop.
 * User: ax2020-1
 * Date: 1/12/2017
 * Time: 3:30 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace AX2020
{
	partial class frm_admin
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
			this.grpbox_info = new System.Windows.Forms.GroupBox();
			this.txtbx_name = new System.Windows.Forms.TextBox();
			this.txtbx_email = new System.Windows.Forms.TextBox();
			this.lbl_email = new System.Windows.Forms.Label();
			this.cbx_dept = new System.Windows.Forms.ComboBox();
			this.lbl_dept = new System.Windows.Forms.Label();
			this.lbl_name = new System.Windows.Forms.Label();
			this.btn_cancel = new System.Windows.Forms.Button();
			this.btn_clear = new System.Windows.Forms.Button();
			this.btn_save = new System.Windows.Forms.Button();
			this.btn_del = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.groupBx_record = new System.Windows.Forms.GroupBox();
			this.dt_grid = new System.Windows.Forms.DataGridView();
			this.grpbox_acc = new System.Windows.Forms.GroupBox();
			this.txtbx_pass = new System.Windows.Forms.TextBox();
			this.txtbx_username = new System.Windows.Forms.TextBox();
			this.lbl_pass = new System.Windows.Forms.Label();
			this.lbl_user_name = new System.Windows.Forms.Label();
			this.grpbox_access = new System.Windows.Forms.GroupBox();
			this.chkbx_alldepartment = new System.Windows.Forms.CheckBox();
			this.chkbx_procurement = new System.Windows.Forms.CheckBox();
			this.chkbx_stretch_film_report = new System.Windows.Forms.CheckBox();
			this.chkbx_ribbon_report = new System.Windows.Forms.CheckBox();
			this.chkbx_kliner_report = new System.Windows.Forms.CheckBox();
			this.chkbx_papercore_report = new System.Windows.Forms.CheckBox();
			this.chkbx_coat_report = new System.Windows.Forms.CheckBox();
			this.chkbx_glue_report = new System.Windows.Forms.CheckBox();
			this.chkbx_conv_report = new System.Windows.Forms.CheckBox();
			this.chkbx_stretch_film = new System.Windows.Forms.CheckBox();
			this.chkbx_mngmt = new System.Windows.Forms.CheckBox();
			this.chkbx_pack = new System.Windows.Forms.CheckBox();
			this.chkbx_qis = new System.Windows.Forms.CheckBox();
			this.chkbx_admin = new System.Windows.Forms.CheckBox();
			this.chkbx_ship = new System.Windows.Forms.CheckBox();
			this.chkbx_qac = new System.Windows.Forms.CheckBox();
			this.chkbx_kliner = new System.Windows.Forms.CheckBox();
			this.chkbx_papercore = new System.Windows.Forms.CheckBox();
			this.chkbx_ribbon = new System.Windows.Forms.CheckBox();
			this.chkbx_glue = new System.Windows.Forms.CheckBox();
			this.chkbx_conv = new System.Windows.Forms.CheckBox();
			this.chkbx_coat = new System.Windows.Forms.CheckBox();
			this.chkbx_whse = new System.Windows.Forms.CheckBox();
			this.chkbx_plan = new System.Windows.Forms.CheckBox();
			this.chkbx_sales = new System.Windows.Forms.CheckBox();
			this.panel2 = new System.Windows.Forms.Panel();
			this.lbl_username = new System.Windows.Forms.Label();
			this.panel1 = new System.Windows.Forms.Panel();
			this.lbl_header = new System.Windows.Forms.Label();
			this.grpbox_info.SuspendLayout();
			this.groupBx_record.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dt_grid)).BeginInit();
			this.grpbox_acc.SuspendLayout();
			this.grpbox_access.SuspendLayout();
			this.panel2.SuspendLayout();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// grpbox_info
			// 
			this.grpbox_info.Controls.Add(this.txtbx_name);
			this.grpbox_info.Controls.Add(this.txtbx_email);
			this.grpbox_info.Controls.Add(this.lbl_email);
			this.grpbox_info.Controls.Add(this.cbx_dept);
			this.grpbox_info.Controls.Add(this.lbl_dept);
			this.grpbox_info.Controls.Add(this.lbl_name);
			this.grpbox_info.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.grpbox_info.Location = new System.Drawing.Point(12, 92);
			this.grpbox_info.Name = "grpbox_info";
			this.grpbox_info.Size = new System.Drawing.Size(473, 143);
			this.grpbox_info.TabIndex = 1;
			this.grpbox_info.TabStop = false;
			this.grpbox_info.Text = "Staff Information";
			// 
			// txtbx_name
			// 
			this.txtbx_name.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtbx_name.Location = new System.Drawing.Point(121, 32);
			this.txtbx_name.Name = "txtbx_name";
			this.txtbx_name.Size = new System.Drawing.Size(335, 26);
			this.txtbx_name.TabIndex = 6;
			// 
			// txtbx_email
			// 
			this.txtbx_email.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtbx_email.Location = new System.Drawing.Point(121, 96);
			this.txtbx_email.Name = "txtbx_email";
			this.txtbx_email.Size = new System.Drawing.Size(335, 26);
			this.txtbx_email.TabIndex = 5;
			// 
			// lbl_email
			// 
			this.lbl_email.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbl_email.Location = new System.Drawing.Point(8, 97);
			this.lbl_email.Name = "lbl_email";
			this.lbl_email.Size = new System.Drawing.Size(110, 26);
			this.lbl_email.TabIndex = 42;
			this.lbl_email.Text = "Email";
			this.lbl_email.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// cbx_dept
			// 
			this.cbx_dept.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			this.cbx_dept.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
			this.cbx_dept.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.cbx_dept.FormattingEnabled = true;
			this.cbx_dept.Location = new System.Drawing.Point(121, 64);
			this.cbx_dept.Name = "cbx_dept";
			this.cbx_dept.Size = new System.Drawing.Size(335, 26);
			this.cbx_dept.TabIndex = 2;
			// 
			// lbl_dept
			// 
			this.lbl_dept.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbl_dept.Location = new System.Drawing.Point(8, 65);
			this.lbl_dept.Name = "lbl_dept";
			this.lbl_dept.Size = new System.Drawing.Size(110, 26);
			this.lbl_dept.TabIndex = 33;
			this.lbl_dept.Text = "Department";
			this.lbl_dept.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lbl_name
			// 
			this.lbl_name.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbl_name.Location = new System.Drawing.Point(8, 33);
			this.lbl_name.Name = "lbl_name";
			this.lbl_name.Size = new System.Drawing.Size(107, 26);
			this.lbl_name.TabIndex = 26;
			this.lbl_name.Text = "Name";
			this.lbl_name.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// btn_cancel
			// 
			this.btn_cancel.BackColor = System.Drawing.Color.Silver;
			this.btn_cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btn_cancel.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_cancel.Location = new System.Drawing.Point(532, 783);
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
			this.btn_clear.Location = new System.Drawing.Point(406, 783);
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
			this.btn_save.Location = new System.Drawing.Point(280, 783);
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
			this.btn_del.Location = new System.Drawing.Point(280, 783);
			this.btn_del.Name = "btn_del";
			this.btn_del.Size = new System.Drawing.Size(120, 27);
			this.btn_del.TabIndex = 147;
			this.btn_del.Text = "Delete";
			this.btn_del.UseVisualStyleBackColor = false;
			this.btn_del.Click += new System.EventHandler(this.Btn_delClick);
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(435, 817);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(100, 23);
			this.label2.TabIndex = 148;
			// 
			// groupBx_record
			// 
			this.groupBx_record.Controls.Add(this.dt_grid);
			this.groupBx_record.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.groupBx_record.Location = new System.Drawing.Point(12, 469);
			this.groupBx_record.Name = "groupBx_record";
			this.groupBx_record.Size = new System.Drawing.Size(955, 286);
			this.groupBx_record.TabIndex = 149;
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
			this.dt_grid.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
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
			this.dt_grid.Size = new System.Drawing.Size(920, 233);
			this.dt_grid.TabIndex = 131;
			this.dt_grid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Dt_gridCellClick);
			this.dt_grid.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.Dt_gridDataBindingComplete);
			// 
			// grpbox_acc
			// 
			this.grpbox_acc.Controls.Add(this.txtbx_pass);
			this.grpbox_acc.Controls.Add(this.txtbx_username);
			this.grpbox_acc.Controls.Add(this.lbl_pass);
			this.grpbox_acc.Controls.Add(this.lbl_user_name);
			this.grpbox_acc.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.grpbox_acc.Location = new System.Drawing.Point(498, 92);
			this.grpbox_acc.Name = "grpbox_acc";
			this.grpbox_acc.Size = new System.Drawing.Size(469, 143);
			this.grpbox_acc.TabIndex = 43;
			this.grpbox_acc.TabStop = false;
			this.grpbox_acc.Text = "User Account";
			// 
			// txtbx_pass
			// 
			this.txtbx_pass.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtbx_pass.Location = new System.Drawing.Point(121, 64);
			this.txtbx_pass.Name = "txtbx_pass";
			this.txtbx_pass.Size = new System.Drawing.Size(331, 26);
			this.txtbx_pass.TabIndex = 34;
			// 
			// txtbx_username
			// 
			this.txtbx_username.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtbx_username.Location = new System.Drawing.Point(121, 32);
			this.txtbx_username.Name = "txtbx_username";
			this.txtbx_username.Size = new System.Drawing.Size(331, 26);
			this.txtbx_username.TabIndex = 6;
			// 
			// lbl_pass
			// 
			this.lbl_pass.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbl_pass.Location = new System.Drawing.Point(8, 65);
			this.lbl_pass.Name = "lbl_pass";
			this.lbl_pass.Size = new System.Drawing.Size(110, 26);
			this.lbl_pass.TabIndex = 33;
			this.lbl_pass.Text = "Password";
			this.lbl_pass.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lbl_user_name
			// 
			this.lbl_user_name.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbl_user_name.Location = new System.Drawing.Point(8, 33);
			this.lbl_user_name.Name = "lbl_user_name";
			this.lbl_user_name.Size = new System.Drawing.Size(107, 26);
			this.lbl_user_name.TabIndex = 26;
			this.lbl_user_name.Text = "Username";
			this.lbl_user_name.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// grpbox_access
			// 
			this.grpbox_access.Controls.Add(this.chkbx_alldepartment);
			this.grpbox_access.Controls.Add(this.chkbx_procurement);
			this.grpbox_access.Controls.Add(this.chkbx_stretch_film_report);
			this.grpbox_access.Controls.Add(this.chkbx_ribbon_report);
			this.grpbox_access.Controls.Add(this.chkbx_kliner_report);
			this.grpbox_access.Controls.Add(this.chkbx_papercore_report);
			this.grpbox_access.Controls.Add(this.chkbx_coat_report);
			this.grpbox_access.Controls.Add(this.chkbx_glue_report);
			this.grpbox_access.Controls.Add(this.chkbx_conv_report);
			this.grpbox_access.Controls.Add(this.chkbx_stretch_film);
			this.grpbox_access.Controls.Add(this.chkbx_mngmt);
			this.grpbox_access.Controls.Add(this.chkbx_pack);
			this.grpbox_access.Controls.Add(this.chkbx_qis);
			this.grpbox_access.Controls.Add(this.chkbx_admin);
			this.grpbox_access.Controls.Add(this.chkbx_ship);
			this.grpbox_access.Controls.Add(this.chkbx_qac);
			this.grpbox_access.Controls.Add(this.chkbx_kliner);
			this.grpbox_access.Controls.Add(this.chkbx_papercore);
			this.grpbox_access.Controls.Add(this.chkbx_ribbon);
			this.grpbox_access.Controls.Add(this.chkbx_glue);
			this.grpbox_access.Controls.Add(this.chkbx_conv);
			this.grpbox_access.Controls.Add(this.chkbx_coat);
			this.grpbox_access.Controls.Add(this.chkbx_whse);
			this.grpbox_access.Controls.Add(this.chkbx_plan);
			this.grpbox_access.Controls.Add(this.chkbx_sales);
			this.grpbox_access.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.grpbox_access.Location = new System.Drawing.Point(12, 241);
			this.grpbox_access.Name = "grpbox_access";
			this.grpbox_access.Size = new System.Drawing.Size(955, 222);
			this.grpbox_access.TabIndex = 44;
			this.grpbox_access.TabStop = false;
			this.grpbox_access.Text = "User Access";
			// 
			// chkbx_alldepartment
			// 
			this.chkbx_alldepartment.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.chkbx_alldepartment.Location = new System.Drawing.Point(714, 192);
			this.chkbx_alldepartment.Name = "chkbx_alldepartment";
			this.chkbx_alldepartment.Size = new System.Drawing.Size(135, 24);
			this.chkbx_alldepartment.TabIndex = 172;
			this.chkbx_alldepartment.Text = "All Department";
			this.chkbx_alldepartment.UseVisualStyleBackColor = true;
			// 
			// chkbx_procurement
			// 
			this.chkbx_procurement.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.chkbx_procurement.Location = new System.Drawing.Point(714, 168);
			this.chkbx_procurement.Name = "chkbx_procurement";
			this.chkbx_procurement.Size = new System.Drawing.Size(135, 24);
			this.chkbx_procurement.TabIndex = 171;
			this.chkbx_procurement.Text = "Procurement";
			this.chkbx_procurement.UseVisualStyleBackColor = true;
			// 
			// chkbx_stretch_film_report
			// 
			this.chkbx_stretch_film_report.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.chkbx_stretch_film_report.Location = new System.Drawing.Point(714, 112);
			this.chkbx_stretch_film_report.Name = "chkbx_stretch_film_report";
			this.chkbx_stretch_film_report.Size = new System.Drawing.Size(171, 24);
			this.chkbx_stretch_film_report.TabIndex = 170;
			this.chkbx_stretch_film_report.Text = "Stretch Film Report";
			this.chkbx_stretch_film_report.UseVisualStyleBackColor = true;
			// 
			// chkbx_ribbon_report
			// 
			this.chkbx_ribbon_report.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.chkbx_ribbon_report.Location = new System.Drawing.Point(237, 164);
			this.chkbx_ribbon_report.Name = "chkbx_ribbon_report";
			this.chkbx_ribbon_report.Size = new System.Drawing.Size(162, 24);
			this.chkbx_ribbon_report.TabIndex = 169;
			this.chkbx_ribbon_report.Text = "Ribbon Report";
			this.chkbx_ribbon_report.UseVisualStyleBackColor = true;
			// 
			// chkbx_kliner_report
			// 
			this.chkbx_kliner_report.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.chkbx_kliner_report.Location = new System.Drawing.Point(494, 112);
			this.chkbx_kliner_report.Name = "chkbx_kliner_report";
			this.chkbx_kliner_report.Size = new System.Drawing.Size(162, 24);
			this.chkbx_kliner_report.TabIndex = 168;
			this.chkbx_kliner_report.Text = "Kliner Report";
			this.chkbx_kliner_report.UseVisualStyleBackColor = true;
			// 
			// chkbx_papercore_report
			// 
			this.chkbx_papercore_report.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.chkbx_papercore_report.Location = new System.Drawing.Point(494, 60);
			this.chkbx_papercore_report.Name = "chkbx_papercore_report";
			this.chkbx_papercore_report.Size = new System.Drawing.Size(162, 24);
			this.chkbx_papercore_report.TabIndex = 167;
			this.chkbx_papercore_report.Text = "Papercore Report";
			this.chkbx_papercore_report.UseVisualStyleBackColor = true;
			// 
			// chkbx_coat_report
			// 
			this.chkbx_coat_report.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.chkbx_coat_report.Location = new System.Drawing.Point(11, 164);
			this.chkbx_coat_report.Name = "chkbx_coat_report";
			this.chkbx_coat_report.Size = new System.Drawing.Size(139, 24);
			this.chkbx_coat_report.TabIndex = 166;
			this.chkbx_coat_report.Text = "Coating Report";
			this.chkbx_coat_report.UseVisualStyleBackColor = true;
			// 
			// chkbx_glue_report
			// 
			this.chkbx_glue_report.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.chkbx_glue_report.Location = new System.Drawing.Point(237, 112);
			this.chkbx_glue_report.Name = "chkbx_glue_report";
			this.chkbx_glue_report.Size = new System.Drawing.Size(162, 24);
			this.chkbx_glue_report.TabIndex = 165;
			this.chkbx_glue_report.Text = "Glue Report";
			this.chkbx_glue_report.UseVisualStyleBackColor = true;
			// 
			// chkbx_conv_report
			// 
			this.chkbx_conv_report.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.chkbx_conv_report.Location = new System.Drawing.Point(237, 60);
			this.chkbx_conv_report.Name = "chkbx_conv_report";
			this.chkbx_conv_report.Size = new System.Drawing.Size(162, 24);
			this.chkbx_conv_report.TabIndex = 164;
			this.chkbx_conv_report.Text = "Converting Report";
			this.chkbx_conv_report.UseVisualStyleBackColor = true;
			// 
			// chkbx_stretch_film
			// 
			this.chkbx_stretch_film.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.chkbx_stretch_film.Location = new System.Drawing.Point(714, 86);
			this.chkbx_stretch_film.Name = "chkbx_stretch_film";
			this.chkbx_stretch_film.Size = new System.Drawing.Size(118, 24);
			this.chkbx_stretch_film.TabIndex = 163;
			this.chkbx_stretch_film.Text = "Stretch Film";
			this.chkbx_stretch_film.UseVisualStyleBackColor = true;
			// 
			// chkbx_mngmt
			// 
			this.chkbx_mngmt.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.chkbx_mngmt.Location = new System.Drawing.Point(714, 138);
			this.chkbx_mngmt.Name = "chkbx_mngmt";
			this.chkbx_mngmt.Size = new System.Drawing.Size(135, 24);
			this.chkbx_mngmt.TabIndex = 162;
			this.chkbx_mngmt.Text = "Management";
			this.chkbx_mngmt.UseVisualStyleBackColor = true;
			// 
			// chkbx_pack
			// 
			this.chkbx_pack.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.chkbx_pack.Location = new System.Drawing.Point(714, 60);
			this.chkbx_pack.Name = "chkbx_pack";
			this.chkbx_pack.Size = new System.Drawing.Size(118, 24);
			this.chkbx_pack.TabIndex = 161;
			this.chkbx_pack.Text = "Packing List";
			this.chkbx_pack.UseVisualStyleBackColor = true;
			// 
			// chkbx_qis
			// 
			this.chkbx_qis.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.chkbx_qis.Location = new System.Drawing.Point(714, 34);
			this.chkbx_qis.Name = "chkbx_qis";
			this.chkbx_qis.Size = new System.Drawing.Size(118, 24);
			this.chkbx_qis.TabIndex = 160;
			this.chkbx_qis.Text = "QIS";
			this.chkbx_qis.UseVisualStyleBackColor = true;
			// 
			// chkbx_admin
			// 
			this.chkbx_admin.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.chkbx_admin.Location = new System.Drawing.Point(11, 112);
			this.chkbx_admin.Name = "chkbx_admin";
			this.chkbx_admin.Size = new System.Drawing.Size(118, 24);
			this.chkbx_admin.TabIndex = 159;
			this.chkbx_admin.Text = "Admin";
			this.chkbx_admin.UseVisualStyleBackColor = true;
			// 
			// chkbx_ship
			// 
			this.chkbx_ship.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.chkbx_ship.Location = new System.Drawing.Point(494, 164);
			this.chkbx_ship.Name = "chkbx_ship";
			this.chkbx_ship.Size = new System.Drawing.Size(118, 24);
			this.chkbx_ship.TabIndex = 158;
			this.chkbx_ship.Text = "Shipping";
			this.chkbx_ship.UseVisualStyleBackColor = true;
			// 
			// chkbx_qac
			// 
			this.chkbx_qac.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.chkbx_qac.Location = new System.Drawing.Point(494, 138);
			this.chkbx_qac.Name = "chkbx_qac";
			this.chkbx_qac.Size = new System.Drawing.Size(118, 24);
			this.chkbx_qac.TabIndex = 157;
			this.chkbx_qac.Text = "QAC";
			this.chkbx_qac.UseVisualStyleBackColor = true;
			// 
			// chkbx_kliner
			// 
			this.chkbx_kliner.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.chkbx_kliner.Location = new System.Drawing.Point(494, 86);
			this.chkbx_kliner.Name = "chkbx_kliner";
			this.chkbx_kliner.Size = new System.Drawing.Size(118, 24);
			this.chkbx_kliner.TabIndex = 156;
			this.chkbx_kliner.Text = "Kliner";
			this.chkbx_kliner.UseVisualStyleBackColor = true;
			// 
			// chkbx_papercore
			// 
			this.chkbx_papercore.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.chkbx_papercore.Location = new System.Drawing.Point(494, 34);
			this.chkbx_papercore.Name = "chkbx_papercore";
			this.chkbx_papercore.Size = new System.Drawing.Size(118, 24);
			this.chkbx_papercore.TabIndex = 155;
			this.chkbx_papercore.Text = "Papercore";
			this.chkbx_papercore.UseVisualStyleBackColor = true;
			// 
			// chkbx_ribbon
			// 
			this.chkbx_ribbon.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.chkbx_ribbon.Location = new System.Drawing.Point(237, 138);
			this.chkbx_ribbon.Name = "chkbx_ribbon";
			this.chkbx_ribbon.Size = new System.Drawing.Size(118, 24);
			this.chkbx_ribbon.TabIndex = 154;
			this.chkbx_ribbon.Text = "Ribbon";
			this.chkbx_ribbon.UseVisualStyleBackColor = true;
			// 
			// chkbx_glue
			// 
			this.chkbx_glue.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.chkbx_glue.Location = new System.Drawing.Point(237, 86);
			this.chkbx_glue.Name = "chkbx_glue";
			this.chkbx_glue.Size = new System.Drawing.Size(118, 24);
			this.chkbx_glue.TabIndex = 153;
			this.chkbx_glue.Text = "Glue";
			this.chkbx_glue.UseVisualStyleBackColor = true;
			// 
			// chkbx_conv
			// 
			this.chkbx_conv.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.chkbx_conv.Location = new System.Drawing.Point(237, 34);
			this.chkbx_conv.Name = "chkbx_conv";
			this.chkbx_conv.Size = new System.Drawing.Size(118, 24);
			this.chkbx_conv.TabIndex = 152;
			this.chkbx_conv.Text = "Converting";
			this.chkbx_conv.UseVisualStyleBackColor = true;
			// 
			// chkbx_coat
			// 
			this.chkbx_coat.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.chkbx_coat.Location = new System.Drawing.Point(11, 138);
			this.chkbx_coat.Name = "chkbx_coat";
			this.chkbx_coat.Size = new System.Drawing.Size(118, 24);
			this.chkbx_coat.TabIndex = 151;
			this.chkbx_coat.Text = "Coating";
			this.chkbx_coat.UseVisualStyleBackColor = true;
			// 
			// chkbx_whse
			// 
			this.chkbx_whse.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.chkbx_whse.Location = new System.Drawing.Point(11, 86);
			this.chkbx_whse.Name = "chkbx_whse";
			this.chkbx_whse.Size = new System.Drawing.Size(118, 24);
			this.chkbx_whse.TabIndex = 150;
			this.chkbx_whse.Text = "Warehouse";
			this.chkbx_whse.UseVisualStyleBackColor = true;
			// 
			// chkbx_plan
			// 
			this.chkbx_plan.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.chkbx_plan.Location = new System.Drawing.Point(11, 60);
			this.chkbx_plan.Name = "chkbx_plan";
			this.chkbx_plan.Size = new System.Drawing.Size(104, 24);
			this.chkbx_plan.TabIndex = 35;
			this.chkbx_plan.Text = "Planning";
			this.chkbx_plan.UseVisualStyleBackColor = true;
			// 
			// chkbx_sales
			// 
			this.chkbx_sales.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.chkbx_sales.Location = new System.Drawing.Point(11, 34);
			this.chkbx_sales.Name = "chkbx_sales";
			this.chkbx_sales.Size = new System.Drawing.Size(104, 24);
			this.chkbx_sales.TabIndex = 34;
			this.chkbx_sales.Text = "Sales";
			this.chkbx_sales.UseVisualStyleBackColor = true;
			// 
			// panel2
			// 
			this.panel2.BackColor = System.Drawing.Color.Gainsboro;
			this.panel2.Controls.Add(this.lbl_username);
			this.panel2.Location = new System.Drawing.Point(0, 49);
			this.panel2.Margin = new System.Windows.Forms.Padding(1);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(1000, 23);
			this.panel2.TabIndex = 171;
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
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.Color.DarkCyan;
			this.panel1.Controls.Add(this.lbl_header);
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Margin = new System.Windows.Forms.Padding(1);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(1000, 52);
			this.panel1.TabIndex = 170;
			// 
			// lbl_header
			// 
			this.lbl_header.BackColor = System.Drawing.Color.DarkCyan;
			this.lbl_header.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbl_header.ForeColor = System.Drawing.SystemColors.ControlLightLight;
			this.lbl_header.Location = new System.Drawing.Point(0, 15);
			this.lbl_header.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
			this.lbl_header.Name = "lbl_header";
			this.lbl_header.Size = new System.Drawing.Size(1000, 23);
			this.lbl_header.TabIndex = 0;
			this.lbl_header.Text = "SYSTEM USER";
			this.lbl_header.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// frm_admin
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.AutoScroll = true;
			this.CancelButton = this.btn_cancel;
			this.ClientSize = new System.Drawing.Size(984, 661);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.grpbox_access);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.grpbox_acc);
			this.Controls.Add(this.groupBx_record);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.btn_cancel);
			this.Controls.Add(this.btn_clear);
			this.Controls.Add(this.grpbox_info);
			this.Controls.Add(this.btn_save);
			this.Controls.Add(this.btn_del);
			this.Name = "frm_admin";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "System User";
			this.Load += new System.EventHandler(this.Frm_mngmtLoad);
			this.grpbox_info.ResumeLayout(false);
			this.grpbox_info.PerformLayout();
			this.groupBx_record.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dt_grid)).EndInit();
			this.grpbox_acc.ResumeLayout(false);
			this.grpbox_acc.PerformLayout();
			this.grpbox_access.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.CheckBox chkbx_alldepartment;
		private System.Windows.Forms.CheckBox chkbx_procurement;
		private System.Windows.Forms.CheckBox chkbx_stretch_film_report;
		private System.Windows.Forms.Label lbl_header;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label lbl_username;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.CheckBox chkbx_conv_report;
		private System.Windows.Forms.CheckBox chkbx_glue_report;
		private System.Windows.Forms.CheckBox chkbx_coat_report;
		private System.Windows.Forms.CheckBox chkbx_papercore_report;
		private System.Windows.Forms.CheckBox chkbx_kliner_report;
		private System.Windows.Forms.CheckBox chkbx_ribbon_report;
		private System.Windows.Forms.CheckBox chkbx_qis;
		private System.Windows.Forms.CheckBox chkbx_pack;
		private System.Windows.Forms.CheckBox chkbx_mngmt;
		private System.Windows.Forms.CheckBox chkbx_stretch_film;
		private System.Windows.Forms.CheckBox chkbx_admin;
		private System.Windows.Forms.CheckBox chkbx_glue;
		private System.Windows.Forms.CheckBox chkbx_ribbon;
		private System.Windows.Forms.CheckBox chkbx_papercore;
		private System.Windows.Forms.CheckBox chkbx_kliner;
		private System.Windows.Forms.CheckBox chkbx_qac;
		private System.Windows.Forms.CheckBox chkbx_ship;
		private System.Windows.Forms.CheckBox chkbx_conv;
		private System.Windows.Forms.CheckBox chkbx_coat;
		private System.Windows.Forms.CheckBox chkbx_plan;
		private System.Windows.Forms.CheckBox chkbx_whse;
		private System.Windows.Forms.CheckBox chkbx_sales;
		private System.Windows.Forms.GroupBox grpbox_access;
		private System.Windows.Forms.Label lbl_user_name;
		private System.Windows.Forms.Label lbl_pass;
		private System.Windows.Forms.TextBox txtbx_username;
		private System.Windows.Forms.TextBox txtbx_pass;
		private System.Windows.Forms.GroupBox grpbox_acc;
		private System.Windows.Forms.GroupBox groupBx_record;
		private System.Windows.Forms.DataGridView dt_grid;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button btn_del;
		private System.Windows.Forms.Button btn_save;
		private System.Windows.Forms.Button btn_clear;
		private System.Windows.Forms.Button btn_cancel;
		private System.Windows.Forms.TextBox txtbx_email;
		private System.Windows.Forms.TextBox txtbx_name;
		private System.Windows.Forms.Label lbl_email;
		private System.Windows.Forms.Label lbl_name;
		private System.Windows.Forms.Label lbl_dept;
		private System.Windows.Forms.ComboBox cbx_dept;
		private System.Windows.Forms.GroupBox grpbox_info;
		

		
	}
}
