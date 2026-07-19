using UnityEngine;
using UnityEngine.UI;

namespace Game.NewConsole
{
    using Console;

    [AddComponentMenu("Game/NewConsole/ConsoleUI")]
    public class ConsoleUI : MonoBehaviour
    {
        [SerializeField] private Text _textPrefab;
        [SerializeField] private Transform _content;

        public void Say(string message, Color color) {
            if (_textPrefab == null) return;

            Text text = Instantiate(_textPrefab, _content.transform);
            text.text = message;
            text.color = color;
        }

        [ConsoleCommand("clear")]
        public void Clear() { foreach (Transform t in _content.transform) Destroy(t.gameObject); }

        [ConsoleCommand("say")]
        public void CmdSay(string message) { Say(message, Color.white); }
    }
}