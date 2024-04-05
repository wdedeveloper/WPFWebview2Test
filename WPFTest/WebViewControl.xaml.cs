using Microsoft.Web.WebView2.Core;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPFTest
{
    /// <summary>
    /// Interaction logic for WebViewControl.xaml
    /// </summary>
    public partial class WebViewControl : UserControl
    {
        public WebViewControl()
        {
            InitializeComponent();
            InitializeAsync();
        }
        async void InitializeAsync()
        {
            Application.Current.Deactivated += Current_Deactivated;
            Application.Current.MainWindow.SizeChanged += MainWindow_SizeChanged;
            Application.Current.MainWindow.LocationChanged += MainWindow_LocationChanged;
            Application.Current.MainWindow.ManipulationCompleted += MainWindow_ManipulationCompleted;
            Application.Current.MainWindow.LostFocus += MainWindow_LostFocus;
            Application.Current.MainWindow.GotFocus += MainWindow_GotFocus;
            CoreWebView2EnvironmentOptions opt = new CoreWebView2EnvironmentOptions();
            opt.Language = "CZ";
            
            CoreWebView2Environment env = await CoreWebView2Environment.CreateAsync(null, null, opt);
            await webView.EnsureCoreWebView2Async(env);
            
            webView.CoreWebView2.WebMessageReceived += WebView_WebMessageReceived;
            webView.CoreWebView2.NavigationCompleted += CoreWebView2_NavigationCompleted;
            webView.CoreWebView2.Navigate("c:\\ProjectsDev\\VisualStudio\\Test\\WPFTest\\WPFTest\\webchatresource\\index.html");
            openPopup();
        }

        private void Current_Deactivated(object? sender, EventArgs e)
        {
            Trace.WriteLine("Current_Deactivated");
        }

        private void MainWindow_GotFocus(object sender, RoutedEventArgs e)
        {
            Trace.WriteLine("MainWindow_LostFocus");
            openPopup();
        }

        private void MainWindow_LostFocus(object sender, RoutedEventArgs e)
        {
            Trace.WriteLine("MainWindow_LostFocus");
            closePopup();
        }

        private void RedrawPopup()
        {
            double Offset = MyPopup.HorizontalOffset;
            MyPopup.HorizontalOffset = Offset + 1;
            MyPopup.HorizontalOffset = Offset;
        }
        private void MainWindow_ManipulationCompleted(object? sender, ManipulationCompletedEventArgs e)
        {
            Trace.WriteLine("MainWindow_ManipulationCompleted");
        }

        private void MainWindow_LocationChanged(object? sender, EventArgs e)
        {
            Trace.WriteLine("MainWindow_LocationChanged");
            RedrawPopup();
        }

        private void MainWindow_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            Trace.WriteLine("MainWindow_SizeChanged");
            RedrawPopup();
        }

        private void openPopup()
        {
            MyPopup.IsOpen = false;
            MyPopup.PlacementTarget = webView as UIElement;
            MyPopup.Placement = PlacementMode.Relative;
            MyPopup.HorizontalOffset = 0;
            MyPopup.VerticalOffset = 10;
            MyPopup.AllowsTransparency = true;
            MyPopup.PopupAnimation = PopupAnimation.Fade;
            MyPopup.IsOpen = true;
        }

        private void closePopup()
        {
            MyPopup.IsOpen = false;
        }

        private void WebView_WebMessageReceived(object? sender, CoreWebView2WebMessageReceivedEventArgs e)
        {

        }

        private void CoreWebView2_NavigationCompleted(object? sender, CoreWebView2NavigationCompletedEventArgs e)
        {
            FocusManager.SetFocusedElement(this, webView);
            //Keyboard.Focus(webView);
        }

        private void webView_GotFocus(object sender, RoutedEventArgs e)
        {
            Trace.WriteLine("GotFocus");
            //openPopup();
        }

        private void webView_LostFocus(object sender, RoutedEventArgs e)
        {
            Trace.WriteLine("LostFocus");
            //closePopup();
        }

        private void webView_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            Trace.WriteLine("GotKeyboardFocus");
        }

        private void webView_LostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            Trace.WriteLine("LostKeyboardFocus");
        }

        private void btn_Expand_Click(object sender, RoutedEventArgs e)
        {
            Trace.WriteLine("btn_Expand_Click");
        }

        private void webView_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            Trace.WriteLine("webView_SizeChanged");
        }

        private void webView_ManipulationStarted(object sender, ManipulationStartedEventArgs e)
        {
            Trace.WriteLine("webView_ManipulationStarted");
        }

        private void webView_ManipulationCompleted(object sender, ManipulationCompletedEventArgs e)
        {
            Trace.WriteLine("webView_ManipulationCompleted");
        }

        private void UserControl_ManipulationStarted(object sender, ManipulationStartedEventArgs e)
        {
            Trace.WriteLine("UserControl_ManipulationStarted");
        }

        private void UserControl_ManipulationCompleted(object sender, ManipulationCompletedEventArgs e)
        {
            Trace.WriteLine("UserControl_ManipulationCompleted");
        }

        private void UserControl_ManipulationDelta(object sender, ManipulationDeltaEventArgs e)
        {
            Trace.WriteLine("UserControl_ManipulationDelta");
        }
    }
}
