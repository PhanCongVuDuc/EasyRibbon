using System.Reflection ;

namespace EasyRibbon.Extensions ;

public static class TypeExtension
{
    public static List<TTypeAtribute> GetCustomAttributes<TTypeAtribute>(this Type type,
        bool inherit) =>
        type.GetCustomAttributes(inherit)
            .OfType<TTypeAtribute>()
            .ToList() ;

    public static List<Type> GetClassTypes(this Type type) =>
        type.GetNestedTypes(BindingFlags.Static | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
            .ToList() ;
}
