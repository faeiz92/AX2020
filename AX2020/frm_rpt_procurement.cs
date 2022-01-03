/*
 * Created by SharpDevelop.
 * User: faeiz
 * Date: 2017-09-21
 * Time: 11:43 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;

namespace AX2020
{
	/// <summary>
	/// Description of frm_prod_procurement.
	/// </summary>
	public partial class frm_rpt_procurement : Form
	{
		public frm_rpt_procurement()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		void Btn_polocalClick(object sender, EventArgs e)
		{
			this.Hide();
			using(frm_po_local frm_po_local1 = new frm_po_local())
			frm_po_local1.ShowDialog();
			this.Show();
		}
		
		void Btn_poimportClick(object sender, EventArgs e)
		{
			this.Hide();
			using(frm_po_import frm_po_import1 = new frm_po_import())
			frm_po_import1.ShowDialog();
			this.Show();
		}
		
		void Btn_proClick(object sender, EventArgs e)
		{				
			this.Hide();
			using(frm_rpt_po_listing frm_rpt_po_listing1 = new frm_rpt_po_listing())
			frm_rpt_po_listing1.ShowDialog();
			this.Show();
		}
		
		void Btn_po_pendingClick(object sender, EventArgs e)
		{
			this.Hide();
			using(frm_rpt_procurement_po_pending_del rpt_procurement_po_pending_del = new frm_rpt_procurement_po_pending_del())
			rpt_procurement_po_pending_del.ShowDialog();
			this.Show();
		}
	}
}
