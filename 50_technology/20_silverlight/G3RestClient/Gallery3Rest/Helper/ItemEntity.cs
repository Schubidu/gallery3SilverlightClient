using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gallery3Rest.Helper
{
    public class ItemEntity
    {
        public Int32 Id { get; set; }
        public string Type { get; set; }
        public Int32 Captured { get; set; }
        public string Description { get; set; }
        public Int32 Height { get; set; }
        public Int32 Level { get; set; }
        public string MimeType { get; set; }
        public string Name { get; set; }
        public Int32 OwnerId { get; set; }
        public float RandKey { get; set; }
        public Int32 ResizeHeight { get; set; }
        public Int32 ResizeWidth { get; set; }
        public string Slug { get; set; }
        public string SortColumn { get; set; }
        public string SortOrder { get; set; }
        public Int32 ThumbHeight { get; set; }
        public Int32 ThumbWidth { get; set; }
        public string Title { get; set; }
        public Int32 Updated { get; set; }
        public Int32 ViewCount { get; set; }
        public Int32 Width { get; set; }
        public Int32 View1 { get; set; }
        public Int32 View2 { get; set; }
        public Int32 View3 { get; set; }
        public Int32 View4 { get; set; }
        public Int32 View5 { get; set; }
        public string AlbumCover { get; set; }
        public string ThumbUrl { get; set; }
        public Boolean CanEdit { get; set; }
        public string Parent { get; set; }
        public string ResizeUrl { get; set; }
        public ItemRelationships Relationships { get; set; }

        private string _G3Url = "";
        public string G3Url {
            get {
                return "Item/" + this.Id.ToString();
            }
        }
    }
}
