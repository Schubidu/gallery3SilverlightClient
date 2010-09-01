﻿using System;
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
        private List<Content.BreadcrumbItem> bcItems;
        public MainPage()
        {
            InitializeComponent();
            bcItems = new List<Content.BreadcrumbItem>();
        }
        /// <summary>
        /// After the Frame navigates, ensure the <see cref="HyperlinkButton"/> representing the current page is selected
        /// </summary>
        private void ContentFrame_Navigated(object sender, NavigationEventArgs e)
        {
            Views.Item ChildFrame = e.Content as Views.Item;
            if(ChildFrame != null)
                ChildFrame.ItemDataLoad += new Views.Item.ItemDataLoadEvent(ChildFrame_ItemDataLoad);
        }

        private int currentLevel = 0;

        void ChildFrame_ItemDataLoad(object sender, Views.ItemDataEventArgs e)
        {
            Content.BreadcrumbItem bci = new Content.BreadcrumbItem()
            {
                Title = e.Title,
                Uri = e.Source
            };

            try {
                if (currentLevel < e.Level)
                {
                    LinksStackPanel.Children.Add(bci);
                }
                else if (currentLevel == e.Level) 
                {
                    LinksStackPanel.Children.Remove(LinksStackPanel.Children.Last());
                    LinksStackPanel.Children.Add(bci);
                }
                else if (currentLevel > e.Level)
                {
                    List<UIElement> links = LinksStackPanel.Children.ToList<UIElement>();
                    LinksStackPanel.Children.Clear();
                    int i = 0;
                    links.ForEach(delegate(UIElement element)
                    {
                        if (i < e.Level) {
                            LinksStackPanel.Children.Add(element);
                        }
                        i++;
                    });
                }

                currentLevel = e.Level;
               


            }
            catch (ArgumentException ex) { }
            catch (Exception ex) { }
            LayoutRoot.IsBusy = false;
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
            LayoutRoot.IsBusy = false;
        }

        private void ContentFrame_Navigating(object sender, NavigatingCancelEventArgs e)
        {
            LayoutRoot.IsBusy = true;

        }

    }
}
