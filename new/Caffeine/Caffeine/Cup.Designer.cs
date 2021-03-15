/*
 *	Project: Caffeine
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
 *	Caffeine/Caffeine/Cup.Designer.cs
 *	
 */

namespace Caffeine
{
	/// <summary>
	/// Underlining code of the designer Cup class
	/// </summary>
	partial class Cup
	{
		/// <summary>
		/// Determines if the (dummy) main form shall be visible.
		/// </summary>
		private readonly bool showForm = false;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Hides or shows the (dummy) main form. By defaults, it hides the form on application startup.
		/// </summary>
		/// <param name="value">True if the form shall be visible, false if not.</param>
		protected override void SetVisibleCore(bool value) => base.SetVisibleCore(showForm ? value : showForm);

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.trayIcon = new System.Windows.Forms.NotifyIcon(this.components);
			this.trayContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.toggleMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.settingsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.exitMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.trayContextMenu.SuspendLayout();
			this.SuspendLayout();
			// 
			// trayIcon
			// 
			this.trayIcon.ContextMenuStrip = this.trayContextMenu;
			this.trayIcon.Visible = true;
			// 
			// trayContextMenu
			// 
			this.trayContextMenu.ImageScalingSize = new System.Drawing.Size(32, 32);
			this.trayContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toggleMenuItem,
            this.settingsMenuItem,
            this.exitMenuItem});
			this.trayContextMenu.Name = "trayContextMenu";
			this.trayContextMenu.Size = new System.Drawing.Size(175, 118);
			// 
			// toggleMenuItem
			// 
			this.toggleMenuItem.Name = "toggleMenuItem";
			this.toggleMenuItem.Size = new System.Drawing.Size(174, 38);
			// 
			// settingsMenuItem
			// 
			this.settingsMenuItem.Name = "settingsMenuItem";
			this.settingsMenuItem.Size = new System.Drawing.Size(174, 38);
			this.settingsMenuItem.Text = "Settings";
			// 
			// exitMenuItem
			// 
			this.exitMenuItem.Name = "exitMenuItem";
			this.exitMenuItem.Size = new System.Drawing.Size(174, 38);
			this.exitMenuItem.Text = "Exit";
			// 
			// Cup
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 32F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Name = "Cup";
			this.Text = "Cup";
			this.trayContextMenu.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.NotifyIcon trayIcon;
		private System.Windows.Forms.ContextMenuStrip trayContextMenu;
		private System.Windows.Forms.ToolStripMenuItem toggleMenuItem;
		private System.Windows.Forms.ToolStripMenuItem exitMenuItem;
		private System.Windows.Forms.ToolStripMenuItem settingsMenuItem;
	}
}