using System.Windows ;

namespace EasyRibbon.Extensions ;

/// <summary>
/// Extension methods to resolve strings from ResourceDictionary
/// </summary>
public static class ResourceExtension
{
  /// <summary>
  /// Resolves string from key by searching in Application.Current.Resources
  /// If not found, returns the original key
  /// </summary>
  /// <param name="key">Key to search in ResourceDictionary</param>
  /// <returns>Resolved string or original key if not found</returns>
  public static string? ResolveString( string? key )
  {
    if ( string.IsNullOrEmpty( key ) )
      return null ;

    // Automatically search in Application.Current.Resources
    try {
      if ( Application.Current != null ) {
        var resource = Application.Current.TryFindResource( key ) ;
        if ( resource is string str
             && ! string.IsNullOrEmpty( str ) )
          return str ;
      }
    }
    catch {
      // Ignore errors, fallback to key
    }

    // Fallback: return original key
    return key ;
  }
}