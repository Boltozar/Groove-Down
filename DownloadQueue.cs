using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Groove_Down
{
	public partial class DownloadQueue : UserControl, GrooveAPI.IProgress
	{
		public DownloadQueue()
		{
			InitializeComponent();
		}

		public void ProgressUpdate(GrooveAPI.GrooveAPI_Song song, int bytesRead, int totalBytes)
		{	
			foreach(DataGridViewRow row in dgvQueue.Rows)
			{
				if((int)row.Cells[4].Value == song.ID.Song)
					row.Cells[0].Value = _GetByteString(bytesRead, totalBytes);		
			}			
		}

		public void DownloadBeginning(GrooveAPI.GrooveAPI_Song song)
		{
			if (!_inDownloadMode)
			{
				dgvQueue.Columns.RemoveAt(0);

				DataGridViewTextBoxColumn clmnProg = new DataGridViewTextBoxColumn();				
				clmnProg.HeaderText = "Progress";				
				clmnProg.Name = "clmnProg";								
				dgvQueue.Columns.Insert(0, clmnProg);

				_inDownloadMode = true;				
			}
		}

		public void DownloadComplete(GrooveAPI.GrooveAPI_Song song)
		{
			if (Program.DownloadsCancelled || song.ID.Song == 0)
			{				
				if (_inDownloadMode)
				{
					dgvQueue.Columns.RemoveAt(0);
					dgvQueue.Columns.Insert(0, clmnRemove);
					_inDownloadMode = false;					
				}
				return;
			}

			DataGridViewRow remove = null;
			int index = 0;
			foreach (DataGridViewRow row in dgvQueue.Rows)
			{
				if ((int)row.Cells[4].Value == song.ID.Song)
				{
					remove = row;
					break;
				}
				index++;
			}
			if (remove != null)
			{
				dgvQueue.Rows.Remove(remove);
				_songs.RemoveAt(index);
			}
			if (dgvQueue.Rows.Count == 0)
			{
				dgvQueue.Columns.RemoveAt(0);
				dgvQueue.Columns.Insert(0, clmnRemove);
				_inDownloadMode = false;
			}
		}

		private string _GetByteString(int bytesRead, int totalBytes)
		{
			string suffix = "bytes";
			double dbRead = (double)bytesRead;
			double dbTotal = (double)totalBytes;
			if (bytesRead > 1024)
			{
				if (bytesRead > 1048576)
				{
					suffix = "MB";
					dbRead /= 1048576;
					dbTotal /= 1048576;
				}
				else
				{
					suffix = "KB";
					dbRead /= 1024;
					dbTotal /= 1024;
				}
			}
			return dbRead.ToString("0.00") + "/" + dbTotal.ToString("0.00") + suffix;
		}

		public void ProgressReset()
		{
			if (dgvQueue.Rows.Count == 0 || dgvQueue[0, 0].GetType() == Type.GetType("System.Windows.Forms.DataGridViewButtonCell"))
				return;
			foreach (DataGridViewRow row in dgvQueue.Rows)			
				row.Cells[0].Value = "";			
		}

		public void Clear()
		{
			dgvQueue.Rows.Clear();
			_songs.Clear();
		}

		private void dgvQueue_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
			if (e.ColumnIndex == 0)
			{
				OnSongRemove(_songs[e.RowIndex]);
				dgvQueue.Rows.RemoveAt(e.RowIndex);
				_songs.RemoveAt(e.RowIndex);
			}
		}
		private void dgvQueue_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
		{
			if (e.Button == MouseButtons.Right)
			{
				ContextMenu cm = new ContextMenu();
				MenuItem mn = new MenuItem("Remove selection", new EventHandler(dgvQueue_ContextMenu_RemoveSelection));
				cm.MenuItems.Add(mn);
				cm.Show(dgvQueue, dgvQueue.PointToClient(Cursor.Position));
			}
		}

		private void dgvQueue_ContextMenu_RemoveSelection(object sender, EventArgs e)
		{
			int index = 0;
			foreach (DataGridViewRow row in dgvQueue.SelectedRows)
			{
				index = row.Index;
				OnSongRemove(_songs[index]);
				_songs.RemoveAt(index);
				dgvQueue.Rows.Remove(row);				
			}
		}	

		private void OnSongRemove(GrooveAPI.GrooveAPI_Song song)
		{
			if(SongChange != null)
				SongChange(this, ChangeType.CT_REMOVE, song);
		}

		public void AddSong(GrooveAPI.GrooveAPI_Song song)
		{
			DataGridViewRow row = new DataGridViewRow();

			object[] args = new object[5];

			args[0] = " ";
			args[1] = song.Name.Artist;
			args[2] = song.Name.Album;
			args[3] = song.Name.Song;
			args[4] = song.ID.Song;

			row.CreateCells(dgvQueue, args);
			dgvQueue.Rows.Add(row);

			_songs.Add(song);
		}

		public void AddSongs(List<GrooveAPI.GrooveAPI_Song> songs)
		{
			foreach (GrooveAPI.GrooveAPI_Song song in songs)
				AddSong(song);
		}

		public List<GrooveAPI.GrooveAPI_Song> RetrieveSongsList()
		{
			return _songs;
		}

		public event SongChange SongChange;
		private List<GrooveAPI.GrooveAPI_Song> _songs = new List<GrooveAPI.GrooveAPI_Song>();
		private bool _inDownloadMode = false;
		private int _bytesTotal = 0;
		private int _bytesDone = 0;		
	}
}
