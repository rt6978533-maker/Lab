using UnityEngine;

namespace GaS.Player
{
    [RequireComponent(typeof(CharacterController))]
    public abstract class PlayerCharacterController : MonoBehaviour
    {
        [SerializeField] protected float _speed = 1;
        [SerializeField] protected float _multipleSprint = 1.5f;

        protected CharacterController _charactController;

        private void Awake()
        {
            _charactController = GetComponent<CharacterController>();
            OnAwake();
        }
        protected virtual void OnAwake() { }
        protected Vector3 GetMoveDir(Vector2 moveInput)
        {
            Vector3 dir = transform.forward * moveInput.y + transform.right * moveInput.x;
            dir.y = 0;
            return dir.normalized;
        }
        protected virtual void Move(Vector2 moveInput)
        {
            if (_charactController == null) return;

            _charactController.SimpleMove(GetMoveDir(moveInput) * _speed);
        }
        protected virtual void MoveSprint(Vector2 moveInput)
        {
            if (_charactController == null) return;

            _charactController.SimpleMove(GetMoveDir(moveInput) * _speed * _multipleSprint);
        }

        public void Teleport(Vector3 newPos)
        {
            if (_charactController == null)
            {
                Debug.LogError("[PlayerCharacterController] _charactController is null.");
                return;
            }

            _charactController.enabled = false;
            transform.position = newPos;
            _charactController.enabled = true;
        }
    }
}