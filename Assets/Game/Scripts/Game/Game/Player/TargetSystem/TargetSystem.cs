using UnityEngine;
using UnityEngine.UI;

namespace Game.Player.Target
{
    [AddComponentMenu("Game/Player/Target/TargetSystem")]
    public class TargetSystem : MonoBehaviour
    {
        [SerializeField] private Text[] TextTarget;

        public void SetTarget(string targetMessage)
        {
            foreach (Text text in TextTarget) { 
                text.text = targetMessage;
            }
        }
    }
}