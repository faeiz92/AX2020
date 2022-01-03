/*
 * Created by SharpDevelop.
 * User: faeiz
 * Date: 2018-01-08
 * Time: 11:09 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace AX2020
{
	partial class frm_prod_coverting_output_rewinding_check_bal
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
			this.btn_bal = new System.Windows.Forms.Button();
			this.btn_close = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.btn_shortline = new System.Windows.Forms.Button();
			this.btn_wastage = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// btn_bal
			// 
			this.btn_bal.Location = new System.Drawing.Point(20, 70);
			this.btn_bal.Name = "btn_bal";
			this.btn_bal.Size = new System.Drawing.Size(75, 30);
			this.btn_bal.TabIndex = 0;
			this.btn_bal.Text = "Balance";
			this.btn_bal.UseVisualStyleBackColor = true;
			this.btn_bal.Click += new System.EventHandler(this.Btn_balClick);
			// 
			// btn_close
			// 
			this.btn_close.Location = new System.Drawing.Point(109, 191);
			this.btn_close.Name = "btn_close";
			this.btn_close.Size = new System.Drawing.Size(75, 30);
			this.btn_close.TabIndex = 2;
			this.btn_close.Text = "Close";
			this.btn_close.UseVisualStyleBackColor = true;
			this.btn_close.Click += new System.EventHandler(this.Btn_closeClick);
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(12, 23);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(260, 27);
			this.label1.TabIndex = 3;
			this.label1.Text = "Please Select Balance or Short Line";
			// 
			// btn_shortline
			// 
			this.btn_shortline.Location = new System.Drawing.Point(198, 70);
			this.btn_shortline.Name = "btn_shortline";
			this.btn_shortline.Size = new System.Drawing.Size(75, 30);
			this.btn_shortline.TabIndex = 4;
			this.btn_shortline.Text = "Short Line";
			this.btn_shortline.UseVisualStyleBackColor = true;
			this.btn_shortline.Click += new System.EventHandler(this.Btn_shortlineClick);
			// 
			// btn_wastage
			// 
			this.btn_wastage.Location = new System.Drawing.Point(109, 70);
			this.btn_wastage.Name = "btn_wastage";
			this.btn_wastage.Size = new System.Drawing.Size(75, 30);
			this.btn_wastage.TabIndex = 5;
			this.btn_wastage.Text = "Wastage";
			this.btn_wastage.UseVisualStyleBackColor = true;
			this.btn_wastage.Click += new System.EventHandler(this.Btn_wastageClick);
			// 
			// frm_prod_coverting_output_rewinding_check_bal
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(284, 262);
			this.Controls.Add(this.btn_wastage);
			this.Controls.Add(this.btn_shortline);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.btn_close);
			this.Controls.Add(this.btn_bal);
			this.Name = "frm_prod_coverting_output_rewinding_check_bal";
			this.Text = "frm_prod_coverting_output_rewinding_chec__bal";
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.Button btn_wastage;
		private System.Windows.Forms.Button btn_shortline;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button btn_close;
		private System.Windows.Forms.Button btn_bal;
	}
}
