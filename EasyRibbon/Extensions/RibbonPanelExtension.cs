using Autodesk.Revit.UI ;

namespace EasyRibbon.Extensions ;

public static class RibbonPanelExtension
{
  public static IList<RibbonItem>? AddStackedItems( this RibbonPanel ribbonPanel,
    List<PushButtonData> pushButtonDatas )
  {
    const int amount2PushButtonData = 2 ;
    const int amount3PushButtonData = 3 ;
    var result = pushButtonDatas.Count switch
    {
      amount2PushButtonData => ribbonPanel.AddStackedItems( pushButtonDatas[ 0 ],
        pushButtonDatas[ 1 ] ),
      amount3PushButtonData => ribbonPanel.AddStackedItems( pushButtonDatas[ 0 ],
        pushButtonDatas[ 1 ],
        pushButtonDatas[ 2 ] ),
      _ => null
    } ;

    return result ;
  }
}