using Autodesk.Revit.UI ;
using EasyRibbon ;
using EasyRibbon.Modules ;

namespace EasyRibbonExample ;

/// <summary>
/// Example module for demonstration
/// </summary>
public class ExampleModule : IApplicationModule
{
  public string ModuleName => "Example EasyRibbon Module" ;
  
  public void OnStartup( UIControlledApplication application )
  {
    // Create ribbon UI
    CreateUIApp.CreateUI<SonnyTab1>( application ) ;
    CreateUIApp.CreateUI<SonnyTab2>( application ) ;
    CreateUIApp.CreateUI<SonnyTab3>( application ) ;
  }
  
  public void OnShutdown( UIControlledApplication application )
  {
    // Cleanup if needed (optional)
    // For example: dispose resources, save settings, etc.
  }
}

