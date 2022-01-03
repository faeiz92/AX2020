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
	partial class frm_menu_converting
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
			this.grpbx_slitting = new System.Windows.Forms.GroupBox();
			this.btn_slit_output_detail = new System.Windows.Forms.Button();
			this.btn_slit_output = new System.Windows.Forms.Button();
			this.btn_slit_output_shift_fast = new System.Windows.Forms.Button();
			this.btn_slit_output_fast = new System.Windows.Forms.Button();
			this.grpbx_pack = new System.Windows.Forms.GroupBox();
			this.btn_pack_output_detail = new System.Windows.Forms.Button();
			this.btn_pack_output = new System.Windows.Forms.Button();
			this.btn_pack_output_shift_fast = new System.Windows.Forms.Button();
			this.btn_pack_output_fast = new System.Windows.Forms.Button();
			this.grpbx_rewind = new System.Windows.Forms.GroupBox();
			this.btn_rewind_output_detail = new System.Windows.Forms.Button();
			this.btn_rewind_output = new System.Windows.Forms.Button();
			this.btn_rewind_output_shift_fast = new System.Windows.Forms.Button();
			this.btn_rewind_output_fast = new System.Windows.Forms.Button();
			this.grpbx_cutting = new System.Windows.Forms.GroupBox();
			this.btn_cut_output_detail = new System.Windows.Forms.Button();
			this.btn_cut_output = new System.Windows.Forms.Button();
			this.btn_cut_output_shift_fast = new System.Windows.Forms.Button();
			this.btn_cut_output_fast = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.btn_rewind_open = new System.Windows.Forms.Button();
			this.btn_stock_receive = new System.Windows.Forms.Button();
			this.btn_slit_pack = new System.Windows.Forms.Button();
			this.btn_pack = new System.Windows.Forms.Button();
			this.btn_slit = new System.Windows.Forms.Button();
			this.btn_cut = new System.Windows.Forms.Button();
			this.btn_rewind = new System.Windows.Forms.Button();
			this.btn_pack_reprint = new System.Windows.Forms.Button();
			this.btn_slit_bal_lbl = new System.Windows.Forms.Button();
			this.btn_jr_bal_rpt = new System.Windows.Forms.Button();
			this.btn_rewind_label = new System.Windows.Forms.Button();
			this.btn_ship_mark = new System.Windows.Forms.Button();
			this.btn_po_pr = new System.Windows.Forms.Button();
			this.btn_prod_track = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			this.btn_jr_bal = new System.Windows.Forms.Button();
			this.btn_print_ax_wl_label = new System.Windows.Forms.Button();
			this.panel2.SuspendLayout();
			this.grpbx_slitting.SuspendLayout();
			this.grpbx_pack.SuspendLayout();
			this.grpbx_rewind.SuspendLayout();
			this.grpbx_cutting.SuspendLayout();
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
			this.lbl_header.Text = "CONVERTING";
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
			this.btn_back.Location = new System.Drawing.Point(440, 663);
			this.btn_back.Margin = new System.Windows.Forms.Padding(1);
			this.btn_back.Name = "btn_back";
			this.btn_back.Size = new System.Drawing.Size(120, 27);
			this.btn_back.TabIndex = 21;
			this.btn_back.Text = "Cancel";
			this.btn_back.UseVisualStyleBackColor = false;
			this.btn_back.Click += new System.EventHandler(this.Btn_backClick);
			// 
			// grpbx_slitting
			// 
			this.grpbx_slitting.Controls.Add(this.btn_slit_output_detail);
			this.grpbx_slitting.Controls.Add(this.btn_slit_output);
			this.grpbx_slitting.Controls.Add(this.btn_slit_output_shift_fast);
			this.grpbx_slitting.Controls.Add(this.btn_slit_output_fast);
			this.grpbx_slitting.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.grpbx_slitting.Location = new System.Drawing.Point(351, 106);
			this.grpbx_slitting.Name = "grpbx_slitting";
			this.grpbx_slitting.Size = new System.Drawing.Size(293, 212);
			this.grpbx_slitting.TabIndex = 5;
			this.grpbx_slitting.TabStop = false;
			this.grpbx_slitting.Text = "Slitting";
			// 
			// btn_slit_output_detail
			// 
			this.btn_slit_output_detail.BackColor = System.Drawing.Color.Silver;
			this.btn_slit_output_detail.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_slit_output_detail.Location = new System.Drawing.Point(21, 70);
			this.btn_slit_output_detail.Margin = new System.Windows.Forms.Padding(1);
			this.btn_slit_output_detail.Name = "btn_slit_output_detail";
			this.btn_slit_output_detail.Size = new System.Drawing.Size(251, 37);
			this.btn_slit_output_detail.TabIndex = 6;
			this.btn_slit_output_detail.Text = "Production Output Detail";
			this.btn_slit_output_detail.UseVisualStyleBackColor = false;
			this.btn_slit_output_detail.Click += new System.EventHandler(this.Btn_slit_output_detailClick);
			// 
			// btn_slit_output
			// 
			this.btn_slit_output.BackColor = System.Drawing.Color.Silver;
			this.btn_slit_output.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_slit_output.Location = new System.Drawing.Point(21, 28);
			this.btn_slit_output.Margin = new System.Windows.Forms.Padding(1);
			this.btn_slit_output.Name = "btn_slit_output";
			this.btn_slit_output.Size = new System.Drawing.Size(251, 37);
			this.btn_slit_output.TabIndex = 5;
			this.btn_slit_output.Text = "Production Output";
			this.btn_slit_output.UseVisualStyleBackColor = false;
			this.btn_slit_output.Click += new System.EventHandler(this.Btn_slit_outputClick);
			// 
			// btn_slit_output_shift_fast
			// 
			this.btn_slit_output_shift_fast.BackColor = System.Drawing.Color.Silver;
			this.btn_slit_output_shift_fast.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_slit_output_shift_fast.Location = new System.Drawing.Point(21, 154);
			this.btn_slit_output_shift_fast.Margin = new System.Windows.Forms.Padding(1);
			this.btn_slit_output_shift_fast.Name = "btn_slit_output_shift_fast";
			this.btn_slit_output_shift_fast.Size = new System.Drawing.Size(251, 37);
			this.btn_slit_output_shift_fast.TabIndex = 8;
			this.btn_slit_output_shift_fast.Text = "Production Output Shift - Fast Info";
			this.btn_slit_output_shift_fast.UseVisualStyleBackColor = false;
			this.btn_slit_output_shift_fast.Click += new System.EventHandler(this.Btn_slit_output_shift_fastClick);
			// 
			// btn_slit_output_fast
			// 
			this.btn_slit_output_fast.BackColor = System.Drawing.Color.Silver;
			this.btn_slit_output_fast.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_slit_output_fast.Location = new System.Drawing.Point(21, 112);
			this.btn_slit_output_fast.Margin = new System.Windows.Forms.Padding(1);
			this.btn_slit_output_fast.Name = "btn_slit_output_fast";
			this.btn_slit_output_fast.Size = new System.Drawing.Size(251, 37);
			this.btn_slit_output_fast.TabIndex = 7;
			this.btn_slit_output_fast.Text = "Production Output - Fast Info";
			this.btn_slit_output_fast.UseVisualStyleBackColor = false;
			this.btn_slit_output_fast.Click += new System.EventHandler(this.Btn_slit_output_fastClick);
			// 
			// grpbx_pack
			// 
			this.grpbx_pack.Controls.Add(this.btn_pack_output_detail);
			this.grpbx_pack.Controls.Add(this.btn_pack_output);
			this.grpbx_pack.Controls.Add(this.btn_pack_output_shift_fast);
			this.grpbx_pack.Controls.Add(this.btn_pack_output_fast);
			this.grpbx_pack.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.grpbx_pack.Location = new System.Drawing.Point(659, 324);
			this.grpbx_pack.Name = "grpbx_pack";
			this.grpbx_pack.Size = new System.Drawing.Size(293, 217);
			this.grpbx_pack.TabIndex = 17;
			this.grpbx_pack.TabStop = false;
			this.grpbx_pack.Text = "Packing";
			// 
			// btn_pack_output_detail
			// 
			this.btn_pack_output_detail.BackColor = System.Drawing.Color.Silver;
			this.btn_pack_output_detail.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_pack_output_detail.Location = new System.Drawing.Point(21, 70);
			this.btn_pack_output_detail.Margin = new System.Windows.Forms.Padding(1);
			this.btn_pack_output_detail.Name = "btn_pack_output_detail";
			this.btn_pack_output_detail.Size = new System.Drawing.Size(251, 37);
			this.btn_pack_output_detail.TabIndex = 18;
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
			this.btn_pack_output.Size = new System.Drawing.Size(251, 37);
			this.btn_pack_output.TabIndex = 17;
			this.btn_pack_output.Text = "Production Output";
			this.btn_pack_output.UseVisualStyleBackColor = false;
			this.btn_pack_output.Click += new System.EventHandler(this.Btn_pack_outputClick);
			// 
			// btn_pack_output_shift_fast
			// 
			this.btn_pack_output_shift_fast.BackColor = System.Drawing.Color.Silver;
			this.btn_pack_output_shift_fast.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_pack_output_shift_fast.Location = new System.Drawing.Point(21, 154);
			this.btn_pack_output_shift_fast.Margin = new System.Windows.Forms.Padding(1);
			this.btn_pack_output_shift_fast.Name = "btn_pack_output_shift_fast";
			this.btn_pack_output_shift_fast.Size = new System.Drawing.Size(251, 37);
			this.btn_pack_output_shift_fast.TabIndex = 20;
			this.btn_pack_output_shift_fast.Text = "Production Output Shift - Fast Info";
			this.btn_pack_output_shift_fast.UseVisualStyleBackColor = false;
			this.btn_pack_output_shift_fast.Click += new System.EventHandler(this.Btn_pack_output_shift_fastClick);
			// 
			// btn_pack_output_fast
			// 
			this.btn_pack_output_fast.BackColor = System.Drawing.Color.Silver;
			this.btn_pack_output_fast.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_pack_output_fast.Location = new System.Drawing.Point(21, 112);
			this.btn_pack_output_fast.Margin = new System.Windows.Forms.Padding(1);
			this.btn_pack_output_fast.Name = "btn_pack_output_fast";
			this.btn_pack_output_fast.Size = new System.Drawing.Size(251, 37);
			this.btn_pack_output_fast.TabIndex = 19;
			this.btn_pack_output_fast.Text = "Production Output - Fast Info";
			this.btn_pack_output_fast.UseVisualStyleBackColor = false;
			this.btn_pack_output_fast.Click += new System.EventHandler(this.Btn_pack_output_fastClick);
			// 
			// grpbx_rewind
			// 
			this.grpbx_rewind.Controls.Add(this.btn_rewind_output_detail);
			this.grpbx_rewind.Controls.Add(this.btn_rewind_output);
			this.grpbx_rewind.Controls.Add(this.btn_rewind_output_shift_fast);
			this.grpbx_rewind.Controls.Add(this.btn_rewind_output_fast);
			this.grpbx_rewind.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.grpbx_rewind.Location = new System.Drawing.Point(659, 107);
			this.grpbx_rewind.Name = "grpbx_rewind";
			this.grpbx_rewind.Size = new System.Drawing.Size(293, 211);
			this.grpbx_rewind.TabIndex = 9;
			this.grpbx_rewind.TabStop = false;
			this.grpbx_rewind.Text = "Rewinding";
			// 
			// btn_rewind_output_detail
			// 
			this.btn_rewind_output_detail.BackColor = System.Drawing.Color.Silver;
			this.btn_rewind_output_detail.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_rewind_output_detail.Location = new System.Drawing.Point(21, 70);
			this.btn_rewind_output_detail.Margin = new System.Windows.Forms.Padding(1);
			this.btn_rewind_output_detail.Name = "btn_rewind_output_detail";
			this.btn_rewind_output_detail.Size = new System.Drawing.Size(251, 37);
			this.btn_rewind_output_detail.TabIndex = 10;
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
			this.btn_rewind_output.Size = new System.Drawing.Size(251, 37);
			this.btn_rewind_output.TabIndex = 9;
			this.btn_rewind_output.Text = "Production Output";
			this.btn_rewind_output.UseVisualStyleBackColor = false;
			this.btn_rewind_output.Click += new System.EventHandler(this.Btn_rewind_outputClick);
			// 
			// btn_rewind_output_shift_fast
			// 
			this.btn_rewind_output_shift_fast.BackColor = System.Drawing.Color.Silver;
			this.btn_rewind_output_shift_fast.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_rewind_output_shift_fast.Location = new System.Drawing.Point(21, 153);
			this.btn_rewind_output_shift_fast.Margin = new System.Windows.Forms.Padding(1);
			this.btn_rewind_output_shift_fast.Name = "btn_rewind_output_shift_fast";
			this.btn_rewind_output_shift_fast.Size = new System.Drawing.Size(251, 37);
			this.btn_rewind_output_shift_fast.TabIndex = 12;
			this.btn_rewind_output_shift_fast.Text = "Production Output Shift - Fast Info";
			this.btn_rewind_output_shift_fast.UseVisualStyleBackColor = false;
			this.btn_rewind_output_shift_fast.Click += new System.EventHandler(this.Btn_rewind_output_shift_fastClick);
			// 
			// btn_rewind_output_fast
			// 
			this.btn_rewind_output_fast.BackColor = System.Drawing.Color.Silver;
			this.btn_rewind_output_fast.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_rewind_output_fast.Location = new System.Drawing.Point(21, 111);
			this.btn_rewind_output_fast.Margin = new System.Windows.Forms.Padding(1);
			this.btn_rewind_output_fast.Name = "btn_rewind_output_fast";
			this.btn_rewind_output_fast.Size = new System.Drawing.Size(251, 37);
			this.btn_rewind_output_fast.TabIndex = 11;
			this.btn_rewind_output_fast.Text = "Production Output - Fast Info";
			this.btn_rewind_output_fast.UseVisualStyleBackColor = false;
			this.btn_rewind_output_fast.Click += new System.EventHandler(this.Btn_rewind_output_fastClick);
			// 
			// grpbx_cutting
			// 
			this.grpbx_cutting.Controls.Add(this.btn_cut_output_detail);
			this.grpbx_cutting.Controls.Add(this.btn_cut_output);
			this.grpbx_cutting.Controls.Add(this.btn_cut_output_shift_fast);
			this.grpbx_cutting.Controls.Add(this.btn_cut_output_fast);
			this.grpbx_cutting.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.grpbx_cutting.Location = new System.Drawing.Point(351, 324);
			this.grpbx_cutting.Name = "grpbx_cutting";
			this.grpbx_cutting.Size = new System.Drawing.Size(293, 217);
			this.grpbx_cutting.TabIndex = 13;
			this.grpbx_cutting.TabStop = false;
			this.grpbx_cutting.Text = "Cutting";
			// 
			// btn_cut_output_detail
			// 
			this.btn_cut_output_detail.BackColor = System.Drawing.Color.Silver;
			this.btn_cut_output_detail.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_cut_output_detail.Location = new System.Drawing.Point(21, 70);
			this.btn_cut_output_detail.Margin = new System.Windows.Forms.Padding(1);
			this.btn_cut_output_detail.Name = "btn_cut_output_detail";
			this.btn_cut_output_detail.Size = new System.Drawing.Size(251, 37);
			this.btn_cut_output_detail.TabIndex = 14;
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
			this.btn_cut_output.Size = new System.Drawing.Size(251, 37);
			this.btn_cut_output.TabIndex = 13;
			this.btn_cut_output.Text = "Production Output";
			this.btn_cut_output.UseVisualStyleBackColor = false;
			this.btn_cut_output.Click += new System.EventHandler(this.Btn_cut_outputClick);
			// 
			// btn_cut_output_shift_fast
			// 
			this.btn_cut_output_shift_fast.BackColor = System.Drawing.Color.Silver;
			this.btn_cut_output_shift_fast.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_cut_output_shift_fast.Location = new System.Drawing.Point(21, 154);
			this.btn_cut_output_shift_fast.Margin = new System.Windows.Forms.Padding(1);
			this.btn_cut_output_shift_fast.Name = "btn_cut_output_shift_fast";
			this.btn_cut_output_shift_fast.Size = new System.Drawing.Size(251, 37);
			this.btn_cut_output_shift_fast.TabIndex = 16;
			this.btn_cut_output_shift_fast.Text = "Production Output Shift - Fast Info";
			this.btn_cut_output_shift_fast.UseVisualStyleBackColor = false;
			this.btn_cut_output_shift_fast.Click += new System.EventHandler(this.Btn_cut_output_shift_fastClick);
			// 
			// btn_cut_output_fast
			// 
			this.btn_cut_output_fast.BackColor = System.Drawing.Color.Silver;
			this.btn_cut_output_fast.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_cut_output_fast.Location = new System.Drawing.Point(21, 112);
			this.btn_cut_output_fast.Margin = new System.Windows.Forms.Padding(1);
			this.btn_cut_output_fast.Name = "btn_cut_output_fast";
			this.btn_cut_output_fast.Size = new System.Drawing.Size(251, 37);
			this.btn_cut_output_fast.TabIndex = 15;
			this.btn_cut_output_fast.Text = "Production Output - Fast Info";
			this.btn_cut_output_fast.UseVisualStyleBackColor = false;
			this.btn_cut_output_fast.Click += new System.EventHandler(this.Btn_cut_output_fastClick);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.btn_rewind_open);
			this.groupBox1.Controls.Add(this.btn_stock_receive);
			this.groupBox1.Controls.Add(this.btn_slit_pack);
			this.groupBox1.Controls.Add(this.btn_pack);
			this.groupBox1.Controls.Add(this.btn_slit);
			this.groupBox1.Controls.Add(this.btn_cut);
			this.groupBox1.Controls.Add(this.btn_rewind);
			this.groupBox1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.groupBox1.Location = new System.Drawing.Point(54, 105);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(284, 292);
			this.groupBox1.TabIndex = 1;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Production Output";
			// 
			// btn_rewind_open
			// 
			this.btn_rewind_open.BackColor = System.Drawing.Color.Silver;
			this.btn_rewind_open.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_rewind_open.Location = new System.Drawing.Point(147, 71);
			this.btn_rewind_open.Margin = new System.Windows.Forms.Padding(1);
			this.btn_rewind_open.Name = "btn_rewind_open";
			this.btn_rewind_open.Size = new System.Drawing.Size(111, 37);
			this.btn_rewind_open.TabIndex = 7;
			this.btn_rewind_open.Text = "Open Rewind";
			this.btn_rewind_open.UseVisualStyleBackColor = false;
			this.btn_rewind_open.Click += new System.EventHandler(this.Btn_rewind_openClick);
			// 
			// btn_stock_receive
			// 
			this.btn_stock_receive.BackColor = System.Drawing.Color.Silver;
			this.btn_stock_receive.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_stock_receive.Location = new System.Drawing.Point(26, 239);
			this.btn_stock_receive.Margin = new System.Windows.Forms.Padding(1);
			this.btn_stock_receive.Name = "btn_stock_receive";
			this.btn_stock_receive.Size = new System.Drawing.Size(231, 37);
			this.btn_stock_receive.TabIndex = 6;
			this.btn_stock_receive.Text = "Converting Stock Receive";
			this.btn_stock_receive.UseVisualStyleBackColor = false;
			this.btn_stock_receive.Click += new System.EventHandler(this.Btn_stock_receiveClick);
			// 
			// btn_slit_pack
			// 
			this.btn_slit_pack.BackColor = System.Drawing.Color.Silver;
			this.btn_slit_pack.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_slit_pack.Location = new System.Drawing.Point(26, 197);
			this.btn_slit_pack.Margin = new System.Windows.Forms.Padding(1);
			this.btn_slit_pack.Name = "btn_slit_pack";
			this.btn_slit_pack.Size = new System.Drawing.Size(231, 37);
			this.btn_slit_pack.TabIndex = 5;
			this.btn_slit_pack.Text = "Slitting + Packing";
			this.btn_slit_pack.UseVisualStyleBackColor = false;
			this.btn_slit_pack.Click += new System.EventHandler(this.btn_slit_packClick);
			// 
			// btn_pack
			// 
			this.btn_pack.BackColor = System.Drawing.Color.Silver;
			this.btn_pack.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_pack.Location = new System.Drawing.Point(26, 155);
			this.btn_pack.Margin = new System.Windows.Forms.Padding(1);
			this.btn_pack.Name = "btn_pack";
			this.btn_pack.Size = new System.Drawing.Size(231, 37);
			this.btn_pack.TabIndex = 4;
			this.btn_pack.Text = "Packing";
			this.btn_pack.UseVisualStyleBackColor = false;
			this.btn_pack.Click += new System.EventHandler(this.Btn_packClick);
			// 
			// btn_slit
			// 
			this.btn_slit.BackColor = System.Drawing.Color.Silver;
			this.btn_slit.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_slit.Location = new System.Drawing.Point(26, 30);
			this.btn_slit.Margin = new System.Windows.Forms.Padding(1);
			this.btn_slit.Name = "btn_slit";
			this.btn_slit.Size = new System.Drawing.Size(231, 37);
			this.btn_slit.TabIndex = 1;
			this.btn_slit.Text = "Slitting";
			this.btn_slit.UseVisualStyleBackColor = false;
			this.btn_slit.Click += new System.EventHandler(this.Btn_slitClick);
			// 
			// btn_cut
			// 
			this.btn_cut.BackColor = System.Drawing.Color.Silver;
			this.btn_cut.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_cut.Location = new System.Drawing.Point(26, 113);
			this.btn_cut.Margin = new System.Windows.Forms.Padding(1);
			this.btn_cut.Name = "btn_cut";
			this.btn_cut.Size = new System.Drawing.Size(231, 37);
			this.btn_cut.TabIndex = 3;
			this.btn_cut.Text = "Cutting";
			this.btn_cut.UseVisualStyleBackColor = false;
			this.btn_cut.Click += new System.EventHandler(this.Btn_cutClick);
			// 
			// btn_rewind
			// 
			this.btn_rewind.BackColor = System.Drawing.Color.Silver;
			this.btn_rewind.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_rewind.Location = new System.Drawing.Point(26, 71);
			this.btn_rewind.Margin = new System.Windows.Forms.Padding(1);
			this.btn_rewind.Name = "btn_rewind";
			this.btn_rewind.Size = new System.Drawing.Size(111, 37);
			this.btn_rewind.TabIndex = 2;
			this.btn_rewind.Text = "Rewinding";
			this.btn_rewind.UseVisualStyleBackColor = false;
			this.btn_rewind.Click += new System.EventHandler(this.Btn_rewindClick);
			// 
			// btn_pack_reprint
			// 
			this.btn_pack_reprint.BackColor = System.Drawing.Color.Silver;
			this.btn_pack_reprint.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_pack_reprint.Location = new System.Drawing.Point(80, 405);
			this.btn_pack_reprint.Margin = new System.Windows.Forms.Padding(1);
			this.btn_pack_reprint.Name = "btn_pack_reprint";
			this.btn_pack_reprint.Size = new System.Drawing.Size(231, 37);
			this.btn_pack_reprint.TabIndex = 5;
			this.btn_pack_reprint.Text = "Reprint Packing";
			this.btn_pack_reprint.UseVisualStyleBackColor = false;
			this.btn_pack_reprint.Click += new System.EventHandler(this.Btn_pack_reprintClick);
			// 
			// btn_slit_bal_lbl
			// 
			this.btn_slit_bal_lbl.BackColor = System.Drawing.Color.Silver;
			this.btn_slit_bal_lbl.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_slit_bal_lbl.Location = new System.Drawing.Point(80, 491);
			this.btn_slit_bal_lbl.Margin = new System.Windows.Forms.Padding(1);
			this.btn_slit_bal_lbl.Name = "btn_slit_bal_lbl";
			this.btn_slit_bal_lbl.Size = new System.Drawing.Size(231, 37);
			this.btn_slit_bal_lbl.TabIndex = 112;
			this.btn_slit_bal_lbl.Text = "JR Balance Label";
			this.btn_slit_bal_lbl.UseVisualStyleBackColor = false;
			this.btn_slit_bal_lbl.Click += new System.EventHandler(this.Btn_slit_balClick);
			// 
			// btn_jr_bal_rpt
			// 
			this.btn_jr_bal_rpt.BackColor = System.Drawing.Color.Silver;
			this.btn_jr_bal_rpt.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_jr_bal_rpt.Location = new System.Drawing.Point(80, 534);
			this.btn_jr_bal_rpt.Margin = new System.Windows.Forms.Padding(1);
			this.btn_jr_bal_rpt.Name = "btn_jr_bal_rpt";
			this.btn_jr_bal_rpt.Size = new System.Drawing.Size(231, 37);
			this.btn_jr_bal_rpt.TabIndex = 113;
			this.btn_jr_bal_rpt.Text = "JR Balance Report";
			this.btn_jr_bal_rpt.UseVisualStyleBackColor = false;
			this.btn_jr_bal_rpt.Click += new System.EventHandler(this.Btn_jr_bal_rptClick);
			// 
			// btn_rewind_label
			// 
			this.btn_rewind_label.BackColor = System.Drawing.Color.Silver;
			this.btn_rewind_label.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_rewind_label.Location = new System.Drawing.Point(80, 447);
			this.btn_rewind_label.Margin = new System.Windows.Forms.Padding(1);
			this.btn_rewind_label.Name = "btn_rewind_label";
			this.btn_rewind_label.Size = new System.Drawing.Size(231, 37);
			this.btn_rewind_label.TabIndex = 114;
			this.btn_rewind_label.Text = "Reprint Rewinding Label";
			this.btn_rewind_label.UseVisualStyleBackColor = false;
			this.btn_rewind_label.Click += new System.EventHandler(this.Btn_rewind_labelClick);
			// 
			// btn_ship_mark
			// 
			this.btn_ship_mark.BackColor = System.Drawing.Color.Silver;
			this.btn_ship_mark.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_ship_mark.Location = new System.Drawing.Point(80, 576);
			this.btn_ship_mark.Margin = new System.Windows.Forms.Padding(1);
			this.btn_ship_mark.Name = "btn_ship_mark";
			this.btn_ship_mark.Size = new System.Drawing.Size(231, 37);
			this.btn_ship_mark.TabIndex = 115;
			this.btn_ship_mark.Text = "JR Balance";
			this.btn_ship_mark.UseVisualStyleBackColor = false;
			this.btn_ship_mark.Click += new System.EventHandler(this.Btn_ship_markClick);
			// 
			// btn_po_pr
			// 
			this.btn_po_pr.BackColor = System.Drawing.Color.Silver;
			this.btn_po_pr.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_po_pr.Location = new System.Drawing.Point(680, 555);
			this.btn_po_pr.Margin = new System.Windows.Forms.Padding(1);
			this.btn_po_pr.Name = "btn_po_pr";
			this.btn_po_pr.Size = new System.Drawing.Size(251, 37);
			this.btn_po_pr.TabIndex = 116;
			this.btn_po_pr.Text = "Purchase Order Via PR";
			this.btn_po_pr.UseVisualStyleBackColor = false;
			this.btn_po_pr.Click += new System.EventHandler(this.Btn_po_prClick);
			// 
			// btn_prod_track
			// 
			this.btn_prod_track.BackColor = System.Drawing.Color.Silver;
			this.btn_prod_track.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_prod_track.Location = new System.Drawing.Point(372, 555);
			this.btn_prod_track.Margin = new System.Windows.Forms.Padding(1);
			this.btn_prod_track.Name = "btn_prod_track";
			this.btn_prod_track.Size = new System.Drawing.Size(251, 37);
			this.btn_prod_track.TabIndex = 117;
			this.btn_prod_track.Text = "Production Tracking";
			this.btn_prod_track.UseVisualStyleBackColor = false;
			this.btn_prod_track.Click += new System.EventHandler(this.Btn_prod_trackClick);
			// 
			// button1
			// 
			this.button1.BackColor = System.Drawing.Color.Silver;
			this.button1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.button1.Location = new System.Drawing.Point(80, 615);
			this.button1.Margin = new System.Windows.Forms.Padding(1);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(231, 37);
			this.button1.TabIndex = 118;
			this.button1.Text = "Small Rewinding";
			this.button1.UseVisualStyleBackColor = false;
			this.button1.Click += new System.EventHandler(this.Button1Click);
			// 
			// btn_jr_bal
			// 
			this.btn_jr_bal.BackColor = System.Drawing.Color.Silver;
			this.btn_jr_bal.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_jr_bal.Location = new System.Drawing.Point(80, 654);
			this.btn_jr_bal.Margin = new System.Windows.Forms.Padding(1);
			this.btn_jr_bal.Name = "btn_jr_bal";
			this.btn_jr_bal.Size = new System.Drawing.Size(231, 37);
			this.btn_jr_bal.TabIndex = 119;
			this.btn_jr_bal.Text = "JR Balance Bal";
			this.btn_jr_bal.UseVisualStyleBackColor = false;
			this.btn_jr_bal.Click += new System.EventHandler(this.Btn_jr_balClick);
			// 
			// btn_print_ax_wl_label
			// 
			this.btn_print_ax_wl_label.BackColor = System.Drawing.Color.Silver;
			this.btn_print_ax_wl_label.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_print_ax_wl_label.Location = new System.Drawing.Point(372, 597);
			this.btn_print_ax_wl_label.Margin = new System.Windows.Forms.Padding(1);
			this.btn_print_ax_wl_label.Name = "btn_print_ax_wl_label";
			this.btn_print_ax_wl_label.Size = new System.Drawing.Size(251, 37);
			this.btn_print_ax_wl_label.TabIndex = 120;
			this.btn_print_ax_wl_label.Text = "Print WL Label";
			this.btn_print_ax_wl_label.UseVisualStyleBackColor = false;
			this.btn_print_ax_wl_label.Click += new System.EventHandler(this.Btn_print_ax_wl_labelClick);
			// 
			// frm_menu_converting
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.AutoScroll = true;
			this.CancelButton = this.btn_back;
			this.ClientSize = new System.Drawing.Size(984, 742);
			this.Controls.Add(this.btn_print_ax_wl_label);
			this.Controls.Add(this.btn_jr_bal);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.btn_prod_track);
			this.Controls.Add(this.btn_po_pr);
			this.Controls.Add(this.btn_ship_mark);
			this.Controls.Add(this.btn_rewind_label);
			this.Controls.Add(this.btn_jr_bal_rpt);
			this.Controls.Add(this.btn_slit_bal_lbl);
			this.Controls.Add(this.btn_pack_reprint);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.grpbx_cutting);
			this.Controls.Add(this.grpbx_rewind);
			this.Controls.Add(this.grpbx_pack);
			this.Controls.Add(this.grpbx_slitting);
			this.Controls.Add(this.btn_back);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.lbl_header);
			this.Controls.Add(this.panel1);
			this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Name = "frm_menu_converting";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Converting";
			this.Load += new System.EventHandler(this.Frm_menu_convertingLoad);
			this.panel2.ResumeLayout(false);
			this.grpbx_slitting.ResumeLayout(false);
			this.grpbx_pack.ResumeLayout(false);
			this.grpbx_rewind.ResumeLayout(false);
			this.grpbx_cutting.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.Button btn_print_ax_wl_label;
		private System.Windows.Forms.Button btn_jr_bal;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button btn_rewind_open;
		private System.Windows.Forms.Button btn_prod_track;
		private System.Windows.Forms.Button btn_stock_receive;
		private System.Windows.Forms.Button btn_po_pr;
		private System.Windows.Forms.Button btn_ship_mark;
		private System.Windows.Forms.Button btn_rewind_label;
		private System.Windows.Forms.Button btn_jr_bal_rpt;
		private System.Windows.Forms.Button btn_slit_bal_lbl;
		private System.Windows.Forms.Button btn_slit_pack;
		private System.Windows.Forms.Button btn_pack_reprint;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Button btn_rewind;
		private System.Windows.Forms.Button btn_cut;
		private System.Windows.Forms.Button btn_slit;
		private System.Windows.Forms.Button btn_pack;
		private System.Windows.Forms.Button btn_cut_output_fast;
		private System.Windows.Forms.Button btn_cut_output_shift_fast;
		private System.Windows.Forms.Button btn_cut_output;
		private System.Windows.Forms.Button btn_cut_output_detail;
		private System.Windows.Forms.GroupBox grpbx_cutting;
		private System.Windows.Forms.Button btn_rewind_output_fast;
		private System.Windows.Forms.Button btn_rewind_output_shift_fast;
		private System.Windows.Forms.Button btn_rewind_output;
		private System.Windows.Forms.Button btn_rewind_output_detail;
		private System.Windows.Forms.GroupBox grpbx_rewind;
		private System.Windows.Forms.Button btn_pack_output_fast;
		private System.Windows.Forms.Button btn_pack_output_shift_fast;
		private System.Windows.Forms.Button btn_pack_output;
		private System.Windows.Forms.Button btn_pack_output_detail;
		private System.Windows.Forms.GroupBox grpbx_pack;
		private System.Windows.Forms.Button btn_slit_output;
		private System.Windows.Forms.Button btn_slit_output_detail;
		private System.Windows.Forms.GroupBox grpbx_slitting;
		private System.Windows.Forms.Button btn_slit_output_shift_fast;
		private System.Windows.Forms.Button btn_slit_output_fast;
		private System.Windows.Forms.Button btn_back;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Label lbl_username;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label lbl_header;
		
	}
}
