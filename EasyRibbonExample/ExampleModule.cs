using System.Windows ;
using Autodesk.Revit.UI ;
using EasyRibbon ;
using EasyRibbon.Modules ;

namespace EasyRibbonExample ;

/// <summary>
///     Example module for demonstration
/// </summary>
public class ExampleModule : IApplicationModule
{
    public string ModuleName => "Example EasyRibbon Module" ;

    public void OnStartup(UIControlledApplication application)
    {
        // Load ResourceDictionary for resource-based names
        LoadResourceDictionary() ;

        // Create ribbon UI
        CreateUIApp.CreateUI<SonnyTab1>(application) ;
        CreateUIApp.CreateUI<SonnyTab2>(application) ;
        CreateUIApp.CreateUI<SonnyTab3>(application) ;
        CreateUIApp.CreateUI<SonnyTab4>(application) ;
    }

    public void OnShutdown(UIControlledApplication application)
    {
        // Cleanup if needed (optional)
        // For example: dispose resources, save settings, etc.
    }

    private static void LoadResourceDictionary()
    {
        // Ensure Application.Current exists (Revit usually initializes it, but create if needed)
        if (System.Windows.Application.Current == null)
        {
            new System.Windows.Application { ShutdownMode = ShutdownMode.OnExplicitShutdown } ;
        }

        if (System.Windows.Application.Current == null)
        {
            return ;
        }

        ResourceDictionary resourceDictionary = new()
        {
            Source = new Uri("/EasyRibbonExample;component/Resources/Strings.xaml",
                UriKind.RelativeOrAbsolute)
        } ;

        System.Windows.Application.Current.Resources.MergedDictionaries.Add(resourceDictionary) ;
    }
}
