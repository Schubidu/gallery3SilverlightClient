namespace BusinessApplication1
{
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Navigation;
    using BusinessApplication1.LoginUI;
    using System;
    using System.Net;
    using System.IO;
    using RestSharp;
    using Gallery3Rest;
    using Gallery3Rest.Helper;

    /// <summary>
    /// <see cref="UserControl"/> class providing the main UI for the application.
    /// </summary>
    public partial class MainPage : UserControl
    {
        /// <summary>
        /// Creates a new <see cref="MainPage"/> instance.
        /// </summary>
        public MainPage()
        {
            InitializeComponent();
            this.loginContainer.Child = new LoginStatus();
            var client = new RestClient("http://bilder.schultstefan.de/index.php/rest/");
           var request = new RestRequest("item/{itemId}", Method.GET);
           //request.AddUrlSegment("itemId", "515");


           client.ExecuteAsync<Item>(request, (response) =>
           {
               var resource = response.Data;
           });
        }

        /// <summary>
        /// After the Frame navigates, ensure the <see cref="HyperlinkButton"/> representing the current page is selected
        /// </summary>
        private void ContentFrame_Navigated(object sender, NavigationEventArgs e)
        {
            HyperlinkButton hb = new HyperlinkButton();
           
            LinksStackPanel.Children.Add(hb);
        }

        /// <summary>
        /// If an error occurs during navigation, show an error window
        /// </summary>
        private void ContentFrame_NavigationFailed(object sender, NavigationFailedEventArgs e)
        {
            e.Handled = true;
            ErrorWindow.CreateNew(e.Exception);
        }
    }
}