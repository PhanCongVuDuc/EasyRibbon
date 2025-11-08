using Autodesk.Revit.UI ;
using EasyRibbon.Extensions ;
using EasyRibbon.UIAttributeBase ;

namespace EasyRibbon ;

public class CreateUIApp
{
  public static void CreateUI<T>( UIControlledApplication application ) where T : class
  {
    var tab = typeof( T ).GetCustomAttributes<TabAttribute>( false )
      .FirstOrDefault() ;
    if ( tab == null )
      return ;

    // Get or create ribbon tab (won't throw exception if tab already exists)
    application.GetOrCreateRibbonTab( tab.Name ) ;

    var panels = typeof( T ).GetClassTypes() ;

    foreach ( var panel in panels ) {
      if ( panel.GetCustomAttributes<PanelAttribute>( false )
            .FirstOrDefault() is not { } panelAttribute ) {
        continue ;
      }

      panelAttribute.SetData( tab.Name ) ;
      if ( panelAttribute.CreateRibbonPanel( application ) is not { } ribbonPanel ) {
        continue ;
      }

      var types = panel.GetClassTypes() ;
      foreach ( var type in types ) {
        var atrItem = type.GetCustomAttributes( false ).FirstOrDefault() ;
        switch ( atrItem ) {
          case StackedButtonAttribute :
            var classButtonTypes = type.GetClassTypes() ;
            var pushButtonDatas = new List<PushButtonData>() ;
            foreach ( var classButtonType in classButtonTypes ) {
              var buttonAttribute = classButtonType.GetCustomAttributes<ButtonAttribute>( false )
                .FirstOrDefault() ;
              if ( buttonAttribute == null ) {
                continue ;
              }

              pushButtonDatas.Add( buttonAttribute.CreatePushButtonData() ) ;
            }

            ribbonPanel.AddStackedItems( pushButtonDatas ) ;
            break ;
          case PulldownButtonDataAttribute pulldownButtonDataAttribute :
            var classButtonTypes1 = type.GetClassTypes() ;
            var pulldownButtonData = pulldownButtonDataAttribute.CreatePulldownButtonData() ;
            var pulldownButton = (PulldownButton) ribbonPanel.AddItem( pulldownButtonData ) ;
            foreach ( var classButtonType in classButtonTypes1 ) {
              var buttonAttribute = classButtonType.GetCustomAttributes<ButtonAttribute>( false )
                .FirstOrDefault() ;

              if ( buttonAttribute == null ) {
                continue ;
              }

              pulldownButton.AddPushButton( buttonAttribute.CreatePushButtonData() ) ;
            }

            break ;
          case ButtonAttribute buttonAttribute :
            var pushButtonData = buttonAttribute.CreatePushButtonData() ;
            ribbonPanel.AddItem( pushButtonData ) ;

            break ;
        }
      }
    }
  }
}