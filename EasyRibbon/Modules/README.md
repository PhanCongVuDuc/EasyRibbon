# Module System

This module system allows you to organize multiple Revit add-ins into independent modules that can be loaded together or separately.

## Architecture

### IApplicationModule Interface
All modules must implement the `IApplicationModule` interface:

```csharp
public interface IApplicationModule
{
    string ModuleName { get; }
    void OnStartup(UIControlledApplication application);
    void OnShutdown(UIControlledApplication application);
}
```

### ModuleRegistry
Central registry for managing and initializing modules.

## Usage

### 1. Create a Module

```csharp
public class MyModule : IApplicationModule
{
    public string ModuleName => "My Custom Module";
    
    public void OnStartup(UIControlledApplication application)
    {
        // Initialize your ribbon UI
        CreateUIApp.CreateUI<MyTab>(application);
    }
    
    public void OnShutdown(UIControlledApplication application)
    {
        // Cleanup if needed
    }
}
```

### 2. Standalone Application (for debugging)

Each module can have its own Application class for debugging:

```csharp
public class Application : ExternalApplication
{
    private readonly MyModule _module = new MyModule();
    
    public override void OnStartup()
    {
        _module.OnStartup(Application);
    }
    
    public override void OnShutdown()
    {
        _module.OnShutdown(Application);
    }
}
```

### 3. Master Application (load all modules)

Create a master application that loads all modules:

```csharp
public class MasterApplication : ExternalApplication
{
    private readonly ModuleRegistry _moduleRegistry = new ModuleRegistry();
    
    public override void OnStartup()
    {
        // Register modules
        _moduleRegistry.RegisterModule<Module1>();
        _moduleRegistry.RegisterModule<Module2>();
        _moduleRegistry.RegisterModule<Module3>();
        
        // Initialize all
        _moduleRegistry.InitializeAll(Application);
    }
    
    public override void OnShutdown()
    {
        _moduleRegistry.ShutdownAll(Application);
    }
}
```

## Benefits

✅ **Separation of Concerns**: Each module is independent  
✅ **Easy Testing**: Debug individual modules separately  
✅ **Flexible Deployment**: Load all modules or specific ones  
✅ **Clean Code**: Clear structure and organization  
✅ **Error Isolation**: One module failure doesn't affect others  

## Project Structure

```
YourSolution/
├── EasyRibbon/              (Core library with Module system)
│   └── Modules/
│       ├── IApplicationModule.cs
│       └── ModuleRegistry.cs
├── Module1/                 (Independent module)
│   ├── Module1Class.cs
│   ├── Application.cs       (for debugging)
│   └── Module1.addin
├── Module2/                 (Independent module)
│   ├── Module2Class.cs
│   ├── Application.cs       (for debugging)
│   └── Module2.addin
└── MasterApp/              (Master application)
    ├── MasterApplication.cs
    └── MasterApplication.addin
```

## Example

See `ExampleEasyRibbon` project for a complete working example.

