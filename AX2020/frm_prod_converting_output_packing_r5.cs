using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic; // For generic collections like List.
using System.Data.SqlClient;      // For the database connections and objects.
using System.Data.Sql;
using System.Data;
using CommonFunction;
using CommonLibrary;
using CommonControl.Functions;
using System.Diagnostics;

namespace AX2020
{
	
	public partial class frm_prod_converting_output_packing_r5 : Form
	{
		public static string sqlconn = "Server=AX-UAT; Password=sbax2020sbg; User ID=sbax2020; Initial Catalog=SBG_AX_2020; Integrated Security=false";
		public static string sqlconnStaging = "Server=AX-SQL; Password=ax2020sbgroup; User ID=ax2020sb; Initial Catalog=AX2020StagingDB; Integrated Security=false";
        
		string ref_no = null, line_no = null, init = "0";
		int NextNo, NextNoSlit;
		string username, prod_line = null, prod_line_slit = null, remark5 = null;
		double qty_ctn_ordered = 0, qty_roll_ordered = 0, total = 0, qty_roll_prod = 0, qty_roll_prod_2 = 0; //balance = 0, consume = 0;
		bool clickCheck = false;
		
		//string jr_ref_no, jr_color, jr_shipmark, jr_barcode, jr_stockcode, jr_micron, jr_width, jr_length;
		string jr_ref_no1, jr_color1, jr_shipmark1, jr_barcode1, jr_stockcode1, jr_micron1, jr_width1, jr_length1;
		string jr_ref_no2, jr_color2, jr_shipmark2, jr_barcode2, jr_stockcode2, jr_micron2, jr_width2, jr_length2;
		string jr_ref_no3, jr_color3, jr_shipmark3, jr_barcode3, jr_stockcode3, jr_micron3, jr_width3, jr_length3;
		string jr_ref_no4, jr_color4, jr_shipmark4, jr_barcode4, jr_stockcode4, jr_micron4, jr_width4, jr_length4;
		string jr_ref_no5, jr_color5, jr_shipmark5, jr_barcode5, jr_stockcode5, jr_micron5, jr_width5, jr_length5;
		
		int shipmark_ori_length1 = 0,  shipmark_ori_length2 = 0,  shipmark_ori_length3 = 0,  shipmark_ori_length4 = 0,  shipmark_ori_length5 = 0;
	
		double  get_qty1 = 0, qty_realmetre1 = 0, balance1 = 0, consume1 = 0;
		double  get_qty2 = 0, qty_realmetre2 = 0, balance2 = 0, consume2 = 0;
		double  get_qty3 = 0, qty_realmetre3 = 0, balance3 = 0, consume3 = 0;
		double  get_qty4 = 0, qty_realmetre4 = 0, balance4 = 0, consume4 = 0;
		double  get_qty5 = 0, qty_realmetre5 = 0, balance5 = 0, consume5 = 0;
		
		double sum_consume = 0, sum_jr_m2 = 0;
		
		
		//------------------init------------------------------------
		
		public frm_prod_converting_output_packing_r5()
		{
			InitializeComponent();
			this.ControlBox = false;
			
			username = frm_menu_system.userName; 
			lbl_username.Text = "User : " + username;
			
			DropDownList("SELECT * FROM TBL_PROD_CONV_JO_MACHINE_LIST WHERE PART = 'PACKING' order by MACHINE_NO", cbx_machine, "MACHINE_NO");	
			DropDownList("SELECT * FROM TBL_PROD_CONV_JO_OUTPUT_SHIFT", cbx_shift, "SHIFT");
			DropDownList("SELECT sysstaffname FROM TBL_ADMIN_USER_FACTORY where sysdept = 'SLITTING' or sysdept = 'RCP' or sysdept = 'PAPER CORE' or sysdept = 'RIBBON'", cbx_operator, "sysstaffname");
			DropDownList("SELECT sysstaffname FROM TBL_ADMIN_USER_FACTORY where sysdept = 'SLITTING' or sysdept = 'RCP' or sysdept = 'PAPER CORE' or sysdept = 'RIBBON'", cbx_helper, "sysstaffname");
			
			DisableControls(this);
			EnableControls(txtbx_ref_no);
			EnableControls(btn_search);
			EnableControls(btn_cancel);
			EnableControls(btn_clear);
			EnableControls(lbl_ref_no);
			EnableControls(dt_grid);
			EnableControls(lbl_header);
			EnableControls(btn_report);
			
		}
		
		void Frm_prod_converting_output_packing_r3Load(object sender, EventArgs e)
		{
			DataGrid();
			ClearAllText(this);
			btn_del.Enabled = false;
			//txtbx_jr_lot_no_img1.Text = string.Empty;
			
		}
		
		private void DisableControls(Control con)
		{
        	foreach (Control c in con.Controls) 
        	{
            	DisableControls(c);
        	}
        	
        	con.Enabled = false;
    	}
		
		private void EnableControls(Control con) 
		 {
        	if (con != null) 
        	{
            	con.Enabled = true;
            	EnableControls(con.Parent);
        	}
    	}
		 
		private void EnableAllControls(Control con) 
		{
        	foreach (Control c in con.Controls) 
        	{
            	EnableAllControls(c);
        	}
        	
        	con.Enabled = true;
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
                //((ComboBox)c).Text = "Please Select";
      				((ComboBox)c).SelectedValue = "Please Select";
				
      			if(c is DateTimePicker)
				{
					((DateTimePicker)c).Value = DateTime.Now;
				}        			
								
   			}
    		
    		ClearVariable(); 

    		
   		
		  		
		}
		
		void ClearAllTextGroupBx(GroupBox gbx)
        {
            foreach (Control c in gbx.Controls)
            {
                if (c is TextBox)
                {
                	((TextBox)c).Clear();
                }
            }
        }
		
		void ClearVariable()
		{
			sum_consume = 0;
			sum_jr_m2 = 0;
			clickCheck = false;
			total 					= 0;
    		qty_ctn_ordered 		= 0;
    		qty_roll_ordered 		= 0;
    		qty_roll_prod 			= 0;
    		qty_roll_prod_2 		= 0;
    		
    		txtbx_ctn_qty.Text 		= init;
    		txtbx_roll_qty.Text 	= init;
    		txtbx_total_roll.Text 	= init;
    		
    		txtbx_ctn_1.Text 		= init;
		 	txtbx_ctn_2.Text 		= init;
		 	txtbx_ctn_3.Text 		= init;
		 	txtbx_ctn_4.Text 		= init;
		 	txtbx_ctn_5.Text 		= init;
		 	
		 	txtbx_roll_1.Text 		= init;
		 	txtbx_roll_2.Text 		= init;
		 	txtbx_roll_3.Text 		= init;
		 	txtbx_roll_4.Text 		= init;
		 	txtbx_roll_5.Text 		= init;
		 	
		 	txtbx_reject_1.Text     = init;
		 	txtbx_reject_2.Text     = init;
		 	txtbx_reject_3.Text     = init;
		 	txtbx_reject_4.Text     = init;
		 	txtbx_reject_5.Text     = init;
		 	
		 	txtbx_waste1.Text = init;
		 	txtbx_waste2.Text = init;
		 	txtbx_waste3.Text = init;
		 	txtbx_waste4.Text = init;
		 	txtbx_waste5.Text = init;
		 	
		 	txtbx_waste_p1.Text = init;
		 	txtbx_waste_p2.Text = init;
		 	txtbx_waste_p3.Text = init;
		 	txtbx_waste_p4.Text = init;
		 	txtbx_waste_p5.Text = init;
		 	
		 	txtbx_bal1.Text = init;
		 	txtbx_bal2.Text = init;
		 	txtbx_bal3.Text = init;
		 	txtbx_bal4.Text = init;
		 	txtbx_bal5.Text = init;
		 	
    		txtbx_jr_lot_no1.Text 		= string.Empty;
    		txtbx_jr_lot_no_img1.Text 	= string.Empty;		
    		txtbx_jrlotno1.Text 		= string.Empty;
    		
    		txtbx_jr_lot_no2.Text 		= string.Empty;
    		txtbx_jr_lot_no_img2.Text 	= string.Empty;		
    		txtbx_jrlotno2.Text 		= string.Empty;
    		
    		txtbx_jr_lot_no3.Text 		= string.Empty;
    		txtbx_jr_lot_no_img3.Text 	= string.Empty;		
    		txtbx_jrlotno3.Text 		= string.Empty;
    		
    		txtbx_jr_lot_no4.Text 		= string.Empty;
    		txtbx_jr_lot_no_img4.Text 	= string.Empty;		
    		txtbx_jrlotno4.Text 		= string.Empty;
    		
    		txtbx_jr_lot_no5.Text 		= string.Empty;
    		txtbx_jr_lot_no_img5.Text 	= string.Empty;		
    		txtbx_jrlotno5.Text 		= string.Empty;
    		
    		txtbx_batch_no.Text 	= string.Empty;
    		
    		remark5 = null;
    		ref_no = null;
    		line_no = null;
			NextNo = 0;
			
			//jr_lot_no = null;
			jr_ref_no1 				= null;
			jr_color1 				= null;
			jr_shipmark1 			= null;
			jr_barcode1 			= null;
			jr_stockcode1 			= null;
			jr_micron1 				= null;
			jr_width1 				= null;
			jr_length1 				= null;
			//shipmark_bal1 = 0;
		 	shipmark_ori_length1 	= 0;
		 	get_qty1 				= 0; 
		 	qty_realmetre1 			= 0;
		 	
		 	jr_ref_no2 = null;
			jr_color2 = null;
			jr_shipmark2 = null;
			jr_barcode2 = null;
			jr_stockcode2 = null;
			jr_micron2 = null;
			jr_width2 = null;
			jr_length2 = null;
			//shipmark_bal2 = 0;
		 	shipmark_ori_length2 = 0;
		 	get_qty2 = 0; 
		 	qty_realmetre2 = 0;
		 	
		 	jr_ref_no3 = null;
			jr_color3 = null;
			jr_shipmark3 = null;
			jr_barcode3 = null;
			jr_stockcode3 = null;
			jr_micron3 = null;
			jr_width3 = null;
			jr_length3 = null;
			//shipmark_bal3 = 0;
		 	shipmark_ori_length3 = 0;
		 	get_qty3 = 0; 
		 	qty_realmetre3 = 0;
		 	
		 	jr_ref_no4 = null;
			jr_color4 = null;
			jr_shipmark4 = null;
			jr_barcode4 = null;
			jr_stockcode4 = null;
			jr_micron4 = null;
			jr_width4 = null;
			jr_length4 = null;
			//shipmark_bal4 = 0;
		 	shipmark_ori_length4 = 0;
		 	get_qty4 = 0; 
		 	qty_realmetre4 = 0;
		 	
		 	jr_ref_no5 = null;
			jr_color5 = null;
			jr_shipmark5 = null;
			jr_barcode5 = null;
			jr_stockcode5 = null;
			jr_micron5 = null;
			jr_width5 = null;
			jr_length5 = null;
			//shipmark_bal5 = 0;
		 	shipmark_ori_length5 = 0;
		 	get_qty5 = 0; 
		 	qty_realmetre5 = 0;
		 	
		 	balance1 = 0;
		 	consume1 = 0;
		 	balance2 = 0;
		 	consume2 = 0;
		 	balance3 = 0;
		 	consume3 = 0;
		 	balance4 = 0;
		 	consume4 = 0;
		 	balance5 = 0;
		 	consume5 = 0;
		 	
		 	
		 	
		}
		
		private void DropDownList(string cmd, ComboBox cbx_text, string col_name)
		{
		    SqlConnection conn = new SqlConnection(sqlconn);
            DataSet ds = new DataSet();
            string cmdSQL = cmd;
            SqlDataAdapter sda = new SqlDataAdapter(cmdSQL, conn);

            try
            {
                conn.Open();
                sda.Fill(ds);
                cbx_text.Items.Add("Please Select");
            
            }
            catch(SqlException se)
            {
            	MessageBox.Show("An error occured while connecting to database" + se.ToString() + se.Message);
            }
            finally
            {
                conn.Close();
 
	           	foreach(DataRow dr1 in ds.Tables[0].Rows)
	           	{
	               cbx_text.Items.Add(dr1[col_name].ToString());
	           	}
            }
            cbx_text.SelectedItem = "Please Select";
		}
		
		void DataGrid()
		{
			try
			{
				string sql = "SELECT * FROM TBL_PROD_CONV_JO_PACKING WHERE PROD_DATE>= DATEADD(day,-15, getdate()) and PROD_USERREVISION <> 'SAPS' order by PROD_DATE DESC, PROD_SHIFT, PROD_LINE";
		        SqlConnection connection = new SqlConnection(sqlconn);
		        SqlDataAdapter dataadapter = new SqlDataAdapter(sql, connection);
		        DataTable ds = new DataTable();
		        connection.Open();
		        dataadapter.Fill(ds);
		                     
		        DataTable tempDT = new DataTable();
				tempDT = ds.DefaultView.ToTable(true, "PROD_DOCNO", "PROD_LINE", "PROD_DATE", "PROD_SHIFT", "PROD_CUSTOMER", "PROD_CODE", "PROD_BRAND", "PROD_COLOR", "PROD_MICRON", "PROD_WIDTH", "PROD_LENGTH", "PROD_QTYCTN", "PROD_QTYROLL");
				dt_grid.DataSource = tempDT;
					
			}
			catch(Exception ex)
			{
				MessageBox.Show("Error" + ex.Message + ex.ToString());
				return;
			}
			finally
			{
				dt_grid.Columns[0].HeaderText = "Ref No";
				dt_grid.Columns[0].Width = 150;
				dt_grid.Columns[1].HeaderText = "Line No";
				dt_grid.Columns[1].Width = 80;				
				dt_grid.Columns[2].HeaderText = "Date";
				dt_grid.Columns[2].Width = 60;				
				dt_grid.Columns[3].HeaderText = "Shift";
				dt_grid.Columns[3].Width = 80;				
				dt_grid.Columns[4].HeaderText = "Customer";
				dt_grid.Columns[4].Width = 150;
				dt_grid.Columns[5].HeaderText = "Code";
				dt_grid.Columns[5].Width = 80;
				dt_grid.Columns[6].HeaderText = "Brand";
				dt_grid.Columns[6].Width = 80;
				dt_grid.Columns[7].HeaderText = "Color";
				dt_grid.Columns[7].Width = 80;
				dt_grid.Columns[8].HeaderText = "Micron";
				dt_grid.Columns[9].HeaderText = "Width";
				dt_grid.Columns[10].HeaderText = "Length";
				dt_grid.Columns[11].HeaderText = "Qty Ctn";
				dt_grid.Columns[12].HeaderText = "Qty Roll";

			}

		}
		
		
		//------------button---------------------------------------------
		
		void Btn_clearClick(object sender, EventArgs e)
		{
			CalcWaste1();
//			ClearAllText(this);	
//			ClearVariable();
//			DataGrid();	
//			btn_save.Enabled = true;
//			btn_del.Enabled = false;
//			txtbx_ref_no.Focus();
						
		}
		
		void Btn_cancelClick(object sender, EventArgs e)
		{
			this.Close();    
		}
				
		void Btn_searchClick(object sender, EventArgs e)
		{
			//AlreadySlit();
			Search();		
		}
		
		void Btn_reportClick(object sender, EventArgs e)
		{
			this.Hide();
			using(frm_rpt_converting_pack_detail frm_conv_pack_detail = new frm_rpt_converting_pack_detail())
				frm_conv_pack_detail.ShowDialog();
			this.Show();			
		}
		
		void Btn_delClick(object sender, EventArgs e)
		{
			if (!Validation())
                return;
			
//			SqlConnection con_check = new SqlConnection(sqlconn);
//			SqlCommand cmd_check = new SqlCommand();
//			
//			try 
//			{
//				cmd_check.CommandText = @"select * from TBL_PROD_CONV_JO_PACKING where PROD_DOCNO = @doc_no";
//				cmd_check.Parameters.AddWithValue("@doc_no",  txtbx_ref_no.Text);
//				
//				cmd_check.Connection = con_check;
//				con_check.Open();
//				SqlDataReader rd_check = cmd_check.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
//
//				if (rd_check.HasRows)
//				{
//					if (rd_check.Read())
//					{
//						MessageBox.Show("Cannot delete. Packing already has been made. \nDelete Packing first if you want to delete this.");
//						return;
//					}
//
//				}
//			}
//			catch (Exception ex)
//			{
//				con_check.Close();
//				MessageBox.Show("Error - Slitting Check \n" + ex.Message + ex.ToString());
//				return;
//			} 
//			finally 
//			{
//				con_check.Close();
//			}
//			
//			con_check.Dispose();
//			cmd_check.Dispose();
//			con_check = null;
//			cmd_check = null;
			
			
//			DialogResult del = new DialogResult();
//            del = MessageBox.Show("Are you sure you want to delete it?", "Delete", 
//                     MessageBoxButtons.YesNo, 
//                     MessageBoxIcon.Warning, 
//                     MessageBoxDefaultButton.Button2);
//            if (del == DialogResult.Yes)
//            {
//            	TotalRollCalculation();
//            	
//            	if (this.dt_grid.SelectedRows.Count > 0)
//            	{
//	            	if(sqlConnParm("SP_PROD_CONV_JO_PACKING_DEL"))
//	            	{
//	            		UpdateBal("SP_PROD_CONV_UPDATE_PACK_DEL");
//	            		dt_grid.Rows.RemoveAt(this.dt_grid.SelectedRows[0].Index);
//						//MessageBox.Show("The data has been deleted");
//						DialogBox.ShowDeleteSuccessDialog();
//	            	}
//	            	else return;
//            	}
//            	ClearAllText(this);
//            	btn_del.Enabled = false;
//            	btn_save.Enabled = true;
//            }
		}
		
		void Btn_saveClick(object sender, EventArgs e)
		{	
			if (clickCheck == false)
			{
				MessageBox.Show("Please make sure you click the Check button");
				return;
			}
			
			if (!Validation())
                return;
			

			if(String.IsNullOrEmpty(txtbx_jr_lot_no1.Text) && !String.IsNullOrEmpty(txtbx_jrlotno1.Text))
			{
				MessageBox.Show("JR 1 invalid");
				return;
			}
			
			if(String.IsNullOrEmpty(txtbx_jr_lot_no2.Text) && !String.IsNullOrEmpty(txtbx_jrlotno2.Text))
			{
				MessageBox.Show("JR 2 invalid");
				return;
			}
			
			if(String.IsNullOrEmpty(txtbx_jr_lot_no3.Text) && !String.IsNullOrEmpty(txtbx_jrlotno3.Text))
			{
				MessageBox.Show("JR 3 invalid");
				return;
			}
			
			if(String.IsNullOrEmpty(txtbx_jr_lot_no4.Text) && !String.IsNullOrEmpty(txtbx_jrlotno4.Text))
			{
				MessageBox.Show("JR 4 invalid");
				return;
			}
			
			if(String.IsNullOrEmpty(txtbx_jr_lot_no5.Text) && !String.IsNullOrEmpty(txtbx_jrlotno5.Text))
			{
				MessageBox.Show("JR 5 invalid");
				return;
			}
				
			
			TotalRollCalculation();
			
			
			if(!String.IsNullOrEmpty(txtbx_jr_lot_no1.Text))
			{
				ConsumeCalculation1();
			}
			if(!String.IsNullOrEmpty(txtbx_jr_lot_no2.Text))
			{
				ConsumeCalculation2();
			}
			if(!String.IsNullOrEmpty(txtbx_jr_lot_no3.Text))
			{
				ConsumeCalculation3();
			}
			if(!String.IsNullOrEmpty(txtbx_jr_lot_no4.Text))
			{
				ConsumeCalculation4();
			}
			if(!String.IsNullOrEmpty(txtbx_jr_lot_no5.Text))
			{
				ConsumeCalculation5();
			}
			
//			if(remark5 == "SLITTING")
//			{
//				if(!String.IsNullOrEmpty(txtbx_jr_lot_no1.Text))
//				{
//					if(!AllowSaveSlit(consume1, get_qty1, txtbx_result_1))
//					{
//						return;
//					}
//				}
//				
//				if(!String.IsNullOrEmpty(txtbx_jr_lot_no2.Text))
//				{
//					if(!AllowSaveSlit(consume2, get_qty2, txtbx_result_2))
//					{
//						return;
//					}
//				}
//				
//				if(!String.IsNullOrEmpty(txtbx_jr_lot_no3.Text))
//				{
//					if(!AllowSaveSlit(consume3, get_qty3, txtbx_result_3))
//					{
//						return;
//					}
//				}
//				
//				if(!String.IsNullOrEmpty(txtbx_jr_lot_no4.Text))
//				{
//					if(!AllowSaveSlit(consume4, get_qty4, txtbx_result_4))
//					{
//						return;
//					}
//				}
//				
//				if(!String.IsNullOrEmpty(txtbx_jr_lot_no5.Text))
//				{
//					if(!AllowSaveSlit(consume5, get_qty5, txtbx_result_5))
//					{
//						return;
//					}
//				}
//				
//			}

				
			if (LineNoGenerator())
			{
						
				if(!sqlConnParm("SP_PROD_CONV_JO_PACKING_ADD_R3_2", jr_shipmark1, jr_width1, jr_length1, jr_micron1, txtbx_jr_lot_no1, 
				                jr_ref_no1, jr_color1, jr_stockcode1, consume1, balance1, txtbx_reject_1))
				{
					return;
				}
				
				UpdateBal3("SP_PROD_CONV_UPDATE_PACK_R3");
				
				frm_messageBox2 msg = new frm_messageBox2();
				msg.ShowDialog();
				
				TempTable();
				Print();
				ClearAllTextGroupBx(grpbox_output);
				ClearAllTextGroupBx(grpbox_cust);
				ClearVariable();
				txtbx_ref_no.Clear();
				txtbx_ref_no.Focus();
				btn_save.Enabled = true;
				btn_del.Enabled = false;
					
				DataGrid();
			
			}
			else
				return;
					
			
		}
		
		void CalcWaste1()
		{
			double cons = 0;
			
			cons = ((Double.Parse(txtbx_ctn_1.Text) * Double.Parse(txtbx_conversion.Text) 
			                      + Double.Parse(txtbx_roll_1.Text) + Double.Parse(txtbx_reject_1.Text)) 
			                      * Double.Parse(txtbx_width_cust.Text)
			                      * Double.Parse(txtbx_length_cust.Text)
			                      / (double)1000);
			
			txtbx_waste1.Text = (get_qty1 - cons - ((double)Double.Parse(txtbx_bal1.Text)*Double.Parse(txtbx_width_cust.Text)/1000)).ToString();
			
			txtbx_waste_p1.Text = (Double.Parse(txtbx_waste1.Text) * 100 / get_qty1).ToString();
		}
		
		void CalcWaste2()
		{
			double cons = 0;
			
			cons = ((Double.Parse(txtbx_ctn_2.Text) * Double.Parse(txtbx_conversion.Text) 
			                      + Double.Parse(txtbx_roll_2.Text) + Double.Parse(txtbx_reject_2.Text)) 
			                      * Double.Parse(txtbx_width_cust.Text)
			                      * Double.Parse(txtbx_length_cust.Text)
			                      / (double)1000);
			
			txtbx_waste2.Text = (get_qty2 - cons - ((double)Double.Parse(txtbx_bal2.Text)*Double.Parse(txtbx_width_cust.Text)/1000)).ToString();
			
			txtbx_waste_p2.Text = (Double.Parse(txtbx_waste2.Text) * 100 / get_qty2).ToString();
		}
		
		void CalcWaste3()
		{
			double cons = 0;
			
			cons = ((Double.Parse(txtbx_ctn_3.Text) * Double.Parse(txtbx_conversion.Text) 
			                      + Double.Parse(txtbx_roll_3.Text) + Double.Parse(txtbx_reject_3.Text)) 
			                      * Double.Parse(txtbx_width_cust.Text)
			                      * Double.Parse(txtbx_length_cust.Text)
			                      / (double)1000);
			
			txtbx_waste3.Text = (get_qty3 - cons - ((double)Double.Parse(txtbx_bal3.Text)*Double.Parse(txtbx_width_cust.Text)/1000)).ToString();
			
			txtbx_waste_p3.Text = (Double.Parse(txtbx_waste3.Text) * 100 / get_qty3).ToString();
		}
		
