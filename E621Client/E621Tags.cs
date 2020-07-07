using System.Collections.Generic;

namespace E621
{
    public class E621Tags
    {
        public List<string> General { get; set; }
        public List<string> Species { get; set; }
        public List<string> Character { get; set; }
        public List<string> Copyright { get; set; }
        public List<string> Artist { get; set; }
        public List<object> Invalid { get; set; }
        public List<object> Lore { get; set; }
        public List<string> Meta { get; set; }
    }
}