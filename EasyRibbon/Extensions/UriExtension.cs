namespace EasyRibbon.Extensions ;

public class UriExtension
{
  public static Uri CreateUri( string linkImage )
  {
    // Handle pack URI format (e.g., /AssemblyName;component/Path/)
    Uri uri ;
    if ( linkImage.StartsWith( "/" ) ) {
      // Pack URI format - need full pack URI scheme
      var packUriString = "pack://application:,,," + linkImage ;
      uri = new Uri( packUriString,
        UriKind.RelativeOrAbsolute ) ;
    }
    else {
      // File system path
      uri = new Uri( linkImage,
        UriKind.Absolute ) ;
    }

    return uri ;
  }
}