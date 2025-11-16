using Autodesk.Revit.UI ;

namespace EasyRibbon.Modules ;

/// <summary>
///     Interface for application modules that can be registered and initialized
/// </summary>
public interface IApplicationModule
{
    /// <summary>
    ///     Name of the module for identification and logging
    /// </summary>
    string ModuleName { get ; }

    /// <summary>
    ///     Called when the module is started
    /// </summary>
    /// <param name="application">The UIControlledApplication instance</param>
    void OnStartup(UIControlledApplication application) ;

    /// <summary>
    ///     Called when the module is shutdown (optional)
    /// </summary>
    /// <param name="application">The UIControlledApplication instance</param>
    void OnShutdown(UIControlledApplication application) ;
}
