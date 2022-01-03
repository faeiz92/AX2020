/*
 * Created by SharpDevelop.
 * User: ax2020-1
 * Date: 2/17/2017
 * Time: 5:50 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace AX2020
{
	partial class frm_shipping_calendar_detail
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			System.Windows.Forms.Calendar.CalendarHighlightRange calendarHighlightRange1 = new System.Windows.Forms.Calendar.CalendarHighlightRange();
			System.Windows.Forms.Calendar.CalendarHighlightRange calendarHighlightRange2 = new System.Windows.Forms.Calendar.CalendarHighlightRange();
			System.Windows.Forms.Calendar.CalendarHighlightRange calendarHighlightRange3 = new System.Windows.Forms.Calendar.CalendarHighlightRange();
			System.Windows.Forms.Calendar.CalendarHighlightRange calendarHighlightRange4 = new System.Windows.Forms.Calendar.CalendarHighlightRange();
			System.Windows.Forms.Calendar.CalendarHighlightRange calendarHighlightRange5 = new System.Windows.Forms.Calendar.CalendarHighlightRange();
			this.calendar1 = new System.Windows.Forms.Calendar.Calendar();
			this.monthView1 = new System.Windows.Forms.Calendar.MonthView();
			this.SuspendLayout();
			// 
			// calendar1
			// 
			this.calendar1.Font = new System.Drawing.Font("Segoe UI", 9F);
			calendarHighlightRange1.DayOfWeek = System.DayOfWeek.Monday;
			calendarHighlightRange1.EndTime = System.TimeSpan.Parse("17:00:00");
			calendarHighlightRange1.StartTime = System.TimeSpan.Parse("08:00:00");
			calendarHighlightRange2.DayOfWeek = System.DayOfWeek.Tuesday;
			calendarHighlightRange2.EndTime = System.TimeSpan.Parse("17:00:00");
			calendarHighlightRange2.StartTime = System.TimeSpan.Parse("08:00:00");
			calendarHighlightRange3.DayOfWeek = System.DayOfWeek.Wednesday;
			calendarHighlightRange3.EndTime = System.TimeSpan.Parse("17:00:00");
			calendarHighlightRange3.StartTime = System.TimeSpan.Parse("08:00:00");
			calendarHighlightRange4.DayOfWeek = System.DayOfWeek.Thursday;
			calendarHighlightRange4.EndTime = System.TimeSpan.Parse("17:00:00");
			calendarHighlightRange4.StartTime = System.TimeSpan.Parse("08:00:00");
			calendarHighlightRange5.DayOfWeek = System.DayOfWeek.Friday;
			calendarHighlightRange5.EndTime = System.TimeSpan.Parse("17:00:00");
			calendarHighlightRange5.StartTime = System.TimeSpan.Parse("08:00:00");
			this.calendar1.HighlightRanges = new System.Windows.Forms.Calendar.CalendarHighlightRange[] {
						calendarHighlightRange1,
						calendarHighlightRange2,
						calendarHighlightRange3,
						calendarHighlightRange4,
						calendarHighlightRange5};
			this.calendar1.Location = new System.Drawing.Point(224, 34);
			this.calendar1.Name = "calendar1";
			this.calendar1.Size = new System.Drawing.Size(673, 507);
			this.calendar1.TabIndex = 0;
			this.calendar1.Text = "calendar1";
			// 
			// monthView1
			// 
			this.monthView1.ArrowsColor = System.Drawing.SystemColors.Window;
			this.monthView1.ArrowsSelectedColor = System.Drawing.Color.Gold;
			this.monthView1.DayBackgroundColor = System.Drawing.Color.Empty;
			this.monthView1.DayGrayedText = System.Drawing.SystemColors.GrayText;
			this.monthView1.DaySelectedBackgroundColor = System.Drawing.SystemColors.Highlight;
			this.monthView1.DaySelectedColor = System.Drawing.SystemColors.WindowText;
			this.monthView1.DaySelectedTextColor = System.Drawing.SystemColors.HighlightText;
			this.monthView1.ItemPadding = new System.Windows.Forms.Padding(2);
			this.monthView1.Location = new System.Drawing.Point(1, 34);
			this.monthView1.MonthTitleColor = System.Drawing.SystemColors.ActiveCaption;
			this.monthView1.MonthTitleColorInactive = System.Drawing.SystemColors.InactiveCaption;
			this.monthView1.MonthTitleTextColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.monthView1.MonthTitleTextColorInactive = System.Drawing.SystemColors.InactiveCaptionText;
			this.monthView1.Name = "monthView1";
			this.monthView1.Size = new System.Drawing.Size(217, 507);
			this.monthView1.TabIndex = 1;
			this.monthView1.Text = "monthView1";
			this.monthView1.TodayBorderColor = System.Drawing.Color.Maroon;
			// 
			// frm_shipping_calendar_detail
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(984, 662);
			this.Controls.Add(this.monthView1);
			this.Controls.Add(this.calendar1);
			this.Name = "frm_shipping_calendar_detail";
			this.Text = "frm_shipping_calendar_detail";
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.Calendar.MonthView monthView1;
		private System.Windows.Forms.Calendar.Calendar calendar1;
	}
}
