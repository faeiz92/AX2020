/*
 * Created by SharpDevelop.
 * User: faeiz
 * Date: 2017-10-14
 * Time: 4:40 PM
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
//using Excel = Microsoft.Office.Interop.Excel;

namespace AX2020
{
	/// <summary>
	/// Description of frm_ax_stock_status_sm06.
	/// </summary>
	public partial class frm_ax_stock_status_sm06 : Form
	{
		public static string sqlconn = "Server=AX-UAT; Password=sbax2020sbg; User ID=sbax2020; Initial Catalog=SBG_AX_2020; Integrated Security=false";

		public frm_ax_stock_status_sm06()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			datagridview1();
			this.ControlBox = false;
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		
		private void datagridview1()
        {
            string sql = "SELECT * FROM VIEW_AXERP_TFRSTK_SM06";
            SqlConnection connection = new SqlConnection(sqlconn);
            SqlDataAdapter dataadapter = new SqlDataAdapter(sql, connection);
            DataSet ds = new DataSet();
            connection.Open();
            dataadapter.Fill(ds, "Authors_table");
            connection.Close();
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "Authors_table";
        }
		
		void Btn_closeClick(object sender, EventArgs e)
		{
			this.Close();
		}
		
		
//			void Btn_export_excellClick(object sender, EventArgs e)
//		{
//			 Excel.Application xlApp;
//            Excel.Workbook xlWorkBook;
//            Excel.Worksheet xlWorkSheet;
//            object misValue = System.Reflection.Missing.Value;
//
//            Int16 i, j;
//
//            xlApp = new Excel.ApplicationClass();
//            xlWorkBook = xlApp.Workbooks.Add(misValue);
//
//            xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
//
//            for (i = 0; i <= dataGridView1.RowCount - 2; i++)
//            {
//                for (j = 0; j <= dataGridView1.ColumnCount - 1; j++)
//                {
//                    xlWorkSheet.Cells[i + 1, j + 1] = dataGridView1[j, i].Value.ToString();
//                }
//            }
//
//            xlWorkBook.SaveAs(@"c:\csharp.net-informations.xls", Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
//            xlWorkBook.Close(true, misValue, misValue);
//            xlApp.Quit();
//
//            releaseObject(xlWorkSheet);
//            releaseObject(xlWorkBook);
//            releaseObject(xlApp);
//		}


//        private void releaseObject(object obj)
//        {
//            try
//            {
//                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
//                obj = null;
//            }
//            catch (Exception ex)
//            {
//                obj = null;
//                MessageBox.Show("Exception Occured while releasing object " + ex.ToString());
//            }
//            finally
//            {
//                GC.Collect();
//            }
//        }
		
	
	}
}
