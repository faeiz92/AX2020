/*
 * Created by SharpDevelop.
 * User: it-3
 * Date: 23/12/2016
 * Time: 8:44 AM
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
	/// Description of frm_prod_coat_schwaner.
	/// </summary>
	public partial class frm_prod_coating_schwaner : Form
	{
		public static string sqlconn = "Server=AX-UAT; Password=sbax2020sbg; User ID=sbax2020; Initial Catalog=SBG_AX_2020; Integrated Security=false";
		
		public frm_prod_coating_schwaner()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			datagrid1();
			datagridall();
			datagrid2();
			datagrid3();
   			datagrid4();
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		
		void datagrid1()
		{
			
			string sql = "SELECT * FROM TBL_PROD_COAT_PRODUCTCODE_SCHWANER";
            SqlConnection connection = new SqlConnection(sqlconn);
            SqlDataAdapter dataadapter = new SqlDataAdapter(sql, connection);
            DataTable ds = new DataTable();
            connection.Open();
            dataadapter.Fill(ds);
                     
            DataTable tempDT = new DataTable();
  			tempDT = ds.DefaultView.ToTable(true,"CODE", "DESC1", "DESC2", "WIDTH", "PUOM", "CONV", "SUOM");
   			dataGridView1.DataSource = tempDT;
   
  			connection.Close();

   			dataGridView1.Columns[0].HeaderText = "Code";
   			dataGridView1.Columns[1].HeaderText = "Desc1";
  			dataGridView1.Columns[2].HeaderText = "Desc2";
   			dataGridView1.Columns[3].HeaderText = "Width";
   			dataGridView1.Columns[4].HeaderText = "Puom";
   			dataGridView1.Columns[5].HeaderText = "Conv";
   			dataGridView1.Columns[6].HeaderText = "Suom";
		}
		
		
		void DataGridView1CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
			 if(dataGridView1.SelectedRows.Count > 0) // make sure user select at least 1 row 
   			{

			       txtbx_prodcode.Text = dataGridView1.SelectedRows[0].Cells[0].Value + string.Empty;
			       txtbx_desc1.Text = dataGridView1.SelectedRows[0].Cells[1].Value + string.Empty;
			       txtbx_desc2.Text = dataGridView1.SelectedRows[0].Cells[2].Value + string.Empty;
//			       txtbx_micron.Text = dataGridView1.SelectedRows[0].Cells[3].Value + string.Empty;
//			       txtbx_width.Text = dataGridView1.SelectedRows[0].Cells[4].Value + string.Empty;
//			       txtbx_length.Text = dataGridView1.SelectedRows[0].Cells[5].Value + string.Empty;
//			       txtbx_colorkg.Text = dataGridView1.SelectedRows[0].Cells[6].Value + string.Empty;
			       
  			}  
			
		}
		
			void datagrid2()
		{
			
			string sql = "SELECT * FROM TBL_PROD_COAT_GLUECODE_SCHWANER";
            SqlConnection connection = new SqlConnection(sqlconn);
            SqlDataAdapter dataadapter = new SqlDataAdapter(sql, connection);
            DataTable ds = new DataTable();
            connection.Open();
            dataadapter.Fill(ds);
                     
            DataTable tempDT = new DataTable();
  			tempDT = ds.DefaultView.ToTable(true,"CODE", "DESC1", "DESC2", "WIDTH", "PUOM", "CONV", "SUOM");
   			dataGridView2.DataSource = tempDT;
   
  			connection.Close();

   			dataGridView2.Columns[0].HeaderText = "Code";
   			dataGridView2.Columns[1].HeaderText = "Desc1";
  			dataGridView2.Columns[2].HeaderText = "Desc2";
   			//dataGridView2.Columns[3].HeaderText = "Width";
   			//dataGridView2.Columns[4].HeaderText = "Puom";
   			//dataGridView2.Columns[5].HeaderText = "Conv";
   			//dataGridView2.Columns[6].HeaderText = "Suom";
		}
		
		
		void DataGridView2CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
			if(dataGridView1.SelectedRows.Count > 0) // make sure user select at least 1 row 
   			{

			       txtbx_prodcode.Text = dataGridView1.SelectedRows[0].Cells[0].Value + string.Empty;
			       txtbx_desc1.Text = dataGridView1.SelectedRows[0].Cells[1].Value + string.Empty;
			       txtbx_desc2.Text = dataGridView1.SelectedRows[0].Cells[2].Value + string.Empty;
//			       txtbx_micron.Text = dataGridView1.SelectedRows[0].Cells[3].Value + string.Empty;
//			       txtbx_width.Text = dataGridView1.SelectedRows[0].Cells[4].Value + string.Empty;
//			       txtbx_length.Text = dataGridView1.SelectedRows[0].Cells[5].Value + string.Empty;
//			       txtbx_colorkg.Text = dataGridView1.SelectedRows[0].Cells[6].Value + string.Empty;
			       
  			}  
		}
		
		
		
		
		void datagrid3()
		{
			
			string sql = "SELECT * FROM TBL_PROD_COAT_GLUECODE_SCHWANER";
            SqlConnection connection = new SqlConnection(sqlconn);
            SqlDataAdapter dataadapter = new SqlDataAdapter(sql, connection);
            DataTable ds = new DataTable();
            connection.Open();
            dataadapter.Fill(ds);
                     
            DataTable tempDT = new DataTable();
  			tempDT = ds.DefaultView.ToTable(true,"CODE", "DESC1", "DESC2", "WIDTH", "PUOM", "CONV", "SUOM");
   			dataGridView3.DataSource = tempDT;
   
  			connection.Close();

   			dataGridView3.Columns[0].HeaderText = "Code";
   			dataGridView3.Columns[1].HeaderText = "Desc1";
  			dataGridView3.Columns[2].HeaderText = "Desc2";
   			dataGridView3.Columns[3].HeaderText = "Width";
   			dataGridView3.Columns[4].HeaderText = "Puom";
   			dataGridView3.Columns[5].HeaderText = "Conv";
   			dataGridView3.Columns[6].HeaderText = "Suom";
		}
		
		
		
		
		void datagrid4()
		{
			
			string sql = "SELECT * FROM TBL_PROD_COAT_LINERCODE_SCHWANER";
            SqlConnection connection = new SqlConnection(sqlconn);
            SqlDataAdapter dataadapter = new SqlDataAdapter(sql, connection);
            DataTable ds = new DataTable();
            connection.Open();
            dataadapter.Fill(ds);
                     
            DataTable tempDT = new DataTable();
  			tempDT = ds.DefaultView.ToTable(true,"CODE", "DESC1", "DESC2", "WIDTH", "PUOM", "CONV", "SUOM");
   			dataGridView4.DataSource = tempDT;
   
  			connection.Close();

   			dataGridView4.Columns[0].HeaderText = "Code";
   			dataGridView4.Columns[1].HeaderText = "Desc1";
  			dataGridView4.Columns[2].HeaderText = "Desc2";
   			dataGridView4.Columns[3].HeaderText = "Width";
   			dataGridView4.Columns[4].HeaderText = "Puom";
   			dataGridView4.Columns[5].HeaderText = "Conv";
   			dataGridView4.Columns[6].HeaderText = "Suom";
		}
		
		
		void DataGridView4CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
			if(dataGridView4.SelectedRows.Count > 0) // make sure user select at least 1 row 
   			{

			       txtbx_prodcode.Text = dataGridView4.SelectedRows[0].Cells[0].Value + string.Empty;
			       txtbx_desc1.Text = dataGridView4.SelectedRows[0].Cells[1].Value + string.Empty;
			       txtbx_desc2.Text = dataGridView4.SelectedRows[0].Cells[2].Value + string.Empty;
//			       txtbx_micron.Text = dataGridView1.SelectedRows[0].Cells[3].Value + string.Empty;
//			       txtbx_width.Text = dataGridView1.SelectedRows[0].Cells[4].Value + string.Empty;
//			       txtbx_length.Text = dataGridView1.SelectedRows[0].Cells[5].Value + string.Empty;
//			       txtbx_colorkg.Text = dataGridView1.SelectedRows[0].Cells[6].Value + string.Empty;
			       
  			}  
		}
		
		void datagridall()
		{
			
			string sql = "SELECT * FROM TBL_PROD_COAT_ALL_ITEM_SCHWANER";
            SqlConnection connection = new SqlConnection(sqlconn);
            SqlDataAdapter dataadapter = new SqlDataAdapter(sql, connection);
            DataTable ds = new DataTable();
            connection.Open();
            dataadapter.Fill(ds);
                     
            DataTable tempDT = new DataTable();
  			tempDT = ds.DefaultView.ToTable(true,"REFNO", "PRODUCTCODE", "DESC1", "THICKNESSMICRON", "FILMCODE", "GLUECODE", "LINERCODE");
   			dataGridView8.DataSource = tempDT;
   
  			connection.Close();

   			dataGridView8.Columns[0].HeaderText = "REFNO";
   			dataGridView8.Columns[1].HeaderText = "CODE";
  			dataGridView8.Columns[2].HeaderText = "DESC";
   			dataGridView8.Columns[3].HeaderText = "MICRON";
   			dataGridView8.Columns[4].HeaderText = "FILM";
   			dataGridView8.Columns[5].HeaderText = "GLUE";
   			dataGridView8.Columns[6].HeaderText = "LINER";
		}

		
		void DataGridView8CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
			 if(dataGridView8.SelectedRows.Count > 0) // make sure user select at least 1 row 
   			{

			       txtbx_refno.Text = dataGridView8.SelectedRows[0].Cells[0].Value + string.Empty;
			       txtbx_prodcode.Text = dataGridView8.SelectedRows[0].Cells[1].Value + string.Empty;
			       txtbx_desc1.Text = dataGridView8.SelectedRows[0].Cells[2].Value + string.Empty;
			       txtbx_thickness.Text = dataGridView8.SelectedRows[0].Cells[3].Value + string.Empty;
			       txtbx_filmcode.Text = dataGridView8.SelectedRows[0].Cells[4].Value + string.Empty;
			       txtbx_gluecode.Text = dataGridView8.SelectedRows[0].Cells[5].Value + string.Empty;
			       txtbx_linercode.Text = dataGridView8.SelectedRows[0].Cells[6].Value + string.Empty;
			       
  			}  
		}
		
		
		
		
		
		
		void Btn_saveClick(object sender, EventArgs e)
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
							cmdUpdateNextNumber.CommandText = "update TBL_ADMIN_NEXT_NUMBER set ProdSchwanerNextNumber = ProdSchwanerNextNumber + 1";
							cmdUpdateNextNumber.Connection = conUpdateNextNumber;
							conUpdateNextNumber.Open();
							cmdUpdateNextNumber.ExecuteNonQuery();
						} catch (Exception ex) {
							conUpdateNextNumber.Close();
							MessageBox.Show("Error Update Next Number!" + ex.ToString() + ex.Message); //Lbl_Message.Text = "Error Update Next Number! " + ex.ToString + ex.Message;
							return;
						} finally {
							conUpdateNextNumber.Close();
						}
						conUpdateNextNumber.Dispose();
						conUpdateNextNumber = null;
						cmdUpdateNextNumber = null;
			
			
			SqlConnection con_data_add = new SqlConnection (sqlconn);
				System.Data.SqlClient.SqlCommand cmd_data_add = new SqlCommand();  //adress pergi ke sql
				try {

						cmd_data_add.Connection = con_data_add;		//coman run store procedure
						cmd_data_add.CommandText = "SP_PROD_COAT_ALL_ITEM_SCHWANER_ADD";	//nama store procedure
						cmd_data_add.CommandType = CommandType.StoredProcedure;		//declare comand
    	
						cmd_data_add.Parameters.Add(new SqlParameter("@SP_REFNO", SqlDbType.Int)); //create parameter pada sql bwk data SP_RefNumber untuk dihantar semula
						cmd_data_add.Parameters["@SP_REFNO"].Value = NextNo;
				
						cmd_data_add.Parameters.Add(new SqlParameter("@SP_PRODUCTCODE", SqlDbType. NVarChar, 50)); //create parameter pada sql bwk data SP_RefNumber untuk dihantar semula
						cmd_data_add.Parameters["@SP_PRODUCTCODE"].Value = txtbx_prodcode.Text.ToUpper();
						
						cmd_data_add.Parameters.Add(new SqlParameter("@SP_DESC1", SqlDbType. NVarChar, 50)); //create parameter pada sql bwk data SP_RefNumber untuk dihantar semula
						cmd_data_add.Parameters["@SP_DESC1"].Value = txtbx_desc1.Text.ToUpper();

						cmd_data_add.Parameters.Add(new SqlParameter("@SP_DESC2", SqlDbType.NVarChar, 50)); //create parameter pada sql bwk data SP_RefNumber untuk dihantar semula
						cmd_data_add.Parameters["@SP_DESC2"].Value = txtbx_desc2.Text.ToUpper();
						
						cmd_data_add.Parameters.Add(new SqlParameter("@SP_FILMCODE", SqlDbType. NVarChar, 50)); //create parameter pada sql bwk data SP_RefNumber untuk dihantar semula
						cmd_data_add.Parameters["@SP_FILMCODE"].Value = txtbx_filmcode.Text.ToUpper();
						
						cmd_data_add.Parameters.Add(new SqlParameter("@SP_FILMDESC1", SqlDbType.NVarChar, 50));
						cmd_data_add.Parameters["@SP_FILMDESC1"].Value = txtbx_filmdesc1.Text.ToUpper();
						
						cmd_data_add.Parameters.Add(new SqlParameter("@SP_FILMWIDTH", SqlDbType.NVarChar, 50));
						cmd_data_add.Parameters["@SP_FILMWIDTH"].Value = txtbx_filmwidth.Text.ToUpper();
						
						cmd_data_add.Parameters.Add(new SqlParameter("@SP_GLUECODE", SqlDbType.NVarChar, 50));
						cmd_data_add.Parameters["@SP_GLUECODE"].Value = txtbx_gluecode.Text.ToUpper();
						
						
						
						cmd_data_add.Parameters.Add(new SqlParameter("@SP_GLUEDESC1", SqlDbType.NVarChar, 50));
						cmd_data_add.Parameters["@SP_GLUEDESC1"].Value = txtbx_gluedesc1.Text.ToUpper();
						
						cmd_data_add.Parameters.Add(new SqlParameter("@SP_GLUEWIDTH", SqlDbType.NVarChar, 50));
						cmd_data_add.Parameters["@SP_GLUEWIDTH"].Value = txtbx_gluwidth.Text.ToUpper();
						
						
						cmd_data_add.Parameters.Add(new SqlParameter("@SP_LINERCODE", SqlDbType.NVarChar, 50));
						cmd_data_add.Parameters["@SP_LINERCODE"].Value = txtbx_linercode.Text.ToUpper();
						
						
						cmd_data_add.Parameters.Add(new SqlParameter("@SP_LINERDESC1", SqlDbType.NVarChar, 50));
						cmd_data_add.Parameters["@SP_LINERDESC1"].Value = txtbx_linerdesc1.Text.ToUpper();
						
						cmd_data_add.Parameters.Add(new SqlParameter("@SP_LINERWIDTH", SqlDbType.Float));
						cmd_data_add.Parameters["@SP_LINERWIDTH"].Value = Convert.ToDouble(txtbx_linerwidth.Text);
						
						cmd_data_add.Parameters.Add(new SqlParameter("@SP_THICKNESSMICRON", SqlDbType.NVarChar, 50));
						cmd_data_add.Parameters["@SP_THICKNESSMICRON"].Value = txtbx_thickness.Text.ToUpper();
						
						
						
						cmd_data_add.Parameters.Add(new SqlParameter("@SP_COLOR", SqlDbType.NVarChar, 50));
						cmd_data_add.Parameters["@SP_COLOR"].Value = txtbx_color.Text.ToUpper();
						
						cmd_data_add.Parameters.Add(new SqlParameter("@SP_GLUEDRUMKG", SqlDbType.NVarChar, 50));
						cmd_data_add.Parameters["@SP_GLUEDRUMKG"].Value = txtbx_gluedrum.Text.ToUpper();
						
						cmd_data_add.Parameters.Add(new SqlParameter("@SP_REMARK", SqlDbType.NVarChar, 50));
						cmd_data_add.Parameters["@SP_REMARK"].Value = txtbx_remark.Text.ToUpper();
						
						cmd_data_add.Parameters.Add(new SqlParameter("@SP_GLUEUSEPERM2", SqlDbType.NVarChar, 50));
						cmd_data_add.Parameters["@SP_GLUEUSEPERM2"].Value = txtbx_useglue.Text.ToUpper();
	
		
						con_data_add.Open();
						cmd_data_add.ExecuteNonQuery();
						cmd_data_add.Parameters.Clear();
						
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
			DialogBox.ShowWarningMessage(" successfull add.");			
		}
		
		
	
		
		void Btn_deleteClick(object sender, EventArgs e)
		{
			
			
				SqlConnection con_data_del = new SqlConnection (sqlconn);
				System.Data.SqlClient.SqlCommand cmd_data_del = new SqlCommand();  //adress pergi ke sql
				try {

						cmd_data_del.Connection = con_data_del;		//coman run store procedure
						cmd_data_del.CommandText = "SP_PROD_COAT_ALL_ITEM_SCHWANER_DEL";	//nama store procedure
						cmd_data_del.CommandType = CommandType.StoredProcedure;		//declare comand
    	
						cmd_data_del.Parameters.Add(new SqlParameter("@SP_REFNO", SqlDbType.Int)); //create parameter pada sql bwk data SP_RefNumber untuk dihantar semula
						cmd_data_del.Parameters["@SP_REFNO"].Value =Convert.ToUInt32(txtbx_refno.Text);
				
						cmd_data_del.Parameters.Add(new SqlParameter("@SP_PRODUCTCODE", SqlDbType. NVarChar, 50)); //create parameter pada sql bwk data SP_RefNumber untuk dihantar semula
						cmd_data_del.Parameters["@SP_PRODUCTCODE"].Value = txtbx_prodcode.Text.ToUpper();
						
						cmd_data_del.Parameters.Add(new SqlParameter("@SP_DESC1", SqlDbType. NVarChar, 50)); //create parameter pada sql bwk data SP_RefNumber untuk dihantar semula
						cmd_data_del.Parameters["@SP_DESC1"].Value = txtbx_desc1.Text.ToUpper();

						cmd_data_del.Parameters.Add(new SqlParameter("@SP_DESC2", SqlDbType.NVarChar, 50)); //create parameter pada sql bwk data SP_RefNumber untuk dihantar semula
						cmd_data_del.Parameters["@SP_DESC2"].Value = txtbx_desc2.Text.ToUpper();
						
						cmd_data_del.Parameters.Add(new SqlParameter("@SP_FILMCODE", SqlDbType. NVarChar, 50)); //create parameter pada sql bwk data SP_RefNumber untuk dihantar semula
						cmd_data_del.Parameters["@SP_FILMCODE"].Value = txtbx_filmcode.Text.ToUpper();
						
						cmd_data_del.Parameters.Add(new SqlParameter("@SP_FILMDESC1", SqlDbType.NVarChar, 50));
						cmd_data_del.Parameters["@SP_FILMDESC1"].Value = txtbx_filmdesc1.Text.ToUpper();
						
						cmd_data_del.Parameters.Add(new SqlParameter("@SP_FILMWIDTH", SqlDbType.NVarChar, 50));
						cmd_data_del.Parameters["@SP_FILMWIDTH"].Value = txtbx_filmwidth.Text.ToUpper();
						
						cmd_data_del.Parameters.Add(new SqlParameter("@SP_GLUECODE", SqlDbType.NVarChar, 50));
						cmd_data_del.Parameters["@SP_GLUECODE"].Value = txtbx_gluecode.Text.ToUpper();
						
						
						
						cmd_data_del.Parameters.Add(new SqlParameter("@SP_GLUEDESC1", SqlDbType.NVarChar, 50));
						cmd_data_del.Parameters["@SP_GLUEDESC1"].Value = txtbx_gluedesc1.Text.ToUpper();
						
						cmd_data_del.Parameters.Add(new SqlParameter("@SP_GLUEWIDTH", SqlDbType.NVarChar, 50));
						cmd_data_del.Parameters["@SP_GLUEWIDTH"].Value = txtbx_gluwidth.Text.ToUpper();
						
						
						cmd_data_del.Parameters.Add(new SqlParameter("@SP_LINERCODE", SqlDbType.NVarChar, 50));
						cmd_data_del.Parameters["@SP_LINERCODE"].Value = txtbx_linercode.Text.ToUpper();
						
						
						cmd_data_del.Parameters.Add(new SqlParameter("@SP_LINERDESC1", SqlDbType.NVarChar, 50));
						cmd_data_del.Parameters["@SP_LINERDESC1"].Value = txtbx_linerdesc1.Text.ToUpper();
						
						cmd_data_del.Parameters.Add(new SqlParameter("@SP_LINERWIDTH", SqlDbType.Float));
						cmd_data_del.Parameters["@SP_LINERWIDTH"].Value = Convert.ToDouble(txtbx_linerwidth.Text);
						
						cmd_data_del.Parameters.Add(new SqlParameter("@SP_THICKNESSMICRON", SqlDbType.NVarChar, 50));
						cmd_data_del.Parameters["@SP_THICKNESSMICRON"].Value = txtbx_thickness.Text.ToUpper();
						
						
						
						cmd_data_del.Parameters.Add(new SqlParameter("@SP_COLOR", SqlDbType.NVarChar, 50));
						cmd_data_del.Parameters["@SP_COLOR"].Value = txtbx_color.Text.ToUpper();
						
						cmd_data_del.Parameters.Add(new SqlParameter("@SP_GLUEDRUMKG", SqlDbType.NVarChar, 50));
						cmd_data_del.Parameters["@SP_GLUEDRUMKG"].Value = txtbx_gluedrum.Text.ToUpper();
						
						cmd_data_del.Parameters.Add(new SqlParameter("@SP_REMARK", SqlDbType.NVarChar, 50));
						cmd_data_del.Parameters["@SP_REMARK"].Value = txtbx_remark.Text.ToUpper();
						
						cmd_data_del.Parameters.Add(new SqlParameter("@SP_GLUEUSEPERM2", SqlDbType.NVarChar, 50));
						cmd_data_del.Parameters["@SP_GLUEUSEPERM2"].Value = txtbx_useglue.Text.ToUpper();
	
		
						con_data_del.Open();
						cmd_data_del.ExecuteNonQuery();
						cmd_data_del.Parameters.Clear();
						
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
			DialogBox.ShowWarningMessage(" successfull del.");
			
		}
		
		
		
		void Button4Click(object sender, EventArgs e)
		{

			btn_delete.Visible = true;
			btn_save.Visible = true;
			if (txtbx_refno.Text == null | txtbx_refno.Text == string.Empty) 
			{
        		MessageBox.Show("Please key-in Ref No");
				return;
			}
			
			SqlConnection con_SP1 = new SqlConnection(sqlconn);
			SqlCommand cmd_SP1 = new SqlCommand();
			
			try 
			{
				cmd_SP1.CommandText = "select * from TBL_PROD_COAT_ALL_ITEM_SCHWANER where REFNO = '" + txtbx_refno.Text + "'";
				cmd_SP1.Connection = con_SP1;
				con_SP1.Open();
				SqlDataReader rd_SP1 = cmd_SP1.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
				
				if (rd_SP1.Read())
				{
				
					
					
						txtbx_refno.Text = rd_SP1["REFNO"].ToString();
						txtbx_prodcode.Text = rd_SP1["PRODUCTCODE"].ToString();
						txtbx_desc1.Text = rd_SP1["DESC1"].ToString();
						txtbx_desc2.Text = rd_SP1["DESC2"].ToString();
						txtbx_filmcode.Text = rd_SP1["FILMCODE"].ToString(); 
						txtbx_filmdesc1.Text = rd_SP1["FILMDESC1"].ToString();
						txtbx_filmwidth.Text = rd_SP1["FILMWIDTH"].ToString();
						txtbx_gluecode.Text = rd_SP1["GLUECODE"].ToString();
						txtbx_gluedesc1.Text = rd_SP1["GLUEDESC1"].ToString();
						txtbx_gluwidth.Text = rd_SP1["GLUEWIDTH"].ToString();
						txtbx_linercode.Text = rd_SP1["LINERCODE"].ToString();
						txtbx_linerdesc1.Text = rd_SP1["LINERDESC1"].ToString();
						txtbx_linerwidth.Text = rd_SP1["LINERWIDTH"].ToString();
						txtbx_thickness.Text = rd_SP1["THICKNESSMICRON"].ToString();
						txtbx_color.Text = rd_SP1["COLOR"].ToString();
						txtbx_gluedrum.Text = rd_SP1["GLUEDRUMKG"].ToString();
						txtbx_remark.Text = rd_SP1["REMARK"].ToString();
						txtbx_useglue.Text = rd_SP1["GLUEUSEPERM2"].ToString();
					
//--------------------------------------------------------------------------------------------			
				} 
				else 
				{
					MessageBox.Show("Error Edit : Cannot find REF NO!");
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
		
		void Btn_clearClick(object sender, EventArgs e)
		{
			txtbx_refno.Clear();
			txtbx_prodcode.Clear();
			txtbx_desc1.Clear();
			txtbx_desc2.Clear();
			txtbx_filmcode.Clear();
			txtbx_filmdesc1.Clear();
			txtbx_filmwidth.Clear();
			txtbx_gluecode.Clear();
			txtbx_gluedesc1.Clear();
			txtbx_gluwidth.Clear();
			txtbx_linercode.Clear();
			txtbx_linerdesc1.Clear();
			txtbx_linerwidth.Clear();
			txtbx_thickness.Clear();
			txtbx_color.Clear();
			txtbx_gluedrum.Clear();
			txtbx_remark.Clear();
			txtbx_useglue.Clear();
		}
		
		void Button3Click(object sender, EventArgs e)
		{
//			DialogResult cancel = new DialogResult();
//            cancel = MessageBox.Show("Are you sure to exit?", "Cancel", 
//                     MessageBoxButtons.YesNo, 
//                     MessageBoxIcon.Warning, 
//                     MessageBoxDefaultButton.Button3);
//            if (cancel == DialogResult.Yes)
                //Application.Exit();
            	this.Close();
		}
		
		
	}
}
