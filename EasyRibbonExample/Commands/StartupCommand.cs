using System.Windows ;
using Autodesk.Revit.Attributes ;
using Nice3point.Revit.Toolkit.External ;

namespace EasyRibbonExample.Commands ;

/// <summary>
///     External command entry point
/// </summary>
[UsedImplicitly]
[Transaction( TransactionMode.Manual )]
public class StartupCommand : ExternalCommand
{
  public override void Execute()
  {
    MessageBox.Show("Hello Sonny");
  }
}