		void CalcWaste4()
		{
			double cons = 0;
			
			cons = ((Double.Parse(txtbx_ctn_4.Text) * Double.Parse(txtbx_conversion.Text) 
			                      + Double.Parse(txtbx_roll_4.Text) + Double.Parse(txtbx_reject_4.Text)) 
			                      * Double.Parse(txtbx_width_cust.Text)
			                      * Double.Parse(txtbx_length_cust.Text)
			                      / (double)1000);
			
			txtbx_waste4.Text = (get_qty4 - cons - ((double)Double.Parse(txtbx_bal4.Text)*Double.Parse(txtbx_width_cust.Text)/1000)).ToString();
			
			txtbx_waste_p4.Text = (Double.Parse(txtbx_waste4.Text) * 100 / get_qty4).ToString();
		}
		
		void CalcWaste5()
		{
			double cons = 0;
			
			cons = ((Double.Parse(txtbx_ctn_5.Text) * Double.Parse(txtbx_conversion.Text) 
			                      + Double.Parse(txtbx_roll_5.Text) + Double.Parse(txtbx_reject_5.Text)) 
			                      * Double.Parse(txtbx_width_cust.Text)
			                      * Double.Parse(txtbx_length_cust.Text)
			                      / (double)1000);
			
			txtbx_waste5.Text = (get_qty5 - cons - ((double)Double.Parse(txtbx_bal5.Text)*Double.Parse(txtbx_width_cust.Text)/1000)).ToString();
			
			txtbx_waste_p5.Text = (Double.Parse(txtbx_waste5.Text) * 100 / get_qty5).ToString();
		}
		
		void Btn_jrlotnoClick(object sender, EventArgs e)
		{
			if(!ValidateJR())
			{
				return;
			}
			else
			{
				txtbx_jr_lot_no_img1.Text 	= string.Empty;
				txtbx_jr_lot_no1.Text 		= string.Empty;
				txtbx_result_1.Text 		= string.Empty;
				
				txtbx_jr_lot_no_img2.Text 	= string.Empty;
				txtbx_jr_lot_no2.Text 		= string.Empty;
				txtbx_result_2.Text 		= string.Empty;
				
				txtbx_jr_lot_no_img3.Text 	= string.Empty;
				txtbx_jr_lot_no3.Text 		= string.Empty;
				txtbx_result_3.Text 		= string.Empty;
				
				txtbx_jr_lot_no_img4.Text 	= string.Empty;
				txtbx_jr_lot_no4.Text 		= string.Empty;
				txtbx_result_4.Text 		= string.Empty;
				
				txtbx_jr_lot_no_img5.Text 	= string.Empty;
				txtbx_jr_lot_no5.Text 		= string.Empty;
				txtbx_result_5.Text 		= string.Empty;

				if(!String.IsNullOrEmpty(txtbx_jrlotno1.Text))
				{
//					CheckJRLotNo(txtbx_jrlotno1, txtbx_jr_lot_no_img1, txtbx_jr_lot_no1, jr_shipmark1,
//		                         jr_ref_no1, jr_micron1, jr_color1, jr_barcode1, jr_stockcode1, 
//		                         jr_width1, shipmark_ori_length1, get_qty1, qty_realmetre1, jr_length1, txtbx_result_1);
					if(!PreCheck(txtbx_jrlotno1.Text))
					{
						return;
					}
					CheckJRLotNo1();
					//CalcWaste1();
				}
				if(!String.IsNullOrEmpty(txtbx_jrlotno2.Text))
				{
//					CheckJRLotNo(txtbx_jrlotno2, txtbx_jr_lot_no_img2, txtbx_jr_lot_no2, jr_shipmark2,
//		                         jr_ref_no2, jr_micron2, jr_color2, jr_barcode2, jr_stockcode2, 
//		                         jr_width2, shipmark_ori_length2, get_qty2, qty_realmetre2, jr_length2, txtbx_result_2);
					if(!PreCheck(txtbx_jrlotno2.Text))
					{
						return;
					}
					CheckJRLotNo2();
					//CalcWaste2();
				}
				if(!String.IsNullOrEmpty(txtbx_jrlotno3.Text))
				{
//					CheckJRLotNo(txtbx_jrlotno3, txtbx_jr_lot_no_img3, txtbx_jr_lot_no3, jr_shipmark3,
//		                         jr_ref_no3, jr_micron3, jr_color3, jr_barcode3, jr_stockcode3, 
//		                         jr_width3, shipmark_ori_length3, get_qty3, qty_realmetre3, jr_length3, txtbx_result_3);
					if(!PreCheck(txtbx_jrlotno3.Text))
					{
						return;
					}
					CheckJRLotNo3();
					//CalcWaste3();
				}
				if(!String.IsNullOrEmpty(txtbx_jrlotno4.Text))
				{
//					CheckJRLotNo(txtbx_jrlotno4, txtbx_jr_lot_no_img4, txtbx_jr_lot_no4, jr_shipmark4,
//		                         jr_ref_no4, jr_micron4, jr_color4, jr_barcode4, jr_stockcode4, 
//		                         jr_width4, shipmark_ori_length4, get_qty4, qty_realmetre4, jr_length4, txtbx_result_4);
					if(!PreCheck(txtbx_jrlotno4.Text))
					{
						return;
					}
					CheckJRLotNo4();
					//CalcWaste4();
				}
				if(!String.IsNullOrEmpty(txtbx_jrlotno5.Text))
				{
//					CheckJRLotNo(txtbx_jrlotno5, txtbx_jr_lot_no_img5, txtbx_jr_lot_no5, jr_shipmark5,
//		                         jr_ref_no5, jr_micron5, jr_color5, jr_barcode5, jr_stockcode5, 
//		                         jr_width5, shipmark_ori_length5, get_qty5, qty_realmetre5, jr_length5, txtbx_result_5);
					if(!PreCheck(txtbx_jrlotno5.Text))
					{
						return;
					}
					CheckJRLotNo5();
					//CalcWaste5();
				}
				
				clickCheck = true;
			
						
			}				
		}
		
		
		//-------------validation----------------------------------------
		
		
		void AlreadySlit()
		{
			SqlConnection con = new SqlConnection(sqlconn);
			SqlCommand cmd_seach = new SqlCommand();
				
			try 
			{
				//cmd_seach.CommandText = @"SELECT * FROM TBL_PROD_CONV_JO_SLITTING where PROD_DOCNO = @doc_no";
				cmd_seach.CommandText = @"SELECT TOP 1 * FROM TBL_PROD_CONV_JO_SLITTING where PROD_DOCNO = @doc_no";
				cmd_seach.Parameters.AddWithValue("@doc_no",  txtbx_ref_no.Text.ToUpper());
				cmd_seach.Connection = con;
				con.Open();
				SqlDataReader dr = cmd_seach.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
					
				if (dr.Read() ==  false)
				{					
					//MessageBox.Show("No slitting output found \nMake sure the slitting output already done");
					AlreadyRewind();
					//return;
				} 
			
			} 
			catch (Exception ex) 
			{
				MessageBox.Show("Error : Cannot load DB!" + ex.Message + ex.ToString());
				return;
			} 
			finally 
			{
				con.Close();
			}
			con.Dispose();
			
		}
		
		void AlreadyRewind()
		{
			SqlConnection con = new SqlConnection(sqlconn);
			SqlCommand cmd_seach = new SqlCommand();
				
			try 
			{
				//cmd_seach.CommandText = @"SELECT * FROM TBL_PROD_CONV_JO_SLITTING where PROD_DOCNO = @doc_no";
				cmd_seach.CommandText = @"SELECT TOP 1 * FROM TBL_PROD_CONV_JO_REWINDING where PROD_DOCNO = @doc_no";
				cmd_seach.Parameters.AddWithValue("@doc_no",  txtbx_ref_no.Text.ToUpper());
				cmd_seach.Connection = con;
				con.Open();
				SqlDataReader dr = cmd_seach.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
					
				if (dr.Read() ==  false)
				{					
					//MessageBox.Show("No slitting/rewinding/cutting output found \nMake sure the slitting/rewinding/cutting output already done");
					AlreadyCut();
					//return;
				} 
			
			} 
			catch (Exception ex) 
			{
				MessageBox.Show("Error : Cannot load DB!" + ex.Message + ex.ToString());
				return;
			} 
			finally 
			{
				con.Close();
			}
			con.Dispose();
			
		}
		
		void AlreadyCut()
		{
			SqlConnection con = new SqlConnection(sqlconn);
			SqlCommand cmd_seach = new SqlCommand();
				
			try 
			{
				//cmd_seach.CommandText = @"SELECT * FROM TBL_PROD_CONV_JO_SLITTING where PROD_DOCNO = @doc_no";
				cmd_seach.CommandText = @"SELECT TOP 1 * FROM TBL_PROD_CONV_JO_CUTTING where PROD_DOCNO = @doc_no";
				cmd_seach.Parameters.AddWithValue("@doc_no",  txtbx_ref_no.Text.ToUpper());
				cmd_seach.Connection = con;
				con.Open();
				SqlDataReader dr = cmd_seach.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
					
				if (dr.Read() ==  false)
				{					
					MessageBox.Show("No slitting/rewinding/cutting output found \nMake sure the slitting/rewinding/cutting output already done");
					//return;
				} 
			
			} 
			catch (Exception ex) 
			{
				MessageBox.Show("Error : Cannot load DB!" + ex.Message + ex.ToString());
				return;
			} 
			finally 
			{
				con.Close();
			}
			con.Dispose();
			
		}
		
		private bool ValidateJR()
        {
                  
			if (CommonValidation.ValidateIsEmptyString(txtbx_jrlotno1.Text.Trim()) && 
			    txtbx_ctn_1.Text.Trim() == "0" && 
			    txtbx_roll_1.Text.Trim() == "0" &&
			    CommonValidation.ValidateIsEmptyString(txtbx_jrlotno2.Text.Trim()) &&
			    txtbx_ctn_2.Text.Trim() == "0" &&
			    txtbx_roll_2.Text.Trim() == "0" &&
			    CommonValidation.ValidateIsEmptyString(txtbx_jrlotno3.Text.Trim()) &&
			    txtbx_ctn_3.Text.Trim() == "0" &&
			    txtbx_roll_3.Text.Trim() == "0" &&
			    CommonValidation.ValidateIsEmptyString(txtbx_jrlotno4.Text.Trim()) &&
			    txtbx_ctn_4.Text.Trim() == "0" &&
			    txtbx_roll_4.Text.Trim() == "0" &&
			    CommonValidation.ValidateIsEmptyString(txtbx_jrlotno5.Text.Trim()) &&
			    txtbx_ctn_5.Text.Trim() == "0" &&
			    txtbx_roll_5.Text.Trim() == "0"
			   )
           	{
                DialogBox.ShowWarningMessage(lbl_jr_lot_no.Text + " cannot be empty.");
               	txtbx_jr_lot_no1.Focus();
               	
                return false;     
          	}
			
			else if (CommonValidation.ValidateIsEmptyString(txtbx_jrlotno1.Text.Trim()) && 
			    txtbx_ctn_1.Text.Trim() != "0"
			   )
           	{
                DialogBox.ShowWarningMessage(lbl_jr_lot_no.Text + " cannot be empty.");
               	txtbx_jrlotno1.Focus();
               	
                return false;     
          	}
			
			else if (CommonValidation.ValidateIsEmptyString(txtbx_jrlotno2.Text.Trim()) && 
			    txtbx_ctn_2.Text.Trim() != "0"
			   )
           	{
                DialogBox.ShowWarningMessage(lbl_jr_lot_no.Text + " cannot be empty.");
                txtbx_jrlotno2.Focus();
               	
                return false;     
          	}
			
			else if (CommonValidation.ValidateIsEmptyString(txtbx_jrlotno3.Text.Trim()) && 
			    txtbx_ctn_3.Text.Trim() != "0"
			   )
           	{
                DialogBox.ShowWarningMessage(lbl_jr_lot_no.Text + " cannot be empty.");
               	txtbx_jrlotno3.Focus();
               	
                return false;     
          	}
			
			
			else if (CommonValidation.ValidateIsEmptyString(txtbx_jrlotno4.Text.Trim()) && 
			    txtbx_ctn_4.Text.Trim() != "0"
			   )
           	{
                DialogBox.ShowWarningMessage(lbl_jr_lot_no.Text + " cannot be empty.");
               	txtbx_jrlotno4.Focus();
               	
                return false;     
          	}
			
			
			else if (CommonValidation.ValidateIsEmptyString(txtbx_jrlotno5.Text.Trim()) && 
			    txtbx_ctn_5.Text.Trim() != "0"
			   )
           	{
                DialogBox.ShowWarningMessage(lbl_jr_lot_no.Text + " cannot be empty.");
               	txtbx_jrlotno5.Focus();
               	
                return false;     
          	}
			
			
			else if (txtbx_jrlotno1.Text.Trim() != string.Empty && 
			         (txtbx_ctn_1.Text.Trim() == "0" || txtbx_ctn_1.Text.Trim() == string.Empty) &&
			         (txtbx_roll_1.Text == "0" || txtbx_roll_1.Text.Trim() == string.Empty)
			   )
           	{
				
				DialogBox.ShowWarningMessage(lbl_output_ctn.Text + " cannot be empty.");
           		txtbx_ctn_1.Focus();
           	
            	return false;
				
                     
          	}
			
			else if (txtbx_jrlotno2.Text.Trim() != string.Empty && 
			         (txtbx_ctn_2.Text.Trim() == "0" || txtbx_ctn_2.Text.Trim() == string.Empty) &&
			         (txtbx_roll_2.Text == "0" || txtbx_roll_2.Text.Trim() == string.Empty)
			   )
           	{
                DialogBox.ShowWarningMessage(lbl_output_ctn.Text + " cannot be empty.");
               	txtbx_ctn_2.Focus();
               	
                return false;     
          	}
			
			else if (txtbx_jrlotno3.Text.Trim() != string.Empty && 
			         (txtbx_ctn_3.Text.Trim() == "0" || txtbx_ctn_3.Text.Trim() == string.Empty) &&
			         (txtbx_roll_3.Text == "0" || txtbx_roll_3.Text.Trim() == string.Empty)
			   )
           	{
                DialogBox.ShowWarningMessage(lbl_output_ctn.Text + " cannot be empty.");
               	txtbx_ctn_3.Focus();
               	
                return false;     
          	}
			
			else if (txtbx_jrlotno4.Text.Trim() != string.Empty && 
			         (txtbx_ctn_4.Text.Trim() == "0" || txtbx_ctn_4.Text.Trim() == string.Empty) &&
			         (txtbx_roll_4.Text == "0" || txtbx_roll_4.Text.Trim() == string.Empty)
			   )
           	{
                DialogBox.ShowWarningMessage(lbl_output_ctn.Text + " cannot be empty.");
               	txtbx_ctn_4.Focus();
               	
                return false;     
          	}
			
			
			else if (txtbx_jrlotno5.Text.Trim() != string.Empty && 
			         (txtbx_ctn_5.Text.Trim() == "0" || txtbx_ctn_5.Text.Trim() == string.Empty) &&
			         (txtbx_roll_5.Text == "0" || txtbx_roll_5.Text.Trim() == string.Empty)
			   )
           	{
                DialogBox.ShowWarningMessage(lbl_output_ctn.Text + " cannot be empty.");
               	txtbx_ctn_5.Focus();
               	
                return false;     
          	}
			
			
			else if ((txtbx_bal1.Text.Trim() == string.Empty))
			   
           	{
                DialogBox.ShowWarningMessage(lbl_bal.Text + " cannot be empty.");
               	txtbx_bal1.Focus();
               	
                return false;     
          	}
			
			
			else if ((txtbx_bal2.Text.Trim() == string.Empty))
			   
           	{
                DialogBox.ShowWarningMessage(lbl_bal.Text + " cannot be empty.");
               	txtbx_bal2.Focus();
               	
                return false;     
          	}
			
			
			else if ((txtbx_bal3.Text.Trim() == string.Empty))
			   
           	{
                DialogBox.ShowWarningMessage(lbl_bal.Text + " cannot be empty.");
               	txtbx_bal3.Focus();
               	
                return false;     
          	}
			
			else if ((txtbx_bal4.Text.Trim() == string.Empty))
			   
           	{
                DialogBox.ShowWarningMessage(lbl_bal.Text + " cannot be empty.");
               	txtbx_bal4.Focus();
               	
                return false;     
          	}
			
			else if ((txtbx_bal5.Text.Trim() == string.Empty))
			   
           	{
                DialogBox.ShowWarningMessage(lbl_bal.Text + " cannot be empty.");
               	txtbx_bal5.Focus();
               	
                return false;     
          	}
			
			return true;
			
		}
			
		private bool Validation()
        {
                  
           	if (CommonValidation.ValidateIsEmptyString(cbx_machine.Text.Trim()) || cbx_machine.Text == "Please Select")
           	{
                DialogBox.ShowWarningMessage(lbl_machine_no.Text + " cannot be empty.");
               	cbx_machine.Focus();
               	
                return false;     
          	}
          
           
           	else if (CommonValidation.ValidateIsEmptyString(cbx_shift.Text.Trim()) || cbx_shift.Text == "Please Select")
            {
                DialogBox.ShowWarningMessage(lbl_shift.Text + " cannot be empty.");
                cbx_shift.Focus();
               	
                return false;       
            }
           
//           	else if (CommonValidation.ValidateIsEmptyString(txtbx_ctn_qty.Text.Trim()))
//            {
//                DialogBox.ShowWarningMessage(lbl_ctn_qty.Text + " cannot be empty.");
//                txtbx_ctn_qty.Focus();
//               	
//                return false;       
//            }
//           
//           	else if (CommonValidation.ValidateIsEmptyString(txtbx_roll_qty.Text.Trim()))
//            {
//                DialogBox.ShowWarningMessage(lbl_roll_qty.Text + " cannot be empty.");
//                txtbx_roll_qty.Focus();
//               	
//                return false;       
//            }
               
            else if (CommonValidation.ValidateIsEmptyString(cbx_operator.Text.Trim()) || cbx_operator.Text == "Please Select")
            {
             	DialogBox.ShowWarningMessage(lbl_name.Text + " cannot be empty.");
                cbx_operator.Focus();
                   	
                return false;     
            }
                 
           	else if (CommonValidation.ValidateIsEmptyString(cbx_helper.Text.Trim()) || cbx_helper.Text == "Please Select")
            {
                DialogBox.ShowWarningMessage(lbl_helper.Text + " cannot be empty.");
                cbx_helper.Focus();
                   	
                return false;       
            }
               
//           	else if (CommonValidation.ValidateIsEmptyString(txtbx_jr_lot_no.Text.Trim()))
//            {
//                DialogBox.ShowWarningMessage(lbl_jr_lot_no.Text + " cannot be empty.");
//                cbx_helper.Focus();
//                   	
//                return false;       
//            }
           	
           	else if (CommonValidation.ValidateIsEmptyString(txtbx_batch_no.Text.Trim()))
            {
                DialogBox.ShowWarningMessage(lbl_batch_no.Text + " cannot be empty.");
                cbx_helper.Focus();
                   	
                return false;       
            }
           	
           		else if (Double.Parse(txtbx_waste1.Text) < 0)
            {
                DialogBox.ShowWarningMessage(lbl_bal + " must not negative.");
                txtbx_bal1.Focus();
                   	
                return false;       
            }
           	
           	else if (Double.Parse(txtbx_waste2.Text) < 0)
            {
                DialogBox.ShowWarningMessage(lbl_bal + " must not negative.");
                txtbx_bal2.Focus();
                   	
                return false;       
            }
           	
           	else if (Double.Parse(txtbx_waste3.Text) < 0)
            {
                DialogBox.ShowWarningMessage(lbl_bal + " must not negative.");
                txtbx_bal3.Focus();
                   	
                return false;       
            }
           	
           	else if (Double.Parse(txtbx_waste4.Text) < 0)
            {
                DialogBox.ShowWarningMessage(lbl_bal + " must not negative.");
                txtbx_bal4.Focus();
                   	
                return false;       
            }
           	
           	else if (Double.Parse(txtbx_waste5.Text) < 0)
            {
                DialogBox.ShowWarningMessage(lbl_bal + " must not negative.");
                txtbx_bal5.Focus();
                   	
                return false;       
            }
           	
            return true;
        }
		
		void TotalRollCalculation()
		{
			try
			{
				txtbx_total_roll.Text = ((Int32.Parse(txtbx_ctn_qty.Text) * Int32.Parse(txtbx_conversion.Text)) + Int32.Parse(txtbx_roll_qty.Text)).ToString();
			}
			catch(Exception e)
			{
				//LogFile(e);
			}
		}
		
		void TotalRollCalculationUnitCtn()
		{	
			if(String.IsNullOrEmpty(txtbx_ctn_1.Text))
			{
				txtbx_ctn_1.Text = init;
			}
			if(String.IsNullOrEmpty(txtbx_ctn_2.Text))
			{
				txtbx_ctn_2.Text = init;
			}
			if(String.IsNullOrEmpty(txtbx_ctn_3.Text))
			{
				txtbx_ctn_3.Text = init;
			}
			if(String.IsNullOrEmpty(txtbx_ctn_4.Text))
			{
				txtbx_ctn_4.Text = init;
			}
			if(String.IsNullOrEmpty(txtbx_ctn_5.Text))
			{
				txtbx_ctn_5.Text = init;
			}
			
//			if(String.IsNullOrEmpty(txtbx_ctn_1.Text) || string.IsNullOrEmpty(txtbx_ctn_2.Text) || string.IsNullOrEmpty(txtbx_ctn_3.Text) || string.IsNullOrEmpty(txtbx_ctn_4.Text) || string.IsNullOrEmpty(txtbx_ctn_5.Text) 
//			   || txtbx_ctn_1.Text == "" || txtbx_ctn_2.Text == "" || txtbx_ctn_3.Text == "" || txtbx_ctn_4.Text == "" || txtbx_ctn_5.Text == "")
//			{
				txtbx_ctn_qty.Text = (Int32.Parse(txtbx_ctn_1.Text) + Int32.Parse(txtbx_ctn_2.Text) + Int32.Parse(txtbx_ctn_3.Text) + Int32.Parse(txtbx_ctn_4.Text) + Int32.Parse(txtbx_ctn_5.Text)).ToString();
//			}
//			else
//				return;
				
		}
		
		void TotalRollCalculationUnitRoll()
		{
			if(String.IsNullOrEmpty(txtbx_roll_1.Text))
			{
				txtbx_roll_1.Text = init;
			}
			if(String.IsNullOrEmpty(txtbx_roll_2.Text))
			{
				txtbx_roll_2.Text = init;
			}
			if(String.IsNullOrEmpty(txtbx_roll_3.Text))
			{
				txtbx_roll_3.Text = init;
			}
			if(String.IsNullOrEmpty(txtbx_roll_4.Text))
			{
				txtbx_roll_4.Text = init;
			}
			if(String.IsNullOrEmpty(txtbx_roll_5.Text))
			{
				txtbx_roll_5.Text = init;
			}
//			if(string.IsNullOrEmpty(txtbx_roll_1.Text) || string.IsNullOrEmpty(txtbx_roll_2.Text) || string.IsNullOrEmpty(txtbx_roll_3.Text) || string.IsNullOrEmpty(txtbx_roll_4.Text) || string.IsNullOrEmpty(txtbx_roll_5.Text))
//			{
				txtbx_roll_qty.Text = (Int32.Parse(txtbx_roll_1.Text) + Int32.Parse(txtbx_roll_2.Text) + Int32.Parse(txtbx_roll_3.Text) + Int32.Parse(txtbx_roll_4.Text) + Int32.Parse(txtbx_roll_5.Text)).ToString();
//			}
//			else
//				return;
				
		}
		
		void TotalRollCalculationUnitReject()
		{	
			if(String.IsNullOrEmpty(txtbx_reject_1.Text))
			{
				txtbx_reject_1.Text = init;
			}
			if(String.IsNullOrEmpty(txtbx_reject_2.Text))
			{
				txtbx_reject_2.Text = init;
			}
			if(String.IsNullOrEmpty(txtbx_reject_3.Text))
			{
				txtbx_reject_3.Text = init;
			}
			if(String.IsNullOrEmpty(txtbx_reject_4.Text))
			{
				txtbx_reject_4.Text = init;
			}
			if(String.IsNullOrEmpty(txtbx_reject_5.Text))
			{
				txtbx_reject_5.Text = init;
			}
			

			txtbx_reject_qty.Text = (Int32.Parse(txtbx_reject_1.Text) + Int32.Parse(txtbx_reject_2.Text) + Int32.Parse(txtbx_reject_3.Text) + Int32.Parse(txtbx_reject_4.Text) + Int32.Parse(txtbx_reject_5.Text)).ToString();

				
		}
		
