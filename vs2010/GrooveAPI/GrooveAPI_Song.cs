namespace GrooveAPI
{
	public struct GrooveAPI_Song
	{
		public struct _ID
		{
			public int Song;
			public int Album;
			public int Artist;
		}		
		public struct _Name
		{
			public string Song;
			public string Album;
			public string Artist;
		}
		public struct _Verification
		{
			public bool General;
			public bool Song;
			public bool Album;
			public bool Artist;
		}
		public struct _Popularity
		{
			public double Song;
			public double Album;
			public double Artist;
		}
		public struct _Misc
		{
			public int Year;
			public int TrackNum;
			public string CoverArtFileName;
		}

		public _ID ID;
		public _Name Name;
		public _Popularity Popularity;
		public _Verification Verification;
		public _Misc Misc;
	}
}