using System;
using System.Reflection;
using UnityEngine;

namespace Game.NewConsole
{
    public class BakedInfoConsoleCommand : ConsoleBakedInfo
    {
        public override void InsertCommand(MethodInfo method)
        {
            Attribute attribute = method.GetCustomAttribute(typeof(ConsoleCommand));
            ConsoleCommand consoleCommand = (ConsoleCommand)attribute;

            TrieCommands.Insert(consoleCommand.CommandName);
            TextInfoCommand.Add(consoleCommand.CommandName, consoleCommand.CommandName + GetInfoMethods(method));
        }
    }

    public class BakedConsoleCommand : ConsoleBaked
    {
        public override void InsertCommand(MethodInfo method)
        {
            Attribute attribute = method.GetCustomAttribute(typeof(ConsoleCommand));
            ConsoleCommand command = (ConsoleCommand)attribute;

            Commands.Add(command.CommandName, method);
        }
    }

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

            Baked = new BakedConsoleCommand();
            Baked.Bake(methods);

            if (!_bakedInfoActive) return;

            BakedInfo = new BakedInfoConsoleCommand() { ParseSettings = _parseSettings };
            BakedInfo.Bake(methods);
        }
    }
}