/*
 * Created by SharpDevelop.
 * User: it-4
 * Date: 17/11/2016
 * Time: 4:52 PM
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
using fyiReporting;
using fyiReporting.RdlViewer;


namespace AX2020
{
	/// Description of frm_prod_converting_grn_film.
	
	public partial class frm_prod_converting_grn_film : Form
	{
		public static string sqlconn = "Server=(local)\\SQLEXPRESS; Password=ax2020sb; User ID=ax2020sb; Initial Catalog=SB_AX2020";
		private fyiReporting.RdlViewer.RdlViewer rdlViewer1;
        private fyiReporting.RdlViewer.ViewerToolstrip reportStrip;
        public static int notParseInt = 0;
        
        //>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
		
		public frm_prod_converting_grn_film()
		{

			InitializeComponent();
			this.ControlBox = false;

			ComboxCountry();

		}

		//>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
		
		private void ComboxCountry()
		{
		    SqlConnection conn = new SqlConnection(sqlconn);
            DataSet ds = new DataSet();
            string cmdSQL = "SELECT CountryList FROM TBL_GRN_COAT_COUNTRY_LIST order by CountryList";
            SqlDataAdapter sda = new SqlDataAdapter(cmdSQL, conn);

            try
            {
                conn.Open();
                sda.Fill(ds);
            
            }catch(SqlException se)
            {
            	MessageBox.Show("An error occured while connecting to database" + se.ToString() + se.Message);
            }
            finally
            {
                conn.Close();
            }

            cbx_country.DataSource = ds.Tables[0];
            cbx_country.DisplayMember = ds.Tables[0].Columns[0].ToString();
		}

		//>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
		
//		public void refreshdata()     
//        {  
//            DataRow dr;  
//  
//            SqlConnection con = new SqlConnection(sqlconn);  
//            con.Open();  
//            SqlCommand cmd = new SqlCommand("SELECT * FROM TBL_GRN_COAT_COUNTRY_LIST", con);  
//            SqlDataAdapter sda = new SqlDataAdapter(cmd);  
//            DataTable dt = new DataTable();  
//            sda.Fill(dt);  
//  
//            dr = dt.NewRow();  
//            dr.ItemArray = new object[] { 0, "Select Country" };  
//            dt.Rows.InsertAt(dr, 0);  
//             
//            cbx_country.ValueMember = "CountryId";  
//          
//            cbx_country.DisplayMember = "CountryList";  
//            cbx_country.DataSource = dt;  
//              
//            con.Close();    
//        }           
		
//>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>

		void Btn_addClick(object sender, EventArgs e)
		{
			if (!Validation())
                return;
			
				
			SqlConnection con_data_add = new SqlConnection(sqlconn);
			System.Data.SqlClient.SqlCommand cmd_data_add = new SqlCommand();
			
			try
			{
					cmd_data_add.Connection = con_data_add;
					cmd_data_add.CommandText = "SP_GRN_COAT_FILM_LABEL_ADD";
					cmd_data_add.CommandType = CommandType.StoredProcedure;

					cmd_data_add.Parameters.Add(new SqlParameter("@SP_RefNumber", SqlDbType.NVarChar, 50));
					cmd_data_add.Parameters["@SP_RefNumber"].Value = txtbx_ref_no.Text.ToUpper();

					cmd_data_add.Parameters.Add(new SqlParameter("@SP_Stockcode", SqlDbType.NVarChar, 50));
					cmd_data_add.Parameters["@SP_Stockcode"].Value = txtbx_stock_code.Text.ToUpper();

					cmd_data_add.Parameters.Add(new SqlParameter("@SP_Stockmicron", SqlDbType.Int, 50));
					cmd_data_add.Parameters["@SP_Stockmicron"].Value = Int32.TryParse(txtbx_mic.Text, out notParseInt);

					cmd_data_add.Parameters.Add(new SqlParameter("@SP_Stockwidth", SqlDbType.Int));
					cmd_data_add.Parameters["@SP_Stockwidth"].Value = Int32.TryParse(txtbx_width.Text, out notParseInt);

					cmd_data_add.Parameters.Add(new SqlParameter("@SP_Stocklength", SqlDbType.Int));
					cmd_data_add.Parameters["@SP_Stocklength"].Value = Int32.TryParse(txtbx_length.Text, out notParseInt);

					cmd_data_add.Parameters.Add(new SqlParameter("@SP_Stocktype", SqlDbType.Int));
					cmd_data_add.Parameters["@SP_Stocktype"].Value = Int32.TryParse(txtbx_type.Text, out notParseInt);

					cmd_data_add.Parameters.Add(new SqlParameter("@SP_Stockcountry", SqlDbType.NVarChar, 50));
					cmd_data_add.Parameters["@SP_Stockcountry"].Value = cbx_country.Text;

					cmd_data_add.Parameters.Add(new SqlParameter("@SP_StockPO", SqlDbType.NVarChar, 50));
					cmd_data_add.Parameters["@SP_StockPO"].Value = txtbx_po.Text.ToUpper();

					cmd_data_add.Parameters.Add(new SqlParameter("@SP_StockQty", SqlDbType.Int));
					cmd_data_add.Parameters["@SP_StockQty"].Value = Int32.TryParse(txtbx_qty.Text, out notParseInt);

					cmd_data_add.Parameters.Add(new SqlParameter("@SP_StockStatus", SqlDbType.NVarChar, 50));
					cmd_data_add.Parameters["@SP_StockStatus"].Value = txtbx_status.Text.ToUpper();

					con_data_add.Open();
					cmd_data_add.ExecuteNonQuery();
					
			} catch (Exception ex) {
				
				con_data_add.Close();
				MessageBox.Show("Unexpected error happen" + Environment.NewLine + ex.ToString() + ex.ToString());
			
				return;
			
			} finally {
				
				con_data_add.Close();
			}
			
			con_data_add.Dispose();
			con_data_add = null;
			cmd_data_add = null;
			
			ClearTextBox();
			
			MessageBox.Show("The data has been added succesfully");
			Print();
			
		}		

		//>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
		
		void Print()
		{
			System.Windows.Forms.Form frm = new System.Windows.Forms.Form();
        	frm.Height = 700;
        	frm.Width = 800;

        	//fyiReporting.RdlViewer.RdlViewer rdlView = new fyiReporting.RdlViewer.RdlViewer();
        	var rdlViewer1 = new fyiReporting.RdlViewer.RdlViewer();
			var reportStrip = new fyiReporting.RdlViewer.ViewerToolstrip(rdlViewer1);
        	//rdlViewer1.SourceFile = new Uri(@"D:\C# Project\Converting\Converting\report\BOPPFilmLabel2.rdl");
        	Uri baseUri = new Uri(System.IO.Directory.GetCurrentDirectory());
        	rdlViewer1.SourceFile = new Uri(baseUri, @"../report/BOPPFilmLabel2.rdl");
        	
        	//rdlView.Parameters += string.Format("&TestParam1={0}&TestParam2={1}", "Value 1", "Value 2");
        	rdlViewer1.Rebuild();

        	rdlViewer1.Dock = DockStyle.Fill;
        	frm.Controls.Add(rdlViewer1);
        	frm.Controls.Add(reportStrip);

        	//Application.Run(frm);
        	frm.ShowDialog(this);

		}
		
		//>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
		
		void Btn_cancelClick(object sender, EventArgs e)
		{
			DialogResult cancel = new DialogResult();
            cancel = MessageBox.Show("Do you want to cancel?", "Cancel", 
                     MessageBoxButtons.YesNo, 
                     MessageBoxIcon.Warning, 
                     MessageBoxDefaultButton.Button2);
            if (cancel == DialogResult.Yes)
                Application.Exit();
		}
		
		//>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
		
		void Btn_delClick(object sender, EventArgs e)
		{
			DialogResult del = new DialogResult();
            del = MessageBox.Show("Are you sure you want to delete it?", "Delete", 
                     MessageBoxButtons.YesNo, 
                     MessageBoxIcon.Warning, 
                     MessageBoxDefaultButton.Button2);
            if (del == DialogResult.Yes)
            {
            
            	SqlConnection con_data_del = new SqlConnection(sqlconn);
				System.Data.SqlClient.SqlCommand cmd_data_del = new SqlCommand();
				try 
				{
						cmd_data_del.Connection = con_data_del;
						cmd_data_del.CommandText = "SP_GRN_COAT_FILM_LABEL_DEL";
						cmd_data_del.CommandType = CommandType.StoredProcedure;
	
						cmd_data_del.Parameters.Add(new SqlParameter("@SP_RefNumber", SqlDbType.NVarChar, 50));
						cmd_data_del.Parameters["@SP_RefNumber"].Value = txtbx_ref_no.Text.ToUpper();
	
						cmd_data_del.Parameters.Add(new SqlParameter("@SP_Stockcode", SqlDbType.NVarChar, 50));
						cmd_data_del.Parameters["@SP_Stockcode"].Value = txtbx_stock_code.Text.ToUpper();
	
						cmd_data_del.Parameters.Add(new SqlParameter("@SP_Stockmicron", SqlDbType.Int, 50));
						cmd_data_del.Parameters["@SP_Stockmicron"].Value = Int32.TryParse(txtbx_mic.Text, out notParseInt);
	
						cmd_data_del.Parameters.Add(new SqlParameter("@SP_Stockwidth", SqlDbType.Int));
						cmd_data_del.Parameters["@SP_Stockwidth"].Value = Int32.TryParse(txtbx_width.Text, out notParseInt);
	
						cmd_data_del.Parameters.Add(new SqlParameter("@SP_Stocklength", SqlDbType.Int));
						cmd_data_del.Parameters["@SP_Stocklength"].Value = Int32.TryParse(txtbx_length.Text, out notParseInt);
	
						cmd_data_del.Parameters.Add(new SqlParameter("@SP_Stocktype", SqlDbType.Int));
						cmd_data_del.Parameters["@SP_Stocktype"].Value = Int32.TryParse(txtbx_type.Text, out notParseInt);
	
						cmd_data_del.Parameters.Add(new SqlParameter("@SP_Stockcountry", SqlDbType.NVarChar, 50));
						cmd_data_del.Parameters["@SP_Stockcountry"].Value = cbx_country.Text;
	
						cmd_data_del.Parameters.Add(new SqlParameter("@SP_StockPO", SqlDbType.NVarChar, 50));
						cmd_data_del.Parameters["@SP_StockPO"].Value = txtbx_po.Text.ToUpper();
	
						cmd_data_del.Parameters.Add(new SqlParameter("@SP_StockQty", SqlDbType.Int));
						cmd_data_del.Parameters["@SP_StockQty"].Value = Int32.TryParse(txtbx_qty.Text, out notParseInt);
	
						cmd_data_del.Parameters.Add(new SqlParameter("@SP_StockStatus", SqlDbType.NVarChar, 50));
						cmd_data_del.Parameters["@SP_StockStatus"].Value = txtbx_status.Text.ToUpper();
	
						con_data_del.Open();
						cmd_data_del.ExecuteNonQuery();
						
				} catch (Exception ex) {
					
					con_data_del.Close();
					MessageBox.Show("Unexpected error happen" + Environment.NewLine + ex.ToString() + ex.ToString());
				
					return;
				
				} finally {
					
					con_data_del.Close();
				}
				
				con_data_del.Dispose();
				con_data_del = null;
				cmd_data_del = null;
				
				ClearTextBox();
				
				MessageBox.Show("The data has been succesfully deleted");
	         }
            
           
		}
		
		//>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
		
		public void ClearTextBox()
		{
			txtbx_ref_no.Clear();
			txtbx_stock_code.Clear();
			txtbx_mic.Clear();
			txtbx_width.Clear();
			txtbx_length.Clear();
			txtbx_type.Clear();
			txtbx_po.Clear();
			txtbx_qty.Clear();
			txtbx_status.Clear();
			cbx_country.SelectedIndex = 0;
			
		}
		
		//>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
		
		private bool Validation()
        {
                  
               if (CommonValidation.ValidateIsEmptyString(txtbx_stock_code.Text.Trim()))
                {
                    DialogBox.ShowWarningMessage(lbl_stock_code.Text + " cannot be empty.");
                    txtbx_stock_code.Focus();
                   	
                    return false;
           
                }
              
               
               else if (CommonValidation.ValidateIsEmptyString(txtbx_mic.Text.Trim()))
                {
                    DialogBox.ShowWarningMessage(lbl_mic.Text + " cannot be empty.");
                    txtbx_mic.Focus();
                   	
                    return false;
                    
                }
               
               
               else if (CommonValidation.ValidateIsEmptyString(txtbx_width.Text.Trim()))
                {
                    DialogBox.ShowWarningMessage(lbl_width.Text + " cannot be empty.");
                    txtbx_width.Focus();
                   	
                    return false;
                   
                }
               
               else if (CommonValidation.ValidateIsEmptyString(txtbx_length.Text.Trim()))
                {
                    DialogBox.ShowWarningMessage(lbl_length.Text + " cannot be empty.");
                    txtbx_length.Focus();
                   	
                    return false;
                    
                }
               
               else if (CommonValidation.ValidateIsEmptyString(txtbx_qty.Text.Trim()))
                {
                    DialogBox.ShowWarningMessage(lbl_qty.Text + " cannot be empty.");
                    txtbx_qty.Focus();
                   	
                    return false;
                    
                }
               return true;
        }
	}
}
