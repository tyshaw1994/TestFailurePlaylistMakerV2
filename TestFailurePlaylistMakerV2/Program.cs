using System;
using System.IO;
using System.Xml;
using System.Xml.Linq;
using TestFailurePlaylistMakerV2.Parsers;

namespace TestFailurePlaylistMakerV2
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            // arg1: path to TRX file
            // arg2: name of output playlist.xml file
            if (File.Exists(string.Concat(Directory.GetCurrentDirectory(), args[0])))
            {
                Console.WriteLine($"Input TRX file did not exist or was not valid: ");
                Environment.Exit(-1);
            }
            XDocument trxAsXml = XDocument.Load(args[0]);
            var playlist = XmlParser.CreatePlaylist(trxAsXml);
            var filename = (args[1].Contains(".playlist")) ? args[1] : $"{args[1]}.playlist";
            playlist.Save(filename);
            Console.WriteLine("Operation Successful.");
        }
    }
}