/*
 * Created by SharpDevelop.
 * User: faeiz
 * Date: 2018-01-08
 * Time: 11:09 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
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
using System.Linq;
namespace AX2020
{
	/// <summary>
	/// Description of frm_prod_coverting_output_rewinding_chec__bal.
	/// </summary>
	public partial class frm_prod_coverting_output_rewinding_check_bal : Form
	{
		public static string sqlconn = "Server=AX-UAT; Password=sbax2020sbg; User ID=sbax2020; Initial Catalog=SBG_AX_2020; Integrated Security=false";
	  string ship_mark_code;
	  string PROD_JONO;
      int PROD_LINENO;
      string PROD_SHIPMARK;
      double PROD_MICRON;
      double PROD_WIDTH;
      double PROD_LENGTH;
      string PROD_STOCKCODE;
      string PROD_COLOR;
      string PROD_BRAND;
      string PROD_LOTNO;
      string PROD_JRSHIPMARK;
      string PROD_JRBARCODE;
      double PROD_CONSUME;
      double PROD_BALANCE;
      string PROD_ISSUEBY;
      string PROD_USER;
      string PROD_USEREMAIL;
      string PROD_USERPC;
      DateTime PROD_USERDATETIME;
      string PROD_USERREVISION;
      string PROD_REMARK;
            
      
  
	  double last_type_bal;
		public frm_prod_coverting_output_rewinding_check_bal()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			ship_mark_code = frm_prod_converting_output_rewinding_r4.ship_mark;
			last_type_bal = frm_prod_conv_output_rewinding_popup_yesno.type_balance2;
			
	
			
			
			
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		
		void retrieve_data()
		{
			
		}
		void Btn_closeClick(object sender, EventArgs e)
		{
			this.Close();
		}
		
		void insert_data_to_table()
		{
			
		}
		
		void Btn_balClick(object sender, EventArgs e)
		{
			
			MessageBox.Show("ship mark bak =" + ship_mark_code.ToString());
			SqlConnection con_SP1 = new SqlConnection(sqlconn);
			SqlCommand cmd_SP1 = new SqlCommand();
			
			try 
			{
				cmd_SP1.CommandText = "select * from TBL_PROD_CONV_JO_REWINDING_SHIPMARK_R1 where PROD_SHIPMARK = '" + ship_mark_code + "'";
				cmd_SP1.Connection = con_SP1;
				con_SP1.Open();
				SqlDataReader rd_SP1 = cmd_SP1.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
				
				if (rd_SP1.Read())
				{
				
						
					PROD_JONO = rd_SP1["PROD_JONO"].ToString();
					MessageBox.Show(PROD_JONO.ToString());
					PROD_LINENO = Convert.ToInt32(rd_SP1["PROD_LINENO"]);
					PROD_SHIPMARK =  rd_SP1["PROD_SHIPMARK"].ToString();
					PROD_MICRON = Convert.ToDouble(rd_SP1["PROD_MICRON"]);
					MessageBox.Show("micron" + PROD_MICRON.ToString());
					PROD_WIDTH = Convert.ToDouble(rd_SP1["PROD_WIDTH"]);
					PROD_LENGTH = Convert.ToDouble(rd_SP1["PROD_LENGTH"]);
					PROD_STOCKCODE = rd_SP1["PROD_STOCKCODE"].ToString();
					PROD_COLOR = rd_SP1["PROD_COLOR"].ToString();
					PROD_BRAND = rd_SP1["PROD_BRAND"].ToString();
					PROD_LOTNO = rd_SP1["PROD_LOTNO"].ToString();
					PROD_JRSHIPMARK = rd_SP1["PROD_JRSHIPMARK"].ToString();
					PROD_JRBARCODE = rd_SP1["PROD_JRBARCODE"].ToString();
					PROD_CONSUME = Convert.ToDouble(rd_SP1["PROD_CONSUME"]);
					PROD_BALANCE = Convert.ToDouble(rd_SP1["PROD_BALANCE"]);
					PROD_ISSUEBY = rd_SP1["PROD_ISSUEBY"].ToString();
					PROD_USER = rd_SP1["PROD_USER"].ToString();
					PROD_USEREMAIL = rd_SP1["PROD_USEREMAIL"].ToString();
					PROD_USERPC = rd_SP1["PROD_USERPC"].ToString();
					PROD_USERDATETIME = Convert.ToDateTime(rd_SP1["PROD_USERDATETIME"]);
					MessageBox.Show(PROD_USERDATETIME.ToString());
					PROD_USERREVISION = rd_SP1["PROD_USERREVISION"].ToString();
					
					
					
					
						
					
//--------------------------------------------------------------------------------------------			
				} 
				else 
				{
					MessageBox.Show("Error Edit : Cannot find SHIP MARK!");
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
			
			
			
			SqlConnection con_data_add = new SqlConnection(sqlconn);
			System.Data.SqlClient.SqlCommand cmd_data_add = new SqlCommand(); 
			try 
			{
				cmd_data_add.Connection = con_data_add;		
				cmd_data_add.CommandText = "SP_PROD_CONV_JO_SLITTING_SHIPMARK_CHECK_TYPE_BAL";
				cmd_data_add.CommandType = CommandType.StoredProcedure;	
							
				cmd_data_add.Parameters.Add(new SqlParameter("@SP_PROD_JONO", SqlDbType. NVarChar, 50)); 
				cmd_data_add.Parameters["@SP_PROD_JONO"].Value = PROD_JONO;
				
				cmd_data_add.Parameters.Add(new SqlParameter("@SP_PROD_LINENO", SqlDbType. Int)); 
				cmd_data_add.Parameters["@SP_PROD_LINENO"].Value = Convert.ToInt32(PROD_LINENO);
				
				
				cmd_data_add.Parameters.Add(new SqlParameter("@SP_PROD_SHIPMARK", SqlDbType. NVarChar, 50)); //create parameter pada sql bwk data SP_RefNumber untuk dihantar semula
				cmd_data_add.Parameters["@SP_PROD_SHIPMARK"].Value = PROD_SHIPMARK;
						
				cmd_data_add.Parameters.Add(new SqlParameter("@SP_PROD_MICRON", SqlDbType. Float));
				cmd_data_add.Parameters["@SP_PROD_MICRON"].Value = PROD_MICRON;
						
				cmd_data_add.Parameters.Add(new SqlParameter("@SP_PROD_WIDTH", SqlDbType.Float));
				cmd_data_add.Parameters["@SP_PROD_WIDTH"].Value = PROD_WIDTH;
						
				cmd_data_add.Parameters.Add(new SqlParameter("@SP_PROD_LENGTH", SqlDbType.Float));
				cmd_data_add.Parameters["@SP_PROD_LENGTH"].Value= PROD_LENGTH;  //tukar daripada string kepada nombor
						
				cmd_data_add.Parameters.Add(new SqlParameter("@SP_PROD_STOCKCODE", SqlDbType.VarChar, 50));
				cmd_data_add.Parameters["@SP_PROD_STOCKCODE"].Value = PROD_STOCKCODE;  //tukar daripada string kepada nom
						
				
						
				cmd_data_add.Parameters.Add(new SqlParameter("@SP_PROD_COLOR", SqlDbType.VarChar, 50));
				cmd_data_add.Parameters["@SP_PROD_COLOR"].Value= PROD_COLOR;
				
				cmd_data_add.Parameters.Add(new SqlParameter("@SP_PROD_BRAND", SqlDbType.VarChar, 50));
				cmd_data_add.Parameters["@SP_PROD_BRAND"].Value = PROD_BRAND;
				
				cmd_data_add.Parameters.Add(new SqlParameter("@SP_PROD_LOTNO", SqlDbType.VarChar, 50));
				cmd_data_add.Parameters["@SP_PROD_LOTNO"].Value = PROD_LOTNO;
				
				cmd_data_add.Parameters.Add(new SqlParameter("@SP_PROD_JRSHIPMARK", SqlDbType.VarChar, 50));
				cmd_data_add.Parameters["@SP_PROD_JRSHIPMARK"].Value = PROD_JRSHIPMARK;
				
				
				cmd_data_add.Parameters.Add(new SqlParameter("@SP_PROD_JRBARCODE", SqlDbType.VarChar, 50));
				cmd_data_add.Parameters["@SP_PROD_JRBARCODE"].Value = PROD_JRBARCODE;
				
				
				cmd_data_add.Parameters.Add(new SqlParameter("@SP_PROD_CONSUME", SqlDbType.Float));
				cmd_data_add.Parameters["@SP_PROD_CONSUME"].Value = PROD_CONSUME;
				
				cmd_data_add.Parameters.Add(new SqlParameter("@SP_PROD_BALANCE", SqlDbType.Float));
				cmd_data_add.Parameters["@SP_PROD_BALANCE"].Value = PROD_BALANCE;
				
				
				cmd_data_add.Parameters.Add(new SqlParameter("@SP_PROD_ISSUEBY", SqlDbType.NVarChar, 50));
				cmd_data_add.Parameters["@SP_PROD_ISSUEBY"].Value = PROD_ISSUEBY;
				
				cmd_data_add.Parameters.Add(new SqlParameter("@SP_PROD_USER", SqlDbType.NVarChar, 50));
				cmd_data_add.Parameters["@SP_PROD_USER"].Value = PROD_USER;
				
				
				cmd_data_add.Parameters.Add(new SqlParameter("@SP_PROD_USEREMAIL", SqlDbType.NVarChar, 50));
				cmd_data_add.Parameters["@SP_PROD_USEREMAIL"].Value = PROD_USEREMAIL;
				
				cmd_data_add.Parameters.Add(new SqlParameter("@SP_PROD_USERPC", SqlDbType.NVarChar, 50));
				cmd_data_add.Parameters["@SP_PROD_USERPC"].Value = PROD_USERPC;
				
				cmd_data_add.Parameters.Add(new SqlParameter("@SP_PROD_USERDATETIME", SqlDbType.DateTime));
				cmd_data_add.Parameters["@SP_PROD_USERDATETIME"].Value = PROD_USERDATETIME;
				
				cmd_data_add.Parameters.Add(new SqlParameter("@SP_PROD_USERREVISION", SqlDbType.NVarChar, 50));
				cmd_data_add.Parameters["@SP_PROD_USERREVISION"].Value = PROD_USERREVISION;
				
				
				PROD_REMARK = "BALANCE";
				cmd_data_add.Parameters.Add(new SqlParameter("@SP_PROD_REMARK", SqlDbType.NVarChar, 50));
				cmd_data_add.Parameters["@SP_PROD_REMARK"].Value = PROD_REMARK;
				
				
				
				

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
			con_data_add = null;

		}
		
		
	
		void Btn_wastageClick(object sender, EventArgs e)
		{
			MessageBox.Show("ship mark bak =" + ship_mark_code.ToString());
			SqlConnection con_SP1 = new SqlConnection(sqlconn);
			SqlCommand cmd_SP1 = new SqlCommand();
			
			try 
			{
				cmd_SP1.CommandText = "select * from TBL_PROD_CONV_JO_REWINDING_SHIPMARK_R1 where PROD_SHIPMARK = '" + ship_mark_code + "'";
				cmd_SP1.Connection = con_SP1;
				con_SP1.Open();
				SqlDataReader rd_SP1 = cmd_SP1.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
				
				if (rd_SP1.Read())
				{
				
						
					PROD_JONO = rd_SP1["PROD_JONO"].ToString();
					MessageBox.Show(PROD_JONO.ToString());
					PROD_LINENO = Convert.ToInt32(rd_SP1["PROD_LINENO"]);
					PROD_SHIPMARK =  rd_SP1["PROD_SHIPMARK"].ToString();
					PROD_MICRON = Convert.ToDouble(rd_SP1["PROD_MICRON"]);
					MessageBox.Show("micron" + PROD_MICRON.ToString());
					PROD_WIDTH = Convert.ToDouble(rd_SP1["PROD_WIDTH"]);
					PROD_LENGTH = Convert.ToDouble(rd_SP1["PROD_LENGTH"]);
					PROD_STOCKCODE = rd_SP1["PROD_STOCKCODE"].ToString();
					PROD_COLOR = rd_SP1["PROD_COLOR"].ToString();
					PROD_BRAND = rd_SP1["PROD_BRAND"].ToString();
					PROD_LOTNO = rd_SP1["PROD_LOTNO"].ToString();
					PROD_JRSHIPMARK = rd_SP1["PROD_JRSHIPMARK"].ToString();
					PROD_JRBARCODE = rd_SP1["PROD_JRBARCODE"].ToString();
					PROD_CONSUME = Convert.ToDouble(rd_SP1["PROD_CONSUME"]);
					PROD_BALANCE = Convert.ToDouble(rd_SP1["PROD_BALANCE"]);
					PROD_ISSUEBY = rd_SP1["PROD_ISSUEBY"].ToString();
					PROD_USER = rd_SP1["PROD_USER"].ToString();
					PROD_USEREMAIL = rd_SP1["PROD_USEREMAIL"].ToString();
					PROD_USERPC = rd_SP1["PROD_USERPC"].ToString();
					PROD_USERDATETIME = Convert.ToDateTime(rd_SP1["PROD_USERDATETIME"]);
					MessageBox.Show(PROD_USERDATETIME.ToString());
					PROD_USERREVISION = rd_SP1["PROD_USERREVISION"].ToString();
					
					
					
					
						
					
//--------------------------------------------------------------------------------------------			
				} 
				else 
				{
					MessageBox.Show("Error Edit : Cannot find SHIP MARK!");
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
			
			
			
			SqlConnection con_data_add = new SqlConnection(sqlconn);
			System.Data.SqlClient.SqlCommand cmd_data_add = new SqlCommand(); 
			try 
			{
				cmd_data_add.Connection = con_data_add;		
				cmd_data_add.CommandText = "SP_PROD_CONV_JO_SLITTING_SHIPMARK_CHECK_TYPE_BAL";
				cmd_data_add.CommandType = CommandType.StoredProcedure;	
							
				cmd_data_add.Parameters.Add(new SqlParameter("@SP_PROD_JONO", SqlDbType. NVarChar, 50)); 
				cmd_data_add.Parameters["@SP_PROD_JONO"].Value = PROD_JONO;
				
				cmd_data_add.Parameters.Add(new SqlParameter("@SP_PROD_LINENO", SqlDbType. Int)); 
				cmd_data_add.Parameters["@SP_PROD_LINENO"].Value = Convert.ToInt32(PROD_LINENO);
				
				
				cmd_data_add.Parameters.Add(new SqlParameter("@SP_PROD_SHIPMARK", SqlDbType. NVarChar, 50)); //create parameter pada sql bwk data SP_RefNumber untuk dihantar semula
				cmd_data_add.Parameters["@SP_PROD_SHIPMARK"].Value = PROD_SHIPMARK;
						
				cmd_data_add.Parameters.Add(new SqlParameter("@SP_PROD_MICRON", SqlDbType. Float));
				cmd_data_add.Parameters["@SP_PROD_MICRON"].Value = PROD_MICRON;
						
				cmd_data_add.Parameters.Add(new SqlParameter("@SP_PROD_WIDTH", SqlDbType.Float));
				cmd_data_add.Parameters["@SP_PROD_WIDTH"].Value = PROD_WIDTH;
						
				cmd_data_add.Parameters.Add(new SqlParameter("@SP_PROD_LENGTH", SqlDbType.Float));
				cmd_data_add.Parameters["@SP_PROD_LENGTH"].Value= PROD_LENGTH;  //tukar daripada string kepada nombor
						
				cmd_data_add.Parameters.Add(new SqlParameter("@SP_PROD_STOCKCODE", SqlDbType.VarChar, 50));
				cmd_data_add.Parameters["@SP_PROD_STOCKCODE"].Value = PROD_STOCKCODE;  //tukar daripada string kepada nom
						
				
						
				cmd_data_add.Parameters.Add(new SqlParameter("@SP_PROD_COLOR", SqlDbType.VarChar, 50));
				cmd_data_add.Parameters["@SP_PROD_COLOR"].Value= PROD_COLOR;
				
				cmd_data_add.Parameters.Add(new SqlParameter("@SP_PROD_BRAND", SqlDbType.VarChar, 50));
				cmd_data_add.Parameters["@SP_PROD_BRAND"].Value = PROD_BRAND;
				
				cmd_data_add.Parameters.Add(new SqlParameter("@SP_PROD_LOTNO", SqlDbType.VarChar, 50));
				cmd_data_add.Parameters["@SP_PROD_LOTNO"].Value = PROD_LOTNO;
				
				cmd_data_add.Parameters.Add(new SqlParameter("@SP_PROD_JRSHIPMARK", SqlDbType.VarChar, 50));
				cmd_data_add.Parameters["@SP_PROD_JRSHIPMARK"].Value = PROD_JRSHIPMARK;
				
				
				cmd_data_add.Parameters.Add(new SqlParameter("@SP_PROD_JRBARCODE", SqlDbType.VarChar, 50));
				cmd_data_add.Parameters["@SP_PROD_JRBARCODE"].Value = PROD_JRBARCODE;
				
				
				cmd_data_add.Parameters.Add(new SqlParameter("@SP_PROD_CONSUME", SqlDbType.Float));
				cmd_data_add.Parameters["@SP_PROD_CONSUME"].Value = PROD_CONSUME;
				
				cmd_data_add.Parameters.Add(new SqlParameter("@SP_PROD_BALANCE", SqlDbType.Float));
				cmd_data_add.Parameters["@SP_PROD_BALANCE"].Value = PROD_BALANCE;
				
				
				cmd_data_add.Parameters.Add(new SqlParameter("@SP_PROD_ISSUEBY", SqlDbType.NVarChar, 50));
				cmd_data_add.Parameters["@SP_PROD_ISSUEBY"].Value = PROD_ISSUEBY;
				
				cmd_data_add.Parameters.Add(new SqlParameter("@SP_PROD_USER", SqlDbType.NVarChar, 50));
				cmd_data_add.Parameters["@SP_PROD_USER"].Value = PROD_USER;
				
				
				cmd_data_add.Parameters.Add(new SqlParameter("@SP_PROD_USEREMAIL", SqlDbType.NVarChar, 50));
				cmd_data_add.Parameters["@SP_PROD_USEREMAIL"].Value = PROD_USEREMAIL;
				
				cmd_data_add.Parameters.Add(new SqlParameter("@SP_PROD_USERPC", SqlDbType.NVarChar, 50));
				cmd_data_add.Parameters["@SP_PROD_USERPC"].Value = PROD_USERPC;
				
				cmd_data_add.Parameters.Add(new SqlParameter("@SP_PROD_USERDATETIME", SqlDbType.DateTime));
				cmd_data_add.Parameters["@SP_PROD_USERDATETIME"].Value = PROD_USERDATETIME;
				
				cmd_data_add.Parameters.Add(new SqlParameter("@SP_PROD_USERREVISION", SqlDbType.NVarChar, 50));
				cmd_data_add.Parameters["@SP_PROD_USERREVISION"].Value = PROD_USERREVISION;
				
				
				PROD_REMARK = "WASTAGE";
				cmd_data_add.Parameters.Add(new SqlParameter("@SP_PROD_REMARK", SqlDbType.NVarChar, 50));
				cmd_data_add.Parameters["@SP_PROD_REMARK"].Value = PROD_REMARK;
				
				
				
				

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
			con_data_add = null;
			
		}
		
		void Btn_shortlineClick(object sender, EventArgs e)
		{
			MessageBox.Show("ship mark bak =" + ship_mark_code.ToString());
			SqlConnection con_SP1 = new SqlConnection(sqlconn);
			SqlCommand cmd_SP1 = new SqlCommand();
			
			try 
			{
				cmd_SP1.CommandText = "select * from TBL_PROD_CONV_JO_REWINDING_SHIPMARK_R1 where PROD_SHIPMARK = '" + ship_mark_code + "'";
				cmd_SP1.Connection = con_SP1;
				con_SP1.Open();
				SqlDataReader rd_SP1 = cmd_SP1.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
				
				if (rd_SP1.Read())
				{
				
						
					PROD_JONO = rd_SP1["PROD_JONO"].ToString();
					MessageBox.Show(PROD_JONO.ToString());
					PROD_LINENO = Convert.ToInt32(rd_SP1["PROD_LINENO"]);
					PROD_SHIPMARK =  rd_SP1["PROD_SHIPMARK"].ToString();
					PROD_MICRON = Convert.ToDouble(rd_SP1["PROD_MICRON"]);
					MessageBox.Show("micron" + PROD_MICRON.ToString());
					PROD_WIDTH = Convert.ToDouble(rd_SP1["PROD_WIDTH"]);
					PROD_LENGTH = Convert.ToDouble(rd_SP1["PROD_LENGTH"]);
					PROD_STOCKCODE = rd_SP1["PROD_STOCKCODE"].ToString();
					PROD_COLOR = rd_SP1["PROD_COLOR"].ToString();
					PROD_BRAND = rd_SP1["PROD_BRAND"].ToString();
					PROD_LOTNO = rd_SP1["PROD_LOTNO"].ToString();
					PROD_JRSHIPMARK = rd_SP1["PROD_JRSHIPMARK"].ToString();
					PROD_JRBARCODE = rd_SP1["PROD_JRBARCODE"].ToString();
					PROD_CONSUME = Convert.ToDouble(rd_SP1["PROD_CONSUME"]);
					PROD_BALANCE = Convert.ToDouble(rd_SP1["PROD_BALANCE"]);
					PROD_ISSUEBY = rd_SP1["PROD_ISSUEBY"].ToString();
					PROD_USER = rd_SP1["PROD_USER"].ToString();
					PROD_USEREMAIL = rd_SP1["PROD_USEREMAIL"].ToString();
					PROD_USERPC = rd_SP1["PROD_USERPC"].ToString();
					PROD_USERDATETIME = Convert.ToDateTime(rd_SP1["PROD_USERDATETIME"]);
					MessageBox.Show(PROD_USERDATETIME.ToString());
					PROD_USERREVISION = rd_SP1["PROD_USERREVISION"].ToString();
					
					
					
					
						
					
//--------------------------------------------------------------------------------------------			
				} 
				else 
				{
					MessageBox.Show("Error Edit : Cannot find SHIP MARK!");
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
			
			
			
			SqlConnection con_data_add = new SqlConnection(sqlconn);
			System.Data.SqlClient.SqlCommand cmd_data_add = new SqlCommand(); 
			try 
			{
				cmd_data_add.Connection = con_data_add;		
				cmd_data_add.CommandText = "SP_PROD_CONV_JO_SLITTING_SHIPMARK_CHECK_TYPE_BAL";
				cmd_data_add.CommandType = CommandType.StoredProcedure;	
							
				cmd_data_add.Parameters.Add(new SqlParameter("@SP_PROD_JONO", SqlDbType. NVarChar, 50)); 
				cmd_data_add.Parameters["@SP_PROD_JONO"].Value = PROD_JONO;
				
				cmd_data_add.Parameters.Add(new SqlParameter("@SP_PROD_LINENO", SqlDbType. Int)); 
				cmd_data_add.Parameters["@SP_PROD_LINENO"].Value = Convert.ToInt32(PROD_LINENO);
				
				
				cmd_data_add.Parameters.Add(new SqlParameter("@SP_PROD_SHIPMARK", SqlDbType. NVarChar, 50)); //create parameter pada sql bwk data SP_RefNumber untuk dihantar semula
				cmd_data_add.Parameters["@SP_PROD_SHIPMARK"].Value = PROD_SHIPMARK;
						
				cmd_data_add.Parameters.Add(new SqlParameter("@SP_PROD_MICRON", SqlDbType. Float));
				cmd_data_add.Parameters["@SP_PROD_MICRON"].Value = PROD_MICRON;
						
				cmd_data_add.Parameters.Add(new SqlParameter("@SP_PROD_WIDTH", SqlDbType.Float));
				cmd_data_add.Parameters["@SP_PROD_WIDTH"].Value = PROD_WIDTH;
						
				cmd_data_add.Parameters.Add(new SqlParameter("@SP_PROD_LENGTH", SqlDbType.Float));
				cmd_data_add.Parameters["@SP_PROD_LENGTH"].Value= PROD_LENGTH;  //tukar daripada string kepada nombor
						
				cmd_data_add.Parameters.Add(new SqlParameter("@SP_PROD_STOCKCODE", SqlDbType.VarChar, 50));
				cmd_data_add.Parameters["@SP_PROD_STOCKCODE"].Value = PROD_STOCKCODE;  //tukar daripada string kepada nom
						
				
						
				cmd_data_add.Parameters.Add(new SqlParameter("@SP_PROD_COLOR", SqlDbType.VarChar, 50));
				cmd_data_add.Parameters["@SP_PROD_COLOR"].Value= PROD_COLOR;
				
				cmd_data_add.Parameters.Add(new SqlParameter("@SP_PROD_BRAND", SqlDbType.VarChar, 50));
				cmd_data_add.Parameters["@SP_PROD_BRAND"].Value = PROD_BRAND;
				
				cmd_data_add.Parameters.Add(new SqlParameter("@SP_PROD_LOTNO", SqlDbType.VarChar, 50));
				cmd_data_add.Parameters["@SP_PROD_LOTNO"].Value = PROD_LOTNO;
				
				cmd_data_add.Parameters.Add(new SqlParameter("@SP_PROD_JRSHIPMARK", SqlDbType.VarChar, 50));
				cmd_data_add.Parameters["@SP_PROD_JRSHIPMARK"].Value = PROD_JRSHIPMARK;
				
				
				cmd_data_add.Parameters.Add(new SqlParameter("@SP_PROD_JRBARCODE", SqlDbType.VarChar, 50));
				cmd_data_add.Parameters["@SP_PROD_JRBARCODE"].Value = PROD_JRBARCODE;
				
				
				cmd_data_add.Parameters.Add(new SqlParameter("@SP_PROD_CONSUME", SqlDbType.Float));
				cmd_data_add.Parameters["@SP_PROD_CONSUME"].Value = PROD_CONSUME;
				
				cmd_data_add.Parameters.Add(new SqlParameter("@SP_PROD_BALANCE", SqlDbType.Float));
				cmd_data_add.Parameters["@SP_PROD_BALANCE"].Value = PROD_BALANCE;
				
				
				cmd_data_add.Parameters.Add(new SqlParameter("@SP_PROD_ISSUEBY", SqlDbType.NVarChar, 50));
				cmd_data_add.Parameters["@SP_PROD_ISSUEBY"].Value = PROD_ISSUEBY;
				
				cmd_data_add.Parameters.Add(new SqlParameter("@SP_PROD_USER", SqlDbType.NVarChar, 50));
				cmd_data_add.Parameters["@SP_PROD_USER"].Value = PROD_USER;
				
				
				cmd_data_add.Parameters.Add(new SqlParameter("@SP_PROD_USEREMAIL", SqlDbType.NVarChar, 50));
				cmd_data_add.Parameters["@SP_PROD_USEREMAIL"].Value = PROD_USEREMAIL;
				
				cmd_data_add.Parameters.Add(new SqlParameter("@SP_PROD_USERPC", SqlDbType.NVarChar, 50));
				cmd_data_add.Parameters["@SP_PROD_USERPC"].Value = PROD_USERPC;
				
				cmd_data_add.Parameters.Add(new SqlParameter("@SP_PROD_USERDATETIME", SqlDbType.DateTime));
				cmd_data_add.Parameters["@SP_PROD_USERDATETIME"].Value = PROD_USERDATETIME;
				
				cmd_data_add.Parameters.Add(new SqlParameter("@SP_PROD_USERREVISION", SqlDbType.NVarChar, 50));
				cmd_data_add.Parameters["@SP_PROD_USERREVISION"].Value = PROD_USERREVISION;
				
				
				PROD_REMARK = "SHORTLINE";
				cmd_data_add.Parameters.Add(new SqlParameter("@SP_PROD_REMARK", SqlDbType.NVarChar, 50));
				cmd_data_add.Parameters["@SP_PROD_REMARK"].Value = PROD_REMARK;
				
				
				
				

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
			con_data_add = null;
			
		}
	}
}
