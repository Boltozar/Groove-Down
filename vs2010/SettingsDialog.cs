using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace Groove_Down
{
	public partial class frmSettingsDialog : Form
	{
		public frmSettingsDialog()
		{
			InitializeComponent();
		}

		private void trkbConnects_Scroll(object sender, EventArgs e)
		{			
			lblConnectsTip.Text = trkbConnects.Value.ToString();
		}

		private void tbDownloadFileNameFormat_TextChanged(object sender, EventArgs e)
		{
			CalculateFileNameFromTextBox();
		}

		private void frmSettingsDialog_Load(object sender, EventArgs e)
		{
			trkbConnects.Value = (int)GrooveAPI.Information.MaxConcurrentDownloads;
			lblConnectsTip.Text = GrooveAPI.Information.MaxConcurrentDownloads.ToString();
			tbBaseDownloadDirectory.Text = GrooveAPI.Information.BaseDownloadDirectory;
			tbDownloadFileNameFormat.Text = GrooveAPI.Information.DownloadFileNameFormat;			
		}

		private void btnOK_Click(object sender, EventArgs e)
		{
			GrooveAPI.Information.MaxConcurrentDownloads = (uint)trkbConnects.Value;

			if (!FSValid(tbDownloadFileNameFormat.Text))
			{
				MessageBox.Show(
					this, "Invalid characters entered in \"" + tbDownloadFileNameFormat.Text + "\".\r\nPlease enter another format.",
					"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			Regex r = new Regex(@"^(([a-zA-Z]\:)|(\\))(\\{1}|((\\{1})[^\\]([^/:*?<>""|]*))+)$");
			if (!r.IsMatch(tbBaseDownloadDirectory.Text))
			{
				MessageBox.Show(
					this, "Invalid base download directory specified. Please enter a valid directory.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			char driveLetter = tbBaseDownloadDirectory.Text.ToUpper()[0];
			bool badDrive = true;
			foreach (System.IO.DriveInfo dinfo in System.IO.DriveInfo.GetDrives())
			{
				if (dinfo.Name[0] == driveLetter)
				{
					badDrive = false;
					break;
				}				
			}
			if (badDrive)
			{
				MessageBox.Show(
					this, "The drive specified for the base download directory does not exist. Choose an existing drive.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			
			StringBuilder dfnSb = new StringBuilder(tbBaseDownloadDirectory.Text);
			for (int i = 0; i < dfnSb.Length; i++)
			{
				if (dfnSb[i] == '/')
					dfnSb[i] = '\\';						
			}
			string dfn = dfnSb.ToString();
			GrooveAPI.Information.BaseDownloadDirectory = dfn;
			if (!dfn.EndsWith("\\"))
				GrooveAPI.Information.BaseDownloadDirectory = dfn + '\\';
			GrooveAPI.Information.DownloadFileNameFormat = tbDownloadFileNameFormat.Text;			

			Close();			
		}

		private void btnBaseDownloadDirectorySelect_Click(object sender, EventArgs e)
		{
			if(fbdBaseDownloadDirectory.ShowDialog(this) == DialogResult.OK)
				tbBaseDownloadDirectory.Text = fbdBaseDownloadDirectory.SelectedPath + '\\';
		}	


		private bool FSValid(string str)
		{
			foreach (char ch in str)
					if (ch == '\0' || ch == ':' || ch == '*' || ch == '?' || ch == '\"' || ch == '<' || ch == '>' || ch == '|')
						return false;			
			return true;
		}

		private void CalculateFileNameFromTextBox()
		{
			#region Example Song Initialization
			GrooveAPI.GrooveAPI_Song exampleSong = new GrooveAPI.GrooveAPI_Song()
			{
				ID = new GrooveAPI.GrooveAPI_Song._ID()
				{
					Song = 89324789,
					Album = 98243223,
					Artist = 42392432
				},
				Name = new GrooveAPI.GrooveAPI_Song._Name()
				{
					Song = "Heavyweight",
					Album = "Vicious Delicious",
					Artist = "Infected Mushroom"
				},
				Misc = new GrooveAPI.GrooveAPI_Song._Misc()
				{
					Year = 2008,
					CoverArtFileName = "jkfxddmvx.png",
					TrackNum = 4
				},
				Popularity = new GrooveAPI.GrooveAPI_Song._Popularity()
				{
					Song = 89328942394.234,
					Album = 48329422.32,
					Artist = 3423423.123
				},
				Verification = new GrooveAPI.GrooveAPI_Song._Verification()
				{
					Album = true,
					Artist = true,
					General = true,
					Song = true
				}
			};
			#endregion
			string format = tbDownloadFileNameFormat.Text;
			
			Regex matchData = new Regex("%(song|album|artist|track|year)%", RegexOptions.IgnoreCase);

			string fileName = "";

			fileName = matchData.Replace(format, new MatchEvaluator((match) =>
			{
				string rtn = "";
				switch (match.Groups[1].Value)
				{
					case "song":
						rtn = exampleSong.Name.Song;
						break;
					case "album":
						rtn = exampleSong.Name.Album;
						break;
					case "artist":
						rtn = exampleSong.Name.Artist;
						break;
					case "track":
						rtn = exampleSong.Misc.TrackNum.ToString();
						break;
					case "year":
						rtn = exampleSong.Misc.Year.ToString();
						break;
				}
				return rtn;
			}));

			bool validNTFS = FSValid(fileName);

			lblDownloadFileNameExample.Text = "Output Example: " + (validNTFS ? fileName : "<ERROR: Invalid characters>");
		}	
	}
}
