using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Navigation;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace G3RestClient
{
    public partial class MainPage : UserControl
    {
        public MainPage()
        {
            InitializeComponent();
        }
        /// <summary>
        /// After the Frame navigates, ensure the <see cref="HyperlinkButton"/> representing the current page is selected
        /// </summary>
        private void ContentFrame_Navigated(object sender, NavigationEventArgs e)
        {
            HyperlinkButton hb = new HyperlinkButton();
            hb.NavigateUri = e.Uri;
            hb.TargetName = "ContentFrame";
            TextBlock tb = new TextBlock();
            tb.Text = e.Uri.ToString();
            hb.Content = tb;
            LinksStackPanel.Children.Insert(0, hb);
            //foreach (UIElement child in LinksStackPanel.Children)
            //{
            //    HyperlinkButton hb = child as HyperlinkButton;
            //    if (hb != null && hb.NavigateUri != null)
            //    {
            //        if (hb.NavigateUri.ToString().Equals(e.Uri.ToString()))
            //        {
            //            VisualStateManager.GoToState(hb, "ActiveLink", true);
            //        }
            //        else
            //        {
            //            VisualStateManager.GoToState(hb, "InactiveLink", true);
            //        }
            //    }
            //}
        }

        /// <summary>
        /// If an error occurs during navigation, show an error window
        /// </summary>
        private void ContentFrame_NavigationFailed(object sender, NavigationFailedEventArgs e)
        {
            e.Handled = true;
            //ErrorWindow.CreateNew(e.Exception);
        }

        private void ContentFrame_FragmentNavigation(object sender, FragmentNavigationEventArgs e)
        {

        }

    }
}
