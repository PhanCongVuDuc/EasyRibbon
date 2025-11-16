using EasyRibbon.Extensions ;

namespace EasyRibbon.UIAttributeBase.Base ;

[AttributeUsage( AttributeTargets.Class )]
public class UIAttributeBase( string name ) : Attribute
{
  public string Name { get ; } = name ;

  /// <summary>
  /// NameKey to resolve from ResourceDictionary, if not found then use Name as fallback
  /// </summary>
  public string? NameKey { get ; set ; }

  /// <summary>
  /// Resolves display name from NameKey or uses Name as fallback
  /// </summary>
  protected string ResolveName()
  {
    return GetResourceStringOrDefault( NameKey,
      Name )! ;
  }

  protected string? GetResourceStringOrDefault( string? resourceKey,
    string? toolTipDefault )
  {
    return ResourceExtension.ResolveString( resourceKey ) ?? toolTipDefault ;
  }
}