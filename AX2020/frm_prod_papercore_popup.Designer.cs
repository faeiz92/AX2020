/*
 * Created by SharpDevelop.
 * User: ax2020-1
 * Date: 1/10/2017
 * Time: 3:59 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace AX2020
{
	partial class frm_prod_papercore_popup
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
			this.dt_grid = new System.Windows.Forms.DataGridView();
			this.btn_cancel = new System.Windows.Forms.Button();
			this.txtbx_stockcode = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.dt_grid)).BeginInit();
			this.SuspendLayout();
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
			this.dt_grid.BackgroundColor = System.Drawing.SystemColors.Control;
			this.dt_grid.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.dt_grid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
			dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle2.BackColor = System.Drawing.Color.WhiteSmoke;
			dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.dt_grid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
			this.dt_grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
			dataGridViewCellStyle3.Font = new System.Drawing.Font("Arial", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
			dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.dt_grid.DefaultCellStyle = dataGridViewCellStyle3;
			this.dt_grid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
			this.dt_grid.EnableHeadersVisualStyles = false;
			this.dt_grid.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.dt_grid.Location = new System.Drawing.Point(12, 47);
			this.dt_grid.MultiSelect = false;
			this.dt_grid.Name = "dt_grid";
			this.dt_grid.ReadOnly = true;
			this.dt_grid.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
			this.dt_grid.RowHeadersVisible = false;
			this.dt_grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dt_grid.Size = new System.Drawing.Size(503, 203);
			this.dt_grid.TabIndex = 150;
			this.dt_grid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Dt_gridCellClick);
			this.dt_grid.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.Dt_gridDataBindingComplete);
			// 
			// btn_cancel
			// 
			this.btn_cancel.BackColor = System.Drawing.Color.Silver;
			this.btn_cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btn_cancel.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_cancel.Location = new System.Drawing.Point(203, 263);
			this.btn_cancel.Margin = new System.Windows.Forms.Padding(1);
			this.btn_cancel.Name = "btn_cancel";
			this.btn_cancel.Size = new System.Drawing.Size(120, 27);
			this.btn_cancel.TabIndex = 152;
			this.btn_cancel.Text = "Cancel";
			this.btn_cancel.UseVisualStyleBackColor = false;
			this.btn_cancel.Click += new System.EventHandler(this.Btn_cancelClick);
			// 
			// txtbx_stockcode
			// 
			this.txtbx_stockcode.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtbx_stockcode.Location = new System.Drawing.Point(142, 17);
			this.txtbx_stockcode.Name = "txtbx_stockcode";
			this.txtbx_stockcode.Size = new System.Drawing.Size(210, 26);
			this.txtbx_stockcode.TabIndex = 153;
			this.txtbx_stockcode.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Txtbx_stock_codeKeyUp);
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(35, 20);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(100, 23);
			this.label1.TabIndex = 154;
			this.label1.Text = "Stock Code";
			// 
			// frm_prod_papercore_popup
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.CancelButton = this.btn_cancel;
			this.ClientSize = new System.Drawing.Size(528, 300);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.txtbx_stockcode);
			this.Controls.Add(this.btn_cancel);
			this.Controls.Add(this.dt_grid);
			this.Name = "frm_prod_papercore_popup";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Select ";
			this.Load += new System.EventHandler(this.Frm_prod_glue_popupLoad);
			((System.ComponentModel.ISupportInitialize)(this.dt_grid)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtbx_stockcode;
		private System.Windows.Forms.Button btn_cancel;
		private System.Windows.Forms.DataGridView dt_grid;
	}
}
