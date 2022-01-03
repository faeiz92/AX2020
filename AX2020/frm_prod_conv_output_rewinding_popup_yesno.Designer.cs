/*
 * Created by SharpDevelop.
 * User: faeiz
 * Date: 2018-01-09
 * Time: 3:48 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace AX2020
{
	partial class frm_prod_conv_output_rewinding_popup_yesno
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
			this.label1 = new System.Windows.Forms.Label();
			this.btn_yes = new System.Windows.Forms.Button();
			this.btn_no = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(79, 52);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(135, 24);
			this.label1.TabIndex = 0;
			this.label1.Text = "JO COMPLETE?";
			// 
			// btn_yes
			// 
			this.btn_yes.Location = new System.Drawing.Point(27, 139);
			this.btn_yes.Name = "btn_yes";
			this.btn_yes.Size = new System.Drawing.Size(94, 23);
			this.btn_yes.TabIndex = 1;
			this.btn_yes.Text = "YES";
			this.btn_yes.UseVisualStyleBackColor = true;
			this.btn_yes.Click += new System.EventHandler(this.Btn_yesClick);
			// 
			// btn_no
			// 
			this.btn_no.Location = new System.Drawing.Point(161, 139);
			this.btn_no.Name = "btn_no";
			this.btn_no.Size = new System.Drawing.Size(94, 23);
			this.btn_no.TabIndex = 2;
			this.btn_no.Text = "NO";
			this.btn_no.UseVisualStyleBackColor = true;
			this.btn_no.Click += new System.EventHandler(this.Btn_noClick);
			// 
			// frm_prod_conv_output_rewinding_popup_yesno
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(298, 272);
			this.Controls.Add(this.btn_no);
			this.Controls.Add(this.btn_yes);
			this.Controls.Add(this.label1);
			this.Name = "frm_prod_conv_output_rewinding_popup_yesno";
			this.Text = "frm_prod_conv_output_rewinding_popup_yesno";
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.Button btn_no;
		private System.Windows.Forms.Button btn_yes;
		private System.Windows.Forms.Label label1;
	}
}
