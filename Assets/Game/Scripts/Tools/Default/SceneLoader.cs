using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Tools.Default
{
    interface ISceneLoader
    {
        void LoadScene();
        IEnumerator LoadSceneAsync();
    }

    [AddComponentMenu("Tools/Default/SceneLoader")]
    public class SceneLoader : MonoBehaviour, ISceneLoader
    {
        [SerializeField] private string _sceneName;
        [SerializeField] private LoadSceneMode _loadType;

        public void LoadScene()
        {
            SceneManager.LoadScene(_sceneName, _loadType);
        }

        public IEnumerator LoadSceneAsync()
        {
            yield return SceneManager.LoadSceneAsync(_sceneName, _loadType);
        }
    }
}