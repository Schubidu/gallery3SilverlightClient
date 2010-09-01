using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gallery3Rest
{
    public interface IG3Item
    {
        int Id
        {
            get;
            set;
        }

        string Name
        {
            get;
            set;
        }

        string Title
        {
            get;
            set;
        }

        DateTime Created
        {
            get;
            set;
        }

        DateTime Captured
        {
            get;
            set;
        }

        int OwnerId
        {
            get;
            set;
        }

        string Slug
        {
            get;
            set;
        }

        SortColumn SortColumn
        {
            get;
            set;
        }

        SortOrder SortOrder
        {
            get;
            set;
        }

        Boolean CanEdit
        {
            get;
            set;
        }

        Uri AlbumCover
        {
            get;
            set;
        }

        Uri ThumbUrl
        {
            get;
            set;
        }

        int ViewCount
        {
            get;
            set;
        }

        Uri Parent
        {
            get;
            set;
        }

        int Level
        {
            get;
            set;
        }
    }
}
