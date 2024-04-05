using Microsoft.Web.WebView2.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfTestdotNetFW
{
    /// <summary>
    /// Interaction logic for WebViewControlComponent.xaml
    /// </summary>
    public partial class WebViewControlComponent : UserControl, IWebViewControlComponent
    {
        public WebViewControlComponent()
        {
            InitializeComponent();
            Application.Current.DispatcherUnhandledException += Current_DispatcherUnhandledException;
        }

        private void Current_DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            Console.Out.WriteLine("Current_DispatcherUnhandledException " + e.Exception.Message);
        }

        public object Context { get; set; }

        public void Create()
        {
            //InitializeAsync();
            //InitializeAsync2();
        }

        public void Destroy()
        {
            
        }

        async void InitializeAsync()
        {
            Console.Out.WriteLine("InitializeAsync");
            CoreWebView2EnvironmentOptions opt = new CoreWebView2EnvironmentOptions();
            opt.Language = "CZ";

            CoreWebView2Environment env = await CoreWebView2Environment.CreateAsync(null, null, opt);
            await webView.EnsureCoreWebView2Async(env);

            //webView.CoreWebView2.WebMessageReceived += WebView_WebMessageReceived;
            //webView.CoreWebView2.NavigationCompleted += CoreWebView2_NavigationCompleted;
            webView.CoreWebView2.Navigate("c:\\ProjectsDev\\VisualStudio\\Test\\WPFTest\\WPFTest\\webchatresource\\index.html");
            Console.Out.WriteLine("InitializeAsync done");
        }
        async void InitializeAsync2()
        {
            Console.Out.WriteLine("InitializeAsync2");
            CoreWebView2EnvironmentOptions opt = new CoreWebView2EnvironmentOptions();
            opt.Language = "CZ";

            CoreWebView2Environment env = await CoreWebView2Environment.CreateAsync(null, null, opt);
            await webView2.EnsureCoreWebView2Async(env);

            //webView.CoreWebView2.WebMessageReceived += WebView_WebMessageReceived;
            //webView.CoreWebView2.NavigationCompleted += CoreWebView2_NavigationCompleted;
            webView2.CoreWebView2.Navigate("c:\\ProjectsDev\\VisualStudio\\Test\\WPFTest\\WPFTest\\webchatresource\\index.html");
            Console.Out.WriteLine("InitializeAsync2 done");
        }

        private void webView2_Loaded(object sender, RoutedEventArgs e)
        {
            InitializeAsync2();
        }

        private void webView_Loaded(object sender, RoutedEventArgs e)
        {
            InitializeAsync();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (webView.Visibility == Visibility.Visible)
            {
                webView.Visibility = Visibility.Collapsed;
                rowView.Height = new GridLength(webView.MinHeight, GridUnitType.Pixel);
            }
            else
            {
                webView.Visibility = Visibility.Visible;
                rowView.Height = new GridLength(100, GridUnitType.Pixel);
            }
        }
    }
}
