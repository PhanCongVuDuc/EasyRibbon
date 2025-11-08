namespace EasyRibbon.UIAttributeBase.Base ;

[AttributeUsage( AttributeTargets.Class )]
public class UIAttributeBase( string name ) : Attribute
{
  public string Name { get ; } = name ;
}