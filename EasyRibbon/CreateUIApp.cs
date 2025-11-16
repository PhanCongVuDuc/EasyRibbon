using Autodesk.Revit.UI ;
using EasyRibbon.Extensions ;
using EasyRibbon.UIAttributeBase ;

namespace EasyRibbon ;

/// <summary>
/// Factory class for creating Revit ribbon UI from attribute-based configuration
/// </summary>
public class CreateUIApp
{
  /// <summary>
  /// Creates ribbon UI from type T that contains TabAttribute and nested panel/button classes
  /// </summary>
  /// <typeparam name="T">Type containing ribbon tab configuration</typeparam>
  /// <param name="application">UIControlledApplication instance</param>
  public static void CreateUI<T>( UIControlledApplication application ) where T : class
  {
    var tabAttribute = typeof( T ).GetCustomAttributes<TabAttribute>( false )
      .FirstOrDefault() ;
    if ( tabAttribute == null )
      return ;

    application.GetOrCreateRibbonTab( tabAttribute.Name ) ;

    var panelTypes = typeof( T ).GetClassTypes() ;
    foreach ( var panelType in panelTypes ) {
      ProcessPanel( application,
        panelType,
        tabAttribute.Name ) ;
    }
  }

  private static void ProcessPanel( UIControlledApplication application,
    Type panelType,
    string tabName )
  {
    var panelAttribute = panelType.GetCustomAttributes<PanelAttribute>( false )
      .FirstOrDefault() ;
    if ( panelAttribute == null )
      return ;

    panelAttribute.SetData( tabName ) ;
    var ribbonPanel = panelAttribute.CreateRibbonPanel( application ) ;
    if ( ribbonPanel == null )
      return ;

    var itemTypes = panelType.GetClassTypes() ;
    foreach ( var itemType in itemTypes ) {
      ProcessRibbonItem( ribbonPanel,
        itemType ) ;
    }
  }

  private static void ProcessRibbonItem( RibbonPanel ribbonPanel,
    Type itemType )
  {
    var attribute = itemType.GetCustomAttributes( false )
      .FirstOrDefault() ;

    switch ( attribute ) {
      case StackedButtonAttribute :
        ProcessStackedButtons( ribbonPanel,
          itemType ) ;
        break ;
      case PulldownButtonDataAttribute pulldownAttribute :
        ProcessPulldownButton( ribbonPanel,
          itemType,
          pulldownAttribute ) ;
        break ;
      case ButtonAttribute buttonAttribute :
        ProcessButton( ribbonPanel,
          buttonAttribute ) ;
        break ;
    }
  }

  private static void ProcessStackedButtons( RibbonPanel ribbonPanel,
    Type stackedButtonType )
  {
    var buttonTypes = stackedButtonType.GetClassTypes() ;
    var (stackedItems, pulldownConfigs) = CollectStackedItems( buttonTypes ) ;

    var stackedRibbonItems = ribbonPanel.AddStackedItemsMixed( stackedItems ) ;
    if ( stackedRibbonItems == null )
      return ;

    AddButtonsToPulldowns( stackedRibbonItems,
      pulldownConfigs ) ;
  }

  private static (List<object> stackedItems, List<(PulldownButtonData data, List<PushButtonData> buttons)>
    pulldownConfigs) CollectStackedItems( List<Type> buttonTypes )
  {
    var stackedItems = new List<object>() ;
    var pulldownConfigs = new List<(PulldownButtonData data, List<PushButtonData> buttons)>() ;

    foreach ( var buttonType in buttonTypes ) {
      if ( buttonType.GetCustomAttributes<ButtonAttribute>( false )
            .FirstOrDefault() is { } buttonAttribute ) {
        stackedItems.Add( buttonAttribute.CreatePushButtonData() ) ;
        continue ;
      }

      if ( buttonType.GetCustomAttributes<PulldownButtonDataAttribute>( false )
            .FirstOrDefault() is not { } pulldownAttribute ) {
        continue ;
      }

      var pulldownButtonData = pulldownAttribute.CreatePulldownButtonData() ;
      stackedItems.Add( pulldownButtonData ) ;

      var nestedButtonTypes = buttonType.GetClassTypes() ;
      var nestedButtons = CollectNestedButtons( nestedButtonTypes ) ;
      pulldownConfigs.Add( ( pulldownButtonData, nestedButtons ) ) ;
    }

    return ( stackedItems, pulldownConfigs ) ;
  }

  private static List<PushButtonData> CollectNestedButtons( List<Type> buttonTypes )
  {
    var buttons = new List<PushButtonData>() ;
    foreach ( var buttonType in buttonTypes ) {
      var buttonAttribute = buttonType.GetCustomAttributes<ButtonAttribute>( false )
        .FirstOrDefault() ;
      if ( buttonAttribute == null )
        continue ;

      buttons.Add( buttonAttribute.CreatePushButtonData() ) ;
    }

    return buttons ;
  }

  private static void AddButtonsToPulldowns( IList<RibbonItem> stackedRibbonItems,
    List<(PulldownButtonData data, List<PushButtonData> buttons)> pulldownConfigs )
  {
    foreach ( var (data, buttons) in pulldownConfigs ) {
      var pulldownButton = stackedRibbonItems.OfType<PulldownButton>()
        .FirstOrDefault( pb => pb.Name == data.Name ) ;
      if ( pulldownButton == null )
        continue ;

      foreach ( var buttonData in buttons ) {
        pulldownButton.AddPushButton( buttonData ) ;
      }
    }
  }

  private static void ProcessPulldownButton( RibbonPanel ribbonPanel,
    Type pulldownType,
    PulldownButtonDataAttribute pulldownAttribute )
  {
    var pulldownButtonData = pulldownAttribute.CreatePulldownButtonData() ;
    var pulldownButton = (PulldownButton) ribbonPanel.AddItem( pulldownButtonData ) ;

    var nestedButtonTypes = pulldownType.GetClassTypes() ;
    var nestedButtons = CollectNestedButtons( nestedButtonTypes ) ;
    foreach ( var buttonData in nestedButtons ) {
      pulldownButton.AddPushButton( buttonData ) ;
    }
  }

  private static void ProcessButton( RibbonPanel ribbonPanel,
    ButtonAttribute buttonAttribute )
  {
    var pushButtonData = buttonAttribute.CreatePushButtonData() ;
    ribbonPanel.AddItem( pushButtonData ) ;
  }
}