		bool AllowSaveQty()
		{
			int qtyPackAllow = 0, qtySlit = 0, qtyPack = 0;
			
			SqlConnection con_SP3 = new SqlConnection(sqlconn);
			SqlCommand cmd_SP3 = new SqlCommand();
			
			try 
			{
				cmd_SP3.CommandText = @"select * from VIEW_PROD_CONV_JO_CHECK where PROD_DOCNO = @doc_no";
				cmd_SP3.Parameters.AddWithValue("@doc_no",  txtbx_ref_no.Text.ToUpper());
				cmd_SP3.Connection = con_SP3;
				con_SP3.Open();
				SqlDataReader rd_SP3 = cmd_SP3.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
				
				if (rd_SP3.Read())
				{	
					if (rd_SP3.HasRows) 
					{
						
						qtySlit 		= Convert.ToInt32(rd_SP3["TOTALROLLSLIT"].ToString());
						
						if(rd_SP3["TOTALROLLPACK"] != DBNull.Value)
						{
							qtyPack 		= Convert.ToInt32(rd_SP3["TOTALROLLPACK"].ToString());
						    qtyPackAllow 	= Convert.ToInt32(rd_SP3["BALPACK"].ToString());						
						}
						else
						{
							qtyPack 		= 0;
						    qtyPackAllow 	= Convert.ToInt32(rd_SP3["TOTALROLLSLIT"].ToString());
						}
						
						if(Convert.ToInt32(txtbx_total_roll.Text) > qtyPackAllow)
						{
							MessageBox.Show("Packing quantity is more than slitting quantity." + "\n\nThe overall slitting quantity is " + qtySlit + "\nThe overall packing quantity is " + qtyPack + "\n\nMake sure the quantity of all the packing list is less than or equal to " + qtyPackAllow);
							return false;
						}
						
					}
					else
					{
						MessageBox.Show("No slitting reported");
						return false;
					}
				} 
				
			} 
			catch (Exception ex) 
			{
				MessageBox.Show("Error - Packing Allow Save \nCannot load DB!" + ex.Message + ex.ToString());
				return false;
			} 
			finally 
			{
				con_SP3.Close();
			}
			
			con_SP3.Dispose();
			con_SP3 = null;
			cmd_SP3 = null;
			
			return true;
		}
		
		bool AllowSavePack()
		{
			int qtyRoll = 0, qtyOrder = 0, qty = 0;
			
			SqlConnection con_SP3 = new SqlConnection(sqlconn);
			SqlCommand cmd_SP3 = new SqlCommand();
			
			try 
			{
				cmd_SP3.CommandText = @"select * from VIEW_PROD_CONV_JO_PACKING where PROD_DOCNO = @doc_no";
				cmd_SP3.Parameters.AddWithValue("@doc_no",  txtbx_ref_no.Text.ToUpper());
				cmd_SP3.Connection = con_SP3;
				con_SP3.Open();
				SqlDataReader rd_SP3 = cmd_SP3.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
				
				if (rd_SP3.Read())
				{	
					
					if(rd_SP3.HasRows)
					{
						qtyRoll 	= Convert.ToInt32(rd_SP3["TOTALROLL"].ToString());
						qtyOrder  	= Convert.ToInt32(rd_SP3["QTYORDERED"].ToString());
						
						
						qty = 120 / 100 * qtyOrder;
						
						if((qtyRoll + Convert.ToInt32(txtbx_total_roll.Text)) > qty)
						{
							MessageBox.Show("Packing List quantity more than quantity ordered." + "\nThe quantity ordered are " + qtyOrder + "\nThe overall quantity of packing list now are " + qtyRoll + "\nMake sure the quantity of all the packing list is less than " + qty);
							return false;
						}
						
					}					
					
				} 
				
			} 
			catch (Exception ex) 
			{
				MessageBox.Show("Error - Packing Allow Save \nCannot load DB!" + ex.Message + ex.ToString());
				return false;
			} 
			finally 
			{
				con_SP3.Close();
			}
			
			con_SP3.Dispose();
			con_SP3 = null;
			cmd_SP3 = null;
			
			return true;
		}
		
		bool AllowSaveSlit(double consume, double get_qty, TextBox txtbx_result)
		{
			if(sum_consume > sum_jr_m2)
			{
				txtbx_result.Text = "Output is more than JR input";
				return false;
			}
			
//			if(consume > (1.2 * get_qty))
//			{				
//				txtbx_result.Text = "Output is more than JR input";
//				return false;
//			}
			else
			{
				return true;
			}			
		}
		
		void CheckQtySlitPack()
		{
			using (SqlConnection conn = new SqlConnection(sqlconn))
			{
				conn.Open();
				
				SqlCommand cmd  = new SqlCommand("SP_AXERP_BJ_CONVERTING_OUTPUT", conn);
				cmd.CommandType = CommandType.StoredProcedure;
				
				cmd.Parameters.Add(new SqlParameter("@SP_PROD_DOCNO", SqlDbType.NVarChar, 50));
				cmd.Parameters["@SP_PROD_DOCNO"].Value = txtbx_ref_no.Text.ToUpper();
								   
				cmd.ExecuteNonQuery();
				//return true;					
			}				
		}
		
		public void CheckDuplicateJR(string jr_shipmark, string jr_ref_no, string jr_micron, string jr_color, string jr_barcode, string jr_stockcode, 
		                       string jr_width, int shipmark_ori_length, double get_qty, double qty_realmetre, string jr_length, 
		                       TextBox txtbx_result, double consume, double balance, TextBox txtbx_jr_lot_no, Label txtbx_jr_lot_no_img)
		{			
			SqlConnection con_Check_Duplicate_JO = new SqlConnection(sqlconn);
			SqlCommand cmd_Check_Duplicate_JO = new SqlCommand();
				
			try 
			{
				cmd_Check_Duplicate_JO.CommandText = @"select * from VIEW_PROD_CONV_JO_SLITTING_JR where PROD_JRSHIPMARK like @ship_mark + '%'";// + "' and JODOCNO <> 'SMSO124608'";
				cmd_Check_Duplicate_JO.Parameters.AddWithValue("@ship_mark",  jr_shipmark);
					
				cmd_Check_Duplicate_JO.Connection = con_Check_Duplicate_JO;
				con_Check_Duplicate_JO.Open();
				SqlDataReader rd_Check_Duplicate_JO = cmd_Check_Duplicate_JO.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
	
				if (rd_Check_Duplicate_JO.HasRows)
				{
					if (rd_Check_Duplicate_JO.Read())
					{
						double jr_consume = 0;
						
						//isDuplicate = true;
						//jr_shipmark 		= rd_Check_Duplicate_JO["PROD_JRSHIPMARK"].ToString();
						//jr_lot_no 			= rd_Check_Duplicate_JO["PROD_LOTNO"].ToString();
						jr_ref_no 			= rd_Check_Duplicate_JO["PROD_JRBARCODE"].ToString();
						jr_micron 			= rd_Check_Duplicate_JO["PROD_MICRON"].ToString();
						jr_color 			= rd_Check_Duplicate_JO["PROD_COLOR"].ToString();
						jr_barcode 			= rd_Check_Duplicate_JO["PROD_JRBARCODE"].ToString();
						jr_stockcode 		= rd_Check_Duplicate_JO["PROD_STOCKCODE"].ToString();
							
						jr_width 			= rd_Check_Duplicate_JO["PROD_WIDTH"].ToString();
						shipmark_ori_length = Convert.ToInt32(rd_Check_Duplicate_JO["PROD_LENGTH"]);
						
						jr_width 			= Convert.ToString(rd_Check_Duplicate_JO["PROD_WIDTH"]);
						
						jr_consume 			= Convert.ToDouble(rd_Check_Duplicate_JO["PROD_CONSUME_TOTAL"]);
						jr_length 			= ((int)(Convert.ToDouble(shipmark_ori_length) - Convert.ToDouble(jr_consume))).ToString();
						
						if(Double.Parse(jr_length) <= 0) 
						{
							//MessageBox.Show("JR already been consume");
							txtbx_result.Text = "JR already been consume";
							txtbx_jr_lot_no_img.Text = "X";
		            		txtbx_jr_lot_no_img.ForeColor = Color.Red;					
		            		txtbx_jr_lot_no.Text = null;							
							return;
						}
						
						MessageBox.Show("2 - "+jr_shipmark.ToString());
					}
				}
				else
				{
					CheckAvailableQty(jr_shipmark, jr_ref_no, jr_micron, jr_color, jr_barcode, jr_stockcode, 
		                       jr_width, shipmark_ori_length, get_qty, qty_realmetre, jr_length, txtbx_result, txtbx_jr_lot_no, txtbx_jr_lot_no_img);
				}
			}
			catch (Exception ex)
			{
				con_Check_Duplicate_JO.Close();
				MessageBox.Show("Error - Converting Slitting Shipping Mark Duplicate " + ex.Message + ex.ToString());
				txtbx_jr_lot_no_img.Text = null;				
		        txtbx_jr_lot_no.Text = null;
				return;
			} 
			finally 
			{
				con_Check_Duplicate_JO.Close();
			}
				
			con_Check_Duplicate_JO.Dispose();
			cmd_Check_Duplicate_JO.Dispose();
			con_Check_Duplicate_JO = null;
			cmd_Check_Duplicate_JO = null;
			
			
		}
		
		public void CheckJRLotNo(TextBox txtbx_jrlotno, Label txtbx_jr_lot_no_img, TextBox txtbx_jr_lot_no, string jr_shipmark,
		                 string jr_ref_no, string jr_micron, string jr_color, string jr_barcode, string jr_stockcode, 
		                 string jr_width, int shipmark_ori_length, double get_qty, double qty_realmetre, string jr_length, TextBox txtbx_result)
		{
			SqlConnection con_SP3 = new SqlConnection(sqlconn);
			SqlCommand cmd_SP3 = new SqlCommand();
			
			try 
			{
				cmd_SP3.CommandText = @"select * from VIEW_CONVERTING_BARCODE where TrxSMQC = @doc_no";
				cmd_SP3.Parameters.AddWithValue("@doc_no",  txtbx_jrlotno.Text.ToUpper());
				cmd_SP3.Connection = con_SP3;
				con_SP3.Open();
				SqlDataReader rd_SP3 = cmd_SP3.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
				
				if (rd_SP3.HasRows)
				{
					while (rd_SP3.Read())
					{
						
						txtbx_jr_lot_no_img.Text = "✓";
		            	txtbx_jr_lot_no_img.ForeColor = Color.Green;					
		            	txtbx_jr_lot_no.Text = rd_SP3["TrxSMQC"].ToString().ToUpper();
		            	
		            	jr_shipmark = rd_SP3["TrxShipmark"].ToString().ToUpper();
		            	MessageBox.Show("1 - "+jr_shipmark.ToString());

						CheckDuplicateJR(jr_shipmark, jr_ref_no, jr_micron, jr_color, jr_barcode, jr_stockcode, 
		                       jr_width, shipmark_ori_length, get_qty, qty_realmetre, jr_length, txtbx_result, 
		                       consume1, balance1, txtbx_jr_lot_no, txtbx_jr_lot_no_img);
		            	
					} 
				}
				else 
				{
					CheckJRLotNoRCP(txtbx_jrlotno, txtbx_jr_lot_no_img, txtbx_jr_lot_no, jr_shipmark,
		                 jr_ref_no, jr_micron, jr_color, jr_barcode, jr_stockcode, 
		                 jr_width, shipmark_ori_length, get_qty, qty_realmetre, jr_length, txtbx_result);
				}
			
				
			} 
			catch (Exception ex) 
			{
				MessageBox.Show("Error - Packing Check JR Lot No \nCannot load DB!" + ex.Message + ex.ToString());
				txtbx_jr_lot_no_img.Text = null;				
		        txtbx_jr_lot_no.Text = null;
				return;
			} 
			finally 
			{
				con_SP3.Close();
			}
			
			con_SP3.Dispose();
			con_SP3 = null;
			cmd_SP3 = null;
		}
		
		public void CheckJRLotNoRCP(TextBox txtbx_jrlotno, Label txtbx_jr_lot_no_img, TextBox txtbx_jr_lot_no, string jr_shipmark,
		                 string jr_ref_no, string jr_micron, string jr_color, string jr_barcode, string jr_stockcode, 
		                 string jr_width, int shipmark_ori_length, double get_qty, double qty_realmetre, string jr_length, TextBox txtbx_result)
		{
			SqlConnection con_SP3 = new SqlConnection(sqlconn);
			SqlCommand cmd_SP3 = new SqlCommand();
			
			try 
			{
				cmd_SP3.CommandText = @"select * from [ax-sql].AX2020StagingDB.dbo.VIEW_AXERP_PDSBATCHATTRIBUTES_FULLINFO where INVENTBATCHID = @doc_no";
				cmd_SP3.Parameters.AddWithValue("@doc_no",  txtbx_jrlotno.Text.ToUpper());
				cmd_SP3.Connection = con_SP3;
				con_SP3.Open();
				SqlDataReader rd_SP3 = cmd_SP3.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
				
				if (rd_SP3.Read())
				{
					txtbx_jr_lot_no_img.Text = "✓";
	            	txtbx_jr_lot_no_img.ForeColor = Color.Green;					
	            	txtbx_jr_lot_no.Text = rd_SP3["INVENTBATCHID"].ToString().ToUpper();
	            	
	            	CheckAvailableQty(jr_shipmark, jr_ref_no, jr_micron, jr_color, jr_barcode, jr_stockcode, 
		                       jr_width, shipmark_ori_length, get_qty, qty_realmetre, jr_length, txtbx_result, txtbx_jr_lot_no, txtbx_jr_lot_no_img);
				} 
				else 
				{
					if(remark5 == "SLITTING")
					{
						txtbx_jr_lot_no_img.Text = "X";
		            	txtbx_jr_lot_no_img.ForeColor = Color.Red;
		            	//txtbx_jr_lot_no.Text = txtbx_jrlotno.Text.ToUpper();
		            	txtbx_jr_lot_no.Text = null;
						//MessageBox.Show("Error - Packing Check JR Lot No \nCannot find JR Lot No!");
						return;
					}
					else
					{
						txtbx_jr_lot_no_img.Text = "✓";
	            		txtbx_jr_lot_no_img.ForeColor = Color.Green;					
	            		txtbx_jr_lot_no.Text = txtbx_jrlotno.Text.ToUpper();
	            		
	            		//jr_shipmark 	= string.Empty;
						//jr_lot_no 		= string.Empty;
						jr_ref_no 		= txtbx_ref_no.Text;
						jr_color 		= txtbx_color.Text;
						jr_barcode 		= txtbx_jr_lot_no.Text;
						jr_stockcode 	= txtbx_jr_lot_no.Text;
						jr_micron 		= txtbx_mic.Text;
						jr_width 		= "0";
						jr_length 		= "0";
					}
				}
			} 
			catch (Exception ex) 
			{
				MessageBox.Show("Error - Packing Check JR Lot No \nCannot load DB!" + ex.Message + ex.ToString());
				txtbx_jr_lot_no_img.Text = null;				
		        txtbx_jr_lot_no.Text = null;
				return;
			} 
			finally 
			{
				con_SP3.Close();
			}
			
			con_SP3.Dispose();
			con_SP3 = null;
			cmd_SP3 = null;
		}
		
		public void CheckAvailableQty(string jr_shipmark, string jr_ref_no, string jr_micron, string jr_color, string jr_barcode, string jr_stockcode, 
		                       string jr_width, int shipmark_ori_length, double get_qty, double qty_realmetre, string jr_length, 
		                       TextBox txtbx_result, TextBox txtbx_jr_lot_no, Label txtbx_jr_lot_no_img)
		{
			SqlConnection con = new SqlConnection(sqlconnStaging);
			SqlCommand cmd = new SqlCommand();
				
			try 
			{
				cmd.CommandText = "select top 1 * from VIEW_AXERP_QOH_ATTRIBUTE_FULLINFO_PM04 where INVENTBATCHID like @ship_mark +'%' or grade = @ship_mark +'%'";
				cmd.Parameters.AddWithValue("@ship_mark",  jr_shipmark);
				//cmd.Parameters.AddWithValue("@stock_code",  txtbx_prod_code.Text.ToUpper());
				cmd.Connection = con;
				con.Open();
				SqlDataReader rd = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
					
				if (rd.HasRows)
				{
					while (rd.Read())
					{					        								
						//jr_shipmark 		= rd["INVENTBATCHID"].ToString();
						//jr_lot_no 			= rd["LOTNO"].ToString();
						jr_ref_no 			= rd["Grade"].ToString();
						jr_micron 			= rd["Micron"].ToString();
						jr_color 			= rd["Color"].ToString();
						jr_barcode 			= rd["Grade"].ToString();
						jr_stockcode 		= rd["ITEMID"].ToString();							
						jr_width 			= rd["Width"].ToString();
						shipmark_ori_length = Convert.ToInt32(rd["LLength"]);
						//jr_length 			= rd["LLength"].ToString();							
						
						get_qty = Convert.ToDouble(rd["AVAILPHYSICAL"].ToString());
						qty_realmetre = Convert.ToDouble((double) get_qty / (double) Convert.ToDouble(jr_width) * 1000);
						
						jr_length = qty_realmetre.ToString();
						
						//MessageBox.Show("3 - "+jr_shipmark.ToString());
															
					} 
				}
				else 
				{
					jr_shipmark 	= string.Empty;
					//jr_lot_no 		= string.Empty;
					jr_ref_no 		= string.Empty;
					//txtbx_mic.Text 	= string.Empty;
					jr_color 		= string.Empty;
					jr_barcode 		= string.Empty;
					jr_stockcode 	= string.Empty;
					jr_micron 		= string.Empty;
					jr_width 		= string.Empty;
					jr_length 		= string.Empty;
						
					shipmark_ori_length = 0;
					
					//MessageBox.Show("Cannot find shipping mark!");
					txtbx_result.Text = "Cannot find shipping mark!";
					txtbx_jr_lot_no_img.Text = "X";
		            txtbx_jr_lot_no_img.ForeColor = Color.Red;					
		            txtbx_jr_lot_no.Text = null;	
					return;
					
					//MessageBox.Show("4 - "+jr_shipmark.ToString());
				}
			} 
			catch (Exception ex) 
			{
				MessageBox.Show("Error - Packing Check \nCannot load DB!" + ex.Message + ex.ToString());
				txtbx_jr_lot_no_img.Text = null;				
		        txtbx_jr_lot_no.Text = null;	
				return;
			} 
			finally 
			{
				con.Close();
			}
				
			con.Dispose();
			con = null;
			cmd = null;
			
//			if (!CheckQty())
//			{
//				jr_shipmark 	= string.Empty;
//				//jr_lot_no 		= string.Empty;
//				jr_ref_no 		= string.Empty;
//				txtbx_mic.Text 	= string.Empty;
//				jr_color 		= string.Empty;
//				jr_barcode 		= string.Empty;
//				jr_stockcode 	= string.Empty;
//				jr_micron 		= string.Empty;
//				jr_width 		= string.Empty;
//				jr_length 		= string.Empty;
//					
//				shipmark_ori_length = 0;
//				return;
//			}				
			//TotalRollCalculation();
		}
		
		
//		void ConsumeCalculation(double get_qty, double consume, double balance)
//		{
//			consume = Math.Round(Double.Parse(txtbx_length_cust.Text) * Double.Parse(txtbx_total_roll.Text) * Double.Parse(txtbx_width_cust.Text), 2);
//			balance = Math.Round(get_qty - consume, 2);
//		}
		
		void ConsumeCalculation1()
		{
			consume1 = Math.Round(Double.Parse(txtbx_length_cust.Text) * 
			           ((double)(Double.Parse(txtbx_ctn_1.Text)*
			           Double.Parse(txtbx_conversion.Text)) + 
			           Double.Parse(txtbx_roll_1.Text) + Double.Parse(txtbx_reject_1.Text)) * 
			           Double.Parse(txtbx_width_cust.Text) / 1000, 2);
			balance1 = Math.Round(get_qty1 - consume1, 2);
			sum_consume = sum_consume + consume1;
			sum_jr_m2 = sum_jr_m2 + get_qty1;
		}
		
		void ConsumeCalculation2()
		{
			consume2 = Math.Round(Double.Parse(txtbx_length_cust.Text) * 
			           ((double)(Double.Parse(txtbx_ctn_2.Text)*
			           Double.Parse(txtbx_conversion.Text)) + 
			           Double.Parse(txtbx_roll_2.Text) + Double.Parse(txtbx_reject_2.Text)) * 
			           Double.Parse(txtbx_width_cust.Text) / 1000, 2);
			balance2 = Math.Round(get_qty2 - consume2, 2);
			sum_consume = sum_consume + consume2;
			sum_jr_m2 = sum_jr_m2 + get_qty2;
		}
		
		void ConsumeCalculation3()
		{
			consume3 = Math.Round(Double.Parse(txtbx_length_cust.Text) * 
			           ((double)(Double.Parse(txtbx_ctn_3.Text)*
			           Double.Parse(txtbx_conversion.Text)) + 
			           Double.Parse(txtbx_roll_3.Text) + Double.Parse(txtbx_reject_3.Text)) * 
			           Double.Parse(txtbx_width_cust.Text) / 1000, 2);
			balance3 = Math.Round(get_qty3 - consume3, 2);
			sum_consume = sum_consume + consume3;
			sum_jr_m2 = sum_jr_m2 + get_qty3;
		}
		
		void ConsumeCalculation4()
		{
			consume4 = Math.Round(Double.Parse(txtbx_length_cust.Text) * 
			           ((double)(Double.Parse(txtbx_ctn_4.Text)*
			           Double.Parse(txtbx_conversion.Text)) + 
			           Double.Parse(txtbx_roll_4.Text) + Double.Parse(txtbx_reject_4.Text)) * 
			           Double.Parse(txtbx_width_cust.Text) / 1000, 2);
			balance4 = Math.Round(get_qty4 - consume4, 2);
			sum_consume = sum_consume + consume4;
			sum_jr_m2 = sum_jr_m2 + get_qty4;
		}
		
		void ConsumeCalculation5()
		{
			consume5 = Math.Round(Double.Parse(txtbx_length_cust.Text) * 
			           ((double)(Double.Parse(txtbx_ctn_5.Text)*
			           Double.Parse(txtbx_conversion.Text)) + 
			           Double.Parse(txtbx_roll_5.Text) + Double.Parse(txtbx_reject_5.Text)) * 
			           Double.Parse(txtbx_width_cust.Text) / 1000, 2);
			balance5 = Math.Round(get_qty5 - consume5, 2);
			sum_consume = sum_consume + consume5;
			sum_jr_m2 = sum_jr_m2 + get_qty5;
		}
		
