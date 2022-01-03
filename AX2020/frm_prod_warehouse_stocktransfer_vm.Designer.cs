/*
 * Created by SharpDevelop.
 * User: afiqah
 * Date: 06/10/2017
 * Time: 5:51 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace AX2020
{
	partial class frm_prod_warehouse_stocktransfer_vm
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
			this.btn_clear = new System.Windows.Forms.Button();
			this.btn_save = new System.Windows.Forms.Button();
			this.grpBx_search = new System.Windows.Forms.GroupBox();
			this.btn_add = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.txtbx_shipmark = new System.Windows.Forms.TextBox();
			this.groupbx_add = new System.Windows.Forms.GroupBox();
			this.dt_grid_add = new System.Windows.Forms.DataGridView();
			this.panel2.SuspendLayout();
			this.grpBx_search.SuspendLayout();
			this.groupbx_add.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dt_grid_add)).BeginInit();
			this.SuspendLayout();
			// 
			// panel2
			// 
			this.panel2.BackColor = System.Drawing.Color.Gainsboro;
			this.panel2.Controls.Add(this.lbl_username);
			this.panel2.Location = new System.Drawing.Point(0, 49);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(1000, 23);
			this.panel2.TabIndex = 140;
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
			this.lbl_header.Location = new System.Drawing.Point(0, 13);
			this.lbl_header.Name = "lbl_header";
			this.lbl_header.Size = new System.Drawing.Size(1000, 23);
			this.lbl_header.TabIndex = 138;
			this.lbl_header.Text = "WAREHOUSE TRANSFER ORDER FROM GFWVM05 TO GFWRM01";
			this.lbl_header.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.Color.DarkCyan;
			this.panel1.Location = new System.Drawing.Point(0, -1);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(1000, 52);
			this.panel1.TabIndex = 139;
			// 
			// btn_cancel
			// 
			this.btn_cancel.BackColor = System.Drawing.Color.Silver;
			this.btn_cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btn_cancel.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_cancel.Location = new System.Drawing.Point(558, 605);
			this.btn_cancel.Name = "btn_cancel";
			this.btn_cancel.Size = new System.Drawing.Size(120, 27);
			this.btn_cancel.TabIndex = 145;
			this.btn_cancel.Text = "Cancel";
			this.btn_cancel.UseVisualStyleBackColor = false;
			this.btn_cancel.Click += new System.EventHandler(this.Btn_cancelClick);
			// 
			// btn_clear
			// 
			this.btn_clear.BackColor = System.Drawing.Color.Silver;
			this.btn_clear.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_clear.Location = new System.Drawing.Point(432, 605);
			this.btn_clear.Name = "btn_clear";
			this.btn_clear.Size = new System.Drawing.Size(120, 27);
			this.btn_clear.TabIndex = 144;
			this.btn_clear.Text = "Clear";
			this.btn_clear.UseVisualStyleBackColor = false;
			this.btn_clear.Click += new System.EventHandler(this.Btn_clearClick);
			// 
			// btn_save
			// 
			this.btn_save.BackColor = System.Drawing.Color.Silver;
			this.btn_save.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_save.Location = new System.Drawing.Point(307, 605);
			this.btn_save.Name = "btn_save";
			this.btn_save.Size = new System.Drawing.Size(120, 27);
			this.btn_save.TabIndex = 143;
			this.btn_save.Text = "Save";
			this.btn_save.UseVisualStyleBackColor = false;
			this.btn_save.Click += new System.EventHandler(this.Btn_saveClick);
			// 
			// grpBx_search
			// 
			this.grpBx_search.Controls.Add(this.btn_add);
			this.grpBx_search.Controls.Add(this.label1);
			this.grpBx_search.Controls.Add(this.txtbx_shipmark);
			this.grpBx_search.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.grpBx_search.Location = new System.Drawing.Point(20, 93);
			this.grpBx_search.Name = "grpBx_search";
			this.grpBx_search.Size = new System.Drawing.Size(947, 63);
			this.grpBx_search.TabIndex = 146;
			this.grpBx_search.TabStop = false;
			// 
			// btn_add
			// 
			this.btn_add.BackColor = System.Drawing.Color.Silver;
			this.btn_add.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_add.Location = new System.Drawing.Point(405, 20);
			this.btn_add.Name = "btn_add";
			this.btn_add.Size = new System.Drawing.Size(120, 27);
			this.btn_add.TabIndex = 142;
			this.btn_add.Text = "Add";
			this.btn_add.UseVisualStyleBackColor = false;
			this.btn_add.Click += new System.EventHandler(this.Btn_addClick);
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(11, 21);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(118, 26);
			this.label1.TabIndex = 6;
			this.label1.Text = "Shipping Mark";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtbx_shipmark
			// 
			this.txtbx_shipmark.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtbx_shipmark.Location = new System.Drawing.Point(133, 21);
			this.txtbx_shipmark.Name = "txtbx_shipmark";
			this.txtbx_shipmark.Size = new System.Drawing.Size(274, 26);
			this.txtbx_shipmark.TabIndex = 1;
			// 
			// groupbx_add
			// 
			this.groupbx_add.Controls.Add(this.dt_grid_add);
			this.groupbx_add.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.groupbx_add.Location = new System.Drawing.Point(18, 163);
			this.groupbx_add.Name = "groupbx_add";
			this.groupbx_add.Size = new System.Drawing.Size(949, 385);
			this.groupbx_add.TabIndex = 147;
			this.groupbx_add.TabStop = false;
			// 
			// dt_grid_add
			// 
			this.dt_grid_add.AllowUserToAddRows = false;
			this.dt_grid_add.AllowUserToDeleteRows = false;
			this.dt_grid_add.AllowUserToResizeRows = false;
			dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			this.dt_grid_add.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
			this.dt_grid_add.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.dt_grid_add.BackgroundColor = System.Drawing.SystemColors.Control;
			this.dt_grid_add.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.dt_grid_add.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
			dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle2.BackColor = System.Drawing.Color.WhiteSmoke;
			dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.dt_grid_add.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
			this.dt_grid_add.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dt_grid_add.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
			this.dt_grid_add.EnableHeadersVisualStyles = false;
			this.dt_grid_add.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.dt_grid_add.Location = new System.Drawing.Point(17, 28);
			this.dt_grid_add.MultiSelect = false;
			this.dt_grid_add.Name = "dt_grid_add";
			this.dt_grid_add.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
			this.dt_grid_add.RowHeadersVisible = false;
			this.dt_grid_add.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
			this.dt_grid_add.Size = new System.Drawing.Size(914, 288);
			this.dt_grid_add.TabIndex = 149;
			this.dt_grid_add.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dt_grid_addCellClick);
			// 
			// frm_prod_warehouse_stocktransfer_vm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(984, 662);
			this.Controls.Add(this.groupbx_add);
			this.Controls.Add(this.grpBx_search);
			this.Controls.Add(this.btn_cancel);
			this.Controls.Add(this.btn_clear);
			this.Controls.Add(this.btn_save);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.lbl_header);
			this.Controls.Add(this.panel1);
			this.Name = "frm_prod_warehouse_stocktransfer_vm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "frm_prod_warehouse_stocktransfer";
			this.panel2.ResumeLayout(false);
			this.grpBx_search.ResumeLayout(false);
			this.grpBx_search.PerformLayout();
			this.groupbx_add.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dt_grid_add)).EndInit();
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.DataGridView dt_grid_add;
		private System.Windows.Forms.GroupBox groupbx_add;
		private System.Windows.Forms.GroupBox grpBx_search;
		private System.Windows.Forms.Button btn_save;
		private System.Windows.Forms.Button btn_clear;
		private System.Windows.Forms.Button btn_cancel;
		private System.Windows.Forms.Button btn_add;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label lbl_header;
		private System.Windows.Forms.Label lbl_username;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtbx_shipmark;
		

	}
}
