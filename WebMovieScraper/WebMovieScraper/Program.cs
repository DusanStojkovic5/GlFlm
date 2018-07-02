using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebMovieScraper {
    class Program {
        static void Main(string[] args) {
            Scraper scraper = new Scraper();
            scraper.scrap("http://filmovi.eu/");
            Console.ReadKey();
        }
    }
}
