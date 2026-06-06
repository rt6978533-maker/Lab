namespace GaS.Interface
{
    interface IInitializable
    { void Init(); }
    interface IInitializable<T>
    { void Init(T arg); }
    interface IInitializable<T1, T2>
    { void Init(T1 args1, T2 args2); }
}