using Landon.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Threading.Tasks;

namespace Demo.Async
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var webClient = new WebClient();
            var api = "http://localhost:5000/Countries";
            var watch = new Stopwatch();

            {
                // sync
                watch.Start();
                var json = webClient.DownloadString(api);
                Console.WriteLine("Sync ended : " + watch.ElapsedMilliseconds);
            }

            {
                // eap
                Console.ReadLine();
                watch.Restart();
                webClient.DownloadStringAsync(new Uri(api));
                Console.WriteLine("EAP ended : " + watch.ElapsedMilliseconds);
            }

            {
                // tap
                Console.ReadLine();
                watch.Restart();
                var json = await webClient.DownloadStringTaskAsync(new Uri(api));
                Console.WriteLine("TAP ended : " + watch.ElapsedMilliseconds);
                watch.Stop();

                var countries = JsonConvert.DeserializeObject<IEnumerable<Country>>(json);
            }
        }
    }
}
