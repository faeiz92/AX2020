/*
 * Created by SharpDevelop.
 * User: faeiz
 * Date: 2017-09-12
 * Time: 9:35 AM
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
using System.Linq;
using System.Net;
using System.Net.Mail;

namespace AX2020
{
	/// <summary>
	/// Description of frm_prod_get_CI_NO.
	/// </summary>
	public partial class frm_get_CI_NO : Form
	{
		public static string sqlconn = "Server=AX-UAT; Password=sbax2020sbg; User ID=sbax2020; Initial Catalog=SBG_AX_2020; Integrated Security=false";
		
		public static string sqlconn2 = "Server=AX-UAT; Password=sbax2020sbg; User ID=sbax2020; Initial Catalog=MyProductionTrack; Integrated Security=false";
		
		public static string sqlconn3 = "Server=AX-SQL; Password=ax2020sbgroup; User ID=ax2020sb; Initial Catalog=AX2020StagingDB; Integrated Security=false";
		string CI_NO;
		DateTime User_date = DateTime.Now;
		string	User_Name, username;
		string	IP_Address;
		string	User_Email;
		string	SO_Number, final_nextno;
		public static string SetValueForText1 = "";
		


		
		string CI_NextNo, Customer_Name;
		public frm_get_CI_NO()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			username = frm_menu_system.userName;
			lbl_username.Text = "User : " + username;
			txtbx_so1.Text = "0";
			txtbx_so2.Text = "0";
			txtbx_so3.Text = "0";
			txtbx_so4.Text = "0";
			txtbx_so5.Text = "0";
			txtbx_so6.Text = "0";
			txtbx_so7.Text = "0";
			txtbx_so8.Text = "0";
			txtbx_so9.Text = "0";
			txtbx_so10.Text = "0";
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		

		 void Btn_generateClick(object sender, EventArgs e)
		{
		 	
		 	
			
			//int Ci_No_Start = 0000000;
			
	
//			SqlConnection con_Check_Jodoc_Printing = new SqlConnection(sqlconn3);
//			SqlCommand cmd2 = new SqlCommand();
//								
//								
//								
//					try {
//							cmd2.CommandText = "select * from VIEW_AXERP_SO_DETAIL where SALESID = '" + txtbx_so1.Text.ToUpper() +  "' or SALESID ='" + txtbx_so2.Text.ToUpper() +  "'or SALESID ='" + txtbx_so3.Text.ToUpper() +  "' or SALESID ='" + txtbx_so4.Text.ToUpper() +  "'or SALESID ='" + txtbx_so5.Text.ToUpper() +  "'or SALESID ='" + txtbx_so6.Text.ToUpper() +  "'or SALESID ='" + txtbx_so7.Text.ToUpper() +  "'or SALESID ='" + txtbx_so8.Text.ToUpper() +  "'or SALESID ='" + txtbx_so9.Text.ToUpper() +  "'or SALESID ='" + txtbx_so10.Text.ToUpper() +  "'";
//							cmd2.Connection = con_Check_Jodoc_Printing;
//							con_Check_Jodoc_Printing.Open();
//							SqlDataReader rd_Check_Jodoc_Printing = cmd2.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
//					
//
//											if (!rd_Check_Jodoc_Printing.HasRows) 
//												{
//												MessageBox.Show("CAN'T SAVE,SALES ORDER NUMBERS NOT EXIST");//Lbl_Message.Text = "Error 1.0 : Duplicate JO! ";
//													return;
//												}
//											
//											
//											
//									//	}
//								
////								else
////												
////									{
////										DialogBox.ShowWarningMessage("CAN'T SAVE, JOB ORDER NUMBERS PRINTING ARE NOT EXIST");//Lbl_Message.Text = "Error 1.0 : Duplicate JO! ";	
////										return;
////									}
//								
//									} 
//								catch (Exception ex) 
//								{
//									con_Check_Jodoc_Printing.Close();
//									MessageBox.Show("Error 2.0 : Duplicate JO!" + ex.ToString() + ex.Message);
//									return;
//								} 
//					
//								finally 
//								{
//									con_Check_Jodoc_Printing.Close();
//								}
//								
//								con_Check_Jodoc_Printing.Dispose();
//								cmd2.Dispose();
//								con_Check_Jodoc_Printing = null;
//								cmd2 = null;
			NextNumberRetrieve();
			
			final_nextno = "CI" + 0000 + CI_NextNo;
			
			
			
			
			//SqlConnection con_Check_Jodoc_Printing = new SqlConnection(sqlconn);
			
			using (SqlConnection cmd = new SqlConnection(sqlconn))
			{
				cmd.Open();
			
			
			
			try{
				
				
	
		for (int i =0;i<10;i++)
		

		{
			
			//retrieve_cust_name();
			
			//CI_NextNo = "0000" + CI_NextNo;

			
			SqlCommand cmd_command = new SqlCommand("INSERT INTO TBL_PROD_CI_NUMBER (Prod_CI_Next_No,CI_NO,Customer_Name,User_date,User_Name,IP_Address,User_Email,SO_Number) VALUES (@Prod_CI_Next_No,@CI_NO,@Customer_Name,@User_date,@User_Name,@IP_Address,@User_Email,@SO_Number)",cmd);

			cmd_command.Parameters.AddWithValue("@Prod_CI_Next_No", int.Parse(CI_NextNo.ToString()));
			cmd_command.Parameters.AddWithValue("@CI_NO", (final_nextno).ToString());
			cmd_command.Parameters.AddWithValue("@User_date", User_date.Date);
			cmd_command.Parameters.AddWithValue("@User_Name", lbl_username.Text);
			cmd_command.Parameters.AddWithValue("@IP_Address", frm_menu_system.ipAddress.ToString().ToUpper());
			cmd_command.Parameters.AddWithValue("@User_Email", frm_menu_system.email.ToString().ToUpper());
			
			
			if(i<=0)
			{
				
				if (txtbx_so1.Text.ToUpper().Substring(0,1) == "S")
				{
				cmd_command.Parameters.AddWithValue("@SO_Number", txtbx_so1.Text.ToUpper());
				retrieve_cust_name1();
				cmd_command.Parameters.AddWithValue("@Customer_Name", Customer_Name.ToString());
				}
				
				else //if (txtbx_so1.Text != "SBSD")
				{
					cmd_command.Parameters.AddWithValue("@SO_Number", txtbx_so1.Text = "0");
					cmd_command.Parameters.AddWithValue("@Customer_Name", Customer_Name = "0");

				}
					

			}
			else if (i<=1)
			{
				
				if (txtbx_so2.Text.ToUpper().Substring(0,1) == "S")
				{
				cmd_command.Parameters.AddWithValue("@SO_Number", txtbx_so2.Text.ToUpper());
				retrieve_cust_name2();
				cmd_command.Parameters.AddWithValue("@Customer_Name", Customer_Name.ToString());
				}
				
				else //if (txtbx_so2.Text != "SBSD")
				{
					cmd_command.Parameters.AddWithValue("@SO_Number", txtbx_so2.Text = "0");
					cmd_command.Parameters.AddWithValue("@Customer_Name", Customer_Name= "0");

				}

			}
			
			else if (i<=2)
			{
				if(txtbx_so3.Text.ToUpper().Substring(0,1) =="S")
				{
					 cmd_command.Parameters.AddWithValue("@SO_Number", txtbx_so3.Text);
					 retrieve_cust_name3();
					 cmd_command.Parameters.AddWithValue("@Customer_Name", Customer_Name.ToString());
				}
				
				else// if (txtbx_so3.Text != "SBSD")
				{
					cmd_command.Parameters.AddWithValue("@SO_Number", txtbx_so3.Text = "0");
					cmd_command.Parameters.AddWithValue("@Customer_Name", Customer_Name = "0");
				}

			}
					
			else if (i<=3)
			{
				if(txtbx_so4.Text.ToUpper().Substring(0,1) == "S")
				{
					cmd_command.Parameters.AddWithValue("@SO_Number", txtbx_so4.Text);
					retrieve_cust_name4();
					cmd_command.Parameters.AddWithValue("@Customer_Name", Customer_Name.ToString());

				}
				
				else //if (txtbx_so4.Text != "SBSD")
				{
					cmd_command.Parameters.AddWithValue("@SO_Number", txtbx_so4.Text = "0");
					cmd_command.Parameters.AddWithValue("@Customer_Name", Customer_Name = "0");
				}
			}
			
			else if (i<=4)
			{
				
				if(txtbx_so5.Text.ToUpper().Substring(0,1) =="S")
				{
					cmd_command.Parameters.AddWithValue("@SO_Number", txtbx_so5.Text);
					retrieve_cust_name5();
					cmd_command.Parameters.AddWithValue("@Customer_Name", Customer_Name.ToString());
				}
				
				else //if (txtbx_so5.Text != "SBSD")
				{
					cmd_command.Parameters.AddWithValue("@SO_Number", txtbx_so5.Text = "0");
					cmd_command.Parameters.AddWithValue("@Customer_Name", Customer_Name = "0");
				}

			}
			
			else if (i<=5)
			{
				
				if(txtbx_so6.Text.ToUpper().Substring(0,1) == "S")
				{
					cmd_command.Parameters.AddWithValue("@SO_Number", txtbx_so6.Text);
					retrieve_cust_name6();
					cmd_command.Parameters.AddWithValue("@Customer_Name", Customer_Name.ToString());
				}
				
				else// if (txtbx_so6.Text.Substring(0,4) != "SBSD")
				{
					cmd_command.Parameters.AddWithValue("@SO_Number", txtbx_so6.Text = "0");
					cmd_command.Parameters.AddWithValue("@Customer_Name", Customer_Name ="0");
				}

			}
			else if	(i<=6)
			{
				if(txtbx_so7.Text.ToUpper().Substring(0,1) == "S")
				{
					cmd_command.Parameters.AddWithValue("@SO_Number", txtbx_so7.Text);
					retrieve_cust_name7();
					cmd_command.Parameters.AddWithValue("@Customer_Name", Customer_Name.ToString());
				}
				
				else// if (txtbx_so7.Text.Substring(0,4) != "SBSD")
				{
					cmd_command.Parameters.AddWithValue("@SO_Number", txtbx_so7.Text = "0");
					cmd_command.Parameters.AddWithValue("@Customer_Name", Customer_Name ="0");
				}

				
				
				}
					
			else if (i<=7)
			{
				if(txtbx_so8.Text.ToUpper().Substring(0,1) == "S")
				{
				cmd_command.Parameters.AddWithValue("@SO_Number", txtbx_so8.Text);
				retrieve_cust_name8();
				cmd_command.Parameters.AddWithValue("@Customer_Name", Customer_Name.ToString());
				
				}
				else// if (txtbx_so8.Text.Substring(0,4) != "SBSD")
				{
					cmd_command.Parameters.AddWithValue("@SO_Number", txtbx_so8.Text = "0");
					cmd_command.Parameters.AddWithValue("@Customer_Name", Customer_Name ="0");
				}

			}
			
			else if (i<=8)
			{
				if(txtbx_so9.Text.ToUpper().Substring(0,1) == "S")
			{
				
			cmd_command.Parameters.AddWithValue("@SO_Number", txtbx_so9.Text);
			retrieve_cust_name9();
			cmd_command.Parameters.AddWithValue("@Customer_Name", Customer_Name.ToString());
			}
			else// if (txtbx_so9.Text.Substring(0,4) != "SBSD")
			{
				cmd_command.Parameters.AddWithValue("@SO_Number", txtbx_so9.Text = "0");
				cmd_command.Parameters.AddWithValue("@Customer_Name", Customer_Name ="0");
			}

			}
			else if (i<=9)
			{
				
				if(txtbx_so10.Text.ToUpper().Substring(0,1) == "S")
				{
				cmd_command.Parameters.AddWithValue("@SO_Number", txtbx_so10.Text);
				retrieve_cust_name10();
				cmd_command.Parameters.AddWithValue("@Customer_Name", Customer_Name.ToString());
				}
				else// if (txtbx_so10.Text.Substring(0,4) != "SBSD")
				{
					cmd_command.Parameters.AddWithValue("@SO_Number", txtbx_so10.Text = "0");
					cmd_command.Parameters.AddWithValue("@Customer_Name", Customer_Name ="0");
				}


			}
					
					

				    cmd_command.ExecuteNonQuery();

		}
		
		MessageBox.Show("Succesfull Save");
		
			}
			
		
		catch (Exception ex) 
				{
//				con_Check_Jodoc_Printing.Close();
				MessageBox.Show("Error 2.0 : Duplicate JO!" + ex.ToString() + ex.Message);
//				return;
				} 
				
		finally 
				{
						cmd.Close();
		
				}
		
		
						delete_not_valid_so();
						txtbx_so1.Text = "0";
						txtbx_so2.Text = "0";
						txtbx_so3.Text = "0";
						txtbx_so4.Text = "0";
						txtbx_so5.Text = "0";
						txtbx_so6.Text = "0";
						txtbx_so7.Text = "0";
						txtbx_so8.Text = "0";
						txtbx_so9.Text = "0";
						txtbx_so10.Text = "0";

			}
			
			
				lbl_CI_NO.Text = final_nextno;
			SetValueForText1 = lbl_CI_NO.Text;	
			
			
			SqlConnection con_data_add2 = new SqlConnection(sqlconn);
			System.Data.SqlClient.SqlCommand cmd_data_add2 = new SqlCommand();  //adress pergi ke sql
			try 
			{
			//	MessageBox.Show(lbl_CI_NO.Text + "cino");

				cmd_data_add2.Connection = con_data_add2;		//coman run store procedure
				cmd_data_add2.CommandText = "SP_PROD_CI_NUMBER_TEMP";	//nama store procedure
				cmd_data_add2.CommandType = CommandType.StoredProcedure;		//declare comand
    	
				cmd_data_add2.Parameters.Add(new SqlParameter("@SP_CI_NO", SqlDbType.NVarChar, 50)); //create parameter pada sql bwk data SP_RefNumber untuk dihantar semula
				cmd_data_add2.Parameters["@SP_CI_NO"].Value = lbl_CI_NO.Text.ToUpper();
				
						
				con_data_add2.Open();
				cmd_data_add2.ExecuteNonQuery();
				
				MessageBox.Show("masuk x");
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
			
			
			
					

				}
						
				
		
		
		
		
		
		
		
		
			void NextNumberRetrieve()
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
							NextNo = Convert.ToInt32(rdNextNumber["Prod_CI_Next_No"].ToString());
							
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
						
						//************************************************************************************************************************
						//************************************************************************************************************************
						
			
						//************************************************************************************************************************
						
						CI_NextNo = Convert.ToString(NextNo);
						
						//************************************************************************************************************************
						//************************************************************************************************************************
						//---  Update next number
						SqlConnection conUpdateNextNumber = new SqlConnection(sqlconn);
						System.Data.SqlClient.SqlCommand cmdUpdateNextNumber = new SqlCommand();
						try {
							cmdUpdateNextNumber.CommandText = "update TBL_ADMIN_NEXT_NUMBER set Prod_CI_Next_No = Prod_CI_Next_No + 1";
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
			
			
			
			void retrieve_CI_NO()
		{
					
		}
			
			
			
			void send_email()
			{
				string FromName = "SAPS E-SERVICE";
			string FromEmail = "sbti.ax2020@gmail.com";
			string Subject = "STORE STOCK REQUISITION";
	
			SmtpClient smtp = new SmtpClient();
			smtp.Host = "smtp.gmail.com";
			smtp.Credentials = new System.Net.NetworkCredential("sbti.ax2020@gmail.com", "wsc4143pk");
			smtp.EnableSsl = true;
			smtp.Port = 587;
			//smtp.Port = 25;
	
			MailMessage msg = new MailMessage();
			msg.IsBodyHtml = true;
			msg.From = new MailAddress(FromEmail, FromName);
			
			msg.To.Add(new MailAddress("it-4@sbgroup.com.my", "Afiqah"));
			msg.To.Add(new MailAddress("samuel@sbgroup.com.my", "Samuel"));
			msg.To.Add(new MailAddress("it-2@sbgroup.com.my", "Kelvin"));
			

			msg.To.Add(new MailAddress("cath@sbgroup.com.my", "Catherine Teh"));
			msg.To.Add(new MailAddress("Kelly@sbgroup.com.my", "Kelly"));
	//
	//		if (txtbx_cust_type.Text == "LC") {
//			//--> Customer Service Local
//			msg.To.Add(new MailAddress("kelly@sbgroup.com.my", "Kelly Chan"));
//			msg.To.Add(new MailAddress("salesco-1@sbgroup.com.my", "Han Chok Min Jie"));
//			msg.To.Add(new MailAddress("salesco-1@sbgroup.com.my", "SalesCo1"));
//			msg.To.Add(new MailAddress("salesco-3@sbgroup.com.my", "SalesCo"));
//
//			if (StockCheckGlue == "N") {
//				//--> Store1806
//				//msg.To.Add(New MailAddress("logistic-8@sbgroup.com.my", "Fan Phong Lin"))
				msg.To.Add(new MailAddress("ST963@sbgroup.com.my", "Suriani"));
				msg.To.Add(new MailAddress("store-2@sbgroup.com.my", "Kalyani"));
				msg.To.Add(new MailAddress("store-9@sbgroup.com.my", "Chin Chin"));
				msg.To.Add(new MailAddress("logistic-5@sbgroup.com.my", "Arveenah"));
				msg.To.Add(new MailAddress("cyyong@sbgroup.com.my", "CY Yong"));
				msg.To.Add(new MailAddress("sosiaw@sbgroup.com.my", "SO Siaw"));
//			} else {
//				//--> Logistic
//				msg.To.Add(new MailAddress("logistic-5@sbgroup.com.my", "Arveenah"));
//				msg.To.Add(new MailAddress("store-4@sbgroup.com.my", "Shuairah "));
//				msg.To.Add(new MailAddress("store-7@sbgroup.com.my", "Hazlinda"));
//				msg.To.Add(new MailAddress("store-8@sbgroup.com.my", "Wong Wen Kuang"));
//				msg.To.Add(new MailAddress("logistic-10@sbgroup.com.my", "Jenny"));
//				msg.To.Add(new MailAddress("cyyong@sbgroup.com.my", "CY Yong"));
//				msg.To.Add(new MailAddress("sosiaw@sbgroup.com.my", "SO Siaw"));
//			}
//		
//			//--> Store1806
//			//msg.To.Add(New MailAddress("logistic-8@sbgroup.com.my", "Fan Phong Lin"))
//			msg.To.Add(new MailAddress("store-2@sbgroup.com.my", "Kalyani "));
//			msg.To.Add(new MailAddress("store-9@sbgroup.com.my", "Chin Chin"));
//			msg.To.Add(new MailAddress("logistic-5@sbgroup.com.my", "Arveenah"));
//
//			
//			//--> Logistic
//			msg.To.Add(new MailAddress("logistic-5@sbgroup.com.my", "Arveenah"));
//			msg.To.Add(new MailAddress("store-4@sbgroup.com.my", "Shuairah "));
//			msg.To.Add(new MailAddress("store-7@sbgroup.com.my", "Hazlinda"));
//			msg.To.Add(new MailAddress("store-8@sbgroup.com.my", "Wong Wen Kuang"));
//			msg.To.Add(new MailAddress("logistic-10@sbgroup.com.my", "Jenny"));
//			msg.To.Add(new MailAddress("cyyong@sbgroup.com.my", "CY Yong"));
//			msg.To.Add(new MailAddress("sosiaw@sbgroup.com.my", "SO Siaw"));
//		
			msg.To.Add(new MailAddress("stacy@sbgroup.com.my", "Stacy Chooi"));			
			msg.To.Add(new MailAddress("yap@sbgroup.com.my", "Yap Hong Kee "));
			msg.To.Add(new MailAddress("slitting-1@sbgroup.com.my","Sufia"));
			msg.To.Add(new MailAddress("ST964@sbgroup.com.my","Ain Zuhaili"));
			msg.To.Add(new MailAddress("planner-5@sbgroup.com.my", "Jess Ng"));
//			
//		
		string EmailUserName = null;
		string EmailUserDept = null;
		
		EmailUserName = null;
		EmailUserDept = null;

		SqlConnection con_Check_Recepient = new SqlConnection(sqlconn);
		SqlCommand cmd_Check_Recepient = new SqlCommand();
		
		try
		{
			cmd_Check_Recepient.CommandText = "Select * from TBL_ADMIN_USER_ACCESS where sysusername ='" + username.ToUpper() + "'";
			cmd_Check_Recepient.Connection = con_Check_Recepient;
			con_Check_Recepient.Open();
			
			SqlDataReader rd_Check_Recepient = cmd_Check_Recepient.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
			
			if (rd_Check_Recepient.HasRows) 
			{
				if (rd_Check_Recepient.Read()) 
				{
					EmailUserName = rd_Check_Recepient["sysstaffname"].ToString();
					EmailUserDept = rd_Check_Recepient["sysdept"].ToString();
				}
			}
			} 
			catch (Exception ex) 
			{
				con_Check_Recepient.Close();
				
			} 
			finally 
			{
				con_Check_Recepient.Close();
			}
			
			con_Check_Recepient.Dispose();
			cmd_Check_Recepient.Dispose();
			con_Check_Recepient = null;
			cmd_Check_Recepient = null;
			
			msg.Subject = Subject;
			msg.Body = "Please be informed that " + EmailUserName + " submitted stock requisition as follows:\n\n";//Ref Number         Line Number StockCode      Desc1                             Desc2                             Qty Ordered\n";
			
			//SqlDataAdapter thisAdapter = new SqlDataAdapter("Select JODOCNO, JOLINENO, JOSTOCKCODE, JOSTOCKDESC1, JOSTOCKDESC2, JOSTOCKQTYORDER from TBL_PROD_CONV_STORE_READY'"); //+ txtbx_ref_no.Text + "' order by JOLINENO", sqlconn);
			//DataSet DataSet = new DataSet(); 
			
			//thisAdapter.Fill(DataSet, "TBL_PROD_CONV_STORE_READY");
			
			//msg.Body = msg.Body + "<table> <tr> <th>Ref Number</th> <th>Line Number</th> <th>StockCode</th> <th>Desc1</th> <th>Desc2</th> <th>Qty Ordered</th> </tr>";
			
//			foreach (DataRow Row in DataSet.Tables["TBL_PROD_CONV_STORE_READY"].Rows)	
//			{
//			 	//msg.Body = msg.Body + "\n" + Row["JODOCNO"] + "  " + Row["JOLINENO"] + "  " + Row["JOSTOCKCODE"] + "  " + Row["JOSTOCKDESC1"] + "  " + Row["JOSTOCKDESC2"] + "  " + Row["JOSTOCKQTYORDER"]; 
//			 	msg.Body = msg.Body + "<tr> <td>" + Row["JODOCNO"].ToString() + "</td> <td>" + Row["JOLINENO"].ToString() + "</td> <td>" + Row["JOSTOCKCODE"].ToString() + "</td> <td>" + Row["JOSTOCKDESC1"].ToString() + "</td> <td>" + Row["JOSTOCKDESC2"].ToString() + "</td> <td>" + Row["JOSTOCKQTYORDER"].ToString() + "</td> </tr>";
//			}
			
			msg.Body = msg.Body + "</table>";
			msg.Body = msg.Body + "<br> <br> <br> <br>Thank you.<br> <br>SAPS SO System Notification.";
			
			try
			{
				smtp.Send(msg);
			} 
			catch (FormatException ex) 
			{
				MessageBox.Show("Format Exception: " + ex.Message + ex.ToString());
				return;
			} 
			catch (SmtpException ex) 
			{
				MessageBox.Show("SMTP Exception:  " + ex.Message + ex.ToString());
				return;
			} 
			catch (Exception ex) 
			{
				MessageBox.Show("General Exception:  " + ex.Message + ex.ToString());
				return;
			}
			
			}
				
			
		
		void Button1Click(object sender, EventArgs e)
		{
			
			frm_get_CI_NO_rpt f1 = new frm_get_CI_NO_rpt();
             f1.Show();
//			SqlConnection con_SP1 = new SqlConnection(sqlconn);
//			SqlCommand cmd_SP1 = new SqlCommand();
//			
//			try 
//			{
//				cmd_SP1.CommandText = "select * from TBL_PROD_CI_NUMBER where CI_NO like '" + CI_NextNo + "%'";
//				cmd_SP1.Connection = con_SP1;
//				con_SP1.Open();
//				SqlDataReader rd_SP1 = cmd_SP1.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
//				
//				if (rd_SP1.Read())
//				{
//
//						lbl_CI_NO.Text = rd_SP1["CI_NO"].ToString();
//	
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
		}
		
		
		
		void retrieve_cust_name1()
		{
			
			SqlConnection con_ret_so1 = new SqlConnection(sqlconn3);
			SqlCommand cmd_ret_so1 = new SqlCommand();
			
			try 
			{
				cmd_ret_so1.CommandText = "select * from VIEW_AXERP_SO_DETAIL where SALESID = '" + txtbx_so1.Text.ToUpper() +  "'";

				cmd_ret_so1.Connection = con_ret_so1;
				con_ret_so1.Open();
				SqlDataReader rd_ret_so1 = cmd_ret_so1.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
				
				
				if (rd_ret_so1.Read())
				{
				
						Customer_Name = rd_ret_so1["DELIVERYNAME"].ToString();
						MessageBox.Show(Customer_Name);		
				}


			
				else 
				{
					MessageBox.Show("Error Edit : Cannot find SO!");
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
				con_ret_so1.Close();
			}
			
			con_ret_so1.Dispose();
			con_ret_so1 = null;
			cmd_ret_so1 = null;
			
		}
		
		
		void retrieve_cust_name2()
		{
			SqlConnection con_ret_so2 = new SqlConnection(sqlconn3);
			SqlCommand cmd_ret_so2 = new SqlCommand();
			
			try 
			{
				cmd_ret_so2.CommandText = "select * from VIEW_AXERP_SO_DETAIL where SALESID = '" + txtbx_so2.Text.ToUpper() +  "'";

				cmd_ret_so2.Connection = con_ret_so2;
				con_ret_so2.Open();
				SqlDataReader rd_ret_so2 = cmd_ret_so2.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
				
				
				if (rd_ret_so2.Read())
				{
				
						Customer_Name = rd_ret_so2["DELIVERYNAME"].ToString();
						MessageBox.Show(Customer_Name);		
				}


			
				else 
				{
					MessageBox.Show("Error Edit : Cannot find SO!");
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
				con_ret_so2.Close();
			}
			
			con_ret_so2.Dispose();
			con_ret_so2 = null;
			cmd_ret_so2 = null;
		}
		
		
			void retrieve_cust_name3()
			{
				SqlConnection con_ret_so3 = new SqlConnection(sqlconn3);
			SqlCommand cmd_ret_so3 = new SqlCommand();
			
			try 
			{
				cmd_ret_so3.CommandText = "select * from VIEW_AXERP_SO_DETAIL where SALESID = '" + txtbx_so3.Text.ToUpper() +  "'";

				cmd_ret_so3.Connection = con_ret_so3;
				con_ret_so3.Open();
				SqlDataReader rd_ret_so3 = cmd_ret_so3.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
				
				
				if (rd_ret_so3.Read())
				{
				
						Customer_Name = rd_ret_so3["DELIVERYNAME"].ToString();
						MessageBox.Show(Customer_Name);		
				}


			
				else 
				{
					MessageBox.Show("Error Edit : Cannot find SO!");
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
				con_ret_so3.Close();
			}
			
			con_ret_so3.Dispose();
			con_ret_so3 = null;
			cmd_ret_so3 = null;
			}
			
			
			
			void retrieve_cust_name4()
			{
				SqlConnection con_ret_so4 = new SqlConnection(sqlconn3);
			SqlCommand cmd_ret_so4 = new SqlCommand();
			
			try 
			{
				cmd_ret_so4.CommandText = "select * from VIEW_AXERP_SO_DETAIL where SALESID = '" + txtbx_so4.Text.ToUpper() +  "'";

				cmd_ret_so4.Connection = con_ret_so4;
				con_ret_so4.Open();
				SqlDataReader rd_ret_so4 = cmd_ret_so4.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
				
				
				if (rd_ret_so4.Read())
				{
				
						Customer_Name = rd_ret_so4["DELIVERYNAME"].ToString();
						MessageBox.Show(Customer_Name);		
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
				con_ret_so4.Close();
			}
			
			con_ret_so4.Dispose();
			con_ret_so4 = null;
			cmd_ret_so4 = null;
			}
			
			
			
			void retrieve_cust_name5()
			{
				SqlConnection con_ret_so5 = new SqlConnection(sqlconn3);
			SqlCommand cmd_ret_so5 = new SqlCommand();
			
			try 
			{
				cmd_ret_so5.CommandText = "select * from VIEW_AXERP_SO_DETAIL where SALESID = '" + txtbx_so5.Text.ToUpper() +  "'";

				cmd_ret_so5.Connection = con_ret_so5;
				con_ret_so5.Open();
				SqlDataReader rd_ret_so5 = cmd_ret_so5.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
				
				
				if (rd_ret_so5.Read())
				{
				
						Customer_Name = rd_ret_so5["DELIVERYNAME"].ToString();
						MessageBox.Show(Customer_Name);		
				}


			
				else 
				{
					MessageBox.Show("Error Edit : Cannot find SO!");
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
				con_ret_so5.Close();
			}
			
			con_ret_so5.Dispose();
			con_ret_so5 = null;
			cmd_ret_so5 = null;
			}
			
			
			void retrieve_cust_name6()
			{
				SqlConnection con_ret_so6 = new SqlConnection(sqlconn3);
			SqlCommand cmd_ret_so6 = new SqlCommand();
			
			try 
			{
				cmd_ret_so6.CommandText = "select * from VIEW_AXERP_SO_DETAIL where SALESID = '" + txtbx_so6.Text.ToUpper() +  "'";

				cmd_ret_so6.Connection = con_ret_so6;
				con_ret_so6.Open();
				SqlDataReader rd_ret_so6 = cmd_ret_so6.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
				
				
				if (rd_ret_so6.Read())
				{
				
						Customer_Name = rd_ret_so6["DELIVERYNAME"].ToString();
						MessageBox.Show(Customer_Name);		
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
				con_ret_so6.Close();
			}
			
			con_ret_so6.Dispose();
			con_ret_so6 = null;
			cmd_ret_so6 = null;
			}
			
			
			void retrieve_cust_name7()
			{
				SqlConnection con_ret_so7 = new SqlConnection(sqlconn3);
			SqlCommand cmd_ret_so7 = new SqlCommand();
			
			try 
			{
				cmd_ret_so7.CommandText = "select * from VIEW_AXERP_SO_DETAIL where SALESID = '" + txtbx_so7.Text.ToUpper() +  "'";

				cmd_ret_so7.Connection = con_ret_so7;
				con_ret_so7.Open();
				SqlDataReader rd_ret_so7 = cmd_ret_so7.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
				
				
				if (rd_ret_so7.Read())
				{
				
						Customer_Name = rd_ret_so7["DELIVERYNAME"].ToString();
						MessageBox.Show(Customer_Name);		
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
				con_ret_so7.Close();
			}
			
			con_ret_so7.Dispose();
			con_ret_so7 = null;
			cmd_ret_so7 = null;
			}
			
			
			
			void retrieve_cust_name8()
			{
				SqlConnection con_ret_so8 = new SqlConnection(sqlconn3);
			SqlCommand cmd_ret_so8 = new SqlCommand();
			
			try 
			{
				cmd_ret_so8.CommandText = "select * from VIEW_AXERP_SO_DETAIL where SALESID = '" + txtbx_so8.Text.ToUpper() +  "'";

				cmd_ret_so8.Connection = con_ret_so8;
				con_ret_so8.Open();
				SqlDataReader rd_ret_so8 = cmd_ret_so8.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
				
				
				if (rd_ret_so8.Read())
				{
				
						Customer_Name = rd_ret_so8["DELIVERYNAME"].ToString();
						MessageBox.Show(Customer_Name);		
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
				con_ret_so8.Close();
			}
			
			con_ret_so8.Dispose();
			con_ret_so8 = null;
			cmd_ret_so8 = null;
			}
			
			
			
				void retrieve_cust_name9()
				{
					SqlConnection con_ret_so9 = new SqlConnection(sqlconn3);
					SqlCommand cmd_ret_so9 = new SqlCommand();
			
			try 
			{
				cmd_ret_so9.CommandText = "select * from VIEW_AXERP_SO_DETAIL where SALESID = '" + txtbx_so9.Text.ToUpper() +  "'";

				cmd_ret_so9.Connection = con_ret_so9;
				con_ret_so9.Open();
				SqlDataReader rd_ret_so9 = cmd_ret_so9.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
				
				
				if (rd_ret_so9.Read())
				{
				
						Customer_Name = rd_ret_so9["DELIVERYNAME"].ToString();
						MessageBox.Show(Customer_Name);		
				}


			
				else 
				{
					MessageBox.Show("Error Edit : Cannot find SO!");
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
				con_ret_so9.Close();
			}
			
			con_ret_so9.Dispose();
			con_ret_so9 = null;
			cmd_ret_so9 = null;
				}
				
				
				
				
				
				void retrieve_cust_name10()
				{
			SqlConnection con_ret_so10 = new SqlConnection(sqlconn3);
			SqlCommand cmd_ret_so10 = new SqlCommand();
			
			try 
			{
				cmd_ret_so10.CommandText = "select * from VIEW_AXERP_SO_DETAIL where SALESID = '" + txtbx_so10.Text.ToUpper() +  "'";

				cmd_ret_so10.Connection = con_ret_so10;
				con_ret_so10.Open();
				SqlDataReader rd_ret_so10 = cmd_ret_so10.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
				
				
				if (rd_ret_so10.Read())
				{
				
						Customer_Name = rd_ret_so10["DELIVERYNAME"].ToString();
						MessageBox.Show(Customer_Name);		
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
				con_ret_so10.Close();
			}
			
			con_ret_so10.Dispose();
			con_ret_so10 = null;
			cmd_ret_so10 = null;
		}
				
				
				
				void delete_not_valid_so()
				{
					SqlConnection sqlConnection1 = new SqlConnection(sqlconn);
					SqlCommand cmd = new SqlCommand();
					Int32 rowsAffected;
		
					cmd.CommandText = "SP_PROD_CI_NO";
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.Connection = sqlConnection1;
		
					sqlConnection1.Open();
		
					rowsAffected = cmd.ExecuteNonQuery();
		
					sqlConnection1.Close();
				}
					
		
		
		
		
		
		
		
		
		

	}
}
