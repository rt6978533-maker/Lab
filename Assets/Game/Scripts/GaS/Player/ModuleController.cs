using GaS.Interface;

namespace GaS.Player
{
    public abstract class ModuleController<T> : IGetType<T>
    {
        public bool IsEnable { get; private set; }

        public T GetValue()
        {
            if (!IsEnable) return default;
            return getValue();
        }

        protected virtual T getValue() { return default; }

        public void Enable() => IsEnable = true;
        public void Disable() => IsEnable = false;
    }
}