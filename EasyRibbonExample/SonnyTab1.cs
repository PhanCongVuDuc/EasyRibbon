using EasyRibbon.UIAttributeBase ;
using EasyRibbonExample.Commands ;

namespace EasyRibbonExample ;

[Tab("Sonny Tab")]
public class SonnyTab1
{
    [Panel("Sonny Pannel 1")]
    public class SonnyPannel1
    {
        [StackedButton("Sonny Stacked Button 1")]
        public class SonnySpitButton1
        {
            [Button("Sonny Button 1-1",
                typeof( StartupCommand ),
                Image = "/EasyRibbonExample;component/Resources/Icons/RibbonIcon16.png",
                LargeImage = "/EasyRibbonExample;component/Resources/Icons/RibbonIcon32.png",
                LongDescription = "This is Test",
                ToolTip = "This is toolTip",
                ToolTipImage = "/EasyRibbonExample;component/Resources/Icons/RibbonIcon32.png")]
            public class SonnyButton1 ;

            [Button("Sonny Button 1-2",
                typeof( StartupCommand ),
                Image = "/EasyRibbonExample;component/Resources/Icons/RibbonIcon16.png",
                LargeImage = "/EasyRibbonExample;component/Resources/Icons/RibbonIcon32.png",
                LongDescription = "This is Test")]
            public class SonnyButton12 ;
        }

        [Button("Sonny Button 1-3",
            typeof( StartupCommand ),
            Image = "/EasyRibbonExample;component/Resources/Icons/RibbonIcon16.png",
            LargeImage = "/EasyRibbonExample;component/Resources/Icons/RibbonIcon32.png",
            LongDescription = "This is Test",
            ToolTip = "This is toolTip",
            ToolTipImage = "/EasyRibbonExample;component/Resources/Icons/RibbonIcon32.png")]
        public class SonnyButton2 ;

        [Button("Sonny Button 1-4",
            typeof( StartupCommand ),
            Image = "/EasyRibbonExample;component/Resources/Icons/RibbonIcon16.png",
            LargeImage = "/EasyRibbonExample;component/Resources/Icons/RibbonIcon32.png",
            LongDescription = "This is Test")]
        public class SonnyButton3 ;
    }
}
