/*
 * Created by SharpDevelop.
 * User: faeiz
 * Date: 2017-10-25
 * Time: 10:45 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace AX2020
{
	partial class frm_prod_ribbon2_menu
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
			this.panel2 = new System.Windows.Forms.Panel();
			this.lbl_username = new System.Windows.Forms.Label();
			this.panel1 = new System.Windows.Forms.Panel();
			this.label1 = new System.Windows.Forms.Label();
			this.btn_rbn_jo = new System.Windows.Forms.Button();
			this.btn_rbn_output = new System.Windows.Forms.Button();
			this.btn_rbn_mtnce = new System.Windows.Forms.Button();
			this.btn_reprint = new System.Windows.Forms.Button();
			this.btn_cancel = new System.Windows.Forms.Button();
			this.panel2.SuspendLayout();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel2
			// 
			this.panel2.BackColor = System.Drawing.Color.Gainsboro;
			this.panel2.Controls.Add(this.lbl_username);
			this.panel2.Location = new System.Drawing.Point(2, 51);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(986, 16);
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
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.Color.DarkCyan;
			this.panel1.Controls.Add(this.label1);
			this.panel1.Location = new System.Drawing.Point(0, 1);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(984, 52);
			this.panel1.TabIndex = 139;
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
			this.label1.Location = new System.Drawing.Point(406, 14);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(200, 23);
			this.label1.TabIndex = 0;
			this.label1.Text = "RIBBON MAIN MENU";
			// 
			// btn_rbn_jo
			// 
			this.btn_rbn_jo.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.btn_rbn_jo.BackColor = System.Drawing.Color.Silver;
			this.btn_rbn_jo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
			this.btn_rbn_jo.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_rbn_jo.Location = new System.Drawing.Point(392, 136);
			this.btn_rbn_jo.Margin = new System.Windows.Forms.Padding(1);
			this.btn_rbn_jo.Name = "btn_rbn_jo";
			this.btn_rbn_jo.Size = new System.Drawing.Size(214, 61);
			this.btn_rbn_jo.TabIndex = 141;
			this.btn_rbn_jo.Text = "RIBBON JOB ORDER";
			this.btn_rbn_jo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btn_rbn_jo.UseVisualStyleBackColor = false;
			this.btn_rbn_jo.Click += new System.EventHandler(this.Btn_rbn_joClick);
			// 
			// btn_rbn_output
			// 
			this.btn_rbn_output.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.btn_rbn_output.BackColor = System.Drawing.Color.Silver;
			this.btn_rbn_output.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
			this.btn_rbn_output.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_rbn_output.Location = new System.Drawing.Point(392, 199);
			this.btn_rbn_output.Margin = new System.Windows.Forms.Padding(1);
			this.btn_rbn_output.Name = "btn_rbn_output";
			this.btn_rbn_output.Size = new System.Drawing.Size(214, 61);
			this.btn_rbn_output.TabIndex = 142;
			this.btn_rbn_output.Text = "RIBBON OUTPUT";
			this.btn_rbn_output.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btn_rbn_output.UseVisualStyleBackColor = false;
			this.btn_rbn_output.Click += new System.EventHandler(this.Btn_rbn_outputClick);
			// 
			// btn_rbn_mtnce
			// 
			this.btn_rbn_mtnce.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.btn_rbn_mtnce.BackColor = System.Drawing.Color.Silver;
			this.btn_rbn_mtnce.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
			this.btn_rbn_mtnce.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_rbn_mtnce.Location = new System.Drawing.Point(392, 262);
			this.btn_rbn_mtnce.Margin = new System.Windows.Forms.Padding(1);
			this.btn_rbn_mtnce.Name = "btn_rbn_mtnce";
			this.btn_rbn_mtnce.Size = new System.Drawing.Size(214, 61);
			this.btn_rbn_mtnce.TabIndex = 143;
			this.btn_rbn_mtnce.Text = "RIBBON MAINTENANCE";
			this.btn_rbn_mtnce.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btn_rbn_mtnce.UseVisualStyleBackColor = false;
			this.btn_rbn_mtnce.Click += new System.EventHandler(this.Btn_rbn_mtnceClick);
			// 
			// btn_reprint
			// 
			this.btn_reprint.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.btn_reprint.BackColor = System.Drawing.Color.Silver;
			this.btn_reprint.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
			this.btn_reprint.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_reprint.Location = new System.Drawing.Point(392, 325);
			this.btn_reprint.Margin = new System.Windows.Forms.Padding(1);
			this.btn_reprint.Name = "btn_reprint";
			this.btn_reprint.Size = new System.Drawing.Size(214, 61);
			this.btn_reprint.TabIndex = 144;
			this.btn_reprint.Text = "REPRINT REPORT";
			this.btn_reprint.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btn_reprint.UseVisualStyleBackColor = false;
			this.btn_reprint.Click += new System.EventHandler(this.Button1Click);
			// 
			// btn_cancel
			// 
			this.btn_cancel.BackColor = System.Drawing.Color.Silver;
			this.btn_cancel.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_cancel.Location = new System.Drawing.Point(423, 615);
			this.btn_cancel.Margin = new System.Windows.Forms.Padding(2);
			this.btn_cancel.Name = "btn_cancel";
			this.btn_cancel.Size = new System.Drawing.Size(136, 26);
			this.btn_cancel.TabIndex = 164;
			this.btn_cancel.Text = "CANCEL";
			this.btn_cancel.UseVisualStyleBackColor = false;
			this.btn_cancel.Click += new System.EventHandler(this.Btn_cancelClick);
			// 
			// frm_prod_ribbon2_menu
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.ClientSize = new System.Drawing.Size(984, 662);
			this.Controls.Add(this.btn_cancel);
			this.Controls.Add(this.btn_reprint);
			this.Controls.Add(this.btn_rbn_mtnce);
			this.Controls.Add(this.btn_rbn_output);
			this.Controls.Add(this.btn_rbn_jo);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.panel1);
			this.Name = "frm_prod_ribbon2_menu";
			this.Text = "frm_prod_ribbon2_menu";
			this.panel2.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.Button btn_cancel;
		private System.Windows.Forms.Button btn_reprint;
		private System.Windows.Forms.Button btn_rbn_mtnce;
		private System.Windows.Forms.Button btn_rbn_output;
		private System.Windows.Forms.Button btn_rbn_jo;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label lbl_username;
		private System.Windows.Forms.Panel panel2;
	}
}
