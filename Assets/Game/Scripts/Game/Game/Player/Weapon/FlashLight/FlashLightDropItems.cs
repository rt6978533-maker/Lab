using GaS.Interface;
using UnityEngine;

namespace Game.Player.Weapon.Flashlight
{
    [AddComponentMenu("Game/Player/Weapon/Flashlight/FlashLightDropItems")]
    public class FlashLightDropItems : MonoBehaviour, IInitializable<FlashLightData>
    {
        [SerializeField] private int _addEnergy = 20;

        private FlashLightData _data;

        public void Init(FlashLightData arg)
        { _data = arg; }

        public void Trigger(GameObject ball) => _data?.AddEnergy(_addEnergy);
    }
}