using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic; // For generic collections like List.
using System.Data.SqlClient;      // For the database connections and objects.
using System.Data.Sql;
using System.Data;
using System.Text;

namespace AX2020
{
	
	public partial class frm_prod_converting_jo_progress : Form
	{
		public static string sqlconn = "Server=AX-UAT; Password=sbax2020sbg; User ID=sbax2020; Initial Catalog=SBG_AX_2020; Integrated Security=false";
		string username;
	
		public frm_prod_converting_jo_progress()
		{
			
			InitializeComponent();
			
			this.ControlBox = false;
			
			username = frm_menu_system.userName; 
			lbl_username.Text = "User : " + username;
		}
		
		void Btn_cancelClick(object sender, EventArgs e)
		{
			this.Close();
		}
		
		
		
//		void DataGrid(string from_date, string to_date)
//		{
//			SqlConnection con_SP = new SqlConnection(sqlconn);
//			SqlCommand cmd_SP = new SqlCommand();
//				
//			try 
//			{
//				//cmd_SP.CommandText = @"SELECT a.JODOCNO, a.JODATE, a.JOCUSTOMER, a.JOSTOCKCODE, a.JOSTOCKBRAND, a.JOSTOCKCOLOR, a.JOSTOCKMICRON, a.JOSTOCKWIDTH, a.JOSTOCKLENGTH, a.JOSTOCKCONVERSION, a.JOSTOCKQTYCTN, a.JOSTOCKQTYROLL, a.JOPRODREMARK0c, b.PROD_DATE, b.PROD_TOTALROLL, a.JOPACKQTYBAL FROM TBL_PROD_CONV_JO a INNER JOIN TBL_PROD_CONV_JO_SLITTING b ON b.PROD_DOCNO = a.JODOCNO WHERE PROD_DATE BETWEEN @from_date AND @to_date";
//				cmd_SP.CommandText = @"SELECT 	JODOCNO, 
//												JODATE, 
//												JOCUSTOMER, 
//												JOSTOCKCODE, 
//												JOSTOCKBRAND, 
//												JOSTOCKCOLOR, 
//												JOSTOCKMICRON, 
//												JOSTOCKWIDTH, 
//												JOSTOCKLENGTH, 
//												JOSTOCKCONVERSION, 
//												JOPRODREMARK0c, 
//												JOETDDATE, 
//												JOPRODQTY, 
//												JOPRODQTYBAL, 
//												JOPACKQTY, 
//												JOPACKQTYBAL FROM TBL_PROD_CONV_JO WHERE JOETDDATE BETWEEN @from_date AND @to_date";
//				//cmd_SP.CommandText = @"SELECT 	";
//				
//				
//				cmd_SP.Parameters.AddWithValue("@from_date",  from_date);
//				cmd_SP.Parameters.AddWithValue("@to_date",  to_date);
//				cmd_SP.Connection = con_SP;
//				con_SP.Open();
//				SqlDataAdapter dataadapter = new SqlDataAdapter(cmd_SP);	
//								 
//			    //DataSet ds = new DataSet();
//			    DataTable ds = new DataTable();
//			    dataadapter.Fill(ds);
//				 
//  				this.dt_grid.DataSource = AutoNumberedTable(ds);
//
//			}
//			catch(Exception ex)
//			{
//				MessageBox.Show("Error" + ex.Message + ex.ToString());
//				return;
//			}
//			finally
//			{
//				con_SP.Close();
//				dt_grid.Columns[0].Name = "No";
//	            dt_grid.Columns[0].Width = 35;
//	            dt_grid.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
//	            dt_grid.Columns[1].HeaderText = "Jo No";
//	            dt_grid.Columns[1].Width = 100;
//	            dt_grid.Columns[2].HeaderText = "Jo Date";
//	            dt_grid.Columns[2].Width = 80;
//	            dt_grid.Columns[3].HeaderText = "Customer";
//	            dt_grid.Columns[3].Width = 150;
//	            dt_grid.Columns[4].HeaderText = "Stock Code";
//	            dt_grid.Columns[4].Width = 100;
//	            dt_grid.Columns[5].HeaderText = "Brand";
//				dt_grid.Columns[5].Width = 80;            
//				dt_grid.Columns[6].HeaderText = "Color";
//				dt_grid.Columns[6].Width = 50;
//	            dt_grid.Columns[7].HeaderText = "Micron";
//	            dt_grid.Columns[7].Width = 50;
//	            dt_grid.Columns[8].HeaderText = "Width";
//	            dt_grid.Columns[8].Width = 50;
//	            dt_grid.Columns[9].HeaderText = "Length";
//	            dt_grid.Columns[9].Width = 50;
//	            dt_grid.Columns[10].HeaderText = "Roll/Ctn";
//	            dt_grid.Columns[10].Width = 80;
//	            dt_grid.Columns[11].HeaderText = "Total Order";
//	            dt_grid.Columns[11].Width = 90;
//	            dt_grid.Columns[12].HeaderText = "ETD Date";
//	            dt_grid.Columns[12].Width = 80;
//	            
//	            dt_grid.Columns[13].HeaderText = "Prod Qty";
//				dt_grid.Columns[13].Width = 90;            
//				dt_grid.Columns[14].HeaderText = "Prod Qty Balanced";
//				dt_grid.Columns[14].Width = 90;
//				
//				dt_grid.Columns[15].HeaderText = "Pack Qty";
//				dt_grid.Columns[15].Width = 90;            
//				dt_grid.Columns[16].HeaderText = "Pack Qty Balanced";
//				dt_grid.Columns[16].Width = 90;
//	                       	
//			}
//			
//			con_SP.Dispose();
//			con_SP = null;
//			cmd_SP = null;	
//		}
//		
//		
//		
//		void DataGrid2(string cmd, string no)
//		{
//			SqlConnection con_SP2 = new SqlConnection(sqlconn);
//			SqlCommand cmd_SP2 = new SqlCommand();
//				
//			try 
//			{
//				//cmd_SP.CommandText = @"SELECT a.JODOCNO, a.JODATE, a.JOCUSTOMER, a.JOSTOCKCODE, a.JOSTOCKBRAND, a.JOSTOCKCOLOR, a.JOSTOCKMICRON, a.JOSTOCKWIDTH, a.JOSTOCKLENGTH, a.JOSTOCKCONVERSION, a.JOSTOCKQTYCTN, a.JOSTOCKQTYROLL, a.JOPRODREMARK0c, b.PROD_DATE, b.PROD_TOTALROLL, a.JOPACKQTYBAL FROM TBL_PROD_CONV_JO a INNER JOIN TBL_PROD_CONV_JO_SLITTING b ON b.PROD_DOCNO = a.JODOCNO WHERE PROD_DATE BETWEEN @from_date AND @to_date";
//				cmd_SP2.CommandText = cmd;
//				//cmd_SP.CommandText = @"SELECT 	";
//				
//				
//				cmd_SP2.Parameters.AddWithValue("@no", no);
//				cmd_SP2.Connection = con_SP2;
//				con_SP2.Open();
//				SqlDataAdapter dataadapter = new SqlDataAdapter(cmd_SP2);	
//								 
//			    //DataSet ds = new DataSet();
//			    DataTable ds = new DataTable();
//			    dataadapter.Fill(ds);
//				 
//  				this.dt_grid.DataSource = AutoNumberedTable(ds);
//
//			}
//			catch(Exception ex)
//			{
//				MessageBox.Show("Error" + ex.Message + ex.ToString());
//				return;
//			}
//			finally
//			{
//				con_SP2.Close();
//				dt_grid.Columns[0].Name = "No";
//	            dt_grid.Columns[0].Width = 35;
//	            dt_grid.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
//	            dt_grid.Columns[1].HeaderText = "Jo No";
//	            dt_grid.Columns[1].Width = 100;
//	            dt_grid.Columns[2].HeaderText = "Jo Date";
//	            dt_grid.Columns[2].Width = 80;
//	            dt_grid.Columns[3].HeaderText = "Customer";
//	            dt_grid.Columns[3].Width = 150;
//	            dt_grid.Columns[4].HeaderText = "Stock Code";
//	            dt_grid.Columns[4].Width = 100;
//	            dt_grid.Columns[5].HeaderText = "Brand";
//				dt_grid.Columns[5].Width = 80;            
//				dt_grid.Columns[6].HeaderText = "Color";
//				dt_grid.Columns[6].Width = 50;
//	            dt_grid.Columns[7].HeaderText = "Micron";
//	            dt_grid.Columns[7].Width = 50;
//	            dt_grid.Columns[8].HeaderText = "Width";
//	            dt_grid.Columns[8].Width = 50;
//	            dt_grid.Columns[9].HeaderText = "Length";
//	            dt_grid.Columns[9].Width = 50;
//	            dt_grid.Columns[10].HeaderText = "Roll/Ctn";
//	            dt_grid.Columns[10].Width = 80;
//	            dt_grid.Columns[11].HeaderText = "Total Order";
//	            dt_grid.Columns[11].Width = 90;
//	            dt_grid.Columns[12].HeaderText = "ETD Date";
//	            dt_grid.Columns[12].Width = 80;
//	            
//	            dt_grid.Columns[13].HeaderText = "Prod Qty";
//				dt_grid.Columns[13].Width = 90;            
//				dt_grid.Columns[14].HeaderText = "Prod Qty Balanced";
//				dt_grid.Columns[14].Width = 90;
//				
//				dt_grid.Columns[15].HeaderText = "Pack Qty";
//				dt_grid.Columns[15].Width = 90;            
//				dt_grid.Columns[16].HeaderText = "Pack Qty Balanced";
//				dt_grid.Columns[16].Width = 90;
//	                       	
//			}
//			
//			con_SP2.Dispose();
//			con_SP2 = null;
//			cmd_SP2 = null;	
//		}
//		
//		private DataTable AutoNumberedTable(DataTable SourceTable)
//		{
//		
//			DataTable ResultTable = new DataTable();
//			DataColumn AutoNumberColumn = new DataColumn();
//			AutoNumberColumn.ColumnName ="No";
//			AutoNumberColumn.DataType = typeof(int);
//			AutoNumberColumn.AutoIncrement = true;
//			AutoNumberColumn.AutoIncrementSeed = 1;
//			AutoNumberColumn.AutoIncrementStep = 1;
//			
//			ResultTable.Columns.Add(AutoNumberColumn);
//			ResultTable.Merge(SourceTable);
//			return ResultTable;
//		
//		}
		
