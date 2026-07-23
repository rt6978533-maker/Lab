using System.Reflection;
using Unity.VisualScripting;
using UnityEngine;

namespace Game.NewConsole
{
    [AddComponentMenu("Game/NewConsole/IFModule/CheatsAndUnsafe")]
    public class IFConsole : IFModuleConsole
    {
        public bool IsCheats = false, IsUnsafe = false;

        [ConsoleCommand("cheats")]
        public void Cheats(bool value=false) => IsCheats = value;

        [ConsoleCommand("unsafe")]
        public void Unsafe(bool value=false) => IsUnsafe = value;


        private bool Test(ConsoleCommand command)
        { 
            if (command.Require.HasFlag(RequireBinding.None)) return true;
            else if (command.Require.HasFlag(RequireBinding.Cheats | RequireBinding.Unsafe)) return IsCheats & IsUnsafe;
            else if (command.Require.HasFlag(RequireBinding.Cheats)) return IsCheats;
            else if (command.Require.HasFlag(RequireBinding.Unsafe)) return IsUnsafe;

            return false;
        }

        protected override bool OnIF(MethodInfo methods)
        {
            if (!methods.HasAttribute(typeof(ConsoleCommand), false)) return false;

            ConsoleCommand c = (ConsoleCommand)methods.GetCustomAttribute(typeof(ConsoleCommand), false);

            return Test(c);
        }
    }
}
