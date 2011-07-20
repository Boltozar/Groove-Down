namespace Groove_Down
{
	partial class DownloadQueue
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
			this.dgvQueue = new System.Windows.Forms.DataGridView();
			this.clmnRemove = new System.Windows.Forms.DataGridViewButtonColumn();
			this.clmnArtist = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.clmnAlbum = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.clmnSong = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.clmnSongID = new System.Windows.Forms.DataGridViewTextBoxColumn();
			((System.ComponentModel.ISupportInitialize)(this.dgvQueue)).BeginInit();
			this.SuspendLayout();
			// 
			// dgvQueue
			// 
			this.dgvQueue.AllowUserToAddRows = false;
			this.dgvQueue.AllowUserToDeleteRows = false;
			this.dgvQueue.AllowUserToResizeRows = false;
			this.dgvQueue.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.dgvQueue.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.dgvQueue.BackgroundColor = System.Drawing.Color.Gainsboro;
			this.dgvQueue.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.dgvQueue.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
			this.dgvQueue.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvQueue.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmnRemove,
            this.clmnArtist,
            this.clmnAlbum,
            this.clmnSong,
            this.clmnSongID});
			this.dgvQueue.Location = new System.Drawing.Point(0, 0);
			this.dgvQueue.Name = "dgvQueue";
			this.dgvQueue.ReadOnly = true;
			this.dgvQueue.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
			this.dgvQueue.RowHeadersVisible = false;
			this.dgvQueue.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
			this.dgvQueue.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dgvQueue.ShowEditingIcon = false;
			this.dgvQueue.Size = new System.Drawing.Size(400, 320);
			this.dgvQueue.TabIndex = 1;
			this.dgvQueue.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvQueue_CellContentClick);
			this.dgvQueue.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvQueue_CellMouseClick);
			// 
			// clmnRemove
			// 
			this.clmnRemove.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
			this.clmnRemove.FillWeight = 5F;
			this.clmnRemove.HeaderText = "Remove";
			this.clmnRemove.MinimumWidth = 50;
			this.clmnRemove.Name = "clmnRemove";
			this.clmnRemove.ReadOnly = true;
			this.clmnRemove.UseColumnTextForButtonValue = true;
			this.clmnRemove.Width = 88;
			// 
			// clmnArtist
			// 
			this.clmnArtist.HeaderText = "Artist";
			this.clmnArtist.Name = "clmnArtist";
			this.clmnArtist.ReadOnly = true;
			// 
			// clmnAlbum
			// 
			this.clmnAlbum.HeaderText = "Album";
			this.clmnAlbum.Name = "clmnAlbum";
			this.clmnAlbum.ReadOnly = true;
			// 
			// clmnSong
			// 
			this.clmnSong.HeaderText = "Song";
			this.clmnSong.Name = "clmnSong";
			this.clmnSong.ReadOnly = true;
			// 
			// clmnSongID
			// 
			this.clmnSongID.HeaderText = "Song ID";
			this.clmnSongID.Name = "clmnSongID";
			this.clmnSongID.ReadOnly = true;
			this.clmnSongID.Visible = false;
			// 
			// DownloadQueue
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.BackColor = System.Drawing.SystemColors.Control;
			this.Controls.Add(this.dgvQueue);
			this.Name = "DownloadQueue";
			this.Size = new System.Drawing.Size(400, 320);
			((System.ComponentModel.ISupportInitialize)(this.dgvQueue)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.DataGridView dgvQueue;
		private System.Windows.Forms.DataGridViewButtonColumn clmnRemove;
		private System.Windows.Forms.DataGridViewTextBoxColumn clmnArtist;
		private System.Windows.Forms.DataGridViewTextBoxColumn clmnAlbum;
		private System.Windows.Forms.DataGridViewTextBoxColumn clmnSong;
		private System.Windows.Forms.DataGridViewTextBoxColumn clmnSongID;

	}
}
