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
    public partial class BreadcrumbItem : UserControl
    {
        public BreadcrumbItem()
        {
            InitializeComponent();
            this.MouseEnter += new MouseEventHandler(BreadcrumbItem_MouseEnter);
            this.MouseLeave += new MouseEventHandler(BreadcrumbItem_MouseLeave);
        }

        void BreadcrumbItem_MouseLeave(object sender, MouseEventArgs e)
        {
            VisualStateManager.GoToState(this, "Base", true);
        }

        void BreadcrumbItem_MouseEnter(object sender, MouseEventArgs e)
        {
            VisualStateManager.GoToState(this, "MouseEnterState", true);
        }

        public static readonly DependencyProperty UriProperty = DependencyProperty.Register(
          "Uri",
          typeof(Uri),
          typeof(BreadcrumbItem),
          new PropertyMetadata(null,
              new PropertyChangedCallback(OnUriChanged)
          )
        );
        public Uri Uri
        {
            get { return (Uri)GetValue(UriProperty); }
            set { SetValue(UriProperty, value); }
        }
        private static void OnUriChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
        }

        public static readonly DependencyProperty TitleProperty = DependencyProperty.Register(
          "Title",
          typeof(string),
          typeof(BreadcrumbItem),
          new PropertyMetadata(null,
              new PropertyChangedCallback(OnTitleChanged)
          )
        );
        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }
        private static void OnTitleChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
        }

    }
}
