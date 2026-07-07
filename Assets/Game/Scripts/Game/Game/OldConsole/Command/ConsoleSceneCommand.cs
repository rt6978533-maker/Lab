using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game.Console.Command
{
    [AddComponentMenu("Game/Console/Command/ConsoleScene")]
    public class ConsoleSceneCommand : MonoBehaviour
    {
        [ConsoleCommand("scene-load", RequireBinding.Cheats)]
        public void SetScene(int id)
        {
            SceneManager.LoadScene(id);
        }
    }
}
