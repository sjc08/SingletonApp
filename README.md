This library allows you to create single instance applications.

## Getting started

Call the `SingletonApp.Check` method at an appropriate place. It will return a bool indicating whether the application is a new instance.

```c#
// WPF
protected override void OnStartup(StartupEventArgs e)
{
    base.OnStartup(e);

    if (!SingletonApp.Check())
        Shutdown();
}
```

Don't forget to call the `SingletonApp.Cleanup` method when the application is closed!

### Attention

**Do not** call the `SingletonApp.Check` method repeatedly. Use `SingletonApp.IsNew` instead, unless you are fully aware of what you are doing.

```csharp
bool result1 = SingletonApp.Check(); // True
bool result2 = SingletonApp.IsNew; // True
bool result3 = SingletonApp.Check(); // False
bool result4 = SingletonApp.IsNew; // False
```

