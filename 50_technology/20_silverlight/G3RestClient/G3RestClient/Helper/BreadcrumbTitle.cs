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
using System.Collections.Generic;

namespace G3RestClient.Helper
{
    public class BreadcrumbTitle : List<string>
    {
        public override string ToString()
        {
            string t = "";
            int i = 0;
            if (this != null)
            {
                this.ForEach(delegate(string title)
                {
                    t += ((i != 0) ? " - " : "")  + title;
                    i++;
                });
            }
            return t;
        }
    }
}
