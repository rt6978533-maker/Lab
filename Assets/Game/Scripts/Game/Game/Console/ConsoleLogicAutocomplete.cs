using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace Game.Console
{
    [AddComponentMenu("Game/Console/ConsoleLogicAutocomplete")]
    public class ConsoleLogicAutocomplete : MonoBehaviour
    {
        [SerializeField] private ConsoleGraphics _consoleGraphycs;
        [SerializeField] private ConsoleManager _consoleManager;

        public void Change(string command)
        {
            if (string.IsNullOrEmpty(command)) {
                _consoleGraphycs.Clear(); 
                return;
            }

            IEnumerable<string> commandsHelper = _consoleManager.NameCommands.Where(c => c.StartsWith(command));

            _consoleGraphycs.EnterHelpers(commandsHelper);
        }
    }
}