namespace EasyRibbon.Extensions ;

public static class StringExtension
{
    public static string RemoveWhitespace(this string str) => string.Concat(str.Where(c => ! char.IsWhiteSpace(c))) ;
}
