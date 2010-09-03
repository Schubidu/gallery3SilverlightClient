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

namespace G3RestClient.Content
{
    public partial class G3Album : UserControl
    {
 
        public static readonly DependencyProperty ItemsProperty = DependencyProperty.Register(
            "List<G3Item>",
            typeof(List<G3Item>),
            typeof(G3Album),
            new PropertyMetadata(null,
                new PropertyChangedCallback(OnItemsChanged)
            )
        );
        public List<G3Item> Items
        {
            get { return (List<G3Item>)GetValue(ItemsProperty); }
            set { SetValue(ItemsProperty, value); }
        }
        private static void OnItemsChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            G3Album album = (d as G3Album);
            album.PanelWrapper.Children.Clear();
            album.Items.ForEach(delegate(G3Item item)
            {
                try { album.PanelWrapper.Children.Add(item); }
                catch (Exception ex) { 
                    
                }
            });
        }


        
        public G3Album()
        {
            InitializeComponent();
        }

        public G3Album(List<G3Item> items):this()
        {
            this.Items = items;
        }
    }
}
