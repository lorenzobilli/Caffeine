
namespace Espresso
{
	partial class Settings
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Settings));
			this.checkBoxEnableOnAppStartup = new System.Windows.Forms.CheckBox();
			this.SuspendLayout();
			// 
			// checkBoxEnableOnAppStartup
			// 
			this.checkBoxEnableOnAppStartup.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.checkBoxEnableOnAppStartup.AutoSize = true;
			this.checkBoxEnableOnAppStartup.Location = new System.Drawing.Point(53, 62);
			this.checkBoxEnableOnAppStartup.Name = "checkBoxEnableOnAppStartup";
			this.checkBoxEnableOnAppStartup.Size = new System.Drawing.Size(357, 36);
			this.checkBoxEnableOnAppStartup.TabIndex = 0;
			this.checkBoxEnableOnAppStartup.Text = "Enable on application startup";
			this.checkBoxEnableOnAppStartup.UseVisualStyleBackColor = true;
			// 
			// Settings
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 32F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.checkBoxEnableOnAppStartup);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "Settings";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Settings";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.CheckBox checkBoxEnableOnAppStartup;
	}
}