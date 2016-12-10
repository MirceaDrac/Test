using epguides;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net;

namespace Part2
{
    class Program
    {
        static void Main(string[] args)
        {
            string show = args.Length > 0 ? args[0] : "bigbangtheory";

            try
            {
                using (var client = new WebClient())
                {
                    var json = client.DownloadString($"http://epguides.frecar.no/show/{show}/next");
                    var serializer = new JsonSerializer();
                    Next next = JsonConvert.DeserializeObject<Next>(json);
                    Console.WriteLine($"Title:{next.Episode.Title} release date:{next.Episode.ReleaseDate}");

                    json = client.DownloadString($"http://epguides.frecar.no/show/{show}");
                    JObject modelO = (JObject)JsonConvert.DeserializeObject(json);
                    var seasons = modelO.Children();
                    List<Episode> episodes = new List<Episode>();
                    foreach (var season in seasons)
                    {
                        episodes.AddRange(season.First.ToObject<Episode[]>());
                    }

                    var episodesAired = episodes.FindAll(e => DateTime.Parse(e.ReleaseDate) <= DateTime.Now).Count;
                    var episodesLeft = episodes.Count - episodesAired;
                    Console.WriteLine($"Aired:{episodesAired} remaining:{episodesLeft}");

                    Console.ReadKey();
                }
            }
            catch (WebException wEx)
            {
                Console.WriteLine($"Exception:{wEx.Message}");
            }
        }
    }
}
