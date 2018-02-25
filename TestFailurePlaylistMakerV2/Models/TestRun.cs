using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace TestFailurePlaylistMakerV2.Models
{
    public class TestRun
    {
        public IEnumerable<Test> Tests { get; set; }
    }

    public static class TestRunExtensions
    {
        public static XDocument ToXml(this TestRun run)
        {
            return new XDocument();
        }
    }

}
