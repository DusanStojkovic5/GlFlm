using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace WebMovieScraper {
    class Scraper {
        private List<string> hyperlinks = new List<string>();
        private HtmlWeb web = new HtmlWeb();

        public void scrap(string url) {
            hyperlinks.AddRange(grabAllLinks(url));

            List<string> grabed_links = new List<string>();
            while (hyperlinks.Count > 0) {
                int rem_links = 0;
                foreach (string link in hyperlinks) {
                    grabed_links.AddRange(grabAllLinks(link));
                    Console.WriteLine("[L " + (hyperlinks.Count - rem_links) + " ] " + link);
                    rem_links++;
                }
                hyperlinks.Clear();
                hyperlinks.AddRange(grabed_links);
                grabed_links.Clear();
            }
        }

        private List<string> grabAllLinks(string url) {
            List<string> links = new List<string>();
            HtmlDocument doc = web.Load(url);
            List<HtmlNode> nodes = doc.DocumentNode.SelectNodes("//a[@href]").ToList();
            foreach (HtmlNode node in nodes) {
                HtmlAttribute attrib = node.Attributes["href"];
                if (attrib.Value.StartsWith(url))
                    links.Add(attrib.Value);
            }
            return links.Distinct().ToList();
        }
    }
}
