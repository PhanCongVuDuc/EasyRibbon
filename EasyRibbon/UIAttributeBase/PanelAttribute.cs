using Autodesk.Revit.UI ;
using EasyRibbon.Extensions ;

namespace EasyRibbon.UIAttributeBase ;

public class PanelAttribute( string name ) : Base.UIAttributeBase( name )
{
  private string? _tabName ;

  public void SetData( string tabName )
  {
    _tabName = tabName ;
  }

  public RibbonPanel? CreateRibbonPanel( UIControlledApplication application )
  {
    // Get or create ribbon panel (won't throw exception if panel already exists)
    return _tabName == null
      ? null
      : application.GetOrCreateRibbonPanel( _tabName,
        Name ) ;
  }
}