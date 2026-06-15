using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

namespace Game
{
    [AddComponentMenu("Game/LevelLoader")]
    public class LevelLoader : MonoBehaviour
    {
        [SerializeField] private string _currentNameScene;
        [SerializeField] private string _levelNameScene;

        public UnityEvent OnLoadLevel;

        public void Load()
        {
            StartCoroutine(asyncLoadScene(_currentNameScene, _levelNameScene));
        }

        public IEnumerator asyncLoadScene(string currentNameScene, string levelNameScene)
        {
            OnLoadLevel?.Invoke();
            yield return SceneManager.LoadSceneAsync(levelNameScene, LoadSceneMode.Additive);
            yield return SceneManager.UnloadSceneAsync(currentNameScene);
        }
    }
}