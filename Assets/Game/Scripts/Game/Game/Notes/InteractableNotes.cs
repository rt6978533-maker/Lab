using UnityEngine;

namespace Game
{
    using Player.ItemsPickUp;

    namespace Notes
    {
        public class InteractableNotes : Items
        {
            [SerializeField]
            private NoteData _noteData;

            public override void InteractOne(GameObject plr)
            {
                if (plr.TryGetComponent(out IPickUpNotes notesInterface))
                {
                    if (_noteData != null) notesInterface.AddNote(_noteData);
                    else { Debug.LogError("[InteractableNotes] _noteData is null."); }
                }
                else Debug.LogWarning("[InteractableNotes] " + plr.name + " is not exist IPickUpNotes.");

                Destroy(gameObject);
            }
        }
    }
}