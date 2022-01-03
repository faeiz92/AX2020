/*
 * Created by SharpDevelop.
 * User: it-3
 * Date: 17/11/2016
 * Time: 8:53 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace AX2020
{
	partial class frm_menu_coating
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
			this.panel1 = new System.Windows.Forms.Panel();
			this.label1 = new System.Windows.Forms.Label();
			this.btn_back = new System.Windows.Forms.Button();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.btn_prod_output_underweight = new System.Windows.Forms.Button();
			this.btn_prod_output_overweight = new System.Windows.Forms.Button();
			this.btn_stock_receive = new System.Windows.Forms.Button();
			this.btn_sumbopp = new System.Windows.Forms.Button();
			this.btn_conv_outstanding_jr = new System.Windows.Forms.Button();
			this.btn_Cgrade = new System.Windows.Forms.Button();
			this.btn_po = new System.Windows.Forms.Button();
			this.btn_cjsm = new System.Windows.Forms.Button();
			this.btn_podj = new System.Windows.Forms.Button();
			this.btn_ple = new System.Windows.Forms.Button();
			this.btn_pod = new System.Windows.Forms.Button();
			this.btn_cjso = new System.Windows.Forms.Button();
			this.btn_pw = new System.Windows.Forms.Button();
			this.btn_pb = new System.Windows.Forms.Button();
			this.btn_pc = new System.Windows.Forms.Button();
			this.btn_capacity = new System.Windows.Forms.Button();
			this.panel1.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.Color.DarkCyan;
			this.panel1.Controls.Add(this.label1);
			this.panel1.Location = new System.Drawing.Point(-1, 0);
			this.panel1.Margin = new System.Windows.Forms.Padding(2);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(1002, 45);
			this.panel1.TabIndex = 0;
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.ForeColor = System.Drawing.Color.White;
			this.label1.Location = new System.Drawing.Point(326, 13);
			this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(220, 19);
			this.label1.TabIndex = 1;
			this.label1.Text = "COATING REPORTING";
			// 
			// btn_back
			// 
			this.btn_back.BackColor = System.Drawing.Color.Silver;
			this.btn_back.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btn_back.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_back.Location = new System.Drawing.Point(409, 613);
			this.btn_back.Margin = new System.Windows.Forms.Padding(2);
			this.btn_back.Name = "btn_back";
			this.btn_back.Size = new System.Drawing.Size(163, 27);
			this.btn_back.TabIndex = 16;
			this.btn_back.Text = "Cancel";
			this.btn_back.UseVisualStyleBackColor = false;
			this.btn_back.Click += new System.EventHandler(this.Btn_backClick);
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.btn_capacity);
			this.groupBox3.Controls.Add(this.btn_prod_output_underweight);
			this.groupBox3.Controls.Add(this.btn_prod_output_overweight);
			this.groupBox3.Controls.Add(this.btn_stock_receive);
			this.groupBox3.Controls.Add(this.btn_sumbopp);
			this.groupBox3.Controls.Add(this.btn_conv_outstanding_jr);
			this.groupBox3.Controls.Add(this.btn_Cgrade);
			this.groupBox3.Controls.Add(this.btn_po);
			this.groupBox3.Controls.Add(this.btn_cjsm);
			this.groupBox3.Controls.Add(this.btn_podj);
			this.groupBox3.Controls.Add(this.btn_ple);
			this.groupBox3.Controls.Add(this.btn_pod);
			this.groupBox3.Controls.Add(this.btn_cjso);
			this.groupBox3.Controls.Add(this.btn_pw);
			this.groupBox3.Controls.Add(this.btn_pb);
			this.groupBox3.Controls.Add(this.btn_pc);
			this.groupBox3.Location = new System.Drawing.Point(22, 98);
			this.groupBox3.Margin = new System.Windows.Forms.Padding(2);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Padding = new System.Windows.Forms.Padding(2);
			this.groupBox3.Size = new System.Drawing.Size(957, 362);
			this.groupBox3.TabIndex = 12;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "REPORT";
			// 
			// btn_prod_output_underweight
			// 
			this.btn_prod_output_underweight.BackColor = System.Drawing.Color.Silver;
			this.btn_prod_output_underweight.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_prod_output_underweight.Location = new System.Drawing.Point(511, 309);
			this.btn_prod_output_underweight.Margin = new System.Windows.Forms.Padding(2);
			this.btn_prod_output_underweight.Name = "btn_prod_output_underweight";
			this.btn_prod_output_underweight.Size = new System.Drawing.Size(243, 35);
			this.btn_prod_output_underweight.TabIndex = 33;
			this.btn_prod_output_underweight.Text = "Production Output Underweight";
			this.btn_prod_output_underweight.UseVisualStyleBackColor = false;
			this.btn_prod_output_underweight.Click += new System.EventHandler(this.Btn_prod_output_underweightClick);
			// 
			// btn_prod_output_overweight
			// 
			this.btn_prod_output_overweight.BackColor = System.Drawing.Color.Silver;
			this.btn_prod_output_overweight.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_prod_output_overweight.Location = new System.Drawing.Point(511, 270);
			this.btn_prod_output_overweight.Margin = new System.Windows.Forms.Padding(2);
			this.btn_prod_output_overweight.Name = "btn_prod_output_overweight";
			this.btn_prod_output_overweight.Size = new System.Drawing.Size(243, 35);
			this.btn_prod_output_overweight.TabIndex = 32;
			this.btn_prod_output_overweight.Text = "Production Output Overweight";
			this.btn_prod_output_overweight.UseVisualStyleBackColor = false;
			this.btn_prod_output_overweight.Click += new System.EventHandler(this.Btn_prod_output_overweightClick);
			// 
			// btn_stock_receive
			// 
			this.btn_stock_receive.BackColor = System.Drawing.Color.Silver;
			this.btn_stock_receive.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_stock_receive.Location = new System.Drawing.Point(245, 309);
			this.btn_stock_receive.Margin = new System.Windows.Forms.Padding(2);
			this.btn_stock_receive.Name = "btn_stock_receive";
			this.btn_stock_receive.Size = new System.Drawing.Size(243, 35);
			this.btn_stock_receive.TabIndex = 31;
			this.btn_stock_receive.Text = "Coating Stock Transfer Receive";
			this.btn_stock_receive.UseVisualStyleBackColor = false;
			this.btn_stock_receive.Click += new System.EventHandler(this.Btn_stock_receiveClick);
			// 
			// btn_sumbopp
			// 
			this.btn_sumbopp.BackColor = System.Drawing.Color.Silver;
			this.btn_sumbopp.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_sumbopp.Location = new System.Drawing.Point(511, 231);
			this.btn_sumbopp.Margin = new System.Windows.Forms.Padding(2);
			this.btn_sumbopp.Name = "btn_sumbopp";
			this.btn_sumbopp.Size = new System.Drawing.Size(243, 35);
			this.btn_sumbopp.TabIndex = 30;
			this.btn_sumbopp.Text = "Summary Bopp Stock";
			this.btn_sumbopp.UseVisualStyleBackColor = false;
			this.btn_sumbopp.Click += new System.EventHandler(this.Btn_sumboppClick);
			// 
			// btn_conv_outstanding_jr
			// 
			this.btn_conv_outstanding_jr.BackColor = System.Drawing.Color.Silver;
			this.btn_conv_outstanding_jr.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_conv_outstanding_jr.Location = new System.Drawing.Point(245, 270);
			this.btn_conv_outstanding_jr.Margin = new System.Windows.Forms.Padding(2);
			this.btn_conv_outstanding_jr.Name = "btn_conv_outstanding_jr";
			this.btn_conv_outstanding_jr.Size = new System.Drawing.Size(243, 35);
			this.btn_conv_outstanding_jr.TabIndex = 29;
			this.btn_conv_outstanding_jr.Text = "Converting Outstanding JR";
			this.btn_conv_outstanding_jr.UseVisualStyleBackColor = false;
			this.btn_conv_outstanding_jr.Click += new System.EventHandler(this.Btn_conv_outstanding_jrClick);
			// 
			// btn_Cgrade
			// 
			this.btn_Cgrade.BackColor = System.Drawing.Color.Silver;
			this.btn_Cgrade.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_Cgrade.Location = new System.Drawing.Point(511, 75);
			this.btn_Cgrade.Margin = new System.Windows.Forms.Padding(2);
			this.btn_Cgrade.Name = "btn_Cgrade";
			this.btn_Cgrade.Size = new System.Drawing.Size(243, 35);
			this.btn_Cgrade.TabIndex = 28;
			this.btn_Cgrade.Text = "Production C-Grade";
			this.btn_Cgrade.UseVisualStyleBackColor = false;
			this.btn_Cgrade.Click += new System.EventHandler(this.Btn_CgradeClick);
			// 
			// btn_po
			// 
			this.btn_po.BackColor = System.Drawing.Color.Silver;
			this.btn_po.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_po.Location = new System.Drawing.Point(244, 36);
			this.btn_po.Margin = new System.Windows.Forms.Padding(2);
			this.btn_po.Name = "btn_po";
			this.btn_po.Size = new System.Drawing.Size(243, 35);
			this.btn_po.TabIndex = 26;
			this.btn_po.Text = "Production Output";
			this.btn_po.UseVisualStyleBackColor = false;
			this.btn_po.Click += new System.EventHandler(this.Button11Click);
			// 
			// btn_cjsm
			// 
			this.btn_cjsm.BackColor = System.Drawing.Color.Silver;
			this.btn_cjsm.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_cjsm.Location = new System.Drawing.Point(245, 153);
			this.btn_cjsm.Margin = new System.Windows.Forms.Padding(2);
			this.btn_cjsm.Name = "btn_cjsm";
			this.btn_cjsm.Size = new System.Drawing.Size(243, 35);
			this.btn_cjsm.TabIndex = 25;
			this.btn_cjsm.Text = "Check JR Shipping Mark";
			this.btn_cjsm.UseVisualStyleBackColor = false;
			this.btn_cjsm.Click += new System.EventHandler(this.Button10Click);
			// 
			// btn_podj
			// 
			this.btn_podj.BackColor = System.Drawing.Color.Silver;
			this.btn_podj.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_podj.Location = new System.Drawing.Point(511, 114);
			this.btn_podj.Margin = new System.Windows.Forms.Padding(2);
			this.btn_podj.Name = "btn_podj";
			this.btn_podj.Size = new System.Drawing.Size(243, 35);
			this.btn_podj.TabIndex = 24;
			this.btn_podj.Text = "Production Output Detail Jo";
			this.btn_podj.UseVisualStyleBackColor = false;
			this.btn_podj.Click += new System.EventHandler(this.Button9Click);
			// 
			// btn_ple
			// 
			this.btn_ple.BackColor = System.Drawing.Color.Silver;
			this.btn_ple.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_ple.Location = new System.Drawing.Point(511, 192);
			this.btn_ple.Margin = new System.Windows.Forms.Padding(2);
			this.btn_ple.Name = "btn_ple";
			this.btn_ple.Size = new System.Drawing.Size(243, 35);
			this.btn_ple.TabIndex = 23;
			this.btn_ple.Text = "Product Local Extra";
			this.btn_ple.UseVisualStyleBackColor = false;
			this.btn_ple.Click += new System.EventHandler(this.Button8Click);
			// 
			// btn_pod
			// 
			this.btn_pod.BackColor = System.Drawing.Color.Silver;
			this.btn_pod.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_pod.Location = new System.Drawing.Point(244, 115);
			this.btn_pod.Margin = new System.Windows.Forms.Padding(2);
			this.btn_pod.Name = "btn_pod";
			this.btn_pod.Size = new System.Drawing.Size(243, 35);
			this.btn_pod.TabIndex = 22;
			this.btn_pod.Text = "Production Output Detail";
			this.btn_pod.UseVisualStyleBackColor = false;
			this.btn_pod.Click += new System.EventHandler(this.Button7Click);
			// 
			// btn_cjso
			// 
			this.btn_cjso.BackColor = System.Drawing.Color.Silver;
			this.btn_cjso.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_cjso.Location = new System.Drawing.Point(511, 153);
			this.btn_cjso.Margin = new System.Windows.Forms.Padding(2);
			this.btn_cjso.Name = "btn_cjso";
			this.btn_cjso.Size = new System.Drawing.Size(243, 35);
			this.btn_cjso.TabIndex = 21;
			this.btn_cjso.Text = "Check Jr Sales Order";
			this.btn_cjso.UseVisualStyleBackColor = false;
			this.btn_cjso.Click += new System.EventHandler(this.Button6Click);
			// 
			// btn_pw
			// 
			this.btn_pw.BackColor = System.Drawing.Color.Silver;
			this.btn_pw.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_pw.Location = new System.Drawing.Point(244, 192);
			this.btn_pw.Margin = new System.Windows.Forms.Padding(2);
			this.btn_pw.Name = "btn_pw";
			this.btn_pw.Size = new System.Drawing.Size(243, 35);
			this.btn_pw.TabIndex = 20;
			this.btn_pw.Text = "Production Wastage";
			this.btn_pw.UseVisualStyleBackColor = false;
			this.btn_pw.Click += new System.EventHandler(this.Button5Click);
			// 
			// btn_pb
			// 
			this.btn_pb.BackColor = System.Drawing.Color.Silver;
			this.btn_pb.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_pb.Location = new System.Drawing.Point(244, 75);
			this.btn_pb.Margin = new System.Windows.Forms.Padding(2);
			this.btn_pb.Name = "btn_pb";
			this.btn_pb.Size = new System.Drawing.Size(243, 35);
			this.btn_pb.TabIndex = 19;
			this.btn_pb.Text = "Production B-Grade";
			this.btn_pb.UseVisualStyleBackColor = false;
			this.btn_pb.Click += new System.EventHandler(this.Button4Click);
			// 
			// btn_pc
			// 
			this.btn_pc.BackColor = System.Drawing.Color.Silver;
			this.btn_pc.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_pc.Location = new System.Drawing.Point(510, 36);
			this.btn_pc.Margin = new System.Windows.Forms.Padding(2);
			this.btn_pc.Name = "btn_pc";
			this.btn_pc.Size = new System.Drawing.Size(243, 35);
			this.btn_pc.TabIndex = 18;
			this.btn_pc.Text = "Production Consumption";
			this.btn_pc.UseVisualStyleBackColor = false;
			this.btn_pc.Click += new System.EventHandler(this.Button1Click);
			// 
			// btn_capacity
			// 
			this.btn_capacity.BackColor = System.Drawing.Color.Silver;
			this.btn_capacity.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_capacity.Location = new System.Drawing.Point(244, 231);
			this.btn_capacity.Margin = new System.Windows.Forms.Padding(2);
			this.btn_capacity.Name = "btn_capacity";
			this.btn_capacity.Size = new System.Drawing.Size(243, 35);
			this.btn_capacity.TabIndex = 34;
			this.btn_capacity.Text = "Capacity";
			this.btn_capacity.UseVisualStyleBackColor = false;
			this.btn_capacity.Click += new System.EventHandler(this.Btn_capacityClick);
			// 
			// frm_menu_coating
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.AutoScroll = true;
			this.BackColor = System.Drawing.SystemColors.Control;
			this.CancelButton = this.btn_back;
			this.ClientSize = new System.Drawing.Size(1001, 679);
			this.Controls.Add(this.groupBox3);
			this.Controls.Add(this.btn_back);
			this.Controls.Add(this.panel1);
			this.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Margin = new System.Windows.Forms.Padding(4);
			this.MinimumSize = new System.Drawing.Size(1000, 700);
			this.Name = "frm_menu_coating";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "frm_menu_main";
			this.Load += new System.EventHandler(this.Frm_menu_coatingLoad);
			this.panel1.ResumeLayout(false);
			this.groupBox3.ResumeLayout(false);
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.Button btn_capacity;
		private System.Windows.Forms.Button btn_prod_output_underweight;
		private System.Windows.Forms.Button btn_prod_output_overweight;
		private System.Windows.Forms.Button btn_stock_receive;
		private System.Windows.Forms.Button btn_sumbopp;
		private System.Windows.Forms.Button btn_conv_outstanding_jr;
		private System.Windows.Forms.Button btn_Cgrade;
		private System.Windows.Forms.Button btn_po;
		private System.Windows.Forms.Button btn_cjso;
		private System.Windows.Forms.Button btn_pod;
		private System.Windows.Forms.Button btn_ple;
		private System.Windows.Forms.Button btn_podj;
		private System.Windows.Forms.Button btn_cjsm;
		private System.Windows.Forms.Button btn_pw;
		private System.Windows.Forms.Button btn_pc;
		private System.Windows.Forms.Button btn_pb;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.Button btn_back;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Panel panel1;
		
		
		void GroupBox3Enter(object sender, System.EventArgs e)
		{
			
		}
		
	}
}
