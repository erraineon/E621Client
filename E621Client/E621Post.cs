using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace E621
{
    public class E621Post
    {
        public long Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public E621File File { get; set; }
        public E621Preview Preview { get; set; }
        public E621Preview Sample { get; set; }
        public E621Score Score { get; set; }
        public E621Tags Tags { get; set; }
        public List<string> LockedTags { get; set; }

        [JsonProperty("change_seq")] public int ChangeSequence { get; set; }

        public E621Flags Flags { get; set; }
        public string Rating { get; set; }
        public int FavCount { get; set; }
        public List<string> Sources { get; set; }
        public E621Relationships Relationships { get; set; }
        public int? ApproverId { get; set; }
        public int UploaderId { get; set; }
        public string Description { get; set; }
        public int CommentCount { get; set; }
        public bool IsFavorited { get; set; }
        public bool HasNotes { get; set; }
    }
}