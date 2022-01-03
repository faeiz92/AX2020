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
	public partial class frm_prod_coat_schwaner_bill_of_material : Form
	{
		string username;
		public static string sqlconn = "Server=AX-UAT; Password=sbax2020sbg; User ID=sbax2020; Initial Catalog=SBG_AX_2020; Integrated Security=false";
		public frm_prod_coat_schwaner_bill_of_material()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			datagrid();
			this.ControlBox = false;
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
    			//Bitmap
       			pictureBox1.Image = new Bitmap(open.FileName);
       			//txtPathdirectory.Text = open.FileName;
    		 }
			
		}
		
		void Btn_createClick(object sender, EventArgs e)
		{
			
//			if (!Validate()); 
//			return;
			
			SqlConnection con_data_add = new SqlConnection(sqlconn);
				System.Data.SqlClient.SqlCommand cmd_data_add = new SqlCommand();   //adress pergi ke sql
				try {
					
					

						cmd_data_add.Connection = con_data_add;	
						cmd_data_add.CommandText = "SP_PROD_COAT_SCHWANER_JOB_MEMO_DEFAULT_ADD";
						cmd_data_add.CommandType = CommandType.StoredProcedure;						

						

							//MessageBox.Show("lalu");
				
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
						
						
						cmd_data_add.Parameters.Add(new SqlParameter("@SP_SOLID_CONTENT", SqlDbType.Float)); //create parameter pada sql bwk data SP_RefNumber untuk dihantar semula
						cmd_data_add.Parameters["@SP_SOLID_CONTENT"].Value = Convert.ToDouble(txtbx_sld_content.Text);
						
						cmd_data_add.Parameters.Add(new SqlParameter("@SP_COATING_THICKNESS", SqlDbType.Float)); //create parameter pada sql bwk data SP_RefNumber untuk dihantar semula
						cmd_data_add.Parameters["@SP_COATING_THICKNESS"].Value = Convert.ToDouble(txtbx_coat_thickness.Text);
						
						
						
					
						
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
//						cmd_data_add.Parameters.Add(new SqlParameter("@SP_PRODUCT_DESIGN", SqlDbType.Binary));
//						cmd_data_add.Parameters["@SP_PRODUCT_DESIGN"].Value = img2;
//						
//  						}
  						
//  						else
//  						{
  						cmd_data_add.Parameters.Add(new SqlParameter("@SP_PRODUCT_DESIGN", SqlDbType.Binary));
						cmd_data_add.Parameters["@SP_PRODUCT_DESIGN"].Value = img;
//  						}
						
						
						cmd_data_add.Parameters.Add(new SqlParameter("@SP_STOCKCODE_GLUECODE", SqlDbType.NVarChar, 50));
						cmd_data_add.Parameters["@SP_STOCKCODE_GLUECODE"].Value = txtbx_scgc.Text.ToUpper() ;
						
						cmd_data_add.Parameters.Add(new SqlParameter("@SP_STOCKCODE_PRODUCTCODE", SqlDbType.NVarChar, 50));
						cmd_data_add.Parameters["@SP_STOCKCODE_PRODUCTCODE"].Value = txtbx_scpc.Text.ToUpper() ;
						
						cmd_data_add.Parameters.Add(new SqlParameter("@SP_STOCKCODE_COLORCODE", SqlDbType.NVarChar, 50));
						cmd_data_add.Parameters["@SP_STOCKCODE_COLORCODE"].Value = txtbx_sccc.Text.ToUpper() ;
						
						cmd_data_add.Parameters.Add(new SqlParameter("@SP_STOCKCODE_LINERCODE", SqlDbType.NVarChar, 50));
						cmd_data_add.Parameters["@SP_STOCKCODE_LINERCODE"].Value = txtbx_sclc.Text.ToUpper() ;
						
						
						
						
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
			
			
			
			
			
			
			MessageBox.Show("SUCCESFULL SAVE");
			
			datagrid();
			dataGridView1.Update();
			dataGridView1.Refresh();
			Clear_All_Textbox();
		}
		
	
			
		
		
			
		
		void datagrid()
		{
			string sql = "SELECT * FROM TBL_PROD_COAT_SCHWANER_JOB_MEMO_DEFAULT";
            SqlConnection connection = new SqlConnection(sqlconn);
            SqlDataAdapter dataadapter = new SqlDataAdapter(sql, connection);
            DataTable ds = new DataTable();
            connection.Open();
            dataadapter.Fill(ds);
                     
            DataTable tempDT = new DataTable();
  			tempDT = ds.DefaultView.ToTable(true,"PRODUCT_CODE", "TAPE_TYPE", "GLUE_CODE", "EFF_WIDTH", "LINER_CODE", "LC_WIDTH", "TAPE_THICKNESS", "COLOR", "COATING_THICKNESS", "SOLID_CONTENT","STOCKCODE_PRODUCTCODE", "STOCKCODE_LINERCODE", "STOCKCODE_GLUECODE","STOCKCODE_COLORCODE", "PRODUCT_DESIGN");
   			dataGridView1.DataSource = tempDT;
   
  			connection.Close();

   			dataGridView1.Columns[0].HeaderText = "PRODUCT CODE";
   			dataGridView1.Columns[1].HeaderText = "TYPE OF TAPE";
  			dataGridView1.Columns[2].HeaderText = "GLUE CODE";
  			dataGridView1.Columns[3].HeaderText = "EFFECTIVE WIDTH";
   			dataGridView1.Columns[4].HeaderText = "LINER CODE";
   			dataGridView1.Columns[5].HeaderText = "LC WIDTH";
   			dataGridView1.Columns[6].HeaderText = "TAPE THICKNESS";
   			dataGridView1.Columns[7].HeaderText = "COLOR";
   			dataGridView1.Columns[8].HeaderText = "COATING THICKNESS";
   			dataGridView1.Columns[9].HeaderText = "SOLID CONTENT";
   			dataGridView1.Columns[10].HeaderText = "STOCKCODE PRODUCTCODE";
			dataGridView1.Columns[11].HeaderText = "STOCKCODE LINERCODE";
			dataGridView1.Columns[12].HeaderText = "STOCKCODE GLUECODE";
			dataGridView1.Columns[13].HeaderText = "STOCKCODE COLORCODE";
   			dataGridView1.Columns[14].HeaderText = "PRODUCT DESIGN";
   			
   			
   			
   			
   			dataGridView1.AllowUserToAddRows = false;
		}
 
		
		void DataGridView1CellClick(object sender, DataGridViewCellEventArgs e)
		{
			
			if(dataGridView1.SelectedRows.Count > 0) // make sure user select at least 1 row 
   			{


			       txtbx_product_code.Text = dataGridView1.SelectedRows[0].Cells[0].Value + string.Empty;
			       txtbx_tape_type.Text = dataGridView1.SelectedRows[0].Cells[1].Value + string.Empty;
			       txtbx_glue_code.Text = dataGridView1.SelectedRows[0].Cells[2].Value + string.Empty;
			       txtbx_eff_width.Text = dataGridView1.SelectedRows[0].Cells[3].Value + string.Empty;
			       txtbx_liner_code.Text = dataGridView1.SelectedRows[0].Cells[4].Value + string.Empty;
			       txtbx_lc_width.Text = dataGridView1.SelectedRows[0].Cells[5].Value + string.Empty;
			       txtbx_tape_thickness.Text = dataGridView1.SelectedRows[0].Cells[6].Value + string.Empty;
			       txtbx_color.Text = dataGridView1.SelectedRows[0].Cells[7].Value + string.Empty;
			       txtbx_coat_thickness.Text = dataGridView1.SelectedRows[0].Cells[8].Value + string.Empty;
			       txtbx_sld_content.Text = dataGridView1.SelectedRows[0].Cells[9].Value + string.Empty;
			       
			       txtbx_scpc.Text = dataGridView1.SelectedRows[0].Cells[10].Value + string.Empty;
			       txtbx_sclc.Text = dataGridView1.SelectedRows[0].Cells[11].Value + string.Empty;
			       txtbx_scgc.Text = dataGridView1.SelectedRows[0].Cells[12].Value + string.Empty;
			       txtbx_sccc.Text = dataGridView1.SelectedRows[0].Cells[13].Value + string.Empty;
			  		
			       var data = (Byte[])(dataGridView1.SelectedRows[0].Cells[14].Value);
				   var stream = new MemoryStream(data);
				   pictureBox1.Image= Image.FromStream(stream);
			       


			       
  			}  
			 
			 
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
						cmd_data_add_update.CommandText = "SP_PROD_COAT_SCHWANER_JOB_MEMO_DEFAULT_EDIT";
						cmd_data_add_update.CommandType = CommandType.StoredProcedure;						


					
				
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
						
						
						cmd_data_add_update.Parameters.Add(new SqlParameter("@SP_SOLID_CONTENT", SqlDbType.Float)); //create parameter pada sql bwk data SP_RefNumber untuk dihantar semula
						cmd_data_add_update.Parameters["@SP_SOLID_CONTENT"].Value = Convert.ToDouble(txtbx_sld_content.Text);
						
						cmd_data_add_update.Parameters.Add(new SqlParameter("@SP_COATING_THICKNESS", SqlDbType.Float)); //create parameter pada sql bwk data SP_RefNumber untuk dihantar semula
						cmd_data_add_update.Parameters["@SP_COATING_THICKNESS"].Value = Convert.ToDouble(txtbx_coat_thickness.Text);
						
						
					
						
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
//						MessageBox.Show("img2");
//  						}
//  						
//  						else
//  						{
  						cmd_data_add_update.Parameters.Add(new SqlParameter("@SP_PRODUCT_DESIGN", SqlDbType.Binary));
						cmd_data_add_update.Parameters["@SP_PRODUCT_DESIGN"].Value = img;
						//MessageBox.Show("img");
  						//}
  						
  						
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
			
			
			
			MessageBox.Show("SUCCESFULL UPDATE AND SAVE");
			
			
			Clear_All_Textbox();
			datagrid();
			dataGridView1.Update();
			dataGridView1.Refresh();
			
		}
		
//		private bool Validate()
//	{
//
//
//
//		if (CommonValidation.ValidateIsEmptyString(txtbx_product_code.Text.Trim()))
//	                {
//	                    DialogBox.ShowWarningMessage(txtbx_product_code.Text + " cannot be empty.");
//	                  	txtbx_product_code.Focus();
//	                    return false;
//	                }
//			
//
//			else if (CommonValidation.ValidateIsEmptyString(txtbx_glue_code.Text.Trim()))
//				                {
//				                    DialogBox.ShowWarningMessage(txtbx_glue_code.Text + " cannot be empty.");
//				                    txtbx_glue_code.Focus();
//				                    return false;
//				                }
//
//			else if (CommonValidation.ValidateIsEmptyString(txtbx_color.Text.Trim()))
//				                {
//				                    DialogBox.ShowWarningMessage(txtbx_color.Text + " cannot be empty.");
//				                    txtbx_color.Focus();
//				                    return false;
//				                }
//
//			else if (CommonValidation.ValidateIsEmptyString(txtbx_coat_thickness.Text.Trim()))
//				                {
//				                    DialogBox.ShowWarningMessage(txtbx_coat_thickness.Text + " cannot be empty.");
//				                    txtbx_coat_thickness.Focus();
//				                    return false;
//				                }
//
//			else if (CommonValidation.ValidateIsEmptyString(txtbx_tape_type.Text.Trim()))
//				                {
//				                    DialogBox.ShowWarningMessage(txtbx_tape_type.Text + " cannot be empty.");
//				                    txtbx_tape_type.Focus();
//				                    return false;
//				                }
//			else if (CommonValidation.ValidateIsEmptyString(txtbx_lc_width.Text.Trim()))
//				                {
//				                    DialogBox.ShowWarningMessage(txtbx_lc_width.Text + " cannot be empty.");
//				                    txtbx_lc_width.Focus();
//				                    return false;
//				                }
//			
//			
//			
//			
//			else if (CommonValidation.ValidateIsEmptyString(txtbx_tape_thickness.Text.Trim()))
//				                {
//				                    DialogBox.ShowWarningMessage(txtbx_tape_thickness.Text + " cannot be empty.");
//				                    txtbx_tape_thickness.Focus();
//				                    return false;
//	                			}
//			
//			
//			else if (CommonValidation.ValidateIsEmptyString(txtbx_eff_width.Text.Trim()))
//				                {
//				                    DialogBox.ShowWarningMessage(txtbx_eff_width.Text + " cannot be empty.");
//				                    txtbx_tape_thickness.Focus();
//				                    return false;
//	                			}
//			
//			else if (CommonValidation.ValidateIsEmptyString(txtbx_sld_content.Text.Trim()))
//				                {
//				                    DialogBox.ShowWarningMessage(txtbx_sld_content.Text + " cannot be empty.");
//				                    txtbx_sld_content.Focus();
//				                    return false;
//	                			}
//			
//			
//			else if (pictureBox1.Image == null)
//				                {
//				                    DialogBox.ShowWarningMessage(pictureBox1.Image + " Please Select Image");
//				                    pictureBox1.Focus();
//				                    return false;
//	                			}
//
//	                
//	                return true;
//}
		
		
		
		
		
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
		
		
		
		void Btn_deleteClick(object sender, EventArgs e)
		{
			SqlConnection con_data_del = new SqlConnection(sqlconn);
				System.Data.SqlClient.SqlCommand cmd_data_del = new SqlCommand();   //adress pergi ke sql
				try {
					
					

						cmd_data_del.Connection = con_data_del;	
						cmd_data_del.CommandText = "SP_PROD_COAT_SCHWANER_JOB_MEMO_DEFAULT_DEL";
						cmd_data_del.CommandType = CommandType.StoredProcedure;						
							//coman run store procedure
							//nama store procedure
							//declare comand
						

					
				
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
						
						
						
						cmd_data_del.Parameters.Add(new SqlParameter("@SP_SOLID_CONTENT", SqlDbType.Float)); //create parameter pada sql bwk data SP_RefNumber untuk dihantar semula
						cmd_data_del.Parameters["@SP_SOLID_CONTENT"].Value = Convert.ToDouble(txtbx_sld_content.Text);
						
						cmd_data_del.Parameters.Add(new SqlParameter("@SP_COATING_THICKNESS", SqlDbType.Float)); //create parameter pada sql bwk data SP_RefNumber untuk dihantar semula
						cmd_data_del.Parameters["@SP_COATING_THICKNESS"].Value = Convert.ToDouble(txtbx_coat_thickness.Text);
						
						
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
	
//  						if(img2 == new byte[ms2.Length])
//  						{
//						cmd_data_del.Parameters.Add(new SqlParameter("@SP_PRODUCT_DESIGN", SqlDbType.Binary));
//						cmd_data_del.Parameters["@SP_PRODUCT_DESIGN"].Value = img2;
//						
//  						}
//  						
//  						else
//  						{
  						cmd_data_del.Parameters.Add(new SqlParameter("@SP_PRODUCT_DESIGN", SqlDbType.Binary));
						cmd_data_del.Parameters["@SP_PRODUCT_DESIGN"].Value = img;
//  						}
						
						
						cmd_data_del.Parameters.Add(new SqlParameter("@SP_STOCKCODE_GLUECODE", SqlDbType.NVarChar, 50));
						cmd_data_del.Parameters["@SP_STOCKCODE_GLUECODE"].Value = txtbx_scgc.Text.ToUpper() ;
						
						cmd_data_del.Parameters.Add(new SqlParameter("@SP_STOCKCODE_PRODUCTCODE", SqlDbType.NVarChar, 50));
						cmd_data_del.Parameters["@SP_STOCKCODE_PRODUCTCODE"].Value = txtbx_scpc.Text.ToUpper() ;
						
						cmd_data_del.Parameters.Add(new SqlParameter("@SP_STOCKCODE_COLORCODE", SqlDbType.NVarChar, 50));
						cmd_data_del.Parameters["@SP_STOCKCODE_COLORCODE"].Value = txtbx_sccc.Text.ToUpper() ;
						
						cmd_data_del.Parameters.Add(new SqlParameter("@SP_STOCKCODE_LINERCODE", SqlDbType.NVarChar, 50));
						cmd_data_del.Parameters["@SP_STOCKCODE_LINERCODE"].Value = txtbx_sclc.Text.ToUpper() ;
						
						
						
						
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
		
	}
}
