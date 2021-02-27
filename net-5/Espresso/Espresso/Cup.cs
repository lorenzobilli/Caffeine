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
	public partial class Cup : Form
	{
		private static readonly Size TRAY_ICON_SIZE = new(256, 256);

		private Icon disabledIcon = new(Icons.disabled, TRAY_ICON_SIZE);

		private Icon enabledIcon = new(Icons.enabled, TRAY_ICON_SIZE);

		public Cup()
		{
			InitializeComponent();

			trayIcon.Icon = disabledIcon;
		}
	}
}
