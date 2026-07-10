using GaS.Interface;
using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace Game.NewConsole
{
    public interface IConsoleGraphics { public void Render(List<string> commands); }

    [AddComponentMenu("Game/NewConsole/ConsoleGraphics")]
    public class ConsoleGraphics : MonoBehaviour, IConsoleGraphics
    {
        [SerializeField] private GameObject _prefab;
        [SerializeField] private Transform _content;
        [SerializeField] private ConsoleBaker _baker;

        private List<IInitializable<string, string>> _bufferPoolObject = new();

        private void CreatePool(int length)
        {
            IInitializable<string, string>[] inits = new IInitializable<string, string>[length];

            for (int index = 0; index < length; index++)
            {
                GameObject obj = Instantiate(_prefab, _content.transform);
                if (!obj.TryGetComponent(out IInitializable<string, string> init))
                {
                    Debug.LogError("[ConsoleGraphics][CreatePool] _prefab is not exist IInitializable<string, string>");
                    Destroy(obj);
                    enabled = false;
                    break;
                }

                inits[index] = init;
            }

            _bufferPoolObject.AddRange(inits);
        }

        private void Clear()
        {
            foreach (var obj in _bufferPoolObject) obj.Init("", "");
        }

        public void Render(List<string> commands)
        {
            if (commands.Count > _bufferPoolObject.Count) CreatePool(commands.Count);

            Clear();

            for (int index = 0; index < commands.Count; index++)
            {
                string one = commands[index];

                if (!_baker.BakedInfo.TextInfoCommand.TryGetValue(one, out string two)) return;

                _bufferPoolObject[index].Init(one, two);
            }
        }
    }
}