		void Btn_searchClick(object sender, EventArgs e)
		{
			//dt_grid.DataSource = null;
			
			string from_date_search = dtp_date_from.Value.Date.ToString();
			string to_date_search = dtp_date_to.Value.Date.AddDays(1).AddSeconds(-1).ToString();
			
			//DataGrid(from_date_search, to_date_search);
		}
		
		void Btn_search_soClick(object sender, EventArgs e)
		{
			//DataGrid2(@"SELECT JODOCNO, JODATE, JOCUSTOMER, JOSTOCKCODE, JOSTOCKBRAND, JOSTOCKCOLOR, JOSTOCKMICRON, JOSTOCKWIDTH, JOSTOCKLENGTH, JOSTOCKCONVERSION, JOPRODREMARK0c, JOETDDATE, JOPRODQTY, JOPRODQTYBAL, JOPACKQTY, JOPACKQTYBAL FROM TBL_PROD_CONV_JO WHERE LEFT(JODOCNO, CHARINDEX('-', JODOCNO)-1) = @no ", txtbx_so_no.Text);
		}
		
		void Btn_search_joClick(object sender, EventArgs e)
		{
			//DataGrid2(@"SELECT JODOCNO, JODATE, JOCUSTOMER, JOSTOCKCODE, JOSTOCKBRAND, JOSTOCKCOLOR, JOSTOCKMICRON, JOSTOCKWIDTH, JOSTOCKLENGTH, JOSTOCKCONVERSION, JOPRODREMARK0c, JOETDDATE, JOPRODQTY, JOPRODQTYBAL, JOPACKQTY, JOPACKQTYBAL FROM TBL_PROD_CONV_JO WHERE JODOCNO = @no ", txtbx_jo_no.Text);
		}
		
