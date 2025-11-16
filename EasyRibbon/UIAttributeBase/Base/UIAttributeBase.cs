using EasyRibbon.Extensions ;

namespace EasyRibbon.UIAttributeBase.Base ;

[AttributeUsage(AttributeTargets.Class)]
public class UIAttributeBase(string name) : Attribute
{
    public string Name { get ; } = name ;

    /// <summary>
    ///     NameKey to resolve from ResourceDictionary, if not found then use Name as fallback
    /// </summary>
    public string? NameKey { get ; set ; }

    /// <summary>
    ///     Resolves display name from NameKey or uses Name as fallback
    /// </summary>
    public string ResolveName()
    {
        string? resourceStringOrDefault = GetResourceStringOrDefault(NameKey,
            Name) ;
        return resourceStringOrDefault ?? Name ;
    }

    protected string? GetResourceStringOrDefault(string? resourceKey,
        string? defaultString)
    {
        string? resourceStringOrDefault = ResourceExtension.ResolveString(resourceKey) ;
        return resourceStringOrDefault ?? defaultString ;
    }
}
