using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;

namespace Game.Console
{
    [AddComponentMenu("Game/Console/ConsoleManager")]
    public class ConsoleManager : MonoBehaviour
    {
        public Dictionary<string, MethodInfo> Command;

        private object[] GetArgs(ParameterInfo[] parameters, string[] parametersConsole)
        {
            if (parameters.Length != parametersConsole.Length) { return null; }

            object[] value = new object[parameters.Length];

            for (int index = 0; index < parameters.Length; index++) {
                value[index] = parametersConsole[index];
            }


            return value;
        }
        private IEnumerable<MethodInfo> GetMethodInAttrib(Type customAttrib)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();

            return assembly.GetTypes().SelectMany(
                type => type.GetMethods(
                        BindingFlags.Public |
                        BindingFlags.Static |
                        BindingFlags.Instance |
                        BindingFlags.NonPublic
                    )
                ).Where(method => method.IsDefined(customAttrib, true));
        }

        public void InvokeCommand(string command)
        {
            if (string.IsNullOrEmpty(command)) return;
            string[] commandAndArgs = command.Split(": ");
            if (commandAndArgs.Length == 0) return;

            if (Command.TryGetValue(commandAndArgs[0], out MethodInfo methodInfo)) {

                Type currentClass = methodInfo.DeclaringType;

                UnityEngine.Object targetObject = FindAnyObjectByType(currentClass);

                if (targetObject != null)
                {
                    ParameterInfo[] parameters = methodInfo.GetParameters();
                    if (parameters.Length == 0)
                    {
                        methodInfo.Invoke(targetObject, null);
                        return;
                    }
                    else
                    {
                        if (commandAndArgs.Length < 2) return;
                        methodInfo.Invoke(targetObject, GetArgs(parameters, commandAndArgs[1].Split(" ; ")));
                        return;
                    }
                }
            }
        }

        private void Awake()
        {
            Command = new Dictionary<string, MethodInfo>();

            var methodsWithAttribute = GetMethodInAttrib(typeof(ConsoleCommand));

            foreach (var item in methodsWithAttribute)
            {
                Attribute c = item.GetCustomAttribute(typeof(ConsoleCommand));
                ConsoleCommand command = (ConsoleCommand)c;
                Command[command.CommandName] = item;
            }
        }
    }
}