namespace Groove_Down
{
	public enum ChangeType { CT_REMOVE, CT_ADD }

	public delegate void SongChange(object sender, ChangeType type, GrooveAPI.GrooveAPI_Song song);
}