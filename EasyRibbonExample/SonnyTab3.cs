using EasyRibbon.UIAttributeBase ;
using EasyRibbonExample.Commands ;

namespace EasyRibbonExample ;

[Tab( "Sonny Tab" )]
public class SonnyTab3
{
  [Panel( "Sonny Pannel 1" )]
  public class SonnyPannel1
  {
    [PulldownButtonData( "Sonny Pulldown Button Data 1",
      Image = "/EasyRibbonExample;component/Resources/Icons/RibbonIcon16.png",
      LargeImage = "/EasyRibbonExample;component/Resources/Icons/RibbonIcon32.png",
      LongDescription = "This is Test",
      ToolTipDefault = "This is toolTip",
      ToolTipImage = "/EasyRibbonExample;component/Resources/Icons/RibbonIcon32.png" )]
    public class PulldownButtonData1
    {
      [Button( "Sonny Button 1-5",
        typeof( StartupCommand ),
        Image = "/EasyRibbonExample;component/Resources/Icons/RibbonIcon16.png",
        LargeImage = "/EasyRibbonExample;component/Resources/Icons/RibbonIcon32.png",
        LongDescription = "This is Test",
        ToolTip = "This is toolTip",
        ToolTipImage = "/EasyRibbonExample;component/Resources/Icons/RibbonIcon32.png" )]
      public class SonnyButton1 ;

      [Button( "Sonny Button 1-6",
        typeof( StartupCommand ),
        Image = "/EasyRibbonExample;component/Resources/Icons/RibbonIcon16.png",
        LargeImage = "/EasyRibbonExample;component/Resources/Icons/RibbonIcon32.png",
        LongDescription = "This is Test" )]
      public class SonnyButton2 ;

      [Button( "Sonny Button 1-7",
        typeof( StartupCommand ),
        Image = "/EasyRibbonExample;component/Resources/Icons/RibbonIcon16.png",
        LargeImage = "/EasyRibbonExample;component/Resources/Icons/RibbonIcon32.png",
        LongDescription = "This is Test",
        ToolTip = "This is toolTip",
        ToolTipImage = "/EasyRibbonExample;component/Resources/Icons/RibbonIcon32.png" )]
      public class SonnyButton3 ;

      [Button( "Sonny Button 1-8",
        typeof( StartupCommand ),
        Image = "/EasyRibbonExample;component/Resources/Icons/RibbonIcon16.png",
        LargeImage = "/EasyRibbonExample;component/Resources/Icons/RibbonIcon32.png",
        LongDescription = "This is Test" )]
      public class SonnyButton4 ;

      [Button( "Sonny Button 1-9",
        typeof( StartupCommand ),
        Image = "/EasyRibbonExample;component/Resources/Icons/RibbonIcon16.png",
        LargeImage = "/EasyRibbonExample;component/Resources/Icons/RibbonIcon32.png",
        LongDescription = "This is Test",
        ToolTip = "This is toolTip",
        ToolTipImage = "/EasyRibbonExample;component/Resources/Icons/RibbonIcon32.png" )]
      public class SonnyButton5 ;

      [Button( "Sonny Button 1-10",
        typeof( StartupCommand ),
        Image = "/EasyRibbonExample;component/Resources/Icons/RibbonIcon16.png",
        LargeImage = "/EasyRibbonExample;component/Resources/Icons/RibbonIcon32.png",
        LongDescription = "This is Test" )]
      public class SonnyButton6 ;
    }
  }
}