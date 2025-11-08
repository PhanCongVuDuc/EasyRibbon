namespace EasyRibbon.UIAttributeBase.Base ;

public interface IRibbonItem
{
  string Unique { get ; }
  string? Image { get ; set ; }
  string? LargeImage { get ; set ; }
  string? ToolTipImage { get ; set ; }
  string? LongDescription { get ; set ; }
  string? ToolTip { get ; set ; }
}