using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace Game.NewConsole
{
    public interface IConsoleIf { public delegate bool ConsoleAdditionIf(MethodInfo method); public ConsoleAdditionIf ConsoleIF { get; set; } }
    public interface IConsoleChange { void Change(string newText); }
    public interface IConsoleCommandInvoke { void CommandInvoke(string commands, string[] parameters = null); }
    public interface IConsoleMethods : IConsoleCommandInvoke, IConsoleChange, IConsoleIf { }

    [AddComponentMenu("Game/NewConsole/ConsoleInterface")]
    public class ConsoleInterface : MonoBehaviour, IConsoleMethods
    {
        //IConsoleIf
        public IConsoleIf.ConsoleAdditionIf ConsoleIF { get; set; }

        //Setting
        [SerializeField] private ConsoleBaker _consoleBaker;
        [SerializeField] private ConsoleGraphics _consoleGraphics;
        [SerializeField] private ConsoleUI _consoleUI;

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
        private void MethodInvoke(MethodInfo method, object obj, object[] parameters) {
            if (method.ReturnType == typeof(void)) method.Invoke(obj, parameters);
            else if(method.ReturnType == typeof(string))
            {
                object returnValue = method.Invoke(obj, parameters);

                if (_consoleUI == null) return;

                _consoleUI.Say((string)returnValue, Color.white);
            }
        }

        public void CommandInvoke(string commands, string[] parameters) {
            if (string.IsNullOrEmpty(commands)) return;

            if (_consoleBaker.Baked.Commands.TryGetValue(commands, out MethodInfo method)) {
                if (ConsoleIF != null && !ConsoleIF.Invoke(method)) return; 

                object[] objectParameters = ConvertParameters(method.GetParameters(), parameters);

                if (method.IsStatic) {
                    MethodInvoke(method, null, objectParameters);
                } else {
                    Type type = method.DeclaringType;
                    if (type == null) return;

                    if (_targetObjectCache.TryGetValue(type, out object obj))
                    {
                        MethodInvoke(method, obj, objectParameters);
                    } else
                    {
                        object objFind = FindAnyObjectByType(type);

                        if (objFind == null)
                        {
                            Debug.LogWarning($"[ConsoleInterface][CommandInvoke] {commands}: {nameof(objFind)} not in scene.");
                            return;
                        }
                        _targetObjectCache[type] = objFind;
                        MethodInvoke(method, objFind, objectParameters);
                    }
                }
            }
        }

        public void Change(string newText)
        {
            if (_consoleBaker.BakedInfo == null || _consoleGraphics == null) return;

            List<string> commands = _consoleBaker.BakedInfo.TrieCommands.FindSuggestions(newText);
            _consoleGraphics.Render(commands);
        }
    }
}
