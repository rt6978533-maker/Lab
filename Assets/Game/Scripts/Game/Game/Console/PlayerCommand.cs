using Game.Player.Target;
using UnityEngine;
namespace Game.Console.Command
{
    public class PlayerCommand : MonoBehaviour
    {
        [SerializeField] private TargetSystem _targetSystem;
        [SerializeField] private Transform _camera;
        [SerializeField] private GameObject[] _prefabs;

        [ConsoleCommand("player_target")]
        public void SetTarget(string message)
        {
            _targetSystem.SetTarget(message);
        }

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

        [ConsoleCommand("create_prop")]
        public void CreateProp(uint id)
        {
            if (id >= _prefabs.Length) return;
            Ray ray = new Ray(_camera.position, _camera.forward);

            if (Physics.Raycast(ray, out RaycastHit hit))
            { Instantiate(_prefabs[id], hit.point, Quaternion.identity); }
        }
    }
}