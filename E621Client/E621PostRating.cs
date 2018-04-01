using System.Runtime.Serialization;

namespace E621
{
    public enum E621PostRating
    {
        None,
        [EnumMember(Value = "s")] Safe,
        [EnumMember(Value = "q")] Questionable,
        [EnumMember(Value = "e")] Explicit
    }
}