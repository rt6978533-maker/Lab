using GaS.Interface;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Console
{
    [AddComponentMenu("Game/Console/ConsoleRenderPrefab")]
    public class ConsoleRenderPrefab : MonoBehaviour, IInitializable<string, ConsoleGraphics>
    {
        [SerializeField] private Text _text;

        private ConsoleGraphics _consoleGraphics;
        private string _name;

        public void Init(string args1, ConsoleGraphics args2)
        {
            _consoleGraphics = args2;
            _name = args1;
            _text.text = _name;
        }

        public void OnSelect()
        {
            _consoleGraphics.SetInput(_name);
        }
    }
}