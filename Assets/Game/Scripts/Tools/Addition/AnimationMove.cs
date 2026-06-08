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

        [SerializeField] private float _minRange = 0.1f;
        [SerializeField] private TypeValueAnimation _typeValue;

        private Vector3 OldPos, NewPos;

        private Vector3 GetNewPos()
        {
            switch (_typeValue)
            {
                case TypeValueAnimation.OffsetPos: return OldPos + Value;
                case TypeValueAnimation.WorldPos: return Value;
                default: return Vector3.zero;
            }
        }

        private void Awake() {
            OldPos = transform.position;
            NewPos = GetNewPos();
        }

        [ContextMenu("Play")]
        public void Play() {
            IsPlay = true;
        }
        [ContextMenu("Revert")]
        public void Revert() {
            transform.position = OldPos;
        }

        [ContextMenu("Stop")]
        public void Stop() {
            IsPlay = false; 
        }

        private void Update()
        {
            if (IsPlay) {
                Vector3 dir = NewPos - transform.position;

                if (dir.sqrMagnitude <= _minRange * _minRange)
                { 
                    IsPlay = false;
                    return;
                }

                transform.position += dir.normalized * Time.deltaTime;
            }
        }
    }
}