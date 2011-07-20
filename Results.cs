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
	public partial class Results : UserControl, GrooveAPI.IResults
	{
		public Results()
		{
			InitializeComponent();			
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

			row.CreateCells(dgvResults, args);
			dgvResults.Rows.Insert(0, row);

			ListSortDirection direction;
			if(dgvResults.SortOrder == SortOrder.None)
				direction = ListSortDirection.Ascending;
			else
				direction = dgvResults.SortOrder == SortOrder.Ascending ? ListSortDirection.Ascending : ListSortDirection.Descending;

			dgvResults.Sort(dgvResults.SortedColumn == null ? dgvResults.Columns[0] : dgvResults.SortedColumn, direction);
		}

		public void ResultUpdateNotification()
		{
			dgvResults.RowCount = 0;
			foreach (GrooveAPI.GrooveAPI_Song song in GrooveAPI.Information.CurrentResults.Values)
			{
				DataGridViewRow row = new DataGridViewRow();

				object[] args = new object[5];

				args[0] = " ";
				args[1] = song.Name.Artist;
				args[2] = song.Name.Album;
				args[3] = song.Name.Song;
				args[4] = song.ID.Song;

				row.CreateCells(dgvResults, args);
				dgvResults.Rows.Add(row);
			}			
		}

		private void dgvResults_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
			if (e.ColumnIndex == 0)
			{				
				OnSongRemove(GrooveAPI.Information.CurrentResults[Convert.ToInt32(dgvResults[4, e.RowIndex].Value)]);
				dgvResults.Rows.RemoveAt(e.RowIndex);
			}			
		}

		private void dgvResults_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
		{
			if (e.Button == MouseButtons.Right)
			{
				ContextMenu cm = new ContextMenu();
				MenuItem mn = new MenuItem("Add selection", new EventHandler(dgvResults_ContextMenu_AddSelection));
				cm.MenuItems.Add(mn);
				cm.Show(dgvResults, dgvResults.PointToClient(Cursor.Position));
			}
		}

		private void dgvResults_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			OnSongRemove(GrooveAPI.Information.CurrentResults[Convert.ToInt32(dgvResults[4, e.RowIndex].Value)]);
			dgvResults.Rows.RemoveAt(e.RowIndex);
		}

		private void dgvResults_ContextMenu_AddSelection(object sender, EventArgs e)
		{
			foreach (DataGridViewRow row in dgvResults.SelectedRows)
			{
				OnSongRemove(GrooveAPI.Information.CurrentResults[Convert.ToInt32(dgvResults[4, row.Index].Value)]);
				dgvResults.Rows.Remove(row);
			}
		}

		private void OnSongRemove(GrooveAPI.GrooveAPI_Song song)
		{
			SongChange(this, ChangeType.CT_REMOVE, song);
		}

		private void dgvResults_KeyDown(object sender, KeyEventArgs e)
		{			
			if(e.KeyCode == Keys.Enter)
			{				
				if (dgvResults.SelectedRows.Count > 0)
				{
					e.Handled = true;
					OnSongRemove(GrooveAPI.Information.CurrentResults[Convert.ToInt32(dgvResults[4, dgvResults.SelectedRows[0].Index].Value)]);
					dgvResults.Rows.Remove(dgvResults.SelectedRows[0]);
				}
			}
		}

		public event SongChange SongChange;
	}
}
