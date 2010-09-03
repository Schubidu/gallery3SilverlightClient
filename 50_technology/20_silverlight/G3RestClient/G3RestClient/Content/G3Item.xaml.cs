using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using RestSharp;

namespace G3RestClient.Content
{
    public partial class G3Item : UserControl
    {
        public string Title { get; set; }
        public G3Item()
        {
            InitializeComponent();
            this.MouseEnter += new MouseEventHandler(G3Item_MouseEnter);
            this.MouseLeave += new MouseEventHandler(G3Item_MouseLeave);
        }

        void G3Item_MouseLeave(object sender, MouseEventArgs e)
        {
            VisualStateManager.GoToState(this, "MouseLeaveState", true);
        }

        void G3Item_MouseEnter(object sender, MouseEventArgs e)
        {
            VisualStateManager.GoToState(this, "MouseEnterState", true);
        }
        public G3Item(string itemUrl):this()
        {
            this.Title = itemUrl;
            //this.DataContext = this;
            var client = new RestClient(itemUrl);
            var request = new RestRequest(Method.GET);
            //request.AddHeader("X-Gallery-Request-Metho: get", "");
            //request.AddHeader("X-Gallery-Request-Key: d4bbbfdecc2fe3f3d39c0f638347fe5b", "");
            client.ExecuteAsync<Helper.Item>(request, (response) =>
            {
                var resource = response.Data;
                Dispatcher.BeginInvoke(() => this.OnItemDataLoaded(resource));
            });
        }

        private void OnItemDataLoaded(Helper.Item resource)
        {
            this.DataContext = resource.Entity;
        }
    }
}