		//----------------search-----------------------------------------
		
		
		void Search()
		{
			SqlConnection con_search = new SqlConnection(sqlconn);
			SqlCommand cmd_seach = new SqlCommand();
				
			try 
			{
				//cmd_seach.CommandText = @"SELECT * FROM TBL_PROD_CONV_JO_SLITTING where PROD_DOCNO = @doc_no";
				cmd_seach.CommandText = @"SELECT * FROM TBL_PROD_CONV_JO where JODOCNO = @doc_no";
				cmd_seach.Parameters.AddWithValue("@doc_no",  txtbx_ref_no.Text.ToUpper());
				cmd_seach.Connection = con_search;
				con_search.Open();
				SqlDataReader dr_search = cmd_seach.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
					
				if (dr_search.Read())
				{	
					ref_no = txtbx_ref_no.Text;					
//					txtbx_cust.Text = dr_search["PROD_CUSTOMER"].ToString();
//					txtbx_prod_code.Text = dr_search["PROD_CODE"].ToString();
//					txtbx_color.Text = dr_search["PROD_COLOR"].ToString();
//					txtbx_brand.Text = dr_search["PROD_BRAND"].ToString();
//					txtbx_length_cust.Text = dr_search["PROD_LENGTH"].ToString();
//					txtbx_width_cust.Text = dr_search["PROD_WIDTH"].ToString();
//					txtbx_mic.Text = dr_search["PROD_MICRON"].ToString();
//					txtbx_conversion.Text = dr_search["PROD_CONVERSION"].ToString();
					
					txtbx_cust.Text = dr_search["JOCUSTOMER"].ToString();
					txtbx_prod_code.Text = dr_search["JOSTOCKCODE"].ToString();
					txtbx_color.Text = dr_search["JOSTOCKCOLOR"].ToString();
					txtbx_brand.Text = dr_search["JOSTOCKBRAND"].ToString();
					txtbx_length_cust.Text = dr_search["JOSTOCKLENGTH"].ToString();
					txtbx_width_cust.Text = dr_search["JOSTOCKWIDTH"].ToString();
					txtbx_mic.Text = dr_search["JOSTOCKMICRON"].ToString();
					qty_ctn_ordered = Convert.ToDouble(dr_search["JOSTOCKQTYCTN"]);
					qty_roll_ordered = Convert.ToDouble(dr_search["JOSTOCKQTYROLL"]);
					txtbx_conversion.Text = dr_search["JOSTOCKCONVERSION"].ToString();
					txtbx_total_qty_order.Text = dr_search["JOPRODREMARK0c"].ToString();
					txtbx_total_qty_balance.Text = dr_search["JOPACKQTYBAL"].ToString();
					qty_roll_prod = Double.Parse(dr_search["JOPRODQTY"].ToString());
					qty_roll_prod_2 = Double.Parse(dr_search["JOPRODQTYBAL"].ToString());
					remark5 = dr_search["JOPRODREMARK5"].ToString();
				} 
				else 
				{
					MessageBox.Show("Error : Cannot find JO!");
					return;
				}
			} 
			catch (Exception ex) 
			{
				MessageBox.Show("Error : Cannot load DB!" + ex.Message + ex.ToString());
				return;
			} 
			finally 
			{
				con_search.Close();
			}
			con_search.Dispose();
			cmd_seach = null;
			EnableAllControls(this);
			btn_del.Enabled = false;
			
//			if (txtbx_prod_code.Text.Substring(0, 7) == "B-GRADE" || txtbx_prod_code.Text.Substring(0, 6) == "BGRADE")
//			{
//				txtbx_jrlotno1.Text = txtbx_prod_code.Text;
//				clickCheck = true;
//			}
		}
		
		
		//-----------------save------------------------------------------
		
		private bool LineNoGenerator()
		{
			
			SqlConnection conNextNumber = new SqlConnection(sqlconn);
			SqlCommand cmdNextNumber = new SqlCommand();
			
			try 
			{
				cmdNextNumber.CommandText = "Select ProdPackingNextNumber from TBL_ADMIN_NEXT_NUMBER";
				cmdNextNumber.Connection = conNextNumber;

				conNextNumber.Open();
				SqlDataReader rdNextNumber = cmdNextNumber.ExecuteReader(System.Data.CommandBehavior.CloseConnection);

				rdNextNumber.Read();
				NextNo = Convert.ToInt32(rdNextNumber["ProdPackingNextNumber"].ToString());
								
			} 
			catch (Exception ex) 
			{
				MessageBox.Show("Error Edit : Cannot load DB!" + ex.Message + ex.ToString());
				return false;
			} 
			finally 
			{
				conNextNumber.Close();	
			}
			
			conNextNumber.Dispose();
			conNextNumber = null;
			cmdNextNumber = null;
			
			prod_line = DateTime.Now.ToString("yyMM") + NextNo;
			//prod_line = NextNo.ToString();
		
			if(NextNo == 9999)
			{
				SqlConnection conUpdate = new SqlConnection(sqlconn);
				SqlCommand cmdUpdateNextNumber = new SqlCommand();
	
				try
				{
					cmdUpdateNextNumber.CommandText = "update TBL_ADMIN_NEXT_NUMBER set ProdPackingNextNumber = 1000";
					
					cmdUpdateNextNumber.Connection = conUpdate;
	
					conUpdate.Open();
					cmdUpdateNextNumber.ExecuteNonQuery();
	
				}
				catch (Exception ex)
				{
					conUpdate.Close();
					MessageBox.Show("Error in updating next number" + ex.Message + ex.ToString());
					return false;
				}
				finally 
				{
					conUpdate.Close();
				}
	
				conUpdate.Dispose();
				conUpdate = null;
				cmdUpdateNextNumber = null;
			}
			else
			{
				SqlConnection conUpdate2 = new SqlConnection(sqlconn);
				SqlCommand cmdUpdateNextNumber2 = new SqlCommand();
	
				try
				{
					cmdUpdateNextNumber2.CommandText = "update TBL_ADMIN_NEXT_NUMBER set ProdPackingNextNumber = ProdPackingNextNumber + 1";
					
					cmdUpdateNextNumber2.Connection = conUpdate2;
	
					conUpdate2.Open();
					cmdUpdateNextNumber2.ExecuteNonQuery();
	
				}
				catch (Exception ex)
				{
					conUpdate2.Close();
					MessageBox.Show("Error in updating next number" + ex.Message + ex.ToString());
					return false;
				}
				finally 
				{
					conUpdate2.Close();
				}
	
				conUpdate2.Dispose();
				conUpdate2 = null;
				cmdUpdateNextNumber2 = null;
			}
			return true;			
		}
		
		private bool LineNoGeneratorSlit()
		{
			
			SqlConnection conNextNumber = new SqlConnection(sqlconn);
			SqlCommand cmdNextNumber = new SqlCommand();
			
			try 
			{
				cmdNextNumber.CommandText = "Select ProdConvSlitNextNumber from TBL_ADMIN_NEXT_NUMBER";
				cmdNextNumber.Connection = conNextNumber;

				conNextNumber.Open();
				SqlDataReader rdNextNumber = cmdNextNumber.ExecuteReader(System.Data.CommandBehavior.CloseConnection);

				rdNextNumber.Read();
				NextNoSlit = Convert.ToInt32(rdNextNumber["ProdConvSlitNextNumber"].ToString());
								
			} 
			catch (Exception ex) 
			{
				MessageBox.Show("Error Edit : Cannot load DB!" + ex.Message + ex.ToString());
				return false;
			} 
			finally 
			{
				conNextNumber.Close();	
			}
			
			conNextNumber.Dispose();
			conNextNumber = null;
			cmdNextNumber = null;
			
			prod_line_slit = DateTime.Now.ToString("yyMM") + NextNoSlit;
			//prod_line = NextNo.ToString();
		
			if(NextNo == 9999)
			{
				SqlConnection conUpdate = new SqlConnection(sqlconn);
				SqlCommand cmdUpdateNextNumber = new SqlCommand();
	
				try
				{
					cmdUpdateNextNumber.CommandText = "update TBL_ADMIN_NEXT_NUMBER set ProdConvSlitNextNumber = 1000";
					
					cmdUpdateNextNumber.Connection = conUpdate;
	
					conUpdate.Open();
					cmdUpdateNextNumber.ExecuteNonQuery();
	
				}
				catch (Exception ex)
				{
					conUpdate.Close();
					MessageBox.Show("Error in updating next number" + ex.Message + ex.ToString());
					return false;
				}
				finally 
				{
					conUpdate.Close();
				}
	
				conUpdate.Dispose();
				conUpdate = null;
				cmdUpdateNextNumber = null;
			}
			else
			{
				SqlConnection conUpdate2 = new SqlConnection(sqlconn);
				SqlCommand cmdUpdateNextNumber2 = new SqlCommand();
	
				try
				{
					cmdUpdateNextNumber2.CommandText = "update TBL_ADMIN_NEXT_NUMBER set ProdConvSlitNextNumber = ProdConvSlitNextNumber + 1";
					
					cmdUpdateNextNumber2.Connection = conUpdate2;
	
					conUpdate2.Open();
					cmdUpdateNextNumber2.ExecuteNonQuery();
	
				}
				catch (Exception ex)
				{
					conUpdate2.Close();
					MessageBox.Show("Error in updating next number" + ex.Message + ex.ToString());
					return false;
				}
				finally 
				{
					conUpdate2.Close();
				}
	
				conUpdate2.Dispose();
				conUpdate2 = null;
				cmdUpdateNextNumber2 = null;
			}
			return true;			
		}
		
		void UpdateBal(string cmd_update, string jr_shipmark, double consume, double balance)
		{
			using (SqlConnection conn = new SqlConnection(sqlconn))
			{
				conn.Open();
				
				SqlCommand cmd  = new SqlCommand(cmd_update, conn);
				cmd.CommandType = CommandType.StoredProcedure;
				
				cmd.Parameters.Add(new SqlParameter("@SP_JODOCNO", SqlDbType.NVarChar, 50));
				cmd.Parameters["@SP_JODOCNO"].Value = txtbx_ref_no.Text.ToUpper();
					
				cmd.Parameters.Add(new SqlParameter("@SP_JOPACKQTYTOTAL", SqlDbType.Float));
				cmd.Parameters["@SP_JOPACKQTYTOTAL"].Value = Double.Parse(txtbx_total_roll.Text);
				
				cmd.Parameters.Add(new SqlParameter("@SP_PROD_SHIPMARK", SqlDbType.NVarChar, 50));
				cmd.Parameters["@SP_PROD_SHIPMARK"].Value = jr_shipmark;
								        
				cmd.Parameters.Add(new SqlParameter("@SP_PROD_CONSUME", SqlDbType.Float));
				cmd.Parameters["@SP_PROD_CONSUME"].Value = consume;
					
				cmd.Parameters.Add(new SqlParameter("@SP_PROD_BALANCE", SqlDbType.Float));
				cmd.Parameters["@SP_PROD_BALANCE"].Value = balance;
								   
				cmd.ExecuteNonQuery();				
			}				
		}
		
		void UpdateBalSlit(string cmd_update, string jr_shipmark, double consume, double balance)
		{
			using (SqlConnection conn = new SqlConnection(sqlconn))
			{
				conn.Open();
				
				SqlCommand cmd  = new SqlCommand(cmd_update, conn);
				cmd.CommandType = CommandType.StoredProcedure;
				
				cmd.Parameters.Add(new SqlParameter("@SP_JODOCNO", SqlDbType.NVarChar, 50));
				cmd.Parameters["@SP_JODOCNO"].Value = txtbx_ref_no.Text.ToUpper();
					
				cmd.Parameters.Add(new SqlParameter("@SP_JOPACKQTYTOTAL", SqlDbType.Float));
				cmd.Parameters["@SP_JOPACKQTYTOTAL"].Value = Double.Parse(txtbx_total_roll.Text);
				
				cmd.Parameters.Add(new SqlParameter("@SP_PROD_SHIPMARK", SqlDbType.NVarChar, 50));
				cmd.Parameters["@SP_PROD_SHIPMARK"].Value = jr_shipmark;
								        
				cmd.Parameters.Add(new SqlParameter("@SP_PROD_CONSUME", SqlDbType.Float));
				cmd.Parameters["@SP_PROD_CONSUME"].Value = consume;
					
				cmd.Parameters.Add(new SqlParameter("@SP_PROD_BALANCE", SqlDbType.Float));
				cmd.Parameters["@SP_PROD_BALANCE"].Value = balance;
								   
				cmd.ExecuteNonQuery();				
			}				
		}
		
		void UpdateBal3(string cmd_update)
		{
			using (SqlConnection conn = new SqlConnection(sqlconn))
			{
				conn.Open();
				
				SqlCommand cmd  = new SqlCommand(cmd_update, conn);
				cmd.CommandType = CommandType.StoredProcedure;
				
				cmd.Parameters.Add(new SqlParameter("@SP_JODOCNO", SqlDbType.NVarChar, 50));
				cmd.Parameters["@SP_JODOCNO"].Value = txtbx_ref_no.Text.ToUpper();
					
				cmd.Parameters.Add(new SqlParameter("@SP_JOPACKQTYTOTAL", SqlDbType.Float));
				cmd.Parameters["@SP_JOPACKQTYTOTAL"].Value = Double.Parse(txtbx_total_roll.Text);
								   
				cmd.ExecuteNonQuery();				
			}				
		}
		
		bool sqlConnParm(string sqlStatement, string jr_shipmark, string jr_width, string jr_length, string jr_micron, 
		                 TextBox txtbx_jr_lot_no, string jr_ref_no, string jr_color, string jr_stockcode, 
		                 double consume, double balance, TextBox txtbx_reject)
			
		{
			string trim_ref_no = ref_no.Substring(0, ref_no.LastIndexOf("-"));
			line_no = trim_ref_no.Substring(trim_ref_no.IndexOf('-') + 1);
			
			SqlConnection con_data = new SqlConnection(sqlconn);
			SqlCommand cmd_data = new SqlCommand();
			
			try
			{
				//MessageBox.Show(jr_shipmark.ToString());
				cmd_data.Connection = con_data;
				cmd_data.CommandText = sqlStatement;
				cmd_data.CommandType = CommandType.StoredProcedure;

				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_SONO", SqlDbType.NVarChar, 20));
				cmd_data.Parameters["@SP_PROD_SONO"].Value = ref_no.Substring(0, ref_no.IndexOf('-')).ToUpper();
				
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_SOLINENO", SqlDbType.NVarChar, 20));
				cmd_data.Parameters["@SP_PROD_SOLINENO"].Value = line_no;
				
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_DOCNO", SqlDbType.NVarChar, 50));
				cmd_data.Parameters["@SP_PROD_DOCNO"].Value = ref_no.ToUpper();
				
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_REPORTDATE", SqlDbType.DateTime));
				cmd_data.Parameters["@SP_PROD_REPORTDATE"].Value = DateTime.Now;

				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_CODE", SqlDbType.NVarChar, 50));
				cmd_data.Parameters["@SP_PROD_CODE"].Value = txtbx_prod_code.Text.ToUpper();

				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_CUSTOMER", SqlDbType.NVarChar, 50));
				cmd_data.Parameters["@SP_PROD_CUSTOMER"].Value = txtbx_cust.Text.ToUpper();

				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_COLOR", SqlDbType.NVarChar, 50));
				cmd_data.Parameters["@SP_PROD_COLOR"].Value = txtbx_color.Text.ToUpper();

				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_BRAND", SqlDbType.NVarChar, 50));
				cmd_data.Parameters["@SP_PROD_BRAND"].Value = txtbx_brand.Text.ToUpper();

				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_WIDTH", SqlDbType.Float));
				cmd_data.Parameters["@SP_PROD_WIDTH"].Value = Convert.ToDouble(txtbx_width_cust.Text);

				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_LENGTH ", SqlDbType.Float));
				cmd_data.Parameters["@SP_PROD_LENGTH "].Value = Double.Parse(txtbx_length_cust.Text);

				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_MICRON", SqlDbType.Float));
				cmd_data.Parameters["@SP_PROD_MICRON"].Value = Double.Parse(txtbx_mic.Text);
				
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_QTYORDERED", SqlDbType.Float));
				cmd_data.Parameters["@SP_PROD_QTYORDERED"].Value = Double.Parse(txtbx_total_qty_order.Text);

				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_QTYCTNORDERED", SqlDbType.Float));
				cmd_data.Parameters["@SP_PROD_QTYCTNORDERED"].Value = qty_ctn_ordered;
				
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_QTYROLLORDERED", SqlDbType.Float));
				cmd_data.Parameters["@SP_PROD_QTYROLLORDERED"].Value = qty_roll_ordered;

				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_CONVERSION", SqlDbType.Float));
				cmd_data.Parameters["@SP_PROD_CONVERSION"].Value =Double.Parse(txtbx_conversion.Text);
			
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_ETDDATE", SqlDbType.DateTime));
				cmd_data.Parameters["@SP_PROD_ETDDATE"].Value = dtp_date.Value;
				
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_STARTDATE", SqlDbType.DateTime));
				cmd_data.Parameters["@SP_PROD_STARTDATE"].Value = dtp_date.Value;
				
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_ENDDATE", SqlDbType.DateTime));
				cmd_data.Parameters["@SP_PROD_ENDDATE"].Value = dtp_date.Value;
				
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_LOTNO", SqlDbType.NVarChar, 50));
				cmd_data.Parameters["@SP_PROD_LOTNO"].Value = txtbx_jr_lot_no1.Text.ToUpper();
				
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_BATCHNO", SqlDbType.NVarChar, 50));
				cmd_data.Parameters["@SP_PROD_BATCHNO"].Value = txtbx_batch_no.Text.ToUpper();
				
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_LINE", SqlDbType.NVarChar, 50));
				cmd_data.Parameters["@SP_PROD_LINE"].Value = prod_line;
				
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_MACHINE", SqlDbType.NVarChar, 50));
				cmd_data.Parameters["@SP_PROD_MACHINE"].Value = cbx_machine.Text.ToUpper();
				
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_MACHINESPEED", SqlDbType.Float));
				cmd_data.Parameters["@SP_PROD_MACHINESPEED"].Value = 0;
					
				
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_OPERATOR", SqlDbType.NVarChar, 50));
				cmd_data.Parameters["@SP_PROD_OPERATOR"].Value = cbx_operator.Text;
				
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_HELPER", SqlDbType.NVarChar, 50));
				cmd_data.Parameters["@SP_PROD_HELPER"].Value = cbx_helper.Text;
				
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_SUPERVISOR", SqlDbType.NVarChar, 50));
				cmd_data.Parameters["@SP_PROD_SUPERVISOR"].Value = cbx_helper.Text.ToUpper();
				
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_SHIFT", SqlDbType.NVarChar, 50));
				cmd_data.Parameters["@SP_PROD_SHIFT"].Value = cbx_shift.Text;	
				
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_DATE", SqlDbType.DateTime));
				cmd_data.Parameters["@SP_PROD_DATE"].Value = dtp_date.Value;
							
				
				
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_QTYCTN", SqlDbType.Float));
				cmd_data.Parameters["@SP_PROD_QTYCTN"].Value = Double.Parse(txtbx_ctn_qty.Text);
				
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_QTYROLL", SqlDbType.Float));
				cmd_data.Parameters["@SP_PROD_QTYROLL"].Value = Double.Parse(txtbx_roll_qty.Text);
				
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_TOTALROLL", SqlDbType.Float));
				cmd_data.Parameters["@SP_PROD_TOTALROLL"].Value = Double.Parse(txtbx_total_roll.Text);
				
				
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_REMARK1", SqlDbType.NVarChar, 50));
				cmd_data.Parameters["@SP_PROD_REMARK1"].Value = cbx_shift.Text.ToUpper();
				
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_REMARK2", SqlDbType.NVarChar, 50));
				cmd_data.Parameters["@SP_PROD_REMARK2"].Value = cbx_shift.Text.ToUpper();	
				
				
				cmd_data.Parameters.Add(new SqlParameter("@SP_flag1", SqlDbType.NVarChar, 2));
				cmd_data.Parameters["@SP_flag1"].Value = "N";

				cmd_data.Parameters.Add(new SqlParameter("@SP_flag2", SqlDbType.NVarChar, 2));
				cmd_data.Parameters["@SP_flag2"].Value = "0";

				cmd_data.Parameters.Add(new SqlParameter("@SP_flag3", SqlDbType.NVarChar, 2));
				cmd_data.Parameters["@SP_flag3"].Value = "0";

				cmd_data.Parameters.Add(new SqlParameter("@SP_flag4", SqlDbType.NVarChar, 2));
				cmd_data.Parameters["@SP_flag4"].Value = "0";

				cmd_data.Parameters.Add(new SqlParameter("@SP_flag5", SqlDbType.NVarChar, 2));
				cmd_data.Parameters["@SP_flag5"].Value = "0";

				cmd_data.Parameters.Add(new SqlParameter("@SP_flag6", SqlDbType.NVarChar, 2));
				cmd_data.Parameters["@SP_flag6"].Value = "0";

				cmd_data.Parameters.Add(new SqlParameter("@SP_flag7", SqlDbType.NVarChar, 20));
				cmd_data.Parameters["@SP_flag7"].Value = "0";

				cmd_data.Parameters.Add(new SqlParameter("@SP_flag8", SqlDbType.NVarChar, 20));
				cmd_data.Parameters["@SP_flag8"].Value = "0";

				cmd_data.Parameters.Add(new SqlParameter("@SP_flagStatus", SqlDbType.NVarChar, 2));
				cmd_data.Parameters["@SP_flagStatus"].Value = jr_shipmark;

								
				
					
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_ISSUEBY", SqlDbType.NVarChar, 50));
				cmd_data.Parameters["@SP_PROD_ISSUEBY"].Value = username;
				
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_USER", SqlDbType.NVarChar, 50));
				cmd_data.Parameters["@SP_PROD_USER"].Value = username;
				
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_USEREMAIL", SqlDbType.NVarChar, 50));
				cmd_data.Parameters["@SP_PROD_USEREMAIL"].Value = frm_menu_system.email;
				
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_USERPC", SqlDbType.NVarChar, 50));
				cmd_data.Parameters["@SP_PROD_USERPC"].Value = frm_menu_system.ipAddress;
				
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_USERDATETIME", SqlDbType.DateTime));
				cmd_data.Parameters["@SP_PROD_USERDATETIME"].Value = DateTime.Now;
				
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_USERREVISION", SqlDbType.NVarChar, 50));
				cmd_data.Parameters["@SP_PROD_USERREVISION"].Value = "0";

				
				//SLIT
				
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_SHIPMARK", SqlDbType.NVarChar, 50));
				cmd_data.Parameters["@SP_PROD_SHIPMARK"].Value = jr_shipmark;		
				
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_JRWIDTH", SqlDbType.Float));
				//cmd_data.Parameters["@SP_JOSTOCKQTYCTN"].Value = Double.TryParse(txtbx_ctn_order.Text, out notParseDouble);
				cmd_data.Parameters["@SP_PROD_JRWIDTH"].Value = jr_width;
				
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_JRLENGTH", SqlDbType.Float));
				//cmd_data.Parameters["@SP_JOSTOCKQTYROLL"].Value = Double.TryParse(txtbx_roll_order.Text, out notParseDouble);
				cmd_data.Parameters["@SP_PROD_JRLENGTH"].Value = jr_length;
				
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_JRMICRON", SqlDbType.Float));
				cmd_data.Parameters["@SP_PROD_JRMICRON"].Value = jr_micron;
				
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_JRLOTNO", SqlDbType.NVarChar, 50));
				cmd_data.Parameters["@SP_PROD_JRLOTNO"].Value = txtbx_jr_lot_no.Text.ToUpper();
				
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_JRJONO", SqlDbType.NVarChar, 50));
				cmd_data.Parameters["@SP_PROD_JRJONO"].Value = jr_ref_no;
				
				
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_JRCOLOR", SqlDbType.NVarChar, 50));
				cmd_data.Parameters["@SP_PROD_JRCOLOR"].Value = jr_color;
				
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_JRSTOCKCODE", SqlDbType.NVarChar, 50));
				cmd_data.Parameters["@SP_PROD_JRSTOCKCODE"].Value = jr_stockcode;
								        
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_CONSUME", SqlDbType.Float));
				cmd_data.Parameters["@SP_PROD_CONSUME"].Value = consume;
					
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_BALANCE", SqlDbType.Float));
				cmd_data.Parameters["@SP_PROD_BALANCE"].Value = balance;
				
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_QTYREJECT", SqlDbType.Float));
				cmd_data.Parameters["@SP_PROD_QTYREJECT"].Value = Double.Parse(txtbx_reject.Text);
				
				con_data.Open();
				cmd_data.ExecuteNonQuery();					
			} 
			catch (Exception ex) 
			{	
				con_data.Close();
				MessageBox.Show("Unexpected error happen" + Environment.NewLine + ex.Message + ex.ToString());			
				return false;
			} 
			finally 
			{
				con_data.Close();		
			}
			
			con_data.Dispose();
			con_data = null;
			cmd_data = null;
			return true;
		}
		
		
		
		bool sqlConnParmSlit(string sqlStatement, string jr_shipmark, string jr_width, string jr_length, string jr_micron, 
		                 TextBox txtbx_jr_lot_no, string jr_ref_no, string jr_color, string jr_stockcode, 
		                 double consume, double balance, TextBox txtbx_reject, TextBox txtbx_qty_ctn, TextBox txtbx_qty_roll,
		                 TextBox txtbx_waste, TextBox txtbx_balance
		                 )
			
