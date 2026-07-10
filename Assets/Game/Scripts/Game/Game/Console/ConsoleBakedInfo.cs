using Game.Console;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace Game.NewConsole
{
    public class ConsoleBakedInfo
    {
        public Dictionary<string, string> TextInfoCommand;
        public TrieManager TrieCommands;

        public ParseSettings ParseSettings;

        private string GetInfoMethods(MethodInfo method)
        {
            ParameterInfo[] parameters = method.GetParameters();
            if (parameters.Length == 0) return "";

            ParameterInfo param = parameters[0];
            string result = ParseSettings.SuffixCommand + (!param.HasDefaultValue ? $"{param.Name}[{TypeTools.GetNameInType(param.ParameterType)}]" :
                $"{param.Name}[{TypeTools.GetNameInType(param.ParameterType)} = {param.DefaultValue}]");

            foreach (ParameterInfo parameter in parameters.AsSpan(1))
            {
                if (parameter.HasDefaultValue) result += $"{ParseSettings.ArgumentSeparator}{parameter.Name}[{TypeTools.GetNameInType(parameter.ParameterType)} = {parameter.DefaultValue}]";
                else result += $"{ParseSettings.ArgumentSeparator}{parameter.Name}[{TypeTools.GetNameInType(parameter.ParameterType)}]"; 
            }

            return result;
        }

        public void Bake(MethodInfo[] methods)
        {
            TrieCommands = new();
            TextInfoCommand = new();

            foreach (MethodInfo method in methods)
            {
                Attribute attribute = method.GetCustomAttribute(typeof(ConsoleCommand));
                ConsoleCommand consoleCommand = (ConsoleCommand)attribute;

                TrieCommands.Insert(consoleCommand.CommandName);
                TextInfoCommand.Add(consoleCommand.CommandName, consoleCommand.CommandName + GetInfoMethods(method));
            }
        }
    }
}