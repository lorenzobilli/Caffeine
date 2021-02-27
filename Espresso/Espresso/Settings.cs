using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Espresso
{
	public partial class Settings : Form
	{
		public Settings()
		{
			InitializeComponent();

			checkBoxEnableOnAppStartup.Checked = Properties.Settings.Default.EnableOnAppStartup;
			checkBoxEnableOnAppStartup.CheckedChanged += (sender, e) => HandleEnableOnStartupPreference();
		}

		private void HandleEnableOnStartupPreference()
		{
			Properties.Settings.Default.EnableOnAppStartup = checkBoxEnableOnAppStartup.Checked;
			Properties.Settings.Default.Save();
		}
	}
}
