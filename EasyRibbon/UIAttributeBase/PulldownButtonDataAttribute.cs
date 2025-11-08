using Autodesk.Revit.UI ;
using System.Windows.Media.Imaging ;
using EasyRibbon.Extensions ;
using EasyRibbon.UIAttributeBase.Base ;

namespace EasyRibbon.UIAttributeBase ;

public class PulldownButtonDataAttribute( string name ) : Base.UIAttributeBase( name ), IRibbonItem
{
  public string? Image { get ; set ; }
  public string? LargeImage { get ; set ; }
  public string? ToolTipImage { get ; set ; }
  public string? LongDescription { get ; set ; }
  public string? ToolTip { get ; set ; }
  public string Unique => Name.RemoveWhitespace() ;

  public PulldownButtonData CreatePulldownButtonData()
  {
    var pulldownButtonData = new PulldownButtonData( Unique,
      Name ) ;

    // Set Image (16x16)
    if ( Image != null ) {
      var uri = UriExtension.CreateUri( Image ) ;
      var bitmapImage = new BitmapImage( uri ) ;
      pulldownButtonData.Image = bitmapImage ;
    }

    // Set LargeImage (32x32)
    if ( LargeImage != null ) {
      var uri = UriExtension.CreateUri( LargeImage ) ;
      var bitmapImage = new BitmapImage( uri ) ;
      pulldownButtonData.LargeImage = bitmapImage ;
    }

    // Set ToolTipImage
    if ( ToolTipImage != null ) {
      var uri = UriExtension.CreateUri( ToolTipImage ) ;
      var bitmapImage = new BitmapImage( uri ) ;
      pulldownButtonData.ToolTipImage = bitmapImage ;
    }

    if ( ! string.IsNullOrEmpty( LongDescription ) ) {
      pulldownButtonData.LongDescription = LongDescription ;
    }

    if ( ! string.IsNullOrEmpty( ToolTip ) ) {
      pulldownButtonData.ToolTip = ToolTip ;
    }

    return pulldownButtonData ;
  }
}