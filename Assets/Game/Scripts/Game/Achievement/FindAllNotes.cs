using UnityEngine;
using UnityEngine.Events;

namespace Game.Achievement
{
    public class FindAllNotes : Achievement<byte>
    {
        public const int IDAchievement = 1;
        public static byte OneBit = 0b00000001, AllBit = 0b11111111;

        private void Start()
        {
            Value = (byte)PlayerPrefs.GetInt("Achievement_FindAllNotes_Count", 0);
            Debug.Log(Value);
        }

        private void UpdateLogic()
        {
            PlayerPrefs.SetInt("Achievement_FindAllNotes_Count", Value);

            if (Value == 255) {
                AddAchievement(IDAchievement);
            }
        }

        public override void Invoke(byte id)
        {
            if (id > 7) { throw new System.ArgumentOutOfRangeException("The id, сannot exceed 7."); }

            if (((Value >> id) & OneBit) == OneBit) return;
            else Value = (byte)(Value | (OneBit << id));

            UpdateLogic();
        }
    }
}