/*
 *	Project: Espresso
 *	Author(s): Lorenzo Billi
 *	
 *	
 *	The MIT License
 *	
 *	Copyright (c) 2018-2019 Lorenzo Billi
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
 *	Espresso/Espresso.WPF/MainWindow.xaml.cs
 *	
 */
 
using System.Drawing;
using System.Windows;
using System.Windows.Forms;

namespace Espresso.WPF
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		/// <summary>
		/// Icon used by the system tray icon to tell the user that the application is in the disabled state.
		/// </summary>
		private readonly Icon _disabledIcon = new Icon(
			Properties.Resources.disabled, new System.Drawing.Size(256, 256)
		);

		/// <summary>
		/// Icon used by the system tray icon to tell the user that the application is in the enabled state.
		/// </summary>
		private readonly Icon _enabledIcon = new Icon(
			Properties.Resources.enabled, new System.Drawing.Size(256, 256)
		);

		/// <summary>
		/// Application's system tray icon.
		/// </summary>
		private NotifyIcon _trayIcon = new NotifyIcon();

		/// <summary>
		/// System tray icon's context menu.
		/// </summary>
		private ContextMenu _trayContextMenu = new ContextMenu();

		/// <summary>
		/// Context menu's item handling enable and disable states.
		/// </summary>
		private MenuItem _toggleItem = new MenuItem();

		/// <summary>
		/// Context menu's item handling application exit.
		/// </summary>
		private MenuItem _exitItem = new MenuItem();

		/// <summary>
		/// Hides the main application's window and initializes the application's system tray icon.
		/// </summary>
		public MainWindow()
		{
			InitializeComponent();
			Hide();

			ConfigureContextMenu();
			SpawnTrayIcon();
		}

		/// <summary>
		/// Configures tray icon's context menu options.
		/// </summary>
		private void ConfigureContextMenu()
		{
			_toggleItem.Index = 0;
			_toggleItem.Text = "Enable";
			_toggleItem.Click += (sender, e) => SetState();

			_exitItem.Index = 1;
			_exitItem.Text = "Exit";
			_exitItem.Click += (sender, e) => CloseApp();

			_trayContextMenu.MenuItems.AddRange(new MenuItem[] { _toggleItem, _exitItem });
		}

		/// <summary>
		/// Creates the application's system tray icon and makes it visible.
		/// </summary>
		private void SpawnTrayIcon()
		{
			_trayIcon.Icon = _disabledIcon;
			_trayIcon.ContextMenu = _trayContextMenu;
			_trayIcon.MouseDown += (sender, e) => FilterMouseInput(sender, e);
			_trayIcon.Visible = true;
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
		/// Toggles between enabled and disabled application states.
		/// </summary>
		private void SetState()
		{
			if (App.coffee.IsActive)
			{
				if (App.coffee.Deactivate())
				{
					_trayIcon.Icon = _disabledIcon;
					_toggleItem.Text = "Enable";
				}
			} 
			else
			{
				if (App.coffee.Activate())
				{
					_trayIcon.Icon = _enabledIcon;
					_toggleItem.Text = "Disable";
				}
			}
		}

		/// <summary>
		/// Makes sure that the application is set to disabled states, then closes the application.
		/// </summary>
		private void CloseApp()
		{
			if (App.coffee.IsActive)
			{
				App.coffee.Deactivate();
			}
			_trayIcon.Visible = false;
			_trayIcon.Dispose();
			Close();
		}
	}
}
