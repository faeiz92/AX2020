/*
 * Created by SharpDevelop.
 * User: afiqah
 * Date: 22/03/2017
 * Time: 11:51 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace AX2020
{
	partial class frm_rpt_converting_tracking_r1
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
			this.lbl_header = new System.Windows.Forms.Label();
			this.panel1 = new System.Windows.Forms.Panel();
			this.btn_cancel = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
			this.groupBox6 = new System.Windows.Forms.GroupBox();
			this.txtbx_fr_lot_no = new System.Windows.Forms.TextBox();
			this.btn_search_fr = new System.Windows.Forms.Button();
			this.lbl_fr_lot_no = new System.Windows.Forms.Label();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.txtbx_so_no = new System.Windows.Forms.TextBox();
			this.btn_search_so = new System.Windows.Forms.Button();
			this.lbl_so_no = new System.Windows.Forms.Label();
			this.groupBox4 = new System.Windows.Forms.GroupBox();
			this.txtbx_pi_no = new System.Windows.Forms.TextBox();
			this.btn_search_pi = new System.Windows.Forms.Button();
			this.lbl_pi_no = new System.Windows.Forms.Label();
			this.groupBox7 = new System.Windows.Forms.GroupBox();
			this.txtbx_pack_no = new System.Windows.Forms.TextBox();
			this.btn_search_pack = new System.Windows.Forms.Button();
			this.lbl_pack_no = new System.Windows.Forms.Label();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.txtbx_jr_lot_no = new System.Windows.Forms.TextBox();
			this.btn_search_jr = new System.Windows.Forms.Button();
			this.lbl_jr_lot_no = new System.Windows.Forms.Label();
			this.button8 = new System.Windows.Forms.Button();
			this.groupBox5 = new System.Windows.Forms.GroupBox();
			this.txtbx_inv_no = new System.Windows.Forms.TextBox();
			this.btn_search_inv = new System.Windows.Forms.Button();
			this.lbl_inv_no = new System.Windows.Forms.Label();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.txtbx_jo_no = new System.Windows.Forms.TextBox();
			this.btn_search_jo = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.dt_grid = new System.Windows.Forms.DataGridView();
			this.panel2.SuspendLayout();
			this.groupBox6.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.groupBox4.SuspendLayout();
			this.groupBox7.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.groupBox5.SuspendLayout();
			this.groupBox2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dt_grid)).BeginInit();
			this.SuspendLayout();
			// 
			// panel2
			// 
			this.panel2.BackColor = System.Drawing.Color.Gainsboro;
			this.panel2.Controls.Add(this.lbl_username);
			this.panel2.Location = new System.Drawing.Point(-1, 50);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(1000, 23);
			this.panel2.TabIndex = 144;
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
			// lbl_header
			// 
			this.lbl_header.BackColor = System.Drawing.Color.DarkCyan;
			this.lbl_header.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbl_header.ForeColor = System.Drawing.SystemColors.ControlLightLight;
			this.lbl_header.Location = new System.Drawing.Point(4, 17);
			this.lbl_header.Name = "lbl_header";
			this.lbl_header.Size = new System.Drawing.Size(959, 23);
			this.lbl_header.TabIndex = 142;
			this.lbl_header.Text = "PRODUCTION FR TRACKING";
			this.lbl_header.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.Color.DarkCyan;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(1000, 52);
			this.panel1.TabIndex = 143;
			// 
			// btn_cancel
			// 
			this.btn_cancel.BackColor = System.Drawing.Color.Silver;
			this.btn_cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btn_cancel.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_cancel.Location = new System.Drawing.Point(432, 915);
			this.btn_cancel.Name = "btn_cancel";
			this.btn_cancel.Size = new System.Drawing.Size(120, 27);
			this.btn_cancel.TabIndex = 155;
			this.btn_cancel.Text = "Cancel";
			this.btn_cancel.UseVisualStyleBackColor = false;
			this.btn_cancel.Click += new System.EventHandler(this.Btn_cancelClick);
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(443, 943);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(100, 23);
			this.label2.TabIndex = 157;
			// 
			// reportViewer1
			// 
			this.reportViewer1.Location = new System.Drawing.Point(18, 330);
			this.reportViewer1.Name = "ReportViewer";
			this.reportViewer1.Size = new System.Drawing.Size(949, 280);
			this.reportViewer1.TabIndex = 0;
			// 
			// groupBox6
			// 
			this.groupBox6.Controls.Add(this.txtbx_fr_lot_no);
			this.groupBox6.Controls.Add(this.btn_search_fr);
			this.groupBox6.Controls.Add(this.lbl_fr_lot_no);
			this.groupBox6.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.groupBox6.Location = new System.Drawing.Point(497, 194);
			this.groupBox6.Name = "groupBox6";
			this.groupBox6.Size = new System.Drawing.Size(469, 59);
			this.groupBox6.TabIndex = 168;
			this.groupBox6.TabStop = false;
			// 
			// txtbx_fr_lot_no
			// 
			this.txtbx_fr_lot_no.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtbx_fr_lot_no.Location = new System.Drawing.Point(109, 21);
			this.txtbx_fr_lot_no.Name = "txtbx_fr_lot_no";
			this.txtbx_fr_lot_no.Size = new System.Drawing.Size(226, 26);
			this.txtbx_fr_lot_no.TabIndex = 159;
			// 
			// btn_search_fr
			// 
			this.btn_search_fr.BackColor = System.Drawing.Color.Silver;
			this.btn_search_fr.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_search_fr.Location = new System.Drawing.Point(338, 20);
			this.btn_search_fr.Name = "btn_search_fr";
			this.btn_search_fr.Size = new System.Drawing.Size(120, 27);
			this.btn_search_fr.TabIndex = 160;
			this.btn_search_fr.Text = "Search";
			this.btn_search_fr.UseVisualStyleBackColor = false;
			this.btn_search_fr.Click += new System.EventHandler(this.Btn_search_frClick);
			// 
			// lbl_fr_lot_no
			// 
			this.lbl_fr_lot_no.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbl_fr_lot_no.Location = new System.Drawing.Point(12, 20);
			this.lbl_fr_lot_no.Name = "lbl_fr_lot_no";
			this.lbl_fr_lot_no.Size = new System.Drawing.Size(88, 26);
			this.lbl_fr_lot_no.TabIndex = 161;
			this.lbl_fr_lot_no.Text = "FR Lot No";
			this.lbl_fr_lot_no.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.txtbx_so_no);
			this.groupBox1.Controls.Add(this.btn_search_so);
			this.groupBox1.Controls.Add(this.lbl_so_no);
			this.groupBox1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.groupBox1.Location = new System.Drawing.Point(18, 136);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(473, 59);
			this.groupBox1.TabIndex = 164;
			this.groupBox1.TabStop = false;
			// 
			// txtbx_so_no
			// 
			this.txtbx_so_no.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtbx_so_no.Location = new System.Drawing.Point(109, 21);
			this.txtbx_so_no.Name = "txtbx_so_no";
			this.txtbx_so_no.Size = new System.Drawing.Size(227, 26);
			this.txtbx_so_no.TabIndex = 159;
			// 
			// btn_search_so
			// 
			this.btn_search_so.BackColor = System.Drawing.Color.Silver;
			this.btn_search_so.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_search_so.Location = new System.Drawing.Point(339, 20);
			this.btn_search_so.Name = "btn_search_so";
			this.btn_search_so.Size = new System.Drawing.Size(120, 27);
			this.btn_search_so.TabIndex = 160;
			this.btn_search_so.Text = "Search";
			this.btn_search_so.UseVisualStyleBackColor = false;
			this.btn_search_so.Click += new System.EventHandler(this.Btn_search_soClick);
			// 
			// lbl_so_no
			// 
			this.lbl_so_no.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbl_so_no.Location = new System.Drawing.Point(12, 20);
			this.lbl_so_no.Name = "lbl_so_no";
			this.lbl_so_no.Size = new System.Drawing.Size(75, 26);
			this.lbl_so_no.TabIndex = 161;
			this.lbl_so_no.Text = "SO No";
			this.lbl_so_no.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// groupBox4
			// 
			this.groupBox4.Controls.Add(this.txtbx_pi_no);
			this.groupBox4.Controls.Add(this.btn_search_pi);
			this.groupBox4.Controls.Add(this.lbl_pi_no);
			this.groupBox4.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.groupBox4.Location = new System.Drawing.Point(18, 79);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new System.Drawing.Size(473, 59);
			this.groupBox4.TabIndex = 166;
			this.groupBox4.TabStop = false;
			// 
			// txtbx_pi_no
			// 
			this.txtbx_pi_no.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtbx_pi_no.Location = new System.Drawing.Point(109, 21);
			this.txtbx_pi_no.Name = "txtbx_pi_no";
			this.txtbx_pi_no.Size = new System.Drawing.Size(227, 26);
			this.txtbx_pi_no.TabIndex = 159;
			// 
			// btn_search_pi
			// 
			this.btn_search_pi.BackColor = System.Drawing.Color.Silver;
			this.btn_search_pi.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_search_pi.Location = new System.Drawing.Point(339, 20);
			this.btn_search_pi.Name = "btn_search_pi";
			this.btn_search_pi.Size = new System.Drawing.Size(120, 27);
			this.btn_search_pi.TabIndex = 160;
			this.btn_search_pi.Text = "Search";
			this.btn_search_pi.UseVisualStyleBackColor = false;
			this.btn_search_pi.Click += new System.EventHandler(this.Btn_search_piClick);
			// 
			// lbl_pi_no
			// 
			this.lbl_pi_no.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbl_pi_no.Location = new System.Drawing.Point(12, 20);
			this.lbl_pi_no.Name = "lbl_pi_no";
			this.lbl_pi_no.Size = new System.Drawing.Size(75, 26);
			this.lbl_pi_no.TabIndex = 161;
			this.lbl_pi_no.Text = "PI No";
			this.lbl_pi_no.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// groupBox7
			// 
			this.groupBox7.Controls.Add(this.txtbx_pack_no);
			this.groupBox7.Controls.Add(this.btn_search_pack);
			this.groupBox7.Controls.Add(this.lbl_pack_no);
			this.groupBox7.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.groupBox7.Location = new System.Drawing.Point(18, 255);
			this.groupBox7.Name = "groupBox7";
			this.groupBox7.Size = new System.Drawing.Size(473, 59);
			this.groupBox7.TabIndex = 170;
			this.groupBox7.TabStop = false;
			// 
			// txtbx_pack_no
			// 
			this.txtbx_pack_no.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtbx_pack_no.Location = new System.Drawing.Point(109, 21);
			this.txtbx_pack_no.Name = "txtbx_pack_no";
			this.txtbx_pack_no.Size = new System.Drawing.Size(227, 26);
			this.txtbx_pack_no.TabIndex = 159;
			// 
			// btn_search_pack
			// 
			this.btn_search_pack.BackColor = System.Drawing.Color.Silver;
			this.btn_search_pack.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_search_pack.Location = new System.Drawing.Point(339, 20);
			this.btn_search_pack.Name = "btn_search_pack";
			this.btn_search_pack.Size = new System.Drawing.Size(120, 27);
			this.btn_search_pack.TabIndex = 160;
			this.btn_search_pack.Text = "Search";
			this.btn_search_pack.UseVisualStyleBackColor = false;
			this.btn_search_pack.Click += new System.EventHandler(this.Btn_search_packClick);
			// 
			// lbl_pack_no
			// 
			this.lbl_pack_no.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbl_pack_no.Location = new System.Drawing.Point(12, 20);
			this.lbl_pack_no.Name = "lbl_pack_no";
			this.lbl_pack_no.Size = new System.Drawing.Size(104, 26);
			this.lbl_pack_no.TabIndex = 161;
			this.lbl_pack_no.Text = "Packing No";
			this.lbl_pack_no.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.txtbx_jr_lot_no);
			this.groupBox3.Controls.Add(this.btn_search_jr);
			this.groupBox3.Controls.Add(this.lbl_jr_lot_no);
			this.groupBox3.Controls.Add(this.button8);
			this.groupBox3.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.groupBox3.Location = new System.Drawing.Point(18, 194);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(473, 59);
			this.groupBox3.TabIndex = 165;
			this.groupBox3.TabStop = false;
			// 
			// txtbx_jr_lot_no
			// 
			this.txtbx_jr_lot_no.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtbx_jr_lot_no.Location = new System.Drawing.Point(109, 21);
			this.txtbx_jr_lot_no.Name = "txtbx_jr_lot_no";
			this.txtbx_jr_lot_no.Size = new System.Drawing.Size(227, 26);
			this.txtbx_jr_lot_no.TabIndex = 159;
			// 
			// btn_search_jr
			// 
			this.btn_search_jr.BackColor = System.Drawing.Color.Silver;
			this.btn_search_jr.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_search_jr.Location = new System.Drawing.Point(339, 20);
			this.btn_search_jr.Name = "btn_search_jr";
			this.btn_search_jr.Size = new System.Drawing.Size(120, 27);
			this.btn_search_jr.TabIndex = 160;
			this.btn_search_jr.Text = "Search";
			this.btn_search_jr.UseVisualStyleBackColor = false;
			this.btn_search_jr.Click += new System.EventHandler(this.Btn_search_jrClick);
			// 
			// lbl_jr_lot_no
			// 
			this.lbl_jr_lot_no.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbl_jr_lot_no.Location = new System.Drawing.Point(12, 20);
			this.lbl_jr_lot_no.Name = "lbl_jr_lot_no";
			this.lbl_jr_lot_no.Size = new System.Drawing.Size(88, 26);
			this.lbl_jr_lot_no.TabIndex = 161;
			this.lbl_jr_lot_no.Text = "JR Lot No";
			this.lbl_jr_lot_no.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// button8
			// 
			this.button8.BackColor = System.Drawing.Color.Silver;
			this.button8.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.button8.Location = new System.Drawing.Point(806, 20);
			this.button8.Name = "button8";
			this.button8.Size = new System.Drawing.Size(120, 27);
			this.button8.TabIndex = 154;
			this.button8.Text = "Search";
			this.button8.UseVisualStyleBackColor = false;
			// 
			// groupBox5
			// 
			this.groupBox5.Controls.Add(this.txtbx_inv_no);
			this.groupBox5.Controls.Add(this.btn_search_inv);
			this.groupBox5.Controls.Add(this.lbl_inv_no);
			this.groupBox5.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.groupBox5.Location = new System.Drawing.Point(497, 79);
			this.groupBox5.Name = "groupBox5";
			this.groupBox5.Size = new System.Drawing.Size(467, 59);
			this.groupBox5.TabIndex = 169;
			this.groupBox5.TabStop = false;
			// 
			// txtbx_inv_no
			// 
			this.txtbx_inv_no.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtbx_inv_no.Location = new System.Drawing.Point(109, 21);
			this.txtbx_inv_no.Name = "txtbx_inv_no";
			this.txtbx_inv_no.Size = new System.Drawing.Size(226, 26);
			this.txtbx_inv_no.TabIndex = 159;
			// 
			// btn_search_inv
			// 
			this.btn_search_inv.BackColor = System.Drawing.Color.Silver;
			this.btn_search_inv.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_search_inv.Location = new System.Drawing.Point(338, 20);
			this.btn_search_inv.Name = "btn_search_inv";
			this.btn_search_inv.Size = new System.Drawing.Size(120, 27);
			this.btn_search_inv.TabIndex = 160;
			this.btn_search_inv.Text = "Search";
			this.btn_search_inv.UseVisualStyleBackColor = false;
			this.btn_search_inv.Click += new System.EventHandler(this.Btn_search_invClick);
			// 
			// lbl_inv_no
			// 
			this.lbl_inv_no.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbl_inv_no.Location = new System.Drawing.Point(12, 20);
			this.lbl_inv_no.Name = "lbl_inv_no";
			this.lbl_inv_no.Size = new System.Drawing.Size(75, 26);
			this.lbl_inv_no.TabIndex = 161;
			this.lbl_inv_no.Text = "Inv No";
			this.lbl_inv_no.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.txtbx_jo_no);
			this.groupBox2.Controls.Add(this.btn_search_jo);
			this.groupBox2.Controls.Add(this.label1);
			this.groupBox2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.groupBox2.Location = new System.Drawing.Point(497, 136);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(469, 59);
			this.groupBox2.TabIndex = 167;
			this.groupBox2.TabStop = false;
			// 
			// txtbx_jo_no
			// 
			this.txtbx_jo_no.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtbx_jo_no.Location = new System.Drawing.Point(109, 21);
			this.txtbx_jo_no.Name = "txtbx_jo_no";
			this.txtbx_jo_no.Size = new System.Drawing.Size(226, 26);
			this.txtbx_jo_no.TabIndex = 159;
			// 
			// btn_search_jo
			// 
			this.btn_search_jo.BackColor = System.Drawing.Color.Silver;
			this.btn_search_jo.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_search_jo.Location = new System.Drawing.Point(338, 20);
			this.btn_search_jo.Name = "btn_search_jo";
			this.btn_search_jo.Size = new System.Drawing.Size(120, 27);
			this.btn_search_jo.TabIndex = 160;
			this.btn_search_jo.Text = "Search";
			this.btn_search_jo.UseVisualStyleBackColor = false;
			this.btn_search_jo.Click += new System.EventHandler(this.Btn_search_joClick);
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(12, 20);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(75, 26);
			this.label1.TabIndex = 161;
			this.label1.Text = "JO No";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// dt_grid
			// 
			this.dt_grid.AllowUserToAddRows = false;
			this.dt_grid.AllowUserToDeleteRows = false;
			this.dt_grid.AllowUserToResizeRows = false;
			this.dt_grid.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.dt_grid.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
			this.dt_grid.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
			this.dt_grid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
			dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.dt_grid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
			this.dt_grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
			dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
			dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.dt_grid.DefaultCellStyle = dataGridViewCellStyle2;
			this.dt_grid.Location = new System.Drawing.Point(18, 619);
			this.dt_grid.Name = "dt_grid";
			this.dt_grid.ReadOnly = true;
			this.dt_grid.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
			this.dt_grid.Size = new System.Drawing.Size(947, 280);
			this.dt_grid.TabIndex = 171;
			// 
			// frm_rpt_converting_tracking_r1
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.AutoScroll = true;
			this.CancelButton = this.btn_cancel;
			this.ClientSize = new System.Drawing.Size(1001, 679);
			this.Controls.Add(this.dt_grid);
			this.Controls.Add(this.groupBox6);
			this.Controls.Add(this.groupBox4);
			this.Controls.Add(this.groupBox7);
			this.Controls.Add(this.groupBox3);
			this.Controls.Add(this.groupBox5);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.btn_cancel);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.lbl_header);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.reportViewer1);
			this.Controls.Add(this.groupBox1);
			this.Name = "frm_rpt_converting_tracking_r1";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Production FR Tracking";
			this.panel2.ResumeLayout(false);
			this.groupBox6.ResumeLayout(false);
			this.groupBox6.PerformLayout();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.groupBox4.ResumeLayout(false);
			this.groupBox4.PerformLayout();
			this.groupBox7.ResumeLayout(false);
			this.groupBox7.PerformLayout();
			this.groupBox3.ResumeLayout(false);
			this.groupBox3.PerformLayout();
			this.groupBox5.ResumeLayout(false);
			this.groupBox5.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dt_grid)).EndInit();
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.DataGridView dt_grid;
		private System.Windows.Forms.Button btn_search_jo;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Label lbl_inv_no;
		private System.Windows.Forms.Button btn_search_inv;
		private System.Windows.Forms.TextBox txtbx_inv_no;
		private System.Windows.Forms.GroupBox groupBox5;
		private System.Windows.Forms.Button button8;
		private System.Windows.Forms.Label lbl_jr_lot_no;
		private System.Windows.Forms.Button btn_search_jr;
		private System.Windows.Forms.TextBox txtbx_jr_lot_no;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.Label lbl_pack_no;
		private System.Windows.Forms.Button btn_search_pack;
		private System.Windows.Forms.TextBox txtbx_pack_no;
		private System.Windows.Forms.GroupBox groupBox7;
		private System.Windows.Forms.Label lbl_pi_no;
		private System.Windows.Forms.Button btn_search_pi;
		private System.Windows.Forms.TextBox txtbx_pi_no;
		private System.Windows.Forms.GroupBox groupBox4;
		private System.Windows.Forms.Label lbl_so_no;
		private System.Windows.Forms.Button btn_search_so;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label lbl_fr_lot_no;
		private System.Windows.Forms.Button btn_search_fr;
		private System.Windows.Forms.TextBox txtbx_fr_lot_no;
		private System.Windows.Forms.GroupBox groupBox6;
		private System.Windows.Forms.TextBox txtbx_jo_no;
		private System.Windows.Forms.TextBox txtbx_so_no;
		private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button btn_cancel;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label lbl_header;
		private System.Windows.Forms.Label lbl_username;
		private System.Windows.Forms.Panel panel2;
	}
}




