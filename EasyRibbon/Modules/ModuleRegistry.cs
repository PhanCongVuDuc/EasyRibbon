using Autodesk.Revit.UI ;

namespace EasyRibbon.Modules ;

/// <summary>
/// Registry for managing application modules
/// </summary>
public class ModuleRegistry
{
  private readonly List<IApplicationModule> _modules = new List<IApplicationModule>() ;

  /// <summary>
  /// Register a module to be initialized
  /// </summary>
  /// <typeparam name="T">Module type that implements IApplicationModule</typeparam>
  public void RegisterModule<T>() where T : IApplicationModule, new()
  {
    var module = new T() ;
    _modules.Add( module ) ;
  }

  /// <summary>
  /// Register a module instance
  /// </summary>
  /// <param name="module">The module instance to register</param>
  public void RegisterModule( IApplicationModule module )
  {
    _modules.Add( module ) ;
  }

  /// <summary>
  /// Initialize all registered modules
  /// </summary>
  /// <param name="application">The UIControlledApplication instance</param>
  public void InitializeAll( UIControlledApplication application )
  {
    foreach ( var module in _modules ) {
      try {
        module.OnStartup( application ) ;
      }
      catch ( Exception ex ) {
        // Log error but continue with other modules
        System.Diagnostics.Debug.WriteLine( $"Failed to initialize module '{module.ModuleName}': {ex.Message}" ) ;
      }
    }
  }

  /// <summary>
  /// Shutdown all registered modules
  /// </summary>
  /// <param name="application">The UIControlledApplication instance</param>
  public void ShutdownAll( UIControlledApplication application )
  {
    foreach ( var module in _modules ) {
      try {
        module.OnShutdown( application ) ;
      }
      catch ( Exception ex ) {
        // Log error but continue with other modules
        System.Diagnostics.Debug.WriteLine( $"Failed to shutdown module '{module.ModuleName}': {ex.Message}" ) ;
      }
    }
  }

  /// <summary>
  /// Get all registered modules
  /// </summary>
  public IReadOnlyList<IApplicationModule> GetModules() => _modules.AsReadOnly() ;
}