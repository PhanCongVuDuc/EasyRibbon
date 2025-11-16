using Autodesk.Revit.UI ;
using EasyRibbon.Extensions ;
using EasyRibbon.UIAttributeBase ;

namespace EasyRibbon ;

/// <summary>
///     Factory class for creating Revit ribbon UI from attribute-based configuration
/// </summary>
public class CreateUIApp
{
    /// <summary>
    ///     Creates ribbon UI from type T that contains TabAttribute and nested panel/button classes
    /// </summary>
    /// <typeparam name="T">Type containing ribbon tab configuration</typeparam>
    /// <param name="application">UIControlledApplication instance</param>
    public static void CreateUI<T>(UIControlledApplication application) where T : class
    {
        TabAttribute? tabAttribute = typeof( T ).GetCustomAttributes<TabAttribute>(false)
            .FirstOrDefault() ;
        if (tabAttribute == null)
        {
            return ;
        }

        string tabName = tabAttribute.ResolveName() ;
        application.GetOrCreateRibbonTab(tabName) ;

        List<Type> panelTypes = typeof( T ).GetClassTypes() ;
        foreach (Type? panelType in panelTypes)
        {
            ProcessPanel(application,
                panelType,
                tabName) ;
        }
    }

    private static void ProcessPanel(UIControlledApplication application,
        Type panelType,
        string tabName)
    {
        PanelAttribute? panelAttribute = panelType.GetCustomAttributes<PanelAttribute>(false)
            .FirstOrDefault() ;
        if (panelAttribute == null)
        {
            return ;
        }

        panelAttribute.SetData(tabName) ;
        RibbonPanel? ribbonPanel = panelAttribute.CreateRibbonPanel(application) ;
        if (ribbonPanel == null)
        {
            return ;
        }

        List<Type> itemTypes = panelType.GetClassTypes() ;
        foreach (Type? itemType in itemTypes)
        {
            ProcessRibbonItem(ribbonPanel,
                itemType) ;
        }
    }

    private static void ProcessRibbonItem(RibbonPanel ribbonPanel,
        Type itemType)
    {
        object? attribute = itemType.GetCustomAttributes(false)
            .FirstOrDefault() ;

        switch (attribute)
        {
            case StackedButtonAttribute :
                ProcessStackedButtons(ribbonPanel,
                    itemType) ;
                break ;
            case PulldownButtonDataAttribute pulldownAttribute :
                ProcessPulldownButton(ribbonPanel,
                    itemType,
                    pulldownAttribute) ;
                break ;
            case ButtonAttribute buttonAttribute :
                ProcessButton(ribbonPanel,
                    buttonAttribute) ;
                break ;
        }
    }

    private static void ProcessStackedButtons(RibbonPanel ribbonPanel,
        Type stackedButtonType)
    {
        List<Type> buttonTypes = stackedButtonType.GetClassTypes() ;
        (List<object> stackedItems, List<(PulldownButtonData data, List<PushButtonData> buttons)> pulldownConfigs) =
            CollectStackedItems(buttonTypes) ;

        IList<RibbonItem>? stackedRibbonItems = ribbonPanel.AddStackedItemsMixed(stackedItems) ;
        if (stackedRibbonItems == null)
        {
            return ;
        }

        AddButtonsToPulldowns(stackedRibbonItems,
            pulldownConfigs) ;
    }

    private static (List<object> stackedItems, List<(PulldownButtonData data, List<PushButtonData> buttons)>
        pulldownConfigs) CollectStackedItems(List<Type> buttonTypes)
    {
        List<object> stackedItems = new() ;
        List<(PulldownButtonData data, List<PushButtonData> buttons)> pulldownConfigs = new() ;

        foreach (Type? buttonType in buttonTypes)
        {
            if (buttonType.GetCustomAttributes<ButtonAttribute>(false)
                    .FirstOrDefault() is { } buttonAttribute)
            {
                stackedItems.Add(buttonAttribute.CreatePushButtonData()) ;
                continue ;
            }

            if (buttonType.GetCustomAttributes<PulldownButtonDataAttribute>(false)
                    .FirstOrDefault() is not { } pulldownAttribute)
            {
                continue ;
            }

            PulldownButtonData pulldownButtonData = pulldownAttribute.CreatePulldownButtonData() ;
            stackedItems.Add(pulldownButtonData) ;

            List<Type> nestedButtonTypes = buttonType.GetClassTypes() ;
            List<PushButtonData> nestedButtons = CollectNestedButtons(nestedButtonTypes) ;
            pulldownConfigs.Add((pulldownButtonData, nestedButtons)) ;
        }

        return (stackedItems, pulldownConfigs) ;
    }

    private static List<PushButtonData> CollectNestedButtons(List<Type> buttonTypes)
    {
        List<PushButtonData> buttons = new() ;
        foreach (Type? buttonType in buttonTypes)
        {
            ButtonAttribute? buttonAttribute = buttonType.GetCustomAttributes<ButtonAttribute>(false)
                .FirstOrDefault() ;
            if (buttonAttribute == null)
            {
                continue ;
            }

            buttons.Add(buttonAttribute.CreatePushButtonData()) ;
        }

        return buttons ;
    }

    private static void AddButtonsToPulldowns(IList<RibbonItem> stackedRibbonItems,
        List<(PulldownButtonData data, List<PushButtonData> buttons)> pulldownConfigs)
    {
        foreach ((PulldownButtonData data, List<PushButtonData> buttons) in pulldownConfigs)
        {
            PulldownButton? pulldownButton = stackedRibbonItems.OfType<PulldownButton>()
                .FirstOrDefault(pb => pb.Name == data.Name) ;
            if (pulldownButton == null)
            {
                continue ;
            }

            foreach (PushButtonData? buttonData in buttons)
            {
                pulldownButton.AddPushButton(buttonData) ;
            }
        }
    }

    private static void ProcessPulldownButton(RibbonPanel ribbonPanel,
        Type pulldownType,
        PulldownButtonDataAttribute pulldownAttribute)
    {
        PulldownButtonData pulldownButtonData = pulldownAttribute.CreatePulldownButtonData() ;
        PulldownButton? pulldownButton = (PulldownButton)ribbonPanel.AddItem(pulldownButtonData) ;

        List<Type> nestedButtonTypes = pulldownType.GetClassTypes() ;
        List<PushButtonData> nestedButtons = CollectNestedButtons(nestedButtonTypes) ;
        foreach (PushButtonData? buttonData in nestedButtons)
        {
            pulldownButton.AddPushButton(buttonData) ;
        }
    }

    private static void ProcessButton(RibbonPanel ribbonPanel,
        ButtonAttribute buttonAttribute)
    {
        PushButtonData pushButtonData = buttonAttribute.CreatePushButtonData() ;
        ribbonPanel.AddItem(pushButtonData) ;
    }
}
