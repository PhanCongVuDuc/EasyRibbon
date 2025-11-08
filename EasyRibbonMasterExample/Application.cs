using EasyRibbon.Modules ;
using EasyRibbonExample ;
using Nice3point.Revit.Toolkit.External ;

namespace EasyRibbonMasterExample ;

/// <summary>
/// Master application example that manages multiple modules
/// This is an example of how to create a master application that loads multiple modules
/// 
/// Usage:
/// 1. Create a new project for your Master Application
/// 2. Reference all module projects (EasyRibbonExample, BimSpeedModule, etc.)
/// 3. Copy this code and register all your modules
/// 4. Update your .addin file to point to this MasterApplication
/// </summary>
public class Application : ExternalApplication
{
  private readonly ModuleRegistry _moduleRegistry = new ModuleRegistry() ;

  public override void OnStartup()
  {
    // Register all modules
    RegisterModules() ;

    // Initialize all registered modules
    _moduleRegistry.InitializeAll( Application ) ;
  }

  public override void OnShutdown()
  {
    // Shutdown all modules
    _moduleRegistry.ShutdownAll( Application ) ;
  }

  private void RegisterModules()
  {
    // Register modules using generic method
    _moduleRegistry.RegisterModule<ExampleModule>() ;
  }
}