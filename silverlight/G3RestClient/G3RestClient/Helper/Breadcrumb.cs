using System.Collections.Generic;
using System;

namespace G3RestClient.Helper
{
    public class Breadcrumb : List<Content.BreadcrumbItem>
    {
        public List<BreadcrumbItem> ConvertToSettings
        {
            get {
                List<BreadcrumbItem> items = new List<BreadcrumbItem>();
                this.ForEach(delegate(Content.BreadcrumbItem item)
                {
                    items.Add(new BreadcrumbItem() {
                        Title = item.Title,
                        Uri = item.Uri
                    });
                });
                return items;
            }
        }
    }
}
