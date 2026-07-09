using System;
using System.Linq;
using System.Reflection;

namespace Game.NewConsole
{
    public static class TypeTools
    {
        public static void GetMethodInAttributeAssembly<T>(BindingFlags flags, out MethodInfo[] methodInfo) where T : Attribute
        {
            Assembly assembly = Assembly.GetExecutingAssembly();

            Type[] classes = assembly.GetTypes();
            methodInfo = classes.SelectMany(t => t.GetMethods(flags)).Where(m => m.IsDefined(typeof(T))).ToArray();
        }

        public static string GetNameInType(Type type)
        {
            return type switch
            {
                var t when t == typeof(bool) => "bool",
                var t when t == typeof(byte) => "byte",
                var t when t == typeof(short) => "short",
                var t when t == typeof(ushort) => "ushort",
                var t when t == typeof(int) => "int",
                var t when t == typeof(uint) => "uint",
                var t when t == typeof(float) => "float",
                var t when t == typeof(long) => "long",
                var t when t == typeof(ulong) => "long",
                var t when t == typeof(string) => "string",
                _ => "Null"
            };
        }

        public static object ConvertToT(object obj, Type type) {
            return Convert.ChangeType(obj, type);
        }
    }
}
