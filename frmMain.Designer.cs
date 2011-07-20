namespace Groove_Down
{
	partial class frmMain
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
			this.tbQuery = new System.Windows.Forms.TextBox();
			this.btnSettings = new System.Windows.Forms.Button();
			this.btnDownloadQueue = new System.Windows.Forms.Button();
			this.btnSearch = new System.Windows.Forms.Button();
			this.splSongs = new System.Windows.Forms.SplitContainer();
			this.results = new Groove_Down.Results();
			this.dq = new Groove_Down.DownloadQueue();
			this.logger = new Groove_Down.Logger();
			((System.ComponentModel.ISupportInitialize)(this.splSongs)).BeginInit();
			this.splSongs.Panel1.SuspendLayout();
			this.splSongs.Panel2.SuspendLayout();
			this.splSongs.SuspendLayout();
			this.SuspendLayout();
			// 
			// tbQuery
			// 
			this.tbQuery.Location = new System.Drawing.Point(4, 13);
			this.tbQuery.Name = "tbQuery";
			this.tbQuery.Size = new System.Drawing.Size(353, 20);
			this.tbQuery.TabIndex = 0;
			this.tbQuery.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbQuery_KeyDown);
			// 
			// btnSettings
			// 
			this.btnSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnSettings.Location = new System.Drawing.Point(648, 2);
			this.btnSettings.Name = "btnSettings";
			this.btnSettings.Size = new System.Drawing.Size(75, 23);
			this.btnSettings.TabIndex = 2;
			this.btnSettings.Text = "&Settings";
			this.btnSettings.UseVisualStyleBackColor = true;
			this.btnSettings.Click += new System.EventHandler(this.btnSettings_Click);
			// 
			// btnDownloadQueue
			// 
			this.btnDownloadQueue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnDownloadQueue.Location = new System.Drawing.Point(620, 31);
			this.btnDownloadQueue.Name = "btnDownloadQueue";
			this.btnDownloadQueue.Size = new System.Drawing.Size(103, 23);
			this.btnDownloadQueue.TabIndex = 3;
			this.btnDownloadQueue.Text = "&Download";
			this.btnDownloadQueue.UseVisualStyleBackColor = true;
			this.btnDownloadQueue.Click += new System.EventHandler(this.btnDownloadQueue_Click);
			// 
			// btnSearch
			// 
			this.btnSearch.AutoSize = true;
			this.btnSearch.Location = new System.Drawing.Point(363, 10);
			this.btnSearch.Name = "btnSearch";
			this.btnSearch.Size = new System.Drawing.Size(75, 23);
			this.btnSearch.TabIndex = 1;
			this.btnSearch.Text = "Search";
			this.btnSearch.UseVisualStyleBackColor = true;
			this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
			// 
			// splSongs
			// 
			this.splSongs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.splSongs.BackColor = System.Drawing.SystemColors.ControlLight;
			this.splSongs.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.splSongs.Location = new System.Drawing.Point(4, 60);
			this.splSongs.Name = "splSongs";
			// 
			// splSongs.Panel1
			// 
			this.splSongs.Panel1.Controls.Add(this.results);
			// 
			// splSongs.Panel2
			// 
			this.splSongs.Panel2.Controls.Add(this.dq);
			this.splSongs.Size = new System.Drawing.Size(719, 305);
			this.splSongs.SplitterDistance = 366;
			this.splSongs.TabIndex = 7;
			this.splSongs.TabStop = false;
			// 
			// results
			// 
			this.results.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.results.Location = new System.Drawing.Point(-1, -1);
			this.results.Name = "results";
			this.results.Size = new System.Drawing.Size(366, 310);
			this.results.TabIndex = 6;
			this.results.TabStop = false;
			this.results.SongChange += new Groove_Down.SongChange(this.results_SongChange);
			// 
			// dq
			// 
			this.dq.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.dq.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.dq.BackColor = System.Drawing.SystemColors.Control;
			this.dq.Location = new System.Drawing.Point(1, 0);
			this.dq.Name = "dq";
			this.dq.Size = new System.Drawing.Size(347, 304);
			this.dq.TabIndex = 5;
			this.dq.SongChange += new Groove_Down.SongChange(this.dq_SongChange);
			// 
			// logger
			// 
			this.logger.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.logger.AutoScroll = true;
			this.logger.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.logger.Location = new System.Drawing.Point(4, 371);
			this.logger.Name = "logger";
			this.logger.Size = new System.Drawing.Size(719, 21);
			this.logger.TabIndex = 5;
			this.logger.TabStop = false;
			// 
			// frmMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(727, 398);
			this.Controls.Add(this.splSongs);
			this.Controls.Add(this.btnSearch);
			this.Controls.Add(this.btnDownloadQueue);
			this.Controls.Add(this.btnSettings);
			this.Controls.Add(this.tbQuery);
			this.Controls.Add(this.logger);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MinimumSize = new System.Drawing.Size(737, 430);
			this.Name = "frmMain";
			this.Text = "Groove Down";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmMain_FormClosed);
			this.splSongs.Panel1.ResumeLayout(false);
			this.splSongs.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splSongs)).EndInit();
			this.splSongs.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private Logger logger;		
		private Results results;
		private System.Windows.Forms.TextBox tbQuery;
		private System.Windows.Forms.Button btnSettings;
		private System.Windows.Forms.Button btnDownloadQueue;
		private DownloadQueue dq;
		private System.Windows.Forms.Button btnSearch;
		private System.Windows.Forms.SplitContainer splSongs;
	}
}

