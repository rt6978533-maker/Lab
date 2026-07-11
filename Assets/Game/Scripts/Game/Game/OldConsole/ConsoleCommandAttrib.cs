using System;
using GaS.Interface;

namespace Game.Console {
    [Flags]
    public enum RequireBinding
    { 
        None = 0,  // 00
        Cheats = 1,// 10
        Unsafe = 2,// 01
    }

    [AttributeUsage(AttributeTargets.Method)]
    public class ConsoleCommand : Attribute
    {
        public string CommandName { get; set; }
        public RequireBinding Require { get; set; }
        public ConsoleCommand(string commandName, RequireBinding require = RequireBinding.None) { CommandName = commandName; Require = require; }
    }
}