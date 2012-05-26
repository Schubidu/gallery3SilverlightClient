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
using System.Windows.Navigation;
using G3RestClient.Helper;
using G3RestClient.Content;
using RestSharp;

namespace G3RestClient.Views
{
    public partial class Item : Page
    {
        public delegate void ItemDataLoadEvent(Object sender, ItemDataEventArgs e);
        public event ItemDataLoadEvent ItemDataLoad;

        public Item()
        {
            InitializeComponent();
        }

        // Executes when the user navigates to this page.
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            string itemId;
            if (this.NavigationContext.QueryString.ContainsKey("ItemId"))
            {
                itemId = this.NavigationContext.QueryString["ItemId"];
            }
            else
            {
                //itemId = App.Current.Resources["FeaturedItemId"].ToString();
                itemId = "1";
            }

           var client = new RestClient("http://bilder.schultstefan.de/index.php/rest/");
           var request = new RestRequest("item/{itemId}", Method.GET);
           request.AddUrlSegment("itemId", itemId);
           client.ExecuteAsync<Helper.Item>(request, (response) =>
           {
               var resource = response.Data;
               Dispatcher.BeginInvoke(() => this.OnItemDataLoaded(resource));
           });
        }

        protected virtual void OnItemDataLoaded(Helper.Item item)
        {
            if (item != null) {
                LayoutRoot.Children.Clear();
                this.Title = item.Entity.Title;
                if(item.Entity.Type.Equals("album")){
                    G3Album album = new G3Album();
                    List<G3Item> items = new List<G3Item>();
                    item.Members.ForEach(delegate(string member)
                    {
                        items.Add(new G3Item(member));
                    });
                    album.Items = items;
                    LayoutRoot.Children.Add(album);
                }
                else if (item.Entity.Type.Equals("photo")) {
                    LayoutRoot.Children.Add(new Content.G3Photo(item.Entity));
                }
                ItemDataEventArgs itemDataEventArgs = new ItemDataEventArgs(item.Entity, this.NavigationService.Source);
                this.ItemDataLoad(this, itemDataEventArgs);
            }
        }
    }
}
