using UnityEngine;

namespace Tools.Default
{
    interface IDestroy { void Destroy(); }

    [AddComponentMenu("Tools/Default/Destroy")]
    public class DestroyObject : MonoBehaviour, IDestroy
    {
        public virtual void Destroy() => Destroy(gameObject);
        public virtual void DestroyGameObject(GameObject arg) => Destroy(arg);
    }
}