		{
			string trim_ref_no = ref_no.Substring(0, ref_no.LastIndexOf("-"));
			line_no = trim_ref_no.Substring(trim_ref_no.IndexOf('-') + 1);
			
			SqlConnection con_data = new SqlConnection(sqlconn);
			SqlCommand cmd_data = new SqlCommand();
			
			try
			{
				//MessageBox.Show(jr_shipmark.ToString());
				cmd_data.Connection = con_data;
				cmd_data.CommandText = sqlStatement;
				cmd_data.CommandType = CommandType.StoredProcedure;

				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_SONO", SqlDbType.NVarChar, 20));
				cmd_data.Parameters["@SP_PROD_SONO"].Value = ref_no.Substring(0, ref_no.IndexOf('-')).ToUpper();
				
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_SOLINENO", SqlDbType.NVarChar, 20));
				cmd_data.Parameters["@SP_PROD_SOLINENO"].Value = line_no;
				
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_DOCNO", SqlDbType.NVarChar, 50));
				cmd_data.Parameters["@SP_PROD_DOCNO"].Value = ref_no.ToUpper();
				
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_REPORTDATE", SqlDbType.DateTime));
				cmd_data.Parameters["@SP_PROD_REPORTDATE"].Value = DateTime.Now;

				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_CODE", SqlDbType.NVarChar, 50));
				cmd_data.Parameters["@SP_PROD_CODE"].Value = txtbx_prod_code.Text.ToUpper();

				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_CUSTOMER", SqlDbType.NVarChar, 50));
				cmd_data.Parameters["@SP_PROD_CUSTOMER"].Value = txtbx_cust.Text.ToUpper();

				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_COLOR", SqlDbType.NVarChar, 50));
				cmd_data.Parameters["@SP_PROD_COLOR"].Value = txtbx_color.Text.ToUpper();

				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_BRAND", SqlDbType.NVarChar, 50));
				cmd_data.Parameters["@SP_PROD_BRAND"].Value = txtbx_brand.Text.ToUpper();

				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_WIDTH", SqlDbType.Float));
				cmd_data.Parameters["@SP_PROD_WIDTH"].Value = Convert.ToDouble(txtbx_width_cust.Text);

				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_LENGTH ", SqlDbType.Float));
				cmd_data.Parameters["@SP_PROD_LENGTH "].Value = Double.Parse(txtbx_length_cust.Text);

				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_MICRON", SqlDbType.Float));
				cmd_data.Parameters["@SP_PROD_MICRON"].Value = Double.Parse(txtbx_mic.Text);
				
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_QTYORDERED", SqlDbType.Float));
				cmd_data.Parameters["@SP_PROD_QTYORDERED"].Value = Double.Parse(txtbx_total_qty_order.Text);

				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_QTYCTNORDERED", SqlDbType.Float));
				cmd_data.Parameters["@SP_PROD_QTYCTNORDERED"].Value = qty_ctn_ordered;
				
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_QTYROLLORDERED", SqlDbType.Float));
				cmd_data.Parameters["@SP_PROD_QTYROLLORDERED"].Value = qty_roll_ordered;

				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_CONVERSION", SqlDbType.Float));
				cmd_data.Parameters["@SP_PROD_CONVERSION"].Value =Double.Parse(txtbx_conversion.Text);
			
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_ETDDATE", SqlDbType.DateTime));
				cmd_data.Parameters["@SP_PROD_ETDDATE"].Value = dtp_date.Value;
				
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_STARTDATE", SqlDbType.DateTime));
				cmd_data.Parameters["@SP_PROD_STARTDATE"].Value = dtp_date.Value;
				
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_ENDDATE", SqlDbType.DateTime));
				cmd_data.Parameters["@SP_PROD_ENDDATE"].Value = dtp_date.Value;
				
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_LOTNO", SqlDbType.NVarChar, 50));
				cmd_data.Parameters["@SP_PROD_LOTNO"].Value = txtbx_jr_lot_no1.Text.ToUpper();
				
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_BATCHNO", SqlDbType.NVarChar, 50));
				cmd_data.Parameters["@SP_PROD_BATCHNO"].Value = txtbx_batch_no.Text.ToUpper();
				
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_LINE", SqlDbType.NVarChar, 50));
				cmd_data.Parameters["@SP_PROD_LINE"].Value = prod_line_slit;
				
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_MACHINE", SqlDbType.NVarChar, 50));
				cmd_data.Parameters["@SP_PROD_MACHINE"].Value = cbx_machine.Text.ToUpper();
				
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_MACHINESPEED", SqlDbType.Float));
				cmd_data.Parameters["@SP_PROD_MACHINESPEED"].Value = 0;
					
				
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_OPERATOR", SqlDbType.NVarChar, 50));
				cmd_data.Parameters["@SP_PROD_OPERATOR"].Value = cbx_operator.Text;
				
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_HELPER", SqlDbType.NVarChar, 50));
				cmd_data.Parameters["@SP_PROD_HELPER"].Value = cbx_helper.Text;
				
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_SUPERVISOR", SqlDbType.NVarChar, 50));
				cmd_data.Parameters["@SP_PROD_SUPERVISOR"].Value = cbx_helper.Text.ToUpper();
				
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_SHIFT", SqlDbType.NVarChar, 50));
				cmd_data.Parameters["@SP_PROD_SHIFT"].Value = cbx_shift.Text;	
				
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_DATE", SqlDbType.DateTime));
				cmd_data.Parameters["@SP_PROD_DATE"].Value = dtp_date.Value;
							
				
				
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_QTYCTN", SqlDbType.Float));
				cmd_data.Parameters["@SP_PROD_QTYCTN"].Value = Double.Parse(txtbx_qty_ctn.Text);
				
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_QTYROLL", SqlDbType.Float));
				cmd_data.Parameters["@SP_PROD_QTYROLL"].Value = Double.Parse(txtbx_qty_roll.Text);
				
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_TOTALROLL", SqlDbType.Float));
				cmd_data.Parameters["@SP_PROD_TOTALROLL"].Value = (Double.Parse(txtbx_qty_ctn.Text) * Double.Parse(txtbx_conversion.Text)) + Double.Parse(txtbx_qty_roll.Text);
				
				
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_REMARK1", SqlDbType.NVarChar, 50));
				cmd_data.Parameters["@SP_PROD_REMARK1"].Value = cbx_shift.Text.ToUpper();
				
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_REMARK2", SqlDbType.NVarChar, 50));
				cmd_data.Parameters["@SP_PROD_REMARK2"].Value = cbx_shift.Text.ToUpper();	
				
				
				cmd_data.Parameters.Add(new SqlParameter("@SP_flag1", SqlDbType.NVarChar, 20));
				cmd_data.Parameters["@SP_flag1"].Value = "N";

				cmd_data.Parameters.Add(new SqlParameter("@SP_flag2", SqlDbType.NVarChar, 20));
				cmd_data.Parameters["@SP_flag2"].Value = "0";

				cmd_data.Parameters.Add(new SqlParameter("@SP_flag3", SqlDbType.NVarChar, 20));
				cmd_data.Parameters["@SP_flag3"].Value = "0";

				cmd_data.Parameters.Add(new SqlParameter("@SP_flag4", SqlDbType.NVarChar, 20));
				cmd_data.Parameters["@SP_flag4"].Value = "0";

				cmd_data.Parameters.Add(new SqlParameter("@SP_flag5", SqlDbType.NVarChar, 20));
				cmd_data.Parameters["@SP_flag5"].Value = "0";

				cmd_data.Parameters.Add(new SqlParameter("@SP_flag6", SqlDbType.NVarChar, 20));
				cmd_data.Parameters["@SP_flag6"].Value = "slit+pack";

				cmd_data.Parameters.Add(new SqlParameter("@SP_flag7", SqlDbType.NVarChar, 20));
				cmd_data.Parameters["@SP_flag7"].Value = txtbx_waste.Text;

				cmd_data.Parameters.Add(new SqlParameter("@SP_flag8", SqlDbType.NVarChar, 20));
				cmd_data.Parameters["@SP_flag8"].Value = txtbx_balance.Text;

				cmd_data.Parameters.Add(new SqlParameter("@SP_flagStatus", SqlDbType.NVarChar, 20));
				cmd_data.Parameters["@SP_flagStatus"].Value = prod_line;

								
				
					
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_ISSUEBY", SqlDbType.NVarChar, 50));
				cmd_data.Parameters["@SP_PROD_ISSUEBY"].Value = username;
				
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_USER", SqlDbType.NVarChar, 50));
				cmd_data.Parameters["@SP_PROD_USER"].Value = username;
				
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_USEREMAIL", SqlDbType.NVarChar, 50));
				cmd_data.Parameters["@SP_PROD_USEREMAIL"].Value = frm_menu_system.email;
				
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_USERPC", SqlDbType.NVarChar, 50));
				cmd_data.Parameters["@SP_PROD_USERPC"].Value = frm_menu_system.ipAddress;
				
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_USERDATETIME", SqlDbType.DateTime));
				cmd_data.Parameters["@SP_PROD_USERDATETIME"].Value = DateTime.Now;
				
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_USERREVISION", SqlDbType.NVarChar, 50));
				cmd_data.Parameters["@SP_PROD_USERREVISION"].Value = "0";

				
				//SLIT
				
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_SHIPMARK", SqlDbType.NVarChar, 50));
				cmd_data.Parameters["@SP_PROD_SHIPMARK"].Value = jr_shipmark;		
				
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_JRWIDTH", SqlDbType.Float));
				//cmd_data.Parameters["@SP_JOSTOCKQTYCTN"].Value = Double.TryParse(txtbx_ctn_order.Text, out notParseDouble);
				cmd_data.Parameters["@SP_PROD_JRWIDTH"].Value = jr_width;
				
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_JRLENGTH", SqlDbType.Float));
				//cmd_data.Parameters["@SP_JOSTOCKQTYROLL"].Value = Double.TryParse(txtbx_roll_order.Text, out notParseDouble);
				cmd_data.Parameters["@SP_PROD_JRLENGTH"].Value = jr_length;
				
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_JRMICRON", SqlDbType.Float));
				cmd_data.Parameters["@SP_PROD_JRMICRON"].Value = jr_micron;
				
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_JRLOTNO", SqlDbType.NVarChar, 50));
				cmd_data.Parameters["@SP_PROD_JRLOTNO"].Value = txtbx_jr_lot_no.Text.ToUpper();
				
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_JRJONO", SqlDbType.NVarChar, 50));
				cmd_data.Parameters["@SP_PROD_JRJONO"].Value = jr_ref_no;
				
				
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_JRCOLOR", SqlDbType.NVarChar, 50));
				cmd_data.Parameters["@SP_PROD_JRCOLOR"].Value = jr_color;
				
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_JRSTOCKCODE", SqlDbType.NVarChar, 50));
				cmd_data.Parameters["@SP_PROD_JRSTOCKCODE"].Value = jr_stockcode;
								        
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_CONSUME", SqlDbType.Float));
				cmd_data.Parameters["@SP_PROD_CONSUME"].Value = consume;
					
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_BALANCE", SqlDbType.Float));
				cmd_data.Parameters["@SP_PROD_BALANCE"].Value = txtbx_balance.Text;
				
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_QTYREJECT", SqlDbType.Float));
				cmd_data.Parameters["@SP_PROD_QTYREJECT"].Value = Double.Parse(txtbx_reject.Text);
				
				con_data.Open();
				cmd_data.ExecuteNonQuery();					
			} 
			catch (Exception ex) 
			{	
				con_data.Close();
				MessageBox.Show("Unexpected error happen" + Environment.NewLine + ex.Message + ex.ToString());			
				return false;
			} 
			finally 
			{
				con_data.Close();		
			}
			
			con_data.Dispose();
			con_data = null;
			cmd_data = null;
			return true;
		}
		
		bool sqlConnParmB(string sqlStatement,  
		                 TextBox txtbx_jr_lot_no, string jr_ref_no,  
		                 TextBox txtbx_reject, TextBox txtbx_qty_ctn, TextBox txtbx_qty_roll)
			
		{
			string trim_ref_no = ref_no.Substring(0, ref_no.LastIndexOf("-"));
			line_no = trim_ref_no.Substring(trim_ref_no.IndexOf('-') + 1);
			
			SqlConnection con_data = new SqlConnection(sqlconn);
			SqlCommand cmd_data = new SqlCommand();
			
			try
			{
				//MessageBox.Show(jr_shipmark.ToString());
				cmd_data.Connection = con_data;
				cmd_data.CommandText = sqlStatement;
				cmd_data.CommandType = CommandType.StoredProcedure;

				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_SONO", SqlDbType.NVarChar, 20));
				cmd_data.Parameters["@SP_PROD_SONO"].Value = ref_no.Substring(0, ref_no.IndexOf('-')).ToUpper();
				
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_SOLINENO", SqlDbType.NVarChar, 20));
				cmd_data.Parameters["@SP_PROD_SOLINENO"].Value = line_no;
				
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_DOCNO", SqlDbType.NVarChar, 50));
				cmd_data.Parameters["@SP_PROD_DOCNO"].Value = ref_no.ToUpper();
				
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_REPORTDATE", SqlDbType.DateTime));
				cmd_data.Parameters["@SP_PROD_REPORTDATE"].Value = DateTime.Now;

				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_CODE", SqlDbType.NVarChar, 50));
				cmd_data.Parameters["@SP_PROD_CODE"].Value = txtbx_prod_code.Text.ToUpper();

				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_CUSTOMER", SqlDbType.NVarChar, 50));
				cmd_data.Parameters["@SP_PROD_CUSTOMER"].Value = txtbx_cust.Text.ToUpper();

				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_COLOR", SqlDbType.NVarChar, 50));
				cmd_data.Parameters["@SP_PROD_COLOR"].Value = txtbx_color.Text.ToUpper();

				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_BRAND", SqlDbType.NVarChar, 50));
				cmd_data.Parameters["@SP_PROD_BRAND"].Value = txtbx_brand.Text.ToUpper();

				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_WIDTH", SqlDbType.Float));
				cmd_data.Parameters["@SP_PROD_WIDTH"].Value = Convert.ToDouble(txtbx_width_cust.Text);

				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_LENGTH ", SqlDbType.Float));
				cmd_data.Parameters["@SP_PROD_LENGTH "].Value = Double.Parse(txtbx_length_cust.Text);

				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_MICRON", SqlDbType.Float));
				cmd_data.Parameters["@SP_PROD_MICRON"].Value = Double.Parse(txtbx_mic.Text);
				
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_QTYORDERED", SqlDbType.Float));
				cmd_data.Parameters["@SP_PROD_QTYORDERED"].Value = Double.Parse(txtbx_total_qty_order.Text);

				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_QTYCTNORDERED", SqlDbType.Float));
				cmd_data.Parameters["@SP_PROD_QTYCTNORDERED"].Value = qty_ctn_ordered;
				
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_QTYROLLORDERED", SqlDbType.Float));
				cmd_data.Parameters["@SP_PROD_QTYROLLORDERED"].Value = qty_roll_ordered;

				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_CONVERSION", SqlDbType.Float));
				cmd_data.Parameters["@SP_PROD_CONVERSION"].Value =Double.Parse(txtbx_conversion.Text);
			
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_ETDDATE", SqlDbType.DateTime));
				cmd_data.Parameters["@SP_PROD_ETDDATE"].Value = dtp_date.Value;
				
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_STARTDATE", SqlDbType.DateTime));
				cmd_data.Parameters["@SP_PROD_STARTDATE"].Value = dtp_date.Value;
				
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_ENDDATE", SqlDbType.DateTime));
				cmd_data.Parameters["@SP_PROD_ENDDATE"].Value = dtp_date.Value;
				
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_LOTNO", SqlDbType.NVarChar, 50));
				cmd_data.Parameters["@SP_PROD_LOTNO"].Value = txtbx_jr_lot_no1.Text.ToUpper();
				
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_BATCHNO", SqlDbType.NVarChar, 50));
				cmd_data.Parameters["@SP_PROD_BATCHNO"].Value = txtbx_batch_no.Text.ToUpper();
				
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_LINE", SqlDbType.NVarChar, 50));
				cmd_data.Parameters["@SP_PROD_LINE"].Value = prod_line_slit;
				
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_MACHINE", SqlDbType.NVarChar, 50));
				cmd_data.Parameters["@SP_PROD_MACHINE"].Value = cbx_machine.Text.ToUpper();
				
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_MACHINESPEED", SqlDbType.Float));
				cmd_data.Parameters["@SP_PROD_MACHINESPEED"].Value = 0;
					
				
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_OPERATOR", SqlDbType.NVarChar, 50));
				cmd_data.Parameters["@SP_PROD_OPERATOR"].Value = cbx_operator.Text;
				
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_HELPER", SqlDbType.NVarChar, 50));
				cmd_data.Parameters["@SP_PROD_HELPER"].Value = cbx_helper.Text;
				
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_SUPERVISOR", SqlDbType.NVarChar, 50));
				cmd_data.Parameters["@SP_PROD_SUPERVISOR"].Value = cbx_helper.Text.ToUpper();
				
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_SHIFT", SqlDbType.NVarChar, 50));
				cmd_data.Parameters["@SP_PROD_SHIFT"].Value = cbx_shift.Text;	
				
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_DATE", SqlDbType.DateTime));
				cmd_data.Parameters["@SP_PROD_DATE"].Value = dtp_date.Value;
							
				
				
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_QTYCTN", SqlDbType.Float));
				cmd_data.Parameters["@SP_PROD_QTYCTN"].Value = Double.Parse(txtbx_qty_ctn.Text);
				
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_QTYROLL", SqlDbType.Float));
				cmd_data.Parameters["@SP_PROD_QTYROLL"].Value = Double.Parse(txtbx_qty_roll.Text);
				
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_TOTALROLL", SqlDbType.Float));
				cmd_data.Parameters["@SP_PROD_TOTALROLL"].Value = (Double.Parse(txtbx_qty_ctn.Text) * Double.Parse(txtbx_conversion.Text)) + Double.Parse(txtbx_qty_roll.Text);
				
				
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_REMARK1", SqlDbType.NVarChar, 50));
				cmd_data.Parameters["@SP_PROD_REMARK1"].Value = cbx_shift.Text.ToUpper();
				
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_REMARK2", SqlDbType.NVarChar, 50));
				cmd_data.Parameters["@SP_PROD_REMARK2"].Value = cbx_shift.Text.ToUpper();	
				
				
				cmd_data.Parameters.Add(new SqlParameter("@SP_flag1", SqlDbType.NVarChar, 2));
				cmd_data.Parameters["@SP_flag1"].Value = "N";

				cmd_data.Parameters.Add(new SqlParameter("@SP_flag2", SqlDbType.NVarChar, 2));
				cmd_data.Parameters["@SP_flag2"].Value = "0";

				cmd_data.Parameters.Add(new SqlParameter("@SP_flag3", SqlDbType.NVarChar, 2));
				cmd_data.Parameters["@SP_flag3"].Value = "0";

				cmd_data.Parameters.Add(new SqlParameter("@SP_flag4", SqlDbType.NVarChar, 2));
				cmd_data.Parameters["@SP_flag4"].Value = "0";

				cmd_data.Parameters.Add(new SqlParameter("@SP_flag5", SqlDbType.NVarChar, 2));
				cmd_data.Parameters["@SP_flag5"].Value = "0";

				cmd_data.Parameters.Add(new SqlParameter("@SP_flag6", SqlDbType.NVarChar, 2));
				cmd_data.Parameters["@SP_flag6"].Value = "0";

				cmd_data.Parameters.Add(new SqlParameter("@SP_flag7", SqlDbType.NVarChar, 2));
				cmd_data.Parameters["@SP_flag7"].Value = "0";

				cmd_data.Parameters.Add(new SqlParameter("@SP_flag8", SqlDbType.NVarChar, 2));
				cmd_data.Parameters["@SP_flag8"].Value = "0";

				cmd_data.Parameters.Add(new SqlParameter("@SP_flagStatus", SqlDbType.NVarChar, 2));
				cmd_data.Parameters["@SP_flagStatus"].Value = "0";

								
				
					
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_ISSUEBY", SqlDbType.NVarChar, 50));
				cmd_data.Parameters["@SP_PROD_ISSUEBY"].Value = username;
				
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_USER", SqlDbType.NVarChar, 50));
				cmd_data.Parameters["@SP_PROD_USER"].Value = username;
				
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_USEREMAIL", SqlDbType.NVarChar, 50));
				cmd_data.Parameters["@SP_PROD_USEREMAIL"].Value = frm_menu_system.email;
				
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_USERPC", SqlDbType.NVarChar, 50));
				cmd_data.Parameters["@SP_PROD_USERPC"].Value = frm_menu_system.ipAddress;
				
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_USERDATETIME", SqlDbType.DateTime));
				cmd_data.Parameters["@SP_PROD_USERDATETIME"].Value = DateTime.Now;
				
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_USERREVISION", SqlDbType.NVarChar, 50));
				cmd_data.Parameters["@SP_PROD_USERREVISION"].Value = "0";

				
				//SLIT
				
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_SHIPMARK", SqlDbType.NVarChar, 50));
				cmd_data.Parameters["@SP_PROD_SHIPMARK"].Value = "0";		
				
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_JRWIDTH", SqlDbType.Float));
				//cmd_data.Parameters["@SP_JOSTOCKQTYCTN"].Value = Double.TryParse(txtbx_ctn_order.Text, out notParseDouble);
				cmd_data.Parameters["@SP_PROD_JRWIDTH"].Value = 0;
				
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_JRLENGTH", SqlDbType.Float));
				//cmd_data.Parameters["@SP_JOSTOCKQTYROLL"].Value = Double.TryParse(txtbx_roll_order.Text, out notParseDouble);
				cmd_data.Parameters["@SP_PROD_JRLENGTH"].Value = 0;
				
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_JRMICRON", SqlDbType.Float));
				cmd_data.Parameters["@SP_PROD_JRMICRON"].Value = 0;
				
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_JRLOTNO", SqlDbType.NVarChar, 50));
				cmd_data.Parameters["@SP_PROD_JRLOTNO"].Value = txtbx_jr_lot_no.Text.ToUpper();
				
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_JRJONO", SqlDbType.NVarChar, 50));
				cmd_data.Parameters["@SP_PROD_JRJONO"].Value = jr_ref_no;
				
				
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_JRCOLOR", SqlDbType.NVarChar, 50));
				cmd_data.Parameters["@SP_PROD_JRCOLOR"].Value = "0";
				
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_JRSTOCKCODE", SqlDbType.NVarChar, 50));
				cmd_data.Parameters["@SP_PROD_JRSTOCKCODE"].Value = "0";
								        
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_CONSUME", SqlDbType.Float));
				cmd_data.Parameters["@SP_PROD_CONSUME"].Value = 0;
					
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_BALANCE", SqlDbType.Float));
				cmd_data.Parameters["@SP_PROD_BALANCE"].Value = 0;
				
				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_QTYREJECT", SqlDbType.Float));
				cmd_data.Parameters["@SP_PROD_QTYREJECT"].Value = Double.Parse(txtbx_reject.Text);
				
				con_data.Open();
				cmd_data.ExecuteNonQuery();					
			} 
			catch (Exception ex) 
			{	
				con_data.Close();
				MessageBox.Show("Unexpected error happen" + Environment.NewLine + ex.Message + ex.ToString());			
				return false;
			} 
			finally 
			{
				con_data.Close();		
			}
			
			con_data.Dispose();
			con_data = null;
			cmd_data = null;
			return true;
		}
				
