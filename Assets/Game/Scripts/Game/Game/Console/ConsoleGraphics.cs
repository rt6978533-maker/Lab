using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Console
{
    public interface IInputSet { void SetInput(string newText); }

    [AddComponentMenu("Game/Console/ConsoleGraphics")]
    public class ConsoleGraphics : MonoBehaviour, IInputSet
    {
        [SerializeField] private Transform _content;
        [SerializeField] private ConsoleRenderPrefab _prefabCreate;
        [SerializeField] private InputField _inputField;

        public void SetInput(string newText)
        {
            if (_inputField == null) return;

            _inputField.text = newText;
        }

        public void Clear() { foreach (Transform child in _content.transform) Destroy(child.gameObject); }
        public void Create(string name)
        {
            ConsoleRenderPrefab text = Instantiate(_prefabCreate, _content);
            text.Init(name, this);
        }

        public void EnterHelpers(IEnumerable<string> commands)
        {
            Clear();

            foreach (var command in commands)
            {
                Create(command);
            }
        }
    }
}