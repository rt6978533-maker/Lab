using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Reflection;
using Unity.VisualScripting;
using UnityEngine;

namespace Game.Console
{
    [AddComponentMenu("Game/Console/ConsoleManager")]
    public class ConsoleManager : MonoBehaviour
    {
        [SerializeField] string _suffixCommand = ": ", _commandSeparator = " ; ";

        public Dictionary<string, MethodInfo> Command;
        public List<string> NameCommands { get; private set; }
        public bool Cheats = false, Unsafe = false;

        [ConsoleCommand("console_command_length")]
        public void LenghtCommand() => Debug.Log(Command.Count);

        [ConsoleCommand("cheats_mode")]
        public void SetCheats(bool state) {
            Cheats = state;
        }

        [ConsoleCommand("unsafe_mode")]
        public void SetUnsafe(bool state) {
            Unsafe = state;
        }

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
                object[] args = GetArgs(parameters, argsCommand.Split(_commandSeparator));
                if (args == null) return;

                methodInfo.Invoke(obj, args);
                return;
            }
        }

        public void InvokeCommand(string command)
        {
            if (string.IsNullOrEmpty(command)) return;

            string[] commandAndArgs = command.Split(_suffixCommand);
            if (commandAndArgs.Length == 0) return;

            if (Command.TryGetValue(commandAndArgs[0], out MethodInfo methodInfo)) {
                ConsoleCommand c = (ConsoleCommand)methodInfo.GetAttribute(typeof(ConsoleCommand), true);

                if (c.Require.HasFlag(RequireBinding.Cheats) && Cheats == false) return;
                if (c.Require.HasFlag(RequireBinding.Unsafe) && Unsafe == false) return;

                if (commandAndArgs.Length < 2) InvokeMethodByType(methodInfo, "");
                else InvokeMethodByType(methodInfo, commandAndArgs[1]);
            }
        }
        
        private string GetNameType(Type type)
        {
            return type switch
            {
                var t when t == typeof(bool) => "bool",
                var t when t == typeof(byte) => "byte",
                var t when t == typeof(short) => "short",
                var t when t == typeof(ushort) => "ushort",
                var t when t == typeof(int) => "int",
                var t when t == typeof(uint) => "uint",
                var t when t == typeof(float) => "float",
                var t when t == typeof(long) => "long",
                var t when t == typeof(ulong) => "ulong",
                var t when t == typeof(double) => "double",
                var t when t == typeof(string) => "string",
                _ => "not support Type" + nameof(type)
            };
        }
        private string GetParametersString(ParameterInfo[] parameters)
        {
            if (parameters == null || parameters.Length == 0) return "";

            string value;

            if (parameters[0].HasDefaultValue()) value = $"{parameters[0].Name}[{GetNameType(parameters[0].ParameterType)} = {parameters[0].DefaultValue}]";
            else value = $"{parameters[0].Name}[{GetNameType(parameters[0].ParameterType)}]";

            foreach (var parameter in parameters.AsSpan(1))
            {
                if (parameter.HasDefaultValue()) value += $"{_commandSeparator}{parameter.Name}[{GetNameType(parameter.ParameterType)} = {parameter.DefaultValue}]";
                else value += $"{_commandSeparator}{parameter.Name}[{GetNameType(parameter.ParameterType)}]";
            }

            return value;
        }
        private void AddNameCommand(MethodInfo item)
        {
            Attribute c = item.GetCustomAttribute(typeof(ConsoleCommand));
            ConsoleCommand command = (ConsoleCommand)c;

            NameCommands.Add(command.CommandName + _suffixCommand + GetParametersString(item.GetParameters()));
        }

        private void Awake()
        {
            NameCommands = new();
            Command = new Dictionary<string, MethodInfo>();

            IEnumerable<MethodInfo> methodsWithAttribute = GetMethodInAttrib(typeof(ConsoleCommand));

            foreach (var item in methodsWithAttribute)
            {
                Attribute c = item.GetCustomAttribute(typeof(ConsoleCommand));
                ConsoleCommand command = (ConsoleCommand)c;
                Command[command.CommandName] = item;
                AddNameCommand(item);
            }
        }
    }
}