using GaS.Interface;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Console
{
    [AddComponentMenu("Game/Console/ConsoleRenderPrefab")]
    public class ConsoleRenderPrefab : MonoBehaviour, IInitializable<string, IInputSet>
    {
        [SerializeField] private Text _text;

        private IInputSet _consoleGraphics;
        private string _name;
        private string _command;

        public void Init(string args1, IInputSet args2)
        {
            _consoleGraphics = args2;
            _name = args1;
            _command = _name.Split(": ")[0];
            _text.text = _name;
        }

        public void OnSelect()
        {
            _consoleGraphics.SetInput(_command);
        }
    }
}