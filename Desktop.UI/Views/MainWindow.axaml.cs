using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Remotely.Desktop.Shared;
using Microsoft.Extensions.DependencyInjection;

namespace Remotely.Desktop.UI.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        if (!Design.IsDesignMode)
        {
            DataContext = StaticServiceProvider.Instance?.GetService<IMainWindowViewModel>();
        }

        InitializeComponent();
    }

    /// <summary>
    /// Intercept close to hide instead. This keeps the app running
    /// silently in the background with SignalR connection alive.
    /// </summary>
    protected override void OnClosing(WindowClosingEventArgs e)
    {
        e.Cancel = true;
        this.Hide();
    }
}
