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

        [SerializeField] private float _speed = 0.01f;
        [SerializeField] private TypeValueAnimation _typeValue;
        [SerializeField] private AnimationCurve _curveAnim;

        private Vector3 _oldPos, _newPos, _targetPos, _startPos;

        private bool _isPlay = false;

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
            _isPlay = true;
            _targetPos = _newPos;
            _startPos = _oldPos;
            _valueStep = 0;
        }
        [ContextMenu("PlayRevert")]
        public void PlayRevert() {
            _isPlay = true;
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
            _isPlay = false;
        }

        private void Update()
        {
            if (_isPlay) {
                _valueStep += Time.deltaTime * _speed;
                _valueStep = Mathf.Clamp(_valueStep, 0, 1);

                if (_valueStep == 1)
                {
                    transform.position = _targetPos;
                    _isPlay = false;
                }

                transform.position =
                    Vector3.Lerp(_startPos,
                        _targetPos,
                        _curveAnim.Evaluate(_valueStep));
            }
        }
    }
}