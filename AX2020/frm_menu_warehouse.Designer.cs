/*
 * Created by SharpDevelop.
 * User: ax2020-1
 * Date: 1/26/2017
 * Time: 10:39 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace AX2020
{
	partial class frm_menu_warehouse
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
			this.grpbox_order = new System.Windows.Forms.GroupBox();
			this.btn_sample_request = new System.Windows.Forms.Button();
			this.btn_store_order = new System.Windows.Forms.Button();
			this.btn_warehouse_order = new System.Windows.Forms.Button();
			this.grpbx_receive = new System.Windows.Forms.GroupBox();
			this.btn_stock_receive_film = new System.Windows.Forms.Button();
			this.btn_stock_receive_ribbon = new System.Windows.Forms.Button();
			this.btn_stock_receive_kliner = new System.Windows.Forms.Button();
			this.btn_stock_receive_fr = new System.Windows.Forms.Button();
			this.btn_stock_receive_jr = new System.Windows.Forms.Button();
			this.grpbx_so = new System.Windows.Forms.GroupBox();
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.btn_get_so = new System.Windows.Forms.Button();
			this.btn_stock_receive_fr_checklist = new System.Windows.Forms.Button();
			this.grpbx_prod = new System.Windows.Forms.GroupBox();
			this.btn_converting = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.btn_poimport = new System.Windows.Forms.Button();
			this.btn_polocal = new System.Windows.Forms.Button();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.btn_bopp_label = new System.Windows.Forms.Button();
			this.btn_menu_wj303 = new System.Windows.Forms.Button();
			this.btn_stock_recive_jr = new System.Windows.Forms.Button();
			this.btn_jr_mov = new System.Windows.Forms.Button();
			this.btn_jr_transfer = new System.Windows.Forms.Button();
			this.btn_bopp_transfer = new System.Windows.Forms.Button();
			this.btn_bopp_upload = new System.Windows.Forms.Button();
			this.panel2.SuspendLayout();
			this.grpbox_order.SuspendLayout();
			this.grpbx_receive.SuspendLayout();
			this.grpbx_so.SuspendLayout();
			this.grpbx_prod.SuspendLayout();
			this.groupBox1.SuspendLayout();
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
			this.lbl_header.Text = "WAREHOUSE";
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
			this.panel2.Size = new System.Drawing.Size(984, 23);
			this.panel2.TabIndex = 111;
			// 
			// btn_back
			// 
			this.btn_back.BackColor = System.Drawing.Color.Silver;
			this.btn_back.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btn_back.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_back.Location = new System.Drawing.Point(440, 609);
			this.btn_back.Margin = new System.Windows.Forms.Padding(1);
			this.btn_back.Name = "btn_back";
			this.btn_back.Size = new System.Drawing.Size(120, 27);
			this.btn_back.TabIndex = 114;
			this.btn_back.Text = "Cancel";
			this.btn_back.UseVisualStyleBackColor = false;
			this.btn_back.Click += new System.EventHandler(this.Btn_backClick);
			// 
			// grpbox_order
			// 
			this.grpbox_order.Controls.Add(this.btn_sample_request);
			this.grpbox_order.Controls.Add(this.btn_store_order);
			this.grpbox_order.Controls.Add(this.btn_warehouse_order);
			this.grpbox_order.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.grpbox_order.Location = new System.Drawing.Point(66, 95);
			this.grpbox_order.Name = "grpbox_order";
			this.grpbox_order.Size = new System.Drawing.Size(274, 201);
			this.grpbox_order.TabIndex = 119;
			this.grpbox_order.TabStop = false;
			this.grpbox_order.Text = "Order";
			// 
			// btn_sample_request
			// 
			this.btn_sample_request.BackColor = System.Drawing.Color.Silver;
			this.btn_sample_request.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_sample_request.Location = new System.Drawing.Point(22, 135);
			this.btn_sample_request.Margin = new System.Windows.Forms.Padding(1);
			this.btn_sample_request.Name = "btn_sample_request";
			this.btn_sample_request.Size = new System.Drawing.Size(231, 46);
			this.btn_sample_request.TabIndex = 5;
			this.btn_sample_request.Text = "Sample Request";
			this.btn_sample_request.UseVisualStyleBackColor = false;
			this.btn_sample_request.Click += new System.EventHandler(this.Btn_sample_requestClick);
			// 
			// btn_store_order
			// 
			this.btn_store_order.BackColor = System.Drawing.Color.Silver;
			this.btn_store_order.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_store_order.Location = new System.Drawing.Point(22, 33);
			this.btn_store_order.Margin = new System.Windows.Forms.Padding(1);
			this.btn_store_order.Name = "btn_store_order";
			this.btn_store_order.Size = new System.Drawing.Size(231, 46);
			this.btn_store_order.TabIndex = 3;
			this.btn_store_order.Text = "Store Order - FR";
			this.btn_store_order.UseVisualStyleBackColor = false;
			this.btn_store_order.Click += new System.EventHandler(this.Btn_store_orderClick);
			// 
			// btn_warehouse_order
			// 
			this.btn_warehouse_order.BackColor = System.Drawing.Color.Silver;
			this.btn_warehouse_order.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_warehouse_order.Location = new System.Drawing.Point(22, 84);
			this.btn_warehouse_order.Margin = new System.Windows.Forms.Padding(1);
			this.btn_warehouse_order.Name = "btn_warehouse_order";
			this.btn_warehouse_order.Size = new System.Drawing.Size(231, 46);
			this.btn_warehouse_order.TabIndex = 4;
			this.btn_warehouse_order.Text = "Warehouse Order - JR";
			this.btn_warehouse_order.UseVisualStyleBackColor = false;
			this.btn_warehouse_order.Click += new System.EventHandler(this.Btn_warehouse_orderClick);
			// 
			// grpbx_receive
			// 
			this.grpbx_receive.Controls.Add(this.btn_stock_receive_film);
			this.grpbx_receive.Controls.Add(this.btn_stock_receive_ribbon);
			this.grpbx_receive.Controls.Add(this.btn_stock_receive_kliner);
			this.grpbx_receive.Controls.Add(this.btn_stock_receive_fr);
			this.grpbx_receive.Controls.Add(this.btn_stock_receive_jr);
			this.grpbx_receive.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.grpbx_receive.Location = new System.Drawing.Point(358, 95);
			this.grpbx_receive.Name = "grpbx_receive";
			this.grpbx_receive.Size = new System.Drawing.Size(274, 313);
			this.grpbx_receive.TabIndex = 120;
			this.grpbx_receive.TabStop = false;
			this.grpbx_receive.Text = "Receive";
			// 
			// btn_stock_receive_film
			// 
			this.btn_stock_receive_film.BackColor = System.Drawing.Color.Silver;
			this.btn_stock_receive_film.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_stock_receive_film.Location = new System.Drawing.Point(22, 237);
			this.btn_stock_receive_film.Margin = new System.Windows.Forms.Padding(1);
			this.btn_stock_receive_film.Name = "btn_stock_receive_film";
			this.btn_stock_receive_film.Size = new System.Drawing.Size(231, 46);
			this.btn_stock_receive_film.TabIndex = 123;
			this.btn_stock_receive_film.Text = "Stock Receive - Stretch Film";
			this.btn_stock_receive_film.UseVisualStyleBackColor = false;
			this.btn_stock_receive_film.Click += new System.EventHandler(this.Btn_stock_receive_filmClick);
			// 
			// btn_stock_receive_ribbon
			// 
			this.btn_stock_receive_ribbon.BackColor = System.Drawing.Color.Silver;
			this.btn_stock_receive_ribbon.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_stock_receive_ribbon.Location = new System.Drawing.Point(22, 135);
			this.btn_stock_receive_ribbon.Margin = new System.Windows.Forms.Padding(1);
			this.btn_stock_receive_ribbon.Name = "btn_stock_receive_ribbon";
			this.btn_stock_receive_ribbon.Size = new System.Drawing.Size(231, 46);
			this.btn_stock_receive_ribbon.TabIndex = 121;
			this.btn_stock_receive_ribbon.Text = "Stock Receive - Ribbon";
			this.btn_stock_receive_ribbon.UseVisualStyleBackColor = false;
			this.btn_stock_receive_ribbon.Click += new System.EventHandler(this.Btn_stock_receive_ribbonClick);
			// 
			// btn_stock_receive_kliner
			// 
			this.btn_stock_receive_kliner.BackColor = System.Drawing.Color.Silver;
			this.btn_stock_receive_kliner.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_stock_receive_kliner.Location = new System.Drawing.Point(22, 186);
			this.btn_stock_receive_kliner.Margin = new System.Windows.Forms.Padding(1);
			this.btn_stock_receive_kliner.Name = "btn_stock_receive_kliner";
			this.btn_stock_receive_kliner.Size = new System.Drawing.Size(231, 46);
			this.btn_stock_receive_kliner.TabIndex = 122;
			this.btn_stock_receive_kliner.Text = "Stock Receive - Kliner";
			this.btn_stock_receive_kliner.UseVisualStyleBackColor = false;
			this.btn_stock_receive_kliner.Click += new System.EventHandler(this.Btn_stock_receive_klinerClick);
			// 
			// btn_stock_receive_fr
			// 
			this.btn_stock_receive_fr.BackColor = System.Drawing.Color.Silver;
			this.btn_stock_receive_fr.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_stock_receive_fr.Location = new System.Drawing.Point(22, 33);
			this.btn_stock_receive_fr.Margin = new System.Windows.Forms.Padding(1);
			this.btn_stock_receive_fr.Name = "btn_stock_receive_fr";
			this.btn_stock_receive_fr.Size = new System.Drawing.Size(231, 46);
			this.btn_stock_receive_fr.TabIndex = 119;
			this.btn_stock_receive_fr.Text = "Stock Receive - FR";
			this.btn_stock_receive_fr.UseVisualStyleBackColor = false;
			this.btn_stock_receive_fr.Click += new System.EventHandler(this.Btn_stock_receive_frClick);
			// 
			// btn_stock_receive_jr
			// 
			this.btn_stock_receive_jr.BackColor = System.Drawing.Color.Silver;
			this.btn_stock_receive_jr.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_stock_receive_jr.Location = new System.Drawing.Point(22, 84);
			this.btn_stock_receive_jr.Margin = new System.Windows.Forms.Padding(1);
			this.btn_stock_receive_jr.Name = "btn_stock_receive_jr";
			this.btn_stock_receive_jr.Size = new System.Drawing.Size(231, 46);
			this.btn_stock_receive_jr.TabIndex = 120;
			this.btn_stock_receive_jr.Text = "Stock Receive - JR";
			this.btn_stock_receive_jr.UseVisualStyleBackColor = false;
			this.btn_stock_receive_jr.Click += new System.EventHandler(this.Btn_stock_receive_jrClick);
			// 
			// grpbx_so
			// 
			this.grpbx_so.Controls.Add(this.button1);
			this.grpbx_so.Controls.Add(this.button2);
			this.grpbx_so.Controls.Add(this.btn_get_so);
			this.grpbx_so.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.grpbx_so.Location = new System.Drawing.Point(651, 95);
			this.grpbx_so.Name = "grpbx_so";
			this.grpbx_so.Size = new System.Drawing.Size(274, 201);
			this.grpbx_so.TabIndex = 120;
			this.grpbx_so.TabStop = false;
			this.grpbx_so.Text = "Sales Order";
			// 
			// button1
			// 
			this.button1.BackColor = System.Drawing.Color.Silver;
			this.button1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.button1.Location = new System.Drawing.Point(22, 135);
			this.button1.Margin = new System.Windows.Forms.Padding(1);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(231, 46);
			this.button1.TabIndex = 8;
			this.button1.Text = "Sales Order Delivery Next 5 Days";
			this.button1.UseVisualStyleBackColor = false;
			this.button1.Click += new System.EventHandler(this.Button1Click);
			// 
			// button2
			// 
			this.button2.BackColor = System.Drawing.Color.Silver;
			this.button2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.button2.Location = new System.Drawing.Point(22, 84);
			this.button2.Margin = new System.Windows.Forms.Padding(1);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(231, 46);
			this.button2.TabIndex = 7;
			this.button2.Text = "Sales Backorder Due";
			this.button2.UseVisualStyleBackColor = false;
			this.button2.Click += new System.EventHandler(this.Button2Click);
			// 
			// btn_get_so
			// 
			this.btn_get_so.BackColor = System.Drawing.Color.Silver;
			this.btn_get_so.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_get_so.Location = new System.Drawing.Point(22, 33);
			this.btn_get_so.Margin = new System.Windows.Forms.Padding(1);
			this.btn_get_so.Name = "btn_get_so";
			this.btn_get_so.Size = new System.Drawing.Size(231, 46);
			this.btn_get_so.TabIndex = 3;
			this.btn_get_so.Text = "Get Sales Order";
			this.btn_get_so.UseVisualStyleBackColor = false;
			this.btn_get_so.Click += new System.EventHandler(this.Btn_get_soClick);
			// 
			// btn_stock_receive_fr_checklist
			// 
			this.btn_stock_receive_fr_checklist.BackColor = System.Drawing.Color.Silver;
			this.btn_stock_receive_fr_checklist.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_stock_receive_fr_checklist.Location = new System.Drawing.Point(380, 421);
			this.btn_stock_receive_fr_checklist.Margin = new System.Windows.Forms.Padding(1);
			this.btn_stock_receive_fr_checklist.Name = "btn_stock_receive_fr_checklist";
			this.btn_stock_receive_fr_checklist.Size = new System.Drawing.Size(231, 46);
			this.btn_stock_receive_fr_checklist.TabIndex = 124;
			this.btn_stock_receive_fr_checklist.Text = "Stock Receive - FR Checklist";
			this.btn_stock_receive_fr_checklist.UseVisualStyleBackColor = false;
			this.btn_stock_receive_fr_checklist.Click += new System.EventHandler(this.Btn_stock_receive_fr_checklistClick);
			// 
			// grpbx_prod
			// 
			this.grpbx_prod.Controls.Add(this.btn_converting);
			this.grpbx_prod.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.grpbx_prod.Location = new System.Drawing.Point(651, 301);
			this.grpbx_prod.Name = "grpbx_prod";
			this.grpbx_prod.Size = new System.Drawing.Size(274, 101);
			this.grpbx_prod.TabIndex = 121;
			this.grpbx_prod.TabStop = false;
			this.grpbx_prod.Text = "Production";
			// 
			// btn_converting
			// 
			this.btn_converting.BackColor = System.Drawing.Color.Silver;
			this.btn_converting.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_converting.Location = new System.Drawing.Point(22, 33);
			this.btn_converting.Margin = new System.Windows.Forms.Padding(1);
			this.btn_converting.Name = "btn_converting";
			this.btn_converting.Size = new System.Drawing.Size(231, 46);
			this.btn_converting.TabIndex = 3;
			this.btn_converting.Text = "Converting";
			this.btn_converting.UseVisualStyleBackColor = false;
			this.btn_converting.Click += new System.EventHandler(this.Btn_convertingClick);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.btn_poimport);
			this.groupBox1.Controls.Add(this.btn_polocal);
			this.groupBox1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.groupBox1.Location = new System.Drawing.Point(651, 409);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(274, 148);
			this.groupBox1.TabIndex = 125;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Purchase Order Delivery";
			// 
			// btn_poimport
			// 
			this.btn_poimport.BackColor = System.Drawing.Color.Silver;
			this.btn_poimport.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_poimport.Location = new System.Drawing.Point(22, 81);
			this.btn_poimport.Margin = new System.Windows.Forms.Padding(1);
			this.btn_poimport.Name = "btn_poimport";
			this.btn_poimport.Size = new System.Drawing.Size(231, 46);
			this.btn_poimport.TabIndex = 4;
			this.btn_poimport.Text = "Po Import";
			this.btn_poimport.UseVisualStyleBackColor = false;
			this.btn_poimport.Click += new System.EventHandler(this.Btn_poimportClick);
			// 
			// btn_polocal
			// 
			this.btn_polocal.BackColor = System.Drawing.Color.Silver;
			this.btn_polocal.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_polocal.Location = new System.Drawing.Point(22, 33);
			this.btn_polocal.Margin = new System.Windows.Forms.Padding(1);
			this.btn_polocal.Name = "btn_polocal";
			this.btn_polocal.Size = new System.Drawing.Size(231, 46);
			this.btn_polocal.TabIndex = 3;
			this.btn_polocal.Text = "Po Local";
			this.btn_polocal.UseVisualStyleBackColor = false;
			this.btn_polocal.Click += new System.EventHandler(this.Btn_polocalClick);
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.btn_bopp_label);
			this.groupBox2.Controls.Add(this.btn_menu_wj303);
			this.groupBox2.Controls.Add(this.btn_stock_recive_jr);
			this.groupBox2.Controls.Add(this.btn_jr_mov);
			this.groupBox2.Controls.Add(this.btn_jr_transfer);
			this.groupBox2.Controls.Add(this.btn_bopp_transfer);
			this.groupBox2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.groupBox2.Location = new System.Drawing.Point(66, 299);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(274, 337);
			this.groupBox2.TabIndex = 127;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "AX Stock Movement";
			// 
			// btn_bopp_label
			// 
			this.btn_bopp_label.BackColor = System.Drawing.Color.Silver;
			this.btn_bopp_label.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_bopp_label.Location = new System.Drawing.Point(22, 278);
			this.btn_bopp_label.Margin = new System.Windows.Forms.Padding(1);
			this.btn_bopp_label.Name = "btn_bopp_label";
			this.btn_bopp_label.Size = new System.Drawing.Size(231, 46);
			this.btn_bopp_label.TabIndex = 132;
			this.btn_bopp_label.Text = "AX BOPP Print Label";
			this.btn_bopp_label.UseVisualStyleBackColor = false;
			this.btn_bopp_label.Click += new System.EventHandler(this.Btn_bopp_labelClick);
			// 
			// btn_menu_wj303
			// 
			this.btn_menu_wj303.BackColor = System.Drawing.Color.Silver;
			this.btn_menu_wj303.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_menu_wj303.Location = new System.Drawing.Point(22, 228);
			this.btn_menu_wj303.Margin = new System.Windows.Forms.Padding(1);
			this.btn_menu_wj303.Name = "btn_menu_wj303";
			this.btn_menu_wj303.Size = new System.Drawing.Size(231, 46);
			this.btn_menu_wj303.TabIndex = 131;
			this.btn_menu_wj303.Text = "AX WJ Print Label";
			this.btn_menu_wj303.UseVisualStyleBackColor = false;
			this.btn_menu_wj303.Click += new System.EventHandler(this.Btn_menu_wj303Click);
			// 
			// btn_stock_recive_jr
			// 
			this.btn_stock_recive_jr.BackColor = System.Drawing.Color.Silver;
			this.btn_stock_recive_jr.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_stock_recive_jr.Location = new System.Drawing.Point(22, 177);
			this.btn_stock_recive_jr.Margin = new System.Windows.Forms.Padding(1);
			this.btn_stock_recive_jr.Name = "btn_stock_recive_jr";
			this.btn_stock_recive_jr.Size = new System.Drawing.Size(231, 46);
			this.btn_stock_recive_jr.TabIndex = 130;
			this.btn_stock_recive_jr.Text = "AX Stock Receive - JR";
			this.btn_stock_recive_jr.UseVisualStyleBackColor = false;
			this.btn_stock_recive_jr.Click += new System.EventHandler(this.Btn_stock_recive_jrClick);
			// 
			// btn_jr_mov
			// 
			this.btn_jr_mov.BackColor = System.Drawing.Color.Silver;
			this.btn_jr_mov.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_jr_mov.Location = new System.Drawing.Point(22, 126);
			this.btn_jr_mov.Margin = new System.Windows.Forms.Padding(1);
			this.btn_jr_mov.Name = "btn_jr_mov";
			this.btn_jr_mov.Size = new System.Drawing.Size(231, 46);
			this.btn_jr_mov.TabIndex = 129;
			this.btn_jr_mov.Text = "AX JR Movement";
			this.btn_jr_mov.UseVisualStyleBackColor = false;
			this.btn_jr_mov.Click += new System.EventHandler(this.Btn_jr_movClick);
			// 
			// btn_jr_transfer
			// 
			this.btn_jr_transfer.BackColor = System.Drawing.Color.Silver;
			this.btn_jr_transfer.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_jr_transfer.Location = new System.Drawing.Point(22, 75);
			this.btn_jr_transfer.Margin = new System.Windows.Forms.Padding(1);
			this.btn_jr_transfer.Name = "btn_jr_transfer";
			this.btn_jr_transfer.Size = new System.Drawing.Size(231, 46);
			this.btn_jr_transfer.TabIndex = 128;
			this.btn_jr_transfer.Text = "AX JR Transfer";
			this.btn_jr_transfer.UseVisualStyleBackColor = false;
			this.btn_jr_transfer.Click += new System.EventHandler(this.Btn_whse_transfer_vmClick);
			// 
			// btn_bopp_transfer
			// 
			this.btn_bopp_transfer.BackColor = System.Drawing.Color.Silver;
			this.btn_bopp_transfer.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_bopp_transfer.Location = new System.Drawing.Point(22, 23);
			this.btn_bopp_transfer.Margin = new System.Windows.Forms.Padding(1);
			this.btn_bopp_transfer.Name = "btn_bopp_transfer";
			this.btn_bopp_transfer.Size = new System.Drawing.Size(231, 46);
			this.btn_bopp_transfer.TabIndex = 127;
			this.btn_bopp_transfer.Text = "AX BOPP Transfer";
			this.btn_bopp_transfer.UseVisualStyleBackColor = false;
			this.btn_bopp_transfer.Click += new System.EventHandler(this.Btn_ax_stock_transferClick);
			// 
			// btn_bopp_upload
			// 
			this.btn_bopp_upload.BackColor = System.Drawing.Color.Silver;
			this.btn_bopp_upload.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_bopp_upload.Location = new System.Drawing.Point(380, 472);
			this.btn_bopp_upload.Margin = new System.Windows.Forms.Padding(1);
			this.btn_bopp_upload.Name = "btn_bopp_upload";
			this.btn_bopp_upload.Size = new System.Drawing.Size(231, 46);
			this.btn_bopp_upload.TabIndex = 133;
			this.btn_bopp_upload.Text = "AX BOPP Upload";
			this.btn_bopp_upload.UseVisualStyleBackColor = false;
			this.btn_bopp_upload.Click += new System.EventHandler(this.Btn_bopp_uploadClick);
			// 
			// frm_menu_warehouse
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.CancelButton = this.btn_back;
			this.ClientSize = new System.Drawing.Size(984, 662);
			this.Controls.Add(this.btn_bopp_upload);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.grpbx_prod);
			this.Controls.Add(this.btn_stock_receive_fr_checklist);
			this.Controls.Add(this.grpbx_so);
			this.Controls.Add(this.grpbx_receive);
			this.Controls.Add(this.grpbox_order);
			this.Controls.Add(this.btn_back);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.lbl_header);
			this.Controls.Add(this.panel1);
			this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Name = "frm_menu_warehouse";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Converting";
			this.panel2.ResumeLayout(false);
			this.grpbox_order.ResumeLayout(false);
			this.grpbx_receive.ResumeLayout(false);
			this.grpbx_so.ResumeLayout(false);
			this.grpbx_prod.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.Button btn_bopp_upload;
		private System.Windows.Forms.Button btn_bopp_label;
		private System.Windows.Forms.Button btn_menu_wj303;
		private System.Windows.Forms.Button btn_stock_recive_jr;
		private System.Windows.Forms.Button btn_jr_mov;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Button btn_jr_transfer;
		private System.Windows.Forms.Button btn_bopp_transfer;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button btn_polocal;
		private System.Windows.Forms.Button btn_poimport;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Button btn_sample_request;
		private System.Windows.Forms.Button btn_converting;
		private System.Windows.Forms.GroupBox grpbx_prod;
		private System.Windows.Forms.Button btn_stock_receive_fr_checklist;
		private System.Windows.Forms.Button btn_get_so;
		private System.Windows.Forms.GroupBox grpbx_so;
		private System.Windows.Forms.Button btn_stock_receive_kliner;
		private System.Windows.Forms.Button btn_stock_receive_ribbon;
		private System.Windows.Forms.Button btn_stock_receive_film;
		private System.Windows.Forms.GroupBox grpbx_receive;
		private System.Windows.Forms.GroupBox grpbox_order;
		private System.Windows.Forms.Button btn_stock_receive_jr;
		private System.Windows.Forms.Button btn_stock_receive_fr;
		private System.Windows.Forms.Button btn_store_order;
		private System.Windows.Forms.Button btn_back;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Label lbl_username;
		private System.Windows.Forms.Button btn_warehouse_order;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label lbl_header;
	}
}
