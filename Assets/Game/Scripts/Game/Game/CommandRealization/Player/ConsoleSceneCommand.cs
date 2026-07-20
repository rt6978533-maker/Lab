using UnityEngine;
using UnityEngine.SceneManagement;
using Game.NewConsole;

namespace Game.CommandRealization
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
