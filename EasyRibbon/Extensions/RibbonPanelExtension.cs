using Autodesk.Revit.UI ;

namespace EasyRibbon.Extensions ;

public static class RibbonPanelExtension
{
    /// <summary>
    ///     Add stacked items supporting both PushButtonData and PulldownButtonData
    /// </summary>
    public static IList<RibbonItem>? AddStackedItemsMixed(this RibbonPanel ribbonPanel,
        List<object> items)
    {
        if (items.Count is < 2 or > 3)
        {
            return null ;
        }

        // Convert to appropriate types
        object? item0 = items[0] ;
        object? item1 = items[1] ;
        object? item2 = items.Count > 2 ? items[2] : null ;

        // Handle 2 items
        if (items.Count == 2)
        {
            return (item0, item1) switch
            {
                (PushButtonData pb0, PushButtonData pb1) => ribbonPanel.AddStackedItems(pb0,
                    pb1),
                (PulldownButtonData pd0, PulldownButtonData pd1) => ribbonPanel.AddStackedItems(pd0,
                    pd1),
                (PushButtonData pb0, PulldownButtonData pd1) => ribbonPanel.AddStackedItems(pb0,
                    pd1),
                (PulldownButtonData pd0, PushButtonData pb1) => ribbonPanel.AddStackedItems(pd0,
                    pb1),
                _ => null
            } ;
        }

        // Handle 3 items
        if (items.Count == 3
            && item2 != null)
        {
            return (item0, item1, item2) switch
            {
                (PushButtonData pb0, PushButtonData pb1, PushButtonData pb2) => ribbonPanel.AddStackedItems(pb0,
                    pb1,
                    pb2),
                (PulldownButtonData pd0, PulldownButtonData pd1, PulldownButtonData pd2) => ribbonPanel.AddStackedItems(
                    pd0,
                    pd1,
                    pd2),
                (PushButtonData pb0, PushButtonData pb1, PulldownButtonData pd2) => ribbonPanel.AddStackedItems(pb0,
                    pb1,
                    pd2),
                (PushButtonData pb0, PulldownButtonData pd1, PushButtonData pb2) => ribbonPanel.AddStackedItems(pb0,
                    pd1,
                    pb2),
                (PulldownButtonData pd0, PushButtonData pb1, PushButtonData pb2) => ribbonPanel.AddStackedItems(pd0,
                    pb1,
                    pb2),
                (PulldownButtonData pd0, PulldownButtonData pd1, PushButtonData pb2) => ribbonPanel.AddStackedItems(pd0,
                    pd1,
                    pb2),
                (PushButtonData pb0, PulldownButtonData pd1, PulldownButtonData pd2) => ribbonPanel.AddStackedItems(pb0,
                    pd1,
                    pd2),
                (PulldownButtonData pd0, PushButtonData pb1, PulldownButtonData pd2) => ribbonPanel.AddStackedItems(pd0,
                    pb1,
                    pd2),
                _ => null
            } ;
        }

        return null ;
    }
}
