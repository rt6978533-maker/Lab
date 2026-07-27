using UnityEngine;

namespace Game
{
    using Game.Achievement;
    using Player.ItemsPickUp;

    namespace Notes
    {
        public class InteractableNotes : Items
        {
            [Header("FindNotes Achievement")]
            [SerializeField]
            private FindAllNotes _notesAchievement;

            [SerializeField]
            private int ID;

            [Header("Reference")]
            [SerializeField]
            private NoteData _noteData;

            public override void InteractOne(GameObject plr)
            {
                if (plr.TryGetComponent(out IPickUpNotes notesInterface))
                {
                    if (_noteData != null) {
                        _notesAchievement?.AddCount(ID);
                        notesInterface.AddNote(_noteData);
                    }
                    else { Debug.LogError("[InteractableNotes] _noteData is null."); }
                }
                else Debug.LogWarning("[InteractableNotes] " + plr.name + " is not exist IPickUpNotes.");

                Destroy(gameObject);
            }
        }
    }
}