using UnityEngine;
using Game.NewConsole;
using UnityEngine.SceneManagement;

namespace Game.CommandRealization
{
    [AddComponentMenu("Game/Console/Command/MapsCommand")]
    public class MapsCommand : MonoBehaviour
    {
        [SerializeField] private int _nextLevel, _backLevel;

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