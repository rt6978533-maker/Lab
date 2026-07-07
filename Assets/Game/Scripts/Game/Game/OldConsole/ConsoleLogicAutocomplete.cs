using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Game.Console
{
    [AddComponentMenu("Game/Console/ConsoleLogicAutocomplete")]
    public class ConsoleLogicAutocomplete : MonoBehaviour
    {
        [SerializeField] private ConsoleGraphics _consoleGraphycs;
        [SerializeField] private ConsoleManager _consoleManager;

        public void Change(string currentInput)
        {
            if (string.IsNullOrEmpty(currentInput)) {
                _consoleGraphycs.Clear(); 
                return;
            }

            string userInputCommand = currentInput.Split(':', StringSplitOptions.RemoveEmptyEntries)[0].Trim();

            IEnumerable<string> commandsHelper = _consoleManager.NameCommands.Where(template =>
            {
                string templateCommandName = template.Split(':', StringSplitOptions.RemoveEmptyEntries)[0].Trim();

                return templateCommandName.StartsWith(userInputCommand, StringComparison.OrdinalIgnoreCase);
            });
            
            _consoleGraphycs.EnterHelpers(commandsHelper);
        }
    }
}