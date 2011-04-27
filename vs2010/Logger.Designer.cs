namespace Groove_Down
{
	partial class Logger
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

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.lblLog = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// lblLog
			// 
			this.lblLog.AutoSize = true;
			this.lblLog.Location = new System.Drawing.Point(3, 3);
			this.lblLog.Name = "lblLog";
			this.lblLog.Size = new System.Drawing.Size(0, 13);
			this.lblLog.TabIndex = 0;
			// 
			// Logger
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = false;
			this.Controls.Add(this.lblLog);
			this.Name = "Logger";
			this.Size = new System.Drawing.Size(708, 22);
			this.ResumeLayout(false);			
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label lblLog;





	}
}
