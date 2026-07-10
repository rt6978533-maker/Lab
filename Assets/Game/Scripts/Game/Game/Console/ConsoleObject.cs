using GaS.Interface;
using UnityEngine;
using UnityEngine.UI;

namespace Game.NewConsole
{
    [AddComponentMenu("Game/NewConsole/ConsoleObject")]
    public class ConsoleObject : MonoBehaviour, IInitializable<string, string>
    {
        [SerializeField] private Text _text;

        private string _command;

        public void Init(string command, string commandInfo)
        {
            if (_text == null)
            {
                Debug.LogError("[ConsoleObject][Init] _text is null.");
                enabled = false;
                return;
            }
            _command = command;
            _text.text = commandInfo;
        }
    }

}