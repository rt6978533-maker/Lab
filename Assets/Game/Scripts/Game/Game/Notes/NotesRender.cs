using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Notes
{
    /// <summary>
    /// Render current notes in NotesManager. 
    /// </summary>
    [AddComponentMenu("Game/Notes/NotesRender")]
    public class NotesRender : MonoBehaviour
    {
        /// <summary>
        /// 
        /// </summary>
        [SerializeField]
        private NotesManager _notesManager;

        /// <summary>
        /// Create the prefab.
        /// </summary>
        [SerializeField]
        private Image _prefab;

        /// <summary>
        /// Who created a prefab.
        /// </summary>
        [SerializeField]
        private Transform _content;

        /// <summary>
        /// Created notes.
        /// </summary>
        private List<Image> _createdNotes;

        private void Awake() {
            if (_notesManager == null)
            {
                Debug.LogError("[NotesRender] _notesManager is null.");
                return;
            }

            _createdNotes = new();
            _notesManager.OnChange += AddToRender;
        }

        private void OnDestroy() {
            if (_notesManager == null)
            {
                Debug.LogError("[NotesRender] _notesManager is null.");
                return;
            }

            _notesManager.OnChange -= AddToRender;
        }

        /// <summary>
        /// Add & Create a object to render.
        /// </summary>
        /// <param name="note"></param>
        public void AddToRender(NoteData note) {
            Image p = Instantiate(_prefab);
            p.transform.SetParent(_content);

            p.sprite = note.Texture;
            _createdNotes.Add(p);
        }
    }
}