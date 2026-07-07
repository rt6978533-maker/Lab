using System;
using System.Linq;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using Game.Console;

namespace Game.NewConsole {
    [AddComponentMenu("Game/NewConsole/ConsoleBaked")]
    public class ConsoleBaked : MonoBehaviour
    {
        public Dictionary<string, MethodInfo> Commands;

        private IEnumerable<MethodInfo> GetMethodsAttrib<T>(Assembly assembly) where T : Attribute
        {
            if (assembly == null) return null;

            Type[] classes = assembly.GetTypes();

            IEnumerable<MethodInfo> methods = classes.SelectMany(t => t.GetMethods(
                BindingFlags.NonPublic | BindingFlags.Default | BindingFlags.Instance | BindingFlags.Public
                ));
            return methods.Where(m => m.IsDefined(typeof(T)));
        }

        private void Awake()
        {
            Commands = new Dictionary<string, MethodInfo>();

            Assembly assembly = Assembly.GetExecutingAssembly();
            IEnumerable<MethodInfo> methodsAttribute = GetMethodsAttrib<ConsoleCommand>(assembly);

            foreach (var methodAttribute in methodsAttribute)
            {
                Attribute attribute = methodAttribute.GetCustomAttribute(typeof(ConsoleCommand));
                ConsoleCommand command = (ConsoleCommand)attribute;

                Commands.Add(command.CommandName, methodAttribute);
            }
        }
    }
}
