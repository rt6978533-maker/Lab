using UnityEngine;

namespace Game.Achievement
{
    public class FindAllNotes : Achievement
    {
        public static byte OneBit = 0b10000000, AllBit = 0b11111111;

        public byte FindCount { get; private set; }

        private void Start()
        {
            FindCount = (byte)PlayerPrefs.GetInt("Achievement_FindAllNotes_Count", 0);
            Debug.Log(FindCount);
        }

        private void UpdateLogic()
        {
            PlayerPrefs.SetInt("Achievement_FindAllNotes_Count", FindCount);

            //if ((FindCount & AllBit) == AllBit)
        }

        public void AddCount(int id)
        {
            if (id > 7) { throw new System.ArgumentOutOfRangeException("The id, сannot exceed 7."); }

            if (((FindCount << id) & OneBit) == OneBit) return;
            else FindCount = (byte)(FindCount | (OneBit >> id));

            UpdateLogic();
        }
    }
}