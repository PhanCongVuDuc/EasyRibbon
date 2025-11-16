using System.IO ;
using System.Windows.Media.Imaging ;

namespace EasyRibbon.Extensions ;

/// <summary>
///     Extension methods for creating BitmapImage safely
/// </summary>
public static class ImageExtension
{
    /// <summary>
    ///     Try to create BitmapImage from image path. Returns null if file not found or any error occurs.
    /// </summary>
    /// <param name="imagePath">Path to image file (file system path or pack URI)</param>
    /// <returns>BitmapImage if successful, null otherwise</returns>
    public static BitmapImage? TryCreateBitmapImage(string? imagePath)
    {
        if (string.IsNullOrEmpty(imagePath))
        {
            return null ;
        }

        try
        {
            Uri uri = UriExtension.CreateUri(imagePath) ;

            // Check if it's a file path and file exists
            if (uri.IsFile
                && ! File.Exists(uri.LocalPath))
            {
                return null ;
            }

            return new BitmapImage(uri) ;
        }
        catch
        {
            // If any error occurs (file not found, invalid URI, etc.), return null
            return null ;
        }
    }
}
