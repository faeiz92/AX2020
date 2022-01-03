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
	partial class frm_menu_planning_coating
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
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.btn_bill_schwaner = new System.Windows.Forms.Button();
			this.btn_billmaterial_test2 = new System.Windows.Forms.Button();
			this.btn_billmaterial_test = new System.Windows.Forms.Button();
			this.btn_jo_wip = new System.Windows.Forms.Button();
			this.btn_billmaterial = new System.Windows.Forms.Button();
			this.btn_reprintjo = new System.Windows.Forms.Button();
			this.button7 = new System.Windows.Forms.Button();
			this.btn_JOChangeFilm = new System.Windows.Forms.Button();
			this.btn_printingoop = new System.Windows.Forms.Button();
			this.btn_stockcode = new System.Windows.Forms.Button();
			this.btn_schwaner = new System.Windows.Forms.Button();
			this.btn_doubleside = new System.Windows.Forms.Button();
			this.btn_jo = new System.Windows.Forms.Button();
			this.btn_capacity = new System.Windows.Forms.Button();
			this.panel1.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.Color.DarkCyan;
			this.panel1.Controls.Add(this.label1);
			this.panel1.Location = new System.Drawing.Point(-1, 0);
			this.panel1.Margin = new System.Windows.Forms.Padding(2);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(980, 45);
			this.panel1.TabIndex = 0;
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.ForeColor = System.Drawing.Color.White;
			this.label1.Location = new System.Drawing.Point(400, 8);
			this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(262, 20);
			this.label1.TabIndex = 1;
			this.label1.Text = "PRODUCTION PLANNING";
			// 
			// btn_back
			// 
			this.btn_back.BackColor = System.Drawing.Color.Silver;
			this.btn_back.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btn_back.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_back.Location = new System.Drawing.Point(413, 698);
			this.btn_back.Margin = new System.Windows.Forms.Padding(2);
			this.btn_back.Name = "btn_back";
			this.btn_back.Size = new System.Drawing.Size(130, 30);
			this.btn_back.TabIndex = 16;
			this.btn_back.Text = "Cancel";
			this.btn_back.UseVisualStyleBackColor = false;
			this.btn_back.Click += new System.EventHandler(this.Btn_backClick);
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.btn_capacity);
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
			this.groupBox3.Location = new System.Drawing.Point(22, 393);
			this.groupBox3.Margin = new System.Windows.Forms.Padding(2);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Padding = new System.Windows.Forms.Padding(2);
			this.groupBox3.Size = new System.Drawing.Size(980, 292);
			this.groupBox3.TabIndex = 12;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "REPORT";
			// 
			// btn_conv_outstanding_jr
			// 
			this.btn_conv_outstanding_jr.BackColor = System.Drawing.Color.Silver;
			this.btn_conv_outstanding_jr.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_conv_outstanding_jr.Location = new System.Drawing.Point(216, 245);
			this.btn_conv_outstanding_jr.Margin = new System.Windows.Forms.Padding(2);
			this.btn_conv_outstanding_jr.Name = "btn_conv_outstanding_jr";
			this.btn_conv_outstanding_jr.Size = new System.Drawing.Size(243, 35);
			this.btn_conv_outstanding_jr.TabIndex = 28;
			this.btn_conv_outstanding_jr.Text = "Converting Outstanding JR";
			this.btn_conv_outstanding_jr.UseVisualStyleBackColor = false;
			this.btn_conv_outstanding_jr.Click += new System.EventHandler(this.Btn_conv_outstanding_jrClick);
			// 
			// btn_Cgrade
			// 
			this.btn_Cgrade.BackColor = System.Drawing.Color.Silver;
			this.btn_Cgrade.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_Cgrade.Location = new System.Drawing.Point(473, 68);
			this.btn_Cgrade.Margin = new System.Windows.Forms.Padding(2);
			this.btn_Cgrade.Name = "btn_Cgrade";
			this.btn_Cgrade.Size = new System.Drawing.Size(243, 35);
			this.btn_Cgrade.TabIndex = 27;
			this.btn_Cgrade.Text = "Production C-Grade";
			this.btn_Cgrade.UseVisualStyleBackColor = false;
			this.btn_Cgrade.Click += new System.EventHandler(this.Btn_CgradeClick);
			// 
			// btn_po
			// 
			this.btn_po.BackColor = System.Drawing.Color.Silver;
			this.btn_po.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_po.Location = new System.Drawing.Point(216, 23);
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
			this.btn_cjsm.Location = new System.Drawing.Point(216, 155);
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
			this.btn_podj.Location = new System.Drawing.Point(473, 109);
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
			this.btn_ple.Location = new System.Drawing.Point(216, 200);
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
			this.btn_pod.Location = new System.Drawing.Point(216, 109);
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
			this.btn_cjso.Location = new System.Drawing.Point(473, 155);
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
			this.btn_pw.Location = new System.Drawing.Point(473, 200);
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
			this.btn_pb.Location = new System.Drawing.Point(216, 68);
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
			this.btn_pc.Location = new System.Drawing.Point(473, 23);
			this.btn_pc.Margin = new System.Windows.Forms.Padding(2);
			this.btn_pc.Name = "btn_pc";
			this.btn_pc.Size = new System.Drawing.Size(243, 35);
			this.btn_pc.TabIndex = 18;
			this.btn_pc.Text = "Production Consumption";
			this.btn_pc.UseVisualStyleBackColor = false;
			this.btn_pc.Click += new System.EventHandler(this.Button1Click);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.btn_bill_schwaner);
			this.groupBox1.Controls.Add(this.btn_billmaterial_test2);
			this.groupBox1.Controls.Add(this.btn_billmaterial_test);
			this.groupBox1.Controls.Add(this.btn_jo_wip);
			this.groupBox1.Controls.Add(this.btn_billmaterial);
			this.groupBox1.Controls.Add(this.btn_reprintjo);
			this.groupBox1.Controls.Add(this.button7);
			this.groupBox1.Controls.Add(this.btn_JOChangeFilm);
			this.groupBox1.Controls.Add(this.btn_printingoop);
			this.groupBox1.Controls.Add(this.btn_stockcode);
			this.groupBox1.Controls.Add(this.btn_schwaner);
			this.groupBox1.Controls.Add(this.btn_doubleside);
			this.groupBox1.Controls.Add(this.btn_jo);
			this.groupBox1.Location = new System.Drawing.Point(22, 114);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(980, 269);
			this.groupBox1.TabIndex = 17;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "TYPE OF JO";
			// 
			// btn_bill_schwaner
			// 
			this.btn_bill_schwaner.BackColor = System.Drawing.Color.Silver;
			this.btn_bill_schwaner.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_bill_schwaner.Location = new System.Drawing.Point(216, 169);
			this.btn_bill_schwaner.Margin = new System.Windows.Forms.Padding(2);
			this.btn_bill_schwaner.Name = "btn_bill_schwaner";
			this.btn_bill_schwaner.Size = new System.Drawing.Size(243, 35);
			this.btn_bill_schwaner.TabIndex = 38;
			this.btn_bill_schwaner.Text = "Bill of Material Schwaner";
			this.btn_bill_schwaner.UseVisualStyleBackColor = false;
			this.btn_bill_schwaner.Click += new System.EventHandler(this.Btn_bill_schwanerClick);
			// 
			// btn_billmaterial_test2
			// 
			this.btn_billmaterial_test2.BackColor = System.Drawing.Color.Silver;
			this.btn_billmaterial_test2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_billmaterial_test2.Location = new System.Drawing.Point(726, 169);
			this.btn_billmaterial_test2.Margin = new System.Windows.Forms.Padding(2);
			this.btn_billmaterial_test2.Name = "btn_billmaterial_test2";
			this.btn_billmaterial_test2.Size = new System.Drawing.Size(243, 35);
			this.btn_billmaterial_test2.TabIndex = 37;
			this.btn_billmaterial_test2.Text = "Bill of Material Test 2";
			this.btn_billmaterial_test2.UseVisualStyleBackColor = false;
			this.btn_billmaterial_test2.Click += new System.EventHandler(this.Btn_billmaterial_test2Click);
			// 
			// btn_billmaterial_test
			// 
			this.btn_billmaterial_test.BackColor = System.Drawing.Color.Silver;
			this.btn_billmaterial_test.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_billmaterial_test.Location = new System.Drawing.Point(726, 120);
			this.btn_billmaterial_test.Margin = new System.Windows.Forms.Padding(2);
			this.btn_billmaterial_test.Name = "btn_billmaterial_test";
			this.btn_billmaterial_test.Size = new System.Drawing.Size(243, 35);
			this.btn_billmaterial_test.TabIndex = 36;
			this.btn_billmaterial_test.Text = "Bill of Material Test";
			this.btn_billmaterial_test.UseVisualStyleBackColor = false;
			// 
			// btn_jo_wip
			// 
			this.btn_jo_wip.BackColor = System.Drawing.SystemColors.ActiveBorder;
			this.btn_jo_wip.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_jo_wip.Location = new System.Drawing.Point(726, 74);
			this.btn_jo_wip.Margin = new System.Windows.Forms.Padding(2);
			this.btn_jo_wip.Name = "btn_jo_wip";
			this.btn_jo_wip.Size = new System.Drawing.Size(243, 35);
			this.btn_jo_wip.TabIndex = 35;
			this.btn_jo_wip.Text = "Jo Order WIP";
			this.btn_jo_wip.UseVisualStyleBackColor = false;
			this.btn_jo_wip.Click += new System.EventHandler(this.Btn_jo_wipClick);
			// 
			// btn_billmaterial
			// 
			this.btn_billmaterial.BackColor = System.Drawing.Color.Silver;
			this.btn_billmaterial.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_billmaterial.Location = new System.Drawing.Point(473, 169);
			this.btn_billmaterial.Margin = new System.Windows.Forms.Padding(2);
			this.btn_billmaterial.Name = "btn_billmaterial";
			this.btn_billmaterial.Size = new System.Drawing.Size(243, 35);
			this.btn_billmaterial.TabIndex = 34;
			this.btn_billmaterial.Text = "Bill of Material Printing";
			this.btn_billmaterial.UseVisualStyleBackColor = false;
			this.btn_billmaterial.Click += new System.EventHandler(this.Btn_billmaterialClick);
			// 
			// btn_reprintjo
			// 
			this.btn_reprintjo.BackColor = System.Drawing.SystemColors.ActiveBorder;
			this.btn_reprintjo.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_reprintjo.Location = new System.Drawing.Point(216, 217);
			this.btn_reprintjo.Margin = new System.Windows.Forms.Padding(2);
			this.btn_reprintjo.Name = "btn_reprintjo";
			this.btn_reprintjo.Size = new System.Drawing.Size(243, 35);
			this.btn_reprintjo.TabIndex = 34;
			this.btn_reprintjo.Text = "RE-PRINT Job Order";
			this.btn_reprintjo.UseVisualStyleBackColor = false;
			this.btn_reprintjo.Click += new System.EventHandler(this.Btn_reprintjoClick);
			// 
			// button7
			// 
			this.button7.BackColor = System.Drawing.Color.Silver;
			this.button7.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.button7.Location = new System.Drawing.Point(473, 217);
			this.button7.Margin = new System.Windows.Forms.Padding(2);
			this.button7.Name = "button7";
			this.button7.Size = new System.Drawing.Size(243, 35);
			this.button7.TabIndex = 33;
			this.button7.Text = "JO Printing Change";
			this.button7.UseVisualStyleBackColor = false;
			// 
			// btn_JOChangeFilm
			// 
			this.btn_JOChangeFilm.BackColor = System.Drawing.Color.Silver;
			this.btn_JOChangeFilm.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_JOChangeFilm.Location = new System.Drawing.Point(473, 120);
			this.btn_JOChangeFilm.Margin = new System.Windows.Forms.Padding(2);
			this.btn_JOChangeFilm.Name = "btn_JOChangeFilm";
			this.btn_JOChangeFilm.Size = new System.Drawing.Size(243, 35);
			this.btn_JOChangeFilm.TabIndex = 32;
			this.btn_JOChangeFilm.Text = "JO Change Film ";
			this.btn_JOChangeFilm.UseVisualStyleBackColor = false;
			this.btn_JOChangeFilm.Click += new System.EventHandler(this.Btn_JOChangeFilmClick);
			// 
			// btn_printingoop
			// 
			this.btn_printingoop.BackColor = System.Drawing.Color.Silver;
			this.btn_printingoop.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_printingoop.Location = new System.Drawing.Point(473, 73);
			this.btn_printingoop.Margin = new System.Windows.Forms.Padding(2);
			this.btn_printingoop.Name = "btn_printingoop";
			this.btn_printingoop.Size = new System.Drawing.Size(243, 35);
			this.btn_printingoop.TabIndex = 31;
			this.btn_printingoop.Text = "JO - Printing OPP ";
			this.btn_printingoop.UseVisualStyleBackColor = false;
			this.btn_printingoop.Click += new System.EventHandler(this.Btn_printingoopClick);
			// 
			// btn_stockcode
			// 
			this.btn_stockcode.BackColor = System.Drawing.Color.Silver;
			this.btn_stockcode.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_stockcode.Location = new System.Drawing.Point(473, 24);
			this.btn_stockcode.Margin = new System.Windows.Forms.Padding(2);
			this.btn_stockcode.Name = "btn_stockcode";
			this.btn_stockcode.Size = new System.Drawing.Size(243, 35);
			this.btn_stockcode.TabIndex = 30;
			this.btn_stockcode.Text = "JO - Stockcode";
			this.btn_stockcode.UseVisualStyleBackColor = false;
			this.btn_stockcode.Click += new System.EventHandler(this.Btn_stockcodeClick);
			// 
			// btn_schwaner
			// 
			this.btn_schwaner.BackColor = System.Drawing.Color.Silver;
			this.btn_schwaner.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_schwaner.Location = new System.Drawing.Point(216, 120);
			this.btn_schwaner.Margin = new System.Windows.Forms.Padding(2);
			this.btn_schwaner.Name = "btn_schwaner";
			this.btn_schwaner.Size = new System.Drawing.Size(243, 35);
			this.btn_schwaner.TabIndex = 29;
			this.btn_schwaner.Text = "JO - Schwaner ";
			this.btn_schwaner.UseVisualStyleBackColor = false;
			this.btn_schwaner.Click += new System.EventHandler(this.Btn_schwanerClick);
			// 
			// btn_doubleside
			// 
			this.btn_doubleside.BackColor = System.Drawing.Color.Silver;
			this.btn_doubleside.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_doubleside.Location = new System.Drawing.Point(216, 73);
			this.btn_doubleside.Margin = new System.Windows.Forms.Padding(2);
			this.btn_doubleside.Name = "btn_doubleside";
			this.btn_doubleside.Size = new System.Drawing.Size(243, 35);
			this.btn_doubleside.TabIndex = 28;
			this.btn_doubleside.Text = "JO - Double Side ";
			this.btn_doubleside.UseVisualStyleBackColor = false;
			this.btn_doubleside.Click += new System.EventHandler(this.Btn_doublesideClick);
			// 
			// btn_jo
			// 
			this.btn_jo.BackColor = System.Drawing.Color.Silver;
			this.btn_jo.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_jo.Location = new System.Drawing.Point(216, 24);
			this.btn_jo.Margin = new System.Windows.Forms.Padding(2);
			this.btn_jo.Name = "btn_jo";
			this.btn_jo.Size = new System.Drawing.Size(243, 35);
			this.btn_jo.TabIndex = 27;
			this.btn_jo.Text = "Job Order";
			this.btn_jo.UseVisualStyleBackColor = false;
			this.btn_jo.Click += new System.EventHandler(this.Btn_joClick);
			// 
			// btn_capacity
			// 
			this.btn_capacity.BackColor = System.Drawing.Color.Silver;
			this.btn_capacity.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_capacity.Location = new System.Drawing.Point(473, 245);
			this.btn_capacity.Margin = new System.Windows.Forms.Padding(2);
			this.btn_capacity.Name = "btn_capacity";
			this.btn_capacity.Size = new System.Drawing.Size(243, 35);
			this.btn_capacity.TabIndex = 29;
			this.btn_capacity.Text = "Capacity";
			this.btn_capacity.UseVisualStyleBackColor = false;
			this.btn_capacity.Click += new System.EventHandler(this.Btn_capacityClick);
			// 
			// frm_menu_planning_coating
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.AutoScroll = true;
			this.BackColor = System.Drawing.SystemColors.Control;
			this.CancelButton = this.btn_back;
			this.ClientSize = new System.Drawing.Size(1018, 696);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.groupBox3);
			this.Controls.Add(this.btn_back);
			this.Controls.Add(this.panel1);
			this.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Margin = new System.Windows.Forms.Padding(4);
			this.MinimumSize = new System.Drawing.Size(1000, 700);
			this.Name = "frm_menu_planning_coating";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "frm_menu_main";
			this.Load += new System.EventHandler(this.Frm_menu_coatingLoad);
			this.panel1.ResumeLayout(false);
			this.groupBox3.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.Button btn_capacity;
		private System.Windows.Forms.Button btn_bill_schwaner;
		private System.Windows.Forms.Button btn_conv_outstanding_jr;
		private System.Windows.Forms.Button btn_billmaterial_test2;
		private System.Windows.Forms.Button btn_billmaterial_test;
		private System.Windows.Forms.Button btn_Cgrade;
		private System.Windows.Forms.Button btn_jo_wip;
		private System.Windows.Forms.Button btn_reprintjo;
		private System.Windows.Forms.Button btn_jo;
		private System.Windows.Forms.Button btn_doubleside;
		private System.Windows.Forms.Button btn_schwaner;
		private System.Windows.Forms.Button btn_stockcode;
		private System.Windows.Forms.Button btn_printingoop;
		private System.Windows.Forms.Button btn_JOChangeFilm;
		private System.Windows.Forms.Button button7;
		private System.Windows.Forms.Button btn_billmaterial;
		private System.Windows.Forms.GroupBox groupBox1;
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
