using UnityEngine;
using UnityEngine.Events;

namespace Game.Achievement
{
    public interface IAchievement<T>
    {
        void Invoke(T arg);
        void AddAchievement(int id);
    }

    public class Achievement<T> : MonoBehaviour, IAchievement<T>
    {
        public const int MaxValue = 0x7FFFFFFF;

        public T Value { get; protected set; }

        public UnityEvent GetAchievement;

        public virtual void Invoke(T arg)
        { }

        public virtual void AddAchievement(int id) {
            if (id >= MaxValue) { 
                throw new System.ArgumentOutOfRangeException(nameof(id) + " out of range excaption num(" + MaxValue + ")."); 
            }

            int achievement = PlayerPrefs.GetInt("Achievement", 0);

            if ((achievement & id) == id)
                return;

            achievement = achievement | id;
            PlayerPrefs.SetInt("Achievement", achievement);
        }
    }
}