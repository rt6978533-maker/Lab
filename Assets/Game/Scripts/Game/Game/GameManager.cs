using System.Collections;
using Tools.Default;
using UnityEngine;

namespace Game
{
    [AddComponentMenu("Game/GameManager")]
    [RequireComponent(typeof(ISceneLoader))]
    [RequireComponent(typeof(CreateObject))]
    public class GameManager : MonoBehaviour
    {
        private CreateObject _createPlayer;
        private ISceneLoader _loader;

        private void Awake()
        {
            _loader = GetComponent<ISceneLoader>();
            _createPlayer = GetComponent<CreateObject>();
        }

        private void Start() => 
            StartCoroutine(GameStart());

        IEnumerator GameStart()
        {
            Debug.Log("[GameManager] Load map.");
            yield return StartCoroutine(_loader.LoadSceneAsync());
            Debug.Log("[GameManager] well done.");

            Debug.Log("[GameManager] Create player.");
            _createPlayer.Create();
            Debug.Log("[GameManager] well done.");
        }
    }
}