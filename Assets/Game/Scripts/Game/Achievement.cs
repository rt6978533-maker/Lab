using UnityEngine;

namespace Game.Achievement
{
    public interface IAchievement
    {
        void Invoke();
    }

    public class Achievement : MonoBehaviour, IAchievement
    {
        public void Invoke()
        {
            throw new System.NotImplementedException();
        }
    }
}