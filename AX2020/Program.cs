/*
 * Created by SharpDevelop.
 * User: it-4
 * Date: 16/11/2016
 * Time: 10:42 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Windows.Forms;
using fyiReporting;
//using fyiReporting.RDL;
using fyiReporting.RdlViewer;


namespace AX2020
{
	/// <summary>
	/// Class with program entry point.
	/// </summary>
	internal sealed class Program
	{
		/// <summary>
		/// Program entry point.
		/// </summary>
		[STAThread]
		private static void Main(string[] args)
		{
			//Application.EnableVisualStyles();  //jangan uncomment
			Application.SetCompatibleTextRenderingDefault(false);  //jangan uncomment
			
			Application.Run(new frm_menu_system());
			//Application.Run(new frm_menu_main());
			//Application.Run(new frm_menu_converting());
			//Application.Run(new frm_admin_factory());
			
			//Application.Run(new frm_prod_converting_jo());
			//Application.Run(new frm_prod_converting_store());
			//Application.Run(new frm_prod_converting_bill());
			//Application.Run(new frm_prod_converting_jo_print());
			//Application.Run(new frm_prod_converting_jo_progress());
			//Application.Run(new frm_prod_converting_jo_tracking());
			//Application.Run(new frm_prod_stretch_film());
			//Application.Run(new frm_prod_shipping());
			//Application.Run(new frm_prod_converting_output_slitting());
			//Application.Run(new frm_prod_converting_output_rewinding());
			//Application.Run(new frm_prod_converting_output_cutting());
			//Application.Run(new frm_prod_converting_output_packing());
			//Application.Run(new frm_prod_converting_output_papercore());
			//Application.Run(new frm_prod_converting_grn_film());
			//Application.Run(new frm_prod_coating_grn());
			//Application.Run(new frm_prod_warehouse_fr_receive_pack());
			//Application.Run(new frm_prod_warehouse_ribbon_received());
			//Application.Run(new frm_prod_warehouse_stretch_film_received());
			
			
			//Application.Run(new frm_rpt_converting_prod());
			//Application.Run(new frm_rpt_converting_pack());
			//Application.Run(new frm_rpt_converting_prod_detail());
			//Application.Run(new frm_rpt_converting_pack_detail());
			//Application.Run(new frm_rpt_converting_prod_fast());
			//Application.Run(new frm_rpt_converting_prod_shift_fast());
			//Application.Run(new frm_rpt_converting_pack_fast());
			//Application.Run(new frm_rpt_converting_pack_shift_fast());
			//Application.Run(new frm_rpt_converting_progress());
			//Application.Run(new frm_rpt_converting_tracking());
			//Application.Run(new frm_rpt_ribbon_output());
			
			//Application.Run(new frm_prod_ribbon());
			//Application.Run(new frm_prod_kliner());
			//Application.Run(new frm_prod_ribbon_popup());
			//Application.Run(new frm_mngmt());
			//Application.Run(new frm_shipping_calendar());
			//Application.Run(new frm_prod_sales_order());
			
			//Application.Run(new frm_prod_coating_jo());
			//Application.Run(new frm_prod_coating_jo_printing());
			//Application.Run(new frm_prod_coating_double_side());
			//Application.Run(new frm_prod_coating_schwaner());
			//Application.Run(new frm_prod_coating_printing_bom());
			//Application.Run(new frm_prod_coating_store());
			//Application.Run(new frm_menu_coating());
			
			
			//Application.Run(new frm_prod_glue());
			//Application.Run(new frm_prod_glue_popup());
			//Application.Run(new frm_prod_papercore());
			//Application.Run(new frm_prod_papercore_popup());
			//Application.Run(new frm_menu_coating());
			//Application.Run(new frm_prod_stretch_film_popup());		
			//Application.Run(new frm_prod_stretch_film());		
			//Application.Run(new frm_menu_coating());	
			//Application.Run(new frm_prod_warehouse_jr_receive_barcode());	
			
			//Application.Run(new frm_main_menu_coating());
								
			
			//report COATING
			//Application.Run(new frm_rpt_coating_output());
			//Application.Run(new frm_rpt_coating_consumption());
			//Application.Run(new frm_rpt_coating_Bgrade());
			//Application.Run(new frm_rpt_coating_wastage());
			//Application.Run(new frm_rpt_coating_output_detail());
			//Application.Run(new frm_rpt_coating_output_detail_jo());			
			//Application.Run(new frm_rpt_coating_local());
			//Application.Run(new frm_rpt_coating_check_saleorder());	
			//Application.Run(new frm_rpt_coating_check_jrshipmark());			
								
		}
		
	}
}