		bool sqlConnParm2(string sqlStatement)
		{
						
			SqlConnection con_data = new SqlConnection(sqlconn);
			SqlCommand cmd_data = new SqlCommand();
			
			try
			{
				cmd_data.Connection = con_data;
				cmd_data.CommandText = sqlStatement;
				cmd_data.CommandType = CommandType.StoredProcedure;

				cmd_data.Parameters.Add(new SqlParameter("@SP_PROD_DOCNO", SqlDbType.NVarChar, 50));
				cmd_data.Parameters["@SP_PROD_DOCNO"].Value = txtbx_ref_no.Text;
					
				con_data.Open();
				cmd_data.ExecuteNonQuery();					
			} 
			catch (Exception ex) 
			{	
				con_data.Close();
				MessageBox.Show("Unexpected error happen" + Environment.NewLine + ex.Message + ex.ToString());			
				return false;
			} 
			finally 
			{
				con_data.Close();		
			}
			
			con_data.Dispose();
			con_data = null;
			cmd_data = null;
			return true;
		}
		
		
		bool sqlConnParmCount()
		{
			
			SqlConnection con_data_count = new SqlConnection(sqlconn);
			SqlCommand cmd_data_count = new SqlCommand();
			
			try 
			{
				cmd_data_count.CommandText = @"select PROD_TOTALMUSTPACK from TBL_PROD_CONV_JO_SLIT_CHECK_TEMP";
				//cmd_data_count.Parameters.AddWithValue("@doc_no",  txtbx_ref_no.Text.ToUpper());
				cmd_data_count.Connection = con_data_count;
				con_data_count.Open();
				SqlDataReader rd_count = cmd_data_count.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
				
				if (rd_count.Read())
				{	
					qty_roll_prod = Double.Parse(rd_count["PROD_TOTALMUSTPACK"].ToString());
				} 
				else 
				{
					MessageBox.Show("Error - Packing Save \nCannot find JO!");
					return false;
				}
			} 
			catch (Exception ex) 
			{
				MessageBox.Show("Error - Packing Save \nCannot load DB!" + ex.Message + ex.ToString());
				return false;
			} 
			finally 
			{
				con_data_count.Close();
			}
			
			con_data_count.Dispose();
			con_data_count = null;
			cmd_data_count = null;	
			return true;
		}
		
		
		//-----------retrieve-----------------------------------------------
		
		void Retrieve()
		{
			SqlConnection con_SP1 = new SqlConnection(sqlconn);
			SqlCommand cmd_SP1 = new SqlCommand();
				
			try 
			{
				cmd_SP1.CommandText = @"SELECT * FROM TBL_PROD_CONV_JO_PACKING where PROD_DOCNO = @doc_no and PROD_LINE = @line_no";
				cmd_SP1.Parameters.AddWithValue("@doc_no",  ref_no);
        		cmd_SP1.Parameters.AddWithValue("@line_no",  prod_line);
				cmd_SP1.Connection = con_SP1;
				con_SP1.Open();
				SqlDataReader rd_SP1 = cmd_SP1.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
					
				if (rd_SP1.Read())
				{				        	
					txtbx_cust.Text = rd_SP1["PROD_CUSTOMER"].ToString();
					txtbx_prod_code.Text = rd_SP1["PROD_CODE"].ToString();
					txtbx_color.Text = rd_SP1["PROD_COLOR"].ToString();
					txtbx_brand.Text = rd_SP1["PROD_BRAND"].ToString();
					txtbx_length_cust.Text = rd_SP1["PROD_LENGTH"].ToString();
					txtbx_width_cust.Text = rd_SP1["PROD_WIDTH"].ToString();
					txtbx_mic.Text = rd_SP1["PROD_MICRON"].ToString();
					txtbx_conversion.Text = rd_SP1["PROD_CONVERSION"].ToString();
					txtbx_total_qty_order.Text = rd_SP1["PROD_QTYORDERED"].ToString();

					cbx_machine.Text = rd_SP1["PROD_MACHINE"].ToString();
					cbx_shift.Text = rd_SP1["PROD_SHIFT"].ToString();
					cbx_operator.Text = rd_SP1["PROD_OPERATOR"].ToString();
					
					cbx_helper.Text = rd_SP1["PROD_HELPER"].ToString();
					txtbx_ctn_qty.Text = rd_SP1["PROD_QTYCTN"].ToString();
					txtbx_roll_qty.Text = rd_SP1["PROD_QTYROLL"].ToString();
					txtbx_jr_lot_no1.Text = rd_SP1["PROD_LOTNO"].ToString();
					txtbx_jrlotno1.Text = rd_SP1["PROD_LOTNO"].ToString();
					txtbx_batch_no.Text = rd_SP1["PROD_BATCHNO"].ToString();
				} 
				else 
				{
					MessageBox.Show("Error : Cannot find JO!");
					return;
				}
			} 
			catch (Exception ex) 
			{
				MessageBox.Show("Error : Cannot load DB!" + ex.Message + ex.ToString());
				return;
			} 
			finally 
			{
				con_SP1.Close();
			}
			
			SqlConnection con_SP3 = new SqlConnection(sqlconn);
			SqlCommand cmd_SP3 = new SqlCommand();
			
			try 
			{
				cmd_SP3.CommandText = @"select * from TBL_PROD_CONV_JO where JODOCNO = @doc_no";
				cmd_SP3.Parameters.AddWithValue("@doc_no",  txtbx_ref_no.Text.ToUpper());
				cmd_SP3.Connection = con_SP3;
				con_SP3.Open();
				SqlDataReader rd_SP3 = cmd_SP3.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
				
				if (rd_SP3.Read())
				{	
					txtbx_total_qty_balance.Text = rd_SP3["JOPACKQTYBAL"].ToString();
				} 
				else 
				{
					MessageBox.Show("Error - Packing Retrieve \nCannot find JO!");
					return;
				}
			} 
			catch (Exception ex) 
			{
				MessageBox.Show("Error - Packing Retrieve \nCannot load DB!" + ex.Message + ex.ToString());
				return;
			} 
			finally 
			{
				con_SP3.Close();
			}
			
			con_SP3.Dispose();
			con_SP3 = null;
			cmd_SP3 = null;
		}		
	
		
		//--------------print----------------------------------------------
		
		void TempTable()
		{
			using (SqlConnection conn = new SqlConnection(sqlconn))
			{
				conn.Open();
				
				SqlCommand cmd  = new SqlCommand("SP_PROD_CONV_JO_PACKING_LIST_R1", conn);
				cmd.CommandType = CommandType.StoredProcedure;
				
				cmd.Parameters.Add(new SqlParameter("@SP_DOCNO", SqlDbType.NVarChar, 50));
				cmd.Parameters["@SP_DOCNO"].Value = txtbx_ref_no.Text.ToUpper();
					
				cmd.Parameters.Add(new SqlParameter("@SP_PACKNO", SqlDbType.NVarChar, 50));
				cmd.Parameters["@SP_PACKNO"].Value = prod_line;
								   
				cmd.ExecuteNonQuery();
				//return true;					
			}				
		}
		
		public void Print()
		{		
			//try
			//{
			using(Form frm = new Form())
			{
				//Form frm = new Form();
	        	frm.Height = 700;
	        	frm.Width = 800;

	
	        	//fyiReporting.RdlViewer.RdlViewer rdlView = new fyiReporting.RdlViewer.RdlViewer();
	        	var rdlViewer1 = new fyiReporting.RdlViewer.RdlViewer();
				var reportStrip = new fyiReporting.RdlViewer.ViewerToolstrip(rdlViewer1);
	        	Uri baseUri = new Uri(System.IO.Directory.GetCurrentDirectory());
	        	
//	        	if(cbx_remark5.Text == "SLITTING")
//	        	{
//	        		rdlViewer1.SourceFile = new Uri(baseUri, @"../report/planning_jo_converting_7.rdl");
//	        	}
//	        	else
//	        	{
//	        		rdlViewer1.SourceFile = new Uri(baseUri, @"../report/planning_jo_converting_9.rdl");
//	        	}
	        	//rdlView.Parameters += string.Format("&TestParam1={0}&TestParam2={1}", "Value 1", "Value 2");
	        	rdlViewer1.SourceFile = new Uri(baseUri, @"../report/planning_jo_converting_10_1.rdl");
	        	rdlViewer1.Report.DataSets["Data"].SetSource("select * from TBL_PROD_CONV_JO_PACKING_LIST_TEMP where PROD_LINE = '" + prod_line + "'");
	        	rdlViewer1.Rebuild();
	
	        	rdlViewer1.Dock = DockStyle.Fill;
	        	frm.Controls.Add(rdlViewer1);
	        	frm.Controls.Add(reportStrip);

        		frm.ShowDialog(this);
        	
			}	
		}
				
		
		//--------------event----------------------------------------------
		
