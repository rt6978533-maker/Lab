using Game.Player.Module;
using GaS.Interface;
using GaS.Player;
using UnityEngine;

namespace Game.Player
{
    [AddComponentMenu("Game/Player/PlayerController")]
    public class PlayerController : PlayerCharacterController, IInitializable<PlayerInputSystem>
    {
        [Header("Look settings")]
        [SerializeField] private float _sensitivity = 1;
        [SerializeField] private int _passedFrameRate = 5;
        [SerializeField] private Transform _head;

        private float _lookY, _lookX;

        private ushort _frameCurrent;

        private ModuleController<Vector2> _move, _look;
        private ModuleController<bool> _sprint;

        protected override void OnAwake()
        {
            Vector3 angles = transform.localEulerAngles;
            _lookY = angles.y;
            _lookX = 0;
        }

        public void Init(PlayerInputSystem arg)
        {
            //Move
            MoveModule move = new();
            move.Init(arg);
            move.Enable();
            //Look
            LookModule look = new();
            look.Init(arg);
            look.Enable();
            //Sprint
            SprintModule sprint = new();
            sprint.Init(arg);
            sprint.Enable();

            _move = move;
            _look = look;
            _sprint = sprint;
        }

        private void LookController(Vector2 lookInput)
        {
            if (_head == null) return;

            lookInput *= _sensitivity;

            _lookY += lookInput.x;
            _lookX -= lookInput.y;
            _lookX = Mathf.Clamp(_lookX, -90.0f, 90.0f);

            transform.rotation = Quaternion.Euler(0, _lookY, 0);
            _head.rotation = Quaternion.Euler(_lookX, _lookY, 0);
        }

        private void Move()
        {
            if (_move == null) return;

            Vector2 input = _move.GetValue();

            if (_sprint == null) Move(input);

            if (!_sprint.GetValue()) Move(input);
            else MoveSprint(input);
        }

        private void Update() {
            //Move
            Move();

            _frameCurrent++;

            if (_frameCurrent <= _passedFrameRate) return;

            //Look
            LookController(_look.GetValue());
        }
    }
}