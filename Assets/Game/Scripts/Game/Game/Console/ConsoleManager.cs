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

            bool isExit = false;

            for (int index = 0; index < parameters.Length; index++) {
                try
                {
                    value[index] = Convert.ChangeType(parametersConsole[index], parameters[index].ParameterType);
                } catch (Exception e) { Debug.LogError(e); isExit = true; }
            }

            if (isExit) return null;
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

        private void InvokeMethodByType(MethodInfo methodInfo, string args)
        {
            if (methodInfo.IsStatic)
            {
                InvokeMethod(null, methodInfo, args);
            }
            else
            {
                UnityEngine.Object targetObject = FindAnyObjectByType(methodInfo.DeclaringType);

                if (targetObject != null)
                {
                    InvokeMethod(targetObject, methodInfo, args);
                }
            }
        }
        private void InvokeMethod(object obj, MethodInfo methodInfo, string argsCommand)
        {
            ParameterInfo[] parameters = methodInfo.GetParameters();
            if (parameters.Length == 0)
            {
                methodInfo.Invoke(obj, null);
                return;
            }
            else
            {
                object[] args = GetArgs(parameters, argsCommand.Split(" ; "));
                if (args == null) return;

                methodInfo.Invoke(obj, args);
                return;
            }
        }

        public void InvokeCommand(string command)
        {
            if (string.IsNullOrEmpty(command)) return;
            string[] commandAndArgs = command.Split(": ");
            if (commandAndArgs.Length == 0) return;
            Debug.Log(commandAndArgs[0]);

            if (Command.TryGetValue(commandAndArgs[0], out MethodInfo methodInfo)) {
                if (commandAndArgs.Length < 2) InvokeMethodByType(methodInfo, "");
                else InvokeMethodByType(methodInfo, commandAndArgs[1]);
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