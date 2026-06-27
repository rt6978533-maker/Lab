using System;
using UnityEngine;

namespace Game.Console {
    [AttributeUsage(AttributeTargets.Method)]
    public class ConsoleCommand : Attribute
    {
        public string CommandName { get; set; }

        public ConsoleCommand(string commandName) { CommandName = commandName; }
    }
}