		void Btn_custClick(object sender, EventArgs e)
		{
			//DataGrid2(@"SELECT JODOCNO, JODATE, JOCUSTOMER, JOSTOCKCODE, JOSTOCKBRAND, JOSTOCKCOLOR, JOSTOCKMICRON, JOSTOCKWIDTH, JOSTOCKLENGTH, JOSTOCKCONVERSION, JOPRODREMARK0c, JOETDDATE, JOPRODQTY, JOPRODQTYBAL, JOPACKQTY, JOPACKQTYBAL FROM TBL_PROD_CONV_JO WHERE JOCUSTOMER LIKE '%' + @no + '%' ", txtbx_cust.Text);
		}
		

		
//		void BuildCommand()
//        {
//            var sb = new StringBuilder();
//            var sqlparams = new Dictionary<string, string>();
//
//            sb.AppendLine("select JODOCNO, JOCUSTOMER");
//            sb.AppendLine("from TBL_PROD_CONV_JO");
//            sb.AppendLine("Where");
//            //sb.AppendLine("param1 = @param1");
//            //sqlparams.Add("param1", textBox1.Text);
//            
//            if (!string.IsNullOrWhiteSpace(txtbx_jo_no.Text))
//            {
//                sb.AppendLine("and JODOCNO = @param1");
//                sqlparams.Add("@param1", txtbx_jo_no.Text);
//            }
//
//            if (!string.IsNullOrWhiteSpace(txtbx_cust.Text))
//            {
//                sb.AppendLine("and JOCUSTOMER like % + @param2 + %");
//                sqlparams.Add("@param2", txtbx_cust.Text);
//            }
//
//            
//            if (!string.IsNullOrWhiteSpace(txtbx_so_no.Text))
//            {
//                sb.AppendLine("and JODOCNO = @param3 + %");
//                sqlparams.Add("@param3", txtbx_so_no.Text);
//            }
//
//            //var cmd_SP3 = new SqlCommand(sb.ToString());
//            //var cmd.CommandText = sb.ToString();
//            
//            foreach (var sqlparam in sqlparams)
//            {
//               // cmd_SP3.Parameters.Add(sqlparam.Key, sqlparam.Value);
//            }
//        }
//		
//		
//		void DataGrid3()
//		{
//			SqlConnection con_SP3 = new SqlConnection(sqlconn);
//			SqlCommand cmd_SP3 = new SqlCommand();
//				
//			try 
//			{
//				//cmd_SP.CommandText = @"SELECT a.JODOCNO, a.JODATE, a.JOCUSTOMER, a.JOSTOCKCODE, a.JOSTOCKBRAND, a.JOSTOCKCOLOR, a.JOSTOCKMICRON, a.JOSTOCKWIDTH, a.JOSTOCKLENGTH, a.JOSTOCKCONVERSION, a.JOSTOCKQTYCTN, a.JOSTOCKQTYROLL, a.JOPRODREMARK0c, b.PROD_DATE, b.PROD_TOTALROLL, a.JOPACKQTYBAL FROM TBL_PROD_CONV_JO a INNER JOIN TBL_PROD_CONV_JO_SLITTING b ON b.PROD_DOCNO = a.JODOCNO WHERE PROD_DATE BETWEEN @from_date AND @to_date";
//				//cmd_SP3.CommandText = cmd;
//				//cmd_SP.CommandText = @"SELECT 	";
//				
//				//BuildCommand();
//				
//				
//				var sb = new StringBuilder();
//            var sqlparams = new Dictionary<string, string>();
//
//            sb.AppendLine("select JODOCNO, JOCUSTOMER, JODOCNO");
//            sb.AppendLine("from TBL_PROD_CONV_JO");
//            sb.AppendLine("Where");
//            //sb.AppendLine("param1 = @param1");
//            //sqlparams.Add("param1", textBox1.Text);
//            
//            if (!string.IsNullOrWhiteSpace(txtbx_jo_no.Text))
//            {
//                sb.AppendLine("and param1 = @param1");
//                sqlparams.Add("param1", txtbx_jo_no.Text);
//            }
//
//            if (!string.IsNullOrWhiteSpace(txtbx_cust.Text))
//            {
//                sb.AppendLine("and param2 like %@param2%");
//                sqlparams.Add("param2", txtbx_cust.Text);
//            }
//
//            
//            if (!string.IsNullOrWhiteSpace(txtbx_so_no.Text))
//            {
//                sb.AppendLine("and param3 like @param3%");
//                sqlparams.Add("param3", txtbx_so_no.Text);
//            }
//
//            //var cmd_SP3 = new SqlCommand(sb.ToString());
//            cmd_SP3.CommandText = sb.ToString();
//            
//            foreach (var sqlparam in sqlparams)
//            {
//                cmd_SP3.Parameters.Add(sqlparam.Key, sqlparam.Value);
//            }
//				//cmd_SP3.Parameters.AddWithValue("@no", no);
//				cmd_SP3.Connection = con_SP3;
//				con_SP3.Open();
//				
//				SqlDataAdapter dataadapter = new SqlDataAdapter(cmd_SP3);	
//								 
//			    //DataSet ds = new DataSet();
//			    DataTable ds = new DataTable();
//			    dataadapter.Fill(ds);
//				 
//  				this.dt_grid.DataSource = AutoNumberedTable(ds);
//
//			}
//			catch(Exception ex)
//			{
//				MessageBox.Show("Error" + ex.Message + ex.ToString());
//				return;
//			}
//			finally
//			{
//				con_SP3.Close();
//				dt_grid.Columns[0].Name = "No";
//	            dt_grid.Columns[0].Width = 35;
//	            dt_grid.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
//	            dt_grid.Columns[1].HeaderText = "Jo No";
//	            dt_grid.Columns[1].Width = 100;
//	            dt_grid.Columns[2].HeaderText = "Jo Date";
//	            dt_grid.Columns[2].Width = 80;
//	            dt_grid.Columns[3].HeaderText = "Customer";
//	            dt_grid.Columns[3].Width = 150;
//	            dt_grid.Columns[4].HeaderText = "Stock Code";
//	            dt_grid.Columns[4].Width = 100;
//	            dt_grid.Columns[5].HeaderText = "Brand";
//				dt_grid.Columns[5].Width = 80;            
//				dt_grid.Columns[6].HeaderText = "Color";
//				dt_grid.Columns[6].Width = 50;
//	            dt_grid.Columns[7].HeaderText = "Micron";
//	            dt_grid.Columns[7].Width = 50;
//	            dt_grid.Columns[8].HeaderText = "Width";
//	            dt_grid.Columns[8].Width = 50;
//	            dt_grid.Columns[9].HeaderText = "Length";
//	            dt_grid.Columns[9].Width = 50;
//	            dt_grid.Columns[10].HeaderText = "Roll/Ctn";
//	            dt_grid.Columns[10].Width = 80;
//	            dt_grid.Columns[11].HeaderText = "Total Order";
//	            dt_grid.Columns[11].Width = 90;
//	            dt_grid.Columns[12].HeaderText = "ETD Date";
//	            dt_grid.Columns[12].Width = 80;
//	            
//	            dt_grid.Columns[13].HeaderText = "Prod Qty";
//				dt_grid.Columns[13].Width = 90;            
//				dt_grid.Columns[14].HeaderText = "Prod Qty Balanced";
//				dt_grid.Columns[14].Width = 90;
//				
//				dt_grid.Columns[15].HeaderText = "Pack Qty";
//				dt_grid.Columns[15].Width = 90;            
//				dt_grid.Columns[16].HeaderText = "Pack Qty Balanced";
//				dt_grid.Columns[16].Width = 90;
//	                       	
//			}
//			
//			con_SP3.Dispose();
//			con_SP3 = null;
//			cmd_SP3 = null;	
//		}
//		
//		void Dt_gridDataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
//		{
//			dt_grid.ClearSelection();
//		}
	}
}
