using EasyRibbon.UIAttributeBase ;
using EasyRibbonExample.Commands ;

namespace EasyRibbonExample ;

[Tab( "Sonny Tab" )]
public class SonnyTab2
{
  [Panel( "Sonny Pannel 2" )]
  public class SonnyPannel2
  {
    [StackedButton( "Sonny Stacked Button 2" )]
    public class SonnySpitButton2
    {
      [Button( "Sonny Button 2-1",
        typeof( StartupCommand ),
        Image = "/EasyRibbonExample;component/Resources/Icons/RibbonIcon16.png",
        LargeImage = "/EasyRibbonExample;component/Resources/Icons/RibbonIcon32.png",
        LongDescription = "This is Test" )]
      public class SonnyButton1 ;

      [Button( "Sonny Button 2-2",
        typeof( StartupCommand ),
        Image = "/EasyRibbonExample;component/Resources/Icons/RibbonIcon16.png",
        LargeImage = "/EasyRibbonExample;component/Resources/Icons/RibbonIcon32.png",
        LongDescription = "This is Test" )]
      public class SonnyButton2 ;
    }

    [Button( "Sonny Button 2-3",
      typeof( StartupCommand ),
      Image = "/EasyRibbonExample;component/Resources/Icons/RibbonIcon16.png",
      LargeImage = "/EasyRibbonExample;component/Resources/Icons/RibbonIcon32.png",
      LongDescription = "This is Test" )]
    public class SonnyButton3 ;

    [Button( "Sonny Button 2-4",
      typeof( StartupCommand ),
      Image = "/EasyRibbonExample;component/Resources/Icons/RibbonIcon16.png",
      LargeImage = "/EasyRibbonExample;component/Resources/Icons/RibbonIcon32.png",
      LongDescription = "This is Test" )]
    public class SonnyButton4 ;
  }
}