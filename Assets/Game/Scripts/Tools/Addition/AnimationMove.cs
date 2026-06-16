using UnityEngine;

namespace Tools.Addition
{
    [AddComponentMenu("Tools/Addition/AnimationMove")]
    public class AnimationMove : MonoBehaviour
    {
        private enum TypeValueAnimation
        {
            OffsetPos, WorldPos
        }

        public Vector3 Value;
        [HideInInspector] public bool IsPlay { get; private set; }

        [SerializeField] private float _speed = 0.01f;
        [SerializeField] private TypeValueAnimation _typeValue;
        [SerializeField] private AnimationCurve _curveAnim;

        private Vector3 _oldPos, _newPos, _targetPos, _startPos;
        private float _valueStep;
        private Vector3 GetNewPos()
        {
            switch (_typeValue)
            {
                case TypeValueAnimation.OffsetPos: return _oldPos + Value;
                case TypeValueAnimation.WorldPos: return Value;
                default: return Vector3.zero;
            }
        }

        private void Awake() {
            _oldPos = transform.position;
            _newPos = GetNewPos();
        }

        [ContextMenu("Play")]
        public void Play() {
            IsPlay = true;
            _targetPos = _newPos;
            _startPos = _oldPos;
            _valueStep = 0;
        }
        [ContextMenu("PlayRevert")]
        public void PlayRevert() {
            IsPlay = true;
            _targetPos = _oldPos;
            _startPos = _newPos;
            _valueStep = 0;
        }
        [ContextMenu("Revert")]
        public void Revert() {
            transform.position = _oldPos;
        }

        [ContextMenu("Stop")]
        public void Stop() {
            IsPlay = false;
        }

        private void Update()
        {
            if (IsPlay) {
                _valueStep += Time.deltaTime * _speed;
                _valueStep = Mathf.Clamp(_valueStep, 0, 1);

                if (_valueStep == 1)
                {
                    transform.position = _targetPos;
                    IsPlay = false;
                }

                transform.position =
                    Vector3.Lerp(_startPos,
                        _targetPos,
                        _curveAnim.Evaluate(_valueStep));
            }
        }
    }
}