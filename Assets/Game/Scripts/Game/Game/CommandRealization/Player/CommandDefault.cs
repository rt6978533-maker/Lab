using UnityEngine;

namespace Game.CommandRealization
{
    using NewConsole;

    public class CommandDefault : MonoBehaviour
    {
        [SerializeField] private ConsoleBaker _baker;

        [ConsoleCommand("length")]
        public string GetLength() => _baker.Baked.Length.ToString();
    }
}