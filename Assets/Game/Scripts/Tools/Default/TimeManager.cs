using UnityEngine;

namespace Tools.Default
{
    [AddComponentMenu("Tools/Default/TimeManager")]
    public class TimeManager : MonoBehaviour
    {
        public void SetTime(float value)
        {
            if (value < 0f || value > 1f)
            {
                Debug.Log("[TimeManager][SetTime] argument out of range(0f-1f).");
                return;
            }
            Time.timeScale = value;
        }
    }
}
