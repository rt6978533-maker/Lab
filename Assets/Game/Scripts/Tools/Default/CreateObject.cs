using System.Runtime.InteropServices.WindowsRuntime;
using Unity.VisualScripting;
using UnityEngine;

namespace Tools.Default
{
    enum TypeTransform
    {
        All, Position, Rotation, World, Parent
    }
    interface ICreatable
    {
        void Create();
        GameObject GetCreate();
    }

    [AddComponentMenu("Tools/Default/Create")]
    public class CreateObject : MonoBehaviour, ICreatable
    {
        [SerializeField] private GameObject _prefab;
        [Header("Value create: ")]
        [SerializeField] private Transform _transform;
        [SerializeField] private TypeTransform _type;

        public virtual void Create() => GetCreate();
        public virtual GameObject GetCreate()
        {
            if (_prefab == null) return null;

            switch (_type)
            {
                case TypeTransform.All: return Instantiate(_prefab, _transform.position, _transform.rotation);
                case TypeTransform.Rotation: return Instantiate(_prefab, Vector3.zero, _transform.rotation);
                case TypeTransform.Position: return Instantiate(_prefab, _transform.position, Quaternion.identity);
                case TypeTransform.Parent: return Instantiate(_prefab, _transform);
                case TypeTransform.World: return Instantiate(_prefab);
                default: return null;
            }
        }
    }
}