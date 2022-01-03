/*
 * Created by SharpDevelop.
 * User: ax2020-1
 * Date: 2/20/2017
 * Time: 9:33 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace AX2020
{
	partial class frm_menu_management
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
			this.btn_prod_track_stat = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.btn_get_so = new System.Windows.Forms.Button();
			this.grpbx_cutting = new System.Windows.Forms.GroupBox();
			this.btn_cut_output_detail = new System.Windows.Forms.Button();
			this.btn_cut_output = new System.Windows.Forms.Button();
			this.btn_cut_output_shift_fast = new System.Windows.Forms.Button();
			this.btn_cut_output_fast = new System.Windows.Forms.Button();
			this.grpbx_slitting = new System.Windows.Forms.GroupBox();
			this.btn_slit_output_detail = new System.Windows.Forms.Button();
			this.btn_slit_output = new System.Windows.Forms.Button();
			this.btn_slit_output_shift_fast = new System.Windows.Forms.Button();
			this.btn_slit_output_fast = new System.Windows.Forms.Button();
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
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.btn_po = new System.Windows.Forms.Button();
			this.btn_cjsm = new System.Windows.Forms.Button();
			this.btn_podj = new System.Windows.Forms.Button();
			this.btn_ple = new System.Windows.Forms.Button();
			this.btn_pod = new System.Windows.Forms.Button();
			this.btn_cjso = new System.Windows.Forms.Button();
			this.btn_pw = new System.Windows.Forms.Button();
			this.btn_pb = new System.Windows.Forms.Button();
			this.btn_pc = new System.Windows.Forms.Button();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.button3 = new System.Windows.Forms.Button();
			this.btn_item_master = new System.Windows.Forms.Button();
			this.panel2.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.grpbx_cutting.SuspendLayout();
			this.grpbx_slitting.SuspendLayout();
			this.grpbx_rewind.SuspendLayout();
			this.grpbx_pack.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.groupBox2.SuspendLayout();
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
			this.lbl_header.Text = "Management";
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
			this.panel2.Size = new System.Drawing.Size(1000, 23);
			this.panel2.TabIndex = 111;
			// 
			// btn_back
			// 
			this.btn_back.BackColor = System.Drawing.Color.Silver;
			this.btn_back.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btn_back.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_back.Location = new System.Drawing.Point(440, 615);
			this.btn_back.Margin = new System.Windows.Forms.Padding(1);
			this.btn_back.Name = "btn_back";
			this.btn_back.Size = new System.Drawing.Size(120, 27);
			this.btn_back.TabIndex = 114;
			this.btn_back.Text = "Cancel";
			this.btn_back.UseVisualStyleBackColor = false;
			this.btn_back.Click += new System.EventHandler(this.Btn_backClick);
			// 
			// btn_prod_track_stat
			// 
			this.btn_prod_track_stat.BackColor = System.Drawing.Color.Silver;
			this.btn_prod_track_stat.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_prod_track_stat.Location = new System.Drawing.Point(33, 436);
			this.btn_prod_track_stat.Margin = new System.Windows.Forms.Padding(1);
			this.btn_prod_track_stat.Name = "btn_prod_track_stat";
			this.btn_prod_track_stat.Size = new System.Drawing.Size(251, 35);
			this.btn_prod_track_stat.TabIndex = 1;
			this.btn_prod_track_stat.Text = "Job Order Tracking Status";
			this.btn_prod_track_stat.UseVisualStyleBackColor = false;
			this.btn_prod_track_stat.Click += new System.EventHandler(this.Btn_prod_track_statClick);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.btn_get_so);
			this.groupBox1.Controls.Add(this.grpbx_cutting);
			this.groupBox1.Controls.Add(this.grpbx_slitting);
			this.groupBox1.Controls.Add(this.btn_prod_track_stat);
			this.groupBox1.Controls.Add(this.grpbx_rewind);
			this.groupBox1.Controls.Add(this.grpbx_pack);
			this.groupBox1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.groupBox1.Location = new System.Drawing.Point(342, 82);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(620, 482);
			this.groupBox1.TabIndex = 117;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Converting Report";
			// 
			// btn_get_so
			// 
			this.btn_get_so.BackColor = System.Drawing.Color.Silver;
			this.btn_get_so.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_get_so.Location = new System.Drawing.Point(338, 436);
			this.btn_get_so.Margin = new System.Windows.Forms.Padding(1);
			this.btn_get_so.Name = "btn_get_so";
			this.btn_get_so.Size = new System.Drawing.Size(251, 35);
			this.btn_get_so.TabIndex = 123;
			this.btn_get_so.Text = "Get Sales Order";
			this.btn_get_so.UseVisualStyleBackColor = false;
			this.btn_get_so.Click += new System.EventHandler(this.Btn_get_soClick);
			// 
			// grpbx_cutting
			// 
			this.grpbx_cutting.Controls.Add(this.btn_cut_output_detail);
			this.grpbx_cutting.Controls.Add(this.btn_cut_output);
			this.grpbx_cutting.Controls.Add(this.btn_cut_output_shift_fast);
			this.grpbx_cutting.Controls.Add(this.btn_cut_output_fast);
			this.grpbx_cutting.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.grpbx_cutting.Location = new System.Drawing.Point(12, 237);
			this.grpbx_cutting.Name = "grpbx_cutting";
			this.grpbx_cutting.Size = new System.Drawing.Size(289, 191);
			this.grpbx_cutting.TabIndex = 121;
			this.grpbx_cutting.TabStop = false;
			this.grpbx_cutting.Text = "Cutting";
			// 
			// btn_cut_output_detail
			// 
			this.btn_cut_output_detail.BackColor = System.Drawing.Color.Silver;
			this.btn_cut_output_detail.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_cut_output_detail.Location = new System.Drawing.Point(21, 63);
			this.btn_cut_output_detail.Margin = new System.Windows.Forms.Padding(1);
			this.btn_cut_output_detail.Name = "btn_cut_output_detail";
			this.btn_cut_output_detail.Size = new System.Drawing.Size(251, 35);
			this.btn_cut_output_detail.TabIndex = 15;
			this.btn_cut_output_detail.Text = "Production Output Detail";
			this.btn_cut_output_detail.UseVisualStyleBackColor = false;
			this.btn_cut_output_detail.Click += new System.EventHandler(this.Btn_cut_output_detailClick);
			// 
			// btn_cut_output
			// 
			this.btn_cut_output.BackColor = System.Drawing.Color.Silver;
			this.btn_cut_output.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_cut_output.Location = new System.Drawing.Point(21, 22);
			this.btn_cut_output.Margin = new System.Windows.Forms.Padding(1);
			this.btn_cut_output.Name = "btn_cut_output";
			this.btn_cut_output.Size = new System.Drawing.Size(251, 35);
			this.btn_cut_output.TabIndex = 14;
			this.btn_cut_output.Text = "Production Output";
			this.btn_cut_output.UseVisualStyleBackColor = false;
			this.btn_cut_output.Click += new System.EventHandler(this.Btn_cut_outputClick);
			// 
			// btn_cut_output_shift_fast
			// 
			this.btn_cut_output_shift_fast.BackColor = System.Drawing.Color.Silver;
			this.btn_cut_output_shift_fast.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_cut_output_shift_fast.Location = new System.Drawing.Point(21, 143);
			this.btn_cut_output_shift_fast.Margin = new System.Windows.Forms.Padding(1);
			this.btn_cut_output_shift_fast.Name = "btn_cut_output_shift_fast";
			this.btn_cut_output_shift_fast.Size = new System.Drawing.Size(251, 35);
			this.btn_cut_output_shift_fast.TabIndex = 17;
			this.btn_cut_output_shift_fast.Text = "Production Output Shift - Fast Info";
			this.btn_cut_output_shift_fast.UseVisualStyleBackColor = false;
			this.btn_cut_output_shift_fast.Click += new System.EventHandler(this.Btn_cut_output_shift_fastClick);
			// 
			// btn_cut_output_fast
			// 
			this.btn_cut_output_fast.BackColor = System.Drawing.Color.Silver;
			this.btn_cut_output_fast.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_cut_output_fast.Location = new System.Drawing.Point(21, 102);
			this.btn_cut_output_fast.Margin = new System.Windows.Forms.Padding(1);
			this.btn_cut_output_fast.Name = "btn_cut_output_fast";
			this.btn_cut_output_fast.Size = new System.Drawing.Size(251, 35);
			this.btn_cut_output_fast.TabIndex = 16;
			this.btn_cut_output_fast.Text = "Production Output - Fast Info";
			this.btn_cut_output_fast.UseVisualStyleBackColor = false;
			this.btn_cut_output_fast.Click += new System.EventHandler(this.Btn_cut_output_fastClick);
			// 
			// grpbx_slitting
			// 
			this.grpbx_slitting.Controls.Add(this.btn_slit_output_detail);
			this.grpbx_slitting.Controls.Add(this.btn_slit_output);
			this.grpbx_slitting.Controls.Add(this.btn_slit_output_shift_fast);
			this.grpbx_slitting.Controls.Add(this.btn_slit_output_fast);
			this.grpbx_slitting.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.grpbx_slitting.Location = new System.Drawing.Point(12, 25);
			this.grpbx_slitting.Name = "grpbx_slitting";
			this.grpbx_slitting.Size = new System.Drawing.Size(289, 206);
			this.grpbx_slitting.TabIndex = 119;
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
			this.btn_slit_output_detail.Size = new System.Drawing.Size(251, 35);
			this.btn_slit_output_detail.TabIndex = 7;
			this.btn_slit_output_detail.Text = "Production Output Detail";
			this.btn_slit_output_detail.UseVisualStyleBackColor = false;
			this.btn_slit_output_detail.Click += new System.EventHandler(this.Btn_slit_output_detailClick);
			// 
			// btn_slit_output
			// 
			this.btn_slit_output.BackColor = System.Drawing.Color.Silver;
			this.btn_slit_output.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_slit_output.Location = new System.Drawing.Point(21, 30);
			this.btn_slit_output.Margin = new System.Windows.Forms.Padding(1);
			this.btn_slit_output.Name = "btn_slit_output";
			this.btn_slit_output.Size = new System.Drawing.Size(251, 35);
			this.btn_slit_output.TabIndex = 6;
			this.btn_slit_output.Text = "Production Output";
			this.btn_slit_output.UseVisualStyleBackColor = false;
			this.btn_slit_output.Click += new System.EventHandler(this.Btn_slit_outputClick);
			// 
			// btn_slit_output_shift_fast
			// 
			this.btn_slit_output_shift_fast.BackColor = System.Drawing.Color.Silver;
			this.btn_slit_output_shift_fast.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_slit_output_shift_fast.Location = new System.Drawing.Point(21, 152);
			this.btn_slit_output_shift_fast.Margin = new System.Windows.Forms.Padding(1);
			this.btn_slit_output_shift_fast.Name = "btn_slit_output_shift_fast";
			this.btn_slit_output_shift_fast.Size = new System.Drawing.Size(251, 35);
			this.btn_slit_output_shift_fast.TabIndex = 9;
			this.btn_slit_output_shift_fast.Text = "Production Output Shift - Fast Info";
			this.btn_slit_output_shift_fast.UseVisualStyleBackColor = false;
			this.btn_slit_output_shift_fast.Click += new System.EventHandler(this.Btn_slit_output_shift_fastClick);
			// 
			// btn_slit_output_fast
			// 
			this.btn_slit_output_fast.BackColor = System.Drawing.Color.Silver;
			this.btn_slit_output_fast.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_slit_output_fast.Location = new System.Drawing.Point(21, 111);
			this.btn_slit_output_fast.Margin = new System.Windows.Forms.Padding(1);
			this.btn_slit_output_fast.Name = "btn_slit_output_fast";
			this.btn_slit_output_fast.Size = new System.Drawing.Size(251, 35);
			this.btn_slit_output_fast.TabIndex = 8;
			this.btn_slit_output_fast.Text = "Production Output - Fast Info";
			this.btn_slit_output_fast.UseVisualStyleBackColor = false;
			this.btn_slit_output_fast.Click += new System.EventHandler(this.Btn_slit_output_fastClick);
			// 
			// grpbx_rewind
			// 
			this.grpbx_rewind.Controls.Add(this.btn_rewind_output_detail);
			this.grpbx_rewind.Controls.Add(this.btn_rewind_output);
			this.grpbx_rewind.Controls.Add(this.btn_rewind_output_shift_fast);
			this.grpbx_rewind.Controls.Add(this.btn_rewind_output_fast);
			this.grpbx_rewind.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.grpbx_rewind.Location = new System.Drawing.Point(317, 25);
			this.grpbx_rewind.Name = "grpbx_rewind";
			this.grpbx_rewind.Size = new System.Drawing.Size(291, 206);
			this.grpbx_rewind.TabIndex = 120;
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
			this.btn_rewind_output_detail.Size = new System.Drawing.Size(251, 35);
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
			this.btn_rewind_output.Size = new System.Drawing.Size(251, 35);
			this.btn_rewind_output.TabIndex = 10;
			this.btn_rewind_output.Text = "Production Output";
			this.btn_rewind_output.UseVisualStyleBackColor = false;
			this.btn_rewind_output.Click += new System.EventHandler(this.Btn_rewind_outputClick);
			// 
			// btn_rewind_output_shift_fast
			// 
			this.btn_rewind_output_shift_fast.BackColor = System.Drawing.Color.Silver;
			this.btn_rewind_output_shift_fast.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_rewind_output_shift_fast.Location = new System.Drawing.Point(21, 151);
			this.btn_rewind_output_shift_fast.Margin = new System.Windows.Forms.Padding(1);
			this.btn_rewind_output_shift_fast.Name = "btn_rewind_output_shift_fast";
			this.btn_rewind_output_shift_fast.Size = new System.Drawing.Size(251, 35);
			this.btn_rewind_output_shift_fast.TabIndex = 13;
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
			this.btn_rewind_output_fast.Size = new System.Drawing.Size(251, 35);
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
			this.grpbx_pack.Location = new System.Drawing.Point(317, 237);
			this.grpbx_pack.Name = "grpbx_pack";
			this.grpbx_pack.Size = new System.Drawing.Size(291, 191);
			this.grpbx_pack.TabIndex = 122;
			this.grpbx_pack.TabStop = false;
			this.grpbx_pack.Text = "Packing";
			// 
			// btn_pack_output_detail
			// 
			this.btn_pack_output_detail.BackColor = System.Drawing.Color.Silver;
			this.btn_pack_output_detail.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_pack_output_detail.Location = new System.Drawing.Point(21, 63);
			this.btn_pack_output_detail.Margin = new System.Windows.Forms.Padding(1);
			this.btn_pack_output_detail.Name = "btn_pack_output_detail";
			this.btn_pack_output_detail.Size = new System.Drawing.Size(251, 35);
			this.btn_pack_output_detail.TabIndex = 19;
			this.btn_pack_output_detail.Text = "Production Output Detail";
			this.btn_pack_output_detail.UseVisualStyleBackColor = false;
			this.btn_pack_output_detail.Click += new System.EventHandler(this.Btn_pack_output_detailClick);
			// 
			// btn_pack_output
			// 
			this.btn_pack_output.BackColor = System.Drawing.Color.Silver;
			this.btn_pack_output.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_pack_output.Location = new System.Drawing.Point(21, 22);
			this.btn_pack_output.Margin = new System.Windows.Forms.Padding(1);
			this.btn_pack_output.Name = "btn_pack_output";
			this.btn_pack_output.Size = new System.Drawing.Size(251, 35);
			this.btn_pack_output.TabIndex = 18;
			this.btn_pack_output.Text = "Production Output";
			this.btn_pack_output.UseVisualStyleBackColor = false;
			this.btn_pack_output.Click += new System.EventHandler(this.Btn_pack_outputClick);
			// 
			// btn_pack_output_shift_fast
			// 
			this.btn_pack_output_shift_fast.BackColor = System.Drawing.Color.Silver;
			this.btn_pack_output_shift_fast.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_pack_output_shift_fast.Location = new System.Drawing.Point(21, 143);
			this.btn_pack_output_shift_fast.Margin = new System.Windows.Forms.Padding(1);
			this.btn_pack_output_shift_fast.Name = "btn_pack_output_shift_fast";
			this.btn_pack_output_shift_fast.Size = new System.Drawing.Size(251, 35);
			this.btn_pack_output_shift_fast.TabIndex = 21;
			this.btn_pack_output_shift_fast.Text = "Production Output Shift - Fast Info";
			this.btn_pack_output_shift_fast.UseVisualStyleBackColor = false;
			this.btn_pack_output_shift_fast.Click += new System.EventHandler(this.Btn_pack_output_shift_fastClick);
			// 
			// btn_pack_output_fast
			// 
			this.btn_pack_output_fast.BackColor = System.Drawing.Color.Silver;
			this.btn_pack_output_fast.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_pack_output_fast.Location = new System.Drawing.Point(21, 104);
			this.btn_pack_output_fast.Margin = new System.Windows.Forms.Padding(1);
			this.btn_pack_output_fast.Name = "btn_pack_output_fast";
			this.btn_pack_output_fast.Size = new System.Drawing.Size(251, 35);
			this.btn_pack_output_fast.TabIndex = 20;
			this.btn_pack_output_fast.Text = "Production Output - Fast Info";
			this.btn_pack_output_fast.UseVisualStyleBackColor = false;
			this.btn_pack_output_fast.Click += new System.EventHandler(this.Btn_pack_output_fastClick);
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.btn_po);
			this.groupBox3.Controls.Add(this.btn_cjsm);
			this.groupBox3.Controls.Add(this.btn_podj);
			this.groupBox3.Controls.Add(this.btn_ple);
			this.groupBox3.Controls.Add(this.btn_pod);
			this.groupBox3.Controls.Add(this.btn_cjso);
			this.groupBox3.Controls.Add(this.btn_pw);
			this.groupBox3.Controls.Add(this.btn_pb);
			this.groupBox3.Controls.Add(this.btn_pc);
			this.groupBox3.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.groupBox3.Location = new System.Drawing.Point(29, 82);
			this.groupBox3.Margin = new System.Windows.Forms.Padding(2);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Padding = new System.Windows.Forms.Padding(2);
			this.groupBox3.Size = new System.Drawing.Size(290, 406);
			this.groupBox3.TabIndex = 118;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Coating Report";
			// 
			// btn_po
			// 
			this.btn_po.BackColor = System.Drawing.Color.Silver;
			this.btn_po.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_po.Location = new System.Drawing.Point(21, 29);
			this.btn_po.Margin = new System.Windows.Forms.Padding(2);
			this.btn_po.Name = "btn_po";
			this.btn_po.Size = new System.Drawing.Size(251, 35);
			this.btn_po.TabIndex = 26;
			this.btn_po.Text = "Production Output";
			this.btn_po.UseVisualStyleBackColor = false;
			this.btn_po.Click += new System.EventHandler(this.Btn_poClick);
			// 
			// btn_cjsm
			// 
			this.btn_cjsm.BackColor = System.Drawing.Color.Silver;
			this.btn_cjsm.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_cjsm.Location = new System.Drawing.Point(21, 151);
			this.btn_cjsm.Margin = new System.Windows.Forms.Padding(2);
			this.btn_cjsm.Name = "btn_cjsm";
			this.btn_cjsm.Size = new System.Drawing.Size(251, 35);
			this.btn_cjsm.TabIndex = 25;
			this.btn_cjsm.Text = "Check JR Shipping Mark";
			this.btn_cjsm.UseVisualStyleBackColor = false;
			this.btn_cjsm.Click += new System.EventHandler(this.Btn_cjsmClick);
			// 
			// btn_podj
			// 
			this.btn_podj.BackColor = System.Drawing.Color.Silver;
			this.btn_podj.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_podj.Location = new System.Drawing.Point(21, 275);
			this.btn_podj.Margin = new System.Windows.Forms.Padding(2);
			this.btn_podj.Name = "btn_podj";
			this.btn_podj.Size = new System.Drawing.Size(251, 35);
			this.btn_podj.TabIndex = 24;
			this.btn_podj.Text = "Production Output Detail Jo";
			this.btn_podj.UseVisualStyleBackColor = false;
			this.btn_podj.Click += new System.EventHandler(this.Btn_podjClick);
			// 
			// btn_ple
			// 
			this.btn_ple.BackColor = System.Drawing.Color.Silver;
			this.btn_ple.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_ple.Location = new System.Drawing.Point(21, 357);
			this.btn_ple.Margin = new System.Windows.Forms.Padding(2);
			this.btn_ple.Name = "btn_ple";
			this.btn_ple.Size = new System.Drawing.Size(251, 35);
			this.btn_ple.TabIndex = 23;
			this.btn_ple.Text = "Product Local Extra";
			this.btn_ple.UseVisualStyleBackColor = false;
			this.btn_ple.Click += new System.EventHandler(this.Btn_pleClick);
			// 
			// btn_pod
			// 
			this.btn_pod.BackColor = System.Drawing.Color.Silver;
			this.btn_pod.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_pod.Location = new System.Drawing.Point(21, 110);
			this.btn_pod.Margin = new System.Windows.Forms.Padding(2);
			this.btn_pod.Name = "btn_pod";
			this.btn_pod.Size = new System.Drawing.Size(251, 35);
			this.btn_pod.TabIndex = 22;
			this.btn_pod.Text = "Production Output Detail";
			this.btn_pod.UseVisualStyleBackColor = false;
			this.btn_pod.Click += new System.EventHandler(this.Btn_podClick);
			// 
			// btn_cjso
			// 
			this.btn_cjso.BackColor = System.Drawing.Color.Silver;
			this.btn_cjso.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_cjso.Location = new System.Drawing.Point(21, 316);
			this.btn_cjso.Margin = new System.Windows.Forms.Padding(2);
			this.btn_cjso.Name = "btn_cjso";
			this.btn_cjso.Size = new System.Drawing.Size(251, 35);
			this.btn_cjso.TabIndex = 21;
			this.btn_cjso.Text = "Check Jr Sales Order";
			this.btn_cjso.UseVisualStyleBackColor = false;
			this.btn_cjso.Click += new System.EventHandler(this.Btn_cjsoClick);
			// 
			// btn_pw
			// 
			this.btn_pw.BackColor = System.Drawing.Color.Silver;
			this.btn_pw.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_pw.Location = new System.Drawing.Point(21, 234);
			this.btn_pw.Margin = new System.Windows.Forms.Padding(2);
			this.btn_pw.Name = "btn_pw";
			this.btn_pw.Size = new System.Drawing.Size(251, 35);
			this.btn_pw.TabIndex = 20;
			this.btn_pw.Text = "Production Wastage";
			this.btn_pw.UseVisualStyleBackColor = false;
			this.btn_pw.Click += new System.EventHandler(this.Btn_pwClick);
			// 
			// btn_pb
			// 
			this.btn_pb.BackColor = System.Drawing.Color.Silver;
			this.btn_pb.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_pb.Location = new System.Drawing.Point(21, 70);
			this.btn_pb.Margin = new System.Windows.Forms.Padding(2);
			this.btn_pb.Name = "btn_pb";
			this.btn_pb.Size = new System.Drawing.Size(251, 35);
			this.btn_pb.TabIndex = 19;
			this.btn_pb.Text = "Production B-Grade";
			this.btn_pb.UseVisualStyleBackColor = false;
			this.btn_pb.Click += new System.EventHandler(this.Btn_pbClick);
			// 
			// btn_pc
			// 
			this.btn_pc.BackColor = System.Drawing.Color.Silver;
			this.btn_pc.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_pc.Location = new System.Drawing.Point(21, 192);
			this.btn_pc.Margin = new System.Windows.Forms.Padding(2);
			this.btn_pc.Name = "btn_pc";
			this.btn_pc.Size = new System.Drawing.Size(251, 35);
			this.btn_pc.TabIndex = 18;
			this.btn_pc.Text = "Production Consumption";
			this.btn_pc.UseVisualStyleBackColor = false;
			this.btn_pc.Click += new System.EventHandler(this.Btn_pcClick);
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.button1);
			this.groupBox2.Controls.Add(this.button2);
			this.groupBox2.Controls.Add(this.button3);
			this.groupBox2.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.groupBox2.Location = new System.Drawing.Point(28, 493);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(307, 157);
			this.groupBox2.TabIndex = 119;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "GLUE REPORT";
			// 
			// button1
			// 
			this.button1.BackColor = System.Drawing.Color.Silver;
			this.button1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.button1.Location = new System.Drawing.Point(28, 25);
			this.button1.Margin = new System.Windows.Forms.Padding(2);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(251, 35);
			this.button1.TabIndex = 27;
			this.button1.Text = "Output";
			this.button1.UseVisualStyleBackColor = false;
			this.button1.Click += new System.EventHandler(this.Button1Click);
			// 
			// button2
			// 
			this.button2.BackColor = System.Drawing.Color.Silver;
			this.button2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.button2.Location = new System.Drawing.Point(28, 107);
			this.button2.Margin = new System.Windows.Forms.Padding(2);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(251, 35);
			this.button2.TabIndex = 26;
			this.button2.Text = "Consumption";
			this.button2.UseVisualStyleBackColor = false;
			this.button2.Click += new System.EventHandler(this.Button2Click);
			// 
			// button3
			// 
			this.button3.BackColor = System.Drawing.Color.Silver;
			this.button3.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.button3.Location = new System.Drawing.Point(28, 66);
			this.button3.Margin = new System.Windows.Forms.Padding(2);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(251, 35);
			this.button3.TabIndex = 25;
			this.button3.Text = "Consume";
			this.button3.UseVisualStyleBackColor = false;
			this.button3.Click += new System.EventHandler(this.Button3Click);
			// 
			// btn_item_master
			// 
			this.btn_item_master.BackColor = System.Drawing.Color.Silver;
			this.btn_item_master.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_item_master.Location = new System.Drawing.Point(680, 573);
			this.btn_item_master.Margin = new System.Windows.Forms.Padding(1);
			this.btn_item_master.Name = "btn_item_master";
			this.btn_item_master.Size = new System.Drawing.Size(251, 35);
			this.btn_item_master.TabIndex = 124;
			this.btn_item_master.Text = "AX Item Master";
			this.btn_item_master.UseVisualStyleBackColor = false;
			this.btn_item_master.Click += new System.EventHandler(this.Btn_item_masterClick);
			// 
			// frm_menu_management
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.CancelButton = this.btn_back;
			this.ClientSize = new System.Drawing.Size(984, 662);
			this.Controls.Add(this.btn_item_master);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox3);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.btn_back);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.lbl_header);
			this.Controls.Add(this.panel1);
			this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Name = "frm_menu_management";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Management";
			this.Load += new System.EventHandler(this.Frm_menu_managementLoad);
			this.panel2.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.grpbx_cutting.ResumeLayout(false);
			this.grpbx_slitting.ResumeLayout(false);
			this.grpbx_rewind.ResumeLayout(false);
			this.grpbx_pack.ResumeLayout(false);
			this.groupBox3.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.Button btn_item_master;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Button btn_get_so;
		private System.Windows.Forms.Button btn_pc;
		private System.Windows.Forms.Button btn_pb;
		private System.Windows.Forms.Button btn_pw;
		private System.Windows.Forms.Button btn_cjso;
		private System.Windows.Forms.Button btn_pod;
		private System.Windows.Forms.Button btn_ple;
		private System.Windows.Forms.Button btn_podj;
		private System.Windows.Forms.Button btn_cjsm;
		private System.Windows.Forms.Button btn_po;
		private System.Windows.Forms.GroupBox groupBox3;
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
		private System.Windows.Forms.Button btn_slit_output_fast;
		private System.Windows.Forms.Button btn_slit_output_shift_fast;
		private System.Windows.Forms.Button btn_slit_output;
		private System.Windows.Forms.Button btn_slit_output_detail;
		private System.Windows.Forms.GroupBox grpbx_slitting;
		private System.Windows.Forms.Button btn_cut_output_fast;
		private System.Windows.Forms.Button btn_cut_output_shift_fast;
		private System.Windows.Forms.Button btn_cut_output;
		private System.Windows.Forms.Button btn_cut_output_detail;
		private System.Windows.Forms.GroupBox grpbx_cutting;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Button btn_back;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Label lbl_username;
		private System.Windows.Forms.Button btn_prod_track_stat;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label lbl_header;
	}
}