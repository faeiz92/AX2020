using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic; // For generic collections like List.
using System.Data.SqlClient;      // For the database connections and objects.
using System.Data.Sql;
using System.Data;

namespace AX2020
{
	
	public partial class frm_prod_converting_jo_tracking : Form
	{
		public static string sqlconn = "Server=AX-UAT; Password=sbax2020sbg; User ID=sbax2020; Initial Catalog=SBG_AX_2020; Integrated Security=false";
		string username;
	
		public frm_prod_converting_jo_tracking()
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
		
		void DataGrid(string cmd_string, string no)
		{
			SqlConnection con = new SqlConnection(sqlconn);
			SqlCommand cmd = new SqlCommand();
				
			try 
			{
				//cmd_SP.CommandText = @"SELECT a.JODOCNO, a.JODATE, a.JOCUSTOMER, a.JOSTOCKCODE, a.JOSTOCKBRAND, a.JOSTOCKCOLOR, a.JOSTOCKMICRON, a.JOSTOCKWIDTH, a.JOSTOCKLENGTH, a.JOSTOCKCONVERSION, a.JOSTOCKQTYCTN, a.JOSTOCKQTYROLL, a.JOPRODREMARK0c, b.PROD_DATE, b.PROD_TOTALROLL, a.JOPACKQTYBAL FROM TBL_PROD_CONV_JO a INNER JOIN TBL_PROD_CONV_JO_SLITTING b ON b.PROD_DOCNO = a.JODOCNO WHERE PROD_DATE BETWEEN @from_date AND @to_date";
				cmd.CommandText = cmd_string;
				
				cmd.Parameters.AddWithValue("@no", no);
				cmd.Connection = con;
				con.Open();
				SqlDataAdapter dataadapter = new SqlDataAdapter(cmd);	
								 
			    //DataSet ds = new DataSet();
			    DataTable ds = new DataTable();
			    dataadapter.Fill(ds);
				 
  				this.dt_grid.DataSource = AutoNumberedTable(ds);

			}
			catch(Exception ex)
			{
				MessageBox.Show("Error" + ex.Message + ex.ToString());
				return;
			}
			finally
			{
				con.Close();
				dt_grid.Columns[0].Name = "No";
	            dt_grid.Columns[0].Width = 35;
	            dt_grid.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
	            dt_grid.Columns[1].HeaderText = "Jo No";
	            dt_grid.Columns[1].Width = 100;
	            dt_grid.Columns[2].HeaderText = "Jo Date";
	            dt_grid.Columns[2].Width = 80;
	            dt_grid.Columns[3].HeaderText = "Customer";
	            dt_grid.Columns[3].Width = 150;
	            dt_grid.Columns[4].HeaderText = "Stock Code";
	            dt_grid.Columns[4].Width = 100;
	            dt_grid.Columns[5].HeaderText = "Brand";
				dt_grid.Columns[5].Width = 80;            
				dt_grid.Columns[6].HeaderText = "Color";
				dt_grid.Columns[6].Width = 50;
	            dt_grid.Columns[7].HeaderText = "Micron";
	            dt_grid.Columns[7].Width = 50;
	            dt_grid.Columns[8].HeaderText = "Width";
	            dt_grid.Columns[8].Width = 50;
	            dt_grid.Columns[9].HeaderText = "Length";
	            dt_grid.Columns[9].Width = 50;
	            dt_grid.Columns[10].HeaderText = "Roll/Ctn";
	            dt_grid.Columns[10].Width = 80;
	            dt_grid.Columns[11].HeaderText = "Total Order";
	            dt_grid.Columns[11].Width = 90;
	            dt_grid.Columns[12].HeaderText = "ETD Date";
	            dt_grid.Columns[12].Width = 80;
	            
	            dt_grid.Columns[13].HeaderText = "Prod Qty";
				dt_grid.Columns[13].Width = 90;            
				dt_grid.Columns[14].HeaderText = "Prod Qty Balanced";
				dt_grid.Columns[14].Width = 90;
				
				dt_grid.Columns[15].HeaderText = "Pack Qty";
				dt_grid.Columns[15].Width = 90;            
				dt_grid.Columns[16].HeaderText = "Pack Qty Balanced";
				dt_grid.Columns[16].Width = 90;
	                       	
			}
			
			con.Dispose();
			con = null;
			cmd = null;	
		}
		
		private DataTable AutoNumberedTable(DataTable SourceTable)
		{
		
			DataTable ResultTable = new DataTable();
			DataColumn AutoNumberColumn = new DataColumn();
			AutoNumberColumn.ColumnName ="No";
			AutoNumberColumn.DataType = typeof(int);
			AutoNumberColumn.AutoIncrement = true;
			AutoNumberColumn.AutoIncrementSeed = 1;
			AutoNumberColumn.AutoIncrementStep = 1;
			
			ResultTable.Columns.Add(AutoNumberColumn);
			ResultTable.Merge(SourceTable);
			return ResultTable;
		
		}
		
		void Btn_search_soClick(object sender, EventArgs e)
		{
			DataGrid(@"SELECT JODOCNO, JODATE, JOCUSTOMER, JOSTOCKCODE, JOSTOCKBRAND, JOSTOCKCOLOR, JOSTOCKMICRON, JOSTOCKWIDTH, JOSTOCKLENGTH, JOSTOCKCONVERSION, JOPRODREMARK0c, JOETDDATE, JOPRODQTY, JOPRODQTYBAL, JOPACKQTY, JOPACKQTYBAL FROM TBL_PROD_CONV_JO WHERE LEFT(JODOCNO, CHARINDEX('-', JODOCNO)-1) = @no ", txtbx_so_no.Text);
		}
		
		void Btn_search_joClick(object sender, EventArgs e)
		{
			DataGrid(@"SELECT JODOCNO, JODATE, JOCUSTOMER, JOSTOCKCODE, JOSTOCKBRAND, JOSTOCKCOLOR, JOSTOCKMICRON, JOSTOCKWIDTH, JOSTOCKLENGTH, JOSTOCKCONVERSION, JOPRODREMARK0c, JOETDDATE, JOPRODQTY, JOPRODQTYBAL, JOPACKQTY, JOPACKQTYBAL FROM TBL_PROD_CONV_JO WHERE JODOCNO = @no ", txtbx_jo_no.Text);			
		}
		
		void Dt_gridDataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
		{
			dt_grid.ClearSelection();
		}
	}
}