		void Txtbx_ref_noKeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode == Keys.Enter)
			{
				if (txtbx_ref_no.Text.Substring(0, 4) == "GFSO" || txtbx_ref_no.Text.Substring(0, 4) == "SWSO" || txtbx_ref_no.Text.Substring(0, 5) == "STORE" || txtbx_ref_no.Text.Substring(0, 4) == "SBSD")
				     Search();
			}
			else return;
		}
		
		void Txtbx_ctn_qtyTextChanged(object sender, EventArgs e)
		{
			if(!String.IsNullOrWhiteSpace(txtbx_ctn_qty.Text))
			{
				TotalRollCalculation();
			}
			else
				return;	
		}
		
		void Txtbx_roll_qtyTextChanged(object sender, EventArgs e)
		{
			if(!String.IsNullOrWhiteSpace(txtbx_roll_qty.Text))
			{
				TotalRollCalculation();
			}
			else
				return;				
		}
		
		void LogFile(Exception exc)
		{
			EventLog AX2020Log = new EventLog();
			AX2020Log.Source = "AX2020 Code Error / Failure";
			AX2020Log.WriteEntry(exc.Message, EventLogEntryType.Error);
		}
		
		void EnterNumberOnly(KeyPressEventArgs e)
		{
			if (!(Char.IsDigit(e.KeyChar) || (e.KeyChar == (char)Keys.Back)))
		     {
		          e.Handled = true;
		          MessageBox.Show("Key in number only");
		     }
		}
		
		void Txtbx_ctn_qtyKeyPress(object sender, KeyPressEventArgs e)
		{
			EnterNumberOnly(e);
		}
		
		void Txtbx_roll_qtyKeyPress(object sender, KeyPressEventArgs e)
		{
			EnterNumberOnly(e);
		}		
		
		void Dt_gridCellClick(object sender, DataGridViewCellEventArgs e)
		{
			if(dt_grid.SelectedRows.Count > 0) // make sure user select at least 1 row 
			{
				ref_no = dt_grid.SelectedRows[0].Cells[0].Value + string.Empty;
			   	txtbx_ref_no.Text = ref_no;
			   	prod_line = dt_grid.SelectedRows[0].Cells[1].Value + string.Empty;
			   	
			   	Retrieve();
			   	//btn_del.Enabled = true;
			   	btn_save.Enabled = false;
			   	EnableAllControls(this);
			   	btn_del.Enabled = false;
			   	
			   	if(username.ToUpper() == "ADMIN")
				{
					btn_del.Enabled = true;
				}
			}		
 
		}
		
		void Dt_gridDataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
		{
			dt_grid.ClearSelection();
		}	
		
		void Txtbx_ctn_1TextChanged(object sender, EventArgs e)
		{
			if(!String.IsNullOrEmpty(txtbx_ctn_1.Text))
			{
				TotalRollCalculationUnitCtn();
			}
			else
				return;
		}
		
		void Txtbx_ctn_2TextChanged(object sender, EventArgs e)
		{
			if(!String.IsNullOrEmpty(txtbx_ctn_2.Text))
			{
				TotalRollCalculationUnitCtn();
			}
			else
				return;			
		}
		
		void Txtbx_ctn_3TextChanged(object sender, EventArgs e)
		{
			if(!String.IsNullOrEmpty(txtbx_ctn_3.Text))
			{
				TotalRollCalculationUnitCtn();
			}
			else
				return;			
		}
		
		void Txtbx_ctn_4TextChanged(object sender, EventArgs e)
		{
			if(!String.IsNullOrEmpty(txtbx_ctn_4.Text))
			{
				TotalRollCalculationUnitCtn();
			}
			else
				return;			
		}
		
		void Txtbx_ctn_5TextChanged(object sender, EventArgs e)
		{
			if(!String.IsNullOrEmpty(txtbx_ctn_5.Text))
			{
				TotalRollCalculationUnitCtn();
			}
			else
				return;
						
		}
		
		void Txtbx_roll_1TextChanged(object sender, EventArgs e)
		{
			if(!String.IsNullOrEmpty(txtbx_roll_1.Text))
			{
				TotalRollCalculationUnitRoll();
			}
			else
				return;			
		}
		
		void Txtbx_roll_2TextChanged(object sender, EventArgs e)
		{
			if(!String.IsNullOrEmpty(txtbx_roll_2.Text))
			{
				TotalRollCalculationUnitRoll();
			}
			else
				return;	
		}
		
		void Txtbx_roll_3TextChanged(object sender, EventArgs e)
		{
			if(!String.IsNullOrEmpty(txtbx_roll_3.Text))
			{
				TotalRollCalculationUnitRoll();
			}
			else
				return;
		}
		
		void Txtbx_roll_4TextChanged(object sender, EventArgs e)
		{
			if(!String.IsNullOrEmpty(txtbx_roll_4.Text))
			{
				TotalRollCalculationUnitRoll();
			}
			else
				return;
		}
		
		void Txtbx_roll_5TextChanged(object sender, EventArgs e)
		{
			if(!String.IsNullOrEmpty(txtbx_roll_5.Text))
			{
				TotalRollCalculationUnitRoll();
			}
			else
				return;
					
		}
		
		void Txtbx_reject_1TextChanged(object sender, EventArgs e)
		{
			if(!String.IsNullOrEmpty(txtbx_reject_1.Text))
			{
				TotalRollCalculationUnitReject();
			}
			else
				return;
		}
		
		void Txtbx_reject_2TextChanged(object sender, EventArgs e)
		{
			if(!String.IsNullOrEmpty(txtbx_reject_2.Text))
			{
				TotalRollCalculationUnitReject();
			}
			else
				return;			
		}
		
		void Txtbx_reject_3TextChanged(object sender, EventArgs e)
		{
			if(!String.IsNullOrEmpty(txtbx_reject_3.Text))
			{
				TotalRollCalculationUnitReject();
			}
			else
				return;			
		}
		
		void Txtbx_reject_4TextChanged(object sender, EventArgs e)
		{
			if(!String.IsNullOrEmpty(txtbx_reject_4.Text))
			{
				TotalRollCalculationUnitReject();
			}
			else
				return;			
		}
		
		void Txtbx_reject_5TextChanged(object sender, EventArgs e)
		{
			if(!String.IsNullOrEmpty(txtbx_reject_5.Text))
			{
				TotalRollCalculationUnitReject();
			}
			else
				return;			
		}
		
		void Txtbx_ctn_1KeyPress(object sender, KeyPressEventArgs e)
		{
			EnterNumberOnly(e);
		}
		
		void Txtbx_ctn_2KeyPress(object sender, KeyPressEventArgs e)
		{
			EnterNumberOnly(e);
		}
		
		void Txtbx_ctn_3KeyPress(object sender, KeyPressEventArgs e)
		{
			EnterNumberOnly(e);
		}
		
		void Txtbx_ctn_4KeyPress(object sender, KeyPressEventArgs e)
		{
			EnterNumberOnly(e);
		}
		
		void Txtbx_ctn_5KeyPress(object sender, KeyPressEventArgs e)
		{
			EnterNumberOnly(e);
		}
		
		void Txtbx_roll_1KeyPress(object sender, KeyPressEventArgs e)
		{
			EnterNumberOnly(e);
		}
		
		void Txtbx_roll_2KeyPress(object sender, KeyPressEventArgs e)
		{
			EnterNumberOnly(e);
		}
		
		void Txtbx_roll_3KeyPress(object sender, KeyPressEventArgs e)
		{
			EnterNumberOnly(e);
		}
		
		void Txtbx_roll_4KeyPress(object sender, KeyPressEventArgs e)
		{
			EnterNumberOnly(e);
		}
		
		void Txtbx_roll_5KeyPress(object sender, KeyPressEventArgs e)
		{
			EnterNumberOnly(e);
		}
		
		void Txtbx_reject_1KeyPress(object sender, KeyPressEventArgs e)
		{
			EnterNumberOnly(e);
		}
		
		void Txtbx_reject_2KeyPress(object sender, KeyPressEventArgs e)
		{
			EnterNumberOnly(e);
		}
		
		void Txtbx_reject_3KeyPress(object sender, KeyPressEventArgs e)
		{
			EnterNumberOnly(e);
		}
		
		void Txtbx_reject_4KeyPress(object sender, KeyPressEventArgs e)
		{
			EnterNumberOnly(e);
		}
		
		void Txtbx_reject_5KeyPress(object sender, KeyPressEventArgs e)
		{
			EnterNumberOnly(e);
		}
		
		
		
		//-------------------- JR 1--------------------------------------------------------
		
		public void CheckDuplicateJR1()
		{			
			SqlConnection con_Check_Duplicate_JO = new SqlConnection(sqlconn);
			SqlCommand cmd_Check_Duplicate_JO = new SqlCommand();
				
			try 
			{
				cmd_Check_Duplicate_JO.CommandText = @"select * from VIEW_PROD_CONV_JO_SLITTING_JR where PROD_JRSHIPMARK like @ship_mark + '%'";// + "' and JODOCNO <> 'SMSO124608'";
				cmd_Check_Duplicate_JO.Parameters.AddWithValue("@ship_mark",  jr_shipmark1);
					
				cmd_Check_Duplicate_JO.Connection = con_Check_Duplicate_JO;
				con_Check_Duplicate_JO.Open();
				SqlDataReader rd_Check_Duplicate_JO = cmd_Check_Duplicate_JO.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
	
				if (rd_Check_Duplicate_JO.HasRows)
				{
					if (rd_Check_Duplicate_JO.Read())
					{
						double jr_consume1 = 0;
						
						//isDuplicate = true;
						//jr_shipmark 		= rd_Check_Duplicate_JO["PROD_JRSHIPMARK"].ToString();
						//jr_lot_no 			= rd_Check_Duplicate_JO["PROD_LOTNO"].ToString();
						jr_ref_no1 			= rd_Check_Duplicate_JO["PROD_JRBARCODE"].ToString();
						jr_micron1 			= rd_Check_Duplicate_JO["PROD_MICRON"].ToString();
						jr_color1 			= rd_Check_Duplicate_JO["PROD_COLOR"].ToString();
						jr_barcode1 			= rd_Check_Duplicate_JO["PROD_JRBARCODE"].ToString();
						jr_stockcode1 		= rd_Check_Duplicate_JO["PROD_STOCKCODE"].ToString();
							
						jr_width1 			= rd_Check_Duplicate_JO["PROD_WIDTH"].ToString();
						shipmark_ori_length1 = Convert.ToInt32(rd_Check_Duplicate_JO["PROD_LENGTH"]);
						
						jr_width1			= Convert.ToString(rd_Check_Duplicate_JO["PROD_WIDTH"]);
						
						jr_consume1			= Convert.ToDouble(rd_Check_Duplicate_JO["PROD_CONSUME_TOTAL"]);
						jr_length1 			= ((int)(Convert.ToDouble(shipmark_ori_length1) - Convert.ToDouble(jr_consume1))).ToString();
						
						if(Double.Parse(jr_length1) <= 0) 
						{
							//MessageBox.Show("JR already been consume");
							txtbx_result_1.Text = "JR already been consume";
							txtbx_jr_lot_no_img1.Text = "X";
		            		txtbx_jr_lot_no_img1.ForeColor = Color.Red;					
		            		txtbx_jr_lot_no1.Text = null;							
							return;
						}
						
						//MessageBox.Show("2 - "+jr_shipmark1.ToString());
					}
				}
				else
				{
					CheckAvailableQty1();
				}
			}
			catch (Exception ex)
			{
				con_Check_Duplicate_JO.Close();
				MessageBox.Show("Error - Converting Slitting Shipping Mark Duplicate " + ex.Message + ex.ToString());
				txtbx_jr_lot_no_img1.Text = null;				
		        txtbx_jr_lot_no1.Text = null;
				return;
			} 
			finally 
			{
				con_Check_Duplicate_JO.Close();
			}
				
			con_Check_Duplicate_JO.Dispose();
			cmd_Check_Duplicate_JO.Dispose();
			con_Check_Duplicate_JO = null;
			cmd_Check_Duplicate_JO = null;
			
			
		}
		
		public void CheckJRLotNo1()
		{
			SqlConnection con_SP3 = new SqlConnection(sqlconn);
			SqlCommand cmd_SP3 = new SqlCommand();
			
			try 
			{
				cmd_SP3.CommandText = @"select * from VIEW_CONVERTING_BARCODE where TrxSMQC like @doc_no + '%'";
				cmd_SP3.Parameters.AddWithValue("@doc_no",  txtbx_jrlotno1.Text.ToUpper());
				cmd_SP3.Connection = con_SP3;
				con_SP3.Open();
				SqlDataReader rd_SP3 = cmd_SP3.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
				
				if (rd_SP3.HasRows)
				{
					while (rd_SP3.Read())
					{
						
						txtbx_jr_lot_no_img1.Text = "✓";
		            	txtbx_jr_lot_no_img1.ForeColor = Color.Green;					
		            	txtbx_jr_lot_no1.Text = rd_SP3["TrxSMQC"].ToString().ToUpper();
		            	
		            	jr_shipmark1 = rd_SP3["TrxShipmark"].ToString().ToUpper();
		            	//MessageBox.Show("1 - "+jr_shipmark1.ToString());

						CheckDuplicateJR1();
		            	
					} 
				}
				else 
				{
					CheckJRLotNoRCP1();
				}
			
				
			} 
			catch (Exception ex) 
			{
				MessageBox.Show("Error - Packing Check JR Lot No \nCannot load DB!" + ex.Message + ex.ToString());
				txtbx_jr_lot_no_img1.Text = null;				
		        txtbx_jr_lot_no1.Text = null;
				return;
			} 
			finally 
			{
				con_SP3.Close();
			}
			
			con_SP3.Dispose();
			con_SP3 = null;
			cmd_SP3 = null;
		}
		
		public void CheckJRLotNoRCP1()
		{
			SqlConnection con_SP3 = new SqlConnection(sqlconn);
			SqlCommand cmd_SP3 = new SqlCommand();
			
			try 
			{
				cmd_SP3.CommandText = @"select * from [ax-sql].AX2020StagingDB.dbo.VIEW_AXERP_PDSBATCHATTRIBUTES_FULLINFO where INVENTBATCHID = @doc_no";
				cmd_SP3.Parameters.AddWithValue("@doc_no",  txtbx_jrlotno1.Text.ToUpper());
				cmd_SP3.Connection = con_SP3;
				con_SP3.Open();
				SqlDataReader rd_SP3 = cmd_SP3.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
				
				if (rd_SP3.Read())
				{
					txtbx_jr_lot_no_img1.Text = "✓";
	            	txtbx_jr_lot_no_img1.ForeColor = Color.Green;					
	            	txtbx_jr_lot_no1.Text = rd_SP3["INVENTBATCHID"].ToString().ToUpper();
	            	
	            	CheckAvailableQty1();
				} 
				else 
				{
					if(remark5 == "SLITTING")
					{
						txtbx_jr_lot_no_img1.Text = "X";
		            	txtbx_jr_lot_no_img1.ForeColor = Color.Red;
		            	//txtbx_jr_lot_no.Text = txtbx_jrlotno.Text.ToUpper();
		            	txtbx_jr_lot_no1.Text = null;
						//MessageBox.Show("Error - Packing Check JR Lot No \nCannot find JR Lot No!");
						return;
					}
					else
					{
						txtbx_jr_lot_no_img1.Text = "✓";
	            		txtbx_jr_lot_no_img1.ForeColor = Color.Green;					
	            		txtbx_jr_lot_no1.Text = txtbx_jrlotno1.Text.ToUpper();
	            		
	            		jr_shipmark1 	= txtbx_jrlotno1.Text.ToUpper();
						//jr_lot_no 		= string.Empty;
						jr_ref_no1 		= txtbx_ref_no.Text;
						jr_color1 		= txtbx_color.Text;
						jr_barcode1 		= txtbx_jr_lot_no1.Text;
						jr_stockcode1	= txtbx_jr_lot_no1.Text;
						jr_micron1 		= txtbx_mic.Text;
						jr_width1		= "0";
						jr_length1 		= "0";
					}
				}
			} 
			catch (Exception ex) 
			{
				MessageBox.Show("Error - Packing Check JR Lot No \nCannot load DB!" + ex.Message + ex.ToString());
				txtbx_jr_lot_no_img1.Text = null;				
		        txtbx_jr_lot_no1.Text = null;
				return;
			} 
			finally 
			{
				con_SP3.Close();
			}
			
			con_SP3.Dispose();
			con_SP3 = null;
			cmd_SP3 = null;
		}
		
		public void CheckAvailableQty1()
		{
			SqlConnection con = new SqlConnection(sqlconnStaging);
			SqlCommand cmd = new SqlCommand();
				
			try 
			{
				cmd.CommandText = "select top 1 * from VIEW_AXERP_QOH_ATTRIBUTE_FULLINFO_PM04 where INVENTBATCHID like @ship_mark +'%' or grade = @ship_mark +'%'";
				cmd.Parameters.AddWithValue("@ship_mark",  jr_shipmark1);
				//cmd.Parameters.AddWithValue("@stock_code",  txtbx_prod_code.Text.ToUpper());
				cmd.Connection = con;
				con.Open();
				SqlDataReader rd = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
					
				if (rd.HasRows)
				{
					while (rd.Read())
					{					        								
						jr_shipmark1 		= rd["INVENTBATCHID"].ToString();
						//jr_lot_no 			= rd["LOTNO"].ToString();
						jr_ref_no1			= rd["Grade"].ToString();
						jr_micron1 			= rd["Micron"].ToString();
						jr_color1 			= rd["Color"].ToString();
						jr_barcode1 			= rd["Grade"].ToString();
						jr_stockcode1 		= rd["ITEMID"].ToString();							
						jr_width1 			= rd["Width"].ToString();
						shipmark_ori_length1 = Convert.ToInt32(rd["LLength"]);
						//jr_length 			= rd["LLength"].ToString();							
						
						get_qty1 = Convert.ToDouble(rd["AVAILPHYSICAL"].ToString());
						qty_realmetre1 = Convert.ToDouble((double) get_qty1 / (double) Convert.ToDouble(jr_width1) * 1000);
						
						jr_length1 = qty_realmetre1.ToString();
						
						//MessageBox.Show("3 - "+jr_shipmark1.ToString());
															
					} 
				}
				else 
				{
					jr_shipmark1 	= string.Empty;
					//jr_lot_no1 		= string.Empty;
					jr_ref_no1 		= string.Empty;
					//txtbx_mic.Text 	= string.Empty;
					jr_color1 		= string.Empty;
					jr_barcode1 		= string.Empty;
					jr_stockcode1 	= string.Empty;
					jr_micron1 		= string.Empty;
					jr_width1 		= string.Empty;
					jr_length1 		= string.Empty;
						
					shipmark_ori_length1 = 0;
					
					//MessageBox.Show("Cannot find shipping mark!");
					txtbx_result_1.Text = "Cannot find shipping mark!";
					txtbx_jr_lot_no_img1.Text = "X";
		            txtbx_jr_lot_no_img1.ForeColor = Color.Red;					
		            txtbx_jr_lot_no1.Text = null;	
					return;

				}
			} 
			catch (Exception ex) 
			{
				MessageBox.Show("Error - Packing Check \nCannot load DB!" + ex.Message + ex.ToString());
				txtbx_jr_lot_no_img1.Text = null;				
		        txtbx_jr_lot_no1.Text = null;	
				return;
			} 
			finally 
			{
				con.Close();
			}
				
			con.Dispose();
			con = null;
			cmd = null;
			

		}
		
		//-------------------- JR 2--------------------------------------------------------
		
		public void CheckDuplicateJR2()
		{			
			SqlConnection con_Check_Duplicate_JO = new SqlConnection(sqlconn);
			SqlCommand cmd_Check_Duplicate_JO = new SqlCommand();
				
			try 
			{
				cmd_Check_Duplicate_JO.CommandText = @"select * from VIEW_PROD_CONV_JO_SLITTING_JR where PROD_JRSHIPMARK like @ship_mark + '%'";// + "' and JODOCNO <> 'SMSO224608'";
				cmd_Check_Duplicate_JO.Parameters.AddWithValue("@ship_mark",  jr_shipmark2);
					
				cmd_Check_Duplicate_JO.Connection = con_Check_Duplicate_JO;
				con_Check_Duplicate_JO.Open();
				SqlDataReader rd_Check_Duplicate_JO = cmd_Check_Duplicate_JO.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
	
				if (rd_Check_Duplicate_JO.HasRows)
				{
					if (rd_Check_Duplicate_JO.Read())
					{
						double jr_consume2 = 0;
						
						//isDuplicate = true;
						//jr_shipmark 		= rd_Check_Duplicate_JO["PROD_JRSHIPMARK"].ToString();
						//jr_lot_no 			= rd_Check_Duplicate_JO["PROD_LOTNO"].ToString();
						jr_ref_no2 			= rd_Check_Duplicate_JO["PROD_JRBARCODE"].ToString();
						jr_micron2 			= rd_Check_Duplicate_JO["PROD_MICRON"].ToString();
						jr_color2 			= rd_Check_Duplicate_JO["PROD_COLOR"].ToString();
						jr_barcode2 			= rd_Check_Duplicate_JO["PROD_JRBARCODE"].ToString();
						jr_stockcode2 		= rd_Check_Duplicate_JO["PROD_STOCKCODE"].ToString();
							
						jr_width2 			= rd_Check_Duplicate_JO["PROD_WIDTH"].ToString();
						shipmark_ori_length2 = Convert.ToInt32(rd_Check_Duplicate_JO["PROD_LENGTH"]);
						
						jr_width2			= Convert.ToString(rd_Check_Duplicate_JO["PROD_WIDTH"]);
						
						jr_consume2			= Convert.ToDouble(rd_Check_Duplicate_JO["PROD_CONSUME_TOTAL"]);
						jr_length2 			= ((int)(Convert.ToDouble(shipmark_ori_length2) - Convert.ToDouble(jr_consume2))).ToString();
						
						if(Double.Parse(jr_length2) <= 0) 
						{
							//MessageBox.Show("JR already been consume");
							txtbx_result_2.Text = "JR already been consume";
							txtbx_jr_lot_no_img2.Text = "X";
		            		txtbx_jr_lot_no_img2.ForeColor = Color.Red;					
		            		txtbx_jr_lot_no2.Text = null;							
							return;
						}
						
						//MessageBox.Show("2 - "+jr_shipmark2.ToString());
					}
				}
				else
				{
					CheckAvailableQty2();
				}
			}
			catch (Exception ex)
			{
				con_Check_Duplicate_JO.Close();
				MessageBox.Show("Error - Converting Slitting Shipping Mark Duplicate " + ex.Message + ex.ToString());
				txtbx_jr_lot_no_img2.Text = null;				
		        txtbx_jr_lot_no2.Text = null;
				return;
			} 
			finally 
			{
				con_Check_Duplicate_JO.Close();
			}
				
			con_Check_Duplicate_JO.Dispose();
			cmd_Check_Duplicate_JO.Dispose();
			con_Check_Duplicate_JO = null;
			cmd_Check_Duplicate_JO = null;
			
			
		}
		
		public void CheckJRLotNo2()
		{
			SqlConnection con_SP3 = new SqlConnection(sqlconn);
			SqlCommand cmd_SP3 = new SqlCommand();
			
			try 
			{
				cmd_SP3.CommandText = @"select * from VIEW_CONVERTING_BARCODE where TrxSMQC like @doc_no + '%'";
				cmd_SP3.Parameters.AddWithValue("@doc_no",  txtbx_jrlotno2.Text.ToUpper());
				cmd_SP3.Connection = con_SP3;
				con_SP3.Open();
				SqlDataReader rd_SP3 = cmd_SP3.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
				
				if (rd_SP3.HasRows)
				{
					while (rd_SP3.Read())
					{
						
						txtbx_jr_lot_no_img2.Text = "✓";
		            	txtbx_jr_lot_no_img2.ForeColor = Color.Green;					
		            	txtbx_jr_lot_no2.Text = rd_SP3["TrxSMQC"].ToString().ToUpper();
		            	
		            	jr_shipmark2 = rd_SP3["TrxShipmark"].ToString().ToUpper();
		            	//MessageBox.Show("2 - "+jr_shipmark2.ToString());

						CheckDuplicateJR2();
		            	
					} 
				}
				else 
				{
					CheckJRLotNoRCP2();
				}
			
				
			} 
			catch (Exception ex) 
			{
				MessageBox.Show("Error - Packing Check JR Lot No \nCannot load DB!" + ex.Message + ex.ToString());
				txtbx_jr_lot_no_img2.Text = null;				
		        txtbx_jr_lot_no2.Text = null;
				return;
			} 
			finally 
			{
				con_SP3.Close();
			}
			
			con_SP3.Dispose();
			con_SP3 = null;
			cmd_SP3 = null;
		}
		
		public void CheckJRLotNoRCP2()
		{
			SqlConnection con_SP3 = new SqlConnection(sqlconn);
			SqlCommand cmd_SP3 = new SqlCommand();
			
			try 
			{
				cmd_SP3.CommandText = @"select * from [ax-sql].AX2020StagingDB.dbo.VIEW_AXERP_PDSBATCHATTRIBUTES_FULLINFO where INVENTBATCHID = @doc_no";
				cmd_SP3.Parameters.AddWithValue("@doc_no",  txtbx_jrlotno2.Text.ToUpper());
				cmd_SP3.Connection = con_SP3;
				con_SP3.Open();
				SqlDataReader rd_SP3 = cmd_SP3.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
				
				if (rd_SP3.Read())
				{
					txtbx_jr_lot_no_img2.Text = "✓";
	            	txtbx_jr_lot_no_img2.ForeColor = Color.Green;					
	            	txtbx_jr_lot_no2.Text = rd_SP3["INVENTBATCHID"].ToString().ToUpper();
	            	
	            	CheckAvailableQty2();
				} 
				else 
				{
					if(remark5 == "SLITTING")
					{
						txtbx_jr_lot_no_img2.Text = "X";
		            	txtbx_jr_lot_no_img2.ForeColor = Color.Red;
		            	//txtbx_jr_lot_no.Text = txtbx_jrlotno.Text.ToUpper();
		            	txtbx_jr_lot_no2.Text = null;
						//MessageBox.Show("Error - Packing Check JR Lot No \nCannot find JR Lot No!");
						return;
					}
					else
					{
						txtbx_jr_lot_no_img2.Text = "✓";
	            		txtbx_jr_lot_no_img2.ForeColor = Color.Green;					
	            		txtbx_jr_lot_no2.Text = txtbx_jrlotno2.Text.ToUpper();
	            		
	            		jr_shipmark2 	= txtbx_jrlotno1.Text.ToUpper();
						//jr_lot_no 		= string.Empty;
						jr_ref_no2 		= txtbx_ref_no.Text;
						jr_color2 		= txtbx_color.Text;
						jr_barcode2 		= txtbx_jr_lot_no2.Text;
						jr_stockcode2	= txtbx_jr_lot_no2.Text;
						jr_micron2 		= txtbx_mic.Text;
						jr_width2		= "0";
						jr_length2 		= "0";
					}
				}
			} 
			catch (Exception ex) 
			{
				MessageBox.Show("Error - Packing Check JR Lot No \nCannot load DB!" + ex.Message + ex.ToString());
				txtbx_jr_lot_no_img2.Text = null;				
		        txtbx_jr_lot_no2.Text = null;
				return;
			} 
			finally 
			{
				con_SP3.Close();
			}
			
			con_SP3.Dispose();
			con_SP3 = null;
			cmd_SP3 = null;
		}
		
		public void CheckAvailableQty2()
		{
			SqlConnection con = new SqlConnection(sqlconnStaging);
			SqlCommand cmd = new SqlCommand();
				
			try 
			{
				cmd.CommandText = "select top 2 * from VIEW_AXERP_QOH_ATTRIBUTE_FULLINFO_PM04 where INVENTBATCHID like @ship_mark +'%' or grade = @ship_mark +'%'";
				cmd.Parameters.AddWithValue("@ship_mark",  jr_shipmark2);
				//cmd.Parameters.AddWithValue("@stock_code",  txtbx_prod_code.Text.ToUpper());
				cmd.Connection = con;
				con.Open();
				SqlDataReader rd = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
					
				if (rd.HasRows)
				{
					while (rd.Read())
					{					        								
						jr_shipmark2 		= rd["INVENTBATCHID"].ToString();
						//jr_lot_no 			= rd["LOTNO"].ToString();
						jr_ref_no2			= rd["Grade"].ToString();
						jr_micron2 			= rd["Micron"].ToString();
						jr_color2 			= rd["Color"].ToString();
						jr_barcode2 			= rd["Grade"].ToString();
						jr_stockcode2 		= rd["ITEMID"].ToString();							
						jr_width2 			= rd["Width"].ToString();
						shipmark_ori_length2 = Convert.ToInt32(rd["LLength"]);
						//jr_length 			= rd["LLength"].ToString();							
						
						get_qty2 = Convert.ToDouble(rd["AVAILPHYSICAL"].ToString());
						qty_realmetre2 = Convert.ToDouble((double) get_qty2 / (double) Convert.ToDouble(jr_width2) * 2000);
						
						jr_length2 = qty_realmetre2.ToString();
						
						//MessageBox.Show("3 - "+jr_shipmark2.ToString());
															
					} 
				}
				else 
				{
					jr_shipmark2 	= string.Empty;
					//jr_lot_no2 		= string.Empty;
					jr_ref_no2 		= string.Empty;
					//txtbx_mic.Text 	= string.Empty;
					jr_color2 		= string.Empty;
					jr_barcode2 		= string.Empty;
					jr_stockcode2 	= string.Empty;
					jr_micron2 		= string.Empty;
					jr_width2 		= string.Empty;
					jr_length2 		= string.Empty;
						
					shipmark_ori_length2 = 0;
					
					//MessageBox.Show("Cannot find shipping mark!");
					txtbx_result_2.Text = "Cannot find shipping mark!";
					txtbx_jr_lot_no_img2.Text = "X";
		            txtbx_jr_lot_no_img2.ForeColor = Color.Red;					
		            txtbx_jr_lot_no2.Text = null;	
					return;

				}
			} 
			catch (Exception ex) 
			{
				MessageBox.Show("Error - Packing Check \nCannot load DB!" + ex.Message + ex.ToString());
				txtbx_jr_lot_no_img2.Text = null;				
		        txtbx_jr_lot_no2.Text = null;	
				return;
			} 
			finally 
			{
				con.Close();
			}
				
			con.Dispose();
			con = null;
			cmd = null;
			

		}
		
		//-------------------- JR 3--------------------------------------------------------
		
		public void CheckDuplicateJR3()
		{			
			SqlConnection con_Check_Duplicate_JO = new SqlConnection(sqlconn);
			SqlCommand cmd_Check_Duplicate_JO = new SqlCommand();
				
			try 
			{
				cmd_Check_Duplicate_JO.CommandText = @"select * from VIEW_PROD_CONV_JO_SLITTING_JR where PROD_JRSHIPMARK like @ship_mark + '%'";// + "' and JODOCNO <> 'SMSO334608'";
				cmd_Check_Duplicate_JO.Parameters.AddWithValue("@ship_mark",  jr_shipmark3);
					
				cmd_Check_Duplicate_JO.Connection = con_Check_Duplicate_JO;
				con_Check_Duplicate_JO.Open();
				SqlDataReader rd_Check_Duplicate_JO = cmd_Check_Duplicate_JO.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
	
				if (rd_Check_Duplicate_JO.HasRows)
				{
					if (rd_Check_Duplicate_JO.Read())
					{
						double jr_consume3 = 0;
						
						//isDuplicate = true;
						//jr_shipmark 		= rd_Check_Duplicate_JO["PROD_JRSHIPMARK"].ToString();
						//jr_lot_no 			= rd_Check_Duplicate_JO["PROD_LOTNO"].ToString();
						jr_ref_no3 			= rd_Check_Duplicate_JO["PROD_JRBARCODE"].ToString();
						jr_micron3 			= rd_Check_Duplicate_JO["PROD_MICRON"].ToString();
						jr_color3 			= rd_Check_Duplicate_JO["PROD_COLOR"].ToString();
						jr_barcode3 			= rd_Check_Duplicate_JO["PROD_JRBARCODE"].ToString();
						jr_stockcode3 		= rd_Check_Duplicate_JO["PROD_STOCKCODE"].ToString();
							
						jr_width3 			= rd_Check_Duplicate_JO["PROD_WIDTH"].ToString();
						shipmark_ori_length3 = Convert.ToInt32(rd_Check_Duplicate_JO["PROD_LENGTH"]);
						
						jr_width3			= Convert.ToString(rd_Check_Duplicate_JO["PROD_WIDTH"]);
						
						jr_consume3			= Convert.ToDouble(rd_Check_Duplicate_JO["PROD_CONSUME_TOTAL"]);
						jr_length3 			= ((int)(Convert.ToDouble(shipmark_ori_length3) - Convert.ToDouble(jr_consume3))).ToString();
						
						if(Double.Parse(jr_length3) <= 0) 
						{
							//MessageBox.Show("JR already been consume");
							txtbx_result_3.Text = "JR already been consume";
							txtbx_jr_lot_no_img3.Text = "X";
		            		txtbx_jr_lot_no_img3.ForeColor = Color.Red;					
		            		txtbx_jr_lot_no3.Text = null;							
							return;
						}
						
						//MessageBox.Show("3 - "+jr_shipmark3.ToString());
					}
				}
				else
				{
					CheckAvailableQty3();
				}
			}
			catch (Exception ex)
			{
				con_Check_Duplicate_JO.Close();
				MessageBox.Show("Error - Converting Slitting Shipping Mark Duplicate " + ex.Message + ex.ToString());
				txtbx_jr_lot_no_img3.Text = null;				
		        txtbx_jr_lot_no3.Text = null;
				return;
			} 
			finally 
			{
				con_Check_Duplicate_JO.Close();
			}
				
			con_Check_Duplicate_JO.Dispose();
			cmd_Check_Duplicate_JO.Dispose();
			con_Check_Duplicate_JO = null;
			cmd_Check_Duplicate_JO = null;
			
			
		}
		
		public void CheckJRLotNo3()
		{
			SqlConnection con_SP3 = new SqlConnection(sqlconn);
			SqlCommand cmd_SP3 = new SqlCommand();
			
			try 
			{
				cmd_SP3.CommandText = @"select * from VIEW_CONVERTING_BARCODE where TrxSMQC like @doc_no + '%'";
				cmd_SP3.Parameters.AddWithValue("@doc_no",  txtbx_jrlotno3.Text.ToUpper());
				cmd_SP3.Connection = con_SP3;
				con_SP3.Open();
				SqlDataReader rd_SP3 = cmd_SP3.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
				
				if (rd_SP3.HasRows)
				{
					while (rd_SP3.Read())
					{
						
						txtbx_jr_lot_no_img3.Text = "✓";
		            	txtbx_jr_lot_no_img3.ForeColor = Color.Green;					
		            	txtbx_jr_lot_no3.Text = rd_SP3["TrxSMQC"].ToString().ToUpper();
		            	
		            	jr_shipmark3 = rd_SP3["TrxShipmark"].ToString().ToUpper();
		            	//MessageBox.Show("3 - "+jr_shipmark3.ToString());

						CheckDuplicateJR3();
		            	
					} 
				}
				else 
				{
					CheckJRLotNoRCP3();
				}
			
				
			} 
			catch (Exception ex) 
			{
				MessageBox.Show("Error - Packing Check JR Lot No \nCannot load DB!" + ex.Message + ex.ToString());
				txtbx_jr_lot_no_img3.Text = null;				
		        txtbx_jr_lot_no3.Text = null;
				return;
			} 
			finally 
			{
				con_SP3.Close();
			}
			
			con_SP3.Dispose();
			con_SP3 = null;
			cmd_SP3 = null;
		}
		
		public void CheckJRLotNoRCP3()
		{
			SqlConnection con_SP3 = new SqlConnection(sqlconn);
			SqlCommand cmd_SP3 = new SqlCommand();
			
			try 
			{
				cmd_SP3.CommandText = @"select * from [ax-sql].AX3030StagingDB.dbo.VIEW_AXERP_PDSBATCHATTRIBUTES_FULLINFO where INVENTBATCHID = @doc_no";
				cmd_SP3.Parameters.AddWithValue("@doc_no",  txtbx_jrlotno3.Text.ToUpper());
				cmd_SP3.Connection = con_SP3;
				con_SP3.Open();
				SqlDataReader rd_SP3 = cmd_SP3.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
				
				if (rd_SP3.Read())
				{
					txtbx_jr_lot_no_img3.Text = "✓";
	            	txtbx_jr_lot_no_img3.ForeColor = Color.Green;					
	            	txtbx_jr_lot_no3.Text = rd_SP3["INVENTBATCHID"].ToString().ToUpper();
	            	
	            	CheckAvailableQty3();
				} 
				else 
				{
					if(remark5 == "SLITTING")
					{
						txtbx_jr_lot_no_img3.Text = "X";
		            	txtbx_jr_lot_no_img3.ForeColor = Color.Red;
		            	//txtbx_jr_lot_no.Text = txtbx_jrlotno.Text.ToUpper();
		            	txtbx_jr_lot_no3.Text = null;
						//MessageBox.Show("Error - Packing Check JR Lot No \nCannot find JR Lot No!");
						return;
					}
					else
					{
						txtbx_jr_lot_no_img3.Text = "✓";
	            		txtbx_jr_lot_no_img3.ForeColor = Color.Green;					
	            		txtbx_jr_lot_no3.Text = txtbx_jrlotno3.Text.ToUpper();
	            		
	            		jr_shipmark3 	= txtbx_jrlotno1.Text.ToUpper();
						//jr_lot_no 		= string.Empty;
						jr_ref_no3 		= txtbx_ref_no.Text;
						jr_color3 		= txtbx_color.Text;
						jr_barcode3 		= txtbx_jr_lot_no3.Text;
						jr_stockcode3	= txtbx_jr_lot_no3.Text;
						jr_micron3 		= txtbx_mic.Text;
						jr_width3		= "0";
						jr_length3 		= "0";
					}
				}
			} 
			catch (Exception ex) 
			{
				MessageBox.Show("Error - Packing Check JR Lot No \nCannot load DB!" + ex.Message + ex.ToString());
				txtbx_jr_lot_no_img3.Text = null;				
		        txtbx_jr_lot_no3.Text = null;
				return;
			} 
			finally 
			{
				con_SP3.Close();
			}
			
			con_SP3.Dispose();
			con_SP3 = null;
			cmd_SP3 = null;
		}
		
		public void CheckAvailableQty3()
		{
			SqlConnection con = new SqlConnection(sqlconnStaging);
			SqlCommand cmd = new SqlCommand();
				
			try 
			{
				cmd.CommandText = "select top 1 * from VIEW_AXERP_QOH_ATTRIBUTE_FULLINFO_PM04 where INVENTBATCHID like @ship_mark +'%' or grade = @ship_mark +'%'";
				cmd.Parameters.AddWithValue("@ship_mark",  jr_shipmark3);
				//cmd.Parameters.AddWithValue("@stock_code",  txtbx_prod_code.Text.ToUpper());
				cmd.Connection = con;
				con.Open();
				SqlDataReader rd = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
					
				if (rd.HasRows)
				{
					while (rd.Read())
					{			        								
						jr_shipmark3 		= rd["INVENTBATCHID"].ToString();
						//jr_lot_no 			= rd["LOTNO"].ToString();
						jr_ref_no3			= rd["Grade"].ToString();
						jr_micron3 			= rd["Micron"].ToString();
						jr_color3 			= rd["Color"].ToString();
						jr_barcode3 			= rd["Grade"].ToString();
						jr_stockcode3 		= rd["ITEMID"].ToString();							
						jr_width3 			= rd["Width"].ToString();
						shipmark_ori_length3 = Convert.ToInt32(rd["LLength"]);
						//jr_length 			= rd["LLength"].ToString();							
						
						get_qty3 = Convert.ToDouble(rd["AVAILPHYSICAL"].ToString());
						qty_realmetre3 = Convert.ToDouble((double) get_qty3 / (double) Convert.ToDouble(jr_width3) * 3000);
						
						jr_length3 = qty_realmetre3.ToString();
						
						//MessageBox.Show("3 - "+jr_shipmark3.ToString());
															
					} 
				}
				else 
				{
					jr_shipmark3 	= string.Empty;
					//jr_lot_no3 		= string.Empty;
					jr_ref_no3 		= string.Empty;
					//txtbx_mic.Text 	= string.Empty;
					jr_color3 		= string.Empty;
					jr_barcode3 		= string.Empty;
					jr_stockcode3 	= string.Empty;
					jr_micron3 		= string.Empty;
					jr_width3 		= string.Empty;
					jr_length3 		= string.Empty;
						
					shipmark_ori_length3 = 0;
					
					//MessageBox.Show("Cannot find shipping mark!");
					txtbx_result_3.Text = "Cannot find shipping mark!";
					txtbx_jr_lot_no_img3.Text = "X";
		            txtbx_jr_lot_no_img3.ForeColor = Color.Red;					
		            txtbx_jr_lot_no3.Text = null;	
					return;

				}
			} 
			catch (Exception ex) 
			{
				MessageBox.Show("Error - Packing Check \nCannot load DB!" + ex.Message + ex.ToString());
				txtbx_jr_lot_no_img3.Text = null;				
		        txtbx_jr_lot_no3.Text = null;	
				return;
			} 
			finally 
			{
				con.Close();
			}
				
			con.Dispose();
			con = null;
			cmd = null;
			

		}
		
		
		//-------------------- JR 4--------------------------------------------------------
		
		public void CheckDuplicateJR4()
		{			
			SqlConnection con_Check_Duplicate_JO = new SqlConnection(sqlconn);
			SqlCommand cmd_Check_Duplicate_JO = new SqlCommand();
				
			try 
			{
				cmd_Check_Duplicate_JO.CommandText = @"select * from VIEW_PROD_CONV_JO_SLITTING_JR where PROD_JRSHIPMARK like @ship_mark + '%'";// + "' and JODOCNO <> 'SMSO444608'";
				cmd_Check_Duplicate_JO.Parameters.AddWithValue("@ship_mark",  jr_shipmark4);
					
				cmd_Check_Duplicate_JO.Connection = con_Check_Duplicate_JO;
				con_Check_Duplicate_JO.Open();
				SqlDataReader rd_Check_Duplicate_JO = cmd_Check_Duplicate_JO.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
	
				if (rd_Check_Duplicate_JO.HasRows)
				{
					if (rd_Check_Duplicate_JO.Read())
					{
						double jr_consume4 = 0;
						
						//isDuplicate = true;
						//jr_shipmark 		= rd_Check_Duplicate_JO["PROD_JRSHIPMARK"].ToString();
						//jr_lot_no 			= rd_Check_Duplicate_JO["PROD_LOTNO"].ToString();
						jr_ref_no4 			= rd_Check_Duplicate_JO["PROD_JRBARCODE"].ToString();
						jr_micron4 			= rd_Check_Duplicate_JO["PROD_MICRON"].ToString();
						jr_color4 			= rd_Check_Duplicate_JO["PROD_COLOR"].ToString();
						jr_barcode4 			= rd_Check_Duplicate_JO["PROD_JRBARCODE"].ToString();
						jr_stockcode4 		= rd_Check_Duplicate_JO["PROD_STOCKCODE"].ToString();
							
						jr_width4 			= rd_Check_Duplicate_JO["PROD_WIDTH"].ToString();
						shipmark_ori_length4 = Convert.ToInt32(rd_Check_Duplicate_JO["PROD_LENGTH"]);
						
						jr_width4			= Convert.ToString(rd_Check_Duplicate_JO["PROD_WIDTH"]);
						
						jr_consume4			= Convert.ToDouble(rd_Check_Duplicate_JO["PROD_CONSUME_TOTAL"]);
						jr_length4 			= ((int)(Convert.ToDouble(shipmark_ori_length4) - Convert.ToDouble(jr_consume4))).ToString();
						
						if(Double.Parse(jr_length4) <= 0) 
						{
							//MessageBox.Show("JR already been consume");
							txtbx_result_4.Text = "JR already been consume";
							txtbx_jr_lot_no_img4.Text = "X";
		            		txtbx_jr_lot_no_img4.ForeColor = Color.Red;					
		            		txtbx_jr_lot_no4.Text = null;							
							return;
						}
						
						//MessageBox.Show("4 - "+jr_shipmark4.ToString());
					}
				}
				else
				{
					CheckAvailableQty4();
				}
			}
			catch (Exception ex)
			{
				con_Check_Duplicate_JO.Close();
				MessageBox.Show("Error - Converting Slitting Shipping Mark Duplicate " + ex.Message + ex.ToString());
				txtbx_jr_lot_no_img4.Text = null;				
		        txtbx_jr_lot_no4.Text = null;
				return;
			} 
			finally 
			{
				con_Check_Duplicate_JO.Close();
			}
				
			con_Check_Duplicate_JO.Dispose();
			cmd_Check_Duplicate_JO.Dispose();
			con_Check_Duplicate_JO = null;
			cmd_Check_Duplicate_JO = null;
			
			
		}
		
		public void CheckJRLotNo4()
		{
			SqlConnection con_SP3 = new SqlConnection(sqlconn);
			SqlCommand cmd_SP3 = new SqlCommand();
			
			try 
			{
				cmd_SP3.CommandText = @"select * from VIEW_CONVERTING_BARCODE where TrxSMQC like @doc_no + '%'";
				cmd_SP3.Parameters.AddWithValue("@doc_no",  txtbx_jrlotno4.Text.ToUpper());
				cmd_SP3.Connection = con_SP3;
				con_SP3.Open();
				SqlDataReader rd_SP3 = cmd_SP3.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
				
				if (rd_SP3.HasRows)
				{
					while (rd_SP3.Read())
					{
						
						txtbx_jr_lot_no_img4.Text = "✓";
		            	txtbx_jr_lot_no_img4.ForeColor = Color.Green;					
		            	txtbx_jr_lot_no4.Text = rd_SP3["TrxSMQC"].ToString().ToUpper();
		            	
		            	jr_shipmark4 = rd_SP3["TrxShipmark"].ToString().ToUpper();
		            	//MessageBox.Show("4 - "+jr_shipmark4.ToString());

						CheckDuplicateJR4();
		            	
					} 
				}
				else 
				{
					CheckJRLotNoRCP4();
				}
			
				
			} 
			catch (Exception ex) 
			{
				MessageBox.Show("Error - Packing Check JR Lot No \nCannot load DB!" + ex.Message + ex.ToString());
				txtbx_jr_lot_no_img4.Text = null;				
		        txtbx_jr_lot_no4.Text = null;
				return;
			} 
			finally 
			{
				con_SP3.Close();
			}
			
			con_SP3.Dispose();
			con_SP3 = null;
			cmd_SP3 = null;
		}
		
		public void CheckJRLotNoRCP4()
		{
			SqlConnection con_SP3 = new SqlConnection(sqlconn);
			SqlCommand cmd_SP3 = new SqlCommand();
			
			try 
			{
				cmd_SP3.CommandText = @"select * from [ax-sql].AX4040StagingDB.dbo.VIEW_AXERP_PDSBATCHATTRIBUTES_FULLINFO where INVENTBATCHID = @doc_no";
				cmd_SP3.Parameters.AddWithValue("@doc_no",  txtbx_jrlotno4.Text.ToUpper());
				cmd_SP3.Connection = con_SP3;
				con_SP3.Open();
				SqlDataReader rd_SP3 = cmd_SP3.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
				
				if (rd_SP3.Read())
				{
					txtbx_jr_lot_no_img4.Text = "✓";
	            	txtbx_jr_lot_no_img4.ForeColor = Color.Green;					
	            	txtbx_jr_lot_no4.Text = rd_SP3["INVENTBATCHID"].ToString().ToUpper();
	            	
	            	CheckAvailableQty4();
				} 
				else 
				{
					if(remark5 == "SLITTING")
					{
						txtbx_jr_lot_no_img4.Text = "X";
		            	txtbx_jr_lot_no_img4.ForeColor = Color.Red;
		            	//txtbx_jr_lot_no.Text = txtbx_jrlotno.Text.ToUpper();
		            	txtbx_jr_lot_no4.Text = null;
						//MessageBox.Show("Error - Packing Check JR Lot No \nCannot find JR Lot No!");
						return;
					}
					else
					{
						txtbx_jr_lot_no_img4.Text = "✓";
	            		txtbx_jr_lot_no_img4.ForeColor = Color.Green;					
	            		txtbx_jr_lot_no4.Text = txtbx_jrlotno4.Text.ToUpper();
	            		
	            		jr_shipmark4 	= txtbx_jrlotno1.Text.ToUpper();
						//jr_lot_no 		= string.Empty;
						jr_ref_no4 		= txtbx_ref_no.Text;
						jr_color4 		= txtbx_color.Text;
						jr_barcode4 		= txtbx_jr_lot_no4.Text;
						jr_stockcode4	= txtbx_jr_lot_no4.Text;
						jr_micron4 		= txtbx_mic.Text;
						jr_width4		= "0";
						jr_length4 		= "0";
					}
				}
			} 
			catch (Exception ex) 
			{
				MessageBox.Show("Error - Packing Check JR Lot No \nCannot load DB!" + ex.Message + ex.ToString());
				txtbx_jr_lot_no_img4.Text = null;				
		        txtbx_jr_lot_no4.Text = null;
				return;
			} 
			finally 
			{
				con_SP3.Close();
			}
			
			con_SP3.Dispose();
			con_SP3 = null;
			cmd_SP3 = null;
		}
		
		public void CheckAvailableQty4()
		{
			SqlConnection con = new SqlConnection(sqlconnStaging);
			SqlCommand cmd = new SqlCommand();
				
			try 
			{
				cmd.CommandText = "select top 1 * from VIEW_AXERP_QOH_ATTRIBUTE_FULLINFO_PM04 where INVENTBATCHID like @ship_mark +'%' or grade = @ship_mark +'%'";
				cmd.Parameters.AddWithValue("@ship_mark",  jr_shipmark4);
				//cmd.Parameters.AddWithValue("@stock_code",  txtbx_prod_code.Text.ToUpper());
				cmd.Connection = con;
				con.Open();
				SqlDataReader rd = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
					
				if (rd.HasRows)
				{
					while (rd.Read())
					{					        								
						jr_shipmark4 		= rd["INVENTBATCHID"].ToString();
						//jr_lot_no 			= rd["LOTNO"].ToString();
						jr_ref_no4			= rd["Grade"].ToString();
						jr_micron4 			= rd["Micron"].ToString();
						jr_color4 			= rd["Color"].ToString();
						jr_barcode4 			= rd["Grade"].ToString();
						jr_stockcode4 		= rd["ITEMID"].ToString();							
						jr_width4 			= rd["Width"].ToString();
						shipmark_ori_length4 = Convert.ToInt32(rd["LLength"]);
						//jr_length 			= rd["LLength"].ToString();							
						
						get_qty4 = Convert.ToDouble(rd["AVAILPHYSICAL"].ToString());
						qty_realmetre4 = Convert.ToDouble((double) get_qty4 / (double) Convert.ToDouble(jr_width4) * 4000);
						
						jr_length4 = qty_realmetre4.ToString();
						
						//MessageBox.Show("3 - "+jr_shipmark4.ToString());
															
					} 
				}
				else 
				{
					jr_shipmark4 	= string.Empty;
					//jr_lot_no4 		= string.Empty;
					jr_ref_no4 		= string.Empty;
					//txtbx_mic.Text 	= string.Empty;
					jr_color4 		= string.Empty;
					jr_barcode4 		= string.Empty;
					jr_stockcode4 	= string.Empty;
					jr_micron4 		= string.Empty;
					jr_width4 		= string.Empty;
					jr_length4 		= string.Empty;
						
					shipmark_ori_length4 = 0;
					
					//MessageBox.Show("Cannot find shipping mark!");
					txtbx_result_4.Text = "Cannot find shipping mark!";
					txtbx_jr_lot_no_img4.Text = "X";
		            txtbx_jr_lot_no_img4.ForeColor = Color.Red;					
		            txtbx_jr_lot_no4.Text = null;	
					return;

				}
			} 
			catch (Exception ex) 
			{
				MessageBox.Show("Error - Packing Check \nCannot load DB!" + ex.Message + ex.ToString());
				txtbx_jr_lot_no_img4.Text = null;				
		        txtbx_jr_lot_no4.Text = null;	
				return;
			} 
			finally 
			{
				con.Close();
			}
				
			con.Dispose();
			con = null;
			cmd = null;
			

		}
		
		
		//-------------------- JR 5--------------------------------------------------------
		
		public void CheckDuplicateJR5()
		{			
			SqlConnection con_Check_Duplicate_JO = new SqlConnection(sqlconn);
			SqlCommand cmd_Check_Duplicate_JO = new SqlCommand();
				
			try 
			{
				cmd_Check_Duplicate_JO.CommandText = @"select * from VIEW_PROD_CONV_JO_SLITTING_JR where PROD_JRSHIPMARK like @ship_mark + '%'";// + "' and JODOCNO <> 'SMSO555608'";
				cmd_Check_Duplicate_JO.Parameters.AddWithValue("@ship_mark",  jr_shipmark5);
					
				cmd_Check_Duplicate_JO.Connection = con_Check_Duplicate_JO;
				con_Check_Duplicate_JO.Open();
				SqlDataReader rd_Check_Duplicate_JO = cmd_Check_Duplicate_JO.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
	
				if (rd_Check_Duplicate_JO.HasRows)
				{
					if (rd_Check_Duplicate_JO.Read())
					{
						double jr_consume5 = 0;
						
						//isDuplicate = true;
						//jr_shipmark 		= rd_Check_Duplicate_JO["PROD_JRSHIPMARK"].ToString();
						//jr_lot_no 			= rd_Check_Duplicate_JO["PROD_LOTNO"].ToString();
						jr_ref_no5 			= rd_Check_Duplicate_JO["PROD_JRBARCODE"].ToString();
						jr_micron5 			= rd_Check_Duplicate_JO["PROD_MICRON"].ToString();
						jr_color5 			= rd_Check_Duplicate_JO["PROD_COLOR"].ToString();
						jr_barcode5 			= rd_Check_Duplicate_JO["PROD_JRBARCODE"].ToString();
						jr_stockcode5 		= rd_Check_Duplicate_JO["PROD_STOCKCODE"].ToString();
							
						jr_width5 			= rd_Check_Duplicate_JO["PROD_WIDTH"].ToString();
						shipmark_ori_length5 = Convert.ToInt32(rd_Check_Duplicate_JO["PROD_LENGTH"]);
						
						jr_width5			= Convert.ToString(rd_Check_Duplicate_JO["PROD_WIDTH"]);
						
						jr_consume5			= Convert.ToDouble(rd_Check_Duplicate_JO["PROD_CONSUME_TOTAL"]);
						jr_length5 			= ((int)(Convert.ToDouble(shipmark_ori_length5) - Convert.ToDouble(jr_consume5))).ToString();
						
						if(Double.Parse(jr_length5) <= 0) 
						{
							//MessageBox.Show("JR already been consume");
							txtbx_result_5.Text = "JR already been consume";
							txtbx_jr_lot_no_img5.Text = "X";
		            		txtbx_jr_lot_no_img5.ForeColor = Color.Red;					
		            		txtbx_jr_lot_no5.Text = null;							
							return;
						}
						
						//MessageBox.Show("5 - "+jr_shipmark5.ToString());
					}
				}
				else
				{
					CheckAvailableQty5();
				}
			}
			catch (Exception ex)
			{
				con_Check_Duplicate_JO.Close();
				MessageBox.Show("Error - Converting Slitting Shipping Mark Duplicate " + ex.Message + ex.ToString());
				txtbx_jr_lot_no_img5.Text = null;				
		        txtbx_jr_lot_no5.Text = null;
				return;
			} 
			finally 
			{
				con_Check_Duplicate_JO.Close();
			}
				
			con_Check_Duplicate_JO.Dispose();
			cmd_Check_Duplicate_JO.Dispose();
			con_Check_Duplicate_JO = null;
			cmd_Check_Duplicate_JO = null;
			
			
		}
		
		public void CheckJRLotNo5()
		{
			SqlConnection con_SP3 = new SqlConnection(sqlconn);
			SqlCommand cmd_SP3 = new SqlCommand();
			
			try 
			{
				cmd_SP3.CommandText = @"select * from VIEW_CONVERTING_BARCODE where TrxSMQC like @doc_no + '%'";
				cmd_SP3.Parameters.AddWithValue("@doc_no",  txtbx_jrlotno5.Text.ToUpper());
				cmd_SP3.Connection = con_SP3;
				con_SP3.Open();
				SqlDataReader rd_SP3 = cmd_SP3.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
				
				if (rd_SP3.HasRows)
				{
					while (rd_SP3.Read())
					{
						
						txtbx_jr_lot_no_img5.Text = "✓";
		            	txtbx_jr_lot_no_img5.ForeColor = Color.Green;					
		            	txtbx_jr_lot_no5.Text = rd_SP3["TrxSMQC"].ToString().ToUpper();
		            	
		            	jr_shipmark5 = rd_SP3["TrxShipmark"].ToString().ToUpper();
		            	//MessageBox.Show("5 - "+jr_shipmark5.ToString());

						CheckDuplicateJR5();
		            	
					} 
				}
				else 
				{
					CheckJRLotNoRCP5();
				}
			
				
			} 
			catch (Exception ex) 
			{
				MessageBox.Show("Error - Packing Check JR Lot No \nCannot load DB!" + ex.Message + ex.ToString());
				txtbx_jr_lot_no_img5.Text = null;				
		        txtbx_jr_lot_no5.Text = null;
				return;
			} 
			finally 
			{
				con_SP3.Close();
			}
			
			con_SP3.Dispose();
			con_SP3 = null;
			cmd_SP3 = null;
		}
		
		public void CheckJRLotNoRCP5()
		{
			SqlConnection con_SP3 = new SqlConnection(sqlconn);
			SqlCommand cmd_SP3 = new SqlCommand();
			
			try 
			{
				cmd_SP3.CommandText = @"select * from [ax-sql].AX5050StagingDB.dbo.VIEW_AXERP_PDSBATCHATTRIBUTES_FULLINFO where INVENTBATCHID = @doc_no";
				cmd_SP3.Parameters.AddWithValue("@doc_no",  txtbx_jrlotno5.Text.ToUpper());
				cmd_SP3.Connection = con_SP3;
				con_SP3.Open();
				SqlDataReader rd_SP3 = cmd_SP3.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
				
				if (rd_SP3.Read())
				{
					txtbx_jr_lot_no_img5.Text = "✓";
	            	txtbx_jr_lot_no_img5.ForeColor = Color.Green;					
	            	txtbx_jr_lot_no5.Text = rd_SP3["INVENTBATCHID"].ToString().ToUpper();
	            	
	            	CheckAvailableQty5();
				} 
				else 
				{
					if(remark5 == "SLITTING")
					{
						txtbx_jr_lot_no_img5.Text = "X";
		            	txtbx_jr_lot_no_img5.ForeColor = Color.Red;
		            	//txtbx_jr_lot_no.Text = txtbx_jrlotno.Text.ToUpper();
		            	txtbx_jr_lot_no5.Text = null;
						//MessageBox.Show("Error - Packing Check JR Lot No \nCannot find JR Lot No!");
						return;
					}
					else
					{
						txtbx_jr_lot_no_img5.Text = "✓";
	            		txtbx_jr_lot_no_img5.ForeColor = Color.Green;					
	            		txtbx_jr_lot_no5.Text = txtbx_jrlotno5.Text.ToUpper();
	            		
	            		jr_shipmark5 	= txtbx_jrlotno1.Text.ToUpper();
						//jr_lot_no 		= string.Empty;
						jr_ref_no5 		= txtbx_ref_no.Text;
						jr_color5 		= txtbx_color.Text;
						jr_barcode5 		= txtbx_jr_lot_no5.Text;
						jr_stockcode5	= txtbx_jr_lot_no5.Text;
						jr_micron5 		= txtbx_mic.Text;
						jr_width5		= "0";
						jr_length5 		= "0";
					}
				}
			} 
			catch (Exception ex) 
			{
				MessageBox.Show("Error - Packing Check JR Lot No \nCannot load DB!" + ex.Message + ex.ToString());
				txtbx_jr_lot_no_img5.Text = null;				
		        txtbx_jr_lot_no5.Text = null;
				return;
			} 
			finally 
			{
				con_SP3.Close();
			}
			
			con_SP3.Dispose();
			con_SP3 = null;
			cmd_SP3 = null;
		}
		
		public void CheckAvailableQty5()
		{
			SqlConnection con = new SqlConnection(sqlconnStaging);
			SqlCommand cmd = new SqlCommand();
				
			try 
			{
				cmd.CommandText = "select top 1 * from VIEW_AXERP_QOH_ATTRIBUTE_FULLINFO_PM05 where INVENTBATCHID like @ship_mark +'%' or grade = @ship_mark +'%'";
				cmd.Parameters.AddWithValue("@ship_mark",  jr_shipmark5);
				//cmd.Parameters.AddWithValue("@stock_code",  txtbx_prod_code.Text.ToUpper());
				cmd.Connection = con;
				con.Open();
				SqlDataReader rd = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
					
				if (rd.HasRows)
				{
					while (rd.Read())
					{					        								
						jr_shipmark5 		= rd["INVENTBATCHID"].ToString();
						//jr_lot_no 			= rd["LOTNO"].ToString();
						jr_ref_no5			= rd["Grade"].ToString();
						jr_micron5 			= rd["Micron"].ToString();
						jr_color5 			= rd["Color"].ToString();
						jr_barcode5 			= rd["Grade"].ToString();
						jr_stockcode5 		= rd["ITEMID"].ToString();							
						jr_width5 			= rd["Width"].ToString();
						shipmark_ori_length5 = Convert.ToInt32(rd["LLength"]);
						//jr_length 			= rd["LLength"].ToString();							
						
						get_qty5 = Convert.ToDouble(rd["AVAILPHYSICAL"].ToString());
						qty_realmetre5 = Convert.ToDouble((double) get_qty5 / (double) Convert.ToDouble(jr_width5) * 5000);
						
						jr_length5 = qty_realmetre5.ToString();
						
						//MessageBox.Show("3 - "+jr_shipmark5.ToString());
															
					} 
				}
				else 
				{
					jr_shipmark5 	= string.Empty;
					//jr_lot_no5 		= string.Empty;
					jr_ref_no5 		= string.Empty;
					//txtbx_mic.Text 	= string.Empty;
					jr_color5 		= string.Empty;
					jr_barcode5 		= string.Empty;
					jr_stockcode5 	= string.Empty;
					jr_micron5 		= string.Empty;
					jr_width5 		= string.Empty;
					jr_length5 		= string.Empty;
						
					shipmark_ori_length5 = 0;
					
					//MessageBox.Show("Cannot find shipping mark!");
					txtbx_result_5.Text = "Cannot find shipping mark!";
					txtbx_jr_lot_no_img5.Text = "X";
		            txtbx_jr_lot_no_img5.ForeColor = Color.Red;					
		            txtbx_jr_lot_no5.Text = null;	
					return;

				}
			} 
			catch (Exception ex) 
			{
				MessageBox.Show("Error - Packing Check \nCannot load DB!" + ex.Message + ex.ToString());
				txtbx_jr_lot_no_img5.Text = null;				
		        txtbx_jr_lot_no5.Text = null;	
				return;
			} 
			finally 
			{
				con.Close();
			}
				
			con.Dispose();
			con = null;
			cmd = null;
		}
			
		
		
		
		bool PreCheck(string jr)
		{
			SqlConnection con_search = new SqlConnection(sqlconn);
			SqlCommand cmd_seach = new SqlCommand();
				
			try 
			{
				//cmd_seach.CommandText = @"SELECT * FROM TBL_PROD_CONV_JO_SLITTING where PROD_DOCNO = @doc_no";
				cmd_seach.CommandText = @"SELECT * FROM VIEW_PROD_CONV_JO_SLITTING_3 where PROD_DOCNO = @doc_no and TrxSMQC = @jr";
				cmd_seach.Parameters.AddWithValue("@doc_no",  txtbx_ref_no.Text.ToUpper());
				cmd_seach.Parameters.AddWithValue("@jr",  jr);
				cmd_seach.Connection = con_search;
				con_search.Open();
				SqlDataReader dr_search = cmd_seach.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
					
				if(dr_search.HasRows)
				{
					if (dr_search.Read())
					{				
	//					txtbx_prod_code.Text = dr_search["JOSTOCKCODE"].ToString();	
	//					remark5 = dr_search["JOPRODREMARK5"].ToString();	
							
					} 
					return true;
				}			
				else 
				{
					MessageBox.Show("No match for Slitting output. Please key in slitting first");
					return false;
				}
			} 
			catch (Exception ex) 
			{
				MessageBox.Show("Error PreCheck: Cannot load DB!" + ex.Message + ex.ToString());
				return false;
			} 
			finally 
			{
				con_search.Close();
			}
			
			con_search.Dispose();
			cmd_seach = null;
			
			
		}
		
		
	}
}