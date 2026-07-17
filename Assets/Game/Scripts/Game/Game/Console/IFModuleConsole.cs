using System.Reflection;
using UnityEngine;

namespace Game.NewConsole
{
    [RequireComponent(typeof(IConsoleIf))]
    public abstract class IFModuleConsole : MonoBehaviour
    {
        private IConsoleIf _consoleIf;

        private void Awake()
        {
            _consoleIf = GetComponent<IConsoleIf>();
            
            if (_consoleIf == null)
            {
                Debug.LogError("[IFModuleConsole][Awake] _consoleIf is null.");
                enabled = false;
                return;
            }
        }

        private void OnEnable() => _consoleIf.ConsoleIF = OnIF;

        protected virtual bool OnIF(MethodInfo methods) { return true; }
    }
}