using Autodesk.Revit.UI ;

namespace EasyRibbon.Extensions ;

/// <summary>
/// Extension methods for UIControlledApplication
/// </summary>
public static class UIControlledApplicationExtension
{
  /// <summary>
  /// Get or create a ribbon tab. If the tab already exists, it will not throw an exception.
  /// </summary>
  /// <param name="application">The UIControlledApplication instance</param>
  /// <param name="tabName">Name of the tab to get or create</param>
  /// <returns>True if tab was created, false if it already existed</returns>
  public static bool GetOrCreateRibbonTab( this UIControlledApplication application,
    string tabName )
  {
    try {
      application.CreateRibbonTab( tabName ) ;
      return true ; // Tab was created
    }
    catch {
      // Tab already exists
      return false ; // Tab already existed
    }
  }

  /// <summary>
  /// Get or create a ribbon panel. If the panel already exists, it will return the existing panel.
  /// </summary>
  /// <param name="application">The UIControlledApplication instance</param>
  /// <param name="tabName">Name of the tab containing the panel</param>
  /// <param name="panelName">Name of the panel to get or create</param>
  /// <returns>The RibbonPanel (either existing or newly created)</returns>
  public static RibbonPanel GetOrCreateRibbonPanel( this UIControlledApplication application,
    string tabName,
    string panelName )
  {
    try {
      // Try to create new panel
      return application.CreateRibbonPanel( tabName,
        panelName ) ;
    }
    catch {
      // Panel already exists, find and return it
      return application.GetRibbonPanels( tabName )
               .FirstOrDefault( p => p.Name == panelName ) ??
             throw new InvalidOperationException( $"Failed to get or create panel '{panelName}' in tab '{tabName}'" ) ;
    }
  }
}