using System;
using System.Collections.Generic;
using UnityEngine;


namespace Game.Notes
{
    /// <summary>
    /// 
    /// </summary>
    [AddComponentMenu("Game/Notes/NotesManager")]
    public class NotesManager : MonoBehaviour, INotesInterface
    {
        /// <summary>
        /// Data note
        /// </summary>
        [HideInInspector]
        public List<NoteData> Notes;

        /// <summary>
        /// Change notes in data.
        /// </summary>
        public event Action<NoteData> OnChange;

        /// <summary>
        /// Exist is empty slots
        /// </summary>
        public bool EmptySlotsExist => Notes != null && Notes.Count < _maxCountNotes;

        [SerializeField]
        private int _maxCountNotes = 5;

        private void Awake() {
            Notes = new List<NoteData>();
        }

        /// <summary>
        /// Save a note in data.
        /// </summary>
        /// <param name="note"></param>
        public void AddNote(NoteData note) {
            if (EmptySlotsExist) {
                Notes.Add(note);
                OnChange?.Invoke(note);
            }
        }
    }
}