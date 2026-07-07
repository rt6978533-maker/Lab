using System;
using System.Reflection;
using UnityEngine;

namespace Game.NewConsole
{
    interface IConsoleChange { void Change(string newText); }
    interface IConsoleCommandInvoke { void CommandInvoke(string commands, string[] parameters = null); }
    interface IConsoleMethods : IConsoleCommandInvoke, IConsoleChange { }

    [AddComponentMenu("Game/NewConsole/ConsoleInterface")]
    public class ConsoleInterface : MonoBehaviour, IConsoleMethods
    {
        [SerializeField] private ConsoleBaked _consoleBaked;

        private object[] ConvertParameters(ParameterInfo[] parameters, string[] value)
        {
            if (parameters == null || value == null) return null;
            if (parameters.Length != value.Length)
            {
                Debug.LogError($"[ConsoleInterface][ConvertParameters] parameters.Length({parameters.Length}) != value.Length({value.Length})");
                return null;
            }

            object[] result = new object[parameters.Length];

            for (int i = 0; i < parameters.Length; i++) {
                result[i] = Convert.ChangeType(value[i], parameters[i].ParameterType);
            }

            return result;
        }

        public void Change(string newText)
        {
            
        }
        public void CommandInvoke(string commands, string[] parameters) {
            if (string.IsNullOrEmpty(commands)) return;

            if (_consoleBaked.Commands.TryGetValue(commands, out MethodInfo method)) {
                object[] objectParameters = ConvertParameters(method.GetParameters(), parameters);
                if (method.IsStatic) {
                    method.Invoke(null, objectParameters);
                } else {
                    Type type = method.DeclaringType;
                    if (type == null) return;

                    object classes = FindAnyObjectByType(type);
                    method.Invoke(classes, objectParameters);
                }
            }
        }
    }
}
