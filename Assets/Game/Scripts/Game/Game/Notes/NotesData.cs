using UnityEngine;

namespace Game.Notes
{
    /// <summary>
    /// Holds data for an individual note asset.
    /// </summary>
    [CreateAssetMenu(fileName = "NoteData1", menuName = "Notes/NoteData")]
    public class NoteData : ScriptableObject
    {
        /// <summary>
        /// Unique identifier for the note.
        /// </summary>
        [Tooltip("Unique identifier for the note.")]
        public int ID;

        [Header("Visuals")]
        /// <summary>
        /// Visual texture associated with the note.
        /// </summary>
        [Tooltip("Visual texture associated with the note.")]
        public Texture2D Texture;
    }
}