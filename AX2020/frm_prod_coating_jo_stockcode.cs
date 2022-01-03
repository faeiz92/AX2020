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
using System.IO;
using fyiReporting.RdlViewer;
using fyiReporting;
using System.Text.RegularExpressions;


namespace AX2020
{
	public partial class frm_prod_coating_jo_stockcode : Form
	{
		public static string sqlconn = "Server=AX-UAT; Password=sbax2020sbg; User ID=sbax2020; Initial Catalog=SBG_AX_2020; Integrated Security=false";
		
		public static string sqlconn2 = "Server=AX-UAT; Password=sbax2020sbg; User ID=sbax2020; Initial Catalog=MyProductionTrack; Integrated Security=false";
		
		public static string sqlconn3 = "Server=AX-SQL; Password=ax2020sbgroup; User ID=ax2020sb; Initial Catalog=AX2020StagingDB; Integrated Security=false";

		public static string Sqlconn = "DSN=eb9gf;Port=2138;Uid=dba;Pwd=sql";
		
		double avgmicron2 = 0;
		double totalglue = 0;
		bool check = false;
		bool checkstore = false;
		string username, refno;
		string twoWords, soline;
		int NextNo2;
		string joshipmark_line;
	    string contentAfterLastHyphen;
			    
		//txtbx_refno.Text = "0";

		
		public frm_prod_coating_jo_stockcode()	//function y terdapat dalam form
		{
			InitializeComponent();
			//PRODUCT_CODE_OPTION();
			this.ControlBox = false;
			JrCategory();
			BOPPFilmList();
			//Unable_Edit();
			
			btn_delete.Visible = false;
			btn_save.Visible = false;
			txtbx_jrm2.Text = "0";
			txtbx_qtyorder.Text = "0";
			username = frm_menu_system.userName; 
			lbl_username.Text = "User : " + username;
			txtbx_refno.Text = "0";
			datagrid();

			//TextboxValue();
			
		}
			
//		public void Unable_Edit()
//		{
//			
//			txtbx_bopp_micron.Enabled = false;
//			txtbx_bopp_width.Enabled = false;
//			txtbx_bopp_length.Enabled = false;
//			txtbx_brand.Enabled = false;
//			txtbx_customertype.Enabled = false;
//			txtbx_jrwidth.Enabled = false;
//			txtbx_jrlength.Enabled = false;
//			txtbx_colour.Enabled = false;
//			txtbx_wtfilm.Enabled = false;
//			txtbx_wtglue.Enabled = false;
//			txtbx_total1.Enabled = false;
//			txtbx_core.Enabled = false;
//			txtbx_total2.Enabled = false;
//			txtbx_totalfinal.Enabled = false;
//			txtbx_packing.Enabled = false;
//			txtbx_productwidth.Enabled = false;
//			txtbx_productlength.Enabled = false;
//			txtbx_kgmin.Enabled = false;
//			//txtbx_kgmax.Enabled = false;
//			txtbx_gluemicron.Enabled = false;
//			txtbx_gluewidth.Enabled = false;
//		}
		
		//=========================================================================================
			
		public void Enable_Edit()
		{
			
			txtbx_bopp_micron.Enabled = true;
			txtbx_bopp_width.Enabled = true;
			txtbx_bopp_length.Enabled = true;
			txtbx_brand.Enabled = true;
			txtbx_customertype.Enabled = true;
			txtbx_jrwidth.Enabled = true;
			txtbx_jrlength.Enabled = true;
			txtbx_colour.Enabled = true;
			txtbx_wtfilm.Enabled = true;
			txtbx_wtglue.Enabled = true;
			txtbx_total1.Enabled = true;
			txtbx_core.Enabled = true;
			txtbx_total2.Enabled = true;
			txtbx_totalfinal.Enabled = true;
			txtbx_packing.Enabled = true;
			txtbx_productwidth.Enabled = true;
			txtbx_productlength.Enabled = true;
			txtbx_kgmin.Enabled = true;
			txtbx_gluemicron.Enabled = true;
			txtbx_gluewidth.Enabled = true;
			txtbx_micmax.Enabled = true;
			combobx_category.Enabled = true;
		}
		
		//=========================================================================================
			
		public void BOPPFilmList()	//hanya untuk dropdown
		{
			string sqlStatement = "select StockCode from TBL_PROD_COAT_BOPP_FILM_LIST";
			SqlConnection sqlConn = new SqlConnection(sqlconn);
			DataSet ds = new DataSet();
			SqlDataAdapter sda = new SqlDataAdapter(sqlStatement, sqlConn);
					
			try 
			{		
				sqlConn.Open();
				sda.Fill(ds);
				combo_box3.Text = "Please Select";
						
			}
			catch (Exception exc) 
			{
				DialogBox.ShowWarningMessage("An error occured while connecting to database" + exc.Message+ exc.ToString());
				sqlConn.Close();
				sqlConn.Dispose();
				return;
			} 
			finally 
			{
				sqlConn.Close();
				sqlConn.Dispose();
			}
		
			foreach(DataRow dr1 in ds.Tables[0].Rows)
			{
				combo_box3.Items.Add(dr1["StockCode"].ToString());
			}
				
		}
		
		
		
//		   if (CommonValidation.ValidateIsEmptyString(txtbx_refno.Text.Trim()))
//	                {
//	                    DialogBox.ShowWarningMessage(txtbx_refno.Text + " cannot be empty.");
//	                    txtbx_refno.Focus();
//	                    return false;
//	                }
		
		//-=========================================================================================
		
