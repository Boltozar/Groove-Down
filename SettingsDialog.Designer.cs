namespace Groove_Down
{
	partial class frmSettingsDialog
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
			this.btnOK = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.fbdBaseDownloadDirectory = new System.Windows.Forms.FolderBrowserDialog();
			this.gpbMaxConConnects = new System.Windows.Forms.GroupBox();
			this.lblConnectsTip = new System.Windows.Forms.Label();
			this.trkbConnects = new System.Windows.Forms.TrackBar();
			this.gpbBaseDownloadDir = new System.Windows.Forms.GroupBox();
			this.btnBaseDownloadDirectorySelect = new System.Windows.Forms.Button();
			this.tbBaseDownloadDirectory = new System.Windows.Forms.TextBox();
			this.gpbDownloadNameFormat = new System.Windows.Forms.GroupBox();
			this.rtbDownloadFileNameFormatHelp = new System.Windows.Forms.RichTextBox();
			this.lblDownloadFileNameExample = new System.Windows.Forms.Label();
			this.tbDownloadFileNameFormat = new System.Windows.Forms.TextBox();
			this.gpbMaxConConnects.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.trkbConnects)).BeginInit();
			this.gpbBaseDownloadDir.SuspendLayout();
			this.gpbDownloadNameFormat.SuspendLayout();
			this.SuspendLayout();
			// 
			// btnOK
			// 
			this.btnOK.Location = new System.Drawing.Point(12, 310);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(75, 21);
			this.btnOK.TabIndex = 4;
			this.btnOK.Text = "OK";
			this.btnOK.UseVisualStyleBackColor = true;
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(460, 310);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(75, 21);
			this.btnCancel.TabIndex = 5;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			// 
			// gpbMaxConConnects
			// 
			this.gpbMaxConConnects.Controls.Add(this.lblConnectsTip);
			this.gpbMaxConConnects.Controls.Add(this.trkbConnects);
			this.gpbMaxConConnects.Location = new System.Drawing.Point(12, 10);
			this.gpbMaxConConnects.Name = "gpbMaxConConnects";
			this.gpbMaxConConnects.Size = new System.Drawing.Size(275, 62);
			this.gpbMaxConConnects.TabIndex = 7;
			this.gpbMaxConConnects.TabStop = false;
			this.gpbMaxConConnects.Text = "Maximum Concurrent Connections";
			// 
			// lblConnectsTip
			// 
			this.lblConnectsTip.AutoSize = true;
			this.lblConnectsTip.Location = new System.Drawing.Point(115, 26);
			this.lblConnectsTip.Name = "lblConnectsTip";
			this.lblConnectsTip.Size = new System.Drawing.Size(13, 13);
			this.lblConnectsTip.TabIndex = 4;
			this.lblConnectsTip.Text = "1";
			this.lblConnectsTip.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// trkbConnects
			// 
			this.trkbConnects.Location = new System.Drawing.Point(5, 14);
			this.trkbConnects.Maximum = 5;
			this.trkbConnects.Minimum = 1;
			this.trkbConnects.Name = "trkbConnects";
			this.trkbConnects.Size = new System.Drawing.Size(104, 45);
			this.trkbConnects.TabIndex = 3;
			this.trkbConnects.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
			this.trkbConnects.Value = 1;
			this.trkbConnects.Scroll += new System.EventHandler(this.trkbConnects_Scroll);
			// 
			// gpbBaseDownloadDir
			// 
			this.gpbBaseDownloadDir.Controls.Add(this.btnBaseDownloadDirectorySelect);
			this.gpbBaseDownloadDir.Controls.Add(this.tbBaseDownloadDirectory);
			this.gpbBaseDownloadDir.Location = new System.Drawing.Point(12, 78);
			this.gpbBaseDownloadDir.Name = "gpbBaseDownloadDir";
			this.gpbBaseDownloadDir.Size = new System.Drawing.Size(524, 57);
			this.gpbBaseDownloadDir.TabIndex = 8;
			this.gpbBaseDownloadDir.TabStop = false;
			this.gpbBaseDownloadDir.Text = "Base Download Directory";
			// 
			// btnBaseDownloadDirectorySelect
			// 
			this.btnBaseDownloadDirectorySelect.Location = new System.Drawing.Point(412, 24);
			this.btnBaseDownloadDirectorySelect.Name = "btnBaseDownloadDirectorySelect";
			this.btnBaseDownloadDirectorySelect.Size = new System.Drawing.Size(107, 23);
			this.btnBaseDownloadDirectorySelect.TabIndex = 4;
			this.btnBaseDownloadDirectorySelect.Text = "Select Directory";
			this.btnBaseDownloadDirectorySelect.UseVisualStyleBackColor = true;
			this.btnBaseDownloadDirectorySelect.Click += new System.EventHandler(this.btnBaseDownloadDirectorySelect_Click);
			// 
			// tbBaseDownloadDirectory
			// 
			this.tbBaseDownloadDirectory.Location = new System.Drawing.Point(7, 27);
			this.tbBaseDownloadDirectory.Name = "tbBaseDownloadDirectory";
			this.tbBaseDownloadDirectory.Size = new System.Drawing.Size(399, 20);
			this.tbBaseDownloadDirectory.TabIndex = 3;
			// 
			// gpbDownloadNameFormat
			// 
			this.gpbDownloadNameFormat.Controls.Add(this.rtbDownloadFileNameFormatHelp);
			this.gpbDownloadNameFormat.Controls.Add(this.lblDownloadFileNameExample);
			this.gpbDownloadNameFormat.Controls.Add(this.tbDownloadFileNameFormat);
			this.gpbDownloadNameFormat.Location = new System.Drawing.Point(12, 141);
			this.gpbDownloadNameFormat.Name = "gpbDownloadNameFormat";
			this.gpbDownloadNameFormat.Size = new System.Drawing.Size(523, 163);
			this.gpbDownloadNameFormat.TabIndex = 9;
			this.gpbDownloadNameFormat.TabStop = false;
			this.gpbDownloadNameFormat.Text = "Download Filename Format";
			// 
			// rtbDownloadFileNameFormatHelp
			// 
			this.rtbDownloadFileNameFormatHelp.BackColor = System.Drawing.SystemColors.Control;
			this.rtbDownloadFileNameFormatHelp.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.rtbDownloadFileNameFormatHelp.Cursor = System.Windows.Forms.Cursors.Arrow;
			this.rtbDownloadFileNameFormatHelp.Enabled = false;
			this.rtbDownloadFileNameFormatHelp.Location = new System.Drawing.Point(7, 77);
			this.rtbDownloadFileNameFormatHelp.Name = "rtbDownloadFileNameFormatHelp";
			this.rtbDownloadFileNameFormatHelp.ReadOnly = true;
			this.rtbDownloadFileNameFormatHelp.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
			this.rtbDownloadFileNameFormatHelp.Size = new System.Drawing.Size(420, 81);
			this.rtbDownloadFileNameFormatHelp.TabIndex = 9;
			this.rtbDownloadFileNameFormatHelp.Text = "Variables:\t\t\t\tYou can create subdirectories by using slashes\nArtist\t%artist%\tInfe" +
				"cted Mushroom\t\t\nAlbum\t%album%\tVicious Delicious\nSong\t%song%\tHeavyweight\nYear\t%ye" +
				"ar%\t2008\nTrack\t%track%\t4";
			// 
			// lblDownloadFileNameExample
			// 
			this.lblDownloadFileNameExample.AutoSize = true;
			this.lblDownloadFileNameExample.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblDownloadFileNameExample.Location = new System.Drawing.Point(8, 51);
			this.lblDownloadFileNameExample.Name = "lblDownloadFileNameExample";
			this.lblDownloadFileNameExample.Size = new System.Drawing.Size(85, 13);
			this.lblDownloadFileNameExample.TabIndex = 8;
			this.lblDownloadFileNameExample.Text = "Output Example:";
			// 
			// tbDownloadFileNameFormat
			// 
			this.tbDownloadFileNameFormat.Location = new System.Drawing.Point(11, 19);
			this.tbDownloadFileNameFormat.Name = "tbDownloadFileNameFormat";
			this.tbDownloadFileNameFormat.Size = new System.Drawing.Size(395, 20);
			this.tbDownloadFileNameFormat.TabIndex = 7;
			this.tbDownloadFileNameFormat.TextChanged += new System.EventHandler(this.tbDownloadFileNameFormat_TextChanged);
			// 
			// frmSettingsDialog
			// 
			this.AcceptButton = this.btnOK;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(548, 341);
			this.Controls.Add(this.gpbDownloadNameFormat);
			this.Controls.Add(this.gpbBaseDownloadDir);
			this.Controls.Add(this.gpbMaxConConnects);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnOK);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Name = "frmSettingsDialog";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Settings";
			this.Load += new System.EventHandler(this.frmSettingsDialog_Load);
			this.gpbMaxConConnects.ResumeLayout(false);
			this.gpbMaxConConnects.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.trkbConnects)).EndInit();
			this.gpbBaseDownloadDir.ResumeLayout(false);
			this.gpbBaseDownloadDir.PerformLayout();
			this.gpbDownloadNameFormat.ResumeLayout(false);
			this.gpbDownloadNameFormat.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.FolderBrowserDialog fbdBaseDownloadDirectory;
		private System.Windows.Forms.GroupBox gpbMaxConConnects;
		private System.Windows.Forms.Label lblConnectsTip;
		private System.Windows.Forms.TrackBar trkbConnects;
		private System.Windows.Forms.GroupBox gpbBaseDownloadDir;
		private System.Windows.Forms.Button btnBaseDownloadDirectorySelect;
		private System.Windows.Forms.TextBox tbBaseDownloadDirectory;
		private System.Windows.Forms.GroupBox gpbDownloadNameFormat;
		private System.Windows.Forms.RichTextBox rtbDownloadFileNameFormatHelp;
		private System.Windows.Forms.Label lblDownloadFileNameExample;
		private System.Windows.Forms.TextBox tbDownloadFileNameFormat;
	}
}