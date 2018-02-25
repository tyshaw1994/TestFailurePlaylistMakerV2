using System;

namespace TestFailurePlaylistMakerV2.Models
{
    public class Test
    {
        public string ClassName { get; set; }
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Outcome { get; set; }
    }
}