using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game.Console.Command
{
    [AddComponentMenu("Game/Console/Command/MapsCommand")]
    public class MapsCommand : MonoBehaviour
    {


        private int _nextLevel, _backLevel;

        [ConsoleCommand("mp_restart")]
        public void Restart()
        { SceneManager.LoadScene(SceneManager.GetActiveScene().name); }

        [ConsoleCommand("mp_next", RequireBinding.Cheats)]
        public void NextLevel()
        { SceneManager.LoadScene(_nextLevel); }
        
        [ConsoleCommand("mp_back", RequireBinding.Cheats)]
        public void BackLevel()
        { SceneManager.LoadScene(_backLevel); }
    }
}