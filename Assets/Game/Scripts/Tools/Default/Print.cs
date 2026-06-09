using UnityEngine;

namespace Tools.Default
{
    [AddComponentMenu("Tools/Default/Print")]
    public class Print : MonoBehaviour
    {
        //Matematic
        public void Log(string value) => Debug.Log(value);
        public void Log(long value) => Debug.Log(value);
        public void Log(double value) => Debug.Log(value);
        public void Log(float value) => Debug.Log(value);
        public void Log(int value) => Debug.Log(value);
        public void Log(short value) => Debug.Log(value);
        public void Log(byte value) => Debug.Log(value);
        public void Log(bool value) => Debug.Log(value);
        //Addition
        public void Log(object[] value) { foreach (object obj in value) Debug.Log(obj); }
    }
}