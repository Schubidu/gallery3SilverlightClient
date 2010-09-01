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
using G3RestClient.Helper;
using System.Windows.Media.Imaging;
using System.IO;

namespace G3RestClient.Content
{
    public partial class G3Photo : UserControl
    {
        public ItemEntity Entity {get; set;}
        public double ImageDownload { get; set; }
        public BitmapImage ImageSource { get; set; }
        public G3Photo()
        {
            InitializeComponent();
        }
        public G3Photo(Helper.ItemEntity entity)
        {
            InitializeComponent();
            this.Entity = entity;
            this.DataContext = this;
            WebClient client = new WebClient();
            client.OpenReadCompleted += new OpenReadCompletedEventHandler(client_OpenReadCompleted);
            client.DownloadProgressChanged += new DownloadProgressChangedEventHandler(client_DownloadProgressChanged);
            client.OpenReadAsync(new Uri(entity.G3ImageUrl));
        }

        void client_OpenReadCompleted(object sender, OpenReadCompletedEventArgs e)
        {
            try
            {
                BitmapImage ImageToLoad = new BitmapImage();
                ImageToLoad.SetSource(e.Result as Stream);
                this.image1.Source = ImageToLoad;
            }
            catch (Exception)
            { }
        }

        void client_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            //this.ImageDownload = (double) e.ProgressPercentage;
        }

        private void Image_ImageFailed(object sender, ExceptionRoutedEventArgs e)
        {

        }
    }
}
