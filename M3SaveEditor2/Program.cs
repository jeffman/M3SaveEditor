using System;
using System.Windows.Forms;

namespace M3SaveEditor2;

internal static class Program
{
	[STAThread]
	private static void Main()
	{
		Application.EnableVisualStyles();
		Application.SetCompatibleTextRenderingDefault(defaultValue: false);
		Application.Run(new frmMain());
	}
}
