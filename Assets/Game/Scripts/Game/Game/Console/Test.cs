using System;
using UnityEngine;

namespace Game.Console
{
    public class Test : MonoBehaviour
    {
        [SerializeField] private ConsoleManager consoleManager;

        [ContextMenu("Print")]
        public void SendPrint()
        {
            consoleManager?.InvokeCommand("print");
        }

        [ConsoleCommand("print")]
        public void Print()
        {
            Debug.Log("Print");
        }
    }
}
