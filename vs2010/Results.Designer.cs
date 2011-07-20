namespace Groove_Down
{
	partial class Results
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
			this.dgvResults = new System.Windows.Forms.DataGridView();
			this.clmnAdd = new System.Windows.Forms.DataGridViewButtonColumn();
			this.clmnArtist = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.clmnAlbum = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.clmnSong = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.clmnSongID = new System.Windows.Forms.DataGridViewTextBoxColumn();
			((System.ComponentModel.ISupportInitialize)(this.dgvResults)).BeginInit();
			this.SuspendLayout();
			// 
			// dgvResults
			// 
			this.dgvResults.AllowUserToAddRows = false;
			this.dgvResults.AllowUserToDeleteRows = false;
			this.dgvResults.AllowUserToResizeRows = false;
			this.dgvResults.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.dgvResults.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.dgvResults.BackgroundColor = System.Drawing.Color.Gainsboro;
			this.dgvResults.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.dgvResults.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
			this.dgvResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvResults.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmnAdd,
            this.clmnArtist,
            this.clmnAlbum,
            this.clmnSong,
            this.clmnSongID});
			this.dgvResults.Location = new System.Drawing.Point(0, 0);
			this.dgvResults.Name = "dgvResults";
			this.dgvResults.ReadOnly = true;
			this.dgvResults.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
			this.dgvResults.RowHeadersVisible = false;
			this.dgvResults.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
			this.dgvResults.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dgvResults.ShowEditingIcon = false;
			this.dgvResults.Size = new System.Drawing.Size(353, 300);
			this.dgvResults.StandardTab = true;
			this.dgvResults.TabIndex = 0;
			this.dgvResults.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvResults_CellContentClick);
			this.dgvResults.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvResults_CellContentDoubleClick);
			this.dgvResults.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvResults_CellMouseClick);
			this.dgvResults.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvResults_KeyDown);
			// 
			// clmnAdd
			// 
			this.clmnAdd.FillWeight = 5F;
			this.clmnAdd.HeaderText = "Add";
			this.clmnAdd.MinimumWidth = 35;
			this.clmnAdd.Name = "clmnAdd";
			this.clmnAdd.ReadOnly = true;
			this.clmnAdd.UseColumnTextForButtonValue = true;
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
			// Results
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.dgvResults);
			this.Name = "Results";
			this.Size = new System.Drawing.Size(353, 300);
			((System.ComponentModel.ISupportInitialize)(this.dgvResults)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.DataGridView dgvResults;
		private System.Windows.Forms.DataGridViewButtonColumn clmnAdd;
		private System.Windows.Forms.DataGridViewTextBoxColumn clmnArtist;
		private System.Windows.Forms.DataGridViewTextBoxColumn clmnAlbum;
		private System.Windows.Forms.DataGridViewTextBoxColumn clmnSong;
		private System.Windows.Forms.DataGridViewTextBoxColumn clmnSongID;

	}
}
