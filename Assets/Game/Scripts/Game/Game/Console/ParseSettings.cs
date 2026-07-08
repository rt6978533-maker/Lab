using UnityEngine;

namespace Game.NewConsole
{
    [CreateAssetMenu(fileName = "ConsoleParseSettings", menuName = "Console/ParseSettings", order = 0)]
    public class ParseSettings : ScriptableObject
    {
        public string SuffixCommand, ArgumentSeparator;
    }
}