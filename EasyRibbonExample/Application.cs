using Nice3point.Revit.Toolkit.External ;

namespace EasyRibbonExample ;

/// <summary>
///     Application entry point for standalone debugging
/// </summary>
[UsedImplicitly]
public class Application : ExternalApplication
{
    private readonly ExampleModule _module = new() ;

    public override void OnStartup() =>
        // Initialize module
        _module.OnStartup(Application) ;

    public override void OnShutdown() =>
        // Shutdown module
        _module.OnShutdown(Application) ;
}
