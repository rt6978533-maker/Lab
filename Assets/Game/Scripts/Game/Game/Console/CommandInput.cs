using UnityEngine;

namespace Game.NewConsole
{
    [RequireComponent(typeof(IConsoleMethods))]
    [AddComponentMenu("Game/NewConsole/CommandInput")]
    public class CommandInput : MonoBehaviour
    {
        [SerializeField] private ParseSettings _settings;
        [SerializeField] private string _command;

        private IConsoleMethods _interface;

        private void Awake() {
            _interface = GetComponent<IConsoleMethods>();

            if (_interface == null) {
                Debug.LogError($"[CommandInput] _inreface is dont exist in GameObject({gameObject.name}).");
                enabled = false;
            }
            if (_settings == null) {
                Debug.LogError($"[CommandInput] _settings is null.");
                enabled = false;
            }
        }

        private string[] GetParameters(string parameterString)
        {
            if (string.IsNullOrEmpty(parameterString)) return null;

            string[] parameter = parameterString.Split(_settings.ArgumentSeparator);
            return parameter;
        }

        [ContextMenu("SendCommand")]
        public void SendCommand() => SendCommand(_command);

        public void SendCommand(string command) {
            if (string.IsNullOrEmpty(command)) return;

            string[] commands = command.Split(_settings.SuffixCommand);
            if (commands.Length < 1) return;
            else if (commands.Length == 1) _interface.CommandInvoke(commands[0]);
            else if (commands.Length == 2) _interface.CommandInvoke(commands[0], GetParameters(commands[1]));
        }
    }
}