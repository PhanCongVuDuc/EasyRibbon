namespace EasyRibbon.Extensions ;

public static class StringExtension
{
  public static string RemoveWhitespace( this string str )
  {
    return string.Concat( str.Where( c => ! char.IsWhiteSpace( c ) ) ) ;
  }
}