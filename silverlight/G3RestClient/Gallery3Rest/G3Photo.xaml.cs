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

namespace Gallery3Rest
{
    public partial class G3Photo : UserControl, IG3Item
    {
        public G3Photo()
        {
            InitializeComponent();
        }

        public int Id
        {
            get;
            set;
        }

        public string Title
        {
            get;
            set;
        }

        public DateTime Created
        {
            get;
            set;
        }

        public DateTime Captured
        {
            get;
            set;
        }

        public int OwnerId
        {
            get;
            set;
        }

        public string Slug
        {
            get;
            set;
        }

        public SortColumn SortColumn
        {
            get;
            set;
        }

        public SortOrder SortOrder
        {
            get;
            set;
        }

        public bool CanEdit
        {
            get;
            set;
        }

        public Uri AlbumCover
        {
            get;
            set;
        }

        public Uri ThumbUrl
        {
            get;
            set;
        }

        public int ViewCount
        {
            get;
            set;
        }

        public new Uri Parent
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public int Level
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }
    }
}
