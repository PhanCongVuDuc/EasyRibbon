using Autodesk.Revit.UI ;
using System.Windows.Media.Imaging ;
using EasyRibbon.Extensions ;
using EasyRibbon.UIAttributeBase.Base ;

namespace EasyRibbon.UIAttributeBase ;

public class ButtonAttribute( string name, Type commandType ) : Base.UIAttributeBase( name ), IRibbonItem
{
  private Type CommandType { get ; } = commandType ?? throw new ArgumentNullException( nameof( commandType ) ) ;

  private string ClassName => CommandType.FullName ?? throw new InvalidOperationException( "Command type must have a FullName" ) ;

  private string AssemblyPath => CommandType.Assembly.Location ;
  public string Unique => Name.RemoveWhitespace() ;
  public string? Image { get ; set ; }
  public string? LargeImage { get ; set ; }
  public string? ToolTipImage { get ; set ; }
  public string? LongDescription { get ; set ; }
  public string? ToolTip { get ; set ; }

  public PushButtonData CreatePushButtonData()
  {
    var buttonData = new PushButtonData( Unique,
      Name,
      AssemblyPath,
      ClassName ) ;

    // Set Image (16x16)
    if ( Image != null ) {
      var uri = UriExtension.CreateUri( Image ) ;
      var bitmapImage = new BitmapImage( uri ) ;
      buttonData.Image = bitmapImage ;
    }

    // Set LargeImage (32x32)
    if ( LargeImage != null ) {
      var uri = UriExtension.CreateUri( LargeImage ) ;
      var bitmapImage = new BitmapImage( uri ) ;
      buttonData.LargeImage = bitmapImage ;
    }

    // Set ToolTipImage
    if ( ToolTipImage != null ) {
      var uri = UriExtension.CreateUri( ToolTipImage ) ;
      var bitmapImage = new BitmapImage( uri ) ;
      buttonData.ToolTipImage = bitmapImage ;
    }

    if ( ! string.IsNullOrEmpty( LongDescription ) ) {
      buttonData.LongDescription = LongDescription ;
    }

    if ( ! string.IsNullOrEmpty( ToolTip ) ) {
      buttonData.ToolTip = ToolTip ;
    }

    return buttonData ;
  }
}