using Game.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;

namespace Game.NewConsole
{
    [AddComponentMenu("Game/NewConsole/ConsoleBakedInfo")]
    public class ConsoleBakedInfo : MonoBehaviour
    {
        public Dictionary<MethodInfo, string> _textNameCommand, _textInfoCommand;
        [SerializeField] private ParseSettings _parseSettings;

        private IEnumerable<MethodInfo> GetMethodsAttrib<T>(Assembly assembly) where T : Attribute
        {
            if (assembly == null) return null;

            Type[] classes = assembly.GetTypes();

            IEnumerable<MethodInfo> methods = classes.SelectMany(t => t.GetMethods(
                BindingFlags.NonPublic | BindingFlags.Default | BindingFlags.Instance | BindingFlags.Public
                ));
            return methods.Where(m => m.IsDefined(typeof(T)));
        }

        private string GetInfoMethods(MethodInfo method)
        {
            ParameterInfo[] parameters = method.GetParameters();
            if (parameters.Length == 0) return "";

            ParameterInfo param = parameters[0];
            string result = _parseSettings.SuffixCommand + (param.HasDefaultValue ? $"{param.Name}[{TypeTools.GetNameInType(param.ParameterType)}]" :
                $"{param.Name}[{TypeTools.GetNameInType(param.ParameterType)} = {param.DefaultValue}]");

            foreach (ParameterInfo parameter in parameters.AsSpan(1))
            {
                if (parameter.HasDefaultValue) result += $"{_parseSettings.ArgumentSeparator}{parameter.Name}[{TypeTools.GetNameInType(parameter.ParameterType)} = {param.DefaultValue}]";
                else result += $"{_parseSettings.ArgumentSeparator}{parameter.Name}[{TypeTools.GetNameInType(parameter.ParameterType)}]"; 
            }

            return result;
        }

        private void Awake()
        {
            _textNameCommand = new();
            _textInfoCommand = new();

            Assembly assembly = Assembly.GetExecutingAssembly();

            IEnumerable<MethodInfo> methods = GetMethodsAttrib<ConsoleCommand>(assembly);

            foreach (MethodInfo method in methods)
            {
                Attribute attribute = method.GetCustomAttribute(typeof(ConsoleCommand));
                ConsoleCommand consoleCommand = (ConsoleCommand)attribute;

                _textNameCommand.Add(method, consoleCommand.CommandName);
                _textInfoCommand.Add(method, consoleCommand.CommandName + GetInfoMethods(method));
            }
        }
    }
}