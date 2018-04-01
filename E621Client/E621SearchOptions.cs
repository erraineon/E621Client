namespace E621
{
    public class E621SearchOptions
    {
        public int Limit { get; set; }
        public long BeforeId { get; set; }
        public int Page { get; set; }
        public string Tags { get; set; }
        public bool TypedTags { get; set; }
    }
}