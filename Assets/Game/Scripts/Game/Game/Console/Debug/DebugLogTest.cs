using UnityEngine;
using Game.Console;

namespace Game.NewConsole
{
    [AddComponentMenu("Game/NewConsole/Debug/DebugLogTest")]
    public class DebugLogTest : MonoBehaviour
    {
        [ConsoleCommand("tte")]
        public void Test(string text, int id)
        {
            Debug.Log(text + id);
        }
    }
}
