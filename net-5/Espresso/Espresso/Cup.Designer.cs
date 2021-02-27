
namespace Espresso
{
	partial class Cup
	{
		private readonly bool showForm = false;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

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
            this.exitMenuItem});
			this.trayContextMenu.Name = "trayContextMenu";
			this.trayContextMenu.Size = new System.Drawing.Size(126, 80);
			// 
			// toggleMenuItem
			// 
			this.toggleMenuItem.Name = "toggleMenuItem";
			this.toggleMenuItem.Size = new System.Drawing.Size(125, 38);
			// 
			// exitMenuItem
			// 
			this.exitMenuItem.Name = "exitMenuItem";
			this.exitMenuItem.Size = new System.Drawing.Size(125, 38);
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
	}
}