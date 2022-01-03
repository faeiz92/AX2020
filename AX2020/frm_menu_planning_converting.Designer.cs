/*
 * Created by SharpDevelop.
 * User: it-4
 * Date: 17/11/2016
 * Time: 9:47 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace AX2020
{
	partial class frm_menu_planning_converting
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
			this.panel1 = new System.Windows.Forms.Panel();
			this.lbl_username = new System.Windows.Forms.Label();
			this.panel2 = new System.Windows.Forms.Panel();
			this.btn_back = new System.Windows.Forms.Button();
			this.btn_bill = new System.Windows.Forms.Button();
			this.grpbx_cutting = new System.Windows.Forms.GroupBox();
			this.btn_cut_output_detail = new System.Windows.Forms.Button();
			this.btn_cut_output = new System.Windows.Forms.Button();
			this.btn_cut_output_shift_fast = new System.Windows.Forms.Button();
			this.btn_cut_output_fast = new System.Windows.Forms.Button();
			this.grpbx_rewind = new System.Windows.Forms.GroupBox();
			this.btn_rewind_output_detail = new System.Windows.Forms.Button();
			this.btn_rewind_output = new System.Windows.Forms.Button();
			this.btn_rewind_output_shift_fast = new System.Windows.Forms.Button();
			this.btn_rewind_output_fast = new System.Windows.Forms.Button();
			this.grpbx_pack = new System.Windows.Forms.GroupBox();
			this.btn_pack_output_detail = new System.Windows.Forms.Button();
			this.btn_pack_output = new System.Windows.Forms.Button();
			this.btn_pack_output_shift_fast = new System.Windows.Forms.Button();
			this.btn_pack_output_fast = new System.Windows.Forms.Button();
			this.btn_slit_output_fast = new System.Windows.Forms.Button();
			this.btn_slit_output_shift_fast = new System.Windows.Forms.Button();
			this.btn_slit_output = new System.Windows.Forms.Button();
			this.btn_slit_output_detail = new System.Windows.Forms.Button();
			this.grpbx_slitting = new System.Windows.Forms.GroupBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.btn_get_so = new System.Windows.Forms.Button();
			this.btn_jo_progress = new System.Windows.Forms.Button();
			this.btn_reprint = new System.Windows.Forms.Button();
			this.btn_JO = new System.Windows.Forms.Button();
			this.btn_prod_track_stat = new System.Windows.Forms.Button();
			this.btn_bill_pcore = new System.Windows.Forms.Button();
			this.btn_prod_bal = new System.Windows.Forms.Button();
			this.btn_backorder_rpt = new System.Windows.Forms.Button();
			this.btn_prod_bal_lr = new System.Windows.Forms.Button();
			this.btn_jr_outstanding = new System.Windows.Forms.Button();
			this.btn_maintenance = new System.Windows.Forms.Button();
			this.panel2.SuspendLayout();
			this.grpbx_cutting.SuspendLayout();
			this.grpbx_rewind.SuspendLayout();
			this.grpbx_pack.SuspendLayout();
			this.grpbx_slitting.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// lbl_header
			// 
			this.lbl_header.BackColor = System.Drawing.Color.DarkCyan;
			this.lbl_header.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbl_header.ForeColor = System.Drawing.SystemColors.ControlLightLight;
			this.lbl_header.Location = new System.Drawing.Point(1, 15);
			this.lbl_header.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
			this.lbl_header.Name = "lbl_header";
			this.lbl_header.Size = new System.Drawing.Size(1000, 23);
			this.lbl_header.TabIndex = 89;
			this.lbl_header.Text = "PLANNING CONVERTING";
			this.lbl_header.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.Color.DarkCyan;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Margin = new System.Windows.Forms.Padding(1);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(1000, 52);
			this.panel1.TabIndex = 90;
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
			this.panel2.Location = new System.Drawing.Point(0, 50);
			this.panel2.Margin = new System.Windows.Forms.Padding(1);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(984, 23);
			this.panel2.TabIndex = 111;
			// 
			// btn_back
			// 
			this.btn_back.BackColor = System.Drawing.Color.Silver;
			this.btn_back.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btn_back.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_back.Location = new System.Drawing.Point(440, 631);
			this.btn_back.Margin = new System.Windows.Forms.Padding(1);
			this.btn_back.Name = "btn_back";
			this.btn_back.Size = new System.Drawing.Size(120, 27);
			this.btn_back.TabIndex = 22;
			this.btn_back.Text = "Cancel";
			this.btn_back.UseVisualStyleBackColor = false;
			this.btn_back.Click += new System.EventHandler(this.Btn_backClick);
			// 
			// btn_bill
			// 
			this.btn_bill.BackColor = System.Drawing.Color.Silver;
			this.btn_bill.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_bill.Location = new System.Drawing.Point(62, 369);
			this.btn_bill.Margin = new System.Windows.Forms.Padding(1);
			this.btn_bill.Name = "btn_bill";
			this.btn_bill.Size = new System.Drawing.Size(251, 35);
			this.btn_bill.TabIndex = 5;
			this.btn_bill.Text = "Bill of Material";
			this.btn_bill.UseVisualStyleBackColor = false;
			this.btn_bill.Click += new System.EventHandler(this.Btn_billClick);
			// 
			// grpbx_cutting
			// 
			this.grpbx_cutting.Controls.Add(this.btn_cut_output_detail);
			this.grpbx_cutting.Controls.Add(this.btn_cut_output);
			this.grpbx_cutting.Controls.Add(this.btn_cut_output_shift_fast);
			this.grpbx_cutting.Controls.Add(this.btn_cut_output_fast);
			this.grpbx_cutting.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.grpbx_cutting.Location = new System.Drawing.Point(351, 359);
			this.grpbx_cutting.Name = "grpbx_cutting";
			this.grpbx_cutting.Size = new System.Drawing.Size(289, 242);
			this.grpbx_cutting.TabIndex = 14;
			this.grpbx_cutting.TabStop = false;
			this.grpbx_cutting.Text = "Cutting";
			// 
			// btn_cut_output_detail
			// 
			this.btn_cut_output_detail.BackColor = System.Drawing.Color.Silver;
			this.btn_cut_output_detail.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_cut_output_detail.Location = new System.Drawing.Point(21, 79);
			this.btn_cut_output_detail.Margin = new System.Windows.Forms.Padding(1);
			this.btn_cut_output_detail.Name = "btn_cut_output_detail";
			this.btn_cut_output_detail.Size = new System.Drawing.Size(251, 46);
			this.btn_cut_output_detail.TabIndex = 15;
			this.btn_cut_output_detail.Text = "Production Output Detail";
			this.btn_cut_output_detail.UseVisualStyleBackColor = false;
			this.btn_cut_output_detail.Click += new System.EventHandler(this.Btn_cut_output_detailClick);
			// 
			// btn_cut_output
			// 
			this.btn_cut_output.BackColor = System.Drawing.Color.Silver;
			this.btn_cut_output.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_cut_output.Location = new System.Drawing.Point(21, 28);
			this.btn_cut_output.Margin = new System.Windows.Forms.Padding(1);
			this.btn_cut_output.Name = "btn_cut_output";
			this.btn_cut_output.Size = new System.Drawing.Size(251, 46);
			this.btn_cut_output.TabIndex = 14;
			this.btn_cut_output.Text = "Production Output";
			this.btn_cut_output.UseVisualStyleBackColor = false;
			this.btn_cut_output.Click += new System.EventHandler(this.Btn_cut_outputClick);
			// 
			// btn_cut_output_shift_fast
			// 
			this.btn_cut_output_shift_fast.BackColor = System.Drawing.Color.Silver;
			this.btn_cut_output_shift_fast.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_cut_output_shift_fast.Location = new System.Drawing.Point(21, 181);
			this.btn_cut_output_shift_fast.Margin = new System.Windows.Forms.Padding(1);
			this.btn_cut_output_shift_fast.Name = "btn_cut_output_shift_fast";
			this.btn_cut_output_shift_fast.Size = new System.Drawing.Size(251, 46);
			this.btn_cut_output_shift_fast.TabIndex = 17;
			this.btn_cut_output_shift_fast.Text = "Production Output Shift - Fast Info";
			this.btn_cut_output_shift_fast.UseVisualStyleBackColor = false;
			this.btn_cut_output_shift_fast.Click += new System.EventHandler(this.Btn_cut_output_shift_fastClick);
			// 
			// btn_cut_output_fast
			// 
			this.btn_cut_output_fast.BackColor = System.Drawing.Color.Silver;
			this.btn_cut_output_fast.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_cut_output_fast.Location = new System.Drawing.Point(21, 130);
			this.btn_cut_output_fast.Margin = new System.Windows.Forms.Padding(1);
			this.btn_cut_output_fast.Name = "btn_cut_output_fast";
			this.btn_cut_output_fast.Size = new System.Drawing.Size(251, 46);
			this.btn_cut_output_fast.TabIndex = 16;
			this.btn_cut_output_fast.Text = "Production Output - Fast Info";
			this.btn_cut_output_fast.UseVisualStyleBackColor = false;
			this.btn_cut_output_fast.Click += new System.EventHandler(this.Btn_cut_output_fastClick);
			// 
			// grpbx_rewind
			// 
			this.grpbx_rewind.Controls.Add(this.btn_rewind_output_detail);
			this.grpbx_rewind.Controls.Add(this.btn_rewind_output);
			this.grpbx_rewind.Controls.Add(this.btn_rewind_output_shift_fast);
			this.grpbx_rewind.Controls.Add(this.btn_rewind_output_fast);
			this.grpbx_rewind.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.grpbx_rewind.Location = new System.Drawing.Point(656, 109);
			this.grpbx_rewind.Name = "grpbx_rewind";
			this.grpbx_rewind.Size = new System.Drawing.Size(291, 244);
			this.grpbx_rewind.TabIndex = 10;
			this.grpbx_rewind.TabStop = false;
			this.grpbx_rewind.Text = "Rewinding";
			// 
			// btn_rewind_output_detail
			// 
			this.btn_rewind_output_detail.BackColor = System.Drawing.Color.Silver;
			this.btn_rewind_output_detail.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_rewind_output_detail.Location = new System.Drawing.Point(21, 79);
			this.btn_rewind_output_detail.Margin = new System.Windows.Forms.Padding(1);
			this.btn_rewind_output_detail.Name = "btn_rewind_output_detail";
			this.btn_rewind_output_detail.Size = new System.Drawing.Size(251, 46);
			this.btn_rewind_output_detail.TabIndex = 11;
			this.btn_rewind_output_detail.Text = "Production Output Detail";
			this.btn_rewind_output_detail.UseVisualStyleBackColor = false;
			this.btn_rewind_output_detail.Click += new System.EventHandler(this.Btn_rewind_output_detailClick);
			// 
			// btn_rewind_output
			// 
			this.btn_rewind_output.BackColor = System.Drawing.Color.Silver;
			this.btn_rewind_output.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_rewind_output.Location = new System.Drawing.Point(21, 28);
			this.btn_rewind_output.Margin = new System.Windows.Forms.Padding(1);
			this.btn_rewind_output.Name = "btn_rewind_output";
			this.btn_rewind_output.Size = new System.Drawing.Size(251, 46);
			this.btn_rewind_output.TabIndex = 10;
			this.btn_rewind_output.Text = "Production Output";
			this.btn_rewind_output.UseVisualStyleBackColor = false;
			this.btn_rewind_output.Click += new System.EventHandler(this.Btn_rewind_outputClick);
			// 
			// btn_rewind_output_shift_fast
			// 
			this.btn_rewind_output_shift_fast.BackColor = System.Drawing.Color.Silver;
			this.btn_rewind_output_shift_fast.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_rewind_output_shift_fast.Location = new System.Drawing.Point(21, 179);
			this.btn_rewind_output_shift_fast.Margin = new System.Windows.Forms.Padding(1);
			this.btn_rewind_output_shift_fast.Name = "btn_rewind_output_shift_fast";
			this.btn_rewind_output_shift_fast.Size = new System.Drawing.Size(251, 46);
			this.btn_rewind_output_shift_fast.TabIndex = 13;
			this.btn_rewind_output_shift_fast.Text = "Production Output Shift - Fast Info";
			this.btn_rewind_output_shift_fast.UseVisualStyleBackColor = false;
			this.btn_rewind_output_shift_fast.Click += new System.EventHandler(this.Btn_rewind_output_shift_fastClick);
			// 
			// btn_rewind_output_fast
			// 
			this.btn_rewind_output_fast.BackColor = System.Drawing.Color.Silver;
			this.btn_rewind_output_fast.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_rewind_output_fast.Location = new System.Drawing.Point(21, 129);
			this.btn_rewind_output_fast.Margin = new System.Windows.Forms.Padding(1);
			this.btn_rewind_output_fast.Name = "btn_rewind_output_fast";
			this.btn_rewind_output_fast.Size = new System.Drawing.Size(251, 46);
			this.btn_rewind_output_fast.TabIndex = 12;
			this.btn_rewind_output_fast.Text = "Production Output - Fast Info";
			this.btn_rewind_output_fast.UseVisualStyleBackColor = false;
			this.btn_rewind_output_fast.Click += new System.EventHandler(this.Btn_rewind_output_fastClick);
			// 
			// grpbx_pack
			// 
			this.grpbx_pack.Controls.Add(this.btn_pack_output_detail);
			this.grpbx_pack.Controls.Add(this.btn_pack_output);
			this.grpbx_pack.Controls.Add(this.btn_pack_output_shift_fast);
			this.grpbx_pack.Controls.Add(this.btn_pack_output_fast);
			this.grpbx_pack.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.grpbx_pack.Location = new System.Drawing.Point(656, 359);
			this.grpbx_pack.Name = "grpbx_pack";
			this.grpbx_pack.Size = new System.Drawing.Size(291, 242);
			this.grpbx_pack.TabIndex = 18;
			this.grpbx_pack.TabStop = false;
			this.grpbx_pack.Text = "Packing";
			// 
			// btn_pack_output_detail
			// 
			this.btn_pack_output_detail.BackColor = System.Drawing.Color.Silver;
			this.btn_pack_output_detail.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_pack_output_detail.Location = new System.Drawing.Point(21, 79);
			this.btn_pack_output_detail.Margin = new System.Windows.Forms.Padding(1);
			this.btn_pack_output_detail.Name = "btn_pack_output_detail";
			this.btn_pack_output_detail.Size = new System.Drawing.Size(251, 46);
			this.btn_pack_output_detail.TabIndex = 19;
			this.btn_pack_output_detail.Text = "Production Output Detail";
			this.btn_pack_output_detail.UseVisualStyleBackColor = false;
			this.btn_pack_output_detail.Click += new System.EventHandler(this.Btn_pack_output_detailClick);
			// 
			// btn_pack_output
			// 
			this.btn_pack_output.BackColor = System.Drawing.Color.Silver;
			this.btn_pack_output.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_pack_output.Location = new System.Drawing.Point(21, 28);
			this.btn_pack_output.Margin = new System.Windows.Forms.Padding(1);
			this.btn_pack_output.Name = "btn_pack_output";
			this.btn_pack_output.Size = new System.Drawing.Size(251, 46);
			this.btn_pack_output.TabIndex = 18;
			this.btn_pack_output.Text = "Production Output";
			this.btn_pack_output.UseVisualStyleBackColor = false;
			this.btn_pack_output.Click += new System.EventHandler(this.Btn_pack_outputClick);
			// 
			// btn_pack_output_shift_fast
			// 
			this.btn_pack_output_shift_fast.BackColor = System.Drawing.Color.Silver;
			this.btn_pack_output_shift_fast.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_pack_output_shift_fast.Location = new System.Drawing.Point(21, 181);
			this.btn_pack_output_shift_fast.Margin = new System.Windows.Forms.Padding(1);
			this.btn_pack_output_shift_fast.Name = "btn_pack_output_shift_fast";
			this.btn_pack_output_shift_fast.Size = new System.Drawing.Size(251, 46);
			this.btn_pack_output_shift_fast.TabIndex = 21;
			this.btn_pack_output_shift_fast.Text = "Production Output Shift - Fast Info";
			this.btn_pack_output_shift_fast.UseVisualStyleBackColor = false;
			this.btn_pack_output_shift_fast.Click += new System.EventHandler(this.Btn_pack_output_shift_fastClick);
			// 
			// btn_pack_output_fast
			// 
			this.btn_pack_output_fast.BackColor = System.Drawing.Color.Silver;
			this.btn_pack_output_fast.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_pack_output_fast.Location = new System.Drawing.Point(21, 130);
			this.btn_pack_output_fast.Margin = new System.Windows.Forms.Padding(1);
			this.btn_pack_output_fast.Name = "btn_pack_output_fast";
			this.btn_pack_output_fast.Size = new System.Drawing.Size(251, 46);
			this.btn_pack_output_fast.TabIndex = 20;
			this.btn_pack_output_fast.Text = "Production Output - Fast Info";
			this.btn_pack_output_fast.UseVisualStyleBackColor = false;
			this.btn_pack_output_fast.Click += new System.EventHandler(this.Btn_pack_output_fastClick);
			// 
			// btn_slit_output_fast
			// 
			this.btn_slit_output_fast.BackColor = System.Drawing.Color.Silver;
			this.btn_slit_output_fast.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_slit_output_fast.Location = new System.Drawing.Point(21, 129);
			this.btn_slit_output_fast.Margin = new System.Windows.Forms.Padding(1);
			this.btn_slit_output_fast.Name = "btn_slit_output_fast";
			this.btn_slit_output_fast.Size = new System.Drawing.Size(251, 46);
			this.btn_slit_output_fast.TabIndex = 8;
			this.btn_slit_output_fast.Text = "Production Output - Fast Info";
			this.btn_slit_output_fast.UseVisualStyleBackColor = false;
			this.btn_slit_output_fast.Click += new System.EventHandler(this.Btn_slit_output_fastClick);
			// 
			// btn_slit_output_shift_fast
			// 
			this.btn_slit_output_shift_fast.BackColor = System.Drawing.Color.Silver;
			this.btn_slit_output_shift_fast.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_slit_output_shift_fast.Location = new System.Drawing.Point(21, 179);
			this.btn_slit_output_shift_fast.Margin = new System.Windows.Forms.Padding(1);
			this.btn_slit_output_shift_fast.Name = "btn_slit_output_shift_fast";
			this.btn_slit_output_shift_fast.Size = new System.Drawing.Size(251, 46);
			this.btn_slit_output_shift_fast.TabIndex = 9;
			this.btn_slit_output_shift_fast.Text = "Production Output Shift - Fast Info";
			this.btn_slit_output_shift_fast.UseVisualStyleBackColor = false;
			this.btn_slit_output_shift_fast.Click += new System.EventHandler(this.Btn_slit_output_shift_fastClick);
			// 
			// btn_slit_output
			// 
			this.btn_slit_output.BackColor = System.Drawing.Color.Silver;
			this.btn_slit_output.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_slit_output.Location = new System.Drawing.Point(21, 28);
			this.btn_slit_output.Margin = new System.Windows.Forms.Padding(1);
			this.btn_slit_output.Name = "btn_slit_output";
			this.btn_slit_output.Size = new System.Drawing.Size(251, 46);
			this.btn_slit_output.TabIndex = 6;
			this.btn_slit_output.Text = "Production Output";
			this.btn_slit_output.UseVisualStyleBackColor = false;
			this.btn_slit_output.Click += new System.EventHandler(this.Btn_slit_outputClick);
			// 
			// btn_slit_output_detail
			// 
			this.btn_slit_output_detail.BackColor = System.Drawing.Color.Silver;
			this.btn_slit_output_detail.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_slit_output_detail.Location = new System.Drawing.Point(21, 79);
			this.btn_slit_output_detail.Margin = new System.Windows.Forms.Padding(1);
			this.btn_slit_output_detail.Name = "btn_slit_output_detail";
			this.btn_slit_output_detail.Size = new System.Drawing.Size(251, 46);
			this.btn_slit_output_detail.TabIndex = 7;
			this.btn_slit_output_detail.Text = "Production Output Detail";
			this.btn_slit_output_detail.UseVisualStyleBackColor = false;
			this.btn_slit_output_detail.Click += new System.EventHandler(this.Btn_slit_output_detailClick);
			// 
			// grpbx_slitting
			// 
			this.grpbx_slitting.Controls.Add(this.btn_slit_output_detail);
			this.grpbx_slitting.Controls.Add(this.btn_slit_output);
			this.grpbx_slitting.Controls.Add(this.btn_slit_output_shift_fast);
			this.grpbx_slitting.Controls.Add(this.btn_slit_output_fast);
			this.grpbx_slitting.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.grpbx_slitting.Location = new System.Drawing.Point(351, 109);
			this.grpbx_slitting.Name = "grpbx_slitting";
			this.grpbx_slitting.Size = new System.Drawing.Size(289, 244);
			this.grpbx_slitting.TabIndex = 6;
			this.grpbx_slitting.TabStop = false;
			this.grpbx_slitting.Text = "Slitting";
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.btn_get_so);
			this.groupBox1.Controls.Add(this.btn_jo_progress);
			this.groupBox1.Controls.Add(this.btn_reprint);
			this.groupBox1.Controls.Add(this.btn_JO);
			this.groupBox1.Controls.Add(this.btn_prod_track_stat);
			this.groupBox1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.groupBox1.Location = new System.Drawing.Point(43, 109);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(289, 244);
			this.groupBox1.TabIndex = 1;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Job Order";
			// 
			// btn_get_so
			// 
			this.btn_get_so.BackColor = System.Drawing.Color.Silver;
			this.btn_get_so.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_get_so.Location = new System.Drawing.Point(19, 188);
			this.btn_get_so.Margin = new System.Windows.Forms.Padding(1);
			this.btn_get_so.Name = "btn_get_so";
			this.btn_get_so.Size = new System.Drawing.Size(251, 35);
			this.btn_get_so.TabIndex = 5;
			this.btn_get_so.Text = "Get Sales Order";
			this.btn_get_so.UseVisualStyleBackColor = false;
			this.btn_get_so.Click += new System.EventHandler(this.Btn_get_soClick);
			// 
			// btn_jo_progress
			// 
			this.btn_jo_progress.BackColor = System.Drawing.Color.Silver;
			this.btn_jo_progress.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_jo_progress.Location = new System.Drawing.Point(19, 108);
			this.btn_jo_progress.Margin = new System.Windows.Forms.Padding(1);
			this.btn_jo_progress.Name = "btn_jo_progress";
			this.btn_jo_progress.Size = new System.Drawing.Size(251, 35);
			this.btn_jo_progress.TabIndex = 3;
			this.btn_jo_progress.Text = "Job Order Progress";
			this.btn_jo_progress.UseVisualStyleBackColor = false;
			this.btn_jo_progress.Click += new System.EventHandler(this.Btn_jo_progressClick);
			// 
			// btn_reprint
			// 
			this.btn_reprint.BackColor = System.Drawing.Color.Silver;
			this.btn_reprint.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_reprint.Location = new System.Drawing.Point(19, 68);
			this.btn_reprint.Margin = new System.Windows.Forms.Padding(1);
			this.btn_reprint.Name = "btn_reprint";
			this.btn_reprint.Size = new System.Drawing.Size(251, 35);
			this.btn_reprint.TabIndex = 2;
			this.btn_reprint.Text = "Reprint Job Order";
			this.btn_reprint.UseVisualStyleBackColor = false;
			this.btn_reprint.Click += new System.EventHandler(this.Btn_reprintClick);
			// 
			// btn_JO
			// 
			this.btn_JO.BackColor = System.Drawing.Color.Silver;
			this.btn_JO.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_JO.Location = new System.Drawing.Point(19, 28);
			this.btn_JO.Margin = new System.Windows.Forms.Padding(1);
			this.btn_JO.Name = "btn_JO";
			this.btn_JO.Size = new System.Drawing.Size(251, 35);
			this.btn_JO.TabIndex = 1;
			this.btn_JO.Text = "Job Order";
			this.btn_JO.UseVisualStyleBackColor = false;
			this.btn_JO.Click += new System.EventHandler(this.Btn_JOClick);
			// 
			// btn_prod_track_stat
			// 
			this.btn_prod_track_stat.BackColor = System.Drawing.Color.Silver;
			this.btn_prod_track_stat.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_prod_track_stat.Location = new System.Drawing.Point(19, 148);
			this.btn_prod_track_stat.Margin = new System.Windows.Forms.Padding(1);
			this.btn_prod_track_stat.Name = "btn_prod_track_stat";
			this.btn_prod_track_stat.Size = new System.Drawing.Size(251, 35);
			this.btn_prod_track_stat.TabIndex = 4;
			this.btn_prod_track_stat.Text = "Job Order Tracking Status";
			this.btn_prod_track_stat.UseVisualStyleBackColor = false;
			this.btn_prod_track_stat.Click += new System.EventHandler(this.Btn_prod_track_statClick);
			// 
			// btn_bill_pcore
			// 
			this.btn_bill_pcore.BackColor = System.Drawing.Color.Silver;
			this.btn_bill_pcore.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_bill_pcore.Location = new System.Drawing.Point(62, 409);
			this.btn_bill_pcore.Margin = new System.Windows.Forms.Padding(1);
			this.btn_bill_pcore.Name = "btn_bill_pcore";
			this.btn_bill_pcore.Size = new System.Drawing.Size(251, 35);
			this.btn_bill_pcore.TabIndex = 112;
			this.btn_bill_pcore.Text = "Bill of Material (Papercore)";
			this.btn_bill_pcore.UseVisualStyleBackColor = false;
			this.btn_bill_pcore.Click += new System.EventHandler(this.Btn_bill_pcoreClick);
			// 
			// btn_prod_bal
			// 
			this.btn_prod_bal.BackColor = System.Drawing.Color.Silver;
			this.btn_prod_bal.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_prod_bal.Location = new System.Drawing.Point(62, 449);
			this.btn_prod_bal.Margin = new System.Windows.Forms.Padding(1);
			this.btn_prod_bal.Name = "btn_prod_bal";
			this.btn_prod_bal.Size = new System.Drawing.Size(251, 35);
			this.btn_prod_bal.TabIndex = 113;
			this.btn_prod_bal.Text = "Production Output - Balance";
			this.btn_prod_bal.UseVisualStyleBackColor = false;
			this.btn_prod_bal.Click += new System.EventHandler(this.Btn_prod_balClick);
			// 
			// btn_backorder_rpt
			// 
			this.btn_backorder_rpt.BackColor = System.Drawing.Color.Silver;
			this.btn_backorder_rpt.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_backorder_rpt.Location = new System.Drawing.Point(62, 489);
			this.btn_backorder_rpt.Margin = new System.Windows.Forms.Padding(1);
			this.btn_backorder_rpt.Name = "btn_backorder_rpt";
			this.btn_backorder_rpt.Size = new System.Drawing.Size(251, 35);
			this.btn_backorder_rpt.TabIndex = 114;
			this.btn_backorder_rpt.Text = "Backorder Report";
			this.btn_backorder_rpt.UseVisualStyleBackColor = false;
			this.btn_backorder_rpt.Click += new System.EventHandler(this.Btn_backorder_rptClick);
			// 
			// btn_prod_bal_lr
			// 
			this.btn_prod_bal_lr.BackColor = System.Drawing.Color.Silver;
			this.btn_prod_bal_lr.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_prod_bal_lr.Location = new System.Drawing.Point(62, 531);
			this.btn_prod_bal_lr.Margin = new System.Windows.Forms.Padding(1);
			this.btn_prod_bal_lr.Name = "btn_prod_bal_lr";
			this.btn_prod_bal_lr.Size = new System.Drawing.Size(251, 35);
			this.btn_prod_bal_lr.TabIndex = 115;
			this.btn_prod_bal_lr.Text = "Production Output - Balance";
			this.btn_prod_bal_lr.UseVisualStyleBackColor = false;
			this.btn_prod_bal_lr.Click += new System.EventHandler(this.Btn_prod_bal_lrClick);
			// 
			// btn_jr_outstanding
			// 
			this.btn_jr_outstanding.BackColor = System.Drawing.Color.Silver;
			this.btn_jr_outstanding.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_jr_outstanding.Location = new System.Drawing.Point(62, 572);
			this.btn_jr_outstanding.Margin = new System.Windows.Forms.Padding(1);
			this.btn_jr_outstanding.Name = "btn_jr_outstanding";
			this.btn_jr_outstanding.Size = new System.Drawing.Size(251, 35);
			this.btn_jr_outstanding.TabIndex = 116;
			this.btn_jr_outstanding.Text = "Converting Outstanding JR";
			this.btn_jr_outstanding.UseVisualStyleBackColor = false;
			this.btn_jr_outstanding.Click += new System.EventHandler(this.Btn_jr_outstandingClick);
			// 
			// btn_maintenance
			// 
			this.btn_maintenance.BackColor = System.Drawing.Color.Silver;
			this.btn_maintenance.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_maintenance.Location = new System.Drawing.Point(677, 605);
			this.btn_maintenance.Margin = new System.Windows.Forms.Padding(1);
			this.btn_maintenance.Name = "btn_maintenance";
			this.btn_maintenance.Size = new System.Drawing.Size(251, 46);
			this.btn_maintenance.TabIndex = 22;
			this.btn_maintenance.Text = "Operator Maintenance";
			this.btn_maintenance.UseVisualStyleBackColor = false;
			this.btn_maintenance.Click += new System.EventHandler(this.Btn_maintenanceClick);
			// 
			// frm_menu_planning_converting
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.CancelButton = this.btn_back;
			this.ClientSize = new System.Drawing.Size(984, 662);
			this.Controls.Add(this.btn_maintenance);
			this.Controls.Add(this.btn_jr_outstanding);
			this.Controls.Add(this.btn_prod_bal_lr);
			this.Controls.Add(this.btn_backorder_rpt);
			this.Controls.Add(this.btn_prod_bal);
			this.Controls.Add(this.btn_bill_pcore);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.grpbx_cutting);
			this.Controls.Add(this.grpbx_slitting);
			this.Controls.Add(this.grpbx_rewind);
			this.Controls.Add(this.grpbx_pack);
			this.Controls.Add(this.btn_bill);
			this.Controls.Add(this.btn_back);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.lbl_header);
			this.Controls.Add(this.panel1);
			this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Name = "frm_menu_planning_converting";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Converting";
			this.panel2.ResumeLayout(false);
			this.grpbx_cutting.ResumeLayout(false);
			this.grpbx_rewind.ResumeLayout(false);
			this.grpbx_pack.ResumeLayout(false);
			this.grpbx_slitting.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.Button btn_maintenance;
		private System.Windows.Forms.Button btn_jr_outstanding;
		private System.Windows.Forms.Button btn_prod_bal_lr;
		private System.Windows.Forms.Button btn_backorder_rpt;
		private System.Windows.Forms.Button btn_get_so;
		private System.Windows.Forms.Button btn_prod_bal;
		private System.Windows.Forms.Button btn_bill_pcore;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.GroupBox grpbx_slitting;
		private System.Windows.Forms.Button btn_slit_output_detail;
		private System.Windows.Forms.Button btn_slit_output;
		private System.Windows.Forms.Button btn_slit_output_shift_fast;
		private System.Windows.Forms.Button btn_slit_output_fast;
		private System.Windows.Forms.Button btn_pack_output_fast;
		private System.Windows.Forms.Button btn_pack_output_shift_fast;
		private System.Windows.Forms.Button btn_pack_output;
		private System.Windows.Forms.Button btn_pack_output_detail;
		private System.Windows.Forms.GroupBox grpbx_pack;
		private System.Windows.Forms.Button btn_rewind_output_fast;
		private System.Windows.Forms.Button btn_rewind_output_shift_fast;
		private System.Windows.Forms.Button btn_rewind_output;
		private System.Windows.Forms.Button btn_rewind_output_detail;
		private System.Windows.Forms.GroupBox grpbx_rewind;
		private System.Windows.Forms.Button btn_cut_output_fast;
		private System.Windows.Forms.Button btn_cut_output_shift_fast;
		private System.Windows.Forms.Button btn_cut_output;
		private System.Windows.Forms.Button btn_cut_output_detail;
		private System.Windows.Forms.GroupBox grpbx_cutting;
		private System.Windows.Forms.Button btn_jo_progress;
		private System.Windows.Forms.Button btn_reprint;
		private System.Windows.Forms.Button btn_bill;
		private System.Windows.Forms.Button btn_JO;
		private System.Windows.Forms.Button btn_back;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Label lbl_username;
		private System.Windows.Forms.Button btn_prod_track_stat;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label lbl_header;
	}
}
