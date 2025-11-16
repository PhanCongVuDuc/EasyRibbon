using System.Windows.Media.Imaging ;
using Autodesk.Revit.UI ;
using EasyRibbon.Extensions ;
using EasyRibbon.UIAttributeBase.Base ;

namespace EasyRibbon.UIAttributeBase ;

public class ButtonAttribute(string name, Type commandType) : Base.UIAttributeBase(name), IRibbonItem
{
    private Type CommandType { get ; } = commandType ;

    private string ClassName =>
        CommandType.FullName ?? throw new InvalidOperationException("Command type must have a FullName") ;

    private string AssemblyPath => CommandType.Assembly.Location ;
    public string? ToolTipKey { get ; set ; }
    public string? ToolTip { get ; set ; }

    public string Unique =>
        ResolveName()
            .RemoveWhitespace() ;

    public string? ToolTipDefault { get ; set ; }
    public string? Image { get ; set ; }
    public string? LargeImage { get ; set ; }
    public string? ToolTipImage { get ; set ; }
    public string? LongDescription { get ; set ; }

    public PushButtonData CreatePushButtonData()
    {
        string displayName = ResolveName() ;

        PushButtonData buttonData = new(Unique,
            displayName,
            AssemblyPath,
            ClassName) ;

        // Set Image (16x16)
        BitmapImage? image = ImageExtension.TryCreateBitmapImage(Image) ;
        if (image != null)
        {
            buttonData.Image = image ;
        }

        // Set LargeImage (32x32)
        BitmapImage? largeImage = ImageExtension.TryCreateBitmapImage(LargeImage) ;
        if (largeImage != null)
        {
            buttonData.LargeImage = largeImage ;
        }

        // Set ToolTipImage
        BitmapImage? toolTipImage = ImageExtension.TryCreateBitmapImage(ToolTipImage) ;
        if (toolTipImage != null)
        {
            buttonData.ToolTipImage = toolTipImage ;
        }

        if (! string.IsNullOrEmpty(LongDescription))
        {
            buttonData.LongDescription = LongDescription ;
        }

        // Resolve ToolTip from ToolTipKey or use ToolTipDefault
        string? tooltip = GetResourceStringOrDefault(ToolTipKey,
            ToolTipDefault) ;
        if (! string.IsNullOrEmpty(tooltip))
        {
            buttonData.ToolTip = tooltip ;
        }

        return buttonData ;
    }
}
