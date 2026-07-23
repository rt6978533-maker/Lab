namespace Game.Notes
{
    public interface IPickUpNotes { void AddNote(NoteData note); }
    public interface INotesInterface : IPickUpNotes { }
}
