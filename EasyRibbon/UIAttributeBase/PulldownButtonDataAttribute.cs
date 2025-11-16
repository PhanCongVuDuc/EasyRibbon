using Autodesk.Revit.UI ;
using EasyRibbon.Extensions ;
using EasyRibbon.UIAttributeBase.Base ;

namespace EasyRibbon.UIAttributeBase ;

public class PulldownButtonDataAttribute( string name ) : Base.UIAttributeBase( name ), IRibbonItem
{
  public string Unique => ResolveName().RemoveWhitespace() ;

  /// <summary>
  /// ToolTipKey and ToolTipDefault for resolving
  /// </summary>
  public string? ToolTipKey { get ; set ; }
  public string? ToolTipDefault { get ; set ; }
  public string? Image { get ; set ; }
  public string? LargeImage { get ; set ; }
  public string? ToolTipImage { get ; set ; }
  public string? LongDescription { get ; set ; }

  public PulldownButtonData CreatePulldownButtonData()
  {
    var displayName = ResolveName() ;

    var pulldownButtonData = new PulldownButtonData( Unique,
      displayName ) ;

    // Set Image (16x16)
    var image = ImageExtension.TryCreateBitmapImage( Image ) ;
    if ( image != null ) {
      pulldownButtonData.Image = image ;
    }

    // Set LargeImage (32x32)
    var largeImage = ImageExtension.TryCreateBitmapImage( LargeImage ) ;
    if ( largeImage != null ) {
      pulldownButtonData.LargeImage = largeImage ;
    }

    // Set ToolTipImage
    var toolTipImage = ImageExtension.TryCreateBitmapImage( ToolTipImage ) ;
    if ( toolTipImage != null ) {
      pulldownButtonData.ToolTipImage = toolTipImage ;
    }

    if ( ! string.IsNullOrEmpty( LongDescription ) ) {
      pulldownButtonData.LongDescription = LongDescription ;
    }

    // Resolve ToolTip from ToolTipKey or use ToolTipDefault
    var tooltip = GetResourceStringOrDefault( ToolTipKey,
      ToolTipDefault ) ;
    if ( ! string.IsNullOrEmpty( tooltip ) ) {
      pulldownButtonData.ToolTip = tooltip ;
    }

    return pulldownButtonData ;
  }
}