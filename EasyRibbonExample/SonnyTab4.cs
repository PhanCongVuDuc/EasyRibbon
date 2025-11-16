using EasyRibbon.UIAttributeBase ;
using EasyRibbonExample.Commands ;

namespace EasyRibbonExample ;

/// <summary>
/// Example tab demonstrating stacked buttons with pulldown button and resource-based names
/// </summary>
[Tab( "FAIL: Sonny Tab",
  NameKey = "Tab.SonnyTab4" )]
public class SonnyTab4
{
  [Panel( "FAIL: Sonny Pannel 4",
    NameKey = "Panel.SonnyPannel4" )]
  public class SonnyPannel4
  {
    [StackedButton( "FAIL: Sonny Stacked Button 4",
      NameKey = "StackedButton.SonnyStacked4" )]
    public class SonnyStackedButton4
    {
      [Button( "FAIL: Sonny Button 4-1",
        typeof( StartupCommand ),
        NameKey = "Button.SonnyButton4_1",
        ToolTipKey = "ToolTip.SonnyButton4_1",
        ToolTipDefault = "FAIL: ToolTip Sonny Button 4-1",
        Image = "/EasyRibbonExample;component/Resources/Icons/RibbonIcon16.png",
        LargeImage = "/EasyRibbonExample;component/Resources/Icons/RibbonIcon32.png",
        LongDescription = "This is Sonny Button 4-1",
        ToolTipImage = "/EasyRibbonExample;component/Resources/Icons/RibbonIcon32.png" )]
      public class SonnyButton4_1 ;

      [Button( "FAIL: Sonny Button 4-2",
        typeof( StartupCommand ),
        NameKey = "Button.SonnyButton4_2",
        ToolTipKey = "ToolTip.SonnyButton4_2",
        ToolTipDefault = "FAIL: ToolTip Sonny Button 4-2",
        Image = "/EasyRibbonExample;component/Resources/Icons/RibbonIcon16.png",
        LargeImage = "/EasyRibbonExample;component/Resources/Icons/RibbonIcon32.png",
        LongDescription = "This is Sonny Button 4-2" )]
      public class SonnyButton4_2 ;

      [PulldownButtonData( "FAIL: Sonny Pulldown Button Data 4",
        NameKey = "PulldownButton.SonnyPulldown4",
        ToolTipKey = "ToolTip.SonnyPulldown4",
        ToolTipDefault = "FAIL: ToolTip Sonny Pulldown 4",
        Image = "/EasyRibbonExample;component/Resources/Icons/RibbonIcon16.png",
        LargeImage = "/EasyRibbonExample;component/Resources/Icons/RibbonIcon32.png",
        LongDescription = "This is Sonny Pulldown Button Data 4",
        ToolTipImage = "/EasyRibbonExample;component/Resources/Icons/RibbonIcon32.png" )]
      public class SonnyPulldownButton4
      {
        [Button( "FAIL: Sonny Button 4-3",
          typeof( StartupCommand ),
          NameKey = "Button.SonnyButton4_3",
          ToolTipKey = "ToolTip.SonnyButton4_3",
          ToolTipDefault = "FAIL: ToolTip Sonny Button 4-3",
          Image = "/EasyRibbonExample;component/Resources/Icons/RibbonIcon16.png",
          LargeImage = "/EasyRibbonExample;component/Resources/Icons/RibbonIcon32.png",
          LongDescription = "This is Sonny Button 4-3",
          ToolTipImage = "/EasyRibbonExample;component/Resources/Icons/RibbonIcon32.png" )]
        public class SonnyButton4_3 ;

        [Button( "FAIL: Sonny Button 4-4",
          typeof( StartupCommand ),
          NameKey = "Button.SonnyButton4_4",
          ToolTipKey = "ToolTip.SonnyButton4_4",
          ToolTipDefault = "FAIL: ToolTip Sonny Button 4-4",
          Image = "/EasyRibbonExample;component/Resources/Icons/RibbonIcon16.png",
          LargeImage = "/EasyRibbonExample;component/Resources/Icons/RibbonIcon32.png",
          LongDescription = "This is Sonny Button 4-4" )]
        public class SonnyButton4_4 ;

        [Button( "FAIL: Sonny Button 4-5",
          typeof( StartupCommand ),
          NameKey = "Button.SonnyButton4_5",
          Image = "/EasyRibbonExample;component/Resources/Icons/RibbonIcon16.png",
          LargeImage = "/EasyRibbonExample;component/Resources/Icons/RibbonIcon32.png",
          LongDescription = "This is Sonny Button 4-5" )]
        public class SonnyButton4_5 ;
      }
    }
  }
}