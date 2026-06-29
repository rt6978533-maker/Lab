using System;
using UnityEngine;

namespace Game.Console
{
    public class Test : MonoBehaviour
    {
        [SerializeField] private ConsoleManager consoleManager;
        [SerializeField] private string _command;

        [ContextMenu("Print")]
        public void SendPrint()
        {
            if (string.IsNullOrEmpty(_command)) return;
            consoleManager?.InvokeCommand(_command);
        }
    }
}
