using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using DiagramEditor.Models.Serializers;
using DiagramEditor.ViewModels;
using DiagramEditor.Views;

namespace DiagramEditor
{
    public partial class App : Application
    {
        public override void Initialize()
        {
            AvaloniaXamlLoader.Load(this);
        }

        public override void OnFrameworkInitializationCompleted()
        {
            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                desktop.MainWindow = new MainWindow
                {
                    DataContext = new MainWindowViewModel()
                    {
                        SaverLoaderFactoryCollection = new ISaverLoaderFactory[]
                        {
                            new XMLSaverLoaderFactory(),
                            new JSONSaverLoaderFactory(),
                            new YAMLSaverLoaderFactory(),
                        }
                    }
                };
            }

            base.OnFrameworkInitializationCompleted();
        }
    }
}
