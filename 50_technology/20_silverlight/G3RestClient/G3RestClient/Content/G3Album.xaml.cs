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
        private List<G3Item> items;

        public G3Album()
        {
            InitializeComponent();
        }

        public G3Album(List<G3Item> items):this()
        {
            // TODO: Complete member initialization
            this.items = items;
            this.items.ForEach(delegate(G3Item item)
            {
                PanelWrapper.Children.Add(item);
            });
        }
    }
}
