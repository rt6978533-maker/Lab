using System;
using System.Collections.Generic;
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
        [SerializeField] private ConsoleBaker _consoleBaker;

        private Dictionary<Type, object> _targetObjectCache = new();

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
                Type type = parameters[i].ParameterType;
                result[i] = TypeTools.ConvertToT(value[i], type);
            }

            return result;
        }

        public void CommandInvoke(string commands, string[] parameters) {
            if (string.IsNullOrEmpty(commands)) return;

            if (_consoleBaker.Baked.Commands.TryGetValue(commands, out MethodInfo method)) {
                object[] objectParameters = ConvertParameters(method.GetParameters(), parameters);
                if (method.IsStatic) {
                    method.Invoke(null, objectParameters);
                } else {
                    Type type = method.DeclaringType;
                    if (type == null) return;

                    if (_targetObjectCache.TryGetValue(type, out object obj))
                    {
                        method.Invoke(obj, objectParameters);
                    } else
                    {
                        object objFind = FindAnyObjectByType(type);
                        _targetObjectCache[type] = objFind;
                        method.Invoke(objFind, objectParameters);
                    }
                }
            }
        }

        public void Change(string newText)
        {
            if (_consoleBaker.BakedInfo == null) return;

            List<string> commands = _consoleBaker.BakedInfo.TrieCommands.FinsSuggestions(newText);
            Debug.LogWarning("Commands: ");
            foreach (var command in commands) Debug.Log(command);
        }
    }
}
