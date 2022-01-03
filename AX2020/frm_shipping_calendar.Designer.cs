/*
 * Created by SharpDevelop.
 * User: ax2020-1
 * Date: 2/17/2017
 * Time: 4:26 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace AX2020
{
	partial class frm_shipping_calendar
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
			this.calendar1 = new Calendar.NET.Calendar();
			this.SuspendLayout();
			// 
			// calendar1
			// 
			this.calendar1.AllowEditingEvents = true;
			this.calendar1.CalendarDate = new System.DateTime(2017, 2, 17, 16, 36, 45, 184);
			this.calendar1.CalendarView = Calendar.NET.CalendarViews.Month;
			this.calendar1.DateHeaderFont = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
			this.calendar1.DayOfWeekFont = new System.Drawing.Font("Arial", 10F);
			this.calendar1.DaysFont = new System.Drawing.Font("Arial", 10F);
			this.calendar1.DayViewTimeFont = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
			this.calendar1.DimDisabledEvents = true;
			this.calendar1.HighlightCurrentDay = true;
			this.calendar1.LoadPresetHolidays = true;
			this.calendar1.Location = new System.Drawing.Point(29, 96);
			this.calendar1.Name = "calendar1";
			this.calendar1.ShowArrowControls = true;
			this.calendar1.ShowDashedBorderOnDisabledEvents = true;
			this.calendar1.ShowDateInHeader = true;
			this.calendar1.ShowDisabledEvents = false;
			this.calendar1.ShowEventTooltips = true;
			this.calendar1.ShowTodayButton = true;
			this.calendar1.Size = new System.Drawing.Size(933, 541);
			this.calendar1.TabIndex = 0;
			this.calendar1.TodayFont = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
			// 
			// frm_shipping_calendar
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(984, 662);
			this.Controls.Add(this.calendar1);
			this.Name = "frm_shipping_calendar";
			this.Text = "frm_shipping_calendar";
			this.ResumeLayout(false);
		}
		private Calendar.NET.Calendar calendar1;
	}
}
