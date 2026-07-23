using System.Collections.Generic;
using UnityEngine;


namespace Game.Notes
{
    public class NotesManager : MonoBehaviour, INotesInterface
    {
        [HideInInspector]
        public List<NoteData> Notes;

        private void Awake()
        {
            Notes = new List<NoteData>();
        }

        /// <summary>
        /// Save a note in data.
        /// </summary>
        /// <param name="note"></param>
        public void AddNote(NoteData note)
        {
            Notes.Add(note);
        }
    }
}