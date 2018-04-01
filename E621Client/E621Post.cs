using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace E621
{
    public class E621Post
    {
        public long Id { get; set; }

        [JsonConverter(typeof(TagsLookupConverter))]
        public ILookup<string, string> Tags { get; set; }

        [JsonConverter(typeof(TagsLookupConverter))]
        public ILookup<string, string> LockedTags { get; set; }

        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public long CreatorId { get; set; }
        public string Author { get; set; }
        public int Change { get; set; }
        public string Source { get; set; }
        public int Score { get; set; }
        public int FavCount { get; set; }
        public string Md5 { get; set; }
        public int FileSize { get; set; }
        public string FileUrl { get; set; }
        public string FileExt { get; set; }
        public string PreviewUrl { get; set; }
        public int PreviewWidth { get; set; }
        public int PreviewHeight { get; set; }
        public string SampleUrl { get; set; }
        public int SampleWidth { get; set; }
        public int SampleHeight { get; set; }
        public E621PostRating Rating { get; set; }
        public E621PostStatus Status { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public bool HasComments { get; set; }
        public bool HasNotes { get; set; }
        public bool HasChildren { get; set; }

        [JsonConverter(typeof(CommaSeparatedLongListConverter))]
        public IList<long> Children { get; set; }

        public long? ParentId { get; set; }

        [JsonProperty("artist")] public IList<string> Artists { get; set; }

        public IList<string> Sources { get; set; }
    }
}