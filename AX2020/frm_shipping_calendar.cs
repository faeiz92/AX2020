using System;
using System.Drawing;
using System.Windows.Forms;
using Calendar.NET;

namespace AX2020
{
	/// <summary>
	/// Description of frm_shipping_calendar.
	/// </summary>
	public partial class frm_shipping_calendar : Form
	{
		public frm_shipping_calendar()
		{
			
			InitializeComponent();
			calendar1.CalendarDate = DateTime.Now;
        	calendar1.CalendarView = CalendarViews.Month;
        	
			
		}
	}
}
