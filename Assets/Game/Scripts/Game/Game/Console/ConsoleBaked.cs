using Game.Console;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace Game.NewConsole {
    public class ConsoleBaked
    {
        public Dictionary<string, MethodInfo> Commands;

        public void Bake(MethodInfo[] methods)
        {
            Commands = new();

            foreach (var methodAttribute in methods) InsertCommand(methodAttribute); 
        }

        public virtual void InsertCommand(MethodInfo method) => Commands.Add(method.Name, method); 
    }
}
