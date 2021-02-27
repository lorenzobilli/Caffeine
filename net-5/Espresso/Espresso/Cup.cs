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

		private readonly Icon disabledIcon = new(Icons.disabled, TRAY_ICON_SIZE);

		private readonly Icon enabledIcon = new(Icons.enabled, TRAY_ICON_SIZE);

		public Cup()
		{
			InitializeComponent();

			trayIcon.Icon = disabledIcon;
			trayIcon.MouseDown += (sender, e) => FilterMouseInput(sender, e);

			toggleMenuItem.Text = "Enable";
		}

		/// <summary>
		/// Toggles between enabled and disabled application states.
		/// </summary>
		private void SetState()
		{
			if (Coffee.IsActive)
			{
				if (Coffee.Deactivate())
				{
					trayIcon.Icon = disabledIcon;
					toggleMenuItem.Text = "Enable";
				}
			}
			else
			{
				if (Coffee.Activate())
				{
					trayIcon.Icon = enabledIcon;
					toggleMenuItem.Text = "Disable";
				}
			}
		}

		/// <summary>
		/// Filters user mouse input, distinguishing between left and right click.
		/// SetState() must be called only with a left mouse click.
		/// </summary>
		private void FilterMouseInput(object sender, MouseEventArgs e)
		{
			if (e.Button.Equals(MouseButtons.Left))
			{
				SetState();
			}
		}
	}
}
