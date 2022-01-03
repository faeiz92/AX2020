/*
 * Created by SharpDevelop.
 * User: it-3
 * Date: 20/12/2016
 * Time: 10:48 AM
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

namespace AX2020
{
	/// <summary>
	/// Description of frm_speacial_bom.
	/// </summary>
	public partial class frm_prod_coating_printing_bom_R1 : Form
	{
		
		string username;
		string color_combine;
		public static string sqlconn = "Server=AX-UAT; Password=sbax2020sbg; User ID=sbax2020; Initial Catalog=SBG_AX_2020; Integrated Security=false";
		public frm_prod_coating_printing_bom_R1()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			datagrid();
			this.ControlBox = false;
			username = frm_menu_system.userName; 
			lbl_username.Text = "User : " + username;
			
			
			username = frm_menu_system.userName; 
			lbl_username.Text = "User : " + username;
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		
		void datagrid()
		{
			string sql = "SELECT * FROM TBL_PROD_COAT_PRINTING_BOM";
            SqlConnection connection = new SqlConnection(sqlconn);
            SqlDataAdapter dataadapter = new SqlDataAdapter(sql, connection);
            DataTable ds = new DataTable();
            connection.Open();
            dataadapter.Fill(ds);
                     
            DataTable tempDT = new DataTable();
  			tempDT = ds.DefaultView.ToTable(true,"JOPPREFNO", "JOPPWORDING", "JOPPCOLOR", "JOPPMICRON", "JOPPWIDTH", "JOPPLENGTH", "JOPPCOLORKG", "JOPPCUSTOMER");
   			dataGridView1.DataSource = tempDT;
   
  			connection.Close();

   			dataGridView1.Columns[0].HeaderText = "Ref No";
   			dataGridView1.Columns[1].HeaderText = "Wording";
  			dataGridView1.Columns[2].HeaderText = "Color";
   			dataGridView1.Columns[3].HeaderText = "Micron";
   			dataGridView1.Columns[4].HeaderText = "Width";
   			dataGridView1.Columns[5].HeaderText = "Length";
   			dataGridView1.Columns[6].HeaderText = "Color/Kg";
   			dataGridView1.Columns[7].HeaderText = "Customer";
		}
		
	
		
		void Btn_createClick(object sender, EventArgs e)
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
							NextNo = Convert.ToInt32(rdNextNumber["ProdCoatNextNumber"].ToString());
							
						} 
						
						
						catch (Exception ex) 
						
						{
							MessageBox.Show("ERROR NEXT NUMBER!" + ex.ToString() +ex.Message);
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
		
						
						SqlConnection conUpdateNextNumber = new SqlConnection(sqlconn);
						System.Data.SqlClient.SqlCommand cmdUpdateNextNumber = new SqlCommand();
						try {
							cmdUpdateNextNumber.CommandText = "update TBL_ADMIN_NEXT_NUMBER set ProdCoatNextNumber = ProdCoatNextNumber + 1";
							cmdUpdateNextNumber.Connection = conUpdateNextNumber;
							conUpdateNextNumber.Open();
							cmdUpdateNextNumber.ExecuteNonQuery();
						}
						catch (Exception ex) 
						{
							conUpdateNextNumber.Close();
							MessageBox.Show("Error Update Next Number!" + ex.ToString() + ex.Message); //Lbl_Message.Text = "Error Update Next Number! " + ex.ToString + ex.Message;
							return;
						} 
						finally 
						{
							conUpdateNextNumber.Close();
						}
						conUpdateNextNumber.Dispose();
						conUpdateNextNumber = null;
						cmdUpdateNextNumber = null;
						
						
					
					
//						if (txtbx_wording.Text == Rows.Count > 0)
//						{
//						}

					
                    SqlConnection con_data_add = new SqlConnection (sqlconn);
					System.Data.SqlClient.SqlCommand cmd_data_add = new SqlCommand();  //adress pergi ke sql
					SqlConnection con_Check_Duplicate_word = new SqlConnection(sqlconn);
					SqlCommand cmd_Check_Duplicate_word = new SqlCommand();
					
					try {
						
						
						
						
					cmd_Check_Duplicate_word.CommandText = "select * from TBL_PROD_COAT_PRINTING_BOM where JOPPWORDING  = '" + txtbx_wording.Text.ToUpper() + "' and JOPPCUSTOMER = '"  + txtbx_costumer.Text.ToUpper() + "'";
					cmd_Check_Duplicate_word.Connection = con_Check_Duplicate_word;
					con_Check_Duplicate_word.Open();
					SqlDataReader rd_Check_Duplicate_word = cmd_Check_Duplicate_word.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
					
						if (rd_Check_Duplicate_word.Read())
								{
									if (rd_Check_Duplicate_word.HasRows) 
										{
											MessageBox.Show("Can't Insert Same Wording");//Lbl_Message.Text = "Error 1.0 : Duplicate JO! ";
											return;
										}
								}
				

						cmd_data_add.Connection = con_data_add;		//coman run store procedure
						cmd_data_add.CommandText = "SP_PROD_COAT_PRINTING_BOM_ADD_R2";	//nama store procedure
						cmd_data_add.CommandType = CommandType.StoredProcedure;		//declare comand
						
						
						
			
						cmd_data_add.Parameters.Add(new SqlParameter("@SP_JOPPREFNO", SqlDbType.Int)); //create parameter pada sql bwk data SP_RefNumber untuk dihantar semula
						cmd_data_add.Parameters["@SP_JOPPREFNO"].Value = NextNo;
						
						
    	
						//cmd_data_add.Parameters.Add(new SqlParameter("@SP_REPORTDATE", SqlDbType.DateTime)); //create parameter pada sql bwk data SP_RefNumber untuk dihantar semula
						//cmd_data_add.Parameters["@SP_REPORTDATE"].Value = DateTime.Now;
				
						cmd_data_add.Parameters.Add(new SqlParameter("@SP_JOPPWORDING", SqlDbType. NVarChar, 50)); //create parameter pada sql bwk data SP_RefNumber untuk dihantar semula
						cmd_data_add.Parameters["@SP_JOPPWORDING"].Value = txtbx_wording.Text.ToUpper();
						
						cmd_data_add.Parameters.Add(new SqlParameter("@SP_JOPPCUSTOMER", SqlDbType. NVarChar, 50)); //create parameter pada sql bwk data SP_RefNumber untuk dihantar semula
						cmd_data_add.Parameters["@SP_JOPPCUSTOMER"].Value = txtbx_costumer.Text.ToUpper();
						
						color_combine = txtbx_color1.Text.ToUpper() + "+" + txtbx_color2.Text.ToUpper();
						
						cmd_data_add.Parameters.Add(new SqlParameter("@SP_JOPPCOLOR", SqlDbType. NVarChar, 50)); //create parameter pada sql bwk data SP_RefNumber untuk dihantar semula
						cmd_data_add.Parameters["@SP_JOPPCOLOR"].Value = color_combine;

						cmd_data_add.Parameters.Add(new SqlParameter("@SP_JOPPMICRON", SqlDbType.Float)); //create parameter pada sql bwk data SP_RefNumber untuk dihantar semula
						cmd_data_add.Parameters["@SP_JOPPMICRON"].Value =Convert.ToDouble(txtbx_micron.Text);
						
						cmd_data_add.Parameters.Add(new SqlParameter("@SP_JOPPWIDTH", SqlDbType. Float)); //create parameter pada sql bwk data SP_RefNumber untuk dihantar semula
						cmd_data_add.Parameters["@SP_JOPPWIDTH"].Value = Convert.ToDouble(txtbx_width.Text);
						
						cmd_data_add.Parameters.Add(new SqlParameter("@SP_JOPPLENGTH", SqlDbType.Float));
						cmd_data_add.Parameters["@SP_JOPPLENGTH"].Value = Convert.ToDouble(txtbx_length.Text);
						
						cmd_data_add.Parameters.Add(new SqlParameter("@SP_JOPPCOLORKG", SqlDbType.NVarChar, 50));
						cmd_data_add.Parameters["@SP_JOPPCOLORKG"].Value = txtbx_colorkg.Text.ToUpper();
						
						cmd_data_add.Parameters.Add(new SqlParameter("@SP_JOSTOCKCODE_INK1", SqlDbType.NVarChar, 50));
						cmd_data_add.Parameters["@SP_JOSTOCKCODE_INK1"].Value = txtbx_stockcodeink1.Text.ToUpper();
						
						cmd_data_add.Parameters.Add(new SqlParameter("@SP_JOSTOCKCODE_INK2", SqlDbType.NVarChar, 50));
						cmd_data_add.Parameters["@SP_JOSTOCKCODE_INK2"].Value = txtbx_stockcodeink2.Text.ToUpper();
						
						cmd_data_add.Parameters.Add(new SqlParameter("@SP_JOPPCOLOR_INK1", SqlDbType.NVarChar, 50));
						cmd_data_add.Parameters["@SP_JOPPCOLOR_INK1"].Value = txtbx_color1.Text.ToUpper();
						
						cmd_data_add.Parameters.Add(new SqlParameter("@SP_JOPPCOLOR_INK2", SqlDbType.NVarChar, 50));
						cmd_data_add.Parameters["@SP_JOPPCOLOR_INK2"].Value = txtbx_color2.Text.ToUpper();
						
						cmd_data_add.Parameters.Add(new SqlParameter("@SP_QUANTITY_INK1", SqlDbType.NVarChar, 50));
						cmd_data_add.Parameters["@SP_QUANTITY_INK1"].Value = txtbx_colorkg1.Text.ToUpper();
						
						cmd_data_add.Parameters.Add(new SqlParameter("@SP_QUANTITY_INK2", SqlDbType.NVarChar, 50));
						cmd_data_add.Parameters["@SP_QUANTITY_INK2"].Value = txtbx_colorkg1.Text.ToUpper();
						
						cmd_data_add.Parameters.Add(new SqlParameter("@SP_JOPPISSUEBY", SqlDbType.NVarChar, 50));
						cmd_data_add.Parameters["@SP_JOPPISSUEBY"].Value = username;
	
					
						con_data_add.Open();
						cmd_data_add.ExecuteNonQuery();
						cmd_data_add.Parameters.Clear();
						datagrid();
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
			MessageBox.Show("SUCCESFULL SAVE.");
			
			dataGridView1.Update();
			dataGridView1.Refresh();

				
		}
		
		


 		void DataGridView1CellClick(object sender, DataGridViewCellEventArgs e)
 		 {
 			  if(dataGridView1.SelectedRows.Count > 0) // make sure user select at least 1 row 
   			{

			       txtbx_refNo.Text = dataGridView1.SelectedRows[0].Cells[0].Value + string.Empty;
			       txtbx_wording.Text = dataGridView1.SelectedRows[0].Cells[1].Value + string.Empty;
			       txtbx_color1.Text = dataGridView1.SelectedRows[0].Cells[2].Value + string.Empty;
			       txtbx_micron.Text = dataGridView1.SelectedRows[0].Cells[3].Value + string.Empty;
			       txtbx_width.Text = dataGridView1.SelectedRows[0].Cells[4].Value + string.Empty;
			       txtbx_length.Text = dataGridView1.SelectedRows[0].Cells[5].Value + string.Empty;
			       txtbx_colorkg1.Text = dataGridView1.SelectedRows[0].Cells[6].Value + string.Empty;
			       txtbx_costumer.Text = dataGridView1.SelectedRows[0].Cells[7].Value + string.Empty;
			       
  			}  
 
  		 }

			
		
		void Btn_clearClick(object sender, EventArgs e)
		{
			
			
			
			txtbx_refNo.Clear();
			txtbx_wording.Clear();
			txtbx_color1.Clear();
			txtbx_micron.Clear();
			txtbx_width.Clear();
			txtbx_length.Clear();
			txtbx_colorkg1.Clear();
			txtbx_costumer.Clear();
			
		}
		
		void Button3Click(object sender, EventArgs e)
		{
			

            	this.Close();
		}
		
		void Btn_deleteClick(object sender, EventArgs e)
		{
			
			
				SqlConnection con_data_del = new SqlConnection (sqlconn);
				System.Data.SqlClient.SqlCommand cmd_data_del = new SqlCommand();  //adress pergi ke sql
				try {

						cmd_data_del.Connection = con_data_del;		//coman run store procedure
						cmd_data_del.CommandText = "SP_PROD_COAT_PRINTING_BOM_DEL_R2";	//nama store procedure
						cmd_data_del.CommandType = CommandType.StoredProcedure;		//declare comand
    	
						cmd_data_del.Parameters.Add(new SqlParameter("@SP_JOPPREFNO", SqlDbType.Int)); //create parameter pada sql bwk data SP_RefNumber untuk dihantar semula
						cmd_data_del.Parameters["@SP_JOPPREFNO"].Value = txtbx_refNo.Text;
						
						
    	
						//cmd_data_del.Parameters.Add(new SqlParameter("@SP_REPORTDATE", SqlDbType.DateTime)); //create parameter pada sql bwk data SP_RefNumber untuk dihantar semula
						//cmd_data_del.Parameters["@SP_REPORTDATE"].Value = DateTime.Now;
				
						cmd_data_del.Parameters.Add(new SqlParameter("@SP_JOPPWORDING", SqlDbType. NVarChar, 50)); //create parameter pada sql bwk data SP_RefNumber untuk dihantar semula
						cmd_data_del.Parameters["@SP_JOPPWORDING"].Value = txtbx_wording.Text.ToUpper();
						
						cmd_data_del.Parameters.Add(new SqlParameter("@SP_JOPPCUSTOMER", SqlDbType. NVarChar, 50)); //create parameter pada sql bwk data SP_RefNumber untuk dihantar semula
						cmd_data_del.Parameters["@SP_JOPPCUSTOMER"].Value = txtbx_costumer.Text.ToUpper();
						
						cmd_data_del.Parameters.Add(new SqlParameter("@SP_JOPPCOLOR", SqlDbType. NVarChar, 50)); //create parameter pada sql bwk data SP_RefNumber untuk dihantar semula
						cmd_data_del.Parameters["@SP_JOPPCOLOR"].Value = txtbx_color1.Text.ToUpper() + "+" + txtbx_color2;

						cmd_data_del.Parameters.Add(new SqlParameter("@SP_JOPPMICRON", SqlDbType.Float)); //create parameter pada sql bwk data SP_RefNumber untuk dihantar semula
						cmd_data_del.Parameters["@SP_JOPPMICRON"].Value =Convert.ToDouble(txtbx_micron.Text);
						
						cmd_data_del.Parameters.Add(new SqlParameter("@SP_JOPPWIDTH", SqlDbType. Float)); //create parameter pada sql bwk data SP_RefNumber untuk dihantar semula
						cmd_data_del.Parameters["@SP_JOPPWIDTH"].Value = Convert.ToDouble(txtbx_width.Text);
						
						cmd_data_del.Parameters.Add(new SqlParameter("@SP_JOPPLENGTH", SqlDbType.Float));
						cmd_data_del.Parameters["@SP_JOPPLENGTH"].Value = Convert.ToDouble(txtbx_length.Text);
						
						cmd_data_del.Parameters.Add(new SqlParameter("@SP_JOPPCOLORKG", SqlDbType.NVarChar, 50));
						cmd_data_del.Parameters["@SP_JOPPCOLORKG"].Value = txtbx_colorkg.Text.ToUpper();
						
						cmd_data_del.Parameters.Add(new SqlParameter("@SP_JOSTOCKCODE_INK1", SqlDbType.NVarChar, 50));
						cmd_data_del.Parameters["@SP_JOSTOCKCODE_INK1"].Value = txtbx_stockcodeink1.Text.ToUpper();
						
						cmd_data_del.Parameters.Add(new SqlParameter("@SP_JOSTOCKCODE_INK2", SqlDbType.NVarChar, 50));
						cmd_data_del.Parameters["@SP_JOSTOCKCODE_INK2"].Value = txtbx_stockcodeink2.Text.ToUpper();
						
						cmd_data_del.Parameters.Add(new SqlParameter("@SP_JOPPCOLOR_INK1", SqlDbType.NVarChar, 50));
						cmd_data_del.Parameters["@SP_JOPPCOLOR_INK1"].Value = txtbx_color1.Text.ToUpper();
						
						cmd_data_del.Parameters.Add(new SqlParameter("@SP_JOPPCOLOR_INK2", SqlDbType.NVarChar, 50));
						cmd_data_del.Parameters["@SP_JOPPCOLOR_INK2"].Value = txtbx_color2.Text.ToUpper();
						
						cmd_data_del.Parameters.Add(new SqlParameter("@SP_QUANTITY_INK1", SqlDbType.NVarChar, 50));
						cmd_data_del.Parameters["@SP_QUANTITY_INK1"].Value = txtbx_colorkg1.Text.ToUpper();
						
						cmd_data_del.Parameters.Add(new SqlParameter("@SP_QUANTITY_INK2", SqlDbType.NVarChar, 50));
						cmd_data_del.Parameters["@SP_QUANTITY_INK2"].Value = txtbx_colorkg2.Text.ToUpper();
						
						cmd_data_del.Parameters.Add(new SqlParameter("@SP_JOPPISSUEBY", SqlDbType.NVarChar, 50));
						cmd_data_del.Parameters["@SP_JOPPISSUEBY"].Value = username;
	
		
						con_data_del.Open();
						cmd_data_del.ExecuteNonQuery();
						cmd_data_del.Parameters.Clear();
						
						dataGridView1.Update();
						dataGridView1.Refresh();
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
			MessageBox.Show("SUCCESFULL DELETE.");
			datagrid();
			
		}
		
		
		
		void Frm_prod_coating_printing_bomLoad(object sender, EventArgs e)
		{
			txtbx_refNo.Enabled = false;
		}
		
		void Txtxbx_searchTextChanged(object sender, EventArgs e)
		{
			 SqlConnection connection2 = new SqlConnection(sqlconn);
           // SqlDataAdapter dataadapter = new SqlDataAdapter(sql, connection2);
           // DataTable ds2 = new DataTable();
         	connection2.Open();
            //dataadapter.Fill(ds2);
            
            
		
			SqlDataAdapter da = new SqlDataAdapter("Select JOPPREFNO, JOPPWORDING, JOPPCOLOR, JOPPMICRON, JOPPWIDTH, JOPPLENGTH, JOPPCOLORKG, JOPPCUSTOMER from TBL_PROD_COAT_PRINTING_BOM_R2 Where JOPPWORDING like '" +  txtxbx_search.Text + "%'",connection2);
			DataTable dt2 = new DataTable();
			da.Fill(dt2);
			dataGridView1.DataSource= dt2;
			dataGridView1.Refresh();
			connection2.Close();
		}
		
	
		
	}
}
