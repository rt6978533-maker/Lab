using Game.Console;
using System.Reflection;
using UnityEngine;

namespace Game.NewConsole
{
    [AddComponentMenu("Game/NewConsole/ConsoleBaker")]
    public class ConsoleBaker : MonoBehaviour
    {
        [SerializeField] private ParseSettings _parseSettings;
        [SerializeField] private bool _bakedInfoActive = false;

        public ConsoleBaked Baked { get; private set; }
        public ConsoleBakedInfo BakedInfo { get; private set; }

        private void Awake()
        {
            BindingFlags flags = BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public | BindingFlags.Static;

            MethodInfo[] methods;
            TypeTools.GetMethodInAttributeAssembly<ConsoleCommand>(flags, out methods);

            Baked = new();
            Baked.Bake(methods);

            if (!_bakedInfoActive) return;

            BakedInfo = new() { ParseSettings = _parseSettings };
            BakedInfo.Bake(methods);
        }
    }
}