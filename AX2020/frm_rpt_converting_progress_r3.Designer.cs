/*
 * Created by SharpDevelop.
 * User: afiqah
 * Date: 15/06/2017
 * Time: 3:43 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace AX2020
{
	partial class frm_rpt_converting_progress_r3
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
			this.groupBx_search = new System.Windows.Forms.GroupBox();
			this.txtbx_ctn_bx = new System.Windows.Forms.TextBox();
			this.lbl_ctn_bx = new System.Windows.Forms.Label();
			this.txtbx_brand = new System.Windows.Forms.TextBox();
			this.lbl_brand = new System.Windows.Forms.Label();
			this.txtbx_color = new System.Windows.Forms.TextBox();
			this.lbl_color = new System.Windows.Forms.Label();
			this.txtbx_cust = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.txtbx_jo_no = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.txtbx_so_no = new System.Windows.Forms.TextBox();
			this.lbl_ref_no = new System.Windows.Forms.Label();
			this.btn_search = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.dtp_date_to = new System.Windows.Forms.DateTimePicker();
			this.lbl_date = new System.Windows.Forms.Label();
			this.dtp_date_from = new System.Windows.Forms.DateTimePicker();
			this.btn_cancel = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.dt_grid = new System.Windows.Forms.DataGridView();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
			this.txtbx_code = new System.Windows.Forms.TextBox();
			this.lbl_code = new System.Windows.Forms.Label();
			this.panel2.SuspendLayout();
			this.groupBx_search.SuspendLayout();
			this.tabControl1.SuspendLayout();
			this.tabPage1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dt_grid)).BeginInit();
			this.tabPage2.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel2
			// 
			this.panel2.BackColor = System.Drawing.Color.Gainsboro;
			this.panel2.Controls.Add(this.lbl_username);
			this.panel2.Location = new System.Drawing.Point(-1, 20);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(998, 23);
			this.panel2.TabIndex = 144;
			// 
			// lbl_username
			// 
			this.lbl_username.BackColor = System.Drawing.Color.Gainsboro;
			this.lbl_username.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbl_username.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.lbl_username.Location = new System.Drawing.Point(688, -1);
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
			this.lbl_header.Location = new System.Drawing.Point(4, -13);
			this.lbl_header.Name = "lbl_header";
			this.lbl_header.Size = new System.Drawing.Size(959, 23);
			this.lbl_header.TabIndex = 142;
			this.lbl_header.Text = "JOB ORDER PROGRESS";
			this.lbl_header.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.Color.DarkCyan;
			this.panel1.Location = new System.Drawing.Point(0, -30);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(998, 52);
			this.panel1.TabIndex = 143;
			// 
			// groupBx_search
			// 
			this.groupBx_search.Controls.Add(this.txtbx_code);
			this.groupBx_search.Controls.Add(this.lbl_code);
			this.groupBx_search.Controls.Add(this.txtbx_ctn_bx);
			this.groupBx_search.Controls.Add(this.lbl_ctn_bx);
			this.groupBx_search.Controls.Add(this.txtbx_brand);
			this.groupBx_search.Controls.Add(this.lbl_brand);
			this.groupBx_search.Controls.Add(this.txtbx_color);
			this.groupBx_search.Controls.Add(this.lbl_color);
			this.groupBx_search.Controls.Add(this.txtbx_cust);
			this.groupBx_search.Controls.Add(this.label4);
			this.groupBx_search.Controls.Add(this.txtbx_jo_no);
			this.groupBx_search.Controls.Add(this.label3);
			this.groupBx_search.Controls.Add(this.txtbx_so_no);
			this.groupBx_search.Controls.Add(this.lbl_ref_no);
			this.groupBx_search.Controls.Add(this.btn_search);
			this.groupBx_search.Controls.Add(this.label1);
			this.groupBx_search.Controls.Add(this.dtp_date_to);
			this.groupBx_search.Controls.Add(this.lbl_date);
			this.groupBx_search.Controls.Add(this.dtp_date_from);
			this.groupBx_search.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.groupBx_search.Location = new System.Drawing.Point(18, 58);
			this.groupBx_search.Name = "groupBx_search";
			this.groupBx_search.Size = new System.Drawing.Size(949, 185);
			this.groupBx_search.TabIndex = 150;
			this.groupBx_search.TabStop = false;
			// 
			// txtbx_ctn_bx
			// 
			this.txtbx_ctn_bx.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtbx_ctn_bx.Location = new System.Drawing.Point(597, 113);
			this.txtbx_ctn_bx.Name = "txtbx_ctn_bx";
			this.txtbx_ctn_bx.Size = new System.Drawing.Size(340, 26);
			this.txtbx_ctn_bx.TabIndex = 171;
			// 
			// lbl_ctn_bx
			// 
			this.lbl_ctn_bx.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbl_ctn_bx.Location = new System.Drawing.Point(496, 113);
			this.lbl_ctn_bx.Name = "lbl_ctn_bx";
			this.lbl_ctn_bx.Size = new System.Drawing.Size(99, 26);
			this.lbl_ctn_bx.TabIndex = 172;
			this.lbl_ctn_bx.Text = "Carton Box";
			this.lbl_ctn_bx.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtbx_brand
			// 
			this.txtbx_brand.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtbx_brand.Location = new System.Drawing.Point(597, 81);
			this.txtbx_brand.Name = "txtbx_brand";
			this.txtbx_brand.Size = new System.Drawing.Size(340, 26);
			this.txtbx_brand.TabIndex = 169;
			// 
			// lbl_brand
			// 
			this.lbl_brand.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbl_brand.Location = new System.Drawing.Point(496, 81);
			this.lbl_brand.Name = "lbl_brand";
			this.lbl_brand.Size = new System.Drawing.Size(92, 26);
			this.lbl_brand.TabIndex = 170;
			this.lbl_brand.Text = "Brand";
			this.lbl_brand.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtbx_color
			// 
			this.txtbx_color.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtbx_color.Location = new System.Drawing.Point(597, 49);
			this.txtbx_color.Name = "txtbx_color";
			this.txtbx_color.Size = new System.Drawing.Size(340, 26);
			this.txtbx_color.TabIndex = 167;
			// 
			// lbl_color
			// 
			this.lbl_color.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbl_color.Location = new System.Drawing.Point(496, 49);
			this.lbl_color.Name = "lbl_color";
			this.lbl_color.Size = new System.Drawing.Size(92, 26);
			this.lbl_color.TabIndex = 168;
			this.lbl_color.Text = "Color";
			this.lbl_color.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtbx_cust
			// 
			this.txtbx_cust.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtbx_cust.Location = new System.Drawing.Point(129, 114);
			this.txtbx_cust.Name = "txtbx_cust";
			this.txtbx_cust.Size = new System.Drawing.Size(353, 26);
			this.txtbx_cust.TabIndex = 3;
			// 
			// label4
			// 
			this.label4.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label4.Location = new System.Drawing.Point(10, 114);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(92, 26);
			this.label4.TabIndex = 166;
			this.label4.Text = "Customer";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtbx_jo_no
			// 
			this.txtbx_jo_no.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtbx_jo_no.Location = new System.Drawing.Point(129, 50);
			this.txtbx_jo_no.Name = "txtbx_jo_no";
			this.txtbx_jo_no.Size = new System.Drawing.Size(230, 26);
			this.txtbx_jo_no.TabIndex = 1;
			// 
			// label3
			// 
			this.label3.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.Location = new System.Drawing.Point(11, 49);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(75, 26);
			this.label3.TabIndex = 165;
			this.label3.Text = "JO No";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtbx_so_no
			// 
			this.txtbx_so_no.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtbx_so_no.Location = new System.Drawing.Point(129, 82);
			this.txtbx_so_no.Name = "txtbx_so_no";
			this.txtbx_so_no.Size = new System.Drawing.Size(230, 26);
			this.txtbx_so_no.TabIndex = 2;
			// 
			// lbl_ref_no
			// 
			this.lbl_ref_no.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbl_ref_no.Location = new System.Drawing.Point(11, 81);
			this.lbl_ref_no.Name = "lbl_ref_no";
			this.lbl_ref_no.Size = new System.Drawing.Size(75, 26);
			this.lbl_ref_no.TabIndex = 163;
			this.lbl_ref_no.Text = "SO No";
			this.lbl_ref_no.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// btn_search
			// 
			this.btn_search.BackColor = System.Drawing.Color.Silver;
			this.btn_search.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_search.Location = new System.Drawing.Point(817, 145);
			this.btn_search.Name = "btn_search";
			this.btn_search.Size = new System.Drawing.Size(120, 27);
			this.btn_search.TabIndex = 6;
			this.btn_search.Text = "Search";
			this.btn_search.UseVisualStyleBackColor = false;
			this.btn_search.Click += new System.EventHandler(this.Btn_searchClick);
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(497, 20);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(73, 26);
			this.label1.TabIndex = 153;
			this.label1.Text = "Date To";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// dtp_date_to
			// 
			this.dtp_date_to.Checked = false;
			this.dtp_date_to.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.dtp_date_to.Location = new System.Drawing.Point(597, 17);
			this.dtp_date_to.Name = "dtp_date_to";
			this.dtp_date_to.Size = new System.Drawing.Size(340, 26);
			this.dtp_date_to.TabIndex = 5;
			// 
			// lbl_date
			// 
			this.lbl_date.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbl_date.Location = new System.Drawing.Point(12, 17);
			this.lbl_date.Name = "lbl_date";
			this.lbl_date.Size = new System.Drawing.Size(90, 26);
			this.lbl_date.TabIndex = 151;
			this.lbl_date.Text = "Date From";
			this.lbl_date.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// dtp_date_from
			// 
			this.dtp_date_from.Checked = false;
			this.dtp_date_from.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.dtp_date_from.Location = new System.Drawing.Point(129, 17);
			this.dtp_date_from.Name = "dtp_date_from";
			this.dtp_date_from.Size = new System.Drawing.Size(353, 26);
			this.dtp_date_from.TabIndex = 4;
			// 
			// btn_cancel
			// 
			this.btn_cancel.BackColor = System.Drawing.Color.Silver;
			this.btn_cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btn_cancel.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_cancel.Location = new System.Drawing.Point(432, 627);
			this.btn_cancel.Name = "btn_cancel";
			this.btn_cancel.Size = new System.Drawing.Size(120, 27);
			this.btn_cancel.TabIndex = 155;
			this.btn_cancel.Text = "Cancel";
			this.btn_cancel.UseVisualStyleBackColor = false;
			this.btn_cancel.Click += new System.EventHandler(this.Btn_cancelClick);
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(443, 656);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(100, 23);
			this.label2.TabIndex = 157;
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.tabPage1);
			this.tabControl1.Controls.Add(this.tabPage2);
			this.tabControl1.Location = new System.Drawing.Point(18, 259);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(964, 352);
			this.tabControl1.TabIndex = 159;
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.dt_grid);
			this.tabPage1.Location = new System.Drawing.Point(4, 22);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage1.Size = new System.Drawing.Size(956, 326);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "View";
			this.tabPage1.UseVisualStyleBackColor = true;
			// 
			// dt_grid
			// 
			this.dt_grid.AllowUserToAddRows = false;
			this.dt_grid.AllowUserToDeleteRows = false;
			this.dt_grid.AllowUserToResizeRows = false;
			this.dt_grid.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.dt_grid.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
			this.dt_grid.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
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
			this.dt_grid.Location = new System.Drawing.Point(6, 6);
			this.dt_grid.Name = "dt_grid";
			this.dt_grid.ReadOnly = true;
			this.dt_grid.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
			this.dt_grid.Size = new System.Drawing.Size(939, 314);
			this.dt_grid.TabIndex = 159;
			// 
			// tabPage2
			// 
			this.tabPage2.Controls.Add(this.reportViewer1);
			this.tabPage2.Location = new System.Drawing.Point(4, 22);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage2.Size = new System.Drawing.Size(956, 326);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "Report";
			this.tabPage2.UseVisualStyleBackColor = true;
			// 
			// reportViewer1
			// 
			this.reportViewer1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.reportViewer1.Location = new System.Drawing.Point(5, 8);
			this.reportViewer1.Name = "ReportViewer";
			this.reportViewer1.Size = new System.Drawing.Size(945, 310);
			this.reportViewer1.TabIndex = 0;
			// 
			// txtbx_code
			// 
			this.txtbx_code.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtbx_code.Location = new System.Drawing.Point(129, 146);
			this.txtbx_code.Name = "txtbx_code";
			this.txtbx_code.Size = new System.Drawing.Size(230, 26);
			this.txtbx_code.TabIndex = 173;
			// 
			// lbl_code
			// 
			this.lbl_code.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbl_code.Location = new System.Drawing.Point(11, 145);
			this.lbl_code.Name = "lbl_code";
			this.lbl_code.Size = new System.Drawing.Size(120, 26);
			this.lbl_code.TabIndex = 174;
			this.lbl_code.Text = "Product Code";
			this.lbl_code.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// frm_rpt_converting_progress_r3
			// 
			this.AcceptButton = this.btn_search;
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.AutoScroll = true;
			this.CancelButton = this.btn_cancel;
			this.ClientSize = new System.Drawing.Size(1001, 679);
			this.Controls.Add(this.tabControl1);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.btn_cancel);
			this.Controls.Add(this.groupBx_search);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.lbl_header);
			this.Controls.Add(this.panel1);
			this.Name = "frm_rpt_converting_progress_r3";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Job Order Progress";
			this.Load += new System.EventHandler(this.Frm_rpt_converting_progress_r3Load);
			this.panel2.ResumeLayout(false);
			this.groupBx_search.ResumeLayout(false);
			this.groupBx_search.PerformLayout();
			this.tabControl1.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dt_grid)).EndInit();
			this.tabPage2.ResumeLayout(false);
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.Label lbl_code;
		private System.Windows.Forms.TextBox txtbx_code;
		private System.Windows.Forms.Label lbl_color;
		private System.Windows.Forms.TextBox txtbx_color;
		private System.Windows.Forms.Label lbl_brand;
		private System.Windows.Forms.TextBox txtbx_brand;
		private System.Windows.Forms.Label lbl_ctn_bx;
		private System.Windows.Forms.TextBox txtbx_ctn_bx;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.DataGridView dt_grid;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox txtbx_jo_no;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox txtbx_cust;
		private System.Windows.Forms.Label lbl_ref_no;
		private System.Windows.Forms.TextBox txtbx_so_no;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button btn_cancel;
		private System.Windows.Forms.GroupBox groupBx_search;
		private System.Windows.Forms.Button btn_search;
		private System.Windows.Forms.DateTimePicker dtp_date_to;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.DateTimePicker dtp_date_from;
		private System.Windows.Forms.Label lbl_date;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label lbl_header;
		private System.Windows.Forms.Label lbl_username;
		private System.Windows.Forms.Panel panel2;
		private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
	}
}





