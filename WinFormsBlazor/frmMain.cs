using Microsoft.AspNetCore.Components.WebView.WindowsForms;
using Microsoft.Extensions.DependencyInjection;
using WinFormsBlazor.Data;

namespace WinFormsBlazor;

public partial class frmMain : Form
{
    public frmMain()
    {
        InitializeComponent();

        // Add BlazorWebView Component
        BlazorWebView blazorWebView = new BlazorWebView();
        blazorWebView.Dock = DockStyle.Fill;
        this.Controls.Add(blazorWebView);

        // Services Registration
        var services = new ServiceCollection();
        services.AddWindowsFormsBlazorWebView();
        services.AddSingleton<WeatherForecastService>();

        // Start App
        blazorWebView.HostPage = "wwwroot\\index.html";
        blazorWebView.Services = services.BuildServiceProvider();
        blazorWebView.RootComponents.Add<Main>("#app");
    }
}