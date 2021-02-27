/*
 *	Project: Espresso
 *	Author(s): Lorenzo Billi
 *	
 *	
 *	The MIT License
 *	
 *	Copyright (c) 2018-2021 Lorenzo Billi
 *	
 *	Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated
 *	documentation files (the "Software"), to deal in the Software without restriction, including without limitation
 *	the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and
 *	to permit persons to whom the Software is furnished to do so, subject to the following conditions:
 *	
 *	The above copyright notice and this permission notice shall be included in all copies or substantial portions
 *	of the Software.
 *	
 *	THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO
 *	THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND	NONINFRINGEMENT. IN NO EVENT SHALL THE
 *	AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF
 *	CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS
 *	IN THE SOFTWARE.
 *	
 *	
 *	Espresso/Espresso/Cup.cs
 *	
 */

using System.Drawing;
using System.Windows.Forms;

namespace Espresso
{
	/// <summary>
	/// Main form class of the application, representing the tray icon and all associated items.
	/// </summary>
	public partial class Cup : Form
	{
		/// <summary>
		/// Determines the size of the tray icon.
		/// </summary>
		private static readonly Size TRAY_ICON_SIZE = new(256, 256);

		/// <summary>
		/// Icon used when the application is in the disabled state.
		/// </summary>
		private readonly Icon disabledIcon = new(Icons.disabled, TRAY_ICON_SIZE);

		/// <summary>
		/// Icon used when the application is in the enabled state.
		/// </summary>
		private readonly Icon enabledIcon = new(Icons.enabled, TRAY_ICON_SIZE);

		/// <summary>
		/// Spawns the tray icon and associates the main events to the corresponding actions.
		/// </summary>
		public Cup()
		{
			InitializeComponent();

			trayIcon.Icon = disabledIcon;
			trayIcon.MouseDown += (sender, e) => FilterMouseInput(sender, e);

			toggleMenuItem.Text = "Enable";
			toggleMenuItem.Click += (sender, e) => SetState();

			exitMenuItem.Click += (sender, e) => Exit();
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

		/// <summary>
		/// Makes sure that the application is set to disabled states, then closes the application.
		/// </summary>
		private void Exit()
		{
			if (Coffee.IsActive)
			{
				Coffee.Deactivate();
			}

			trayIcon.Visible = false;
			trayIcon.Dispose();
			Close();
			Application.Exit();
		}
	}
}
