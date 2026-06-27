using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;
using UnityEngine.Rendering;

namespace Game.Console
{
    public class ConsoleManager : MonoBehaviour
    {
        public Dictionary<string, MethodInfo> Command;

        public void InvokeCommand(string command)
        {
            if (string.IsNullOrEmpty(command)) return;

            if (Command.TryGetValue(command, out MethodInfo methodInfo)) {
                Type currentClass = methodInfo.DeclaringType;

                UnityEngine.Object targetObject = FindAnyObjectByType(currentClass);

                if (targetObject != null)
                    methodInfo.Invoke(targetObject, null);
            }
        }

        private void Awake()
        {
            Command = new Dictionary<string, MethodInfo>();

            Assembly assembly = Assembly.GetExecutingAssembly();

            var methodsWithAttribute = assembly.GetTypes().SelectMany(
                type => type.GetMethods(
                        BindingFlags.Public |
                        BindingFlags.Static |
                        BindingFlags.Instance |
                        BindingFlags.NonPublic
                    )
                ).Where(method => method.IsDefined(typeof(ConsoleCommand), true));

            foreach (var item in methodsWithAttribute)
            {
                Attribute c = item.GetCustomAttribute(typeof(ConsoleCommand));
                ConsoleCommand command = (ConsoleCommand)c;
                Command[command.CommandName] = item;
            }
        }
    }
}