		void Btn_saveClick(object sender, EventArgs e)
		{
			if (!Validation())
				return;
			
			
			int tester;
			if (!Int32.TryParse(txtbx_extrameter.Text.Trim(), out tester))
			{
				DialogBox.ShowWarningMessage(txtbx_extrameter.Text.Trim() + "  Extra Meter Only can Input Number!");
	            txtbx_extrameter.Focus();
	            return;
			}
			         
	               
			joshipmark_line = txtbx_smarkcode.Text +"-"+ txtbx_smarkicode.Text;
			btn_stockcode.Visible = true;
			
			
			
			if (TxtBx_StockCode1.Text.ToUpper().Substring(0,4) =="WJ-P" || TxtBx_StockCode1.Text.ToUpper().Substring(0,3) == "WP1" || TxtBx_StockCode1.Text.ToUpper().Substring(0,3) == "WP2")
			{
			
				SqlConnection con_Check_Jodoc_Printing = new SqlConnection(sqlconn);
				SqlCommand cmd2 = new SqlCommand();
							
							
				try 
				{
					cmd2.CommandText = "select * from TBL_PROD_COAT_PRINTING_JOB_ORDER where JODOCNO = '" + txtbx_jo_printing.Text.ToUpper() +  "'";
					cmd2.Connection = con_Check_Jodoc_Printing;
					con_Check_Jodoc_Printing.Open();
					SqlDataReader rd_Check_Jodoc_Printing = cmd2.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
					
					if (rd_Check_Jodoc_Printing.Read())
					{
						if (rd_Check_Jodoc_Printing.HasRows) 
						{
							MessageBox.Show("CAN SAVE, JOB ORDER NUMBERS PRINTING EXIST");//Lbl_Message.Text = "Error 1.0 : Duplicate JO! ";
							//return;
						}											
					}		
					else			
					{
						DialogBox.ShowWarningMessage("CAN'T SAVE, JOB ORDER NUMBERS PRINTING ARE NOT EXIST");//Lbl_Message.Text = "Error 1.0 : Duplicate JO! ";	
						return;
					}
				
				} 
				catch (Exception ex) 
				{
					con_Check_Jodoc_Printing.Close();
					MessageBox.Show("Error 2.0 : Duplicate JO!" + ex.ToString() + ex.Message);
					return;
				} 
				finally 
				{
					con_Check_Jodoc_Printing.Close();
				}
				
				con_Check_Jodoc_Printing.Dispose();
				cmd2.Dispose();
				con_Check_Jodoc_Printing = null;
				cmd2 = null;
								
			}
			
			//---------------------------------------------------------------------------------------
			
			SqlConnection con_Check_Duplicate_ShipMark = new SqlConnection(sqlconn2);
			SqlCommand cmd = new SqlCommand();
																
								
			try 
			{
				cmd.CommandText = "select * from JO_TRX where TrxShipMark like '" + joshipmark_line.ToUpper() +  "%'";
				cmd.Connection = con_Check_Duplicate_ShipMark;
				con_Check_Duplicate_ShipMark.Open();
				SqlDataReader rd_Check_Duplicate_ShipMark = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
		
				if (rd_Check_Duplicate_ShipMark.Read())
				{
					if (rd_Check_Duplicate_ShipMark.HasRows) 
					{
						MessageBox.Show("CAN'T PROCEED WITH THIS JO, BECAUSE DUPLICATE SHIPPING MARK");//Lbl_Message.Text = "Error 1.0 : Duplicate JO! ";
						return;
					}
				}
			} 
			catch (Exception ex) 
			{
				con_Check_Duplicate_ShipMark.Close();
				MessageBox.Show("Error 2.0 : Duplicate JO!" + ex.ToString() + ex.Message);
				return;
			}	
			finally 
			{
				con_Check_Duplicate_ShipMark.Close();
			}
			
			con_Check_Duplicate_ShipMark.Dispose();
			cmd.Dispose();
			con_Check_Duplicate_ShipMark = null;
			cmd = null;
			
			
			if (check == false)	
			{
				NextNumberRetrieve();			
			}
			
//			if (checkstore == true)
//			{
//				NextNumberStore();
//			}
			
			// Button btn = sender as Button;
			 //Button btn3 = sender as Button;
			// if ( txtbx_joso.Text !=null || txtbx_soline.Text !=null|| txtbx_refno.Text !=null )

			
			SqlConnection con_data_add = new SqlConnection(sqlconn);
			System.Data.SqlClient.SqlCommand cmd_data_add = new SqlCommand();  //adress pergi ke sql
			
			try
			{
				cmd_data_add.Connection = con_data_add;		//coman run store procedure
				
				if (check == true)// && checkstore ==true)	
				{
					cmd_data_add.CommandText = "SP_PROD_COAT_JO_ADD_R2_EDIT";
	 
				}	
				else
				{
					cmd_data_add.CommandText = "SP_PROD_COAT_JO_ADD_R2";	
				}	//nama store procedure
					
					
						
				cmd_data_add.CommandType = CommandType.StoredProcedure;	
				//declare comand
				
				cmd_data_add.Parameters.Add(new SqlParameter("@SP_ETDDATETIME", SqlDbType.DateTime)); //create parameter pada sql bwk data SP_RefNumber untuk dihantar semula
				cmd_data_add.Parameters["@SP_ETDDATETIME"].Value = dateTimePicker1.Value;
		
				cmd_data_add.Parameters.Add(new SqlParameter("@SP_JODOCNO", SqlDbType. NVarChar, 50)); //create parameter pada sql bwk data SP_RefNumber untuk dihantar semula
				cmd_data_add.Parameters["@SP_JODOCNO"].Value = txtbx_refno.Text.ToUpper();
				
				cmd_data_add.Parameters.Add(new SqlParameter("@SP_JODOCNO_PRINTING", SqlDbType. NVarChar, 50)); //create parameter pada sql bwk data SP_RefNumber untuk dihantar semula
				cmd_data_add.Parameters["@SP_JODOCNO_PRINTING"].Value = txtbx_jo_printing.Text.ToUpper();
				
				
				//if (txtbx_joso.Text.Substring(0,2) =="WJ")
				//{
//						cmd_data_add.Parameters.Add(new SqlParameter("@SP_JOSALESNO", SqlDbType. NVarChar, 50)); //create parameter pada sql bwk data SP_RefNumber untuk dihantar semula
//						cmd_data_add.Parameters["@SP_JOSALESNO"].Value = txtbx_joso.Text.ToUpper();							;
				
				
				
				cmd_data_add.Parameters.Add(new SqlParameter("@SP_JOSALESNO", SqlDbType. NVarChar, 50)); //create parameter pada sql bwk data SP_RefNumber untuk dihantar semula
				cmd_data_add.Parameters["@SP_JOSALESNO"].Value = txtbx_refno.Text.ToUpper();
							
				
				cmd_data_add.Parameters.Add(new SqlParameter("@SP_JOSALESLINE", SqlDbType. NVarChar, 50)); //create parameter pada sql bwk data SP_RefNumber untuk dihantar semula
				cmd_data_add.Parameters["@SP_JOSALESLINE"].Value = "0";
				
				
				cmd_data_add.Parameters.Add(new SqlParameter("@SP_JOSTOCKCODE", SqlDbType.NVarChar, 50));
				cmd_data_add.Parameters["@SP_JOSTOCKCODE"].Value = txtbx_refno.Text.ToUpper();
				
				cmd_data_add.Parameters.Add(new SqlParameter("@SP_JRSTOCKCODE", SqlDbType.NVarChar, 50));
				cmd_data_add.Parameters["@SP_JRSTOCKCODE"].Value = TxtBx_StockCode1.Text.ToUpper();
				
				cmd_data_add.Parameters.Add(new SqlParameter("@SP_JOSTOCKDESC", SqlDbType.NVarChar, 50));
				cmd_data_add.Parameters["@SP_JOSTOCKDESC"].Value = txtbx_sodesc1.Text.ToUpper();
				
				cmd_data_add.Parameters.Add(new SqlParameter("@SP_JOSTOCKDESC2", SqlDbType.NVarChar, 50));
				cmd_data_add.Parameters["@SP_JOSTOCKDESC2"].Value = txtbx_sodesc2.Text.ToUpper();
				
				cmd_data_add.Parameters.Add(new SqlParameter("@SP_JOSTOCKCOLOR", SqlDbType.NVarChar, 50));
				cmd_data_add.Parameters["@SP_JOSTOCKCOLOR"].Value=txtbx_colour.Text.ToUpper();  //tukar daripada string kepada nombor
				
				cmd_data_add.Parameters.Add(new SqlParameter("@SP_JRCOLOR", SqlDbType.NVarChar, 50));
				cmd_data_add.Parameters["@SP_JRCOLOR"].Value = TxtBx_JRColor1.Text.ToUpper();  //tukar daripada string kepada nom
				
				cmd_data_add.Parameters.Add(new SqlParameter("@SP_JOSTOCKBRAND", SqlDbType.NVarChar, 50));
				cmd_data_add.Parameters["@SP_JOSTOCKBRAND"].Value=txtbx_brand.Text.ToUpper(); 
				
				cmd_data_add.Parameters.Add(new SqlParameter("@SP_JOSMARKCODE", SqlDbType.NVarChar, 50));
				cmd_data_add.Parameters["@SP_JOSMARKCODE"].Value=txtbx_smarkcode.Text.ToUpper(); 
				
				cmd_data_add.Parameters.Add(new SqlParameter("@SP_JOSHIPMARK", SqlDbType.NVarChar, 20));
				cmd_data_add.Parameters["@SP_JOSHIPMARK"].Value=""; 
				
				cmd_data_add.Parameters.Add(new SqlParameter("@SP_JOJRCATEGORY", SqlDbType.NVarChar, 50));
				cmd_data_add.Parameters["@SP_JOJRCATEGORY"].Value = combobx_category.Text;
				
				cmd_data_add.Parameters.Add(new SqlParameter("@SP_JOSMARKLINE", SqlDbType.NVarChar, 50));
				cmd_data_add.Parameters["@SP_JOSMARKLINE"].Value=txtbx_smarkicode.Text.ToUpper(); 
				
				cmd_data_add.Parameters.Add(new SqlParameter("@SP_JOSTOCKWIDTH", SqlDbType.Float));
				cmd_data_add.Parameters["@SP_JOSTOCKWIDTH"].Value = Convert.ToDouble(txtbx_jrwidth.Text);
				
				cmd_data_add.Parameters.Add(new SqlParameter("@SP_JOCOSTGLUE", SqlDbType.Float));
				cmd_data_add.Parameters["@SP_JOCOSTGLUE"].Value = Convert.ToDouble(txtbx_costglue.Text);
				
				cmd_data_add.Parameters.Add(new SqlParameter("@SP_JOCOSTFILM", SqlDbType.Float));
				cmd_data_add.Parameters["@SP_JOCOSTFILM"].Value = Convert.ToDouble(txtbx_costfilm.Text);
				
				cmd_data_add.Parameters.Add(new SqlParameter("@SP_JOCOSTCONV", SqlDbType.Float));
				cmd_data_add.Parameters["@SP_JOCOSTCONV"].Value = Convert.ToDouble(txtbx_costconvert.Text);
				
				cmd_data_add.Parameters.Add(new SqlParameter("@SP_JOCOSTSERVICE", SqlDbType.Float));
				cmd_data_add.Parameters["@SP_JOCOSTSERVICE"].Value = Convert.ToDouble(txtbx_costservice.Text);
				
				cmd_data_add.Parameters.Add(new SqlParameter("@SP_JOSTOCKLENGTH", SqlDbType.Float));
				cmd_data_add.Parameters["@SP_JOSTOCKLENGTH"].Value = Convert.ToDouble(txtbx_jrlength.Text);
				
				//MessageBox.Show(txtbx
				
				//TUKAR QTY ORDERED KEPADA JO JR QTY
			
				cmd_data_add.Parameters.Add(new SqlParameter("@SP_JOSTOCKMICRON", SqlDbType.Float));
				cmd_data_add.Parameters["@SP_JOSTOCKMICRON"].Value = Convert.ToDouble(txtbx_micron.Text);
				
				cmd_data_add.Parameters.Add(new SqlParameter("@SP_JOSTOCKMICRONM2", SqlDbType.NVarChar, 50));
				cmd_data_add.Parameters["@SP_JOSTOCKMICRONM2"].Value = txtbx_M2.Text.ToUpper(); 
		
				
				cmd_data_add.Parameters.Add(new SqlParameter("@SP_JOJRM2", SqlDbType.Float));
				cmd_data_add.Parameters["@SP_JOJRM2"].Value =Convert.ToDouble(txtbx_jrm2.Text);
				
				cmd_data_add.Parameters.Add(new SqlParameter("@SP_PRODUCTWIDTH", SqlDbType.Float));
				cmd_data_add.Parameters["@SP_PRODUCTWIDTH"].Value =Convert.ToDouble(txtbx_productwidth.Text);
				
				cmd_data_add.Parameters.Add(new SqlParameter("@SP_PRODUCTLENGTH", SqlDbType.Float));
				cmd_data_add.Parameters["@SP_PRODUCTLENGTH"].Value =Convert.ToDouble(txtbx_productlength.Text);
				
				cmd_data_add.Parameters.Add(new SqlParameter("@SP_JOSTOCKMICRONMIN", SqlDbType.Float));
				cmd_data_add.Parameters["@SP_JOSTOCKMICRONMIN"].Value = Convert.ToDouble(txtbx_minimummic.Text);

	

				cmd_data_add.Parameters.Add(new SqlParameter("@SP_JOSTOCKMICRONMAX", SqlDbType.Float));
				cmd_data_add.Parameters["@SP_JOSTOCKMICRONMAX"].Value = Convert.ToDouble(txtbx_micmax.Text);

				cmd_data_add.Parameters.Add(new SqlParameter("@SP_JOSTOCKKGMIN", SqlDbType.Float));
				cmd_data_add.Parameters["@SP_JOSTOCKKGMIN"].Value = Convert.ToDouble(txtbx_kgmin.Text);
			
				cmd_data_add.Parameters.Add(new SqlParameter("@SP_JOSTOCKKGMAX", SqlDbType.Float));
				cmd_data_add.Parameters["@SP_JOSTOCKKGMAX"].Value = Convert.ToDouble(txtbx_totalkg.Text);
				
				cmd_data_add.Parameters.Add(new SqlParameter("@SP_JOQTY", SqlDbType.Float));
				cmd_data_add.Parameters["@SP_JOQTY"].Value = Convert.ToDouble(txtbx_qtyorder.Text);
				
				cmd_data_add.Parameters.Add(new SqlParameter("@SP_JOCUSTOMER", SqlDbType.NVarChar, 50));
				cmd_data_add.Parameters["@SP_JOCUSTOMER"].Value = txtbx_socustomer.Text.ToUpper();
				
				cmd_data_add.Parameters.Add(new SqlParameter("@SP_JOCUSTOMERTYPE", SqlDbType.NVarChar, 50));
				cmd_data_add.Parameters["@SP_JOCUSTOMERTYPE"].Value = txtbx_customertype.Text.ToUpper();
				
				cmd_data_add.Parameters.Add(new SqlParameter("@SP_JOGLUECODE", SqlDbType.NVarChar, 50));
				cmd_data_add.Parameters["@SP_JOGLUECODE"].Value = txtbx_gluecode.Text.ToUpper();
		
				cmd_data_add.Parameters.Add(new SqlParameter("@SP_JOGLUEWIDTH", SqlDbType.Float));
				cmd_data_add.Parameters["@SP_JOGLUEWIDTH"].Value = Convert.ToDouble(txtbx_gluewidth.Text);
	
				cmd_data_add.Parameters.Add(new SqlParameter("@SP_JOGLUELENGTH", SqlDbType.Float));
				cmd_data_add.Parameters["@SP_JOGLUELENGTH"].Value = Convert.ToDouble(txtbx_bopp_length.Text);
				
				cmd_data_add.Parameters.Add(new SqlParameter("@SP_JOGLUEMICRON", SqlDbType.Float));
				cmd_data_add.Parameters["@SP_JOGLUEMICRON"].Value = Convert.ToDouble(txtbx_gluemicron.Text);
			
				cmd_data_add.Parameters.Add(new SqlParameter("@SP_JOGLUEKG", SqlDbType.Float));
				cmd_data_add.Parameters["@SP_JOGLUEKG"].Value = Convert.ToDouble(txtbx_gluemicron.Text);

				cmd_data_add.Parameters.Add(new SqlParameter("@SP_JOFILMCODE", SqlDbType.NVarChar, 50));
				cmd_data_add.Parameters["@SP_JOFILMCODE"].Value = combo_box3.Text;

				cmd_data_add.Parameters.Add(new SqlParameter("@SP_JOFILMWIDTH", SqlDbType.Float));
				cmd_data_add.Parameters["@SP_JOFILMWIDTH"].Value =Convert.ToDouble(txtbx_bopp_width.Text);
				                        
				cmd_data_add.Parameters.Add(new SqlParameter("@SP_JOFILMLENGTH", SqlDbType.Float));
				cmd_data_add.Parameters["@SP_JOFILMLENGTH"].Value = Convert.ToDouble(txtbx_bopp_length.Text);


				cmd_data_add.Parameters.Add(new SqlParameter("@SP_JOFILMMICRON", SqlDbType.NVarChar, 50));
				cmd_data_add.Parameters["@SP_JOFILMMICRON"].Value = txtbx_bopp_micron.Text.ToUpper();
				
				cmd_data_add.Parameters.Add(new SqlParameter("@SP_JOFILMKG", SqlDbType.Float));
				cmd_data_add.Parameters["@SP_JOFILMKG"].Value = Convert.ToDouble(txtbx_bopp_micron.Text);

				cmd_data_add.Parameters.Add(new SqlParameter("@SP_JOPRODDATE", SqlDbType.DateTime)); //create parameter pada sql bwk data SP_RefNumber untuk dihantar semula
				cmd_data_add.Parameters["@SP_JOPRODDATE"].Value = dateTimePicker1.Value;
				
				cmd_data_add.Parameters.Add(new SqlParameter("@SP_JOPRODOPERATOR", SqlDbType.NVarChar, 50));
				cmd_data_add.Parameters["@SP_JOPRODOPERATOR"].Value = "0";
				
				cmd_data_add.Parameters.Add(new SqlParameter("@SP_JOPRODHELPER", SqlDbType.NVarChar, 50));
				cmd_data_add.Parameters["@SP_JOPRODHELPER"].Value = "0";
				
				cmd_data_add.Parameters.Add(new SqlParameter("@SP_JOPRODQTY", SqlDbType.Float));
				cmd_data_add.Parameters["@SP_JOPRODQTY"].Value = Convert.ToDouble(txtbx_jojrqty.Text);
				
				cmd_data_add.Parameters.Add(new SqlParameter("@SP_JOPRODLOTNO", SqlDbType.NVarChar, 50));
				cmd_data_add.Parameters["@SP_JOPRODLOTNO"].Value ="0";
				
				cmd_data_add.Parameters.Add(new SqlParameter("@SP_JOPRODBATCHNO", SqlDbType.NVarChar, 50));
				cmd_data_add.Parameters["@SP_JOPRODBATCHNO"].Value = "0";
				
				cmd_data_add.Parameters.Add(new SqlParameter("@SP_JOPRODMACHINENO", SqlDbType.NVarChar, 50));
				cmd_data_add.Parameters["@SP_JOPRODMACHINENO"].Value = "0";
				
				cmd_data_add.Parameters.Add(new SqlParameter("@SP_JOEXTRAMETER", SqlDbType.NVarChar, 50));
				cmd_data_add.Parameters["@SP_JOEXTRAMETER"].Value = txtbx_extrameter.Text.ToUpper();

				cmd_data_add.Parameters.Add(new SqlParameter("@SP_JOREMARK1", SqlDbType.NVarChar, 250));
				cmd_data_add.Parameters["@SP_JOREMARK1"].Value = txtbx_remark1.Text.ToUpper();
				
				cmd_data_add.Parameters.Add(new SqlParameter("@SP_JOREMARK2", SqlDbType.NVarChar, 50));
				cmd_data_add.Parameters["@SP_JOREMARK2"].Value = "";
				
				cmd_data_add.Parameters.Add(new SqlParameter("@SP_JOREMARK3", SqlDbType.NVarChar, 50));
				cmd_data_add.Parameters["@SP_JOREMARK3"].Value = "";
				
				cmd_data_add.Parameters.Add(new SqlParameter("@SP_JOREMARK4", SqlDbType.NVarChar, 50));
				cmd_data_add.Parameters["@SP_JOREMARK4"].Value = "";
				
				cmd_data_add.Parameters.Add(new SqlParameter("@SP_JOREMARK5", SqlDbType.NVarChar, 50));
				cmd_data_add.Parameters["@SP_JOREMARK5"].Value = "";
				
				cmd_data_add.Parameters.Add(new SqlParameter("@SP_JOREMARK6", SqlDbType.NVarChar, 50));
				cmd_data_add.Parameters["@SP_JOREMARK6"].Value = txtbx_remark6.Text.ToUpper();
				
				cmd_data_add.Parameters.Add(new SqlParameter("@SP_JOREMARK7", SqlDbType.NVarChar, 250));
				cmd_data_add.Parameters["@SP_JOREMARK7"].Value = txtbx_remark7.Text.ToUpper();
				
				cmd_data_add.Parameters.Add(new SqlParameter("@SP_JOREMARK8", SqlDbType.NVarChar, 50));
				cmd_data_add.Parameters["@SP_JOREMARK8"].Value = "";
				
				cmd_data_add.Parameters.Add(new SqlParameter("@SP_JOREMARK9", SqlDbType.NVarChar, 50));
				cmd_data_add.Parameters["@SP_JOREMARK9"].Value = "";
				
				cmd_data_add.Parameters.Add(new SqlParameter("@SP_JOREMARK10", SqlDbType.NVarChar, 50));
				cmd_data_add.Parameters["@SP_JOREMARK10"].Value = "";
				
				cmd_data_add.Parameters.Add(new SqlParameter("@SP_JOREMARK", SqlDbType.NVarChar, 50));
				cmd_data_add.Parameters["@SP_JOREMARK"].Value ="0";
				
				cmd_data_add.Parameters.Add(new SqlParameter("@SP_JOSO", SqlDbType.NVarChar, 50));
				cmd_data_add.Parameters["@SP_JOSO"].Value ="0";
				
				cmd_data_add.Parameters.Add(new SqlParameter("@SP_JOISSUEBY", SqlDbType.NVarChar, 50));
				cmd_data_add.Parameters["@SP_JOISSUEBY"].Value =username.ToUpper();

				cmd_data_add.Parameters.Add(new SqlParameter("@SP_JOWTGLUE", SqlDbType.Float));
				cmd_data_add.Parameters["@SP_JOWTGLUE"].Value = Convert.ToDouble(txtbx_wtglue.Text);
				
				cmd_data_add.Parameters.Add(new SqlParameter("@SP_JOWTFILM", SqlDbType.Float));
				cmd_data_add.Parameters["@SP_JOWTFILM"].Value = Convert.ToDouble(txtbx_wtfilm.Text);
				
				cmd_data_add.Parameters.Add(new SqlParameter("@SP_JOWTTOTAL1", SqlDbType.Float));
				cmd_data_add.Parameters["@SP_JOWTTOTAL1"].Value = Convert.ToDouble(txtbx_total1.Text);

				cmd_data_add.Parameters.Add(new SqlParameter("@SP_JOWTCORE", SqlDbType.Float));
				cmd_data_add.Parameters["@SP_JOWTCORE"].Value = Convert.ToDouble(txtbx_core.Text);


				cmd_data_add.Parameters.Add(new SqlParameter("@SP_JOWTTOTAL2", SqlDbType.Float));
				cmd_data_add.Parameters["@SP_JOWTTOTAL2"].Value = Convert.ToDouble(txtbx_total2.Text);

				cmd_data_add.Parameters.Add(new SqlParameter("@SP_JOWTPACK", SqlDbType.Float));
				cmd_data_add.Parameters["@SP_JOWTPACK"].Value = Convert.ToDouble(txtbx_packing.Text);
				
				cmd_data_add.Parameters.Add(new SqlParameter("@SP_JOWTTOTAL3", SqlDbType.Float));
				cmd_data_add.Parameters["@SP_JOWTTOTAL3"].Value = Convert.ToDouble(txtbx_totalfinal.Text);
				
				
				
				cmd_data_add.Parameters.Add(new SqlParameter("@SP_JOPPCODE", SqlDbType.NVarChar, 80));
				cmd_data_add.Parameters["@SP_JOPPCODE"].Value ="0";
				
				cmd_data_add.Parameters.Add(new SqlParameter("@SP_JOPPTOLUNE", SqlDbType.NVarChar, 80));
				cmd_data_add.Parameters["@SP_JOPPTOLUNE"].Value = "0";

				cmd_data_add.Parameters.Add(new SqlParameter("@SP_JOPPWording", SqlDbType.NVarChar, 80));
				cmd_data_add.Parameters["@SP_JOPPWording"].Value = "0"; // "-"
				
				cmd_data_add.Parameters.Add(new SqlParameter("@SP_JOPPFilmSize", SqlDbType.NVarChar, 80));
				cmd_data_add.Parameters["@SP_JOPPFilmSize"].Value = "0";
				
				cmd_data_add.Parameters.Add(new SqlParameter("@SP_JOPPColor", SqlDbType.NVarChar, 80));
				cmd_data_add.Parameters["@SP_JOPPColor"].Value = "0";
				
				cmd_data_add.Parameters.Add(new SqlParameter("@SP_JOPPSizeArt", SqlDbType.NVarChar, 80));
				cmd_data_add.Parameters["@SP_JOPPSizeArt"].Value = "0";
				
				cmd_data_add.Parameters.Add(new SqlParameter("@SP_JOPPColorKG", SqlDbType.NVarChar, 80));
				cmd_data_add.Parameters["@SP_JOPPColorKG"].Value = "0";
				
				cmd_data_add.Parameters.Add(new SqlParameter("@SP_JOPPRemark", SqlDbType.NVarChar, 80));
				cmd_data_add.Parameters["@SP_JOPPRemark"].Value = "0";
				
				cmd_data_add.Parameters.Add(new SqlParameter("@SP_JOPPDate", SqlDbType.NVarChar, 80));
				cmd_data_add.Parameters["@SP_JOPPDate"].Value = DateTime.Now.Date;

				cmd_data_add.Parameters.Add(new SqlParameter("@SP_JOUSER", SqlDbType.NVarChar, 50));
				cmd_data_add.Parameters["@SP_JOUSER"].Value = "0";

				cmd_data_add.Parameters.Add(new SqlParameter("@SP_JOUSEREMAIL", SqlDbType.NVarChar, 50));
				cmd_data_add.Parameters["@SP_JOUSEREMAIL"].Value = frm_menu_system.email;
				

				
				cmd_data_add.Parameters.Add(new SqlParameter("@SP_JOUSERPC", SqlDbType.NVarChar, 50));
				cmd_data_add.Parameters["@SP_JOUSERPC"].Value =frm_menu_system.ipAddress;

				cmd_data_add.Parameters.Add(new SqlParameter("@SP_JOUSERDATETIME", SqlDbType.DateTime));
				cmd_data_add.Parameters["@SP_JOUSERDATETIME"].Value =DateTime.Now.Date; //"2016-11-28";//dateTimePicker1.Value.Date;

				cmd_data_add.Parameters.Add(new SqlParameter("@SP_JOUSERREVISION", SqlDbType.NVarChar, 50));
				cmd_data_add.Parameters["@SP_JOUSERREVISION"].Value = "0";
				
				//double avgmicron;
				avgmicron2 = Convert.ToDouble((Convert.ToDouble(txtbx_minimummic.Text) + Convert.ToDouble(txtbx_micmax.Text)) / 2);

				cmd_data_add.Parameters.Add(new SqlParameter("@SP_AVERAGEMICRON", SqlDbType.Float));
				cmd_data_add.Parameters["@SP_AVERAGEMICRON"].Value = avgmicron2;
				

				cmd_data_add.Parameters.Add(new SqlParameter("@SP_JOTOTALGLUE", SqlDbType.Float));
				cmd_data_add.Parameters["@SP_JOTOTALGLUE"].Value = totalglue;	


				//cmd_data_add.Parameters.Add(new SqlParameter("@SP_JOSHIPMARK", SqlDbType.NVarChar, 20));
				//cmd_data_add.Parameters["@SP_JOSHIPMARK"].Value = "";						

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
			con_data_add = null;
			
			
			DialogBox.ShowWarningMessage("SUCCESFULL SAVE");
			
			SqlConnection con_data_add2 = new SqlConnection(sqlconn);
			System.Data.SqlClient.SqlCommand cmd_data_add2 = new SqlCommand();  //adress pergi ke sql
			try 
			{
				cmd_data_add2.Connection = con_data_add2;		//coman run store procedure
				cmd_data_add2.CommandText = "SP_TEMP_PROD_COAT_JO_ADD_R2";	//nama store procedure
				cmd_data_add2.CommandType = CommandType.StoredProcedure;		//declare comand

				cmd_data_add2.Parameters.Add(new SqlParameter("@SP_JODOCNO", SqlDbType.NVarChar, 50)); //create parameter pada sql bwk data SP_RefNumber untuk dihantar semula
				cmd_data_add2.Parameters["@SP_JODOCNO"].Value = txtbx_refno.Text.ToUpper();
				
				
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

			//--------------------------------------------------------------------------------
						
						
			PrintReport();
			check = false;
			checkstore = false;
			ClearAllText(this);
			txtbx_costglue.Text = "0";
			txtbx_costfilm.Text = "0";
			txtbx_costconvert.Text = "0";
			txtbx_costservice.Text = "0";
			txtbx_refno.Text = "0";
			TxtBx_StockCode1.Enabled = true;
			TxtBx_JRColor1.Enabled =true;
			
			
		}
		
		//==========================================================================================================
		
		void PrintReport()
		{
			System.Windows.Forms.Form frm = new System.Windows.Forms.Form();
	        frm.Height = 600;
	        frm.Width = 800;
	
	        fyiReporting.RdlViewer.RdlViewer rdlView = new fyiReporting.RdlViewer.RdlViewer();
	        fyiReporting.RdlViewer.ViewerToolstrip report = new fyiReporting.RdlViewer.ViewerToolstrip(rdlView);
	        Uri baseUri = new Uri(System.IO.Directory.GetCurrentDirectory());
	        rdlView.SourceFile = new Uri(baseUri,@"../report/planning_jo_coating_R19.rdl");
	                
	        rdlView.Report.DataSets["Data"].SetSource("select * from TBL_PROD_COAT_JO where JODOCNO = '" + txtbx_refno.Text + "'");
	    
	        rdlView.Rebuild();
	
	        rdlView.Dock = DockStyle.Fill;
	        frm.Controls.Add(rdlView);
	        frm.Controls.Add(report);
	
	        frm.ShowDialog(this);
		}
		
		//=====================================================================================================	
		
		void Btn_deleteClick(object sender, EventArgs e)
		{
    	
    		btn_stockcode.Visible = true;
    		
    		SqlConnection Check_Running_Data = new SqlConnection(sqlconn2);
			SqlCommand cmd = new SqlCommand();
								
								
			try 
			{
				cmd.CommandText = "select * from JO_TRX where TrxJoNo  = '"+ txtbx_refno.Text.ToUpper() +"'";
				cmd.Connection = Check_Running_Data;
				Check_Running_Data.Open();
				SqlDataReader rd_Check_Running_Data = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
				
				if (rd_Check_Running_Data.Read())
				{
					if (rd_Check_Running_Data.HasRows) 
					{
						MessageBox.Show("Data Already Running, Can't Edit or Delete Data");//Lbl_Message.Text = "Error 1.0 : Duplicate JO! ";
						return;
					}
				}
			} 
			catch (Exception ex) 
			{
				Check_Running_Data.Close();
				MessageBox.Show("Error 2.0 : Can't Edit or Delete Because Data Already Running!" + ex.ToString() + ex.Message);
				return;
			} 		
			finally 
			{
				Check_Running_Data.Close();
			}
						
			Check_Running_Data.Dispose();
			cmd.Dispose();
			Check_Running_Data = null;
			cmd = null;
    		
			//----------------------------------------------------------------------------------------
			
			
			SqlConnection con_data_del = new SqlConnection(sqlconn);
			System.Data.SqlClient.SqlCommand cmd_data_del = new SqlCommand();
			
			try 
			{
				cmd_data_del.Connection = con_data_del;
				cmd_data_del.CommandText = "SP_PROD_COAT_JO_DEL_R2";
				cmd_data_del.CommandType = CommandType.StoredProcedure;
					
					
				cmd_data_del.Parameters.Add(new SqlParameter("@SP_ETDDATETIME", SqlDbType.DateTime)); //create parameter pada sql bwk data SP_RefNumber untuk dihantar semula
				cmd_data_del.Parameters["@SP_ETDDATETIME"].Value = dateTimePicker1.Value;
		
				cmd_data_del.Parameters.Add(new SqlParameter("@SP_JODOCNO", SqlDbType. NVarChar, 50)); //create parameter pada sql bwk data SP_RefNumber untuk dihantar semula
				cmd_data_del.Parameters["@SP_JODOCNO"].Value = txtbx_refno.Text.ToUpper();
				
				cmd_data_del.Parameters.Add(new SqlParameter("@SP_JODOCNO_PRINTING", SqlDbType. NVarChar, 50)); //create parameter pada sql bwk data SP_RefNumber untuk dihantar semula
				cmd_data_del.Parameters["@SP_JODOCNO_PRINTING"].Value = txtbx_jo_printing.Text.ToUpper();
				
				cmd_data_del.Parameters.Add(new SqlParameter("@SP_JOSALESNO", SqlDbType. NVarChar, 50)); //create parameter pada sql bwk data SP_RefNumber untuk dihantar semula
				cmd_data_del.Parameters["@SP_JOSALESNO"].Value = txtbx_refno.Text.ToUpper();
				
				cmd_data_del.Parameters.Add(new SqlParameter("@SP_JOSALESLINE", SqlDbType. NVarChar, 50)); //create parameter pada sql bwk data SP_RefNumber untuk dihantar semula
				cmd_data_del.Parameters["@SP_JOSALESLINE"].Value = "0";
				
				cmd_data_del.Parameters.Add(new SqlParameter("@SP_JOSTOCKCODE", SqlDbType.NVarChar, 50));
				cmd_data_del.Parameters["@SP_JOSTOCKCODE"].Value = txtbx_refno.Text.ToUpper();
				
				cmd_data_del.Parameters.Add(new SqlParameter("@SP_JRSTOCKCODE", SqlDbType.NVarChar, 50));
				cmd_data_del.Parameters["@SP_JRSTOCKCODE"].Value = TxtBx_StockCode1.Text.ToUpper();
				
				cmd_data_del.Parameters.Add(new SqlParameter("@SP_JOSTOCKDESC", SqlDbType.NVarChar, 50));
				cmd_data_del.Parameters["@SP_JOSTOCKDESC"].Value = txtbx_sodesc1.Text.ToUpper();
				
				cmd_data_del.Parameters.Add(new SqlParameter("@SP_JOSTOCKDESC2", SqlDbType.NVarChar, 50));
				cmd_data_del.Parameters["@SP_JOSTOCKDESC2"].Value = txtbx_sodesc2.Text.ToUpper();
				
				cmd_data_del.Parameters.Add(new SqlParameter("@SP_JOSTOCKCOLOR", SqlDbType.NVarChar, 50));
				cmd_data_del.Parameters["@SP_JOSTOCKCOLOR"].Value=txtbx_colour.Text.ToUpper();  //tukar daripada string kepada nombor
				
				cmd_data_del.Parameters.Add(new SqlParameter("@SP_JRCOLOR", SqlDbType.NVarChar, 50));
				cmd_data_del.Parameters["@SP_JRCOLOR"].Value = TxtBx_JRColor1.Text.ToUpper();  //tukar daripada string kepada nom
				
				cmd_data_del.Parameters.Add(new SqlParameter("@SP_JOSTOCKBRAND", SqlDbType.NVarChar, 50));
				cmd_data_del.Parameters["@SP_JOSTOCKBRAND"].Value=txtbx_brand.Text.ToUpper(); 
				
				cmd_data_del.Parameters.Add(new SqlParameter("@SP_JOSMARKCODE", SqlDbType.NVarChar, 50));
				cmd_data_del.Parameters["@SP_JOSMARKCODE"].Value=txtbx_smarkcode.Text.ToUpper(); 
				
				cmd_data_del.Parameters.Add(new SqlParameter("@SP_JOSHIPMARK", SqlDbType.NVarChar, 20));
				cmd_data_del.Parameters["@SP_JOSHIPMARK"].Value = "";
				
				cmd_data_del.Parameters.Add(new SqlParameter("@SP_JOJRCATEGORY", SqlDbType.NVarChar, 50));
				cmd_data_del.Parameters["@SP_JOJRCATEGORY"].Value = combobx_category.Text;
				
				cmd_data_del.Parameters.Add(new SqlParameter("@SP_JOSMARKLINE", SqlDbType.NVarChar, 50));
				cmd_data_del.Parameters["@SP_JOSMARKLINE"].Value=txtbx_smarkicode.Text.ToUpper(); 
				
				cmd_data_del.Parameters.Add(new SqlParameter("@SP_JOSTOCKWIDTH", SqlDbType.Float));
				cmd_data_del.Parameters["@SP_JOSTOCKWIDTH"].Value = Convert.ToDouble(txtbx_jrwidth.Text);
				
				cmd_data_del.Parameters.Add(new SqlParameter("@SP_JOCOSTGLUE", SqlDbType.Float));
				cmd_data_del.Parameters["@SP_JOCOSTGLUE"].Value = Convert.ToDouble(txtbx_costglue.Text);
				
				cmd_data_del.Parameters.Add(new SqlParameter("@SP_JOCOSTFILM", SqlDbType.Float));
				cmd_data_del.Parameters["@SP_JOCOSTFILM"].Value = Convert.ToDouble(txtbx_costfilm.Text);
				
				cmd_data_del.Parameters.Add(new SqlParameter("@SP_JOCOSTCONV", SqlDbType.Float));
				cmd_data_del.Parameters["@SP_JOCOSTCONV"].Value = Convert.ToDouble(txtbx_costconvert.Text);
				
				cmd_data_del.Parameters.Add(new SqlParameter("@SP_JOCOSTSERVICE", SqlDbType.Float));
				cmd_data_del.Parameters["@SP_JOCOSTSERVICE"].Value = Convert.ToDouble(txtbx_costservice.Text);
				
				cmd_data_del.Parameters.Add(new SqlParameter("@SP_JOSTOCKLENGTH", SqlDbType.Float));
				cmd_data_del.Parameters["@SP_JOSTOCKLENGTH"].Value = Convert.ToDouble(txtbx_jrlength.Text);
				
										
				//TUKAR QTY ORDERED KEPADA JO JR QTY
			
				cmd_data_del.Parameters.Add(new SqlParameter("@SP_JOSTOCKMICRON", SqlDbType.Float));
				cmd_data_del.Parameters["@SP_JOSTOCKMICRON"].Value =Convert.ToDouble(txtbx_micron.Text);
				
				cmd_data_del.Parameters.Add(new SqlParameter("@SP_JOSTOCKMICRONM2", SqlDbType.NVarChar, 50));
				cmd_data_del.Parameters["@SP_JOSTOCKMICRONM2"].Value = txtbx_M2.Text.ToUpper(); 
		
				
				cmd_data_del.Parameters.Add(new SqlParameter("@SP_JOJRM2", SqlDbType.Float));
				cmd_data_del.Parameters["@SP_JOJRM2"].Value =Convert.ToDouble(txtbx_jrm2.Text);
				
				cmd_data_del.Parameters.Add(new SqlParameter("@SP_PRODUCTWIDTH", SqlDbType.Float));
				cmd_data_del.Parameters["@SP_PRODUCTWIDTH"].Value =Convert.ToDouble(txtbx_productwidth.Text);
				
				cmd_data_del.Parameters.Add(new SqlParameter("@SP_PRODUCTLENGTH", SqlDbType.Float));
				cmd_data_del.Parameters["@SP_PRODUCTLENGTH"].Value =Convert.ToDouble(txtbx_productlength.Text);
				
				cmd_data_del.Parameters.Add(new SqlParameter("@SP_JOSTOCKMICRONMIN", SqlDbType.Float));
				cmd_data_del.Parameters["@SP_JOSTOCKMICRONMIN"].Value = Convert.ToDouble(txtbx_minimummic.Text);

	

				cmd_data_del.Parameters.Add(new SqlParameter("@SP_JOSTOCKMICRONMAX", SqlDbType.Float));
				cmd_data_del.Parameters["@SP_JOSTOCKMICRONMAX"].Value = Convert.ToDouble(txtbx_micmax.Text);

				cmd_data_del.Parameters.Add(new SqlParameter("@SP_JOSTOCKKGMIN", SqlDbType.Float));
				cmd_data_del.Parameters["@SP_JOSTOCKKGMIN"].Value = Convert.ToDouble(txtbx_kgmin.Text);
			
				cmd_data_del.Parameters.Add(new SqlParameter("@SP_JOSTOCKKGMAX", SqlDbType.Float));
				cmd_data_del.Parameters["@SP_JOSTOCKKGMAX"].Value = Convert.ToDouble(txtbx_totalkg.Text);
				
				cmd_data_del.Parameters.Add(new SqlParameter("@SP_JOQTY", SqlDbType.Float));
				cmd_data_del.Parameters["@SP_JOQTY"].Value = Convert.ToDouble(txtbx_qtyorder.Text);
				
				//cmd_data_del.Parameters.Add(new SqlParameter("@SP_JOJRM2", SqlDbType.Float));
				//cmd_data_del.Parameters["@SP_JOJRM2"].Value = Convert.ToDouble(txtbx_M2 .Text);
				
				cmd_data_del.Parameters.Add(new SqlParameter("@SP_JOCUSTOMER", SqlDbType.NVarChar, 50));
				cmd_data_del.Parameters["@SP_JOCUSTOMER"].Value = txtbx_socustomer.Text.ToUpper();
				
				cmd_data_del.Parameters.Add(new SqlParameter("@SP_JOCUSTOMERTYPE", SqlDbType.NVarChar, 50));
				cmd_data_del.Parameters["@SP_JOCUSTOMERTYPE"].Value = txtbx_customertype.Text.ToUpper();
				
				cmd_data_del.Parameters.Add(new SqlParameter("@SP_JOGLUECODE", SqlDbType.NVarChar, 50));
				cmd_data_del.Parameters["@SP_JOGLUECODE"].Value = txtbx_gluecode.Text.ToUpper();
		
				cmd_data_del.Parameters.Add(new SqlParameter("@SP_JOGLUEWIDTH", SqlDbType.Float));
				cmd_data_del.Parameters["@SP_JOGLUEWIDTH"].Value = Convert.ToDouble(txtbx_gluewidth.Text);
	
				cmd_data_del.Parameters.Add(new SqlParameter("@SP_JOGLUELENGTH", SqlDbType.Float));
				cmd_data_del.Parameters["@SP_JOGLUELENGTH"].Value = Convert.ToDouble(txtbx_bopp_length.Text);
				
				cmd_data_del.Parameters.Add(new SqlParameter("@SP_JOGLUEMICRON", SqlDbType.Float));
				cmd_data_del.Parameters["@SP_JOGLUEMICRON"].Value = Convert.ToDouble(txtbx_gluemicron.Text);
			
				cmd_data_del.Parameters.Add(new SqlParameter("@SP_JOGLUEKG", SqlDbType.Float));
				cmd_data_del.Parameters["@SP_JOGLUEKG"].Value = Convert.ToDouble(txtbx_costglue.Text);

				cmd_data_del.Parameters.Add(new SqlParameter("@SP_JOFILMCODE", SqlDbType.NVarChar, 50));
				cmd_data_del.Parameters["@SP_JOFILMCODE"].Value = combo_box3.Text;

				cmd_data_del.Parameters.Add(new SqlParameter("@SP_JOFILMWIDTH", SqlDbType.Float));
				cmd_data_del.Parameters["@SP_JOFILMWIDTH"].Value =Convert.ToDouble(txtbx_bopp_width.Text);
				                        
					cmd_data_del.Parameters.Add(new SqlParameter("@SP_JOFILMLENGTH", SqlDbType.Float));
				cmd_data_del.Parameters["@SP_JOFILMLENGTH"].Value = Convert.ToDouble(txtbx_bopp_length.Text);


				cmd_data_del.Parameters.Add(new SqlParameter("@SP_JOFILMMICRON", SqlDbType.NVarChar, 50));
				cmd_data_del.Parameters["@SP_JOFILMMICRON"].Value = txtbx_bopp_micron.Text.ToUpper();
				
				cmd_data_del.Parameters.Add(new SqlParameter("@SP_JOFILMKG", SqlDbType.Float));
				cmd_data_del.Parameters["@SP_JOFILMKG"].Value = Convert.ToDouble(txtbx_bopp_micron.Text);

				cmd_data_del.Parameters.Add(new SqlParameter("@SP_JOPRODDATE", SqlDbType.DateTime)); //create parameter pada sql bwk data SP_RefNumber untuk dihantar semula
				cmd_data_del.Parameters["@SP_JOPRODDATE"].Value = dateTimePicker1.Value;
				
				cmd_data_del.Parameters.Add(new SqlParameter("@SP_JOPRODOPERATOR", SqlDbType.NVarChar, 50));
				cmd_data_del.Parameters["@SP_JOPRODOPERATOR"].Value = "0";
				
				cmd_data_del.Parameters.Add(new SqlParameter("@SP_JOPRODHELPER", SqlDbType.NVarChar, 50));
				cmd_data_del.Parameters["@SP_JOPRODHELPER"].Value = "0";
				
				cmd_data_del.Parameters.Add(new SqlParameter("@SP_JOPRODQTY", SqlDbType.Float));
				cmd_data_del.Parameters["@SP_JOPRODQTY"].Value = Convert.ToDouble(txtbx_jojrqty.Text);
				
				cmd_data_del.Parameters.Add(new SqlParameter("@SP_JOPRODLOTNO", SqlDbType.NVarChar, 50));
				cmd_data_del.Parameters["@SP_JOPRODLOTNO"].Value = "0";
				
				cmd_data_del.Parameters.Add(new SqlParameter("@SP_JOPRODBATCHNO", SqlDbType.NVarChar, 50));
				cmd_data_del.Parameters["@SP_JOPRODBATCHNO"].Value = "0";
				
				cmd_data_del.Parameters.Add(new SqlParameter("@SP_JOPRODMACHINENO", SqlDbType.NVarChar, 50));
				cmd_data_del.Parameters["@SP_JOPRODMACHINENO"].Value = "0";
				
				cmd_data_del.Parameters.Add(new SqlParameter("@SP_JOEXTRAMETER", SqlDbType.NVarChar, 50));
				cmd_data_del.Parameters["@SP_JOEXTRAMETER"].Value = txtbx_extrameter.Text.ToUpper();

				cmd_data_del.Parameters.Add(new SqlParameter("@SP_JOREMARK1", SqlDbType.NVarChar, 250));
				cmd_data_del.Parameters["@SP_JOREMARK1"].Value = txtbx_remark2.Text.ToUpper();
				
				cmd_data_del.Parameters.Add(new SqlParameter("@SP_JOREMARK2", SqlDbType.NVarChar, 50));
				cmd_data_del.Parameters["@SP_JOREMARK2"].Value = txtbx_remark3.Text.ToUpper();
				
				cmd_data_del.Parameters.Add(new SqlParameter("@SP_JOREMARK3", SqlDbType.NVarChar, 50));
				cmd_data_del.Parameters["@SP_JOREMARK3"].Value = txtbx_remark4.Text.ToUpper();
				
				cmd_data_del.Parameters.Add(new SqlParameter("@SP_JOREMARK4", SqlDbType.NVarChar, 50));
				cmd_data_del.Parameters["@SP_JOREMARK4"].Value = txtbx_remark5.Text.ToUpper();
				
				cmd_data_del.Parameters.Add(new SqlParameter("@SP_JOREMARK5", SqlDbType.NVarChar, 50));
				cmd_data_del.Parameters["@SP_JOREMARK5"].Value = txtbx_remark12.Text.ToUpper();
				
				cmd_data_del.Parameters.Add(new SqlParameter("@SP_JOREMARK6", SqlDbType.NVarChar, 50));
				cmd_data_del.Parameters["@SP_JOREMARK6"].Value = txtbx_remark6.Text.ToUpper();
				
				cmd_data_del.Parameters.Add(new SqlParameter("@SP_JOREMARK7", SqlDbType.NVarChar, 250));
				cmd_data_del.Parameters["@SP_JOREMARK7"].Value = txtbx_remark7.Text.ToUpper();
				
				cmd_data_del.Parameters.Add(new SqlParameter("@SP_JOREMARK8", SqlDbType.NVarChar, 50));
				cmd_data_del.Parameters["@SP_JOREMARK8"].Value = txtbx_remark8.Text.ToUpper();
				
				cmd_data_del.Parameters.Add(new SqlParameter("@SP_JOREMARK9", SqlDbType.NVarChar, 50));
				cmd_data_del.Parameters["@SP_JOREMARK9"].Value = txtbx_remark9.Text.ToUpper();
				
				cmd_data_del.Parameters.Add(new SqlParameter("@SP_JOREMARK10", SqlDbType.NVarChar, 50));
				cmd_data_del.Parameters["@SP_JOREMARK10"].Value = txtbx_remark10.Text.ToUpper();
				
				cmd_data_del.Parameters.Add(new SqlParameter("@SP_JOREMARK", SqlDbType.NVarChar, 50));
				cmd_data_del.Parameters["@SP_JOREMARK"].Value = "0";
				
				cmd_data_del.Parameters.Add(new SqlParameter("@SP_JOSO", SqlDbType.NVarChar, 50));
				cmd_data_del.Parameters["@SP_JOSO"].Value = "0";
				
				cmd_data_del.Parameters.Add(new SqlParameter("@SP_JOISSUEBY", SqlDbType.NVarChar, 50));
				cmd_data_del.Parameters["@SP_JOISSUEBY"].Value = username.ToUpper();

				cmd_data_del.Parameters.Add(new SqlParameter("@SP_JOWTGLUE", SqlDbType.Float));
				cmd_data_del.Parameters["@SP_JOWTGLUE"].Value = Convert.ToDouble(txtbx_wtglue.Text);
				
				cmd_data_del.Parameters.Add(new SqlParameter("@SP_JOWTFILM", SqlDbType.Float));
				cmd_data_del.Parameters["@SP_JOWTFILM"].Value = Convert.ToDouble(txtbx_wtfilm.Text);
				
				cmd_data_del.Parameters.Add(new SqlParameter("@SP_JOWTTOTAL1", SqlDbType.Float));
				cmd_data_del.Parameters["@SP_JOWTTOTAL1"].Value = Convert.ToDouble(txtbx_total1.Text);

				cmd_data_del.Parameters.Add(new SqlParameter("@SP_JOWTCORE", SqlDbType.Float));
				cmd_data_del.Parameters["@SP_JOWTCORE"].Value = Convert.ToDouble(txtbx_core.Text);


				cmd_data_del.Parameters.Add(new SqlParameter("@SP_JOWTTOTAL2", SqlDbType.Float));
				cmd_data_del.Parameters["@SP_JOWTTOTAL2"].Value = Convert.ToDouble(txtbx_total2.Text);

				cmd_data_del.Parameters.Add(new SqlParameter("@SP_JOWTPACK", SqlDbType.Float));
				cmd_data_del.Parameters["@SP_JOWTPACK"].Value = Convert.ToDouble(txtbx_packing.Text);
				
				cmd_data_del.Parameters.Add(new SqlParameter("@SP_JOWTTOTAL3", SqlDbType.Float));
				cmd_data_del.Parameters["@SP_JOWTTOTAL3"].Value = Convert.ToDouble(txtbx_totalfinal.Text);
				
				
				
				cmd_data_del.Parameters.Add(new SqlParameter("@SP_JOPPCODE", SqlDbType.NVarChar, 80));
				cmd_data_del.Parameters["@SP_JOPPCODE"].Value = "0";
				
				cmd_data_del.Parameters.Add(new SqlParameter("@SP_JOPPTOLUNE", SqlDbType.NVarChar, 80));
				cmd_data_del.Parameters["@SP_JOPPTOLUNE"].Value = "0";

				cmd_data_del.Parameters.Add(new SqlParameter("@SP_JOPPWording", SqlDbType.NVarChar, 80));
				cmd_data_del.Parameters["@SP_JOPPWording"].Value = "0"; // "-"
				
				cmd_data_del.Parameters.Add(new SqlParameter("@SP_JOPPFilmSize", SqlDbType.NVarChar, 80));
				cmd_data_del.Parameters["@SP_JOPPFilmSize"].Value = "0";
				
				cmd_data_del.Parameters.Add(new SqlParameter("@SP_JOPPColor", SqlDbType.NVarChar, 80));
				cmd_data_del.Parameters["@SP_JOPPColor"].Value = "0";
				
				cmd_data_del.Parameters.Add(new SqlParameter("@SP_JOPPSizeArt", SqlDbType.NVarChar, 80));
				cmd_data_del.Parameters["@SP_JOPPSizeArt"].Value = "0";
				
				cmd_data_del.Parameters.Add(new SqlParameter("@SP_JOPPColorKG", SqlDbType.NVarChar, 80));
				cmd_data_del.Parameters["@SP_JOPPColorKG"].Value = "0";
				
				cmd_data_del.Parameters.Add(new SqlParameter("@SP_JOPPRemark", SqlDbType.NVarChar, 80));
				cmd_data_del.Parameters["@SP_JOPPRemark"].Value = "0";
				
				cmd_data_del.Parameters.Add(new SqlParameter("@SP_JOPPDate", SqlDbType.NVarChar, 80));
				cmd_data_del.Parameters["@SP_JOPPDate"].Value = "0";

				cmd_data_del.Parameters.Add(new SqlParameter("@SP_JOUSER", SqlDbType.NVarChar, 50));
				cmd_data_del.Parameters["@SP_JOUSER"].Value = "0";

				cmd_data_del.Parameters.Add(new SqlParameter("@SP_JOUSEREMAIL", SqlDbType.NVarChar, 50));
				cmd_data_del.Parameters["@SP_JOUSEREMAIL"].Value = frm_menu_system.email;
				

				
				cmd_data_del.Parameters.Add(new SqlParameter("@SP_JOUSERPC", SqlDbType.NVarChar, 50));
				cmd_data_del.Parameters["@SP_JOUSERPC"].Value = frm_menu_system.ipAddress;

				cmd_data_del.Parameters.Add(new SqlParameter("@SP_JOUSERDATETIME", SqlDbType.DateTime));
				cmd_data_del.Parameters["@SP_JOUSERDATETIME"].Value = DateTime.Now.Date; //"2016-11-28";//dateTimePicker1.Value.Date;

				cmd_data_del.Parameters.Add(new SqlParameter("@SP_JOUSERREVISION", SqlDbType.NVarChar, 50));
				cmd_data_del.Parameters["@SP_JOUSERREVISION"].Value = "0";  
				
				cmd_data_del.Parameters.Add(new SqlParameter("@SP_AVERAGEMICRON", SqlDbType.Float));
				cmd_data_del.Parameters["@SP_AVERAGEMICRON"].Value = avgmicron2;

				cmd_data_del.Parameters.Add(new SqlParameter("@SP_JOTOTALGLUE", SqlDbType.Float));
				cmd_data_del.Parameters["@SP_JOTOTALGLUE"].Value = totalglue;


				//cmd_data_del.Parameters.Add(new SqlParameter("@SP_JOSHIPMARK", SqlDbType.NVarChar, 20));
				//cmd_data_del.Parameters["@SP_JOSHIPMARK"].Value = "";						
				

				con_data_del.Open();
				cmd_data_del.ExecuteNonQuery();
				cmd_data_del.Parameters.Clear();
			} 
			catch (Exception ex) 
			{
				con_data_del.Close();
				MessageBox.Show("ERROR ? " + ex.ToString() + ex.ToString());
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
			ClearAllText(this);
			check = false;
			checkstore = false;
		}
		
		
		
//		void textBox1_KeyPress(object sender, KeyPressEventArgs e)
//		{
//    		if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
//       		 (e.KeyChar != '.'))
//   		 	{
//            e.Handled = true;
//    		}
//		}
	
		
		private bool Validation() 
		{
      
            try
            {
                if (CommonValidation.ValidateIsEmptyString(txtbx_refno.Text.Trim()))
                {
                    DialogBox.ShowWarningMessage(txtbx_refno.Text + " cannot be empty.");
                    txtbx_refno.Focus();
                    return false;
                }
                
               else if (combobx_category.Text =="Please Select")
                {
                    DialogBox.ShowWarningMessage(" cannot be empty");
                    combobx_category.Focus();
                    return false;
                }
//              else  if (CommonValidation.ValidateIsEmptyString(txtbx_soline.Text.Trim()))
//	                {
//	                   DialogBox.ShowWarningMessage(txtbx_soline.Text + " cannot be empty.");
//	                   txtbx_soline.Focus();
//	                    return false;
//	                }
			
				else if (CommonValidation.ValidateIsEmptyString(TxtBx_JRColor1.Text.Trim()))
                {
                    DialogBox.ShowWarningMessage(TxtBx_JRColor1.Text + " cannot be empty.");
                    TxtBx_JRColor1.Focus();
                    return false;
                }
             	else if (CommonValidation.ValidateIsEmptyString(txtbx_brand.Text.Trim()))
                {
                    DialogBox.ShowWarningMessage(txtbx_brand.Text + " cannot be empty.");
                    txtbx_brand.Focus();
                    return false;
                }
              	else if (CommonValidation.ValidateIsEmptyString(txtbx_customertype.Text.Trim()))
                {
                    DialogBox.ShowWarningMessage(txtbx_customertype.Text + " cannot be empty.");
                    txtbx_customertype.Focus();
                    return false;
                }
                else if (CommonValidation.ValidateIsEmptyString(combobx_category.Text.Trim()))
                {
                    DialogBox.ShowWarningMessage(combobx_category.Text + " cannot be empty.");
                    combobx_category.Focus();
                    return false;
                }
              	else if (CommonValidation.ValidateIsEmptyString(txtbx_sodesc1.Text.Trim()))
                {
                   DialogBox.ShowWarningMessage(txtbx_sodesc1.Text + " cannot be empty.");
                   txtbx_sodesc1.Focus();
                    return false;
                }
             	else if (CommonValidation.ValidateIsEmptyString(txtbx_sodesc2.Text.Trim()))
                {
                    DialogBox.ShowWarningMessage(txtbx_sodesc2.Text + " cannot be empty.");
                    txtbx_sodesc2.Focus();
                    return false;
                }
              	else  if (CommonValidation.ValidateIsEmptyString(txtbx_micron.Text.Trim()))
                {
                    DialogBox.ShowWarningMessage(txtbx_micron.Text + " cannot be empty.");
                    txtbx_micron.Focus();
                    return false;
                }
              	else if (CommonValidation.ValidateIsEmptyString(txtbx_minimummic.Text.Trim()))
                {
                    DialogBox.ShowWarningMessage(combobx_category.Text + " cannot be empty.");
                    txtbx_minimummic.Focus();
                    return false;
                }
              	else if (CommonValidation.ValidateIsEmptyString(txtbx_micmax.Text.Trim()))
                {
                   DialogBox.ShowWarningMessage(txtbx_micmax.Text + " cannot be empty.");
                   txtbx_micmax.Focus();
                    return false;
                }
             	else if (CommonValidation.ValidateIsEmptyString(txtbx_jrwidth.Text.Trim()))
                {
                    DialogBox.ShowWarningMessage(txtbx_jrwidth.Text + " cannot be empty.");
                    txtbx_jrwidth.Focus();
                    return false;
                }
              	else if (CommonValidation.ValidateIsEmptyString(txtbx_jrlength.Text.Trim()))
                {
                    DialogBox.ShowWarningMessage(txtbx_jrlength.Text + " cannot be empty.");
                    txtbx_jrlength.Focus();
                    return false;
                }
              	else if (CommonValidation.ValidateIsEmptyString(txtbx_colour.Text.Trim()))
                {
                    DialogBox.ShowWarningMessage(txtbx_colour.Text + " cannot be empty.");
                    txtbx_colour.Focus();
                    return false;
          
         		 }
	          	else if (CommonValidation.ValidateIsEmptyString(txtbx_qtyorder.Text.Trim()))
                {
                    DialogBox.ShowWarningMessage(txtbx_qtyorder.Text + " cannot be empty.");
                    txtbx_qtyorder.Focus();
                    return false;
       			}
             	else if (CommonValidation.ValidateIsEmptyString(txtbx_jrm2.Text.Trim()))
                {
                    DialogBox.ShowWarningMessage(txtbx_jrm2.Text + " cannot be empty.");
                    txtbx_jrm2.Focus();
                    return false;
                }
             	else  if (CommonValidation.ValidateIsEmptyString(txtbx_jojrqty.Text.Trim()))
                {
                    DialogBox.ShowWarningMessage(txtbx_jojrqty.Text + " cannot be empty.");
                    txtbx_jojrqty.Focus();
                    return false;
                }
              	else if (CommonValidation.ValidateIsEmptyString(combobx_category.Text.Trim()))
                {
                    DialogBox.ShowWarningMessage(combobx_category.Text + " cannot be empty.");
                    combo_box3.Focus();
                    return false;
                }
             	else  if (CommonValidation.ValidateIsEmptyString(txtbx_jo_printing.Text.Trim()))
                {
                   DialogBox.ShowWarningMessage(txtbx_jo_printing.Text + " cannot be empty.");
                   txtbx_jo_printing.Focus();
                    return false;
                }
            	else   if (CommonValidation.ValidateIsEmptyString(txtbx_bopp_micron.Text.Trim()))
                {
                    DialogBox.ShowWarningMessage(txtbx_bopp_micron.Text + " cannot be empty.");
                    txtbx_bopp_micron.Focus();
                    return false;
                }
            	else if (CommonValidation.ValidateIsEmptyString(txtbx_bopp_width.Text.Trim()))
                {
                    DialogBox.ShowWarningMessage(combobx_category.Text + " cannot be empty.");
                    txtbx_bopp_width.Focus();
                    return false;
                }
            	else  if (CommonValidation.ValidateIsEmptyString(txtbx_bopp_length.Text.Trim()))
                {
                   DialogBox.ShowWarningMessage(txtbx_bopp_length.Text + " cannot be empty.");
                   txtbx_bopp_length.Focus();
                    return false;
                }
            	else   if (CommonValidation.ValidateIsEmptyString(txtbx_gluecode.Text.Trim()))
                {
                    DialogBox.ShowWarningMessage(txtbx_gluecode.Text + " cannot be empty.");
                    txtbx_gluecode.Focus();
                    return false;
                }
            	
              	else  if (CommonValidation.ValidateIsEmptyString(txtbx_gluemicron.Text.Trim()))
                {
                    DialogBox.ShowWarningMessage(txtbx_gluemicron.Text  + " cannot be empty.");
                    txtbx_gluemicron.Focus();
                    return false;
                }
              	else   if (CommonValidation.ValidateIsEmptyString(txtbx_gluewidth.Text.Trim()))
                {
                    DialogBox.ShowWarningMessage(txtbx_gluewidth.Text + " cannot be empty.");
                    txtbx_gluewidth.Focus();
                    return false;
                }
              	else  if (CommonValidation.ValidateIsEmptyString(txtbx_wtfilm.Text.Trim()))
                {
                    DialogBox.ShowWarningMessage(txtbx_wtfilm.Text + " cannot be empty.");
                    txtbx_wtfilm.Focus();
                    return false;
                }
              	else if (CommonValidation.ValidateIsEmptyString(txtbx_wtglue.Text.Trim()))
                {
                    DialogBox.ShowWarningMessage(txtbx_wtglue.Text + " cannot be empty.");
                    txtbx_wtglue.Focus();
                    return false;
                }
             	else if (CommonValidation.ValidateIsEmptyString(txtbx_total1.Text.Trim()))
                {
                   DialogBox.ShowWarningMessage(txtbx_total1.Text + " cannot be empty.");
                   txtbx_total1.Focus();
                    return false;
                }
            	else if (CommonValidation.ValidateIsEmptyString(txtbx_core.Text.Trim()))
                {
                    DialogBox.ShowWarningMessage(txtbx_core.Text + " cannot be empty.");
                    txtbx_core.Focus();
                    return false;
                }

            	else if (CommonValidation.ValidateIsEmptyString(txtbx_total2.Text.Trim()))
                {
                    DialogBox.ShowWarningMessage(txtbx_total2.Text + " cannot be empty.");
                    txtbx_total2.Focus();
                    return false;
                }
              
            	else if (CommonValidation.ValidateIsEmptyString(txtbx_packing.Text.Trim()))
                {
                    DialogBox.ShowWarningMessage(txtbx_packing.Text + " cannot be empty.");
                    txtbx_packing.Focus();
                    return false;
                }
            	else if (CommonValidation.ValidateIsEmptyString(txtbx_totalfinal.Text.Trim()))
                {
                   DialogBox.ShowWarningMessage(txtbx_totalfinal.Text + " cannot be empty.");
                   txtbx_totalfinal.Focus();
                    return false;
                }
            	else if (CommonValidation.ValidateIsEmptyString(txtbx_productwidth.Text.Trim()))
                {
                    DialogBox.ShowWarningMessage(txtbx_productwidth.Text + " cannot be empty.");
                    txtbx_productwidth.Focus();
                    return false;
                }
             	else if (CommonValidation.ValidateIsEmptyString(txtbx_productlength.Text.Trim()))
                {
                    DialogBox.ShowWarningMessage(txtbx_productlength.Text  + " cannot be empty.");
                    txtbx_productlength.Focus();
                    return false;
                }
               	else if (CommonValidation.ValidateIsEmptyString(txtbx_kgmin.Text.Trim()))
                {
                    DialogBox.ShowWarningMessage(txtbx_kgmin.Text  + " cannot be empty.");
                    txtbx_kgmin.Focus();
                    return false;
                }
              	else   if (CommonValidation.ValidateIsEmptyString(txtbx_extrameter.Text.Trim()))
                {
                    DialogBox.ShowWarningMessage(txtbx_extrameter.Text + " cannot be empty.");
                    txtbx_extrameter.Focus();
                    return false;
                }
              
       
//             	else if (!Int32.TryParse(txtbx_extrameter.Text))
//				   {
//    				errorProvider1.SetError(txtbx_extrameter, "Only put Integer");
//					return;
//				   }

              
//              else   if (CommonValidation(txtbx_extrameter.Text.Trim()))
//	                {
//	                    DialogBox.ShowWarningMessage(txtbx_extrameter.Text + " cannot be empty.");
//	                    txtbx_extrameter.Focus();
//	                    return false;
//	                }
              
//              else   if (CommonValidation.ValidateIsEmptyString(txtbx_extrameter.Text.Trim()))
//	                {
//	                    DialogBox.ShowWarningMessage(txtbx_extrameter.Text + " cannot be empty.");
//	                    txtbx_extrameter.Focus();
//	                    return false;
//	                }
//
//              else  if (CommonValidation.ValidateIsEmptyString(txtbx_remark1.Text.Trim()))
//	                {
//	                    DialogBox.ShowWarningMessage(txtbx_remark1.Text + " cannot be empty.");
//	                    txtbx_remark1.Focus();
//	                    return false;
//	                }
//              
//              
//              else if (CommonValidation.ValidateIsEmptyString(txtbx_remark2.Text.Trim()))
//	                {
//	                    DialogBox.ShowWarningMessage(txtbx_remark2.Text + " cannot be empty.");
//	                    txtbx_remark2.Focus();
//	                    return false;
//	                }
//             else  if (CommonValidation.ValidateIsEmptyString(txtbx_remark3.Text.Trim()))
//	                {
//	                   DialogBox.ShowWarningMessage(txtbx_remark3.Text + " cannot be empty.");
//	                   txtbx_remark3.Focus();
//	                    return false;
//	                }
//            else   if (CommonValidation.ValidateIsEmptyString(txtbx_remark4.Text.Trim()))
//	                {
//	                    DialogBox.ShowWarningMessage(txtbx_remark4.Text + " cannot be empty.");
//	                    txtbx_remark4.Focus();
//	                    return false;
//	                }
//
//            else  if (CommonValidation.ValidateIsEmptyString(txtbx_remark5.Text.Trim()))
//	                {
//	                    DialogBox.ShowWarningMessage(txtbx_remark5.Text + " cannot be empty.");
//	                    txtbx_remark5.Focus();
//	                    return false;
//	                }
//              
//            else if (CommonValidation.ValidateIsEmptyString(txtbx_smarkcode.Text.Trim()))
//	                {
//	                    DialogBox.ShowWarningMessage(txtbx_smarkcode.Text + " cannot be empty.");
//	                    txtbx_smarkcode.Focus();
//	                    return false;
//	                }
//            
//            
//            else  if (CommonValidation.ValidateIsEmptyString(txtbx_smarkicode.Text.Trim()))
//	                {
//	                   DialogBox.ShowWarningMessage(txtbx_smarkicode.Text + " cannot be empty.");
//	                   txtbx_smarkicode.Focus();
//	                    return false;
//	                }
//            else   if (CommonValidation.ValidateIsEmptyString(txtbx_remark6.Text.Trim()))
//	                {
//	                    DialogBox.ShowWarningMessage(txtbx_remark6.Text + " cannot be empty.");
//	                    txtbx_remark6.Focus();
//	                    return false;
//	                }
//
//              else  if (CommonValidation.ValidateIsEmptyString(txtbx_remark7.Text.Trim()))
//	                {
//	                    DialogBox.ShowWarningMessage(txtbx_remark7.Text  + " cannot be empty.");
//	                    txtbx_remark7.Focus();
//	                    return false;
//	                }
//              else  if (CommonValidation.ValidateIsEmptyString(txtbx_remark8.Text.Trim()))
//	                {
//	                    DialogBox.ShowWarningMessage(txtbx_remark8.Text  + " cannot be empty.");
//	                    txtbx_remark8.Focus();
//	                    return false;
//	                }
//              
//              
//              else   if (CommonValidation.ValidateIsEmptyString(txtbx_remark9.Text.Trim()))
//	                {
//	                    DialogBox.ShowWarningMessage(txtbx_remark9.Text + " cannot be empty.");
//	                    txtbx_remark9.Focus();
//	                    return false;
//	                }
//
//              else  if (CommonValidation.ValidateIsEmptyString(txtbx_remark10.Text.Trim()))
//	                {
//	                    DialogBox.ShowWarningMessage(txtbx_remark10.Text + " cannot be empty.");
//	                    txtbx_remark10.Focus();
//	                    return false;
//	                }
              
              
              	else if (CommonValidation.ValidateIsEmptyString(TxtBx_StockCode1.Text.Trim()))
	          	{
                    DialogBox.ShowWarningMessage(TxtBx_StockCode1.Text + " cannot be empty.");
                    TxtBx_StockCode1.Focus();
                    return false;
                }
             	else  if (CommonValidation.ValidateIsEmptyString(txtbx_costglue.Text.Trim()))
                {
                   DialogBox.ShowWarningMessage(txtbx_costglue.Text + " cannot be empty.");
                   txtbx_costglue.Focus();
                    return false;
                }
	            else if (CommonValidation.ValidateIsEmptyString(txtbx_productlength.Text.Trim()))
	            {
                    DialogBox.ShowWarningMessage(txtbx_costconvert.Text + " cannot be empty.");
                    txtbx_productlength.Focus();
                    return false;
                }
        
            	else if (CommonValidation.ValidateIsEmptyString(txtbx_costservice.Text.Trim()))
                {
                    DialogBox.ShowWarningMessage(txtbx_costservice.Text + " cannot be empty.");
                    txtbx_costservice.Focus();
                    return false;
                }
    
          	}
            catch(Exception e)
            {
          		;
            }
           //throw();           
			return true;
		} //end validation
		
		
//		bool NextNumberStore()
//		{
//				
//				
//				SqlConnection conNextNumber = new SqlConnection(sqlconn);
//						SqlCommand cmdNextNumber = new SqlCommand();
//						try {
//							cmdNextNumber.CommandText = "Select * from TBL_ADMIN_NEXT_NUMBER";
//							cmdNextNumber.Connection = conNextNumber;
//							conNextNumber.Open();
//							SqlDataReader rdNextNumber = cmdNextNumber.ExecuteReader(System.Data.CommandBehavior.CloseConnection); //UNTUK BACA DATA DALAM TABLE
//							rdNextNumber.Read();
//							NextNo2 = Convert.ToInt32(rdNextNumber["JoStoreCoatNextNumber"].ToString());
//							
//						} 
//						
//						
//						catch (Exception ex) 
//						
//						{
//							MessageBox.Show("ERROR NEXT NUMBER!" + ex.ToString() +ex.Message);
//							NextNo2 = 0;
//							return false;
//							
//						} 
//						
//						finally
//						{
//							conNextNumber.Close();
//						}
//						conNextNumber.Dispose();
//						conNextNumber = null;
//						cmdNextNumber = null;
//						
//						//************************************************************************************************************************
//		
//						
//						SqlConnection conUpdateNextNumber = new SqlConnection(sqlconn);
//						System.Data.SqlClient.SqlCommand cmdUpdateNextNumber = new SqlCommand();
//						try {
//							cmdUpdateNextNumber.CommandText = "update TBL_ADMIN_NEXT_NUMBER set JoStoreCoatNextNumber = JoStoreCoatNextNumber + 1";
//							cmdUpdateNextNumber.Connection = conUpdateNextNumber;
//							conUpdateNextNumber.Open();
//							cmdUpdateNextNumber.ExecuteNonQuery();
//						}
//						catch (Exception ex) 
//						{
//							conUpdateNextNumber.Close();
//							MessageBox.Show("Error Update Next Number!" + ex.ToString() + ex.Message); //Lbl_Message.Text = "Error Update Next Number! " + ex.ToString + ex.Message;
//							return false;
//						} 
//						finally 
//						{
//							conUpdateNextNumber.Close();
//						}
//						conUpdateNextNumber.Dispose();
//						conUpdateNextNumber = null;
//						cmdUpdateNextNumber = null;
//						return true;
//			
//		}
		
		
//		void NextNumberStore()
//		{
//			int NextNo2 ;
//			
//			NextNo2 = 0;
////************************************************************************************************************************
//			SqlConnection conNextNumber = new SqlConnection(sqlconn);
//			SqlCommand cmdNextNumber = new SqlCommand();
//			try 
//			{
//				cmdNextNumber.CommandText = "Select * from TBL_ADMIN_NEXT_NUMBER";
//				cmdNextNumber.Connection = conNextNumber;
//				conNextNumber.Open();
//				SqlDataReader rdNextNumber = cmdNextNumber.ExecuteReader(System.Data.CommandBehavior.CloseConnection); //UNTUK BACA DATA DALAM TABLE
//				rdNextNumber.Read();
//				NextNo2 = Convert.ToInt32(rdNextNumber["JoStoreCoatNextnumber"].ToString());
//							
//			} 
//			catch (Exception ex) 			
//			{
//							//NextNo2 = 0;
//				MessageBox.Show("ERROR NEXT NUMBER!" + ex.ToString() +ex.Message);
//				return;				
//			} 			
//			finally
//			{
//				conNextNumber.Close();
//			}
//			conNextNumber.Dispose();
//			conNextNumber = null;
//			cmdNextNumber = null;
////************************************************************************************************************************
//		
//						
//			SqlConnection conUpdateNextNumber = new SqlConnection(sqlconn);
//			System.Data.SqlClient.SqlCommand cmdUpdateNextNumber = new SqlCommand();
//			try 
//			{
//				cmdUpdateNextNumber.CommandText = "update TBL_ADMIN_NEXT_NUMBER set ProdGlueNextNumber = ProdGlueNextNumber + 1";
//				cmdUpdateNextNumber.Connection = conUpdateNextNumber;
//				conUpdateNextNumber.Open();
//				cmdUpdateNextNumber.ExecuteNonQuery();
//			} 
//						
//			catch (Exception ex) 
//						
//			{
//				conUpdateNextNumber.Close();
//				MessageBox.Show("Error Update Next Number!" + ex.ToString() + ex.Message); //Lbl_Message.Text = "Error Update Next Number! " + ex.ToString + ex.Message;
//				return;
//			} 
//						
//			finally
//			{
//				conUpdateNextNumber.Close();
//			}
//			conUpdateNextNumber.Dispose();
//			conUpdateNextNumber = null;
//			cmdUpdateNextNumber = null;
//			//MessageBox.Show("in store next number " + NextNo2.ToString());
//		}
		
		
		void NextNumberRetrieve()
		{
			int NextNo ;
			//string SDate;
			NextNo = 0;
//************************************************************************************************************************
			SqlConnection conNextNumber = new SqlConnection(sqlconn);
			SqlCommand cmdNextNumber = new SqlCommand();
			
			try 
			{
				cmdNextNumber.CommandText = "Select * from TBL_ADMIN_NEXT_NUMBER";
				cmdNextNumber.Connection = conNextNumber;
				conNextNumber.Open();
				SqlDataReader rdNextNumber = cmdNextNumber.ExecuteReader(System.Data.CommandBehavior.CloseConnection); //UNTUK BACA DATA DALAM TABLE
				rdNextNumber.Read();
				NextNo = Convert.ToInt32(rdNextNumber["JoCoatNextNumber"].ToString());
				
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
				
				try 
				{
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
			
			JODSDateString = null;
			
			JODSDateString = (JODSDate.ToString("yy")) + (JODSDate.ToString("MM"));
			string SDate;

			//************************************************************************************************************************
			//SDate = "JB" & NextNo
			
			if (combobx_category.Text.ToUpper() == "JRLOCAL") 
			{
				SDate = "JE" + NextNo + JODSDateString;
				txtbx_refno.Text = SDate;
			} 
			else if (combobx_category.Text.ToUpper() == "JR WIP")
			{
				SDate = "JW" + NextNo + JODSDateString;
				txtbx_refno.Text = SDate;
			} 
			
			
//			{
//				SDate = "JB" + NextNo + JODSDateString;
//			}
			
			//txtbx_refno.Text = SDate;
			
			//************************************************************************************************************************
			//************************************************************************************************************************
			//---  Update next number
			SqlConnection conUpdateNextNumber = new SqlConnection(sqlconn);
			System.Data.SqlClient.SqlCommand cmdUpdateNextNumber = new SqlCommand();
			
			try 
			{
				cmdUpdateNextNumber.CommandText = "update TBL_ADMIN_NEXT_NUMBER set JoCoatNextNumber = JoCoatNextNumber + 1";
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
		
		//----------------------------------------------------------------------------------------------------------------------------------------------------------------------------
		
		
		void assignValue()
		{
			
			txtbx_jrm2.Text = "0";
            txtbx_qtyorder.Text = "0";
		}
		
		void Btn_cancelClick(object sender, EventArgs e)
		{
			TxtBx_StockCode1.Enabled = true;
			TxtBx_JRColor1.Enabled = true;

            this.Close();
            Enable_Edit();
		}			
	
		
		public void JrCategory()
		{
			string sqlStatement = "SELECT Category FROM TBL_JUMBO_ROLE_CATEGORY_LOCAL";
			SqlConnection sqlConn = new SqlConnection(sqlconn);
			DataSet ds = new DataSet();
			SqlDataAdapter sda = new SqlDataAdapter(sqlStatement, sqlConn);
					
			try 
			{
						
				sqlConn.Open();
				sda.Fill(ds);
				combobx_category.Text = "Please Select";
					
			}
						
			catch (Exception ex) 
			{
					DialogBox.ShowWarningMessage("An error occured while connecting to database" + ex.Message + ex.ToString());
					sqlConn.Close();
					sqlConn.Dispose();
					return;
			} 
			finally 
			{
					sqlConn.Close();
					sqlConn.Dispose();
			}
		
			foreach(DataRow dr1 in ds.Tables[0].Rows)
			{
				combobx_category.Items.Add(dr1["Category"].ToString());
			}
				
		}
		
		void detect_JR()
		{
			string char_stockcode = TxtBx_StockCode1.Text;
			//char[] char_alpha = char_stockcode.ToCharArray();
			Match rgx =  Regex.Match(char_stockcode, @"^[a-zA-Z0-9]JR\d{2}$");
			
			MessageBox.Show("rgx" + rgx.ToString());
			
			//string final_stockcode = rgx;

			//if(regexItem.IsMatch(char_stockcode))
			if (System.Text.RegularExpressions.Regex.IsMatch(char_stockcode, rgx.ToString()))
			{
				 combo_box3.Text = char_stockcode;
				 MessageBox.Show("dlm if" + char_stockcode);
				 
				 string sqlStatement2 = "select StockCode TBL_PROD_COAT_BOPP_FILM_LIST where StockCode like '%"+char_stockcode+"%'" ;
			}
		}
		
		
//		public void detect_StockCode_Type()
//		{
//		
//		string atest = TxtBx_StockCode1.Text;
//		int indexOfHyphen = atest.LastIndexOf("-");
//		
//		if (indexOfHyphen >= 0)
//		{
//			
//		    contentAfterLastHyphen = atest.Substring(indexOfHyphen + 1);
//		  //  MessageBox.Show(contentAfterLastHyphen.ToString() );
//		}
//
//		}


//		 public void detect_StockCode_Type()
//		{
//			string StockCode_Num = TxtBx_StockCode1.Text;
//			//char[] StockCode_Split = StockCode_Num.ToCharArray();
//			//string combine_sc;
//			//var target = "JR";
//			
//			var result = str.Substring(str.LastIndexOf('-') + 1);
//			
//			//int i;
//			//char y;
//			
//			for (i = 0; i<=StockCode_Split.Length -1; i++)
//			{
//					
//			if(StockCode_Split[i].Equals('J') &&  StockCode_Split.Length > 2)
//			{
//				
//				combine_sc = Convert.ToString((i+1) + (i+1) + (i+1) + (i+1));
//				MessageBox.Show(combine_sc.ToString());
//				break;
//				
//				
//				
//			}
//			
//			}
//			
//
//
//		}
 
		void Combo_box3SelectedIndexChanged(object sender, EventArgs e) //nilai akan bertukar apabila memilih data lain dalam dropdown
		{

			SqlConnection con = new SqlConnection(sqlconn);
			
			
			//string sqlStatement2 = "select StockCode TBL_PROD_COAT_BOPP_FILM_LIST where StockCode like '%"+char_stockcode+"%'" ;
			string sqlStatement = "select StockMicron, StockWidth, StockLength from TBL_PROD_COAT_BOPP_FILM_LIST where StockCode = '"+combo_box3.Text+"'";
			
			SqlCommand cmd = new SqlCommand( sqlStatement,con);
			SqlDataReader dbr;
			
			try
			{
				con.Open();
				dbr = cmd.ExecuteReader();
				while(dbr.Read())
				{

					txtbx_bopp_micron.Text = (string) dbr["StockMicron"].ToString();
					txtbx_bopp_width.Text = (string) dbr["StockWidth"].ToString();
					txtbx_bopp_length.Text = (string) dbr["StockLength"].ToString();
			
				}
			}
			catch(Exception es)
			{
				MessageBox.Show("Error" + es.Message + es.ToString());
			}
				
			if (txtbx_bopp_width.Text == "1615")
			{
				txtbx_gluewidth.Text = "1600";
			}
			else if (txtbx_bopp_width.Text == "1610")
			{
				txtbx_gluewidth.Text = "1595";
			}
			else if (txtbx_bopp_width.Text == "1270" || txtbx_bopp_width.Text == "1280")
			{
				txtbx_gluewidth.Text = "1260";
			}
			else if (txtbx_bopp_width.Text == "990") 
			{
				txtbx_gluewidth.Text = "970";
			}
			else if	(txtbx_bopp_width.Text == "900")
			{
				txtbx_gluewidth.Text = "890";
			} 
			else if (txtbx_bopp_width.Text == "1320")
			{
				txtbx_gluewidth.Text = "1305";
			} 
			else 
			{
				txtbx_gluewidth.Text = "0";
			}
		

			if (txtbx_bopp_width.Text == "1615")
			{
				txtbx_core.Text = "3.5";
			}
			else if (txtbx_bopp_width.Text == "1610") 
			{
				//TxtBx_WTCORE.Text = 3.5
				txtbx_core.Text = "3";
			} 
			else if (txtbx_bopp_width.Text == "1270" || txtbx_jrwidth.Text == "1280")
			{
				txtbx_core.Text = "2.5";
			} 
			else if (txtbx_bopp_width.Text == "990")
			{
				txtbx_core.Text = "2";
			} 
			else if (txtbx_bopp_width.Text == "900")
			{
				txtbx_core.Text = "2";
			} 
			else if (txtbx_bopp_width.Text == "1320") 
			{
				txtbx_core.Text = "3";
			}
			else 
			{
				txtbx_core.Text = "0";
			}
			

			if (txtbx_bopp_width.Text == "1615")
			{
				txtbx_packing.Text = "3";
			} 
			else if (txtbx_bopp_width.Text == "1610")
			{
				txtbx_packing.Text = "3";
			} 
			else if(txtbx_bopp_width.Text == "1270" || txtbx_jrwidth.Text == "1280") 
			{
				txtbx_packing.Text = "2.5";
			} 
			else if (txtbx_bopp_width.Text == "990")
			{
				txtbx_packing.Text = "2";
			}
			else if (txtbx_bopp_width.Text == "900")
			{
				txtbx_packing.Text = "2";
			} 
			else if (txtbx_bopp_width.Text == "1320")
			{
				txtbx_packing.Text = "2.5";
			} 
			else
			{
				txtbx_packing.Text = "0";
			}
	

			txtbx_bopp_width.Text = txtbx_bopp_width.Text;
		}
		
		
		void ClearAllText(Control con)
		{
    		foreach (Control c in con.Controls)
    		{
      			if (c is TextBox)
        			((TextBox)c).Clear();
      			else
      				ClearAllText(c);
      			
      			if(c is ComboBox)
                ((ComboBox)c).Text = "Please Select";

				if(c is DateTimePicker)
				{
					((DateTimePicker)c).Value = DateTime.Now;
				}
				
				if(c is RichTextBox)
					((RichTextBox)c).Clear();
				
				txtbx_refno.Text = "0";
   			}
		}	
					
		
//		void Btn_retrieveClick(object sender, EventArgs e)
//		{
//			btn_delete.Visible = true;
//			btn_save.Visible = true;
//			check = true;
//			
//			//string jobord = jobord.Right(3);
//			
//			
//			if (txtbx_refno.Text == null | txtbx_refno.Text == string.Empty) 
//			{
//        		MessageBox.Show("Please key-in Ref No");
//				return;
//			}
//			
//			SqlConnection con_SP1 = new SqlConnection(sqlconn);
//			SqlCommand cmd_SP1 = new SqlCommand();
//			
//			try 
//			{
//				cmd_SP1.CommandText = "select * from stk where mmc = 'GF' and mcode = '" + txtbx_joso.Text + " ' and mcode like 'WJ%'";
//				cmd_SP1.Connection = con_SP1;
//				con_SP1.Open();
//				SqlDataReader rd_SP1 = cmd_SP1.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
//				
//				if (rd_SP1.Read())
//				{
//				
//						txtbx_joso.Text = rd_SP1["JOSALESNO"].ToString();
//						txtbx_soline.Text = rd_SP1["JOSALESLINE"].ToString();
//						//txtbx_refno.Text = rd_SP1["JODOCNO"].ToString();
//						txtbx_socustomer.Text = rd_SP1["JOCUSTOMER"].ToString();
//						txtbx_brand.Text = rd_SP1["JOSTOCKBRAND"].ToString(); 
//						txtbx_customertype.Text = rd_SP1["JOCUSTOMERTYPE"].ToString();
//						combobx_category.Text = rd_SP1["JOJRCATEGORY"].ToString();
//						txtbx_sodesc1.Text = rd_SP1["JOSTOCKDESC"].ToString();
//						txtbx_sodesc2.Text = rd_SP1["JOSTOCKDESC2"].ToString();
//						txtbx_micron.Text = rd_SP1["JOSTOCKMICRON"].ToString();
//						txtbx_M2.Text = rd_SP1["JOSTOCKMICRONM2"].ToString();
//						txtbx_minimummic.Text = rd_SP1["JOSTOCKMICRONMIN"].ToString();
//						txtbx_micmax.Text = rd_SP1["JOSTOCKMICRONMAX"].ToString();
//						txtbx_jrwidth.Text = rd_SP1["JOSTOCKWIDTH"].ToString();
//						txtbx_jrlength.Text = rd_SP1["JOSTOCKLENGTH"].ToString();
//						txtbx_colour.Text = rd_SP1["JOSTOCKCOLOR"].ToString();
//						txtbx_qtyorder.Text = rd_SP1["JOQTY"].ToString();
//						txtbx_jrm2.Text = rd_SP1["JOJRM2"].ToString();
//						txtbx_jojrqty.Text = rd_SP1["JOPRODQTY"].ToString();
//				
//						txtbx_bopp_micron.Text = rd_SP1["JOFILMMICRON"].ToString();
//						txtbx_bopp_width.Text = rd_SP1["JOFILMWIDTH"].ToString();
//						txtbx_bopp_length.Text = rd_SP1["JOGLUELENGTH"].ToString();
//						txtbx_gluecode.Text = rd_SP1["JOGLUECODE"].ToString();
//						txtbx_gluemicron.Text = rd_SP1["JOGLUEMICRON"].ToString();
//						txtbx_gluewidth.Text = rd_SP1["JOGLUEWIDTH"].ToString();
//						txtbx_wtfilm.Text = rd_SP1["JOWTFILM"].ToString();
//						txtbx_wtglue.Text = rd_SP1["JOWTGLUE"].ToString();
//						txtbx_total1.Text = rd_SP1["JOWTTOTAL1"].ToString();
//						txtbx_core.Text = rd_SP1["JOWTCORE"].ToString();
//						txtbx_total2.Text = rd_SP1["JOWTTOTAL2"].ToString();
//						txtbx_packing.Text = rd_SP1["JOWTPACK"].ToString();
//						txtbx_totalfinal.Text = rd_SP1["JOWTTOTAL3"].ToString();
//					
//						txtbx_productwidth.Text = rd_SP1["PRODUCTWIDTH"].ToString();
//						txtbx_productlength.Text = rd_SP1["PRODUCTLENGTH"].ToString();
//						txtbx_kgmin.Text = rd_SP1["JOSTOCKKGMIN"].ToString();
//						txtbx_totalkg.Text = rd_SP1["JOSTOCKKGMAX"].ToString();
//						txtbx_extrameter.Text = rd_SP1["JOEXTRAMETER"].ToString();
//						txtbx_remark1.Text = rd_SP1["JOREMARK1"].ToString();
//						txtbx_remark2.Text = rd_SP1["JOREMARK2"].ToString();
//						txtbx_remark3.Text = rd_SP1["JOREMARK3"].ToString();
//						txtbx_remark4.Text = rd_SP1["JOREMARK4"].ToString();
//						txtbx_remark5.Text = rd_SP1["JOREMARK5"].ToString();
//						txtbx_smarkcode.Text = rd_SP1["JOSMARKCODE"].ToString();
//						txtbx_smarkicode.Text = rd_SP1["JOSMARKLINE"].ToString();
//						txtbx_remark6.Text = rd_SP1["JOREMARK6"].ToString();
//						txtbx_remark7.Text = rd_SP1["JOREMARK7"].ToString();
//						txtbx_remark8.Text = rd_SP1["JOREMARK8"].ToString();
//						txtbx_remark9.Text = rd_SP1["JOREMARK9"].ToString();
//						txtbx_remark10.Text = rd_SP1["JOREMARK10"].ToString();
//						TxtBx_StockCode1.Text = rd_SP1["JRSTOCKCODE"].ToString();
//						TxtBx_JRColor1.Text = rd_SP1["JRCOLOR"].ToString();
//						txtbx_costglue.Text = rd_SP1["JOCOSTGLUE"].ToString();
//						txtbx_costfilm.Text = rd_SP1["JOCOSTFILM"].ToString();
//						txtbx_costconvert.Text = rd_SP1["JOCOSTCONV"].ToString();
//						txtbx_costservice.Text = rd_SP1["JOCOSTSERVICE"].ToString();
//
//
//					dateTimePicker1.Value = Convert.ToDateTime(rd_SP1["JOUSERDATETIME"]);
//						
//				
//						
//    					//txtbx_jrm2.Text = rd_SP1["JOJRM2"].ToString();
//						
//						
//    					txtbx_productwidth.Text = rd_SP1["PRODUCTWIDTH"].ToString();
//					
//    					txtbx_customertype.Text = rd_SP1["JOCUSTOMERTYPE"].ToString();
//
//    					TxtBx_StockCode1.Text = rd_SP1["JRSTOCKCODE"].ToString();
//
//    					combo_box3.Text = rd_SP1["JOJRCATEGORY"].ToString();
//						combo_box3.SelectedValue = rd_SP1["JOJRCATEGORY"].ToString();
////--------------------------------------------------------------------------------------------
//					dateTimePicker1.Text = rd_SP1["JOUSERDATETIME"].ToString();
//					//dateTimePicker1.Value  = rd_SP1["@SP_JOUSERDATETIME"].ToString();
//					
//					
//					combo_box3.Text = rd_SP1["JOFILMCODE"].ToString();
//					combo_box3.SelectedValue  = rd_SP1["JOFILMCODE"].ToString();
//					//combo_box3.Text = rd_SP1["JOFILMCODE"].ToString();
//					
//					
////--------------------------------------------------------------------------------------------			
//				} 
//				else 
//				{
//					MessageBox.Show("Error Edit : Cannot find JO!");
//					return;
//				}
//			} 
//			catch (Exception ex) 
//			{
//				MessageBox.Show("Error Edit : Cannot load DB!" + ex.Message + ex.ToString());
//				return;
//			} 
//			finally 
//			{
//				con_SP1.Close();
//			}
//			
//			con_SP1.Dispose();
//			con_SP1 = null;
//			cmd_SP1 = null;			
//			
//			
//			
//		}
		
		

		
		void Btn_calcWeightClick(object sender, EventArgs e)
		{
			
			if(!ValidateCalculate())
				return;
			
			
			txtbx_gluemicron.Text = Convert.ToString(Math.Round(((Convert.ToDouble(txtbx_micmax.Text) )  - (Convert.ToDouble(txtbx_bopp_micron.Text))),1));;
			txtbx_wtfilm.Text = Convert.ToString(Math.Round(((Convert.ToDouble(txtbx_bopp_micron.Text) * 0.91 * (double) Convert.ToDouble(txtbx_bopp_width.Text) / 1000 *  Convert.ToDouble(txtbx_jrlength.Text) / 1000)),2));
			txtbx_wtglue.Text = Convert.ToString(Math.Round(((Convert.ToDouble(txtbx_gluemicron.Text) * 1.05 * (double) Convert.ToDouble(txtbx_gluewidth.Text) / 1000 *  Convert.ToDouble(txtbx_jrlength.Text) / 1000)),2));
			txtbx_total1.Text = Convert.ToString(Math.Round(((Convert.ToDouble(txtbx_wtfilm.Text) + Convert.ToDouble(txtbx_wtglue.Text))),2));
			txtbx_total2.Text = Convert.ToString(Math.Round(((Convert.ToDouble(txtbx_total1.Text) + Convert.ToDouble(txtbx_core.Text))),2));
			txtbx_totalfinal.Text = Convert.ToString(Convert.ToDouble(txtbx_total2.Text) + Convert.ToDouble(txtbx_packing.Text));
			txtbx_kgmin.Text = Convert.ToString(Math.Round((Convert.ToDouble(txtbx_totalfinal.Text) - 2.0)));
			txtbx_totalkg.Text = Convert.ToString(Math.Round(((Convert.ToDouble(txtbx_totalfinal.Text)))));
			
			//double totalglue2;
			if (txtbx_gluecode.Text.ToUpper() == "820SNY" || txtbx_gluecode.Text.ToUpper() == "820S" || txtbx_gluecode.Text.ToUpper() == "826" || txtbx_gluecode.Text.ToUpper() == "8208" || txtbx_gluecode.Text.ToUpper() == "824" )
			{
				totalglue = Math.Round(Convert.ToDouble(Double.Parse(txtbx_wtglue.Text) / 0.57 * Double.Parse(txtbx_jojrqty.Text)),2);
			}
			
			else if (txtbx_gluecode.Text.ToUpper() == "8209" || txtbx_gluecode.Text.ToUpper() == "SBT" || txtbx_gluecode.Text.ToUpper() == "846" || txtbx_gluecode.Text.ToUpper() == "8209LV")
			{
				totalglue = Math.Round(Convert.ToDouble(Double.Parse(txtbx_wtglue.Text) / 0.6 * Double.Parse(txtbx_jojrqty.Text)),2);
			}
			
			else if (txtbx_gluecode.Text.ToUpper() == "820S-NY54")
			{
				totalglue = Math.Round(Convert.ToDouble(Double.Parse(txtbx_wtglue.Text) / 0.57 * Double.Parse(txtbx_jojrqty.Text)),2);
			}
			
			
			else if (txtbx_gluecode.Text.ToUpper() == "SBT60")
			{
				totalglue = Math.Round(Convert.ToDouble(Double.Parse(txtbx_wtglue.Text) / 0.6 * Double.Parse(txtbx_jojrqty.Text)),2);
			}
			
			else if (txtbx_gluecode.Text.ToUpper() == "SBT54")
			{
				totalglue = Math.Round(Convert.ToDouble(Double.Parse(txtbx_wtglue.Text) / 0.6 * Double.Parse(txtbx_jojrqty.Text)),2);
			}
			
//			else 
//			{
//				totalglue = Math.Round(Convert.ToDouble(Double.Parse(txtbx_wtglue.Text) / 0.56 * Double.Parse(txtbx_jojrqty.Text)),2);
//			}
			
			
					//txtbx_productwidth.Text = txtbx_jrwidth.Text;
					//txtbx_productlength.Text = txtbx_jrlength.Text;
					//txtbx_kgmin.Text = txtbx_total2.Text;
					//txtbx_totalkg.Text = txtbx_totalfinal.Text;
					
		}
		
		
		//===============================================================================================
		
		public void set_combobox()
		{
			//combo_box3.Text = contentAfterLastHyphen;
			SqlConnection conn_sc = new SqlConnection(sqlconn);
			{
				conn_sc.Open();
				string SqlDataPull = ("select StockMicron, StockWidth, StockLength from TBL_PROD_COAT_BOPP_FILM_LIST where StockCode like  '%"+ contentAfterLastHyphen+"%'");
				SqlCommand cmd = new SqlCommand(SqlDataPull, conn_sc);
				cmd.CommandType = CommandType.Text;
				SqlDataReader dr = cmd.ExecuteReader();
			
				
				try 
				{
					while (dr.Read())
					{
						SqlDataPull = dr[0].ToString();
						combo_box3.Items.Add(SqlDataPull);
					}
				}
				
				catch(Exception e)
				{
					MessageBox.Show(contentAfterLastHyphen.ToString());
				}
				
				finally
				{
					conn_sc.Close();
					conn_sc.Dispose();
				}
				
				conn_sc = null;
		
//				    try
//				    {
//				    	MessageBox.Show(contentAfterLastHyphen.ToString());
//				        string query = "select StockMicron, StockWidth, StockLength from TBL_PROD_COAT_BOPP_FILM_LIST where StockCode like  '%"+ contentAfterLastHyphen+"%'";
//				        SqlDataAdapter da = new SqlDataAdapter(query, conn_sc);
//				        conn_sc.Open();
//				        DataSet ds = new DataSet();
//				        da.Fill(ds, "TBL_PROD_COAT_BOPP_FILM_LIST");
//				        combo_box3.DisplayMember =  "StockCode";
//				        combo_box3.ValueMember = "StockMicron";
//				        combo_box3.ValueMember = "StockWidth";
//				        combo_box3.ValueMember = "StockLength";
//				        combo_box3.DataSource = ds.Tables["TBL_PROD_COAT_BOPP_FILM_LIST"];
//				    }
//				    catch (Exception ex)
//				    {
//				        // write exception info to log or anything else
//				        MessageBox.Show(contentAfterLastHyphen.ToString());
//				    }               
				}
			conn_sc = null;
			
		}
						
	//}
	//}
		
			
	//=============================================================================================
		
		void Btn_clearClick(object sender, EventArgs e)
		{
			
			btn_stockcode.Visible = true;
			TxtBx_StockCode1.Enabled = true;
			TxtBx_JRColor1.Enabled = true;
			Enable_Edit();
			ClearAllText(this);
			txtbx_jrm2.Text = "0";
			txtbx_qtyorder.Text = "0";
			txtbx_refno.Text = "0";
			txtbx_costglue.Text = "0";
			txtbx_costfilm.Text = "0";
			txtbx_costconvert.Text = "0";
			txtbx_costservice.Text = "0";
			check = false;
			checkstore = false;
			TxtBx_JRColor1.ReadOnly = false;
			TxtBx_StockCode1.ReadOnly = false;
			
		}
		
		
		

		private bool ValidateCalculate()
		{

			if (CommonValidation.ValidateIsEmptyString(txtbx_micmax.Text.Trim()))
            {
                DialogBox.ShowWarningMessage(txtbx_micmax.Text + " cannot be empty.");
                txtbx_micmax.Focus();
                return false;
            }
			else if (CommonValidation.ValidateIsEmptyString(txtbx_minimummic.Text.Trim()))
            {
                DialogBox.ShowWarningMessage(txtbx_minimummic.Text + " cannot be empty.");
                txtbx_minimummic.Focus();
                return false;
            }
			else if (CommonValidation.ValidateIsEmptyString(txtbx_bopp_micron.Text.Trim()))
            {
                DialogBox.ShowWarningMessage(txtbx_bopp_micron.Text + " cannot be empty.");
                txtbx_bopp_micron.Focus();
                return false;
            }
			else if (CommonValidation.ValidateIsEmptyString(txtbx_jrwidth.Text.Trim()))
            {
                DialogBox.ShowWarningMessage(txtbx_jrwidth.Text + " cannot be empty.");
                txtbx_jrwidth.Focus();
                return false;
            }
			else if (CommonValidation.ValidateIsEmptyString(txtbx_jrlength.Text.Trim()))
            {
                DialogBox.ShowWarningMessage(txtbx_jrlength.Text + " cannot be empty.");
                txtbx_jrlength.Focus();
                return false;
            }
			else if (CommonValidation.ValidateIsEmptyString(txtbx_gluewidth.Text.Trim()))
            {
                DialogBox.ShowWarningMessage(txtbx_gluewidth.Text + " cannot be empty.");
                txtbx_gluewidth.Focus();
                return false;
            }
			else if (CommonValidation.ValidateIsEmptyString(txtbx_core.Text.Trim()))
            {
                DialogBox.ShowWarningMessage(txtbx_core.Text + " cannot be empty.");
                txtbx_core.Focus();
                return false;
            }
			else if (CommonValidation.ValidateIsEmptyString(txtbx_gluecode.Text.Trim()))
            {
                DialogBox.ShowWarningMessage(txtbx_gluecode.Text + " cannot be empty.");
                txtbx_gluecode.Focus();
                return false;
            }
			else if (CommonValidation.ValidateIsEmptyString(txtbx_packing.Text.Trim()))
            {
                DialogBox.ShowWarningMessage(txtbx_packing.Text+ " cannot be empty.");
                txtbx_packing.Focus();
                return false;
            }
			else if (CommonValidation.ValidateIsEmptyString(txtbx_jojrqty.Text.Trim()))
            {
                DialogBox.ShowWarningMessage(txtbx_jojrqty.Text+ " cannot be empty.");
               txtbx_jojrqty.Focus();
                return false;
            }

            
            return true;
		}
		
		
		//=========================================================================================
	
		
		void Btn_stockcodeClick(object sender, EventArgs e)
		{
			//TxtBx_StockCode1.Enabled = false;
			//TxtBx_JRColor1.Enabled = false;
			//Unable_Edit();
			//TxtBx_StockCode1
			//btn_delete.Visible = true;
			//check = false;

				
		
			//btn_save.Visible = true;
			TxtBx_JRColor1.ReadOnly = false;
			TxtBx_StockCode1.ReadOnly = false;
			
			
			if (TxtBx_StockCode1.Text == null || TxtBx_StockCode1.Text == string.Empty) 
			{
			
				MessageBox.Show("PLEASE KEY IN STOCKCODE");//+ ex.Message + ex.ToString());//Lbl_Message.Text = "Error? SO?";
				return;
			}
			
			
//			SqlConnection validate_stockcode = new SqlConnection(sqlconn3);
//			SqlCommand cmd_sc = new SqlCommand();
//			
//			
//								try {
//									cmd_sc.CommandText = "select * from VIEW_AXERP_SO_DETAIL where ITEMID = '" + TxtBx_StockCode1.Text + "'";
//									cmd_sc.Connection = validate_stockcode;
//									validate_stockcode.Open();
//									SqlDataReader read_Stockcode = cmd_sc.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
//					
//									if (!read_Stockcode.Read())
//										{
//										MessageBox.Show("STOCKCODE NOT EXIST");
//										return;
//										}
//									}
//			
//								catch (Exception ex) 
//								{
//									validate_stockcode.Close();
//									MessageBox.Show("Error 2.0 : CHECK STOCKCODE!" + ex.ToString() + ex.Message);
//									return;
//								} 
//					
//								finally 
//								{
//									validate_stockcode.Close();
//								}
//								
//								validate_stockcode.Dispose();
//								cmd_sc.Dispose();
//								validate_stockcode = null;
//								cmd_sc = null;
								
								
								
			
			string stockcodeerp = null;
			
			

//			string ERP_MDESC1_objSqlStatement = "select  * VIEW_AXERP_SO_DETAIL where  ITEMID = '"+ TxtBx_StockCode1.Text.ToString() + "'";
//	//"select * from TBL_PROD_COAT_JO where JOSALESNO = '" + txtbx_joso.Text.ToUpper() + "' and JOSALESLINE = '"  + txtbx_soline.Text.ToUpper() + "'";
//	SqlConnection ERP_MDESC1_objConn = new SqlConnection(sqlconn3);
//					try 
//					{
//						ERP_MDESC1_objConn.Open();
//						SqlCommand ERP_MDESC1_objCMD = new SqlCommand(ERP_MDESC1_objSqlStatement, ERP_MDESC1_objConn);
//						SqlDataReader ERP_MDESC1_objDR = ERP_MDESC1_objCMD.ExecuteReader();
//											
//						if (ERP_MDESC1_objDR.HasRows) 
//							{
//						
//								while (ERP_MDESC1_objDR.Read())
//								{
//									
//									TxtBx_JRColor1.Text = ERP_MDESC1_objDR["DOT_PRODATTRIBCOLOR"].ToString().ToUpper();
//									txtbx_sodesc1.Text = ERP_MDESC1_objDR["NAME"].ToString().ToUpper();
//								}
//							
//							}
//							
//												
//							else 
//							{
//							   DialogBox.ShowWarningMessage(" Error 1 : Cannot find  STOCKCODE?");
//							}
//						
//						}
//						
//					
//					catch (Exception ERP_JRColor_exc) 
//					{
//						DialogBox.ShowWarningMessage("Error 2: Cannot read  DB? MDESC1 ?");
//						ERP_MDESC1_objConn.Close();
//						ERP_MDESC1_objConn.Dispose();
//						return;
//					} 
//					finally
//					{
//						ERP_MDESC1_objConn.Close();
//						ERP_MDESC1_objConn.Dispose();					
//					}
//									
//					ERP_MDESC1_objConn = null;
//					ERP_MDESC1_objSqlStatement = null;
					
					
//			string ERPAX_GETLABEL = "select   a.SALESID, a.NOTESETERNAL, a.NOTESSHIPPINGLABEL,b.SALESID, b.ITEMID, b.DOT_PRODATTRIBCOLOR, b.NAME from   VIEW_AXERP_SO a, VIEW_AXERP_SO_DETAIL b where   b.ITEMID = '"+ TxtBx_StockCode1.Text.ToString() + " and a.SALESID = b.SALESID'";
//			//		string ERPAX_GETLABEL = "select * VIEW_AXERP_SO_DETAIL where  ITEMID = '"+ TxtBx_StockCode1.Text.ToString() + "'";
//
//					SqlConnection ERPAX_GETLABELCONN = new SqlConnection(sqlconn3);
//					try
//					{
//
//						ERPAX_GETLABELCONN.Open();
//						SqlCommand ERPAX_COMMAND = new SqlCommand(ERPAX_GETLABEL, ERPAX_GETLABELCONN);
//						SqlDataReader ERPAX_DATAREAD = ERPAX_COMMAND.ExecuteReader();
//						
//						if (ERPAX_DATAREAD.HasRows)
//						{
//							while (ERPAX_DATAREAD.Read())
//							{
//								//TxtBx_JRColor1.Text = ERPAX_DATAREAD["DOT_PRODATTRIBCOLOR"].ToString().ToUpper();
////								//MessageBox.Show("color");
//								//.Text = ERPAX_DATAREAD["ITEMID"].ToString().ToUpper();
//								TxtBx_JRColor1.Text = ERPAX_DATAREAD["DOT_PRODATTRIBCOLOR"].ToString().ToUpper();
//								txtbx_sodesc1.Text = ERPAX_DATAREAD["NAME"].ToString().ToUpper();
//								//txtbx_colour.Text = ERPAX_DATAREAD["DOT_PRODATTRIBCOLOR"].ToString().ToUpper();
//								
//								//txtbx_colour.t = ERPAX_DATAREAD["DOT_PRODATTRIBCOLOR"].ToString().ToUpper();
////								//MessageBox.Show("color");
////								stockcodeerp = ERP_P3_objDR["ITEMID"].ToString().ToUpper();
////								txtbx_remark1.Text = ERPAX_DATAREAD["NOTESEXTERNAL"].ToString();
////								txtbx_remark6.Text = ERPAX_DATAREAD["NOTESSHIPPINGLABEL"].ToString();
//								
//								
////								if (ERPAX_DATAREAD["DOT_PRODATTRIBCOLOR"].ToString() == null || ERPAX_DATAREAD["DOT_PRODATTRIBCOLOR"].ToString() == string.Empty)
////								{
////									txtbx_colour.Text = "-";
////									MessageBox.Show("Error? SO Color?");
////									return;
////								} 
////								else
////								{
////									txtbx_colour.Text = ERPAX_DATAREAD["DOT_PRODATTRIBCOLOR"].ToString();
////								}
//								
//							}
//							
//							
//						
//							
//						}
//						
//						else
//							{
//				
//							DialogBox.ShowWarningMessage("StockCode Not Exist, Can't Proceed JO");
//							}
//						
//						
//						
//						
//
//						
//					}
//					
//					
//					catch (Exception GETNOTE)
//					{
//						//DialogBox.ShowWarningMessage("ERROR: CANNOT READ DBSHIPNOTE" + GETNOTE.ToString().ToUpper() + GETNOTE.Message);
//						ERPAX_GETLABELCONN.Close();
//						ERPAX_GETLABELCONN.Dispose();
//						return;
//					}
//					
//					finally
//					{
//						ERPAX_GETLABELCONN.Close();
//						ERPAX_GETLABELCONN.Dispose();
//					}
//					
//					ERPAX_GETLABELCONN = null;
//					ERPAX_GETLABEL = null;
					
					
					//string ERP_P3_objSqlStatement ="select distinct  a.DOT_PRODATTRIBCOLOR, a.ITEMID FROM VIEW_AXERP_SO_DETAIL a, VIEW_AXERP_SO where a.ITEMID ='" +TxtBx_StockCode1.Text.ToString() +"'" ;
					string ERP_P3_objSqlStatement ="select * FROM VIEW_AXERP_ITEM_MASTER_PROD_ATTRIB where ITEMID ='" + TxtBx_StockCode1.Text.ToString() +"' and NAME = 'COLOR' and itemid like 'W%'" ;
					
					SqlConnection ERP_P3_objConn = new SqlConnection(sqlconn3);
					
					
					try {
						ERP_P3_objConn.Open();
						SqlCommand ERP_P3_objCMD = new SqlCommand(ERP_P3_objSqlStatement, ERP_P3_objConn);
						SqlDataReader ERP_P3_objDR = ERP_P3_objCMD.ExecuteReader();
					 
						if (ERP_P3_objDR.HasRows) 
						{
						
							while (ERP_P3_objDR.Read())
							{
								TxtBx_JRColor1.Text = ERP_P3_objDR["TEXTVALUE"].ToString().ToUpper();
								txtbx_sodesc1.Text = ERP_P3_objDR["PROD_NAME"].ToString().ToUpper();
							}
							
							//TxtBx_StockCode1.Enabled = false;
							//TxtBx_JRColor1.Enabled = false;
							//Unable_Edit();
							//TxtBx_StockCode1
							btn_delete.Visible = true;
							check = false;	
						
							btn_save.Visible = true;
							TxtBx_JRColor1.ReadOnly = true;
							TxtBx_StockCode1.ReadOnly = true;
											
						}			
						else						
						{
							   DialogBox.ShowWarningMessage(" Error 1 : Cannot find stock code");
							   return;
						}
						
					}	
					catch (Exception ERP_P3_exc)
					{
						DialogBox.ShowWarningMessage("Error 2 : read DB"+ ERP_P3_exc.ToString().ToUpper() + ERP_P3_exc.Message);//Lbl_Message.Text = "Error 2: Cannot read  DB" + ERP_P3_exc.ToString.ToUpper + ERP_P3_exc.Message;
						ERP_P3_objConn.Close();
						ERP_P3_objConn.Dispose();
						return;
					} 
					
					finally 
					{
					
						ERP_P3_objConn.Close();
						ERP_P3_objConn.Dispose();
					}
			
					ERP_P3_objConn = null;

					ERP_P3_objSqlStatement = null;
					
					
					//detect_StockCode_Type();	
					
		//-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
				//TxtBx_JRColor1.ReadOnly = true;
				//----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
				if (string.IsNullOrWhiteSpace(txtbx_jrm2.Text)) 
				 
				{
					txtbx_jrm2.Text = "0";
				}
				
				if (string.IsNullOrWhiteSpace(txtbx_jrwidth.Text)) 
				 
				{
					txtbx_jrwidth.Text = "0";
				}
				
				if (string.IsNullOrWhiteSpace(txtbx_jrlength.Text)) 
				 
				{
					txtbx_jrlength.Text = "0";
				}
			
				
			double jrm2 = 0;
            double jojrqty = 0;
            
                
	     
	             	
	             if (txtbx_M2.Text.ToUpper() == "M2")
	             {
	             	
	             	
	                jrm2 = Math.Round(Convert.ToDouble(txtbx_jrwidth.Text)/1000 * Convert.ToDouble(txtbx_jrlength.Text));
	        		txtbx_jrm2.Text = Convert.ToString(jrm2.ToString());
	                jojrqty = Math.Round(Convert.ToDouble(txtbx_qtyorder.Text) / Convert.ToDouble(txtbx_jrm2.Text));
	                txtbx_jojrqty.Text = Convert.ToString (jojrqty.ToString());
	                 
	                 
                 } 
	             else 
	             {
	                 txtbx_jojrqty.Text = "0";
	                 txtbx_jrm2.Text = "0";
                 }
	             
	             
	            
					txtbx_minimummic.Focus();
//======================================================================================================================================================================
//if (TxtBx_StockCode1.Text.Substring(0,7).ToUpper() == "WJ820SC" || TxtBx_StockCode1.Text.Substring(0,6).ToUpper() == "WJ820S")
//					{
//						if (TxtBx_JRColor1.Text =="CLEAR")
//						{
//						MessageBox.Show("STOCKCODE AND COLOUR IS NOT MATCH");
//						//TxtBx_JRColor1.Text = "CLEAR"
//						}
//					}
//					else 
//					{
//						MessageBox.Show("STOCKCODE AND COLOUR IS NOT MATCH");
//					}

					//set_combobox();
							

					//check = false;
		}
		
		
		
//		public void PRODUCT_CODE_OPTION()	
//		{
//			string sqlStatement = "select STOCKCODE_GLUE_DESC  from TBL_STOCKCODE_GLUE";
//			SqlConnection sqlConn = new SqlConnection(sqlconn);
//			DataSet ds = new DataSet();
//			SqlDataAdapter sda = new SqlDataAdapter(sqlStatement, sqlConn);
//					
//			try 
//			{		
//				sqlConn.Open();
//				sda.Fill(ds);
//				txtbx_gluecode.Text = "Please Select";
//						
//			}
//			catch (Exception exc) 
//			{
//				DialogBox.ShowWarningMessage("An error occured while connecting to database" + exc.Message+ exc.ToString());
//				sqlConn.Close();
//				sqlConn.Dispose();
//				return;
//			} 
//			finally 
//			{
//				sqlConn.Close();
//				sqlConn.Dispose();
//			}
//		
//			foreach(DataRow dr1 in ds.Tables[0].Rows)
//			{
//				txtbx_gluecode.Items.Add(dr1["STOCKCODE_GLUE_DESC"].ToString());
//			}
//				
//		}
		
		void Btn_retrieveClick(object sender, EventArgs e)
		{
			
			btn_stockcode.Visible = false;
			btn_delete.Visible = true;
			btn_save.Visible = true;
			check = true;
			
			//string jobord = jobord.Right(3);
			
			
			if (txtbx_refno.Text == null | txtbx_refno.Text == string.Empty) 
			{
        		MessageBox.Show("Please key-in Ref No");
				return;
			}
			
			
			
			SqlConnection Check_Running_Data = new SqlConnection(sqlconn2);
			SqlCommand cmd = new SqlCommand();
								
								
			try 
			{
				cmd.CommandText = "select * from JO_TRX where TrxJoNo  = '"+ txtbx_refno.Text.ToUpper()+"'";
				cmd.Connection = Check_Running_Data;
				Check_Running_Data.Open();
				SqlDataReader rd_Check_Running_Data = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
				
				if (rd_Check_Running_Data.Read())
				{
					if (rd_Check_Running_Data.HasRows) 
					{
						MessageBox.Show("Data Already Running, Can't Edit or Delete Data");//Lbl_Message.Text = "Error 1.0 : Duplicate JO! ";
						return;
					}
				}
			} 
			catch (Exception ex) 
			{
				Check_Running_Data.Close();
				MessageBox.Show("Error 2.0 : Can't Edit or Delete Because Data Already Running!" + ex.ToString() + ex.Message);
				return;
			} 
					
			finally 
			{
					Check_Running_Data.Close();
			}
								
			Check_Running_Data.Dispose();
			cmd.Dispose();
			Check_Running_Data = null;
			cmd = null;
			
			//-----------------------------------------------------------------------------------
			
			SqlConnection con_SP1 = new SqlConnection(sqlconn);
			SqlCommand cmd_SP1 = new SqlCommand();
			
			try 
			{
				cmd_SP1.CommandText = "select * from TBL_PROD_COAT_JO where JODOCNO = '" + txtbx_refno.Text + "'";
				cmd_SP1.Connection = con_SP1;
				con_SP1.Open();
				SqlDataReader rd_SP1 = cmd_SP1.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
				
				if (rd_SP1.Read())
				{
	
					//txtbx_joso.Text = rd_SP1["JOSALESNO"].ToString();
					//txtbx_soline.Text = rd_SP1["JOSALESLINE"].ToString();
					//txtbx_refno.Text = rd_SP1["JODOCNO"].ToString();
					txtbx_socustomer.Text = rd_SP1["JOCUSTOMER"].ToString();
					txtbx_brand.Text = rd_SP1["JOSTOCKBRAND"].ToString(); 
					txtbx_customertype.Text = rd_SP1["JOCUSTOMERTYPE"].ToString();
					combobx_category.Text = rd_SP1["JOJRCATEGORY"].ToString();
					txtbx_sodesc1.Text = rd_SP1["JOSTOCKDESC"].ToString();
					txtbx_sodesc2.Text = rd_SP1["JOSTOCKDESC2"].ToString();
					txtbx_micron.Text = rd_SP1["JOSTOCKMICRON"].ToString();
					txtbx_M2.Text = rd_SP1["JOSTOCKMICRONM2"].ToString();
					txtbx_minimummic.Text = rd_SP1["JOSTOCKMICRONMIN"].ToString();
					txtbx_micmax.Text = rd_SP1["JOSTOCKMICRONMAX"].ToString();
					txtbx_jrwidth.Text = rd_SP1["JOSTOCKWIDTH"].ToString();
					txtbx_jrlength.Text = rd_SP1["JOSTOCKLENGTH"].ToString();
					txtbx_colour.Text = rd_SP1["JOSTOCKCOLOR"].ToString();
					txtbx_qtyorder.Text = rd_SP1["JOQTY"].ToString();
					txtbx_jrm2.Text = rd_SP1["JOJRM2"].ToString();
					txtbx_jojrqty.Text = rd_SP1["JOPRODQTY"].ToString();
			
					txtbx_bopp_micron.Text = rd_SP1["JOFILMMICRON"].ToString();
					txtbx_bopp_width.Text = rd_SP1["JOFILMWIDTH"].ToString();
					txtbx_bopp_length.Text = rd_SP1["JOGLUELENGTH"].ToString();
					txtbx_gluecode.Text = rd_SP1["JOGLUECODE"].ToString();
					txtbx_gluemicron.Text = rd_SP1["JOGLUEMICRON"].ToString();
					txtbx_gluewidth.Text = rd_SP1["JOGLUEWIDTH"].ToString();
					txtbx_wtfilm.Text = rd_SP1["JOWTFILM"].ToString();
					txtbx_wtglue.Text = rd_SP1["JOWTGLUE"].ToString();
					txtbx_total1.Text = rd_SP1["JOWTTOTAL1"].ToString();
					txtbx_core.Text = rd_SP1["JOWTCORE"].ToString();
					txtbx_total2.Text = rd_SP1["JOWTTOTAL2"].ToString();
					txtbx_packing.Text = rd_SP1["JOWTPACK"].ToString();
					txtbx_totalfinal.Text = rd_SP1["JOWTTOTAL3"].ToString();
				
					txtbx_productwidth.Text = rd_SP1["PRODUCTWIDTH"].ToString();
					txtbx_productlength.Text = rd_SP1["PRODUCTLENGTH"].ToString();
					txtbx_kgmin.Text = rd_SP1["JOSTOCKKGMIN"].ToString();
					txtbx_totalkg.Text = rd_SP1["JOSTOCKKGMAX"].ToString();
					txtbx_extrameter.Text = rd_SP1["JOEXTRAMETER"].ToString();
					txtbx_remark1.Text = rd_SP1["JOREMARK1"].ToString();
					txtbx_remark3.Text = rd_SP1["JOREMARK2"].ToString();
					txtbx_remark4.Text = rd_SP1["JOREMARK3"].ToString();
					txtbx_remark5.Text = rd_SP1["JOREMARK4"].ToString();
					txtbx_remark12.Text = rd_SP1["JOREMARK5"].ToString();
					txtbx_smarkcode.Text = rd_SP1["JOSMARKCODE"].ToString();
					txtbx_smarkicode.Text = rd_SP1["JOSMARKLINE"].ToString();
					txtbx_remark6.Text = rd_SP1["JOREMARK6"].ToString();
					txtbx_remark7.Text = rd_SP1["JOREMARK7"].ToString();
					txtbx_remark9.Text = rd_SP1["JOREMARK8"].ToString();
					txtbx_remark10.Text = rd_SP1["JOREMARK9"].ToString();
					txtbx_remark100.Text = rd_SP1["JOREMARK10"].ToString();
					TxtBx_StockCode1.Text = rd_SP1["JRSTOCKCODE"].ToString();
					TxtBx_JRColor1.Text = rd_SP1["JRCOLOR"].ToString();
					txtbx_costglue.Text = rd_SP1["JOCOSTGLUE"].ToString();
					txtbx_costfilm.Text = rd_SP1["JOCOSTFILM"].ToString();
					txtbx_costconvert.Text = rd_SP1["JOCOSTCONV"].ToString();
					txtbx_costservice.Text = rd_SP1["JOCOSTSERVICE"].ToString();
					txtbx_jo_printing.Text = rd_SP1["JODOCNO_PRINTING"].ToString();


					dateTimePicker1.Value = Convert.ToDateTime(rd_SP1["ETDDATETIME"]);
						
				
						
    					//txtbx_jrm2.Text = rd_SP1["JOJRM2"].ToString();
						
						
					txtbx_productwidth.Text = rd_SP1["PRODUCTWIDTH"].ToString();
				
					txtbx_customertype.Text = rd_SP1["JOCUSTOMERTYPE"].ToString();

					TxtBx_StockCode1.Text = rd_SP1["JRSTOCKCODE"].ToString();

					combo_box3.Text = rd_SP1["JOJRCATEGORY"].ToString();
					combo_box3.SelectedValue = rd_SP1["JOJRCATEGORY"].ToString();
//--------------------------------------------------------------------------------------------
					dateTimePicker1.Text = rd_SP1["ETDDATETIME"].ToString();
					//dateTimePicker1.Value  = rd_SP1["@SP_JOUSERDATETIME"].ToString();
					
					
					combo_box3.Text = rd_SP1["JOFILMCODE"].ToString();
					combo_box3.SelectedValue  = rd_SP1["JOFILMCODE"].ToString();
					//combo_box3.Text = rd_SP1["JOFILMCODE"].ToString();
					
					
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
		
		void Frm_prod_coating_jo_stockcodeLoad(object sender, EventArgs e)
		{
			txtbx_costglue.Text = "0";
			txtbx_costfilm.Text = "0";
			txtbx_costconvert.Text = "0";
			txtbx_costservice.Text = "0";
			txtbx_productlength.Text = txtbx_jrlength.Text;
			txtbx_productwidth.Text = txtbx_jrlength.Text;
			
			SqlConnection sqlConnection1 = new SqlConnection(sqlconn);
			SqlCommand cmd = new SqlCommand();
			Int32 rowsAffected;
			
			cmd.CommandText = "SP_PROD_COAT_OPEN_JO";
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.Connection = sqlConnection1;

			sqlConnection1.Open();

			rowsAffected = cmd.ExecuteNonQuery();

			sqlConnection1.Close();
			
			datagrid();
		}
		
		
		void datagrid()
		{
			string sql = "SELECT * FROM TBL_PROD_COAT_OPEN_JO";
            SqlConnection connection = new SqlConnection(sqlconn);
            SqlDataAdapter dataadapter = new SqlDataAdapter(sql, connection);
            DataTable ds = new DataTable();
            connection.Open();
            dataadapter.Fill(ds);
                     
            DataTable tempDT = new DataTable();
  			tempDT = ds.DefaultView.ToTable(true,"JODOCNO","JODOCNO_PRINTING","JRSTOCKCODE","JOSALESNO" ,"JOSALESLINE" ,"JOSHIPMARK" ,"JOSTOCKCOLOR" ,"PRODUCTWIDTH" ,"PRODUCTLENGTH");
   			dataGridView1.DataSource = tempDT;
   
  			connection.Close();

   			dataGridView1.Columns[0].HeaderText = "JO NO";
   			dataGridView1.Columns[1].HeaderText = "JODOCNO_PRINTING";
  			dataGridView1.Columns[2].HeaderText = "JRSTOCKCODE";
   			dataGridView1.Columns[3].HeaderText = "JOSALESNO";
   			dataGridView1.Columns[4].HeaderText = "JOSALESLINE";
   			dataGridView1.Columns[5].HeaderText = "JOSHIPMARK";
   			dataGridView1.Columns[6].HeaderText = "JOSTOCKCOLOR";
   			dataGridView1.Columns[7].HeaderText = "PRODUCT WIDTH";
   			dataGridView1.Columns[7].HeaderText = "PRODUCT LENGTH";
		}
		
		
		
		
//		void Txtbx_extrameterTextChanged(object sender, EventArgs e)
//		{
//			if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
//			{
//   			 e.Handled = true;
//			}
//		}
		
		void Txtbx_search_jonoTextChanged(object sender, EventArgs e)
		{
			SqlConnection connection2 = new SqlConnection(sqlconn);
           // SqlDataAdapter dataadapter = new SqlDataAdapter(sql, connection2);
           // DataTable ds2 = new DataTable();
         	connection2.Open();
            //dataadapter.Fill(ds2);
            
            
		
			SqlDataAdapter da = new SqlDataAdapter("Select JODOCNO,JODOCNO_PRINTING,JRSTOCKCODE,JOSALESNO ,JOSALESLINE ,JOSHIPMARK ,JOSTOCKCOLOR ,PRODUCTWIDTH ,PRODUCTLENGTH from TBL_PROD_COAT_OPEN_JO Where JODOCNO like '" +  txtbx_search_jono.Text + "%'",connection2);
			DataTable dt2 = new DataTable();
			da.Fill(dt2);
			dataGridView1.DataSource= dt2;
			dataGridView1.Refresh();
			connection2.Close();
		}
	}
}
	
	
