/*
 * Created by SharpDevelop.
 * User: faeiz
 * Date: 2017-07-07
 * Time: 3:48 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;									
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Data;						
using System.Collections.Generic;		/***header untuk jalankan akktiviti/jenis coding dalam c#***/
using System.ComponentModel;			
using System.IO.Ports;
using System.Text;
using CommonFunction;
using CommonLibrary;
using CommonControl.Functions;
using System.Drawing.Drawing2D;
using System.Data.Sql;
using System.IO;
using fyiReporting.RdlViewer;
using fyiReporting;

namespace AX2020
{
	/// <summary>
	/// Description of frm_prod_coat_schwaner_bill_of_material.
	/// </summary>
	public partial class frm_prod_coat_schwaner_jo_memo : Form
	{
		public static string sqlconn = "Server=AX-UAT; Password=sbax2020sbg; User ID=sbax2020; Initial Catalog=SBG_AX_2020; Integrated Security=false";
		
		string username, sc_gluecode, sc_productcode, sc_colorcode, sc_linercode;
		double actual_thickness, coating_weight;
		public static string SetValueForText1 = "";
		
		public frm_prod_coat_schwaner_jo_memo()
		{
		 
			InitializeComponent();
			datagrid();
			this.ControlBox = false;
			btn_image.Enabled = false;
			txtbx_shipmark2.Enabled = false;
			username = frm_menu_system.userName; 
			lbl_username.Text = "User : " + username;
			
			
			
			//convert_image();
			//MemoryStream ms;
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		

		
		void Btn_imageClick(object sender, EventArgs e)
		{
		
			OpenFileDialog open = new OpenFileDialog();
     		// Fiter,used to Filter the image in the required filetype(s)  
     		//open.Filter = Image Files(*.jpg;*.jpeg;*.gif;*.bmp)|"*.jpg","*.jpeg","*.gif","*.bmp";
     
     
     
        	open.Filter ="Images (*.BMP;*.JPG;*.GIF,*.PNG,*.TIFF)|*.BMP;*.JPG;*.GIF;*.PNG;*.TIFF|" + "All files (*.*)|*.*";
        
    		if (open.ShowDialog() == DialogResult.OK)
    		 {
       			pictureBox1.Image = new Bitmap(open.FileName);
       			//txtPathdirectory.Text = open.FileName;
    		 }
			
		}
		
		void Btn_createClick(object sender, EventArgs e)
		{
			
			
		NextNumberShipMark();
		NextNumberJoSchwaner();
			SqlConnection con_data_add = new SqlConnection(sqlconn);
				System.Data.SqlClient.SqlCommand cmd_data_add = new SqlCommand();   //adress pergi ke sql
				try {
					
					

						cmd_data_add.Connection = con_data_add;	
						cmd_data_add.CommandText = "SP_PROD_COAT_SCHWANER_JOB_MEMO_ADD";
						cmd_data_add.CommandType = CommandType.StoredProcedure;						
							//coman run store procedure
							//nama store procedure
							//declare comand
						

						
						cmd_data_add.Parameters.Add(new SqlParameter("@SP_JO_SCHWANER", SqlDbType. NVarChar, 50)); //create parameter pada sql bwk data SP_RefNumber untuk dihantar semula
						cmd_data_add.Parameters["@SP_JO_SCHWANER"].Value = txtbx_jo.Text.ToUpper();
				
						cmd_data_add.Parameters.Add(new SqlParameter("@SP_PRODUCT_CODE", SqlDbType. NVarChar, 50)); //create parameter pada sql bwk data SP_RefNumber untuk dihantar semula
						cmd_data_add.Parameters["@SP_PRODUCT_CODE"].Value = txtbx_product_code.Text.ToUpper();//txtbx_refno.Text.ToUpper();
						
						cmd_data_add.Parameters.Add(new SqlParameter("@SP_TAPE_TYPE", SqlDbType.NVarChar, 50));
						cmd_data_add.Parameters["@SP_TAPE_TYPE"].Value = txtbx_tape_type.Text.ToUpper() ;
						
						cmd_data_add.Parameters.Add(new SqlParameter("@SP_GLUE_CODE ", SqlDbType.NVarChar, 50));
						cmd_data_add.Parameters["@SP_GLUE_CODE "].Value = txtbx_glue_code.Text.ToUpper();
						
    					cmd_data_add.Parameters.Add(new SqlParameter("@SP_EFF_WIDTH", SqlDbType.Float));
    					cmd_data_add.Parameters["@SP_EFF_WIDTH"].Value = Convert.ToDouble(txtbx_eff_width.Text);
						
						cmd_data_add.Parameters.Add(new SqlParameter("@SP_LINER_CODE", SqlDbType.NVarChar, 50));
						cmd_data_add.Parameters["@SP_LINER_CODE"].Value = txtbx_liner_code.Text.ToUpper();
						
						cmd_data_add.Parameters.Add(new SqlParameter("@SP_LC_WIDTH",SqlDbType.Float));
						cmd_data_add.Parameters["@SP_LC_WIDTH"].Value = Convert.ToDouble(txtbx_lc_width.Text);
						
						
						cmd_data_add.Parameters.Add(new SqlParameter("@SP_TAPE_THICKNESS", SqlDbType.Float)); //create parameter pada sql bwk data SP_RefNumber untuk dihantar semula
						cmd_data_add.Parameters["@SP_TAPE_THICKNESS"].Value = Convert.ToDouble(txtbx_tape_thickness.Text);
					
						
						cmd_data_add.Parameters.Add(new SqlParameter("@SP_COLOR", SqlDbType.NVarChar, 50));
						cmd_data_add.Parameters["@SP_COLOR"].Value = txtbx_color.Text.ToUpper();
						

  						
  						
						MemoryStream ms = new MemoryStream();
						pictureBox1.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
 						byte[] img = new byte[ms.Length];
 						//byte[] img = ms.ToArray();
  						ms.Position = 0;
  						ms.Read(img, 0, img.Length);
  						
  						
  						
//  						MemoryStream ms2 = new MemoryStream();
//						pictureBox1.Image.Save(ms2, System.Drawing.Imaging.ImageFormat.Jpeg);
// 						byte[] img2 = new byte[ms2.Length];
// 						//byte[] img = ms.ToArray();
//  						ms2.Position = 0;
//  						ms2.Read(img2, 0, img2.Length);
	
//  						if(img2 == new byte[ms2.Length])
//  						{
						cmd_data_add.Parameters.Add(new SqlParameter("@SP_PRODUCT_DESIGN", SqlDbType.Binary));
						cmd_data_add.Parameters["@SP_PRODUCT_DESIGN"].Value = img;
						
  						//}
  						
//  						else
//  						{
//  						cmd_data_add.Parameters.Add(new SqlParameter("@SP_PRODUCT_DESIGN", SqlDbType.Binary));
//						cmd_data_add.Parameters["@SP_PRODUCT_DESIGN"].Value = img;
//  						}
//						
						
						cmd_data_add.Parameters.Add(new SqlParameter("@SP_TOTAL_LENGTH_REQ", SqlDbType.Float));
						cmd_data_add.Parameters["@SP_TOTAL_LENGTH_REQ"].Value = Convert.ToDouble(txtbx_ttl_length_req.Text);
						
						cmd_data_add.Parameters.Add(new SqlParameter("@SP_TOTAL_M2", SqlDbType.Float));
						cmd_data_add.Parameters["@SP_TOTAL_M2"].Value = Convert.ToDouble(txtbx_ttl_m2.Text);
						
						cmd_data_add.Parameters.Add(new SqlParameter("@SP_TOTAL_GLUE_REQ_KG", SqlDbType.Float));
						cmd_data_add.Parameters["@SP_TOTAL_GLUE_REQ_KG"].Value = Convert.ToDouble(txtbx_glue_kg.Text);
						
						cmd_data_add.Parameters.Add(new SqlParameter("@SP_TOTAL_CROSSLINKER_REQ_KG", SqlDbType.Float));
						cmd_data_add.Parameters["@SP_TOTAL_CROSSLINKER_REQ_KG"].Value = Convert.ToDouble(txtbx_crosslinker_kg.Text);
						
						cmd_data_add.Parameters.Add(new SqlParameter("@SP_TOTAL_GLUE_REQ_DRUM", SqlDbType.Float));
						cmd_data_add.Parameters["@SP_TOTAL_GLUE_REQ_DRUM"].Value = Convert.ToDouble(txtbx_glue_drum.Text);
						
						cmd_data_add.Parameters.Add(new SqlParameter("@SP_CODE_CROSS_LINKER_REQ", SqlDbType.NVarChar, 50));
						cmd_data_add.Parameters["@SP_CODE_CROSS_LINKER_REQ"].Value = txtbx_code_crosslinker.Text.ToUpper();
						
						cmd_data_add.Parameters.Add(new SqlParameter("@SP_TOTAL_CROSS_LINKER_REQ_CAN", SqlDbType.Float));
						cmd_data_add.Parameters["@SP_TOTAL_CROSS_LINKER_REQ_CAN"].Value = Convert.ToDouble(txtbx_ttl_crosslinker.Text);
						
						cmd_data_add.Parameters.Add(new SqlParameter("@SP_SHIP_MARK_SCHWANER", SqlDbType.NVarChar, 30));
						cmd_data_add.Parameters["@SP_SHIP_MARK_SCHWANER"].Value = txtbx_shipmark1.Text.ToUpper() + txtbx_shipmark2.Text.ToUpper();
						
						cmd_data_add.Parameters.Add(new SqlParameter("@SP_DATE_ISSUED_MEMO", SqlDbType.DateTime));
						cmd_data_add.Parameters["@SP_DATE_ISSUED_MEMO"].Value = DateTime.Now;
						
						cmd_data_add.Parameters.Add(new SqlParameter("@SP_ISSUED_BY", SqlDbType.NVarChar, 50));
						cmd_data_add.Parameters["@SP_ISSUED_BY"].Value = username.ToUpper();
						
						cmd_data_add.Parameters.Add(new SqlParameter("@SP_JOUSEREMAIL", SqlDbType.NVarChar, 50));
						cmd_data_add.Parameters["@SP_JOUSEREMAIL"].Value = frm_menu_system.email;
						
						cmd_data_add.Parameters.Add(new SqlParameter("@SP_JOUSERPC", SqlDbType.NVarChar, 50));
						cmd_data_add.Parameters["@SP_JOUSERPC"].Value = frm_menu_system.ipAddress;
						
						cmd_data_add.Parameters.Add(new SqlParameter("@SP_JOUSERDATETIME", SqlDbType.DateTime));
						cmd_data_add.Parameters["@SP_JOUSERDATETIME"].Value = DateTime.Now;
						
						cmd_data_add.Parameters.Add(new SqlParameter("@SP_REMARK", SqlDbType.NVarChar, 50));
						cmd_data_add.Parameters["@SP_REMARK"].Value = txtbx_remark.Text.ToUpper();
						
						cmd_data_add.Parameters.Add(new SqlParameter("@SP_SHIP_MARK1", SqlDbType.NVarChar, 30));
						cmd_data_add.Parameters["@SP_SHIP_MARK1"].Value = txtbx_shipmark1.Text.ToUpper();
						
						cmd_data_add.Parameters.Add(new SqlParameter("@SP_SHIP_MARK2", SqlDbType.NVarChar, 30));
						cmd_data_add.Parameters["@SP_SHIP_MARK2"].Value = txtbx_shipmark2.Text.ToUpper();
						
						
						cmd_data_add.Parameters.Add(new SqlParameter("@SP_SOLID_CONTENT", SqlDbType.Float)); //create parameter pada sql bwk data SP_RefNumber untuk dihantar semula
						cmd_data_add.Parameters["@SP_SOLID_CONTENT"].Value = Convert.ToDouble(txtbx_sld_content.Text);
						
						cmd_data_add.Parameters.Add(new SqlParameter("@SP_COATING_THICKNESS", SqlDbType.Float)); //create parameter pada sql bwk data SP_RefNumber untuk dihantar semula
						cmd_data_add.Parameters["@SP_COATING_THICKNESS"].Value = Convert.ToDouble(txtbx_coat_thickness.Text);
						
						cmd_data_add.Parameters.Add(new SqlParameter("@SP_QTY_BASEGLUE_KG", SqlDbType.Float)); //create parameter pada sql bwk data SP_RefNumber untuk dihantar semula
						cmd_data_add.Parameters["@SP_QTY_BASEGLUE_KG"].Value = Convert.ToDouble(txtbx_qty_crosslinker.Text);
						
						cmd_data_add.Parameters.Add(new SqlParameter("@SP_QTY_CROSSLINKER_KG", SqlDbType.Float)); //create parameter pada sql bwk data SP_RefNumber untuk dihantar semula
						cmd_data_add.Parameters["@SP_QTY_CROSSLINKER_KG"].Value = Convert.ToDouble(txtbx_qty_baseglue.Text);
						
						
						cmd_data_add.Parameters.Add(new SqlParameter("@SP_STOCKCODE_GLUECODE", SqlDbType.NVarChar, 50));
						cmd_data_add.Parameters["@SP_STOCKCODE_GLUECODE"].Value = txtbx_scgc.Text.ToUpper() ;
						
						cmd_data_add.Parameters.Add(new SqlParameter("@SP_STOCKCODE_PRODUCTCODE", SqlDbType.NVarChar, 50));
						cmd_data_add.Parameters["@SP_STOCKCODE_PRODUCTCODE"].Value = txtbx_scpc.Text.ToUpper();
						
						cmd_data_add.Parameters.Add(new SqlParameter("@SP_STOCKCODE_COLORCODE", SqlDbType.NVarChar, 50));
						cmd_data_add.Parameters["@SP_STOCKCODE_COLORCODE"].Value = txtbx_sccc.Text.ToUpper();
						
						cmd_data_add.Parameters.Add(new SqlParameter("@SP_STOCKCODE_LINERCODE", SqlDbType.NVarChar, 50));
						cmd_data_add.Parameters["@SP_STOCKCODE_LINERCODE"].Value = txtbx_sclc.Text.ToUpper();
						
						
						con_data_add.Open();
						cmd_data_add.ExecuteNonQuery();
						//cmd_data_add.Parameters.Clear();
						
				} 
					
				
				catch (Exception ex) 
				{
						con_data_add.Close();
						MessageBox.Show("ERROR ? " + ex.Message + ex.ToString());
						return;
				} 
				finally 
				{
						con_data_add.Close();
				}
				
			con_data_add.Dispose();
			con_data_add = null;
			cmd_data_add = null;
			
			
			
			SqlConnection con_data_add2 = new SqlConnection(sqlconn);
			System.Data.SqlClient.SqlCommand cmd_data_add2 = new SqlCommand();  //adress pergi ke sql
			try 
			{

				cmd_data_add2.Connection = con_data_add2;		//coman run store procedure
				cmd_data_add2.CommandText = "SP_PROD_COAT_SCHWANER_JOB_MEMO_TEMP";	//nama store procedure
				cmd_data_add2.CommandType = CommandType.StoredProcedure;		//declare comand
    	
				cmd_data_add2.Parameters.Add(new SqlParameter("@SP_JO_SCHWANER", SqlDbType.NVarChar, 50)); //create parameter pada sql bwk data SP_RefNumber untuk dihantar semula
				cmd_data_add2.Parameters["@SP_JO_SCHWANER"].Value = txtbx_jo.Text.ToUpper();
				
						
				con_data_add2.Open();
				cmd_data_add2.ExecuteNonQuery();
			}
				
			catch (Exception ex) 
			{
				con_data_add2.Close();
				MessageBox.Show("ERROR ? " + ex.Message + ex.ToString());
				return;
			} 
			finally 
			{
				con_data_add2.Close();
			}
			con_data_add2.Dispose();
			con_data_add2 = null;
			cmd_data_add2 = null;
			
			
			
			MessageBox.Show("SUCCESFULL SAVE");

			datagrid();
			dataGridView1.Update();
			dataGridView1.Refresh();
			
			
			SetValueForText1 = txtbx_jo.Text; 
//			MessageBox.Show(SetValueForText1.ToString());
//   			SetValueForText2 = textBox2.Text;  
//   			SetValueForText3 = textBox3.Text;  
  
//		   	Form2 frm2 = new Form2();  
//		    frm2.Show();  
					
			 frm_prod_coat_schwaner_jo_memo_rpt f2 = new frm_prod_coat_schwaner_jo_memo_rpt();
             f2.Show();
             
//             if (string.IsNullOrWhiteSpace(txtbx_jo.Text))
//             {
//             	set
//             }
Clear_All_Textbox();

		}
	

		
		void Btn_cancelClick(object sender, EventArgs e)
		{
			this.Close();
		}
		
		
		
		void Btn_updateClick(object sender, EventArgs e)
		{
				SqlConnection con_data_add_update = new SqlConnection(sqlconn);
				System.Data.SqlClient.SqlCommand cmd_data_add_update = new SqlCommand();   //adress pergi ke sql
				try {
					
					

						cmd_data_add_update.Connection = con_data_add_update;	
						cmd_data_add_update.CommandText = "SP_PROD_COAT_SCHWANER_JOB_MEMO_EDIT";
						cmd_data_add_update.CommandType = CommandType.StoredProcedure;						


						cmd_data_add_update.Parameters.Add(new SqlParameter("@SP_JO_SCHWANER", SqlDbType. NVarChar, 50)); //create parameter pada sql bwk data SP_RefNumber untuk dihantar semula
						cmd_data_add_update.Parameters["@SP_JO_SCHWANER"].Value = txtbx_jo.Text.ToUpper();
				
						cmd_data_add_update.Parameters.Add(new SqlParameter("@SP_PRODUCT_CODE", SqlDbType. NVarChar, 50)); //create parameter pada sql bwk data SP_RefNumber untuk dihantar semula
						cmd_data_add_update.Parameters["@SP_PRODUCT_CODE"].Value = txtbx_product_code.Text.ToUpper();//txtbx_refno.Text.ToUpper();
						
						cmd_data_add_update.Parameters.Add(new SqlParameter("@SP_TAPE_TYPE", SqlDbType.NVarChar, 50));
						cmd_data_add_update.Parameters["@SP_TAPE_TYPE"].Value = txtbx_tape_type.Text.ToUpper() ;
						
						cmd_data_add_update.Parameters.Add(new SqlParameter("@SP_GLUE_CODE ", SqlDbType.NVarChar, 50));
						cmd_data_add_update.Parameters["@SP_GLUE_CODE "].Value = txtbx_glue_code.Text.ToUpper();
						
    					cmd_data_add_update.Parameters.Add(new SqlParameter("@SP_EFF_WIDTH", SqlDbType.Float));
    					cmd_data_add_update.Parameters["@SP_EFF_WIDTH"].Value = Convert.ToDouble(txtbx_eff_width.Text);
						
						cmd_data_add_update.Parameters.Add(new SqlParameter("@SP_LINER_CODE", SqlDbType.NVarChar, 50));
						cmd_data_add_update.Parameters["@SP_LINER_CODE"].Value = txtbx_liner_code.Text.ToUpper();
						
						cmd_data_add_update.Parameters.Add(new SqlParameter("@SP_LC_WIDTH",SqlDbType.Float));
						cmd_data_add_update.Parameters["@SP_LC_WIDTH"].Value = Convert.ToDouble(txtbx_lc_width.Text);
						
						
						cmd_data_add_update.Parameters.Add(new SqlParameter("@SP_TAPE_THICKNESS", SqlDbType.Float)); //create parameter pada sql bwk data SP_RefNumber untuk dihantar semula
						cmd_data_add_update.Parameters["@SP_TAPE_THICKNESS"].Value = Convert.ToDouble(txtbx_tape_thickness.Text);
					
						
						cmd_data_add_update.Parameters.Add(new SqlParameter("@SP_COLOR", SqlDbType.NVarChar, 50));
						cmd_data_add_update.Parameters["@SP_COLOR"].Value = txtbx_color.Text.ToUpper();
						
						MemoryStream ms = new MemoryStream();
						pictureBox1.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
 						byte[] img = new byte[ms.Length];
 						//byte[] img = ms.ToArray();
  						ms.Position = 0;
						ms.Read(img, 0, img.Length);
						
//  						MemoryStream ms2 = new MemoryStream();
//						pictureBox1.Image.Save(ms2, System.Drawing.Imaging.ImageFormat.Jpeg);
// 						byte[] img2 = new byte[ms2.Length];
// 						//byte[] img = ms.ToArray();
//  						ms2.Position = 0;
//  						ms2.Read(img2, 0, img2.Length);
	
//  						if(img2 == new byte[ms2.Length])
//  						{
//						cmd_data_add_update.Parameters.Add(new SqlParameter("@SP_PRODUCT_DESIGN", SqlDbType.Binary));
//						cmd_data_add_update.Parameters["@SP_PRODUCT_DESIGN"].Value = img2;
//						
//  						}
  						
//  						else
//  						{
  						cmd_data_add_update.Parameters.Add(new SqlParameter("@SP_PRODUCT_DESIGN", SqlDbType.Binary));
						cmd_data_add_update.Parameters["@SP_PRODUCT_DESIGN"].Value = img;
//  						}
						
						
						cmd_data_add_update.Parameters.Add(new SqlParameter("@SP_TOTAL_LENGTH_REQ", SqlDbType.Float));
						cmd_data_add_update.Parameters["@SP_TOTAL_LENGTH_REQ"].Value = Convert.ToDouble(txtbx_ttl_length_req.Text);
						
						cmd_data_add_update.Parameters.Add(new SqlParameter("@SP_TOTAL_M2", SqlDbType.Float));
						cmd_data_add_update.Parameters["@SP_TOTAL_M2"].Value = Convert.ToDouble(txtbx_ttl_m2.Text);
						
						cmd_data_add_update.Parameters.Add(new SqlParameter("@SP_TOTAL_GLUE_REQ_KG", SqlDbType.Float));
						cmd_data_add_update.Parameters["@SP_TOTAL_GLUE_REQ_KG"].Value = Convert.ToDouble(txtbx_glue_kg.Text);
						
						cmd_data_add_update.Parameters.Add(new SqlParameter("@SP_TOTAL_CROSSLINKER_REQ_KG", SqlDbType.Float));
						cmd_data_add_update.Parameters["@SP_TOTAL_CROSSLINKER_REQ_KG"].Value = Convert.ToDouble(txtbx_crosslinker_kg.Text);
						
						cmd_data_add_update.Parameters.Add(new SqlParameter("@SP_TOTAL_GLUE_REQ_DRUM", SqlDbType.Float));
						cmd_data_add_update.Parameters["@SP_TOTAL_GLUE_REQ_DRUM"].Value = Convert.ToDouble(txtbx_glue_drum.Text);
						
						cmd_data_add_update.Parameters.Add(new SqlParameter("@SP_CODE_CROSS_LINKER_REQ", SqlDbType.NVarChar, 50));
						cmd_data_add_update.Parameters["@SP_CODE_CROSS_LINKER_REQ"].Value = txtbx_code_crosslinker.Text.ToUpper();
						
						cmd_data_add_update.Parameters.Add(new SqlParameter("@SP_TOTAL_CROSS_LINKER_REQ_CAN", SqlDbType.Float));
						cmd_data_add_update.Parameters["@SP_TOTAL_CROSS_LINKER_REQ_CAN"].Value = Convert.ToDouble(txtbx_ttl_crosslinker.Text);
						
						cmd_data_add_update.Parameters.Add(new SqlParameter("@SP_SHIP_MARK_SCHWANER", SqlDbType.NVarChar, 30));
						cmd_data_add_update.Parameters["@SP_SHIP_MARK_SCHWANER"].Value = txtbx_shipmark1.Text.ToUpper() + txtbx_shipmark2.Text.ToUpper();
						
						cmd_data_add_update.Parameters.Add(new SqlParameter("@SP_DATE_ISSUED_MEMO", SqlDbType.DateTime));
						cmd_data_add_update.Parameters["@SP_DATE_ISSUED_MEMO"].Value = DateTime.Now;
						
						cmd_data_add_update.Parameters.Add(new SqlParameter("@SP_ISSUED_BY", SqlDbType.NVarChar, 50));
						cmd_data_add_update.Parameters["@SP_ISSUED_BY"].Value = username.ToUpper();
						
						cmd_data_add_update.Parameters.Add(new SqlParameter("@SP_JOUSEREMAIL", SqlDbType.NVarChar, 50));
						cmd_data_add_update.Parameters["@SP_JOUSEREMAIL"].Value = frm_menu_system.email;
						
						cmd_data_add_update.Parameters.Add(new SqlParameter("@SP_JOUSERPC", SqlDbType.NVarChar, 50));
						cmd_data_add_update.Parameters["@SP_JOUSERPC"].Value = frm_menu_system.ipAddress;
						
						cmd_data_add_update.Parameters.Add(new SqlParameter("@SP_JOUSERDATETIME", SqlDbType.DateTime));
						cmd_data_add_update.Parameters["@SP_JOUSERDATETIME"].Value = DateTime.Now;
						
						cmd_data_add_update.Parameters.Add(new SqlParameter("@SP_REMARK", SqlDbType.NVarChar, 50));
						cmd_data_add_update.Parameters["@SP_REMARK"].Value = txtbx_remark.Text.ToUpper();
						
						
						cmd_data_add_update.Parameters.Add(new SqlParameter("@SP_SHIP_MARK1", SqlDbType.NVarChar, 30));
						cmd_data_add_update.Parameters["@SP_SHIP_MARK1"].Value = txtbx_shipmark1.Text.ToUpper();
						
						cmd_data_add_update.Parameters.Add(new SqlParameter("@SP_SHIP_MARK2", SqlDbType.NVarChar, 30));
						cmd_data_add_update.Parameters["@SP_SHIP_MARK2"].Value = txtbx_shipmark2.Text.ToUpper();
						
						
						cmd_data_add_update.Parameters.Add(new SqlParameter("@SP_SOLID_CONTENT", SqlDbType.Float)); //create parameter pada sql bwk data SP_RefNumber untuk dihantar semula
						cmd_data_add_update.Parameters["@SP_SOLID_CONTENT"].Value = Convert.ToDouble(txtbx_sld_content.Text);
						
						cmd_data_add_update.Parameters.Add(new SqlParameter("@SP_COATING_THICKNESS", SqlDbType.Float)); //create parameter pada sql bwk data SP_RefNumber untuk dihantar semula
						cmd_data_add_update.Parameters["@SP_COATING_THICKNESS"].Value = Convert.ToDouble(txtbx_coat_thickness.Text);
						
						cmd_data_add_update.Parameters.Add(new SqlParameter("@SP_QTY_BASEGLUE_KG", SqlDbType.Float)); //create parameter pada sql bwk data SP_RefNumber untuk dihantar semula
						cmd_data_add_update.Parameters["@SP_QTY_BASEGLUE_KG"].Value = Convert.ToDouble(txtbx_qty_crosslinker.Text);
						
						cmd_data_add_update.Parameters.Add(new SqlParameter("@SP_QTY_CROSSLINKER_KG", SqlDbType.Float)); //create parameter pada sql bwk data SP_RefNumber untuk dihantar semula
						cmd_data_add_update.Parameters["@SP_QTY_CROSSLINKER_KG"].Value = Convert.ToDouble(txtbx_qty_baseglue.Text);
						
						
						cmd_data_add_update.Parameters.Add(new SqlParameter("@SP_STOCKCODE_GLUECODE", SqlDbType.NVarChar, 50));
						cmd_data_add_update.Parameters["@SP_STOCKCODE_GLUECODE"].Value = txtbx_scgc.Text.ToUpper() ;
						
						cmd_data_add_update.Parameters.Add(new SqlParameter("@SP_STOCKCODE_PRODUCTCODE", SqlDbType.NVarChar, 50));
						cmd_data_add_update.Parameters["@SP_STOCKCODE_PRODUCTCODE"].Value = txtbx_scpc.Text.ToUpper() ;
						
						cmd_data_add_update.Parameters.Add(new SqlParameter("@SP_STOCKCODE_COLORCODE", SqlDbType.NVarChar, 50));
						cmd_data_add_update.Parameters["@SP_STOCKCODE_COLORCODE"].Value = txtbx_sccc.Text.ToUpper() ;
						
						cmd_data_add_update.Parameters.Add(new SqlParameter("@SP_STOCKCODE_LINERCODE", SqlDbType.NVarChar, 50));
						cmd_data_add_update.Parameters["@SP_STOCKCODE_LINERCODE"].Value = txtbx_sclc.Text.ToUpper() ;
						
						
						con_data_add_update.Open();
						cmd_data_add_update.ExecuteNonQuery();
						//cmd_data_add_update.Parameters.Clear();
						
				} 
					
				
				catch (Exception ex) 
				{
						con_data_add_update.Close();
						MessageBox.Show("ERROR ? " + ex.Message + ex.ToString());
						return;
				} 
				finally 
				{
						con_data_add_update.Close();
				}
			con_data_add_update.Dispose();
			con_data_add_update = null;
			cmd_data_add_update = null;
			
			datagrid();
			dataGridView1.Update();
			dataGridView1.Refresh();
			
			
			
			SqlConnection con_data_add2 = new SqlConnection(sqlconn);
			System.Data.SqlClient.SqlCommand cmd_data_add2 = new SqlCommand();  //adress pergi ke sql
			try 
			{

				cmd_data_add2.Connection = con_data_add2;		//coman run store procedure
				cmd_data_add2.CommandText = "SP_PROD_COAT_SCHWANER_JOB_MEMO_TEMP";	//nama store procedure
				cmd_data_add2.CommandType = CommandType.StoredProcedure;		//declare comand
    	
				cmd_data_add2.Parameters.Add(new SqlParameter("@SP_JO_SCHWANER", SqlDbType.NVarChar, 50)); //create parameter pada sql bwk data SP_RefNumber untuk dihantar semula
				cmd_data_add2.Parameters["@SP_JO_SCHWANER"].Value = txtbx_jo.Text.ToUpper();
						
						
				con_data_add2.Open();
				cmd_data_add2.ExecuteNonQuery();
			}
				
			catch (Exception ex) 
			{
				con_data_add2.Close();
				MessageBox.Show("ERROR ? " + ex.Message + ex.ToString());
				return;
			} 
			finally 
			{
				con_data_add2.Close();
			}
			con_data_add2.Dispose();
			con_data_add2 = null;
			cmd_data_add2 = null;
			
			
			
			MessageBox.Show("SUCCESFULL UPDATE AND SAVE");
			
//			datagrid();
//			dataGridView1.Update();
//			dataGridView1.Refresh();
			Clear_All_Textbox();
			
		
		}
		
		void Btn_clearClick(object sender, EventArgs e)
		{
			Clear_All_Textbox();			
		}
		
		
		void Clear_All_Textbox()
		{
			foreach (Control x in this.Controls)
			{
	  			 if (x is TextBox)
	 			 {
	  			 ((TextBox)x).Text = String.Empty;
	  			 }
	  			 
	  			 if (pictureBox1.Image != null)
       			 {
            		pictureBox1.Image.Dispose();
            		pictureBox1.Image = null;
        		 }
	  			 
			}	
		}
		
		
		
//				public void PassValue(string strValue)
//			    {
//					strValue = 	txtbx_jo.Text.ToUpper();
//			    }
//    
    
    

		
		
		
		void Btn_deleteClick(object sender, EventArgs e)
		{
			SqlConnection con_data_del = new SqlConnection(sqlconn);
				System.Data.SqlClient.SqlCommand cmd_data_del = new SqlCommand();   //adress pergi ke sql
				try {
					
					

						cmd_data_del.Connection = con_data_del;	
						cmd_data_del.CommandText = "SP_PROD_COAT_SCHWANER_JOB_MEMO_DEL";
						cmd_data_del.CommandType = CommandType.StoredProcedure;						
							//coman run store procedure
							//nama store procedure
							//declare comand
						

						cmd_data_del.Parameters.Add(new SqlParameter("@SP_JO_SCHWANER", SqlDbType. NVarChar, 50)); //create parameter pada sql bwk data SP_RefNumber untuk dihantar semula
						cmd_data_del.Parameters["@SP_JO_SCHWANER"].Value = txtbx_jo.Text.ToUpper();
				
						cmd_data_del.Parameters.Add(new SqlParameter("@SP_PRODUCT_CODE", SqlDbType. NVarChar, 50)); //create parameter pada sql bwk data SP_RefNumber untuk dihantar semula
						cmd_data_del.Parameters["@SP_PRODUCT_CODE"].Value = txtbx_product_code.Text.ToUpper();//txtbx_refno.Text.ToUpper();
						
						cmd_data_del.Parameters.Add(new SqlParameter("@SP_TAPE_TYPE", SqlDbType.NVarChar, 50));
						cmd_data_del.Parameters["@SP_TAPE_TYPE"].Value = txtbx_tape_type.Text.ToUpper() ;
						
						cmd_data_del.Parameters.Add(new SqlParameter("@SP_GLUE_CODE ", SqlDbType.NVarChar, 50));
						cmd_data_del.Parameters["@SP_GLUE_CODE "].Value = txtbx_glue_code.Text.ToUpper();
						
    					cmd_data_del.Parameters.Add(new SqlParameter("@SP_EFF_WIDTH", SqlDbType.Float));
    					cmd_data_del.Parameters["@SP_EFF_WIDTH"].Value = Convert.ToDouble(txtbx_eff_width.Text);
						
						cmd_data_del.Parameters.Add(new SqlParameter("@SP_LINER_CODE", SqlDbType.NVarChar, 50));
						cmd_data_del.Parameters["@SP_LINER_CODE"].Value = txtbx_liner_code.Text.ToUpper();
						
						cmd_data_del.Parameters.Add(new SqlParameter("@SP_LC_WIDTH",SqlDbType.Float));
						cmd_data_del.Parameters["@SP_LC_WIDTH"].Value = Convert.ToDouble(txtbx_lc_width.Text);
						
						
						cmd_data_del.Parameters.Add(new SqlParameter("@SP_TAPE_THICKNESS", SqlDbType.Float)); //create parameter pada sql bwk data SP_RefNumber untuk dihantar semula
						cmd_data_del.Parameters["@SP_TAPE_THICKNESS"].Value = Convert.ToDouble(txtbx_tape_thickness.Text);
					
						
						cmd_data_del.Parameters.Add(new SqlParameter("@SP_COLOR", SqlDbType.NVarChar, 50));
						cmd_data_del.Parameters["@SP_COLOR"].Value = txtbx_color.Text.ToUpper();
						
						MemoryStream ms = new MemoryStream();
						pictureBox1.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
 						byte[] img = new byte[ms.Length];
 						//byte[] img = ms.ToArray();
  						ms.Position = 0;
  						ms.Read(img, 0, img.Length);
  						
  						
  						
//  						MemoryStream ms2 = new MemoryStream();
//						pictureBox1.Image.Save(ms2, System.Drawing.Imaging.ImageFormat.Jpeg);
// 						byte[] img2 = new byte[ms2.Length];
// 						//byte[] img = ms.ToArray();
//  						ms2.Position = 0;
//  						ms2.Read(img2, 0, img2.Length);
//	
//  						if(img2 == new byte[ms2.Length])
//  						{
//						cmd_data_del.Parameters.Add(new SqlParameter("@SP_PRODUCT_DESIGN", SqlDbType.Binary));
//						cmd_data_del.Parameters["@SP_PRODUCT_DESIGN"].Value = img2;
//						
//  						}
  						
//  						else
//  						{
  						cmd_data_del.Parameters.Add(new SqlParameter("@SP_PRODUCT_DESIGN", SqlDbType.Binary));
						cmd_data_del.Parameters["@SP_PRODUCT_DESIGN"].Value = img;
//  						}
						
						
						cmd_data_del.Parameters.Add(new SqlParameter("@SP_TOTAL_LENGTH_REQ", SqlDbType.Float));
						cmd_data_del.Parameters["@SP_TOTAL_LENGTH_REQ"].Value = Convert.ToDouble(txtbx_ttl_length_req.Text);
						
						cmd_data_del.Parameters.Add(new SqlParameter("@SP_TOTAL_M2", SqlDbType.Float));
						cmd_data_del.Parameters["@SP_TOTAL_M2"].Value = Convert.ToDouble(txtbx_ttl_m2.Text);
						
						cmd_data_del.Parameters.Add(new SqlParameter("@SP_TOTAL_GLUE_REQ_KG", SqlDbType.Float));
						cmd_data_del.Parameters["@SP_TOTAL_GLUE_REQ_KG"].Value = Convert.ToDouble(txtbx_glue_kg.Text);
						
						cmd_data_del.Parameters.Add(new SqlParameter("@SP_TOTAL_CROSSLINKER_REQ_KG", SqlDbType.Float));
						cmd_data_del.Parameters["@SP_TOTAL_CROSSLINKER_REQ_KG"].Value = Convert.ToDouble(txtbx_crosslinker_kg.Text);
						
						cmd_data_del.Parameters.Add(new SqlParameter("@SP_TOTAL_GLUE_REQ_DRUM", SqlDbType.Float));
						cmd_data_del.Parameters["@SP_TOTAL_GLUE_REQ_DRUM"].Value = Convert.ToDouble(txtbx_glue_drum.Text);
						
						cmd_data_del.Parameters.Add(new SqlParameter("@SP_CODE_CROSS_LINKER_REQ", SqlDbType.NVarChar, 50));
						cmd_data_del.Parameters["@SP_CODE_CROSS_LINKER_REQ"].Value = txtbx_code_crosslinker.Text.ToUpper();
						
						cmd_data_del.Parameters.Add(new SqlParameter("@SP_TOTAL_CROSS_LINKER_REQ_CAN", SqlDbType.Float));
						cmd_data_del.Parameters["@SP_TOTAL_CROSS_LINKER_REQ_CAN"].Value = Convert.ToDouble(txtbx_ttl_crosslinker.Text);
						
						cmd_data_del.Parameters.Add(new SqlParameter("@SP_SHIP_MARK_SCHWANER", SqlDbType.NVarChar, 30));
						cmd_data_del.Parameters["@SP_SHIP_MARK_SCHWANER"].Value = txtbx_shipmark1.Text.ToUpper() + txtbx_shipmark2.Text.ToUpper();
						
						cmd_data_del.Parameters.Add(new SqlParameter("@SP_DATE_ISSUED_MEMO", SqlDbType.DateTime));
						cmd_data_del.Parameters["@SP_DATE_ISSUED_MEMO"].Value = DateTime.Now;
						
						cmd_data_del.Parameters.Add(new SqlParameter("@SP_ISSUED_BY", SqlDbType.NVarChar, 50));
						cmd_data_del.Parameters["@SP_ISSUED_BY"].Value = username.ToUpper();
						
						cmd_data_del.Parameters.Add(new SqlParameter("@SP_JOUSEREMAIL", SqlDbType.NVarChar, 50));
						cmd_data_del.Parameters["@SP_JOUSEREMAIL"].Value = frm_menu_system.email;
						
						cmd_data_del.Parameters.Add(new SqlParameter("@SP_JOUSERPC", SqlDbType.NVarChar, 50));
						cmd_data_del.Parameters["@SP_JOUSERPC"].Value = frm_menu_system.ipAddress;
						
						cmd_data_del.Parameters.Add(new SqlParameter("@SP_JOUSERDATETIME", SqlDbType.DateTime));
						cmd_data_del.Parameters["@SP_JOUSERDATETIME"].Value = DateTime.Now;
						
						cmd_data_del.Parameters.Add(new SqlParameter("@SP_REMARK", SqlDbType.NVarChar, 50));
						cmd_data_del.Parameters["@SP_REMARK"].Value = txtbx_remark.Text.ToUpper();
						
						cmd_data_del.Parameters.Add(new SqlParameter("@SP_SHIP_MARK1", SqlDbType.NVarChar, 30));
						cmd_data_del.Parameters["@SP_SHIP_MARK1"].Value = txtbx_shipmark1.Text.ToUpper();
						
						cmd_data_del.Parameters.Add(new SqlParameter("@SP_SHIP_MARK2", SqlDbType.NVarChar, 30));
						cmd_data_del.Parameters["@SP_SHIP_MARK2"].Value = txtbx_shipmark2.Text.ToUpper();
						
						cmd_data_del.Parameters.Add(new SqlParameter("@SP_SOLID_CONTENT", SqlDbType.Float)); //create parameter pada sql bwk data SP_RefNumber untuk dihantar semula
						cmd_data_del.Parameters["@SP_SOLID_CONTENT"].Value = Convert.ToDouble(txtbx_sld_content.Text);
						
						cmd_data_del.Parameters.Add(new SqlParameter("@SP_COATING_THICKNESS", SqlDbType.Float)); //create parameter pada sql bwk data SP_RefNumber untuk dihantar semula
						cmd_data_del.Parameters["@SP_COATING_THICKNESS"].Value = Convert.ToDouble(txtbx_coat_thickness.Text);
						
						cmd_data_del.Parameters.Add(new SqlParameter("@SP_QTY_BASEGLUE_KG", SqlDbType.Float)); //create parameter pada sql bwk data SP_RefNumber untuk dihantar semula
						cmd_data_del.Parameters["@SP_QTY_BASEGLUE_KG"].Value = Convert.ToDouble(txtbx_qty_crosslinker.Text);
						
						cmd_data_del.Parameters.Add(new SqlParameter("@SP_QTY_CROSSLINKER_KG", SqlDbType.Float)); //create parameter pada sql bwk data SP_RefNumber untuk dihantar semula
						cmd_data_del.Parameters["@SP_QTY_CROSSLINKER_KG"].Value = Convert.ToDouble(txtbx_qty_baseglue.Text);
						
						
						cmd_data_del.Parameters.Add(new SqlParameter("@SP_STOCKCODE_GLUECODE", SqlDbType.NVarChar, 50));
						cmd_data_del.Parameters["@SP_STOCKCODE_GLUECODE"].Value = "";
						
						cmd_data_del.Parameters.Add(new SqlParameter("@SP_STOCKCODE_PRODUCTCODE", SqlDbType.NVarChar, 50));
						cmd_data_del.Parameters["@SP_STOCKCODE_PRODUCTCODE"].Value = "" ;
						
						cmd_data_del.Parameters.Add(new SqlParameter("@SP_STOCKCODE_COLORCODE", SqlDbType.NVarChar, 50));
						cmd_data_del.Parameters["@SP_STOCKCODE_COLORCODE"].Value = "";
						
						cmd_data_del.Parameters.Add(new SqlParameter("@SP_STOCKCODE_LINERCODE", SqlDbType.NVarChar, 50));
						cmd_data_del.Parameters["@SP_STOCKCODE_LINERCODE"].Value = "";
						
						
						
						con_data_del.Open();
						cmd_data_del.ExecuteNonQuery();
						//cmd_data_del.Parameters.Clear();
						
				} 
					
				
				catch (Exception ex) 
				{
						con_data_del.Close();
						MessageBox.Show("ERROR ? " + ex.Message + ex.ToString());
						return;
				} 
				finally 
				{
						con_data_del.Close();
				}
			con_data_del.Dispose();
			con_data_del = null;
			cmd_data_del = null;
			
			
			
			MessageBox.Show("SUCCESFULL DELETE");
			
			datagrid();			
			dataGridView1.Update();
			dataGridView1.Refresh();
			Clear_All_Textbox();
		}
		
		
		
		void Btn_retrieveClick(object sender, EventArgs e)
		{
			if (txtbx_product_code.Text == null | txtbx_product_code.Text == string.Empty) 
			{
        		MessageBox.Show("Please key-in Ref No");
				return;
			}
			
			
			
			SqlConnection con_SP1 = new SqlConnection(sqlconn);
			SqlCommand cmd_SP1 = new SqlCommand();
			
			try 
			{
				cmd_SP1.CommandText = "select * from TBL_PROD_COAT_SCHWANER_JOB_MEMO_DEFAULT where PRODUCT_CODE = '" + txtbx_product_code.Text + "'";
				cmd_SP1.Connection = con_SP1;
				con_SP1.Open();
				SqlDataReader rd_SP1 = cmd_SP1.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
				
				if (rd_SP1.Read())
				{
				
					
					
						txtbx_product_code.Text = rd_SP1["PRODUCT_CODE"].ToString();
						txtbx_tape_type.Text = rd_SP1["TAPE_TYPE"].ToString();
						txtbx_eff_width.Text = rd_SP1["EFF_WIDTH"].ToString();
						txtbx_liner_code.Text = rd_SP1["LINER_CODE"].ToString(); 
						txtbx_glue_code.Text = rd_SP1["GLUE_CODE"].ToString();
						txtbx_lc_width.Text = rd_SP1["LC_WIDTH"].ToString();
						txtbx_tape_thickness.Text = rd_SP1["TAPE_THICKNESS"].ToString();
						txtbx_color.Text = rd_SP1["COLOR"].ToString();
						
//						MemoryStream ms = new MemoryStream((byte[])dataGridView1.CurrentRow.Cells[8].Value);
// 				  		pictureBox1.Image = Image.FromStream(ms);

						MemoryStream ms = new MemoryStream();
						//pictureBox1.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
 						//byte[] img = new byte[ms.Length];
 						byte[] img = ms.ToArray();
  						ms.Position = 0;
  						ms.Read(img, 0, img.Length);

						ms = new MemoryStream((byte[])rd_SP1["PRODUCT_DESIGN"]);
 				   		pictureBox1.Image = Image.FromStream(ms);
 				   		
 				   		
 				   		txtbx_scgc.Text = rd_SP1["STOCKCODE_GLUECODE"].ToString();
						txtbx_scpc.Text = rd_SP1["STOCKCODE_PRODUCTCODE"].ToString();
						txtbx_sccc.Text = rd_SP1["STOCKCODE_COLORCODE"].ToString();
						txtbx_sclc.Text = rd_SP1["STOCKCODE_LINERCODE"].ToString();
 				   		
 				   		
 				   		
 				   		
						


						
					
					
				
					
//--------------------------------------------------------------------------------------------			
				} 
				else 
				{
					MessageBox.Show("Error Edit : Cannot find JO!");
					return;
				}
			} 
			catch (Exception ex) 
			{
				MessageBox.Show("Error Edit : Cannot load DB!" + ex.Message + ex.ToString());
				return;
			} 
			finally 
			{
				con_SP1.Close();
			}
			
			con_SP1.Dispose();
			con_SP1 = null;
			cmd_SP1 = null;	
			
		}
		
		
		
		void NextNumberJoSchwaner()
		{
			int NextNo ;
			
						NextNo = 0;
//************************************************************************************************************************
						SqlConnection conNextNumber = new SqlConnection(sqlconn);
						SqlCommand cmdNextNumber = new SqlCommand();
						try {
							cmdNextNumber.CommandText = "Select * from TBL_ADMIN_NEXT_NUMBER";
							cmdNextNumber.Connection = conNextNumber;
							conNextNumber.Open();
							SqlDataReader rdNextNumber = cmdNextNumber.ExecuteReader(System.Data.CommandBehavior.CloseConnection); //UNTUK BACA DATA DALAM TABLE
							rdNextNumber.Read();
							NextNo = Convert.ToInt32(rdNextNumber["ProdSchwanerNextNumber"].ToString());
							
						} 
						
						
						catch (Exception ex) 
						
						{
							MessageBox.Show("ERROR NEXT NUMBER!" + ex.ToString() + ex.Message);
							NextNo = 0;
							return;
							
						} 
						
						finally
						{
							conNextNumber.Close();
						}
						conNextNumber.Dispose();
						conNextNumber = null;
						cmdNextNumber = null;
						//************************************************************************************************************************
						if (NextNo >= 9999) 
						{
							NextNo = 1000;
							SqlConnection conUpdateNextNumberZero = new SqlConnection(sqlconn);
							System.Data.SqlClient.SqlCommand cmdUpdateNextNumberZero = new SqlCommand();
							try {
								cmdUpdateNextNumberZero.CommandText = "update TBL_ADMIN_NEXT_NUMBER set JoCoatNextNumber = 1000";
								cmdUpdateNextNumberZero.Connection = conUpdateNextNumberZero;
								conUpdateNextNumberZero.Open();
								cmdUpdateNextNumberZero.ExecuteNonQuery();
								} 
							
							catch (Exception ex) 
							{
								conUpdateNextNumberZero.Close();
								MessageBox.Show("Error Updates Next Number" + ex.ToString() + ex.Message);
								return;
							}
							
							finally
							{
								conUpdateNextNumberZero.Close();
							}
							
							
							
							conUpdateNextNumberZero.Dispose();
							conUpdateNextNumberZero = null;
							cmdUpdateNextNumberZero = null;
						}
						//************************************************************************************************************************
						//************************************************************************************************************************
						DateTime JODSDate = DateTime.Now;
						
						string JODSDateString = null;
						//JODSDate = null;
						JODSDateString = null;
						//JODSDate = System.DateTime.Now;
						JODSDateString = (JODSDate.ToString("yy")) + (JODSDate.ToString("MM"));
						string SDate;
						
			
						//************************************************************************************************************************
						//SDate = "JB" & NextNo
						
							SDate = "SC" + NextNo + JODSDateString ;
						
						
						txtbx_jo.Text = SDate;
						
						//************************************************************************************************************************
						//************************************************************************************************************************
						//---  Update next number
						SqlConnection conUpdateNextNumber = new SqlConnection(sqlconn);
						System.Data.SqlClient.SqlCommand cmdUpdateNextNumber = new SqlCommand();
						try {
							cmdUpdateNextNumber.CommandText = "update TBL_ADMIN_NEXT_NUMBER set ProdSchwanerNextNumber = ProdSchwanerNextNumber + 1";
							cmdUpdateNextNumber.Connection = conUpdateNextNumber;
							conUpdateNextNumber.Open();
							cmdUpdateNextNumber.ExecuteNonQuery();
						}
						catch (Exception ex)
						{
							conUpdateNextNumber.Close();
							MessageBox.Show("Error Update Next Number!" + ex.ToString() + ex.Message); 
							return;
						}
						finally 
						{
							conUpdateNextNumber.Close();
						}
						conUpdateNextNumber.Dispose();
						conUpdateNextNumber = null;
						cmdUpdateNextNumber = null;
						
						//MessageBox.Show(NextNo.ToString());
		}
		
		
		
		void NextNumberShipMark()
		{
			int NextNo ;
			
						NextNo = 0;
//************************************************************************************************************************
						SqlConnection conNextNumber = new SqlConnection(sqlconn);
						SqlCommand cmdNextNumber = new SqlCommand();
						try {
							cmdNextNumber.CommandText = "Select * from TBL_ADMIN_NEXT_NUMBER";
							cmdNextNumber.Connection = conNextNumber;
							conNextNumber.Open();
							SqlDataReader rdNextNumber = cmdNextNumber.ExecuteReader(System.Data.CommandBehavior.CloseConnection); //UNTUK BACA DATA DALAM TABLE
							rdNextNumber.Read();
							NextNo = Convert.ToInt32(rdNextNumber["ProdSchwanerShipMarkNextNumber"].ToString());
							
						} 
						
						
						catch (Exception ex) 
						
						{
							MessageBox.Show("ERROR NEXT NUMBER!" + ex.ToString() + ex.Message);
							NextNo = 0;
							return;
							
						} 
						
						finally
						{
							conNextNumber.Close();
						}
						conNextNumber.Dispose();
						conNextNumber = null;
						cmdNextNumber = null;
						//************************************************************************************************************************
						if (NextNo >= 100) 
						{
							NextNo = 1;
							SqlConnection conUpdateNextNumberZero = new SqlConnection(sqlconn);
							System.Data.SqlClient.SqlCommand cmdUpdateNextNumberZero = new SqlCommand();
							try {
								cmdUpdateNextNumberZero.CommandText = "update TBL_ADMIN_NEXT_NUMBER set ProdSchwanerShipMarkNextNumber = 1";
								cmdUpdateNextNumberZero.Connection = conUpdateNextNumberZero;
								conUpdateNextNumberZero.Open();
								cmdUpdateNextNumberZero.ExecuteNonQuery();
								} 
							
							catch (Exception ex) 
							{
								conUpdateNextNumberZero.Close();
								MessageBox.Show("Error Updates Next Number" + ex.ToString() + ex.Message);
								return;
							}
							
							finally
							{
								conUpdateNextNumberZero.Close();
							}
							
							
							
							conUpdateNextNumberZero.Dispose();
							conUpdateNextNumberZero = null;
							cmdUpdateNextNumberZero = null;
						}
						//************************************************************************************************************************
						//************************************************************************************************************************
//						DateTime JODSDate = DateTime.Now;
//						
//						string JODSDateString = null;
//						//JODSDate = null;
//						JODSDateString = null;
//						//JODSDate = System.DateTime.Now;
//						JODSDateString = (JODSDate.ToString("yy")) + (JODSDate.ToString("MM"));
						string SDate;
						
			
						//************************************************************************************************************************
						//SDate = "JB" & NextNo
						
						SDate = NextNo.ToString();
						
						
						txtbx_shipmark2.Text = SDate;
						
						//************************************************************************************************************************
						//************************************************************************************************************************
						//---  Update next number
						SqlConnection conUpdateNextNumber = new SqlConnection(sqlconn);
						System.Data.SqlClient.SqlCommand cmdUpdateNextNumber = new SqlCommand();
						try {
							cmdUpdateNextNumber.CommandText = "update TBL_ADMIN_NEXT_NUMBER set ProdSchwanerShipMarkNextNumber = ProdSchwanerShipMarkNextNumber + 1";
							cmdUpdateNextNumber.Connection = conUpdateNextNumber;
							conUpdateNextNumber.Open();
							cmdUpdateNextNumber.ExecuteNonQuery();
						}
						catch (Exception ex)
						{
							conUpdateNextNumber.Close();
							MessageBox.Show("Error Update Next Number!" + ex.ToString() + ex.Message); 
							return;
						}
						finally 
						{
							conUpdateNextNumber.Close();
						}
						conUpdateNextNumber.Dispose();
						conUpdateNextNumber = null;
						cmdUpdateNextNumber = null;
						
						//MessageBox.Show(NextNo.ToString());
		}
		
		
		
		void datagrid()
		{
			
			
			
			
			string sql = "SELECT * FROM TBL_PROD_COAT_SCHWANER_JOB_MEMO";
            SqlConnection connection = new SqlConnection(sqlconn);
            SqlDataAdapter dataadapter = new SqlDataAdapter(sql, connection);
            DataTable ds = new DataTable();
            connection.Open();
            dataadapter.Fill(ds);
                     
           



            DataTable tempDT = new DataTable();
  			tempDT = ds.DefaultView.ToTable(true,"JO_SCHWANER", "PRODUCT_CODE", "TAPE_TYPE", "GLUE_CODE", "EFF_WIDTH", "LINER_CODE", "LC_WIDTH", "TAPE_THICKNESS", "COLOR", "TOTAL_LENGTH_REQ", "TOTAL_GLUE_REQ_KG", "TOTAL_M2", "TOTAL_CROSSLINKER_REQ_KG", "TOTAL_GLUE_REQ_DRUM", "CODE_CROSS_LINKER_REQ", "TOTAL_CROSS_LINKER_REQ_CAN", "SHIP_MARK1", "SHIP_MARK2", "REMARK", "SOLID_CONTENT", "COATING_THICKNESS", "PRODUCT_DESIGN", "QTY_CROSSLINKER_KG","QTY_BASEGLUE_KG", "STOCKCODE_PRODUCTCODE", "STOCKCODE_LINERCODE", "STOCKCODE_GLUECODE","STOCKCODE_COLORCODE");


   			dataGridView1.DataSource = tempDT;
   
  			connection.Close();
			
  			dataGridView1.Columns[0].HeaderText = "JO SCHWANER";
   			dataGridView1.Columns[1].HeaderText = "PRODUCT CODE";
   			dataGridView1.Columns[2].HeaderText = "TYPE OF TAPE";
  			dataGridView1.Columns[3].HeaderText = "GLUE CODE";
  			dataGridView1.Columns[4].HeaderText = "EFFECTIVE WIDTH";
   			dataGridView1.Columns[5].HeaderText = "LINER CODE";
   			dataGridView1.Columns[6].HeaderText = "LC WIDTH";
   			dataGridView1.Columns[7].HeaderText = "TAPE THICKNESS";
   			dataGridView1.Columns[8].HeaderText = "COLOR";
   			
   			
   			dataGridView1.Columns[9].HeaderText = "TOTAL LENGTH REQUIRED";

   			dataGridView1.Columns[10].HeaderText = "TOTAL GLUE REQUIRED";
   			dataGridView1.Columns[11].HeaderText = "TOTAL M2";
   			dataGridView1.Columns[12].HeaderText = "TOTAL CROSSLINKER REQUIRED KG";
   			dataGridView1.Columns[13].HeaderText = "TOTAL GLUE REQUIRED DRUM";
   			dataGridView1.Columns[14].HeaderText = "CODE CROSS LINKER REQUIRED";
   			dataGridView1.Columns[15].HeaderText = "TOTAL CROSSLINKER REQUIRED CAN";
   			dataGridView1.Columns[16].HeaderText = "SHIP MARK1";
   			dataGridView1.Columns[17].HeaderText = "SHIP MARK2";
   			dataGridView1.Columns[18].HeaderText = "REMARK";

			dataGridView1.Columns[19].HeaderText = "COATING THICKNESS";

			dataGridView1.Columns[20].HeaderText = "SOLID CONTENT";	

			dataGridView1.Columns[21].HeaderText = "PRODUCT DESIGN"; 

			dataGridView1.Columns[22].HeaderText = "QUANTITY CROSSLINKER / KG"; 

			dataGridView1.Columns[23].HeaderText = "QUANTITY BASE GLUE / KG"; 
			
			dataGridView1.Columns[24].HeaderText = "STOCKCODE PRODUCTCODE";
			dataGridView1.Columns[25].HeaderText = "STOCKCODE LINERCODE";
			dataGridView1.Columns[26].HeaderText = "STOCKCODE GLUECODE";
			dataGridView1.Columns[27].HeaderText = "STOCKCODE COLORCODE";
			
			
	

			dataGridView1.AllowUserToAddRows = false;			
   			
		}
 
		
		
		
		void DataGridView1CellClick(object sender, DataGridViewCellEventArgs e)
		{
			if(dataGridView1.SelectedRows.Count > 0) // make sure user select at least 1 row 
   			{		
				
			      
				   txtbx_jo.Text = dataGridView1.SelectedRows[0].Cells[0].Value + string.Empty;
				   txtbx_product_code.Text = dataGridView1.SelectedRows[0].Cells[1].Value + string.Empty;
			       txtbx_tape_type.Text = dataGridView1.SelectedRows[0].Cells[2].Value + string.Empty;
			       txtbx_glue_code.Text = dataGridView1.SelectedRows[0].Cells[3].Value + string.Empty;
			       txtbx_eff_width.Text = dataGridView1.SelectedRows[0].Cells[4].Value + string.Empty;
			       txtbx_liner_code.Text = dataGridView1.SelectedRows[0].Cells[5].Value + string.Empty;
			       txtbx_lc_width.Text = dataGridView1.SelectedRows[0].Cells[6].Value + string.Empty;
			       txtbx_tape_thickness.Text = dataGridView1.SelectedRows[0].Cells[7].Value + string.Empty;
			       txtbx_color.Text = dataGridView1.SelectedRows[0].Cells[8].Value + string.Empty;
				 
 				   
 				   	txtbx_ttl_length_req.Text = dataGridView1.SelectedRows[0].Cells[9].Value + string.Empty;
					txtbx_glue_kg.Text = dataGridView1.SelectedRows[0].Cells[10].Value + string.Empty;
					txtbx_ttl_m2.Text = dataGridView1.SelectedRows[0].Cells[11].Value + string.Empty;
					txtbx_crosslinker_kg.Text = dataGridView1.SelectedRows[0].Cells[12].Value + string.Empty;
					txtbx_glue_drum.Text = dataGridView1.SelectedRows[0].Cells[13].Value + string.Empty;
					txtbx_code_crosslinker.Text = dataGridView1.SelectedRows[0].Cells[14].Value + string.Empty;
					txtbx_ttl_crosslinker.Text = dataGridView1.SelectedRows[0].Cells[15].Value + string.Empty;
					txtbx_shipmark1.Text = dataGridView1.SelectedRows[0].Cells[16].Value + string.Empty;
					txtbx_shipmark2.Text = dataGridView1.SelectedRows[0].Cells[17].Value + string.Empty;
					txtbx_remark.Text = dataGridView1.SelectedRows[0].Cells[18].Value + string.Empty;
					txtbx_coat_thickness.Text = dataGridView1.SelectedRows[0].Cells[19].Value + string.Empty;
			        txtbx_sld_content.Text = dataGridView1.SelectedRows[0].Cells[20].Value + string.Empty;
 				   	
 				   	
					
				   var data = (Byte[])(dataGridView1.SelectedRows[0].Cells[21].Value);
				   var stream = new MemoryStream(data);
				   pictureBox1.Image = Image.FromStream(stream);
				   
				   txtbx_qty_crosslinker.Text = dataGridView1.SelectedRows[0].Cells[22].Value + string.Empty;
			       txtbx_qty_baseglue.Text = dataGridView1.SelectedRows[0].Cells[23].Value + string.Empty;
			       
			       txtbx_scpc.Text = dataGridView1.SelectedRows[0].Cells[24].Value + string.Empty;
			       txtbx_sclc.Text = dataGridView1.SelectedRows[0].Cells[25].Value + string.Empty;
			       txtbx_scgc.Text = dataGridView1.SelectedRows[0].Cells[26].Value + string.Empty;
			       txtbx_sccc.Text = dataGridView1.SelectedRows[0].Cells[27].Value + string.Empty;
			
						
//				   var data = (Byte[])(dataGridView1.SelectedRows[0].Cells[19].Value);
//				   var stream = new MemoryStream(data);
//				   pictureBox1.Image= Image.FromStream(stream);



			       
  			}  
		}
		
		
		
		
		
		
		
		void Btn_calcClick(object sender, EventArgs e)
		{
			txtbx_ttl_m2.Text = Convert.ToString((Convert.ToDouble(txtbx_eff_width.Text) /1000)  * Convert.ToDouble(txtbx_ttl_length_req.Text));
			
			actual_thickness = Convert.ToDouble(Convert.ToString(Convert.ToDouble(txtbx_tape_thickness.Text) - Convert.ToDouble(txtbx_coat_thickness.Text)));
			coating_weight = Convert.ToDouble(Convert.ToString((Convert.ToDouble(actual_thickness) / Convert.ToDouble(txtbx_sld_content.Text)) * 100));
			txtbx_glue_kg.Text = Convert.ToString(Convert.ToDouble(txtbx_ttl_length_req.Text) * (Convert.ToDouble(txtbx_eff_width.Text) / 1000) * (Convert.ToDouble(coating_weight) / 1000));
			
			txtbx_glue_drum.Text = Convert.ToString((Convert.ToDouble(txtbx_glue_kg.Text) / 180));
			txtbx_crosslinker_kg.Text = Convert.ToString(((Convert.ToDouble(txtbx_qty_crosslinker.Text) / Convert.ToDouble(txtbx_qty_baseglue.Text)) * 100));
			txtbx_ttl_crosslinker.Text = Convert.ToString(Convert.ToDouble(txtbx_crosslinker_kg.Text) / Convert.ToDouble(txtbx_qty_crosslinker.Text));
			
		}
		
		
		
	}
}
