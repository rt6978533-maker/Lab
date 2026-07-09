using System;
using System.Collections.Generic;
using System.Reflection;
using Game.Console;

namespace Game.NewConsole {
    public class ConsoleBaked
    {
        public Dictionary<string, MethodInfo> Commands;

        public void Bake(MethodInfo[] methods)
        {
            Commands = new();

            foreach (var methodAttribute in methods)
            {
                Attribute attribute = methodAttribute.GetCustomAttribute(typeof(ConsoleCommand));
                ConsoleCommand command = (ConsoleCommand)attribute;

                Commands.Add(command.CommandName, methodAttribute);
            }
        }
    }
}
