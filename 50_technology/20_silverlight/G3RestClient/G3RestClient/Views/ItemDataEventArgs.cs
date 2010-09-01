using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace G3RestClient.Views
{
    public class ItemDataEventArgs : EventArgs
    {
        private double angle;
        private Helper.ItemEntity item;
        private Uri source;

        public ItemDataEventArgs(Helper.ItemEntity item, Uri source)
        {
            this.item = item;
            this.source = source;
        }

        public string Title
        {
            get
            {
                return item.Title;
            }
        }

        public Uri Source
        {
            get
            {
                return this.source;
            }
        }
    
        public int Level {
            get 
            {
                return this.item.Level;
            }
        }
    }
}
