using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using TestFailurePlaylistMakerV2.Models;

namespace TestFailurePlaylistMakerV2.Parsers
{
    public static class XmlParser
    {
        public static XmlDocument CreatePlaylist(XDocument trxAsXml)
        {
            XNamespace ns = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010";
            var failedTestIds = (from t in trxAsXml.Descendants(ns + "UnitTestResult")
                              where t.Attribute("outcome").Value == "Failed"
                              select t.Attribute("testId").Value).ToList();

            var failedTestPaths = (from td in trxAsXml.Descendants(ns + "UnitTest")
                                   where failedTestIds.Contains(td.Attribute("id").Value)
                                   select $"{td.Descendants(ns + "TestMethod").First().Attribute("className").Value}.{td.Attribute("name").Value}");

            XmlDocument playlist = new XmlDocument();
            XmlElement element = (XmlElement)playlist.AppendChild(playlist.CreateElement("Playlist"));
            element.SetAttribute("Version", "1.0");

            foreach(var test in failedTestPaths)
            {
                XmlElement testToAdd = playlist.CreateElement("Add");
                testToAdd.SetAttribute("Test", test);
                element.AppendChild(testToAdd);
            }
            
            return playlist;
        }


    }
}
