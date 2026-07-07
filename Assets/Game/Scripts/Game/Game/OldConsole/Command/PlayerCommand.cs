using Game.Player.Target;
using GaS.Player;
using UnityEngine;
namespace Game.Console.Command
{
    public class PlayerCommand : MonoBehaviour
    {
        [SerializeField] private TargetSystem _targetSystem;
        [SerializeField] private Transform _camera;
        [SerializeField] private GameObject[] _prefabs;
        [SerializeField] private PlayerCharacterController _playerCharacterController;

        private GameObject[] _allResources;

        private void Awake()
        {
            _allResources = Resources.LoadAll<GameObject>("Prefabs");
        }

        [ConsoleCommand("player_target")]
        public void SetTarget(string message)
        {
            _targetSystem.SetTarget(message);
        }

        [ConsoleCommand("player_speed")]
        public void SetPlayerSpeed(float value) => _playerCharacterController.SetSpeed(value);

        [ConsoleCommand("player_multiple_sprint")]
        public void SetPlayerMultipleSprint(float value) => _playerCharacterController.SetMultipleSprint(value);

        [ConsoleCommand("raycast-destroy")]
        public void RaycastDestroy()
        {
            Ray ray = new Ray(_camera.position, _camera.forward);

            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                Destroy(hit.transform.gameObject);
            }
        }

        [ConsoleCommand("raycast-destroy_in_time")]
        public void RaycastDestroyInTime(float time)
        {
            Ray ray = new Ray(_camera.position, _camera.forward);

            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                Destroy(hit.transform.gameObject, time);
            }
        }

        [ConsoleCommand("create", RequireBinding.Cheats | RequireBinding.Unsafe)]
        public void CreateObject(uint id)
        {
            if (id >= _allResources.Length) return;
            Ray ray = new Ray(_camera.position, _camera.forward);

            if (Physics.Raycast(ray, out RaycastHit hit))
            { Instantiate(_allResources[id], hit.point, Quaternion.identity); }
        }

        [ConsoleCommand("create_prop", RequireBinding.Cheats)]
        public void CreateProp(uint id)
        {
            if (id >= _prefabs.Length) return;
            Ray ray = new Ray(_camera.position, _camera.forward);

            if (Physics.Raycast(ray, out RaycastHit hit))
            { Instantiate(_prefabs[id], hit.point, Quaternion.identity); }
        }
    }
}