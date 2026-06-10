using Game.Player.Weapon.Flashlight;
using GaS.Interface;
using UnityEngine;

namespace Game.Player.Weapon
{
    [AddComponentMenu("Game/Player/Weapon/FlashlightItems")]
    public class FlashLight : Items
    {
        [SerializeField] private FlashLightData _injectData;

        protected override void Drop(GameObject dropedItems)
        {
            if (_injectData == null)
            { Debug.LogError("[FlashLight] _injectData is null."); return; }
            if (dropedItems == null)
            { Debug.LogError("[FlashLight] dropedItems is null."); return; }

            if (dropedItems.TryGetComponent(out IInitializable<FlashLightData> data)) 
                data.Init(_injectData);
            else
            {
                Destroy(dropedItems);
                Debug.LogError("[FlashLight] dropedItems is not exist \"FlashLightData\" component.");
                return;
            }
        }
    }
}