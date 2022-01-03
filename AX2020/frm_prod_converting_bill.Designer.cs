/*
 * Created by SharpDevelop.
 * User: ax2020-1
 * Date: 1/20/2017
 * Time: 11:34 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace AX2020
{
	partial class frm_prod_converting_bill
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
			this.panel2 = new System.Windows.Forms.Panel();
			this.lbl_username = new System.Windows.Forms.Label();
			this.panel1 = new System.Windows.Forms.Panel();
			this.lbl_header = new System.Windows.Forms.Label();
			this.grpbox_info = new System.Windows.Forms.GroupBox();
			this.btn_cancel = new System.Windows.Forms.Button();
			this.btn_clear = new System.Windows.Forms.Button();
			this.btn_del = new System.Windows.Forms.Button();
			this.btn_save = new System.Windows.Forms.Button();
			this.cbx_pallet = new System.Windows.Forms.ComboBox();
			this.lbl_pallet = new System.Windows.Forms.Label();
			this.cbx_pack_type = new System.Windows.Forms.ComboBox();
			this.lbl_pack_type = new System.Windows.Forms.Label();
			this.txtbx_ctn_bx = new System.Windows.Forms.TextBox();
			this.cbx_ctn_bx_code = new System.Windows.Forms.ComboBox();
			this.lbl_ctn_bx_code = new System.Windows.Forms.Label();
			this.cbx_inner_bx = new System.Windows.Forms.ComboBox();
			this.cbx_tape_end = new System.Windows.Forms.ComboBox();
			this.cbx_pack = new System.Windows.Forms.ComboBox();
			this.cbx_tear = new System.Windows.Forms.ComboBox();
			this.lbl_inner_bx = new System.Windows.Forms.Label();
			this.lbl_ctn_bx = new System.Windows.Forms.Label();
			this.lbl_tear = new System.Windows.Forms.Label();
			this.txtbx_prod_code = new System.Windows.Forms.TextBox();
			this.lbl_pack = new System.Windows.Forms.Label();
			this.lbl_tape_end = new System.Windows.Forms.Label();
			this.lbl_prod_code = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.groupBx_record = new System.Windows.Forms.GroupBox();
			this.label1 = new System.Windows.Forms.Label();
			this.txtbx_ctn_bx_search = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.txtbx_stock_code = new System.Windows.Forms.TextBox();
			this.dt_grid = new System.Windows.Forms.DataGridView();
			this.panel2.SuspendLayout();
			this.grpbox_info.SuspendLayout();
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
			this.panel2.Size = new System.Drawing.Size(1005, 23);
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
			this.lbl_username.Size = new System.Drawing.Size(1005, 23);
			this.lbl_username.TabIndex = 0;
			this.lbl_username.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.Color.DarkCyan;
			this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(1005, 52);
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
			this.lbl_header.Text = "CONVERTING BILL OF MATERIAL";
			this.lbl_header.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// grpbox_info
			// 
			this.grpbox_info.Controls.Add(this.btn_cancel);
			this.grpbox_info.Controls.Add(this.btn_clear);
			this.grpbox_info.Controls.Add(this.btn_del);
			this.grpbox_info.Controls.Add(this.btn_save);
			this.grpbox_info.Controls.Add(this.cbx_pallet);
			this.grpbox_info.Controls.Add(this.lbl_pallet);
			this.grpbox_info.Controls.Add(this.cbx_pack_type);
			this.grpbox_info.Controls.Add(this.lbl_pack_type);
			this.grpbox_info.Controls.Add(this.txtbx_ctn_bx);
			this.grpbox_info.Controls.Add(this.cbx_ctn_bx_code);
			this.grpbox_info.Controls.Add(this.lbl_ctn_bx_code);
			this.grpbox_info.Controls.Add(this.cbx_inner_bx);
			this.grpbox_info.Controls.Add(this.cbx_tape_end);
			this.grpbox_info.Controls.Add(this.cbx_pack);
			this.grpbox_info.Controls.Add(this.cbx_tear);
			this.grpbox_info.Controls.Add(this.lbl_inner_bx);
			this.grpbox_info.Controls.Add(this.lbl_ctn_bx);
			this.grpbox_info.Controls.Add(this.lbl_tear);
			this.grpbox_info.Controls.Add(this.txtbx_prod_code);
			this.grpbox_info.Controls.Add(this.lbl_pack);
			this.grpbox_info.Controls.Add(this.lbl_tape_end);
			this.grpbox_info.Controls.Add(this.lbl_prod_code);
			this.grpbox_info.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.grpbox_info.Location = new System.Drawing.Point(13, 92);
			this.grpbox_info.Name = "grpbox_info";
			this.grpbox_info.Size = new System.Drawing.Size(943, 304);
			this.grpbox_info.TabIndex = 1;
			this.grpbox_info.TabStop = false;
			this.grpbox_info.Text = "Product";
			// 
			// btn_cancel
			// 
			this.btn_cancel.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.btn_cancel.BackColor = System.Drawing.Color.Silver;
			this.btn_cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btn_cancel.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_cancel.Location = new System.Drawing.Point(807, 253);
			this.btn_cancel.Name = "btn_cancel";
			this.btn_cancel.Size = new System.Drawing.Size(120, 27);
			this.btn_cancel.TabIndex = 150;
			this.btn_cancel.Text = "Cancel";
			this.btn_cancel.UseVisualStyleBackColor = false;
			this.btn_cancel.Click += new System.EventHandler(this.Btn_cancelClick);
			// 
			// btn_clear
			// 
			this.btn_clear.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.btn_clear.BackColor = System.Drawing.Color.Silver;
			this.btn_clear.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_clear.Location = new System.Drawing.Point(807, 220);
			this.btn_clear.Name = "btn_clear";
			this.btn_clear.Size = new System.Drawing.Size(120, 27);
			this.btn_clear.TabIndex = 149;
			this.btn_clear.Text = "Clear";
			this.btn_clear.UseVisualStyleBackColor = false;
			this.btn_clear.Click += new System.EventHandler(this.Btn_clearClick);
			// 
			// btn_del
			// 
			this.btn_del.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.btn_del.BackColor = System.Drawing.Color.Silver;
			this.btn_del.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_del.Location = new System.Drawing.Point(807, 187);
			this.btn_del.Name = "btn_del";
			this.btn_del.Size = new System.Drawing.Size(120, 27);
			this.btn_del.TabIndex = 148;
			this.btn_del.Text = "Delete";
			this.btn_del.UseVisualStyleBackColor = false;
			this.btn_del.Click += new System.EventHandler(this.Btn_delClick);
			// 
			// btn_save
			// 
			this.btn_save.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.btn_save.BackColor = System.Drawing.Color.Silver;
			this.btn_save.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_save.Location = new System.Drawing.Point(807, 154);
			this.btn_save.Name = "btn_save";
			this.btn_save.Size = new System.Drawing.Size(120, 27);
			this.btn_save.TabIndex = 62;
			this.btn_save.Text = "Save";
			this.btn_save.UseVisualStyleBackColor = false;
			this.btn_save.Click += new System.EventHandler(this.Btn_saveClick);
			// 
			// cbx_pallet
			// 
			this.cbx_pallet.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			this.cbx_pallet.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
			this.cbx_pallet.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbx_pallet.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.cbx_pallet.FormattingEnabled = true;
			this.cbx_pallet.Location = new System.Drawing.Point(592, 32);
			this.cbx_pallet.Margin = new System.Windows.Forms.Padding(1);
			this.cbx_pallet.Name = "cbx_pallet";
			this.cbx_pallet.Size = new System.Drawing.Size(335, 26);
			this.cbx_pallet.TabIndex = 60;
			// 
			// lbl_pallet
			// 
			this.lbl_pallet.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbl_pallet.Location = new System.Drawing.Point(518, 32);
			this.lbl_pallet.Name = "lbl_pallet";
			this.lbl_pallet.Size = new System.Drawing.Size(88, 26);
			this.lbl_pallet.TabIndex = 61;
			this.lbl_pallet.Text = "Pallet";
			this.lbl_pallet.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// cbx_pack_type
			// 
			this.cbx_pack_type.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			this.cbx_pack_type.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
			this.cbx_pack_type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbx_pack_type.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.cbx_pack_type.FormattingEnabled = true;
			this.cbx_pack_type.Location = new System.Drawing.Point(140, 156);
			this.cbx_pack_type.Margin = new System.Windows.Forms.Padding(1);
			this.cbx_pack_type.Name = "cbx_pack_type";
			this.cbx_pack_type.Size = new System.Drawing.Size(335, 26);
			this.cbx_pack_type.TabIndex = 58;
			// 
			// lbl_pack_type
			// 
			this.lbl_pack_type.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbl_pack_type.Location = new System.Drawing.Point(8, 156);
			this.lbl_pack_type.Name = "lbl_pack_type";
			this.lbl_pack_type.Size = new System.Drawing.Size(107, 26);
			this.lbl_pack_type.TabIndex = 59;
			this.lbl_pack_type.Text = "Slitting";
			this.lbl_pack_type.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtbx_ctn_bx
			// 
			this.txtbx_ctn_bx.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtbx_ctn_bx.Location = new System.Drawing.Point(140, 219);
			this.txtbx_ctn_bx.Name = "txtbx_ctn_bx";
			this.txtbx_ctn_bx.ReadOnly = true;
			this.txtbx_ctn_bx.Size = new System.Drawing.Size(655, 26);
			this.txtbx_ctn_bx.TabIndex = 57;
			this.txtbx_ctn_bx.TabStop = false;
			// 
			// cbx_ctn_bx_code
			// 
			this.cbx_ctn_bx_code.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			this.cbx_ctn_bx_code.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
			this.cbx_ctn_bx_code.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbx_ctn_bx_code.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.cbx_ctn_bx_code.FormattingEnabled = true;
			this.cbx_ctn_bx_code.Location = new System.Drawing.Point(140, 187);
			this.cbx_ctn_bx_code.Margin = new System.Windows.Forms.Padding(1);
			this.cbx_ctn_bx_code.Name = "cbx_ctn_bx_code";
			this.cbx_ctn_bx_code.Size = new System.Drawing.Size(335, 26);
			this.cbx_ctn_bx_code.TabIndex = 5;
			this.cbx_ctn_bx_code.SelectionChangeCommitted += new System.EventHandler(this.Cbx_ctn_bx_codeSelectionChangeCommitted);
			// 
			// lbl_ctn_bx_code
			// 
			this.lbl_ctn_bx_code.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbl_ctn_bx_code.Location = new System.Drawing.Point(8, 187);
			this.lbl_ctn_bx_code.Name = "lbl_ctn_bx_code";
			this.lbl_ctn_bx_code.Size = new System.Drawing.Size(133, 26);
			this.lbl_ctn_bx_code.TabIndex = 55;
			this.lbl_ctn_bx_code.Text = "Carton Box Code";
			this.lbl_ctn_bx_code.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// cbx_inner_bx
			// 
			this.cbx_inner_bx.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			this.cbx_inner_bx.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
			this.cbx_inner_bx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbx_inner_bx.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.cbx_inner_bx.FormattingEnabled = true;
			this.cbx_inner_bx.Location = new System.Drawing.Point(140, 251);
			this.cbx_inner_bx.Margin = new System.Windows.Forms.Padding(1);
			this.cbx_inner_bx.Name = "cbx_inner_bx";
			this.cbx_inner_bx.Size = new System.Drawing.Size(655, 26);
			this.cbx_inner_bx.TabIndex = 6;
			// 
			// cbx_tape_end
			// 
			this.cbx_tape_end.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			this.cbx_tape_end.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
			this.cbx_tape_end.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbx_tape_end.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.cbx_tape_end.FormattingEnabled = true;
			this.cbx_tape_end.Location = new System.Drawing.Point(140, 63);
			this.cbx_tape_end.Margin = new System.Windows.Forms.Padding(1);
			this.cbx_tape_end.Name = "cbx_tape_end";
			this.cbx_tape_end.Size = new System.Drawing.Size(335, 26);
			this.cbx_tape_end.TabIndex = 2;
			// 
			// cbx_pack
			// 
			this.cbx_pack.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			this.cbx_pack.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
			this.cbx_pack.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbx_pack.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.cbx_pack.FormattingEnabled = true;
			this.cbx_pack.Location = new System.Drawing.Point(140, 94);
			this.cbx_pack.Margin = new System.Windows.Forms.Padding(1);
			this.cbx_pack.Name = "cbx_pack";
			this.cbx_pack.Size = new System.Drawing.Size(335, 26);
			this.cbx_pack.TabIndex = 3;
			// 
			// cbx_tear
			// 
			this.cbx_tear.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			this.cbx_tear.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
			this.cbx_tear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbx_tear.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.cbx_tear.FormattingEnabled = true;
			this.cbx_tear.Location = new System.Drawing.Point(140, 125);
			this.cbx_tear.Margin = new System.Windows.Forms.Padding(1);
			this.cbx_tear.Name = "cbx_tear";
			this.cbx_tear.Size = new System.Drawing.Size(335, 26);
			this.cbx_tear.TabIndex = 4;
			// 
			// lbl_inner_bx
			// 
			this.lbl_inner_bx.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbl_inner_bx.Location = new System.Drawing.Point(8, 251);
			this.lbl_inner_bx.Name = "lbl_inner_bx";
			this.lbl_inner_bx.Size = new System.Drawing.Size(110, 26);
			this.lbl_inner_bx.TabIndex = 48;
			this.lbl_inner_bx.Text = "Inner Box";
			this.lbl_inner_bx.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lbl_ctn_bx
			// 
			this.lbl_ctn_bx.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbl_ctn_bx.Location = new System.Drawing.Point(8, 220);
			this.lbl_ctn_bx.Name = "lbl_ctn_bx";
			this.lbl_ctn_bx.Size = new System.Drawing.Size(110, 26);
			this.lbl_ctn_bx.TabIndex = 47;
			this.lbl_ctn_bx.Text = "Carton Box";
			this.lbl_ctn_bx.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lbl_tear
			// 
			this.lbl_tear.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbl_tear.Location = new System.Drawing.Point(8, 125);
			this.lbl_tear.Name = "lbl_tear";
			this.lbl_tear.Size = new System.Drawing.Size(107, 26);
			this.lbl_tear.TabIndex = 46;
			this.lbl_tear.Text = "Tear";
			this.lbl_tear.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtbx_prod_code
			// 
			this.txtbx_prod_code.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtbx_prod_code.Location = new System.Drawing.Point(140, 32);
			this.txtbx_prod_code.Name = "txtbx_prod_code";
			this.txtbx_prod_code.Size = new System.Drawing.Size(335, 26);
			this.txtbx_prod_code.TabIndex = 1;
			// 
			// lbl_pack
			// 
			this.lbl_pack.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbl_pack.Location = new System.Drawing.Point(8, 93);
			this.lbl_pack.Name = "lbl_pack";
			this.lbl_pack.Size = new System.Drawing.Size(110, 26);
			this.lbl_pack.TabIndex = 42;
			this.lbl_pack.Text = "Pack Type";
			this.lbl_pack.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lbl_tape_end
			// 
			this.lbl_tape_end.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbl_tape_end.Location = new System.Drawing.Point(8, 62);
			this.lbl_tape_end.Name = "lbl_tape_end";
			this.lbl_tape_end.Size = new System.Drawing.Size(110, 26);
			this.lbl_tape_end.TabIndex = 33;
			this.lbl_tape_end.Text = "Tape End";
			this.lbl_tape_end.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lbl_prod_code
			// 
			this.lbl_prod_code.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbl_prod_code.Location = new System.Drawing.Point(8, 33);
			this.lbl_prod_code.Name = "lbl_prod_code";
			this.lbl_prod_code.Size = new System.Drawing.Size(107, 26);
			this.lbl_prod_code.TabIndex = 26;
			this.lbl_prod_code.Text = "Product Code";
			this.lbl_prod_code.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(455, 713);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(100, 23);
			this.label2.TabIndex = 148;
			// 
			// groupBx_record
			// 
			this.groupBx_record.Controls.Add(this.label1);
			this.groupBx_record.Controls.Add(this.txtbx_ctn_bx_search);
			this.groupBx_record.Controls.Add(this.label3);
			this.groupBx_record.Controls.Add(this.txtbx_stock_code);
			this.groupBx_record.Controls.Add(this.dt_grid);
			this.groupBx_record.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.groupBx_record.Location = new System.Drawing.Point(13, 406);
			this.groupBx_record.Name = "groupBx_record";
			this.groupBx_record.Size = new System.Drawing.Size(943, 286);
			this.groupBx_record.TabIndex = 150;
			this.groupBx_record.TabStop = false;
			this.groupBx_record.Text = "Record Saved";
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(344, 32);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(102, 26);
			this.label1.TabIndex = 163;
			this.label1.Text = "Carton Box";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtbx_ctn_bx_search
			// 
			this.txtbx_ctn_bx_search.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtbx_ctn_bx_search.Location = new System.Drawing.Point(459, 33);
			this.txtbx_ctn_bx_search.Margin = new System.Windows.Forms.Padding(1);
			this.txtbx_ctn_bx_search.Name = "txtbx_ctn_bx_search";
			this.txtbx_ctn_bx_search.Size = new System.Drawing.Size(194, 26);
			this.txtbx_ctn_bx_search.TabIndex = 162;
			this.txtbx_ctn_bx_search.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Txtbx_ctn_bx_searchKeyUp);
			// 
			// label3
			// 
			this.label3.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.Location = new System.Drawing.Point(13, 32);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(102, 26);
			this.label3.TabIndex = 161;
			this.label3.Text = "Stock Code";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtbx_stock_code
			// 
			this.txtbx_stock_code.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtbx_stock_code.Location = new System.Drawing.Point(128, 33);
			this.txtbx_stock_code.Margin = new System.Windows.Forms.Padding(1);
			this.txtbx_stock_code.Name = "txtbx_stock_code";
			this.txtbx_stock_code.Size = new System.Drawing.Size(165, 26);
			this.txtbx_stock_code.TabIndex = 160;
			this.txtbx_stock_code.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Txtbx_stock_codeKeyUp);
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
			this.dt_grid.Location = new System.Drawing.Point(17, 72);
			this.dt_grid.MultiSelect = false;
			this.dt_grid.Name = "dt_grid";
			this.dt_grid.ReadOnly = true;
			this.dt_grid.RowHeadersVisible = false;
			this.dt_grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dt_grid.Size = new System.Drawing.Size(906, 193);
			this.dt_grid.TabIndex = 131;
			this.dt_grid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Dt_gridCellClick);
			// 
			// frm_prod_converting_bill
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.AutoScroll = true;
			this.ClientSize = new System.Drawing.Size(1001, 679);
			this.Controls.Add(this.groupBx_record);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.grpbox_info);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.lbl_header);
			this.Controls.Add(this.panel1);
			this.Name = "frm_prod_converting_bill";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Converting Bill of Material";
			this.Load += new System.EventHandler(this.Frm_prod_converting_billLoad);
			this.panel2.ResumeLayout(false);
			this.grpbox_info.ResumeLayout(false);
			this.grpbox_info.PerformLayout();
			this.groupBx_record.ResumeLayout(false);
			this.groupBx_record.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dt_grid)).EndInit();
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox txtbx_ctn_bx_search;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtbx_stock_code;
		private System.Windows.Forms.Label lbl_pallet;
		private System.Windows.Forms.ComboBox cbx_pallet;
		private System.Windows.Forms.Label lbl_pack_type;
		private System.Windows.Forms.ComboBox cbx_pack_type;
		private System.Windows.Forms.TextBox txtbx_ctn_bx;
		private System.Windows.Forms.ComboBox cbx_ctn_bx_code;
		private System.Windows.Forms.Label lbl_ctn_bx_code;
		private System.Windows.Forms.ComboBox cbx_inner_bx;
		private System.Windows.Forms.ComboBox cbx_tear;
		private System.Windows.Forms.ComboBox cbx_pack;
		private System.Windows.Forms.ComboBox cbx_tape_end;
		private System.Windows.Forms.DataGridView dt_grid;
		private System.Windows.Forms.GroupBox groupBx_record;
		private System.Windows.Forms.Label lbl_tear;
		private System.Windows.Forms.Label lbl_ctn_bx;
		private System.Windows.Forms.Label lbl_inner_bx;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button btn_del;
		private System.Windows.Forms.Button btn_save;
		private System.Windows.Forms.Button btn_clear;
		private System.Windows.Forms.Button btn_cancel;
		private System.Windows.Forms.TextBox txtbx_prod_code;
		private System.Windows.Forms.Label lbl_pack;
		private System.Windows.Forms.Label lbl_prod_code;
		private System.Windows.Forms.Label lbl_tape_end;
		private System.Windows.Forms.GroupBox grpbox_info;
		private System.Windows.Forms.Label lbl_header;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label lbl_username;
		private System.Windows.Forms.Panel panel2;
		


	}
}

