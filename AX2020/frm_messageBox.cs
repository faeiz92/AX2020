using System;
using System.Drawing;
using System.Windows.Forms;

namespace AX2020
{
	
	public partial class frm_messageBox : Form
	{
		public frm_messageBox()
		{
			
			InitializeComponent();
			
		}
		
		void Button1Click(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}
